Imports System
Imports System.Configuration
Imports System.Data

Namespace PortalQH

    Public Class MenuListInfo
        Private _TabID As Integer
        Private _ItemCode As String
        Private _UserID As String
        Private _PortalID As Integer

        ' public properties
        Public Property TabID() As Integer
            Get
                Return _TabID
            End Get
            Set(ByVal Value As Integer)
                _TabID = Value
            End Set
        End Property

        Public Property ItemCode() As String
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
            End Set
        End Property

        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property PortalID() As Integer
            Get
                Return _PortalID
            End Get
            Set(ByVal Value As Integer)
                _PortalID = Value
            End Set
        End Property

        Public Sub SetValues(ByVal objControl As Object)

            _TabID = CType(GetPropertyValue("TabID", objControl), Integer)

        End Sub

    End Class

    Public Class MenuListController

        Public Function getMenuBaoCao(ByVal objMenuListInfo As MenuListInfo) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_getMenuBaoCao", objMenuListInfo.TabID, objMenuListInfo.UserID)
        End Function

        Public Function getMenuList(ByVal objMenuListInfo As MenuListInfo) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_getMenuUser", objMenuListInfo.TabID, objMenuListInfo.UserID)
        End Function

        Public Function getDefaultItemCode(ByVal objMenuListInfo As MenuListInfo) As String
            Return DataProvider.Instance().ExecuteScalar("sp_getDefaultItemCode", objMenuListInfo.TabID, objMenuListInfo.UserID)
        End Function


        Public Function getTargetControl(ByVal objMenuListInfo As MenuListInfo) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_getTargetControl", objMenuListInfo.TabID, objMenuListInfo.ItemCode)
        End Function

        Public Function GetItemUserList(ByVal objMenuListInfo As MenuListInfo) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_GetItemUserList", objMenuListInfo.TabID, objMenuListInfo.UserID)
        End Function

        Public Function getUserList(ByVal objMenuListInfo As MenuListInfo) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_getUserList", objMenuListInfo.PortalID, objMenuListInfo.ItemCode)
        End Function

        Public Function getDanhMucList(ByVal objMenuListInfo As MenuListInfo) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_getDanhMucList", objMenuListInfo.TabID, objMenuListInfo.UserID)
        End Function

        Public Function getTopUserList(ByVal objMenuListInfo As MenuListInfo) As DataRowView
            Dim ds As DataSet
            Dim dv As DataView
            ds = getUserList(objMenuListInfo)
            dv = New DataView(ds.Tables(0))
            Return dv.Item(0)
        End Function

    End Class
End Namespace

