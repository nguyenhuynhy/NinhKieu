Imports System.Text
Imports System.Configuration
Namespace PortalQH
    Public Class LichHomNay
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblIFrame As System.Web.UI.WebControls.Label
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel

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
            Dim Path As String
            Dim FileLich As String
            Dim Height As String
            Dim Width As String

            Path = Request.ApplicationPath()
            Dim FrameText As New StringBuilder

            FileLich = CType(ConfigurationSettings.AppSettings("FileLichToDay"), String)
            Height = CType(ConfigurationSettings.AppSettings("Height"), String)
            Width = CType(ConfigurationSettings.AppSettings("Width"), String)

            FrameText.Append("<iframe frameborder=""")
            FrameText.Append("no")
            FrameText.Append(""" src=""")
            FrameText.Append(CType(AddHTTP("http://" & Request.Url.Authority & Path & FileLich), String))
            FrameText.Append(""" Height=""")
            FrameText.Append(CType(Height, String))
            FrameText.Append(""" Width=""")
            FrameText.Append(CType(Width, String))
            FrameText.Append("""></iframe>")
            lblIFrame.Text = FrameText.ToString
           
        End Sub

    End Class

End Namespace
