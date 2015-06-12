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

Namespace PortalQH.Skins

    Public Class Admin

        Inherits SkinObject

        'TODO: This will be defined by Web.config and is currently just a placeholder
        Protected WithEvents dnnActions As Containers.LinkActions
        Protected WithEvents cmdHelpShow As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdHelpHide As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cboDesktopModules As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboPanes As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboAlign As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdAdd As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkContent As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkPreview As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
        Protected WithEvents CellBefore As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents CellAfter As System.Web.UI.HtmlControls.HtmlTableCell

#Region " Web Form Designer Generated Code "


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()


            'TODO: This will be defined by Web.config and is currently just a placeholder
            dnnActions = New Containers.LinkActions
            dnnActions.ItemSeparator = "&nbsp;&nbsp;"


            If TypeOf dnnActions Is Containers.LinkActions Then
                CellAfter.Controls.Add(dnnActions)
            Else
                CellBefore.Controls.Add(dnnActions)
            End If

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            If Not IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) Then
                dnnActions.AddAction("Edit", "", "", "edit.gif", "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&def=Tab&action=edit", Secure:=SecurityAccessLevel.Admin, Visible:=True)
            End If
            dnnActions.AddAction("Add", "", "", "add.gif", "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&def=Tab", Secure:=SecurityAccessLevel.Admin, Visible:=True)
            dnnActions.ActionListType = Containers.ActionType.TabActions
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
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If Not Page.IsPostBack Then
                    If (PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = True Or PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = True) Then
                        cmdHelpShow.ImageUrl = "~/images/help.gif"
                        cmdHelpShow.ToolTip = "Show Module Info"
                        cmdHelpShow.Visible = True

                        cmdHelpHide.ImageUrl = "~/images/cancel.gif"
                        cmdHelpHide.ToolTip = "Hide Module Info"
                        cmdHelpHide.Visible = False

                        Dim objDesktopModules As New DesktopModuleController
                        cboDesktopModules.DataSource = objDesktopModules.GetPortalDesktopModules(_portalSettings.PortalId)
                        cboDesktopModules.DataBind()

                        Dim intItem As Integer
                        For intItem = 0 To _portalSettings.Panes.Count - 1
                            cboPanes.Items.Add(Convert.ToString(_portalSettings.Panes(intItem)))
                        Next intItem
                        cboPanes.Items.FindByValue(glbDefaultPane).Selected = True

                        cboAlign.SelectedIndex = 0

                        chkContent.Checked = True
                        If Not Request.Cookies("_Tab_Admin_Content" & _portalSettings.PortalId.ToString) Is Nothing Then
                            chkContent.Checked = Boolean.Parse(Request.Cookies("_Tab_Admin_Content" & _portalSettings.PortalId.ToString).Value)
                        End If

                        chkPreview.Checked = False
                        If Not Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString) Is Nothing Then
                            chkPreview.Checked = Boolean.Parse(Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString).Value)
                        End If

                    Else
                        Me.Visible = False
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Try
                ' Obtain portalId from Current Context
                Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

                Dim strEditRoles As String = _portalSettings.ActiveTab.AdministratorRoles
                If InStr(1, strEditRoles, _portalSettings.AdministratorRoleId.ToString & ";") = 0 Then
                    strEditRoles += _portalSettings.AdministratorRoleId.ToString & ";"
                End If

                ' save to database
                Dim objModuleDefinitions As New ModuleDefinitionController
                Dim objModuleDefinition As ModuleDefinitionInfo

                Dim intIndex As Integer
                Dim arrModuleDefinitions As ArrayList = objModuleDefinitions.GetModuleDefinitions(Integer.Parse(cboDesktopModules.SelectedItem.Value))
                For intIndex = 0 To arrModuleDefinitions.Count - 1
                    objModuleDefinition = CType(arrModuleDefinitions(intIndex), ModuleDefinitionInfo)

                    Dim objModule As New ModuleInfo
                    objModule = CType(CBO.InitializeObject(objModule, GetType(ModuleInfo)), ModuleInfo)

                    objModule.TabID = _portalSettings.ActiveTab.TabId
                    objModule.ModuleOrder = -1
                    objModule.ModuleTitle = objModuleDefinition.FriendlyName
                    objModule.PaneName = cboPanes.SelectedItem.Text
                    objModule.ModuleDefID = objModuleDefinition.ModuleDefID
                    objModule.CacheTime = 0
                    objModule.AuthorizedEditRoles = strEditRoles
                    objModule.AllTabs = False
                    objModule.ShowTitle = True
                    objModule.Personalize = 0
                    objModule.Alignment = cboAlign.SelectedItem.Value

                    Dim objModules As New ModuleController
                    objModules.AddModule(objModule)
                Next

                ' Redirect to the same page to pick up changes
                Response.Redirect(Request.RawUrl, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdHelpHide_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdHelpHide.Click
            Try
                lblDescription.Text = ""

                cmdHelpShow.Visible = True
                cmdHelpHide.Visible = False

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdHelpShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdHelpShow.Click
            Try
                Dim objDesktopModules As New DesktopModuleController
                Dim objDesktopModule As DesktopModuleInfo

                objDesktopModule = objDesktopModules.GetDesktopModule(Int32.Parse(cboDesktopModules.SelectedItem.Value))
                If Not objDesktopModule Is Nothing Then
                    lblDescription.Text = "<br>" & objDesktopModule.Description & "<br>"
                End If

                cmdHelpShow.Visible = False
                cmdHelpHide.Visible = True

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkContent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkContent.CheckedChanged
            Try

                ' Obtain portalId from Current Context
                Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

                Dim objContent As HttpCookie

                If Request.Cookies("_Tab_Admin_Content" & _portalSettings.PortalId.ToString) Is Nothing Then
                    objContent = New HttpCookie("_Tab_Admin_Content" & _portalSettings.PortalId.ToString)
                    objContent.Expires = DateTime.MaxValue ' never expires
                    Response.AppendCookie(objContent)
                End If

                objContent = Request.Cookies("_Tab_Admin_Content" & _portalSettings.PortalId.ToString)
                objContent.Value = chkContent.Checked.ToString
                Response.SetCookie(objContent)

                Response.Redirect(Request.RawUrl, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkPreview_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPreview.CheckedChanged
            Try

                ' Obtain portalId from Current Context
                Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

                Dim objPreview As HttpCookie

                If Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString) Is Nothing Then
                    objPreview = New HttpCookie("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString)
                    objPreview.Expires = DateTime.MaxValue ' never expires
                    Response.AppendCookie(objPreview)
                End If

                objPreview = Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString)
                objPreview.Value = chkPreview.Checked.ToString
                Response.SetCookie(objPreview)

                Response.Redirect(Request.RawUrl, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
