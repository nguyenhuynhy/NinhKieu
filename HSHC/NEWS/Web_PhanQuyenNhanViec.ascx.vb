Imports System.Configuration
Namespace PortalQH
    Public Class Web_PhanQuyenNhanViec
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents cklUser As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtMaUser As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlNguoiGiao As System.Web.UI.WebControls.DropDownList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Protected userIDNhanViec As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                InitState()
                InitGrid()
                SetCheckGrid()
            End If
        End Sub

        Sub InitState()
            BindControl.BindDropDownList_StoreProc(ddlNguoiGiao, False, "", ConfigurationSettings.AppSettings("db_web").ToString() & "..sp_CV_getDSNguoiGiaoViec", ConfigurationSettings.AppSettings("commonDB").ToString())
            ddlNguoiGiao.SelectedIndex = 0
        End Sub

        Sub InitGrid()
            BindControl.BindCheckBoxList(cklUser, ConfigurationSettings.AppSettings("db_web").ToString() & "..sp_CV_getNhanViecByID", "", ConfigurationSettings.AppSettings("commonDB").ToString(), ddlNguoiGiao.SelectedItem.Value)
        End Sub

        Sub SetCheckGrid()
            Dim objcon As New LanhDaoController
            Dim ds As DataSet
            Dim i As Integer = 0
            Dim j As Integer = 0
            ds = objcon.getDSNguoiNhanViec(ConfigurationSettings.AppSettings("db_web").ToString(), ConfigurationSettings.AppSettings("commonDB").ToString(), ddlNguoiGiao.SelectedItem.Value)
            For i = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                While Not (cklUser.Items(j).Value().CompareTo(ds.Tables(0).Rows(i)(0).ToString()) = 0)
                    j = j + 1
                End While
                cklUser.Items(j).Selected = True
                j = j + 1
            Next
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objcon As New LanhDaoController
            Dim ID As String

            objcon.delToanBoNguoiNhanViec(ConfigurationSettings.AppSettings("db_web"), ddlNguoiGiao.SelectedItem.Value)

            Dim i As Integer
            For i = 0 To cklUser.Items.Count - 1 Step 1
                If cklUser.Items(i).Selected Then
                    objcon.insNguoiNhanViec(ConfigurationSettings.AppSettings("db_web"), ddlNguoiGiao.SelectedItem.Value, cklUser.Items(i).Value())
                End If
            Next
            objcon = Nothing
        End Sub


        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub ddlNguoiGiao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlNguoiGiao.SelectedIndexChanged
            InitGrid()
            SetCheckGrid()
        End Sub
    End Class
End Namespace