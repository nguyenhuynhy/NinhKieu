Namespace PortalQH
    Public Class PhanQuyenUserInfo
        Private _MenuID As Integer
        Private _UserID As String
        Private _DefaultItemCode As Integer
        Private _TabID As Integer

        Public Property MenuID() As Integer
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As Integer)
                _MenuID = Value
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
        Public Property DefaultItemCode() As Integer
            Get
                Return _DefaultItemCode
            End Get
            Set(ByVal Value As Integer)
                _DefaultItemCode = Value
            End Set
        End Property
        Public Property TabID() As Integer
            Get
                Return _TabID
            End Get
            Set(ByVal Value As Integer)
                _TabID = Value
            End Set
        End Property
    End Class

    Public Class PhanQuyenUserController
        Public Sub DeleteMenuUser(ByVal objPhanQuyenUserInfo As PhanQuyenUserInfo)
            DataProvider.Instance.ExecuteQueryStoreProcReader("sp_DeleteMenuUser", objPhanQuyenUserInfo.TabID, objPhanQuyenUserInfo.UserID)
        End Sub
        Public Sub AddMenuUser(ByVal objPhanQuyenUserInfo As PhanQuyenUserInfo)
            DataProvider.Instance.ExecuteQueryStoreProcReader("sp_AddMenuUser", objPhanQuyenUserInfo.MenuID, _
                                                                objPhanQuyenUserInfo.UserID, _
                                                                objPhanQuyenUserInfo.DefaultItemCode)
        End Sub
    End Class
End Namespace
