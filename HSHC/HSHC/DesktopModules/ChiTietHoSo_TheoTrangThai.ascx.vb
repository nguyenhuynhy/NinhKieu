Imports PortalQH
Namespace HSHC

    Public Class ChiTietHoSo_TheoTrangThai
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblNguoiNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHenTra As System.Web.UI.WebControls.Label
        Protected WithEvents lblNguoiNop As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayThucTra As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoLaoDong As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoLaoDongNu As System.Web.UI.WebControls.Label
        Protected WithEvents lblNganhKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblTinhTrang As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents trCPLD As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trCPVH As System.Web.UI.HtmlControls.HtmlTableRow

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
            Dim objThongKe As New ThongKeBaoCaoController
            Dim ds As DataSet
            Dim maLinhVuc As String = String.Empty

            ds = objThongKe.ChiTietTiepNhan(CType(Request.Params("ID"), String), CType(Request.Params("Malv"), String))
            gLoadControlValues(ds, Me)

            'lay ma linh vuc loai ho so thong ke
            maLinhVuc = CType(Request.Params("Malv"), String)

            'kiem tra malinhvuc va show ra nhung controls tuong ung voi tung linh vuc
            If maLinhVuc = "CPLD" Then
                trCPLD.Visible = True
                trCPVH.Visible = False
            ElseIf maLinhVuc = "CPVH" Or maLinhVuc = "CPKT" Then
                trCPLD.Visible = False
                trCPVH.Visible = True
            Else
                trCPLD.Visible = False
                trCPVH.Visible = False
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/1/2007	Updated
        '''     Desc : Nhung giai doan thu ly tre duoc the hien bang ma`u red
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub LoadGrid()
            Dim objThongKe As New ThongKeBaoCaoController
            Dim ds As DataSet
            ds = objThongKe.LichSuGiaiQuyetHS(CType(Request.Params("ID"), String), CType(Request.Params("Malv"), String))
            'BindControl.BindDataGrid(ds, dgdDanhSach, True, False, False, "STT", "", "", "", 100, 300, 500)
            Me.dgdDanhSach.DataSource = ds
            Me.dgdDanhSach.DataBind()
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(EditURL("Malv", CStr(Request.Params("Malv")) & "&MaLHS=" & CStr(Request.Params("MaLHS")) & "&TuNgay=" & CStr(Request.Params("TuNgay")) & "&DenNgay=" & CStr(Request.Params("DenNgay")) & "&MaTT=" & CStr(Request.Params("MaTT")), "DSHOSO"))
        End Sub


    End Class

End Namespace