Imports PortalQH
Namespace HSHC
    Public Class KhongGiaiQuyet
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayXuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMalyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents imgNgayXuLy As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungXuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNguoiSuDung As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoKhongGiaiQuyetID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaTinhTrangXuLy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayXuLy As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtLyDoKhac As System.Web.UI.WebControls.TextBox
        Protected WithEvents rdoReason As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rdoOtherReason As System.Web.UI.WebControls.RadioButton
        Protected WithEvents btnInVB As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/4/2007	Updated, them method RegisterClientScript
        '''     [phuocdd]   6/13/2007   Updated, khong quan ly visible cua btnIn trong code, theo yeu cau khach hang
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            lblTieuDe.Text = "Hồ sơ không giải quyết"

            txtNgayXuLy.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayXuLy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayXuLy.ClientID & ");")
            cmdNgayXuLy.NavigateUrl = AdminDB.InvokePopupCal(txtNgayXuLy)

            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
                BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangXuLy, False, "", "sp_getTinhTrangHoSoByLoai", CType(Session.Item("ItemCode"), String), Request.Params("tabid"), "HSK")
                If ddlMaTinhTrangXuLy.Items.Count > 0 Then ddlMaTinhTrangXuLy.SelectedIndex = 0
                BindControl.BindDropDownList(ddlMalyDo, "sp_GetDMLyDo", "", CType(Session.Item("ItemCode"), String), 1)
                BindDropDownList_NguoiKy(ddlMaNguoiSuDung)
                txtSoBienNhan.Text = Request.Params("ID").ToString
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
                txtNgayXuLy.Text = NgayHienTai()
            End If
            GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", "HSHC", btnIn, Me)
            'If txtHoSoTiepNhanID.Text = "" Then
            '    btnIn.Visible = False
            'Else
            '    btnIn.Visible = True
            'End If

            Me.RegisterClientScript()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Dang ky javascript
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/4/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub RegisterClientScript()
            Me.rdoReason.Attributes.Add("onclick", "javascript:SelectLyDo();")
            Me.rdoOtherReason.Attributes.Add("onclick", "javascript:InputLyDo();")
        End Sub

        Private Sub LoadData()
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Dim rs As DataSet
            rs = objHoSoKhong.GetHoSoKhongGiaiQuyet(Me)
            gLoadControlValues(rs, Me)
            If (Me.txtLyDoKhac.Text.Trim().Length > 0) Then
                Me.rdoOtherReason.Checked = True
                Me.txtLyDoKhac.Enabled = Me.rdoOtherReason.Checked
                Me.ddlMalyDo.Enabled = Not Me.rdoOtherReason.Checked
            Else
                Me.rdoReason.Checked = True
                Me.txtLyDoKhac.Enabled = Not Me.rdoReason.Checked
                Me.ddlMalyDo.Enabled = Me.rdoReason.Checked
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/13/2007	Updated, khong quan ly visible btnIn trong code, theo yeu cau khach hang
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            objHoSoKhong.AddHoSoKhongGiaiQuyet(Me)
            'btnIn.Visible = True
        End Sub

        Private Sub btnInVB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInVB.Click
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileHoSoKhong", glbXMLFile)
            strOutputFileName = "HoSoKhong" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objHoSoKhong.InHoSoKhongGiaiQuyet(Me.txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, Request("Malv"), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objHoSoKhong = Nothing
            ds = Nothing
        End Sub
    End Class
End Namespace