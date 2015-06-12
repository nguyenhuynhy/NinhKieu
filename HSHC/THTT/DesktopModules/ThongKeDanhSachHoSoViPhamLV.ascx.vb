Imports PortalQH
Namespace THTT
    Public Class ThongKeDanhSachHoSoViPhamLV
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblThoiGian As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtBienBanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTenDonVi As System.Web.UI.WebControls.Label

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
                    txtSoDong.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                    Init_State()
                End If
                LoadGrid()
                'btnTroVe.Attributes.Add("onclick", "javascript:history.back();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub Init_State()
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "LAPBIENBAN" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ ÐÃ LẬP BIÊN BẢN"
                Case "RAQUYETDINH" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ ÐÃ RA QUYẾT ÐỊNH"
                Case "THIHANHQUYETDINH" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ ÐÃ THI HÀNH QUYẾT ÐỊNH"
                Case "QUYETDINHCUONGCHE" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ LẬP QUYẾT ÐỊNH CƯỠNG CHẾ"
                Case "THIHANHCUONGCHE" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ ÐÃ THI HÀNH QUYẾT ÐỊNH CƯỠNG CHẾ"
                Case "THIHANHCUONGCHE" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ ÐÃ THI HÀNH QUYẾT ÐỊNH CƯỠNG CHẾ"
                Case "THONGBAOCUONGCHE" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ ĐÃ LẬP THÔNG BÁO CƯỠNG CHẾ"
                Case "KHIEUNAI" : lblTieuDe.Text = "DANH SÁCH HỒ SƠ KHIẾU NẠI"
                Case Else : lblTieuDe.Text = ""
            End Select
            lblTenDonVi.Text = UCase(CStr(Request.Params("TenDonVi")))
            lblThoiGian.Text = CStr(Request.Params("TuNgay")) + " - " + CStr(Request.Params("DenNgay"))
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            ViewState("MaLinhVuc") = UCase(CStr(Request.Params("Malv")))

        End Sub
        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongKeCtrl As New VPHC_ThongKeBaoCaoController


            Dim strTungay, strDenngay, strMadonvi, strLoaiHoSo, strLinhVuc As String
            strTungay = CStr(Request.QueryString("TuNgay"))
            strDenngay = CStr(Request.QueryString("DenNgay"))
            strMadonvi = CStr(Request.QueryString("MaDonVi"))
            strLoaiHoSo = CStr(Request.QueryString("LoaiHoSo"))
            strLinhVuc = Request.QueryString("selectID")
            ds = objThongKeCtrl.ThongKeDanhSachHoSoPhongBan(strTungay, strDenngay, strMadonvi, strLoaiHoSo, strLinhVuc)
            'txtBienBanID.Text = ds.Tables(0).Rows(0).Item("BienBanID").ToString()
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            ds = Nothing
            objThongKeCtrl = Nothing
        End Sub


        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            SetFocus(Page, txtSoDong)
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

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim strURL As String
            'Response.Redirect(NavigateURL())
            Response.Redirect(NavigateURL() & "&SelectID=" & Request.Params("SelectID") & "&SelectIndex=" & Request.Params("SelectIndex") & "&TuNgay=" & Request.Params("TuNgay") & "&DenNgay=" & Request.Params("DenNgay"))
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
