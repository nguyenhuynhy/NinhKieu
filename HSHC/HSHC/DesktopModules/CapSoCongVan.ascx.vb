Imports PortalQH
Namespace HSHC
    Public Class CongVan
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNhomCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongVanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkHuy As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenLoaiHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayCongVan As System.Web.UI.WebControls.HyperLink


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

            If Not Page.IsPostBack Then
                'If Not KiemTraRequest() Then
                '    btnTroVe_Click(Nothing, Nothing)
                'End If
                BindData()
                SetAttributesControl()
                LoadData()
                'txtMaNguoiTacNghiep.Text = CStr(Session("UserName"))
                If txtNgayCongVan.Text = "" Then
                    txtNgayCongVan.Text = NgayHienTai()
                End If
            End If
        End Sub

        Private Function KiemTraRequest() As Boolean
            If Request.Params("ID") Is Nothing Or Request.Params("ID") = "" _
                        Or Request.Params("NhomCV") Is Nothing Or Request.Params("NhomCV") = "" _
                        Or Request.Params("CongVanID") Is Nothing Or Request.Params("CongVanID") = "" Then
                Return False
            End If
            Return True
        End Function

        Private Sub BindData()
            txtMaNhomCongVan.Text = Request.Params("NhomCV")
            txtCongVanID.Text = Request.Params("CongVanID")
            txtMaNguoiTacNghiep.Text = CStr(Session("UserName"))
            txtMaHoSo.Text = Request.Params("ID")
            txtHoSoTiepNhanID.Text = Request.Params("HoSoTiepNhanID")
            txtNgayCongVan.Text = NgayHienTai()

        End Sub

        Private Sub SetAttributesControl()
            txtSoCongVan.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCongVan.Attributes.Add("ISNULL", "NOTNULL")            
            txtSoCongVan.Attributes.Add("onblur", "javascript:CheckSoNguyen(" & txtSoCongVan.ClientID & ");")

            txtNgayCongVan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCongVan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCongVan.ClientID & ");")
            cmdNgayCongVan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCongVan)

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
        End Sub

        Private Sub LoadData()
            Dim ds As DataSet
            Dim obj As New CongVanController
            ds = obj.getCongVan(Request.Params("ID"), Request.Params("NhomCV"))
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        gLoadControlValues(ds, Me)
                        ds = Nothing
                        obj = Nothing
                        Exit Sub
                    End If
                End If
            End If
            'btnTroVe_Click(Nothing, Nothing)
        End Sub

        Private Overloads Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Overloads Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                Dim obj As New CongVanController
                If obj.insCongVan(Me) <> "" Then
                    'If txtCongVanID.Text <> "" Then
                    ' txtCongVanID.Text = obj.insCongVan(Me)
                    Response.Redirect(Request.RawUrl())
                Else
                    SetMSGBOX_HIDDEN(Page, "Trung so cong van!")
                    Exit Sub
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Overloads Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim obj As New CongVanController
            If obj.delCongVan(Me) <> 0 Then
                SetMSGBOX_HIDDEN(Page, "Xoa thong tin cap so khong thanh cong!")
                Exit Sub
            End If
            Response.Redirect(Request.RawUrl())
            obj = Nothing
        End Sub


    End Class
End Namespace