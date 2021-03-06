Imports PortalQH
Namespace CPKTQH
    Public Class PhuongThucNganhNghe
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lstNganhNgheKinhDoanh As System.Web.UI.WebControls.CheckBoxList

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
                BindControl.BindDropDownList(ddlMaPhuongThucKinhDoanh, "DMPHUONGTHUCKINHDOANH", , , 1)
                BindControl.BindCheckBoxList(lstNganhNgheKinhDoanh, "DMNGANHKINHDOANH", , False)
                If ddlMaPhuongThucKinhDoanh.SelectedValue <> "" Then
                    LoadPhuongThucNganhNghe()
                End If
            End If
            
        End Sub
        Private Sub LoadPhuongThucNganhNghe()
            If lstNganhNgheKinhDoanh.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer
            Dim ds As New DataSet
            Dim objPhuongThucNganhNghe As New DinhNghiaPhuongThucNganhNgheController
            ds = objPhuongThucNganhNghe.GetAllPhuongThucNganhNghe(ddlMaPhuongThucKinhDoanh.SelectedValue)
            For j = 0 To lstNganhNgheKinhDoanh.Items.Count - 1
                lstNganhNgheKinhDoanh.Items(j).Selected = False
            Next
            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstNganhNgheKinhDoanh.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstNganhNgheKinhDoanh.Items(j).Value, String) Then
                        lstNganhNgheKinhDoanh.Items(j).Selected = True
                    End If
                Next
            Next
        End Sub
        Private Sub CapNhatPhuongThucNganhNghe()
            Dim j As Integer
            Dim objPhuongThucNganhNghe As New DinhNghiaPhuongThucNganhNgheController
            objPhuongThucNganhNghe.DelPhuongThucNganhNghe(ddlMaPhuongThucKinhDoanh.SelectedValue)
            For j = 0 To lstNganhNgheKinhDoanh.Items.Count - 1
                If lstNganhNgheKinhDoanh.Items(j).Selected Then
                    objPhuongThucNganhNghe.InsPhuongThucNganhNghe(lstNganhNgheKinhDoanh.Items(j).Value, ddlMaPhuongThucKinhDoanh.SelectedValue)
                End If
            Next
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            CapNhatPhuongThucNganhNghe()
            LoadPhuongThucNganhNghe()
        End Sub

        Private Sub ddlMaPhuongThuckinhDoanh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaPhuongThucKinhDoanh.SelectedIndexChanged
            LoadPhuongThucNganhNghe()
        End Sub

        
    End Class
End Namespace
