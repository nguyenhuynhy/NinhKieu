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

    Public Class ModuleSettingsPage
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboIcon As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents chkShowTitle As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkAllTabs As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cboPersonalize As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCacheTime As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkAuthViewRoles As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents chkAuthEditRoles As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents cboAlign As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtColor As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBorder As System.Web.UI.WebControls.TextBox
        Protected WithEvents ctlModuleContainer As SkinControl
        Protected WithEvents cboTab As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Private Shadows ModuleId As Integer = -1

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
        ' to populate the module settings on the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objModules As New ModuleController

                ' get ModuleId
                If Not (Request.Params("ModuleId") Is Nothing) Then
                    ModuleId = Int32.Parse(Request.Params("ModuleId"))
                End If

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' Verify that the current user has access to edit this module
                If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    ' load the list of files found in the upload directory
                    Dim LogoFileList As ArrayList = GetFileList(PortalId, glbImageFileTypes)
                    cboIcon.DataSource = LogoFileList
                    cboIcon.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    cboTab.DataSource = GetPortalTabs(_portalSettings.DesktopTabs, , True)
                    cboTab.DataBind()

                    ' tab administrators can only manage their own tab
                    If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = False Then
                        cboTab.Enabled = False
                    End If

                    If ModuleId <> -1 Then
                        BindData()
                    Else
                        chkShowTitle.Checked = True
                        cboPersonalize.SelectedIndex = 0 ' maximized
                        chkAllTabs.Checked = False
                        cmdDelete.Visible = False
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '*******************************************************
        '
        ' The ApplyChanges_Click server event handler on this page is used
        ' to save the module settings into the portal configuration system
        '
        '*******************************************************

        Private Sub ApplyChanges_Click(ByVal Sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try

                Dim objModules As New ModuleController

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim item As ListItem

                ' Construct Authorized View Roles 
                Dim viewRoles As String = ""
                For Each item In chkAuthViewRoles.Items
                    If item.Selected Then
                        viewRoles = viewRoles & item.Value & ";"
                    End If
                Next item
                If viewRoles <> "" Then
                    If InStr(1, viewRoles, _portalSettings.AdministratorRoleId.ToString & ";") = 0 Then
                        viewRoles += _portalSettings.AdministratorRoleId.ToString & ";"
                    End If
                End If

                ' Construct Authorized Edit Roles
                Dim editRoles As String = ""
                For Each item In chkAuthEditRoles.Items
                    If item.Selected = True Or item.Value = _portalSettings.AdministratorRoleId.ToString Then
                        editRoles = editRoles & item.Value & ";"
                    End If
                Next item

                Dim strIcon As String = ""
                If Not cboIcon.SelectedItem Is Nothing Then
                    strIcon = cboIcon.SelectedItem.Value
                End If

                ' update module
                Dim objModule As ModuleInfo = objModules.GetModule(ModuleId)

                objModule.ModuleID = ModuleId
                objModule.ModuleTitle = txtTitle.Text
                objModule.Alignment = cboAlign.SelectedItem.Value
                objModule.Color = txtColor.Text
                objModule.Border = txtBorder.Text
                objModule.IconFile = strIcon
                objModule.CacheTime = Int32.Parse(txtCacheTime.Text)
                objModule.AuthorizedViewRoles = viewRoles
                objModule.AuthorizedEditRoles = editRoles
                objModule.TabID = Int32.Parse(cboTab.SelectedItem.Value)
                If objModule.AllTabs <> chkAllTabs.Checked Then
                    ' clear tab cache for all portals
                    DataCache.ClearCoreCache(CoreCacheType.Portal, PortalId, True)

                    If chkAllTabs.Checked = False Then
                        ' move module to bottom of pane in tab
                        objModule.ModuleOrder = -1
                    End If
                End If
                objModule.AllTabs = chkAllTabs.Checked
                objModule.ShowTitle = chkShowTitle.Checked
                objModule.Personalize = Int32.Parse(cboPersonalize.SelectedItem.Value)
                objModule.IsDeleted = False
                If TabId <> Int32.Parse(cboTab.SelectedItem.Value) Then
                    objModule.ModuleOrder = -1
                End If

                objModules.UpdateModule(objModule)

                ' if module was moved to another tab
                If TabId <> Int32.Parse(cboTab.SelectedItem.Value) Then
                    ' update tab module order for source tab
                    objModules.UpdateTabModuleOrder(TabId)
                    ' update tab module order for destination tab
                    objModules.UpdateTabModuleOrder(objModule.TabID)
                End If

                Dim objSkins As New SkinController
                objSkins.SetSkin(SkinInfo.RootContainer, Null.NullInteger, Null.NullInteger, ModuleId, False, ctlModuleContainer.SkinType, ctlModuleContainer.SkinName, ctlModuleContainer.SkinSrc)

                ' Navigate back to admin page
                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '*******************************************************
        '
        ' The BindData helper method is used to populate a asp:datalist
        ' server control with the current "edit access" permissions
        ' set within the portal configuration system
        '
        '*******************************************************

        Sub BindData()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim objModules As New ModuleController
            Dim objUser As New RoleController

            ' Get a list of roles to display as Viewable
            Dim ViewRoles As ArrayList = objUser.GetPortalRoles(PortalId)

            ' Get a list roles to display as Editable
            Dim EditRoles As ArrayList = objUser.GetPortalRoles(PortalId)

            Dim Role As RoleInfo

            ' Clear existing items in checkboxlist
            chkAuthViewRoles.Items.Clear()

            ' Add an entry of All Users for the View roles
            Dim allViewItems As New ListItem
            allViewItems.Text = "All Users"
            allViewItems.Value = glbRoleAllUsers

            ' Add an entry of Unauthenticated Users for the View roles
            Dim unauthViewItems As New ListItem
            unauthViewItems.Text = "Unauthenticated Users"
            unauthViewItems.Value = glbRoleUnauthUser

            ' Clear existing items in checkboxlist
            chkAuthEditRoles.Items.Clear()

            ' Add an entry of All Users for the Edit roles
            Dim allEditItems As New ListItem
            allEditItems.Text = "All Users"
            allEditItems.Value = glbRoleAllUsers

            Dim objModule As ModuleInfo = objModules.GetModule(ModuleId)

            If Not objModule Is Nothing Then
                txtTitle.Text = objModule.ModuleTitle
                If cboIcon.Items.Contains(New ListItem(objModule.IconFile)) Then
                    cboIcon.Items.FindByText(objModule.IconFile).Selected = True
                End If

                chkShowTitle.Checked = objModule.ShowTitle
                chkAllTabs.Checked = objModule.AllTabs

                txtCacheTime.Text = objModule.CacheTime.ToString
                cboPersonalize.SelectedIndex = objModule.Personalize
                If Not cboTab.Items.FindByValue(objModule.TabID.ToString) Is Nothing Then
                    cboTab.Items.FindByValue(objModule.TabID.ToString).Selected = True
                End If

                If Convert.ToBoolean(InStr(1, Convert.ToString(IIf(IsDBNull(objModule.AuthorizedViewRoles), "", objModule.AuthorizedViewRoles)), allViewItems.Value & ";")) Then
                    allViewItems.Selected = True
                End If

                chkAuthViewRoles.Items.Add(allViewItems)
                If Convert.ToBoolean(InStr(1, Convert.ToString(IIf(IsDBNull(objModule.AuthorizedViewRoles), "", objModule.AuthorizedViewRoles)), unauthViewItems.Value & ";")) Then
                    unauthViewItems.Selected = True
                End If
                chkAuthViewRoles.Items.Add(unauthViewItems)
                If Not ViewRoles Is Nothing Then
                    For Each Role In ViewRoles
                        Dim item As New ListItem
                        item.Text = CType(Role.RoleName, String)
                        item.Value = Convert.ToString(Role.RoleID)
                        If Convert.ToBoolean(InStr(objModule.AuthorizedViewRoles, Convert.ToString(Role.RoleID))) Then
                            item.Selected = True
                        End If
                        chkAuthViewRoles.Items.Add(item)
                    Next
                End If

                If Convert.ToBoolean(InStr(1, Convert.ToString(IIf(IsDBNull(objModule.AuthorizedEditRoles), "", objModule.AuthorizedEditRoles)), allEditItems.Value & ";")) Then
                    allEditItems.Selected = True
                End If

                chkAuthEditRoles.Items.Add(allEditItems)
                If Not EditRoles Is Nothing Then
                    For Each Role In EditRoles
                        Dim item As New ListItem
                        item.Text = CType(Role.RoleName, String)
                        item.Value = Convert.ToString(Role.RoleID)
                        If Convert.ToBoolean(InStr(objModule.AuthorizedEditRoles, Convert.ToString(Role.RoleID))) Then
                            item.Selected = True
                        End If
                        chkAuthEditRoles.Items.Add(item)
                    Next
                End If

                If objModule.Alignment <> "" Then
                    cboAlign.Items.FindByValue(objModule.Alignment).Selected = True
                End If
                txtColor.Text = objModule.Color
                txtBorder.Text = objModule.Border
            End If

            Dim objSkins As New SkinController
            Dim objSkin As SkinInfo

            ctlModuleContainer.Width = "300px"
            ctlModuleContainer.SkinRoot = SkinInfo.RootContainer
            objSkin = objSkins.GetSkin(SkinInfo.RootContainer, PortalId, Null.NullInteger, ModuleId, False)
            If Not objSkin Is Nothing Then
                If objSkin.ModuleId = ModuleId Then
                    ctlModuleContainer.SkinType = objSkin.SkinType
                    ctlModuleContainer.SkinName = objSkin.SkinName
                    ctlModuleContainer.SkinSrc = objSkin.SkinSrc
                End If
            End If

        End Sub

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try

                Dim objModules As New ModuleController

                Dim objModule As ModuleInfo = objModules.GetModule(ModuleId)
                If Not objModule Is Nothing Then
                    objModule.IsDeleted = True
                    objModules.UpdateModule(objModule)
                End If

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
