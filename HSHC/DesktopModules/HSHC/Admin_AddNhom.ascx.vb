Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class Admin_AddNhom
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTenNhom As System.Web.UI.WebControls.TextBox
        Protected WithEvents rblChutri As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cklThanhvien As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents txtThanhVien As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNhom As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtStt As System.Web.UI.WebControls.TextBox

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
            txtStt.Attributes.Add("onblur", "javascript:isNumeric(" & txtStt.ClientID & ",'0');")
            If Not Page.IsPostBack Then
                InitState()
                InitGrid()
                SetCheckGrid()
            End If
        End Sub
        Sub InitState()
            Dim objcon As New DanhSachNhomController
            Dim ds As DataSet
            Dim ID As String
            If Not Request.Params("ID") Is Nothing Then
                ID = Request.Params("ID")
            End If
            ds = objcon.Nhom_Get(ConfigurationSettings.AppSettings("db_web").ToString(), ID)
            gLoadControlValues(ds, Me)
            objcon = Nothing
            ds = Nothing
        End Sub
        Sub InitGrid()
            Dim objcon As New DanhSachNhomController
            BindControl.BindCheckBoxList(cklThanhvien, ConfigurationSettings.AppSettings("db_web").ToString() & "..Web_LstUser", "", ConfigurationSettings.AppSettings("db_common").ToString())
            objcon = Nothing
        End Sub
        Sub SetCheckGrid()
            Dim i As Integer
            For i = 0 To cklThanhvien.Items.Count - 1
                If InStr(1, txtThanhVien.Text, cklThanhvien.Items(i).Value) > 0 Then
                    cklThanhvien.Items(i).Selected = True
                End If
            Next
        End Sub
        Private Function GetThanhVien() As String
            Dim i As Integer
            Dim strThanhvien As String
            For i = 0 To cklThanhvien.Items.Count - 1
                If cklThanhvien.Items(i).Selected = True Then
                    strThanhvien = strThanhvien & cklThanhvien.Items(i).Value & ";"
                End If
            Next
            Return Left(strThanhvien, strThanhvien.Length() - 1)
        End Function
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objcon As New DanhSachNhomController
            Dim ds As DataSet
            Dim ID As String
            If txtMaNhom.Text = "" Then 'insert
                ds = objcon.Nhom_GetCodeID(ConfigurationSettings.AppSettings("db_web").ToString(), "GP")
                ID = CType(ds.Tables(0).Rows(0).Item("CodeID"), String)
                objcon.Nhom_Insert(ConfigurationSettings.AppSettings("db_web").ToString(), ID, txtTenNhom.Text, GetThanhVien(), rblChutri.SelectedValue, txtStt.Text)
            Else 'cap nhat
                objcon.Nhom_Update(ConfigurationSettings.AppSettings("db_web").ToString(), txtMaNhom.Text, txtTenNhom.Text, GetThanhVien(), rblChutri.SelectedValue, txtStt.Text)
            End If
            Response.Redirect(NavigateURL())
            objcon = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
    End Class
End Namespace

