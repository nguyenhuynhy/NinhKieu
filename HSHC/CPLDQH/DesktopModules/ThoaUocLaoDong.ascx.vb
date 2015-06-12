Imports PortalQH
Imports System.Configuration

Namespace CPLDQH
    Public Class ThoaUocLaoDong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetQuaGiaiQuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaloaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayDangKyThoaUoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDaiDienNSDLD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChucVuNSDLD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDaiDienTapTheLD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChucVuTapTheLD As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtThoaUocLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayDangKyThoaUoc As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtNgayXacNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayXacNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtNgayThongBao As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayThongBao As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtSoThongBao As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents tblSoThongBao As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtTongSoLaoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdThoiHanTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtThoiHanDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdThoiHanDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtTongSoLD As System.Web.UI.WebControls.TextBox

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
                tblSoThongBao.Visible = False
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
            objHSBS = Nothing
            objHSK = Nothing
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaDuong))
            End If
        End Sub

        Sub SetVisibleButton()
            If txtThoaUocLaoDongID.Text <> "" Then
                btnIn.Visible = True
                btnXoa.Visible = True
                btnYCBS.Visible = False
                btnHoSoKhong.Visible = False
            Else
                btnIn.Visible = False
                btnXoa.Visible = False
                btnYCBS.Visible = True
                btnHoSoKhong.Visible = True
            End If
        End Sub


        Sub InitState()
            BindControl.BindDropDownList(ddlMaloaiHinhDoanhNghiep, "DMLOAIHINHDOANHNGHIEP", , True)
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
            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPLD", Request.QueryString("tabid"))
        End Sub

        Private Sub SetAttribute()
            'add lich cho ngay
            txtNgayXacNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayXacNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayXacNhan.ClientID & ");")
            cmdNgayXacNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayXacNhan)

            txtNgayDangKyThoaUoc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayDangKyThoaUoc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayDangKyThoaUoc.ClientID & ");")
            cmdNgayDangKyThoaUoc.NavigateUrl = AdminDB.InvokePopupCal(txtNgayDangKyThoaUoc)

            txtNgayThongBao.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayThongBao.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThongBao.ClientID & ");")
            cmdNgayThongBao.NavigateUrl = AdminDB.InvokePopupCal(txtNgayThongBao)

            txtThoiHanTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtThoiHanTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtThoiHanTuNgay.ClientID & ");")
            cmdThoiHanTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtThoiHanTuNgay)

            txtThoiHanDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtThoiHanDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtThoiHanDenNgay.ClientID & ");")
            cmdThoiHanDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtThoiHanDenNgay)

            txtTongSoLD.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLD.ClientID & ");")
            'set thuoc tinh not null
            txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")
            'txtSoThongBao.Attributes.Add("ISNULL", "NOTNULL")
            'txtNgayThongBao.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaloaiHinhDoanhNghiep.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayDangKyThoaUoc.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ''''''''''''''''''''''''
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Sub BindData()
            Dim objThoaUocLaoDong As New ThoaUocLaoDongController
            Dim ds As DataSet
            If Not Request.QueryString("ID") Is Nothing Then
                txtHoSoTiepNhanID.Text = CType(Request.QueryString("ID"), String)
            End If
            ds = objThoaUocLaoDong.GetThoaUocLaoDong(txtHoSoTiepNhanID.Text)
            gLoadControlValues(ds, Me)
            If txtThoaUocLaoDongID.Text = "" Then
                txtNgayThongBao.Text = Format(Now, "dd/MM/yyyy")
            End If
            SetVisibleButton()
            objThoaUocLaoDong = Nothing
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objThoaUocLaoDong As New ThoaUocLaoDongController
            objThoaUocLaoDong.AddThoaUocLaoDong(Me)
            objThoaUocLaoDong = Nothing
            BindData()
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThoaUocLaoDong As New ThoaUocLaoDongController
            objThoaUocLaoDong.DelThoaUocLaoDong(Me)
            objThoaUocLaoDong = Nothing
            'Response.Redirect(NavigateURL(), True)
            Response.Redirect(EditURL("ID", Request.Params("ID"), Request.Params("ctl")), True)
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(), True)

        End Sub

        'Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
        '    Dim strSoBienNhan As String
        '    strSoBienNhan = txtSoBienNhan.Text
        '    If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
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
        'Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
        '    If strSoBienNhan = "" Then Exit Function
        '    Dim objHoSoBoSung As New HSHC.HoSoBoSungController
        '    Dim dv As New DataView
        '    dv = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(strSoBienNhan).Tables(0).DefaultView
        '    If dv.Count > 0 Then
        '        If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
        '            SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        'End Function

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

        Private Function f_ExportFile(ByVal ds As DataSet, ByVal Path As String, ByVal FileTemplate As String, ByVal FileExport As String) As String
            Dim url As String
            Dim Script As String
            Dim Tool As OfficeTools.WordTools = New OfficeTools.WordTools

            If Right(FileTemplate, 4) <> ".doc" Then
                Exit Function
            End If
            Tool.OpenFile(FileTemplate)
            Tool.AddToMergeField(ds, 0)

            f_ExportFile = Tool.DoAll(GetAbsoluteServerPath(Request), Path, FileExport)
            Tool.CloseFile()
        End Function

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objThoaUocLaoDong As New ThoaUocLaoDongController
            Dim ds As DataSet
            Dim Script As String
            Dim strFileNew As String
            Dim strServerPath As String
            Dim strFileTemplate As String
            Dim strPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            strPath = "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            strFileNew = "TBTU" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
            strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileThongBaoThoaUoc", glbXMLFile)
            ds = objThoaUocLaoDong.ThongBaoThoaUoc(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportFile(ds, strPath, strFileTemplate, strFileNew))
            Page.RegisterStartupScript("OpenWindow", Script)
            objThoaUocLaoDong = Nothing
        End Sub

    End Class
End Namespace