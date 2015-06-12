Imports PortalQH
Namespace CPKTQH
    Public Class HoSoTiepNhanInfo
        Private _HoSoTiepNhanID As String
        Private _MaQuan As String
        Private _MaPhuong As String
        Private _MaDuong As String
        Private _NgayThucTra As String
        Private _MaNguoiNhan As String
        Private _NgayHopLe As String
        Private _NgayHenTra As String
        Private _NgayNhan As String
        Private _NoiDungKhac As String
        Private _NoiDungTrichYeu As String
        Private _SoNha As String
        Private _GioiTinh As String
        Private _SoCMND As String
        Private _ThongTinLienLac As String
        Private _DiaChiThuongTru As String
        Private _HoTenNguoiNop As String
        Private _SoBienNhanCu As String
        Private _SoBienNhan As String
        Private _MaTinhTrang As String
        Private _MaLoaiHoSo As String
        Private _MaLinhVuc As String
        Private _LastUpdate As String


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

        Public Property MaQuan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaQuan
            Get
                Return _MaQuan
            End Get
            Set(ByVal Value As String)
                _MaQuan = Value
            End Set
        End Property

        Public Property MaPhuong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaPhuong
            Get
                Return _MaPhuong
            End Get
            Set(ByVal Value As String)
                _MaPhuong = Value
            End Set
        End Property

        Public Property MaDuong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaDuong
            Get
                Return _MaDuong
            End Get
            Set(ByVal Value As String)
                _MaDuong = Value
            End Set
        End Property

        Public Property NgayThucTra() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayThucTra
            Get
                Return _NgayThucTra
            End Get
            Set(ByVal Value As String)
                _NgayThucTra = Value
            End Set
        End Property

        Public Property MaNguoiNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNguoiNhan
            Get
                Return _MaNguoiNhan
            End Get
            Set(ByVal Value As String)
                _MaNguoiNhan = Value
            End Set
        End Property

        Public Property NgayHopLe() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayHopLe
            Get
                Return _NgayHopLe
            End Get
            Set(ByVal Value As String)
                _NgayHopLe = Value
            End Set
        End Property

        Public Property NgayHenTra() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayHenTra
            Get
                Return _NgayHenTra
            End Get
            Set(ByVal Value As String)
                _NgayHenTra = Value
            End Set
        End Property

        Public Property NgayNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayNhan
            Get
                Return _NgayNhan
            End Get
            Set(ByVal Value As String)
                _NgayNhan = Value
            End Set
        End Property

        Public Property NoiDungKhac() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungKhac
            Get
                Return _NoiDungKhac
            End Get
            Set(ByVal Value As String)
                _NoiDungKhac = Value
            End Set
        End Property

        Public Property NoiDungTrichYeu() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungTrichYeu
            Get
                Return _NoiDungTrichYeu
            End Get
            Set(ByVal Value As String)
                _NoiDungTrichYeu = Value
            End Set
        End Property

        Public Property SoNha() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoNha
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value
            End Set
        End Property

        Public Property GioiTinh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GioiTinh
            Get
                Return _GioiTinh
            End Get
            Set(ByVal Value As String)
                _GioiTinh = Value
            End Set
        End Property

        Public Property SoCMND() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoCMND
            Get
                Return _SoCMND
            End Get
            Set(ByVal Value As String)
                _SoCMND = Value
            End Set
        End Property

        Public Property ThongTinLienLac() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ThongTinLienLac
            Get
                Return _ThongTinLienLac
            End Get
            Set(ByVal Value As String)
                _ThongTinLienLac = Value
            End Set
        End Property

        Public Property DiaChiThuongTru() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.DiaChiThuongTru
            Get
                Return _DiaChiThuongTru
            End Get
            Set(ByVal Value As String)
                _DiaChiThuongTru = Value
            End Set
        End Property

        Public Property HoTenNguoiNop() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoTenNguoiNop
            Get
                Return _HoTenNguoiNop
            End Get
            Set(ByVal Value As String)
                _HoTenNguoiNop = Value
            End Set
        End Property

        Public Property SoBienNhanCu() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoBienNhanCu
            Get
                Return _SoBienNhanCu
            End Get
            Set(ByVal Value As String)
                _SoBienNhanCu = Value
            End Set
        End Property

        Public Property SoBienNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoBienNhan
            Get
                Return _SoBienNhan
            End Get
            Set(ByVal Value As String)
                _SoBienNhan = Value
            End Set
        End Property

        Public Property MaTinhTrang() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaTinhTrang
            Get
                Return _MaTinhTrang
            End Get
            Set(ByVal Value As String)
                _MaTinhTrang = Value
            End Set
        End Property

        Public Property MaLoaiHoSo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaLoaiHoSo
            Get
                Return _MaLoaiHoSo
            End Get
            Set(ByVal Value As String)
                _MaLoaiHoSo = Value
            End Set
        End Property

        Public Property MaLinhVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaLinhVuc
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
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
            _HoSoTiepNhanID = ""
            _MaQuan = ""
            _MaPhuong = ""
            _MaDuong = ""
            _NgayThucTra = ""
            _MaNguoiNhan = ""
            _NgayHopLe = ""
            _NgayHenTra = ""
            _NgayNhan = ""
            _NoiDungKhac = ""
            _NoiDungTrichYeu = ""
            _SoNha = ""
            _GioiTinh = ""
            _SoCMND = ""
            _ThongTinLienLac = ""
            _DiaChiThuongTru = ""
            _HoTenNguoiNop = ""
            _SoBienNhanCu = ""
            _SoBienNhan = ""
            _MaTinhTrang = ""
            _MaLoaiHoSo = ""
            _MaLinhVuc = ""
            _LastUpdate = ""
        End Sub

    End Class
    Public Class HoSoTiepNhanController
        Public Function GetChiTietHoSoTiepNhan(ByVal HoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getChiTietHoSoTiepNhan", HoSoTiepNhanID)
        End Function
        Public Function GetSoBienNhan(ByVal HoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GetSoBienNhan", HoSoTiepNhanID)
        End Function
        Public Function GetHoSoTiepNhanID(ByVal SoBienNhan As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GetHoSoTiepNhanID", SoBienNhan)
        End Function

        Public Function DangYeuCauBoSung(ByVal pHoSoTiepNhanID As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_HoSoBoSung_Check", pHoSoTiepNhanID)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function DangKhongGiaiQuyet(ByVal pHoSoTiepNhanID As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_HoSoKhongGiaiQuyet_Check", pHoSoTiepNhanID)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function DangDeXuat(ByVal pHoSoTiepNhanID As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_DeXuat_Check", pHoSoTiepNhanID)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function
    End Class
End Namespace

