Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class Admin_AddLocation
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents txtLocationName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox

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
            If Not Page.IsPostBack Then
                InitState()
            End If
        End Sub
        Sub InitState()
            Dim objcon As New DanhSachDiaDiemHopController
            Dim ds As DataSet
            Dim ID As String
            If Not Request.Params("ID") Is Nothing Then
                ID = Request.Params("ID")
            End If
            ds = objcon.DiaDiem_Get(ConfigurationSettings.AppSettings("db_web").ToString(), ID)
            gLoadControlValues(ds, Me)
            objcon = Nothing
            ds = Nothing
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objcon As New DanhSachDiaDiemHopController
            If txtID.Text = "" Then 'insert
                objcon.DiaDiem_Insert(ConfigurationSettings.AppSettings("db_web").ToString(), txtLocationName.Text)
            Else 'cap nhat
                objcon.DiaDiem_Update(ConfigurationSettings.AppSettings("db_web").ToString(), txtID.Text, txtLocationName.Text)
            End If
            Response.Redirect(NavigateURL())
            objcon = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
    End Class

End Namespace
