Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class DeXuat
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTrinhThamDinhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbYkien As System.Web.UI.WebControls.Label
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeXuatID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaCanBoDeXuat As System.Web.UI.WebControls.TextBox
        Protected WithEvents hMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgungKinhDoanhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLoaiDoanhNghiep As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblNgayNhan As System.Web.UI.WebControls.Label
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
        Private strSoGiayPhep As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            strControl = Request.Params("oldControl")
            'strSoGiayPhep = Request.Params("SoGiayPhep")

            If Not Me.IsPostBack Then
                Init_Status()                
            End If
            AddJavaScript()
            'txtMaLinhVuc.Text = gItemCode
            'txtTabCode.Text = CType(TabId, String)
            'txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), Request.Params("Loai"), ctype(Session.Item("ActiveDB"),string), btnIn, Me)
        End Sub
        Private Sub Init_Status()
            Dim objNganhKinhDoanh As New NganhKinhDoanhController
            ddlMaNganhKinhDoanh.DataSource = objNganhKinhDoanh.getNganhKinhDoanhChinh()
            ddlMaNganhKinhDoanh.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanh.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanh.DataBind()

            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)

            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))
            
            lblSoBienNhan.Text = Request.Params("ID").ToString

            If lblSoBienNhan.Text <> "" Then
                LoadData()
            End If
            objNganhKinhDoanh = Nothing
        End Sub
        Private Sub AddJavaScript()
            ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
            btnBoQua.Attributes.Add("onclick", "javascript:history.back();")
            txtMatHangKinhDoanh.Attributes.Add("onblur", "javascript:GetNoiDung('" & txtMatHangKinhDoanh.ClientID & "','" & txtNoiDung.ClientID & "');")
        End Sub
        Private Sub LoadData()
            Dim objThamDinhDeXuat As New ThamDinhDeXuatController
            Dim rs As DataSet
            rs = objThamDinhDeXuat.GetThamDinhDeXuatBySoBienNhan(lblSoBienNhan.Text)
            gLoadControlValues(rs, Me)
            If txtNoiDung.Text = "" Then
                Dim strGioiTinh As String
                Select Case lblGioiTinh.Text
                    Case "Nam"
                        strGioiTinh = "ông"
                    Case "Nữ"
                        strGioiTinh = "bà"
                    Case ""
                        strGioiTinh = ""
                End Select
                Dim strNoiDung As String
                If strControl = "THAYDOIDKKD" Then
                    strNoiDung = GetParamByID("YkiendexuatTD", glbXMLFile)
                Else
                    strNoiDung = GetParamByID("Ykiendexuat", glbXMLFile)
                End If
                strNoiDung = Replace(strNoiDung, "[HoTen]", Server.HtmlDecode(lblHoTen.Text))
                txtNoiDung.Attributes.Add("tag", strNoiDung)
                txtNoiDung.Text = strNoiDung
            End If

            'Load data to textbox visible
            txtMaLinhVuc.Text = GetLinhVuc()
            txtTabCode.Text = Request.QueryString("TabID")
            txtMaCanBoDeXuat.Text = CType(Session.Item("UserName"), String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)

            If objThamDinhDeXuat.CheckKiemTraDeXuat(txtHoSoTiepNhanID.Text) = False Then
                btnXoa.Visible = False
                btnIn.Visible = False
            End If
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objThamDinhDeXuat As New ThamDinhDeXuatController
            txtDeXuatID.Text = objThamDinhDeXuat.AddThamDinhDeXuat(Me)
            If txtDeXuatID.Text = "" Then
                hMsg.Value = "Cap nhat khong thanh cong!"
                Exit Sub
            End If
            Response.Redirect(Request.RawUrl())
            btnXoa.Visible = True
            btnIn.Visible = True
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThamDinhDeXuat As New ThamDinhDeXuatController
            If Not objThamDinhDeXuat.DelThamDinhDeXuat(Me) Then
                SetMSGBOX_HIDDEN(Page, "Xoa khong thanh cong!")
                Exit Sub
            End If
            Response.Redirect(Request.RawUrl())
        End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            'Dim objThamDinhDexuat As New ThamDinhDeXuatController
            'Dim ds As New DataSet
            'Dim strFileTemplate As String
            'Dim strFileOutput As String
            'Dim strFileOpen As String
            'Dim strFileName As String
            'strFileName = GetParamByID("FileDeXuat", glbXMLFile)
            'strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            'strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            'strFileOpen = strFileOutput
            'strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            'ds = objThamDinhDexuat.InBaoCaoDeXuat(txtHoSoTiepNhanID.Text)
            'ReportByWord(ds, strFileTemplate, strFileOutput)
            'Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            'objThamDinhDexuat = Nothing
            Dim objThamDinhDexuat As New ThamDinhDeXuatController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileDeXuat", glbXMLFile)
            strOutputFileName = "DeXuat" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objThamDinhDexuat.InBaoCaoDeXuat(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objThamDinhDexuat = Nothing
            ds = Nothing
        End Sub

        Private Sub btnInPhieuChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim objThamDinhDexuat As New ThamDinhDeXuatController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FilePhieuChuyenKhaoSat", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objThamDinhDexuat.InPhieuChuyenKhaoSat(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objThamDinhDexuat = Nothing
        End Sub

        Private Sub btnInPhieuKhaoSat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim objPhieuKhaoSat As New PhieuKhaoSatController
            Dim dsPhieuKhaoSat As New DataSet
            Dim dsNoiDungKhaoSat As New DataSet
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            Dim strFileTemplate As String
            Dim arrTable As New ArrayList
            strFileName = GetParamByID("FilePhieuKhaoSat", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            dsPhieuKhaoSat = objPhieuKhaoSat.InPhieuKhaoSat(txtTrinhThamDinhID.Text)
            dsNoiDungKhaoSat = objPhieuKhaoSat.InNoiDungKhaoSat(txtTrinhThamDinhID.Text)
            arrTable.Add("2")
            ReportByWord(dsPhieuKhaoSat, strFileTemplate, strFileOutput, arrTable, dsNoiDungKhaoSat)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text & "&SoGiayPhep=" & Request.QueryString("SoGiayPhep") & "&Loai=" & Request.QueryString("ChucNang"), strControl), True)
            'Response.Redirect(NavigateURL(), True)
        End Sub

    End Class
End Namespace