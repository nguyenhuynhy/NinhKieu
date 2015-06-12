Imports PortalQH
Public Class DMNguoiNhanNoiNhan
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlDonvi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkUsers As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton

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
            initState()
            LoadData()
            BindControl.BindCheckBoxList(chkUsers, "sp_BCT_getUserByPhongBan", "", ddlDonvi.SelectedValue.ToString)
        End If
    End Sub
    Private Sub initState()
        BindControl.BindDropDownList(ddlDonvi, "DMDONVI", , False, 0)
        BindControl.BindCheckBoxList(chkUsers, "DMUSERS", , False)
    End Sub
    Private Sub LoadData()
        Dim ds As DataSet
        Dim i, j As Integer
        ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_BCT_getNguoiNhan", ddlDonvi.SelectedValue)
        For j = 0 To chkUsers.Items.Count - 1
            chkUsers.Items(j).Selected = False
        Next
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 0 To chkUsers.Items.Count - 1
                If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(chkUsers.Items(j).Value, String) Then
                    chkUsers.Items(j).Selected = True
                End If
            Next
        Next
    End Sub
    Private Sub ddlDonvi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDonvi.SelectedIndexChanged
        BindControl.BindCheckBoxList(chkUsers, "sp_BCT_getUserByPhongBan", "", ddlDonvi.SelectedValue.ToString)
        LoadData()
    End Sub
    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Dim n, i As Integer
        Dim strFullName As String = ""
        Dim strUser As String = ""

        n = chkUsers.Items.Count
        For i = 0 To n - 1
            If chkUsers.Items(i).Selected = True Then
                strUser = strUser + chkUsers.Items(i).Value + ";"
                strFullName = strFullName + chkUsers.Items(i).Text + ";"
            End If
        Next i
        If strUser = "" Then
            SetMSGBOX_HIDDEN(Page, "Không có dữ liệu cập nhật")
        Else
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_BCT_InsNguoiNhan", strUser, strFullName, ddlDonvi.SelectedValue.ToString)
        End If
    End Sub
End Class
