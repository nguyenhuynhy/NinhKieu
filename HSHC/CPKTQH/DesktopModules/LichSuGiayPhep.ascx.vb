Imports PortalQH
Imports System.Configuration
Namespace CPKTQH

    Public Class LichSuGiayPhep
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents btnInBanSao As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgungKinhDoanhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdLichSu As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton

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
            If Not Page.IsPostBack Then
                If Request.Params("ID") Is Nothing Then
                    btnTroVe_Click(Nothing, Nothing)
                End If
                LoadGrid()
            End If
        End Sub

        Private Sub LoadGrid()
            Dim strLoaiHoSo, strURL As String
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_LichSuGiayPhep")
            BindControl.BindGrdHoSo(ds, dgdLichSu, False, "", "150,200,200,150,150", False, False)


        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(EditURL("ID", Request.Params("ID")))
        End Sub
    End Class
End Namespace

