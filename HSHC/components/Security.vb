'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( sales@perpetualmotion.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web

Namespace PortalQH

    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' The SecurityAccessLevel enum is used to determine which level of access rights
    ''' to assign to a specific module or module action. 
    ''' </summary>
    '''-----------------------------------------------------------------------------
    Public Enum SecurityAccessLevel As Integer
        SkinObject = -2
        Anonymous = -1
        View = 0
        Edit = 1
        Admin = 2
        Host = 3
    End Enum

    Public Class PortalSecurity


        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' The FilterFlag enum determines which filters are applied by the InputFilter
        ''' function.  The Flags attribute allows the user to include multiple 
        ''' enumerated values in a single variable by OR'ing the individual values
        ''' together.
        ''' </summary>
        ''' <history>
        ''' 	[Joe Brinkman] 	8/15/2003	Created  Bug #000120, #000121
        ''' </history>
        '''-----------------------------------------------------------------------------
        <FlagsAttribute()> _
        Enum FilterFlag
            MultiLine = 1
            NoMarkup = 2
            NoScripting = 4
            NoSQL = 8
        End Enum

        Public Function UserLogin(ByVal Username As String, ByVal Password As String, ByVal PortalID As Integer) As String

            Dim dr As IDataReader

            Dim SuperUserId As String = ""
            dr = DataProvider.Instance().GetPortal(PortalID)
            If dr.Read Then
                SuperUserId = CType(dr("SuperUserId"), String)
            End If
            dr.Close()

            Dim EncryptionKey As String = ""
            dr = DataProvider.Instance().GetHostSetting("EncryptionKey")
            If dr.Read Then
                EncryptionKey = dr("SettingValue").ToString
            End If
            dr.Close()

            ' validate user
            Dim UserId As String = ""
            dr = DataProvider.Instance().UserLogin(Username, Encrypt(Password))

            If dr.Read Then
                If Not IsDBNull(dr("UserId")) Then
                    UserId = CType(dr("UserId"), String)
                End If
            End If
            dr.Close()

            If UserId <> "" Then
                If UserId <> SuperUserId Then
                    ' validate user in portal
                    dr = DataProvider.Instance().GetPortalUser(PortalID, UserId)
                    UserId = ""
                    If dr.Read Then
                        If Convert.ToBoolean(dr("Authorized")) Then
                            UserId = CType(dr("UserId"), String)
                        End If
                    End If
                    dr.Close()

                    ' update last login
                    If UserId <> "" Then
                        DataProvider.Instance().UpdatePortalUser(PortalID, UserId, True, Now)
                    End If
                End If
            End If

            UserLogin = UserId
            'lay username
            'GlobalQLDA.UserName = Username

        End Function


        Public Shared Function IsInRole(ByVal role As String) As Boolean

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If HttpContext.Current.User.Identity.Name = _portalSettings.SuperUserId.ToString Then
                Return True
            Else
                Return HttpContext.Current.User.IsInRole(role)
            End If

        End Function


        Public Shared Function IsInRoles(ByVal roles As String) As Boolean

            If Not roles Is Nothing Then
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim context As HttpContext = HttpContext.Current

                Dim role As String
                For Each role In roles.Split(New Char() {";"c})

                    If role <> "" And Not role Is Nothing And _
                        ((context.Request.IsAuthenticated = False And role = glbRoleUnauthUser) Or _
                        role = glbRoleAllUsers Or _
                        context.User.IsInRole(role) = True Or _
                        context.User.Identity.Name = _portalSettings.SuperUserId.ToString) Then
                        Return True
                    End If

                Next role
            End If

            Return False

        End Function

        Public Shared Function HasEditPermissions(ByVal ModuleId As Integer) As Boolean

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim result As IDataReader = GetAuthRoles(_portalSettings.PortalId, ModuleId)

            If result.Read() Then
                If PortalSecurity.IsInRoles(result("AuthorizedRoles").ToString) = False Or PortalSecurity.IsInRoles(result("AuthorizedEditRoles").ToString) = False Then
                    HasEditPermissions = False
                Else
                    HasEditPermissions = True
                End If
            Else
                HasEditPermissions = False
            End If
            result.Close()

        End Function

        Public Shared Function GetAuthRoles(ByVal PortalId As Integer, ByVal ModuleId As Integer) As IDataReader

            Return DataProvider.Instance().GetAuthRoles(PortalId, ModuleId)

        End Function

        Public Function Encrypt(ByVal strKey As String, ByVal strData As String) As String

            Dim strValue As String = ""

            If strKey <> "" Then
                ' convert key to 16 characters for simplicity
                Select Case Len(strKey)
                    Case Is < 16
                        strKey = strKey & Left("XXXXXXXXXXXXXXXX", 16 - Len(strKey))
                    Case Is > 16
                        strKey = Left(strKey, 16)
                End Select

                ' create encryption keys
                Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
                Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))

                ' convert data to byte array
                Dim byteData() As Byte = Encoding.UTF8.GetBytes(strData)

                ' encrypt 
                Dim objDES As New DESCryptoServiceProvider
                Dim objMemoryStream As New MemoryStream
                Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write)
                objCryptoStream.Write(byteData, 0, byteData.Length)
                objCryptoStream.FlushFinalBlock()

                ' convert to string and Base64 encode
                strValue = Convert.ToBase64String(objMemoryStream.ToArray())
            Else
                strValue = strData
            End If

            Return strValue

        End Function

        Public Function Encrypt(ByVal cleanString As String) As String
            Dim clearBytes As Byte()
            Dim hashedBytes As Byte()
            clearBytes = New UnicodeEncoding().GetBytes(cleanString)
            hashedBytes = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(clearBytes)
            Return BitConverter.ToString(hashedBytes)
        End Function

        Public Function Decrypt(ByVal strKey As String, ByVal strData As String) As String

            Dim strValue As String = ""

            If strKey <> "" Then
                ' convert key to 16 characters for simplicity
                Select Case Len(strKey)
                    Case Is < 16
                        strKey = strKey & Left("XXXXXXXXXXXXXXXX", 16 - Len(strKey))
                    Case Is > 16
                        strKey = Left(strKey, 16)
                End Select

                ' create encryption keys
                Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
                Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))

                ' convert data to byte array and Base64 decode
                Dim byteData(strData.Length) As Byte
                Try
                    byteData = Convert.FromBase64String(strData)
                Catch ' invalid length
                    strValue = strData
                End Try

                If strValue = "" Then
                    Try
                        ' decrypt
                        Dim objDES As New DESCryptoServiceProvider
                        Dim objMemoryStream As New MemoryStream
                        Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateDecryptor(byteKey, byteVector), CryptoStreamMode.Write)
                        objCryptoStream.Write(byteData, 0, byteData.Length)
                        objCryptoStream.FlushFinalBlock()

                        ' convert to string
                        Dim objEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
                        strValue = objEncoding.GetString(objMemoryStream.ToArray())
                    Catch ' decryption error
                        strValue = ""
                    End Try
                End If
            Else
                strValue = strData
            End If

            Return strValue

        End Function


        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' This function applies security filtering to the UserInput string.
        ''' </summary>
        ''' <param name="UserInput">This is the string to be filtered</param>
        ''' <param name="FilterType">Flags which designate the filters to be applied</param>
        ''' <returns>Filtered UserInput</returns>
        ''' <history>
        ''' 	[Joe Brinkman] 	8/15/2003	Created Bug #000120, #000121
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Function InputFilter(ByVal UserInput As String, ByVal FilterType As FilterFlag) As String
            Dim TempInput As String = UserInput

            If (FilterType And FilterFlag.NoSQL) = FilterFlag.NoSQL Then
                TempInput = FormatRemoveSQL(TempInput)
            Else
                If (FilterType And FilterFlag.NoMarkup) = FilterFlag.NoMarkup Then
                    If IncludesMarkup(TempInput) Then
                        TempInput = HttpUtility.HtmlEncode(TempInput)
                    End If
                ElseIf (FilterType And FilterFlag.NoScripting) = FilterFlag.NoScripting Then
                    TempInput = FormatDisableScripting(TempInput)
                End If

                If (FilterType And FilterFlag.MultiLine) = FilterFlag.MultiLine Then
                    TempInput = FormatMultiLine(TempInput)
                End If
            End If

            Return TempInput
        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' This filter removes CrLf characters and inserts br
        ''' </summary>
        ''' <param name="strInput">This is the string to be filtered</param>
        ''' <returns>Filtered UserInput</returns>
        ''' <remarks>
        ''' This is a private function that is used internally by the InputFilter function
        ''' </remarks>
        ''' <history>
        ''' 	[Joe Brinkman] 	8/15/2003	Created Bug #000120
        ''' </history>
        '''-----------------------------------------------------------------------------
        Private Function FormatMultiLine(ByVal strInput As String) As String
            Dim TempInput As String = strInput.Replace(ControlChars.Cr + ControlChars.Lf, "<br>")
            Return TempInput.Replace(ControlChars.Cr, "<br>")
        End Function 'FormatMultiLine

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' This function uses Regex search strings to remove HTML tags which are 
        ''' targeted in Cross-site scripting (XSS) attacks.  This function will evolve
        ''' to provide more robust checking as additional holes are found.
        ''' </summary>
        ''' <param name="strInput">This is the string to be filtered</param>
        ''' <returns>Filtered UserInput</returns>
        ''' <remarks>
        ''' This is a private function that is used internally by the InputFilter function
        ''' </remarks>
        ''' <history>
        ''' 	[Joe Brinkman] 	8/15/2003	Created Bug #000120
        ''' </history>
        '''-----------------------------------------------------------------------------
        Private Function FormatDisableScripting(ByVal strInput As String) As String
            Dim TempInput As String = strInput

            Dim options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.Singleline
            Dim strReplacement As String = " "
            Dim strPattern As String = "<script[^>]*>.*?</script[^><]*>"

            TempInput = Regex.Replace(TempInput, "<script[^>]*>.*?</script[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<input[^>]*>.*?</input[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<object[^>]*>.*?</object[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<applet[^>]*>.*?</applet[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<form[^>]*>.*?</form[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<option[^>]*>.*?</option[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<select[^>]*>.*?</select[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<iframe[^>]*>.*?</iframe[^><]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "<form[^>]*>", strReplacement, options)
            TempInput = Regex.Replace(TempInput, "</form[^><]*>", strReplacement, options)

            Return TempInput

        End Function 'FormatDisableScripting

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' This function verifies raw SQL statements to prevent SQL injection attacks 
        ''' and replaces a similar function (PreventSQLInjection) from the Globals.vb module
        ''' </summary>
        ''' <param name="strSQL">This is the string to be filtered</param>
        ''' <returns>Filtered UserInput</returns>
        ''' <remarks>
        ''' This is a private function that is used internally by the InputFilter function
        ''' </remarks>
        ''' <history>
        ''' 	[Joe Brinkman] 	8/15/2003	Created Bug #000121
        '''     [Tom Lucas]     3/8/2004    Fixed   Bug #000114 (Aardvark)
        ''' </history>
        '''-----------------------------------------------------------------------------
        Private Function FormatRemoveSQL(ByVal strSQL As String) As String

            Dim strCleanSQL As String = strSQL

            If strSQL <> Nothing Then

                Dim BadCommands As Array = Split(";,--,create,drop,select,insert,delete,update,union,sp_,xp_", ",")

                ' strip any dangerous SQL commands
                Dim intCommand As Integer
                For intCommand = 0 To BadCommands.Length - 1
                    strCleanSQL = Regex.Replace(strCleanSQL, Convert.ToString(BadCommands.GetValue(intCommand)), " ", RegexOptions.IgnoreCase)
                Next

                ' convert any single quotes
                strCleanSQL = Replace(strCleanSQL, "'", "''")
            End If

            Return strCleanSQL

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' This function determines if the Input string contains any markup.
        ''' </summary>
        ''' <param name="strInput">This is the string to be checked</param>
        ''' <returns>True if string contains Markup tag(s)</returns>
        ''' <remarks>
        ''' This is a private function that is used internally by the InputFilter function
        ''' </remarks>
        ''' <history>
        ''' 	[Joe Brinkman] 	8/15/2003	Created Bug #000120
        ''' </history>
        '''-----------------------------------------------------------------------------
        Private Function IncludesMarkup(ByVal strInput As String) As Boolean
            Dim options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.Singleline
            Dim strPattern As String = "<[^<>]*>"
            Return Regex.IsMatch(strInput, strPattern, options)
        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines is user has the necessary permissions to access the an item with the
        ''' designated AccessLevel.
        ''' </summary>
        ''' <param name="AccessLevel">The SecurityAccessLevel required to access a portal module or module action.</param>
        ''' <param name="pSettings">The PortalSettings for the current portal.</param>
        ''' <param name="mSettings">The ModuleSettings for the associated module.</param>
        ''' <param name="UserName">The Context.User.Identity.Name of the currently logged in user.</param>
        ''' <returns>A boolean value indicating if the user has the necessary permissions</returns>
        ''' <remarks>Every module control and module action has an associated permission level.  This
        ''' function determines whether the user represented by UserName has sufficient permissions, as
        ''' determined by the PortalSettings and ModuleSettings, to access a resource with the 
        ''' designated AccessLevel.</remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/21/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Shared Function HasNecessaryPermission(ByVal AccessLevel As SecurityAccessLevel, ByVal pSettings As PortalSettings, ByVal mSettings As ModuleSettings, ByVal UserName As String) As Boolean
            Dim blnAuthorized As Boolean = True
            Select Case AccessLevel
                Case SecurityAccessLevel.Anonymous
                    blnAuthorized = True
                Case SecurityAccessLevel.View  ' view
                    If PortalSecurity.IsInRole(pSettings.AdministratorRoleId.ToString) = False _
                        And PortalSecurity.IsInRoles(pSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                        If Not PortalSecurity.IsInRoles(mSettings.AuthorizedViewRoles) Then
                            blnAuthorized = False
                        End If
                    End If
                Case SecurityAccessLevel.Edit  ' edit
                    If PortalSecurity.IsInRole(pSettings.AdministratorRoleId.ToString) = False _
                        And PortalSecurity.IsInRoles(pSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                        If Not PortalSecurity.IsInRoles(mSettings.AuthorizedViewRoles) Then
                            blnAuthorized = False
                        Else
                            If Not PortalSecurity.HasEditPermissions(mSettings.ModuleId) Then
                                blnAuthorized = False
                            End If
                        End If
                    End If
                Case SecurityAccessLevel.Admin  ' admin
                    If PortalSecurity.IsInRole(pSettings.AdministratorRoleId.ToString) = False _
                        And PortalSecurity.IsInRoles(pSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                        blnAuthorized = False
                    End If
                Case SecurityAccessLevel.Host  ' host
                    If UserName.Length > 0 Then
                        If UserName <> pSettings.SuperUserId Then
                            blnAuthorized = False
                        End If
                    Else ' no longer logged in
                        blnAuthorized = False
                    End If
            End Select
            Return blnAuthorized
        End Function



    End Class

End Namespace