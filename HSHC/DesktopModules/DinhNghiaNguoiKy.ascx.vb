Namespace PortalQH
    Public Class DinhNghiaNguoiKy
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String
        Private Shared Loai As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lstNguoiSuDung As System.Web.UI.WebControls.CheckBoxList


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
                BindControl.BindCheckBoxList(lstNguoiSuDung, "sp_GetDanhMucCBO", "", GetCommonDB, "DMNGUOISUDUNG")
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, CType(Session.Item("ActiveDB"), String))
            End If
            TabCode = ddlTabCode.SelectedValue

        End Sub
        Private Sub LoadNguoiKy()
            If lstNguoiSuDung.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer

            Dim ds As New DataSet
            Dim objNguoiKyInfo As New NguoiKyInfo
            Dim objNguoiKy As New NguoiKyController
            objNguoiKyInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objNguoiKyInfo.TabCode = ddlTabCode.SelectedValue
            ds = objNguoiKy.GetNguoiKy(objNguoiKyInfo)

            For j = 0 To lstNguoiSuDung.Items.Count - 1
                lstNguoiSuDung.Items(j).Selected = False
            Next

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstNguoiSuDung.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstNguoiSuDung.Items(j).Value, String) Then
                        lstNguoiSuDung.Items(j).Selected = True
                    End If

                Next
            Next
        End Sub
        Private Sub CapNhatNguoiKy()
            Dim j As Integer
            Dim objNguoiKyInfo As NguoiKyInfo
            Dim objNguoiKy As NguoiKyController
            objNguoiKyInfo = New NguoiKyInfo
            objNguoiKy = New NguoiKyController
            objNguoiKyInfo.TabCode = ddlTabCode.SelectedValue
            objNguoiKyInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            For j = 0 To lstNguoiSuDung.Items.Count - 1
                objNguoiKyInfo.UserName = lstNguoiSuDung.Items(j).Value
                If lstNguoiSuDung.Items(j).Selected Then
                    objNguoiKyInfo.ItemCode = "1"
                    objNguoiKy.AddNguoiKy(objNguoiKyInfo)
                Else
                    objNguoiKy.DelNguoiKy(objNguoiKyInfo)
                End If
            Next
        End Sub

        Private Sub ddlTabCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTabCode.SelectedIndexChanged
            LoadNguoiKy()
        End Sub
        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            LoadNguoiKy()
        End Sub

        Private Sub chkNguoiChuyen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            LoadNguoiKy()
        End Sub

        Private Sub chkNguoiNhan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            LoadNguoiKy()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            CapNhatNguoiKy()
            LoadNguoiKy()
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            LoadNguoiKy()
        End Sub
    End Class
End Namespace