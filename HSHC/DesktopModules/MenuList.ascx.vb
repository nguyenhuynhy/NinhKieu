Imports System.Configuration
Namespace PortalQH
    Public Class MenuList
        Inherits PortalQH.PortalModuleControl
        Public iSelectItemCode As String
        Public iSelectItemTitle As String
        Public iSelectIndex As Integer = 0
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents MyList As System.Web.UI.WebControls.DataList


        'TuanNH update ngay 27/09/2006
        'Mo ta : Kiem tra Session("MaTab") truyen tu form Phan quyen Tim kiem

        'TuanNH update ngay 26/12/2006
        'Mo ta : Them ham tra ve selectid mac. dinh.


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim ds As New DataSet
            'Dim objMenuListInfo As New MenuListInfo
            'Dim objMenuList As New MenuListController
            ''get connection to PortalQH
            'objMenuListInfo.PortalID = CInt(DataCache.GetCache("PortalID"))
            'objMenuListInfo.ItemCode = iSelectItemCode
            'objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            'objMenuListInfo.UserID = CType(Session.Item("UserName"), String)
            'If CStr(Request.Params("TabId")) = ConfigurationSettings.AppSettings("TabPQUser") Then
            'If Session.Item("MaTab") Is Nothing Then
            '    If InStr(ConfigurationSettings.AppSettings("TabPQUser"), CStr(Request.Params("TabId"))) > 0 Then
            '        ds = objMenuList.getUserList(objMenuListInfo)
            '    Else
            '        ds = objMenuList.getDanhMucList(objMenuListInfo)
            '    End If
            '    ds = Me.getMenuList
            'Else
            '    objMenuListInfo.TabID = CInt(Session.Item("MaTab").ToString())
            '    ds = objMenuList.getUserList(objMenuListInfo)
            '    Session.Item("MaTab") = Nothing
            'End If
            ds = Me.getMenuList

            MyList.DataSource = ds
            MyList.DataBind()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Request.Params("SelectIndex") Is Nothing Then
                iSelectIndex = CType(Request.Params("SelectIndex"), Integer)
            End If
            MyList.SelectedIndex = iSelectIndex
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Sub


        Private Function getMenuList() As DataSet
            Dim ds As New DataSet
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuList As New MenuListController
            'get connection to PortalQH
            objMenuListInfo.PortalID = CInt(DataCache.GetCache("PortalID"))
            objMenuListInfo.ItemCode = iSelectItemCode
            objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserName"), String)

            If Session.Item("MaTab") Is Nothing Then
                If InStr(ConfigurationSettings.AppSettings("TabPQUser"), CStr(Request.Params("TabId"))) > 0 Then
                    ds = objMenuList.getUserList(objMenuListInfo)
                Else
                    ds = objMenuList.getDanhMucList(objMenuListInfo)
                End If
            Else
                objMenuListInfo.TabID = CInt(Session.Item("MaTab").ToString())
                ds = objMenuList.getUserList(objMenuListInfo)
                Session.Item("MaTab") = Nothing
            End If

            Return ds
        End Function


        Public Function getSelectID() As String
            Return Me.getMenuList.Tables(0).Rows(0)("Ma").ToString()
        End Function
    End Class
End Namespace