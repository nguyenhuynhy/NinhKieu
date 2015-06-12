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

Namespace PortalQH.Containers
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : Containers.Visibility
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the events for collapsing and expanding modules, 
    ''' Showing or hiding admin controls when preview is checked
    ''' if personalization of the module container and title is allowed for that module.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[sun1]	2/1/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class Visibility

        Inherits SkinObject

        ' public attributes
        Public [BorderWidth] As String
        Public [MinIcon] As String
        Public [MaxIcon] As String

        ' protected controls
        Protected WithEvents cmdVisibility As System.Web.UI.WebControls.ImageButton

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
                If Not Page.IsPostBack Then

                    ' public attributes
                    If [BorderWidth] <> "" Then
                        cmdVisibility.BorderWidth = System.Web.UI.WebControls.Unit.Parse([BorderWidth])
                    End If

                    Dim objPortalModule As PortalModuleControl = Container.GetPortalModuleControl(Me)

                    Dim blnPreview As Boolean = False
                    If Not Request.Cookies("_Tab_Admin_Preview" & objPortalModule.PortalSettings.PortalId.ToString) Is Nothing Then
                        blnPreview = Boolean.Parse(Request.Cookies("_Tab_Admin_Preview" & objPortalModule.PortalSettings.PortalId.ToString).Value)
                    End If

                    If Not objPortalModule.ModuleConfiguration Is Nothing Then
                        ' check if Personalization is allowed
                        If objPortalModule.ModuleConfiguration.Personalize = 2 Then
                            cmdVisibility.Enabled = False
                            cmdVisibility.Visible = False
                        End If

                        If (IsAdminControl() = False And IsAdminTab(objPortalModule.PortalSettings.ActiveTab.TabId, objPortalModule.PortalSettings.ActiveTab.ParentId) = False) Then
                            If cmdVisibility.Enabled Then
                                Dim pnlModuleContent As Panel = CType(Me.Parent.FindControl("ModuleContent"), Panel)

                                If Not pnlModuleContent Is Nothing Then
                                    Dim objModuleVisible As HttpCookie = Request.Cookies("_Module" & objPortalModule.ModuleId.ToString & "_Visible")

                                    If Not objModuleVisible Is Nothing Then
                                        If objModuleVisible.Value = "true" Then
                                            ShowMinimize(pnlModuleContent, objPortalModule)
                                        Else
                                            ShowMaximize(pnlModuleContent, objPortalModule)
                                        End If
                                    Else
                                        If objPortalModule.ModuleConfiguration.Personalize = 1 Then
                                            ShowMaximize(pnlModuleContent, objPortalModule)
                                        Else
                                            ShowMinimize(pnlModuleContent, objPortalModule)
                                        End If
                                    End If
                                Else
                                    Me.Visible = False
                                End If
                            End If
                        Else
                            Me.Visible = False
                        End If
                    Else
                        Me.Visible = False
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdVisibility_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdVisibility.Click
            Try
                Dim pnlModuleContent As Panel = CType(Me.Parent.FindControl("ModuleContent"), Panel)

                If Not pnlModuleContent Is Nothing Then

                    Dim objPortalModule As PortalModuleControl = Container.GetPortalModuleControl(Me)

                    Dim objModuleVisible As HttpCookie = New HttpCookie("_Module" & objPortalModule.ModuleId.ToString & "_Visible")

                    If pnlModuleContent.Visible = True Then
                        ShowMaximize(pnlModuleContent, objPortalModule)
                        objModuleVisible.Value = "false"
                    Else
                        ShowMinimize(pnlModuleContent, objPortalModule)
                        objModuleVisible.Value = "true"
                    End If

                    objModuleVisible.Expires = DateTime.MaxValue ' never expires
                    Response.AppendCookie(objModuleVisible)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub ShowMinimize(ByVal pnlModuleContent As Panel, ByVal objPortalModule As PortalModuleControl)
            pnlModuleContent.Visible = True
            If [MinIcon] <> "" Then
                cmdVisibility.ImageUrl = objPortalModule.ModuleConfiguration.ContainerPath.Substring(0, objPortalModule.ModuleConfiguration.ContainerPath.LastIndexOf("/") + 1) & [MinIcon]
            Else
                cmdVisibility.ImageUrl = "~/images/min.gif"
            End If
            cmdVisibility.ToolTip = "Minimize"
            cmdVisibility.AlternateText = "Minimize"
        End Sub

        Private Sub ShowMaximize(ByVal pnlModuleContent As Panel, ByVal objPortalModule As PortalModuleControl)
            pnlModuleContent.Visible = False
            If [MaxIcon] <> "" Then
                cmdVisibility.ImageUrl = objPortalModule.ModuleConfiguration.ContainerPath.Substring(0, objPortalModule.ModuleConfiguration.ContainerPath.LastIndexOf("/") + 1) & [MaxIcon]
            Else
                cmdVisibility.ImageUrl = "~/images/max.gif"
            End If
            cmdVisibility.ToolTip = "Maximize"
            cmdVisibility.AlternateText = "Maximize"
        End Sub

    End Class

End Namespace
