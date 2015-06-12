Imports PortalQH
Namespace CPXD
    Public Class DanhMuc_ChonHangMucSau
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lstDanhMuc As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtValue As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtDanhMuc As System.Web.UI.HtmlControls.HtmlInputHidden

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
            txtDanhMuc.Value = Request.Params("DanhMuc").ToString
            BindlstDanhMuc(lstDanhMuc, "sp_GetDanhMucCBO", "", GetCommonDB, txtDanhMuc.Value)
            btnTroVe.Attributes.Add("onclick", "javascript:SetValue('" & Request.Params("TextName").ToString & "');")
        End Sub
        Public Shared Sub BindlstDanhMuc(ByVal obj As RadioButtonList, ByVal strProcName As String, ByVal strDefaultValue As String, ByVal ParamArray ParamValues() As Object)
            Dim dm As New DanhMucController
            obj.DataSource = dm.GetByID(strProcName, ParamValues)
            obj.DataTextField = "Ten"
            obj.DataValueField = "Ten"

            obj.DataBind()

            'If strDefaultValue <> "" Then
            '    obj.SelectedValue = strDefaultValue
            'End If
            Dim i As Integer
            If strDefaultValue <> "" Then
                For i = 0 To obj.Items.Count - 1
                    If obj.Items(i).Value = strDefaultValue Then
                        obj.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
            'If intDefaultIndex <> -1 And obj.Items.Count > intDefaultIndex Then
            '    obj.SelectedIndex = intDefaultIndex
            'End If
        End Sub

    End Class
End Namespace