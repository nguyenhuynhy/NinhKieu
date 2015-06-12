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

Namespace PortalQH.Containers
    Public Class LinkActions
        Inherits ActionBase

        Protected _itemSeparator As String = ""

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
            Try
                If _itemSeparator.Length = 0 Then
                    _itemSeparator = "&nbsp;&nbsp;"
                End If

                BindLinkList()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub BindLinkList()
            With _menuActionRoot
                ' Is Root Menu visible?
                If .Visible Then
                    If Me.Controls.Count > 0 Then
                        Me.Controls.Clear()
                    End If

                    Dim PreSpacer As New LiteralControl(ItemSeparator)
                    Me.Controls.Add(PreSpacer)

                    ' Add Menu Items
                    Dim action As ModuleAction
                    For Each action In _menuActionRoot.Actions
                        If action.Title = "~" Then
                            ' not supported in this Action object
                        Else
                            If action.Visible _
                              And PortalSecurity.HasNecessaryPermission(action.Secure, _
                                                                        CType(HttpContext.Current.Items("PortalSettings"), PortalSettings), _
                                                                        AssociatedModuleSettings, _
                                                                        context.User.Identity.Name) Then

                                Dim ModuleActionLink As New LinkButton
                                ModuleActionLink.Text = action.Title
                                ModuleActionLink.CssClass = "CommandButton"
                                ModuleActionLink.ID = "lnk" & action.ID.ToString

                                AddHandler ModuleActionLink.Click, AddressOf LinkAction_Click

                                Me.Controls.Add(ModuleActionLink)
                                Dim Spacer As New LiteralControl(ItemSeparator)
                                Me.Controls.Add(Spacer)
                            End If
                        End If
                    Next
                End If
            End With

            'Need to determine if this action list actually has any items.
            If Me.Controls.Count > 0 Then
                Me.Visible = True
            Else
                Me.Visible = False
            End If
        End Sub

        Private Sub LinkAction_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Dim ActionID As String

                ActionID = DirectCast(sender, LinkButton).ID.Substring(3)

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
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Public Property ItemSeparator() As String
            Get
                Return _itemSeparator
            End Get
            Set(ByVal Value As String)
                _itemSeparator = Value
            End Set
        End Property
    End Class

End Namespace