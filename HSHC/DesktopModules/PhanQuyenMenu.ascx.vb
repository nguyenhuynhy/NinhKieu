Namespace PortalQH
    Public Class PhanQuyenMenu
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lstMaChucNang As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim iSelectItemCode As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not IsPostBack Then
                Init_State()
            End If
            tblHeader.Visible = False
        End Sub
        Private Sub Init_State()
            Dim iPortalID As Int32
            iPortalID = CType(DataCache.GetCache("PortalID"), Int32)
            BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", , False, 1)
            BindControl.BindCheckBoxList(lstMaChucNang, "sp_GetMenuTabListByLinhVuc", "", ctype(Session.Item("ActiveDB"),string))
            LoadDanhSachChucNang()
        End Sub
        Private Sub LoadDanhSachChucNang()
            Dim ds As New DataSet
            Dim objPQMenuController As New PhanQuyenMenuController
            ds = objPQMenuController.LstMenu(ddlMaLinhVuc.SelectedValue)
            Dim i, j As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                j = 0
                For j = 0 To lstMaChucNang.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(1), String) = lstMaChucNang.Items(j).Value Then
                        lstMaChucNang.Items(j).Selected = True
                    End If
                Next
            Next
        End Sub
        

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objPQMenuInfo As New PhanQuyenMenuInfo
            Dim objPQMenuController As New PhanQuyenMenuController
            Dim i As Integer
            objPQMenuController.DelMenu(ddlMaLinhVuc.SelectedValue)
            For i = 0 To lstMaChucNang.Items.Count - 1
                If lstMaChucNang.Items(i).Selected Then
                    objPQMenuInfo.TabCode = CType(lstMaChucNang.Items(i).Value, Integer)
                    objPQMenuInfo.ItemName = lstMaChucNang.Items(i).Text
                    objPQMenuInfo.ItemCode = ddlMaLinhVuc.SelectedValue
                    objPQMenuInfo.IsCheckUser = 1
                    objPQMenuController.AddMenu(objPQMenuInfo)
                End If
            Next
        End Sub
    End Class
End Namespace