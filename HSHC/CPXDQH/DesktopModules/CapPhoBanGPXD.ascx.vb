Imports PortalQH
Imports System.Configuration
Namespace CPXD
    Public Class CapPhoBanGPXD
        Inherits PortalQH.PortalModuleControl

        Private pID As String = ""
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Private strControl As String
        Private Const strURL As String = "CPXD/DesktopModules/TimKiemGiayCNDKKD.aspx"

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoaiXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCapNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInQD As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdNgayCap As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtSoQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayQuyetDinh As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtNgayCapPhoBan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSao As System.Web.UI.WebControls.Label
        Protected WithEvents btnInDexuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
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
            End If
            strControl = Request.Params("ctl")
            SetAttributes()
            If Not Me.IsPostBack Then
                'BindControl.BindDropDownList(ddlCapNha, "DMCAPNHA")
                'BindControl.BindDropDownList(ddlPhanLoaiXD, "DMPHANLOAIXAYDUNG")
                BindData(pID)
                txtReload.Text = "0"
                If txtNgayCapPhoBan.Text = "" Then
                    txtNgayCapPhoBan.Text = NgayHienTai()
                End If
                btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            End If

            If Trim(txtSoGiayPhep.Text) <> "" And txtReload.Text = "1" Then
                getGPXD()
                txtReload.Text = "0"
            End If


            'btnDanhSachGP.Visible = CType(Request.Params("AddNew"), Boolean)
            lblSoBN.Visible = True
            lblSoGP.Visible = False
            'SetStatus(CType(Request.Params("AddNew"), Boolean))
            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            '  GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", strReportPath, btnInQD, Me)
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "2", strReportPath, btnInGP, Me)
        End Sub

        Private Sub SetAttributes()
            txtNgayQuyetDinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapPhep.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayQuyetDinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayQuyetDinh.ClientID & ");")
            txtNgayQuyetDinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayQuyetDinh.ClientID & ");")
            cmdNgayQuyetDinh.NavigateUrl = AdminDB.InvokePopupCal(txtNgayQuyetDinh)
            txtNgayCapPhoBan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCapPhoBan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCapPhoBan.ClientID & ");")
            cmdNgayCap.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCapPhoBan)
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            txtMaLinhVuc.Text = Request.Params("Malv")
            txtMaNguoiTacNghiep.Text = Session.Item("UserName").ToString()
            txtTabCode.Text = Request.Params("TabID")
            txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCapPhoBan.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub SetStatus(ByVal flgAddNew As Boolean)
            If flgAddNew Then
                btnXoa.Visible = False
                btnInGP.Visible = False
                btnInQD.Visible = False
            Else
                btnXoa.Visible = True
                btnInGP.Visible = True
                btnInQD.Visible = True
            End If
            If txtSoBienNhan.Text = "" Then

                lblSoBN.Visible = False

            End If
            btnDanhSachGP.Visible = True
            lblSoGP.Visible = False
            'txtSoGiayPhep.ReadOnly = Not flgAddNew
            If txtSoBienNhan.Text = "" Then
                btnDanhSachGP.Visible = False
                lblSoGP.Visible = True
            End If
            lblSao.Visible = btnDanhSachGP.Visible
        End Sub

        Private Sub getGPXD()
            Dim objCapPhoBan As New CapPhoBanController
            Dim ds As DataSet
            ds = objCapPhoBan.getGPXD(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me, LoadControlValuesLocation.Local)
            ds = Nothing
        End Sub

        Sub BindData(ByVal id As String)
            Dim objCapPhoBan As New CapPhoBanController
            Dim ds As DataSet
            ds = objCapPhoBan.GetCapPhoBan(id)
            gLoadControlValues(ds, Me)
            getGPXD()
            objCapPhoBan = Nothing
        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl") & "&AddNew=" & Request.Params("AddNew")), True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objCapPhoBan As New CapPhoBanController
            Dim iError As Integer

            objCapPhoBan.AddCapPhoBan(Me)
            objCapPhoBan = Nothing
            btnXoa.Visible = True
            btnInGP.Visible = True
            btnInQD.Visible = True
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objCapPhoBan As New CapPhoBanController
            Dim iError As Integer

            objCapPhoBan.DelCapPhoBan(Me)

            objCapPhoBan = Nothing
            Response.Redirect(NavigateURL(), True)
        End Sub
        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnInDexuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInDexuat.Click
            Dim objGPXD As New CapPhoBanController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileDeXuatPhoBan", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objGPXD.InBaoCaoDeXuat(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objGPXD = Nothing
        End Sub

        Private Sub btnInQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInQD.Click
            Dim objGPXD As New CapPhoBanController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileQuyetDinh", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objGPXD.InBaoCaoDeXuat(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objGPXD = Nothing
        End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            strHoSoTiepNhanID = txtHoSoTiepNhanID.Text
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & strControl, True)
        End Sub

        'Private Sub btnInGP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInGP.Click

        'End Sub
    End Class
End Namespace
