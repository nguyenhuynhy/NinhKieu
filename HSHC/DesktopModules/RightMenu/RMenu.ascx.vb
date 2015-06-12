Imports PortalQH
Imports HSHC
Imports System.Configuration
Imports System.IO
Imports System.Web.UI.WebControls
Namespace PortalQH
    Public MustInherit Class RMenu
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents tdContent1 As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents tdTitle As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents tblContent As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents img As System.Web.UI.WebControls.Image
        Protected WithEvents lblContent As System.Web.UI.WebControls.Label
        Protected WithEvents pnlDong As System.Web.UI.WebControls.Panel

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            MyBase.Actions.Add(GetNextActionID, "Edit", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                Dim imageSrc As String = CType(Settings("imgSrc"), String)
                Dim imageName As String = CType(Settings("imgName"), String)
                If imageName <> "" Then
                    imageSrc = Global.ApplicationPath & "/" & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder") & imageName
                    img.ImageUrl = imageSrc

                    If CType(Settings("Chieurong"), String) <> "" Then
                        img.Width = Unit.Pixel(CType(Settings("Chieurong"), Integer))
                    Else
                        img.Width = Unit.Pixel(CType(ConfigurationSettings.AppSettings("ImgWidth"), Integer))
                    End If

                    If CType(Settings("ChieuCao"), String) <> "" Then
                        img.Height = Unit.Pixel(CType(Settings("ChieuCao"), Integer))
                    Else
                        img.Width = Unit.Pixel(CType(ConfigurationSettings.AppSettings("ImgHeight"), Integer))
                    End If
                Else
                    img.Visible = False
                End If
                lblContent.Text = CType(Settings("NoiDung"), String)
                'lblTitle.Text = CType(Settings("TieuDe"), String)
                tdTitle.InnerText = CType(Settings("TieuDe"), String)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class
End Namespace
