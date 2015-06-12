Imports PortalQH
Namespace CPKTQH
    <Serializable()> Public Class TimKiemGiayCNDKKDInfo
        Private _TabCode As String
        Private _LoaiHinh As String
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
        Private _MatHang As String
        Private _LinhVucCapPhep As String
        Private _MaNganh As String
        Private _BangHieu As String
        Private _PhuongThucKinhDoanh As String
        Private _SoCMND As String

        Public Property TabCode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property SoCMND() As String
            Get
                Return _SoCMND
            End Get
            Set(ByVal Value As String)
                _SoCMND = Value
            End Set
        End Property

        Public Property LoaiHinh() As String
            Get
                Return _LoaiHinh
            End Get
            Set(ByVal Value As String)
                _LoaiHinh = Value
            End Set
        End Property

        Public Property TuNgay() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _TuNgay
            End Get
            Set(ByVal Value As String)
                _TuNgay = Value
            End Set
        End Property
        Public Property DenNgay() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _DenNgay
            End Get
            Set(ByVal Value As String)
                _DenNgay = Value
            End Set
        End Property
        Public Property SoGiayPhep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value.Replace("'", "''")
            End Set
        End Property
        Public Property HoTen() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value.Replace("'", "''")
            End Set
        End Property

        Public Property TinhTrangHienTai() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _TinhTrangHienTai
            End Get
            Set(ByVal Value As String)
                _TinhTrangHienTai = Value
            End Set
        End Property
        Public Property SoNha() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value.Replace("'", "''")
            End Set
        End Property
        Public Property MaDuong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _MaDuong
            End Get
            Set(ByVal Value As String)
                _MaDuong = Value
            End Set
        End Property
        Public Property MaPhuong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _MaPhuong
            End Get
            Set(ByVal Value As String)
                _MaPhuong = Value
            End Set
        End Property
        Public Property URL() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
        Public Property IsHuy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _IsHuy
            End Get
            Set(ByVal Value As String)
                _IsHuy = Value
            End Set
        End Property

        Public Property MatHang() As String
            Get
                Return _MatHang
            End Get
            Set(ByVal Value As String)
                _MatHang = Value.Replace("'", "''")
            End Set
        End Property
        Public Property LinhVucCapPhep() As String
            Get
                Return _LinhVucCapPhep
            End Get
            Set(ByVal Value As String)
                _LinhVucCapPhep = Value
            End Set
        End Property
        Public Property MaNganh() As String
            Get
                Return _MaNganh
            End Get
            Set(ByVal Value As String)
                _MaNganh = Value
            End Set
        End Property
        Public Property BangHieu() As String
            Get
                'Return _BangHieu.Replace("'", "''")
                Return _BangHieu
            End Get
            Set(ByVal Value As String)
                _BangHieu = Value
            End Set
        End Property
        Public Property PhuongThucKinhDoanh() As String
            Get
                Return _PhuongThucKinhDoanh
            End Get
            Set(ByVal Value As String)
                _PhuongThucKinhDoanh = Value
            End Set
        End Property
    End Class

    Public Class TimKiemGiayCNDKKDController
        Public Function LayDanhSachTamNgungDKKD(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayTamNgungDKKD_Lst", _
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

        Public Function LayDanhSachGiayCNDKKD(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_Lst", _
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
        Public Function LayDanhSachHoCaThe(ByVal TuNgay As String, ByVal DenNgay As String, ByVal MaPhuong As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptXuatRaExcel", _
                                                                TuNgay, _
                                                                DenNgay, _
                                                                MaPhuong)
        End Function
        Public Function DSHoKDCaTheDauKy(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_DSHoKDCaTheDauKy", _
                                                                obj.TuNgay, _
                                                                obj.DenNgay, _
                                                                obj.SoGiayPhep, _
                                                                obj.HoTen, _
                                                                obj.TinhTrangHienTai, _
                                                                obj.SoNha, _
                                                                obj.MaDuong, _
                                                                obj.MaPhuong, _
                                                                obj.IsHuy, _
                                                                obj.URL)
        End Function

        Public Function getDanhSachGCNDKKD(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_LstChung", _
                                                                    obj.TuNgay, _
                                                                    obj.DenNgay, _
                                                                    obj.SoGiayPhep, _
                                                                    obj.HoTen, _
                                                                    obj.SoCMND, _
                                                                    obj.TinhTrangHienTai, _
                                                                    obj.SoNha, _
                                                                    obj.MaDuong, _
                                                                    obj.MaPhuong, _
                                                                    obj.LoaiHinh, _
                                                                    obj.MatHang, _
                                                                    obj.LinhVucCapPhep, _
                                                                    obj.MaNganh, _
                                                                    obj.BangHieu, _
                                                                    obj.URL, _
                                                                    "", _
                                                                    obj.PhuongThucKinhDoanh)
        End Function
        Public Function getDanhSachTamNgungDKKD(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_LstChung", _
                                                                    obj.TuNgay, _
                                                                    obj.DenNgay, _
                                                                    obj.SoGiayPhep, _
                                                                    obj.HoTen, _
                                                                    obj.TinhTrangHienTai, _
                                                                    obj.SoNha, _
                                                                    obj.MaDuong, _
                                                                    obj.MaPhuong, _
                                                                    obj.LoaiHinh, _
                                                                    obj.MatHang, _
                                                                    obj.LinhVucCapPhep, _
                                                                    obj.MaNganh, _
                                                                    obj.BangHieu, _
                                                                    obj.URL, _
                                                                    "TAMNGUNG", _
                                                                    obj.PhuongThucKinhDoanh)
        End Function
    End Class
End Namespace