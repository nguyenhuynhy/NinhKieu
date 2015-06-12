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

Imports System.IO

Namespace PortalQH

    Public Class SiteSettings
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtPortalName As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboLogo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ctlPortalSkin As SkinControl
        Protected WithEvents ctlPortalContainer As SkinControl
        Protected WithEvents ctlAdminSkin As SkinControl
        Protected WithEvents ctlAdminContainer As SkinControl
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKeyWords As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdGoogle As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cboBackground As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFooterText As System.Web.UI.WebControls.TextBox
        Protected WithEvents optUserRegistration As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents optBannerAdvertising As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents cboHomeTabId As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboLoginTabId As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboUserTabId As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboAdministratorId As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboProcessor As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdProcessor As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtUserId As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox

        Protected WithEvents SiteRow1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtPortalAlias As System.Web.UI.WebControls.TextBox
        Protected WithEvents SiteRow2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtExpiryDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents SiteRow3 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtHostSpace As System.Web.UI.WebControls.TextBox
        Protected WithEvents SiteRow4 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtHostFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents SiteRow5 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtSiteLogHistory As System.Web.UI.WebControls.TextBox
        Protected WithEvents SiteRow6 As System.Web.UI.HtmlControls.HtmlTableRow

        Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtRegistration As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSignup As System.Web.UI.WebControls.TextBox

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Protected WithEvents chkStyleSheet As System.Web.UI.WebControls.CheckBox
        Protected WithEvents StyleRow1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtStyleSheet As System.Web.UI.WebControls.TextBox
        Protected WithEvents StyleRow2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents cmdSave As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdRestore As System.Web.UI.WebControls.LinkButton

        Protected WithEvents PortalRow1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents PortalRow2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents grdModuleDefinitions As System.Web.UI.WebControls.DataGrid
        Protected WithEvents PortalRow3 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblHostFee As System.Web.UI.WebControls.Label
        Protected WithEvents lblHostCurrency As System.Web.UI.WebControls.Label
        Protected WithEvents lblModuleFee As System.Web.UI.WebControls.Label
        Protected WithEvents lblModuleCurrency As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalFee As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalCurrency As System.Web.UI.WebControls.Label
        Protected WithEvents PortalRow4 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents PortalRow5 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblExpiryDate As System.Web.UI.WebControls.Label
        Protected WithEvents PortalRow6 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents PortalRow7 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents cmdRenew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdExpiryCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents valExpiryDate As System.Web.UI.WebControls.CompareValidator

        Dim intPortalId As Integer = -1

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
        ' The Page_Load server event handler on this user control is used
        ' to populate the current site settings from the config system
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If Not (Request.QueryString("pid") Is Nothing) And _portalSettings.ActiveTab.ParentId = _portalSettings.SuperTabId Then
                    intPortalId = Int32.Parse(Request.QueryString("pid"))
                Else
                    intPortalId = PortalId
                End If

                ' If this is the first visit to the page, populate the site data
                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Portal ?');")
                    cmdExpiryCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtExpiryDate)

                    ' load the list of files found in the upload directory
                    Dim ImageFileList As ArrayList = GetFileList(intPortalId, glbImageFileTypes)
                    cboLogo.DataSource = ImageFileList
                    cboLogo.DataBind()
                    cboBackground.DataSource = ImageFileList
                    cboBackground.DataBind()

                    Dim objCode As New CodeController
                    Dim objPortalController As New PortalController
                    Dim objModules As New ModuleController
                    Dim objUsers As New UserController

                    cboProcessor.DataSource = objCode.GetProcessorCodes
                    cboProcessor.DataBind()

                    Dim objPortal As PortalInfo = objPortalController.GetPortal(intPortalId)

                    txtPortalName.Text = objPortal.PortalName
                    If cboLogo.Items.Contains(New ListItem(objPortal.LogoFile)) Then
                        cboLogo.Items.FindByText(objPortal.LogoFile).Selected = True
                    End If
                    txtDescription.Text = objPortal.Description
                    txtKeyWords.Text = objPortal.KeyWords
                    If cboBackground.Items.Contains(New ListItem(objPortal.BackgroundFile)) Then
                        cboBackground.Items.FindByText(objPortal.BackgroundFile).Selected = True
                    End If
                    txtFooterText.Text = objPortal.FooterText
                    optUserRegistration.SelectedIndex = objPortal.UserRegistration
                    optBannerAdvertising.SelectedIndex = objPortal.BannerAdvertising

                    cboHomeTabId.DataSource = GetPortalTabs(_portalSettings.DesktopTabs, True, True)
                    cboHomeTabId.DataBind()
                    If Not cboHomeTabId.Items.FindByValue(objPortal.HomeTabId.ToString) Is Nothing Then
                        cboHomeTabId.Items.FindByValue(objPortal.HomeTabId.ToString).Selected = True
                    End If
                    cboLoginTabId.DataSource = GetPortalTabs(_portalSettings.DesktopTabs, True, True)
                    cboLoginTabId.DataBind()
                    If Not cboLoginTabId.Items.FindByValue(objPortal.LoginTabId.ToString) Is Nothing Then
                        cboLoginTabId.Items.FindByValue(objPortal.LoginTabId.ToString).Selected = True
                    End If
                    cboUserTabId.DataSource = GetPortalTabs(_portalSettings.DesktopTabs, True, True)
                    cboUserTabId.DataBind()
                    If Not cboUserTabId.Items.FindByValue(objPortal.UserTabId.ToString) Is Nothing Then
                        cboUserTabId.Items.FindByValue(objPortal.UserTabId.ToString).Selected = True
                    End If

                    cboCurrency.DataSource = objCode.GetCurrencies()
                    cboCurrency.DataBind()
                    If Null.IsNull(objPortal.Currency) Then
                        cboCurrency.Items.FindByValue("USD").Selected = True
                    Else
                        cboCurrency.Items.FindByValue(objPortal.Currency).Selected = True
                    End If

                    Dim Arr As ArrayList = objUsers.GetRoleMembership(intPortalId, objPortal.AdministratorRoleId)
                    Dim i As Integer
                    For i = 0 To Arr.Count - 1
                        Dim objUser As UserRoleInfo = CType(Arr(i), UserRoleInfo)
                        cboAdministratorId.Items.Add(New ListItem(objUser.FullName, objUser.UserID.ToString))
                    Next
                    If Not cboAdministratorId.Items.FindByValue(objPortal.AdministratorId.ToString) Is Nothing Then
                        cboAdministratorId.Items.FindByValue(objPortal.AdministratorId.ToString).Selected = True
                    End If

                    txtPortalAlias.Text = objPortal.PortalAlias
                    If Not Null.IsNull(objPortal.ExpiryDate) Then
                        txtExpiryDate.Text = objPortal.ExpiryDate.ToShortDateString
                    End If
                    lblExpiryDate.Text = txtExpiryDate.Text
                    txtHostFee.Text = objPortal.HostFee.ToString
                    If txtHostFee.Text <> "" Then
                        lblHostFee.Text = Format(Val(txtHostFee.Text), "#,##0.00")
                    Else
                        lblHostFee.Text = "0.00"
                    End If
                    lblHostCurrency.Text = Convert.ToString(_portalSettings.HostSettings("HostCurrency")) & " / Month"
                    txtHostSpace.Text = objPortal.HostSpace.ToString
                    If Not IsDBNull(objPortal.SiteLogHistory) Then
                        txtSiteLogHistory.Text = objPortal.SiteLogHistory.ToString
                    End If

                    If Not cboProcessor.Items.FindByText(objPortal.PaymentProcessor) Is Nothing Then
                        cboProcessor.Items.FindByText(objPortal.PaymentProcessor).Selected = True
                    Else ' default
                        cboProcessor.Items.FindByText("PayPal").Selected = True
                    End If
                    txtUserId.Text = objPortal.ProcessorUserId
                    txtPassword.Text = objPortal.ProcessorPassword

                    Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", intPortalId)
                    Dim settings As Hashtable = _portalSettings.GetModuleSettings(intModuleId)
                    txtLogin.Text = CType(settings("loginmessage"), String)
                    txtRegistration.Text = CType(settings("registrationmessage"), String)
                    txtSignup.Text = CType(settings("signupmessage"), String)

                    Dim objSkins As New SkinController
                    Dim objSkin As SkinInfo

                    ctlPortalSkin.Width = "300px"
                    ctlPortalSkin.SkinRoot = SkinInfo.RootSkin
                    objSkin = objSkins.GetSkin(SkinInfo.RootSkin, PortalId, Null.NullInteger, Null.NullInteger, False)
                    If Not objSkin Is Nothing Then
                        If objSkin.PortalId = PortalId And Null.IsNull(objSkin.TabId) = True Then
                            ctlPortalSkin.SkinType = objSkin.SkinType
                            ctlPortalSkin.SkinName = objSkin.SkinName
                            ctlPortalSkin.SkinSrc = objSkin.SkinSrc
                        End If
                    End If
                    ctlPortalContainer.Width = "300px"
                    ctlPortalContainer.SkinRoot = SkinInfo.RootContainer
                    objSkin = objSkins.GetSkin(SkinInfo.RootContainer, PortalId, Null.NullInteger, Null.NullInteger, False)
                    If Not objSkin Is Nothing Then
                        If objSkin.PortalId = PortalId And Null.IsNull(objSkin.ModuleId) = True Then
                            ctlPortalContainer.SkinType = objSkin.SkinType
                            ctlPortalContainer.SkinName = objSkin.SkinName
                            ctlPortalContainer.SkinSrc = objSkin.SkinSrc
                        End If
                    End If

                    ctlAdminSkin.Width = "300px"
                    ctlAdminSkin.SkinRoot = SkinInfo.RootSkin
                    objSkin = objSkins.GetSkin(SkinInfo.RootSkin, PortalId, Null.NullInteger, Null.NullInteger, True)
                    If Not objSkin Is Nothing Then
                        If objSkin.PortalId = PortalId And Null.IsNull(objSkin.TabId) = True Then
                            ctlAdminSkin.SkinType = objSkin.SkinType
                            ctlAdminSkin.SkinName = objSkin.SkinName
                            ctlAdminSkin.SkinSrc = objSkin.SkinSrc
                        End If
                    End If
                    ctlAdminContainer.Width = "300px"
                    ctlAdminContainer.SkinRoot = SkinInfo.RootContainer
                    objSkin = objSkins.GetSkin(SkinInfo.RootContainer, PortalId, Null.NullInteger, Null.NullInteger, True)
                    If Not objSkin Is Nothing Then
                        If objSkin.PortalId = PortalId And Null.IsNull(objSkin.ModuleId) = True Then
                            ctlAdminContainer.SkinType = objSkin.SkinType
                            ctlAdminContainer.SkinName = objSkin.SkinName
                            ctlAdminContainer.SkinSrc = objSkin.SkinSrc
                        End If
                    End If

                    BindData()

                    If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                        SiteRow1.Visible = True
                        SiteRow2.Visible = True
                        SiteRow3.Visible = True
                        SiteRow4.Visible = True
                        SiteRow5.Visible = True
                        SiteRow6.Visible = True

                        cmdCancel.Visible = True
                        cmdDelete.Visible = True
                        cmdRenew.Visible = False
                    End If

                    If Not Request.UrlReferrer Is Nothing Then
                        ViewState("UrlReferrer") = Convert.ToString(Request.UrlReferrer)
                    Else
                        ViewState("UrlReferrer") = ""
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub BindData()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim objDesktopModules As New DesktopModuleController

            Dim arrDesktopModules As ArrayList = objDesktopModules.GetPremiumDesktopModules(intPortalId)

            grdModuleDefinitions.DataSource = arrDesktopModules
            grdModuleDefinitions.DataBind()

            If grdModuleDefinitions.Items.Count = 0 Then
                grdModuleDefinitions.Visible = False
            End If

            Dim dblModuleFee As Double = 0
            lblModuleCurrency.Text = Convert.ToString(_portalSettings.HostSettings("HostCurrency")) & " / Month"

            Dim intItem As Integer
            For intItem = 0 To arrDesktopModules.Count - 1
                dblModuleFee += CType(arrDesktopModules(intItem), DesktopModuleInfo).HostFee
            Next
            lblModuleFee.Text = Format(dblModuleFee, "#,##0.00")

            lblTotalFee.Text = Format(Val(lblHostFee.Text) + Val(lblModuleFee.Text), "#,##0.00")
            lblTotalCurrency.Text = Convert.ToString(_portalSettings.HostSettings("HostCurrency")) & " / Month"

        End Sub

        Private Sub Update_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                Dim strServerPath As String
                Dim strPortalName As String
                Dim strLogo As String
                Dim strBackground As String

                If Not cboLogo.SelectedItem Is Nothing Then
                    strLogo = cboLogo.SelectedItem.Value
                End If
                If Not cboBackground.SelectedItem Is Nothing Then
                    strBackground = cboBackground.SelectedItem.Value
                End If

                Dim dblHostFee As Double = 0
                If txtHostFee.Text <> "" Then
                    dblHostFee = Double.Parse(txtHostFee.Text)
                End If

                Dim dblHostSpace As Double = 0
                If txtHostSpace.Text <> "" Then
                    dblHostSpace = Double.Parse(txtHostSpace.Text)
                End If

                Dim intSiteLogHistory As Integer = -1
                If txtSiteLogHistory.Text <> "" Then
                    intSiteLogHistory = Integer.Parse(txtSiteLogHistory.Text)
                End If

                Dim datExpiryDate As Date = Convert.ToDateTime(Null.SetNull(datExpiryDate))
                If txtExpiryDate.Text <> "" Then
                    datExpiryDate = Convert.ToDateTime(txtExpiryDate.Text)
                End If

                Dim intHomeTabId As Integer = Convert.ToInt32(Null.SetNull(intHomeTabId))
                If Not cboHomeTabId.SelectedItem Is Nothing Then
                    intHomeTabId = Integer.Parse(cboHomeTabId.SelectedItem.Value)
                End If

                Dim intLoginTabId As Integer = Convert.ToInt32(Null.SetNull(intLoginTabId))
                If Not cboLoginTabId.SelectedItem Is Nothing Then
                    intLoginTabId = Integer.Parse(cboLoginTabId.SelectedItem.Value)
                End If

                Dim intUserTabId As Integer = Convert.ToInt32(Null.SetNull(intUserTabId))
                If Not cboUserTabId.SelectedItem Is Nothing Then
                    intUserTabId = Integer.Parse(cboUserTabId.SelectedItem.Value)
                End If

                ' update Portal info in the database
                Dim objPortalController As New PortalController
                Dim objModules As New ModuleController
                'objPortalController.UpdatePortalInfo(intPortalId, txtPortalName.Text, txtPortalAlias.Text, strLogo, txtFooterText.Text, datExpiryDate, optUserRegistration.SelectedIndex, optBannerAdvertising.SelectedIndex, cboCurrency.SelectedItem.Value, Convert.ToInt32(cboAdministratorId.SelectedItem.Value), dblHostFee, dblHostSpace, cboProcessor.SelectedItem.Text, txtUserId.Text, txtPassword.Text, txtDescription.Text, txtKeyWords.Text, strBackground, intSiteLogHistory, intHomeTabId, intLoginTabId, intUserTabId)
                objPortalController.UpdatePortalInfo(intPortalId, txtPortalName.Text, txtPortalAlias.Text, strLogo, txtFooterText.Text, datExpiryDate, optUserRegistration.SelectedIndex, optBannerAdvertising.SelectedIndex, cboCurrency.SelectedItem.Value, cboAdministratorId.SelectedItem.Value, dblHostFee, dblHostSpace, cboProcessor.SelectedItem.Text, txtUserId.Text, txtPassword.Text, txtDescription.Text, txtKeyWords.Text, strBackground, intSiteLogHistory, intHomeTabId, intLoginTabId, intUserTabId)

                Dim intModuleId As Integer = objModules.GetSiteModule("Site Settings", intPortalId)
                objModules.UpdateModuleSetting(intModuleId, "loginmessage", txtLogin.Text)
                objModules.UpdateModuleSetting(intModuleId, "registrationmessage", txtRegistration.Text)
                objModules.UpdateModuleSetting(intModuleId, "signupmessage", txtSignup.Text)

                Dim objSkins As New SkinController
                'objSkins.SetSkin(SkinInfo.RootSkin, PortalId, Null.NullInteger, Null.NullInteger, False, ctlPortalSkin.SkinType, ctlPortalSkin.SkinName, ctlPortalSkin.SkinSrc)
                'objSkins.SetSkin(SkinInfo.RootContainer, PortalId, Null.NullInteger, Null.NullInteger, False, ctlPortalContainer.SkinType, ctlPortalContainer.SkinName, ctlPortalContainer.SkinSrc)
                'objSkins.SetSkin(SkinInfo.RootSkin, PortalId, Null.NullInteger, Null.NullInteger, True, ctlAdminSkin.SkinType, ctlAdminSkin.SkinName, ctlAdminSkin.SkinSrc)
                'objSkins.SetSkin(SkinInfo.RootContainer, PortalId, Null.NullInteger, Null.NullInteger, True, ctlAdminContainer.SkinType, ctlAdminContainer.SkinName, ctlAdminContainer.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootSkin, intPortalId, Null.NullInteger, Null.NullInteger, False, ctlPortalSkin.SkinType, ctlPortalSkin.SkinName, ctlPortalSkin.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootContainer, intPortalId, Null.NullInteger, Null.NullInteger, False, ctlPortalContainer.SkinType, ctlPortalContainer.SkinName, ctlPortalContainer.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootSkin, intPortalId, Null.NullInteger, Null.NullInteger, True, ctlAdminSkin.SkinType, ctlAdminSkin.SkinName, ctlAdminSkin.SkinSrc)
                objSkins.SetSkin(SkinInfo.RootContainer, intPortalId, Null.NullInteger, Null.NullInteger, True, ctlAdminContainer.SkinType, ctlAdminContainer.SkinName, ctlAdminContainer.SkinSrc)

                ' Redirect to this site to refresh
                If intPortalId = PortalId Then
                    Response.Redirect(Request.RawUrl, True)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub Delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try

                Dim FileName As String
                Dim strServerPath As String
                Dim strPortalName As String

                strServerPath = GetAbsoluteServerPath(Request)

                Dim objPortalController As New PortalController

                Dim objPortalInfo As PortalInfo = objPortalController.GetPortal(intPortalId)
                If Not objPortalInfo Is Nothing Then
                    ' delete upload directory

                    DeleteFolderRecursive(strServerPath & "Portals\" & objPortalInfo.PortalID.ToString)

                    ' delete child directory
                    strPortalName = GetPortalDomainName(objPortalInfo.PortalAlias)
                    If Convert.ToBoolean(InStr(1, objPortalInfo.PortalAlias, "/")) Then
                        strPortalName = Mid(objPortalInfo.PortalAlias, InStrRev(objPortalInfo.PortalAlias, "/") + 1)
                    End If
                    If System.IO.Directory.Exists(strServerPath & strPortalName) Then
                        DeleteFolderRecursive(strServerPath & strPortalName)
                    End If

                    ' remove skin assignments
                    Dim objSkin As New SkinController
                    objSkin.SetSkin(SkinInfo.RootSkin, intPortalId, Null.NullInteger, Null.NullInteger, False, "", "", "")
                    objSkin.SetSkin(SkinInfo.RootContainer, intPortalId, Null.NullInteger, Null.NullInteger, False, "", "", "")
                    objSkin.SetSkin(SkinInfo.RootSkin, intPortalId, Null.NullInteger, Null.NullInteger, True, "", "", "")
                    objSkin.SetSkin(SkinInfo.RootContainer, intPortalId, Null.NullInteger, Null.NullInteger, True, "", "", "")

                    ' remove database references
                    objPortalController.DeletePortalInfo(intPortalId)
                End If

                ' Redirect to another site
                If intPortalId = PortalId Then
                    If PortalSettings.HostSettings("HostURL").ToString <> "" Then
                        Response.Redirect(AddHTTP(PortalSettings.HostSettings("HostURL").ToString))
                    Else
                        Response.End()
                    End If
                Else
                    Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)
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

        Private Sub cmdRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRenew.Click
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim strProcessorURL As String = ""

                Dim objPortalController As New PortalController

                Dim strAdministratorRoleId As String
                Dim objPortalInfo As PortalInfo = objPortalController.GetPortal(intPortalId)
                If Not objPortalInfo Is Nothing Then
                    strAdministratorRoleId = objPortalInfo.AdministratorRoleId.ToString
                End If

                If Convert.ToString(_portalSettings.HostSettings("PaymentProcessor")) = "PayPal" Then
                    strProcessorURL = "https://www.paypal.com/xclick/business=" & HTTPPOSTEncode(Convert.ToString(_portalSettings.HostSettings("ProcessorUserId")))
                    strProcessorURL = strProcessorURL & "&item_name=" & HTTPPOSTEncode(txtPortalName.Text & " - Portal Subscription Renewal ( Basic Hosting Fee: " & lblHostFee.Text & " + Premium Modules: " & lblModuleFee.Text & " = Total Hosting Fee: " & lblTotalFee.Text & " )")
                    strProcessorURL = strProcessorURL & "&item_number=" & HTTPPOSTEncode(strAdministratorRoleId)
                    strProcessorURL = strProcessorURL & "&quantity=1" ' month by month only due to premium modules
                    strProcessorURL = strProcessorURL & "&custom=" & HTTPPOSTEncode(Context.User.Identity.Name)
                    strProcessorURL = strProcessorURL & "&amount=" & HTTPPOSTEncode(lblTotalFee.Text)
                    strProcessorURL = strProcessorURL & "&currency_code=" & HTTPPOSTEncode(Convert.ToString(_portalSettings.HostSettings("HostCurrency")))
                    strProcessorURL = strProcessorURL & "&return=" & HTTPPOSTEncode("http://" & GetDomainName(Request))
                    strProcessorURL = strProcessorURL & "&cancel_return=" & HTTPPOSTEncode("http://" & GetDomainName(Request))
                    strProcessorURL = strProcessorURL & "&notify_url=" & HTTPPOSTEncode("http://" & GetDomainName(Request) & "/admin/Sales/PayPalIPN.aspx")
                    strProcessorURL = strProcessorURL & "&undefined_quantity=&no_note=1&no_shipping=1"
                End If

                ' redirect to payment processor
                If strProcessorURL <> "" Then
                    Response.Redirect(strProcessorURL, True)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkStyleSheet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStyleSheet.CheckedChanged
            Try
                If chkStyleSheet.Checked Then
                    StyleRow1.Visible = True
                    StyleRow2.Visible = True
                    LoadStyleSheet()
                Else
                    StyleRow1.Visible = False
                    StyleRow2.Visible = False
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub LoadStyleSheet()

            Dim strUploadDirectory As String

            Dim objPortalController As New PortalController
            Dim objPortal As PortalInfo = objPortalController.GetPortal(intPortalId)
            If Not objPortal Is Nothing Then
                strUploadDirectory = Convert.ToString(IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath)) & "/Portals/" & objPortal.PortalID.ToString & "/"
            End If

            ' read CSS file
            Dim objStreamReader As StreamReader
            objStreamReader = File.OpenText(Server.MapPath(strUploadDirectory & "portal.css"))
            txtStyleSheet.Text = objStreamReader.ReadToEnd
            objStreamReader.Close()

        End Sub


        Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
            Try
                Dim strUploadDirectory As String

                Dim objPortalController As New PortalController
                Dim objPortal As PortalInfo = objPortalController.GetPortal(intPortalId)
                If Not objPortal Is Nothing Then
                    strUploadDirectory = Convert.ToString(IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath)) & "/Portals/" & objPortal.PortalID.ToString & "/"
                End If

                ' write CSS file
                Dim objStream As StreamWriter
                objStream = File.CreateText(Server.MapPath(strUploadDirectory & "portal.css"))
                objStream.WriteLine(txtStyleSheet.Text)
                objStream.Close()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestore.Click
            Try
                Dim strServerPath As String = GetAbsoluteServerPath(Request)

                Dim objPortalController As New PortalController
                Dim objPortal As PortalInfo = objPortalController.GetPortal(intPortalId)
                If Not objPortal Is Nothing Then
                    If System.IO.File.Exists(strServerPath & "Portals\" & objPortal.PortalID.ToString & "\portal.css") Then
                        ' delete existing style sheet
                        System.IO.File.Delete(strServerPath & "Portals\" & objPortal.PortalID.ToString & "\portal.css")
                    End If
                    ' copy the default style sheet to the upload directory
                    System.IO.File.Copy(strServerPath & "portal.css", strServerPath & "Portals\" & objPortal.PortalID.ToString & "\portal.css")
                End If

                LoadStyleSheet()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdGoogle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGoogle.Click
            Try

                Dim strURL As String = ""
                Dim strComments As String = ""

                Dim objPortalController As New PortalController
                Dim objPortal As PortalInfo = objPortalController.GetPortal(intPortalId)
                If Not objPortal Is Nothing Then
                    strComments += objPortal.PortalName
                    If objPortal.Description <> "" Then
                        strComments += " " & objPortal.Description
                    End If
                    If objPortal.KeyWords <> "" Then
                        strComments += " " & objPortal.KeyWords
                    End If
                End If

                strURL += "http://www.google.com/addurl?q=" & HTTPPOSTEncode(AddHTTP(GetDomainName(Request)))
                strURL += "&dq=" & HTTPPOSTEncode(strComments)
                strURL += "&submit=Add+URL"

                Response.Redirect(strURL, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdModuleDefinitions_CancelEdit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try
                grdModuleDefinitions.EditItemIndex = -1
                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdModuleDefinitions_Edit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                    grdModuleDefinitions.EditItemIndex = e.Item.ItemIndex
                    grdModuleDefinitions.SelectedIndex = -1
                End If

                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdModuleDefinitions_Update(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try
                Dim chkSubscribed As CheckBox = CType(e.Item.FindControl("Checkbox2"), WebControls.CheckBox)
                Dim txtHostingFee As TextBox = CType(e.Item.FindControl("txtHostingFee"), WebControls.TextBox)

                Dim dblHostFee As Double = 0
                If txtHostingFee.Text <> "" Then
                    dblHostFee = Double.Parse(txtHostingFee.Text)
                End If

                Dim objDesktopModules As New DesktopModuleController

                objDesktopModules.UpdatePortalModuleDefinition(intPortalId, Integer.Parse(Convert.ToString(grdModuleDefinitions.DataKeys(e.Item.ItemIndex))), chkSubscribed.Checked, dblHostFee)

                grdModuleDefinitions.EditItemIndex = -1
                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub grdModuleDefinitions_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdModuleDefinitions.ItemCreated
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim cmdEditModuleDefinitions As Control = e.Item.FindControl("cmdEditModuleDefinitions")

                If Not cmdEditModuleDefinitions Is Nothing Then
                    If CType(Context.User.Identity.Name, String) <> _portalSettings.SuperUserId Then
                        CType(cmdEditModuleDefinitions, ImageButton).Attributes.Add("onClick", "javascript: return confirm('If You Wish To Add Premium Modules To Your Portal, Please Consult Your Hosting Provider')")
                    End If
                End If

                Dim itemType As ListItemType
                itemType = CType(e.Item.ItemType, ListItemType)
                If (itemType = ListItemType.EditItem) Then
                    Dim chkCheckbox2 As WebControls.CheckBox
                    Dim txtHostingFee As WebControls.TextBox
                    Dim lblCheckBox2, lblHostingFee As WebControls.Label
                    chkCheckbox2 = CType(e.Item.FindControl("Checkbox2"), WebControls.CheckBox)
                    lblCheckBox2 = CType(e.Item.FindControl("lblCheckBox2"), WebControls.Label)
                    lblCheckBox2.Text = "<label class=""SubHead"" style=""display:none;"" for=""" & chkCheckbox2.ClientID.ToString & """>Subscribed</label>"
                    txtHostingFee = CType(e.Item.FindControl("txtHostingFee"), WebControls.TextBox)
                    lblHostingFee = CType(e.Item.FindControl("lblHostingFee"), WebControls.Label)
                    lblHostingFee.Text = "<label class=""SubHead"" style=""display:none;"" for=""" & txtHostingFee.ClientID.ToString & """>Hosting Fee</label>"
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Function IsSuperUser() As String
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                    Return "True"
                Else
                    Return "False"
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function FormatFee(ByVal objHostFee As Object) As String
            Try
                If Not IsDBNull(objHostFee) Then
                    Return Format(objHostFee, "#,##0.00")
                Else
                    Return "0"
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function FormatCurrency() As String
            Try
                Return lblHostCurrency.Text

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub cmdProcessor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdProcessor.Click
            Try
                Response.Redirect(AddHTTP(cboProcessor.SelectedItem.Value), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Function IsSubscribed(ByVal PortalModuleDefinitionId As Integer) As Boolean
            Try
                Return Null.IsNull(PortalModuleDefinitionId) = False

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

    End Class

End Namespace

