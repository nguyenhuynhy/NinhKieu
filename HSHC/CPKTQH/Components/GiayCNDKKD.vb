Imports PortalQH
Namespace CPKTQH
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
        Private _HoTen As String

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

        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
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
        '--HoangLN 
        Public Sub UpdTinhTrangGiayCNDKKD(ByVal SoGiayPhep As String, ByVal MaTinhTrang As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_TinhTrangGCNDKKD_Upd", SoGiayPhep, MaTinhTrang)
        End Sub
        'modified
        Public Function GetGiayCNDKKDBySoGiayPhep(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCNDKKDBySoGiayPhep", SoGiayPhep)
        End Function
        '----------------------

        'phan to chuc lai hop tac xa
        Public Function GetDanhSachHopTacXaDaToChucLai(ByVal HoSoTiepNhanID As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLaiDanhSach_Lst", HoSoTiepNhanID, Loai)
        End Function
        Public Function GetToChucLai(ByVal HoSoTiepNhanID As String, ByVal SoGiayPhep As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLai_Get", HoSoTiepNhanID, SoGiayPhep, Loai)
        End Function
        Public Function GetDanhSachHopTacXa(ByVal TenDoanhNghiep As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLai_Lst", TenDoanhNghiep, TuNgay, DenNgay)
        End Function
        Public Function InsChia(ByVal ParamArray arrParams() As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLaiChia_Ins", arrParams)
        End Function
        Public Function XoaChia(ByVal ParamArray arrParams() As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLaiChia_Del", arrParams)
        End Function
        Public Function InsToChucLai(ByVal ParamArray arrParams() As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLai_Ins", arrParams)
        End Function
        Public Function DelToChucLai(ByVal HoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ToChucLai_Del", HoSoTiepNhanID)
        End Function
        Public Function CheckToChucLai(ByVal HoSoTiepNhanID As String, ByVal Loai As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_ToChucLai_Check", HoSoTiepNhanID, Loai)
        End Function
        'Phan don vi truc thuoc
        Public Function AddDonViTrucThuoc(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_DonViTrucThuoc_Ins", obj)
        End Function
        Public Function DelDonViTrucThuoc(ByVal ParamArray arrParams() As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_DonViTrucThuoc_Del", arrParams)
            Return Not CBool(str)
        End Function
        Public Function GetDonViTrucThuoc(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_DonViTrucThuoc_Get", obj)
        End Function
        Public Function GetDonViTrucThuocBySoGiayPhep(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_DonViTrucThuoc_GetBySoGiayPhep", SoGiayPhep)
        End Function
        Public Function CheckDonViTrucThuoc(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_DonViTrucThuoc_Check", obj)
        End Function
        Public Function CheckGiayCNDKKDDK(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_CheckDK", obj)
        End Function
        Public Function AddGIAYCNDKKD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_GIAYCNDKKD_Ins", obj)
        End Function
        Public Function CheckGIAYCNDKKD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GIAYCNDKKD_Check", obj)
        End Function
        Public Function AddThanhVien(ByVal ParamArray arrParams() As Object) As String
            Return DataProvider.Instance.ExecuteScalar("sp_ThanhVien_Ins", arrParams)
        End Function
        Public Function AddGIAYCNDKKDDK(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGIAYCNDKKDDK", obj)
        End Function
        Public Function AddGIAYCNDKKD_CD(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_GIAYCNDKKD_InsCD", obj)
        End Function

        Public Sub DelGIAYCNDKKD(ByVal pGiayCNDKKDID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_GIAYCNDKKD_Del", pGiayCNDKKDID)
        End Sub
        Public Function GetGiayCNDKKD_New(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_CNDKKD_GetNew", pHoSoTiepNhanID)
        End Function
        Public Function XoaGiayCNDKKD(ByVal pHoSoTiepNhanID As String, ByVal SoGiayPhep As String, ByVal DauKy As String, ByVal Loai As Integer) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GIAYCNDKKD_Del", pHoSoTiepNhanID, SoGiayPhep, DauKy, Loai)
        End Function
        Public Function GetGiayCNDKKD_Edit(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_CNDKKD_GetEdit", pHoSoTiepNhanID)
        End Function
        Public Function GetThanhVien(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThanhVien_Get", pHoSoTiepNhanID)
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

        Public Function GetGiayCNDKKDBySoGiayPhep1(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_Get", SoGiayPhep)
        End Function
        Public Function GetGiayCNDKKDBySoGiayPhepDK(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_GetDK", SoGiayPhep)
        End Function
        Public Function getNganhKinhDoanhByMaNganh(ByVal pMaNganh As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNganhKinhDoanhByMaNganh", pMaNganh)
        End Function
        Public Function CapSoGiayPhep(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_CapSoGiayPhep", obj)
        End Function
        Public Function CapNhatSoGiayPhep(ByVal HoSoTiepNhanID As String, ByVal SoGiayPhep As String, ByVal STT As Integer, ByVal Loai As Integer) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_CapSoGiayPhep", HoSoTiepNhanID, SoGiayPhep, STT, Loai)
        End Function
        Public Function LaySoGiayPhep(ByVal obj As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_SoGiayPhep_Get", obj)
        End Function
        Public Function LayParam(ByVal ParamID As Integer) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetByIDPARAMS", ParamID)
        End Function
        Public Function GetGiayCNDKKDByID(ByVal pGiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_GetByID", pGiayCNDKKDID)
        End Function
        
        Public Function KiemTraThongTinDKKD(ByVal obj As GiayCNDKKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_KiemTra", _
                                                                    obj.BangHieu, _
                                                                    obj.HoTen)
        End Function

        'ThuyTT add
        Public Function getIDByHoSoTiepNhan(ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GiayCNDKKD_GetID", pHoSoTiepNhanID)
        End Function

        'các hàm lấy thông tin, cập nhật thông tin dữ liệu đầu kì
        Public Function insGiayCNDKKDDauKi(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_GiayCNDKKD_InsDauKi", obj)
        End Function

        'hàm này dùng để kiểm tra giấy CN ĐKKD này đã có thông tin thay đổi, ngưng kinh doanh hay chưa
        Public Function KiemTraDauKi(ByVal pGiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_KiemTraDauKi", pGiayCNDKKDID)
        End Function

        Public Function InGiayCNDKKD(ByVal pGiayCNDKKDID As String, Optional ByVal blnInBanSao As Boolean = False) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptInGiayCNDKKDWord", pGiayCNDKKDID, -CInt(blnInBanSao))
        End Function


        'cập nhật số giấy phép sau khi trình UBND ký duyệt
        'PhuocDD, updated Apr 07th 2006
        'Them NgayCap va LoaiHoSo
        Public Function CapSoGiayPhepGiayCNDKKD(ByVal pGiayCNDKKDID As String, ByVal pSoGiayPhep As String, ByVal pNgayCap As String, ByVal pTabCode As String, ByVal pMaNguoiNhan As String, ByVal pLoaiHoSo As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_CapSoGiayPhepGiayCNDKKD", pGiayCNDKKDID, pSoGiayPhep, pNgayCap, pTabCode, pMaNguoiNhan, pLoaiHoSo)
        End Function

        'Lay thong tin ho so cho phan cap so bang tay
        'PhuocDD, added Apr 13th 2006
        Public Function GetCapSoGiayPhepGiayCNDKKDByID(ByVal pHoSoTiepNhanID As String, ByVal pLoaiHoSo As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_CapSoGiayPhepGiayCNDKKD_GetByID", pHoSoTiepNhanID, pLoaiHoSo)
        End Function

        'PhuocDD, added Apr 10th 2006
        'Xoa so giay phep, phuc hoi lai tinh trang truoc
        Public Sub DelSoGCNCNDKKD(ByVal pGiayCNDKKDID As String, ByVal pTabCode As String, ByVal pMaNguoiNhan As String, ByVal pLoaiHoSo As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_GIAYCNDKKD_DelSoGCN", pGiayCNDKKDID, pTabCode, pMaNguoiNhan, pLoaiHoSo)
        End Sub


        'kiểm tra hết hạn giấy phép
        Public Sub KiemTraHetHanGiayPhep()
            DataProvider.Instance.ExecuteScalar("sp_KiemTraHetHanGiayPhep")
        End Sub
        Public Function InQuyetDinhThuHoiGCNDKKD(ByVal GiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_PrintQDThuHoiGiayCNDKKD", GiayCNDKKDID)
        End Function
        Public Function InThongBaoThuHoiGCNDKKD(ByVal GiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_PrintTBThuHoiGiayCNDKKD", GiayCNDKKDID)
        End Function
        'Thay doi theo thong tu 01/2009 cua Bo KH va DT
        'Lay danh sach thong tin thanh vien gop von thanh lap ho kinh doanh
        Public Function THANHVIENHKD_GetByTiepNhanID(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_THANHVIENHKD_GetByTiepNhanID", pHoSoTiepNhanID)
        End Function
        'Xoa thong tin thanh vien gop von thanh lap ho kinh doanh
        Public Sub THANHVIENHKD_Del(ByVal pThanhVienID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_THANHVIENHKD_Del", pThanhVienID)
        End Sub
        'Cap nhat thong tin thanh vien gop von thanh lap ho kinh doanh
        Public Sub THANHVIENHKD_Upd(ByVal pThanhVienID As String, ByVal pTenThanhVien As String, ByVal pThanhVienThuongTru As String, ByVal pGiaTriGopVon As String, ByVal pTyLeGopVon As String, ByVal pThanhVienCMND As String, ByVal pThanhVienGhiChu As String, ByVal pHoSoTiepNhanID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_THANHVIENHKD_Upd", pThanhVienID, pTenThanhVien, pThanhVienThuongTru, pGiaTriGopVon, pTyLeGopVon, pThanhVienCMND, pThanhVienGhiChu, pHoSoTiepNhanID)
        End Sub
        'Cap nhat thay doi thong tin thanh vien gop von thanh lap ho kinh doanh
        Public Sub THAYDOI_THANHVIENHKD_Upd(ByVal pThanhVienID As String, ByVal pTenThanhVien As String, ByVal pThanhVienThuongTru As String, ByVal pGiaTriGopVon As String, ByVal pTyLeGopVon As String, ByVal pThanhVienCMND As String, ByVal pThanhVienGhiChu As String, ByVal pHoSoTiepNhanID As String, ByVal pSoGiayPhep As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_THAYDOI_THANHVIENHKD_Upd", pThanhVienID, pTenThanhVien, pThanhVienThuongTru, pGiaTriGopVon, pTyLeGopVon, pThanhVienCMND, pThanhVienGhiChu, pHoSoTiepNhanID, pSoGiayPhep)
        End Sub
        'Xoa thong tin thay doi thanh vien gop von thanh lap ho kinh doanh
        Public Sub THAYDOI_THANHVIENHKD_Del(ByVal pThanhVienID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_THAYDOI_THANHVIENHKD_Del", pThanhVienID)
        End Sub
        Public Function THANHVIENHKD_GetByGiayCNDKKDID(ByVal pGiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_THANHVIENHKD_GetByGiayCNDKKDID", pGiayCNDKKDID)
        End Function
        Public Function GetGiayCNDKKDBySoGiayPhepNgungKinhDoanh(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCNDKKDBySoGiayPhepNgungKinhDoanh", SoGiayPhep)
        End Function
        'Thay doi so giay phep khi cap lai cap doi
        Public Function InGiayCNDKKD_DoiSo(ByVal pGiayCNDKKDID As String, ByVal SoGiayPhep As String, Optional ByVal blnInBanSao As Boolean = False) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptInGiayCNDKKDWord_DoiSo", pGiayCNDKKDID, SoGiayPhep, -CInt(blnInBanSao))
        End Function
    End Class
End Namespace
