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

Imports System.Collections.Specialized
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports Microsoft.ApplicationBlocks.ExceptionManagement
Imports System.Web
Imports System.Reflection
Imports System.Diagnostics



Namespace PortalQH

    Public Module Exceptions


        Public Function GetExceptionInfo(ByVal e As Exception) As ExceptionInfo
            Dim objExceptionInfo As New ExceptionInfo

            Do Until e.InnerException Is Nothing
                e = e.InnerException
            Loop

            Dim st As New StackTrace(e, True)
            Dim i As Integer

            For i = 0 To st.FrameCount - 1
                ' Get the i-th stack frame.
                Dim sf As StackFrame = st.GetFrame(i)
                ' Get the corresponding method for that stack frame.
                Dim mi As MemberInfo = sf.GetMethod
                ' Get the namespace where that method is defined.
                Dim res As String = mi.DeclaringType.Namespace & "."
                ' Append the type name.
                res &= mi.DeclaringType.Name & "."
                ' Append the name of the method.
                res &= mi.Name
                objExceptionInfo.Method = res
                If sf.GetFileName <> "" Then
                    objExceptionInfo.FileName = sf.GetFileName
                    objExceptionInfo.FileColumnNumber = sf.GetFileColumnNumber
                    objExceptionInfo.FileLineNumber = sf.GetFileLineNumber
                End If

                Return objExceptionInfo
            Next
        End Function


        Public Sub ProcessModuleLoadException(ByVal FriendlyMessage As String, ByVal ctrlModule As PortalModuleControl, ByVal exc As Exception, ByVal DisplayErrorMessage As Boolean)
            If ThreadAbortCheck(exc) Then Exit Sub
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Try
                If Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "N" Then
                    Throw New ModuleLoadException(FriendlyMessage, exc)
                Else
                    Dim lex As New ModuleLoadException(exc.Message.ToString, exc, ctrlModule.ModuleConfiguration)
                    'publish the exception
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)

                    'Some modules may want to suppress an error message
                    'and just log the exception.
                    If DisplayErrorMessage Then
                        Dim ErrorPlaceholder As PlaceHolder = CType(ctrlModule.Parent.FindControl("MessagePlaceHolder"), PlaceHolder)
                        If Not ErrorPlaceholder Is Nothing Then

                            'hide the module
                            ctrlModule.Visible = False
                            ErrorPlaceholder.Visible = True
                            ErrorPlaceholder.Controls.Add(New ErrorContainer(_portalSettings, FriendlyMessage, lex).Container)                        'add the error message to the error placeholder
                        Else
                            'there's no ErrorPlaceholder, add it to the module's control collection
                            ctrlModule.Controls.Add(New ErrorContainer(_portalSettings, FriendlyMessage, lex).Container)
                        End If
                    End If
                End If
            Catch exc2 As Exception When Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "Y"
                ProcessPageLoadException(exc2)
            End Try
        End Sub
        Public Sub ProcessModuleLoadException(ByVal ctrlModule As PortalModuleControl, ByVal exc As Exception)
            ProcessModuleLoadException("Error: " + ctrlModule.ModuleConfiguration.ModuleTitle + " is currently unavailable.", ctrlModule, exc, True)
        End Sub
        Public Sub ProcessModuleLoadException(ByVal ctrlModule As PortalModuleControl, ByVal exc As Exception, ByVal DisplayErrorMessage As Boolean)
            ProcessModuleLoadException("Error: " + ctrlModule.ModuleConfiguration.ModuleTitle + " is currently unavailable.", ctrlModule, exc, DisplayErrorMessage)
        End Sub

        Public Sub ProcessModuleLoadException(ByVal FriendlyMessage As String, ByVal UserCtrl As Control, ByVal exc As Exception)

            If ThreadAbortCheck(exc) Then Exit Sub

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Try

                If Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "N" Then
                    Throw New ModuleLoadException(FriendlyMessage, exc)
                Else
                    Dim lex As New ModuleLoadException(exc.Message.ToString, exc)
                    'publish the exception
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                    'add the error message to the user control
                    UserCtrl.Controls.Add(New ErrorContainer(_portalSettings, FriendlyMessage, lex).Container)
                End If
            Catch When Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "Y"
                ProcessPageLoadException(exc)
            End Try
        End Sub


        Public Sub ProcessModuleLoadException(ByVal FriendlyMessage As String, ByVal ctrlModule As Control, ByVal exc As Exception, ByVal DisplayErrorMessage As Boolean)
            If ThreadAbortCheck(exc) Then Exit Sub
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Try
                If Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "N" Then
                    Throw New ModuleLoadException(FriendlyMessage, exc)
                Else
                    Dim lex As New ModuleLoadException(exc.Message.ToString, exc)
                    'publish the exception
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)

                    'Some modules may want to suppress an error message
                    'and just log the exception.
                    If DisplayErrorMessage Then
                        Dim ErrorPlaceholder As PlaceHolder = CType(ctrlModule.Parent.FindControl("MessagePlaceHolder"), PlaceHolder)
                        If Not ErrorPlaceholder Is Nothing Then

                            'hide the module
                            ctrlModule.Visible = False
                            ErrorPlaceholder.Visible = True

                            ErrorPlaceholder.Controls.Add(New ErrorContainer(_portalSettings, FriendlyMessage, lex).Container)                        'add the error message to the error placeholder
                        Else
                            'there's no ErrorPlaceholder, add it to the module's control collection
                            ctrlModule.Controls.Add(New ErrorContainer(_portalSettings, FriendlyMessage, lex).Container)
                        End If
                    End If
                End If
            Catch exc2 As Exception When Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "Y"
                ProcessPageLoadException(exc2)
            End Try
        End Sub
        Public Sub ProcessModuleLoadException(ByVal UserCtrl As Control, ByVal exc As Exception)
            ProcessModuleLoadException("An error has occurred.", UserCtrl, exc)
        End Sub
        Public Sub ProcessModuleLoadException(ByVal UserCtrl As Control, ByVal exc As Exception, ByVal DisplayErrorMessage As Boolean)
            ProcessModuleLoadException("An error has occurred.", UserCtrl, exc, DisplayErrorMessage)
        End Sub


        Public Sub ProcessPageLoadException(ByVal exc As Exception)
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            ProcessPageLoadException(exc, "DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId.ToString & "&def=ErrorMessage")
        End Sub
        Public Sub ProcessPageLoadException(ByVal exc As Exception, ByVal URL As String)
            If ThreadAbortCheck(exc) Then Exit Sub

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If Convert.ToString(_portalSettings.HostSettings("UseCustomErrorMessages")) = "N" Then
                Throw New PageLoadException(exc.Message, exc)
            Else
                Dim lex As New PageLoadException(exc.Message.ToString, exc)
                'publish the exception
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                ' redirect

                If URL <> "" Then
                    If URL.IndexOf("&error=terminate") <> -1 Then
                        HttpContext.Current.Response.Clear()
                        HttpContext.Current.Server.Transfer("~/ErrorPage.aspx")
                    Else
                        HttpContext.Current.Response.Redirect(URL, True)
                    End If
                End If
            End If
        End Sub

        Private Function ThreadAbortCheck(ByVal exc As Exception) As Boolean
            If TypeOf exc Is Threading.ThreadAbortException Then
                Threading.Thread.ResetAbort()
                Return True
            Else : Return False
            End If

        End Function
    End Module

    <Serializable()> Public Class BasePortalException
        Inherits BaseApplicationException

        Private m_AssemblyVersion As String
        Private m_DatabaseVersion As String
        Private m_PortalID As Integer
        Private m_UserID As String
        Private m_ActiveTabID As Integer
        Private m_ActiveTabName As String
        Private m_AbsoluteURL As String
        Private m_AbsoluteURLReferrer As String
        Private m_ExceptionGUID As String
        Private m_InnerExceptionString As String
        Private m_FileName As String
        Private m_FileLineNumber As Integer
        Private m_FileColumnNumber As Integer
        Private m_Method As String

        ' default constructor
        Public Sub New()
            MyBase.New()
        End Sub

        'constructor with exception message
        Public Sub New(ByVal message As String)
            MyBase.New(message)
            InitilizePrivateVariables()
        End Sub

        ' constructor with message and inner exception
        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
            InitilizePrivateVariables()
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            InitilizePrivateVariables()
            m_AssemblyVersion = info.GetString("m_AssemblyVersion")
            m_DatabaseVersion = info.GetString("m_DatabaseVersion")
            m_PortalID = info.GetInt32("m_PortalID")
            m_UserID = info.GetString("m_UserID")
            m_ActiveTabID = info.GetInt32("m_ActiveTabID")
            m_ActiveTabName = info.GetString("m_ActiveTabName")
            m_AbsoluteURL = info.GetString("m_AbsoluteURL")
            m_AbsoluteURLReferrer = info.GetString("m_AbsoluteURLReferrer")
            m_ExceptionGUID = info.GetString("m_ExceptionGUID")
            m_InnerExceptionString = info.GetString("m_InnerExceptionString")
            m_FileName = info.GetString("m_FileName")
            m_FileLineNumber = info.GetInt32("m_FileLineNumber")
            m_FileColumnNumber = info.GetInt32("m_FileColumnNumber")
            m_Method = info.GetString("m_Method")
        End Sub

        Private Sub InitilizePrivateVariables()
            'Try and get the Portal settings from context
            'If an error occurs getting the context then set the variables to -1
            Try
                Dim _context As HttpContext = HttpContext.Current
                Dim _portalSettings As PortalSettings = CType(_context.Items("PortalSettings"), PortalSettings)
                Dim _exceptionInfo As ExceptionInfo = GetExceptionInfo(Me)

                Try
                    m_FileName = _exceptionInfo.FileName
                Catch
                    m_FileName = ""
                End Try

                Try
                    m_FileLineNumber = _exceptionInfo.FileLineNumber
                Catch
                    m_FileLineNumber = -1
                End Try

                Try
                    m_FileColumnNumber = _exceptionInfo.FileColumnNumber
                Catch
                    m_FileColumnNumber = -1
                End Try

                Try
                    m_Method = _exceptionInfo.Method
                Catch
                    m_Method = ""
                End Try

                Try
                    m_AbsoluteURLReferrer = _context.Request.UrlReferrer.AbsoluteUri
                Catch
                    m_AbsoluteURLReferrer = ""
                End Try

                Try
                    m_AbsoluteURL = _context.Request.Url.AbsolutePath
                Catch
                    m_AbsoluteURL = ""
                End Try

                Try
                    m_PortalID = _portalSettings.PortalId
                    m_DatabaseVersion = _portalSettings.DatabaseVersion
                Catch
                    m_DatabaseVersion = "-1"
                End Try

                Try
                    m_UserID = CType(_context.User.Identity.Name, String)
                Catch
                    m_UserID = ""
                End Try

                Try
                    m_AssemblyVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(_context.Server.MapPath(_context.Request.ApplicationPath & "/bin/PortalQH.dll")).ProductVersion.ToString
                Catch
                    m_AssemblyVersion = "-1"
                End Try

                Try
                    m_ActiveTabID = _portalSettings.ActiveTab.TabId
                Catch ex As Exception
                    m_ActiveTabID = -1
                End Try

                Try
                    m_ActiveTabName = _portalSettings.ActiveTab.TabName
                Catch ex As Exception
                    m_ActiveTabName = ""
                End Try

                Try
                    m_ExceptionGUID = Guid.NewGuid.ToString
                Catch ex As Exception
                    m_ExceptionGUID = ""
                End Try

            Catch exc As Exception
                m_PortalID = -1
                m_DatabaseVersion = "-1"
                m_UserID = ""
                m_AssemblyVersion = "-1"
                m_ActiveTabID = -1
                m_ActiveTabName = ""
                m_AbsoluteURL = ""
                m_AbsoluteURLReferrer = ""
                m_ExceptionGUID = ""
                m_FileName = ""
                m_FileLineNumber = -1
                m_FileColumnNumber = -1
                m_Method = ""

            End Try
        End Sub

        <SecurityPermission(SecurityAction.Demand, SerializationFormatter:=True)> _
        Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            ' Serialize this class' state and then call the base class GetObjectData
            info.AddValue("m_AssemblyVersion", m_AssemblyVersion, GetType(String))
            info.AddValue("m_DatabaseVersion", m_DatabaseVersion, GetType(String))
            info.AddValue("m_PortalID", m_PortalID, GetType(Int32))
            info.AddValue("m_UserID", m_UserID, GetType(String))
            info.AddValue("m_ActiveTabID", m_ActiveTabID, GetType(Int32))
            info.AddValue("m_ActiveTabName", m_ActiveTabName, GetType(String))
            info.AddValue("m_AbsoluteURL", m_AbsoluteURL, GetType(String))
            info.AddValue("m_ExceptionGUID", m_ExceptionGUID, GetType(String))
            info.AddValue("m_AbsoluteURLReferrer", m_AbsoluteURLReferrer, GetType(String))
            info.AddValue("m_FileName", m_FileName, GetType(String))
            info.AddValue("m_FileLineNumber", m_FileLineNumber, GetType(Int32))
            info.AddValue("m_FileColumnNumber", m_FileColumnNumber, GetType(Int32))
            info.AddValue("m_Method", m_Method, GetType(String))


            MyBase.GetObjectData(info, context)
        End Sub
        Public ReadOnly Property FileName() As String
            Get
                Return m_FileName
            End Get
        End Property
        Public ReadOnly Property FileLineNumber() As String
            Get
                Return m_FileLineNumber.ToString
            End Get
        End Property
        Public ReadOnly Property FileColumnNumber() As String
            Get
                Return m_FileColumnNumber.ToString
            End Get
        End Property
        Public ReadOnly Property Method() As String
            Get
                Return m_Method
            End Get
        End Property

        Public ReadOnly Property DatabaseVersion() As String
            Get
                Return m_DatabaseVersion
            End Get
        End Property

        Public ReadOnly Property AssemblyVersion() As String
            Get
                Return m_AssemblyVersion
            End Get
        End Property

        Public ReadOnly Property PortalID() As Integer
            Get
                Return m_PortalID
            End Get
        End Property

        Public ReadOnly Property UserID() As String
            Get
                Return m_UserID
            End Get
        End Property

        Public ReadOnly Property ActiveTabID() As Integer
            Get
                Return m_ActiveTabID
            End Get
        End Property

        Public ReadOnly Property ActiveTabName() As String
            Get
                Return m_ActiveTabName
            End Get
        End Property

        Public ReadOnly Property AbsoluteURL() As String
            Get
                Return m_AbsoluteURL
            End Get
        End Property

        Public ReadOnly Property AbsoluteURLReferrer() As String
            Get
                Return m_AbsoluteURLReferrer
            End Get
        End Property

        Public ReadOnly Property ExceptionGUID() As String
            Get
                Return m_ExceptionGUID
            End Get
        End Property

    End Class

    Public Class ErrorContainer
        Inherits Control

        Private _Container As Skins.ModuleMessage
        Public Property Container() As Skins.ModuleMessage
            Get
                Return _Container
            End Get
            Set(ByVal Value As Skins.ModuleMessage)
                _Container = Value
            End Set
        End Property

        Public Sub New(ByVal strError As String)
            Container = FormatException(strError)
        End Sub
        Public Sub New(ByVal strError As String, ByVal exc As Exception)
            Container = FormatException(strError, exc)
        End Sub
        Public Sub New(ByVal _PortalSettings As PortalSettings, ByVal strError As String, ByVal exc As Exception)
            Dim PortalSecurity As New PortalSecurity
            If PortalSecurity.IsInRole(_PortalSettings.SuperUserId.ToString) Then
                Container = FormatException(strError, exc)
            Else
                Container = FormatException(strError)
            End If
        End Sub
        Private Function FormatException(ByVal strError As String) As Skins.ModuleMessage
            Dim m As Skins.ModuleMessage
            m = Skin.GetModuleMessageControl("An error has occurred.", strError, Skins.ModuleMessage.ModuleMessageType.RedError)
            Return m
        End Function
        Private Function FormatException(ByVal strError As String, ByVal exc As Exception) As Skins.ModuleMessage
            Dim m As Skins.ModuleMessage
            If Not exc Is Nothing Then
                m = Skin.GetModuleMessageControl(strError, exc.ToString, Skins.ModuleMessage.ModuleMessageType.RedError)
            Else
                m = Skin.GetModuleMessageControl("An error has occurred.", strError, Skins.ModuleMessage.ModuleMessageType.RedError)
            End If
            Return m
        End Function
    End Class
    Public Class ExceptionInfo
        Private _Method As String
        Private _FileColumnNumber As Integer
        Private _FileName As String
        Private _FileLineNumber As Integer

        Public Property Method() As String
            Get
                Return _Method
            End Get
            Set(ByVal Value As String)
                _Method = Value
            End Set
        End Property
        Public Property FileColumnNumber() As Integer
            Get
                Return _FileColumnNumber
            End Get
            Set(ByVal Value As Integer)
                _FileColumnNumber = Value
            End Set
        End Property
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal Value As String)
                _FileName = Value
            End Set
        End Property
        Public Property FileLineNumber() As Integer
            Get
                Return _FileLineNumber
            End Get
            Set(ByVal Value As Integer)
                _FileLineNumber = Value
            End Set
        End Property
    End Class
End Namespace
