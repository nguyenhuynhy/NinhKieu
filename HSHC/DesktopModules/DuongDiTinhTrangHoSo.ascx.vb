
Namespace PortalQH
    Public Class DuongDiTinhTrangHoSo
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaTinhTrangCurr As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents lstMaTinhTrangNext As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDuongDiTinhTrang As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblDuongDiTinhTrang As System.Web.UI.WebControls.Label
        Private Shared TinhTrangCurr As String

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
                BindControl.BindCheckBoxList(lstMaTinhTrangNext, "sp_GetDMTinhTrangHoSoByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, CType(Session.Item("ActiveDB"), String))

                TabCode = ddlTabCode.SelectedValue
                TinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
                BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetDMTinhTrangHoSoByLinhVuc", TinhTrangCurr, ddlMaLinhVuc.SelectedValue)
                LoadGrid()
            End If
        End Sub
        Private Sub LoadTinhTrangKe()
            If lstMaTinhTrangNext.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer

            Dim ds As New DataSet
            Dim objDuongDiTinhTrangInfo As New DuongDiTinhTrangInfo
            Dim objDuongDiTinhTrang As New DuongDiTinhTrangController
            objDuongDiTinhTrangInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objDuongDiTinhTrangInfo.TabCode = ddlTabCode.SelectedValue
            objDuongDiTinhTrangInfo.MaTinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
            ds = objDuongDiTinhTrang.GetDuongDiTinhTrangNext(objDuongDiTinhTrangInfo)

            For j = 0 To lstMaTinhTrangNext.Items.Count - 1
                lstMaTinhTrangNext.Items(j).Selected = False
            Next

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstMaTinhTrangNext.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstMaTinhTrangNext.Items(j).Value, String) Then
                        lstMaTinhTrangNext.Items(j).Selected = True
                    End If

                Next

            Next
        End Sub
        
        Private Sub CapNhatDuongDiTinhTrang()
            Dim j As Integer
            Dim objDuongDiTinhTrangInfo As DuongDiTinhTrangInfo
            Dim objDuongDiTinhTrang As DuongDiTinhTrangController
            objDuongDiTinhTrangInfo = New DuongDiTinhTrangInfo
            objDuongDiTinhTrang = New DuongDiTinhTrangController
            objDuongDiTinhTrangInfo.TabCode = ddlTabCode.SelectedValue
            objDuongDiTinhTrangInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objDuongDiTinhTrangInfo.MaTinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
            objDuongDiTinhTrang.DelDuongDiTinhTrang(objDuongDiTinhTrangInfo)
            For j = 0 To lstMaTinhTrangNext.Items.Count - 1
                If lstMaTinhTrangNext.Items(j).Selected Then
                    objDuongDiTinhTrangInfo.TabCode = ddlTabCode.SelectedValue
                    objDuongDiTinhTrangInfo.ItemCode = "1"
                    objDuongDiTinhTrangInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
                    objDuongDiTinhTrangInfo.MaTinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
                    objDuongDiTinhTrangInfo.MaTinhTrangNext = lstMaTinhTrangNext.Items(j).Value
                    objDuongDiTinhTrang.AddDuongDiTinhTrang(objDuongDiTinhTrangInfo)
                End If
            Next
        End Sub



        Private Sub ddlMaTinhTrangCurr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaTinhTrangCurr.SelectedIndexChanged
            LoadTinhTrangKe()
            LoadGrid()
        End Sub

        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            TinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetDMTinhTrangHoSoByLinhVuc", TinhTrangCurr, ddlMaLinhVuc.SelectedValue)
            BindControl.BindCheckBoxList(lstMaTinhTrangNext, "sp_GetDMTinhTrangHoSoByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadTinhTrangKe()
            LoadGrid()
        End Sub

        Private Sub ddlTabCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTabCode.SelectedIndexChanged
            TinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetDMTinhTrangHoSoByLinhVuc", TinhTrangCurr, ddlMaLinhVuc.SelectedValue)
            BindControl.BindCheckBoxList(lstMaTinhTrangNext, "sp_GetDMTinhTrangHoSoByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadTinhTrangKe()
            LoadGrid()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            CapNhatDuongDiTinhTrang()
            LoadTinhTrangKe()
            LoadGrid()
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetDMTinhTrangHoSoByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            BindControl.BindCheckBoxList(lstMaTinhTrangNext, "sp_GetDMTinhTrangHoSoByLinhVuc", "", ddlMaLinhVuc.SelectedValue)
            LoadTinhTrangKe()
            LoadGrid()
        End Sub
        
        Public Sub LoadGrid()
            Dim objDuongDiTinhTrangController As New DuongDiTinhTrangController
            Dim ds As New DataSet
            ds = objDuongDiTinhTrangController.GetDuongDiTinhTrang(ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindGrdHoSo(ds, dgdDuongDiTinhTrang, False, "", "500,500,500", False, False)
        End Sub
    End Class
End Namespace