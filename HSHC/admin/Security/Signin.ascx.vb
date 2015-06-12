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

Imports System.Web.Security
Imports System.Configuration
Imports System.Data.SqlClient


Namespace PortalQH

    Public MustInherit Class Signin
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtUsername As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents rowVerification1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents rowVerification2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtVerification As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCookie As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cmdLogin As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdSendPassword As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents cmdTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdLogin_Temp As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblLogin As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If _portalSettings.UserRegistration = 0 Then
                cmdTroVe.Visible = False
            End If

            txtPassword.Attributes.Add("value", txtPassword.Text)

            Dim objModules As New ModuleController

            Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", PortalId)
            Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
            lblLogin.Text = CType(settings("loginmessage"), String)

            'LANPHM add 6/6/2005
            'Redirect to LoginPage 
            Dim blnRedirectLogin As Boolean
            blnRedirectLogin = CType(ConfigurationSettings.AppSettings("RedirectLoginPage"), Boolean)
            'Show message alert
            If blnRedirectLogin Then
                Dim strMessage As String
                strMessage = Request.QueryString("Message")
                Skin.AddModuleMessage(Me, strMessage, Skins.ModuleMessage.ModuleMessageType.RedError)
            End If

            If Page.IsPostBack = False Then
                Try
                    If CType(ConfigurationSettings.AppSettings("Intergrated"), Boolean) = True Then
                        Me.cmdLoginPortal()
                    End If
                    SetFormFocus(txtUsername)
                Catch
                    'control not there or error setting focus
                End Try
            End If

        End Sub


        Private Sub cmdSendPassword_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSendPassword.Click

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If Trim(txtUsername.Text) <> "" Then
                Dim objUsers As New UserController
                Dim objSecurity As New PortalSecurity

                Dim objUser As UserInfo = objUsers.GetUserByUsername(_portalSettings.PortalId, txtUsername.Text)

                If Not objUser Is Nothing Then
                    Dim strBody As String

                    strBody = "Dear " & objUser.FullName & "," & vbCrLf & vbCrLf
                    strBody = strBody & "You have requested a Password Reminder from our " & _portalSettings.PortalName & " website." & vbCrLf & vbCrLf
                    strBody = strBody & "Please login using the following information:" & vbCrLf & vbCrLf
                    strBody = strBody & "Portal Website Address: " & GetPortalDomainName(PortalAlias, Request) & vbCrLf
                    strBody = strBody & "Username:   " & objUser.Name & vbCrLf
                    strBody = strBody & "Password: " & objSecurity.Decrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), objUser.Password) & vbCrLf
                    If _portalSettings.UserRegistration = 3 And objUser.LastLoginDate = Date.MinValue And objUser.IsSuperUser = False Then
                        strBody = strBody & "Verification Code: " & _portalSettings.PortalId.ToString & "-" & objUser.UserID & vbCrLf
                    End If
                    If Not IsDBNull(objUser.Authorized) Then
                        If Not objUser.Authorized Then
                            strBody = strBody & "Status: Not Authorized" & vbCrLf
                        End If
                    End If
                    strBody = strBody & vbCrLf

                    strBody = strBody & vbCrLf & "Sincerely," & vbCrLf
                    strBody = strBody & "Portal Administrator" & vbCrLf & vbCrLf
                    strBody = strBody & "*Note: If you did not request a Password Reminder, please disregard this Message."

                    SendNotification(_portalSettings.Email, objUser.Email, "", _portalSettings.PortalName & " Password Reminder", strBody)
                    Skin.AddModuleMessage(Me, "Password Has Been Sent To<br>Your Email Address.", Skins.ModuleMessage.ModuleMessageType.GreenSuccess)
                Else
                    Skin.AddModuleMessage(Me, "Username Does Not Exist", Skins.ModuleMessage.ModuleMessageType.RedError)
                End If

            Else
                Skin.AddModuleMessage(Me, "Please Enter Your Username", Skins.ModuleMessage.ModuleMessageType.RedError)
            End If

        End Sub


        Private Sub cmdTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTroVe.Click
            If PortalSettings.UserTabId <> -1 Then
                ' user defined tab
                Response.Redirect("~/DesktopDefault.aspx?tabid=" & PortalSettings.UserTabId.ToString, True)
            Else
                ' admin tab
                Response.Redirect("~/DesktopDefault.aspx?tabid=" & PortalSettings.ActiveTab.TabId & "&ctl=Login", True)
            End If
        End Sub

        '********************************************************************
        'Purpose           	:Authentication
        'Params         	:None
        'Returns         	:None
        'Created date		:Oct 10 2005
        'Creator		    :Phuocdd
        'Modified date  	:Oct 19 2005
        'Modifier        	:Phuocdd
        '********************************************************************
        Private Sub cmdLoginPortal()
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim objUsers As New UserController
            Dim objSecurity As New PortalSecurity
            Dim username As String
            Dim password As String

            'If CType(ConfigurationSettings.AppSettings("Intergrated"), Boolean) = False Then
            '    username = Me.txtUsername.Text
            '    password = Me.txtPassword.Text
            'Else
            '    username = Request.Form("txtTenTruyCap")
            '    password = Request.Form("txtMatKhau")
            '    If (username Is Nothing) Then
            '        username = Me.txtUsername.Text
            '        password = Me.txtPassword.Text
            '    End If
            'End If
            username = Me.txtUsername.Text
            password = Me.txtPassword.Text

            If (Request.QueryString("SSO") <> "") Then
                If (CheckUserSignIn(Request.UserHostAddress, Request.QueryString("uid")) <> "") _
                                  And ConfigurationSettings.AppSettings("SSO") = "1" Then
                    GoTo pass
                End If
            End If
            If (username Is Nothing) Then
                Exit Sub
            End If

            If (username.Trim().Length <= 0) Then
                Exit Sub
            End If

