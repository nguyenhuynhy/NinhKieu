Namespace PortalQH
    Public Class NguoiChuyenNhanInfo
        Private _TabCode As String
        Private _ItemCode As String
        Private _MaLinhVuc As String
        Private _UserNane As String
        Private _Loai As String

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
        Public Property UserNane() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _UserNane
            End Get
            Set(ByVal Value As String)
                _UserNane = Value
            End Set
        End Property

        Public Property Loai() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _Loai
            End Get
            Set(ByVal Value As String)
                _Loai = Value
            End Set
        End Property
        Public Sub ResetAll()
            _MaLinhVuc = ""
            _TabCode = ""
            _ItemCode = ""
            _UserNane = ""
            _Loai = ""

        End Sub
    End Class
    Public Class NguoiChuyenNhanController
        Public Function GetNguoiChuyenNhan(ByVal obj As NguoiChuyenNhanInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNguoiChuyenNhan", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.Loai)
        End Function
        Public Sub AddNguoiChuyenNhan(ByVal obj As NguoiChuyenNhanInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsNguoiChuyenNhan", _
                                                                    obj.TabCode, _
                                                                    obj.ItemCode, _
                                                                    obj.MaLinhVuc, _
                                                                    obj.UserNane, _
                                                                    obj.Loai)
        End Sub
        Public Sub DelNguoiChuyenNhan(ByVal obj As NguoiChuyenNhanInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelNguoiChuyenNhan", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.Loai)
        End Sub
    End Class
End Namespace