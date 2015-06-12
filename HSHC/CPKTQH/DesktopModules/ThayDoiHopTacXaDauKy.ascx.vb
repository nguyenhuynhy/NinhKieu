Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH
Namespace CPKTQH
    Public Class ThayDoiHopTacXaDauKy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoLanThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBangHieuCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkBangHieu As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtBangHieuMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNganhKinhDoanhCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaNganhKinhDoanh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaNganhKinhDoanhMoi As System.Web.UI.WebControls.DropDownList
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
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
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
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDaoMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDKBS As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayDangKyBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanToc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnThem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnSua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
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
            If Not Page.IsPostBack Then
                loadDataToControl()
                SetAttribute()
                GetSoGiayPhep()
                GetGiayCNDKKD()
                'Thong tin Xa vien
                bindDataXaVien()
                bindGrid()
                '
                setStatusBtnXoa()
            End If
        End Sub
        Private Sub GetSoGiayPhep()
            Dim objHopTacXaCon As New HopTacXaController
            Dim ds As DataSet
            txtGiayCNDKKDID.Text = CStr(Request.Params("ID"))
            ds = objHopTacXaCon.getGiayCNDKKDHTX(txtGiayCNDKKDID.Text)
            txtSoGiayPhep.Text = CStr(ds.Tables(0).Rows(0).Item("SoGiayPhep"))
        End Sub
        Private Sub GetGiayCNDKKD()
            'Get GiayCNDKKD tu so Giay Phep
            Dim objHopTacXaCon As New HopTacXaController
            Dim ds As DataSet
            ds = objHopTacXaCon.getGiayCNDKKDHTXBySoGiayPhep(txtSoGiayPhep.Text.Replace("'", "''"))
            If ds.Tables(0).Rows.Count > 0 Then 'Co data
                txtNgayCap.Text = CStr(ds.Tables(0).Rows(0).Item("NgayCap"))
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
            Dim objThayDoiCon As New ThayDoiHTXController
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
        End Sub
        Private Sub SetAttribute()
            'Javascript
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


            txtSoLanThayDoi.Attributes.Add("onkeypress", "ValidateNumeric()")
            txtSoLanThayDoi.Attributes.Add("onblur", "javascript:CheckNumber(" & txtSoLanThayDoi.ClientID & ");")

            txtVonKinhDoanhMoi.Attributes.Add("onblur", "javascript:CheckData(" & txtVonKinhDoanhMoi.ClientID & ");")
            'txtSoCMNDCNMoi.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMNDCNMoi.ClientID & ");")

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

            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay ?');")

            'Danh sach Xa Vien
            'txtSoCMND.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMND.ClientID & ");")

            txtNgayCapCMND.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMND);")
            txtNgayCapCMND.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapCMND.ClientID & ");")
            txtNgayCapCMND.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgaySinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinh);")
            txtNgaySinh.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgaySinh.ClientID & ");")
            txtNgaySinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            btnThem.Attributes.Add("onclick", "return KiemTraNhapLieu()")
            btnSua.Attributes.Add("onclick", "return KiemTraNhapLieu()")
        End Sub
        Private Sub txtSoLanThayDoi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoLanThayDoi.TextChanged
            If txtSoLanThayDoi.Text <> "" Then
                LoadThongTinThayDoi()
                bindDataXaVien()
                bindGrid()

                setStatusBtnXoa()

            End If
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim strLoi As String
            strLoi = KiemTraDuLieuNhap()
            If strLoi <> "" Then
                SetMSGBOX_HIDDEN(Page, strLoi)
                Return
            End If
            'HoangLN
            Dim objThayDoiHTXCon As New ThayDoiHTXController
            Dim objHopTacXaCon As New HopTacXaController

            'Kiem tra xem co phai la thay doi lan dau hay khong
            'Neu la thay doi lan dau , phai luu thong tin hien tai cua HTX 
            'de rollback neu xoa
            If objThayDoiHTXCon.ThayDoiLanDau(txtGiayCNDKKDID.Text) Then
                'Luu bang thay doi voi lan thay doi dau tien = 0
                objThayDoiHTXCon.UpdateThayDoiHTX( _
                                   txtNgayThayDoi.Text.Replace("'", "''"), _
                                   txtGiayCNDKKDID.Text.Replace("'", "''"), _
                                   txtHoSoTiepNhanID.Text, _
                                   txtGhiChu.Text.Replace("'", "''"), _
                                   "0" _
                           )
                objThayDoiHTXCon.UpdateThayDoiDanhSachXaVien(txtGiayCNDKKDID.Text, "0", CType(ViewState.Item("ThongTinXaVienDauTien"), DataTable))
            End If
            '---------------------Thay doi----------------------
            'Dim objThayDoiCon As New ThayDoiNoiDungKinhDoanhController
            objThayDoiHTXCon.UpdateThayDoiHTX( _
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
                            If (TenTruong = "VonKinhDoanh") And NoiDungMoi <> "" Then
                                NoiDungMoi = Left(NoiDungMoi, NoiDungMoi.Length - 3).Replace(".", "")
                            End If

                            objThayDoiHTXCon.UpdateThayDoiChiTietHTX( _
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
            objThayDoiHTXCon.UpdateThayDoiChiTietHTX( _
                    txtGiayCNDKKDID.Text, _
                    txtSoLanThayDoi.Text.Replace("'", "''"), _
                    "MASOLANHDAO", _
                    NoiDungMoi)
            '---------------------Cap nhat vao GCNDKKD -----------------
            Dim VonKinhDoanhMoi As String = txtVonKinhDoanhMoi.Text
            If (VonKinhDoanhMoi.Length > 0) Then
                VonKinhDoanhMoi = Left(VonKinhDoanhMoi, VonKinhDoanhMoi.Length - 3).Replace(".", "")
            End If

            objThayDoiHTXCon.UpdateGCNDKKDHTX( _
                    txtGiayCNDKKDID.Text, _
                    txtBangHieuMoi.Text.Replace("'", "''"), _
                    ddlMaNganhKinhDoanhMoi.SelectedValue, _
                    Nothing, _
                    VonKinhDoanhMoi.Replace("'", "''"), _
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
                    txtDanTocCNMoi.Text.Replace("'", "''") _
            )


            '--- CAP NHAT DANH SACH XA VIEN VAO BANG THAYDOITHANHVIENHTX 
            objThayDoiHTXCon.UpdateThayDoiDanhSachXaVien(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text, getDTThongTinXaVien)
            '--- CAP NHAT DANH SACH VAO BANG GIAYCNDKKDHTX
            objHopTacXaCon.UpdDanhSachXaVien(txtGiayCNDKKDID.Text, getDTThongTinXaVien())

            setStatusBtnXoa()
        End Sub
        Private Function KiemTraDuLieuNhap() As String
            Dim strLoi As String = ""
            'ThanhVien
            If getDTThongTinXaVien() Is Nothing Then
                strLoi = "Chua nhap Thanh vien cua Hop tac xa"
                Return strLoi
            End If
            If getDTThongTinXaVien.Rows.Count = 0 Then
                strLoi = "Hop tac xa phai co it nhat 1 thanh vien"
                Return strLoi
            End If
            Return strLoi
        End Function
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
        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThayDoiHTXCon As New ThayDoiHTXController
            objThayDoiHTXCon.DelThayDoiHTX(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)
            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub setStatusBtnXoa()
            Dim objThayDoiCon As New ThayDoiHTXController
            If objThayDoiCon.CheckHTXDaThayDoi(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text) Then
                ViewState.Item("isAddNew") = False
                btnXoa.Visible = True
            Else
                ViewState.Item("isAddNew") = True
                btnXoa.Visible = False
            End If
        End Sub
#Region "Xu ly thong tin Xa Vien"
        Private Sub bindDataXaVien()
            Dim objThayDoiHTXCon As New ThayDoiHTXController
            Dim dsThanhVien As DataSet
            dsThanhVien = objThayDoiHTXCon.GetThayDoiThanhVienHTX(txtGiayCNDKKDID.Text, txtSoLanThayDoi.Text)

            Dim dtThongTinXaVien As DataTable
            dtThongTinXaVien = makeDataTable()
            Dim drXaVien As DataRow

            Dim i As Integer
            For i = 0 To dsThanhVien.Tables(0).Rows.Count - 1
                drXaVien = dtThongTinXaVien.NewRow()
                drXaVien.Item("HoTen") = getItemValueFromTable(dsThanhVien.Tables(0), i, "HoTen")
                drXaVien.Item("GioiTinh") = getItemValueFromTable(dsThanhVien.Tables(0), i, "GioiTinh")
                drXaVien.Item("NgaySinh") = getItemValueFromTable(dsThanhVien.Tables(0), i, "NgaySinh")
                drXaVien.Item("DanToc") = getItemValueFromTable(dsThanhVien.Tables(0), i, "DanToc")
                drXaVien.Item("SoCMND") = getItemValueFromTable(dsThanhVien.Tables(0), i, "SoCMND")
                drXaVien.Item("NgayCapCMND") = getItemValueFromTable(dsThanhVien.Tables(0), i, "NgayCapCMND")
                drXaVien.Item("NoiCapCMND") = getItemValueFromTable(dsThanhVien.Tables(0), i, "NoiCapCMND")
                drXaVien.Item("DiaChiThuongTru") = getItemValueFromTable(dsThanhVien.Tables(0), i, "DiaChiThuongTru")
                drXaVien.Item("ChoOHienNay") = getItemValueFromTable(dsThanhVien.Tables(0), i, "ChoOHienNay")
                dtThongTinXaVien.Rows.Add(drXaVien)
                dtThongTinXaVien.AcceptChanges()
            Next
            ViewState.Item("ThongTinXaVien") = dtThongTinXaVien
            ViewState.Item("ThongTinXaVienDauTien") = dtThongTinXaVien
        End Sub
        Private Sub bindGrid()
            Dim dtThongTinXaVien As New DataTable
            If Not ViewState.Item("ThongTinXaVien") Is Nothing Then
                dtThongTinXaVien = CType(ViewState.Item("ThongTinXaVien"), DataTable)
            Else
                dtThongTinXaVien = makeDataTable()
            End If
            dgdDanhSach.DataSource = dtThongTinXaVien
            dgdDanhSach.DataBind()
            AddFunctionOnClick()
        End Sub

        Private Sub btnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua.Click
            If Not updDataTable(False) Then
                Return
            End If
            bindGrid()
            btnThem.Visible = True
            btnSua.Visible = False
            clearControl()
        End Sub
        Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
            If Not (updDataTable(True)) Then
                Return
            End If
            bindGrid()
            clearControl()
        End Sub
        Private Sub clearControl()
            txtHoTen.Text = ""
            ddlGioiTinh.SelectedValue = "1"
            txtNgaySinh.Text = ""
            txtDanToc.Text = ""
            txtSoCMND.Text = ""
            txtNgayCapCMND.Text = ""
            txtNoiCapCMND.Text = ""
            txtDiaChiThuongTru.Text = ""
            txtChoOHienNay.Text = ""
        End Sub
        Private Function updDataTable(ByVal isThemMoi As Boolean) As Boolean
            If ViewState.Item("ThongTinXaVien") Is Nothing Then
                ViewState.Item("ThongTinXaVien") = makeDataTable()
            End If
            '
            Dim dtThongTinXaVien As New DataTable
            dtThongTinXaVien = CType(ViewState.Item("ThongTinXaVien"), DataTable)
            '
            Dim objXaVien As New XaVienInfo
            objXaVien.HoTen = txtHoTen.Text.Replace("'", "''")
            objXaVien.GioiTinh = ddlGioiTinh.SelectedValue
            objXaVien.NgaySinh = txtNgaySinh.Text.Replace("'", "''")
            objXaVien.DanToc = txtDanToc.Text.Replace("'", "''")
            objXaVien.SoCMND = txtSoCMND.Text.Replace("'", "''")
            objXaVien.NgayCapCMND = txtNgayCapCMND.Text.Replace("'", "''")
            objXaVien.NoiCapCMND = txtNoiCapCMND.Text.Replace("'", "''")
            objXaVien.DiaChiThuongTru = txtDiaChiThuongTru.Text.Replace("'", "''")
            objXaVien.ChoOHienNay = txtChoOHienNay.Text.Replace("'", "''")

            Dim i As Integer
            If isThemMoi Then 'Them moi
                For i = 0 To dtThongTinXaVien.Rows.Count - 1
                    If CStr(dtThongTinXaVien.Rows(i).Item("SoCMND")) = objXaVien.SoCMND Then
                        SetMSGBOX_HIDDEN(Page, "So CMND da ton tai")
                        Return False
                    End If
                Next
            Else 'Update
                For i = 0 To dtThongTinXaVien.Rows.Count - 1
                    If CStr(dtThongTinXaVien.Rows(i).Item("SoCMND")) = CStr(viewstate.Item("SoCMND")) Then
                        Dim j As Integer
                        For j = 0 To dtThongTinXaVien.Rows.Count - 1
                            If (CStr(dtThongTinXaVien.Rows(j).Item("SoCMND")) = objXaVien.SoCMND) And (objXaVien.SoCMND <> CStr(viewstate.Item("SoCMND"))) Then
                                SetMSGBOX_HIDDEN(Page, "So CMND da ton tai")
                                Return False
                            End If
                        Next
                        'Xoa DI
                        dtThongTinXaVien.Rows(i).Delete()
                        dtThongTinXaVien.AcceptChanges()
                        ViewState.Item("SoCMND") = objXaVien.SoCMND
                        Exit For
                    End If
                Next
            End If

            'Them vao
            Dim drXaVien As DataRow
            drXaVien = dtThongTinXaVien.NewRow()
            drXaVien.Item("HoTen") = objXaVien.HoTen
            drXaVien.Item("GioiTinh") = objXaVien.GioiTinh
            drXaVien.Item("NgaySinh") = objXaVien.NgaySinh
            drXaVien.Item("DanToc") = objXaVien.DanToc
            drXaVien.Item("SoCMND") = objXaVien.SoCMND
            drXaVien.Item("NgayCapCMND") = objXaVien.NgayCapCMND
            drXaVien.Item("NoiCapCMND") = objXaVien.NoiCapCMND
            drXaVien.Item("DiaChiThuongTru") = objXaVien.DiaChiThuongTru
            drXaVien.Item("ChoOHienNay") = objXaVien.ChoOHienNay
            dtThongTinXaVien.Rows.Add(drXaVien)
            dtThongTinXaVien.AcceptChanges()
            ViewState.Item("ThongTinXaVien") = dtThongTinXaVien
            Return True
        End Function
        Private Sub CreateColumn(ByVal name As String, ByVal namesTable As DataTable)
            Dim idColumn As New DataColumn
            idColumn.ColumnName = name
            namesTable.Columns.Add(idColumn)
        End Sub
        Private Function makeDataTable() As DataTable
            Dim dt As DataTable = New DataTable
            CreateColumn("HoTen", dt)
            CreateColumn("GioiTinh", dt)
            CreateColumn("NgaySinh", dt)
            CreateColumn("DanToc", dt)
            CreateColumn("SoCMND", dt)
            CreateColumn("NgayCapCMND", dt)
            CreateColumn("NoiCapCMND", dt)
            CreateColumn("DiaChiThuongTru", dt)
            CreateColumn("ChoOHienNay", dt)
            Return dt
        End Function
        Sub AddFunctionOnClick()
            Dim btn As System.Web.UI.WebControls.ImageButton
            Dim i As Integer
            For i = 0 To Me.dgdDanhSach.Items.Count - 1
                btn = CType(Me.dgdDanhSach.Items.Item(i).FindControl("imgXoa"), System.Web.UI.WebControls.ImageButton)
                btn.Attributes.Add("OnClick", "return confirm('Ban co chac la muon xoa thanh vien nay ?');")
            Next
        End Sub
        Private Sub dgdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.ItemCommand
            Dim dtThongTinXaVien As New DataTable
            dtThongTinXaVien = CType(ViewState.Item("ThongTinXaVien"), DataTable)
            Dim i As Integer = e.Item.ItemIndex
            Select Case e.CommandName
                Case "Xoa"
                    dtThongTinXaVien.Rows(i).Delete()
                    dtThongTinXaVien.AcceptChanges()
                    ViewState.Item("ThongTinXaVien") = dtThongTinXaVien
                    bindGrid()
                    btnThem.Visible = True
                    btnSua.Visible = False
                Case "Sua"
                    txtHoTen.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "HoTen")
                    ddlGioiTinh.SelectedValue = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "GioiTinh")
                    txtNgaySinh.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "NgaySinh")
                    txtDanToc.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "DanToc")
                    txtSoCMND.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "SoCMND")
                    txtNgayCapCMND.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "NgayCapCMND")
                    txtNoiCapCMND.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "NoiCapCMND")
                    txtDiaChiThuongTru.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "DiaChiThuongTru")
                    txtChoOHienNay.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "ChoOHienNay")
                    btnSua.Visible = True
                    btnThem.Visible = False
                    ViewState.Item("SoCMND") = txtSoCMND.Text
            End Select
        End Sub
        Private Function getItemValueFromTable(ByVal dt As DataTable, ByVal rowNo As Integer, ByVal field As String) As String
            If (Not IsDBNull(dt.Rows(rowNo).Item(field))) Then
                Return Replace(CStr(dt.Rows(rowNo).Item(field)), "''", "'")
            Else
                Return ""
            End If
        End Function
        Private Function getDTThongTinXaVien() As DataTable
            If ViewState.Item("ThongTinXaVien") Is Nothing Then
                Return Nothing
            End If
            Return CType(ViewState.Item("ThongTinXaVien"), DataTable)
        End Function


#End Region


        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
    End Class
End Namespace
