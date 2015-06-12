Imports System.Configuration
Namespace PortalQH
    Public Class DanhMuc
        Inherits PortalQH.PortalModuleControl
        Private strTableName As String
        Private strFileGlobal As String
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblSoDong As System.Web.UI.WebControls.Label
        Protected WithEvents btnSearch As System.Web.UI.WebControls.LinkButton
        Private strFileControl As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Panel As System.Web.UI.WebControls.Panel
        Protected WithEvents grdList As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Form As System.Web.UI.HtmlControls.HtmlForm
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents MenuList1 As MenuList
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
            Dim objDanhMuc As New DanhMucController
            'get connection theo tabid

            strFileControl = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Path" & ctype(Session.Item("ActiveDB"),string)) & "CONTROLS.xml"
            strFileGlobal = ConfigurationSettings.AppSettings("Path" & ctype(Session.Item("ActiveDB"),string)) & "GLOBAL.xml"
            If Not Page.IsPostBack Then
                txtSoDong.Text = CType(grdList.PageSize, String)
            End If

            If Not Request.Params("SelectID") Is Nothing Then
                strTableName = GetLoaiDanhMuc(Request, Request.Params("SelectID"), strFileGlobal)
            Else
                'strTableName = GetLoaiDanhMuc(Request, "1", strFileGlobal)
                strTableName = GetLoaiDanhMuc(Request, MenuList1.getSelectID(), strFileGlobal)
            End If

            'CreateControls(strTableName, Table2, strFileControl, grdList, btnUpdate, btnCancel, btnSearch, lblSoDong, txtSoDong)
            CreateControls(strTableName, Table2, strFileControl)
            'BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, ""), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 150, 200, 70, 30, 50, 100, 0, 0, 0, 0)

            Dim objPortalModule As PortalModuleControl = Container.GetPortalModuleControl(Me)
            If Not objPortalModule Is Nothing Then
                lblTitle.Text = objPortalModule.ModuleConfiguration.ModuleTitle
            End If
            MenuList1.iSelectIndex = CType(Request.Params("SelectIndex"), Integer)
            MenuList1.iSelectItemCode = Request.Params("SelectItemCode")
            If Not Request.Params("SelectTitle") Is Nothing Then
                lblTitle.Text = ".:: Danh mục " & Request.Params("SelectTitle") & " ::."
            Else
                lblTitle.Text = ".:: Danh mục " & MenuList1.iSelectItemTitle & " ::."
            End If
            If CType(viewstate("DieuKien"), String) = "" Then
                viewstate("DieuKien") = GetDieuKien()
            End If
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, "", CType(viewstate("DieuKien"), String)), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif")
            btnUpdate.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub grdList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdList.ItemCommand
            If e.CommandName = "Edit" Then
                Dim objDanhMuc As New DanhMucController
                Dim ds As New DataSet
                Dim i As Integer
                Select Case UCase(strTableName)
                    Case "DMTINHTRANGHOSO", "DMTINHTRANGXULY"
                        ds = objDanhMuc.GetDanhMuc(Page, strTableName, GetCommonDB, e.Item.Cells(1).Text, e.Item.Cells(3).Text)
                    Case Else
                        ds = objDanhMuc.GetDanhMuc(Page, strTableName, GetCommonDB, e.Item.Cells(1).Text)
                End Select

                If ds.Tables(0).Rows.Count = 0 Then
                    ResetControls(Me)
                    Exit Sub
                End If
                For i = 0 To ds.Tables(0).Columns.Count - 1
                    SetControlValues("obj" & ds.Tables(0).Columns(i).ToString, ds.Tables(0).Rows(0).Item(i).ToString, Me)
                Next
                EnableKeyTextBox(Table2, False)
            End If
        End Sub

        Private Sub grdList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdList.PageIndexChanged
            Dim objDanhMuc As New DanhMucController
            grdList.CurrentPageIndex = e.NewPageIndex
            'BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, ""), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 50, 200, 70, 30, 50, 100, 0, 0, 0, 0)
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, "", CType(viewstate("DieuKien"), String)), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif")
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            Dim objDanhMuc As New DanhMucController
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(grdList.PageSize)
                Exit Sub
            End If
            If grdList.PageSize <> CInt(txtSoDong.Text) Then
                grdList.PageSize = CInt(txtSoDong.Text)
                grdList.CurrentPageIndex = 0
                'BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, ""), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif", 50, 200, 70, 30, 50, 100, 0, 0, 0, 0)
                BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, "", GetDieuKien), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif")
            End If
        End Sub

        Private Sub grdList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdList.SortCommand
            Dim strSortBy As String = CType(ViewState("SortExpression"), String)
            Dim strSortAsc As String = CType(ViewState("SortAscending"), String)
            Dim strFieldSort As String = "" : Dim objDanhMuc As New DanhMucController

            ViewState("SortExpression") = e.SortExpression

            If (e.SortExpression = strSortBy) Then
                If strSortAsc = "yes" Then
                    ViewState("SortAscending") = "no"
                    strFieldSort = " DESC"
                Else
                    ViewState("SortAscending") = "yes"
                    strFieldSort = " ASC"
                End If
            Else
                ViewState("SortAscending") = "yes"
                strFieldSort = " ASC"
            End If

            strFieldSort = " Order By " & e.SortExpression.ToString() & strFieldSort
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, strFieldSort, GetDieuKien), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif")
        End Sub


        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim objDanhMuc As New DanhMucController
            Dim ds As New DataSet
            If CheckEnableKey(Table2) = True Then 'truong hop nhap moi
                'check trung
                ds = objDanhMuc.GetDanhMuc(Me, strTableName)
                If ds.Tables(0).Rows.Count > 0 Then
                    SetMSGBOX_HIDDEN(Page, "Thong tin ma bi trung. Vui long nhap ma khac !")
                    Exit Sub
                End If
            End If
            If CheckNull(Table2) Then
                SetMSGBOX_HIDDEN(Page, "Ban chua dien du thong tin !")
                Exit Sub
            End If
            objDanhMuc.AddDanhMuc(Me, strTableName)
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, ""), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif")
            ResetControls(Me)
            EnableKeyTextBox(Table2, True)
            'SetMSGBOX_HIDDEN(Page, "Ban da cap nhat thanh cong !")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            ResetControls(Me)
            EnableKeyTextBox(Table2, True)
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim objDanhMuc As New DanhMucController
            grdList.CurrentPageIndex = 0
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName, "", GetDieuKien), grdList, True, False, True, "STT", "Xóa", "Sửa", "~/Images/edit.gif")
            viewstate("DieuKien") = GetDieuKien()
        End Sub
        Private Function GetDieuKien() As String
            Dim strDK As String
            strDK = " where 1=1 "
            FindDieuKien(strDK, Table2)
            Return strDK
        End Function

        Private Function FindDieuKien(ByRef strDK As String, ByVal obj As Object) As String
            Dim oControl As Control
            For Each oControl In CType(obj, Control).Controls
                Select Case True
                    Case TypeOf oControl Is TextBox
                        If CType(oControl, TextBox).Text <> "" Then
                            strDK = strDK + " and " + Mid(CType(oControl, TextBox).ID, 4) + " like N'%" + Replace(CType(oControl, TextBox).Text, "'", "''") + "%'"
                        End If
                    Case TypeOf oControl Is DropDownList
                        If CType(oControl, DropDownList).SelectedValue <> "" Then
                            strDK = strDK + " and " + Mid(CType(oControl, DropDownList).ID, 4) + " like N'%" + Replace(CType(oControl, DropDownList).SelectedValue, "'", "''") + "%'"
                        End If
                    Case TypeOf oControl Is CheckBoxList
                        If CType(oControl, CheckBox).Checked = True Then
                            strDK = strDK + " and " + Mid(CType(oControl, CheckBox).ID, 4) + " like N'%" + CType(IIf(CType(oControl, CheckBox).Checked = True, 1, 0), String) + "%'"
                        End If
                    Case TypeOf oControl Is RadioButton
                        If CType(oControl, RadioButton).Checked = True Then
                            strDK = strDK + " and " + Mid(CType(oControl, RadioButton).ID, 4) + " like N'%" + CType(IIf(CType(oControl, RadioButton).Checked = True, 1, 0), String) + "%'"
                        End If
                    Case Else
                        FindDieuKien(strDK, oControl)
                End Select

            Next
        End Function

    End Class
End Namespace
