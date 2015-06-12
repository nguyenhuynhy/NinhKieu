Namespace DOITHOAI
    Public Class ErrorPage
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblError As System.Web.UI.WebControls.Label
        Protected WithEvents btnDanhSach As System.Web.UI.WebControls.LinkButton

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
            If Not Page.IsPostBack Then
                Select Case Request.Params("Type")
                    Case "VIEW"
                        lblError.Text = "Bạn không được quyền xem nội dung tin nhắn này<br>hoặc tin nhắn này đã bị xóa"
                    Case "DELETE"
                        lblError.Text = "Bạn không được quyền xóa nội dung tin nhắn này<br>" & _
                        "Đã có người trả lời tin nhắn này hoặc nội dung tin nhắn không tồn tại trong hệ thống"
                    Case "EDIT"
                        lblError.Text = "Bạn không được quyền sửa nội dung tin nhắn này<br>Đã có người trả lời tin nhắn này hoặc  nội dung tin nhắn không tồn tại trong hệ thống"
                    Case "ADDNEW"
                        lblError.Text = "Bạn không được quyền trả lời tin nhắn này"
                End Select
            End If
        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDanhSach.Click
            Dim strURL As String
            strURL = NavigateURL()
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub
    End Class
End Namespace