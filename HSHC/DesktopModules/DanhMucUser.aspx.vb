Imports System.Configuration
Namespace PORTALQH
    Public Class DanhMucUser
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCancel As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Form As System.Web.UI.HtmlControls.HtmlForm
        Protected WithEvents TblInput As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents TblControl As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private strTableName As String
        Private strFileGlobal As String
        Private strFileControl As String
        Private strDB As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            'Put user code to initialize the page here
            Dim objDanhMuc As New DanhMucController
            'get connection theo tabid
            strDB = ConfigurationSettings.AppSettings(Request.Params("DB"))
            strFileControl = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Path" & strDB) & "CONTROLS.xml"
            strTableName = Request.Params("DanhMuc")
            CreateControlsUser(strTableName, TblInput, strFileControl, btnCapNhat, btnCancel)
            btnCapNhat.Attributes.Add("onclick", "javascript:SetValue('" & Request.Params("TextName").ToString & "');")
        End Sub
     

        

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
            ResetControls(Me)
            EnableKeyTextBox(TblInput, True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objDanhMuc As New DanhMucUserController
            Dim ds As New DataSet
            objDanhMuc.AddDanhMuc(Me, strDB, strTableName)
            ResetControls(Me)
            EnableKeyTextBox(TblInput, True)
        End Sub
    End Class
End Namespace
