Imports PortalQH
Namespace CPXD
    Public Class BaoCaoTongHop
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTuNgay As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdStartCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblDenNgay As System.Web.UI.WebControls.Label
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdEndCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents lblMaPhuong As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblMaloaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblThang As System.Web.UI.WebControls.Label
        Protected WithEvents ddlThang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblNam As System.Web.UI.WebControls.Label
        Protected WithEvents txtNam As System.Web.UI.WebControls.TextBox
        Protected WithEvents lstReports As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents txtLoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btntroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnExport As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtQuyMo As System.Web.UI.WebControls.TextBox

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

            Dim ctrl As Control
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
                CreateDdlThang()
                BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
                BindControl.BindRadioButtonList(lstReports, "sp_GetReportList", "1", TabId)
                lblTieuDe.Text = "Báo cáo tình hình cấp phép xây dựng"
                txtTuNgay.Text = g_DateToString(DateAdd(DateInterval.Month, -1, Now))
                txtDenNgay.Text = NgayHienTai()

                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
                SetControlStatus()
                SetAttributesNgay()

            End If
            txtLoai.Text = lstReports.SelectedItem.Value
            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            GetReportURL(Request.Params("TabId").ToString, GetLinhVuc, lstReports.SelectedItem.Value, strReportPath, btnIn, Me)
        End Sub


        Private Sub lstReports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstReports.SelectedIndexChanged
            SetControlStatus()
        End Sub
        Private Sub SetControlStatus()
            btnIn.Visible = True
            Select Case lstReports.SelectedValue
                Case "1", "2", "3", "5" 'Báo cáo công tác cấp phép xây dựng
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlThang.Visible = False
                    txtNam.Visible = False
                    btnExport.Visible = False
                    btnIn.Visible = True
                    'Case "2" 'Báo cáo công tác cấp phép xây dựng và lũy kế đầu năm
                    '    txtTuNgay.Visible = False
                    '    txtDenNgay.Visible = False
                    '    ddlThang.Visible = True
                    '    txtNam.Visible = True
                    '    btnExport.Visible = False
                    '    btnIn.Visible = True
                    'Case "3" 'Danh mục công trình được cấp phép
                    '    txtTuNgay.Visible = False
                    '    txtDenNgay.Visible = False
                    '    ddlThang.Visible = True
                    '    txtNam.Visible = True
                    '    btnExport.Visible = False
                    '    btnIn.Visible = True
                Case "4"
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlThang.Visible = False
                    txtNam.Visible = False
                    btnExport.Visible = False
                    btnIn.Visible = True
                    btnExport.Visible = True
                    btnIn.Visible = False

            End Select
            cmdStartCalendar.Visible = txtTuNgay.Visible
            cmdEndCalendar.Visible = txtDenNgay.Visible
            lblTuNgay.Visible = txtTuNgay.Visible
            lblDenNgay.Visible = txtDenNgay.Visible
            lblThang.Visible = ddlThang.Visible
            lblNam.Visible = txtNam.Visible
            lblMaPhuong.Visible = ddlMaPhuong.Visible
        End Sub


        Private Sub SetAttributesNgay()
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            cmdStartCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdEndCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
        End Sub
        Private Sub CreateDdlThang()
            Dim arrThang As New ArrayList
            arrThang.Add("01")
            arrThang.Add("02")
            arrThang.Add("03")
            arrThang.Add("04")
            arrThang.Add("05")
            arrThang.Add("06")
            arrThang.Add("07")
            arrThang.Add("08")
            arrThang.Add("09")
            arrThang.Add("10")
            arrThang.Add("11")
            arrThang.Add("12")
            ddlThang.DataSource = arrThang
            ddlThang.DataBind()
        End Sub
        Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim objDSHoCaThe As New TimKiemGiayPhepXayDungController
            Dim dt As DataTable
            dt = objDSHoCaThe.LayDanhSachGiayPhepXuatExcel(txtTuNgay.Text, txtDenNgay.Text, ddlMaPhuong.SelectedValue).Tables(0)
            Dim strServerPath As String
            Dim strFile As String
            Dim strTemplate As String
            Dim strFileOpen As String
            strServerPath = Request.MapPath(Request.ApplicationPath)
            strFile = strServerPath & "\CPXD\Reports\Temp\DanhSachGiayPhep_" & Session.Item("UserName").ToString & ".xls"
            strFileOpen = "\CPXD\Reports\Temp\DanhSachGiayPhep_" & Session.Item("UserName").ToString & ".xls"
            strTemplate = strServerPath & "\CPXD\Reports\Reports\MyTemplate.xls"
            If ExportToExcel(dt, strFile, strTemplate) Then
                LinkButton1.Visible = True
            Else
                LinkButton1.Visible = False
                SetMSGBOX_HIDDEN(Page, "Khong tao duoc file. Kiem tra xem ban da dong file 'DanhSachHoCaThe_" & Session.Item("UserName").ToString & ".xls' chua?")
            End If
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
        End Sub
    End Class
End Namespace
