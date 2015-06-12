Imports PortalQH
Namespace CPXD
    Public Class VaoSoGiayPhep
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayPhatHanh As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkHuy As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNhomCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongVanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox

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
            If Not Page.IsPostBack Then
                'If Not KiemTraRequest() Then
                '    btnTroVe_Click(Nothing, Nothing)
                'End If
                BindData()
                SetAttributesControl()
                LoadData()
                'txtMaNguoiTacNghiep.Text = CStr(Session("UserName"))
                If txtNgayCap.Text = "" Then
                    txtNgayCap.Text = NgayHienTai()
                End If
            End If
        End Sub
        Private Sub SetAttributesControl()
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCap.ClientID & ");")
            txtSoGiayPhep.Attributes.Add("onblur", "javascript:CheckSoNguyen(" & txtSoGiayPhep.ClientID & ");")

            cmdNgayPhatHanh.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCap)

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
        End Sub
        Private Sub BindData()

            txtMaNguoiTacNghiep.Text = CStr(Session("UserName"))
            txtMaHoSo.Text = Request.Params("ID")
            txtHoSoTiepNhanID.Text = Request.Params("HoSoTiepNhanID")
            txtNgayCap.Text = NgayHienTai()
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
        End Sub
        Private Sub LoadData()
            Dim objCPXD As New GPXDController
            Dim ds As New DataSet
            ds = objCPXD.getGPXD_New(txtMaHoSo.Text)
            gLoadControlValues(ds, Me)
            txtSoGiayPhep.Text = objCPXD.getsoGiayPhep(txtMaHoSo.Text).Tables(0).Rows(0)(0).ToString
        End Sub
        Private Overloads Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objCPXD As New GPXDController
            'objCPXD.CapSoGiayPhep(txtMaHoSo.Text, txtSoGiayPhep.Text, txtNgayCap.Text)
            objCPXD.CapSoGiayPhep_BinhThuy(txtMaHoSo.Text, txtSoGiayPhep.Text, txtNgayCap.Text, CType(Session.Item("ItemCode"), String), Request.Params("TabID"), CStr(Session("UserName")))
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click

        End Sub
    End Class
End Namespace
