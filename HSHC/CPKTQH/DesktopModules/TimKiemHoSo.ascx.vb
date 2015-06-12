Imports PortalQH
Namespace CPKTQH
    Public Class TimKiemHoSo
        Inherits PortalQH.PortalModuleControl


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaTinhTrang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlNguoiThuLy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlLoaiTimKiem As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLoaiTiepNhanHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblTieuDeLoaiTiepNhan As System.Web.UI.WebControls.Label
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
            If Not Me.IsPostBack Then
                SetAttributesControl()
                BindData()
                Init_State()
                KiemTraRequest()
                GetValues()
            End If
            LoadGrid()
        End Sub

        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtTuNgay.ClientID & ", 'dd/mm/yyyy');")
            Me.txtTuNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtTuNgay.ClientID & ");")
            Me.txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtDenNgay.ClientID & ", 'dd/mm/yyyy');")
            Me.txtDenNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtDenNgay.ClientID & ");")
            Me.txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtSoDong.Attributes.Add("onkeypress", "javascript:return ValidateNumeric();")

            GetReportURL(Request.Params("TabID"), GetLinhVuc, "1", GetReportPath(GetLinhVuc()), btnInRaGiay, Me)
        End Sub

        Private Sub BindData()
            'BindControl.BindDropDownList(ddlLoaiHinh, "DMLOAIDOANHNGHIEP")
            BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
            BindControl.BindDropDownList(ddlMaTinhTrang, "DMTINHTRANGHOSO")
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlNguoiThuLy, "DMNGUOISUDUNG")
        End Sub

        Private Sub Init_State()
            If Not SuDungDangKyQuaMang() Then
                lblTieuDeLoaiTiepNhan.Visible = False
                ddlLoaiTiepNhanHoSo.Visible = False
            End If

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)

        End Sub

        Private Sub KiemTraRequest()
            'sử dụng tron trường hợp từ trang chủ gọi sang
            If Not Request.Params("TuNgay") Is Nothing Then
                If Not TestDateInput(Request.Params("TuNgay")) Then GoTo err
                txtTuNgay.Text = Request.Params("TuNgay")
            End If

            If Not Request.Params("DenNgay") Is Nothing Then
                If Not TestDateInput(Request.Params("DenNgay")) Then GoTo err
                txtDenNgay.Text = Request.Params("DenNgay")
            End If

            If Not Request.Params("Loai") Is Nothing Then
                Try
                    ddlLoaiTimKiem.SelectedValue = UCase(Request.Params("Loai"))
                Catch ex As Exception
                    GoTo err
                End Try
            End If

            If Not Request.Params("MaLHS") Is Nothing Then
                Try
                    ddlMaLoaiHoSo.SelectedValue = Request.Params("MaLHS")
                Catch ex As Exception
                    GoTo err
                End Try
            End If
            Exit Sub
err:
            Response.Redirect(ApplicationURL())
        End Sub

        Private Sub GetValues()
            Dim objTimKiem As New TimKiemHoSoInfo
            With objTimKiem
                '.LoaiHinh = "" 'ddlLoaiHinh.SelectedValue
                .MaLoaiHoSo = ddlMaLoaiHoSo.SelectedValue
                .MaTinhTrang = ddlMaTinhTrang.SelectedValue
                .SoBienNhan = Trim(txtSoBienNhan.Text)
                .TuNgay = Trim(txtTuNgay.Text)
                .DenNgay = Trim(txtDenNgay.Text)
                .LoaiTimKiem = ddlLoaiTimKiem.SelectedValue
                .SoNha = Trim(txtSoNha.Text)
                .MaDuong = ddlDuong.SelectedValue
                .MaPhuong = ddlPhuong.SelectedValue
                .NguoiThuLy = ddlNguoiThuLy.SelectedValue
                .URL = EditURL("ID", "VALUE")
                .LoaiTiepNhanHoSo = ddlLoaiTiepNhanHoSo.SelectedValue
                .HoTen = Trim(txtHoTen.Text)
                .SoGiayPhep = Trim(txtSoGiayPhep.Text)
            End With
            Session("TimKiemHoSo") = objTimKiem
            objTimKiem = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim objTimKiemInfo As New TimKiemHoSoInfo
            Dim objTimKiem As New TimKiemHoSoController
            Dim ds As DataSet

            If Session("TimKiemHoSo") Is Nothing Then GetValues()
            objTimKiemInfo = CType(Session("TimKiemHoSo"), TimKiemHoSoInfo)

            ds = objTimKiem.TimKiemHoSo(objTimKiemInfo)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,HoSoTiepNhanID,Họ tên,Địa chỉ,Ngày nhận,Ngày hẹn trả,Ngày thực trả,Loại hình,Loại hồ sơ,Tình trạng,Ngày nhận thụ lý,Người thụ lý,TinhTrangHoSoID", _
                                    "100,0,200,200,100,100,0,0,200,200,100,200,0", False)
                    lblTongSoHoSo.Text = CStr(ds.Tables(0).Rows.Count) & " hồ sơ"

                    ds = Nothing
                    objTimKiemInfo = Nothing
                    objTimKiem = Nothing
                End If
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

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            GetValues()
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub
    End Class
End Namespace