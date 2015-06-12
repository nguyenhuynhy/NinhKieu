Imports PortalQH
Namespace CPKTQH
    Public Class ViPhamHanhChinh
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayQuyetDinh As System.Web.UI.WebControls.Image
        Protected WithEvents txtDonViRaQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtViPhamHanhChinhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label




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
            If Not Me.IsPostBack Then
                SetAttributesControl()
                BindControl.BindDropDownList(ddlDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")

                If Not Request.Params("ID") Is Nothing Then
                    txtViPhamHanhChinhID.Text = CStr(Request.Params("ID"))
                End If

                InitState()
                txtSoCMND.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMND.ClientID & ");")
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtNgayQuyetDinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayQuyetDinh);")
            imgNgayQuyetDinh.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayQuyetDinh, 'dd/mm/yyyy');")

            txtSoQuyetDinh.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayQuyetDinh.Attributes.Add("ISNULL", "NOTNULL")
            'txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            Me.btnXoa.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn xóa quyết định vi phạm hành chính này không?');")
            btnThemMoi.Attributes.Add("onclick", "javascript:return form_empty();")
        End Sub

        Private Sub InitState()
            If txtViPhamHanhChinhID.Text = "" Then   'thêm mới
                txtNgayQuyetDinh.Text = Format(Now(), "dd/MM/yyyy")
                SetEnabledControl(True)
            Else    'cập nhật
                Dim ds As DataSet
                Dim objVPHC As New ViPhamHanhChinhController
                ds = objVPHC.getThongTinViPhamHanhChinh(txtViPhamHanhChinhID.Text)
                gLoadControlValues(ds, Me)
                ds = Nothing
                objVPHC = Nothing

                SetEnabledControl(False)
            End If
        End Sub

        Private Sub SetEnabledControl(ByVal flag As Boolean)
            txtSoQuyetDinh.Enabled = flag
            txtSoGiayPhep.Enabled = flag
            txtSoCMND.Enabled = flag
            txtSoNha.Enabled = flag
            ddlDuong.Enabled = flag
            ddlPhuong.Enabled = flag
            btnXoa.Visible = Not flag
        End Sub



        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            If txtViPhamHanhChinhID.Text = "" Then
                SetMSGBOX_HIDDEN(Page, "Bạn chưa chọn quyết định vi phạm hành chính!!!")
                SetEnabledControl(True)
                Exit Sub
            End If

            Dim objVPHC As New ViPhamHanhChinhController
            objVPHC.delViPhamHanhChinh(txtViPhamHanhChinhID.Text)
            objVPHC = Nothing

            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            If Trim(txtSoGiayPhep.Text) = "" And Trim(txtSoCMND.Text) = "" And _
                (Trim(txtSoNha.Text) = "" Or ddlDuong.SelectedValue = "" Or ddlPhuong.SelectedValue = "") Then
                SetMSGBOX_HIDDEN(Page, "Bạn phải nhập thông tin đơn vị vi phạm!!!")
                Exit Sub
            End If

            Dim objVPHC As New ViPhamHanhChinhController
            Dim strID As String
            strID = objVPHC.updViPhamHanhChinh(Me)
            Select Case strID
                Case "-1" : SetMSGBOX_HIDDEN(Page, "Số quyết định vi phạm đã tồn tại!!!")
                Case "-2" : SetMSGBOX_HIDDEN(Page, "Không có thông tin của đơn vị vi phạm!!!")
                Case "-3" : SetMSGBOX_HIDDEN(Page, "Thông tin của đơn vị vi phạm không chính xác!!!")
                Case Else  'cập nhật thành công
                    txtViPhamHanhChinhID.Text = strID
                    InitState()
            End Select
        End Sub
    End Class
End Namespace