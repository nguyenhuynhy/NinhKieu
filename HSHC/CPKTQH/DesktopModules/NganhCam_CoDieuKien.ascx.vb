Imports PortalQH
Namespace CPKTQH
    Public Class NghanhCam_CoDieuKien
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlNganh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents rblLoai As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents chkToanQuan As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblPhuong As System.Web.UI.WebControls.Label
        Protected WithEvents lblDuong As System.Web.UI.WebControls.Label
        Protected WithEvents dgrPhuong As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dgrDuong As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents dgrDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink


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
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)

            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlNganh, "DMNGANHKINHDOANH")
            End If
        End Sub

    End Class
End Namespace