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
    Public Class DropDownActions
        Inherits ActionBase

        Protected WithEvents cboActions As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdGo As System.Web.UI.WebControls.ImageButton

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here

        End Sub

        Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            Try
                BindDropDown()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdGo.Click
            Try
                Dim ActionID As String

                If cboActions.SelectedIndex <> -1 Then
                    ActionID = cboActions.SelectedItem.Value()

                    If IsNumeric(ActionID) Then
                        Dim action As ModuleAction = GetAction(Convert.ToInt32(ActionID))
                        Select Case Convert.ToInt32(ActionID)
                            Case Is >= cMenuActionRoot
                                If action.Url.Length > 0 And action.UseActionEvent = False Then
                                    DoAction(action)
                                Else
                                    OnAction(New ActionEventArgs(action, AssociatedModuleSettings))
                                End If
                            Case Is >= cMenuMovePaneRoot
                                MoveToPane(action)
                            Case cMenuMoveDown
                                MoveUpDown(action)
                            Case cMenuMoveUp
                                MoveUpDown(action)
                            Case cMenuModSettings
                                DoAction(action)
                            Case cMenuDelete
                                Delete(action)
                            Case cMenuClearCache
                                ClearCache(action)
                            Case cMenuHelp, cMenuDocumentation
                                DoAction(action)
                        End Select
                    End If
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Public Sub BindDropDown()

            With _menuActionRoot
                ' Is Root Menu visible?
                If .Visible Then
                    ' Clear old Actions...  
                    ' The module may have added/removed actions during postback
                    cboActions.Items.Clear()

                    ' Add Menu Items
                    Dim action As ModuleAction
                    For Each action In _menuActionRoot.Actions
                        If action.Title = "~" Then
                            cboActions.Items.Add("-------------------")
                        Else
                            If action.Visible _
                              And PortalSecurity.HasNecessaryPermission(action.Secure, _
                                                                        CType(HttpContext.Current.Items("PortalSettings"), PortalSettings), _
                                                                        AssociatedModuleSettings, _
                                                                        context.User.Identity.Name) Then

                                cboActions.Items.Add(New ListItem(action.Title, action.ID.ToString))
                            End If
                        End If
                    Next
                End If
            End With

            'Need to determine if the dropdown actually has any menu items.
            If cboActions.Items.Count > 0 Then
                Me.Visible = True
            Else
                Me.Visible = False
            End If
        End Sub
    End Class
End Namespace
