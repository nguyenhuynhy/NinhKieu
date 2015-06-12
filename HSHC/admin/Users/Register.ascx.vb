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

Namespace PortalQH

    Public Class Register
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents Title1 As DesktopModuleTitle
        Protected WithEvents UserRow As System.Web.UI.WebControls.Panel
        Protected WithEvents lblRegister As System.Web.UI.WebControls.Label
        Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valFirstName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valLastName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtUsername As System.Web.UI.WebControls.TextBox
        Protected WithEvents valUsername As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents valPassword As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtConfirm As System.Web.UI.WebControls.TextBox
        Protected WithEvents valConfirm1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valConfirm2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents valEmail2 As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents Address1 As Address
        Protected WithEvents Message As System.Web.UI.WebControls.Label
        Protected WithEvents lblRegistration As System.Web.UI.WebControls.Label

        Protected WithEvents RegisterBtn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents UnregisterBtn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ReturnBtn As System.Web.UI.WebControls.LinkButton

        Protected WithEvents ServicesRow As System.Web.UI.WebControls.Panel
        Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents ReturnButton As System.Web.UI.WebControls.LinkButton

        Private Services As Integer = 0
        Private RoleID As Integer = -1

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
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' Verify that the current user has access to this page
                If _portalSettings.UserRegistration = 0 And Request.IsAuthenticated = False Then
                    Response.Redirect(NavigateURL("Access Denied"), True)
                End If

                If Not (Request.Params("Services") Is Nothing) Then
                    Services = Int32.Parse(Request.Params("Services"))
                End If

                ' free subscriptions
                If Not (Request.Params("RoleID") Is Nothing) Then
                    RoleID = Int32.Parse(Request.Params("RoleID"))

                    Dim objUser As New RoleController

                    objUser.UpdateService(PortalId, CType(Context.User.Identity.Name, String), RoleID, Convert.ToBoolean(IIf(Not Request.Params("cancel") Is Nothing, True, False)))

                    Response.Redirect(NavigateURL("Register"), True)

                End If

                ' If this is the first visit to the page, bind the role data to the datalist
                If Page.IsPostBack = False Then
                    UnregisterBtn.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Cancel Your Account ?');")

                    BindData()

                    Try
                        SetFormFocus(txtFirstName)
                    Catch
                        'control not there or error setting focus
                    End Try

                    ' Store URL Referrer to return to portal
                    If Not Request.UrlReferrer Is Nothing Then
                        ViewState("UrlReferrer") = Convert.ToString(Request.UrlReferrer)
                    Else
                        ViewState("UrlReferrer") = ""
                    End If
                End If

                txtPassword.Attributes.Add("value", txtPassword.Text)
                txtConfirm.Attributes.Add("value", txtConfirm.Text)

                Dim objModules As New ModuleController
                Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", PortalId)
                Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
                lblRegistration.Text = CType(settings("registrationmessage"), String)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Sub BindData()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

            Dim objModules As New ModuleController
            Dim objPortalController As New PortalController

            Address1.ModuleId = objModules.GetSiteModule("Site Settings", PortalId)
            Address1.StartTabIndex = 7

            If Services = 1 Then
                Title1.TitleVisible = False
                UserRow.Visible = False

                Dim objUser As New RoleController

                myDataGrid.DataSource = objUser.GetServices(PortalId)
                myDataGrid.DataBind()

                If myDataGrid.Items.Count <> 0 Then
                    lblMessage.Text = "<br>In order to take advantage of our Membership Services, you must first identify yourself as a member of the site. If you have already registered in the past, please <a class=""CommandButton"" href=""" & GetPortalDomainName(PortalAlias, Request) & "/DesktopDefault.aspx?tabid=" & TabId & "&showlogin=1"">Login</a> now. If you have not yet registered for the site, please take the opportunity to <a class=""CommandButton"" href=""" & GetPortalDomainName(PortalAlias) & "/DesktopDefault.aspx?tabid=" & TabId & "&def=Register"">Register</a> now."
                Else
                    myDataGrid.Visible = False
                    lblMessage.Text = "Membership Services are not being offered at this time"
                End If
                lblMessage.Visible = True

                myDataGrid.Columns(0).Visible = False ' subscribe
                myDataGrid.Columns(9).Visible = False ' expiry date

                ServicesRow.Visible = True
            Else
                UserRow.Visible = True

                If Request.IsAuthenticated Then

                    Title1.DisplayTitle = "Account Details"
                    lblRegister.Text = "<b>*Note:</b> All fields marked with an asterisk (*) are required."

                    RegisterBtn.Text = "Update"
                    valPassword.Enabled = False
                    valConfirm1.Enabled = False
                    valConfirm2.Enabled = False

                    Dim users As New UserController
                    Dim objUserInfo As UserInfo = users.GetUser(PortalId, CType(Context.User.Identity.Name, String))

                    If Not objUserInfo Is Nothing Then
                        txtUsername.Text = objUserInfo.Name
                        txtEmail.Text = objUserInfo.Email

                        Address1.Unit = objUserInfo.Unit
                        Address1.Street = objUserInfo.Street
                        Address1.City = objUserInfo.City
                        Address1.Region = objUserInfo.Region
                        Address1.Country = objUserInfo.Country
                        Address1.Postal = objUserInfo.PostalCode
                        Address1.Telephone = objUserInfo.Telephone
                    End If


                    Dim objUser As New RoleController

                    myDataGrid.DataSource = objUser.GetServices(PortalId, CType(Context.User.Identity.Name, String))
                    myDataGrid.DataBind()

                    ' if no e-commerce service available then hide options
                    ServicesRow.Visible = False
                    Dim objPortalInfo As PortalInfo = objPortalController.GetPortal(_portalSettings.PortalId)
                    If Not objPortalInfo Is Nothing Then
                        If objPortalInfo.PaymentProcessor <> "" Then
                            ServicesRow.Visible = True
                        End If
                    End If
                Else
                    Select Case _portalSettings.UserRegistration
                        Case 1 ' private
                            Title1.DisplayTitle = "Account Application"
                            lblRegister.Text = "<b>*Note:</b> Membership to this portal is Private. Once your account information has been submitted, the portal Administrator will be notified and your application will be subjected to a screening procedure. If your application is authorized, you will receive notification of your access to the portal environment."
                        Case 2 ' public
                            Title1.DisplayTitle = "Account Registration"
                            lblRegister.Text = "<b>*Note:</b> Membership to this portal is Public. Once your account information has been submitted, you will be immediately granted access to the portal environment."
                        Case 3 ' verified
                            Title1.DisplayTitle = "Account Registration"
                            lblRegister.Text = "<b>*Note:</b> Membership to this portal is Verified. Once your account information has been submitted, you will receive an email containing your unique Verification Code. The Verification Code will be required the first time you attempt to sign in to the portal environment."
                    End Select
                    lblRegister.Text += " All fields marked with an asterisk (*) are required."

                    RegisterBtn.Text = "Register"
                    UnregisterBtn.Visible = False
                    ServicesRow.Visible = False
                    valPassword.Enabled = True
                    valConfirm1.Enabled = True
                    valConfirm2.Enabled = True
                End If
            End If

        End Sub

        Private Sub RegisterBtn_Click(ByVal sender As Object, ByVal E As EventArgs) Handles RegisterBtn.Click
            Try
                Dim strBody As String

                ' Only attempt a save/update if all form fields on the page are valid
                If Page.IsValid = True Then

                    ' Obtain PortalSettings from Current Context
                    Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                    ' Add New User to Portal User Database
                    Dim objUser As New UserController
                    Dim objSecurity As New PortalSecurity
                    Dim objModules As New ModuleController

                    If Request.IsAuthenticated Then
                        Message.Text = ""
                        If txtPassword.Text <> "" Or txtConfirm.Text <> "" Then
                            If txtPassword.Text <> txtConfirm.Text Then
                                Message.Text = "Password Values Entered Do Not Match."
                            End If
                        End If

                        If Message.Text = "" Then
                            Dim Username As String = Nothing
                            Dim objUserInfo As UserInfo = objUser.GetUser(PortalId, CType(context.User.Identity.Name, String))
                            If Not objUserInfo Is Nothing Then
                                Username = objUserInfo.Name
                            End If

                            objUserInfo = Nothing

                            objUserInfo = objUser.GetUserByUsername(PortalId, txtUsername.Text)
                            'if a user is found with that username and the username isn't our current user's username
                            If Not objUserInfo Is Nothing And txtUsername.Text <> Username Then
                                'username already exists in DB so show user an error message
                                Message.Text = "Registration Failed! Username <u>" & txtUsername.Text & "</u> is already registered." & "<" & "br" & ">" & "Please select a different Username."
                            Else
                                'update the user
                                objUser.UpdateUser(PortalId, CType(Context.User.Identity.Name, String), txtFirstName.Text + txtLastName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, Convert.ToString(IIf(txtPassword.Text <> "", objSecurity.Encrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), txtPassword.Text), "")), True, "", "")
                                ' Redirect browser back to home page
                                Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)
                            End If

                        End If
                    Else
                        Dim AffiliateId As Integer = Convert.ToInt32(Null.SetNull(AffiliateId))
                        If Not Request.Cookies("AffiliateId") Is Nothing Then
                            AffiliateId = Integer.Parse(Request.Cookies("AffiliateId").Value)
                        End If

                        Dim UserId As String = objUser.AddUser(PortalId, txtFirstName.Text + txtLastName.Text, Address1.Unit, Address1.Street, Address1.City, Address1.Region, Address1.Postal, Address1.Country, Address1.Telephone, txtEmail.Text, txtUsername.Text, objSecurity.Encrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), txtPassword.Text), Convert.ToBoolean(IIf(_portalSettings.UserRegistration = 1, False, True)), AffiliateId, "", "")

                        If UserId <> "" Then
                            strBody = ""
                            strBody = strBody & "Date: " & Now().ToString & vbCrLf & vbCrLf
                            strBody = strBody & "First Name: " & txtFirstName.Text & vbCrLf
                            strBody = strBody & "Last Name: " & txtLastName.Text & vbCrLf & vbCrLf
                            strBody = strBody & "Unit: " & Address1.Unit & vbCrLf
                            strBody = strBody & "Street: " & Address1.Street & vbCrLf
                            strBody = strBody & "City: " & Address1.City & vbCrLf
                            strBody = strBody & "Region: " & Address1.Region & vbCrLf
                            strBody = strBody & "Country: " & Address1.Country & vbCrLf
                            strBody = strBody & "Postal Code: " & Address1.Postal & vbCrLf
                            strBody = strBody & "Telephone: " & Address1.Telephone & vbCrLf & vbCrLf
                            strBody = strBody & "Email: " & txtEmail.Text & vbCrLf

                            SendNotification(_portalSettings.Email, _portalSettings.Email, "", _portalSettings.PortalName & " New User Registration", strBody)

                            ' complete registration
                            Select Case _portalSettings.UserRegistration
                                Case 1 ' private
                                    strBody = "Dear " & txtFirstName.Text & " " & txtLastName.Text & "," & vbCrLf & vbCrLf
                                    strBody = strBody & "Thank you for registering at the " & _portalSettings.PortalName & " portal website. Please read the following information carefully and be sure to save this message in a safe location for future reference." & vbCrLf & vbCrLf
                                    strBody = strBody & "Portal Website Address: " & GetPortalDomainName(PortalAlias, Request) & vbCrLf
                                    strBody = strBody & "Username: " & txtUsername.Text & vbCrLf
                                    strBody = strBody & "Password: " & txtPassword.Text & vbCrLf & vbCrLf
                                    strBody = strBody & "Your account details will be reviewed by the portal Administrator and you will receive a notification upon account activation." & vbCrLf & vbCrLf

                                    Dim objAdmin As New AdminDB
                                    Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", PortalId)
                                    Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
                                    strBody = strBody & CType(settings("signupmessage"), String) & vbCrLf & vbCrLf

                                    strBody = strBody & "Thank you, we appreciate your support..." & vbCrLf & vbCrLf
                                    strBody = strBody & _portalSettings.PortalName

                                    SendNotification(_portalSettings.Email, txtEmail.Text, "", _portalSettings.PortalName & " Account Application", strBody)
                                Case 2 ' public
                                    UserId = objSecurity.UserLogin(txtUsername.Text, txtPassword.Text, _portalSettings.PortalId)
                                    FormsAuthentication.SetAuthCookie(UserId.ToString, False)
                                Case 3 ' verified
                                    strBody = "Dear " & txtFirstName.Text & " " & txtLastName.Text & "," & vbCrLf & vbCrLf
                                    strBody = strBody & "Thank you for registering at the " & _portalSettings.PortalName & " portal website. Please read the following information carefully and be sure to save this message in a safe location for future reference." & vbCrLf & vbCrLf
                                    strBody = strBody & "Portal Website Address: " & GetPortalDomainName(PortalAlias, Request) & vbCrLf
                                    strBody = strBody & "Username: " & txtUsername.Text & vbCrLf
                                    strBody = strBody & "Password: " & txtPassword.Text & vbCrLf
                                    strBody = strBody & "Verification Code: " & _portalSettings.PortalId.ToString & "-" & UserId.ToString & vbCrLf & vbCrLf

                                    Dim objAdmin As New AdminDB
                                    Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", PortalId)
                                    Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
                                    strBody = strBody & CType(settings("signupmessage"), String) & vbCrLf & vbCrLf

                                    strBody = strBody & "Thank you, we appreciate your support..." & vbCrLf & vbCrLf
                                    strBody = strBody & _portalSettings.PortalName

                                    SendNotification(_portalSettings.Email, txtEmail.Text, "", _portalSettings.PortalName & " New User Registration", strBody)
                            End Select

                            ' affiliate
                            If Not Null.IsNull(AffiliateId) Then
                                Dim objAffiliates As New AffiliateController
                                objAffiliates.UpdateAffiliateStats(AffiliateId, 0, 1)
                            End If

                            ' Redirect browser back to home page
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
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub UnregisterBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnregisterBtn.Click
            Try
                Dim users As New UserController
                If users.DeleteUser(PortalId, CType(Context.User.Identity.Name, String)) Then
                    ' Obtain PortalSettings from Current Context
                    Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                    Dim strBody As String
                    strBody = ""
                    strBody = strBody & "Date: " & Now().ToString & vbCrLf & vbCrLf
                    strBody = strBody & "First Name: " & txtFirstName.Text & vbCrLf
                    strBody = strBody & "Last Name: " & txtLastName.Text & vbCrLf & vbCrLf
                    strBody = strBody & "Unit: " & Address1.Unit & vbCrLf
                    strBody = strBody & "Street: " & Address1.Street & vbCrLf
                    strBody = strBody & "City: " & Address1.City & vbCrLf
                    strBody = strBody & "Region: " & Address1.Region & vbCrLf
                    strBody = strBody & "Country: " & Address1.Country & vbCrLf
                    strBody = strBody & "Postal Code: " & Address1.Postal & vbCrLf
                    strBody = strBody & "Telephone: " & Address1.Telephone & vbCrLf & vbCrLf
                    strBody = strBody & "Email: " & txtEmail.Text & vbCrLf

                    SendNotification(_portalSettings.Email, _portalSettings.Email, "", _portalSettings.PortalName & " Unregister User", strBody)
                End If

                Response.Redirect("~/Admin/Security/Logoff.aspx")

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function FormatURL() As String
            Try

                Dim strServerPath As String

                strServerPath = Request.ApplicationPath
                If Not strServerPath.EndsWith("/") Then
                    strServerPath += "/"
                End If

                Return strServerPath & "Register.aspx?tabid=" & TabId

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub ReturnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
            Try
                Response.Redirect(Convert.ToString(ViewState("UrlReferrer")), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Function ServiceText(ByVal Subscribed As Boolean) As String
            Try
                If Not Subscribed Then
                    ServiceText = "Subscribe"
                Else
                    ServiceText = "Cancel"
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function ServiceURL(ByVal strKeyName As String, ByVal strKeyValue As String, ByVal objServiceFee As Object, ByVal Subscribed As Boolean) As String
            Try
                Dim dblServiceFee As Double = 0
                If Not IsDBNull(objServiceFee) Then
                    dblServiceFee = Convert.ToDouble(objServiceFee)
                End If

                If Not Subscribed Then
                    If dblServiceFee > 0 Then
                        ServiceURL = "~/admin/Sales/PayPalSubscription.aspx?tabid=" & TabId & "&" & strKeyName & "=" & strKeyValue
                    Else
                        ServiceURL = NavigateURL("Register") & "&" & strKeyName & "=" & strKeyValue
                    End If
                Else ' cancel
                    If dblServiceFee > 0 Then
                        ServiceURL = "~/admin/Sales/PayPalSubscription.aspx?tabid=" & TabId & "&" & strKeyName & "=" & strKeyValue & "&cancel=1"
                    Else
                        ServiceURL = NavigateURL("Register") & "&" & strKeyName & "=" & strKeyValue & "&cancel=1"
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        ' Format the Fee amount and filter out null-values
        Function FormatPrice(ByVal price As Double) As String
            Try
                If price <> Null.NullInteger Then
                    FormatPrice = price.ToString("##0.00")
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        ' Filter out null-values
        Function FormatPeriod(ByVal period As Integer) As String
            Try
                If period <> Null.NullInteger Then
                    FormatPeriod = period.ToString
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        ' Format the expiry date and filter out null-dates 
        Function FormatExpiryDate(ByVal DateTime As Date) As String
            Try
                If Not Null.IsNull(DateTime) Then
                    FormatExpiryDate = DateTime.ToShortDateString
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function


    End Class

End Namespace
