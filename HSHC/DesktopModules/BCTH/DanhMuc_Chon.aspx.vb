Imports System.Configuration
Imports System.Xml
Imports PortalQH
Imports System.Net
Namespace HSHC
    Public Class DanhMuc_Chon
        Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lstDanhMuc As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtValue As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtDanhMuc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlMaCha As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
        Protected WithEvents Chon As System.Web.UI.WebControls.ImageButton
        Protected WithEvents ddlNhomChiTieu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMaCTCha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenCTCha As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnChon As System.Web.UI.WebControls.ImageButton

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
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList_StoreProc(ddlNhomChiTieu, True, "", ConfigurationSettings.AppSettings("db_bcth").ToString + "..sp_GetDMChiTieuByGroup")
            End If
            BindGrid()
            ddlNhomChiTieu.Attributes.Add("ISNULL", "NOTNULL")
            btnChon.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnTroVe.Attributes.Add("onclick", "javascript:window.close();")
            btnChon.Attributes.Add("onclick", "javascript:return form1_onsubmit();")

        End Sub
        Private Sub BindGrid()
            Dim objDMCT As New DanhMucChiTieuController
            Dim ds As DataSet
            ds = objDMCT.GetAllDMChiTieuByGroup(ConfigurationSettings.AppSettings("db_bcth"), ddlNhomChiTieu.SelectedValue)
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            AddAttributeCheckBox()
            objDMCT = Nothing
            ds = Nothing
        End Sub
        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub
        Private Sub AddAttributeCheckBox()
            Dim chk As CheckBox
            Dim i As Integer
            If dgdDanhSach.Items.Count = 0 Then Exit Sub
            For i = 0 To dgdDanhSach.Controls(0).Controls.Count - 1
                chk = CType(dgdDanhSach.Controls(0).Controls(i).FindControl("chkXoa"), CheckBox)
                If Not chk Is Nothing Then
                    chk.Attributes.Add("OnClick", "javascript: return select_deselect('" & chk.ClientID & "');")
                End If
            Next

        End Sub

    End Class
End Namespace