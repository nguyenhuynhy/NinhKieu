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

Namespace PortalQH

    Public Class ManageUsers
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents Address1 As Address
        Protected WithEvents Message As System.Web.UI.WebControls.Label

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdManage As System.Web.UI.WebControls.LinkButton

        Protected WithEvents pnlAudit As System.Web.UI.WebControls.Panel
        Protected WithEvents txtFullName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valFirstName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtUsername As System.Web.UI.WebControls.TextBox
        Protected WithEvents valUsername As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents valPassword As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtConfirm As System.Web.UI.WebControls.TextBox
        Protected WithEvents valConfirm1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valConfirm2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkAuthorized As System.Web.UI.WebControls.CheckBox
        Protected WithEvents rowAuthorized As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblCreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblLastLoginDate As System.Web.UI.WebControls.Label
        Protected WithEvents ddlChucDanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhongBan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents valEmail2 As System.Web.UI.WebControls.RegularExpressionValidator

        Private Shadows UserId As String = ""


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

        '*******************************************************
        '
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objUser As New UserController
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' get userid
                'If Not (Request.Params("userid") Is Nothing) Then
                '    UserId = Request.Params("userid")
                'End If

                If Not (Request.QueryString("userid") Is Nothing) Then
                    UserId = Request.QueryString("userid")
                End If

                ' security check for super user
                If UserId = _portalSettings.SuperUserId And UserId <> CType(Context.User.Identity.Name, String) Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

                ' If this is the first visit to the page, bind the role data to the datalist
                If Page.IsPostBack = False Then
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    BindDropDownList(ddlChucDanh, True, objUser.getDMChucDanh)
                    BindDropDownList(ddlPhongBan, True, objUser.getDMPhongBan)
                    BindData()

                    If UserId = _portalSettings.SuperUserId Then
                        Address1.Visible = False
                        rowAuthorized.Visible = False
                        cmdDelete.Visible = False
                        cmdManage.Visible = False

                        If Not Request.UrlReferrer Is Nothing Then
                            ViewState("UrlReferrer") = Convert.ToString(Request.UrlReferrer)
                        Else
                            ViewState("UrlReferrer") = ""
                        End If
                    Else
                        ViewState("UrlReferrer") = "~/DesktopDefault.aspx?tabid=" & TabId & "&tabname=User Accounts" & "&filter=" & Request.Params("filter")
                    End If
                End If

                txtPassword.Attributes.Add("value", txtPassword.Text)
                txtConfirm.Attributes.Add("value", txtConfirm.Text)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
            'cmdDelete.Attributes.Add("onclick", "javascript:return ThongBao();")
            objUser = Nothing
        End Sub


        '*******************************************************
        '
        ' The Save_Click server event handler on this page is used
        ' to save the current security settings to the configuration system
        '
        '*******************************************************

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '********************************************************************
        'Purpose           	:Update user's profile
        'Params         	:System
        'Returns         	:None
        'Created date		:Unknown
        'Creator		    :Unknown
        'Modified date  	:Oct 21st 2005
        'Modifier        	:Phuocdd :Not update password when it was blank
        '********************************************************************
        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Try

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' update the user record in the database
                Dim objUsers As New UserController
                Dim ObjUser As UserInfo
                Dim objSecurity As New PortalSecurity
                Dim objModules As New ModuleController
                Dim strBody As String
                Dim strURL As String

                If UserId = "" Then
                    'UserId = objUsers.AddUser(PortalId, txtFullName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, objSecurity.Encrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), txtPassword.Text), chkAuthorized.Checked, Null.NullInteger, ddlChucDanh.SelectedValue, ddlPhongBan.SelectedValue)
                    UserId = objUsers.AddUser(PortalId, txtFullName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, objSecurity.Encrypt(txtPassword.Text), chkAuthorized.Checked, Null.NullInteger, ddlChucDanh.SelectedValue, ddlPhongBan.SelectedValue)
                    If UserId <> "" Then
                        strURL = GetPortalDomainName(PortalAlias, Request)
                        strBody = "Dear " & txtFullName.Text & " " & "," & vbCrLf & vbCrLf
                        strBody = strBody & "We are pleased to advise that you have been added as a Registered User to the " & _portalSettings.PortalName & " portal website. Please read the following information carefully and be sure to save this message in a safe location for future reference." & vbCrLf & vbCrLf
                        strBody = strBody & "Portal Website Address: " & strURL & vbCrLf
                        strBody = strBody & "Username: " & txtUsername.Text & vbCrLf
                        strBody = strBody & "Password: " & txtPassword.Text & vbCrLf
                        If _portalSettings.UserRegistration = 3 Then
                            strBody = strBody & "Verification Code: " & _portalSettings.PortalId.ToString & "-" & UserId.ToString & vbCrLf
                        End If
                        strBody = strBody & vbCrLf & "Please take the opportunity to visit the website to review its content and take advantage of its many features." & vbCrLf & vbCrLf

                        Dim objAdmin As New AdminDB
                        Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", PortalId)
                        Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
                        strBody = strBody & CType(settings("signupmessage"), String) & vbCrLf & vbCrLf

                        strBody = strBody & "Thank you, we appreciate your support..." & vbCrLf & vbCrLf
                        strBody = strBody & _portalSettings.PortalName

                        SendNotification(_portalSettings.Email, txtEmail.Text, "", _portalSettings.PortalName & " New User Registration", strBody)

                        Viewstate("UrlReferrer") = Replace(Convert.ToString(Viewstate("UrlReferrer")), "&filter=", "&filter=" & Left(txtFullName.Text, 1))

                        Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)
                    Else ' registration error
                        Select Case CType(UserId, UserRegistrationStatus)
                            Case UserRegistrationStatus.UserAlreadyRegistered
                                Message.Text = "You Are Already Registered For This Portal Using The Username Specified. Please Perform A Password Reminder If You Have Forgotten Your Password For This Account."
                            Case UserRegistrationStatus.UsernameAlreadyExists
                                Message.Text = "A User Already Exists For the Username Specified. Please Register Again Using A Different Username."
                            Case UserRegistrationStatus.UnexpectedError
                                Message.Text = "An Unexpected Error Occurred During Registration. Please Contact The Portal Administrator For Futher Information."
                        End Select
                    End If
                Else
                    Message.Text = ""
                    If txtPassword.Text <> "" Or txtConfirm.Text <> "" Then
                        If txtPassword.Text <> txtConfirm.Text Then
                            Message.Text = "Password Values Entered Do Not Match."
                        End If
                    End If
                    If Message.Text = "" Then
                        ' if activating an account, send notification
                        If chkAuthorized.Checked Then
                            ObjUser = objUsers.GetUser(PortalId, UserId)
                            If Not ObjUser Is Nothing Then
                                If ObjUser.Authorized <> chkAuthorized.Checked Then
                                    strURL = GetPortalDomainName(PortalAlias, Request)
                                    strBody = "Dear " & txtFullName.Text & "," & vbCrLf & vbCrLf
                                    strBody = strBody & "We are pleased to advise that your application to the " & _portalSettings.PortalName & " portal website has been authorized. Please read the following information carefully and be sure to save this message in a safe location for future reference." & vbCrLf & vbCrLf
                                    strBody = strBody & "Portal Website Address: " & strURL & vbCrLf
                                    strBody = strBody & "Username: " & txtUsername.Text & vbCrLf
                                    strBody = strBody & "Password: " & objSecurity.Decrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), ObjUser.Password.ToString) & vbCrLf
                                    If _portalSettings.UserRegistration = 3 Then
                                        strBody = strBody & "Verification Code: " & _portalSettings.PortalId.ToString & "-" & UserId.ToString & vbCrLf
                                    End If
                                    strBody = strBody & vbCrLf & "Please take the opportunity to visit the website to review its content and take advantage of its many features." & vbCrLf & vbCrLf

                                    Dim objAdmin As New AdminDB
                                    Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", PortalId)
                                    Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
                                    strBody = strBody & CType(settings("signupmessage"), String) & vbCrLf & vbCrLf

                                    strBody = strBody & "Thank you, we appreciate your support..." & vbCrLf & vbCrLf
                                    strBody = strBody & _portalSettings.PortalName

                                    SendNotification(_portalSettings.Email, txtEmail.Text, "", _portalSettings.PortalName & " New User Authorization", strBody)
                                End If
                            End If

                        End If

                        'If Not (Request.Params("userid") Is Nothing) Then
                        '    UserId = CType(Request.Params("userid"), String)
                        'End If

                        If Not (Request.QueryString("userid") Is Nothing) Then
                            UserId = CType(Request.QueryString("userid"), String)
                        End If

                        Dim Username As String = Nothing
                        ObjUser = objUsers.GetUser(PortalId, UserId)
                        If Not ObjUser Is Nothing Then
                            Username = ObjUser.Name 'objreader.Item("Username")
                        End If

                        Dim objUser2 As UserInfo = objUsers.GetUserByUsername(PortalId, txtUsername.Text)
                        'if a user is found with that username and the username isn't our current user's username
                        If Not objUser2 Is Nothing And txtUsername.Text <> Username Then
                            'username already exists in DB so show user an error message
                            Message.Text = "Registration Failed! Username <u>" & txtUsername.Text & "</u> is already registered." & "<" & "br" & ">" & "Please select a different Username."
                        Else
                            'update the user
                            'objUsers.UpdateUser(PortalId, UserId, txtFullName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, Convert.ToString(IIf(txtPassword.Text <> "", objSecurity.Encrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), txtPassword.Text), "")), chkAuthorized.Checked, ddlChucDanh.SelectedValue, ddlPhongBan.SelectedValue)
                            If Me.txtPassword.Text.Trim().Length <= 0 Then
                                objUsers.UpdateUser(PortalId, UserId, txtFullName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, Nothing, chkAuthorized.Checked, ddlChucDanh.SelectedValue, ddlPhongBan.SelectedValue)
                            Else
                                objUsers.UpdateUser(PortalId, UserId, txtFullName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, objSecurity.Encrypt(txtPassword.Text), chkAuthorized.Checked, ddlChucDanh.SelectedValue, ddlPhongBan.SelectedValue)
                            End If
                            ' Redirect browser back to home page
                            Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)
                        End If
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '*******************************************************
        '
        ' The BindData helper method is used to bind the list of
        ' security roles for this portal to an asp:datalist server control
        '
        '*******************************************************

        Sub BindData()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

            Address1.ModuleId = ModuleId
            Address1.StartTabIndex = 8

            If UserId <> "" Then
                ' Bind the Email and Password
                Dim objUsers As New UserController
                Dim objUser As UserInfo = objUsers.GetUser(PortalId, UserId)

                ' Read first row from database
                If Not objUser Is Nothing Then
                    txtFullName.Text = objUser.FullName
                    ' objUser.FirstName+objUser.LastName da duoc sua lai thanh FullName
                    txtUsername.Text = objUser.Name
                    txtEmail.Text = objUser.Email
                    BindDdl(ddlPhongBan, objUser.MaPhongBan)
                    BindDdl(ddlChucDanh, objUser.MaChucDanh)
                    If UserId <> _portalSettings.SuperUserId Then
                        chkAuthorized.Checked = objUser.Authorized
                    End If

                    Address1.Unit = objUser.Unit
                    Address1.Street = objUser.Street
                    Address1.City = objUser.City
                    Address1.Region = objUser.Region
                    Address1.Country = objUser.Country
                    Address1.Postal = objUser.PostalCode
                    Address1.Telephone = objUser.Telephone

                    ' Hide createddate and lastlogindate for superuser
                    If UserId = _portalSettings.SuperUserId Then
                        pnlAudit.Visible = False
                    End If

                    ' Hide null-dates
                    If Not Null.IsNull(objUser.CreatedDate) Then
                        lblCreatedDate.Text = objUser.CreatedDate.ToString
                    End If
                    If Not Null.IsNull(objUser.LastLoginDate) Then
                        lblLastLoginDate.Text = objUser.LastLoginDate.ToString
                    End If
                End If

                valPassword.Enabled = False
                valConfirm1.Enabled = False
                valConfirm2.Enabled = False
            Else
                chkAuthorized.Checked = True
                cmdDelete.Visible = False
                cmdManage.Visible = False
                valPassword.Enabled = True
                valConfirm1.Enabled = True
                valConfirm2.Enabled = True
                pnlAudit.Visible = False
            End If

        End Sub
        Sub BindDdl(ByRef Ddl As DropDownList, Optional ByVal ItemSelected As String = "")
            Dim i As Integer
            If Ddl.Items.Count > 0 Then
                For i = Ddl.Items.Count - 1 To 1 Step -1
                    If Ddl.Items(i).Value = ItemSelected Then
                        Ddl.Items(i).Selected = True
                    End If
                Next
            End If
        End Sub
        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' get user id from dropdownlist of users
                Dim objUsers As New UserController
                objUsers.DeleteUser(PortalId, UserId)

                Response.Redirect("~/DesktopDefault.aspx?tabid=" & TabId & "&tabname=User Accounts", True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManage.Click
            Try
                Response.Redirect(NavigateURL("User Roles&UserId=" & UserId), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Shared Sub BindDropDownList(ByVal obj As DropDownList, ByVal All As Boolean, ByVal ds As DataSet)

            obj.DataSource = ds
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ma"
            obj.DataBind()
            Dim tmpItem As New ListItem
            tmpItem.Value = ""
            tmpItem.Text = ""
            If All = True Then
                obj.Items.Insert(0, tmpItem)
            End If
        End Sub
    End Class

End Namespace