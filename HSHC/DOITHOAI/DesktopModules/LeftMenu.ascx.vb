Imports System.Configuration
Imports System.Web.UI.WebControls
Imports PortalQH
Namespace DOITHOAI
    Public Class LeftMenu
        Inherits PortalQH.PortalModuleControl
        Dim iSelectIndex As Integer

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
                Dim ds As DataSet
                ds = getDanhSachChucNang()
            CheckRequest(ds)      'Kiểm tra tham số request truyền vào có đúng không
            BindList(ds)
        End Sub
        Private Function getDanhSachChucNang() As DataSet
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuList As New MenuListController
            Dim ds As New DataSet

            'get connection to PortalQH
            objMenuListInfo.PortalID = CInt(DataCache.GetCache("PortalID"))
            'objMenuListInfo.ItemCode = iSelectItemCode
            objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            'If CStr(Request.Params("TabId")) = ConfigurationSettings.AppSettings("TabPQUser") Then
            If InStr(ConfigurationSettings.AppSettings("TabPQUser"), CStr(Request.Params("TabId"))) > 0 Then
                ds = objMenuList.getUserList(objMenuListInfo)
            Else
                ds = objMenuList.getDanhMucList(objMenuListInfo)
            End If

            '-------------------------------------------------------------------
            'tạm thời bỏ dùng cuối cùng do dùng chung store voi form MenuList
            ds.Tables(0).Rows.RemoveAt(ds.Tables(0).Rows.Count - 1)
            '-------------------------------------------------------------------
            Return ds
        End Function
        Private Sub CheckRequest(ByVal ds As DataSet)
            iSelectIndex = 0
            If Request.Params("SelectID") Is Nothing And Request.Params("SelectIndex") Is Nothing Then
                Exit Sub
            End If
            If Request.Params("SelectID") Is Nothing Or Request.Params("SelectIndex") Is Nothing Then
                SubErr()
            End If

            Dim iSelectID As String
            Dim i As Integer
            Try
                iSelectIndex = CInt(Request.Params("SelectIndex"))
                iSelectID = Request.Params("SelectID")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            If ds.Tables(0).Rows(iSelectIndex).Item("Ma").ToString = iSelectID Then
                                Exit Sub
                            Else
                                SubErr()
                            End If
                        End If
                    End If
                End If
            Catch
                SubErr()
            End Try
        End Sub
        Private Sub SubErr()
            Response.Redirect(NavigateURL())
        End Sub
        Private Sub BindList(ByVal ds As DataSet)
            MyList.DataSource = ds
            MyList.DataBind()
            MyList.SelectedIndex = iSelectIndex
        End Sub
        Public Function getSelectIDbySelectIndex(ByVal pSelectIndex As Integer) As String
            Dim ds As DataSet
            ds = getDanhSachChucNang()
            Try
                Return ds.Tables(0).Rows(pSelectIndex).Item("Ma").ToString
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class
End Namespace