Namespace PortalQH

    Public Class EditLinksViewOptions
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents optControl As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents optView As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents optInfo As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents cmdUpdateOptions As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancelOptions As System.Web.UI.WebControls.LinkButton
        Protected WithEvents pnlOptions As System.Web.UI.WebControls.Panel

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
            Try
                If (Page.IsPostBack = False) Then
                    If CType(Settings("linkcontrol"), String) <> "" Then
                        optControl.Items.FindByValue(CType(Settings("linkcontrol"), String)).Selected = True
                    Else
                        optControl.SelectedIndex = 0 ' list
                    End If
                    If CType(Settings("linkview"), String) <> "" Then
                        optView.Items.FindByValue(CType(Settings("linkview"), String)).Selected = True
                    Else
                        optView.SelectedIndex = 0 ' vertical
                    End If
                    If CType(Settings("displayinfo"), String) <> "" Then
                        optInfo.Items.FindByValue(CType(Settings("displayinfo"), String)).Selected = True
                    Else
                        optInfo.SelectedIndex = 1 ' vertical
                    End If
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdateOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdateOptions.Click
            Try
                Dim objModules As New ModuleController

                objModules.UpdateModuleSetting(ModuleId, "linkcontrol", optControl.SelectedItem.Value)
                objModules.UpdateModuleSetting(ModuleId, "linkview", optView.SelectedItem.Value)
                objModules.UpdateModuleSetting(ModuleId, "displayinfo", optInfo.SelectedItem.Value)

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancelOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelOptions.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
