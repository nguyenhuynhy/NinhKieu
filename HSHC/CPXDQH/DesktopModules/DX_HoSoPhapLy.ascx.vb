Imports PortalQH
Namespace CPXD
    Public Class DX_HoSoPhapLy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents LinkGiaySuDungDat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHSPL_DienTichKhuonVienHienHuu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHSPL_DienTichKhuonVienHienHuuTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHSPL_DienTichChenhLech As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHSPL_LyDoChenhLech As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_GiaySuDungDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHSPL_DienTichKhuonVienGhiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents LnkChenhLech As System.Web.UI.WebControls.LinkButton

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
            If Not IsPostBack Then
                Dim strURL As String
                strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMGIAYPHEPSUDUNGDAT&TextName=" & txtGP_GiaySuDungDat.ClientID
                LinkGiaySuDungDat.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
                txtHSPL_DienTichKhuonVienHienHuu.Attributes.Add("onblur", "javascript:TinhChenhLech(" & txtHSPL_DienTichKhuonVienGhiNhan.ClientID & "," & txtHSPL_DienTichKhuonVienHienHuu.ClientID & "," & txtHSPL_DienTichChenhLech.ClientID & ");" & "CheckData(" & txtHSPL_DienTichKhuonVienHienHuu.ClientID & ");")
                txtHSPL_DienTichKhuonVienHienHuuTru.Attributes.Add("onblur", "javascript:TinhDienTichSan();" & "CheckData(" & txtHSPL_DienTichKhuonVienHienHuuTru.ClientID & ");")
                strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMLYDOCHENHLECH&TextName=" & txtHSPL_LyDoChenhLech.ClientID
                LnkChenhLech.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
                ' txtHSPL_DienTichKhuonVienGhiNhan.Attributes.Add("onblur", "javascript:CheckData(" & txtHSPL_DienTichKhuonVienGhiNhan.ClientID & ");")
                txtHSPL_DienTichChenhLech.Attributes.Add("onblur", "javascript:CheckData(" & txtHSPL_DienTichChenhLech.ClientID & ");")
            End If
        End Sub

    End Class
End Namespace