Imports PORTALQH
Namespace CPKTQH
    Public Class DinhNghiaLuongHoSo
        Inherits PortalQH.PortalModuleControl

        Private Const COL_DUONGDITINHTRANGID As Integer = 1
        Private Const COL_TABNAME As Integer = 2
        Private Const COL_QUITRINH As Integer = 3
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaTinhTrangCurr As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lstMaTinhTrangNext As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaTinhTrangNext As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtDuongDiTinhTrangID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlItemCode As System.Web.UI.WebControls.DropDownList

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
            Try
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", , , 1)
                    viewstate("MaLinhVuc") = ddlMaLinhVuc.SelectedValue

                    BindData()
                    LoadGrid()
                    lblHeader.Text = ".:: " & Me.PortalSettings.ActiveTab.TabName & " ::."
                    If Request.Params("ID") Is Nothing Then
                        lblTieuDe.Text = UCase("Thêm mới đường đi tình trạng")
                    Else
                        GetDuongDiTinhTrang(Request.Params("ID"))
                    End If
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub

        Private Sub SetAttributesControl()
            ddlTabCode.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaTinhTrangCurr.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaTinhTrangNext.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub BindData()
            BindControl.BindDropDownList_StoreProc(ddlTabCode, True, "", "sp_GetMenuTabListByLinhVuc", CType(Session.Item("ActiveDB"), String))
            BindControl.BindDropDownList_StoreProc(ddlItemCode, True, "", "sp_getLoaiDuongDiTinhTrang", viewstate("MaLinhVuc"))
            BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangCurr, True, "", "sp_GetDMTinhTrangHoSoByLinhVuc", viewstate("MaLinhVuc"))
            BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangNext, True, "", "sp_GetDMTinhTrangHoSoByLinhVuc", viewstate("MaLinhVuc"))
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objDuongDiTinhTrang As New DuongDiTinhTrangController
            ds = objDuongDiTinhTrang.getDanhSachDuongDiTinhTrang(ddlMaLinhVuc.SelectedValue)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dgdDanhSach.DataSource = ds
                    dgdDanhSach.DataBind()
                End If
            End If
            ds = Nothing
            objDuongDiTinhTrang = Nothing
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            ddlMaLinhVuc.Enabled = True
            ddlTabCode.Enabled = True
            ddlTabCode.SelectedValue = ""
            ddlItemCode.SelectedValue = ""
            ddlMaTinhTrangCurr.SelectedValue = ""
            ddlMaTinhTrangNext.SelectedValue = ""
            txtDuongDiTinhTrangID.Text = ""
            lblTieuDe.Text = "Thêm mới qui trình"
        End Sub

        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            viewstate("MaLinhVuc") = ddlMaLinhVuc.SelectedValue
            BindData()
            LoadGrid()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objDuongDiTinhTrangCtrl As New DuongDiTinhTrangController
            Dim objDuongDiTinhTrangInfo As New DuongDiTinhTrangInfo
            With objDuongDiTinhTrangInfo
                .DuongDiTinhTrangID = txtDuongDiTinhTrangID.Text
                .TabCode = ddlTabCode.SelectedValue
                .ItemCode = ddlItemCode.SelectedValue
                .MaLinhVuc = ddlMaLinhVuc.SelectedValue
                .MaTinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
                .MaTinhTrangNext = ddlMaTinhTrangNext.SelectedValue
            End With

            'chưa có đường đi tình trạng --> thêm mới
            If objDuongDiTinhTrangInfo.DuongDiTinhTrangID = "" Then
                txtDuongDiTinhTrangID.Text = objDuongDiTinhTrangCtrl.insDuongDiTinhTrang(objDuongDiTinhTrangInfo)
                If txtDuongDiTinhTrangID.Text = "" Then
                    SetMSGBOX_HIDDEN(Page, "Them moi qui trinh khong thanh cong!")
                    Exit Sub
                End If
                'refresh lại trang
                If Request.Params("ID") = "" Then
                    Response.Redirect(Request.RawUrl() & "&ID=" & txtDuongDiTinhTrangID.Text)
                Else
                    Response.Redirect(Replace(Request.RawUrl(), "&ID=" & Request.Params("ID"), "&ID=" & txtDuongDiTinhTrangID.Text))
                End If
            Else
                If Not objDuongDiTinhTrangCtrl.updDuongDiTinhTrang(objDuongDiTinhTrangInfo) Then
                    SetMSGBOX_HIDDEN(Page, "Cap nhat qui trinh khong thanh cong!")
                    Exit Sub
                End If
            End If
            objDuongDiTinhTrangCtrl = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub dgdDanhSach_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgdDanhSach.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim img As ImageButton
                img = CType(e.Item.FindControl("imgXoa"), ImageButton)
                If Not img Is Nothing Then
                    img.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn muốn xóa qui trình này không?');")
                End If
            End If
        End Sub

        Private Sub dgdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.ItemCommand
            Try
                Select Case e.CommandName
                    Case "Sua"
                        GetDuongDiTinhTrang(e.Item.Cells(COL_DUONGDITINHTRANGID).Text)
                    Case "Xoa"
                        DelDuongDiTinhTrang(e.Item.Cells(COL_DUONGDITINHTRANGID).Text)
                        Response.Redirect(Replace(Request.RawUrl, "&ID=" & Request.Params("ID"), ""))
                End Select
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub GetDuongDiTinhTrang(ByVal strDuongDiTinhTrangID As String)
            Dim objDuongDiTinhTrang As New DuongDiTinhTrangController
            Dim ds As DataSet
            ds = objDuongDiTinhTrang.getDuongDiTinhTrang(strDuongDiTinhTrangID)
            ddlMaLinhVuc.Enabled = False
            ddlTabCode.Enabled = False
            gLoadControlValues(ds, Me)
            ds = Nothing
            objDuongDiTinhTrang = Nothing
        End Sub

        Private Sub DelDuongDiTinhTrang(ByVal strDuongDiTinhTrangID As String)
            Dim objDuongDiTinhTrang As New DuongDiTinhTrangController
            If Not objDuongDiTinhTrang.DelDuongDiTinhTrang(strDuongDiTinhTrangID) Then
                SetMSGBOX_HIDDEN(Page, "Xoa qui trinh khong thanh cong!")
                Exit Sub
            End If
            objDuongDiTinhTrang = Nothing
        End Sub

    End Class


End Namespace