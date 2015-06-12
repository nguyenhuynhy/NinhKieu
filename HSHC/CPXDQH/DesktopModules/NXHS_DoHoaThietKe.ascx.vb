Imports PortalQH
Namespace CPXD
    Public Class NXHS_DoHoaThietKe
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtDienTichDangSuDungNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichKhuonVienXayDungNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQuyenSuDungDatNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatDoXayDungNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongDienTichSanXayDungNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCachTimDuongThietKeNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongTrinhKeCanNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhacThietKeNhanXet1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhacThietKeNhanXet2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichDangSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichKhuonVienXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQuyenSuDungDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQuyenSuDungDatChuaCo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatDoXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongDienTichSanXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCachTimDuongThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongTrinhKeCan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDien As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoatNuoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents TxtC As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKhacThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents TxtCapNuoc As System.Web.UI.WebControls.TextBox

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
            txtDienTichDangSuDung.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtDienTichDangSuDung.ClientID & ",'0');")
            txtDienTichKhuonVienXayDung.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtDienTichKhuonVienXayDung.ClientID & ",'0');")
            txtQuyenSuDungDat.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtQuyenSuDungDat.ClientID & ",'0');")
            txtQuyenSuDungDatChuaCo.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtQuyenSuDungDatChuaCo.ClientID & ",'0');")
            txtMatDoXayDung.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtMatDoXayDung.ClientID & ",'0');")
            txtTongDienTichSanXayDung.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtTongDienTichSanXayDung.ClientID & ");")
            txtCachTimDuongThietKe.Attributes.Add("onblur", "javascript:CheckDataInNeg(" & txtCachTimDuongThietKe.ClientID & ");")
            txtDienTichDangSuDung.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDienTichKhuonVienXayDung.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtQuyenSuDungDat.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtQuyenSuDungDatChuaCo.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtMatDoXayDung.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtCachTimDuongThietKe.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTongDienTichSanXayDung.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
        End Sub
    End Class
End Namespace