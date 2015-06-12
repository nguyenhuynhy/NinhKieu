Imports PortalQH
Imports System.Configuration
Namespace LICHCONGTAC
    Public Class Admin_ListChucNang
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.ImageButton

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
                Init_State()
            End If
            BindGrid()
        End Sub
        Private Sub BindGrid()
            Dim objcon As New DanhSachChucNangController
            Dim ds As DataSet
            Dim strURL As String
            strURL = EditURL("ID", "value", "EditChucNang")
            ds = objcon.ChucNang_List(ConfigurationSettings.AppSettings("db_web").ToString(), strURL)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "", "0,800", False, True)
            objcon = Nothing
            ds = Nothing
        End Sub
        Private Sub Init_State()
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub
        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                BindGrid()
            End If
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL("ID", "", "EditChucNang"))
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnXoa.Click
            Dim i As Integer
            Dim chkXoa As CheckBox
            Dim objcon As New DanhSachChucNangController
            For i = 0 To dgdDanhSach.Items.Count - 1
                chkXoa = CType(Me.dgdDanhSach.Items(i).FindControl("chkXoa"), CheckBox)
                If chkXoa.Checked Then
                    objcon.ChucNang_Del(ConfigurationSettings.AppSettings("db_web").ToString(), CType(Me.dgdDanhSach.Items(i).FindControl("morelink"), HyperLink).Text)
                End If
            Next
            BindGrid()
            objcon = Nothing
        End Sub
        
    End Class
End Namespace

