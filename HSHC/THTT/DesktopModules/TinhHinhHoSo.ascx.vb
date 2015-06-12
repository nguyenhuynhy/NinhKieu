Option Strict Off
Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class TinhHinhHoSo
        Inherits PortalQH.PortalModuleControl
        'Public strHeaderTitle As String = ""
        Dim objControl As Object
        Dim iSelectedId As String
        Protected WithEvents tdMenu As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents MenuList1 As MenuList

        Dim iSelectedChildId As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents getUserControl As System.Web.UI.HtmlControls.HtmlTableCell
        Dim objMenuListInfo As New MenuListInfo
        Dim objMenuList As New MenuListController
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
            Session("MidOfStartPage") = ModuleId.ToString()
            Try
                If Not Page.IsPostBack Then
                    objMenuListInfo.UserID = CType(Session("UserID"), String) 'CType(DataCache.GetCache("UserID"), String)
                    iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
                End If
                If Not Request.Params("TabId") Is Nothing Then
                    objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
                Else
                    objMenuListInfo.TabID = CType(ConfigurationSettings.AppSettings("TabDefault"), Integer)
                End If
                getUserControlList()
                'lblHeader.Text = ".::  " & strHeaderTitle & "  ::."
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Function GetDefaultItem() As String
            Dim ds As New DataSet
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuList As New MenuListController
            objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            ds = objMenuList.getDanhMucList(objMenuListInfo, CType(Session("UserID"), String))
            If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
                Return CType(ds.Tables(0).Rows(0).Item(0), String)
            End If
            Return ""
        End Function

        Private Sub getUserControlList()
            Dim strFileNameControlPath As String

            If Not Request.Params("SelectID") Is Nothing Then
                iSelectedId = Request.Params("SelectID")
            Else
                'iSelectedId = ConfigurationSettings.AppSettings("MenuIDStart").ToString()
                iSelectedId = GetDefaultItem()
            End If

            If Not Request.Params("SelectChildID") Is Nothing Then
                iSelectedChildId = Request.Params("SelectChildID")
            Else
                iSelectedChildId = "1" 'ConfigurationSettings.AppSettings("MenuIDStart").ToString()
            End If

            If iSelectedId <> " " Then
                strFileNameControlPath = getTargetControlFile(objMenuListInfo.TabID, iSelectedId, iSelectedChildId)
                If strFileNameControlPath <> "" Then
                    getUserControl.Controls.Add(Page.LoadControl(strFileNameControlPath))
                    objControl = Page.LoadControl(strFileNameControlPath)
                End If
                MenuList1.iSelectItemCode = iSelectedId
                MenuList1.Visible = True
            Else
                MenuList1.Visible = False
            End If
        End Sub
        Private Function getTargetControlFile(ByVal p_TabId As Integer, ByVal p_ItemCode As String, ByVal p_ItemCodeChild As String) As String
            Dim ds As DataSet
            Dim dr As DataRow
            objMenuListInfo.TabID = p_TabId
            objMenuListInfo.ItemCode = p_ItemCode
            objMenuListInfo.UserID = CType(Session("UserID"), String) 'CType(DataCache.GetCache("UserID"), String)
            ds = objMenuList.getMenuHoSo(objMenuListInfo, p_ItemCode)
            For Each dr In ds.Tables(0).Rows
                If dr.Item("ItemCode").ToString() = p_ItemCodeChild Then
                    getTargetControlFile = CType(dr.Item("Target"), String)
                    'strHeaderTitle = CType(dr.Item("Title"), String)
                End If
            Next
        End Function
    End Class
End Namespace

