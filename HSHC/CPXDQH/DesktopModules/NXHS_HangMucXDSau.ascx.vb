Imports PortalQH
Namespace CPXD
    Public Class NXHS_HangMucXDSau
        Inherits PortalQH.PortalModuleControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtHangMucSau As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkChonHangMucSau As System.Web.UI.WebControls.LinkButton

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
            Dim strURL As String
            strURL = "CPXD/DesktopModules/DanhMuc_ChonHangMucSau.aspx?DanhMuc=DMNOIDUNGHANGMUCGOIY&TextName=" & txtHangMucSau.ClientID
            LinkChonHangMucSau.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
        End Sub

      
    End Class
End Namespace