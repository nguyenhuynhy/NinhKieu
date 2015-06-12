Imports portalqh
Namespace CPKTQH
    <Serializable()> Public Class KiemTraHoSoInfo
        Private _SoGiayPhep As String
        Private _BangHieu As String
        Private _HoTen As String
        Private _SoCMND As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _MaNganh As String
        Private _GiayCNDKKDID As String
        Private _GiayCNDKKDHTXID As String
        Private _DonViTrucThuocID As String
        Private _DiaChiThuongTru As String

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

        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
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

        Public Property MaNganh() As String
            Get
                Return _MaNganh
            End Get
            Set(ByVal Value As String)
                _MaNganh = Value
            End Set
        End Property
        Public Property GiayCNDKKDID() As String
            Get
                Return _GiayCNDKKDID
            End Get
            Set(ByVal Value As String)
                _GiayCNDKKDID = Value
            End Set
        End Property
        Public Property GiayCNDKKDHTXID() As String
            Get
                Return _GiayCNDKKDHTXID
            End Get
            Set(ByVal Value As String)
                _GiayCNDKKDHTXID = Value
            End Set
        End Property
        Public Property DonViTrucThuocID() As String
            Get
                Return _DonViTrucThuocID
            End Get
            Set(ByVal Value As String)
                _DonViTrucThuocID = Value
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


    End Class

    Public Class KiemTraHoSoController
        Public Function KiemTraViPhamHanhChinh(ByVal obj As KiemTraHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraViPhamHanhChinh", _
                                                                    obj.SoGiayPhep, _
                                                                    obj.SoCMND, _
                                                                    obj.SoNha, _
                                                                    obj.MaDuong, _
                                                                    obj.MaPhuong)
        End Function

        Public Function KiemTraNganhCamKD(ByVal obj As KiemTraHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraNganhCamKD", _
                                                                    obj.MaNganh, _
                                                                    obj.MaDuong, _
                                                                    obj.MaPhuong, _
                                                                    Nothing)
        End Function

        Public Function KiemTraNganhKDCoDieuKien(ByVal obj As KiemTraHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraNganhKDCoDK", _
                                                                    obj.MaNganh)
        End Function

        Public Function KiemTraBangHieu(ByVal obj As KiemTraHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraBangHieu", _
                                                            obj.GiayCNDKKDID, _
                                                            obj.GiayCNDKKDHTXID, _
                                                            obj.DonViTrucThuocID, _
                                                            obj.BangHieu)
        End Function

        Public Function KiemTraNguoiDangKy(ByVal obj As KiemTraHoSoInfo) As String
            'Gia tri tra ve:
            '+ 0: nguoi nay chua DKKD
            '+ 1: nguoi nay da dang ky kinh doanh
            '+ 2: TH 2 nguoi cung 1 so CMND
            '+ 3: TH 1 nguoi 2 CMND
            '+ 4: co nguoi trung ten
            Dim str As String
            Dim strKetQua As String
            str = DataProvider.Instance.ExecuteScalar("sp_KiemTraNguoiDangKy", _
                                                            obj.GiayCNDKKDID, _
                                                            obj.GiayCNDKKDHTXID, _
                                                            obj.DonViTrucThuocID, _
                                                            obj.HoTen, _
                                                            obj.SoCMND, _
                                                            obj.DiaChiThuongTru)
            Select Case str
                Case "0" : strKetQua = "Người này chưa đăng ký kinh doanh"
                Case "1" : strKetQua = "Người này đã đăng ký kinh doanh"
                Case "2" : strKetQua = "Hai người cùng một số CMND"
                Case "3" : strKetQua = "Một người có 2 số CMND"
                Case "4" : strKetQua = "Đã có người cùng tên đăng ký kinh doanh trong hệ thống"
                Case Else : strKetQua = ""
            End Select
        End Function

        Public Function KiemTraDiaChiDKKD(ByVal obj As KiemTraHoSoInfo) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_KiemTraDiaChiDKKD", _
                                                            obj.GiayCNDKKDID, _
                                                            obj.GiayCNDKKDHTXID, _
                                                            obj.DonViTrucThuocID, _
                                                            obj.SoNha, _
                                                            obj.MaDuong, _
                                                            obj.MaPhuong)
            If str = "1" Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function KiemTraSoCMND(ByVal obj As KiemTraHoSoInfo) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_KiemTraSoCMND", _
                                                            obj.GiayCNDKKDID, _
                                                            obj.GiayCNDKKDHTXID, _
                                                            obj.DonViTrucThuocID, _
                                                            obj.SoCMND)
            If str = "1" Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function KiemTraThongTinDKKD(ByVal obj As KiemTraHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraThongTinDKKD", _
                                                                obj.BangHieu, _
                                                                obj.HoTen, _
                                                                obj.SoGiayPhep, _
                                                                obj.SoCMND)
        End Function

        '**********************************************************************************
        '       Mục đích        : kiểm tra hồ sơ tiếp nhận
        '       Tham số vào     : màn hình cần kiểm tra
        '       Kết quả trả về  : dataset thông tin hồ sơ
        '       Người tạo       : ThuyTT
        '       Ngày tạo        : 12/01/2006
        '       Người sửa       : PhuocDD
        '       Ngày sửa        : 30/03/2006, Rem
        '**********************************************************************************
        Public Function KiemTraDaCapGCN(ByVal MaLinhVuc As String, ByVal SoCMND As String, ByVal SoNha As String, ByVal MaDuong As String, ByVal MaPhuong As String) As DataSet
            Dim dsKetQua As DataSet

            dsKetQua = DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraDaCapGCN", MaLinhVuc, SoCMND, SoNha, MaDuong, MaPhuong)

            Return dsKetQua
        End Function
    End Class
End Namespace