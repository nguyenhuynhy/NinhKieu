Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH
Namespace CPKTQH
    Public Class ThayDoiKinhDoanh
        Inherits PortalQH.PortalModuleControl
        'Private Shared IsAddNew As Boolean
        Private strControl As String
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDanhSachGP As System.Web.UI.WebControls.Label
        Protected WithEvents lblDanhSach As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNhaMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuongMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuongMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanhCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBangHieuCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVonKinhDoanhCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNhaCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuongCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuongCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaNganhKinhDoanhCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaNganhKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDiaChiCuCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDiaChiCu As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDiaChiCuMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhoneCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkPhone As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtPhoneMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFaxCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkFax As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtFaxMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEmailCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkEmail As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtEmailMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebsiteCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkWebsite As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtWebSiteMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkHoTenCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtHoTenCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinhCNCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkGioiTinhCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlGioiTinhCNMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgaySinhCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNgaySinhCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNgaySinhCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTruCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDiaChiThuongTruCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDiaChiThuongTruCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNayCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkChoOHienNayCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtChoOHienNayCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMNDCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkSoCMNDCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtSoCMNDCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMNDCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMNDCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMNDCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNoiCapCMNDCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNoiCapCMNDCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanTocCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanTocCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents chkNgayCapCMNDCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkDanTocCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaSoLanhDaoMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnKiemTra As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblKetQuaKiemTraBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaKiemTraDiaChiDKKD As System.Web.UI.WebControls.Label
        Protected WithEvents lblKiemTra As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaThongTin As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaVPHC As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaNganhCam As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaNganhDieuKien As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabelDonViTinhCu As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabelDonViTinhMoi As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaPhuongThucKinhDoanhCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuongThucKinhDoanhMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaNganhKinhDoanhMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents hplDanhSachBangHieu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtQuocTichCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkQuocTich As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtQuocTichMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTenGiayChungThucCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkTenGiayChungThuc As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtTenGiayChungThucMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayChungThucCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkSoGiayChungThuc As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtSoGiayChungThucMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNgayCapGiayChungThuc As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNgayCapGiayChungThucMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapGiayChungThucCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNoiCapGiayChungThuc As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNoiCapGiayChungThucMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDKBS As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayDangKyBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtThanhVienIDXoa As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkTongSoLaoDong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNgayCapGiayChungThucCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDoiSo As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtTongSoLaoDongCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLaoDongMoi As System.Web.UI.WebControls.TextBox
        Private bFlag As Boolean
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgNgayCapDKKD As System.Web.UI.WebControls.Image
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblCMNDCu As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkSoNha As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkMaDuong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkMaPhuong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkMatHangKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtMatHangKinhDoanhMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkBangHieu As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtBangHieuMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkVonKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtVonKinhDoanhMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoLanThayDoi As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Hàm sự kiện"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            strControl = Request.Params("ctl")

            btnDanhSachGP.Visible = True
            lblTieuDe.Text = "Thay đổi nội dung kinh doanh"

            If Not Me.IsPostBack Then
                InitState()
                loadDataToControl()
                SetAttribute()

                '---Lay thong tin ve ho so tiep nhan
                If Not Request.Params("ID") Is Nothing Then
                    txtHoSoTiepNhanID.Text = Request.Params("ID")
                    Dim objHoSoTiepNhan As New HoSoTiepNhanController
                    Dim ds As New DataSet
                    ds = objHoSoTiepNhan.GetChiTietHoSoTiepNhan(txtHoSoTiepNhanID.Text)
                    txtHoTenNguoiNop.Text = ds.Tables(0).Rows(0).Item("HoTenNguoiNop")
                    txtSoBienNhan.Text = ds.Tables(0).Rows(0).Item("SoBienNhan")
                End If

                '--Lay so giay phep di ke`m voi HSTN trong table THAYDOI
                GetSoGiayPhep()

                '--Lay Thong tin giay CNDKKD cua giay phep tren neu co
                If Trim(txtSoGiayPhep.Text) <> "" Then 'Da co data
                    ViewState("isAddNew") = False
                    GetGiayCNDKKD()
                Else 'Chua co data
                    ViewState("isAddNew") = True

                End If
            End If

            hiddenAllButton()
            '--Cap nhat trang thai cac control
            If CBool(ViewState("isAddNew")) Then 'New la them moi
                If CheckHoSoBoSung(Request.Params("ID")) Then 'Neu la ho so da bo sung
                    btnYCBS.Visible = True
                    btnYCBS_Click(Nothing, Nothing)
                ElseIf CheckHoSoKhongGiaiQuyet(Request.Params("ID")) Then 'Neu la ho so khong giai quyet
                    btnHoSoKhong.Visible = True
                    btnHoSoKhong_Click(Nothing, Nothing)
                Else
                    btnHoSoKhong.Visible = True
                    btnYCBS.Visible = True
                    btnCapNhat.Visible = True
                End If

                lblDanhSachGP.Visible = False
                btnDanhSachGP.Visible = True
                txtSoGiayPhep.ReadOnly = False
            Else ' Neu la cap nhat
                If CheckHoSoDeXuat(Request.Params("ID")) Then 'Neu la ho so da de xuat
                    btnDeXuat.Visible = True
                    btnIn.Visible = True
                    btnCapNhat.Visible = True
                    Me.chkDoiSo.Visible = True
                Else
                    btnDeXuat.Visible = True
                    btnCapNhat.Visible = True
                    btnXoa.Visible = True
                End If

                lblDanhSachGP.Visible = True
                btnDanhSachGP.Visible = False
                txtSoGiayPhep.ReadOnly = True
            End If
            txtNgayThayDoi.Attributes.Add("ISNULL", "NOTNULL")
            InitLabelKiemTra()
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", CStr(Session.Item("ActiveDB")), btnIn, Me)
            'Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganhKinhDoanhMoi))
            If ddlMaNganhKinhDoanhMoi.SelectedValue <> "" Then
                Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganhKinhDoanhMoi))
                'ddlMaNganh.Attributes.Add("ISNULL", "NOTNNULL")
            End If
        End Sub
        Private Sub txtSoGiayPhep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoGiayPhep.TextChanged
            GetGiayCNDKKD()
        End Sub
        Private Sub btnDanhSach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDanhSach.Click
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl")), True)
        End Sub
        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            'HoangLN
            '---------------------Thay doi----------------------
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            objThayDoiCon.UpdateThayDoi( _
                    txtNgayThayDoi.Text.Replace("'", "''"), _
                    txtGiayCNDKKDID.Text.Replace("'", "''"), _
                    CStr(Request.Params("ID")), _
                    txtGhiChu.Text.Replace("'", "''"), _
                    txtSoLanThayDoi.Text.Replace("'", "''") _
            )
            '---------------------Thay doi chi tiet -----------------
            Dim TenTruong, NoiDungCu, NoiDungMoi As String
            Dim ctrl As Control
            For Each ctrl In Me.Controls
                Select Case True
                    Case TypeOf ctrl Is CheckBox
                        If CType(ctrl, CheckBox).Checked Then
                            TenTruong = Mid(ctrl.ID, 4)
                            If TenTruong.ToString <> "DoiSo" Then
                                NoiDungMoi = GetNoiDung(TenTruong & "Moi", Me)

                                objThayDoiCon.UpdateThayDoiChiTiet( _
                                        txtGiayCNDKKDID.Text, _
                                        txtSoLanThayDoi.Text.Replace("'", "''"), _
                                        TenTruong, _
                                        NoiDungMoi)
                                'reset
                                CType(ctrl, CheckBox).Checked = False
                            End If
                            'reset
                        End If
                End Select
            Next
            'Cap nhat Lanh dao
            NoiDungMoi = ddlMaSoLanhDaoMoi.SelectedValue
            objThayDoiCon.UpdateThayDoiChiTiet( _
                    txtGiayCNDKKDID.Text, _
                    txtSoLanThayDoi.Text.Replace("'", "''"), _
                    "MASOLANHDAO", _
                    NoiDungMoi)

            objThayDoiCon.UpdateGCNDKKD( _
                    txtGiayCNDKKDID.Text, _
                    txtBangHieuMoi.Text.Replace("'", "''"), _
                    ddlMaNganhKinhDoanhMoi.SelectedValue, _
                    Nothing, _
                    txtVonKinhDoanhMoi.Text.Replace("'", "''"), _
                    txtMatHangKinhDoanhMoi.Text.Replace("'", "''"), _
                    txtSoNhaMoi.Text.Replace("'", "''"), _
                    ddlMaDuongMoi.SelectedValue, _
                    ddlMaPhuongMoi.SelectedValue, _
                    txtDiaChiCuMoi.Text.Replace("'", "''"), _
                    txtPhoneMoi.Text.Replace("'", "''"), _
                    txtFaxMoi.Text.Replace("'", "''"), _
                    txtEmailMoi.Text.Replace("'", "''"), _
                    txtWebSiteMoi.Text.Replace("'", "''"), _
                    ddlMaSoLanhDaoMoi.SelectedValue, _
                    txtHoTenCNMoi.Text.Replace("'", "''"), _
                    ddlGioiTinhCNMoi.SelectedValue, _
                    txtNgaySinhCNMoi.Text.Replace("'", "''"), _
                    txtDiaChiThuongTruCNMoi.Text.Replace("'", "''"), _
                    txtChoOHienNayCNMoi.Text.Replace("'", "''"), _
                    txtSoCMNDCNMoi.Text.Replace("'", "''"), _
                    txtNgayCapCMNDCNMoi.Text.Replace("'", "''"), _
                    txtNoiCapCMNDCNMoi.Text.Replace("'", "''"), _
                    txtDanTocCNMoi.Text.Replace("'", "''"), _
                    txtQuocTichMoi.Text.Replace("'", "''"), _
                    txtTenGiayChungThucMoi.Text.Replace("'", "''"), _
                    txtSoGiayChungThucMoi.Text.Replace("'", "''"), _
                    txtNgayCapGiayChungThucMoi.Text.Replace("'", "''"), _
                    txtNoiCapGiayChungThucMoi.Text.Replace("'", "''"), _
                    txtTongSoLaoDongMoi.Text.Replace("'", "''"), _
                    ddlMaPhuongThucKinhDoanhMoi.SelectedValue _
            )

            '--Thay doi theo thong tu 01/2009 cua Bo ke hoach va dau tu
            '-----------------------Cap nhat thay doi thanh vien------------
            Dim objCapCNDKKD As New GiayCNDKKDController
            'cap nhat thong tin thanh vien gop von
            Dim grdItem As DataGridItem
            For Each grdItem In dgdDanhSach.Items

                'lay thong tin du lieu dau vao
                Dim chkChon As HtmlInputCheckBox = CType(grdItem.FindControl("chkChon"), HtmlInputCheckBox)
                Dim objTenThanhVien As HtmlInputText = CType(grdItem.FindControl("txtTenThanhVien"), HtmlInputText)
                Dim objThanhVienThuongTru As HtmlInputText = CType(grdItem.FindControl("txtThanhVienThuongTru"), HtmlInputText)
                Dim objGiaTriGopVon As HtmlInputText = CType(grdItem.FindControl("txtGiaTriGopVon"), HtmlInputText)
                Dim objTyLeGopVon As HtmlInputText = CType(grdItem.FindControl("txtTyLeGopVon"), HtmlInputText)
                Dim objThanhVienCMND As HtmlInputText = CType(grdItem.FindControl("txtThanhVienCMND"), HtmlInputText)
                Dim objThanhVienGhiChu As HtmlInputText = CType(grdItem.FindControl("txtThanhVienGhiChu"), HtmlInputText)

                'Cap nhat du lieu xuong database
                If chkChon.Checked = True And objTenThanhVien.Value <> "" And objThanhVienCMND.Value <> "" Then
                    objCapCNDKKD.THAYDOI_THANHVIENHKD_Upd(grdItem.Cells(0).Text.ToString().Replace("&nbsp;", ""), objTenThanhVien.Value, objThanhVienThuongTru.Value, objGiaTriGopVon.Value, objTyLeGopVon.Value, objThanhVienCMND.Value, objThanhVienGhiChu.Value, Request.QueryString("ID").ToString(), txtSoGiayPhep.Text)
                End If

            Next
            'Cap nhat xoa thong tin thay doi thanh vien gop von
            If txtThanhVienIDXoa.Text.Replace(",", "").Trim() <> "" Then
                objCapCNDKKD.THAYDOI_THANHVIENHKD_Del(txtThanhVienIDXoa.Text)
            End If
            ViewState("isAddNew") = False
            '-----------------------Cap nhat trang thai cac nut------------
            lblDanhSachGP.Visible = True
            btnDanhSachGP.Visible = False
            txtSoGiayPhep.ReadOnly = True

            btnXoa.Visible = Not CBool(ViewState("isAddNew"))
            btnDeXuat.Visible = btnXoa.Visible
            btnIn.Visible = btnXoa.Visible
            btnHoSoKhong.Visible = Not btnXoa.Visible
            btnYCBS.Visible = Not btnXoa.Visible
            '--------------------------------------------------------------

            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            objThayDoiCon.DelThayDoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub btnYCBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYCBS.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG") & "&oldControl=" & strControl, True)
            End If
        End Sub
        Private Sub btnHoSoKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtHoSoTiepNhanID.Text
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & strControl, True)
            End If
        End Sub
        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=DX&oldControl=" & strControl, True)
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Try

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            'Dim objGiayCNDKKD As New GiayCNDKKDController
            'Dim ds As New DataSet
            'Dim Script As String
            'Dim strTemplateFileName As String
            'Dim strOutputFileName As String

            'strTemplateFileName = GetParamByID("FileGiayCNDKKD", glbXMLFile)
            'strOutputFileName = "GiayCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            'ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID.Text)
            'Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            'Page.RegisterStartupScript("OpenWindow", Script)

            'objGiayCNDKKD = Nothing
            'ds = Nothing
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String
            If chkDoiSo.Checked = True Then
                ds = objGiayCNDKKD.InGiayCNDKKD_DoiSo(txtGiayCNDKKDID.Text, txtSoGiayPhep.Text)
                'Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", InGiayCNDKKD(Request, ds, GetLinhVuc()))
            Else
                ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID.Text)
                'Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", InGiayCNDKKD(Request, ds, GetLinhVuc()))
            End If
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", InGiayCNDKKD(Request, ds, GetLinhVuc()))
            Page.RegisterStartupScript("OpenWindow", Script)

            objGiayCNDKKD = Nothing
            ds = Nothing
        End Sub

        Private Sub btnKiemTra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKiemTra.Click

            Dim ds As DataSet
            Dim objKiemTraInfo As New KiemTraHoSoInfo
            Dim objKiemTra As New KiemTraHoSoController
            Dim strKetQuaKiemTra As String

            If Not Session("TimKiemGiayCNDKKD") Is Nothing Then
                Session("TimKiemGiayCNDKKD") = Nothing
            End If

            With objKiemTraInfo
                .GiayCNDKKDID = txtGiayCNDKKDID.Text
                .BangHieu = txtBangHieuMoi.Text
                .HoTen = txtHoTenCNMoi.Text
                .SoCMND = txtSoCMNDCNMoi.Text
                .SoNha = Trim(txtSoNhaMoi.Text)
                .MaDuong = ddlMaDuongMoi.SelectedValue
                .MaPhuong = ddlMaPhuongMoi.SelectedValue
                .MaNganh = ddlMaNganhKinhDoanhMoi.SelectedValue
                .DiaChiThuongTru = Trim(txtDiaChiThuongTruCNMoi.Text)
            End With

            'kiểm tra bảng hiệu
            If chkBangHieu.Checked = True And Trim(txtBangHieuMoi.Text) <> "" Then
                'lblKetQuaKiemTraBangHieu.Text = "- Bảng hiệu này chưa được sử dụng"
                ds = objKiemTra.KiemTraBangHieu(objKiemTraInfo)
                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            lblKetQuaKiemTraBangHieu.Text = "- Bảng hiệu này đã được đăng ký"
                            Dim strURL As String
                            strURL = glbFilePath_BangHieu
                            strURL = strURL & "?BangHieu=" & objKiemTraInfo.BangHieu
                            hplDanhSachBangHieu.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');return false;")
                            hplDanhSachBangHieu.Visible = True
                        End If
                    End If
                End If
            End If

            'kiểm tra địa điểm DKKD
            If chkSoNha.Checked = True Or chkMaDuong.Checked = True Or chkMaPhuong.Checked = True Then
                If objKiemTraInfo.SoNha <> "" Or objKiemTraInfo.MaDuong <> "" Or objKiemTraInfo.MaPhuong <> "" Then
                    If Not objKiemTra.KiemTraDiaChiDKKD(objKiemTraInfo) Then
                        lblKetQuaKiemTraDiaChiDKKD.Text = "Địa chỉ này đã được đăng ký kinh doanh"
                    End If
                End If
            End If

            'kiểm tra CMND/Passport
            If chkSoCMNDCN.Checked = True And objKiemTraInfo.SoCMND <> "" Then
                If Not objKiemTra.KiemTraSoCMND(objKiemTraInfo) Then
                    lblKetQuaKiemTraDiaChiDKKD.Text = "Số CMND/Passport này đã được đăng ký kinh doanh"
                End If
            End If

            'kiểm tra người đăng ký
            If chkHoTenCN.Checked = True Then
                If objKiemTraInfo.HoTen <> "" Or objKiemTraInfo.SoCMND <> "" Then
                    lblKetQuaThongTin.Text = objKiemTra.KiemTraNguoiDangKy(objKiemTraInfo)
                End If
            End If

            'kiểm tra vi phạm hành chính
            If objKiemTraInfo.SoGiayPhep <> "" Or objKiemTraInfo.SoCMND <> "" _
                Or (objKiemTraInfo.SoNha <> "" And objKiemTraInfo.MaPhuong <> "") Then
                'lblKetQuaVPHC.Text = "- Địa chỉ, người đứng tên không vi phạm hành chính"
                ds = objKiemTra.KiemTraViPhamHanhChinh(objKiemTraInfo)
                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            lblKetQuaVPHC.Text = "- Số giấy phép/ Địa chỉ ĐKKD/ Ngươi đăng ký có vi phạm hành chính"
                        End If
                    End If
                End If
            End If

            'kiểm tra ngành cấm kinh doanh
            If chkMaNganhKinhDoanh.Checked = True And objKiemTraInfo.MaNganh <> "" Then
                'lblKetQuaNganhCam.Text = "- Ngành đăng ký không thuộc phạm vi cấm kinh doanh"
                ds = objKiemTra.KiemTraNganhCamKD(objKiemTraInfo)
                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            lblKetQuaNganhCam.Text = "- Ngành đăng ký thuộc phạm vi cấm kinh doanh"
                        End If
                    End If
                End If
            End If

            'kiểm tra ngành kinh doanh có điều kiện
            If chkMaNganhKinhDoanh.Checked = True And objKiemTraInfo.MaNganh <> "" Then
                'lblKetQuaNganhDieuKien.Text = "- Ngành đăng ký không thuộc ngành kinh doanh có điều kiện"
                ds = objKiemTra.KiemTraNganhKDCoDieuKien(objKiemTraInfo)
                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            lblKetQuaNganhDieuKien.Text = "- Ngành đăng ký thuộc ngành kinh doanh có điều kiện"
                        End If
                    End If
                End If
            End If

            lblKiemTra.Visible = True
            'trường hợp không vi phạm
            If lblKetQuaKiemTraBangHieu.Text = "" _
                    And lblKetQuaKiemTraDiaChiDKKD.Text = "" _
                    And lblKetQuaThongTin.Text = "" _
                    And lblKetQuaVPHC.Text = "" _
                    And lblKetQuaNganhCam.Text = "" _
                    And lblKetQuaNganhDieuKien.Text = "" Then
                lblKetQuaThongTin.Text = "Hồ sơ đăng ký không vi phạm"
            End If
            objKiemTraInfo = Nothing
            objKiemTra = Nothing
            ds = Nothing
        End Sub
