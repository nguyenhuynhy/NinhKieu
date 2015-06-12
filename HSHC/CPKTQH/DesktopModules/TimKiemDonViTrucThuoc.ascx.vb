Imports PortalQH
Namespace CPKTQH
    Public Class TimKiemDonViTrucThuoc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtNguoiDungDau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenDoanhNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlHoatDong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

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
            If Not Page.IsPostBack Then
                SetAttributesControl()
                BindData()
                Init_State()
            End If
            LoadGrid()
        End Sub
        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            Me.txtTuNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtTuNgay.ClientID & ");")
            Me.txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Me.txtDenNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtDenNgay.ClientID & ");")
            Me.txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtSoDong.Attributes.Add("onkeypress", "javascript:return ValidateNumeric();")
        End Sub
        Private Sub BindData()
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlMaLoaiHinhDoanhNghiep, "DMLOAICHINHANH")
        End Sub
        Private Sub Init_State()
            If Not Session.Item("TimKiemDonViTrucThuocInfo") Is Nothing Then
                Dim TKDVTT As New TimKiemDonViTrucThuocInfo
                TKDVTT = CType(Session.Item("TimKiemDonViTrucThuocInfo"), TimKiemDonViTrucThuocInfo)
                With TKDVTT
                    txtNguoiDungDau.Text = .NguoiDungDau
                    txtSoNha.Text = .SoNha
                    ddlMaDuong.SelectedValue = .MaDuong
                    ddlMaPhuong.SelectedValue = .MaPhuong
                    txtTuNgay.Text = .TuNgay
                    txtDenNgay.Text = .DenNgay

                    txtSoGiayPhep.Text = .SoGiayPhep
                    txtTenDoanhNghiep.Text = .TenDoanhNghiep
                    ddlMaLoaiHinhDoanhNghiep.SelectedValue = .MaLoaiHinhDoanhNghiep
                    ddlHoatDong.SelectedValue = .HoatDong
                    txtMatHangKinhDoanh.Text = .MatHangKinhDoanh
                End With
            Else
                getValues()
            End If
        End Sub
        Private Sub getValues()
            Dim TKDVTT As New TimKiemDonViTrucThuocInfo
            With TKDVTT
                .NguoiDungDau = txtNguoiDungDau.Text
                .SoNha = txtSoNha.Text
                .MaDuong = ddlMaDuong.SelectedValue
                .MaPhuong = ddlMaPhuong.SelectedValue
                .TuNgay = txtTuNgay.Text
                .DenNgay = txtDenNgay.Text

                .SoGiayPhep = txtSoGiayPhep.Text
                .TenDoanhNghiep = txtTenDoanhNghiep.Text
                .MaLoaiHinhDoanhNghiep = ddlMaLoaiHinhDoanhNghiep.SelectedValue
                .HoatDong = ddlHoatDong.SelectedValue
                .MatHangKinhDoanh = txtMatHangKinhDoanh.Text
                .URL = EditURL() + "&ID="
            End With
            Session.Item("TimKiemDonViTrucThuocInfo") = TKDVTT
        End Sub

        Private Sub LoadGrid()
            If txtSoDong.Text = "" Then
                dgdDanhSach.PageSize = GetSoDongHienThiLuoi()
                txtSoDong.Text() = CStr(GetSoDongHienThiLuoi())
            End If

            Dim TKDVTTCon As New TimKiemDonViTrucThuocController
            Dim dsDVTT As DataSet
            dsDVTT = TKDVTTCon.LayDanhSachDonViTrucThuoc(CType(Session.Item("TimKiemDonViTrucThuocInfo"), TimKiemDonViTrucThuocInfo))
            BindControl.BindGrdHoSo(dsDVTT, dgdDanhSach, False, "Số GCN ĐKKD,Tên doanh nghiệp,Loại hình DN,Người đại diện,Ngày cấp,Tình trạng", "100,350,200,150,100,100,100", False, True)
            If Not dsDVTT Is Nothing Then
                lblTongSoHoSo.Text = CStr(dsDVTT.Tables(0).Rows.Count)
            End If
        End Sub
        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            getValues()
            LoadGrid()
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
    End Class
End Namespace
