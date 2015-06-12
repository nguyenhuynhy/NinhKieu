Imports PortalQH
Namespace CPXD
    Public Class YeuCauBSHS
        Inherits PortalQH.PortalModuleControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtNgayYeuCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNgayBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLanhDao As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents imgNgayYeuCau As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungYeuCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNguoiSuDung As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoBoSungID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaTinhTrangXuLy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnInXacMinh As System.Web.UI.WebControls.LinkButton

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
            lblTieuDe.Text = "Yêu cầu bổ sung hồ sơ" & UCase(Request.Params("Tenlv"))
            
            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            ' GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "4", strReportPath, btnInThongBao, Me)
            If Not Me.IsPostBack Then
                BindDropDownList_NguoiKy(ddlMaNguoiSuDung)
                If CType(Request.Params("ctl"), String) = "HENXACMINH" Then
                    BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangXuLy, False, "", "sp_getTinhTrangHoSoByLoai", CType(Session.Item("ItemCode"), String), Request.Params("tabid"), "HXM")
                Else
                    BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangXuLy, False, "", "sp_getTinhTrangHoSoByLoai", CType(Session.Item("ItemCode"), String), Request.Params("tabid"), "BHS")
                End If
                If ddlMaTinhTrangXuLy.Items.Count > 0 Then ddlMaTinhTrangXuLy.SelectedIndex = 0
                If Not Request.Params("ID") Is Nothing Then
                    txtSoBienNhan.Text = Request.Params("ID").ToString
                End If
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
                If txtNgayYeuCau.Text = "" Then
                    txtNgayYeuCau.Text = NgayHienTai()
                End If
            End If
            If txtHoSoBoSungID.Text = "" Then
                'btnInThongBao.Visible = False
            End If
        End Sub
        Private Sub SetAttribute()
            txtNgayYeuCau.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayYeuCau);")
            imgNgayYeuCau.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayYeuCau, 'dd/mm/yyyy');")
            txtSoNgayBoSung.Attributes.Add("onblur", "javascript:CheckSoNgay(" & txtSoNgayBoSung.ClientID & ");")
            txtSoNgayBoSung.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub
        Private Sub LoadData()
            Dim objHoSoBoSung As New HoSoBoSungController
            Dim rs As DataSet
            If CType(Request.Params("ctl"), String) = "HENXACMINH" Then
                rs = objHoSoBoSung.GetThongBaoXacMinhBySoBienNhan(Me)
            Else
                rs = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(Me)
            End If
            gLoadControlValues(rs, Me)
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim objHoSoBoSung As New HoSoBoSungController
            If CType(Request.Params("ctl"), String) = "HENXACMINH" Then
                txtHoSoBoSungID.Text = objHoSoBoSung.AddThongBaoXacMinh(Me)
            Else
                txtHoSoBoSungID.Text = objHoSoBoSung.AddHoSoBoSung(Me)
            End If
            '            btnInThongBao.Visible = True
        End Sub

        Private Sub btnInThongBao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
    End Class
End Namespace