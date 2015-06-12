Imports PortalQH
Namespace CPKTQH
    Public Class HoatDongLaiHCT
        Inherits PortalQH.PortalModuleControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLoaiHinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTinhTrangHienTai As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMatHang As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim objTimKiemCNDKKD As TimKiemGiayCNDKKDInfo
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                SetAttributesControl()
                BindData()
                GetValues()
                LoadGrid()
                GetReportURL(Request.Params("TabID"), GetLinhVuc, "1", GetReportPath(GetLinhVuc()), btnIn, Me)
            End If
        End Sub
        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtTuNgay.ClientID & ", 'dd/mm/yyyy');")
            txtTuNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtTuNgay.ClientID & ");")
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtDenNgay.ClientID & ", 'dd/mm/yyyy');")
            txtDenNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtDenNgay.ClientID & ");")
            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtSoDong.Attributes.Add("onkeypress", "javascript:return ValidateNumeric();")

            btnCapNhat.Attributes.Add("onclick", "return btnCapNhat_click()")
        End Sub
        Private Sub BindData()
            txtTabCode.Text = Request.Params("tabid")
            txtNguoiTacNghiep.Text = CStr(Session("UserName"))
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlLoaiHinh, "DMLOAIDOANHNGHIEP")
            BindControl.BindDropDownList_StoreProc(ddlTinhTrangHienTai, True, "", "sp_DuongDiGiayPhep_GetTinhTrang", Request.Params("TabID"))
            Dim mSoNgay As Integer
            mSoNgay = getSoNgayLoc(Request)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
        End Sub
        Private Sub GetValues()
            If Not Session("TimKiemGiayCNDKKD") Is Nothing Then
                objTimKiemCNDKKD = CType(Session("TimKiemGiayCNDKKD"), TimKiemGiayCNDKKDInfo)
            End If

            If objTimKiemCNDKKD Is Nothing Then objTimKiemCNDKKD = New TimKiemGiayCNDKKDInfo

            With objTimKiemCNDKKD
                .LoaiHinh = ddlLoaiHinh.SelectedValue
                .TinhTrangHienTai = ddlTinhTrangHienTai.SelectedValue
                .SoGiayPhep = Trim(txtSoGiayPhep.Text)
                .TuNgay = txtTuNgay.Text
                .DenNgay = txtDenNgay.Text
                .HoTen = Trim(txtHoTen.Text)
                .SoNha = Trim(txtSoNha.Text)
                .MaDuong = ddlDuong.SelectedValue
                .MaPhuong = ddlPhuong.SelectedValue
                .MatHang = Trim(txtMatHang.Text)
                .URL = EditURL("ID", "VALUE")
                .BangHieu = txtBangHieu.Text

            End With

            'If objTimKiemCNDKKD.TinhTrangHienTai = "" Then objTimKiemCNDKKD.TinhTrangHienTai = CHUOITINHTRANG

            Session("TimKiemGiayCNDKKD") = objTimKiemCNDKKD
        End Sub
        Private Sub LoadGrid()
            Dim ds As New DataSet
            Dim obj As New TimKiemGiayCNDKKDController

            lblTongSoHoSo.Text = "0"

            If Session("TimKiemGiayCNDKKD") Is Nothing Then
                GetValues()
            End If
            objTimKiemCNDKKD = CType(Session("TimKiemGiayCNDKKD"), TimKiemGiayCNDKKDInfo)
            ds = obj.getDanhSachTamNgungDKKD(objTimKiemCNDKKD)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                    dgdDanhSach.DataSource = ds
                    dgdDanhSach.DataBind()
                    lblTongSoHoSo.Text = CStr(ds.Tables(0).Rows.Count)
                End If
            End If
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

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            GetValues()
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            txtSoGiayPhep.Text = ""
            LoadGrid()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objHoatDongLaiCon As New HoatDongLaiHCTController
            Dim i As Integer
            Dim strGiayCNDKKDID As String
            Dim strTinhTrangHienTai As String
            For i = 0 To dgdDanhSach.Items.Count - 1
                Dim chk As CheckBox
                chk = CType(dgdDanhSach.Items(i).FindControl("chkHoatDongLai"), CheckBox)
                If chk.Checked Then
                    strGiayCNDKKDID = dgdDanhSach.Items(i).Cells(1).Text
                    strTinhTrangHienTai = dgdDanhSach.Items(i).Cells(2).Text
                    objHoatDongLaiCon.updHoatDongLai(strGiayCNDKKDID, strTinhTrangHienTai)
                End If
            Next
            Response.Redirect(Request.RawUrl())
        End Sub
    End Class
End Namespace
