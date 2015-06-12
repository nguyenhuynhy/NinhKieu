Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class Admin_AddChucNang
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtThanhVien As System.Web.UI.WebControls.TextBox
        Protected WithEvents cklVaiTro As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents txtSoThuTu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenTrang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenChucNang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaChucNang As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkPUB As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkIsShow As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlTuongDuong As System.Web.UI.WebControls.DropDownList

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
            txtSoThuTu.Attributes.Add("onblur", "javascript:isNumeric(" & txtSoThuTu.ClientID & ",'0');")
            If Not Page.IsPostBack Then
                BindControl.BindDropDownList(ddlTuongDuong, "DMTUONGDUONG")
                InitState()
                InitGrid()
                SetCheckGrid()
            End If
        End Sub
        Sub InitState()
            Dim objcon As New DanhSachChucNangController
            Dim ds As DataSet
            Dim ID As String
            If Not Request.Params("ID") Is Nothing Then
                ID = Request.Params("ID")
            End If
            ds = objcon.ChucNang_Get(ConfigurationSettings.AppSettings("db_web").ToString(), ID)
            gLoadControlValues(ds, Me)
            objcon = Nothing
            ds = Nothing
        End Sub
        Sub InitGrid()
            Dim objcon As New DanhSachChucNangController
            BindControl.BindCheckBoxList(cklVaiTro, ConfigurationSettings.AppSettings("db_web").ToString() & "..Web_LstDMROLE", "", ConfigurationSettings.AppSettings("db_common").ToString())
            objcon = Nothing
        End Sub
        Sub SetCheckGrid()
            Dim objcon As New DanhSachChucNangController
            Dim ds As DataSet
            Dim ID As String
            If Not Request.Params("ID") Is Nothing Then
                ID = Request.Params("ID").ToString()
            End If
            ds = objcon.ChucNang_ListPhanQuyen(ConfigurationSettings.AppSettings("db_web").ToString(), ID)
            Dim i As Integer
            Dim lst As ListItem
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i).Item("MaVaiTro").ToString() = "PUB" Then
                    chkPUB.Checked = True
                    Exit Sub
                End If
                lst = cklVaiTro.Items.FindByValue(ds.Tables(0).Rows(i).Item("MaVaiTro").ToString())
                If Not lst Is Nothing Then
                    lst.Selected = True
                End If
            Next

        End Sub

        Sub SaveGrid()
            Dim objcon As New DanhSachChucNangController
            Dim i As Integer
            objcon.ChucNang_DelPhanQuyen(ConfigurationSettings.AppSettings("db_web").ToString(), txtTenTrang.Text)
            If chkPUB.Checked Then
                objcon.ChucNang_InsertPhanQuyen(ConfigurationSettings.AppSettings("db_web").ToString(), txtTenTrang.Text, "PUB")
            Else
                For i = 0 To cklVaiTro.Items.Count - 1
                    If cklVaiTro.Items(i).Selected = True Then
                        objcon.ChucNang_InsertPhanQuyen(ConfigurationSettings.AppSettings("db_web").ToString(), txtTenTrang.Text, cklVaiTro.Items(i).Value)
                    End If
                Next
            End If
            
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objcon As New DanhSachChucNangController
            Dim ds As DataSet
            Dim IsShow As String
            If chkIsShow.Checked Then
                IsShow = "1"
            Else
                IsShow = "0"
            End If
            If txtMaChucNang.Text = "" Then 'insert
                objcon.ChucNang_Insert(ConfigurationSettings.AppSettings("db_web").ToString(), txtMaChucNang.Text, txtTenChucNang.Text, txtTenTrang.Text, txtSoThuTu.Text, ddlTuongDuong.SelectedValue, IsShow)
                SaveGrid()
            Else 'cap nhat
                objcon.ChucNang_Update(ConfigurationSettings.AppSettings("db_web").ToString(), txtMaChucNang.Text, txtTenChucNang.Text, txtTenTrang.Text, txtSoThuTu.Text, ddlTuongDuong.SelectedValue, IsShow)
                SaveGrid()
            End If
            Response.Redirect(NavigateURL())
            objcon = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
    End Class

End Namespace
