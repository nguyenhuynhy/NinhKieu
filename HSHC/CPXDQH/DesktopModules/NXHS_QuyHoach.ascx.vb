Imports PortalQH
Namespace CPXD
    Public Class NXHS_QuyHoach
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Dropdownlist3 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhoangLui As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKienTrucKhuVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVanDeKhac2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDuongDuPhongNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhoangLuiNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKienTrucKhuVucNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtViTriQuyHoach As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDuongDuPhong As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkViTriQuiHoach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLoGioi As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkLoGioi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLoGioiNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtViTriQuyHoachNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVanDeKhacNhanXet2 As System.Web.UI.WebControls.TextBox

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
            Init_State()
        End Sub
        Private Sub Init_State()
            Dim strURL As String
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMVITRIQUIHOACH&TextName=" & txtViTriQuyHoach.ClientID
            LinkViTriQuiHoach.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMLOGIOI&TextName=" & txtLoGioi.ClientID
            LinkLoGioi.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
        End Sub
    End Class
End Namespace