Namespace PortalQH
    Public Class DinhNghiaLoaiHoSo_KemTheo
        Inherits PortalQH.PortalModuleControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Private Shared strLinhVuc As String
        Private Shared strLoaiHoSo As String
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblHoSoKemTheo As System.Web.UI.WebControls.Label
        Protected WithEvents lstHoSoKemTheo As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList

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
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", , , 1)
                strLinhVuc = ddlMaLinhVuc.SelectedValue
                BindControl.BindDropDownList(ddlLoaiHoSo, "sp_GetDMLoaiHoSo", "", strLinhVuc, "")
                strLoaiHoSo = ddlLoaiHoSo.SelectedValue
                BindControl.BindCheckBoxList(lstHoSoKemTheo, "sp_GetHoSoKemTheoByMaLinhVuc", "", ddlMaLinhVuc.SelectedValue)
                LoadHoSoKemTheo(strLinhVuc, strLoaiHoSo)
            End If

        End Sub
        Private Sub LoadHoSoKemTheo(ByVal strLinhVuc As String, ByVal strLoaiHoSo As String)
            If lstHoSoKemTheo.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer
            Dim ds As New DataSet
            Dim objHoSo As New DinhNghiaLoaiHoSo_KemTheoController
            ds = objHoSo.GetLoaiHoSoHoSoKemTheo(strLinhVuc, strLoaiHoSo)

            For j = 0 To lstHoSoKemTheo.Items.Count - 1
                lstHoSoKemTheo.Items(j).Selected = False
            Next

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstHoSoKemTheo.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstHoSoKemTheo.Items(j).Value, String) Then
                        lstHoSoKemTheo.Items(j).Selected = True
                    End If
                Next
            Next
        End Sub

        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            strLinhVuc = ddlMaLinhVuc.SelectedValue
            BindControl.BindDropDownList(ddlLoaiHoSo, "sp_GetDMLoaiHoSo", "", strLinhVuc, "")
            strLoaiHoSo = ddlLoaiHoSo.SelectedValue
            BindControl.BindCheckBoxList(lstHoSoKemTheo, "sp_GetHoSoKemTheoByMaLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadHoSoKemTheo(strLinhVuc, strLoaiHoSo)
        End Sub

        Private Sub ddlLoaiHoSo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLoaiHoSo.SelectedIndexChanged
            strLoaiHoSo = ddlLoaiHoSo.SelectedValue
            BindControl.BindCheckBoxList(lstHoSoKemTheo, "sp_GetHoSoKemTheoByMaLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadHoSoKemTheo(strLinhVuc, strLoaiHoSo)
        End Sub

      
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim j As Integer
            Dim objHoSo As New DinhNghiaLoaiHoSo_KemTheoController
            Dim strHoSoKemTheo As String
            objHoSo.DelLoaiHoSoHoSoKemTheo(strLinhVuc, strLoaiHoSo)
            For j = 0 To lstHoSoKemTheo.Items.Count - 1
                If lstHoSoKemTheo.Items(j).Selected Then
                    strHoSoKemTheo = lstHoSoKemTheo.Items(j).Value
                    objHoSo.AddLoaiHoSoHoSoKemTheo(strLinhVuc, strLoaiHoSo, strHoSoKemTheo)
                End If
            Next
        End Sub
    End Class

End Namespace

