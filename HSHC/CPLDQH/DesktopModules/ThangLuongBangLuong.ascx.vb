Imports PortalQH
Imports System.Configuration
Namespace CPLDQH
    Public Class ThangLuongBangLuong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayBangLuong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLaoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetQuaGiaiQuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMaSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayXacNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoThongBao As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayThongBao As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtThangLuongBangLuongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents a As System.Web.UI.WebControls.Label
        Protected WithEvents imgNgayBangLuong As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayCongVan As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayXacNhan As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayThongBao As System.Web.UI.WebControls.Image
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayCongVan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayThongBao As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlInLan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents rowSoThongBao As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents cmdNgayXacNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayBangLuong As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtSXMucLuongThapNhat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSXMucLuongCaoNhat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSXSoBacLuong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenGiamDoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNganhKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTienLuongToiThieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThuNhapThapNhat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThuNhapCaoNhat As System.Web.UI.WebControls.TextBox
        Protected WithEvents ctrlScriptComboFilterPhuong As PortalQH.ComboFilter

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
                'rowSoThongBao.Visible = False
                txtTabCode.Text = CType(Request.Params("TabID"), String)
                txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
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
            If txtThangLuongBangLuongID.Text <> "" Then
                btnXoa.Visible = True
                btnIn.Visible = True
                btnYCBS.Visible = False
                btnHoSoKhong.Visible = False
            Else
                btnXoa.Visible = False
                btnIn.Visible = False
                btnYCBS.Visible = True
                btnHoSoKhong.Visible = True
            End If
        End Sub

        Public Sub GetInfoThangLuongBangLuong()
            Dim ds As New DataSet
            Dim objThangLuongBangLuongController As New ThangLuongBangLuongController
            Me.txtHoSoTiepNhanID.Text = Request.QueryString.Get("ID").ToString()
            ds = objThangLuongBangLuongController.GetThangLuongBangLuong(Me)
            objThangLuongBangLuongController = Nothing
            gLoadControlValues(ds, Me)
            'selectValueInCombobox(ddlMaDuong, RTrim(ds.Tables(0).Rows(0)("MaDuong").ToString()))
            ds = Nothing
            'If (txtNgayBangLuong.Text = "") Then
            '    txtNgayBangLuong.Text = NgayHienTai()
            'End If
            'If (txtNgayThongBao.Text = "") Then
            '    txtNgayThongBao.Text = NgayHienTai()
            'End If
            If (txtNgayXacNhan.Text = "") Then
                txtNgayXacNhan.Text = ""
            End If
            'If (txtNgayCongVan.Text = "") Then
            '    txtNgayCongVan.Text = NgayHienTai()
            'End If
        End Sub

        Public Sub InitState()
            BindControl.BindDropDownList(ddlMaLoaiHinhDoanhNghiep, "DMLOAIHINHDOANHNGHIEP")
            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPLD", Request.QueryString("tabid"))
            
            'Doan loc duong theo phuong
            
            Dim objDanhMuc As New DanhMucController
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
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
            GetInfoThangLuongBangLuong()
        End Sub
        Public Sub SetAttributesControl()
            'add lich cho ngay
            txtNgayBangLuong.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayBangLuong.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayBangLuong.ClientID & ");")
            cmdNgayBangLuong.NavigateUrl = AdminDB.InvokePopupCal(txtNgayBangLuong)

            txtNgayCongVan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCongVan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCongVan.ClientID & ");")
            cmdNgayCongVan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCongVan)

            txtNgayXacNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayXacNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayXacNhan.ClientID & ");")
            cmdNgayXacNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayXacNhan)

            'txtNgayThongBao.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            'txtNgayThongBao.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThongBao.ClientID & ");")
            'cmdNgayThongBao.NavigateUrl = AdminDB.InvokePopupCal(txtNgayThongBao)
            'check is numeric?

            txtTongSoLaoDong.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLaoDong.ClientID & ");")
            txtTienLuongToiThieu.Attributes.Add("onblur", "javascript:CheckData(" & txtTienLuongToiThieu.ClientID & ");")
            txtSXMucLuongCaoNhat.Attributes.Add("onblur", "javascript:CheckData(" & txtSXMucLuongCaoNhat.ClientID & ");")
            txtSXMucLuongThapNhat.Attributes.Add("onblur", "javascript:CheckData(" & txtSXMucLuongThapNhat.ClientID & ");")
            txtSXSoBacLuong.Attributes.Add("onblur", "javascript:CheckData(" & txtSXSoBacLuong.ClientID & ");")
            'txtTienLuongBQ.Attributes.Add("onblur", "javascript:CheckData(" & txtTienLuongBQ.ClientID & ");")
            'txtTienThuongBQ.Attributes.Add("onblur", "javascript:CheckData(" & txtTienThuongBQ.ClientID & ");")
            'txtKhacBQ.Attributes.Add("onblur", "javascript:CheckData(" & txtKhacBQ.ClientID & ");")
            'txtThuNhapBQ.Attributes.Add("onblur", "javascript:CheckData(" & txtThuNhapBQ.ClientID & ");")
            txtThuNhapCaoNhat.Attributes.Add("onblur", "javascript:CheckData(" & txtThuNhapCaoNhat.ClientID & ");")
            txtThuNhapThapNhat.Attributes.Add("onblur", "javascript:CheckData(" & txtThuNhapThapNhat.ClientID & ");")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?');")
            'check data not null
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLoaiHinhDoanhNghiep.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            'txtMaSo.Attributes.Add("ISNULL", "NOTNULL")
            'txtSoThongBao.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayXacNhan.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
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
        Public Sub ResetAllField()
            txtHoTen.Text = ""
            ddlMaLoaiHinhDoanhNghiep.SelectedIndex = -1
            txtNgayBangLuong.Text = ""
            txtSoCongVan.Text = ""
            txtNgayCongVan.Text = ""
            txtTongSoLaoDong.Text = ""
            txtTienLuongToiThieu.Text = ""
            txtSXMucLuongCaoNhat.Text = ""
            txtSXMucLuongThapNhat.Text = ""
            txtSXSoBacLuong.Text = ""
            txtHoTenGiamDoc.Text = ""
            txtNganhKinhDoanh.Text = ""
            txtThuNhapCaoNhat.Text = ""
            txtThuNhapThapNhat.Text = ""
            txtSoNha.Text = ""
            ddlMaDuong.SelectedIndex = -1
            ddlMaPhuong.SelectedIndex = -1
            txtDienThoai.Text = ""
            txtKetQuaGiaiQuyet.Text = ""
            txtMaSo.Text = ""
            txtNgayXacNhan.Text = ""
            'txtSoThongBao.Text = ""
            'txtNgayThongBao.Text = ""
            ddlMaSoLanhDao.SelectedIndex = -1
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objThangLuongBangLuongController As New ThangLuongBangLuongController
            txtHoSoTiepNhanID.Text = Request.QueryString.Get("ID").ToString()
            Dim a As String = Me.txtThuNhapCaoNhat.Text
            txtThangLuongBangLuongID.Text = objThangLuongBangLuongController.AddThangLuongBangLuong(Me)

            objThangLuongBangLuongController = Nothing
            SetVisibleButton()
        End Sub

        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThangLuongBangLuongController As New ThangLuongBangLuongController

            objThangLuongBangLuongController.DelThangLuongBangLuong(Me)
            SetVisibleButton()
            objThangLuongBangLuongController = Nothing
            'ResetAllField()
            'Response.Redirect(NavigateURL(), True)
            Response.Redirect(EditURL("ID", Request.Params("ID"), Request.Params("ctl")), True)
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
            Dim objThangLuongBangLuong As New ThangLuongBangLuongController
            Dim ds As DataSet
            Dim Script As String
            Dim strFileNew As String
            Dim strServerPath As String
            Dim strFileTemplate As String
            Dim strPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            strPath = "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            strFileNew = "TBTL" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
            strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileThongBaoThangLuongBangLuong", glbXMLFile)
            ds = objThangLuongBangLuong.ThongBaoThangLuongBangLuong(txtHoSoTiepNhanID.Text, ddlInLan.SelectedValue)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportFile(ds, strPath, strFileTemplate, strFileNew))
            Page.RegisterStartupScript("OpenWindow", Script)
            objThangLuongBangLuong = Nothing
        End Sub

        Private Sub ddlMaPhuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub


    End Class
End Namespace