#End Region

#Region "Hàm hỗ trợ"
        Private Sub SetAttribute()
            'Javascript
            chkTongSoLaoDong.Attributes.Add("onclick", "javascript:SetStatus('" & chkTongSoLaoDong.ClientID & "','" & txtTongSoLaoDongMoi.ClientID & "');") 'TUNGLDL
            chkBangHieu.Attributes.Add("onclick", "javascript:SetStatus('" & chkBangHieu.ClientID & "','" & txtBangHieuMoi.ClientID & "');")
            chkMaNganhKinhDoanh.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaNganhKinhDoanh.ClientID & "','" & ddlMaNganhKinhDoanhMoi.ClientID & "');")
            'chkMaHinhThucKinhDoanh.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaHinhThucKinhDoanh.ClientID & "','" & ddlMaHinhThucKinhDoanhMoi.ClientID & "');")
            chkVonKinhDoanh.Attributes.Add("onclick", "javascript:SetStatus('" & chkVonKinhDoanh.ClientID & "','" & txtVonKinhDoanhMoi.ClientID & "');")
            chkMatHangKinhDoanh.Attributes.Add("onclick", "javascript:SetStatus('" & chkMatHangKinhDoanh.ClientID & "','" & txtMatHangKinhDoanhMoi.ClientID & "');")
            chkSoNha.Attributes.Add("onclick", "javascript:SetStatus('" & chkSoNha.ClientID & "','" & txtSoNhaMoi.ClientID & "');")
            chkMaDuong.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaDuong.ClientID & "','" & ddlMaDuongMoi.ClientID & "');")
            chkMaPhuong.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaPhuong.ClientID & "','" & ddlMaPhuongMoi.ClientID & "');")
            chkDiaChiCu.Attributes.Add("onclick", "javascript:SetStatus('" & chkDiaChiCu.ClientID & "','" & txtDiaChiCuMoi.ClientID & "');")
            chkPhone.Attributes.Add("onclick", "javascript:SetStatus('" & chkPhone.ClientID & "','" & txtPhoneMoi.ClientID & "');")
            chkFax.Attributes.Add("onclick", "javascript:SetStatus('" & chkFax.ClientID & "','" & txtFaxMoi.ClientID & "');")
            chkEmail.Attributes.Add("onclick", "javascript:SetStatus('" & chkEmail.ClientID & "','" & txtEmailMoi.ClientID & "');")
            chkWebsite.Attributes.Add("onclick", "javascript:SetStatus('" & chkWebsite.ClientID & "','" & txtWebSiteMoi.ClientID & "');")
            chkHoTenCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkHoTenCN.ClientID & "','" & txtHoTenCNMoi.ClientID & "');")
            chkGioiTinhCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkGioiTinhCN.ClientID & "','" & ddlGioiTinhCNMoi.ClientID & "');")
            chkNgaySinhCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkNgaySinhCN.ClientID & "','" & txtNgaySinhCNMoi.ClientID & "');")
            chkDiaChiThuongTruCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkDiaChiThuongTruCN.ClientID & "','" & txtDiaChiThuongTruCNMoi.ClientID & "');")
            chkChoOHienNayCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkChoOHienNayCN.ClientID & "','" & txtChoOHienNayCNMoi.ClientID & "');")
            chkSoCMNDCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkSoCMNDCN.ClientID & "','" & txtSoCMNDCNMoi.ClientID & "');")
            chkNgayCapCMNDCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkNgayCapCMNDCN.ClientID & "','" & txtNgayCapCMNDCNMoi.ClientID & "');")
            chkNoiCapCMNDCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkNoiCapCMNDCN.ClientID & "','" & txtNoiCapCMNDCNMoi.ClientID & "');")
            chkDanTocCN.Attributes.Add("onclick", "javascript:SetStatus('" & chkDanTocCN.ClientID & "','" & txtDanTocCNMoi.ClientID & "');")


            txtVonKinhDoanhMoi.Attributes.Add("onblur", "javascript:ConvertNumericVN(" & _
                                                                txtVonKinhDoanhMoi.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")

            'txtSoCMNDCNMoi.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMNDCNMoi.ClientID & ");")

            txtNgaySinhCNMoi.Attributes.Add("onblur", "javascript:KiemTraNamSinhDKKD(" & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinhCNMoi);")
            Me.txtNgaySinhCNMoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgaySinhCNMoi.ClientID & ");")
            Me.txtNgaySinhCNMoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayCapCMNDCNMoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMNDCNMoi);")
            Me.txtNgayCapCMNDCNMoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapCMNDCNMoi.ClientID & ");")
            Me.txtNgayCapCMNDCNMoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayThayDoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayThayDoi);")
            Me.txtNgayThayDoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayThayDoi.ClientID & ");")
            Me.txtNgayThayDoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayCapGiayChungThucMoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapGiayChungThucMoi);")
            Me.txtNgayCapGiayChungThucMoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapGiayChungThucMoi.ClientID & ");")
            Me.txtNgayCapGiayChungThucMoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            btnCapNhat.Attributes.Add("onclick", "return btnCapNhat_clicked()")

            Dim strURL As String
            strURL = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"
            'btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');return false;")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay ?');")



        End Sub
        Private Sub InitState()
            Dim dsLinhVuc As New DataSet
            Dim dsPhuongThuc As New DataSet
            Dim dsNganh As New DataSet
            Dim objNganhKD As New NganhKinhDoanhController
            dsLinhVuc = objNganhKD.getLinhVucCapPhep()
            dsPhuongThuc = objNganhKD.getPhuongThucKinhDoanh()
            'dsNganh = objNganhKD.getNganhKinhDoanhChinh
            dsNganh = objNganhKD.getPhuongThucNganhNghe
            objNganhKD = Nothing
            'ThuyTT end

            ddlMaPhuongThucKinhDoanhMoi.DataSource = dsPhuongThuc
            ddlMaPhuongThucKinhDoanhMoi.DataTextField = "TenLinhVuc"
            ddlMaPhuongThucKinhDoanhMoi.DataValueField = "MaLinhVuc"
            ddlMaPhuongThucKinhDoanhMoi.DataBind()
            ddlMaPhuongThucKinhDoanhMoi.Items.Insert(0, "")

            BindControl.BindDropDownList(ddlMaPhuongThucKinhDoanhCu, "DMPHUONGTHUCKINHDOANH", , , 0)
            BindControl.BindDropDownList(ddlMaNganhKinhDoanhCu, "DMNGANHKINHDOANH", , , 0)

            ddlMaNganhKinhDoanhMoi.DataSource = dsNganh
            ddlMaNganhKinhDoanhMoi.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanhMoi.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanhMoi.DataBind()
            ddlMaNganhKinhDoanhMoi.Items.Insert(0, "")
            With ctrlScriptComboFilter
                '.ConditionID = ddlMaLinhVucCapPhep.ClientID
                .ConditionID = ddlMaPhuongThucKinhDoanhMoi.ClientID
                .ConditionText = "TenLinhVuc"
                .ConditionValue = "MaLinhVuc"

                .ResultID = ddlMaNganhKinhDoanhMoi.ClientID
                .ResultText = "TenNganh"
                .ResultValue = "MaNganh"
                .ConditionDS = dsLinhVuc
                .ResultDS = dsNganh
            End With
            dsLinhVuc = Nothing
            dsNganh = Nothing
            ddlMaPhuongThucKinhDoanhMoi.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")


        End Sub

        Private Function GetNoiDung(ByVal strTenTruong As String, ByVal obj As Object) As String
            'ham nay de lay noi dung cua control
            Dim ctrl As Control
            For Each ctrl In Me.Controls
                Select Case True
                    Case TypeOf ctrl Is TextBox
                        If UCase(Mid(ctrl.ID, 4)) = UCase(strTenTruong) Then
                            Return CType(ctrl, TextBox).Text
                        End If
                    Case TypeOf ctrl Is DropDownList
                        If UCase(Mid(ctrl.ID, 4)) = UCase(strTenTruong) Then
                            Return CType(ctrl, DropDownList).SelectedValue
                        End If
                End Select
            Next
        End Function
        Private Function CheckHoSoDeXuat(ByVal strID As String) As Boolean
            Dim objHoSoThamDinh As New ThamDinhDeXuatController
            CheckHoSoDeXuat = objHoSoThamDinh.CheckKiemTraDeXuat(strID)
        End Function
        Private Function CheckHoSoBoSung(ByVal strID As String) As Boolean
            Dim objHoSoThamDinh As New ThamDinhDeXuatController
            Return objHoSoThamDinh.CheckKiemTraBoSung(strID)
        End Function
        Private Function CheckHoSoKhongGiaiQuyet(ByVal strID As String) As Boolean
            Dim objHoSoThamDinh As New ThamDinhDeXuatController
            Return objHoSoThamDinh.CheckKiemTraKhongGiaiQuyet(strID)
        End Function
        Private Sub hiddenAllButton()
            btnCapNhat.Visible = False
            btnXoa.Visible = False
            btnDeXuat.Visible = False
            btnHoSoKhong.Visible = False
            btnYCBS.Visible = False
            btnIn.Visible = False
        End Sub

        Private Sub InitLabelKiemTra()
            hplDanhSachBangHieu.Visible = False
            lblKiemTra.Visible = False
            lblKetQuaKiemTraBangHieu.Text = ""
            lblKetQuaKiemTraDiaChiDKKD.Text = ""
            lblKetQuaThongTin.Text = ""
            lblKetQuaVPHC.Text = ""
            lblKetQuaNganhCam.Text = ""
            lblKetQuaNganhDieuKien.Text = ""
        End Sub
