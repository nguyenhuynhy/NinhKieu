Imports PortalQH
Imports System.Configuration
Namespace CPLDQH
    Public Class SuDungLaoDong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label18 As System.Web.UI.WebControls.Label
        Protected WithEvents Label21 As System.Web.UI.WebControls.Label
        Protected WithEvents Label24 As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLaoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLaoDongNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongKyMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongKyMoiNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayHopDongLaoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauThanhPhoNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauThanhPhoNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTinhNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTinhNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongThuNhap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLuongChinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLaoDongKhongXacDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLaoDongXacDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLaoDongThoiVu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSuDungLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayNhan As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayHopDong As System.Web.UI.WebControls.Image
        Protected WithEvents cmdNgayNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayHopDong As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtHopDongLaoDongGiaHan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongGiaHanNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtTenChuDonVi As System.Web.UI.WebControls.TextBox

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
            SetAttribute()
            If Not Page.IsPostBack Then
                InitState()
                BindData()
                txtTabCode.Text = CType(Request.Params("TabID"), String)
                txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
                txtMaSoNguoiSuDung.Text = CType(Session.Item("UserName"), String)
                If txtNgayNhan.Text = "" Then txtNgayNhan.Text = NgayHienTai()

            End If
            SetVisibleButton()
            'Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaDuong))
        End Sub

        Sub SetVisibleButton()
            If txtSuDungLaoDongID.Text <> "" Then
                btnXoa.Visible = True
                btnYCBS.Visible = False
                btnHoSoKhong.Visible = False
            Else
                btnXoa.Visible = False
                btnYCBS.Visible = True
                btnHoSoKhong.Visible = True
            End If
            If CType(Request.QueryString("ctl"), String) = "SUDUNGLAODONG" Then
                btnYCBS.Visible = True
                btnHoSoKhong.Visible = True
            Else
                btnYCBS.Visible = False
                btnHoSoKhong.Visible = False
            End If
        End Sub

        Sub InitState()
            BindControl.BindDropDownList(ddlMaLoaiHinhDoanhNghiep, "DMLOAIHINHDOANHNGHIEP", , True)
            'BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            'BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            'Doan loc duong theo phuong
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
            Dim objDanhMuc As New DanhMucController
            dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
            dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
            BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, "")
            BindDropDownList_Dataset(ddlMaDuong, dsDuong, "TenDuong", "MaDuong", True, "")
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                With ctrlScriptComboFilter
                    .ConditionID = ddlMaPhuong.ClientID
                    .ConditionText = "Ten"
                    .ConditionValue = "Ma"
                    .ResultID = ddlMaDuong.ClientID
                    .ResultText = "TenDuong"
                    .ResultValue = "MaDuong"
                    .ConditionDS = dsPhuong
                    .ResultDS = dsDuong
                End With
                ddlMaPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            Else
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            End If

            '-------------------------------------------------------------
        End Sub

        Private Sub SetAttribute()
            'add lich cho ngay
            txtNgayNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayNhan.ClientID & ");")
            cmdNgayNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayNhan)

            txtNgayHopDongLaoDong.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHopDongLaoDong.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHopDongLaoDong.ClientID & ");")
            cmdNgayHopDong.NavigateUrl = AdminDB.InvokePopupCal(txtNgayHopDongLaoDong)
            'kiem tra la so
            txtTongSoLaoDong.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLaoDong.ClientID & ");")
            txtTongSoLaoDongNu.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLaoDongNu.ClientID & ");")

            txtHopDongLaoDongKyMoi.Attributes.Add("onblur", "javascript:CheckData(" & txtHopDongLaoDongKyMoi.ClientID & ");")
            txtHopDongLaoDongKyMoiNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHopDongLaoDongKyMoiNu.ClientID & ");")

            txtHopDongLaoDongGiaHan.Attributes.Add("onblur", "javascript:CheckData(" & txtHopDongLaoDongGiaHan.ClientID & ");")
            txtHopDongLaoDongGiaHanNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHopDongLaoDongGiaHanNu.ClientID & ");")

            txtHoKhauThanhPhoNam.Attributes.Add("onblur", "javascript:CheckData(" & txtHoKhauThanhPhoNam.ClientID & ");")
            txtHoKhauThanhPhoNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHoKhauThanhPhoNu.ClientID & ");")

            txtHoKhauTinhNam.Attributes.Add("onblur", "javascript:CheckData(" & txtHoKhauTinhNam.ClientID & ");")
            txtHoKhauTinhNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHoKhauTinhNu.ClientID & ");")

            txtTongThuNhap.Attributes.Add("onblur", "javascript:CheckData(" & txtTongThuNhap.ClientID & ");")
            txtLuongChinh.Attributes.Add("onblur", "javascript:CheckData(" & txtLuongChinh.ClientID & ");")

            txtSoLaoDongKhongXacDinh.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLaoDongKhongXacDinh.ClientID & ");")
            txtSoLaoDongXacDinh.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLaoDongXacDinh.ClientID & ");")
            txtSoLaoDongThoiVu.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLaoDongThoiVu.ClientID & ");")
            'set thuoc tinh not null
            'txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ''''''''''''''''''''''''
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Sub BindData()
            Dim objSuDungLaoDong As New SuDungLaoDongController
            Dim ds As DataSet

            If CType(Request.QueryString("ctl"), String) = "SUDUNGLAODONG" Then
                btnThemMoi.Visible = False
                If Not Request.QueryString("ID") Is Nothing Then
                    txtHoSoTiepNhanID.Text = CType(Request.QueryString("ID"), String)
                End If
                ds = objSuDungLaoDong.GetSuDungLaoDong(txtHoSoTiepNhanID.Text)
            Else
                If txtSuDungLaoDongID.Text = "" Then
                    If Not Request.QueryString("ID") Is Nothing Then
                        txtSuDungLaoDongID.Text = CType(Request.QueryString("ID"), String)
                    End If
                End If
                ds = objSuDungLaoDong.GetSuDungLaoDong_DauKy(txtSuDungLaoDongID.Text)
            End If

            gLoadControlValues(ds, Me)
            If txtSuDungLaoDongID.Text = "" Then
                txtNgayNhan.Text = Format(Now, "dd/MM/yyyy")
            End If
            SetVisibleButton()
            Dim objHSBS As New HSHC.HoSoBoSungController
            If objHSBS.CheckBoSungHoSo(txtSoBienNhan.Text) Then
                Response.Redirect(EditURL("ID", txtSoBienNhan.Text, "YEUCAUBOSUNG"), True)
            End If
            Dim objHSK As New HoSoKhongGiaiQuyetController
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                Response.Redirect(EditURL("ID", txtSoBienNhan.Text, "HOSOKHONG"), True)
            End If
            objSuDungLaoDong = Nothing
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim strSoBienNhan As String
            If CType(Request.QueryString("ctl"), String) = "SUDUNGLAODONG" Then
                strSoBienNhan = txtSoBienNhan.Text
                If strSoBienNhan = "" Then Exit Sub
                Dim objHSBS As New HSHC.HoSoBoSungController
                If objHSBS.CheckBoSungHoSo(strSoBienNhan) Then
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Exit Sub
                End If
                Dim objHSK As New HoSoKhongGiaiQuyetController
                If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                    SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                    Exit Sub
                End If
            End If
            Dim objSuDungLaoDong As New SuDungLaoDongController
            txtSuDungLaoDongID.Text = objSuDungLaoDong.AddSuDungLaoDong(Me)
            objSuDungLaoDong = Nothing
            'BindData()
            '    If CType(Request.QueryString("ctl"), String) = "SUDUNGLAODONG" Then
            '   Response.Redirect(Replace(EditURL("ID", txtHoSoTiepNhanID.Text), "ctl=Edit", "ctl=SUDUNGLAODONG"))
            '  Else
            '     Response.Redirect(EditURL("ID", txtSuDungLaoDongID.Text))
            'End If
            btnHoSoKhong.Visible = False
            btnYCBS.Visible = False
            btnXoa.Visible = True

        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objSuDungLaoDong As New SuDungLaoDongController
            objSuDungLaoDong.DelSuDungLaoDong(Me)
            objSuDungLaoDong = Nothing
            'Response.Redirect(NavigateURL(), True)
            Response.Redirect(EditURL("ID", Request.Params("ID"), Request.Params("ctl")), True)
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL("ID", ""))
        End Sub
        'Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
        '    Dim strSoBienNhan As String
        '    strSoBienNhan = txtSoBienNhan.Text
        '    Dim objHSBS As New HSHC.HoSoBoSungController
        '    If strSoBienNhan <> "" And Not objHSBS.CheckBoSungHoSo(strSoBienNhan) Then
        '        SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
        '        Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=DX&oldControl=" & Request.Params("ctl"), True)
        '    End If
        'End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSBS As New HSHC.HoSoBoSungController
            If objHSBS.CheckBoSungHoSo(strSoBienNhan) Then
                SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                Exit Sub
            End If
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub

        Private Sub btnYCBS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYCBS.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSK As New HoSoKhongGiaiQuyetController
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG") & "&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub


        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click

        End Sub
    End Class
End Namespace