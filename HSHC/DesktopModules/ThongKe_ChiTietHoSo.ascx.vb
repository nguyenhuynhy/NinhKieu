Imports PortalQH
Imports System.Web.UI.WebControls

Public Class ThongKe_ChiTietHoSo
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblLoaiHoSo As System.Web.UI.WebControls.Label
    Protected WithEvents lblNgayNhan As System.Web.UI.WebControls.Label
    Protected WithEvents lblNguoiNhan As System.Web.UI.WebControls.Label
    Protected WithEvents lblNgayHenTra As System.Web.UI.WebControls.Label
    Protected WithEvents lblNguoiNop As System.Web.UI.WebControls.Label
    Protected WithEvents lblNgayThucTra As System.Web.UI.WebControls.Label
    Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
    Protected WithEvents lblNhanVien As System.Web.UI.WebControls.Label
    Protected WithEvents lblTinhTrang As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents lblLoai As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private DBName As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        DBName = CType(Request.Params("LoaiHoSo"), String)
        If Not Page.IsPostBack Then
            Init_State()
        End If
        LoadGrid()
    End Sub

    Private Sub Init_State()
        Dim objThongKe As New ThongKeBaoCaoController
        Dim ds As DataSet
        ds = objThongKe.ChiTietTiepNhan(DBName, CType(Request.Params("ID"), String))
        gLoadControlValues(ds, Me)
        ds = Nothing
        objThongKe = Nothing
    End Sub

    Private Sub LoadGrid()
        Dim objThongKe As New ThongKeBaoCaoController
        Dim ds As DataSet
        ds = objThongKe.QuaTrinhGiaiQuyet(DBName, CType(Request.Params("ID"), String))
        BindControl.BindDataGrid(ds, dgdDanhSach, True, False, False, "STT", "", "", "", 100, 300, 500)
        ds = Nothing
        objThongKe = Nothing
    End Sub

    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

    Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
        Response.Redirect(EditURL("Malv", CStr(Request.Params("Malv")) & "&Tenlv=" & CStr(Request.Params("Tenlv")) & "&MaLHS=" & CStr(Request.Params("MaLHS")) & "&TenLHS=" & CStr(Request.Params("TenLHS")) & "&TuNgay=" & CStr(Request.Params("TuNgay")) & "&DenNgay=" & CStr(Request.Params("DenNgay")) & "&Loai=" & CStr(Request.Params("Loai")), "DSHOSO"))
    End Sub
End Class
