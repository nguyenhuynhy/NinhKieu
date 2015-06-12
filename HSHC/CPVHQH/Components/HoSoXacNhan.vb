Imports PortalQH
Namespace CPVHQH
    Public Class HoSoXacNhanInfo
        Private _HoSoXacNhanID As String
        Private _HoSoTiepNhanID As String
        Private _NgayXacNhan As String
        Private _HoTen As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _DienTich As Single
        Private _DiaChiThuongTru As String
        Private _MaSoLanhDao As String
        Private _MaNganhKinhDoanh As String
        Private _GioiTinh As String
        Private _TinhTrangHienTai As String
        Private _MaSoNguoiSuDung As String
        Private _GhiChu As String
        Private _NoiDungKinhDoanh As String
        Private _MaLinhVuc As String
        Private _TabCode As String
        Private _MaNguoiTacNghiep As String

        Public Property HoSoXacNhanID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _HoSoXacNhanID
            End Get
            Set(ByVal Value As String)
                _HoSoXacNhanID = Value
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
        Public Property NgayXacNhan() As String
            Get
                Return _NgayXacNhan
            End Get
            Set(ByVal Value As String)
                _NgayXacNhan = Value
            End Set
        End Property
        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
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
        Public Property DienTich() As Single
            Get
                Return _DienTich
            End Get
            Set(ByVal Value As Single)
                _DienTich = Value
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
        Public Property MaSoLanhDao() As String
            Get
                Return _MaSoLanhDao
            End Get
            Set(ByVal Value As String)
                _MaSoLanhDao = Value
            End Set
        End Property
        Public Property MaNganhKinhDoanh() As String
            Get
                Return _MaNganhKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MaNganhKinhDoanh = Value
            End Set
        End Property
        Public Property GioiTinh() As String
            Get
                Return _GioiTinh
            End Get
            Set(ByVal Value As String)
                _GioiTinh = Value
            End Set
        End Property
        Public Property TinhTrangHienTai() As String
            Get
                Return _TinhTrangHienTai
            End Get
            Set(ByVal Value As String)
                _TinhTrangHienTai = Value
            End Set
        End Property
        Public Property MaSoNguoiSuDung() As String
            Get
                Return _MaSoNguoiSuDung
            End Get
            Set(ByVal Value As String)
                _MaSoNguoiSuDung = Value
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
        Public Property NoiDungKinhDoanh() As String
            Get
                Return _NoiDungKinhDoanh
            End Get
            Set(ByVal Value As String)
                _NoiDungKinhDoanh = Value
            End Set
        End Property
        Public Property MaLinhVuc() As String
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property
        Public Property TabCode() As String
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
    End Class
    Public Class DiaChiInfo
        Private _DiaChiID As String
        Private _HoSoTiepNhanID As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _DienTich As String
        Public Property DiaChiID() As String
            Get
                Return _DiaChiID
            End Get
            Set(ByVal Value As String)
                _DiaChiID = Value
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
        Public Property DienTich() As String
            Get
                Return _DienTich
            End Get
            Set(ByVal Value As String)
                _DienTich = Value
            End Set
        End Property
    End Class
    'Public Class HoSoXacNhanController
    '    Public Sub AddHoSoXacNhan(ByVal obj As HoSoXacNhanInfo)

    '        DataProvider.Instance.ExecuteQueryStoreProc("sp_InsHoSoXacNhan", obj.HoSoXacNhanID, _
    '        obj.HoSoTiepNhanID, obj.NgayXacNhan, obj.HoTen, obj.SoNha, obj.MaDuong, obj.MaPhuong, _
    '        obj.DiaChiThuongTru, obj.MaSoLanhDao, obj.MaNganhKinhDoanh, obj.GioiTinh, obj.TinhTrangHienTai, _
    '        obj.MaSoNguoiSuDung, obj.GhiChu, obj.NoiDungKinhDoanh, obj.MaLinhVuc, obj.TabCode, obj.MaNguoiTacNghiep)
    '    End Sub

    Public Class HoSoXacNhanController
        Public Function AddHoSoXacNhan(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsHoSoXacNhan", obj)
        End Function
        Public Function GetHoSoXacNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_getHoSoXacNhan", obj)
        End Function
        Public Sub DelHoSoXacNhan(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelHoSoXacNhan", obj)
        End Sub
        Public Function GetDiaChi(ByVal pHoSoTiepNhanId As String) As DataSet
            ' DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_getDiaChi")
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDiaChi", pHoSoTiepNhanId)

        End Function
        Public Sub DelDiaChi(ByVal obj As DiaChiInfo)
            'DataProvider.Instance.ExecuteQueryStoreProc("sp_DelDiaChi", pDiaChiID)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelDiaChi", obj.DiaChiID)
        End Sub
        Public Sub InsDiaChi(ByVal obj As DiaChiInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsDiaChi", obj.DiaChiID, obj.HoSoTiepNhanID, obj.SoNha, obj.MaDuong, obj.MaPhuong, obj.DienTich)
        End Sub
        Public Sub DelDiaChiForUpdate(ByVal obj As DiaChiInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelAllDiaChiForUpdate", obj.HoSoTiepNhanID)
        End Sub
    End Class

    'Public Function GetHoSoXacNhan(ByVal obj As HoSoXacNhanInfo) As DataSet
    '    Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getHoSoXacNhan", obj.HoSoTiepNhanID)
    'End Function

    ''Public Sub DelHoSoXacNhan(ByVal obj As HoSoXacNhanInfo)
    ''    DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelHoSoXacNhan", obj.HoSoXacNhanID, obj.MaLinhVuc, obj.TabCode, obj.MaNguoiTacNghiep)
    ''End Sub
    'Public Sub DelHoSoXacNhan(ByVal obj As HoSoXacNhanInfo)
    '    DataProvider.Instance.ExecuteQueryStoreProc("sp_DelHoSoXacNhan", obj.HoSoTiepNhanID, obj.MaLinhVuc, obj.TabCode, obj.MaNguoiTacNghiep)
    'End Sub
    'End Class
End Namespace