Imports PortalQH
Namespace CPXD
    Public Class NXHS_PhapLy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtMoiTruong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtYkienUBND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHienTrang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhongChayChuaChay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaySuDungDatNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhongChayChuaChayNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMoiTruongNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayChuQuyenNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayChuQuyenNhaNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKienTruc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhacPhapLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtViTriDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKienTrucNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtYKienUBNDNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHienTrangNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtViTriDatNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaySuDungDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkGiaySuDungDat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlGiaySuDungDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhacPhapLyNhanXet As System.Web.UI.WebControls.TextBox

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
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMGIAYPHEPSUDUNGDAT&TextName=" & txtGiaySuDungDat.ClientID
            LinkGiaySuDungDat.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
        End Sub
    End Class
End Namespace