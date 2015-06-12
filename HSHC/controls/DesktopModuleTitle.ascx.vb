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

    Public MustInherit Class DesktopModuleTitle
        Inherits System.Web.UI.UserControl

        Protected WithEvents pnlModuleTitle As System.Web.UI.WebControls.Panel
        Protected WithEvents cmdEditModule As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdEditModuleImage As System.Web.UI.WebControls.Image
        Protected WithEvents cmdModuleUp As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdModuleDown As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdModuleLeft As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdModuleRight As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblModuleTitle As System.Web.UI.WebControls.Label
        Protected WithEvents cmdEditContent As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdEditOptions As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdEditOptionsImage As System.Web.UI.WebControls.Image
        Protected WithEvents cmdDisplayModule As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdHelpShow As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdHelpHide As System.Web.UI.WebControls.ImageButton
        Protected WithEvents rowHelp1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents rowHelp2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
        Protected WithEvents lblModuleContent As System.Web.UI.WebControls.Label

        Public DisplayTitle As [String] = Nothing
        Public EditText As [String] = Nothing
        Public EditURL As [String] = Nothing
        Public TitleVisible As [Boolean] = True
        Public DisplayOptions As [Boolean] = False

        Private tabId As Integer = 0

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

                tabId = _portalSettings.ActiveTab.TabId

                ' Obtain reference to parent portal module
                Dim portalModule As PortalModuleControl = CType(Me.Parent, PortalModuleControl)

                lblModuleTitle.Text = ""
                If Not IsNothing(DisplayTitle) Then
                    ' Display Custom Title
                    lblModuleTitle.Text = DisplayTitle
                End If

                ' Display the Module and Content Edit button 
                If Not IsNothing(portalModule.ModuleConfiguration) Then

                    ' Display Module Title
                    If lblModuleTitle.Text = "" Then
                        lblModuleTitle.Text = portalModule.ModuleConfiguration.ModuleTitle
                    End If

                    ' check if the Module Title is hidden 
                    If portalModule.ModuleConfiguration.ShowTitle = False And portalModule.ModuleConfiguration.PaneName <> "Edit" Then
                        pnlModuleTitle.Visible = False
                    End If
                    ' check if Personalization is allowed
                    If portalModule.ModuleConfiguration.Personalize = 2 Then
                        cmdDisplayModule.Enabled = False
                    End If

                    If portalModule.ModuleConfiguration.IconFile <> "" Then
                        cmdEditModuleImage.ImageUrl = _portalSettings.ActiveTab.SkinPath & portalModule.ModuleConfiguration.IconFile
                        cmdEditModuleImage.Visible = True
                        cmdEditModule.ToolTip = portalModule.ModuleConfiguration.ModuleTitle
                        cmdEditModuleImage.AlternateText = portalModule.ModuleConfiguration.ModuleTitle
                        cmdEditModule.Visible = True
                    ElseIf portalModule.ModuleConfiguration.IconFile <> "" Then
                        If portalModule.ModuleConfiguration.PaneName = "Edit" Or IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) = True Then
                            cmdEditModuleImage.ImageUrl = "~/images/" & portalModule.ModuleConfiguration.IconFile
                            cmdEditModule.ToolTip = portalModule.ModuleConfiguration.ModuleTitle
                            cmdEditModuleImage.AlternateText = portalModule.ModuleConfiguration.ModuleTitle
                            cmdEditModuleImage.Visible = True
                            cmdEditModule.Visible = True
                        End If
                    End If

                    Dim blnPreview As Boolean = False
                    If Not Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString) Is Nothing Then
                        blnPreview = Boolean.Parse(Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString).Value)
                    End If

                    If (blnPreview = False And (PortalSecurity.IsInRoles(portalModule.ModuleConfiguration.AuthorizedEditRoles) = True _
                        Or PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = True)) _
                    Or (portalModule.ModuleConfiguration.PaneName = "Edit" _
                        Or IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) = True) Then

                        If Not IsNothing(EditText) Then
                            pnlModuleTitle.Visible = True
                            cmdEditContent.Text = EditText
                            cmdEditContent.ToolTip = EditText
                            If Not IsNothing(EditURL) Then
                                cmdEditContent.NavigateUrl = EditURL & IIf(InStr(1, EditURL, "?") <> 0, "&", "?").ToString & "tabid=" & tabId & "&mid=" + portalModule.ModuleId.ToString & "&def=Edit"
                            Else
                                cmdEditContent.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & tabId & "&mid=" + portalModule.ModuleId.ToString & "&def=Edit"
                            End If
                            If DisplayOptions Then
                                cmdEditOptionsImage.ImageUrl = "~/images/view.gif"
                                cmdEditOptions.NavigateUrl = cmdEditContent.NavigateUrl & "&options=1"
                                cmdEditOptions.ToolTip = "Module Display Options"
                                cmdEditOptions.Visible = True
                                cmdEditOptionsImage.Visible = True
                                cmdEditOptionsImage.AlternateText = "Module Display Options"
                            End If
                        End If
                        cmdHelpShow.ImageUrl = "~/images/help.gif"
                        cmdHelpShow.ToolTip = "Show Module Info"
                        cmdHelpShow.AlternateText = "Show Module Info"
                        cmdHelpShow.Visible = True

                        cmdHelpHide.ImageUrl = "~/images/cancel.gif"
                        cmdHelpHide.ToolTip = "Hide Module Info"
                        cmdHelpHide.AlternateText = "Hide Module Info"
                        cmdHelpHide.Visible = False
                    End If

                    If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = True Or PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = True Then
                        If portalModule.ModuleConfiguration.PaneName <> "Edit" And IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) = False Then
                            If blnPreview = False Then
                                pnlModuleTitle.Visible = True

                                cmdEditModuleImage.ImageUrl = "~/images/edit.gif"
                                cmdEditModule.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & tabId & "&def=Module&ModuleId=" & portalModule.ModuleId.ToString
                                cmdEditModule.ToolTip = "Edit Module Settings"
                                cmdEditModuleImage.AlternateText = "Edit Module Settings"
                                cmdEditModuleImage.Visible = True
                                cmdEditModule.Visible = True

                                If portalModule.ModuleConfiguration.ModuleOrder > 1 Then
                                    cmdModuleUp.ImageUrl = "~/images/up.gif"
                                    cmdModuleUp.ToolTip = "Move Module Up"
                                    cmdModuleUp.AlternateText = "Move Module Up"
                                    cmdModuleUp.CommandArgument = portalModule.ModuleConfiguration.PaneName
                                    cmdModuleUp.CommandName = "up"
                                    cmdModuleUp.Visible = True
                                End If

                                If portalModule.ModuleConfiguration.ModuleOrder <> 0 Then
                                    cmdModuleDown.ImageUrl = "~/images/dn.gif"
                                    cmdModuleDown.ToolTip = "Move Module Down"
                                    cmdModuleDown.AlternateText = "Move Module Down"
                                    cmdModuleDown.CommandArgument = portalModule.ModuleConfiguration.PaneName
                                    cmdModuleDown.CommandName = "down"
                                    cmdModuleDown.Visible = True
                                End If

                                If LCase(portalModule.ModuleConfiguration.PaneName) <> "leftpane" Then
                                    cmdModuleLeft.ImageUrl = "~/images/lt.gif"
                                    cmdModuleLeft.ToolTip = "Move Module Left"
                                    cmdModuleLeft.AlternateText = "Move Module Left"
                                    cmdModuleLeft.CommandArgument = portalModule.ModuleConfiguration.PaneName
                                    cmdModuleLeft.CommandName = "left"
                                    cmdModuleLeft.Visible = True
                                End If

                                If LCase(portalModule.ModuleConfiguration.PaneName) <> "rightpane" Then
                                    cmdModuleRight.ImageUrl = "~/images/rt.gif"
                                    cmdModuleRight.ToolTip = "Move Module Right"
                                    cmdModuleRight.AlternateText = "Move Module Right"
                                    cmdModuleRight.CommandArgument = portalModule.ModuleConfiguration.PaneName
                                    cmdModuleRight.CommandName = "right"
                                    cmdModuleRight.Visible = True
                                End If
                            End If
                        End If
                    End If
                End If

                If Not Page.IsPostBack Then
                    If Not IsNothing(portalModule.ModuleConfiguration) Then
                        If portalModule.ModuleConfiguration.PaneName <> "Edit" And IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) = False Then
                            If cmdDisplayModule.Enabled Then
                                Dim pnlModuleContent As Panel = CType(Parent.FindControl("pnlModuleContent"), Panel)
                                If Not pnlModuleContent Is Nothing Then
                                    Dim objModuleVisible As HttpCookie = Request.Cookies("_Module" & portalModule.ModuleId.ToString & "_Visible")

                                    If Not objModuleVisible Is Nothing Then
                                        If objModuleVisible.Value = "true" Then
                                            pnlModuleContent.Visible = True
                                            cmdDisplayModule.ImageUrl = "~/images/minus.gif"
                                            cmdDisplayModule.ToolTip = "Minimize"
                                            cmdDisplayModule.AlternateText = "Minimize"
                                        Else
                                            pnlModuleContent.Visible = False
                                            cmdDisplayModule.ImageUrl = "~/images/plus.gif"
                                            cmdDisplayModule.ToolTip = "Maximize"
                                            cmdDisplayModule.AlternateText = "Maximize"
                                        End If
                                    Else
                                        If portalModule.ModuleConfiguration.Personalize = 1 Then
                                            pnlModuleContent.Visible = False
                                            cmdDisplayModule.ImageUrl = "~/images/plus.gif"
                                            cmdDisplayModule.ToolTip = "Maximize"
                                            cmdDisplayModule.AlternateText = "Maximize"
                                        Else
                                            pnlModuleContent.Visible = True
                                            cmdDisplayModule.ImageUrl = "~/images/minus.gif"
                                            cmdDisplayModule.ToolTip = "Minimize"
                                            cmdDisplayModule.AlternateText = "Minimize"
                                        End If
                                    End If

                                    cmdDisplayModule.Visible = True

                                End If
                            End If
                        End If
                    End If
                End If

                If Not TitleVisible Then
                    pnlModuleTitle.Visible = False
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDisplayModule_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdDisplayModule.Click
            Try
                ' Obtain reference to parent portal module
                Dim portalModule As PortalModuleControl = CType(Me.Parent, PortalModuleControl)

                Dim pnlModuleContent As Panel = CType(FindControlRecursive(CType(sender, Control), "pnlModuleContent"), Panel)

                If Not pnlModuleContent Is Nothing Then
                    Dim objModuleVisible As HttpCookie = New HttpCookie("_Module" & portalModule.ModuleId.ToString & "_Visible")

                    If pnlModuleContent.Visible = True Then
                        pnlModuleContent.Visible = False
                        cmdDisplayModule.ImageUrl = "~/images/plus.gif"
                        cmdDisplayModule.ToolTip = "Show Module Content"
                        cmdDisplayModule.AlternateText = "Show Module Content"
                        objModuleVisible.Value = "false"
                    Else
                        pnlModuleContent.Visible = True
                        cmdDisplayModule.ImageUrl = "~/images/minus.gif"
                        cmdDisplayModule.ToolTip = "Hide Module Content"
                        cmdDisplayModule.AlternateText = "Hide Module Content"
                        objModuleVisible.Value = "true"
                    End If

                    objModuleVisible.Expires = DateTime.MaxValue ' never expires
                    Response.AppendCookie(objModuleVisible)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub ModuleLeftRight_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdModuleLeft.Click, cmdModuleRight.Click
            Try
                Dim PaneName As String

                ' Obtain reference to parent portal module
                Dim portalModule As PortalModuleControl = CType(Me.Parent, PortalModuleControl)

                Select Case CType(sender, ImageButton).CommandName
                    Case "left"
                        Select Case CType(sender, ImageButton).CommandArgument.ToLower
                            Case "contentpane"
                                PaneName = "LeftPane"
                            Case "rightpane"
                                PaneName = "ContentPane"
                        End Select
                    Case "right"
                        Select Case CType(sender, ImageButton).CommandArgument.ToLower
                            Case "leftpane"
                                PaneName = "ContentPane"
                            Case "contentpane"
                                PaneName = "RightPane"
                        End Select
                End Select

                Dim objModules As New ModuleController

                objModules.UpdateModuleOrder(portalModule.ModuleConfiguration.ModuleId, -1, PaneName)
                objModules.UpdateTabModuleOrder(tabId)

                ' Redirect to the same page to pick up changes
                Response.Redirect(Request.RawUrl, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub ModuleUpDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdModuleUp.Click, cmdModuleDown.Click
            Try
                ' Obtain reference to parent portal module
                Dim portalModule As PortalModuleControl = CType(Me.Parent, PortalModuleControl)

                Dim objModules As New ModuleController

                Select Case CType(sender, ImageButton).CommandName
                    Case "up"
                        objModules.UpdateModuleOrder(portalModule.ModuleConfiguration.ModuleId, portalModule.ModuleConfiguration.ModuleOrder - 3, CType(sender, ImageButton).CommandArgument)
                    Case "down"
                        objModules.UpdateModuleOrder(portalModule.ModuleConfiguration.ModuleId, portalModule.ModuleConfiguration.ModuleOrder + 3, CType(sender, ImageButton).CommandArgument)
                End Select

                objModules.UpdateTabModuleOrder(tabId)

                ' Redirect to the same page to pick up changes
                Response.Redirect(Request.RawUrl, True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdHelpShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdHelpShow.Click

        End Sub

        Private Sub cmdHelpHide_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdHelpHide.Click

        End Sub

    End Class

End Namespace