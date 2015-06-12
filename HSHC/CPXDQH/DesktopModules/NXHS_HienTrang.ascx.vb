Imports PortalQH
Namespace CPXD
    Public Class NXHS_HienTrang
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtDienTichDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkKetCau As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoTang As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkSoTang As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtCachTimDuongNhaDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKienTrucKeCan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVanDeKhac As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtDienTichDatNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichXayDungNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetCauNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCachTimDuongNhaDatNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKienTrucKeCanNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVanDeKhacNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoTangNhanXet As System.Web.UI.WebControls.TextBox


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
            If Not IsPostBack() Then
                Init_State()
            End If
        End Sub
        Private Sub Init_State()
            Dim strURL As String
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMSOTANG&TextName=" & txtSoTang.ClientID
            LinkSoTang.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMKETCAU&TextName=" & txtKetCau.ClientID
            LinkKetCau.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            txtDienTichDat.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtDienTichDat.ClientID & ");")
            txtDienTichXayDung.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtDienTichXayDung.ClientID & ");")
            txtDienTichXayDung.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDienTichDat.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
        End Sub
    End Class
End Namespace