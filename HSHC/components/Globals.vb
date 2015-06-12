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
Option Strict Off
Option Explicit Off
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Web.Mail
Imports System.Text
Imports System.Net
Imports PortalQH.Web.UI.WebControls
Imports System.Data
Imports System.Security.Cryptography
Imports System.Math
Imports System.Runtime.InteropServices.ExternalException
Imports System.Web.Services.Interop
Imports System.Runtime.InteropServices.Marshal
Imports ProgStudios.WebControls
Imports System.Diagnostics.Process
Imports Microsoft.Office.Interop
Imports Microsoft.Office
Imports RandomKey




Namespace PortalQH

    '*********************************************************************
    '
    ' Globals Module
    ' This module contains global utility functions, constants, and enumerations.
    '
    '*********************************************************************

    Public Module Globals

        Public Const glbRoleAllUsers As String = "-1"
        Public Const glbRoleSuperUser As String = "-2"
        Public Const glbRoleUnauthUser As String = "-3"
        Public Const glbDefaultPage As String = "Default.aspx"
        Public Const glbDefaultPane As String = "ContentPane"
        Public Const glbImageFileTypes As String = "jpg,jpeg,jpe,gif,bmp,png"

        'khai báo các hằng danh mục
        Public Const glbDuong As String = "DMDUONG"
        Public Const glbPhuong As String = "DMPHUONG"

        Private _intPortalID As String = "0"
        Private _intItemCode As String
        Private _ActiveDB As String = "PORTALQH"

        Private _Request As HttpRequest
        Public glbTHOUSANDS_SEPERATOR As String = "."
        Public glbDECIMAL_SEPERATOR As String = ","

        Public Property gItemCode() As String
            Get
                'gItemCode = Session.item("ItemCode")
                gItemCode = _intItemCode
            End Get
            Set(ByVal Value As String)
                'Session.item("ItemCode") = Value
                _intItemCode = Value
            End Set
        End Property

        'Public Property ctype(Session.Item("ActiveDB"),string)() As String
        '    Get
        '        ctype(Session.Item("ActiveDB"),string) = _ActiveDB
        '    End Get
        '    Set(ByVal Value As String)
        '        _ActiveDB = Value
        '    End Set
        'End Property


        Public Property gPortalID() As String
            Get
                gPortalID = _intPortalID
            End Get
            Set(ByVal Value As String)
                _intPortalID = Value
            End Set
        End Property

        Public Property gRequest() As HttpRequest
            Get
                gRequest = _Request
            End Get
            Set(ByVal Value As HttpRequest)
                _Request = Value
            End Set
        End Property

        ' returns the absolute server path to the root ( ie. D:\Inetpub\wwwroot\directory\ )
        Public Function GetAbsoluteServerPath(ByVal Request As System.Web.HttpRequest) As String
            Dim strServerPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            If Not strServerPath.EndsWith("\") Then
                strServerPath += "\"
            End If

            GetAbsoluteServerPath = strServerPath

        End Function

        '' returns the domain name of the current request ( ie. www.domain.com or 207.132.12.123 or www.domain.com/directory if subhost )
        Public Function GetDomainName(ByVal Request As HttpRequest) As String
            Dim DomainName As StringBuilder = New StringBuilder
            Dim URL() As String
            Dim intURL As Integer

            URL = Split(Request.Url.ToString(), "/")
            For intURL = 2 To URL.GetUpperBound(0)
                Select Case URL(intURL).ToLower
                    Case "admin", "controls", "desktopmodules", "mobilemodules", "premiummodules", "cpktqh", "cpktqh_temp"
                        Exit For
                    Case Else
                        ' check if filename
                        If InStr(1, URL(intURL), ".aspx") = 0 And InStr(1, URL(intURL), ".axd") = 0 Then
                            DomainName.Append(IIf(DomainName.ToString <> "", "/", "").ToString & URL(intURL))
                        Else
                            Exit For
                        End If
                End Select
            Next intURL

            Return DomainName.ToString
        End Function

        ' stub included for legacy purposes
        Public Function SendNotification(ByVal strFrom As String, ByVal strTo As String, ByVal strBcc As String, ByVal strSubject As String, ByVal strBody As String, Optional ByVal strAttachment As String = "", Optional ByVal strBodyType As String = "", Optional ByVal strSMTPServer As String = "") As String

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' SMTP server
            If _portalSettings.HostSettings("SMTPServer").ToString <> "" Then
                strSMTPServer = _portalSettings.HostSettings("SMTPServer").ToString
            End If
            Dim strSMTPUsername As String = ""
            If Convert.ToString(_portalSettings.HostSettings("SMTPUsername")) <> "" Then
                strSMTPUsername = Convert.ToString(_portalSettings.HostSettings("SMTPUsername"))
            End If
            Dim strSMTPPassword As String = ""
            If Convert.ToString(_portalSettings.HostSettings("SMTPPassword")) <> "" Then
                strSMTPPassword = Convert.ToString(_portalSettings.HostSettings("SMTPPassword"))
            End If

            ' here we check if we want to format the email as html or plain text.
            Dim objBodyFormat As MailFormat
            If strBodyType <> "" Then
                Select Case LCase(strBodyType)
                    Case "html"
                        objBodyFormat = MailFormat.Html
                    Case "text"
                        objBodyFormat = MailFormat.Text
                End Select
            End If

            Return SendMail(strFrom, strTo, "", strBcc, MailPriority.Normal, strSubject, objBodyFormat, System.Text.Encoding.Default, strBody, strAttachment, strSMTPServer, strSMTPUsername, strSMTPPassword)

        End Function

        ' sends a simple email
        Public Function SendMail(ByVal [From] As String, ByVal [To] As String, ByVal [Cc] As String, ByVal [Bcc] As String, ByVal [Priority] As MailPriority, ByVal [Subject] As String, ByVal [BodyFormat] As MailFormat, ByVal [BodyEncoding] As System.Text.Encoding, ByVal [Body] As String, ByVal [Attachment] As String, ByVal [SMTPServer] As String, ByVal [SMTPUsername] As String, ByVal [SMTPPassword] As String) As String

            Dim objMail As New MailMessage

            ' recipients
            objMail.From = [From]
            objMail.To = [To]
            If [Cc] <> "" Then
                objMail.Cc = [Cc]
            End If
            If [Bcc] <> "" Then
                objMail.Bcc = [Bcc]
            End If

            ' message
            objMail.Priority = [Priority]
            objMail.Subject = [Subject]
            objMail.BodyFormat = [BodyFormat]
            objMail.BodyEncoding = [BodyEncoding]
            objMail.Body = [Body]

            ' attachment
            If [Attachment] <> "" Then
                objMail.Attachments.Add(New MailAttachment([Attachment]))
            End If

            ' SMTP server
            If [SMTPServer] <> "" Then
                SmtpMail.SmtpServer = [SMTPServer]
            End If

            ' external SMTP server
            If [SMTPServer] <> "" Then
                SmtpMail.SmtpServer = [SMTPServer]
                ' with authentication
                If [SMTPUsername] <> "" And [SMTPPassword] <> "" Then
                    objMail.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
                    objMail.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = [SMTPUsername]
                    objMail.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = [SMTPPassword]
                End If
            End If

            Try
                SmtpMail.Send(objMail)
            Catch objException As Exception
                ' mail configuration problem
                SendMail = objException.Message
            End Try

        End Function

        ' encodes a URL for posting to an external site
        Public Function HTTPPOSTEncode(ByVal strPost As String) As String
            strPost = Replace(strPost, "\", "")
            strPost = System.Web.HttpUtility.UrlEncode(strPost)
            strPost = Replace(strPost, "%2f", "/")
            HTTPPOSTEncode = strPost
        End Function

        ' retrieves the domain name of the portal ( ie. http://www.domain.com " )
        Public Function GetPortalDomainName(ByVal strPortalAlias As String, Optional ByVal Request As HttpRequest = Nothing, Optional ByVal blnAddHTTP As Boolean = True) As String

            Dim strDomainName As String

            Dim strURL As String = ""
            Dim arrPortalAlias() As String
            Dim intAlias As Integer

            If Not Request Is Nothing Then
                strURL = GetDomainName(Request)
            End If

            arrPortalAlias = Split(strPortalAlias, ",")
            For intAlias = 0 To arrPortalAlias.Length - 1
                If arrPortalAlias(intAlias) = strURL Then
                    strDomainName = arrPortalAlias(intAlias)
                End If
            Next
            If strDomainName = "" Then
                strDomainName = arrPortalAlias(0)
            End If

            If blnAddHTTP Then
                strDomainName = AddHTTP(strDomainName)
            End If

            GetPortalDomainName = strDomainName

        End Function

        ' adds HTTP to URL if no other protocol specified
        Public Function AddHTTP(ByVal strURL As String) As String
            If strURL <> "" Then
                If InStr(1, strURL, "://") = 0 And InStr(1, strURL, "~") = 0 And InStr(1, strURL, "\\") = 0 Then
                    If HttpContext.Current.Request.IsSecureConnection Then
                        strURL = "https://" & strURL
                    Else
                        strURL = "http://" & strURL
                    End If
                End If
            End If
            Return strURL
        End Function
        Public Function ConvertDataViewToDataTable(ByVal obDataView As DataView) As DataTable
            If (obDataView Is Nothing) Then
                Throw New ArgumentNullException("DataView", "Invalid DataView object specified")
            End If
            Dim obNewDt As DataTable = obDataView.Table.Clone()
            Dim idx As Integer = 0
            'string [] strColNames = new string[obNewDt.Columns.Count];
            Dim strColNames(obNewDt.Columns.Count - 1) As String
            Dim col As DataColumn
            For Each col In obNewDt.Columns
                strColNames(idx) = col.ColumnName
                idx += 1
            Next
            Dim viewEnumerator As IEnumerator = obDataView.GetEnumerator()
            While (viewEnumerator.MoveNext())

                Dim drv As DataRowView = CType(viewEnumerator.Current, DataRowView)
                Dim dr As DataRow = obNewDt.NewRow()
                'try
                Dim strName As String
                Dim i As Integer
                For i = 0 To strColNames.Length - 1
                    'dr(strName) = drv(strName)
                    dr(strColNames(i)) = drv(strColNames(i))
                Next
                'catch	        
                obNewDt.Rows.Add(dr)
            End While
            Return obNewDt
        End Function
        ' convert datareader to dataset
        Public Function ConvertDataReaderToDataSet(ByVal reader As IDataReader) As DataSet

            ' add datatable to dataset
            Dim objDataSet As New DataSet
            objDataSet.Tables.Add(ConvertDataReaderToDataTable(reader))

            Return objDataSet

        End Function
        ' convert datatable to dataset
        Public Function ConvertDataTableToDataSet(ByVal datatable As DataTable) As DataSet

            ' add datatable to dataset
            Dim objDataSet As New DataSet
            objDataSet.Tables.Add(datatable)

            Return objDataSet

        End Function
        ' convert datareader to dataset
        Public Function ConvertDataReaderToDataTable(ByVal reader As IDataReader) As DataTable

            ' create datatable from datareader
            Dim objDataTable As New DataTable
            Dim intFieldCount As Integer = reader.FieldCount
            Dim intCounter As Integer
            For intCounter = 0 To intFieldCount - 1
                objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter))
            Next intCounter

            ' populate datatable
            objDataTable.BeginLoadData()
            Dim objValues(intFieldCount - 1) As Object
            While reader.Read()
                reader.GetValues(objValues)
                objDataTable.LoadDataRow(objValues, True)
            End While
            reader.Close()
            objDataTable.EndLoadData()

            Return objDataTable

        End Function

        ' convert datareader to crosstab dataset
        Public Function BuildCrossTabDataSet(ByVal DataSetName As String, ByVal result As IDataReader, ByVal FixedColumns As String, ByVal VariableColumns As String, ByVal KeyColumn As String, ByVal FieldColumn As String, ByVal FieldTypeColumn As String, ByVal StringValueColumn As String, ByVal NumericValueColumn As String) As DataSet

            Dim arrFixedColumns As String()
            Dim arrVariableColumns As String()
            Dim arrField As String()
            Dim FieldName As String
            Dim FieldType As String
            Dim intColumn As Integer
            Dim intKeyColumn As Integer

            ' create dataset
            Dim crosstab As New DataSet(DataSetName)
            crosstab.Namespace = "NetFrameWork"

            ' create table
            Dim tab As New DataTable(DataSetName)

            ' split fixed columns
            arrFixedColumns = FixedColumns.Split(",".ToCharArray())

            ' add fixed columns to table
            For intColumn = LBound(arrFixedColumns) To UBound(arrFixedColumns)
                arrField = arrFixedColumns(intColumn).Split("|".ToCharArray())
                Dim col As New DataColumn(arrField(0), System.Type.GetType("System." & arrField(1)))
                tab.Columns.Add(col)
            Next intColumn

            ' split variable columns
            If VariableColumns <> "" Then
                arrVariableColumns = VariableColumns.Split(",".ToCharArray())

                ' add varible columns to table
                For intColumn = LBound(arrVariableColumns) To UBound(arrVariableColumns)
                    arrField = arrVariableColumns(intColumn).Split("|".ToCharArray())
                    Dim col As New DataColumn(arrField(0), System.Type.GetType("System." & arrField(1)))
                    col.AllowDBNull = True
                    tab.Columns.Add(col)
                Next intColumn
            End If

            ' add table to dataset
            crosstab.Tables.Add(tab)

            ' add rows to table
            intKeyColumn = -1
            Dim row As DataRow
            While result.Read()
                ' loop using KeyColumn as control break
                If Convert.ToInt32(result(KeyColumn)) <> intKeyColumn Then
                    ' add row
                    If intKeyColumn <> -1 Then
                        tab.Rows.Add(row)
                    End If

                    ' create new row
                    row = tab.NewRow()

                    ' assign fixed column values
                    For intColumn = LBound(arrFixedColumns) To UBound(arrFixedColumns)
                        arrField = arrFixedColumns(intColumn).Split("|".ToCharArray())
                        row(arrField(0)) = result(arrField(0))
                    Next intColumn

                    ' initialize variable column values
                    If VariableColumns <> "" Then
                        For intColumn = LBound(arrVariableColumns) To UBound(arrVariableColumns)
                            arrField = arrVariableColumns(intColumn).Split("|".ToCharArray())
                            Select Case arrField(1)
                                Case "Decimal"
                                    row(arrField(0)) = 0
                                Case "String"
                                    row(arrField(0)) = ""
                            End Select
                        Next intColumn
                    End If

                    intKeyColumn = Convert.ToInt32(result(KeyColumn))
                End If

                ' assign pivot column value
                If FieldTypeColumn <> "" Then
                    FieldType = result(FieldTypeColumn).ToString
                Else
                    FieldType = "String"
                End If
                Select Case FieldType
                    Case "Decimal" ' decimal
                        row(Convert.ToInt32(result(FieldColumn))) = result(NumericValueColumn)
                    Case "String" ' string
                        row(result(FieldColumn).ToString) = result(StringValueColumn)
                End Select
            End While

            result.Close()

            ' add row
            If intKeyColumn <> -1 Then
                tab.Rows.Add(row)
            End If

            ' finalize dataset
            crosstab.AcceptChanges()

            ' return the dataset
            Return crosstab

        End Function

        Public Class FileItem
            Private _Value As String
            Private _Text As String

            Public Sub New(ByVal Value As String, ByVal Text As String)
                _Value = Value
                _Text = Text
            End Sub

            Public ReadOnly Property Value() As String
                Get
                    Return _Value
                End Get
            End Property

            Public ReadOnly Property Text() As String
                Get
                    Return _Text
                End Get
            End Property

        End Class

        ' get list of files from folder matching criteria
        Public Function GetFileList(Optional ByVal PortalId As Integer = -1, Optional ByVal strExtensions As String = "", Optional ByVal NoneSpecified As Boolean = True) As ArrayList
            Dim arrFileList As New ArrayList

            If NoneSpecified Then
                arrFileList.Add(New FileItem("", "<None Specified>"))
            End If

            Dim objFiles As New FileController

            Dim dr As IDataReader = objFiles.GetFiles(PortalId)
            While dr.Read()
                If InStr(1, strExtensions.ToUpper, dr("Extension").ToString.ToUpper) <> 0 Or strExtensions = "" Then
                    arrFileList.Add(New FileItem(dr("FileName").ToString, dr("FileName").ToString))
                End If

            End While
            dr.Close()

            GetFileList = arrFileList
        End Function

        ' format an address on a single line ( ie. Unit, Street, City, Region, Country, PostalCode )
        Public Function FormatAddress(ByVal Unit As Object, ByVal Street As Object, ByVal City As Object, ByVal Region As Object, ByVal Country As Object, ByVal PostalCode As Object) As String

            Dim strAddress As String = ""

            If Not Unit Is Nothing Then
                If Trim(Unit.ToString()) <> "" Then
                    strAddress += ", " & Unit.ToString
                End If
            End If
            If Not Street Is Nothing Then
                If Trim(Street.ToString()) <> "" Then
                    strAddress += ", " & Street.ToString
                End If
            End If
            If Not City Is Nothing Then
                If Trim(City.ToString()) <> "" Then
                    strAddress += ", " & City.ToString
                End If
            End If
            If Not Region Is Nothing Then
                If Trim(Region.ToString()) <> "" Then
                    strAddress += ", " & Region.ToString
                End If
            End If
            If Not Country Is Nothing Then
                If Trim(Country.ToString()) <> "" Then
                    strAddress += ", " & Country.ToString
                End If
            End If
            If Not PostalCode Is Nothing Then
                If Trim(PostalCode.ToString()) <> "" Then
                    strAddress += ", " & PostalCode.ToString
                End If
            End If
            If Trim(strAddress) <> "" Then
                strAddress = Mid(strAddress, 3)
            End If

            FormatAddress = strAddress

        End Function

        ' format an email address including link
        Public Function FormatEmail(ByVal Email As Object) As String

            If Not IsDBNull(Email) Then
                If Trim(Email.ToString()) <> "" Then
                    If Email.ToString.IndexOf("@") <> -1 Then
                        FormatEmail = "<a href=""mailto:" & Email.ToString() & """>" & Email.ToString() & "</a>"
                    Else
                        FormatEmail = Email.ToString()
                    End If
                End If
            End If

            Return CloakText(FormatEmail)

        End Function

        ' format a domain name including link
        Public Function FormatWebsite(ByVal Website As Object) As String

            If Not IsDBNull(Website) Then
                If Trim(Website.ToString()) <> "" Then
                    If Convert.ToBoolean(InStr(1, Website.ToString(), ".")) Then
                        FormatWebsite = "<a href=""" & IIf(Convert.ToBoolean(InStr(1, Website.ToString(), "://")), "", "http://").ToString & Website.ToString() & """>" & Website.ToString() & "</a>"
                    Else
                        FormatWebsite = Website.ToString()
                    End If
                End If
            End If

        End Function

        ' obfuscate sensitive data to prevent collection by robots and spiders and crawlers
        Public Function CloakText(ByVal PersonalInfo As String) As String
            Dim sb As New StringBuilder

            ' convert to ASCII character codes
            sb.Remove(0, sb.Length)
            Dim StringLength As Integer = PersonalInfo.Length - 1
            For i As Integer = 0 To StringLength
                sb.Append(Asc(PersonalInfo.Substring(i, 1)).ToString)
                If i < StringLength Then
                    sb.Append(",")
                End If
            Next

            ' build script block
            Dim sbScript As New StringBuilder

            sbScript.Append(vbCrLf & "<script language=""javascript"">" & vbCrLf)
            sbScript.Append("<!-- " & vbCrLf)
            sbScript.Append("   document.write(String.fromCharCode(" & sb.ToString & "))" & vbCrLf)
            sbScript.Append("// -->" & vbCrLf)
            sbScript.Append("</script>" & vbCrLf)

            Return sbScript.ToString

        End Function

        ' returns an arraylist of tabitems for a portal
        Public Function GetPortalTabs(ByVal objDesktopTabs As ArrayList, Optional ByVal blnNoneSpecified As Boolean = False, Optional ByVal blnHidden As Boolean = False, Optional ByVal blnDeleted As Boolean = False) As ArrayList

            Dim arrPortalTabs As ArrayList = New ArrayList
            Dim objPortalTab As TabItem
            Dim objTab As TabStripDetails

            If blnNoneSpecified Then
                objPortalTab = New TabItem
                objPortalTab.TabId = -1
                objPortalTab.TabName = "<None Specified>"
                objPortalTab.TabOrder = 0
                objPortalTab.ParentId = -2
                arrPortalTabs.Add(objPortalTab)
            End If

            Dim intCounter As Integer
            Dim strIndent As String

            For Each objTab In objDesktopTabs
                If IsAdminTab(objTab.TabId, objTab.ParentId) = False And (objTab.IsVisible = True Or blnHidden = True) And (objTab.IsDeleted = False Or blnDeleted = True) Then
                    strIndent = ""
                    For intCounter = 1 To objTab.Level
                        strIndent += "..."
                    Next

                    objPortalTab = New TabItem
                    objPortalTab.TabId = objTab.TabId
                    objPortalTab.TabName = strIndent & objTab.TabName
                    objPortalTab.TabOrder = objTab.TabOrder
                    objPortalTab.ParentId = objTab.ParentId
                    arrPortalTabs.Add(objPortalTab)
                End If
            Next

            Return arrPortalTabs

        End Function

        ' returns a SQL Server compatible date
        Public Function GetMediumDate(ByVal strDate As String) As String

            If strDate <> "" Then
                Dim datDate As Date = Convert.ToDateTime(strDate)

                Dim strYear As String = Year(datDate).ToString
                Dim strMonth As String = MonthName(Month(datDate), True)
                Dim strDay As String = Day(datDate).ToString

                strDate = strDay & "-" & strMonth & "-" & strYear
            End If

            Return strDate

        End Function

        ' returns a SQL Server compatible date
        Public Function GetShortDate(ByVal strDate As String) As String

            If strDate <> "" Then
                Dim datDate As Date = Convert.ToDateTime(strDate)

                Dim strYear As String = Year(datDate).ToString
                Dim strMonth As String = Month(datDate).ToString
                Dim strDay As String = Day(datDate).ToString

                strDate = strMonth & "/" & strDay & "/" & strYear
            End If

            Return strDate

        End Function

        ' returns a boolean value whether the tab is an admin tab
        Public Function IsAdminTab(ByVal intTabId As Integer, ByVal intParentId As Integer) As Boolean

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Return (intTabId = _portalSettings.AdminTabId) Or _
                    (intParentId = _portalSettings.AdminTabId) Or _
                    (intTabId = _portalSettings.SuperTabId) Or _
                    (intParentId = _portalSettings.SuperTabId)

        End Function

        ' returns a boolean value whether the control is an admin control
        Public Function IsAdminControl() As Boolean

            Return (IsNothing(HttpContext.Current.Request.QueryString("mid")) = False) Or _
                (IsNothing(HttpContext.Current.Request.QueryString("def")) = False) Or _
                (IsNothing(HttpContext.Current.Request.QueryString("ctl")) = False)

        End Function

        ' Deprecated PreventSQLInjection Function to consolidate Security Filter functions in the PortalSecurity class.
        Public Function PreventSQLInjection(ByVal strSQL As String) As String
            Return (New PortalSecurity).InputFilter(strSQL, PortalSecurity.FilterFlag.NoSQL)
        End Function

        ' creates RRS files
        Public Sub CreateRSS(ByVal dr As IDataReader, ByVal TitleField As String, ByVal URLField As String, ByVal CreatedDateField As String, ByVal SyndicateField As String, ByVal DomainName As String, ByVal FileName As String)

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' create RSS file
            Dim strRSS As String = ""

            Dim strRelativePath As String = DomainName & Replace(Mid(FileName, InStr(1, FileName, "\Portals")), "\", "/")
            strRelativePath = Left(strRelativePath, InStrRev(strRelativePath, "/"))

            While dr.Read()
                If Convert.ToBoolean(dr(SyndicateField)) Then
                    strRSS += "      <item>" & ControlChars.CrLf
                    strRSS += "         <title>" & dr(TitleField).ToString & "</title>" & ControlChars.CrLf
                    If InStr(1, dr("URL").ToString, "://") = 0 Then
                        If IsNumeric(dr("URL").ToString) Then
                            strRSS += "         <link>" & DomainName & "/DesktopDefault.aspx?tabid=" & dr(URLField).ToString & "</link>" & ControlChars.CrLf
                        Else
                            strRSS += "         <link>" & strRelativePath & dr(URLField).ToString & "</link>" & ControlChars.CrLf
                        End If
                    Else
                        strRSS += "         <link>" & dr(URLField).ToString & "</link>" & ControlChars.CrLf
                    End If
                    strRSS += "         <description>" & _portalSettings.PortalName & " " & GetMediumDate(dr(CreatedDateField).ToString) & "</description>" & ControlChars.CrLf
                    strRSS += "     </item>" & ControlChars.CrLf
                End If
            End While
            dr.Close()

            If strRSS <> "" Then
                strRSS = "<?xml version=""1.0"" encoding=""iso-8859-1""?>" & ControlChars.CrLf & _
                    "<rss version=""0.91"">" & ControlChars.CrLf & _
                    "  <channel>" & ControlChars.CrLf & _
                    "     <title>" & _portalSettings.PortalName & "</title>" & ControlChars.CrLf & _
                    "     <link>" & DomainName & "</link>" & ControlChars.CrLf & _
                    "     <description>" & _portalSettings.PortalName & "</description>" & ControlChars.CrLf & _
                    "     <language>en-us</language>" & ControlChars.CrLf & _
                    "     <copyright>" & _portalSettings.FooterText & "</copyright>" & ControlChars.CrLf & _
                    "     <webMaster>" & _portalSettings.Email & "</webMaster>" & ControlChars.CrLf & _
                    strRSS & _
                    "   </channel>" & ControlChars.CrLf & _
                    "</rss>"

                Dim objStream As StreamWriter
                objStream = File.CreateText(FileName)
                objStream.WriteLine(strRSS)
                objStream.Close()
            Else
                If File.Exists(FileName) Then
                    File.Delete(FileName)
                End If
            End If

        End Sub

        ' injects the upload directory into raw HTML for src and background tags
        Public Function ManageUploadDirectory(ByVal strHTML As String, ByVal strUploadDirectory As String) As String

            Dim P As Integer

            ManageUploadDirectory = ""

            If strHTML <> "" Then
                P = InStr(1, strHTML.ToLower, "src=""")
                While P <> 0
                    ManageUploadDirectory = ManageUploadDirectory & Left(strHTML, P + 4)

                    strHTML = Mid(strHTML, P + 5)

                    ' add uploaddirectory if we are linking internally
                    If InStr(1, strHTML, "://") = 0 Then
                        strHTML = strUploadDirectory & strHTML
                    End If

                    P = InStr(1, strHTML.ToLower, "src=""")
                End While
                ManageUploadDirectory = ManageUploadDirectory & strHTML

                strHTML = ManageUploadDirectory
                ManageUploadDirectory = ""

                P = InStr(1, strHTML.ToLower, "background=""")
                While P <> 0
                    ManageUploadDirectory = ManageUploadDirectory & Left(strHTML, P + 11)

                    strHTML = Mid(strHTML, P + 12)

                    ' add uploaddirectory if we are linking internally
                    If InStr(1, strHTML, "://") = 0 Then
                        strHTML = strUploadDirectory & strHTML
                    End If

                    P = InStr(1, strHTML.ToLower, "background=""")
                End While
            End If

            ManageUploadDirectory = ManageUploadDirectory & strHTML

        End Function

        ' returns the database connection string
        Public Function GetDBConnectionString() As String
            Return ConfigurationSettings.AppSettings("connectionString")
        End Function

        ' uses recursion to search the control hierarchy for a specific control based on controlname
        Public Function FindControlRecursive(ByVal objControl As Control, ByVal strControlName As String) As Control
            If objControl.Parent Is Nothing Then
                Return Nothing
            Else
                If Not objControl.Parent.FindControl(strControlName) Is Nothing Then
                    Return objControl.Parent.FindControl(strControlName)
                Else
                    Return FindControlRecursive(objControl.Parent, strControlName)
                End If
            End If
        End Function

        'set focus to any control
        Public Sub SetFormFocus(ByVal control As Control)
            If Not control.Page Is Nothing And control.Visible Then
                If control.Page.Request.Browser.JavaScript = True Then

                    ' Create JavaScript 
                    Dim sb As New System.Text.StringBuilder
                    sb.Append("<SCRIPT LANGUAGE='JavaScript'>")
                    sb.Append("<!--")
                    sb.Append(ControlChars.Lf)
                    sb.Append("function SetInitialFocus() {")
                    sb.Append(ControlChars.Lf)
                    sb.Append(" document.")

                    ' Find the Form 
                    Dim objParent As Control = control.Parent
                    While Not TypeOf objParent Is System.Web.UI.HtmlControls.HtmlForm
                        objParent = objParent.Parent
                    End While
                    sb.Append(objParent.ClientID)
                    sb.Append("['")
                    'PhuocDD: Modified, Oct 18th 2005: Replace UniqueID with ClientID
                    sb.Append(control.ClientID)
                    sb.Append("'].focus(); }")
                    sb.Append("window.onload = SetInitialFocus;")
                    sb.Append(ControlChars.Lf)
                    sb.Append("// -->")
                    sb.Append(ControlChars.Lf)
                    sb.Append("</SCRIPT>")

                    ' Register Client Script 
                    control.Page.RegisterClientScriptBlock("InitialFocus", sb.ToString())
                End If
            End If
        End Sub

        Public Function GetExternalRequest(ByVal Address As String) As HttpWebRequest
            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' Create the request object
            Dim objRequest As HttpWebRequest = CType(WebRequest.Create(Address), HttpWebRequest)

            ' Set a time out to the request ... 10 seconds
            If Not _portalSettings.HostSettings("WebRequestTimeout") Is Nothing Then
                objRequest.Timeout = Integer.Parse(CType(_portalSettings.HostSettings("WebRequestTimeout"), String))
            Else
                objRequest.Timeout = 10000
            End If

            ' Attach a User Agent to the request
            objRequest.UserAgent = "PortalQH"

            ' If there is Proxy info, apply it to the Request
            If CType(_portalSettings.HostSettings("ProxyServer"), String) <> "" Then

                ' Create a new Proxy
                Dim Proxy As WebProxy

                ' Create a new Network Credentials item
                Dim ProxyCredentials As NetworkCredential

                ' Fill Proxy info from host settings
                Proxy = New WebProxy(CType(_portalSettings.HostSettings("ProxyServer"), String), Convert.ToInt32(_portalSettings.HostSettings("ProxyPort")))

                If Not CType(_portalSettings.HostSettings("ProxyUsername"), String) = "" Then
                    ' Fill the credential info from host settings
                    ProxyCredentials = New NetworkCredential(CType(_portalSettings.HostSettings("ProxyUsername"), String), CType(_portalSettings.HostSettings("ProxyPassword"), String))

                    'Apply credentials to proxy
                    Proxy.Credentials = ProxyCredentials
                End If

                ' Apply Proxy to Request
                objRequest.Proxy = Proxy

            End If
            Return objRequest
        End Function

        Public Function GetExternalRequest(ByVal Address As String, ByVal Credentials As NetworkCredential) As HttpWebRequest

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' Create the request object
            Dim objRequest As HttpWebRequest = CType(WebRequest.Create(Address), HttpWebRequest)

            ' Set a time out to the request ... 10 seconds
            If Not _portalSettings.HostSettings("WebRequestTimeout") Is Nothing Then
                objRequest.Timeout = Integer.Parse(CType(_portalSettings.HostSettings("WebRequestTimeout"), String))
            Else
                objRequest.Timeout = 10000
            End If

            ' Attach a User Agent to the request
            objRequest.UserAgent = "PortalQH"

            ' Attach supplied credentials
            If Not Credentials.UserName Is Nothing Then
                objRequest.Credentials = Credentials
            End If

            ' If there is Proxy info, apply it to the Request
            If CType(_portalSettings.HostSettings("ProxyServer"), String) <> "" Then

                ' Create a new Proxy
                Dim Proxy As WebProxy

                ' Create a new Network Credentials item
                Dim ProxyCredentials As NetworkCredential

                ' Fill Proxy info from host settings
                Proxy = New WebProxy(CType(_portalSettings.HostSettings("ProxyServer"), String), Convert.ToInt32(_portalSettings.HostSettings("ProxyPort")))

                If Not CType(_portalSettings.HostSettings("ProxyUsername"), String) = "" Then
                    ' Fill the credential info from host settings
                    ProxyCredentials = New NetworkCredential(CType(_portalSettings.HostSettings("ProxyUsername"), String), CType(_portalSettings.HostSettings("ProxyPassword"), String))

                    'Apply credentials to proxy
                    Proxy.Credentials = ProxyCredentials
                End If

                ' Apply Proxy to Request
                objRequest.Proxy = Proxy

            End If
            Return objRequest
        End Function

        Public Sub DeleteFolderRecursive(ByVal strRoot As String)
            If strRoot <> "" Then
                Dim strFolder As String
                If Directory.Exists(strRoot) Then
                    For Each strFolder In Directory.GetDirectories(strRoot)
                        DeleteFolderRecursive(strFolder)
                    Next
                    Dim strFile As String
                    For Each strFile In Directory.GetFiles(strRoot)
                        File.SetAttributes(strFile, FileAttributes.Normal)
                        File.Delete(strFile)
                    Next
                    Directory.Delete(strRoot)
                End If
            End If
        End Sub

        Public Function CreateValidID(ByVal strID As String) As String

            Dim strBadCharacters As String = " ./-\"

            Dim intIndex As Integer
            For intIndex = 0 To strBadCharacters.Length - 1
                strID = strID.Replace(strBadCharacters.Substring(intIndex, 1), "_")
            Next

            Return strID

        End Function

        Public Function ApplicationURL() As String

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Return ("~/" & glbDefaultPage & "?tabid=" & _portalSettings.ActiveTab.TabId.ToString)

        End Function

        '--    
        'by AnhLH
        'date May 17, 2004 
        '
        Public Function GetControlValues(ByVal strControlID As String, ByVal objControl As Object) As String
            Return FindControlValues(strControlID, objControl)
        End Function

        Private Function FindControlValues(ByVal strControlID As String, ByVal objForm As Object) As String
            Dim oControl As Control
            For Each oControl In CType(objForm, Control).Controls
                'If UCase(oControl.ID) = UCase(strControlID) Then
                Select Case True
                    Case TypeOf oControl Is TextBox And UCase(oControl.ID) = UCase(strControlID)
                        Return CType(oControl, TextBox).Text
                    Case TypeOf oControl Is DropDownList And UCase(oControl.ID) = UCase(strControlID)
                        Return CType(oControl, DropDownList).SelectedValue
                    Case TypeOf oControl Is CheckBoxList And UCase(oControl.ID) = UCase(strControlID)
                        Return CType(IIf(CType(oControl, CheckBox).Checked = True, 1, 0), String)
                    Case TypeOf oControl Is RadioButton And UCase(oControl.ID) = UCase(strControlID)
                        Return CType(IIf(CType(oControl, RadioButton).Checked = True, 1, 0), String)
                    Case Else
                        FindControlValues(strControlID, oControl)
                End Select
                'End If
            Next
        End Function

        Public Enum LoadControlValuesLocation
            Local 'Anh huong den cac field thuoc dataset
            Form 'Anh huong den tat ca cac control tren form
        End Enum

        Public Sub gLoadControlValues(ByVal ds As DataSet, ByVal objControl As Object, Optional ByVal locate As LoadControlValuesLocation = LoadControlValuesLocation.Form)
            Dim objDanhMuc As New DanhMucController

            Dim i As Integer

            If ds.Tables(0).Rows.Count = 0 Then
                If locate = LoadControlValuesLocation.Form Then
                    ResetControls(objControl)
                Else
                    ResetControls(objControl, ds)
                End If
                Exit Sub
            End If
            For i = 0 To ds.Tables(0).Columns.Count - 1
                SetControlValues("obj" & ds.Tables(0).Columns(i).ToString, ds.Tables(0).Rows(0).Item(i).ToString, objControl)
            Next

        End Sub

        Public Sub SetControlValues(ByVal strControlID As String, ByVal strValue As String, ByVal objControl As Object)

            FindSetControlValues(strControlID, strValue, objControl)

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="strControlID"></param>
        ''' <param name="strValue"></param>
        ''' <param name="objControl"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/4/2007	Updated, sua lai set value for dropdownlist
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub FindSetControlValues(ByVal strControlID As String, ByVal strValue As String, ByVal objControl As Object)
            Dim oControl As Control
            Dim i As Integer
            For Each oControl In CType(objControl, Control).Controls
                Select Case True
                    Case TypeOf oControl Is TextBox And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        strValue = HttpUtility.HtmlDecode(strValue)
                        CType(oControl, TextBox).Text = strValue
                        Exit Sub
                    Case TypeOf oControl Is DropDownList And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        'For i = 0 To CType(oControl, DropDownList).Items.Count - 1
                        '    If UCase(CType(oControl, DropDownList).Items(i).Value) = UCase(strValue) Then
                        '        CType(oControl, DropDownList).SelectedIndex = i
                        '    End If
                        'Next
                        CType(oControl, DropDownList).SelectedIndex = CType(oControl, DropDownList).Items.IndexOf(CType(oControl, DropDownList).Items.FindByValue(strValue))
                        Exit Sub
                    Case TypeOf oControl Is CheckBox And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        CType(oControl, CheckBox).Checked = CType(Val(strValue), Boolean)
                        Exit Sub
                    Case TypeOf oControl Is ComboBox And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        For i = 0 To CType(oControl, ComboBox).Items.Count - 1
                            If UCase(CType(oControl, ComboBox).Items(i).Value) = UCase(strValue) Then
                                'CType(oControl, ComboBox).SelectedIndex = i
                                CType(oControl, ComboBox).Value = UCase(strValue)
                                Exit Sub
                            End If
                        Next
                        'CType(oControl, DropDownList).SelectedValue = strValue
                        Exit Sub
                    Case TypeOf oControl Is RadioButton And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        CType(oControl, RadioButton).Checked = CType(Val(strValue), Boolean)
                        Exit Sub
                    Case TypeOf oControl Is RadioButtonList And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        CType(oControl, RadioButtonList).SelectedValue = strValue
                        Exit Sub
                    Case TypeOf oControl Is CheckBoxList And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        'Cac field duoc check cach nhau dau /
                        Dim values() As String = strValue.Split("/")
                        For Each item As ListItem In CType(oControl, CheckBoxList).Items
                            If values.IndexOf(values, item.Value) >= 0 Then
                                item.Selected = True
                            Else
                                item.Selected = False
                            End If
                        Next
                        Exit Sub
                    Case TypeOf oControl Is Label And UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4))
                        strValue = HttpUtility.HtmlEncode(strValue)
                        CType(oControl, Label).Text = strValue
                        Exit Sub
                    Case Else
                        FindSetControlValues(strControlID, strValue, oControl)
                End Select
            Next
        End Sub
        'Private Sub FindSetControlValues(ByVal strControlID As String, ByVal strValue As String, ByVal objControl As Object)
        '    Dim oControl As Control
        '    For Each oControl In CType(objControl, Control).Controls
        '        If UCase(Mid(oControl.ID, 4)) = UCase(Mid(strControlID, 4)) Then

        '            Select Case True
        '                Case TypeOf oControl Is TextBox
        '                    CType(oControl, TextBox).Text = strValue
        '                    Exit Sub
        '                Case TypeOf oControl Is DropDownList
        '                    If strValue <> "" Then
        '                        CType(oControl, DropDownList).SelectedValue = strValue
        '                    End If
        '                    Exit Sub
        '                Case TypeOf oControl Is CheckBox
        '                    CType(oControl, CheckBox).Checked = CType(Val(strValue), Boolean)
        '                    Exit Sub
        '                Case TypeOf oControl Is RadioButton
        '                    CType(oControl, RadioButton).Checked = CType(Val(strValue), Boolean)
        '                    Exit Sub
        '            End Select
        '        End If
        '    Next
        'End Sub

        Public Sub ResetControls(ByVal objControl As Object, Optional ByVal dsField As DataSet = Nothing)
            FindResetControls(objControl, dsField)
        End Sub

        Private Sub FindResetControls(ByVal objForm As Object, Optional ByVal dsField As DataSet = Nothing)
            Dim oControl As Control
            For Each oControl In CType(objForm, Control).Controls

                Select Case True
                    Case TypeOf oControl Is TextBox
                        If dsField Is Nothing Then
                            CType(oControl, TextBox).Text = ""
                        Else
                            If dsField.Tables(0).Columns.Contains(CType(oControl, TextBox).ID.Substring(3)) Then
                                CType(oControl, TextBox).Text = ""
                            End If
                        End If
                    Case TypeOf oControl Is DropDownList
                        CType(oControl, DropDownList).SelectedIndex = -1
                    Case TypeOf oControl Is ComboBox
                        CType(oControl, ComboBox).Value = ""
                    Case TypeOf oControl Is ComboBox
                        CType(oControl, ComboBox).SelectedIndex = -1
                    Case TypeOf oControl Is CheckBox
                        CType(oControl, CheckBox).Checked = False
                    Case TypeOf oControl Is RadioButton
                        CType(oControl, RadioButton).Checked = False
                    Case TypeOf oControl Is CheckBoxList
                        CType(oControl, CheckBoxList).ClearSelection()
                    Case Else
                        FindResetControls(oControl)
                End Select
            Next
        End Sub
        'Public Sub ResetDataGrid(ByRef dv As DataView, ByVal Grid As DataGrid)
        '    Dim i As Integer
        '    With dv
        '        If dv Is Nothing Then Exit Sub
        '        If dv.Count = 0 Then Exit Sub
        '        Dim a As DataGridItem
        '        While .Count > 1
        '            .Delete(1)
        '        End While
        '        For Each a In Grid.Items
        '            If a.ItemIndex <> 0 Then
        '                While a.Cells.Count > 0
        '                    a.Cells.RemoveAt(0)
        '                End While
        '            End If
        '        Next
        '        If .Count = 1 Then
        '            For i = 0 To .Table.Columns.Count - 1
        '                .Item(0).Item(i) = ""
        '                'If i > 1 And Grid.Items.Count <> 0 Then
        '                'Grid.Items(0).Cells(i).Text = ""
        '                'End If
        '            Next
        '            Grid.EditItemIndex = 0
        '            'Grid.DataSource = dv
        '            'Grid.DataBind()
        '            'Grid.Items(i).Cells.RemoveAt(0)
        '        End If
        '    End With
        'End Sub


        'Public Function CheckNull(ByVal objControl As Object) As Boolean
        '    Return FindCheckNullControls(objControl)
        'End Function

        'Private Function FindCheckNullControls(ByVal objForm As Object) As Boolean
        '    Dim oControl As Control
        '    For Each oControl In CType(objForm, Control).Controls

        '        Select Case True
        '            Case TypeOf oControl Is TextBoxA
        '                If Not CType(oControl, TextBoxA).IsNull Then
        '                    If CType(oControl, TextBoxA).Text = "" Then
        '                        Return True
        '                        Exit Function
        '                    End If
        '                    'Else
        '                    'Return True
        '                End If
        '                'Case TypeOf oControl Is DropDownList
        '                '    CType(oControl, DropDownList).SelectedIndex = -1
        '                'Case TypeOf oControl Is CheckBox
        '                '    CType(oControl, CheckBox).Checked = False
        '                'Case TypeOf oControl Is RadioButton
        '                '    CType(oControl, RadioButton).Checked = False
        '            Case TypeOf oControl Is HtmlTable
        '                Dim objRow As HtmlTableRow
        '                For Each objRow In CType(oControl, HtmlTable).Rows
        '                    Dim objCell As HtmlTableCell
        '                    For Each objCell In CType(objRow, HtmlTableRow).Cells
        '                        FindCheckNullControls(objCell)
        '                    Next
        '                Next

        '        End Select

        '    Next
        'End Function
        Public Function CheckNull(ByVal objHtmlTable As HtmlTable) As Boolean
            Dim objRow As HtmlTableRow
            For Each objRow In objHtmlTable.Rows
                Dim objCell As HtmlTableCell
                For Each objCell In objRow.Cells
                    Dim objControl As Control
                    For Each objControl In objCell.Controls
                        Select Case True
                            Case TypeOf objControl Is TextBoxA
                                If Not CType(objControl, TextBoxA).IsNull Then
                                    If CType(objControl, TextBoxA).Text = "" Then
                                        Return True
                                    End If
                                End If
                        End Select
                    Next
                Next
            Next
        End Function

        'Public Function EnableKeyTextBox(ByVal objForm As Object, ByVal blnStatus As Boolean) As Boolean
        '    Dim oControl As Control
        '    For Each oControl In CType(objForm, Control).Controls

        '        Select Case True
        '            Case TypeOf oControl Is TextBoxA
        '                If CType(oControl, TextBoxA).IsKey Then
        '                    CType(oControl, TextBoxA).Enabled = blnStatus
        '                End If
        '        End Select

        '    Next
        'End Function
        Public Function EnableKeyTextBox(ByVal objHtmlTable As HtmlTable, ByVal blnStatus As Boolean) As Boolean
            Dim objRow As HtmlTableRow
            For Each objRow In objHtmlTable.Rows
                Dim objCell As HtmlTableCell
                For Each objCell In objRow.Cells
                    Dim objControl As Control
                    For Each objControl In objCell.Controls
                        Select Case True
                            Case TypeOf objControl Is TextBoxA
                                If Not CType(objControl, TextBoxA).IsNull Then
                                    If CType(objControl, TextBoxA).IsKey Then
                                        CType(objControl, TextBoxA).Enabled = blnStatus
                                    End If
                                End If
                        End Select
                    Next
                Next
            Next
        End Function
        'ngantl them
        Public Function CheckEnableKey(ByVal objhtmlTable As HtmlTable) As Boolean
            Dim objRow As HtmlTableRow
            For Each objRow In objhtmlTable.Rows
                Dim objCell As HtmlTableCell
                For Each objCell In objRow.Cells
                    Dim objControl As Control
                    For Each objControl In objCell.Controls
                        Select Case True
                            Case TypeOf objControl Is TextBoxA
                                If Not CType(objControl, TextBoxA).IsNull Then
                                    If CType(objControl, TextBoxA).IsKey Then
                                        Return CType(objControl, TextBoxA).Enabled
                                    End If
                                End If
                        End Select
                    Next
                Next
            Next
        End Function
        Public Function GetValueEnableKey(ByVal objhtmlTable As HtmlTable) As String
            Dim objRow As HtmlTableRow
            For Each objRow In objhtmlTable.Rows
                Dim objCell As HtmlTableCell
                For Each objCell In objRow.Cells
                    Dim objControl As Control
                    For Each objControl In objCell.Controls
                        Select Case True
                            Case TypeOf objControl Is TextBoxA
                                If Not CType(objControl, TextBoxA).IsNull Then
                                    If CType(objControl, TextBoxA).IsKey Then
                                        Return CType(objControl, TextBoxA).Text
                                    End If
                                End If
                        End Select
                    Next
                Next
            Next
        End Function
        'END ngantl them

        ' returns the database connection string
        Public Function GetCommonDB() As String
            Return ConfigurationSettings.AppSettings("commonDB")
        End Function

        Public Function GetLoaiDanhMuc(ByVal Request As HttpRequest, ByVal strTabid As String, ByVal glbXMLCPKTQH As String) As String
            Dim xmldoc As New Xml.XmlDocument
            Dim elemList As Xml.XmlNodeList
            Dim xmlNode As Xml.XmlNode
            Dim i, k As Integer
            Dim strXMLFile As String
            strXMLFile = GetAbsoluteServerPath(Request) & glbXMLCPKTQH
            xmldoc.Load(strXMLFile)


            elemList = xmldoc.GetElementsByTagName("tabDanhMuc")
            For i = 0 To elemList.Count - 1
                xmlNode = elemList.Item(i)
                For k = 0 To xmlNode.ChildNodes.Count - 1
                    If xmlNode.ChildNodes(k).Name = "tab" & strTabid Then
                        GetLoaiDanhMuc = xmlNode.ChildNodes(k).InnerXml
                        Exit For
                    End If
                Next
                xmlNode = Nothing
            Next
            xmldoc = Nothing
            elemList = Nothing

        End Function


        Public Function GetDanhMucList(ByVal Request As HttpRequest, ByVal glbXMLCPKTQH As String) As ArrayList
            Dim xmldoc As New Xml.XmlDocument
            Dim elemList As Xml.XmlNodeList
            Dim xmlNode As Xml.XmlNode
            Dim i, k As Integer
            Dim arrTableName As New ArrayList
            Dim strXMLFile As String

            strXMLFile = GetAbsoluteServerPath(Request) & glbXMLCPKTQH
            xmldoc.Load(strXMLFile)

            elemList = xmldoc.GetElementsByTagName("tabDanhMuc")
            For i = 0 To elemList.Count - 1
                xmlNode = elemList.Item(i)
                For k = 0 To xmlNode.ChildNodes.Count - 1
                    arrTableName.Add(xmlNode.ChildNodes(k).InnerXml)
                Next
                xmlNode = Nothing
            Next
            xmldoc = Nothing
            elemList = Nothing
            GetDanhMucList = arrTableName
        End Function
        Public Function GetParamByID(ByVal strID As String, ByVal strXMLFileName As String) As String
            Dim xmldoc As New Xml.XmlDocument
            Dim i, k As Integer
            Dim strTableName As String
            Dim strXMLFile As String
            strXMLFile = GetAbsoluteServerPath(gRequest) & strXMLFileName
            xmldoc.Load(strXMLFile)
            Return xmldoc.GetElementsByTagName(strID).Item(0).InnerXml
        End Function

        Public Function GetPropertyValue(ByVal strPropertyName As String, ByVal objControl As Object) As Object
            GetPropertyValue = FindPropertyControl(strPropertyName, objControl)
        End Function
        Private Function FindPropertyControl(ByVal strPropertyName As String, ByVal obj As Object) As Object
            Dim oControl As Object
            Dim strValue As Object
            Try
                If obj Is Nothing Then Exit Function
                strValue = Nothing
                For Each oControl In CType(obj, Control).Controls
                    Select Case True
                        Case TypeOf oControl Is TextBox
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(strPropertyName) Then
                                strValue = IIf(CType(oControl, TextBox).Text = "", Nothing, CType(oControl, TextBox).Text)
                                Exit For
                            End If
                        Case TypeOf oControl Is DropDownList
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(strPropertyName) Then
                                strValue = IIf(CType(oControl, DropDownList).SelectedItem.Value = "", Nothing, CType(oControl, DropDownList).SelectedItem.Value)
                                Exit For
                            End If
                        Case TypeOf oControl Is RadioButtonList
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(strPropertyName) Then
                                strValue = IIf(CType(oControl, RadioButtonList).SelectedItem.Value = "", Nothing, CType(oControl, RadioButtonList).SelectedItem.Value)
                                Exit For
                            End If
                        Case TypeOf oControl Is CheckBox
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(strPropertyName) Then
                                strValue = IIf(CType(oControl, CheckBox).Checked = True, 1, 0)
                                Exit For
                            End If
                        Case TypeOf oControl Is RadioButton
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(strPropertyName) Then
                                strValue = IIf(CType(oControl, RadioButton).Checked = True, 1, 0)
                                Exit For
                            End If
                        Case Else
                            FindPropertyControl(strPropertyName, oControl)
                    End Select
                Next oControl
            Catch ex As Exception
            Finally
                FindPropertyControl = strValue
            End Try
        End Function

        Public Function GetGridControlValue(ByVal iRow As Integer, ByVal grdData As DataGrid, ByVal strControlName As String) As String
            'Dim TempList As DropDownList
            Dim TempList As Object
            Dim TempValue As String

            TempList = grdData.Items(iRow).FindControl(strControlName)
            Select Case True
                Case TypeOf TempList Is DropDownList
                    If CType(TempList, DropDownList).SelectedIndex <> -1 Then
                        TempValue = CType(TempList, DropDownList).SelectedValue
                    Else
                        TempValue = Nothing
                    End If
                Case TypeOf TempList Is TextBox
                    If CType(TempList, TextBox).Text <> "" Then
                        TempValue = CType(TempList, TextBox).Text
                    Else
                        TempValue = Nothing
                    End If
                Case TypeOf TempList Is Label
                    If CType(TempList, Label).Text <> "" Then
                        TempValue = CType(TempList, Label).Text
                    Else
                        TempValue = Nothing
                    End If
                Case TypeOf TempList Is CheckBox
                    If CType(TempList, CheckBox).Checked = True Then
                        TempValue = "1"
                    Else
                        TempValue = "0"
                    End If
                Case TypeOf TempList Is RadioButton
                    If CType(TempList, RadioButton).Checked = True Then
                        TempValue = "1"
                    Else
                        TempValue = "0"
                    End If
                Case TypeOf TempList Is HyperLink
                    If CType(TempList, HyperLink).Text <> "" Then
                        TempValue = CType(TempList, HyperLink).Text
                    Else
                        TempValue = Nothing
                    End If
            End Select

            Return TempValue
            ' Save TempValue to DB		
        End Function
        Public Sub SetGridControlValue1(ByVal iRow As Integer, ByVal grdData As DataGrid, ByVal strControlName As String, ByVal strValue As Object)
            'Dim TempList As DropDownList
            Dim TempList As Object

            TempList = grdData.Items(iRow).FindControl(strControlName)
            Select Case True
                Case TypeOf TempList Is DropDownList
                    CType(TempList, DropDownList).SelectedValue = CType(strValue, String)
                Case TypeOf TempList Is TextBox
                    CType(TempList, TextBox).Text = CType(strValue, String)
                Case TypeOf TempList Is CheckBox
                    CType(TempList, CheckBox).Checked = CType(strValue, Boolean)
                Case TypeOf TempList Is RadioButton
                    CType(TempList, RadioButton).Checked = CType(strValue, Boolean)
            End Select


        End Sub
        ' Cretad by     : DaoLT
        ' Date          : 20/07/2004
        Public Function SetGridControlValue(ByVal iRow As Integer, ByVal grdData As DataGrid, ByVal strControlName As String, ByVal obj As Object) As Object
            'Dim TempList As DropDownList
            Dim TempList As Object
            Dim TempValue As String

            TempList = grdData.Items(iRow).FindControl(strControlName)
            Select Case True
                Case TypeOf TempList Is DropDownList
                    CType(TempList, DropDownList).SelectedValue = CType(obj, String)
                Case TypeOf TempList Is TextBox
                    CType(TempList, TextBox).Text = CType(obj, String)
                Case TypeOf TempList Is CheckBox
                    CType(TempList, CheckBox).Checked = CType(obj, Boolean)
                Case TypeOf TempList Is RadioButton
                    CType(TempList, RadioButton).Checked = CType(obj, Boolean)
            End Select

            Return obj
        End Function

        Public Function GetDanhMucList(ByVal strTableName As String, Optional ByVal IsNull As Boolean = True) As ArrayList
            Dim dm As New DanhMucController
            Return dm.GetDanhMucListCBO(strTableName, IsNull)
        End Function
        Public Function GetTenQuan() As String
            Dim ds As DataSet
            Dim dm As New DanhMucController
            ds = dm.GetTenQuan()
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item(0)
            End If
        End Function

        Public Function GetNgayLamViec() As String
            Return DataProvider.Instance.ExecuteScalar("sp_NgayHientai")
        End Function
        Public Function GetSelectedIndex(ByVal strTableName As String, ByVal strMa As Object, Optional ByVal IsNull As Boolean = True) As Integer

            Dim i As Integer

            Dim arrDM As New ArrayList
            Dim arr As New DanhMucInfo
            arrDM = GetDanhMucList(strTableName, IsNull)
            GetSelectedIndex = 0
            For i = 0 To arrDM.Count - 1
                arr = CType(arrDM(i), DanhMucInfo)
                If strMa Is Nothing Or strMa Is DBNull.Value Then Exit For

                If CType(arr.Ma, String) = CType(strMa, String) Then
                    GetSelectedIndex = i
                    Exit For
                End If
            Next

        End Function
        Function TestDateInput(ByVal DateInput As String) As Boolean 'test with format dd/mm/yyyy
            Dim day, month, year As String
            If DateInput.Length() < 10 Or DateInput.Length() > 10 Then
                Return False
            Else
                day = DateInput.Substring(0, 2)
                month = DateInput.Substring(3, 2)
                year = DateInput.Substring(6, 4)
                If IsDate(month + "/" + day + "/" + year) = True Then
                    Return True
                Else
                    Return False
                End If
            End If

        End Function
        Public Function ConvertTo_DMY(ByVal day As DateTime) As String
            Dim strDay As String = day.Day()
            If strDay.Length < 2 Then
                strDay = "0" & strDay
            End If
            Dim strMonth As String = day.Month()
            If strMonth.Length < 2 Then
                strMonth = "0" & strMonth
            End If
            Dim strYear As String = day.Year
            Return strDay & "/" & strMonth & "/" & strYear
        End Function
        Public Function getYear(ByVal day As String) As Integer
            Return Val(day.Split("/")(2))
        End Function
        Public Function ConvertTo_Date(ByVal strdate As String) As Date
            Dim iYear, iMonth, iDay As Integer
            iYear = CInt(strdate.Split("/")(2))
            iMonth = CInt(strdate.Split("/")(1))
            iDay = CInt(strdate.Split("/")(0))
            Dim ddate As New Date(iYear, iMonth, iDay)
            Return ddate
        End Function
        Public Function GetDataSetItem(ByVal iRow As Integer, ByVal ds As DataSet, ByVal strColName As String) As Object
            Dim objValue As Object
            If ds.Tables(0).Rows(iRow).Item(strColName) Is DBNull.Value Then
                objValue = Nothing
            Else
                objValue = ds.Tables(0).Rows(iRow).Item(strColName)
            End If
            Return objValue
        End Function
        Public Sub EnableControls(ByVal objControl As Object, Optional ByVal blnEnabled As Boolean = True)
            FindEnableControls(objControl, blnEnabled)
        End Sub

        Private Sub FindEnableControls(ByVal objControl As Object, Optional ByVal blnEnabled As Boolean = True)
            Dim oControl As Control
            For Each oControl In objControl.Controls
                Select Case True
                    Case TypeOf oControl Is TextBox
                        CType(oControl, TextBox).Enabled = blnEnabled
                    Case TypeOf oControl Is DropDownList
                        CType(oControl, DropDownList).Enabled = blnEnabled
                    Case TypeOf oControl Is CheckBox
                        CType(oControl, CheckBox).Enabled = blnEnabled
                    Case TypeOf oControl Is RadioButton
                        CType(oControl, RadioButton).Enabled = blnEnabled
                    Case Else
                        FindEnableControls(oControl, blnEnabled)
                End Select

            Next
        End Sub
        Public Sub AddNewRowToDataTable(ByVal dt As DataTable)
            Dim i As Integer
            ' Them moi mot hang trong DanhSach
            Dim dr As DataRow
            dr = dt.NewRow()
            For i = 0 To dt.Columns.Count - 1
                dr(i) = ""
            Next
            dt.Rows.Add(dr)
        End Sub
        Public Function ConvertToNumericDB(ByVal strValue As String) As String
            Dim strKq As String
            strKq = strValue
            strKq = Replace(strKq, glbTHOUSANDS_SEPERATOR, "")
            strKq = Replace(strKq, glbDECIMAL_SEPERATOR, ".")
            Return strKq

        End Function

        Public Function FormatNumberTextBox(ByVal iRow As Integer, ByVal grdData As DataGrid, ByVal strControlName As String) As String
            Dim TempList As Object
            Dim TempValue As String

            TempList = grdData.Items(iRow).FindControl(strControlName)
            Select Case True
                Case TypeOf TempList Is DropDownList
                    If CType(TempList, DropDownList).SelectedIndex <> -1 Then
                        TempValue = CType(TempList, DropDownList).SelectedValue
                    Else
                        TempValue = Nothing
                    End If
                Case TypeOf TempList Is TextBox
                    CType(TempList, TextBox).Attributes.Add("onblur", "javascript:CheckData(" & TempList.ClientID & ");")
                Case TypeOf TempList Is CheckBox
                    If CType(TempList, CheckBox).Checked = True Then
                        TempValue = "1"
                    Else
                        TempValue = "0"
                    End If
                Case TypeOf TempList Is RadioButton
                    If CType(TempList, RadioButton).Checked = True Then
                        TempValue = "1"
                    Else
                        TempValue = "0"
                    End If
            End Select

            Return TempValue
            ' Save TempValue to DB		
        End Function
        Public Function NgayHienTai() As String
            Dim rightNow As DateTime = DateTime.Now
            Return rightNow.ToString("dd/MM/yyyy")
        End Function
        Public Function g_DateToString(ByVal Ngay As DateTime) As String
            Return Ngay.ToString("dd/MM/yyyy")
        End Function
        Public Function GetFieldValue(ByVal obj As Object) As String
            If obj Is DBNull.Value Then
                Return Nothing
            Else
                Return CType(obj, String)
            End If
        End Function
        Public Function convertSoVN(ByVal Value As String) As String
            'Input dang 478748984.89
            Dim kq As String
            Dim so As String
            Dim nguyen As String
            Dim le As String
            Dim pos As Integer


            If CType(Value, Double) < "999" Then
                Return Value & glbDECIMAL_SEPERATOR & "00"
            End If
            so = Value

            pos = InStr(1, so, ".")

            If pos = 0 Then
                nguyen = so
                le = ""
            Else
                nguyen = Mid(so, 1, pos - 1)
                le = Mid(so, pos + 1)
            End If

            While Len(nguyen) > 3
                kq = Mid(nguyen, Len(nguyen) - 2) & "." & kq
                nguyen = Mid(nguyen, 1, Len(nguyen) - 3)
            End While
            If Len(nguyen) > 0 Then
                kq = nguyen & "." & kq
            End If
            If Len(kq) > 3 Then
                kq = Mid(kq, 1, Len(kq) - 1)
            End If
            If Len(le) > 2 Then
                If Val(Mid(le, 3)) >= 5 Then
                    le = CType(Val(Mid(le, 1, 2)) + 1, String)
                Else
                    le = CType(Val(Mid(le, 1, 2)), String)
                End If
            End If
            If Len(le) = 0 Then le = "00"
            If Len(le) = 1 Then le = le & "0"

            'If Len(le) > 0 Then
            kq = kq & "," & le
            'End If


            Return kq
        End Function
        ' Add by DaoLT
        Public Function IsInteger(ByVal StringToCheck As String) As Boolean
            Dim iCounter As Integer

            '//-- for each caracter in the string
            For iCounter = 0 To StringToCheck.Length - 1
                '//-- check if numeric
                If Not Char.IsDigit(StringToCheck.Chars(iCounter)) Then
                    Return False
                End If
            Next

            Return True

        End Function
        ' Add by DaoLT
        Public Function GetTotal(ByVal grd As DataGrid, ByVal strControlName As String, _
                                   Optional ByVal blnDinhDangVN As Boolean = True) As String
            Dim i As Integer
            Dim dblTong, dblGiaTri As Double
            Dim strGiaTri As String
            Dim strKQ As String = ""
            dblTong = 0
            Try
                For i = 0 To grd.Items.Count - 1
                    If CType(GetGridControlValue(i, grd, strControlName), String) = "" Then
                        dblGiaTri = 0
                    Else
                        strGiaTri = Replace(CType(GetGridControlValue(i, grd, strControlName), String), glbTHOUSANDS_SEPERATOR, "")
                        strGiaTri = Replace(strGiaTri, glbDECIMAL_SEPERATOR, ".")
                        dblGiaTri = CType(strGiaTri, Double)
                    End If
                    dblTong = dblTong + dblGiaTri
                Next
                If blnDinhDangVN Then
                    strKQ = convertSoVN(CType(dblTong, String))
                Else
                    strKQ = CType(dblTong, String)
                End If
            Catch ex As Exception
                strKQ = "L?n hon 100 t? t?!"
            End Try
            Return strKQ
        End Function
        Public Sub SetMSGBOX_HIDDEN(ByVal objPage As Page, ByVal strMessage As String)
            Dim ctrl As Control
            For Each ctrl In objPage.Controls
                FindMSGBOX_HIDDEN(ctrl, strMessage)
            Next
        End Sub
        Public Sub FindMSGBOX_HIDDEN(ByVal obj As Object, ByVal strMessage As String)
            Dim ctrl As Control
            For Each ctrl In CType(obj, Control).Controls
                If UCase(ctrl.ID) = "MSGBOX_HIDDEN" Then
                    CType(ctrl, HtmlInputControl).Value = strMessage
                Else
                    FindMSGBOX_HIDDEN(ctrl, strMessage)
                End If
            Next
        End Sub
        Public Sub SetFocus(ByVal objPage As Page, ByVal ctrl As Control)
            Dim strS As String
            strS = "<SCRIPT language='javascript'>document.getElementById('" + ctrl.ClientID + "').focus() </SCRIPT>"
            objPage.RegisterStartupScript("focus", strS)
        End Sub

        'Danh Muc
        Public Sub CreateControls(ByVal strTableName As String, ByVal objHtmlTable As HtmlTable, ByVal XMLFileName As String, _
        Optional ByVal grdList As DataGrid = Nothing, Optional ByVal btnUpdate As Control = Nothing, _
        Optional ByVal btnCancel As Control = Nothing, _
        Optional ByVal btnTroVe As Control = Nothing, _
        Optional ByVal lblSoDong As Control = Nothing, _
        Optional ByVal txtSoDong As Control = Nothing _
        )

            Dim row As Integer = 0
            'Generate rows and cells.
            Dim numrows As Integer = 5
            Dim numcells As Integer = 2


            Dim ds As New DataSet
            ds.ReadXml(XMLFileName)
            Dim dv As DataView = New DataView(ds.Tables(strTableName))
            Dim r As HtmlTableRow
            Dim c As HtmlTableCell
            Dim j As Integer
            For j = 0 To dv.Count - 1
                r = New HtmlTableRow
                Dim drw As DataRowView = dv.Item(j)
                Dim i As Integer

                c = New HtmlTableCell
                c.Controls.Add(CreateLabel(drw))
                c.Width = "25%"
                c.VAlign = "middle"


                r.Cells.Add(c)
                c = Nothing
                c = New HtmlTableCell
                c.Controls.Add(CreateInputControls(drw))
                c.Width = "75%"
                c.VAlign = "top"
                r.Cells.Add(c)

                c = Nothing

                objHtmlTable.Rows.Add(r)


            Next

            r = New HtmlTableRow
            c = New HtmlTableCell
            c.Controls.Add(New LiteralControl("<br>"))
            r.Cells.Add(c)
            objHtmlTable.Rows.Add(r)

            r = New HtmlTableRow
            c = New HtmlTableCell
            If Not btnUpdate Is Nothing Then c.Controls.Add(btnUpdate)
            If Not btnCancel Is Nothing Then c.Controls.Add(btnCancel)
            If Not btnTroVe Is Nothing Then c.Controls.Add(btnTroVe)




            c.ColSpan = 2
            c.VAlign = "middle"
            c.Align = "center"
            r.Cells.Add(c)
            objHtmlTable.Rows.Add(r)

            r = New HtmlTableRow
            c = New HtmlTableCell
            c.Controls.Add(New LiteralControl("<br>"))
            r.Cells.Add(c)
            objHtmlTable.Rows.Add(r)

            r = New HtmlTableRow
            c = New HtmlTableCell
            If Not lblSoDong Is Nothing Then c.Controls.Add(lblSoDong)
            If Not txtSoDong Is Nothing Then c.Controls.Add(txtSoDong)

            c.Align = "right"
            c.ColSpan = 2
            r.Cells.Add(c)
            objHtmlTable.Rows.Add(r)

            If Not grdList Is Nothing Then
                r = New HtmlTableRow
                c = New HtmlTableCell
                grdList.CssClass = "QH_DataGrid"
                grdList.AllowPaging = True
                grdList.CellPadding = 0
                grdList.AlternatingItemStyle.CssClass = "QH_DatagridAlternation"
                grdList.HeaderStyle.CssClass = "QH_DatagridHeader"
                grdList.PagerStyle.HorizontalAlign = HorizontalAlign.Right
                grdList.PagerStyle.Mode = PagerMode.NumericPages
                grdList.PagerStyle.CssClass = "ActivePage"
                c.Controls.Add(grdList)

                c.ColSpan = 2
                c.Align = "center"
                c.VAlign = "middle"
                r.Cells.Add(c)
                objHtmlTable.Rows.Add(r)
            End If
        End Sub
        'DanhMucUser
        'Danh Muc
        Public Sub CreateControlsUser(ByVal strTableName As String, ByVal objHtmlTable As HtmlTable, ByVal XMLFileName As String, _
        Optional ByVal btnUpdate As Control = Nothing, _
        Optional ByVal btnCancel As Control = Nothing)

            Dim row As Integer = 0
            'Generate rows and cells.
            Dim numrows As Integer = 5
            Dim numcells As Integer = 2
            Dim ds As New DataSet
            ds.ReadXml(XMLFileName)
            Dim dv As DataView = New DataView(ds.Tables(strTableName))
            Dim r As HtmlTableRow
            Dim c As HtmlTableCell
            Dim j As Integer
            For j = 0 To dv.Count - 1
                r = New HtmlTableRow
                Dim drw As DataRowView = dv.Item(j)
                Dim i As Integer
                c = New HtmlTableCell
                c.Controls.Add(CreateLabel(drw))
                c.Width = "25%"
                c.VAlign = "middle"
                r.Cells.Add(c)
                c = Nothing
                c = New HtmlTableCell
                c.Controls.Add(CreateInputControls(drw))
                c.Width = "75%"
                c.VAlign = "top"
                r.Cells.Add(c)
                c = Nothing
                objHtmlTable.Rows.Add(r)
            Next
            r = New HtmlTableRow
            c = New HtmlTableCell
            c.Controls.Add(New LiteralControl("<br>"))
            r.Cells.Add(c)
            objHtmlTable.Rows.Add(r)
            r = New HtmlTableRow
            c = New HtmlTableCell
            'c.Controls.Add(btnUpdate)
            'c.Controls.Add(btnCancel)
        End Sub
        Private Function CreateLabel(ByVal drw As DataRowView) As Label
            Dim lbl As New Label
            lbl.ID = "lbl" & drw.Item("ID").ToString & "1"
            lbl.Text = drw.Item("Description").ToString
            lbl.Visible = CType(Val(drw.Item("Visible")), Boolean)
            Return lbl
        End Function
        Private Function CreateInputControls(ByVal drw As DataRowView) As Control
            Dim obj As Control
            Select Case UCase(drw.Item("ControlType").ToString)
                Case "TEXTBOX"
                    obj = New TextBoxA
                    CType(obj, TextBox).ID = "txt" & drw.Item("ID").ToString
                    CType(obj, TextBox).Attributes.Add("runat", "server")

                    If drw.Item("TextMode").ToString <> "" Then
                        CType(obj, TextBox).TextMode = CType(drw.Item("TextMode"), TextBoxMode)
                    End If
                    If drw.Item("Width").ToString <> "" Then
                        CType(obj, TextBox).Width = New Unit((Val(drw.Item("Width"))))
                    End If
                    CType(obj, TextBoxA).IsNull = CType(Val(drw.Item("IsNull")), Boolean)
                    CType(obj, TextBoxA).IsKey = CType(Val(drw.Item("IsKey")), Boolean)
                    CType(obj, TextBoxA).Visible = CType(Val(drw.Item("Visible")), Boolean)
                    CType(obj, TextBoxA).IsNumber = CType(Val(drw.Item("IsNumber")), Boolean)
                    CType(obj, TextBoxA).Enabled = CType(drw.Item("Enabled"), Boolean)
                    CType(obj, TextBoxA).Text = CType(drw.Item("DefaultValue"), String)
                    CType(obj, TextBoxA).CssClass = CType(drw.Item("CssClass"), String)
                    If Val(drw.Item("MaxLength")) <> 0 Then
                        CType(obj, TextBoxA).MaxLength = CType(drw.Item("MaxLength"), Integer)
                    End If
                Case "DROPDOWNLIST"
                    obj = New DropDownList
                    CType(obj, DropDownList).ID = "cbo" & drw.Item("ID").ToString
                    CType(obj, DropDownList).Attributes.Add("runat", "server")
                    CType(obj, DropDownList).Attributes.Add("CssClass", CType(drw.Item("CssClass"), String))
                    If drw.Item("Width").ToString <> "" Then
                        CType(obj, DropDownList).Width = New Unit((Val(drw.Item("Width"))))
                    End If
                    'BindControl.BindDropDownList(CType(obj, DropDownList), drw.Item("DataSource").ToString, drw.Item("DefaultValue").ToString, CType(drw.Item("Isnull").ToString, Boolean))
                    If Val(drw.Item("IsNull")) = 0 Then
                        CType(obj, DropDownList).Attributes.Add("ISNULL", "NOTNULL")
                    End If
                    BindControl.BindDropDownList_StoreProc(CType(obj, DropDownList), True, drw.Item("DefaultValue").ToString, "sp_GetDanhMucCBO", ConfigurationSettings.AppSettings("commonDB"), drw.Item("DataSource").ToString)
                Case "CHECKBOXLIST"
                    obj = New CheckBoxList
                    CType(obj, CheckBoxList).ID = "cbl" & drw.Item("ID").ToString
                    CType(obj, CheckBoxList).Attributes.Add("runat", "server")
                    CType(obj, CheckBoxList).RepeatDirection = RepeatDirection.Vertical
                    CType(obj, CheckBoxList).RepeatColumns = 2
                    If drw.Item("Width").ToString <> "" Then
                        CType(obj, CheckBoxList).Width = New Unit((Val(drw.Item("Width"))))
                    End If
                    BindControl.BindCheckBoxList(CType(obj, CheckBoxList), drw.Item("DataSource").ToString, drw.Item("DefaultValue").ToString, CType(drw.Item("Isnull").ToString, Boolean))
                Case "CHECKBOX"
                    obj = New CheckBox
                    CType(obj, CheckBox).ID = "chk" & drw.Item("ID").ToString
                    CType(obj, CheckBox).Attributes.Add("runat", "server")
                    CType(obj, CheckBox).Enabled = CType(Val(drw.Item("Enabled")), Boolean)
                    CType(obj, CheckBox).Checked = True
            End Select
            Return obj
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Lay ma linh vuc ho so
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function GetLinhVuc() As String
            Return ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(HttpContext.Current.Session.Item("ActiveDB"), String))
        End Function
        Public Sub GetReportURL(ByVal TabCode As String, _
                                ByVal MaLinhVuc As String, _
                                ByVal ItemCode As String, _
                                ByVal Path As String, _
                                ByVal objCommand As Object, _
                                ByVal objControl As Object, _
                                Optional ByVal isInPhieuChuyen As Boolean = False)

            Dim objReportInfo As New ReportsInfo
            Dim objReport As New ReportController
            Dim strSQL As String
            With objReportInfo
                .MaLinhVuc = MaLinhVuc
                .TabCode = TabCode
                .ItemCode = ItemCode
            End With
            objReportInfo = objReport.GetReportInfo(objReportInfo)
            strSQL = objReport.GetParamArray(objReportInfo.ProcedureName, objControl)
            Dim strURL, strPath As String

            If objReportInfo.ReportName = "InBienNhan.rpt" Then
                strURL = "'" & "\" & MaLinhVuc & "\\" & objReportInfo.ReportName & _
                            "','" & strSQL & _
                            "','" & "Title" & _
                            "','" & objReportInfo.Title & _
                            "','" & Path & "'"
            Else
                strURL = "'" & objReportInfo.ReportName & _
                                            "','" & strSQL & _
                                            "','" & "Title" & _
                                            "','" & objReportInfo.Title & _
                                            "','" & Path & "'"
            End If

            If isInPhieuChuyen = True Then
                objCommand.Attributes.Add("onclick", "javascript:return ShowReport(" & strURL & ",'ABC');")
            Else
                objCommand.Attributes.Add("onclick", "javascript:ShowReport(" & strURL & ");")
            End If

        End Sub

        Function Trans_VietNam(ByVal mamt As Double)

            Const ones As String = "một  hai  ba   bốn  năm  sáu   bảy  tám  chín  "
            Const v_ones As String = "một  hai  ba   bốn  lăm  sáu  bảy  tám  chín  "
            Const v__ones As String = "một  hai  ba   bốn  lăm  sáu  bảy  tám  chín  "
            Const teen As String = "mười    mười một mười hai mười ba mười bốn mười lăm mười sáu mười bảy mười tám mười chín"
            Const tens As String = "TWENTY THIRTY FORTY  FIFTY  SIXTY  SEVENTYEIGHTY NINETY "
            Dim camt, enum_ As String
            camt = ""

            'mamt = 91100401918.79

            enum_ = Format(Abs(mamt), "###.00")

            enum_ = Left(enum_, Len(enum_) - 3)
            If Len(enum_) < 12 Then
                enum_ = Space(12 - Len(enum_)) + enum_
            End If

            'Check hundred of billion
            If Mid(enum_, 1, 1) > "0" Then
                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 1, 1)) - 1) * 5 + 1, 5)) + " trăm"
            End If
            If Mid(enum_, 2, 1) = "1" Then   'vidu "015,000,000"
                If Val(Mid(enum_, 3, 1)) > 0 Then
                    camt = camt + " mười " + Trim(Mid(v_ones, (Val(Mid(enum_, 3, 1)) - 1) * 5 + 1, 5)) + " tỷ"
                Else
                    camt = camt + " mười tỷ"
                End If
            Else
                If Mid(enum_, 2, 1) > "1" Then  'vidu 095,000,000
                    'camt = camt + " " + Trim(Mid(tens, (Val(Mid(enum_, 2, 1)) - 2) * 7 + 1, 7))
                    camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 2, 1)) - 1) * 5 + 1, 5)) + " mươi"
                    If Mid(enum_, 3, 1) > "0" Then
                        'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 3, 1)) - 1) * 5 + 1, 5)) + " BILLION"
                        camt = camt + " " + Trim(Mid(v__ones, (Val(Mid(enum_, 3, 1)) - 1) * 5 + 1, 5)) + " tỷ"
                    Else    'vidu "x20,000,000"
                        'camt = camt + " BILLION"
                        camt = camt + " tỷ"
                    End If
                Else    'vidu "x0x,000,000,000"
                    If Val(Mid(enum_, 1, 3)) = 0 Then
                        camt = camt
                    Else
                        If Mid(enum_, 3, 1) > "0" Then
                            'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 3, 1)) - 1) * 5 + 1, 5)) + " BILLION"
                            If Val(Mid(enum_, 1, 1)) > 0 And Val(Mid(enum_, 3, 1)) > 0 And Val(Mid(enum_, 2, 1)) = 0 Then
                                camt = camt + " lẻ " + Trim(Mid(ones, (Val(Mid(enum_, 3, 1)) - 1) * 5 + 1, 5)) + " tỷ"
                            Else
                                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 3, 1)) - 1) * 5 + 1, 5)) + " tỷ"
                            End If

                        Else
                            'camt = camt + " BILLION"
                            camt = camt + " tỷ"
                        End If
                    End If
                End If
            End If

            'Check hundred of million
            If Mid(enum_, 4, 1) > "0" Then
                'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 4, 1)) - 1) * 5 + 1, 5)) + " HUNDRED"
                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 4, 1)) - 1) * 5 + 1, 5)) + " trăm"
            Else
                If Val(Mid(enum_, 1, 4)) > 0 And Val(Mid(enum_, 5, 2)) > 0 Then
                    camt = camt + " không trăm"
                Else
                    camt = camt
                End If
            End If
            If Mid(enum_, 5, 1) = "1" Then   'vidu "015,000,000"
                'camt = camt + " " + Trim(Mid(teen, (Val(Mid(enum_, 6, 1))) * 9 + 1, 9)) + " MILLION"
                If Val(Mid(enum_, 6, 1)) = 0 Then
                    camt = camt + " mười triệu"
                Else
                    camt = camt + " mười " + Trim(Mid(v_ones, (Val(Mid(enum_, 6, 1)) - 1) * 5 + 1, 5)) + " triệu"
                End If
            Else
                If Mid(enum_, 5, 1) > "1" Then  'vidu 095,000,000
                    'camt = camt + " " + Trim(Mid(tens, (Val(Mid(enum_, 5, 1)) - 2) * 7 + 1, 7))
                    camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 5, 1)) - 1) * 5 + 1, 5)) + " mươi"
                    If Mid(enum_, 6, 1) > "0" Then
                        'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 6, 1)) - 1) * 5 + 1, 5)) + " MILLION"
                        camt = camt + " " + Trim(Mid(v__ones, (Val(Mid(enum_, 6, 1)) - 1) * 5 + 1, 5)) + " triệu"
                    Else    'vidu "x20,000,000"
                        'camt = camt + " MILLION"
                        camt = camt + " triệu"
                    End If
                Else    'vidu "x0x,000,000"
                    If Val(Mid(enum_, 4, 3)) = 0 Then
                        camt = camt
                    Else
                        If Mid(enum_, 6, 1) > "0" Then
                            'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 6, 1)) - 1) * 5 + 1, 5)) + " MILLION"
                            If Val(Mid(enum_, 5, 1)) = 0 And Val(Mid(enum_, 1, 4)) > 0 Then
                                camt = camt + " lẻ " + Trim(Mid(ones, (Val(Mid(enum_, 6, 1)) - 1) * 5 + 1, 5)) + " triệu"
                            Else
                                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 6, 1)) - 1) * 5 + 1, 5)) + " triệu"
                            End If
                        Else
                            'camt = camt + " MILLION"
                            camt = camt + " triệu"
                        End If
                    End If
                End If
            End If

            'Check hundreds of thousands
            If Mid(enum_, 7, 1) > "0" Then
                'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 7, 1)) - 1) * 5 + 1, 5)) + " HUNDRED"
                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 7, 1)) - 1) * 5 + 1, 5)) + " trăm"
            Else
                If Val(Mid(enum_, 1, 7)) > 0 And Val(Mid(enum_, 8, 2)) > 0 Then
                    camt = camt + " không trăm"
                Else
                    camt = camt
                End If
            End If
            If Mid(enum_, 8, 1) = "1" Then   'vidu "015,000"
                'camt = camt + " " + Trim(Mid(teen, (Val(Mid(enum_, 9, 1))) * 9 + 1, 9)) + " THOUSAND"
                If Val(Mid(enum_, 9, 1)) > 0 Then
                    camt = camt + " mười " + Trim(Mid(v_ones, (Val(Mid(enum_, 9, 1)) - 1) * 5 + 1, 5)) + " nghìn "
                Else
                    camt = camt + " mười nghìn"
                End If
            Else
                If Mid(enum_, 8, 1) > "1" Then  'vidu 095,000
                    'camt = camt + " " + Trim(Mid(tens, (Val(Mid(enum_, 8, 1)) - 2) * 7 + 1, 7))
                    camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 8, 1)) - 1) * 5 + 1, 5)) + " mươi"
                    If Mid(enum_, 9, 1) > "0" Then
                        'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 9, 1)) - 1) * 5 + 1, 5)) + " THOUSAND"
                        camt = camt + " " + Trim(Mid(v__ones, (Val(Mid(enum_, 9, 1)) - 1) * 5 + 1, 5)) + " nghìn"
                    Else    'vidu "x20,000"
                        'camt = camt + " THOUSAND"
                        camt = camt + " nghìn"
                    End If
                Else    'vidu "x0x,000"
                    If Val(Mid(enum_, 7, 3)) = 0 Then
                        camt = camt
                    Else
                        If Mid(enum_, 9, 1) > "0" Then
                            'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 9, 1)) - 1) * 5 + 1, 5)) + " THOUSAND"
                            If Val(Mid(enum_, 8, 1)) = 0 And Val(Mid(enum_, 1, 8)) > 0 Then
                                camt = camt + " lẻ " + Trim(Mid(ones, (Val(Mid(enum_, 9, 1)) - 1) * 5 + 1, 5)) + " nghìn"
                            Else
                                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 9, 1)) - 1) * 5 + 1, 5)) + " nghìn"
                            End If
                        Else
                            'camt = camt + " THOUSAND"
                            camt = camt + " nghìn"
                        End If
                    End If
                End If
            End If

            'Check hundreds
            If Mid(enum_, 10, 1) > "0" Then
                'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 10, 1)) - 1) * 5 + 1, 5)) + " HUNDRED"
                camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 10, 1)) - 1) * 5 + 1, 5)) + " trăm"
            Else
                'khong tram
                If Val(Mid(enum_, 1, 10)) > 0 And Val(Mid(enum_, 11, 2)) > 0 Then
                    camt = camt + " không trăm"
                Else
                    camt = camt + " "
                End If
            End If

            If Val(Mid(enum_, 11, 1)) = 0 And Val(Left(enum_, 11)) > 0 And Val(Mid(enum_, 12, 1)) > 0 Then
                camt = camt + " lẻ"
            End If

            'Check tens and ones

            If Mid(enum_, 11, 1) = "1" Then      'vidu 012
                'camt = camt + " " + Trim(Mid(teen, (Val(Mid(enum_, 12, 1))) * 9 + 1, 9))
                If Mid(enum_, 11, 2) = "10" Then
                    camt = camt + " mười"
                Else
                    camt = camt + " mười " + Trim(Mid(v_ones, (Val(Mid(enum_, 12, 1)) - 1) * 5 + 1, 5))
                End If
            Else
                If Mid(enum_, 11, 1) > "1" Then  'vidu 095
                    'camt = camt + " " + Trim(Mid(tens, (Val(Mid(enum_, 11, 1)) - 2) * 7 + 1, 7))
                    camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 11, 1)) - 1) * 5 + 1, 5)) + " mươi"
                    If Mid(enum_, 12, 1) > "0" Then
                        'camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 12, 1)) - 1) * 5 + 1, 5))
                        camt = camt + " " + Trim(Mid(v__ones, (Val(Mid(enum_, 12, 1)) - 1) * 5 + 1, 5))
                    End If
                Else    '008, 000
                    If Val(enum_) = 0 Then
                        camt = "không"
                    Else
                        If Mid(enum_, 12, 1) > "0" Then
                            camt = camt + " " + Trim(Mid(ones, (Val(Mid(enum_, 12, 1)) - 1) * 5 + 1, 5))
                        End If
                    End If
                End If
            End If

            Trans_VietNam = camt

        End Function
        Public Function ExportToExcel(ByVal dt As DataTable, ByVal sFile As String, _
                            ByVal sTemplate As String, _
                            Optional ByVal SheetName As String = "Sheet1", Optional ByVal iIndex As Integer = 0) As Boolean
            Dim oExcel As New Excel.Application
            Dim oBooks As Excel.Workbooks, oBook As Excel.Workbook
            Dim oSheets As Excel.Sheets, oSheet As Excel.Worksheet
            Dim oCells As Excel.Range
            Try
                oExcel.Visible = False : oExcel.DisplayAlerts = False
                'Start a new workbook
                oBooks = oExcel.Workbooks
                oBooks.Open(sTemplate)
                oBook = oBooks.Item(1)
                oSheets = oBook.Worksheets
                oSheet = CType(oSheets.Item(1), Excel.Worksheet)
                oSheet.Name = SheetName
                oCells = oSheet.Cells
                DumpData(dt, oCells, iIndex) 'Fill in the data
                oSheet.Range("A6:I15").Borders.LineStyle = 1
                'oSheet.Range(oCells(iIndex, 0), oCells(iIndex + dt.Rows.Count - 1, dt.Columns.Count - 1)).Borders.LineStyle = 1
                oSheet.SaveAs(sFile) 'Save in a temporary file
                ExportToExcel = True
            Catch ex As Exception
                ExportToExcel = False
            Finally
                oBook.Close()
                'Quit Excel and thoroughly deallocate everything
                oExcel.Quit()

                ReleaseComObject(oCells) : ReleaseComObject(oSheet)
                ReleaseComObject(oSheets) : ReleaseComObject(oBook)
                ReleaseComObject(oBooks) : ReleaseComObject(oExcel)
                oExcel = Nothing : oBooks = Nothing : oBook = Nothing
                oSheets = Nothing : oSheet = Nothing : oCells = Nothing
                System.GC.Collect()
            End Try
        End Function
        'Outputs a DataTable to an Excel Worksheet
        Private Function DumpData(ByVal dt As DataTable, ByVal oCells As Excel.Range, Optional ByVal iIndex As Integer = 0) As String
            Dim dr As DataRow, ary() As Object
            Dim iRow As Integer, iCol As Integer
            'Output Column Headers
            If iIndex = 0 Then
                For iCol = 0 To dt.Columns.Count - 1
                    oCells(2, iCol + 1) = dt.Columns(iCol).ToString
                Next
                'Output Data
                For iRow = 0 To dt.Rows.Count - 1
                    dr = dt.Rows.Item(iRow)
                    ary = dr.ItemArray
                    For iCol = 0 To UBound(ary)
                        oCells(iRow + 3, iCol + 1) = ary(iCol).ToString
                    Next
                Next
            Else
                For iRow = 0 To dt.Rows.Count - 1
                    dr = dt.Rows.Item(iRow)
                    ary = dr.ItemArray
                    For iCol = 0 To UBound(ary)
                        oCells(iRow + iIndex, iCol + 1) = ary(iCol).ToString
                    Next
                Next
            End If
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Ddl"></param>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	12/25/2007	Updated, set value by find value
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub DdLSelected(ByVal Ddl As DropDownList, ByVal Value As String)
            Dim i As Integer
            If Ddl.Items.Count > 0 Then
                Ddl.SelectedIndex = Ddl.Items.IndexOf(Ddl.Items.FindByValue(Value))
            End If
        End Sub
        Public Function GetArrayFromString(ByVal strInput As String, ByVal strSeperate As String) As ArrayList
            Dim pos, i As Integer
            Dim arr As New ArrayList

            While Left(strInput, 1) = strSeperate
                strInput = Right(strInput, Len(strInput) - Len(strSeperate))
            End While

            If Len(strInput) = 0 Then Return arr

            pos = InStr(strInput, strSeperate)
            If pos = 0 Then
                arr.Add(strInput)
                Return arr
            End If

            strInput = strInput & strSeperate

            While pos > 1
                arr.Add(Left(strInput, pos - 1))
                strInput = Right(strInput, Len(strInput) - Len(strSeperate) - pos + 1)
                While Left(strInput, 1) = strSeperate
                    strInput = Right(strInput, Len(strInput) - Len(strSeperate))
                End While
                pos = InStr(strInput, strSeperate)
            End While

            Return arr
        End Function
        Public Sub ProcessAddTableList(ByRef oDoc As Word.Document, ByVal arrTableList As ArrayList, ByVal dsDatasetlist As DataSet)
            If arrTableList Is Nothing Or dsDatasetlist Is Nothing Then
                Exit Sub
            End If

            If arrTableList.Count = 0 Or dsDatasetlist.Tables.Count = 0 Then
                Exit Sub
            End If

            Dim sumTable As Integer      'số table động sẽ được tạo
            Dim i, j As Integer
            Dim arr As ArrayList
            Dim tbl As Word.Table

            sumTable = arrTableList.Count
            If sumTable > dsDatasetlist.Tables.Count Then
                sumTable = dsDatasetlist.Tables.Count
            End If

            For i = 0 To sumTable - 1
                arr = GetArrayFromString(Trim(arrTableList(i)), "|")
                Try
                    If arr.Count > 0 Then
                        If Not IsInteger(arr(0)) Then
                            Exit Try
                        End If
                        tbl = oDoc.Tables(CInt(arr(0)))

                        For j = 1 To arr.Count - 1
                            If Not IsInteger(arr(j)) Then
                                Exit Try
                            End If
                            tbl = tbl.Tables(CInt(arr(0)))
                        Next

                        CreateTableInWord(tbl, dsDatasetlist.Tables(i))
                    End If
                Catch
                End Try
            Next
        End Sub
        Public Sub CreateTableInWord(ByRef tblWord As Word.Table, ByVal tblDataset As DataTable)

            If tblWord Is Nothing Then Exit Sub
            If tblDataset Is Nothing Then Exit Sub

            Dim i, j, NumOfRow As Integer
            Dim rowNext As Microsoft.Office.Interop.Word.Row
            Dim row As Microsoft.Office.Interop.Word.Row

            NumOfRow = tblDataset.Rows.Count
            For i = 0 To NumOfRow - 1
                rowNext = tblWord.Rows.Add()
                row = rowNext.Previous()
                For j = 1 To row.Cells.Count
                    row.Cells(j).Range.Text = tblDataset.Rows(i).Item(j - 1).ToString
                Next
            Next
            rowNext.Delete()
        End Sub
        Public Sub ReportByWord(ByVal ds As DataSet, ByVal TemplateFileName As String, ByVal ExportFileName As String, Optional ByVal arrTableList As ArrayList = Nothing, Optional ByVal dsDatasetList As DataSet = Nothing)
            If ds.Tables(0).Rows.Count = 0 Then Exit Sub
            Dim oWord As New Word.Application
            Dim oDoc As New Word.Document
            Dim i As Integer
            Dim s1 As String
            Dim s2 As String
            oWord.Documents.Open(strFileName)
            oDoc = oWord.ActiveDocument
            oDoc.SaveAs(strNewFileName)
            oDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            oWord.Documents.Open(strNewFileName)
            Dim j As Integer
            Dim n As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                With oWord.Selection.Find
                    .ClearFormatting()
                    .Text = UCase("<" & ds.Tables(0).Columns(i).ColumnName.ToString() & ">")
                    s1 = ds.Tables(0).Rows(0).Item(i).ToString()
                    j = 1
                    n = 200
                    If n > Len(s1) Then n = Len(s1)
                    If s1 = "" Then
                        With .Replacement
                            .ClearFormatting()
                            .Text = ""
                        End With
                        .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                    End If
                    While j <= Len(s1)
                        s2 = Mid(s1, j, n)
                        If j + n < Len(s1) Then s2 = s2 & (UCase("<" & ds.Tables(0).Columns(i).ColumnName.ToString() & ">"))
                        j = j + n
                        With .Replacement
                            .ClearFormatting()
                            .Text = s2
                        End With
                        .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        If n > Len(s1) - j Then n = Len(s1) - j + 1
                    End While
                End With
            Next
            oDoc = oWord.ActiveDocument
            ProcessAddTableList(oDoc, arrTableList, dsDatasetList)
            oDoc.Save()
            oDoc.Close()
            oWord.Application.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            oWord = Nothing
            oDoc = Nothing
            'KillProcessByName("WINWORD.EXE")

            
        End Sub
        Public Sub BindDropDownList_Dataset(ByVal obj As DropDownList, ByVal ds As DataSet, Optional ByVal TextColumn As String = "Ten", Optional ByVal ValueColumn As String = "Ma", Optional ByVal All As Boolean = True, Optional ByVal strDefaultValue As String = "")
            If ds.Tables(0).Columns.IndexOf(TextColumn) = -1 Or ds.Tables(0).Columns.IndexOf(ValueColumn) = -1 Then
                Exit Sub
            End If
            obj.DataSource = ds
            obj.DataTextField = TextColumn
            obj.DataValueField = ValueColumn
            obj.DataBind()

            If All = True Then
                Dim tmpItem As New ListItem
                tmpItem.Value = ""
                tmpItem.Text = ""
                obj.Items.Insert(0, tmpItem)
            End If

            If strDefaultValue <> "" Then
                obj.ClearSelection()
                If obj.Items.Count > 0 Then
                    Dim lst As ListItem
                    lst = obj.Items.FindByValue(strDefaultValue)
                    If Not lst Is Nothing Then
                        lst.Selected = True
                    End If
                End If
            End If

        End Sub

        Public Function GetCookieName(ByVal Request As HttpRequest) As String
            If Request.Cookies("UserID") Is Nothing Then
                GetCookieName = ""
            Else
                GetCookieName = GetDomainName(Request) & CStr(gPortalID) & Request.Cookies("UserID").Value
            End If
        End Function

        'ThuyTT add date 06/10/2005

        'hàm này dùng để lấy tên thư mục tương ứng với ActiveDB
        Public Function getFolderPath() As String
            Return CStr(ConfigurationSettings.AppSettings("FolderPath" & CType(HttpContext.Current.Session.Item("ActiveDB"), String)))
        End Function

        'lấy đường dẫn đến thư mục template của file Word
        Public Function getTemplatePathOfWord() As String
            Return getFolderPath() & "\" & CStr(ConfigurationSettings.AppSettings("WordTemplatePath"))
        End Function

        'lấy đường dẫn đến thư mục output của file Word
        Public Function getOutputPathOfWord() As String
            Return getFolderPath() & "\" & CStr(ConfigurationSettings.AppSettings("WordOutputPath"))
        End Function

        'lấy đường dẫn đến thư mục template của file Excel
        Public Function getTemplatePathOfExcel() As String
            Return getFolderPath() & "\" & CStr(ConfigurationSettings.AppSettings("ExcelTemplatePath"))
        End Function

        'lấy đường dẫn đến thư mục output của file Excel
        Public Function getOutputPathOfExcel() As String
            Return getFolderPath() & "\" & CStr(ConfigurationSettings.AppSettings("ExcelOutputPath"))
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Generate a random string
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	1/19/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function genRandomKey() As String
            Dim KeyGen As RandomKeyGenerator
            Dim NumKeys As Integer
            Dim i_Keys As Integer
            Dim RandomKey As String

            KeyGen = New RandomKeyGenerator
            KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
            KeyGen.KeyNumbers = "0123456789"
            KeyGen.KeyChars = 23 'key has 20 characters
            RandomKey = KeyGen.Generate()
            Return RandomKey
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 'Mục đích: tạo ra file Word từ file template
        '''Giá trị in:
        '''     - request: sử dụng để lấy đường dẫn đến source chương trình
        '''     - ds: dataset chứa giá trị cần đưa vào file Tempalte
        '''     - strItemCode: mã lĩnh vực (CPKT, CPXD, ....)
        '''     - TemplateFileName: tên của file template
        '''     - ExportFileName: tên của file output
        ''' </summary>
        ''' <param name="request"></param>
        ''' <param name="ds"></param>
        ''' <param name="strItemCode"></param>
        ''' <param name="TemplateFileName"></param>
        ''' <param name="ExportFileName"></param>
        ''' <returns>đoạn script cho phép người dùng xem file hoặc download file về</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	1/19/2007	Updated, fix loi open file readonly
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function f_ExportWordFile(ByVal request As HttpRequest, ByVal ds As DataSet, ByVal strItemCode As String, ByVal TemplateFileName As String, ByVal ExportFileName As String) As String
            Dim url As String
            Dim Script As String
            Dim strServerPath As String
            Dim Tool As OfficeTools.WordTools = New OfficeTools.WordTools

            If Right(TemplateFileName, 4) <> ".doc" Then
                Exit Function
            End If

            strServerPath = GetAbsoluteServerPath(request)

            Dim sFileName As String
            Dim sourceFileName As String = strServerPath & getTemplatePathOfWord() & strItemCode & "\" & TemplateFileName
            Dim destFilePath As String = strServerPath & getOutputPathOfWord() & strItemCode & "\"
            Do
                sFileName = genRandomKey() & ".doc"
                If (Not File.Exists(destFilePath & sFileName)) Then
                    Exit Do
                End If
            Loop
            File.Copy(sourceFileName, destFilePath & sFileName)

            Dim m_doc As New OfficeHelper.Utilities.Data.WordHelper
            m_doc.Open(destFilePath & sFileName)
            If ds.Tables.Count > 1 Then
                If (ds.Tables(1).Rows.Count > 0) Then
                    m_doc.ExecuteWithRegions(ds)
                End If
            End If
            m_doc.MergeField(ds.Tables(0))
            m_doc.Save(destFilePath & ExportFileName)
            f_ExportWordFile = getOutputPathOfWord().Replace("\", "/") & strItemCode & "/" & ExportFileName
            Try
                File.Delete(destFilePath & sFileName)
            Catch
            End Try
        End Function

        'hàm dùng để lấy giá trị của Param được qui định trong thư mục PARAMS
        Public Function GetParamValue(ByVal pMaLinhVuc As String, ByVal pParamName As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_getParamValue", pMaLinhVuc, pParamName)
        End Function
        'hàm này được sử dụng trường hợp condition dropdownlist đã được set giá trị mặc định,
        'result dropdownlist chỉ hiển thị những record  tương ứng với giá trị này
        Public Function ReLoadComboFilter(ByVal ctrlScriptComboFilter As ComboFilter, ByVal ddlResult As DropDownList) As String
            Dim str As String
            str = "<script language='javascript'>"
            str = str & "ComboFilter" & ctrlScriptComboFilter.ID & "('1');"
            str = str & "document.all('" & ddlResult.ClientID & "').value='" & ddlResult.SelectedValue & "';"
            str = str & "</script>"
            Return str
        End Function
        'ThuyTT end
        Public Function GetUserSignedIn(ByVal Username As String) As String
            Dim sqlCmd As New SqlCommand
            Dim sqlConnect As New SqlClient.SqlConnection
            Dim ds As New DataSet
            Dim userid As String
            sqlConnect.ConnectionString = ConfigurationSettings.AppSettings("connectionStringPortalQH")
            sqlConnect.Open()
            sqlCmd.Connection = sqlConnect
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandText = "sp_GetUserIDByUserName"
            sqlCmd.Parameters.Add(New SqlParameter("@pUserName", Username))
            Dim da As New SqlDataAdapter(sqlCmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                userid = dt.Rows(0)("userid").ToString
            End If
            sqlConnect.Close()
            sqlCmd = Nothing
            sqlConnect = Nothing
            Return userid
        End Function
        Public Function CheckUserSignIn(ByVal IPAddress As String, ByVal UserName As String) As String
            Dim sqlCmd As New SqlCommand
            Dim sqlConnect As New SqlClient.SqlConnection
            Dim ds As New DataSet
            sqlConnect.ConnectionString = ConfigurationSettings.AppSettings("connectionStringPortalQH")
            sqlConnect.Open()
            sqlCmd.Connection = sqlConnect
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandText = "sp_GetUserSignedin"
            sqlCmd.Parameters.Add(New SqlParameter("@pIPAddress", IPAddress))
            sqlCmd.Parameters.Add(New SqlParameter("@pUserName", UserName))
            Dim da As New SqlDataAdapter(sqlCmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                UserName = dt.Rows(0)("username").ToString
            End If
            sqlConnect.Close()
            sqlCmd = Nothing
            sqlConnect = Nothing
            Return UserName
        End Function
        Public Sub UpdateProgramAccess(ByVal username As String, ByVal IPAddress As String)
            Dim sqlCmd As New SqlCommand
            Dim sqlConnect As New SqlClient.SqlConnection
            Dim ds As New DataSet
            sqlConnect.ConnectionString = ConfigurationSettings.AppSettings("connectionStringPortalQH")
            sqlConnect.Open()
            sqlCmd.Connection = sqlConnect
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandText = "sp_AddProgramUserAccess"
            sqlCmd.Parameters.Add(New SqlParameter("@pUserName", username))
            sqlCmd.Parameters.Add(New SqlParameter("@pIPAddress", IPAddress))
            sqlCmd.Parameters.Add(New SqlParameter("@pProgram", ConfigurationSettings.AppSettings("Name")))
            sqlCmd.ExecuteNonQuery()
            sqlConnect.Close()
            sqlCmd = Nothing
            sqlConnect = Nothing
        End Sub
        Public Sub DeleteProgramAccess(ByVal username As String, ByVal IPAddress As String)
            Dim sqlCmd As New SqlCommand
            Dim sqlConnect As New SqlClient.SqlConnection
            Dim ds As New DataSet
            sqlConnect.ConnectionString = ConfigurationSettings.AppSettings("connectionStringPortalQH")
            sqlConnect.Open()
            sqlCmd.Connection = sqlConnect
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandText = "sp_DelUserAccessProgram"
            sqlCmd.Parameters.Add(New SqlParameter("@pUserName", username))
            sqlCmd.Parameters.Add(New SqlParameter("@pIPAddress", IPAddress))
            sqlCmd.Parameters.Add(New SqlParameter("@pProgram", ConfigurationSettings.AppSettings("Name")))
            sqlCmd.ExecuteNonQuery()
            sqlConnect.Close()
            sqlCmd = Nothing
            sqlConnect = Nothing
        End Sub
        'HieuLc
        Public Function InPhieuChuyenPhuongXa(ByVal request As HttpRequest, ByVal ds As DataSet, ByVal strItemCode As String, ByVal PhieuChuyen As String) As String
            Dim url As String
            Dim Script As String
            Dim strServerPath As String

            'Dim strTemplateFileName As String = GetParamByID("FilePhieuChuyen", glbXMLFile)
            Dim strTemplateFileName As String = PhieuChuyen

            strServerPath = GetAbsoluteServerPath(request)

            Dim sFileName As String
            Dim sourceFileName As String = strServerPath & getTemplatePathOfWord() & strItemCode & "\PhuongXa\" & strTemplateFileName
            Dim destFilePath As String = strServerPath & getOutputPathOfWord() & strItemCode & "\PhuongXa\"

            Do
                sFileName = genRandomKey() & ".doc"
                If (Not File.Exists(destFilePath & sFileName)) Then
                    Exit Do
                End If
            Loop
            File.Copy(sourceFileName, destFilePath & sFileName)

            'Open temp file
            Dim m_doc As New OfficeHelper.Utilities.Data.WordHelper
            m_doc.Open(destFilePath & sFileName)

            'Phan thong tin chinh
            m_doc.MergeField(ds.Tables(0))

            'Close file
            m_doc.Save()

            InPhieuChuyenPhuongXa = getOutputPathOfWord().Replace("\", "/") & strItemCode & "/PhuongXa/" & sFileName

        End Function
        Public Sub GetReport_TKBC_phuongXa(ByVal TabCode As String, _
                                      ByVal MaLinhVuc As String, _
                                      ByVal MaNguoiXemBaoCao As String, _
                                      ByVal ItemCode As String, _
                                      ByVal Path As String, _
                                      ByVal objCommand As Object, _
                                      ByVal objControl As Object, _
                                      Optional ByVal isInPhieuChuyen As Boolean = False)

            Dim objReportInfo As New ReportsInfo
            Dim objReport As New ReportController
            Dim strSQL As String
            With objReportInfo
                .MaLinhVuc = MaLinhVuc
                .TabCode = TabCode
                .ItemCode = ItemCode
                .MaNguoiXemBaoCao = MaNguoiXemBaoCao
            End With
            objReportInfo = objReport.GetReportPhuongXa(objReportInfo)
            strSQL = objReport.GetParamArray(objReportInfo.ProcedureName, objControl)
            Dim strURL, strPath As String

            If objReportInfo.ReportName = "InBienNhan.rpt" Then
                strURL = "'" & "\" & MaLinhVuc & "\\" & objReportInfo.ReportName & _
                            "','" & strSQL & _
                            "','" & "Title" & _
                            "','" & objReportInfo.Title & _
                            "','" & Path & "'"
            Else
                strURL = "'" & objReportInfo.ReportName & _
                                            "','" & strSQL & _
                                            "','" & "Title" & _
                                            "','" & objReportInfo.Title & _
                                            "','" & Path & "'"
            End If

            If isInPhieuChuyen = True Then
                objCommand.Attributes.Add("onclick", "javascript:return ShowReport(" & strURL & ",'ABC');")
            Else
                objCommand.Attributes.Add("onclick", "javascript:ShowReport(" & strURL & ");")
            End If

        End Sub
        'End HieuLC
#Region "Methods For Encrypt and Decrypt"
        Dim mCryptoService As SymmetricAlgorithm = Nothing
        Dim mEncryptor As ICryptoTransform = Nothing
        Dim mDecryptor As ICryptoTransform = Nothing
        Dim sKey As String = "P@ssw0rdP@ssw0rd"

        Private Function GetLegalKey(ByVal Key As String) As Byte()
            Dim sTemp As String = Key
            If (mCryptoService.LegalKeySizes.Length > 0) Then
                Dim moreSize As Integer = mCryptoService.LegalKeySizes(0).MinSize
                ' key sizes are in bits
                If (sTemp.Length * 8 > mCryptoService.LegalKeySizes(0).MaxSize) Then
                    ' get the left of the key up to the max size allowed
                    sTemp = sTemp.Substring(0, mCryptoService.LegalKeySizes(0).MaxSize / 8)
                ElseIf (sTemp.Length * 8 < moreSize) Then
                    If (mCryptoService.LegalKeySizes(0).SkipSize = 0) Then
                        ' simply pad the key with spaces up to the min size allowed
                        sTemp = sTemp.PadRight(moreSize / 8, " ")
                    Else
                        While (sTemp.Length * 8 > moreSize)
                            moreSize += mCryptoService.LegalKeySizes(0).SkipSize
                        End While

                        sTemp = sTemp.PadRight(moreSize / 8, " ")
                    End If
                End If
            End If
            'convert the secret key to byte array
            Return ASCIIEncoding.ASCII.GetBytes(sTemp)
        End Function

        Public Function EncryptText(ByVal PlainText As String) As String
            mCryptoService = New DESCryptoServiceProvider
            Dim Key() As Byte = GetLegalKey(sKey)
            mCryptoService.Key = Key
            mCryptoService.Mode = CipherMode.ECB
            mEncryptor = mCryptoService.CreateEncryptor()
            mDecryptor = mCryptoService.CreateDecryptor()
            Dim mCipher As String = IIf(PlainText Is Nothing, String.Empty, PlainText)
            If (mCipher.Length > 0) Then
                Dim buff() As Byte
                buff = UTF8Encoding.UTF8.GetBytes(mCipher)
                mCipher = Convert.ToBase64String(mEncryptor.TransformFinalBlock(buff, 0, buff.Length))
            End If
            Return mCipher
        End Function
        Public Function DecryptText(ByVal CipherText As String) As String
            mCryptoService = New DESCryptoServiceProvider
            Dim Key() As Byte = GetLegalKey(sKey)
            mCryptoService.Key = Key
            mCryptoService.Mode = CipherMode.ECB
            mEncryptor = mCryptoService.CreateEncryptor()
            mDecryptor = mCryptoService.CreateDecryptor()
            Dim mPlain As String = IIf(CipherText Is Nothing, String.Empty, CipherText)
            If (mPlain.Length > 0) Then
                Dim buff() As Byte
                buff = Convert.FromBase64String(mPlain)
                mPlain = UTF8Encoding.UTF8.GetString(mDecryptor.TransformFinalBlock(buff, 0, buff.Length))
            End If
            Return mPlain
        End Function
        Public Function DecryptQueryParam(ByVal CipherText As String) As String
            mCryptoService = New DESCryptoServiceProvider
            Dim Key() As Byte = GetLegalKey(sKey)
            mCryptoService.Key = Key
            mCryptoService.Mode = CipherMode.ECB
            mEncryptor = mCryptoService.CreateEncryptor()
            mDecryptor = mCryptoService.CreateDecryptor()
            Dim mPlain As String = IIf(CipherText Is Nothing, String.Empty, CipherText.Replace(" ", "+"))
            If (mPlain.Length > 0) Then
                Dim buff() As Byte
                buff = Convert.FromBase64String(mPlain)
                mPlain = UTF8Encoding.UTF8.GetString(mDecryptor.TransformFinalBlock(buff, 0, buff.Length))
            End If
            Return mPlain
        End Function

#End Region
    End Module
End Namespace
