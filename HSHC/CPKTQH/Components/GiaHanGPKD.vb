Imports PortalQH
Namespace CPKTQH
    Public Class GiaHanGPKDInfo
        Private _GiaHanGPKDID As String
        Private _SoBNhan As String
        Private _SoGiayPhep As String
        Private _NgayCap As String
        Private _NgayGiaHan As String
        Private _GiaHanDen As String
        Private _HoTen As String
        Private _DiaChiThuongTru As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _MaSoLanhDao As String
        Private _GhiChu As String
        Private _HoSoTiepNhanID As String
        Private _MaLinhVuc As String
        Private _TabCode As String
        Private _MaNguoiTacNghiep As String

        Public Property MaLinhVuc() As String
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                MaLinhVuc = Value
            End Set
        End Property
        Public Property Tabcode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property MaNguoiTacNghiep() As String
            Get
                Return _MaNguoiTacNghiep
            End Get
            Set(ByVal Value As String)
                _MaNguoiTacNghiep = Value
            End Set
        End Property

        Public Property GiaHanGPKDID() As String
            Get
                Return _GiaHanGPKDID
            End Get
            Set(ByVal Value As String)
                _GiaHanGPKDID = Value
            End Set
        End Property
        Public Property SoBNhan() As String
            Get
                Return _SoBNhan
            End Get
            Set(ByVal Value As String)
                _SoBNhan = Value
            End Set
        End Property
        Public Property SoGiayPhep() As String
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value
            End Set
        End Property
        Public Property NgayCap() As String
            Get
                Return _NgayCap
            End Get
            Set(ByVal Value As String)
                NgayCap = Value
            End Set
        End Property
        Public Property NgayGiaHan() As String
            Get
                Return _NgayGiaHan
            End Get
            Set(ByVal Value As String)
                _NgayGiaHan = Value
            End Set
        End Property
        Public Property GiaHanDen() As String
            Get
                Return _GiaHanDen
            End Get
            Set(ByVal Value As String)
                _GiaHanDen = Value
            End Set
        End Property
        Public Property Hoten() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
            End Set
        End Property
        Public Property DiaChiThuongTru() As String
            Get
                Return _DiaChiThuongTru
            End Get
            Set(ByVal Value As String)
                _DiaChiThuongTru = Value
            End Set
        End Property
        Public Property SoNha() As String
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value
            End Set
        End Property
        Public Property MaDuong() As String
            Get
                Return _MaDuong
            End Get
            Set(ByVal Value As String)
                _MaDuong = Value
            End Set
        End Property
        Public Property MaPhuong() As String
            Get
                Return _MaPhuong
            End Get
            Set(ByVal Value As String)
                _MaPhuong = Value
            End Set
        End Property
        Public Property MaSoLanhDao() As String
            Get
                Return _MaSoLanhDao
            End Get
            Set(ByVal Value As String)
                _MaSoLanhDao = Value
            End Set
        End Property
        Public Property GhiChu() As String
            Get
                Return _GhiChu
            End Get
            Set(ByVal Value As String)
                _GhiChu = Value
            End Set
        End Property
        Public Property HoSoTiepNhanID() As String
            Get
                Return _HoSoTiepNhanID
            End Get
            Set(ByVal Value As String)
                _HoSoTiepNhanID = Value
            End Set
        End Property
    End Class
    Public Class GiaHanGPKDController
        'ThuyTT begin date 20/10/2005
        Public Function getGiaHanID(ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GiaHanGPKD_GetID", pHoSoTiepNhanID)
        End Function
        Public Function GetGiaHanGPKD(ByVal pGiaHanGPKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiaHanGPKD_Get", pGiaHanGPKDID)
        End Function
        Public Function UpdGiaHanGPKD(ByVal obj As Object) As Boolean
            Return CBool(DataProvider.Instance.ExecuteScalarAuto("sp_GiaHanGPKD_Upd", obj))
        End Function
        Public Function DelGiaHanGPKD(ByVal pGiaHanGPKDID As String) As Boolean
            Return CBool(DataProvider.Instance.ExecuteScalar("sp_GiaHanGPKD_Del", pGiaHanGPKDID))
        End Function
        
        'ThuyTT end
    End Class
End Namespace
