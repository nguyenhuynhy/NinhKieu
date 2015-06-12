Imports PortalQH
Namespace CPKTQH
    <Serializable()> Public Class TimKiemHoSoInfo
        Private _LoaiTimKiem As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _SoBienNhan As String
        Private _HoTen As String
        Private _MaLoaiHoSo As String
        Private _MaTinhTrang As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _URL As String
        Private _LoaiHoSo As String
        'Private _LoaiHinh As String
        Private _NguoiThuLy As String
        Private _LoaiTiepNhanHoSo As String     ' 0: tại chỗ, 1: qua mạng, khác: không quan tâm
        Private _SoGiayPhep As String

        Public Property LoaiTimKiem() As String
            Get
                Return _LoaiTimKiem
            End Get
            Set(ByVal Value As String)
                _LoaiTimKiem = Value
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
        Public Property SoBienNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _SoBienNhan
            End Get
            Set(ByVal Value As String)
                _SoBienNhan = Value
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
        Public Property MaLoaiHoSo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _MaLoaiHoSo
            End Get
            Set(ByVal Value As String)
                _MaLoaiHoSo = Value
            End Set
        End Property
        Public Property MaTinhTrang() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _MaTinhTrang
            End Get
            Set(ByVal Value As String)
                _MaTinhTrang = Value
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

        Public Property LoaiHoSo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _LoaiHoSo
            End Get
            Set(ByVal Value As String)
                _LoaiHoSo = Value
            End Set
        End Property

        'Public Property LoaiHinh() As String
        '    Get
        '        Return _LoaiHinh
        '    End Get
        '    Set(ByVal Value As String)
        '        _LoaiHinh = Value
        '    End Set
        'End Property

        Public Property NguoiThuLy() As String
            Get
                Return _NguoiThuLy
            End Get
            Set(ByVal Value As String)
                _NguoiThuLy = Value
            End Set
        End Property

        Public Property LoaiTiepNhanHoSo() As String
            Get
                Return _LoaiTiepNhanHoSo
            End Get
            Set(ByVal Value As String)
                _LoaiTiepNhanHoSo = Value
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
    End Class

    Public Class TimKiemHoSoController
        Public Function LayDanhSachHoSo_DangXuLy(ByVal obj As TimKiemHoSoInfo) As DataSet
            Dim strStoreName As String
            Select Case obj.LoaiHoSo
                Case HS_CAPMOICNDKKD
                    strStoreName = "sp_GetListGiayCNDKKD"
                Case HS_DONVITRUCTHUOC
                Case HS_HOSOKHONG
                Case HS_HUYCNDKKD
                Case HS_THAYDOIDKKD
            End Select
            Return DataProvider.Instance.ExecuteQueryStoreProc(strStoreName, _
                                                                obj.TuNgay, _
                                                                obj.DenNgay, _
                                                                obj.SoBienNhan, _
                                                                obj.HoTen, _
                                                                obj.MaLoaiHoSo, _
                                                                obj.MaTinhTrang, _
                                                                obj.SoNha, _
                                                                obj.MaDuong, _
                                                                obj.MaPhuong, _
                                                                obj.URL)
        End Function
        Public Function LayDanhSachHoSo_ChuaXuLy(ByVal obj As TimKiemHoSoInfo) As DataSet
            Dim strStoreName As String
            Select Case obj.LoaiHoSo
                Case HS_CAPMOICNDKKD
                    strStoreName = "sp_GetListHoSoChuaXuLy"
                Case HS_DONVITRUCTHUOC
                Case HS_HOSOKHONG
                Case HS_HUYCNDKKD
                Case HS_THAYDOIDKKD
            End Select
            Return DataProvider.Instance.ExecuteQueryStoreProc(strStoreName, _
                                                                obj.TuNgay, _
                                                                obj.DenNgay, _
                                                                obj.SoBienNhan, _
                                                                obj.HoTen, _
                                                                obj.MaLoaiHoSo, _
                                                                obj.MaTinhTrang, _
                                                                obj.SoNha, _
                                                                obj.MaDuong, _
                                                                obj.MaPhuong, _
                                                                obj.URL)
        End Function

        Public Function TimKiemHoSo(ByVal objTimKiem As TimKiemHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_TimKiemHoSo", _
                                                                objTimKiem.MaLoaiHoSo, _
                                                                objTimKiem.MaTinhTrang, _
                                                                objTimKiem.SoBienNhan, _
                                                                objTimKiem.TuNgay, _
                                                                objTimKiem.DenNgay, _
                                                                objTimKiem.LoaiTimKiem, _
                                                                objTimKiem.NguoiThuLy, _
                                                                objTimKiem.SoNha, _
                                                                objTimKiem.MaDuong, _
                                                                objTimKiem.MaPhuong, _
                                                                objTimKiem.HoTen, _
                                                                objTimKiem.SoGiayPhep, _
                                                                objTimKiem.LoaiTiepNhanHoSo, _
                                                                objTimKiem.URL)
        End Function
    End Class
End Namespace