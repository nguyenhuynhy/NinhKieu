Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data
Imports System

Namespace PortalQH
    Public MustInherit Class DanhMucAddNew
        Inherits PortalQH.PortalModuleControl
        Private m_strTableName As String
        Public Const glbXMLCPKTQH As String = "DesktopModules\CPKTQH\CPKTQH.xml"
        ' Added by hand for access to the form.
        'Protected Form1 As System.Web.UI.HtmlControls.HtmlForm

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Panel As System.Web.UI.WebControls.Panel
        Protected WithEvents grdList As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnCancel As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnDelete As System.Web.UI.WebControls.ImageButton

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
            'Dim strTablename As String
            m_strTableName = GetLoaiDanhMuc(Request, CStr(TabId), glbXMLCPKTQH)
            Dim XMLFileName As String
            XMLFileName = GetAbsoluteServerPath(Request) & "DesktopModules\CPKTQH\Controls.xml"
            BindControl.CreateControlsFromXMLFile(Request, m_strTableName, Me, grdList, btnUpdate, btnCancel, XMLFileName)
            Dim objDanhMuc As New DanhMucController
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(m_strTableName), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/images/edit.gif", -1, 500, -1, -1, 2, 2, 2, 2, 2, 2)

            btnDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

        End Sub

        Private Sub btnGetByID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim objDanhMuc As New DanhMucController
            Dim ds As New DataSet
            Dim i As Integer

            'ds = objDanhMuc.GetByID("sp_GetByIDDMLOAIHOSO", GetControlValues("txtMaLoaiHoSo", Page))
            ds = objDanhMuc.GetDanhMuc(Me, m_strTableName)
            If ds.Tables(0).Rows.Count = 0 Then
                ResetControls(Me)
                Exit Sub
            End If
            For i = 0 To ds.Tables(0).Columns.Count - 1
                SetControlValues("obj" & ds.Tables(0).Columns(i).ToString, ds.Tables(0).Rows(0).Item(i).ToString, Me)
            Next

        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Dim objDanhMuc As New DanhMucController
                'If MessageBox.Show("Ban co chac chan muon xoa thong tin nay khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) = DialogResult.No Then Exit Sub
                'objDanhMuc.DeleteDanhMuc(Page, "DMLOAIHOSO")
                'ResetControls(Page)
                Dim chkEdit As New CheckBox
                Dim arrID As New ArrayList
                'If e.CommandName = "Edit" Then


                Dim i As Integer
                For i = 0 To Me.grdList.Items.Count - 1
                    chkEdit = CType(grdList.Items(i).FindControl("chkEdit"), CheckBox)
                    If chkEdit.Checked Then
                        'arrID.Add(grdList.Items(i).Cells(2).Text)
                        objDanhMuc.DeleteDanhMuc(Me, m_strTableName, grdList.Items(i).Cells(2).Text)
                    End If
                Next
                BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(m_strTableName), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/images/edit.gif", -1, 500, -1, -1, 2, 2, 2, 2, 2, 2)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub grdList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdList.ItemCommand
            If e.CommandName = "Edit" Then

                Dim objDanhMuc As New DanhMucController
                Dim ds As New DataSet
                Dim i As Integer

                'ds = objDanhMuc.GetByID("sp_GetByIDDMLOAIHOSO", GetControlValues("txtMaLoaiHoSo", Page))
                ds = objDanhMuc.GetDanhMuc(Page, m_strTableName, GetCommonDB, e.Item.Cells(2).Text)
                If ds.Tables(0).Rows.Count = 0 Then
                    ResetControls(Me)
                    Exit Sub
                End If
                For i = 0 To ds.Tables(0).Columns.Count - 1
                    SetControlValues("obj" & ds.Tables(0).Columns(i).ToString, ds.Tables(0).Rows(0).Item(i).ToString, Me)
                Next
            End If

            'EnableKeyTextBox(Table1, False)
            'For i = 0 To Me.DataGrid.Items.Count - 1 Step 1
            '    chkActive = Me.DataGrid.Items(i).FindControl("chkActive")
            '    txtSoBanChinh = Me.DataGrid.Items(i).FindControl("txtSoBanChinh")
            '    txtSoBanSao = Me.DataGrid.Items(i).FindControl("txtSoBanSao")
            '    txtSoPhoto = Me.DataGrid.Items(i).FindControl("txtSoPhoto")

            '    If (chkActive.Checked) Then ' co checked grid ho so kem theo
            '        mstrMaHoSoKemTheo = DataGrid.Items(i).Cells(1).Text.Trim()
            '        'kiem tra viec nhap vao luoi datagrid
            '        If IsNumeric(txtSoBanChinh.Text) Then
            '            intSoBanChinh = txtSoBanChinh.Text
            '            If Val(intSoBanChinh) < 0 Then
            '                MsgBox_Hidden.Value = "Số bản chính không được nhỏ hơn 0 !"
            '                Exit Sub
            '            ElseIf (intSoBanChinh.toString().length > 3) Then
            '                MsgBox_Hidden.Value = "Số bản chính không được lớn hơn 3 số !"
            '                Exit Sub
            '            End If
            '        Else
            '            MsgBox_Hidden.Value = "Bạn đã nhập số bản chính không phải là số !"
            '            Exit Sub
            '        End If
            '        If IsNumeric(txtSoBanSao.Text) Then
            '            intSoBanSao = txtSoBanSao.Text
            '            If Val(intSoBanSao) < 0 Then
            '                MsgBox_Hidden.Value = "Số bản sao không được nhỏ hơn 0 !"
            '                Exit Sub
            '            ElseIf (intSoBanSao.toString().length() > 3) Then
            '                MsgBox_Hidden.Value = "Số bản sao không được lớn hơn 3 số !"
            '                Exit Sub
            '            End If
            '        Else
            '            MsgBox_Hidden.Value = "Bạn đã nhập số bản sao không phải là số !"
            '            Exit Sub
            '        End If
            '        If IsNumeric(txtSoPhoto.Text) Then
            '            intSoPhoto = txtSoPhoto.Text
            '            If Val(intSoPhoto) < 0 Then
            '                MsgBox_Hidden.Value = "Số bản photo không được nhỏ hơn 0 !"
            '                Exit Sub
            '            ElseIf (intSoPhoto.toString().length() > 3) Then
            '                MsgBox_Hidden.Value = "Số bản photo không được lớn hơn 3 số !"
            '                Exit Sub
            '            End If
            '        Else
            '            MsgBox_Hidden.Value = "Bạn đã nhập số bản photo không phải là số !"
            '            Exit Sub
            '        End If
            '    End If
            'Next

            'End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub grdList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdList.PageIndexChanged
            Dim objDanhMuc As New DanhMucController
            grdList.CurrentPageIndex = e.NewPageIndex
            BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(m_strTableName), grdList, True, True, True, "STT", "Xóa", "Sửa", "~/images/edit.gif", -1, 500, -1, -1, 2, 2, 2, 2, 2, 2)
        End Sub

        Private Sub grdList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdList.SelectedIndexChanged

        End Sub
    End Class
End Namespace
