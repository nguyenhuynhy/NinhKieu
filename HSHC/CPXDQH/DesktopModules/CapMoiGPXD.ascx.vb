Imports System.Configuration
Imports PortalQH
Namespace CPXD
    Public Class CapMoiGPXD
        Inherits PortalQH.PortalModuleControl
        Private strControl As String
        Private pID As String = ""

    


#Region " Web Form Designer Generated Code "
        Private Const strURL As String = "CPXD/DesktopModules/TimKiemGiayCNDKKD.aspx"
        Protected WithEvents btnBaoCaoDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYeuCauBoSung As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnKiemTraHS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXacMinhThucDia As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSao As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhepTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayCapPhep As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiachicu As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaPhanLoaiXayDung As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCongTrinhXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaCapNha As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDonViThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaySuDungDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkLoDat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents title As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayHoanCong As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkGiaySuDungDat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtThoiHanHoanThanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblKetQuaVPHC As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayCapCu As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaDuong As ProgStudios.WebControls.ComboBox
        Protected WithEvents ddlMaPhuong As ProgStudios.WebControls.ComboBox
        Protected WithEvents txtNgayHoanCong As System.Web.UI.WebControls.TextBox
        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        


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
            If Not Request.Params("ID") Is Nothing Then
                pID = Request.Params("ID")
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                strControl = Request.Params("ctl")
                txtTabCode.Text = Request.Params("TabID")
            End If
            If Not Me.IsPostBack Then
                Me.bindDropdownlists()
                'BindData(pID, CType(Request.Params("AddNew"), Boolean))
                BindData(pID)
                If txtNgayCapPhep.Text = "" Then txtNgayCapPhep.Text = NgayHienTai()
                btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
                If strControl = "DIEUCHINHGPXD" Then
                    btnDanhSachGP.Visible = True
                    lblSoGP.Visible = False
                    txtSoGiayPhepTruoc.Attributes.Add("ISNULL", "NOTNULL")
                End If
                txtReload.Text = "0"
                btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
                txtNgayCapPhep.Text = NgayHienTai()
            End If

            'btnDSBienNhan.Visible = CType(Request.Params("AddNew"), Boolean)
            'lblSoBN.Visible = Not CType(Request.Params("AddNew"), Boolean)
            SetAttributesNgay()
            'SetStatus(CType(Request.Params("AddNew"), Boolean))
            SetStatus()
            If Trim(txtSoGiayPhep.Text) <> "" And txtReload.Text = "1" Then
                getGPXD()
                txtReload.Text = "0"
            End If
            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            Dim dmURL As String
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", strReportPath, btnInThongBao, Me)
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "2", strReportPath, btnIn, Me)
            dmURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMLODAT&TextName=" & txtLoDat.ClientID
            LinkLoDat.Attributes.Add("onclick", "javascript:DanhMucChon('" & dmURL & "','Application');")
            dmURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMLODAT&TextName=" & txtLoDat.ClientID
            LinkLoDat.Attributes.Add("onclick", "javascript:DanhMucChon('" & dmURL & "','Application');")
            dmURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMGIAYPHEPSUDUNGDAT&TextName=" & txtGiaySuDungDat.ClientID
            LinkGiaySuDungDat.Attributes.Add("onclick", "javascript:DanhMucChon('" & dmURL & "','Application');")
            If ddlMaPhanLoaiXayDung.SelectedValue = "" Then
                DdLSelected(ddlMaPhanLoaiXayDung, "XM")
            End If
            If ddlMaCapNha.SelectedValue = "" Then
                DdLSelected(ddlMaCapNha, "NO")
            End If
            If txtDonViThietKe.Text = "" Then
                txtDonViThietKe.Text = "Công ty"
            End If
        End Sub

        Private Sub SetStatus()
   
            If txtSoBienNhan.Text = "" Then

                lblSoBN.Visible = False
            End If
            If Request.Params("TabID") = GetValueItem(Request, "TabCapDoi", ConfigurationSettings.AppSettings("Path" & ctype(Session.Item("ActiveDB"),string)) & "GLOBAL.xml") Then
                If txtSoBienNhan.Text <> "" Then

                    lblSoGP.Visible = False
                    btnDanhSachGP.Visible = True
                Else
                    lblSoGP.Visible = True
                    btnDanhSachGP.Visible = False
                End If
                txtSoGiayPhepTruoc.Attributes.Add("ISNULL", "NOTNULL")
            End If
            lblSao.Visible = btnDanhSachGP.Visible
            txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")

            txtNgayCapPhep.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub SetAttributesNgay()
            txtNgayNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayNhan.ClientID & ");")
            txtNgayCapPhep.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapPhep.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCapPhep.ClientID & ");")
            cmdNgayNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayNhan)
            cmdNgayCapPhep.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCapPhep)
            txtMaLinhVuc.Text = Request.Params("Malv")
            txtMaNguoiTacNghiep.Text = Session.Item("UserName").ToString()
            txtTabCode.Text = Request.Params("TabID")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub bindDropdownlists()
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlMaPhanLoaiXayDung, "DMPHANLOAIXAYDUNG")
            BindControl.BindDropDownList(ddlMaCapNha, "DMCAPNHA")
            DdLSelected(ddlMaCapNha, "NO")
            BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
            BindDropDownList_NguoiKy(ddlMaSoLanhDao)
        End Sub

        Sub BindData(ByVal id As String)
            Dim objGPXD As New GPXDController
            Dim ds As DataSet

            ds = objGPXD.getGPXD_Edit(id)
            If ds.Tables(0).Rows.Count > 0 Then
                gLoadControlValues(ds, Me)
                btnBaoCaoDeXuat.Visible = True
            
                btnHoSoKhong.Visible = False

                btnXacMinhThucDia.Visible = False
                btnXoa.Visible = True
            Else
                    ds = objGPXD.getGPXD_New(id)
                    gLoadControlValues(ds, Me)
                    btnBaoCaoDeXuat.Visible = False
                    btnHoSoKhong.Visible = True
                    btnYeuCauBoSung.Visible = True
                btnXacMinhThucDia.Visible = True
                btnXoa.Visible = False
                End If
                Dim objBCDX As New BaoCaoDeXuatController
                If objBCDX.CheckBaoCaoDeXuat(txtHoSoTiepNhanID.Text) Then
                btnIn.Visible = True
                btnXoa.Visible = False
                Else
                btnIn.Visible = False

            End If            
            objGPXD = Nothing
        End Sub
        Private Sub getGPXD()
            Dim objCapPhoBan As New CapPhoBanController
            Dim ds As DataSet
            ds = objCapPhoBan.getGPXD(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me, LoadControlValuesLocation.Local)
            ds = Nothing
            If strControl = "DIEUCHINHGPXD" And txtSoGiayPhep.Text <> "" Then
                txtSoGiayPhepTruoc.Text = txtSoGiayPhep.Text
                txtNgayCapCu.Text = txtNgayCapPhep.Text
                txtSoGiayPhep.Text = ""
                txtNgayCapPhep.Text = NgayHienTai()
            End If
        End Sub

        Private Sub btnDSBienNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl") & "&AddNew=" & Request.Params("AddNew")), True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objGPXD As New GPXDController
            Dim mID As String
            Dim objHSK As New HoSoKhongGiaiQuyetController
            'Kiem tra neu ho so da khong giai quyet thi khong cap nhat
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If
            'truong hop cap doi
            If strControl = "DIEUCHINHGPXD" Then
                mID = objGPXD.addGPXD_CD(Me)
            Else 'cap moi
                mID = objGPXD.addGPXD(Me)
            End If
            'BindData(mID, False)
            BindData(mID)
            'Cap nhat chu dau tu
            objGPXD = Nothing
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objGPXD As New GPXDController
            objGPXD.delGPXD(Me)
            objGPXD = Nothing

            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnBaoCaoDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaoCaoDeXuat.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            Dim objHSK As New HoSoKhongGiaiQuyetController
            strSoBienNhan = txtSoBienNhan.Text
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If

            Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&oldControl=" & strControl, True)
            
        End Sub

    
        


        'Private Sub btnKiemTraHS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKiemTraHS.Click
        '    Dim objVPHC As New ViPhamHanhChinhController
        '    Dim strHoSoTiepNhanID As String
        '    strHoSoTiepNhanID = Request.Params("ID")

        '    If strHoSoTiepNhanID <> "" Then
        '        If objVPHC.IsViPhamHanhchinh(Trim(strHoSoTiepNhanID)) Then
        '            lblKetQuaVPHC.Text = "Hồ sơ này đã vi phạm hành chính."
        '            lblKetQuaVPHC.ForeColor = System.Drawing.Color.Red
        '        Else
        '            lblKetQuaVPHC.Text = "Hồ sơ này không vi phạm hành chính."
        '            lblKetQuaVPHC.ForeColor = System.Drawing.Color.Blue
        '        End If
        '    End If
        'End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            strHoSoTiepNhanID = txtHoSoTiepNhanID.Text
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & strControl, True)
        End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objGPXD As New CapMoiGPXDController
            Dim objCapNhatGPXD As New GPXDController
            Dim mID As String
            ''truong hop cap doi
            'If strControl = "DIEUCHINHGPXD" Then
            '    mID = objCapNhatGPXD.addGPXD_CD(Me)
            'Else 'cap moi
            '    mID = objCapNhatGPXD.addGPXD(Me)
            'End If
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileGiayPhepXayDung", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            If strControl = "DIEUCHINHGPXD" Then
                ds = objGPXD.InGiayPhepXayDungDieuChinh(txtHoSoTiepNhanID.Text, txtSoGiayPhepTruoc.Text)
            Else
                ds = objGPXD.InGiayPhepXayDung(txtHoSoTiepNhanID.Text)
            End If
            If ds.Tables(0).Rows.Count = 0 Then
                SetMSGBOX_HIDDEN(Me.Page, "Khong co du lieu")
                Exit Sub
            End If
            txtSoGiayPhep.Text = ds.Tables(0).Rows(0).Item("M_SOGIAYPHEP").ToString
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objGPXD = Nothing
        End Sub

        Private Sub btnXacMinhThucDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXacMinhThucDia.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            Response.Redirect(EditURL("ID", strSoBienNhan, "XACMINHTHUCDIA") & "&oldControl=" & strControl, True)
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
        Private Sub btnKiemTraHS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKiemTraHS.Click
            If txtSoGiayPhep.Text <> "" Then Exit Sub
            Dim objVPHC As New ViPhamHanhChinhController
            Dim objGPXD As New CapMoiGPXDController
            lblKetQuaVPHC.Visible = False
            lblKetQuaDiaChi.Text = "Hồ sơ hợp lệ "
            lblKetQuaDiaChi.ForeColor = Color.Blue
            If objGPXD.KiemTraDiaChiXayDung(txtHoSoTiepNhanID.Text) = False Then
                lblKetQuaDiaChi.ForeColor = Color.Red
                lblKetQuaDiaChi.Text = "Địa chỉ đã được cấp giấy phép xây dựng "
            End If
            If objVPHC.IsViPhamHanhchinh(Trim(txtHoSoTiepNhanID.Text)) Then
                lblKetQuaVPHC.Text = "Chủ đầu tư đã vi phạm hành chính"
                lblKetQuaVPHC.Visible = True
            End If
        End Sub

      
    End Class

End Namespace
