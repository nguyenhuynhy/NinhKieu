Imports PortalQH
Namespace CPXD
    Public Class TimKiemGiayPhepXayDungInfo
        Private _TuNgay As String
        Private _DenNgay As String
        Private _SoGiayPhep As String
        Private _HoTen As String
        Private _TinhTrangHienTai As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _URL As String
        Private _IsHuy As String

        Public Property TuNgay() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _TuNgay
            End Get
            Set(ByVal Value As String)
                _TuNgay = Value
            End Set
        End Property
        Public Property DenNgay() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _DenNgay
            End Get
            Set(ByVal Value As String)
                _DenNgay = Value
            End Set
        End Property
        Public Property SoGiayPhep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value
            End Set
        End Property
        Public Property HoTen() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
            End Set
        End Property

        Public Property TinhTrangHienTai() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _TinhTrangHienTai
            End Get
            Set(ByVal Value As String)
                _TinhTrangHienTai = Value
            End Set
        End Property
        Public Property SoNha() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value
            End Set
        End Property
        Public Property MaDuong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _MaDuong
            End Get
            Set(ByVal Value As String)
                _MaDuong = Value
            End Set
        End Property
        Public Property MaPhuong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _MaPhuong
            End Get
            Set(ByVal Value As String)
                _MaPhuong = Value
            End Set
        End Property
        Public Property URL() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
        Public Property IsHuy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayPhepXayDungID
            Get
                Return _IsHuy
            End Get
            Set(ByVal Value As String)
                _IsHuy = Value
            End Set
        End Property
    End Class
    Public Class TimKiemGiayPhepXayDungController
        Public Function LayDanhSachGiayPhepXayDung(ByVal obj As TimKiemGiayPhepXayDungInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayPhepXayDungList", _
                                                                obj.TuNgay, _
                                                                obj.DenNgay, _
                                                                obj.SoGiayPhep, _
                                                                obj.HoTen, _
                                                                obj.TinhTrangHienTai, _
                                                                obj.SoNha, _
                                                                obj.MaDuong, _
                                                                obj.MaPhuong, _
                                                                obj.IsHuy)
        End Function
        Public Function LayDanhSachGiayPhepXuatExcel(ByVal strTuNgay As String, ByVal strDenNgay As String, ByVal MaPhuong As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_XuatThongTinGiayPhepRaExcel", strTuNgay, strDenNgay, MaPhuong)
        End Function
        Public Function LayDanhSachHoCaThe(ByVal TuNgay As String, ByVal DenNgay As String, ByVal MaPhuong As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptXuatRaExcel", _
                                                                TuNgay, _
                                                                DenNgay, _
                                                                MaPhuong)
        End Function

    End Class
End Namespace