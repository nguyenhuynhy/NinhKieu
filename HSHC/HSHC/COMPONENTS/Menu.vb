
Namespace PortalQH
    Public Class MenuInfo
        Private _MenuID As String
        Private _TabCode As String
        Private _ItemCode As String
        Private _ItemName As String
        Private _Target As String
        Private _TargetChild As String
        Private _MenuOrder As String
        Public Property MenuID() As String
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As String)
                _MenuID = Value
            End Set
        End Property
        Public Property TabCode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
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
        Public Property ItemName() As String
            Get
                Return _ItemName
            End Get
            Set(ByVal Value As String)
                _ItemName = Value
            End Set
        End Property
        Public Property Target() As String
            Get
                Return _Target
            End Get
            Set(ByVal Value As String)
                _Target = Value
            End Set
        End Property
        Public Property TargetChild() As String
            Get
                Return _TargetChild
            End Get
            Set(ByVal Value As String)
                _TargetChild = Value
            End Set
        End Property
        Public Property MenuOrder() As String
            Get
                Return _MenuOrder
            End Get
            Set(ByVal Value As String)
                _MenuOrder = Value
            End Set
        End Property
    End Class

    Public Class MenuController
        Public Function AddMenu(ByVal objMenuInfo As MenuInfo) As String
            Return DataProvider.Instance.ExecuteScalar("sp_InsMENU", _
                                                        objMenuInfo.MenuID, _
                                                        objMenuInfo.TabCode, _
                                                        objMenuInfo.ItemCode, _
                                                        objMenuInfo.ItemName, _
                                                        objMenuInfo.Target, _
                                                        objMenuInfo.TargetChild, _
                                                        objMenuInfo.MenuOrder)
        End Function

    End Class
End Namespace