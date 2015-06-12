Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH
Namespace CPXD
    Public Class ThayDoiKinhDoanh
        Inherits PortalQH.PortalModuleControl
        Dim strControl As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDanhSach As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDanhSachGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCapDKKD As System.Web.UI.WebControls.Image
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDKTD As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayDangKyBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDKBS As System.Web.UI.WebControls.Image
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTenCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTruCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongTrinhXayDungCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKyHieuThietKeCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDonViThietKeCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetCauCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChieuCaoTungTangCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChieuCaoToanCongTrinhCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichXayDungCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichSanXayDungCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChuHangMucCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoDatCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCaoDoNenCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChiGioiCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNhaCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuongCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuongCu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkHoTen As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtHoTenMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNganhMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDiaChiThuongTru As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDiaChiThuongTruMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCongTrinhXayDung As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtCongTrinhXayDungMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkKyHieuThietKe As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtKyHieuThietKeMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDonViThietKe As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDonViThietKeMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkKetCau As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtKetCauMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkChieuCaoTungTang As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtChieuCaoTungTangMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkChieuCaoToanCongTrinh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtChieuCaoToanCongTrinhMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDienTichXayDung As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDienTichXayDungMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDienTichSanXayDung As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDienTichSanXayDungMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkGhiChuHangMuc As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtGhiChuHangMucMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkLoDat As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtLoDatMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTienBangChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCaoDoNen As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtCaoDoNenMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkChiGioi As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtChiGioiMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkSoNha As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtSoNhaMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkMaDuong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaDuongMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkMaPhuong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMaPhuongMoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnInDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYeuCauBoSung As System.Web.UI.WebControls.LinkButton


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
            lblTieuDe.Text = "Thay đổi nội dung giấy phép xây dựng"
            strControl = Request.Params("ctl")

            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap);")
            imgNgayCapDKKD.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap, 'dd/mm/yyyy');")

            txtNgayDangKyBoSung.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayDangKyBoSung);")
            imgNgayDKBS.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayDangKyBoSung, 'dd/mm/yyyy');")

            txtNgayThayDoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayThayDoi);")
            imgNgayDKTD.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayThayDoi, 'dd/mm/yyyy');")

            Dim strURL As String
            strURL = "CPXD/DesktopModules/TimKiemGiayCNDKKD.aspx"
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")

            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaDuongMoi, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuongMoi, "DMPHUONG")
                BindControl.BindDropDownList(ddlMaDuongCu, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuongCu, "DMPHUONG")
                BindDropDownList_NguoiKy(ddlMaSoLanhDao)
                txtReload.Text = "0"
                BindData()
                If txtSoGiayPhep.Text = "" Then
                    ViewState.Item("AddNew") = True
                Else
                    ViewState.Item("AddNew") = False
                End If
                SetStatusControl(ViewState.Item("AddNew"))
                If txtNgayThayDoi.Text = "" Then
                    txtNgayThayDoi.Text = NgayHienTai()
                End If
            End If
            If Trim(txtSoGiayPhep.Text) <> "" And txtReload.Text = "1" Then
                GetGiayCNDKKD()
                txtReload.Text = "0"
            End If
            If Not Request.Params("ID") Is Nothing Then
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                Dim objHoSoTiepNhan As New HoSoTiepNhanController
                txtSoBienNhan.Text = objHoSoTiepNhan.GetSoBienNhan(txtHoSoTiepNhanID.Text)
                objHoSoTiepNhan = Nothing
            End If
            SetAttribute()
            SetStatusControl(ViewState.Item("AddNew"))
            txtNgayThayDoi.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", ctype(Session.Item("ActiveDB"),string), btnIn, Me)
        End Sub


        Private Sub SetAttribute()
            chkHoTen.Attributes.Add("onclick", "javascript:SetStatus('" & chkHoTen.ClientID & "','" & txtHoTenMoi.ClientID & "');")
            chkDiaChiThuongTru.Attributes.Add("onclick", "javascript:SetStatus('" & chkDiaChiThuongTru.ClientID & "','" & txtDiaChiThuongTruMoi.ClientID & "');")
            chkCaoDoNen.Attributes.Add("onclick", "javascript:SetStatus('" & chkCaoDoNen.ClientID & "','" & txtCaoDoNenMoi.ClientID & "');")
            chkChiGioi.Attributes.Add("onclick", "javascript:SetStatus('" & chkChiGioi.ClientID & "','" & txtChiGioiMoi.ClientID & "');")
            chkCongTrinhXayDung.Attributes.Add("onclick", "javascript:SetStatus('" & chkCongTrinhXayDung.ClientID & "','" & txtCongTrinhXayDungMoi.ClientID & "');")
            chkKyHieuThietKe.Attributes.Add("onclick", "javascript:SetStatus('" & chkKyHieuThietKe.ClientID & "','" & txtKyHieuThietKeMoi.ClientID & "');")
            chkDonViThietKe.Attributes.Add("onclick", "javascript:SetStatus('" & chkDonViThietKe.ClientID & "','" & txtDonViThietKeMoi.ClientID & "');")
            chkLoDat.Attributes.Add("onclick", "javascript:SetStatus('" & chkLoDat.ClientID & "','" & txtLoDatMoi.ClientID & "');")
            chkMaDuong.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaDuong.ClientID & "','" & ddlMaDuongMoi.ClientID & "');")
            chkMaPhuong.Attributes.Add("onclick", "javascript:SetStatus('" & chkMaPhuong.ClientID & "','" & ddlMaPhuongMoi.ClientID & "');")
            chkSoNha.Attributes.Add("onclick", "javascript:SetStatus('" & chkSoNha.ClientID & "','" & txtSoNhaMoi.ClientID & "');")
            chkKetCau.Attributes.Add("onclick", "javascript:SetStatus('" & chkKetCau.ClientID & "','" & txtKetCauMoi.ClientID & "');")
            chkChieuCaoTungTang.Attributes.Add("onclick", "javascript:SetStatus('" & chkChieuCaoTungTang.ClientID & "','" & txtChieuCaoTungTangMoi.ClientID & "');")
            chkChieuCaoToanCongTrinh.Attributes.Add("onclick", "javascript:SetStatus('" & chkChieuCaoToanCongTrinh.ClientID & "','" & txtChieuCaoToanCongTrinhMoi.ClientID & "');")
            chkDienTichXayDung.Attributes.Add("onclick", "javascript:SetStatus('" & chkDienTichXayDung.ClientID & "','" & txtDienTichXayDungMoi.ClientID & "');")
            chkDienTichSanXayDung.Attributes.Add("onclick", "javascript:SetStatus('" & chkDienTichSanXayDung.ClientID & "','" & txtDienTichSanXayDungMoi.ClientID & "');")
            chkGhiChuHangMuc.Attributes.Add("onclick", "javascript:SetStatus('" & chkGhiChuHangMuc.ClientID & "','" & txtGhiChuHangMucMoi.ClientID & "');")
        End Sub

        Private Sub GetGiayCNDKKD()
            Dim objGiayCNDKKD As New GPXDController
            Dim ds As DataSet
            ds = objGiayCNDKKD.GetGPXDBySoGiayPhep(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me)
            ds = Nothing

        End Sub

        Private Sub txtSoGiayPhep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoGiayPhep.TextChanged
            GetGiayCNDKKD()
        End Sub

        Private Function LoadThayDoiNoiDungKinhDoanh() As Integer
            Dim ds As DataSet
            Dim strHoTen As String
            Dim objThayDoiNoiDungKinhDoanh As New ThayDoiNoiDungKinhDoanhController
            ds = objThayDoiNoiDungKinhDoanh.GetThayDoiNoiDungKinhDoanh(txtHoSoTiepNhanID.Text)
            gLoadControlValues(ds, Me)
            strHoTen = txtHoTen.Text
            GetGiayCNDKKD()
            txtHoTen.Text = strHoTen
            Dim dv As DataView
            Dim i As Integer
            ds = objThayDoiNoiDungKinhDoanh.GetThayDoiNoiDungKinhDoanh_ChiTiet(txtHoSoTiepNhanID.Text)
            dv = ds.Tables(0).DefaultView
            For i = 0 To dv.Count - 1
                SetNoiDung(dv.Item(i).Item("TenTruong") & "cu", Me, dv.Item(i).Item("NoiDungTruoc"))
                SetNoiDung(dv.Item(i).Item("TenTruong") & "moi", Me, dv.Item(i).Item("NoiDungMoi"))
                If UCase(dv.Item(i).Item("TenTruong")) = "MANGANH" Then
                    SetNoiDung("TenNganhCu", Me, dv.Item(i).Item("TenNganhCu"))
                    SetNoiDung("TenNganhMoi", Me, dv.Item(i).Item("TenNganhMoi"))
                End If
            Next


            dv = Nothing
            ds = Nothing
        End Function
        Private Function CapNhatThayDoi() As Boolean
            'Cap nhat vao bang thay doi noi dung kinh doanh

            Dim strTentruong, strNoiDungCu, strNoiDungMoi As String
            Dim objThayDoiNoiDungKDInfo As New ThayDoiNoiDungKinhDoanhInfo
            Dim objThayDoiNoiDungKD As New ThayDoiNoiDungKinhDoanhController
            Dim blnThayDoi As Boolean = False
            With objThayDoiNoiDungKDInfo
                .GiayCNDKKDID = txtGiayCNDKKDID.Text
                .HoSoTiepNhanID = txtHoSoTiepNhanID.Text
                .NgayCapGiayPhepGoc = IIf(txtNgayCapGiayPhepGoc.Text = "", Nothing, txtNgayCapGiayPhepGoc.Text)
                .NgayDangKyBoSung = IIf(txtNgayDangKyBoSung.Text = "", Nothing, txtNgayDangKyBoSung.Text)
                .NgayThayDoi = IIf(txtNgayThayDoi.Text = "", Nothing, txtNgayThayDoi.Text)
                .SoGiayPhep = txtSoGiayPhep.Text
                .SoGiayPhepGoc = txtSoGiayPhepGoc.Text
                .MaLinhVuc = CType(Session.Item("ItemCode"), String)
                .TabCode = CType(TabId, String)
                .MaNguoiTacNghiep = CType(Session.Item("UserName"), String)
                .MaSoLanhDao = ddlMaSoLanhDao.SelectedValue
                .GhiChu = txtGhiChu.Text
                Dim ctrl As Control
                For Each ctrl In Me.Controls
                    Select Case True
                        Case TypeOf ctrl Is CheckBox
                            If CType(ctrl, CheckBox).Checked Then
                                .TenTruong = Mid(ctrl.ID, 4)
                                .NoiDungTruoc = GetNoiDung(.TenTruong & "cu", Me)
                                .NoiDungMoi = GetNoiDung(.TenTruong & "moi", Me)
                                objThayDoiNoiDungKD.AddThayDoiNoiDungKinhDoanh(objThayDoiNoiDungKDInfo)
                                blnThayDoi = True
                                'reset
                                CType(ctrl, CheckBox).Checked = False
                            End If
                    End Select
                Next
                
                Return True
            End With
        End Function
        Private Function GetNoiDung(ByVal strTenTruong As String, ByVal obj As Object) As String
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
        Private Sub SetNoiDung(ByVal strTenTruong As String, ByVal obj As Object, ByVal strValue As String)
            Dim ctrl As Control
            For Each ctrl In Me.Controls
                Select Case True
                    Case TypeOf ctrl Is TextBox
                        If UCase(Mid(ctrl.ID, 4)) = UCase(strTenTruong) Then
                            CType(ctrl, TextBox).Text = strValue
                        End If
                    Case TypeOf ctrl Is DropDownList
                        If UCase(Mid(ctrl.ID, 4)) = UCase(strTenTruong) Then
                            CType(ctrl, DropDownList).SelectedValue = strValue
                        End If
                End Select
            Next
        End Sub

        Private Sub BindData()
            Dim ds As DataSet
            If Not Request.Params("ID") Is Nothing Then
                txtHoSoTiepNhanID.Text = Request.Params("ID")
            End If
            'Select Case Request.Params("AddNew")
            '    Case "False" 'Load thong tin tu bang THAYDOINOIDUNGKINHDOANH
            '        LoadThayDoiNoiDungKinhDoanh()
            '    Case "True"
            '        btnDanhSachGP.Visible = True

            'End Select
            LoadThayDoiNoiDungKinhDoanh
            btnDanhSachGP.Visible = True

        End Sub


        Private Sub SetStatusControl(ByVal btnAddNew As Boolean)
            'Session.Item("IsAddNew") = btnAddNew
            btnDanhSachGP.Visible = btnAddNew
            'txtSoGiayPhep.ReadOnly = Not Session.Item("IsAddNew")
            'btnXoa.Visible = Not Session.Item("IsAddNew")
            txtSoGiayPhep.ReadOnly = Not btnAddNew
            btnXoa.Visible = Not btnAddNew
            txtNgayCap.ReadOnly = True
            txtHoTen.ReadOnly = True
            'If txtSoBienNhan.Text = "" Then
            '    btnDanhSachGP.Visible = False
            'End If
            lblDanhSach.Visible = Not btnDanhSach.Visible
            lblDanhSachGP.Visible = Not btnDanhSachGP.Visible
            btnIn.Visible = btnXoa.Visible
        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDanhSach.Click
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl")), True)
            SetStatusControl(True)
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            If txtSoBienNhan.Text = "" Or txtSoGiayPhep.Text = "" Then Exit Sub
            If CapNhatThayDoi() Then
                SetStatusControl(False)
            End If
            'm_IsAddNew = False
            ViewState.Item("Addnew") = False
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThayDoiNoiDungKDInfo As New ThayDoiNoiDungKinhDoanhInfo
            Dim objThayDoiNoiDungKD As New ThayDoiNoiDungKinhDoanhController
            With objThayDoiNoiDungKDInfo
                .GiayCNDKKDID = txtGiayCNDKKDID.Text
                .HoSoTiepNhanID = txtHoSoTiepNhanID.Text
                .MaLinhVuc = CType(Session.Item("ItemCode"), String)
                .TabCode = CType(TabId, String)
                .MaNguoiTacNghiep = CType(Session.Item("UserName"), String)
            End With
            objThayDoiNoiDungKD.DelThayDoiNoiDungKinhDoanh(objThayDoiNoiDungKDInfo)
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objThayDoiNoiDungKinhDoanh As New ThayDoiNoiDungKinhDoanhController
            Dim ds As New DataSet
            Dim strFileName As String
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            strFileName = GetParamByID("FileDieuChinhNoiDung", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & Mid(strFileName, 1, Len(strFileName) - 4) & CType(Session.Item("UserName"), String) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objThayDoiNoiDungKinhDoanh.InDieuChinhNoiDungGPXD(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objThayDoiNoiDungKinhDoanh = Nothing
        End Sub

        Private Sub btnInDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInDeXuat.Click
            Dim objThayDoiNoiDungKinhDoanh As New ThayDoiNoiDungKinhDoanhController
            Dim ds As New DataSet
            Dim strFileName As String
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            strFileName = GetParamByID("FileDeXuatDieuChinhNoiDung", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & Mid(strFileName, 1, Len(strFileName) - 4) & CType(Session.Item("UserName"), String) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objThayDoiNoiDungKinhDoanh.InDeXuat(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objThayDoiNoiDungKinhDoanh = Nothing
        End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            strHoSoTiepNhanID = txtHoSoTiepNhanID.Text
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & strControl, True)
        End Sub

        Private Sub btnYeuCauBoSung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYeuCauBoSung.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSK As New HoSoKhongGiaiQuyetController
            Dim objBCDX As New BaoCaoDeXuatController
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            If strSoBienNhan <> "" And objBCDX.CheckBaoCaoDeXuat(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so da lam de xuat")
                Exit Sub
            End If
            Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG") & "&oldControl=" & strControl, True)
        End Sub
    End Class

End Namespace