Namespace PortalQH
    Public Class TabLoaiHoSoMotCua
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.LinkButton
        Private Shared MaLoaiHoSo As String


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lstLoaiHoSo As System.Web.UI.WebControls.CheckBoxList

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
                BindControl.BindCheckBoxList(lstLoaiHoSo, "sp_GetDMLoaiHoSo", "", ddlMaLinhVuc.SelectedValue, "")
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, CType(Session.Item("ActiveDB"), String))
                LoadLoaiHoSo()
            End If
            TabCode = ddlTabCode.SelectedValue
        End Sub


        Private Sub CapNhatTabLoaiHoSo()
            Dim j As Integer
            Dim objLoaiHoSoInfo As New TabLoaiHoSoInfo
            Dim objLoaiHoSo As New TabLoaiHoSoController
            objLoaiHoSoInfo.TabCode = ddlTabCode.SelectedValue
            objLoaiHoSo.DelLoaiHoSo(objLoaiHoSoInfo)
            For j = 0 To lstLoaiHoSo.Items.Count - 1
                If lstLoaiHoSo.Items(j).Selected Then
                    objLoaiHoSoInfo = New TabLoaiHoSoInfo
                    objLoaiHoSo = New TabLoaiHoSoController
                    objLoaiHoSoInfo.MaLoaiHoSo = lstLoaiHoSo.Items(j).Value
                    objLoaiHoSoInfo.TabCode = ddlTabCode.SelectedValue
                    objLoaiHoSo.AddLoaiHoSo(objLoaiHoSoInfo)
                End If
            Next

        End Sub
        Private Sub LoadLoaiHoSo()
            If lstLoaiHoSo.Items.Count = 0 Then Exit Sub
            Dim j As Integer
            Dim i As Integer
            Dim objTabLoaiHoSoInfo As New TabLoaiHoSoInfo
            Dim objTabLoaiHoSo As New TabLoaiHoSoController
            Dim ds As New DataSet

            objTabLoaiHoSoInfo.TabCode = ddlTabCode.SelectedValue
            'ds = objTabLoaiHoSo.GetLoaiHoSo(objTabLoaiHoSoInfo)
            ds = objTabLoaiHoSo.GetLoaiHoSoByLinhVuc(objTabLoaiHoSoInfo, ddlMaLinhVuc.SelectedValue)
            For j = 0 To lstLoaiHoSo.Items.Count - 1
                lstLoaiHoSo.Items(j).Selected = False
            Next
            If Not ds Is Nothing Then
                For j = 0 To lstLoaiHoSo.Items.Count - 1
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        If Not ds.Tables(0).Rows(i).Item(0) Is Nothing Then
                            If CType(ds.Tables(0).Rows(i).Item(0).ToString(), String) = CType(lstLoaiHoSo.Items(j).Value, String) Then
                                lstLoaiHoSo.Items(j).Selected = True
                            End If
                        End If
                    Next
                Next
            End If
        End Sub

        Private Sub ddlTabCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTabCode.SelectedIndexChanged
            LoadLoaiHoSo()
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            CapNhatTabLoaiHoSo()
        End Sub

        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            BindControl.BindCheckBoxList(lstLoaiHoSo, "sp_GetDMLoaiHoSo", "", ddlMaLinhVuc.SelectedValue, "")
            LoadLoaiHoSo()
        End Sub
    End Class

End Namespace