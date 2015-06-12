Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class ChiTietTinhHinhThuLyHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayNhan As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblNgayQuyetDinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayThiHanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiViPham As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenTinhTrang As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLinhVuc As System.Web.UI.WebControls.Label
        Protected WithEvents lblFullName As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBienBan As System.Web.UI.WebControls.Label

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
            Dim objThongKe As New VPHC_ThongKeBaoCaoController
            Dim ds As DataSet
            Dim strLinhVuc As String
            strLinhVuc = Request.QueryString("selectID")
            ds = objThongKe.ChiTietTiepNhan(CStr(Request.Params("ID")), strLinhVuc)
            gLoadControlValues(ds, Me)
            ds = Nothing
            objThongKe = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim objThongKe As New VPHC_ThongKeBaoCaoController
            Dim ds As DataSet
            Dim strLinhVuc As String
            strLinhVuc = Request.QueryString("selectID")
            ds = objThongKe.QuaTrinhGiaiQuyet(CStr(Request.Params("ID")), strLinhVuc)
            BindControl.BindDataGrid(ds, dgdDanhSach, True, False, False, "STT", "", "", "", 100, 300, 500)
            ds = Nothing
            objThongKe = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(EditURL("MaDonVi", Request.Params("MaDonVi") & "&TenDonVi=" & Request.Params("TenDonVi") & "&LoaiHoSo=" & Request.Params("LoaiHoSo") & "&TuNgay=" & Request.Params("TuNgay") & "&DenNgay=" & Request.Params("DenNgay") & "&SelectID=" & Request.QueryString("SelectID") & "&SelectIndex=" & Request.QueryString("SelectIndex"), "VPHC_DSHOSO"))
        End Sub
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            End If
            Return strURL
        End Function
    End Class
End Namespace
