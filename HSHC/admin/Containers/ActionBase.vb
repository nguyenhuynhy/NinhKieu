'
' Copyright (c) 2003-2004
' by Joe Brinkman ( joe.brinkman@tag-software.net ) of TAG Software, Inc. ( http://www.tag-software.net )
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

Imports System.Diagnostics
Imports Solpart.WebControls

Namespace PortalQH.Containers

    Public Enum ActionType
        TabActions
        ModuleActions
    End Enum

    Public Class ActionBase
        Inherits SkinObject

        Protected _menuActions As ModuleActionCollection
        Protected _menuActionRoot As ModuleAction

        Protected _portalModule As PortalModuleControl

        Protected _tabPreview As Boolean = False
        Protected _editMode As Boolean = False
        Protected _adminModule As Boolean = False
        Protected _adminControl As Boolean = False
        Protected _actionListType As ActionType = ActionType.ModuleActions
        Protected _associatedModuleSettings As ModuleSettings


        Protected _supportsIcons As Boolean = True


        Public Const cMenuBreak As Integer = -1
        Public Const cMenuModSettings As Integer = 10
        Public Const cMenuDelete As Integer = 11
        Public Const cMenuClearCache As Integer = 12
        Public Const cMenuMoveUp As Integer = 13
        Public Const cMenuMoveDown As Integer = 14
        Public Const cMenuHelp As Integer = 15
        Public Const cMenuDocumentation As Integer = 16

        Public Const cMenuMovePaneRoot As Integer = 100
        Public Const cMenuActionRoot As Integer = 200

        Public Event Action As ActionEventHandler

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
            _portalModule = Container.GetPortalModuleControl(Me)

            If Not Request.Cookies("_Tab_Admin_Preview" & _portalModule.PortalSettings.PortalId.ToString) Is Nothing Then
                _tabPreview = Boolean.Parse(Request.Cookies("_Tab_Admin_Preview" & _portalModule.PortalSettings.PortalId.ToString).Value)
            End If

            _adminControl = IsAdminControl()

            If Not _portalModule.ModuleConfiguration Is Nothing Then
                _editMode = PortalSecurity.IsInRoles(_portalModule.PortalSettings.AdministratorRoleId.ToString) Or PortalSecurity.IsInRoles(_portalModule.PortalSettings.ActiveTab.AdministratorRoles.ToString)
                _adminModule = _portalModule.ModuleConfiguration.IsAdmin
            End If
        End Sub

        Protected Overridable Sub OnAction(ByVal e As ActionEventArgs)
            RaiseEvent Action(Me, e)
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                _menuActionRoot = New ModuleAction(1, " ", "", Icon:="action.gif")

                ' module actions
                Dim userAction As ModuleAction
                Dim intItem As Integer
                For intItem = 0 To MenuActions.Count - 1
                    userAction = MenuActions(intItem)
                    _menuActionRoot.Actions.Insert(0, New ModuleAction(cMenuActionRoot + intItem, userAction.Title, userAction.CommandName, userAction.CommandArgument, userAction.Icon, userAction.Url, userAction.UseActionEvent, userAction.Secure, userAction.Visible))
                Next intItem

                ' Since the Tab Edit Menus share the action menu structure
                ' we must distinguish ActionTypes to prevent adding items
                ' to the Tab edit menu.
                If ActionListType = ActionType.ModuleActions Then
                    If _editMode = True And _adminModule = False And _adminControl = False Then

                        ' module help
                        If _portalModule.HelpURL <> "" Then
                            _menuActionRoot.Actions.Add(cMenuHelp, "Online Help", "", "", "help.gif", AddHTTP(_portalModule.HelpURL), UseActionEvent:=True, Secure:=SecurityAccessLevel.Edit, Visible:=True, NewWindow:=True)
                        End If
                        If _portalModule.HelpFile <> "" Then
                            _menuActionRoot.Actions.Add(cMenuDocumentation, "Documentation", "", "", "help.gif", _portalModule.TemplateSourceDirectory & "/" & _portalModule.HelpFile, Secure:=SecurityAccessLevel.Edit, Visible:=True, NewWindow:=True)
                        End If

                        ' module settings
                        _menuActionRoot.Actions.Add(cMenuBreak, "~", "")
                        _menuActionRoot.Actions.Add(cMenuModSettings, "Module Settings", "Settings", "", "edit.gif", ApplicationURL() & "&def=Module&ModuleId=" & _portalModule.ModuleId.ToString, secure:=SecurityAccessLevel.Admin, Visible:=True)
                        _menuActionRoot.Actions.Add(cMenuDelete, "Delete Module", "Delete", _portalModule.ModuleConfiguration.ModuleId.ToString, "delete.gif", secure:=SecurityAccessLevel.Admin, Visible:=True)
                        If _portalModule.ModuleConfiguration.CacheTime <> 0 Then
                            _menuActionRoot.Actions.Add(cMenuClearCache, "Clear Cache", "Clear", _portalModule.ModuleConfiguration.ModuleId.ToString, "restore.gif", secure:=SecurityAccessLevel.Admin, Visible:=True)
                        End If
                    End If

                    If _editMode = True And _adminControl = False Then

                        ' module movement
                        _menuActionRoot.Actions.Add(cMenuBreak, "~", "")
                        ' move module up/down
                        If Not _portalModule.ModuleConfiguration Is Nothing Then
                            SetMoveMenuVisibility(_menuActionRoot.Actions.Add(cMenuMoveUp, "Move Up", "MoveUp", _portalModule.ModuleConfiguration.PaneName, Icon:="up.gif", secure:=SecurityAccessLevel.Admin, Visible:=_editMode))
                            SetMoveMenuVisibility(_menuActionRoot.Actions.Add(cMenuMoveDown, "Move Down", "MoveDown", _portalModule.ModuleConfiguration.PaneName, Icon:="dn.gif", secure:=SecurityAccessLevel.Admin, Visible:=_editMode))
                        End If
                        ' move module to pane
                        For intItem = 0 To _portalModule.PortalSettings.Panes.Count - 1
                            SetMoveMenuVisibility(_menuActionRoot.Actions.Add(cMenuMovePaneRoot + intItem, "Move To " & Convert.ToString(_portalModule.PortalSettings.Panes(intItem)), "MovePane", Convert.ToString(_portalModule.PortalSettings.Panes(intItem)), Icon:="unchecked.gif", secure:=SecurityAccessLevel.Admin, Visible:=_editMode))
                        Next intItem
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Protected Sub MoveToPane(ByVal Command As ModuleAction)

            Dim objModules As New ModuleController

            objModules.UpdateModuleOrder(_portalModule.ModuleConfiguration.ModuleId, -1, Command.CommandArgument)
            objModules.UpdateTabModuleOrder(_portalModule.TabId)

            ' Redirect to the same page to pick up changes
            Response.Redirect(Request.RawUrl, True)

        End Sub

        Protected Sub MoveUpDown(ByVal Command As ModuleAction)

            Dim objModules As New ModuleController
            Select Case Command.ID
                Case cMenuMoveUp
                    objModules.UpdateModuleOrder(_portalModule.ModuleConfiguration.ModuleId, _portalModule.ModuleConfiguration.ModuleOrder - 3, Command.CommandArgument)
                Case cMenuMoveDown
                    objModules.UpdateModuleOrder(_portalModule.ModuleConfiguration.ModuleId, _portalModule.ModuleConfiguration.ModuleOrder + 3, Command.CommandArgument)
            End Select

            objModules.UpdateTabModuleOrder(_portalModule.TabId)

            ' Redirect to the same page to pick up changes
            Response.Redirect(Request.RawUrl, True)

        End Sub

        Protected Sub DoAction(ByVal Command As ModuleAction)
            If Command.NewWindow Then
                Response.Write("<script>window.open('" & Command.Url & "','_new')</script>")
            Else
                Response.Redirect(Command.Url, True)
            End If
        End Sub

        Protected Sub Delete(ByVal Command As ModuleAction)

            Dim objModules As New ModuleController

            Dim objModule As ModuleInfo = objModules.GetModule(Integer.Parse(Command.CommandArgument))
            If Not objModule Is Nothing Then
                objModule.IsDeleted = True
                objModules.UpdateModule(objModule)
            End If

            ' Redirect to the same page to pick up changes
            Response.Redirect(Request.RawUrl, True)

        End Sub

        Protected Sub ClearCache(ByVal Command As ModuleAction)

            DataCache.RemoveCache(_portalModule.CacheKey)

            ' Redirect to the same page to pick up changes
            Response.Redirect(Request.RawUrl, True)

        End Sub

        Public Sub AddAction(ByVal Title As String, ByVal CmdName As String, Optional ByVal CmdArg As String = "", Optional ByVal Icon As String = "", Optional ByVal Url As String = "", Optional ByVal UseActionEvent As Boolean = False, Optional ByVal Secure As SecurityAccessLevel = SecurityAccessLevel.Anonymous, Optional ByVal Visible As Boolean = False, Optional ByVal NewWindow As Boolean = False)
            Dim Action As ModuleAction = MenuActions.Add(GetNextActionID, Title, CmdName, CmdArg, Icon, Url, UseActionEvent, Secure, Visible, NewWindow)
        End Sub

        Protected Function GetNextActionID() As Integer
            Return cMenuActionRoot + MenuActions.Count
        End Function

        Public Function GetAction(ByVal Index As Integer) As ModuleAction
            If Not _menuActionRoot Is Nothing Then
                Dim modaction As ModuleAction
                For Each modaction In _menuActionRoot.Actions
                    If modaction.ID = Index Then
                        Return modaction
                    End If
                Next
            End If
            Return Nothing
        End Function

        Protected Sub SetMoveMenuVisibility(ByVal MMAction As ModuleAction)

            Select Case MMAction.ID
                Case cMenuMoveUp
                    MMAction.Visible = (_portalModule.ModuleConfiguration.ModuleOrder <> 0) And (_portalModule.ModuleConfiguration.PaneModuleIndex > 0) And _editMode
                Case cMenuMoveDown
                    MMAction.Visible = (_portalModule.ModuleConfiguration.ModuleOrder <> 0) And (_portalModule.ModuleConfiguration.PaneModuleIndex < (_portalModule.ModuleConfiguration.PaneModuleCount - 1)) And _editMode
                Case Is >= cMenuMovePaneRoot
                    MMAction.Visible = (LCase(_portalModule.ModuleConfiguration.PaneName) <> LCase(MMAction.CommandArgument)) And _editMode
            End Select

        End Sub

        Public ReadOnly Property MenuActions() As ModuleActionCollection
            Get
                If _menuActions Is Nothing Then
                    _menuActions = New ModuleActionCollection
                End If
                Return _menuActions
            End Get
        End Property

        Public ReadOnly Property EditMode() As Boolean
            Get
                Return _editMode
            End Get
        End Property

        Public Property AssociatedModuleSettings() As ModuleSettings
            Get
                Return _associatedModuleSettings
            End Get
            Set(ByVal Value As ModuleSettings)
                _associatedModuleSettings = Value
            End Set
        End Property

        Public ReadOnly Property SupportsIcons() As Boolean
            Get
                Return _supportsIcons
            End Get
        End Property

        Public Property ActionListType() As ActionType
            Get
                Return _actionListType
            End Get
            Set(ByVal Value As ActionType)
                _actionListType = Value
            End Set
        End Property
    End Class
End Namespace
