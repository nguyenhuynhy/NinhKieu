Namespace PortalQH
    Public Class Reports
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String

        '=========================================================
        '=Người tạo : TuanNH                                     =
        '=Ngày tạo  : 21/09/2006                                 =
        '=Mục đích  : Thay đổi thêm cột Used cho các reports     =
        '=========================================================


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents grdList As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtItemCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReportID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReportName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtProcedureName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkUsed As System.Web.UI.WebControls.CheckBox

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
                BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", , False, 0)
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, ctype(Session.Item("ActiveDB"),string))
            End If
            TabCode = ddlTabCode.SelectedValue

            Dim objReport As New ReportController

            BindControl.BindDataGrid(objReport.GetReports(Me), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 0, 0, 0, 50, 200, 200, 300, 50)
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong ?');")
            txtItemCode.Attributes.Add("ISNULL", "NOTNULL")
            txtProcedureName.Attributes.Add("ISNULL", "NOTNULL")
            txtReportName.Attributes.Add("ISNULL", "NOTNULL")
            btnUpdate.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub grdList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdList.ItemCommand
            If e.CommandName = "Edit" Then
                Dim objReport As New ReportController
                Dim ds As New DataSet
                Dim i As Integer
                txtReportID.Text = e.Item.Cells(2).Text
                ds = objReport.GetByIDReport(Me)
                gLoadControlValues(ds, Me)
            End If
        End Sub

        Private Sub grdList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdList.PageIndexChanged
            Dim objReport As New ReportController
            grdList.CurrentPageIndex = e.NewPageIndex
            BindControl.BindDataGrid(objReport.GetReports(Me), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 0, 0, 0, 50, 200, 200, 300, 50)
        End Sub

        Private Sub mResetControls()
            txtItemCode.Text = ""
            txtProcedureName.Text = ""
            txtReportID.Text = ""
            txtReportName.Text = ""
            txtTitle.Text = ""
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            If txtItemCode.Text = "" Then

                SetMSGBOX_HIDDEN(Page, "Ban chua dien du thong tin !")
                Exit Sub
            End If
            Dim objReport As New ReportController

            objReport.AddReport(Me)
            BindControl.BindDataGrid(objReport.GetReports(Me), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 0, 0, 0, 50, 200, 200, 300, 50)
            mResetControls()
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim Item As DataGridItem
            Dim strID As String
            Dim chk As CheckBox
            For Each Item In grdList.Items
                chk = CType(Item.Cells(1).FindControl("chkXoa"), CheckBox)
                If chk.Checked Then
                    If strID <> "" Then strID = strID & ","
                    strID = strID & Item.Cells(2).Text
                End If
            Next
            Dim objReport As New ReportController
            objReport.DelReport(strID)
            BindControl.BindDataGrid(objReport.GetReports(Me), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 0, 0, 0, 50, 200, 200, 300)
            objReport = Nothing
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            mResetControls()
        End Sub
    End Class

End Namespace