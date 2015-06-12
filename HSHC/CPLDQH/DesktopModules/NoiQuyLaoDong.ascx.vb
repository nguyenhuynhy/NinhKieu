Imports PortalQH
Imports System.Configuration
Namespace CPLDQH
    Public Class NoiQuyLaoDong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoThongBao As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetQuaGiaiQuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayDangKyNoiQuy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanNoiQuy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayXacNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiQuyLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayThongBao As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayDangKyNoiQuy As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayXacNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents rblBieuMau As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents rowSoThongBao As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents rowNgayThongBao As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtNgayThongBao As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtHoTenGiamDoc As System.Web.UI.WebControls.TextBox
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
            SetAttributesControl()
            If Not Page.IsPostBack() Then
                InitState()
                rowSoThongBao.Visible = False
                rowNgayThongBao.Visible = False
                txtTabCode.Text = CType(Request.Params("TabID"), String)
                txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            End If
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaDuong))
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
        End Sub
        Public Sub InitState()
            BindControl.BindDropDownList(ddlMaLoaiHinhDoanhNghiep, "DMLOAIHINHDOANHNGHIEP")
            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPLD", Request.QueryString("tabid"))
            'BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            'BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
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
            GetInfoNoiQuyLaoDong()
        End Sub
        
        Sub SetVisibleButton()
            If txtNoiQuyLaoDongID.Text <> "" Then
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

        Public Sub selectValueInCombobox(ByRef cboBox As DropDownList, ByVal sValue As String)
            Dim i As Integer
            For i = 0 To cboBox.Items.Count - 1
                If (cboBox.Items(i).Value.Equals(sValue)) Then
                    cboBox.SelectedIndex = i
                    Exit For
                End If
            Next
        End Sub
        Public Sub GetInfoNoiQuyLaoDong()
            Dim ds As New DataSet
            Dim objNoiQuyLaoDongController As New NoiQuyLaoDongController
            txtHoSoTiepNhanID.Text = Request.QueryString.Get("ID").ToString()
            ds = objNoiQuyLaoDongController.GetNoiQuyLaoDong(Me)
            objNoiQuyLaoDongController = Nothing
            gLoadControlValues(ds, Me)
            SetVisibleButton()
            If (txtNgayXacNhan.Text = "") Then
                txtNgayXacNhan.Text = NgayHienTai()
            End If
            If (txtNgayDangKyNoiQuy.Text = "") Then
                txtNgayDangKyNoiQuy.Text = NgayHienTai()
            End If
            ds = Nothing
        End Sub
        Private Sub SetAttributesControl()

            txtNgayThongBao.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayThongBao.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThongBao.ClientID & ");")
            cmdNgayThongBao.NavigateUrl = AdminDB.InvokePopupCal(txtNgayThongBao)


            'txtSoThongBao.Attributes.Add("ISNULL", "NOTNULL")

            txtNgayDangKyNoiQuy.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayDangKyNoiQuy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayDangKyNoiQuy.ClientID & ");")
            cmdNgayDangKyNoiQuy.NavigateUrl = AdminDB.InvokePopupCal(txtNgayDangKyNoiQuy)

            txtNgayXacNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayXacNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayXacNhan.ClientID & ");")
            cmdNgayXacNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayXacNhan)

            txtTongSoLD.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLD.ClientID & ");")

            'txtNgayThongBao.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLoaiHinhDoanhNghiep.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayDangKyNoiQuy.Attributes.Add("ISNULL", "NOTNULL")
            txtThoiHanNoiQuy.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayXacNhan.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")

            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")

        End Sub


        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objNoiQuyLaoDongController As New NoiQuyLaoDongController
            txtHoSoTiepNhanID.Text = Request.QueryString.Get("ID").ToString()
            Me.txtNoiQuyLaoDongID.Text = objNoiQuyLaoDongController.AddNoiQuyLaoDong(Me)
            SetVisibleButton()
            objNoiQuyLaoDongController = Nothing
        End Sub

        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objNoiQuyLaoDongController As New NoiQuyLaoDongController
            objNoiQuyLaoDongController.DelNoiQuyLaoDong(Me)
            objNoiQuyLaoDongController = Nothing
            'ResetAllField()
            'Response.Redirect(NavigateURL(), True)
            Response.Redirect(EditURL("ID", Request.Params("ID"), Request.Params("ctl")), True)
        End Sub
        Public Sub ResetAllField()
            Me.txtSoThongBao.Text = ""
            Me.txtNgayThongBao.Text = ""
            Me.txtHoTen.Text = ""
            Me.ddlMaLoaiHinhDoanhNghiep.SelectedIndex = -1
            Me.txtNgayDangKyNoiQuy.Text = ""
            Me.txtThoiHanNoiQuy.Text = ""
            Me.txtNgayXacNhan.Text = ""
            Me.ddlMaSoLanhDao.SelectedIndex = -1
            Me.txtKetQuaGiaiQuyet.Text = ""
            Me.txtSoNha.Text = ""
            ddlMaDuong.SelectedIndex = -1
            ddlMaPhuong.SelectedIndex = -1
            txtDienThoai.Text = ""
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
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
            Dim objNoiQuyLaoDong As New NoiQuyLaoDongController
            Dim ds As DataSet
            Dim Script As String
            Dim strFileNew As String
            Dim strServerPath As String
            Dim strFileTemplate As String
            Dim strPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            strPath = "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            strFileNew = "TBNQ" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
            If rblBieuMau.SelectedValue = "0" Then 'lan dau
                strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileThongBaoNoiQuy_LanDau", glbXMLFile)
            Else 'sau doi
                strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileThongBaoNoiQuy_SuaDoi", glbXMLFile)
            End If
            ds = objNoiQuyLaoDong.ThongBaoNoiQuy(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportFile(ds, strPath, strFileTemplate, strFileNew))
            Page.RegisterStartupScript("OpenWindow", Script)
            objNoiQuyLaoDong = Nothing
        End Sub
    End Class

End Namespace