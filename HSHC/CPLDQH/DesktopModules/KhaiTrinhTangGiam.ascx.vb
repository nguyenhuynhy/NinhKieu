Option Strict Off
Imports PortalQH
Imports System.Configuration
Imports System.Xml
Imports System.Net

Namespace CPLDQH

    Public Class KhaiTrinhTangGiam
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnDanhSachDV As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDanhSachDV As System.Web.UI.WebControls.Label
        Protected WithEvents txtSuDungLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenChuDonVi As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTongSoLaoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLaoDongNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHopDongLaoDongKyMoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongKyMoiNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongGiaHan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongGiaHanNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayHopDongLaoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayHopDong As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtTongThuNhap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLuongChinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label18 As System.Web.UI.WebControls.Label
        Protected WithEvents Label21 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoKhauThanhPhoNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauThanhPhoNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTinhNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTinhNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLaoDongKhongXacDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLaoDongXacDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLaoDongThoiVu As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDangKyGiam As System.Web.UI.WebControls.Label
        Protected WithEvents txtHopDongLaoDongGiam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongLaoDongGiamNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamNghiHuu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamThoiViec As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamSaThai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamKhac As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblHoKhauTP As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoKhauTinh As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoKhauTPGiamNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTPGiamNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTinhGiamNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoKhauTinhGiamNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongKXDGiam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongXDGiam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHopDongTVGiam As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDKBS As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayDangKyBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBienDongLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoaiThuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHDKXD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHDXD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHDTV As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHDKXDGiam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHDXDGiam As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHDTVGiam As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region


        '=========================================================
        '=Người tạo : TuanNH                                     =
        '=Ngày tạo  : 06/11/2006                                 =
        '=Mục đích  : thụ lý hồ sơ khai trình tăng giảm lao động =
        '=========================================================

        Private strControl As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            strControl = Request.Params("ctl")

            btnDanhSachDV.Visible = True

            If Not Me.IsPostBack Then
                loadDataToControl()
                SetAttribute()

                If txtNgayNhan.Text = "" Then txtNgayNhan.Text = NgayHienTai()
                txtTabCode.Text = CType(Request.Params("TabID"), String)
                txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
                txtMaSoNguoiSuDung.Text = CType(Session.Item("UserName"), String)

                '--Lay Thong tin doanh nghiep tren neu co
                If Trim(txtSuDungLaoDongID.Text) <> "" Or Trim(txtBienDongLaoDongID.Text) <> "" Then 'Da co data
                    ViewState("isAddNew") = False
                    'GetDoanhNghiep()
                Else 'Chua co data
                    ViewState("isAddNew") = True

                End If
            End If

            hiddenAllButton()
            '--Cap nhat trang thai cac control
            If CBool(ViewState("isAddNew")) Then 'New la them moi
                If CheckHoSoBoSung(Request.Params("ID")) Then 'Neu la ho so da bo sung
                    btnYCBS.Visible = True
                ElseIf CheckHoSoKhongGiaiQuyet(Request.Params("ID")) Then 'Neu la ho so khong giai quyet
                    btnHoSoKhong.Visible = True
                Else
                    btnHoSoKhong.Visible = True
                    btnYCBS.Visible = True
                    btnCapNhat.Visible = True
                End If

                lblDanhSachDV.Visible = False
                btnDanhSachDV.Visible = True
                txtSuDungLaoDongID.ReadOnly = False
            Else ' Neu la cap nhat
                btnCapNhat.Visible = True
                btnXoa.Visible = True

                lblDanhSachDV.Visible = True
                btnDanhSachDV.Visible = False
                txtSuDungLaoDongID.ReadOnly = True
            End If
            txtNgayNhan.Attributes.Add("ISNULL", "NOTNULL")

            Me.setEnableControls()
        End Sub


        Private Sub setEnableControls()
            If txtLoaiThuLy.Text = "TANGGIAM" Then
                txtTongSoLaoDong.Enabled = False
                txtTongSoLaoDongNu.Enabled = False
                lblHeader.Text = "Khai báo tăng giảm lao động"
            Else
                txtTongSoLaoDong.Enabled = True
                txtTongSoLaoDongNu.Enabled = True
                lblHeader.Text = "Khai trình sử dụng lao động"
            End If
        End Sub

        Private Sub SetAttribute()
            'Javascript
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

            txtSoLDGiamNghiHuu.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamNghiHuu.ClientID & ");")
            txtSoLDGiamSaThai.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamSaThai.ClientID & ");")
            txtSoLDGiamThoiViec.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamThoiViec.ClientID & ");")
            txtSoLDGiamKhac.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamKhac.ClientID & ");")

            'set thuoc tinh not null
            'txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ''''''''''''''''''''''''

            'btnCapNhat.Attributes.Add("onclick", "return btnCapNhat_clicked()")

            Dim strURL As String
            strURL = "CPLDQH/DesktopModules/TimKiemDoanhNghiep.aspx"
            btnDanhSachDV.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?');")

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

        Private Function CheckHoSoBoSung(ByVal strID As String) As Boolean
            Dim objHSBS As New HSHC.HoSoBoSungController
            Return objHSBS.CheckBoSungHoSo(strID)
        End Function

        Private Function CheckHoSoKhongGiaiQuyet(ByVal strID As String) As Boolean
            Dim objHSK As New HoSoKhongGiaiQuyetController
            Return objHSK.CheckHoSoKhong(strID)
        End Function

        Private Sub hiddenAllButton()
            btnCapNhat.Visible = False
            btnXoa.Visible = False
            btnHoSoKhong.Visible = False
            btnYCBS.Visible = False
        End Sub

        Private Sub loadDataToControl()
            strControl = Request.Params("ctl")

            Dim objDanhMuc As New DanhMucController
            Dim objSuDungLaoDong As New SuDungLaoDongController
            Dim ds As New DataSet

            'Bind data vào càc Combo Box danh mục
            BindControl.BindDropDownList(ddlMaLoaiHinhDoanhNghiep, "DMLOAIHINHDOANHNGHIEP", , True)
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")

            If CType(Request.QueryString("ctl"), String) = "SUDUNGLAODONG" Then
                If Not Request.QueryString("ID") Is Nothing Then
                    txtHoSoTiepNhanID.Text = CType(Request.QueryString("ID"), String)
                End If
                ds = objSuDungLaoDong.GetKhaiTrinhTangGiam(txtHoSoTiepNhanID.Text)

                'Bind data vào các controls trên form
                gLoadControlValues(ds, Me)
            End If


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

        Private Sub GetDoanhNghiep()
            'Get DoanhNghiep tu SuDungLaoDongID
            Dim objSuDungLaoDong As New SuDungLaoDongController
            Dim ds As DataSet
            ds = objSuDungLaoDong.GetSuDungLaoDongByID(txtSuDungLaoDongID.Text.Replace("'", "''"))
            If ds.Tables(0).Rows.Count > 0 Then 'Co data
                gLoadControlValues(ds, Me)

                Me.setEnableControls()
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

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim strSoBienNhan As String
            If CType(Request.QueryString("ctl"), String) = "SUDUNGLAODONG" Then
                strSoBienNhan = txtSoBienNhan.Text
                If strSoBienNhan = "" Then Exit Sub
                Dim objHSBS As New HSHC.HoSoBoSungController
                If objHSBS.CheckBoSungHoSo(strSoBienNhan) Then  'Nếu là hồ sơ yêu cầu bổ sung
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Exit Sub
                End If
                Dim objHSK As New HoSoKhongGiaiQuyetController
                If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then   'Nếu là hồ sơ không giải quyết
                    SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                    Exit Sub
                End If
            End If
            Dim objSuDungLaoDong As New SuDungLaoDongController
            Dim dsInfo As New DataSet

            If txtLoaiThuLy.Text = "" And txtSuDungLaoDongID.Text = "" Then
                txtLoaiThuLy.Text = "KHAITRINH"
            End If

            dsInfo = objSuDungLaoDong.AddKhaiTrinhTangGiam(Me)  'Thêm mới khai báo tăng giảm
            txtSuDungLaoDongID.Text = dsInfo.Tables(0).Rows(0)(0).ToString()
            txtBienDongLaoDongID.Text = dsInfo.Tables(0).Rows(0)(1).ToString()
            txtLoaiThuLy.Text = dsInfo.Tables(0).Rows(0)(2).ToString()
            objSuDungLaoDong = Nothing

            btnHoSoKhong.Visible = False
            btnYCBS.Visible = False
            btnXoa.Visible = True

            Response.Redirect(Request.RawUrl())

        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objSuDungLaoDong As New SuDungLaoDongController
            objSuDungLaoDong.DelKhaiTrinhTangGiam(Me) 'Xóa khai trình có tăng giảm lao động
            objSuDungLaoDong = Nothing
            Response.Redirect(EditURL("ID", Request.Params("ID"), Request.Params("ctl")), True)
        End Sub


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


        Private Sub txtSuDungLaoDongID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuDungLaoDongID.TextChanged
            GetDoanhNghiep()
        End Sub

        Private Sub txtNgayDangKyBoSung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNgayDangKyBoSung.TextChanged

        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub
    End Class

End Namespace