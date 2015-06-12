Imports PortalQH
Imports System.Configuration
Imports System.Web.UI.WebControls
Public Class SearchHoSo
    Inherits PortalQH.PortalModuleControl
    Dim objControl As Object

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents getUserControl As System.Web.UI.HtmlControls.HtmlTableCell

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
        ' Lay ModuleID cua trang dau
        Session("ModuleIDOfPage") = ModuleId.ToString()

        Dim mTabId As String
        Dim mLinhVuc As String
        If Not Request.Params("Tabid") Is Nothing Then
            mTabId = Request.Params("Tabid")
        End If
        If Not Request.Params("LinhVuc") Is Nothing Then
            mLinhVuc = Request.Params("LinhVuc")
        Else
            mLinhVuc = GetDefaultLinhVuc()
        End If
        LoadControls(mLinhVuc)


    End Sub
    Private Sub LoadControls(ByVal LinhVuc As String)
        Dim strFileNameControlPath As String
        Dim TabId As String
        Dim ds As New DataSet
        Dim obj As New SearchInfoController
        If Not Request.Params("Tabid") Is Nothing Then
            TabId = Request.Params("Tabid")
        End If
        ds = obj.getTargetControlFile(TabId, LinhVuc)
        strFileNameControlPath = ds.Tables(0).Rows(0)(0).ToString
        If strFileNameControlPath <> "" Then
            getUserControl.Controls.Add(Page.LoadControl(strFileNameControlPath))
            objControl = Page.LoadControl(strFileNameControlPath)
        End If
    End Sub
    Private Function GetDefaultLinhVuc() As String
        Dim TabId As String
        Dim ds As New DataSet
        Dim obj As New SearchInfoController
        If Not Request.Params("Tabid") Is Nothing Then
            TabId = Request.Params("Tabid")
        End If
        ds = obj.GetDefaultLinhVuc(TabId)
        If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
            Return CType(ds.Tables(0).Rows(0).Item(0), String)
        End If
        Return ""
    End Function
End Class
