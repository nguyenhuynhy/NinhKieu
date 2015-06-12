Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class NgungKinhDoanh
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblDanhSach As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDanhSachGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblNganhCapTren As System.Web.UI.WebControls.Label
        Protected WithEvents lblVonKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgaySinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents imgNgayNgungKD As System.Web.UI.WebControls.Image
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTrove As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgungKinhDoanhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaLyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayBatDau As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayKetThuc As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayKetThuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenHinhThucKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHetHan As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLinhVucCapPhep As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label



        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private strControl As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            strControl = Request.Params("ctl")

            If Not Me.IsPostBack Then
                SetAttributesControl()
                BindControl.BindDropDownList(ddlMaLyDo, "DMLYDO")

                '--Get thong tin so bien nhan
                If Not Request.Params("ID") Is Nothing Then
                    txtHoSoTiepNhanID.Text = Request.Params("ID")
                    Dim objHoSoTiepNhan As New HoSoTiepNhanController
                    Dim ds As New DataSet
                    ds = objHoSoTiepNhan.GetChiTietHoSoTiepNhan(txtHoSoTiepNhanID.Text)
                    txtSoBienNhan.Text = CStr(ds.Tables(0).Rows(0).Item("SoBienNhan"))
                    strControl = Request.Params("ctl")
                End If

                '--Get So giay phep cua so bien nhan
                GetSoGiayPhep()

                '--Lay Thong tin GiayCNDKKD neu co
                If Trim(txtSoGiayPhep.Text) <> "" Then 'Da co data
                    ViewState("isAddNew") = False
                    GetGiayCNDKKD()
                Else 'Chua co data
                    ViewState("isAddNew") = True

                End If
                SetFocus(Page, txtSoGiayPhep)
            End If
            hiddenAllButton()
            '-----------------------Cap nhat trang thai cac control-------------
            If CBool(ViewState("isAddNew")) Then 'New la them moi
                If CheckHoSoBoSung(Request.Params("ID")) Then 'Neu la ho so da bo sung
                    btnYCBS.Visible = True
                    btnYCBS_Click(Nothing, Nothing)
                ElseIf CheckHoSoKhongGiaiQuyet(Request.Params("ID")) Then 'Neu la ho so khong giai quyet
                    btnHoSoKhong.Visible = True
                    btnHoSoKhong_Click(Nothing, Nothing)
                Else
                    btnHoSoKhong.Visible = True
                    btnYCBS.Visible = True
                    btnCapNhat.Visible = True
                End If

                lblDanhSachGP.Visible = False
                btnDanhSachGP.Visible = True
                txtSoGiayPhep.ReadOnly = False
            Else ' Neu la cap nhat
                If CheckHoSoDeXuat(Request.Params("ID")) Then 'Neu la ho so da de xuat
                    btnDeXuat.Visible = True
                    btnIn.Visible = True
                    btnCapNhat.Visible = True
                Else
                    btnDeXuat.Visible = True
                    btnCapNhat.Visible = True
                    btnXoa.Visible = True
                End If

                lblDanhSachGP.Visible = True
                btnDanhSachGP.Visible = False
                txtSoGiayPhep.ReadOnly = True
                '-----------------------------------------------------------------

            End If

            If txtNgayBatDau.Text = "" Then
                txtNgayBatDau.Text = Format(Now(), "dd/MM/yyyy")
            End If





        End Sub
        Private Sub GetSoGiayPhep()
            Dim objNgungKinhDoanh As New NgungKinhDoanhController
            txtSoGiayPhep.Text = objNgungKinhDoanh.getSoGiayPhep(txtSoBienNhan.Text)
        End Sub
        Private Sub GetGiayCNDKKD()
            'Get thong tin GiayCNDKKD tu SoGiayPhep
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet

            '--Get thong tin GCNDKKD
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhepNgungKinhDoanh(txtSoGiayPhep.Text.Replace("'", "''"))
            If ds.Tables(0).Rows.Count > 0 Then 'Co data
                gLoadControlValues(ds, Me)

                '---Load thong tin Ngung kinh doanh 
                Dim objNgungKinhDoanh As New NgungKinhDoanhController
                Dim dsThongTin As New DataSet
                dsThongTin = objNgungKinhDoanh.getThongTinNgungKinhDoanh(txtSoGiayPhep.Text)
                If dsThongTin.Tables(0).Rows.Count > 0 Then
                    txtNgungKinhDoanhID.Text = CStr(dsThongTin.Tables(0).Rows(0).Item("NgungKinhDoanhID"))
                    ddlMaLyDo.SelectedValue = CStr(dsThongTin.Tables(0).Rows(0).Item("MaLyDo"))
                    If Not IsDBNull(dsThongTin.Tables(0).Rows(0).Item("NgayBatDau")) Then
                        txtNgayBatDau.Text = CStr(dsThongTin.Tables(0).Rows(0).Item("NgayBatDau"))
                    Else
                        txtNgayBatDau.Text = Format(Now(), "dd/MM/yyyy")
                    End If
                    If Not IsDBNull(dsThongTin.Tables(0).Rows(0).Item("GhiChu")) Then
                        txtGhiChu.Text = CStr(dsThongTin.Tables(0).Rows(0).Item("GhiChu"))
                    End If
                    If Not IsDBNull(dsThongTin.Tables(0).Rows(0).Item("NgayKetThuc")) Then
                        txtNgayKetThuc.Text = CStr(dsThongTin.Tables(0).Rows(0).Item("NgayKetThuc"))
                    Else

                    End If
                Else 'Khong co data thi` clear
                    ddlMaLyDo.SelectedValue = ""
                    txtGhiChu.Text = ""
                    txtNgayBatDau.Text = Format(Now(), "dd/MM/yyyy")
                    txtNgayKetThuc.Text = Format(Now(), "dd/MM/yyyy")
                End If
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
        Private Sub txtSoGiayPhep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoGiayPhep.TextChanged
            GetGiayCNDKKD()
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            'Cap nhat Ngung Kinh Doanh
            Dim objNgungKinhDoanh As New NgungKinhDoanhController
            Dim NgayKetThuc As String = ""
            If txtNgayKetThuc.Enabled Then
                NgayKetThuc = txtNgayKetThuc.Text
            End If
            txtNgungKinhDoanhID.Text = objNgungKinhDoanh.updNgungKinhDoanh(Me)

            'Cap nhat tinh trang ho so
            'Dim objGiayCNDKKD As New GiayCNDKKDController
            'objGiayCNDKKD.UpdTinhTrangGiayCNDKKD(txtSoGiayPhep.Text.Replace("'", "''"), "N")

            ViewState("isAddNew") = False
            '-----------------------Cap nhat trang thai cac nut------------
            lblDanhSachGP.Visible = True
            btnDanhSachGP.Visible = False
            txtSoGiayPhep.ReadOnly = True

            hiddenAllButton()
            btnDeXuat.Visible = True
            btnCapNhat.Visible = True
            btnXoa.Visible = True
     
        End Sub
        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objNgungKinhDoanh As New NgungKinhDoanhController
            objNgungKinhDoanh.delNgungKinhDoanh(txtNgungKinhDoanhID.Text, txtGiayCNDKKDID.Text, txtHoSoTiepNhanID.Text)
            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub SetAttributesControl()
            txtNgayBatDau.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayBatDau);")
            imgNgayNgungKD.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayBatDau, 'dd/mm/yyyy');")
            Me.txtNgayBatDau.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayBatDau.ClientID & ");")
            Me.txtNgayBatDau.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayKetThuc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayKetThuc);")
            imgNgayKetThuc.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayKetThuc, 'dd/mm/yyyy');")
            Me.txtNgayKetThuc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayKetThuc.ClientID & ");")
            Me.txtNgayKetThuc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayBatDau.Text = Format(Now(), "dd/MM/yyyy")

            Dim strURL As String
            strURL = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")

            txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLyDo.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayBatDau.Attributes.Add("ISNULL", "NOTNULL")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return btnCapNhat_clicked();")

        End Sub
        'Private Sub SetStatusControl(ByVal IsAddNew As Boolean)
        'btnDanhSachGP.Visible = False
        'lblDanhSachGP.Visible = Not btnDanhSachGP.Visible
        'End Sub
        Private Sub btnDanhSach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl")), True)
            'SetStatusControl(True)
        End Sub
        Private Sub btnTrove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrove.Click
            Response.Redirect(NavigateURL(""))
        End Sub
        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            'Dim objNgungKinhDoanh As New NgungKinhDoanhController
            'Dim ds As New DataSet
            'Dim strFileOutput As String
            'Dim strFileOpen As String
            'Dim strFileName As String
            'Dim strFileTemplate As String
            'Dim arrTable As New ArrayList
            'strFileName = GetParamByID("FileNgungKinhDoanh", glbXMLFile)
            'strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("TemplatesCPKTQH") & strFileName
            'strFileOutput = ConfigurationSettings.AppSettings("DocumentsCPKTQH") & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            'strFileOpen = strFileOutput
            'strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            'ds = objNgungKinhDoanh.InGiayChungNhanNgungKinhDoanh(txtNgungKinhDoanhID.Text)
            'ReportByWord(ds, strFileTemplate, strFileOutput)
            'Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")

            Dim objNgungKinhDoanh As New NgungKinhDoanhController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileNgungKinhDoanh", glbXMLFile)
            strOutputFileName = "ChungNhanNgungKinhDoanh" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objNgungKinhDoanh.InGiayChungNhanNgungKinhDoanh(txtNgungKinhDoanhID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objNgungKinhDoanh = Nothing
            ds = Nothing
        End Sub
        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            If strSoBienNhan <> "" And Not CheckHoSoBoSung(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=DX&oldControl=" & strControl, True)
            End If
        End Sub
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
        Private Sub hiddenAllButton()
            btnCapNhat.Visible = False
            btnXoa.Visible = False
            btnDeXuat.Visible = False
            btnHoSoKhong.Visible = False
            btnYCBS.Visible = False
            btnIn.Visible = False
        End Sub
    End Class
End Namespace