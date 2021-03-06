Namespace PortalQH
    Public Class DinhNghiaDuongPhuong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lstDuong As System.Web.UI.WebControls.CheckBoxList

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
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG", , , 1)
                BindControl.BindCheckBoxList(lstDuong, "DMDUONG", , False)
                If ddlMaPhuong.SelectedValue <> "" Then
                    LoadDuongPhuong()
                End If

            End If
        End Sub
        Private Sub LoadDuongPhuong()
            If lstDuong.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer
            Dim ds As New DataSet
            Dim objDuongPhuong As New DinhNghiaDuongPhuongController
            ds = objDuongPhuong.GetAllDuongPhuong(ddlMaPhuong.SelectedValue)
            For j = 0 To lstDuong.Items.Count - 1
                lstDuong.Items(j).Selected = False
            Next
            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstDuong.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstDuong.Items(j).Value, String) Then
                        lstDuong.Items(j).Selected = True
                    End If
                Next
            Next
        End Sub
        Private Sub CapNhatDuongPhuong()
            Dim j As Integer
            Dim objDuongPhuong As New DinhNghiaDuongPhuongController
            objDuongPhuong.DelDuongPhuong(ddlMaPhuong.SelectedValue)
            For j = 0 To lstDuong.Items.Count - 1
                If lstDuong.Items(j).Selected Then
                    objDuongPhuong.InsDuongPhuong(lstDuong.Items(j).Value, ddlMaPhuong.SelectedValue)
                End If
            Next
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            CapNhatDuongPhuong()
            LoadDuongPhuong()
        End Sub

        Private Sub ddlMaPhuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaPhuong.SelectedIndexChanged
            LoadDuongPhuong()
        End Sub
    End Class
End Namespace
