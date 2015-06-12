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

    Public Class ManageTabs
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtTabName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valTabName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKeyWords As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdGoogle As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cboIcon As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ctlSkin As SkinControl
        Protected WithEvents ctlContainer As SkinControl
        Protected WithEvents rowTemplate As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents cboTemplate As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboTab As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkHidden As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkDisableLink As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkAdminRoles As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents chkAuthRoles As System.Web.UI.WebControls.CheckBoxList

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Private strAction As String = ""

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
        ' to populate a tab's layout settings on the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objModules As New ModuleController

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' Verify that the current user has access to edit this module
                If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

                If Not (Request.Params("action") Is Nothing) Then
                    strAction = Request.Params("action")
                End If

                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    ' load the list of files found in the upload directory
                    Dim LogoFileList As ArrayList = GetFileList(PortalId, glbImageFileTypes)
                    cboIcon.DataSource = LogoFileList
                    cboIcon.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    cboTab.DataSource = GetPortalTabs(_portalSettings.DesktopTabs, True)
                    cboTab.DataBind()

                    cboTemplate.DataSource = GetPortalTabs(_portalSettings.DesktopTabs, True)
                    cboTemplate.DataBind()

                    ' tab administrators can only manage their own tab
                    If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = False Then
                        cboTab.Enabled = False
                    End If

                    ctlSkin.Width = "300px"
                    ctlSkin.SkinRoot = SkinInfo.RootSkin

                    ctlContainer.Width = "300px"
                    ctlContainer.SkinRoot = SkinInfo.RootContainer

                    If strAction = "" Then
                        InitializeTab()
                        cmdDelete.Visible = False
                        cmdGoogle.Visible = False
                    Else
                        rowTemplate.Visible = False
                        BindData()
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '*******************************************************
        '
        ' The cmdCancel_Click() handler cancels operation and redirects
        ' user to admin tab of their portal.
        '
        '*******************************************************

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        Sub InitializeTab()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' Populate Tab Names, etc.
            txtTabName.Text = ""
            txtTitle.Text = ""
            txtDescription.Text = ""
            txtKeyWords.Text = ""

            If _portalSettings.ActiveTab.ParentId <> _portalSettings.AdminTabId Then
                If Not cboTab.Items.FindByValue(TabId.ToString) Is Nothing Then
                    cboTab.Items.FindByValue(TabId.ToString).Selected = True
                End If
            End If

            ' hide the upload new file link until the tab has been saved
            cmdUpload.Visible = False

            chkHidden.Checked = False
            chkDisableLink.Checked = False

            ' Populate checkbox list with all security roles for this portal
            ' and "check" the ones already configured for this tab
            Dim objRoles As New RoleController
            Dim Arr As ArrayList = objRoles.GetPortalRoles(PortalId)

            ' Clear existing items in checkboxlist
            chkAuthRoles.Items.Clear()

            Dim allAuthItem As New ListItem
            allAuthItem.Text = "All Users"
            allAuthItem.Value = glbRoleAllUsers
            allAuthItem.Selected = True
            chkAuthRoles.Items.Add(allAuthItem)

            Dim unauthItem As New ListItem
            unauthItem.Text = "Unauthenticated Users"
            unauthItem.Value = glbRoleUnauthUser
            chkAuthRoles.Items.Add(unauthItem)

            Dim allAdminItem As New ListItem
            allAdminItem.Text = "All Users"
            allAdminItem.Value = glbRoleAllUsers
            chkAdminRoles.Items.Add(allAdminItem)

            Dim i As Integer
            For i = 0 To Arr.Count - 1
                Dim authItem As New ListItem
                Dim objRole As RoleInfo = CType(Arr(i), RoleInfo)
                authItem.Text = objRole.RoleName
                authItem.Value = objRole.RoleID.ToString
                If authItem.Value = _portalSettings.AdministratorRoleId.ToString Then
                    authItem.Selected = True
                End If
                If Convert.ToBoolean(InStr(1, _portalSettings.ActiveTab.AdministratorRoles.ToString, authItem.Value)) Then
                    authItem.Selected = True
                End If
                chkAuthRoles.Items.Add(authItem)

                Dim adminItem As New ListItem
                adminItem.Text = objRole.RoleName
                adminItem.Value = objRole.RoleID.ToString
                If adminItem.Value = _portalSettings.AdministratorRoleId.ToString Then
                    adminItem.Selected = True
                End If
                If Convert.ToBoolean(InStr(1, _portalSettings.ActiveTab.AdministratorRoles.ToString, adminItem.Value)) Then
                    adminItem.Selected = True
                End If
                chkAdminRoles.Items.Add(adminItem)
            Next

        End Sub

        Private Sub cmdUpdate_Click(ByVal Sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                Dim intTabId As Integer = SaveTabData(strAction)

                Response.Redirect("~/DesktopDefault.aspx?tabid=" & intTabId.ToString, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal Sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try

                Select Case TabId
                    Case PortalSettings.AdminTabId, PortalSettings.HomeTabId, PortalSettings.LoginTabId, PortalSettings.UserTabId
                        ' can not delete 
                    Case Else
                        Dim objTabs As New TabController

                        Dim objTab As TabInfo = objTabs.GetTab(TabId)
                        If Not objTab Is Nothing Then
                            objTab.IsDeleted = True
                            objTabs.UpdateTab(objTab)
                        End If

                        Response.Redirect(GetPortalDomainName(PortalAlias, Request), True)
                End Select

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '*******************************************************
        '
        ' The SaveTabData helper method is used to persist the
        ' current tab settings to the database.
        '
        '*******************************************************

        Function SaveTabData(ByVal strAction As String) As Integer

            ' Construct AdministratorRoles String
            Dim strAdministratorRoles As String = ""

            Dim item As ListItem

            For Each item In chkAdminRoles.Items
                ' admins always have access to all tabs
                If item.Selected = True Or item.Value = PortalSettings.AdministratorRoleId.ToString Or (PortalSecurity.IsInRole(PortalSettings.AdministratorRoleId.ToString) = False And InStr(1, PortalSettings.ActiveTab.AdministratorRoles.ToString, item.Value) <> 0) Then
                    strAdministratorRoles += item.Value & ";"
                End If
            Next item

            ' Construct AuthorizedRoles String
            Dim strAuthorizedRoles As String = ""

            For Each item In chkAuthRoles.Items
                ' admins always have access to all tabs
                If item.Selected = True Or item.Value = PortalSettings.AdministratorRoleId.ToString Or (PortalSecurity.IsInRole(PortalSettings.AdministratorRoleId.ToString) = False And InStr(1, PortalSettings.ActiveTab.AdministratorRoles.ToString, item.Value) <> 0) Then
                    strAuthorizedRoles += item.Value & ";"
                End If
            Next item

            Dim strIcon As String = ""
            If Not cboIcon.SelectedItem Is Nothing Then
                strIcon = cboIcon.SelectedItem.Value
            End If

            Dim objTabs As New TabController

            Dim objTab As New TabInfo
            objTab = CType(CBO.InitializeObject(objTab, GetType(TabInfo)), TabInfo)

            objTab.TabID = TabId
            objTab.PortalID = PortalId
            objTab.TabName = txtTabName.Text
            objTab.Title = txtTitle.Text
            objTab.Description = txtDescription.Text
            objTab.KeyWords = txtKeyWords.Text
            objTab.AuthorizedRoles = strAuthorizedRoles
            objTab.IsVisible = (Not chkHidden.Checked)
            objTab.DisableLink = chkDisableLink.Checked
            objTab.ParentId = Int32.Parse(cboTab.SelectedItem.Value)
            objTab.IconFile = strIcon
            objTab.AdministratorRoles = strAdministratorRoles
            objTab.IsDeleted = False

            If strAction = "edit" Then

                ' trap circular tab reference
                If objTab.TabID <> Int32.Parse(cboTab.SelectedItem.Value) Then
                    objTabs.UpdateTab(objTab)
                End If

            Else ' add

                objTab.TabID = objTabs.AddTab(objTab)

                If Int32.Parse(cboTemplate.SelectedItem.Value) <> -1 Then
                    ' copy all modules to new tab
                    objTabs.CopyTab(Int32.Parse(cboTemplate.SelectedItem.Value), objTab.TabID)
                End If
            End If

            Dim objSkins As New SkinController
            objSkins.SetSkin(SkinInfo.RootSkin, Null.NullInteger, objTab.TabID, Null.NullInteger, False, ctlSkin.SkinType, ctlSkin.SkinName, ctlSkin.SkinSrc)
            objSkins.SetSkin(SkinInfo.RootContainer, Null.NullInteger, objTab.TabID, Null.NullInteger, False, ctlContainer.SkinType, ctlContainer.SkinName, ctlContainer.SkinSrc)

            Return objTab.TabID

        End Function

        '*******************************************************
        '
        ' The BindData helper method is used to update the tab's
        ' layout panes with the current configuration information
        '
        '*******************************************************
        Sub BindData()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

            Dim tab As TabSettings = _portalSettings.ActiveTab

            ' Populate Tab Names, etc.
            txtTabName.Text = tab.TabName
            txtTitle.Text = tab.Title
            txtDescription.Text = tab.Description
            txtKeyWords.Text = tab.KeyWords
            If cboIcon.Items.Contains(New ListItem(tab.IconFile)) Then
                cboIcon.Items.FindByText(tab.IconFile).Selected = True
            End If

            cboTab.Items.FindByValue(tab.ParentId.ToString).Selected = True
            chkHidden.Checked = (Not tab.IsVisible)
            chkDisableLink.Checked = tab.DisableLink

            Dim objRoles As New RoleController
            Dim Arr As ArrayList = objRoles.GetPortalRoles(PortalId)

            ' Populate AuthorizedRoles, AdministratorRoles
            chkAuthRoles.Items.Clear()
            chkAdminRoles.Items.Clear()

            Dim allAuthItem As New ListItem
            allAuthItem.Text = "All Users"
            allAuthItem.Value = glbRoleAllUsers
            If tab.AuthorizedRoles.LastIndexOf(allAuthItem.Value & ";") > -1 Then
                allAuthItem.Selected = True
            End If
            chkAuthRoles.Items.Add(allAuthItem)

            Dim unauthItem As New ListItem
            unauthItem.Text = "Unauthenticated Users"
            unauthItem.Value = glbRoleUnauthUser
            If tab.AuthorizedRoles.LastIndexOf(unauthItem.Value & ";") > -1 Then
                unauthItem.Selected = True
            End If
            chkAuthRoles.Items.Add(unauthItem)


            Dim allAdminItem As New ListItem
            allAdminItem.Text = "All Users"
            allAdminItem.Value = glbRoleAllUsers
            If tab.AdministratorRoles.LastIndexOf(allAdminItem.Value & ";") > -1 Then
                allAdminItem.Selected = True
            End If
            chkAdminRoles.Items.Add(allAdminItem)

            Dim i As Integer
            For i = 0 To Arr.Count - 1
                Dim authItem As New ListItem
                Dim objRole As RoleInfo = CType(Arr(i), RoleInfo)
                authItem.Text = objRole.RoleName
                authItem.Value = objRole.RoleID.ToString
                If tab.AuthorizedRoles.LastIndexOf(authItem.Value & ";") > -1 Then
                    authItem.Selected = True
                End If
                chkAuthRoles.Items.Add(authItem)

                Dim adminItem As New ListItem
                adminItem.Text = objRole.RoleName
                adminItem.Value = objRole.RoleID.ToString
                If tab.AdministratorRoles.LastIndexOf(adminItem.Value & ";") > -1 Then
                    adminItem.Selected = True
                End If
                chkAdminRoles.Items.Add(adminItem)
            Next

            Dim objSkins As New SkinController
            Dim objSkin As SkinInfo

            objSkin = objSkins.GetSkin(SkinInfo.RootSkin, PortalId, tab.TabId, Null.NullInteger, False)
            If Not objSkin Is Nothing Then
                If objSkin.TabId = tab.TabId Then
                    ctlSkin.SkinType = objSkin.SkinType
                    ctlSkin.SkinName = objSkin.SkinName
                    ctlSkin.SkinSrc = objSkin.SkinSrc
                End If
            End If

            objSkin = objSkins.GetSkin(SkinInfo.RootContainer, PortalId, tab.TabId, Null.NullInteger, False)
            If Not objSkin Is Nothing Then
                If objSkin.TabId = tab.TabId Then
                    ctlContainer.SkinType = objSkin.SkinType
                    ctlContainer.SkinName = objSkin.SkinName
                    ctlContainer.SkinSrc = objSkin.SkinSrc
                End If
            End If

        End Sub

        Private Sub cmdGoogle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGoogle.Click

            Try
                Dim strURL As String = ""
                Dim strComments As String = ""

                strComments += txtTitle.Text
                If txtDescription.Text <> "" Then
                    strComments += " " & txtDescription.Text
                End If
                If txtKeyWords.Text <> "" Then
                    strComments += " " & txtKeyWords.Text
                End If

                strURL += "http://www.google.com/addurl?q=" & HTTPPOSTEncode(AddHTTP(GetDomainName(Request)) & "/desktopdefault.aspx?tabid=" & TabId.ToString)
                strURL += "&dq=" & HTTPPOSTEncode(strComments)
                strURL += "&submit=Add+URL"

                Response.Redirect(strURL, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

    End Class

End Namespace
