Imports PortalQH
Namespace CPKTQH
    Public Class XaVienInfo
        Private _HoTen As String
        Private _GioiTinh As String
        Private _NgaySinh As String
        Private _DanToc As String
        Private _SoCMND As String
        Private _NgayCapCMND As String
        Private _NoiCapCMND As String
        Private _DiaChiThuongTru As String
        Private _ChoOHienNay As String
        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
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

        Public Property NgaySinh() As String

            Get
                Return _NgaySinh
            End Get
            Set(ByVal Value As String)
                _NgaySinh = Value
            End Set
        End Property

        Public Property DanToc() As String

            Get
                Return _DanToc
            End Get
            Set(ByVal Value As String)
                _DanToc = Value
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

        Public Property NgayCapCMND() As String

            Get
                Return _NgayCapCMND
            End Get
            Set(ByVal Value As String)
                _NgayCapCMND = Value
            End Set
        End Property

        Public Property NoiCapCMND() As String

            Get
                Return _NoiCapCMND
            End Get
            Set(ByVal Value As String)
                _NoiCapCMND = Value
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

        Public Property ChoOHienNay() As String

            Get
                Return _ChoOHienNay
            End Get
            Set(ByVal Value As String)
                _ChoOHienNay = Value
            End Set
        End Property
        Public Sub ResetAll()
            _HoTen = ""
            _GioiTinh = ""
            _NgaySinh = ""
            _DanToc = ""
            _SoCMND = ""
            _NgayCapCMND = ""
            _NoiCapCMND = ""
            _DiaChiThuongTru = ""
            _ChoOHienNay = ""
        End Sub
    End Class
    Public Class GiayPhepHopTacXaInfo
        Private _SoBienNhan As String
        Private _SoGiayPhep As String
        Private _BangHieu As String
        Private _MaLinhVucCapPhep As String
        Private _MaHinhThucKinhDoanh As String
        Private _MaNganhKinhDoanh As String
        Private _MatHangKinhDoanh As String
        Private _VonKinhDoanh As String
        Private _NgayCap As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _DiaChiCu As String
        Private _DienThoai As String
        Private _Fax As String
        Private _Email As String
        Private _Website As String
        Private _SoLanCapDoi As String
        Private _SoLanThayDoi As String
        Private _SoLanCapPhoBan As String
        Private _GhiChu As String
        Private _NguoiKy As String
        Private _SoGiayPhepGoc As String
        Private _NgayCapGoc As String
        Private _SoGiayPhepTruoc As String
        Private _NgayCapTruoc As String

        Public Property SoBienNhan() As String
            Get
                Return _SoBienNhan
            End Get
            Set(ByVal Value As String)
                _SoBienNhan = Value
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
        Public Property BangHieu() As String
            Get
                Return _BangHieu
            End Get
            Set(ByVal Value As String)
                _BangHieu = Value
            End Set
        End Property
        Public Property MaLinhVucCapPhep() As String
            Get
                Return _MaLinhVucCapPhep
            End Get
            Set(ByVal Value As String)
                _MaLinhVucCapPhep = Value
            End Set
        End Property
        Public Property MaHinhThucKinhDoanh() As String
            Get
                Return _MaHinhThucKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MaHinhThucKinhDoanh = Value
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
        Public Property MatHangKinhDoanh() As String
            Get
                Return _MatHangKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MatHangKinhDoanh = Value
            End Set
        End Property
        Public Property VonKinhDoanh() As String
            Get
                Return _VonKinhDoanh
            End Get
            Set(ByVal Value As String)
                _VonKinhDoanh = Value
            End Set
        End Property
        Public Property NgayCap() As String
            Get
                Return _NgayCap
            End Get
            Set(ByVal Value As String)
                _NgayCap = Value
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
        Public Property DiaChiCu() As String
            Get
                Return _DiaChiCu
            End Get
            Set(ByVal Value As String)
                _DiaChiCu = Value
            End Set
        End Property
        Public Property DienThoai() As String
            Get
                Return _DienThoai
            End Get
            Set(ByVal Value As String)
                _DienThoai = Value
            End Set
        End Property
        Public Property Fax() As String
            Get
                Return _Fax
            End Get
            Set(ByVal Value As String)
                _Fax = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property
        Public Property Website() As String
            Get
                Return _Website
            End Get
            Set(ByVal Value As String)
                _Website = Value
            End Set
        End Property
        Public Property SoLanCapDoi() As String
            Get
                Return _SoLanCapDoi
            End Get
            Set(ByVal Value As String)
                _SoLanCapDoi = Value
            End Set
        End Property
        Public Property SoLanThayDoi() As String
            Get
                Return _SoLanThayDoi
            End Get
            Set(ByVal Value As String)
                _SoLanThayDoi = Value
            End Set
        End Property
        Public Property SoLanCapPhoBan() As String
            Get
                Return _SoLanCapPhoBan
            End Get
            Set(ByVal Value As String)
                _SoLanCapPhoBan = Value
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
        Public Property NguoiKy() As String
            Get
                Return _NguoiKy
            End Get
            Set(ByVal Value As String)
                _NguoiKy = Value
            End Set
        End Property

        Public Property SoGiayPhepGoc() As String
            Get
                Return _SoGiayPhepGoc
            End Get
            Set(ByVal Value As String)
                _SoGiayPhepGoc = Value
            End Set
        End Property
        Public Property NgayCapGoc() As String
            Get
                Return _NgayCapGoc
            End Get
            Set(ByVal Value As String)
                _NgayCapGoc = Value
            End Set
        End Property
        Public Property SoGiayPhepTruoc() As String
            Get
                Return _SoGiayPhepTruoc
            End Get
            Set(ByVal Value As String)
                _SoGiayPhepTruoc = Value
            End Set
        End Property
        Public Property NgayCapTruoc() As String
            Get
                Return _NgayCapTruoc
            End Get
            Set(ByVal Value As String)
                _NgayCapTruoc = Value
            End Set
        End Property
    End Class
    Public Class HopTacXaController
        Function checkSoGiayPhepHTX(ByVal strSoGiayPhep As String) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_SoGiayPhepHopTacXa_Check", strSoGiayPhep)
            If str = "0" Then
                Return False
            End If
            Return True
        End Function
        Function updCapDoiGiayCNDKKDHTX(ByVal strGiayCNKDDKHTXID As String, ByVal strSoGiayPhepTruoc As String, ByVal strMaSoNguoiSuDung As String, ByVal objTTGP As GiayPhepHopTacXaInfo, ByVal objTTCN As XaVienInfo, ByVal dtThongTinXaVien As DataTable) As String
            'Cap nhat thong tin hop tac xa
            strGiayCNKDDKHTXID = DataProvider.Instance.ExecuteScalar("sp_HopTacXa_UpdCapDoi", _
                    strGiayCNKDDKHTXID, _
                    strSoGiayPhepTruoc, _
                    strMaSoNguoiSuDung, _
                    objTTGP.SoBienNhan, _
                    objTTGP.SoGiayPhep, _
                    objTTGP.BangHieu, _
                    objTTGP.MaLinhVucCapPhep, _
                    objTTGP.MaHinhThucKinhDoanh, _
                    objTTGP.MaNganhKinhDoanh, _
                    objTTGP.MatHangKinhDoanh, _
                    objTTGP.VonKinhDoanh, _
                    objTTGP.NgayCap, _
                    objTTGP.SoNha, _
                    objTTGP.MaDuong, _
                    objTTGP.MaPhuong, _
                    objTTGP.DiaChiCu, _
                    objTTGP.DienThoai, _
                    objTTGP.Fax, _
                    objTTGP.Email, _
                    objTTGP.Website, _
                    objTTGP.GhiChu, _
                    objTTGP.NguoiKy, _
                    objTTCN.HoTen, _
                    objTTCN.GioiTinh, _
                    objTTCN.NgaySinh, _
                    objTTCN.DanToc, _
                    objTTCN.SoCMND, _
                    objTTCN.NgayCapCMND, _
                    objTTCN.NoiCapCMND, _
                    objTTCN.DiaChiThuongTru, _
                    objTTCN.ChoOHienNay _
            )
            If strGiayCNKDDKHTXID = "1" Then
                Return strGiayCNKDDKHTXID
            End If
            'Cap nhat danh sach Xa Vien
            UpdDanhSachXaVien(strGiayCNKDDKHTXID, dtThongTinXaVien)
            Return strGiayCNKDDKHTXID
        End Function
        Function updGiayCNDKKDHTX(ByVal strGiayCNKDDKHTXID As String, ByVal strMaSoNguoiSuDung As String, ByVal objTTGP As GiayPhepHopTacXaInfo, ByVal objTTCN As XaVienInfo, ByVal dtThongTinXaVien As DataTable) As String
            'Cap nhat thong tin hop tac xa
            strGiayCNKDDKHTXID = DataProvider.Instance.ExecuteScalar("sp_HopTacXa_Upd", _
                    strGiayCNKDDKHTXID, _
                    strMaSoNguoiSuDung, _
                    objTTGP.SoBienNhan, _
                    objTTGP.SoGiayPhep, _
                    objTTGP.BangHieu, _
                    objTTGP.MaLinhVucCapPhep, _
                    objTTGP.MaHinhThucKinhDoanh, _
                    objTTGP.MaNganhKinhDoanh, _
                    objTTGP.MatHangKinhDoanh, _
                    objTTGP.VonKinhDoanh, _
                    objTTGP.NgayCap, _
                    objTTGP.SoNha, _
                    objTTGP.MaDuong, _
                    objTTGP.MaPhuong, _
                    objTTGP.DiaChiCu, _
                    objTTGP.DienThoai, _
                    objTTGP.Fax, _
                    objTTGP.Email, _
                    objTTGP.Website, _
                    objTTGP.SoLanCapDoi, _
                    objTTGP.SoLanThayDoi, _
                    objTTGP.SoLanCapPhoBan, _
                    objTTGP.GhiChu, _
                    objTTGP.NguoiKy, _
                    objTTGP.SoGiayPhepGoc, _
                    objTTGP.NgayCapGoc, _
                    objTTGP.SoGiayPhepTruoc, _
                    objTTGP.NgayCapTruoc, _
                    objTTCN.HoTen, _
                    objTTCN.GioiTinh, _
                    objTTCN.NgaySinh, _
                    objTTCN.DanToc, _
                    objTTCN.SoCMND, _
                    objTTCN.NgayCapCMND, _
                    objTTCN.NoiCapCMND, _
                    objTTCN.DiaChiThuongTru, _
                    objTTCN.ChoOHienNay _
            )
            If strGiayCNKDDKHTXID = "1" Then
                Return strGiayCNKDDKHTXID
            End If
            'Cap nhat danh sach Xa Vien
            UpdDanhSachXaVien(strGiayCNKDDKHTXID, dtThongTinXaVien)
            Return strGiayCNKDDKHTXID
        End Function
        Public Sub UpdDanhSachXaVien(ByVal strGiayCNKDDKHTXID As String, ByVal dtThongTinXaVien As DataTable)
            'delete thong tin xa vien
            DataProvider.Instance.ExecuteScalar("sp_ThanhVienHTX_Del", strGiayCNKDDKHTXID)
            'insert thong tin xa vien
            Dim i As Integer
            For i = 0 To dtThongTinXaVien.Rows.Count - 1
                DataProvider.Instance.ExecuteScalar("sp_ThanhVienHTX_Ins", _
                    strGiayCNKDDKHTXID, _
                    getItemValueFromTable(dtThongTinXaVien, i, "HoTen"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "GioiTinh"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "NgaySinh"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "DanToc"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "SoCMND"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "NgayCapCMND"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "NoiCapCMND"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "DiaChiThuongTru"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "ChoOHienNay") _
                )
            Next
        End Sub

        Public Function DelCapDoiHopTacXa(ByVal strGiayCNDKKDHTXID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_HopTacXa_DelCapDoi", strGiayCNDKKDHTXID)
        End Function

        Public Function DelHopTacXa(ByVal strGiayCNDKKDHTXID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_HopTacXa_Del", strGiayCNDKKDHTXID)
        End Function
        Public Function getGiayCNDKKDHTXBySoGiayPhep(ByVal strSoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_HopTacXa_GetBySoGiayPhep", strSoGiayPhep)
        End Function

        Public Function getGiayCNDKKDHTX(ByVal strGiayCNDKKDHTXID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_HopTacXa_Get", strGiayCNDKKDHTXID)
        End Function
        Public Function getThanhVienHTX(ByVal GiayCNDKKDHTXID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThanhVienHTX_Get", GiayCNDKKDHTXID)
        End Function
        Private Function getItemValueFromTable(ByVal dt As DataTable, ByVal rowNo As Integer, ByVal field As String) As String
            If (Not IsDBNull(dt.Rows(rowNo).Item(field))) Then
                Return Replace(CStr(dt.Rows(rowNo).Item(field)), "''", "'")
            Else
                Return ""
            End If
        End Function
    End Class
End Namespace
