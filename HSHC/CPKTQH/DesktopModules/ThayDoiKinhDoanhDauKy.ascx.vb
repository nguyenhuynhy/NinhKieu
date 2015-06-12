Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH
Namespace CPKTQH
    Public Class ThayDoiKinhDoanhDauKy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDaoMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtBangHieuCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkBangHieu As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtBangHieuMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNganhKinhDoanhCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaNganhKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaNganhKinhDoanhMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaHinhThucKinhDoanhCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaHinhThucKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaHinhThucKinhDoanhMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtVonKinhDoanhCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkVonKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtVonKinhDoanhMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanhCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkMatHangKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtMatHangKinhDoanhMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNhaCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkSoNha As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtSoNhaMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuongCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaDuong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaDuongMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuongCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaPhuong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaPhuongMoi As System.Web.UI.WebControls.DropDownList
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
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
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
        Protected WithEvents chkNgayCapCMNDCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNgayCapCMNDCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMNDCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNoiCapCMNDCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNoiCapCMNDCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanTocCNCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDanTocCN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDanTocCNMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDKBS As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayDangKyBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLanThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLabelDonViTinhCu As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabelDonViTinhMoi As System.Web.UI.WebControls.Label
        Protected WithEvents txtTongSoLaoDongCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkTongSoLaoDong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtTongSoLaoDongMoi As System.Web.UI.WebControls.TextBox

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
                loadDataToControl()
                SetAttribute()
                GetSoGiayPhep()
                GetGiayCNDKKD()
                setStatusBtnXoa()
            End If
        End Sub
        Private Sub GetSoGiayPhep()
            Dim objGiayCNDKKDCon As New GiayCNDKKDController
            Dim ds As DataSet
            txtGiayCNDKKDID.Text = CStr(Request.Params("ID"))
            ds = objGiayCNDKKDCon.GetGiayCNDKKDByID(txtGiayCNDKKDID.Text)
            txtSoGiayPhep.Text = CStr(ds.Tables(0).Rows(0).Item("SoGiayPhep"))
        End Sub
        Private Sub GetGiayCNDKKD()
            'Get GiayCNDKKD tu so Giay Phep
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep(txtSoGiayPhep.Text.Replace("'", "''"))
            If ds.Tables(0).Rows.Count > 0 Then 'Co data
                txtGiayCNDKKDID.Text = CStr(ds.Tables(0).Rows(0).Item("GiayCNDKKDID"))
                txtNgayCap.Text = CStr(ds.Tables(0).Rows(0).Item("NgayCap"))
                Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
                ViewState("SoLanThayDoi") = ds.Tables(0).Rows(0).Item("SoLanThayDoi")
                txtSoLanThayDoi.Text = (CInt(ViewState("SoLanThayDoi")) + 1).ToString()
                '-- Load thong tin thay doi Cu & Moi
                LoadThongTinThayDoi()
                '-------------------------------------
            Else
                '--Neu khong co du lieu thi` tro ve
                Response.Redirect(NavigateURL)
            End If
        End Sub
        Private Sub LoadThongTinThayDoi()
            'Load thong tin thay doi cua sogiayphep + lanthaydoi
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            Dim dsThayDoi As New DataSet
            dsThayDoi = objThayDoiCon.GetThongTinThayDoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            If dsThayDoi.Tables(0).Rows.Count > 0 Then
                txtGhiChu.Text = CStr(dsThayDoi.Tables(0).Rows(0).Item("GhiChu"))
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
        Private Sub loadDataToControl()
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

            ddlMaNganhKinhDoanhCu.DataSource = objDanhMuc.GetDanhMucList("DMNGANHKINHDOANHBYLINHVUC")
            ddlMaNganhKinhDoanhCu.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanhCu.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanhCu.DataBind()
            ddlMaNganhKinhDoanhCu.Items.Insert(0, "")

            ddlMaNganhKinhDoanhMoi.DataSource = objDanhMuc.GetDanhMucList("DMNGANHKINHDOANHBYLINHVUC")
            ddlMaNganhKinhDoanhMoi.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanhMoi.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanhMoi.DataBind()
            ddlMaNganhKinhDoanhMoi.Items.Insert(0, "")

            If txtNgayThayDoi.Text = "" Then
                txtNgayThayDoi.Text = NgayHienTai()
            End If
            lblLabelDonViTinhCu.Text = getLabelDonViTinh()
            lblLabelDonViTinhMoi.Text = lblLabelDonViTinhCu.Text
        End Sub
        Private Sub SetAttribute()
            'Javascript
            chkTongSoLaoDong.Attributes.Add("onclick", "javascript:SetStatus('" & chkTongSoLaoDong.ClientID & "','" & txtTongSoLaoDongMoi.ClientID & "');") 'TUNGLDL
            chkBangHieu.Attributes.Add("onclick", "javascript:SetStatus('" & chkBangHieu.ClientID & "','" & txtBangHieuMoi.ClientID & "');")
            chkMaNganhKinhDoanh.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaNganhKinhDoanh.ClientID & "','" & ddlMaNganhKinhDoanhMoi.ClientID & "');")
            chkMaHinhThucKinhDoanh.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaHinhThucKinhDoanh.ClientID & "','" & ddlMaHinhThucKinhDoanhMoi.ClientID & "');")
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


            txtSoLanThayDoi.Attributes.Add("onkeypress", "ValidateNumeric()")
            txtSoLanThayDoi.Attributes.Add("onblur", "javascript:CheckNumber(" & txtSoLanThayDoi.ClientID & ");")
            
            txtVonKinhDoanhMoi.Attributes.Add("onblur", "javascript:ConvertNumericVN(" & _
                                                                txtVonKinhDoanhMoi.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")


            txtNgaySinhCNMoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinhCNMoi);")
            Me.txtNgaySinhCNMoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgaySinhCNMoi.ClientID & ");")
            Me.txtNgaySinhCNMoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayCapCMNDCNMoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMNDCNMoi);")
            Me.txtNgayCapCMNDCNMoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapCMNDCNMoi.ClientID & ");")
            Me.txtNgayCapCMNDCNMoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayThayDoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayThayDoi);")
            Me.txtNgayThayDoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayThayDoi.ClientID & ");")
            Me.txtNgayThayDoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")


            btnCapNhat.Attributes.Add("onclick", "return btnCapNhat_clicked()")

            Dim strURL As String
            strURL = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay ?');")
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            'HoangLN
            '---------------------Thay doi----------------------
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            objThayDoiCon.UpdateThayDoi( _
                    txtNgayThayDoi.Text.Replace("'", "''"), _
                    txtGiayCNDKKDID.Text.Replace("'", "''"), _
                    txtHoSoTiepNhanID.Text, _
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
                            NoiDungMoi = GetNoiDung(TenTruong & "Moi", Me)
                            
                            objThayDoiCon.UpdateThayDoiChiTiet( _
                                    txtGiayCNDKKDID.Text, _
                                    txtSoLanThayDoi.Text.Replace("'", "''"), _
                                    TenTruong, _
                                    NoiDungMoi)
                            'reset
                            CType(ctrl, CheckBox).Checked = False
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
            '---------------------Cap nhat vao GCNDKKD -----------------
            
            objThayDoiCon.UpdateGCNDKKD( _
                    txtGiayCNDKKDID.Text, _
                    txtBangHieuMoi.Text.Replace("'", "''"), _
                    ddlMaNganhKinhDoanhMoi.SelectedValue, _
                    ddlMaHinhThucKinhDoanhMoi.SelectedValue, _
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
                    txtTongSoLaoDongMoi.Text.Replace("'", "''") _
            )
            setStatusBtnXoa()
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
        Private Sub txtSoLanThayDoi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoLanThayDoi.TextChanged
            If txtSoLanThayDoi.Text <> "" Then
                LoadThongTinThayDoi()
                setStatusBtnXoa()
            End If
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            objThayDoiCon.DelThayDoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub setStatusBtnXoa()
            Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            If objThayDoiCon.CheckDaThayDoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text) Then
                ViewState.Item("isAddNew") = False
                btnXoa.Visible = True
            Else
                ViewState.Item("isAddNew") = True
                btnXoa.Visible = False
            End If
        End Sub
    End Class
End Namespace
