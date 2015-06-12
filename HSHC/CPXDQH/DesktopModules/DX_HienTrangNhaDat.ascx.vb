Imports PortalQH
Namespace CPXD
    Public Class DX_HienTrangNhaDat
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtHTND_KienTrucKeCan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHTND_Tuong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHTND_Dien As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHTND_Nuoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkKetCau As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHTND_Noidung As System.Web.UI.WebControls.TextBox
        Protected WithEvents LnkDien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents LnkNuoc As System.Web.UI.WebControls.LinkButton
        Protected WithEvents LnkTuong As System.Web.UI.WebControls.LinkButton

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
                strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=HIENTRANGNHADAT&TextName=" & txtHTND_Noidung.ClientID
                LinkKetCau.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
                strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMDIEN&TextName=" & txtHTND_Dien.ClientID
                LnkDien.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
                strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMNUOC&TextName=" & txtHTND_Nuoc.ClientID
                LnkNuoc.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
                strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMTUONG&TextName=" & txtHTND_Tuong.ClientID
                LnkTuong.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            End If
        End Sub

    End Class
End Namespace