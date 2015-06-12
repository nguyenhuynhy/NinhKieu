Imports PortalQH
Namespace DOITHOAI
    Public Class Main
        Inherits PortalQH.PortalModuleControl
        Dim iSelectedId As String
        Dim strHeaderTitle As String = ""
        Dim objControl As Object
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents tdUserControl As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents LeftMenu1 As LeftMenu
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
            Try                
                getUserControlList()
                lblTitle.Text = ".::  " & strHeaderTitle & "  ::."
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Sub getUserControlList()
            Dim strFileNameControlPath As String
            Dim iSelectIndex As Integer
            Dim TabId As Integer

            If Not Request.Params("SelectIndex") Is Nothing Then
                iSelectIndex = CInt(Request.Params("SelectIndex"))
            End If
            TabId = CInt(Request.Params("TabId"))
            iSelectedId = LeftMenu1.getSelectIDbySelectIndex(iSelectIndex)

            strFileNameControlPath = getTargetControlFile(TabId, iSelectedId)
            tdUserControl.Controls.Add(Page.LoadControl(strFileNameControlPath))
            objControl = Page.LoadControl(strFileNameControlPath)
        End Sub
        Private Function getTargetControlFile(ByVal p_TabId As Integer, ByVal p_ItemCode As String) As String
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuList As New MenuListController
            Dim ds As DataSet
            Dim dr As DataRow
            objMenuListInfo.TabID = p_TabId
            ds = objMenuList.getMenuBaoCao(objMenuListInfo)
            For Each dr In ds.Tables(0).Rows
                If dr.Item("ItemCode").ToString() = p_ItemCode Then
                    getTargetControlFile = CType(IIf(IsDBNull(dr.Item("Target")), "", dr.Item("Target")), String)
                    strHeaderTitle = CType(IIf(IsDBNull(dr.Item("Title")), "", dr.Item("Title")), String)
                End If
            Next
        End Function
        'lấy đường dẫn URL (sử dụng cho các hàm con)
        Public Function GetURL(Optional ByVal pKeyName As String = "", Optional ByVal pKeyValue As String = "", Optional ByVal pControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(pKeyName, pKeyValue, pControlKey)
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Return strURL
        End Function
        Public Function GetSelectID(ByVal pSelectIndex As Integer) As String
            Return LeftMenu1.getSelectIDbySelectIndex(pSelectIndex)
        End Function


    End Class
End Namespace