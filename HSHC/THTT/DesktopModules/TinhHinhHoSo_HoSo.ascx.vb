Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class TinhHinhHoSo_HoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblThoiGian As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton

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
            'lblLinhVuc.Text = UCase(CStr(Request.Params("SelectTitle")))
            lblLoaiHoSo.Text = UCase(CStr(Request.Params("TenLoaiCP")))
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "TONTRUOC" : lblLoai.Text = "DANH SÁCH HỒ SƠ TỒN TRƯỚC"
                Case "MOINHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ NHẬN TRONG KỲ"
                    'Case "DAHUY" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ HỦY TRONG KỲ"
                Case "DAGIAIQUYET" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ GIẢI QUYẾT ĐÚNG HẠN"
                Case "DAGQQUAHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ GIẢI QUYẾT QUÁ HẠN"
                Case "CHUAGQ" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHƯA GIẢI QUYẾT TRONG HẠN"
                Case "QUAHAN" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHƯA GIẢI QUYẾT QUÁ HẠN"
                Case "DATRA" : lblLoai.Text = "DANH SÁCH HỒ SƠ ĐÃ TRẢ DÂN"
                Case "CHUATRA" : lblLoai.Text = "DANH SÁCH HỒ SƠ CHƯA TRẢ DÂN"
                Case Else : lblLoai.Text = ""
            End Select
            lblThoiGian.Text = CStr(Request.Params("TuNgay")) + " - " + CStr(Request.Params("DenNgay"))

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub
        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim strLinhvuc As String
            Dim objTinhHinhInfo As New TinhHinhHoSoInfo
            Dim objTinhHinhCtrl As New TinhHinhHoSoController

            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhvuc = Request.Params("LinhVuc")
            End If


            With objTinhHinhInfo
                .LinhVuc = strLinhvuc
                .LoaiHoSo = CStr(Request.Params("MaSoLHCP"))
                .TuNgay = CStr(Request.Params("TuNgay"))
                .DenNgay = CStr(Request.Params("DenNgay"))
                .LoaiThongKe = CStr(Request.Params("Loai"))
                Dim strIndex As String
                If Request.Params("SelectIndex") Is Nothing Then
                    strIndex = ""
                Else
                    strIndex = Request.Params("SelectIndex").ToString
                End If

                .URL = EditURL("ID", "value" & "N&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&SelectID=" & CType(Request.Params("SelectID"), String) & "&TenLoaiCP=" & Request.Params("TenLoaiCP").ToString() & "&SelectIndex=" & strIndex, "CHITIETHOSO")
            End With


            ds = objTinhHinhCtrl.ThongKeHoSo(objTinhHinhInfo, ConfigurationSettings.AppSettings("commonDB").ToString())
            Select Case UCase(CStr(Request.Params("Loai")))
                Case "TONTRUOC", "CHUAGQ", "QUAHAN" : BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "100,200,400,100,100,100,200", False, True)
                Case "MOINHAN", "DAGIAIQUYET", "DAGQQUAHAN", "DATRA", "CHUATRA" : BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "130,300,600,100,100,100,200", False, True)
            End Select
            ds = Nothing
            objTinhHinhInfo = Nothing
            objTinhHinhCtrl = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Dim iIndex As String
            Dim iChildIndex As String
            Dim iType As String
            Dim iSelectID As String
            Dim iSelectTitle As String
            Dim strLinhVuc As String

            If Not Request.Params("SelectTitle") Is Nothing Then
                iSelectTitle = Request.Params("SelectTitle").ToString()
            Else
                iSelectTitle = "0"
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectID = Request.Params("SelectID").ToString()
            End If
            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhVuc = Request.Params("LinhVuc").ToString()
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                iIndex = Request.Params("SelectIndex").ToString()
            Else
                iIndex = "0"
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                iChildIndex = Request.Params("SelectChildIndex").ToString()
            Else
                iChildIndex = "0"
            End If
            If Not Request.Params("Type") Is Nothing Then
                iType = Request.Params("Type").ToString()
            Else
                iType = "1"
            End If
            If iSelectID = ConfigurationSettings.AppSettings("DBCOMMON") Then
                Response.Redirect(Replace(EditURL(), "Edit", "CP") & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&LinhVuc=" & strLinhVuc)
            Else
                Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&LinhVuc=" & strLinhVuc)
            End If

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

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
            If dgdDanhSach.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub

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
    End Class
End Namespace

