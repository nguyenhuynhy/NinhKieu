Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class TinhHinhHoSo_ChiTietHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblNguoiNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHenTra As System.Web.UI.WebControls.Label
        Protected WithEvents lblNguoiNop As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayThucTra As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents lblTinhTrang As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton

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
            If Not Page.IsPostBack Then
                Init_State()
            End If
            LoadGrid()
        End Sub
        Private Sub Init_State()
            Dim objTinhHinh As New TinhHinhHoSoController
            Dim ds As DataSet
            Dim strLinhVuc As String
            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhVuc = Request.Params("LinhVuc")
            End If
            ds = objTinhHinh.ChiTietTiepNhan(ConfigurationSettings.AppSettings("DBCOMMON").ToString(), CStr(Request.Params("ID")), strLinhVuc)
            gLoadControlValues(ds, Me)
            ds = Nothing
            objTinhHinh = Nothing
        End Sub
        Private Sub LoadGrid()
            Dim objTinhHinh As New TinhHinhHoSoController
            Dim ds As DataSet
            Dim strLinhVuc As String
            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhVuc = Request.Params("LinhVuc")
            End If
            ds = objTinhHinh.QuaTrinhGiaiQuyet(CStr(Request.Params("ID")), strLinhVuc)
            BindControl.BindDataGrid(ds, dgdDanhSach, True, False, False, "STT", "", "", "", 100, 300, 500)
            ds = Nothing
            objTinhHinh = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Dim strLinhVuc As String
            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhVuc = Request.Params("LinhVuc")
            End If
            Response.Redirect(EditURL("SelectID", Request.Params("SelectID").ToString() & "&LinhVuc=" & strLinhVuc & "&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&MaSoLHCP=" & Request.Params("MaSoLHCP").ToString() & "&TenLoaiCP=" & Request.Params("TenLoaiCP").ToString() & "&TuNgay=" & Request.Params("TuNgay").ToString() & " &DenNgay=" & Request.Params("DenNgay").ToString() & "&Loai=" & Request.Params("Loai").ToString() & "&SelectIndex=" & Request.Params("SelectIndex").ToString(), "DSHOSO"))
        End Sub
    End Class

End Namespace
