Imports System.Configuration
Imports PORTALQH
Namespace THTT
    Public Class MenuList
        Inherits PortalQH.PortalModuleControl
        Public iSelectItemCode As String
        Public iSelectItemTitle As String
        Public iSelectIndex As Integer = 0
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents MyList As System.Web.UI.WebControls.DataList

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
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuList As New MenuListController
            'get connection to PortalQH
            objMenuListInfo.PortalID = PortalId 'CInt(DataCache.GetCache("PortalID"))
            objMenuListInfo.ItemCode = iSelectItemCode
            objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            'If CStr(Request.Params("TabId")) = ConfigurationSettings.AppSettings("TabPQUser") Then
            If InStr(ConfigurationSettings.AppSettings("TabPQUser"), CStr(Request.Params("TabId"))) > 0 Then
                ds = objMenuList.getUserList(objMenuListInfo)
            Else
                ds = objMenuList.getDanhMucList(objMenuListInfo, CType(Session("UserID"), String))
            End If
            MyList.DataSource = ds
            MyList.DataBind()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Request.Params("SelectIndex") Is Nothing Then
                iSelectIndex = CType(Request.Params("SelectIndex"), Integer)
            End If
            MyList.SelectedIndex = iSelectIndex
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Sub
        Public Function GetLink() As String
            Dim TabId As String
            If Not Request.Params("TabID") Is Nothing Then
                TabId = Request.Params("TabID").ToString()
            Else
                TabId = ConfigurationSettings.AppSettings("TabHSHC").ToString()
            End If
            Return "~/Default.aspx?tabid=" & TabId & "&SelectItemCode=" & iSelectItemCode ' & "&SelectIndex=" & CStr(Container.ItemIndex) & "&SelectID=" & DataBinder.Eval(Container.DataItem, "Ma") & "&SelectTitle=" & DataBinder.Eval(Container.DataItem, "Title") & "&SelectChildIndex=0"
        End Function
    End Class
End Namespace