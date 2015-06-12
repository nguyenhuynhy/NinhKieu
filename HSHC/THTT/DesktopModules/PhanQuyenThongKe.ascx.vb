Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class PhanQuyenThongKe
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtMaUser As System.Web.UI.WebControls.TextBox
        Protected WithEvents cklUser As System.Web.UI.WebControls.CheckBoxList

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
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, "", CType(ConfigurationSettings.AppSettings("commonDB"), String) & "..sp_getDanhMucLV", CType(ConfigurationSettings.AppSettings("TabHSHC"), String))
                InitState()
                InitGrid()
                SetCheckGrid()
            End If
        End Sub

        Sub InitState()
            Dim objcon As New PhanQuyenThongKeController
            Dim ds As DataSet
            Dim ID As String
            Dim TabCode As String

            ID = ddlLinhVuc.SelectedValue

            ds = objcon.Get_LinhVuc(ConfigurationSettings.AppSettings("commonDB").ToString(), ID, CType(ConfigurationSettings.AppSettings("TabHSHC"), String))
            gLoadControlValues(ds, Me)
            objcon = Nothing
            ds = Nothing
        End Sub

        Sub InitGrid()
            BindControl.BindCheckBoxList(cklUser, ConfigurationSettings.AppSettings("commonDB").ToString() & "..LstUser", "", ConfigurationSettings.AppSettings("commonDB").ToString())
        End Sub

        Sub SetCheckGrid()
            Dim i As Integer
            For i = 0 To cklUser.Items.Count - 1
                If InStr(1, txtMaUser.Text, cklUser.Items(i).Value) > 0 Then
                    cklUser.Items(i).Selected = True
                Else
                    cklUser.Items(i).Selected = False
                End If
            Next
        End Sub

        Private Function GetThanhVien() As String
            Dim i As Integer
            Dim strThanhvien As String = ""

            For i = 0 To cklUser.Items.Count - 1
                If cklUser.Items(i).Selected = True Then
                    strThanhvien = strThanhvien & cklUser.Items(i).Value & ";"
                End If
            Next
            If strThanhvien <> "" Then
                Return Left(strThanhvien, strThanhvien.Length() - 1)
            Else
                Return ""
            End If
        End Function

        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            InitState()
            SetCheckGrid()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objcon As New PhanQuyenThongKeController
            Dim ds As DataSet
            Dim ID As String

            objcon.LV_Update(ConfigurationSettings.AppSettings("commonDB").ToString(), ddlLinhVuc.SelectedValue, CType(ConfigurationSettings.AppSettings("TabHSHC"), String), GetThanhVien())

            objcon = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
    End Class
End Namespace

