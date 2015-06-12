Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class TinhHinhHoSo_ChucNang
        Inherits System.Web.UI.UserControl
        Dim iTabID As String
        Dim iSelectID As String
        Dim iIndex As String
        Dim iSelectChildID As String
        Dim iSelectTitle As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents rblChucNang As System.Web.UI.WebControls.RadioButtonList

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
                Dim objCon As New PhanQuyenThongKeController
                If Not Request.Params("SelectID") Is Nothing Then
                    iSelectID = Request.Params("SelectID").ToString()
                Else
                    'iSelectID = ConfigurationSettings.AppSettings("MenuIDStart").ToString()
                    iSelectID = GetDefaultItem()
                End If

                If Not Request.Params("SelectChildID") Is Nothing Then
                    iSelectChildID = Request.Params("SelectChildID").ToString()
                Else
                    iSelectChildID = "1"
                End If

                If Not Request.Params("TabID") Is Nothing Then
                    iTabID = Request.Params("TabID").ToString()
                Else
                    iTabID = ConfigurationSettings.AppSettings("TabDefault").ToString()
                End If

                If Not Page.IsPostBack Then
                    BindControl.BindRadioButtonList(rblChucNang, "sp_getMenuChucNang", iSelectChildID, iTabID, iSelectID)
                    If Not Request.Params("SelectChildIndex") Is Nothing Then
                        rblChucNang.SelectedIndex = CType(Request.Params("SelectChildIndex"), Integer)
                    End If
                End If
                If rblChucNang.Items.Count <= 1 Then
                    Me.Visible = False
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
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

        Private Sub rblChucNang_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblChucNang.SelectedIndexChanged
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectID = Request.Params("SelectID").ToString()
            Else
                iSelectID = ConfigurationSettings.AppSettings("MenuIDStart").ToString()
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                iIndex = Request.Params("SelectIndex").ToString()
            Else
                iIndex = "0"
            End If
            If Not Request.Params("SelectTitle") Is Nothing Then
                iSelectTitle = Request.Params("SelectTitle").ToString()
            Else
                iSelectTitle = ""
            End If
            If Not Request.Params("TabId") Is Nothing Then
                iTabID = Request.Params("TabId").ToString()
            Else
                iTabID = CType(ConfigurationSettings.AppSettings("TabDefault"), String)
            End If
            Response.Redirect("~/Default.aspx?tabid=" & iTabID & "&SelectIndex=" & iIndex & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&SelectChildID=" & rblChucNang.SelectedValue & "&SelectChildIndex=" & rblChucNang.SelectedIndex & "&Type=" & rblChucNang.SelectedValue)
        End Sub
    End Class
End Namespace

