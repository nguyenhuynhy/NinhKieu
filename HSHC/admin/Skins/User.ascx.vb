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

Imports System.Web.UI.UserControl

Namespace PortalQH.Skins

    Public Class User

        Inherits SkinObject

        ' public attributes
        Public [Text] As String
        Protected WithEvents hypRegister As System.Web.UI.WebControls.Label
        Public [CssClass] As String

        ' protected controls


#Region " Web Form Designer Generated Code "


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
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
                Dim objModules As New ModuleController

                If Not Page.IsPostBack Then

                    ' public attributes
                    If [CssClass] <> "" Then
                        hypRegister.CssClass = [CssClass]
                    End If

                    If Request.IsAuthenticated = False Then
                        If _portalSettings.UserRegistration <> 0 Then
                            If [Text] <> "" Then
                                If [Text].IndexOf("src=") <> -1 Then
                                    [Text] = Replace([Text], "src=""", "src=""" & _portalSettings.ActiveTab.SkinPath)
                                End If
                                hypRegister.Text = [Text]
                            Else
                                hypRegister.Text = "Ðăng ký"
                            End If
                            'If _portalSettings.UserTabId <> -1 Then
                            '    ' user defined tab
                            '    'hypRegister.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.UserTabId.ToString
                            '    hypRegister.NavigateUrl = "#"
                            'Else
                            '    ' admin tab
                            '    hypRegister.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&ctl=Register"
                            'End If
                            hypRegister.Visible = True
                        End If
                    Else
                        Dim UserId As String = CType(Context.User.Identity.Name, String)

                        Dim objUsers As New UserController
                        Dim objUser As UserInfo

                        objUser = objUsers.GetUser(_portalSettings.PortalId, UserId)

                        If Not objUser Is Nothing Then
                            hypRegister.Text = objUser.FullName
                            'hypRegister.ToolTip = "Click Here To Edit Your Account Profile"
                            'DataCache.SetCache("UserName", objUser.Name)
                            DataCache.SetCache("UserID", objUser.UserID)
                            Session.Item("UserName") = objUser.Name
                            'If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                            '    Dim intModuleId As Integer = objModules.GetSiteModule("Ngu?i s? d?ng", _portalSettings.PortalId)
                            '    'hypRegister.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&mid=" & intModuleId & "&ctl=S?a" & "&UserId=" & _portalSettings.SuperUserId

                            'Else
                            '    If _portalSettings.UserTabId <> -1 Then
                            '        ' user defined tab
                            '        'hypRegister.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.UserTabId.ToString
                            '        'hypRegister.NavigateUrl = "#"
                            '    Else
                            '        ' admin tab
                            '        'hypRegister.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&ctl=Register"
                            '    End If
                            'End If
                        End If
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
