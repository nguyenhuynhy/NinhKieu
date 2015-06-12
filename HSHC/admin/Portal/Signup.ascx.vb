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

Imports System.Xml
Imports System.IO

Namespace PortalQH

    Public Class Signup
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents Title1 As DesktopModuleTitle
        Protected WithEvents lblInstructions As System.Web.UI.WebControls.Label

        Protected WithEvents rowType As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents optParent As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optChild As System.Web.UI.WebControls.RadioButton
        Protected WithEvents txtPortalName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valPortalName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents lblAdminAccount As System.Web.UI.WebControls.Label
        Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valFirstName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valLastName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtUsername As System.Web.UI.WebControls.TextBox
        Protected WithEvents valUsername As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents valPassword As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtConfirm As System.Web.UI.WebControls.TextBox
        Protected WithEvents valConfirm As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents valEmail As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents cboTemplate As System.Web.UI.WebControls.DropDownList

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton

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
            Try
                Dim strFolder As String
                Dim strFileName As String

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' ensure portal signup is allowed
                If (_portalSettings.ActiveTab.ParentId <> _portalSettings.SuperTabId Or HttpContext.Current.User.Identity.Name <> _portalSettings.SuperUserId.ToString) And Convert.ToString(_portalSettings.HostSettings("DemoSignup")) <> "Y" Then
                    Response.Redirect(NavigateURL("Access Denied"), True)
                End If

                If Not Page.IsPostBack Then

                    strFolder = Request.MapPath(Global.HostPath)
                    If System.IO.Directory.Exists(strFolder) Then
                        lblMessage.Text = "<br>Your admin.template File Is Missing And Must be Uploaded To The Site.<br><br>"
                        cmdUpdate.Enabled = False

                        Dim fileEntries As String() = System.IO.Directory.GetFiles(strFolder, "*.template")
                        For Each strFileName In fileEntries
                            If Path.GetFileNameWithoutExtension(strFileName) = "admin" Then
                                lblMessage.Text = ""
                                cmdUpdate.Enabled = True
                            Else
                                cboTemplate.Items.Add(Path.GetFileNameWithoutExtension(strFileName))
                            End If
                        Next
                        cboTemplate.Items.Insert(0, "<Not Specified>")
                        cboTemplate.SelectedIndex = 0
                    End If

                    If _portalSettings.ActiveTab.ParentId = _portalSettings.SuperTabId Then
                        rowType.Visible = True
                        optParent.Checked = True
                        Title1.DisplayTitle = "Add New Portal"
                        lblInstructions.Text = "There are two types of portals which can be created using this application:<br><br><li><b>Parent Portals</b> are sites which have a unique URL ( ie. www.domain.com ) associated to them. This generally involves purchasing a Domain Name from an Internet Registrar, setting the Primary/Secondary DNS entries to point to the Hosting Provider's DNS Server, and having your Hosting Provider map the Domain Name to the IP Address of your account. An example of a valid Parent Portal Name is <b>www.mydomain.com</b>. You can also use the IP Address of your site without a Domain Name ( ie. <b>65.174.86.217</b> ). If you need to have multiple Domain Names pointing to the same portal then you can seperate them with commas ( ie. <b>www.domain1.com,www.domain2.com</b> ). Do not create a Parent Portal until all of the DNS mappings are in place or else you will not be able to access your portal.<br><br><li><b>Child Portals</b> are subhosts of your Hosting Provider account. Essentially this means a directory is created on the web server which allows the site to be accessed through a URL address which includes a Parent domain name as well as the directory name ( ie. www.domain.com/directory ). An example of a valid Child Portal Name is <b>" & GetDomainName(Request) & "/portalname</b>. A Child Portal can be converted into a Parent Portal at any time by simply modifying the Portal Alias entry.<br><br>*Please Note: Portals will be created using the default properties defined in the Host Settings module ( HostFee, HostSpace, DemoPeriod ). Once the portal is created, these properties can be modified in the Admin tab Site Settings module.<br><br>"
                    Else
                        rowType.Visible = False
                        Title1.DisplayTitle = "Demo Portal Signup"
                        lblInstructions.Text = "Demo Portal Signup allows you to create your very own Portal Website and experiment with its advanced features" & Convert.ToString(IIf(Convert.ToString(_portalSettings.HostSettings("DemoPeriod")) <> "", " for " & Convert.ToString(_portalSettings.HostSettings("DemoPeriod")) & " days", "")) & ". At any time during or after the trial period, you can convert your Demo Portal into a Registered Portal by logging in as the Administrator and selecting the Renew/Extend Your Portal Subscription link in the Admin tab. Registered Portals have the added benefit of using their own domain name ( ie. www.yourdomain.com ) as their Web address.<br><br><b>*Note:</b> Your Portal Name must be a simple name for your site and cannot contain spaces or punctuation characters. The URL for your portal will take the form of <b>" & GetDomainName(Request) & "/portalname</b><br><br>"
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(GetPortalDomainName(PortalAlias, Request), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Try
                Dim blnChild As Boolean
                Dim strMessage As String
                Dim strPortalAlias As String
                Dim intCounter As Integer
                Dim intPortalId As Integer
                Dim strServerPath As String
                Dim strBody As String
                Dim ExpiryDate As Date
                Dim strChildPath As String

                Dim objPortalController As New PortalController
                Dim objSecurity As New PortalSecurity

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                txtPortalName.Text = LCase(txtPortalName.Text)
                txtPortalName.Text = Replace(txtPortalName.Text, "http://", "")

                If _portalSettings.ActiveTab.ParentId <> _portalSettings.SuperTabId Then
                    blnChild = True

                    ' child portal
                    For intCounter = 1 To txtPortalName.Text.Length
                        If InStr(1, "abcdefghijklmnopqrstuvwxyz0123456789-", Mid(txtPortalName.Text, intCounter, 1)) = 0 Then
                            strMessage = "The Portal Name Must Not Contain Spaces Or Punctuation"
                        End If
                    Next intCounter

                    strPortalAlias = txtPortalName.Text
                Else
                    blnChild = optChild.Checked

                    If blnChild Then
                        strPortalAlias = Mid(txtPortalName.Text, InStrRev(txtPortalName.Text, "/") + 1)
                    Else
                        strPortalAlias = txtPortalName.Text
                    End If

                    Dim strValidChars As String = "abcdefghijklmnopqrstuvwxyz0123456789-"
                    If Not blnChild Then
                        strValidChars += "./:,"
                    End If

                    For intCounter = 1 To strPortalAlias.Length
                        If InStr(1, strValidChars, Mid(strPortalAlias, intCounter, 1)) = 0 Then
                            strMessage = "The Portal Name Must Not Contain Spaces Or Punctuation"
                        End If
                    Next intCounter

                End If

                If txtPassword.Text <> txtConfirm.Text Then
                    strMessage = "The Password Values Entered Do Not Match"
                End If

                strServerPath = GetAbsoluteServerPath(Request)

                If strMessage = "" Then
                    If blnChild Then
                        strChildPath = strServerPath & strPortalAlias

                        If System.IO.Directory.Exists(strChildPath) Then
                            strMessage = "The Child Portal Name You Specified Already Exists. Please Choose A Different Child Portal Name."
                        Else
                            If _portalSettings.ActiveTab.ParentId <> _portalSettings.SuperTabId Then
                                strPortalAlias = GetDomainName(Request) & "/" & strPortalAlias
                            Else
                                strPortalAlias = txtPortalName.Text
                            End If
                        End If
                    End If
                End If

                If strMessage = "" Then

                    If Convert.ToString(_portalSettings.HostSettings("DemoPeriod")) <> "" Then
                        ExpiryDate = Convert.ToDateTime(GetMediumDate(DateAdd(DateInterval.Day, Int32.Parse(Convert.ToString(_portalSettings.HostSettings("DemoPeriod"))), Now()).ToString))
                    Else
                        ExpiryDate = Convert.ToDateTime(Null.SetNull(ExpiryDate))
                    End If

                    Dim dblHostFee As Double = 0
                    If Convert.ToString(_portalSettings.HostSettings("HostFee")) <> "" Then
                        dblHostFee = Convert.ToDouble(_portalSettings.HostSettings("HostFee"))
                    End If

                    Dim dblHostSpace As Double = 0
                    If Convert.ToString(_portalSettings.HostSettings("HostSpace")) <> "" Then
                        dblHostSpace = Convert.ToDouble(_portalSettings.HostSettings("HostSpace"))
                    End If

                    Dim intSiteLogHistory As Integer = -1
                    If Convert.ToString(_portalSettings.HostSettings("SiteLogHistory")) <> "" Then
                        intSiteLogHistory = Convert.ToInt32(_portalSettings.HostSettings("SiteLogHistory"))
                    End If

                    Dim strCurrency As String = Convert.ToString(_portalSettings.HostSettings("HostCurrency"))
                    If strCurrency = "" Then
                        strCurrency = "USD"
                    End If

                    Dim strTemplateFile As String = ""
                    If cboTemplate.SelectedIndex <> 0 Then
                        strTemplateFile = cboTemplate.SelectedItem.Text & ".template"
                    End If

                    ' add new portal
                    'intPortalId = objPortalController.AddPortalInfo(txtPortalName.Text, strPortalAlias, strCurrency, txtFirstName.Text + txtLastName.Text, txtUsername.Text, objSecurity.Encrypt(Convert.ToString(_portalSettings.HostSettings("EncryptionKey")), txtPassword.Text), txtEmail.Text, ExpiryDate, dblHostFee, dblHostSpace, intSiteLogHistory, Request.MapPath(Global.HostPath), strTemplateFile)
                    'phuocdd: 25 Feb 2005: Encrypt password using MD5
                    intPortalId = objPortalController.AddPortalInfo(txtPortalName.Text, strPortalAlias, strCurrency, txtFirstName.Text + txtLastName.Text, txtUsername.Text, objSecurity.Encrypt(txtPassword.Text), txtEmail.Text, ExpiryDate, dblHostFee, dblHostSpace, intSiteLogHistory, Request.MapPath(Global.HostPath), strTemplateFile)

                    If intPortalId <> -1 Then

                        If blnChild Then
                            ' create the subdirectory for the new portal
                            System.IO.Directory.CreateDirectory(strChildPath)

                            ' create the subhost default.aspx file
                            System.IO.File.Copy(strServerPath & "subhost.aspx", strChildPath & "\default.aspx")
                        End If

                        ' the upload directory may already exist if this is a new DB working with a previously installed application
                        If Directory.Exists(strServerPath & "Portals\" & intPortalId.ToString) Then
                            DeleteFolderRecursive(strServerPath & "Portals\" & intPortalId.ToString)
                        End If

                        ' create the upload directory for the new portal
                        System.IO.Directory.CreateDirectory(strServerPath & "Portals\" & intPortalId.ToString)

                        ' copy the stylesheet to the upload directory
                        System.IO.File.Copy(strServerPath & "Portals\_default\portal.css", strServerPath & "Portals\" & intPortalId.ToString & "\portal.css")


                        ' notification
                        If _portalSettings.ActiveTab.ParentId <> _portalSettings.SuperTabId Then
                            strBody = "Dear " & txtFirstName.Text & " " & txtLastName.Text & "," & vbCrLf & vbCrLf
                            strBody = strBody & "Thank you for creating a Demo Portal. Please read the following information carefully and be sure to save this message in a safe location for future reference." & vbCrLf & vbCrLf
                            strBody = strBody & "Portal Website Address: " & GetDomainName(Request) & "/" & txtPortalName.Text & vbCrLf
                            strBody = strBody & "Administrator Username: " & txtUsername.Text & vbCrLf
                            strBody = strBody & "Administrator Password: " & txtPassword.Text & vbCrLf & vbCrLf
                            strBody = strBody & "Your Demo Portal will be active for " & Convert.ToString(_portalSettings.HostSettings("DemoPeriod")) & " days. At any time during or after the trial period, you can convert your Demo Portal into a Registered Portal by logging in as the Administrator and selecting the Renew/Extend Your Portal Subscription link in the Admin tab. Registered Portals have the added benefit of using their own domain name ( ie. www.yourdomain.com ) as their Web address." & vbCrLf & vbCrLf
                            strBody = strBody & "Thank you, we hope you will enjoy our service..."
                            SendNotification(_portalSettings.Email, txtEmail.Text, _portalSettings.Email, "Demo Portal Signup", strBody)
                        Else
                            strBody = "Dear " & txtFirstName.Text & " " & txtLastName.Text & "," & vbCrLf & vbCrLf
                            strBody = strBody & "Your Portal Website Has Been Created. Please read the following information carefully and be sure to save this message in a safe location for future reference." & vbCrLf & vbCrLf
                            strBody = strBody & "Portal Website Address: " & txtPortalName.Text & vbCrLf
                            strBody = strBody & "Administrator Username: " & txtUsername.Text & vbCrLf
                            strBody = strBody & "Administrator Password: " & txtPassword.Text & vbCrLf & vbCrLf
                            strBody = strBody & "Thank you, we hope you will enjoy our service..."
                            SendNotification(Convert.ToString(_portalSettings.HostSettings("HostEmail")), txtEmail.Text, Convert.ToString(_portalSettings.HostSettings("HostEmail")), "Demo Portal Signup", strBody)
                        End If

                        ' Redirect to this new site
                        'Response.Redirect(AddHTTP(strPortalAlias), True)
                        Response.Redirect(EditURL("portalid", CStr(intPortalId)), True)
                        'Response.Redirect(GetPortalDomainName(PortalAlias, Request), True)
                    Else
                        strMessage = "An Error Was Encountered During The Creation Of Your Portal. This May Have Been Caused By Specifying An Incorrect Password For An Existing User Account. Please Verify Your Details Before You Try Again."
                    End If
                End If

                lblMessage.Text = "<br>" & strMessage & "<br><br>"

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub optChild_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optChild.CheckedChanged
            Try
                txtPortalName.Text = GetDomainName(Request) & "/"

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace