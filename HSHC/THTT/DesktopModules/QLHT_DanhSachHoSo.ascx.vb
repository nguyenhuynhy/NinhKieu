Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class QLHT_DanhSachHoSo
        Inherits PortalQH.PortalModuleControl
        Private strColWidth As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents lblLinhVuc As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblThoiGian As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton


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
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub Init_State()
            Dim objQLHT As New QuanLyHoTichController
            Dim strKhuVuc As String = objQLHT.GetLinhVuc(ConfigurationSettings.AppSettings("DB_QLHT"), CStr(Request.Params("MaKhuVuc")))
            lblLinhVuc.Text = UCase(strKhuVuc)
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "KHAISINH" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐĂNG KÝ KHAI SINH"
                Case "KHAISINH_BS" : lblLoai.Text = "CẤP BẢN SAO GIẤY KHAI SINH"
                Case "KHAITU" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐĂNG KÝ KHAI TỬ"
                Case "KHAITU_BS" : lblLoai.Text = "CẤP BẢN SAO GIẤY KHAI TỬ"
                Case "KETHON" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐĂNG KÝ KẾT HÔN"
                Case "KETHON_BS" : lblLoai.Text = "CẤP BẢN SAO GIẤY ĐĂNG KÝ KẾT HÔN"
                Case "NHANNUOICONNUOI" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐĂNG KÝ NHẬN NUÔI CON NUÔI"
                Case "NHANNUOICONNUOI_BS" : lblLoai.Text = "CẤP BẢN SAO GIẤY ĐĂNG KÝ NHẬN NUÔI CON NUÔI"
                Case "NHANCHAMECON" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐĂNG KÝ NHẬN CON"
                Case "NHANCHAMECON_BS" : lblLoai.Text = "CẤP BẢN SAO GIẤY ĐĂNG KÝ NHẬN CON"
                Case "NHANGIAMHO" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐĂNG KÝ NHẬN GIÁM HỘ"
                Case "NHANGIAMHO_BS" : lblLoai.Text = "CẤP BẢN SAO GIẤY ĐĂNG KÝ NHẬN GIÁM HỘ"
                Case "CHAMDUTGIAMHO" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHẤM DỨT GIÁM HỘ"
                Case "CHUNGNHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ XIN GIẤY CHỨNG NHẬN"
                Case "CHUNGNHANMB" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHỨNG NHẬN MẤT BỘ"
                Case "THONGBAOSOTBO" : lblLoai.Text = "DANH SÁCH HỒ SƠ THÔNG BÁO SÓT BỘ"
                Case Else : lblLoai.Text = ""
            End Select
            lblThoiGian.Text = CStr(Session.Item("TuNgay")) + " - " + CStr(Session.Item("DenNgay"))

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objQLHT As New QuanLyHoTichController
            Dim strURL As String
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "KHAISINH", "KHAISINH_BS" : strColWidth = "70,70,80,300,70,80,300,200"
                Case "KHAITU", "KHAITU_BS" : strColWidth = "70,70,80,300,70,80,80,200"
                Case "KETHON", "KETHON_BS" : strColWidth = "70,70,80,250,80,200,250,80,200"
                Case "NHANNUOICONNUOI", "NHANNUOICONNUOI_BS" : strColWidth = "70,70,70,70,70,250,70,70,200,300"
                Case "NHANCHAMECON", "NHANCHAMECON_BS" : strColWidth = "70,70,80,70,80,250,300,200,50,80"
                Case "NHANGIAMHO", "NHANGIAMHO_BS" : strColWidth = "70,70,80,80,80,150,200,80,200,200,200"
                Case "CHAMDUTGIAMHO" : strColWidth = "70,70,80,300,70,80,300,200"
                Case "CHUNGNHAN" : strColWidth = "120,100,80,150,300,300,100"
                Case "CHUNGNHANMB" : strColWidth = "120,100,80,150,300,300,100"
                Case "THONGBAOSOTBO" : strColWidth = "120,100,80,150,300,300,100"

            End Select
            strURL = GetMidURL("ID", "VALUE" & "&MaKhuVuc=" & Request.QueryString("MaKhuVuc") & "&Loai=" & Request.QueryString("Loai"), "QLHT_CHITIETHOSO")

            ds = objQLHT.GetDanhSachHoSo(ConfigurationSettings.AppSettings("DB_QLHT"), _
                                            Session.Item("TuNgay").ToString, _
                                            Session.Item("DenNgay").ToString, _
                                            Request.QueryString("MaKhuVuc"), _
                                            Request.QueryString("Loai"), _
                                            strURL)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "", strColWidth, False, True)
            ds = Nothing
            objQLHT = Nothing
        End Sub


        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
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

        

        Private Sub GridToExcel()
            dgdDanhSach.AllowPaging = False
            dgdDanhSach.AllowSorting = False
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
            RenderGrid()
        End Sub

        Private Sub RenderGrid()

            Dim strFileName As String = "DanhSachHoSo.xls"
            Response.Clear()
            Response.ContentType = "application/vnd.ms-excel"
            Response.Charset = ""
            Response.AddHeader("Content-Disposition", "attachment; filename=""" & strFileName & """")
            ' Turn off the view state.
            Me.EnableViewState = False
            Dim tw As New System.IO.StringWriter
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim str As String = ""
            Dim lbl As New Label

            dgdDanhSach.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            'Response.Redirect(NavigateURL(""))
            Response.Redirect(NavigateURL() & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID"))
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            If dgdDanhSach.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub
    End Class
End Namespace