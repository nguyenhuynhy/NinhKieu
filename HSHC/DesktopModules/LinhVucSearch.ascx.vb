Imports PortalQH
Imports System.Configuration
Imports System.Web.UI.WebControls
Public Class LinhVucSearch
    Inherits PortalQH.PortalModuleControl
    Dim objControl As Object
    Dim iTabID As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList

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
        If Not Me.IsPostBack Then
            Dim TabId As String
            Dim LinhVuc As String
            If Not Request.Params("Tabid") Is Nothing Then
                TabId = Request.Params("Tabid")
            End If
            If Not Request.Params("LinhVuc") Is Nothing Then
                LinhVuc = Request.Params("LinhVuc")
            End If
            BindControl.BindDropDownList_StoreProc(ddlMaLinhVuc, False, LinhVuc, "sp_LinhVucSeach", TabId)
        End If
    End Sub

    Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
        If Not Request.Params("TabId") Is Nothing Then
            iTabID = Request.Params("TabId").ToString()
        Else
            iTabID = CType(ConfigurationSettings.AppSettings("TabDefault"), String)
        End If
        Response.Redirect("~/Default.aspx?tabid=" & iTabID & "&LinhVuc=" & ddlMaLinhVuc.SelectedValue)
    End Sub
End Class
