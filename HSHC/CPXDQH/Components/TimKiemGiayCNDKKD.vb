Imports PortalQH
Namespace CPXD
    Public Class TimKiemGiayCNDKKDInfo
        Private _TuNgay As String
        Private _DenNgay As String
        Private _SoGiayPhep As String
        Private _HoTen As String
        Private _TinhTrangHienTai As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _NguoiTacNghiep As String
        Private _TabCode As String
        Private _ItemCode As String
        Private _URL As String
        Private _IsHuy As String

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
                _SoGiayPhep = Value
            End Set
        End Property
        Public Property HoTen() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
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
                _SoNha = Value
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
        Public Property NguoiTacNghiep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _NguoiTacNghiep
            End Get
            Set(ByVal Value As String)
                _NguoiTacNghiep = Value
            End Set
        End Property
        Public Property TabCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property ItemCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
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
    End Class
    Public Class TimKiemGiayCNDKKDController
        Public Function LayDanhSachGiayCNDKKD(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GIAYPHEPXAYDUNGList", _
                                                                obj.TuNgay, _
                                                                obj.DenNgay, _
                                                                obj.SoGiayPhep, _
                                                                obj.HoTen, _
                                                                obj.TinhTrangHienTai, _
                                                                obj.SoNha, _
                                                                obj.MaDuong, _
                                                                obj.MaPhuong, _
                                                                obj.IsHuy, _
                                                                obj.NguoiTacNghiep, _
                                                                obj.TabCode, _
                                                                obj.ItemCode)
        End Function
        Public Function LayDanhSachHoCaThe(ByVal TuNgay As String, ByVal DenNgay As String, ByVal MaPhuong As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptXuatRaExcel", _
                                                                TuNgay, _
                                                                DenNgay, _
                                                                MaPhuong)
        End Function
        Public Function DSGiayPhepDauKy(ByVal obj As TimKiemGiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_DSGiayPhepDauKy", _
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

    End Class
End Namespace