pass:
            Dim blnLogin As Boolean = True

            If _portalSettings.UserRegistration = 3 Then ' verified
                Dim objUser As UserInfo = objUsers.GetUserByUsername(_portalSettings.PortalId, username)
                If Not objUser.UserID = "" Then
                    If objUser.LastLoginDate = Date.MinValue And objUser.IsSuperUser = False Then
                        blnLogin = False
                        If rowVerification1.Visible Then
                            If txtVerification.Text <> "" Then
                                If txtVerification.Text = (_portalSettings.PortalId.ToString & "-" & objUser.UserID) Then
                                    blnLogin = True
                                Else
                                    Skin.AddModuleMessage(Me, "Invalid Verification Code", Skins.ModuleMessage.ModuleMessageType.RedError)
                                End If
                            Else
                                Skin.AddModuleMessage(Me, "Enter Your Verification Code", Skins.ModuleMessage.ModuleMessageType.GreenSuccess)
                            End If
                        Else
                            rowVerification1.Visible = True
                            rowVerification2.Visible = True
                        End If
                    End If
                End If
            End If

            If blnLogin Then
                ' Attempt to Validate User Credentials

                Dim userId As String = ""
                ' check ldap flag

                If CType(ConfigurationSettings.AppSettings("UseLDAP"), Boolean) Then userId = LDAPLogin(username, password)
                If (Request.QueryString("SSO") <> "") Then
                    If (CheckUserSignIn(Request.UserHostAddress, Request.QueryString("uid")) <> "") _
                                                                             And ConfigurationSettings.AppSettings("SSO") = "1" Then
                        userId = GetUserSignedIn(Request.QueryString("uid"))
                        txtUsername.Text = Request.QueryString("uid")
                        'username = Request.QueryString("uid")
                    End If
                End If
                If userId = "" Then userId = objSecurity.UserLogin(username, password, _portalSettings.PortalId)
                If userId <> "" Then
                    'luu username, userid
                    Session.Item("UserName") = username
                    Session.Item("UserID") = userId
                    Session.Item("ActiveDB") = ""
                    Response.Cookies("UserID").Value = userId
                    UpdateProgramAccess(username, Request.UserHostAddress)
                    ' Use security system to set the UserID within a client-side Cookie
                    FormsAuthentication.SetAuthCookie(Convert.ToString(userId), chkCookie.Checked)

                    ' redirect browser - override is used if the user defined login tab has no signin control
                    If _portalSettings.HomeTabId <> -1 And Request.QueryString("override") Is Nothing Then
                        ' user defined tab
                        Response.Redirect("~/DesktopDefault.aspx?tabid=" & _portalSettings.HomeTabId.ToString, True)
                    Else
                        ' admin tab
                        Response.Redirect("~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId.ToString, True)
                    End If
                Else
                    Skin.AddModuleMessage(Me, "Kiểm tra lại tên và mật khẩu", Skins.ModuleMessage.ModuleMessageType.RedError)
                End If
            End If
        End Sub

        Private Sub cmdLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
            Me.cmdLoginPortal()
        End Sub

        Private Sub cmdLogin_Temp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdLogin_Temp.Click
            cmdLogin_Click(sender, e)
        End Sub

        Private Function LDAPLogin(ByVal name As String, ByVal pass As String) As String
            ' check ldap account
            Dim ad As New ActiveDirectory
            ad.DomainName = ConfigurationSettings.AppSettings("DomainName")
            ad.Filters = ConfigurationSettings.AppSettings("Filters")
            ad.Username = ConfigurationSettings.AppSettings("DefName")
            ad.Password = ConfigurationSettings.AppSettings("DefPass")

            ' checking
            If Not ad.CheckAccount(ConfigurationSettings.AppSettings("Shortcut") & name, pass) Then Return ""
            ' get user information
            Dim al As New ArrayList
            ad.Filters = String.Format(ConfigurationSettings.AppSettings("Filter1"), ConfigurationSettings.AppSettings("UNameID") & "=" & name)
            al.Add(ConfigurationSettings.AppSettings("UNameID"))
            al.Add(ConfigurationSettings.AppSettings("MailID"))
            al.Add(ConfigurationSettings.AppSettings("FNameID"))
            Dim dt As DataTable = ad.GetTableUser(al)
            ' get fname, email
            Dim fname As String = ""
            Dim email As String = ""
            If Not dt.Rows(0)(ConfigurationSettings.AppSettings("FNameID")) Is System.DBNull.Value Then fname = CType(dt.Rows(0)(ConfigurationSettings.AppSettings("FNameID")), String)
            If Not dt.Rows(0)(ConfigurationSettings.AppSettings("MailID")) Is System.DBNull.Value Then email = CType(dt.Rows(0)(ConfigurationSettings.AppSettings("MailID")), String)

            ' synchronous password
            Dim uc As New UserController
            Dim ds As DataSet = uc.GetUsersDataSet
            Dim id As String
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If CType(ds.Tables(0).Rows(i)(ConfigurationSettings.AppSettings("UsernameID")), String).ToLower = name.ToLower Then
                    ' get user from table
                    Dim da As New SqlDataAdapter("select * from " & ConfigurationSettings.AppSettings("UsersTab") & " where " & ConfigurationSettings.AppSettings("UsridCol") & "='" & CType(ds.Tables(0).Rows(i)(ConfigurationSettings.AppSettings("IdentifyID")), String) & "'", ConfigurationSettings.AppSettings("connectionStringPortalQH"))
                    dt = New DataTable
                    da.Fill(dt)
                    ' get user information
                    If Not dt.Rows(0)(ConfigurationSettings.AppSettings("FnameCol")) Is System.DBNull.Value Then fname = CType(dt.Rows(0)(ConfigurationSettings.AppSettings("FNameCol")), String)
                    If Not dt.Rows(0)(ConfigurationSettings.AppSettings("EmailCol")) Is System.DBNull.Value Then email = CType(dt.Rows(0)(ConfigurationSettings.AppSettings("EmailCol")), String)
                    id = CType(ds.Tables(0).Rows(i)(ConfigurationSettings.AppSettings("IdentifyID")), String)
                    ' if password id null
                    If dt.Rows(0)(ConfigurationSettings.AppSettings("PswrdCol")) Is System.DBNull.Value Then
                        GoTo update_password
                    Else
                        ' if password is different
                        If (New PortalSecurity).Encrypt(pass) <> CType(dt.Rows(0)(ConfigurationSettings.AppSettings("PswrdCol")), String) Then
                            GoTo update_password
                        Else : Return CType(ds.Tables(0).Rows(i)(ConfigurationSettings.AppSettings("IdentifyID")), String)
                        End If
                    End If
                End If
            Next

            ' add new ldap user
            Dim AffiliateId As Integer = Convert.ToInt32(Null.SetNull(AffiliateId))
            If Not Request.Cookies("AffiliateId") Is Nothing Then
                AffiliateId = Integer.Parse(Request.Cookies("AffiliateId").Value)
            End If
            id = uc.AddUser(PortalId, fname, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, email, name, Nothing, True, AffiliateId, Nothing, Nothing)
            If id = "" Then Return ""

update_password:
            ' update system user password
            Dim ui As UserInfo = uc.GetUser(PortalId, id)
            Dim ps As New PortalSecurity
            uc.UpdateUser(PortalId, id, ui.FullName, ui.Unit, ui.Street, ui.City, ui.Region, ui.PostalCode, ui.Country, ui.Telephone, ui.Email, name, (New PortalSecurity).Encrypt(pass), True, ui.MaChucDanh, ui.MaPhongBan)

            Return id
        End Function
    End Class

End Namespace
