Imports PortalQH
Namespace THTT
    Public Class ThongKe_ChiTietHoSo
        Inherits PortalQH.PortalModuleControl

#Region "Custom Members"
        Dim objGenKey As New RandomKey.RandomKeyGenerator
#End Region

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
        Protected WithEvents btnGui As System.Web.UI.WebControls.LinkButton
        Protected WithEvents trCPLD As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblNganhKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents trCPVH As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents lblTongSoLaoDong As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoLaoDongNu As System.Web.UI.WebControls.Label

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
                If (DataCache.GetCache("ThongKe_ChiTietHoSo") Is Nothing) Then
                    DataCache.SetCache("ThongKe_ChiTietHoSo", Request.UrlReferrer.PathAndQuery)
                End If
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

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	Oct 3rd 2007	Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            'get return URL from cache
            Dim m_ReturnURL As String = CStr(DataCache.GetCache("ThongKe_ChiTietHoSo"))
            DataCache.RemoveCache("ThongKe_ChiTietHoSo")
            Response.Redirect(m_ReturnURL, True)
        End Sub

        Private Sub btnGui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGui.Click
            'Response.Write(Request.Url.ToString)
            DataCache.SetCache(Session.SessionID + "UrlReferrer", Request.Url.ToString)
            Response.Redirect(EditURL("&HoSoID", Request.Params("ID"), "GUITINNHAN"))
        End Sub
    End Class
End Namespace