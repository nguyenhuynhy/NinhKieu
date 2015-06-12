Option Strict Off
Imports PortalQH
Imports System.Configuration
Namespace HSHC
    'NganTL
    'Created on 15/10/2004
    'Desc : Thong ke va bao cao ho so
    'Updated on : 
    Public Class ThongKeBaoCao
        Inherits PortalQH.PortalModuleControl
        Public strHeaderTitle As String = ""
        Dim objControl As Object
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUserID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Dim iSelectedId As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents getUserControl As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents MenuList1 As MenuList
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
                If Not Page.IsPostBack Then
                    If CType(ConfigurationSettings.AppSettings("CheckUser" & ctype(Session.Item("ActiveDB"),string)), Boolean) Then
                        BindControl.BindDropDownList_StoreProc(ddlLinhVuc, True, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
                    Else
                        BindControl.BindDropDownList_StoreProc(ddlLinhVuc, True, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
                    End If
                    '============================================================================='
                    Dim objMenuList As New MenuListController
                    Dim objMenuListInfo As New MenuListInfo
                    objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
                    objMenuListInfo.UserID = CType(Session.Item("UserID"), String)
                    iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
                    '============================================================================='
                End If
                Init_State()
                getUserControlList()
                lblHeader.Text = ".::  " & strHeaderTitle & "  ::."
                Init_Report()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Sub Init_State()
            '====================================================================================================='
            If ctype(Session.Item("ActiveDB"),string) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                If ddlLinhVuc.Items.Count > 0 Then
                    ddlLinhVuc.SelectedIndex = 1
                End If
                tblHeader.Visible = False
            End If
            '====================================================================================================='
            If ddlLinhVuc.SelectedIndex > -1 Then
                Session.Item("MaLinhVuc") = ddlLinhVuc.SelectedValue()
                txtMaLinhVuc.Text = ddlLinhVuc.SelectedValue
                txtTabID.Text = CStr(Request.Params("TabID"))
                txtUserID.Text = CStr(Session.Item("UserID"))
            End If
        End Sub

        Sub Init_Report()
            Dim strItemCode As String
            If Request.Params("SelectID") Is Nothing Then
                strItemCode = "1"
            Else
                strItemCode = Request.Params("SelectID")
            End If
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("MaLinhVuc"), String), strItemCode, "HSHC", btnIn, Me)
        End Sub

        Private Sub getUserControlList()
            Dim strFileNameControlPath As String
            Dim TabId As Integer
            TabId = CInt(Request.Params("TabId"))
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectedId = Request.Params("SelectID")
            Else
                iSelectedId = 1
            End If
            strFileNameControlPath = getTargetControlFile(TabId, iSelectedId)
            getUserControl.Controls.Add(Page.LoadControl(strFileNameControlPath))
            objControl = Page.LoadControl(strFileNameControlPath)
            MenuList1.iSelectItemCode = iSelectedId
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
                    getTargetControlFile = CType(dr.Item("Target"), String)
                    strHeaderTitle = CType(dr.Item("Title"), String)
                End If
            Next
        End Function

        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            If ddlLinhVuc.SelectedIndex > -1 Then
                Session.Item("MaLinhVuc") = ddlLinhVuc.SelectedValue()
                txtMaLinhVuc.Text = CType(Session.Item("MaLinhVuc"), String)
                objControl.BindData(CType(Session.Item("MaLinhVuc"), String))
                If Request.Params("SelectID") <> "" Then
                    GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("MaLinhVuc"), String), Request.Params("SelectID"), "HSHC", btnIn, Me)
                Else
                    GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("MaLinhVuc"), String), "1", "HSHC", btnIn, Me)
                End If
            End If
        End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click

        End Sub
    End Class

End Namespace
