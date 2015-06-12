Namespace PortalQH
    Public Class TinhTrangXuLyHoSo
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String
        Private Shared TinhTrangHoSo As String
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaTinhTrangHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lstMaTinhTrangXuLy As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhsach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList



#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


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
                BindControl.BindCheckBoxList(lstMaTinhTrangXuLy, "sp_GetDMTinhTrangXuLyByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, CType(Session.Item("ActiveDB"), String))
                BindControl.BindDropDownList(ddlMaTinhTrangHoSo, "sp_GetDanhSachTinhTrangHoSoByTabCode", "", ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            End If
            TabCode = ddlTabCode.SelectedValue

            TinhTrangHoSo = ddlMaTinhTrangHoSo.SelectedValue
            'BindControl.BindDropDownList(ddlMaTinhTrangHoSo, "sp_GetDMTinhTrangHoSoByLinhVuc", TinhTrangHoSo, ddlMaLinhVuc.SelectedValue)

            LoadGrid()
        End Sub
        Private Sub LoadTinhTrangXuLy()
            If lstMaTinhTrangXuLy.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer

            Dim ds As New DataSet
            Dim objTinhTrangXuLyHoSoInfo As New TinhTrangXuLyHoSoInfo
            Dim objTinhTrangXuLyHoSo As New TinhTrangXuLyHoSoController
            objTinhTrangXuLyHoSoInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objTinhTrangXuLyHoSoInfo.TabCode = ddlTabCode.SelectedValue
            objTinhTrangXuLyHoSoInfo.MaTinhTrangHoSo = ddlMaTinhTrangHoSo.SelectedValue
            ds = objTinhTrangXuLyHoSo.GetTinhTrangXuLy(objTinhTrangXuLyHoSoInfo)

            For j = 0 To lstMaTinhTrangXuLy.Items.Count - 1
                lstMaTinhTrangXuLy.Items(j).Selected = False
            Next

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstMaTinhTrangXuLy.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstMaTinhTrangXuLy.Items(j).Value, String) Then
                        lstMaTinhTrangXuLy.Items(j).Selected = True
                    End If

                Next

            Next
        End Sub
        Private Sub CapNhatTinhTrangXuLyHoSo()
            Dim j As Integer
            Dim objTinhTrangXuLyHoSoInfo As TinhTrangXuLyHoSoInfo
            Dim objTinhTrangXuLyHoSo As TinhTrangXuLyHoSoController
            objTinhTrangXuLyHoSoInfo = New TinhTrangXuLyHoSoInfo
            objTinhTrangXuLyHoSo = New TinhTrangXuLyHoSoController
            objTinhTrangXuLyHoSoInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objTinhTrangXuLyHoSoInfo.TabCode = ddlTabCode.SelectedValue
            objTinhTrangXuLyHoSoInfo.MaTinhTrangHoSo = ddlMaTinhTrangHoSo.SelectedValue
            objTinhTrangXuLyHoSo.DelTinhTrangXuLyHoSo(objTinhTrangXuLyHoSoInfo)
            For j = 0 To lstMaTinhTrangXuLy.Items.Count - 1
                If lstMaTinhTrangXuLy.Items(j).Selected Then
                    objTinhTrangXuLyHoSoInfo = New TinhTrangXuLyHoSoInfo
                    objTinhTrangXuLyHoSo = New TinhTrangXuLyHoSoController
                    objTinhTrangXuLyHoSoInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
                    objTinhTrangXuLyHoSoInfo.TabCode = ddlTabCode.SelectedValue
                    objTinhTrangXuLyHoSoInfo.MaTinhTrangHoSo = ddlMaTinhTrangHoSo.SelectedValue
                    objTinhTrangXuLyHoSoInfo.MaTinhTrangXuLy = lstMaTinhTrangXuLy.Items(j).Value
                    objTinhTrangXuLyHoSo.AddTinhTrangXuLyHoSo(objTinhTrangXuLyHoSoInfo)
                End If
            Next
        End Sub

        Private Sub ddlMaTinhTrangHoSo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaTinhTrangHoSo.SelectedIndexChanged
            LoadTinhTrangXuLy()
            LoadGrid()
        End Sub

        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            TinhTrangHoSo = ddlMaTinhTrangHoSo.SelectedValue
            'BindControl.BindDropDownList(ddlMaTinhTrangHoSo, "sp_GetDMTinhTrangHoSoByLinhVuc", TinhTrangHoSo, ddlMaLinhVuc.SelectedValue)
            BindControl.BindDropDownList(ddlMaTinhTrangHoSo, "sp_GetDanhSachTinhTrangHoSoByTabCode", "", ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindCheckBoxList(lstMaTinhTrangXuLy, "sp_GetDMTinhTrangXuLyByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadTinhTrangXuLy()
            LoadGrid()
        End Sub
        Private Sub ddlTabCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTabCode.SelectedIndexChanged
            TinhTrangHoSo = ddlMaTinhTrangHoSo.SelectedValue
            BindControl.BindDropDownList(ddlMaTinhTrangHoSo, "sp_GetDanhSachTinhTrangHoSoByTabCode", "", ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindCheckBoxList(lstMaTinhTrangXuLy, "sp_GetDMTinhTrangXuLyByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadTinhTrangXuLy()
            LoadGrid()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            CapNhatTinhTrangXuLyHoSo()
            LoadTinhTrangXuLy()
            LoadGrid()
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            BindControl.BindDropDownList(ddlMaTinhTrangHoSo, "sp_GetDanhSachTinhTrangHoSoByTabCode", "", ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindCheckBoxList(lstMaTinhTrangXuLy, "sp_GetDMTinhTrangXuLyByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadTinhTrangXuLy()
            LoadGrid()
        End Sub
        Public Sub LoadGrid()
            Dim objTinhTrangXuLy As New TinhTrangXuLyHoSoController
            Dim ds As New DataSet
            ds = objTinhTrangXuLy.GetTinhTrangXuLyByTinhTrangHoSo(ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindGrdHoSo(ds, dgdDanhsach, False, "", "500,500,500", False, False, True)
        End Sub
    End Class


End Namespace