Imports PortalQH
Namespace CPKTQH
    Public Class ThayDoiNoiDungKinhDoanhInfo
        Private _ThayDoiNoiDungKinhDoanhID As String
        Private _NgayThayDoi As String
        Private _NgayDangKyBoSung As String
        Private _SoGiayPhep As String
        Private _NoiDungTruoc As String
        Private _NoiDungMoi As String
        Private _TenTruong As String
        Private _SoGiayPhepGoc As String
        Private _NgayCapGiayPhepGoc As String
        Private _GiayCNDKKDID As String
        Private _HoSoTiepNhanID As String
        Private _LastUpdate As String
        Private _MaLinhVuc As String
        Private _TabCode As String
        Private _MaNguoiTacNghiep As String
        Private _MaSoLanhDao As String
        Private _GhiChu As String


        Public Property ThayDoiNoiDungKinhDoanhID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ThayDoiNoiDungKinhDoanhID
            Get
                Return _ThayDoiNoiDungKinhDoanhID
            End Get
            Set(ByVal Value As String)
                _ThayDoiNoiDungKinhDoanhID = Value
            End Set
        End Property

        Public Property NgayThayDoi() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayThayDoi
            Get
                Return _NgayThayDoi
            End Get
            Set(ByVal Value As String)
                _NgayThayDoi = Value
            End Set
        End Property

        Public Property NgayDangKyBoSung() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayDangKyBoSung
            Get
                Return _NgayDangKyBoSung
            End Get
            Set(ByVal Value As String)
                _NgayDangKyBoSung = Value
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

        Public Property NoiDungTruoc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungTruoc
            Get
                Return _NoiDungTruoc
            End Get
            Set(ByVal Value As String)
                _NoiDungTruoc = Value
            End Set
        End Property

        Public Property NoiDungMoi() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungMoi
            Get
                Return _NoiDungMoi
            End Get
            Set(ByVal Value As String)
                _NoiDungMoi = Value
            End Set
        End Property

        Public Property TenTruong() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.TenTruong
            Get
                Return _TenTruong
            End Get
            Set(ByVal Value As String)
                _TenTruong = Value
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

        Public Property NgayCapGiayPhepGoc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayCapGiayPhepGoc
            Get
                Return _NgayCapGiayPhepGoc
            End Get
            Set(ByVal Value As String)
                _NgayCapGiayPhepGoc = Value
            End Set
        End Property

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
        
        Public Property MaLinhVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property
        Public Property TabCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property MaNguoiTacNghiep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _MaNguoiTacNghiep
            End Get
            Set(ByVal Value As String)
                _MaNguoiTacNghiep = Value
            End Set
        End Property
        Public Property MaSoLanhDao() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _MaSoLanhDao
            End Get
            Set(ByVal Value As String)
                _MaSoLanhDao = Value
            End Set
        End Property
        Public Property GhiChu() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _GhiChu
            End Get
            Set(ByVal Value As String)
                _GhiChu = Value
            End Set
        End Property
        Public Sub ResetAll()
            _ThayDoiNoiDungKinhDoanhID = ""
            _NgayThayDoi = ""
            _NgayDangKyBoSung = ""
            _SoGiayPhep = ""
            _NoiDungTruoc = ""
            _NoiDungMoi = ""
            _TenTruong = ""
            _SoGiayPhepGoc = ""
            _NgayCapGiayPhepGoc = ""
            _GiayCNDKKDID = ""
            _HoSoTiepNhanID = ""
            _LastUpdate = ""
            _MaLinhVuc = ""
            _TabCode = ""
            _MaNguoiTacNghiep = ""
            _MaSoLanhDao = ""
            _GhiChu = ""
        End Sub



    End Class
    Public Class ThayDoiNoiDungKinhDoanhController
        'HoangLN
        Public Function GetThongTinThayDoi(ByVal pGiayCNDKKDID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiDKKD_Get", pGiayCNDKKDID, pLanThayDoi)
        End Function
        Public Sub UpdateThayDoiChiTiet(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiChiTiet_Upd", arrParams)
        End Sub
        Public Sub UpdateThayDoi(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoi_Upd", arrParams)
        End Sub
        Public Sub UpdateGCNDKKD(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_NoiDungDKKD_upd", arrParams)
        End Sub
        Public Sub DelThayDoi(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoi_Del", arrParams)
        End Sub
        Public Function GetSoGiayPhep(ByVal SoBienNhan As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_SoGiayPhepThayDoi_GetBySoBienNhan", SoBienNhan)
        End Function
        Public Function GetThongTinDKKDCu(ByVal pGiayCNDKKDID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongTinDKKDCu_Get", pGiayCNDKKDID, pLanThayDoi)
        End Function
        Public Function GetThongTinDKKDMoi(ByVal pGiayCNDKKDID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongTinDKKDMoi_Get", pGiayCNDKKDID, pLanThayDoi)
        End Function
        Public Sub AddThayDoiThanhVien(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteScalar("sp_ThayDoiThanhVien_Ins", arrParams)
        End Sub
        Public Sub DelThayDoiThanhVien(ByVal SoGiayPhep As String, ByVal SoLan As String)
            DataProvider.Instance.ExecuteScalar("sp_ThayDoiThanhVien_Del", SoGiayPhep, SoLan)
        End Sub
        Public Function GetThayDoiThanhVien(ByVal SoGiayPhep As String, ByVal SoLan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiThanhVien_Get", SoGiayPhep, SoLan)
        End Function
        Public Function CheckDaThayDoi(ByVal pGiayCNDKKDID As String, ByVal pLanThayDoi As String) As Boolean
            Dim strResult As String
            strResult = DataProvider.Instance.ExecuteScalar("sp_ThayDoi_Check", pGiayCNDKKDID, pLanThayDoi)
            If strResult = "0" Then
                Return False
            End If
            Return True
        End Function

        '------------ cai nay se dua qua GiayCNDKKDController
        Public Function GetThanhVienBySoGiayPhep(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThanhVien_GetBySoGiayPhep", SoGiayPhep)
        End Function
        Public Function AddThanhVien(ByVal ParamArray arrParams() As Object) As String
            Return DataProvider.Instance.ExecuteScalar("sp_ThanhVien_InsBySoGiayPhep", arrParams)
        End Function
        Public Sub DelThanhVienBySoGiayPhep(ByVal SoGiayPhep As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_ThanhVien_DelBySoGiayPhep", SoGiayPhep)
        End Sub
        '------------------------------------------------
        'AnhLH
        Public Sub AddThayDoiNoiDungKinhDoanh(ByVal obj As ThayDoiNoiDungKinhDoanhInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsThayDoiNoiDungKinhDoanh", _
                                                                obj.ThayDoiNoiDungKinhDoanhID, _
                                                                obj.NgayThayDoi, _
                                                                obj.NgayDangKyBoSung, _
                                                                obj.SoGiayPhep, _
                                                                obj.NoiDungTruoc, _
                                                                obj.NoiDungMoi, _
                                                                obj.TenTruong, _
                                                                obj.SoGiayPhepGoc, _
                                                                obj.NgayCapGiayPhepGoc, _
                                                                obj.GiayCNDKKDID, _
                                                                obj.HoSoTiepNhanID, _
                                                                obj.MaLinhVuc, _
                                                                obj.TabCode, _
                                                                obj.MaNguoiTacNghiep, _
                                                                obj.MaSoLanhDao, _
                                                                obj.GhiChu)
        End Sub
        Public Sub CapNhatTinhTrangHoSoTiepNhan(ByVal obj As ThayDoiNoiDungKinhDoanhInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_CapNhatTinhHinhThuLy", _
                                                                obj.MaLinhVuc, _
                                                                obj.TabCode, _
                                                                "HSD", _
                                                                obj.MaNguoiTacNghiep, _
                                                                obj.MaNguoiTacNghiep, _
                                                                obj.MaNguoiTacNghiep, _
                                                                obj.HoSoTiepNhanID, _
                                                                Nothing)
        End Sub
        Public Function GetThayDoiNoiDungKinhDoanh(ByVal HoSoTiepNhanID As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getThayDoiNoiDungKinhDoanhByHoSoTiepNhanID", HoSoTiepNhanID)
        End Function
        Public Function GetThayDoiNoiDungKinhDoanh_ChiTiet(ByVal HoSoTiepNhanID As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getThayDoiNoiDungKinhDoanh_ChiTiet", HoSoTiepNhanID)
        End Function
        Public Sub DelThayDoiNoiDungKinhDoanh(ByVal obj As ThayDoiNoiDungKinhDoanhInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelThayDoiNoiDungKinhDoanh", obj.GiayCNDKKDID, _
                                                                                            obj.HoSoTiepNhanID, _
                                                                                            obj.MaLinhVuc, _
                                                                                            obj.TabCode, _
                                                                                            obj.MaNguoiTacNghiep)
        End Sub
        Public Sub CapNhatSoLanThayDoi(ByVal strSoLanThayDoi As String, ByVal strSoGiayPhep As String)
            DataProvider.Instance.ExecuteScalar("sp_UpdSoLanThayDoi", strSoGiayPhep, strSoLanThayDoi)
        End Sub
    End Class
End Namespace

