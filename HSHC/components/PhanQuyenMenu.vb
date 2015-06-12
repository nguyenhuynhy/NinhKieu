Namespace PortalQH
    Public Class PhanQuyenMenuInfo
        Private _iMenuID As Integer
        Private _iTabCode As Integer
        Private _sItemCode As String
        Private _sItemName As String
        Private _sTarget As String
        Private _sTargetChild As String
        Private _iMenuOrder As Integer
        Private _iIsCheckUser As Integer
        Public Property MenuID() As Integer
            Get
                Return _iMenuID
            End Get
            Set(ByVal Value As Integer)
                _iMenuID = Value
            End Set
        End Property
        Public Property TabCode() As Integer
            Get
                Return _iTabCode
            End Get
            Set(ByVal Value As Integer)
                _iTabCode = Value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                Return _sItemCode
            End Get
            Set(ByVal Value As String)
                _sItemCode = Value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                Return _sItemName
            End Get
            Set(ByVal Value As String)
                _sItemName = Value
            End Set
        End Property
        Public Property Target() As String
            Get
                Return _sTarget
            End Get
            Set(ByVal Value As String)
                _sTarget = Value
            End Set
        End Property
        Public Property TargetChild() As String
            Get
                Return _sTargetChild
            End Get
            Set(ByVal Value As String)
                _sTargetChild = Value
            End Set
        End Property
        Public Property MenuOrder() As Integer
            Get
                Return _iMenuOrder
            End Get
            Set(ByVal Value As Integer)
                _iMenuOrder = Value
            End Set
        End Property
        Public Property IsCheckUser() As Integer
            Get
                Return _iIsCheckUser
            End Get
            Set(ByVal Value As Integer)
                _iIsCheckUser = Value
            End Set
        End Property

    End Class
    Public Class PhanQuyenMenuController
        Public Function AddMenu(ByVal objPQMenuInfo As PhanQuyenMenuInfo) As String
            Return DataProvider.Instance.ExecuteScalar("sp_InsPQMenu", objPQMenuInfo.MenuID, _
                                                        objPQMenuInfo.TabCode, _
                                                        objPQMenuInfo.ItemCode, _
                                                        objPQMenuInfo.ItemName, _
                                                        objPQMenuInfo.Target, _
                                                        objPQMenuInfo.TargetChild, _
                                                        objPQMenuInfo.MenuOrder, _
                                                        objPQMenuInfo.IsCheckUser)
        End Function
        Public Sub DelMenu(ByVal sItemCode As String)
            DataProvider.Instance.ExecuteScalar("sp_DelPQMenu", sItemCode)
        End Sub
        Public Function LstMenu(ByVal sItemCode As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_LstPQMenu", sItemCode)
        End Function
    End Class
End Namespace