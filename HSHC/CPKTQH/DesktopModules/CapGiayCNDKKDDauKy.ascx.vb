Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class CapGiayCNDKKDDauKy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSo As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoGiayPhepTruoc1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhepTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaHinhThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCap As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayHetHan As System.Web.UI.WebControls.Image
        Protected WithEvents lblKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebsite As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDanToc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgaySinh As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCapCMND As System.Web.UI.WebControls.Image
        Protected WithEvents txtNoiCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDIDTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents cMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents KiemTra As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtSoLanCapDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLanThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLanCapPhoBan As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayCapGiayPhepTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayHetHan As System.Web.UI.WebControls.TextBox
        Protected WithEvents LableCapNhat As System.Web.UI.WebControls.Label
        Protected WithEvents LabelXoa As System.Web.UI.WebControls.Label
        Protected WithEvents LabelCapDoi As System.Web.UI.WebControls.Label
        Protected WithEvents LabelThayDoi As System.Web.UI.WebControls.Label
        Protected WithEvents LabelNgung As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapDoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThayDoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnNgung As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblLabelDonViTinh As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilterPhuong As PortalQH.ComboFilter
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaLinhVucCapPhep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTongSoLaoDong As System.Web.UI.WebControls.TextBox

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
                SetAttibutesControl()
                BindData()

                txtGiayCNDKKDID.Text = Request.Params("ID")
                txtMaSoNguoiSuDung.Text = CStr(Session("UserName"))
                If txtGiayCNDKKDID.Text <> "" Then
                    ThongTinGCNDKKD()   'lấy thông tin giấy CN ĐKKD
                    'NamTH update Quan 4
                    'SetEnableControlGiayPhep() 'set enable = false các thông tin về các giấy phép trước đó
                    KiemTraCapDoi()     'Kiểm tra có phải trường hợp cấp đổi giấy CN ĐKKD không
                Else
                    SetDefault()
                End If
                SetVisibleControl()
                If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                    Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganhKinhDoanh) & _
                                                                            ReLoadComboFilter(ctrlScriptComboFilterPhuong, ddlMaDuong))
                End If
                Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganhKinhDoanh))
            End If
        End Sub

        Private Sub SetAttibutesControl()
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            'PhuocDD updated Apr 06th 2006
            'Remove require
            'txtBangHieu.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaLinhVucCapPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuongThucKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganhKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtMatHangKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtVonKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            txtSoCMND.Attributes.Add("ISNULL", "NOTNULL")
            txtNgaySinh.Attributes.Add("ISNULL", "NOTNULL")
            txtThuongTru.Attributes.Add("ISNULL", "NOTNULL")

            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
            'ddlMaLinhVucCapPhep.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            ddlMaPhuongThucKinhDoanh.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            'ddlMaHinhThucKinhDoanh.Attributes.Add("onchange", "javascript:KiemTraHinhThucKinhDoanh();")

            'PhuocDD updated Apr 04th 2006
            'Added DonViTinh
            txtVonKinhDoanh.Attributes.Add("onblur", "javascript:ConvertNumericVN(" & _
                                                                txtVonKinhDoanh.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")
            txtEmail.Attributes.Add("onblur", "javascript:validateEmail(" & txtEmail.ClientID & ");")

            txtNgayCapGiayPhepTruoc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCapGiayPhepTruoc.ClientID & ");")
            txtNgayCapGiayPhepTruoc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapGiayPhepTruoc.ClientID & ");")
            txtNgayCapGiayPhepTruoc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapGoc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCapGoc.ClientID & ");")
            txtNgayCapGoc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapGoc.ClientID & ");")
            txtNgayCapGoc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHetHan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayHetHan);")
            imgNgayHetHan.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayHetHan, 'dd/mm/yyyy');")
            txtNgayHetHan.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayHetHan.ClientID & ");")
            txtNgayHetHan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap);")
            imgNgayCap.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap, 'dd/mm/yyyy');")
            txtNgayCap.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCap.ClientID & ");")
            txtNgayCap.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgaySinh.Attributes.Add("onblur", "javascript:KiemTraNamSinhDKKD(" & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinh);")
            imgNgaySinh.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinh, 'dd/mm/yyyy');")
            txtNgaySinh.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgaySinh.ClientID & ");")
            txtNgaySinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapCMND.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMND);")
            imgNgayCapCMND.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMND, 'dd/mm/yyyy');")
            txtNgayCapCMND.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapCMND.ClientID & ");")
            txtNgayCapCMND.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            ddlMaNganhKinhDoanh.Attributes.Add("onblur", "javascript:getNganhKinhDoanh(" & ddlMaNganhKinhDoanh.ClientID & "," & txtMatHangKinhDoanh.ClientID & ");")
        End Sub

        Private Sub BindData()
            Dim dsPhuongThuc As New DataSet

            'Doan loc duong theo phuong
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Dim dsPhuong As New DataSet
                Dim dsDuong As New DataSet
                Dim objDanhMuc As New DanhMucController
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
            'BindControl.BindDropDownList(ddlMaHinhThucKinhDoanh, "DMHINHTHUCKINHDOANH")
            BindDropDownList_NguoiKy(ddlMaSoLanhDao)

            Dim dsLinhVuc As New DataSet
            Dim dsNganh As New DataSet
            Dim objNganhKD As New NganhKinhDoanhController

            dsLinhVuc = objNganhKD.getLinhVucCapPhep()
            'dsNganh = objNganhKD.getNganhKinhDoanhChinh()
            dsNganh = objNganhKD.getPhuongThucNganhNghe()
            dsPhuongThuc = objNganhKD.getPhuongThucKinhDoanh()
            objNganhKD = Nothing

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

            ddlMaNganhKinhDoanh.DataSource = dsNganh
            ddlMaNganhKinhDoanh.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanh.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanh.DataBind()
            ddlMaNganhKinhDoanh.Items.Insert(0, "")
            With ctrlScriptComboFilter
                .ConditionID = ddlMaPhuongThucKinhDoanh.ClientID 'ddlMaLinhVucCapPhep.ClientID
                .ConditionText = "TenLinhVuc"
                .ConditionValue = "MaLinhVuc"

                .ResultID = ddlMaNganhKinhDoanh.ClientID
                .ResultText = "TenNganh"
                .ResultValue = "MaNganh"
                .ConditionDS = dsLinhVuc
                .ResultDS = dsNganh
            End With
            dsLinhVuc = Nothing
            dsNganh = Nothing
        End Sub

        Private Sub ThongTinGCNDKKD()
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet

            ds = objGiayCNDKKD.GetGiayCNDKKDByID(txtGiayCNDKKDID.Text)
            gLoadControlValues(ds, Me)
            If txtGiayCNDKKDID.Text = "" Then   'trường hợp không tồn tại ID này
                btnBoQua_Click(Nothing, Nothing)
            End If
            ds = Nothing
            objGiayCNDKKD = Nothing
        End Sub

        Private Sub SetEnableControlGiayPhep()
            txtSoGiayPhepGoc.Enabled = False
            txtNgayCapGoc.Enabled = False
            txtSoGiayPhepTruoc.Enabled = False
            txtNgayCapGiayPhepTruoc.Enabled = False

            If Request.Params("ctl") = getControlCapDoiCNDKKD() Then
                txtSoLanCapDoi.Enabled = False
                txtSoLanCapPhoBan.Enabled = False
                txtSoLanThayDoi.Enabled = False
            End If
        End Sub

        Private Sub SetVisibleControl()
            'trường hợp chưa có dữ liệu về giấy CN
            If txtGiayCNDKKDID.Text = "" Then
                btnXoa.Visible = False
                LabelXoa.Visible = False
                btnCapDoi.Visible = False
                LabelCapDoi.Visible = False
                btnThayDoi.Visible = False
                LabelThayDoi.Visible = False
                btnNgung.Visible = False
                LabelNgung.Visible = False
            Else
                Dim objGiayCNDKKD As New GiayCNDKKDController
                Dim ds As DataSet
                ds = objGiayCNDKKD.KiemTraDauKi(txtGiayCNDKKDID.Text)
                If ds.Tables(0).Rows(0).Item("DaThayDoi").ToString = "1" Then
                    'trường hợp đã nhập liệu nội dung thay đổi đối với giấy CN ĐKKD này
                    EnableControls(Me, False)
                    btnCapNhat.Visible = False
                    LableCapNhat.Visible = False
                    btnXoa.Visible = False
                    LableCapNhat.Visible = False
                End If
                'tạm thời visible = false tất cả các nút Cấp đổi,thay đổi, ngưng
                btnCapDoi.Visible = False
                LabelCapDoi.Visible = False
                btnThayDoi.Visible = False
                LabelThayDoi.Visible = False
                btnNgung.Visible = False
                LabelNgung.Visible = False
                'If ds.Tables(0).Rows(0).Item("DaNgungKinhDoanh").ToString = "1" Then
                '    'trường hợp đã nhập liệu nội dung thay đổi đối với giấy CN ĐKKD này
                '    SetEnableControl(Me, False)
                '    btnCapNhat.Visible = False
                '    LableCapNhat.Visible = False
                '    btnXoa.Visible = False
                '    LableCapNhat.Visible = False
                '    btnCapDoi.Visible = False
                '    LabelCapDoi.Visible = False
                '    btnThayDoi.Visible = False
                '    LabelThayDoi.Visible = False
                'End If
                'objGiayCNDKKD = Nothing
            End If

        End Sub

        Private Sub KiemTraCapDoi()
            Dim strControl As String
            strControl = Request.Params("ctl")

            'kiểm tra có phải trường hợp cấp đổi giấy CN không
            If UCase(strControl) = UCase(getControlCapDoiCNDKKD()) Then
                'nếu là trường hợp cấp đổi thì chuyển các thông tin về số giấy phép, ngày cấp thành số giấy phép trước, ngày cấp giấy phép trước
                txtGiayCNDKKDIDTruoc.Text = txtGiayCNDKKDID.Text
                txtSoGiayPhepTruoc.Text = txtSoGiayPhep.Text
                txtNgayCapGiayPhepTruoc.Text = txtNgayCap.Text

                txtGiayCNDKKDID.Text = ""
                txtSoGiayPhep.Text = ""
                txtNgayCap.Text = Format(Now, "dd/MM/yyyy")
            Else
                'NamTH update Quan 4
                'txtSoGiayPhep.Enabled = False
            End If
        End Sub

        Private Sub SetDefault()
            txtNgayCap.Text = Format(Now, "dd/MM/yyyy")
            txtNgayCapGoc.Text = txtNgayCap.Text
            txtNgayCapGiayPhepTruoc.Text = txtNgayCap.Text
            txtSoLanCapDoi.Text = "0"
            txtSoLanCapPhoBan.Text = "0"
            txtSoLanThayDoi.Text = "0"
            lblLabelDonViTinh.Text = getLabelDonViTinh()
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim strGiayCNDKKDID As String
            Dim strURL As String

            'If txtSoGiayPhep.Enabled Then 'trường hợp cho phép nhập liệu số giấy phép --> kiểm tra số giấy phép có tồn tại trong hệ thống không
            '    If Not KiemTraThongTinNhapLieu() Then
            '        Exit Sub
            '    End If
            'End If

            strGiayCNDKKDID = objGiayCNDKKD.insGiayCNDKKDDauKi(Me)
            objGiayCNDKKD = Nothing

            If strGiayCNDKKDID = "" Then
                SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                Exit Sub
            End If
            If txtGiayCNDKKDID.Text = "" Then   'trường hợp nhập mới phải refresh lại trang
                If Request.Params("ID") Is Nothing Then
                    strURL = Request.RawUrl & "&ID=" & strGiayCNDKKDID
                Else
                    strURL = Replace(Request.RawUrl, "ID=" & Request.Params("ID"), "ID=" & strGiayCNDKKDID)
                End If
                If UCase(Request.Params("ctl")) = UCase(getControlCapDoiCNDKKD()) Then
                    strURL = Replace(strURL, "ctl=" & Request.Params("ctl"), "ctl=" & getControlCapMoiCNDKKD())
                End If
                Response.Redirect(strURL)
            End If

        End Sub

        Private Function KiemTraThongTinNhapLieu() As Boolean
            Dim objKiemTraInfo As New KiemTraHoSoInfo
            Dim objKiemTra As New KiemTraHoSoController
            Dim ds As DataSet

            objKiemTraInfo.SoGiayPhep = Trim(txtSoGiayPhep.Text)
            objKiemTraInfo.BangHieu = Trim(txtBangHieu.Text)
            objKiemTraInfo.HoTen = Trim(txtHoTen.Text)
            ds = objKiemTra.KiemTraThongTinDKKD(objKiemTraInfo)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        SetMSGBOX_HIDDEN(Page, "So giay phep nay da ton tai trong he thong!")
                        SetFocus(Page, txtSoGiayPhep)
                        Return False
                    End If
                End If
            End If

            objKiemTra = Nothing
            objKiemTraInfo = Nothing
            Return True
        End Function

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            objGiayCNDKKD.DelGIAYCNDKKD(txtGiayCNDKKDID.Text)
            objGiayCNDKKD = Nothing
            Response.Redirect(NavigateURL)
        End Sub

        Private Sub btnNgung_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNgung.Click
            Response.Redirect(EditURL("ID", txtGiayCNDKKDID.Text, "NGUNGKINHDOANH"))
        End Sub
    End Class

End Namespace
