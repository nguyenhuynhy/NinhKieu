Imports PortalQH
Namespace CPXD
    Public Class GiayCNDKKDInfo
        Private _GiayCNDKKDID As String
        Private _SoGiayPhep As String
        Private _NgayCap As String
        Private _SoGiayPhepGoc As String
        Private _NgayCapGoc As String
        Private _SoGiayPhepTruoc As String
        Private _NgayCapGiayPhepTruoc As String
        Private _TinhTrangHienTai As String
        Private _MatHangKinhDoanh As String
        Private _BangHieu As String
        Private _VonKinhDoanh As String
        Private _VonCoDinh As String
        Private _VonLuuDong As String
        Private _MaSoLanhDao As String
        Private _MaSoNguoiSuDung As String
        Private _GhiChu As String
        Private _MaNganh As String
        Private _MaPhuongThucKinhDoanh As String
        Private _MaHinhThucKinhDoanh As String
        Private _MaTinhTrang As String
        Private _LastUpdate As String


        Public Property GiayCNDKKDID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GiayCNDKKDID
            Get
                Return _GiayCNDKKDID
            End Get
            Set(ByVal Value As String)
                _GiayCNDKKDID = Value
            End Set
        End Property

        Public Property SoGiayPhep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoGiayPhep
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value
            End Set
        End Property

        Public Property NgayCap() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayCap
            Get
                Return _NgayCap
            End Get
            Set(ByVal Value As String)
                _NgayCap = Value
            End Set
        End Property

        Public Property SoGiayPhepGoc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoGiayPhepGoc
            Get
                Return _SoGiayPhepGoc
            End Get
            Set(ByVal Value As String)
                _SoGiayPhepGoc = Value
            End Set
        End Property

        Public Property NgayCapGoc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayCapGoc
            Get
                Return _NgayCapGoc
            End Get
            Set(ByVal Value As String)
                _NgayCapGoc = Value
            End Set
        End Property

        Public Property SoGiayPhepTruoc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoGiayPhepTruoc
            Get
                Return _SoGiayPhepTruoc
            End Get
            Set(ByVal Value As String)
                _SoGiayPhepTruoc = Value
            End Set
        End Property

        Public Property NgayCapGiayPhepTruoc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayCapGiayPhepTruoc
            Get
                Return _NgayCapGiayPhepTruoc
            End Get
            Set(ByVal Value As String)
                _NgayCapGiayPhepTruoc = Value
            End Set
        End Property

        Public Property TinhTrangHienTai() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.TinhTrangHienTai
            Get
                Return _TinhTrangHienTai
            End Get
            Set(ByVal Value As String)
                _TinhTrangHienTai = Value
            End Set
        End Property

        Public Property MatHangKinhDoanh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MatHangKinhDoanh
            Get
                Return _MatHangKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MatHangKinhDoanh = Value
            End Set
        End Property

        Public Property BangHieu() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.BangHieu
            Get
                Return _BangHieu
            End Get
            Set(ByVal Value As String)
                _BangHieu = Value
            End Set
        End Property

        Public Property VonKinhDoanh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.VonKinhDoanh
            Get
                Return _VonKinhDoanh
            End Get
            Set(ByVal Value As String)
                _VonKinhDoanh = Value
            End Set
        End Property

        Public Property VonCoDinh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.VonCoDinh
            Get
                Return _VonCoDinh
            End Get
            Set(ByVal Value As String)
                _VonCoDinh = Value
            End Set
        End Property

        Public Property VonLuuDong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.VonLuuDong
            Get
                Return _VonLuuDong
            End Get
            Set(ByVal Value As String)
                _VonLuuDong = Value
            End Set
        End Property

        Public Property MaSoLanhDao() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaSoLanhDao
            Get
                Return _MaSoLanhDao
            End Get
            Set(ByVal Value As String)
                _MaSoLanhDao = Value
            End Set
        End Property

        Public Property MaSoNguoiSuDung() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaSoNguoiSuDung
            Get
                Return _MaSoNguoiSuDung
            End Get
            Set(ByVal Value As String)
                _MaSoNguoiSuDung = Value
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

        Public Property MaNganh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNganh
            Get
                Return _MaNganh
            End Get
            Set(ByVal Value As String)
                _MaNganh = Value
            End Set
        End Property

        Public Property MaPhuongThucKinhDoanh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaPhuongThucKinhDoanh
            Get
                Return _MaPhuongThucKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MaPhuongThucKinhDoanh = Value
            End Set
        End Property

        Public Property MaHinhThucKinhDoanh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaHinhThucKinhDoanh
            Get
                Return _MaHinhThucKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MaHinhThucKinhDoanh = Value
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
            _GiayCNDKKDID = ""
            _SoGiayPhep = ""
            _NgayCap = Nothing
            _SoGiayPhepGoc = ""
            _NgayCapGoc = Nothing
            _SoGiayPhepTruoc = ""
            _NgayCapGiayPhepTruoc = Nothing
            _TinhTrangHienTai = ""
            _MatHangKinhDoanh = ""
            _BangHieu = ""
            _VonKinhDoanh = ""
            _VonCoDinh = ""
            _VonLuuDong = ""
            _MaSoLanhDao = ""
            _MaSoNguoiSuDung = ""
            _GhiChu = ""
            _MaNganh = ""
            _MaPhuongThucKinhDoanh = ""
            _MaHinhThucKinhDoanh = ""
            _MaTinhTrang = ""
            _LastUpdate = Nothing
        End Sub


    End Class

    Public Class GiayCNDKKDController
        Public Function AddGIAYCNDKKD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGIAYPHEPXAYDUNG", obj)
        End Function
        Public Function AddGIAYCNDKKD_CD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGIAYPHEPXAYDUNG_CD", obj)
        End Function
        Public Sub DelGIAYCNDKKD(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelGIAYPHEPXAYDUNG", obj)
        End Sub
        Public Function GetGiayCNDKKD_New(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGIAYPHEPXAYDUNG_New", pHoSoTiepNhanID)
        End Function
        Public Function GetGiayCNDKKD_Edit(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGIAYPHEPXAYDUNG_Edit", pHoSoTiepNhanID)
        End Function
        Public Function getNganhKinhDoanh(ByVal pMaNganh As String, ByVal pTenNganh As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNganhKinhDoanh", pMaNganh, pTenNganh)
        End Function
        Public Function getNganhKinhDoanh(ByVal pTenNganh As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_searchNganhKinhDoanh", pTenNganh)
        End Function

        Public Function getNganhKinhDoanhByID(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNganhKinhDoanhByID", pSoBienNhan)
        End Function
        Public Sub UpdNganhKinhDoanh(ByVal pMaNganhKinhDoanh As String, ByVal pTenNganhKinhDoanh As String, ByVal pHoSoTiepNhanID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_UpdNganhKinhDoanh", pMaNganhKinhDoanh, pTenNganhKinhDoanh, pHoSoTiepNhanID)
        End Sub
        Public Sub DelNganhKinhDoanh(ByVal pHoSoTiepNhanID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelNganhKinhDoanh", pHoSoTiepNhanID)
        End Sub
        Public Function GetGiayCNDKKDBySoGiayPhep(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGiayPhepXayDungBySoGiayPhep", SoGiayPhep)
        End Function
        Public Function GetGiayCNDKKDBySoGiayPhep1(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGIAYPHEPXAYDUNGBySoGiayPhep1", SoGiayPhep)
        End Function
        Public Function getNganhKinhDoanhByMaNganh(ByVal pMaNganh As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNganhKinhDoanhByMaNganh", pMaNganh)
        End Function
    End Class

    Public Class GPXDController
        Public Function addGPXD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGIAYPHEPXAYDUNG", obj)
        End Function
        Public Function addGPXD_CD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGIAYPHEPXAYDUNG_CD", obj)
        End Function
        Public Sub delGPXD(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelGIAYPHEPXAYDUNG", obj)
        End Sub
        Public Function getGPXD_New(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGIAYPHEPXAYDUNG_New", pHoSoTiepNhanID)
        End Function
        Public Function getsoGiayPhep(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetSoGiayPhep", pHoSoTiepNhanID)
        End Function

        Public Function getGPXD_Edit(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGIAYPHEPXAYDUNG_Edit", pHoSoTiepNhanID)
        End Function
        Public Function GetGPXDBySoGiayPhep(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGiayPhepXayDungBySoGiayPhep", SoGiayPhep)
        End Function
        Public Sub CapSoGiayPhep(ByVal strHoSoTiepNhanID As String, ByVal strSoGiayPhep As String, ByVal strNgayCap As String)
            DataProvider.Instance.ExecuteScalar("sp_CapNhatSoGiayPhep", strHoSoTiepNhanID, strSoGiayPhep, strNgayCap)
        End Sub
        Public Sub CapSoGiayPhep_BinhThuy(ByVal strHoSoTiepNhanID As String, ByVal strSoGiayPhep As String, ByVal strNgayCap As String, ByVal strMaLinhVuc As String, ByVal strTabCode As String, ByVal strMaNguoiTacNghiep As String)
            DataProvider.Instance.ExecuteScalar("sp_CapNhatSoGiayPhep_BinhThuy", strHoSoTiepNhanID, strSoGiayPhep, strNgayCap, strMaLinhVuc, strTabCode, strMaNguoiTacNghiep)
        End Sub
    End Class
End Namespace