#End Region

#Region "Các hàm dữ liệu"
        Private Sub GetSoGiayPhep()
            'Get so giay phep tu so bien nhan
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            txtSoGiayPhep.Text = objThayDoiCon.GetSoGiayPhep(txtSoBienNhan.Text)
            'Lay thong tin danh sach thanh vien
            Dim objCapCNDKKD As New GiayCNDKKDController
            Dim dsThanhVien As DataSet
            dsThanhVien = objCapCNDKKD.THANHVIENHKD_GetByTiepNhanID(Request.QueryString("ID"))
            'default one row in grid
            If Not dsThanhVien.Tables(0) Is Nothing Then
                If dsThanhVien.Tables(0).Rows.Count > 0 Then
                    Me.MakeCart(dsThanhVien)
                Else
                    Me.MakeCart(Nothing)
                End If
            Else
                Me.MakeCart(Nothing)
            End If

            'dispose object
            dsThanhVien = Nothing
            objThayDoiCon = Nothing
            objCapCNDKKD = Nothing
        End Sub
        Private Sub loadDataToControl()
            strControl = Request.Params("ctl")
            Dim dsLinhVuc As New DataSet
            Dim dsNganh As New DataSet
            Dim objDanhMuc As New DanhMucController

            BindControl.BindDropDownList(ddlMaDuongCu, "DMDUONG")
            BindControl.BindDropDownList(ddlMaDuongMoi, "DMDUONG")

            BindControl.BindDropDownList(ddlMaPhuongCu, "DMPHUONG")
            BindControl.BindDropDownList(ddlMaPhuongMoi, "DMPHUONG")

            'BindControl.BindDropDownList(ddlMaHinhThucKinhDoanhCu, "DMHINHTHUCKINHDOANH")
            'BindControl.BindDropDownList(ddlMaHinhThucKinhDoanhMoi, "DMHINHTHUCKINHDOANH")

            Dim strNguoiKy As String
            strNguoiKy = GetParamByID("nguoiky", glbXMLFile)
            'BindDropDownList_NguoiKy(ddlMaSoLanhDaoMoi)
            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDaoMoi, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))
            'ddlMaSoLanhDaoMoi.DataSource = objDanhMuc.getDanhSachNguoiKy(strNguoiKy)
            'ddlMaSoLanhDaoMoi.DataTextField = "Ten"
            'ddlMaSoLanhDaoMoi.DataValueField = "Ma"
            'ddlMaSoLanhDaoMoi.DataBind()

            'ddlMaNganhKinhDoanhCu.DataSource = objDanhMuc.GetDanhMucList("DMNGANHKINHDOANHBYLINHVUC")
            'ddlMaNganhKinhDoanhCu.DataTextField = "TenNganh"
            'ddlMaNganhKinhDoanhCu.DataValueField = "MaNganh"
            'ddlMaNganhKinhDoanhCu.DataBind()
            'ddlMaNganhKinhDoanhCu.Items.Insert(0, "")

            'ddlMaNganhKinhDoanhMoi.DataSource = objDanhMuc.GetDanhMucList("DMNGANHKINHDOANHBYLINHVUC")
            'ddlMaNganhKinhDoanhMoi.DataTextField = "TenNganh"
            'ddlMaNganhKinhDoanhMoi.DataValueField = "MaNganh"
            'ddlMaNganhKinhDoanhMoi.DataBind()
            'ddlMaNganhKinhDoanhMoi.Items.Insert(0, "")

            If txtNgayThayDoi.Text = "" Then
                txtNgayThayDoi.Text = NgayHienTai()
            End If
            lblLabelDonViTinhCu.Text = getLabelDonViTinh()
            lblLabelDonViTinhMoi.Text = lblLabelDonViTinhCu.Text
        End Sub
        Private Sub GetGiayCNDKKD()
            'Get GiayCNDKKD tu so Giay Phep
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep(txtSoGiayPhep.Text.Replace("'", "''"))
            If ds.Tables(0).Rows.Count > 0 Then 'Co data
                txtGiayCNDKKDID.Text = ds.Tables(0).Rows(0).Item("GiayCNDKKDID")
                txtNgayCap.Text = ds.Tables(0).Rows(0).Item("NgayCap")
                Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
                ViewState("SoLanThayDoi") = ds.Tables(0).Rows(0).Item("SoLanThayDoi")

                If CBool(ViewState("isAddNew")) Then
                    txtSoLanThayDoi.Text = (CInt(ViewState("SoLanThayDoi")) + 1).ToString()
                Else
                    txtSoLanThayDoi.Text = ViewState("SoLanThayDoi")
                End If

                '-- Load thong tin thay doi Cu & Moi
                LoadThongTinThayDoi()
                '-------------------------------------
                'Lay thong tin danh sach thanh vien
                Dim objCapCNDKKD As New GiayCNDKKDController
                Dim dsThanhVien As DataSet
                'dsThanhVien = objCapCNDKKD.THANHVIENHKD_GetByTiepNhanID(ds.Tables(0).Rows(0).Item("HoSoTiepNhanID"))
                dsThanhVien = objCapCNDKKD.THANHVIENHKD_GetByGiayCNDKKDID(ds.Tables(0).Rows(0).Item("GiayCNDKKDID"))
                'default one row in grid
                If Not dsThanhVien.Tables(0) Is Nothing Then
                    If dsThanhVien.Tables(0).Rows.Count > 0 Then
                        Me.MakeCart(dsThanhVien)
                    Else
                        dsThanhVien = objCapCNDKKD.THANHVIENHKD_GetByTiepNhanID(Request.QueryString("ID"))
                        If dsThanhVien.Tables(0).Rows.Count > 0 Then
                            Me.MakeCart(dsThanhVien)
                        Else
                            Me.MakeCart(Nothing)
                        End If
                    End If
                Else
                    Me.MakeCart(Nothing)
                End If


            Else
                '--Neu khong co du lieu thi` clear all textbox
                Dim strMid As String = Request.QueryString("mid")
                Dim strCtl As String = Request.QueryString("ctl")
                Dim strID As String = Request.QueryString("ID")
                Dim strMaLV As String = Request.QueryString("Malv")
                Dim strTenLV As String = Request.QueryString("Tenlv")
                Dim strAddNew As String = Request.QueryString("AddNew")
                Dim strURL As String = ApplicationURL()

                strURL += "&mid=" + strMid + "&ctl=" + strCtl + "&ID=" + strID + "&Malv=" + strMaLV + "&Tenlv=" + strTenLV + "&AddNew=" + strAddNew
                Response.Redirect(strURL)

            End If

        End Sub
        Private Sub LoadThongTinThayDoi()
            'Load thong tin thay doi cua sogiayphep + lanthaydoi
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            Dim dsThayDoi As New DataSet
            dsThayDoi = objThayDoiCon.GetThongTinThayDoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            If dsThayDoi.Tables(0).Rows.Count > 0 Then
                txtGhiChu.Text = dsThayDoi.Tables(0).Rows(0).Item("GhiChu")
            Else
                txtGhiChu.Text = ""
            End If

            'ddlMaSoLanhDao.SelectedValue()
            '-----------------------------
            Dim dsThongTinCu As New DataSet
            dsThongTinCu = objThayDoiCon.GetThongTinDKKDCu(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            gLoadControlValues(dsThongTinCu, Me)
            '-----------------------------
            Dim dsThongTinMoi As New DataSet
            dsThongTinMoi = objThayDoiCon.GetThongTinDKKDMoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            gLoadControlValues(dsThongTinMoi, Me)

        End Sub
        Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New HSHC.HoSoBoSungController
            Dim dv As New DataView
            dv = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Return True
                Else
                    Return False
                End If
            End If
        End Function
#End Region

#Region "Thao tac du lieu voi CART"
        Private dtCart As System.Data.DataTable
        Private drCart As System.Data.DataRow
        '
        '==============================================================
        ' Make a new cart to save Chuyen xac minh's data
        ' Set default one empty row
        '==============================================================
        '
        Private Sub MakeCart(ByVal dsData As DataSet)
            'initialize data table
            dtCart = New System.Data.DataTable("Cart")
            dtCart.Columns.Add("ID", GetType(String))
            'dtCart.Columns.Add("ID", GetType(Integer))
            'dtCart.Columns("ID").AutoIncrement = True
            'dtCart.Columns("ID").AutoIncrementSeed = 1

            dtCart.Columns.Add("STT", GetType(Integer))
            dtCart.Columns.Add("TenThanhVien", GetType(String))
            dtCart.Columns.Add("ThanhVienThuongTru", GetType(String))
            dtCart.Columns.Add("GiaTriGopVon", GetType(String))
            dtCart.Columns.Add("TyLeGopVon", GetType(String))
            dtCart.Columns.Add("ThanhVienCMND", GetType(String))
            dtCart.Columns.Add("ThanhVienGhiChu", GetType(String))

            'save it to session object
            Session("Cart") = dtCart

            If Not dsData Is Nothing Then
                BindDataToCart(dsData)
            Else
                'add one row
                Me.AddToCart()
            End If
        End Sub


        '
        '==============================================================
        ' bind data to cart
        ' and re-bind data from cart to grid
        '==============================================================
        '
        Private Sub BindDataToCart(ByVal dsData As DataSet)
            Dim nCount As Integer
            'get data from session object
            dtCart = CType(Session("Cart"), DataTable)

            'delete all old data
            dtCart.Rows.Clear()

            For nCount = 0 To dsData.Tables(0).Rows.Count - 1
                'new row data
                drCart = dtCart.NewRow
                drCart("ID") = dsData.Tables(0).Rows(nCount)("ThanhVienID").ToString()
                drCart("TenThanhVien") = dsData.Tables(0).Rows(nCount)("TenThanhVien").ToString()
                drCart("ThanhVienThuongTru") = dsData.Tables(0).Rows(nCount)("ThanhVienThuongTru").ToString()
                drCart("GiaTriGopVon") = dsData.Tables(0).Rows(nCount)("GiaTriGopVon").ToString()
                drCart("TyLeGopVon") = dsData.Tables(0).Rows(nCount)("TyLeGopVon").ToString()
                drCart("ThanhVienCMND") = dsData.Tables(0).Rows(nCount)("ThanhVienCMND").ToString()
                drCart("ThanhVienGhiChu") = dsData.Tables(0).Rows(nCount)("ThanhVienGhiChu").ToString()
                dtCart.Rows.Add(drCart)
            Next

            'save data to session object
            Session("Cart") = dtCart

            'bind data to grid
            Me.BindGridData()
        End Sub


        '
        '==============================================================
        ' Add new row to cart
        ' and re-bind data from cart to grid
        '==============================================================
        '
        Private Sub AddToCart()
            'get data from session object
            dtCart = CType(Session("Cart"), DataTable)

            'new row data
            drCart = dtCart.NewRow
            drCart("TenThanhVien") = ""
            drCart("ThanhVienThuongTru") = ""
            drCart("GiaTriGopVon") = ""
            drCart("TyLeGopVon") = ""
            drCart("ThanhVienCMND") = ""
            drCart("ThanhVienGhiChu") = ""
            dtCart.Rows.Add(drCart)

            'save data to session object
            Session("Cart") = dtCart

            'bind data to grid
            Me.BindGridData()
        End Sub


        '
        '==============================================================
        ' Update item to cart
        ' and re-bind data from cart to grid
        '==============================================================
        '
        Private Sub UpdateItem(ByVal index As Integer, ByVal TenThanhVien As String, ByVal ThanhVienThuongTru As String, ByVal GiaTriGopVon As String, ByVal TyLeGopVon As String, ByVal ThanhVienCMND As String, ByVal ThanhVienGhiChu As String)
            dtCart = CType(Session("Cart"), DataTable)

            dtCart.Rows(index)("TenThanhVien") = TenThanhVien
            dtCart.Rows(index)("ThanhVienThuongTru") = ThanhVienThuongTru
            dtCart.Rows(index)("GiaTriGopVon") = GiaTriGopVon
            dtCart.Rows(index)("TyLeGopVon") = TyLeGopVon
            dtCart.Rows(index)("ThanhVienCMND") = ThanhVienCMND
            dtCart.Rows(index)("ThanhVienGhiChu") = ThanhVienGhiChu

            'save data to session object
            Session("Cart") = dtCart
        End Sub


        '
        '==============================================================
        ' Remove item from cart
        ' and re-bind data from cart to grid
        '==============================================================
        '
        Private Sub RemoveItemFromCart(ByVal index As Integer)
            dtCart = CType(Session("Cart"), DataTable)
            'If dtCart.Rows(index)("ID").ToString().Trim() <> "" Then
            '    Dim objGiayCNDKKD As New GiayCNDKKDController
            '    objGiayCNDKKD.THANHVIENHKD_Del(dtCart.Rows(index)("ID").ToString().Trim())

            '    'dispose object
            '    objGiayCNDKKD = Nothing
            'End If
            If dtCart.Rows(index)("ID").ToString().Trim() <> "" Then
                txtThanhVienIDXoa.Text += "," + dtCart.Rows(index)("ID").ToString().Trim()
            End If
            dtCart.Rows(index).Delete()
            Session("Cart") = dtCart

            'bind data to grid
            If dtCart.Rows.Count > 0 Then
                Me.BindGridData()
            Else
                Me.MakeCart(Nothing)
            End If
        End Sub


        '
        '==============================================================
        ' Set data for column STT 
        ' and bind data to grid
        '==============================================================
        '
        Private Sub BindGridData()
            Dim iCount As Integer
            dtCart = CType(Session("Cart"), DataTable)

            For iCount = 0 To dtCart.Rows.Count - 1
                dtCart.Rows(iCount)("STT") = iCount + 1
            Next

            'save data to session object
            Session("Cart") = dtCart

            'bind data to grid
            dgdDanhSach.DataSource = dtCart
            dgdDanhSach.DataBind()

            'Gán JS vào controls của Datagrid
            Dim grdItem As DataGridItem
            For Each grdItem In dgdDanhSach.Items

                'lay thong tin du lieu dau vao
                Dim objChon As HtmlInputCheckBox = CType(grdItem.FindControl("chkChon"), HtmlInputCheckBox)
                'lay thong tin du lieu dau vao
                Dim objTenThanhVien As HtmlInputText = CType(grdItem.FindControl("txtTenThanhVien"), HtmlInputText)
                Dim objThanhVienThuongTru As HtmlInputText = CType(grdItem.FindControl("txtThanhVienThuongTru"), HtmlInputText)
                Dim objGiaTriGopVon As HtmlInputText = CType(grdItem.FindControl("txtGiaTriGopVon"), HtmlInputText)
                Dim objTyLeGopVon As HtmlInputText = CType(grdItem.FindControl("txtTyLeGopVon"), HtmlInputText)
                Dim objThanhVienCMND As HtmlInputText = CType(grdItem.FindControl("txtThanhVienCMND"), HtmlInputText)
                Dim objThanhVienGhiChu As HtmlInputText = CType(grdItem.FindControl("txtThanhVienGhiChu"), HtmlInputText)

                objChon.Attributes.Add("onClick", "checkThayDoi('" + objChon.ClientID + "'," + objTenThanhVien.ClientID + "," + objThanhVienThuongTru.ClientID + "," + objGiaTriGopVon.ClientID + "," + objTyLeGopVon.ClientID + "," + objThanhVienCMND.ClientID + "," + objThanhVienGhiChu.ClientID + ")")

            Next
        End Sub


        Private Sub dgdDanhSach_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.DeleteCommand
            'remove item from cart
            Me.RemoveItemFromCart(e.Item.ItemIndex)
        End Sub


        Private Sub dgdDanhSach_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.UpdateCommand
            'get data input from grid
            Dim objTenThanhVien As HtmlInputText = CType(e.Item.FindControl("txtTenThanhVien"), HtmlInputText)
            Dim objThanhVienThuongTru As HtmlInputText = CType(e.Item.FindControl("txtThanhVienThuongTru"), HtmlInputText)
            Dim objGiaTriGopVon As HtmlInputText = CType(e.Item.FindControl("txtGiaTriGopVon"), HtmlInputText)
            Dim objTyLeGopVon As HtmlInputText = CType(e.Item.FindControl("txtTyLeGopVon"), HtmlInputText)
            Dim objThanhVienCMND As HtmlInputText = CType(e.Item.FindControl("txtThanhVienCMND"), HtmlInputText)
            Dim objThanhVienGhiChu As HtmlInputText = CType(e.Item.FindControl("txtThanhVienGhiChu"), HtmlInputText)
            'update data to cart
            Me.UpdateItem(e.Item.ItemIndex, objTenThanhVien.Value, objThanhVienThuongTru.Value, objGiaTriGopVon.Value, objTyLeGopVon.Value, objThanhVienCMND.Value, objThanhVienGhiChu.Value)

            'add new row to cart
            Me.AddToCart()
        End Sub


#End Region
    End Class

End Namespace