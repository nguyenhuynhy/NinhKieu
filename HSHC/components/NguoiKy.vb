Namespace PortalQH
    Public Class NguoiKyInfo
        Private _TabCode As String
        Private _ItemCode As String
        Private _MaLinhVuc As String
        Private _UserName As String

        Public Property TabCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property ItemCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
            End Set
        End Property
        Public Property MaLinhVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property
        Public Property UserName() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _UserName
            End Get
            Set(ByVal Value As String)
                _UserName = Value
            End Set
        End Property


        Public Sub ResetAll()
            _MaLinhVuc = ""
            _TabCode = ""
            _ItemCode = ""
            _UserName = ""
        End Sub

    End Class
    Public Class NguoiKyController
        Public Function GetNguoiKy(ByVal obj As NguoiKyInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNguoiKy", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode)
        End Function
        Public Sub AddNguoiKy(ByVal obj As NguoiKyInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsNguoiKy", _
                                                                    obj.TabCode, _
                                                                    obj.ItemCode, _
                                                                    obj.MaLinhVuc, _
                                                                    obj.UserName)
        End Sub
        Public Sub DelNguoiKy(ByVal obj As NguoiKyInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelNguoiKy", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.UserName)
        End Sub
    End Class
End Namespace