Namespace PortalQH
    Public Class TabLoaiHoSoInfo
        Private _HosoID As Integer
        Private _Tabcode As String
        Private _MaLoaiHoSo As String


        Public Property HosoID() As Integer
            Get
                Return _HosoID
            End Get
            Set(ByVal Value As Integer)
                _HosoID = Value
            End Set
        End Property
        Public Property TabCode() As String
            Get
                Return _Tabcode
            End Get
            Set(ByVal Value As String)
                _Tabcode = Value
            End Set
        End Property
        Public Property MaLoaiHoSo() As String
            Get
                Return _MaLoaiHoSo
            End Get
            Set(ByVal Value As String)
                _MaLoaiHoSo = Value
            End Set
        End Property
        Public Sub ResetAll()
            _Tabcode = ""
            _MaLoaiHoSo = ""
        End Sub
    End Class


    Public Class TabLoaiHoSoController
        Public Function GetLoaiHoSo(ByVal obj As TabLoaiHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getLoaiHoSo", obj.TabCode)
        End Function
        Public Function GetLoaiHoSoByLinhVuc(ByVal obj As TabLoaiHoSoInfo, ByVal MaLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getLoaiHoSoByLinhVuc", obj.TabCode, MaLinhVuc)
        End Function
        Public Sub AddLoaiHoSo(ByVal obj As TabLoaiHoSoInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_insTabLoaiHoSo", obj.MaLoaiHoSo, obj.TabCode)
        End Sub
        Public Sub DelLoaiHoSo(ByVal obj As TabLoaiHoSoInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_delTabLoaiHoSo", obj.TabCode)
        End Sub
    End Class
End Namespace
