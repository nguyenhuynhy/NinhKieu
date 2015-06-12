Imports PortalQH
Namespace CPKTQH
    Public Class HoSoBoSungInfo
        Private _HoSoBoSungID As String
        Private _NgayYeuCau As String
        Private _NoiDungYeuCau As String
        Private _SoNgayBoSung As Long
        Private _HoSoTiepNhanID As String
        Private _LanhDaoKy As String
        Private _GhiChu As String
        Private _MaNguoiThaoTac As String
        Private _LastUpdate As String


        Public Property HoSoBoSungID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _HoSoBoSungID
            End Get
            Set(ByVal Value As String)
                _HoSoBoSungID = Value
            End Set
        End Property

        Public Property NgayYeuCau() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayYeuCau
            Get
                Return _NgayYeuCau
            End Get
            Set(ByVal Value As String)
                _NgayYeuCau = Value
            End Set
        End Property

        Public Property NoiDungYeuCau() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungYeuCau
            Get
                Return _NoiDungYeuCau
            End Get
            Set(ByVal Value As String)
                _NoiDungYeuCau = Value
            End Set
        End Property

        Public Property SoNgayBoSung() As Long
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoNgayBoSung
            Get
                Return _SoNgayBoSung
            End Get
            Set(ByVal Value As Long)
                _SoNgayBoSung = Value
            End Set
        End Property

        Public Property HoSoTiepNhanID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoTiepNhanID
            Get
                Return _HoSoTiepNhanID
            End Get
            Set(ByVal Value As String)
                _HoSoTiepNhanID = Value
            End Set
        End Property

        Public Property LanhDaoKy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LanhDaoKy
            Get
                Return _LanhDaoKy
            End Get
            Set(ByVal Value As String)
                _LanhDaoKy = Value
            End Set
        End Property

        Public Property GhiChu() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GhiChu
            Get
                Return _GhiChu
            End Get
            Set(ByVal Value As String)
                _GhiChu = Value
            End Set
        End Property

        Public Property MaNguoiThaoTac() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNguoiThaoTac
            Get
                Return _MaNguoiThaoTac
            End Get
            Set(ByVal Value As String)
                _MaNguoiThaoTac = Value
            End Set
        End Property

        Public Property LastUpdate() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _LastUpdate
            End Get
            Set(ByVal Value As String)
                _LastUpdate = Value
            End Set
        End Property
        Public Sub ResetAll()
            _HoSoBoSungID = ""
            _NgayYeuCau = Nothing
            _NoiDungYeuCau = ""
            _SoNgayBoSung = 0
            _HoSoTiepNhanID = ""
            _LanhDaoKy = ""
            _GhiChu = ""
            _MaNguoiThaoTac = ""
            _LastUpdate = Nothing
        End Sub


    End Class
    Public Class HoSoBoSungController
        Public Function GetHoSoBoSung(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSung", pID)
        End Function
        Public Function UpdHoSoBoSung(ByVal obj As Object) As String
            'return "" khong thanh cong <> hosobosungid thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHoSoBoSung", obj)
        End Function
        'AnhLH
        Public Function AddHoSoBoSung(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsHoSoBoSung", obj)
            'DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_InsHoSoBoSung", obj)
        End Function
        Public Function GetHoSoBoSungBySoBienNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetHoSoBoSungBySoBienNhan", obj)
        End Function
        Public Function GetHoSoBoSungBySoBienNhan(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSungBySoBienNhan", pSoBienNhan)
        End Function
        Public Function GetQuaHanBoSung(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetQuaHanBoSung", pSoBienNhan)
        End Function
        Public Function InThongBaoYeuCauBoSungHoSo(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuYeuCauBoSungHoSo", strHoSoTiepNhanID)
        End Function
    End Class
End Namespace
