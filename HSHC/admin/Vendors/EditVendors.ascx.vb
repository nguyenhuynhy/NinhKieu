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
    Public Class EditVendors
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents Title1 As DesktopModuleTitle

        ' module options
        Protected WithEvents txtVendorName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valVendorName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valFirstName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valLastName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents Address1 As Address
        Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents valEmail As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtWebsite As System.Web.UI.WebControls.TextBox
        Protected WithEvents rowVendor1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents cboLogo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents rowVendor2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents chkAuthorized As System.Web.UI.WebControls.CheckBox
        Protected WithEvents colVendor As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents lstClassifications As System.Web.UI.WebControls.ListBox
        Protected WithEvents txtKeyWords As System.Web.UI.WebControls.TextBox

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Protected WithEvents pnlAudit As System.Web.UI.WebControls.Panel
        Protected WithEvents lblCreatedBy As System.Web.UI.WebControls.Label
        Protected WithEvents lblCreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblViews As System.Web.UI.WebControls.Label
        Protected WithEvents lblClickThroughs As System.Web.UI.WebControls.Label

        Protected WithEvents pnlBanners As System.Web.UI.WebControls.PlaceHolder
        Protected WithEvents pnlAffiliates As System.Web.UI.WebControls.PlaceHolder

        Public VendorID As Integer = -1

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
                Dim objTabs As New TabController
                Dim objTab As TabInfo
                Dim objModules As New ModuleController

                Dim blnBanner As Boolean = False
                Dim blnSignup As Boolean = False

                If Not (Request.Params("VendorID") Is Nothing) Then
                    VendorID = Int32.Parse(Request.Params("VendorID"))
                End If

                If Not Request.Params("def") Is Nothing And VendorID = -1 Then
                    blnSignup = True
                End If

                If Not Request.Params("banner") Is Nothing Then
                    blnBanner = True
                End If

                If Page.IsPostBack = False Then

                    Address1.ModuleId = ModuleId
                    Address1.StartTabIndex = 4

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    ' load the list of files found in the upload directory
                    Dim strDirectory As String
                    Dim FileList As ArrayList
                    If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                        FileList = GetFileList(, glbImageFileTypes)
                    Else
                        FileList = GetFileList(PortalId, glbImageFileTypes)
                    End If
                    cboLogo.DataSource = FileList
                    cboLogo.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    Dim objClassifications As New ClassificationController
                    Dim Arr As ArrayList = objClassifications.GetVendorClassifications(VendorID)
                    Dim i As Integer
                    For i = 0 To Arr.Count - 1
                        Dim lstItem As New ListItem
                        Dim objClassification As ClassificationInfo = CType(Arr(0), ClassificationInfo)
                        lstItem.Text = objClassification.ClassificationName
                        lstItem.Value = objClassification.ClassificationId.ToString
                        lstItem.Selected = objClassification.IsAssociated
                        lstClassifications.Items.Add(lstItem)
                    Next

                    Dim objVendors As New VendorController
                    If VendorID <> -1 Then
                        Dim objVendor As VendorInfo
                        objVendor = objVendors.GetVendor(VendorID)
                        If Not objVendor Is Nothing Then
                            txtVendorName.Text = objVendor.VendorName
                            txtFirstName.Text = objVendor.FirstName
                            txtLastName.Text = objVendor.LastName
                            If cboLogo.Items.Contains(New ListItem(objVendor.LogoFile)) Then
                                cboLogo.Items.FindByText(objVendor.LogoFile).Selected = True
                            End If
                            Address1.Unit = objVendor.Unit
                            Address1.Street = objVendor.Street
                            Address1.City = objVendor.City
                            Address1.Region = objVendor.Region
                            Address1.Country = objVendor.Country
                            Address1.Postal = objVendor.PostalCode
                            Address1.Telephone = objVendor.Telephone
                            txtFax.Text = objVendor.Fax
                            txtEmail.Text = objVendor.Email
                            txtWebsite.Text = objVendor.Website
                            chkAuthorized.Checked = objVendor.Authorized
                            txtKeyWords.Text = objVendor.KeyWords

                            lblCreatedBy.Text = objVendor.CreatedByUser
                            lblCreatedDate.Text = objVendor.CreatedDate.ToString
                            lblViews.Text = objVendor.Views.ToString
                            lblClickThroughs.Text = objVendor.ClickThroughs.ToString
                        End If

                        ' use dispatch method to load modules
                        Dim objPortalModuleControl As PortalModuleControl

                        objPortalModuleControl = CType(Me.LoadControl("~" & Me.TemplateSourceDirectory.Remove(0, Global.ApplicationPath.Length) & "/Banners.ascx"), PortalModuleControl)
                        objPortalModuleControl.ModuleConfiguration = ModuleConfiguration
                        pnlBanners.Controls.Add(objPortalModuleControl)

                        objPortalModuleControl = CType(Me.LoadControl("~" & Me.TemplateSourceDirectory.Remove(0, Global.ApplicationPath.Length) & "/Affiliates.ascx"), PortalModuleControl)
                        objPortalModuleControl.ModuleConfiguration = ModuleConfiguration
                        pnlAffiliates.Controls.Add(objPortalModuleControl)

                    Else
                        chkAuthorized.Checked = True
                        pnlAudit.Visible = False
                        cmdDelete.Visible = False
                        pnlBanners.Visible = False
                        pnlAffiliates.Visible = False
                    End If

                    If blnSignup = True Or blnBanner = True Then
                        rowVendor1.Visible = False
                        rowVendor2.Visible = False
                        colVendor.Visible = False
                        cmdDelete.Visible = False
                        pnlAudit.Visible = False

                        If blnBanner = True Then
                            cmdUpdate.Visible = False
                        Else
                            Title1.DisplayTitle = "Application Form"
                            cmdUpdate.Text = "Signup"
                        End If
                    Else
                        If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                            objTab = objTabs.GetTabByName("Vendors")
                        Else
                            objTab = objTabs.GetTabByName("Vendors", PortalId)
                        End If
                        If Not objTab Is Nothing Then
                            ViewState("filter") = Request.Params("filter")
                        End If
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try

                Dim intPortalID As Integer
                Dim strLogoFile As String = ""

                If Page.IsValid Then

                    If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                        intPortalID = -1
                    Else
                        intPortalID = PortalId
                    End If

                    If Not cboLogo.SelectedItem Is Nothing Then
                        If cboLogo.SelectedIndex <> 0 Then
                            strLogoFile = cboLogo.SelectedItem.Value
                        End If
                    End If

                    Dim objVendors As New VendorController
                    Dim objVendor As New VendorInfo

                    objVendor.PortalId = intPortalID
                    objVendor.VendorId = VendorID
                    objVendor.VendorName = txtVendorName.Text
                    objVendor.Unit = Address1.Unit
                    objVendor.Street = Address1.Street
                    objVendor.City = Address1.City
                    objVendor.Region = Address1.Region
                    objVendor.Country = Address1.Country
                    objVendor.PostalCode = Address1.Postal
                    objVendor.Telephone = Address1.Telephone
                    objVendor.Fax = txtFax.Text
                    objVendor.Email = txtEmail.Text
                    objVendor.Website = txtWebsite.Text
                    objVendor.FirstName = txtFirstName.Text
                    objVendor.LastName = txtLastName.Text
                    objVendor.UserName = Context.User.Identity.Name
                    objVendor.LogoFile = strLogoFile
                    objVendor.KeyWords = txtKeyWords.Text
                    objVendor.Authorized = chkAuthorized.Checked

                    If VendorID = -1 Then
                        VendorID = objVendors.AddVendor(objVendor)
                    Else
                        objVendors.UpdateVendor(objVendor)
                    End If

                    ' update vendor classifications
                    Dim objClassifications As New ClassificationController
                    objClassifications.DeleteVendorClassifications(VendorID)
                    Dim lstItem As ListItem
                    For Each lstItem In lstClassifications.Items
                        If lstItem.Selected Then
                            objClassifications.AddVendorClassification(VendorID, Int32.Parse(lstItem.Value))
                        End If
                    Next

                    If cmdUpdate.Text = "Signup" Then
                        Dim strBody As String = ""
                        strBody = strBody & "Date: " & Now().ToString & vbCrLf & vbCrLf
                        strBody = strBody & "Vendor Name: " & txtVendorName.Text & vbCrLf
                        strBody = strBody & "First Name: " & txtFirstName.Text & vbCrLf
                        strBody = strBody & "Last Name: " & txtLastName.Text & vbCrLf & vbCrLf
                        strBody = strBody & "Unit: " & Address1.Unit & vbCrLf
                        strBody = strBody & "Street: " & Address1.Street & vbCrLf
                        strBody = strBody & "City: " & Address1.City & vbCrLf
                        strBody = strBody & "Region: " & Address1.Region & vbCrLf
                        strBody = strBody & "Country: " & Address1.Country & vbCrLf
                        strBody = strBody & "Postal Code: " & Address1.Postal & vbCrLf
                        strBody = strBody & "Telephone: " & Address1.Telephone & vbCrLf & vbCrLf
                        strBody = strBody & "Fax: " & txtFax.Text & vbCrLf
                        strBody = strBody & "Email: " & txtEmail.Text & vbCrLf
                        strBody = strBody & "Website: " & txtWebsite.Text & vbCrLf

                        SendNotification(txtEmail.Text, PortalSettings.Email, "", PortalSettings.PortalName & " Vendor Application", strBody)

                        strBody = "Dear " & txtFirstName.Text & " " & txtLastName.Text & "," & vbCrLf & vbCrLf
                        strBody = strBody & "Your company has been successfully registered at the " & PortalSettings.PortalName & " portal website." & vbCrLf & vbCrLf
                        strBody = strBody & "Thank you," & vbCrLf & vbCrLf
                        strBody = strBody & PortalSettings.PortalName

                        SendNotification(PortalSettings.Email, txtEmail.Text, "", PortalSettings.PortalName & " Vendor Application", strBody)

                        Response.Redirect(NavigateURL() & "&filter=" & Left(txtVendorName.Text, 1), True)
                    Else
                        Response.Redirect(NavigateURL() & "&filter=" & Convert.ToString(Viewstate("filter")), True)
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                If VendorID <> -1 Then
                    Dim objVendors As New VendorController
                    objVendors.DeleteVendor(VendorID)
                End If
                Response.Redirect(NavigateURL())

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL() & "&filter=" & Convert.ToString(Viewstate("filter")), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
    End Class

End Namespace
