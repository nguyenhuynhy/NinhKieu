Imports PortalQH


Namespace HSHC


    Public Class DanhSachHoSoTheoTrangThai
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLinhVuc As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblThoiGian As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton

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

            Dim dsInfo As New DataSet
            Dim objThongKeCtrl As New ThongKeBaoCaoController
            dsInfo = objThongKeCtrl.GetLoaiViecByMa("LINHVUC", CStr(Request.Params("MaLV")), "")
            If dsInfo.Tables(0).Rows.Count > 0 Then
                lblLinhVuc.Text = UCase(dsInfo.Tables(0).Rows(0)("TenLinhVuc").ToString())
            End If


            If Not Request.Params("MaLHS") Is Nothing Then
                dsInfo = objThongKeCtrl.GetLoaiViecByMa("LOAIHOSO", CStr(Request.Params("MaLHS")), CStr(Request.Params("MaLV")))
                If dsInfo.Tables(0).Rows.Count > 0 Then
                    lblLoaiHoSo.Text = UCase(dsInfo.Tables(0).Rows(0)("TenLoaiHoSo").ToString())
                End If

            End If

            dsInfo = objThongKeCtrl.GetLoaiViecByMa("TINHTRANG", CStr(Request.Params("MaTT")), CStr(Request.Params("MaLV")))
            If dsInfo.Tables(0).Rows.Count > 0 Then
                lblLoai.Text = "DANH SÁCH HỒ SƠ " + UCase(dsInfo.Tables(0).Rows(0)("TenTinhTrang").ToString())
            Else
                lblLoai.Text = "DANH SÁCH HỒ SƠ "
            End If

            lblThoiGian.Text = CStr(Request.Params("TuNgay")) + " - " + CStr(Request.Params("DenNgay"))

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub


        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongKeInfo As New ThongKeBaoCaoInfo
            Dim objThongKeCtrl As New ThongKeBaoCaoController

            With objThongKeInfo
                .LinhVuc = CStr(Request.Params("MaLV"))
                .LoaiHoSo = CStr(Request.Params("MaLHS"))
                .TuNgay = CStr(Request.Params("TuNgay"))
                .DenNgay = CStr(Request.Params("DenNgay"))
                .LoaiThongKe = "TRANGTHAI"
                .TinhTrang = CStr(Request.Params("MaTT"))
                .URL = EditURL("ID", "value", "CHITIETHOSO")
            End With

            ds = objThongKeCtrl.ThongKeHoSo(objThongKeInfo)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận", "130,300,600,100,100,100,300", False, True)

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


        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL() & "&MaLV=" & CStr(Request.Params("MaLV")) & "&TuNgay=" & Me.Request.Params("TuNgay") & "&DenNgay=" & Me.Request.Params("DenNgay") & "&MaLHS=" & CStr(Request.Params("MaLHS")))
        End Sub

    End Class


End Namespace