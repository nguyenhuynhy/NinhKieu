'Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports PortalQH
Imports PortalQH.UserInfo
Namespace CPKTQH
    Public Class CapGiayCNDKKD
        'Created NganTL
        'Descr : Cap moi va cap doi giay CNDKKD
        'Date by 03/11/2004
        Inherits PortalQH.PortalModuleControl


        '========================================================
        '= TuanNH update ngay 22/09/2006
        '= Muc dich : Kiem tra in Giay CNDKKD by Word hay Report
        '========================================================

        Private blDoiSo As String 'TUNGLDL biến kiểm tra đổi số khi cấp lại cấp đổi
        Private pID As String = ""
        Private strControl As String
        Private Shared dv As DataView
        Protected WithEvents txtQuocTich As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTenGiayChungThuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayChungThuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapGiayChungThuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblKetQuaKiemTraSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents hplDanhSachDiaChi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtThanhVienIDXoa As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCapChungThuc As System.Web.UI.WebControls.Image
        Protected WithEvents cmdNgayCap As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayHetHan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgaySinh As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayCapCMND As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayCapGiayChungThuc As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtNgayCapGiayChungThuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDoiSo As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtGiayCNDKKDID1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLaoDong As System.Web.UI.WebControls.TextBox


        Private Const strURL As String = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNoiCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNganh As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSGP As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGiayPhepTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents btnKiemTra As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblKetQuaVPHC As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaNganhCam As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaThongTin As System.Web.UI.WebControls.Label
        Protected WithEvents cMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents KiemTra As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblDanhSach As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLinhVucCapPhep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNganh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox10 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Combobox1 As ProgStudios.WebControls.ComboBox
        Protected WithEvents Textbox11 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Combobox2 As ProgStudios.WebControls.ComboBox
        Protected WithEvents Textbox12 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox13 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebsite As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanToc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayHetHan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents SoGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents txtMaLoaiDoanhNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayHetHan As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgaySinh As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayCapCMND As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayCap As System.Web.UI.WebControls.Image
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDIDMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLabelSoGiayPhepMoi As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGiayPhepMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblKetQuaKiemTraBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaNganhDieuKien As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaKiemTraDiaChiDKKD As System.Web.UI.WebControls.Label
        Protected WithEvents btnDanhSachBangHieu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents hplDanhSachBangHieu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblLabelDonViTinh As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents ctrlScriptComboFilterPhuong As PortalQH.ComboFilter
        Protected WithEvents btnSoGiayPhep As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList

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
            If Not Request.Params("ID") Is Nothing Then
                pID = Request.Params("ID")
                strControl = Request.Params("ctl")
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                txtMaLinhVuc.Text = Request.Params("malv")
            End If
            'imgNgayHetHan.Enabled = False

            If Not Me.IsPostBack Then
                InitState()
                AddJavaScript()
            End If
            'If lblSoGiayPhepMoi.Text <> "" Then
            '    GetGiayCNDKKD()
            '    btnDeXuat.Visible = False
            '    btnSoGiayPhep.Enabled = False
            'End If
            '------------Loc giay cndkkd(truong hop cap doi)---------
            If KiemTra.Value = "1" Then
                GetGiayCNDKKD()
                btnIn.Visible = False
                KiemTra.Value = "0"
            End If
            InitLabelKiemTra()
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganh) & _
                                                        ReLoadComboFilter(ctrlScriptComboFilterPhuong, ddlMaDuong))
            End If


            'TUNGLDL
            'Lay so giay phep id de cap lai cap doi ko thay doi so
            If txtSoGiayPhep.Text <> "" Then
                Dim ds As DataSet
                Dim objGiayCNDKKD As New GiayCNDKKDController
                ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep(txtSoGiayPhep.Text.Replace("'", "''"))
                If ds.Tables(0).Rows.Count > 0 Then
                    txtGiayCNDKKDID1.Text = Convert.ToString(ds.Tables(0).Rows(0).Item("GiayCNDKKDID"))
                End If
            End If

        End Sub


        Sub AddJavaScript()
            'txtBangHieu.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaLinhVucCapPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuongThucKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganh.Attributes.Add("ISNULL", "NOTNULL")
            txtMatHangKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtVonKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaHinhThucKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            ' txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            'txtSoCMND.Attributes.Add("ISNULL", "NOTNULL")
            txtNgaySinh.Attributes.Add("ISNULL", "NOTNULL")
            txtThuongTru.Attributes.Add("ISNULL", "NOTNULL")

            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
            btnSoGiayPhep.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            Dim strURLNganhKD As String
            'ddlMaLinhVucCapPhep.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            ddlMaPhuongThucKinhDoanh.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');cboPhuongThucKinhDoanh_onChanged(this.options[this.selectedIndex].value,'" + Me.txtMatHangKinhDoanh.ClientID + "');")

            'Ngay cap
            txtNgayCap.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCap.ClientID & ");")
            cmdNgayCap.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCap)

            'Ngay het han
            txtNgayHetHan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHetHan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHetHan.ClientID & ");")
            cmdNgayHetHan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayHetHan)

            'Ngay sinh
            txtNgaySinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgaySinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgaySinh.ClientID & ");")
            cmdNgaySinh.NavigateUrl = AdminDB.InvokePopupCal(txtNgaySinh)

            'Ngay cap CMND
            txtNgayCapCMND.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapCMND.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCapCMND.ClientID & ");")
            cmdNgayCapCMND.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCapCMND)
            

            'txtDienThoai.Attributes.Add("onblur", "javascript:CheckNumber(" & txtDienThoai.ClientID & ");")
            txtVonKinhDoanh.Attributes.Add("onblur", "javascript:ConvertNumericVN(" & _
                                                                txtVonKinhDoanh.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")
            txtEmail.Attributes.Add("onblur", "javascript:validateEmail(" & txtEmail.ClientID & ");")

            'hàm mặc định viết chữ hoa
            txtBangHieu.Attributes.Add("onblur", "javascript:upper(" & txtBangHieu.ClientID & ");")
            txtHoTen.Attributes.Add("onblur", "javascript:upper(" & txtHoTen.ClientID & ");")
            'txtNgayCapGiayChungThuc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapGiayChungThuc);")
            'imgNgayCapChungThuc.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapGiayChungThuc, 'dd/mm/yyyy');")
            'txtNgayCapGiayChungThuc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapGiayChungThuc.ClientID & ");")
            'txtNgayCapGiayChungThuc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayCapGiayChungThuc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapGiayChungThuc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCapGiayChungThuc.ClientID & ");")
            cmdNgayCapGiayChungThuc.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCapGiayChungThuc)
            txtSoCMND.Attributes.Add("onblur", "javascript:checkGiayToCaNhan()")
            txtTenGiayChungThuc.Attributes.Add("onblur", "javascript:checkGiayToCaNhan()")
        End Sub
        Sub InitState()            
            Dim dsLinhVuc As New DataSet
            Dim dsNganh As New DataSet
            Dim dsPhuongThuc As New DataSet
            Dim objDanhMuc As New DanhMucController


            txtMaSoNguoiSuDung.Text = CStr(Session("UserName"))
            If txtNgayCap.Text = "" Then txtNgayCap.Text = NgayHienTai()

            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)

            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))

            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                'Doan loc duong theo phuong
                Dim dsPhuong As New DataSet
                Dim dsDuong As New DataSet
                dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
                dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
                BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, "")
                BindDropDownList_Dataset(ddlMaDuong, dsDuong, "TenDuong", "MaDuong", True, "")
                With ctrlScriptComboFilterPhuong
                    .ConditionID = ddlMaPhuong.ClientID
                    .ConditionText = "Ten"
                    .ConditionValue = "Ma"
                    .ResultID = ddlMaDuong.ClientID
                    .ResultText = "TenDuong"
                    .ResultValue = "MaDuong"
                    .ConditionDS = dsPhuong
                    .ResultDS = dsDuong
                End With
                ddlMaPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilterPhuong.ID & "('1');")
            Else
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            End If

            '-------------------------------------------------------------

            'txtReload.Text = "0"

            'ThuyTT update:chi lay nhung nganh cap 1 lam nganh kinh doanh chính
            Dim objNganhKD As New NganhKinhDoanhController
            dsLinhVuc = objNganhKD.getLinhVucCapPhep()
            'dsNganh = objNganhKD.getNganhKinhDoanhChinh
            dsNganh = objNganhKD.getPhuongThucNganhNghe()
            dsPhuongThuc = objNganhKD.getPhuongThucKinhDoanh()
            objNganhKD = Nothing
            'ThuyTT end

            'ddlMaLinhVucCapPhep.DataSource = dsLinhVuc
            'ddlMaLinhVucCapPhep.DataTextField = "TenLinhVuc"
            'ddlMaLinhVucCapPhep.DataValueField = "MaLinhVuc"
            'ddlMaLinhVucCapPhep.DataBind()
            'ddlMaLinhVucCapPhep.Items.Insert(0, "")

            ddlMaPhuongThucKinhDoanh.DataSource = dsPhuongThuc
            ddlMaPhuongThucKinhDoanh.DataTextField = "TenLinhVuc"
            ddlMaPhuongThucKinhDoanh.DataValueField = "MaLinhVuc"
            ddlMaPhuongThucKinhDoanh.DataBind()
            ddlMaPhuongThucKinhDoanh.Items.Insert(0, "")

            ddlMaNganh.DataSource = dsNganh
            ddlMaNganh.DataTextField = "TenNganh"
            ddlMaNganh.DataValueField = "MaNganh"
            ddlMaNganh.DataBind()
            ddlMaNganh.Items.Insert(0, "")
            With ctrlScriptComboFilter
                '.ConditionID = ddlMaLinhVucCapPhep.ClientID
                .ConditionID = ddlMaPhuongThucKinhDoanh.ClientID
                .ConditionText = "TenLinhVuc"
                .ConditionValue = "MaLinhVuc"

                .ResultID = ddlMaNganh.ClientID
                .ResultText = "TenNganh"
                .ResultValue = "MaNganh"
                .ConditionDS = dsLinhVuc
                .ResultDS = dsNganh
            End With
            dsLinhVuc = Nothing
            dsNganh = Nothing

            If strControl = "CAPDOICNDKKD" Then
                txtSoGiayPhep.Visible = True
                txtSoGiayPhep.Text = Request.QueryString("SoGiayPhep")
                btnSoGiayPhep.Visible = True
                chkDoiSo.Visible = True
                txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            Else
                    txtSoGiayPhep.Visible = False
                    btnSoGiayPhep.Visible = False
                End If
                If txtDanToc.Text = "" Then txtDanToc.Text = "Kinh"
                BindData(pID)

                '' Kiem tra ma hinh thuc kinh doanh
                'If ddlMaHinhThucKinhDoanh.SelectedValue = "TV" Then
                '    txtNgayHetHan.Enabled = True
                '    imgNgayHetHan.Enabled = True
                'End If
                'Kiem tra de xuat
                If CheckHoSoDeXuat(txtHoSoTiepNhanID.Text) = True Then
                    btnIn.Visible = True
                    btnXoa.Visible = False
                    btnYCBS.Visible = False
                    btnHoSoKhong.Visible = False
                Else
                    btnIn.Visible = False
                End If
                'Kiem tra bo sung
                If CheckHoSoBoSung(txtHoSoTiepNhanID.Text) = True Then
                    btnYCBS_Click(Nothing, Nothing)
                    btnIn.Visible = False
                    btnXoa.Visible = False
                    btnCapNhat.Visible = False
                    btnHoSoKhong.Visible = False
                    btnKiemTra.Visible = False
                End If
                'Kiem tra khong giai quyet
                If CheckHoSoKhongGiaiQuyet(txtHoSoTiepNhanID.Text) = True Then
                    btnHoSoKhong_Click(Nothing, Nothing)
                    btnIn.Visible = False
                    btnXoa.Visible = False
                    btnCapNhat.Visible = False
                    btnYCBS.Visible = False
                    btnKiemTra.Visible = False
                End If

                'TuanNH update ngay 22/09/2006
                'Kiem tra in Giay CNDKKD by Word hay Report
                If CType(ConfigurationSettings.AppSettings("InGiayCNDKKDByWord"), String) = "0" Then
                    GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", CType(Session.Item("ActiveDB"), String), btnIn, Me)
                End If

        End Sub
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
        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=HCT&oldControl=" & strControl & "&SoGiayPhep=" & txtSoGiayPhep.Text, True)
                'Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&oldControl=" & strControl, True)
                btnXoa.Visible = False
                btnYCBS.Visible = False
                btnHoSoKhong.Visible = False
            End If
        End Sub
        Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New CPKTQH.HoSoBoSungController
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

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            If txtTenGiayChungThuc.Text = "" And txtSoCMND.Text = "" Then
                SetMSGBOX_HIDDEN(Page, "Chưa nhập chứng minh nhân dân!")
                Exit Sub
            End If
            Dim objCapCNDKKD As New GiayCNDKKDController
            'truong hop cap doi
            'If Request.Params("ctl") = GetValueItem(Request, "ControlCapDoi", ConfigurationSettings.AppSettings("Path" & CType(Session.Item("ActiveDB"), String)) & "GLOBAL.xml") Then

            txtGiayCNDKKDID.Text = objCapCNDKKD.AddGIAYCNDKKD(Me)

            If txtGiayCNDKKDID.Text = "" Then
                SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                Exit Sub
            End If
            Dim grdItem As DataGridItem
            For Each grdItem In dgdDanhSach.Items

                'lay thong tin du lieu dau vao
                Dim objTenThanhVien As HtmlInputText = CType(grdItem.FindControl("txtTenThanhVien"), HtmlInputText)
                Dim objThanhVienThuongTru As HtmlInputText = CType(grdItem.FindControl("txtThanhVienThuongTru"), HtmlInputText)
                Dim objGiaTriGopVon As HtmlInputText = CType(grdItem.FindControl("txtGiaTriGopVon"), HtmlInputText)
                Dim objTyLeGopVon As HtmlInputText = CType(grdItem.FindControl("txtTyLeGopVon"), HtmlInputText)
                Dim objThanhVienCMND As HtmlInputText = CType(grdItem.FindControl("txtThanhVienCMND"), HtmlInputText)
                Dim objThanhVienGhiChu As HtmlInputText = CType(grdItem.FindControl("txtThanhVienGhiChu"), HtmlInputText)

                'Cap nhat du lieu xuong database
                If objTenThanhVien.Value <> "" And objThanhVienCMND.Value <> "" Then
                    objCapCNDKKD.THANHVIENHKD_Upd(grdItem.Cells(0).Text.ToString().Replace("&nbsp;", ""), objTenThanhVien.Value, objThanhVienThuongTru.Value, objGiaTriGopVon.Value, objTyLeGopVon.Value, objThanhVienCMND.Value, objThanhVienGhiChu.Value, Request.QueryString("ID").ToString())
                End If

            Next

            'Cap nhat xoa thong tin thay doi thanh vien gop von
            If txtThanhVienIDXoa.Text.Replace(",", "").Trim() <> "" Then
                objCapCNDKKD.THANHVIENHKD_Del(txtThanhVienIDXoa.Text)
            End If
            'GetGiayCNDKKD() 'TUNGLDL
            objCapCNDKKD = Nothing
            Response.Redirect(Request.RawUrl())

        End Sub

        Sub BindData(ByVal id As String)
            Dim objCapCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            ds = objCapCNDKKD.GetGiayCNDKKD_Edit(id)
            If ds.Tables(0).Rows.Count > 0 Then
                gLoadControlValues(ds, Me)
                btnDeXuat.Visible = True
                btnYCBS.Visible = False
                btnHoSoKhong.Visible = False
                btnSoGiayPhep.Enabled = False
                txtSoBienNhan.ReadOnly = True
                txtSoGiayPhep.ReadOnly = True
            Else
                ds = objCapCNDKKD.GetGiayCNDKKD_New(id)
                gLoadControlValues(ds, Me)
                btnDeXuat.Visible = False
                btnXoa.Visible = False
            End If
            'BindGrid()
            lblLabelSoGiayPhepMoi.Text = lblSoGiayPhepMoi.Text
            'Lay thong tin danh sach thanh vien
            Dim dsThanhVien As DataSet
            dsThanhVien = objCapCNDKKD.THANHVIENHKD_GetByTiepNhanID(id)
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
            objCapCNDKKD = Nothing
        End Sub
        Private Sub GetGiayCNDKKD()
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep1(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me)
            lblLabelSoGiayPhepMoi.Text = lblSoGiayPhepMoi.Text
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

            If Not Session("TimKiemGiayCNDKKDCUT") Is Nothing Then
                Session("TimKiemGiayCNDKKDCUT") = Nothing
            End If


            With objKiemTraInfo
                If txtGiayCNDKKDIDMoi.Text = "" Then
                    .GiayCNDKKDID = txtGiayCNDKKDID.Text
                    .SoGiayPhep = txtSoGiayPhep.Text
                Else
                    .GiayCNDKKDID = txtGiayCNDKKDIDMoi.Text
                    .SoGiayPhep = lblSoGiayPhepMoi.Text
                End If
                .BangHieu = Trim(txtBangHieu.Text)
                .HoTen = Trim(txtHoTen.Text)
                .SoCMND = Trim(txtSoCMND.Text)
                .MaNganh = ddlMaNganh.SelectedValue
                .MaDuong = ddlMaDuong.SelectedValue
                .MaPhuong = ddlMaPhuong.SelectedValue
                .SoNha = Trim(txtSoNha.Text)
            End With

            'kiểm tra bảng hiệu
            If Trim(txtBangHieu.Text) <> "" Then
                Session("TimKiemGiayCNDKKDCUT") = Trim(txtBangHieu.Text)
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
            If objKiemTraInfo.SoNha <> "" Or objKiemTraInfo.MaDuong <> "" Or objKiemTraInfo.MaPhuong <> "" Then
                If Not objKiemTra.KiemTraDiaChiDKKD(objKiemTraInfo) Then
                    lblKetQuaKiemTraDiaChiDKKD.Text = "Địa chỉ này đã được đăng ký kinh doanh"
                End If
            End If

            'kiểm tra CMND/Passport
            If objKiemTraInfo.SoCMND <> "" Then
                If Not objKiemTra.KiemTraSoCMND(objKiemTraInfo) Then
                    lblKetQuaKiemTraDiaChiDKKD.Text = "Số CMND/Passport này đã được đăng ký kinh doanh"
                End If
            End If

            ''kiểm tra người đăng ký
            'If Trim(txtHoTen.Text) <> "" Or Trim(txtSoCMND.Text) <> "" Then
            '    lblKetQuaThongTin.Text = objKiemTra.KiemTraNguoiDangKy(objKiemTraInfo)
            'End If

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
            If objKiemTraInfo.MaNganh <> "" Then
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
            If objKiemTraInfo.MaNganh <> "" Then
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

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click

            'TuanNH update ngay 22/09/2006
            'Kiem tra in Giay CNDKKD by Word hay Report
            If CType(ConfigurationSettings.AppSettings("InGiayCNDKKDByWord"), String) = "1" Then

                Dim objGiayCNDKKD As New GiayCNDKKDController
                Dim ds As New DataSet
                Dim Script As String
                'Dim strTemplateFileName As String
                'Dim strOutputFileName As String

                'strTemplateFileName = GetParamByID("FileGiayCNDKKD", glbXMLFile)
                'strOutputFileName = "GiayCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

                '' Neu cap lai cap doi thi cap so moi 
                'If strControl = "CAPDOICNDKKD" Then
                '    ds = objGiayCNDKKD.InGiayCNDKKD_DoiSo(txtGiayCNDKKDIDMoi.Text, txtSoGiayPhep.Text)
                'Else
                '    ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDIDMoi.Text)
                'End If

                '--*TUNGLDL*--'
                'Cấp lại chỉ đổi số mới khi check chọn
                If strControl = "CAPDOICNDKKD" Then
                    If chkDoiSo.Checked = True Then
                        ds = objGiayCNDKKD.InGiayCNDKKD_DoiSo(txtGiayCNDKKDIDMoi.Text, txtSoGiayPhep.Text)
                    Else
                        ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID1.Text)
                    End If
                Else
                    ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDIDMoi.Text)
                End If

                'ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDIDMoi.Text)
                'Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
                'Page.RegisterStartupScript("OpenWindow", Script)

                Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", InGiayCNDKKD(Request, ds, GetLinhVuc()))
                Page.RegisterStartupScript("OpenWindow", Script)

                objGiayCNDKKD = Nothing
                ds = Nothing

                If lblLabelSoGiayPhepMoi.Text = "" Then
                    InitState()
                    'If ddlMaLinhVucCapPhep.SelectedValue <> "" Then
                    '    Page.RegisterStartupScript("LINHVUCCAPPHEP", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganh))
                    '    'ddlMaNganh.Attributes.Add("ISNULL", "NOTNNULL")
                    'End If

                    If ddlMaPhuongThucKinhDoanh.SelectedValue <> "" Then
                        Page.RegisterStartupScript("LINHVUCCAPPHEP", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganh))
                        'ddlMaNganh.Attributes.Add("ISNULL", "NOTNNULL")
                    End If
                End If
                lblKetQuaNganhDieuKien.Text = ""
                lblKetQuaNganhCam.Text = ""
                lblKetQuaThongTin.Text = ""
                lblKetQuaVPHC.Text = ""
                lblKetQuaKiemTraBangHieu.Text = ""

            End If

        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objCapCNDKKD As New GiayCNDKKDController
            objCapCNDKKD.DelGIAYCNDKKD(txtGiayCNDKKDIDMoi.Text)
            btnBoQua_Click(Nothing, Nothing)
        End Sub

        Private Sub txtSoGiayPhep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoGiayPhep.TextChanged
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            txtSoGiayPhep.Text = Trim(txtSoGiayPhep.Text)
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep1(txtSoGiayPhep.Text)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        gLoadControlValues(ds, Me)
                        Exit Sub
                    End If
                End If
            End If
            'SetMSGBOX_HIDDEN(Page, "So giay phep nay khong ton tai hoac chua duoc hoat dong!")
            'SetFocus(Page, txtSoGiayPhep)
        End Sub

        Private Sub InitLabelKiemTra()
            lblKetQuaKiemTraBangHieu.Text = ""
            hplDanhSachBangHieu.Visible = False
            hplDanhSachDiaChi.Visible = False
            lblKetQuaKiemTraDiaChiDKKD.Text = ""
            lblKetQuaThongTin.Text = ""
            lblKetQuaVPHC.Text = ""
            lblKetQuaNganhCam.Text = ""
            lblKetQuaNganhDieuKien.Text = ""
        End Sub
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
            If dtCart.Rows(index)("ID").ToString().Trim() <> "" Then
                'Dim objGiayCNDKKD As New GiayCNDKKDController
                'objGiayCNDKKD.THANHVIENHKD_Del(dtCart.Rows(index)("ID").ToString().Trim())

                ''dispose object
                'objGiayCNDKKD = Nothing
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
