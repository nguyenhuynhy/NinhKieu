Imports PortalQH
Namespace HSHC
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : ThongKeHoSoQuaHanTheoUser
    ''' Reference: ThongKeHoSoQuaHan
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[phuocdd]	Oct 4th 2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ThongKeHoSoQuaHanTheoTinhTrang
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents lblLinhVuc As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblThoiGian As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTinhTrang As System.Web.UI.WebControls.Label


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
            Try
                If Not Page.IsPostBack Then
                    If (DataCache.GetCache("ThongKeHoSoQuaHanTheoTinhTrang") Is Nothing) Then
                        DataCache.SetCache("ThongKeHoSoQuaHanTheoTinhTrang", Request.UrlReferrer.PathAndQuery)
                    End If
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub Init_State()
            lblLinhVuc.Text = UCase(DecryptQueryParam(Request.Params("Tenlv")))
            lblLoaiHoSo.Text = UCase(DecryptQueryParam(Request.Params("TenLHS")))
            lblTinhTrang.Text = DecryptQueryParam(Request.Params("TenTT"))
            lblThoiGian.Text = CStr(Request.Params("TuNgay")) + " - " + CStr(Request.Params("DenNgay"))
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongKeCtrl As New DanhSachHSQuaHanController
            ds = objThongKeCtrl.DanhSachHSChuaGQQuaHanByStatus(Request.Params("Malv"), Request.Params("MaLHS"), Request.Params("TuNgay"), Request.Params("DenNgay"), Request.Params("ttid"))
            Me.dgdDanhSach.DataSource = ds.Tables(0)
            Me.dgdDanhSach.DataBind()
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "So dong hien thi khong hop le")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
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
            Dim m_ReturnURL As String = CStr(DataCache.GetCache("ThongKeHoSoQuaHanTheoTinhTrang"))
            DataCache.RemoveCache("ThongKeHoSoQuaHanTheoTinhTrang")
            Response.Redirect(m_ReturnURL, True)
        End Sub
    End Class
End Namespace