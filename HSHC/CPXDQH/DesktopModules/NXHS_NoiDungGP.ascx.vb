Imports PortalQH
Namespace CPXD
    Public Class NXHS_NoiDungGP
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TxtNgayHoanCong As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayHoanCong As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtSoQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayQD As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtCaoDoNen As System.Web.UI.WebControls.TextBox
        Protected WithEvents TxTNoiDungXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichHienTrangGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkViTriQuiHoach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents LinkCaoDoNen As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtDienTichKhuonVienGiayPhep As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private Sub SetAttributesNgay()
            Dim strURL As String
            txtNgayQuyetDinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayQuyetDinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayQuyetDinh.ClientID & ");")
            txtNgayHoanCong.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHoanCong.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHoanCong.ClientID & ");")
            cmdNgayQD.NavigateUrl = AdminDB.InvokePopupCal(txtNgayQuyetDinh)
            cmdNgayHoanCong.NavigateUrl = AdminDB.InvokePopupCal(txtNgayHoanCong)
            txtDienTichHienTrangGiayPhep.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtDienTichHienTrangGiayPhep.ClientID & ");")
            txtDienTichHienTrangGiayPhep.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDienTichKhuonVienGiayPhep.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDienTichKhuonVienGiayPhep.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtDienTichKhuonVienGiayPhep.ClientID & ");")
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMCAODONEN&TextName=" & txtCaoDoNen.ClientID
            LinkCaoDoNen.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
        End Sub
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            SetAttributesNgay()
        End Sub

    End Class
End Namespace