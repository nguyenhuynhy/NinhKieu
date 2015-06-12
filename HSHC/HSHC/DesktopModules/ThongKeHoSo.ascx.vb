Imports PortalQH
Namespace HSHC
    Public Class ThongKeHoSo
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
                    If (DataCache.GetCache("ThongKeHoSo") Is Nothing) Then
                        DataCache.SetCache("ThongKeHoSo", Request.UrlReferrer.PathAndQuery)
                    End If
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/21/2007	Updated, thay "BỔ TÚC" bằng "BỔ SUNG"
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Init_State()
            lblLinhVuc.Text = UCase(DecryptQueryParam(Request.Params("Tenlv")))
            lblLoaiHoSo.Text = UCase(DecryptQueryParam(Request.Params("TenLHS")))
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "TONTRUOC" : lblLoai.Text = "DANH SÁCH HỒ SƠ TỒN TRƯỚC"
                Case "MOINHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ NHẬN TRONG KỲ"
                Case "DAHUY" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ HỦY TRONG KỲ"
                Case "DAGQDUNGHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ GIẢI QUYẾT ĐÚNG HẠN"
                Case "DAGQQUAHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ GIẢI QUYẾT QUÁ HẠN"
                Case "CHUAGQTRONGHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHƯA GIẢI QUYẾT TRONG HẠN"
                Case "BOTUCHOSO" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHỜ BỔ SUNG"
                Case "CHUAGQQUAHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHƯA GIẢI QUYẾT QUÁ HẠN"
                Case "DATRA" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ TRẢ DÂN"
                Case "CHUATRA" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHƯA TRẢ DÂN"
                Case Else : lblLoai.Text = ""
            End Select
            lblThoiGian.Text = CStr(Request.Params("TuNgay")) + " - " + CStr(Request.Params("DenNgay"))

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/22/2007	Updated, Tach rieng bindgrid cac ho so qua han
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongKeInfo As New ThongKeBaoCaoInfo
            Dim objThongKeCtrl As New ThongKeBaoCaoController

            With objThongKeInfo
                .LinhVuc = CStr(Request.Params("Malv"))
                .LoaiHoSo = CStr(Request.Params("MaLHS"))
                .TuNgay = CStr(Request.Params("TuNgay"))
                .DenNgay = CStr(Request.Params("DenNgay"))
                .LoaiThongKe = CStr(Request.Params("Loai"))
                .URL = EditURL("ID", "value", "CHITIETHOSO")
            End With

            ds = objThongKeCtrl.ThongKeHoSo(objThongKeInfo)
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "TONTRUOC", "DAHUY", "CHUAGQTRONGHAN", "BOTUCHOSO" : BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "130,300,600,100,100,400", False, True)
                Case "MOINHAN", "DAGQDUNGHAN", "DATRA", "CHUATRA" : BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "130,300,600,100,100,100,300", False, True)
                Case "DAGQQUAHAN" : BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "130,300,600,100,100,100,150", False, True)
                Case "CHUAGQQUAHAN" : BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "130,300,600,100,100,150", False, True)
            End Select
            ds = Nothing
            objThongKeInfo = Nothing
            objThongKeCtrl = Nothing
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
            Dim m_ReturnURL As String = CStr(DataCache.GetCache("ThongKeHoSo"))
            DataCache.RemoveCache("ThongKeHoSo")
            Response.Redirect(m_ReturnURL, True)
        End Sub
    End Class
End Namespace