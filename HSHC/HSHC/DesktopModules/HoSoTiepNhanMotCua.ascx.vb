Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ConvertHoSoTiepNhan
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnNhanHoSo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label

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
            LoadGrid()
        End Sub

        

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            Response.Redirect(NavigateURL())
        End Sub
        Private Sub LoadGrid()
            Dim objHoSoTiepNhan As New TiepNhanHoSoController
            Dim ds As DataSet
            ds = objHoSoTiepNhan.GetHoSoTiepNhanCPB(ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String)))
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, ",,,,,", "100,150,200,100,100,200", False, False)
        End Sub


        Private Sub btnNhanHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNhanHoSo.Click
            Dim objHoSoTiepNhan As New TiepNhanHoSoController
            objHoSoTiepNhan.ConvertHoSoTiepNhan(ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String)))
            LoadGrid()
        End Sub
    End Class
End Namespace