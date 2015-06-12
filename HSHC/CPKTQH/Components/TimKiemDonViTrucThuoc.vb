Imports PortalQH
Namespace CPKTQH
    <Serializable()> Public Class TimKiemDonViTrucThuocInfo
        Private _NguoiDungDau As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _HoatDong As String
        Private _SoGiayPhep As String
        Private _TenDoanhNghiep As String
        Private _MaLoaiHinhDoanhNghiep As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _MatHangKinhDoanh As String
        Private _URL As String
        Public Property NguoiDungDau() As String
            Get
                Return _NguoiDungDau
            End Get
            Set(ByVal Value As String)
                _NguoiDungDau = Value.Replace("'", "''")
            End Set
        End Property
        Public Property SoNha() As String
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value.Replace("'", "''")
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
        Public Property HoatDong() As String
            Get
                Return _HoatDong
            End Get
            Set(ByVal Value As String)
                _HoatDong = Value
            End Set
        End Property
        Public Property SoGiayPhep() As String
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value.Replace("'", "''")
            End Set
        End Property
        Public Property TenDoanhNghiep() As String
            Get
                Return _TenDoanhNghiep
            End Get
            Set(ByVal Value As String)
                _TenDoanhNghiep = Value.Replace("'", "''")
            End Set
        End Property

        Public Property MatHangKinhDoanh() As String
            Get
                Return _MatHangKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MatHangKinhDoanh = Value.Replace("'", "''")
            End Set
        End Property
        Public Property MaLoaiHinhDoanhNghiep() As String
            Get
                Return _MaLoaiHinhDoanhNghiep
            End Get
            Set(ByVal Value As String)
                _MaLoaiHinhDoanhNghiep = Value
            End Set
        End Property
        Public Property TuNgay() As String
            Get
                Return _TuNgay
            End Get
            Set(ByVal Value As String)
                _TuNgay = Value
            End Set
        End Property

        Public Property DenNgay() As String
            Get
                Return _DenNgay
            End Get
            Set(ByVal Value As String)
                _DenNgay = Value
            End Set
        End Property
        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
    End Class

    Public Class TimKiemDonViTrucThuocController
        Public Function LayDanhSachDonViTrucThuoc(ByVal obj As TimKiemDonViTrucThuocInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_DonViTruocThuoc_Lst", _
                                                                obj.NguoiDungDau, _
                                                                obj.SoNha, _
                                                                obj.MaDuong, _
                                                                obj.MaPhuong, _
                                                                obj.HoatDong, _
                                                                obj.SoGiayPhep, _
                                                                obj.TenDoanhNghiep, _
                                                                obj.MaLoaiHinhDoanhNghiep, _
                                                                obj.MatHangKinhDoanh, _
                                                                obj.TuNgay, _
                                                                obj.DenNgay, _
                                                                obj.URL)
        End Function
    End Class
End Namespace