Imports PortalQH

Public Class DinhNghiaHanBaoCao
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtHanBaoCaoThang As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHanBaoCaoTuan As System.Web.UI.WebControls.TextBox

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
            Me.InitState()
        End If
    End Sub


    Private Sub InitState()
        Dim ds As DataSet

        ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_BCT_getHanBaoCao")

        gLoadControlValues(ds, Me)

        btnCapNhat.Attributes.Add("onClick", "return checkNgayHanBaoCao();")
    End Sub


    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click

        Dim strHanBaoCaoThang As Integer
        Dim strHanBaoCaoTuan As Integer

        strHanBaoCaoThang = CInt(txtHanBaoCaoThang.Text)
        strHanBaoCaoTuan = CInt(txtHanBaoCaoTuan.Text)

        DataProvider.Instance.ExecuteNonQueryStoreProc("sp_BCT_InsNgayHanBaoCao", strHanBaoCaoThang, strHanBaoCaoTuan)

        Response.Redirect(Request.RawUrl)
    End Sub
End Class
