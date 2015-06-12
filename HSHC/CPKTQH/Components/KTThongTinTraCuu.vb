Imports PortalQH
Namespace CPKTQH
    <Serializable()> Public Class KTThongTinTraCuuInfo
        Private _TabCode As String
        Private _HoTen As String
        Private _SoNha As String
        Private _MaDuong As String
        Private _MaPhuong As String
        Private _BangHieu As String
        Private _TinhTrangGiayPhep As String
        Private _MatHangKinhDoanh As String
        Private _SoGiayPhep As String
        Private _SoCMND As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _DauKi As String
        Private _URL As String

        Public Property TabCode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
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
        Public Property BangHieu() As String
            Get
                Return _BangHieu
            End Get
            Set(ByVal Value As String)
                _BangHieu = Value
            End Set
        End Property
        Public Property TinhTrangGiayPhep() As String
            Get
                Return _TinhTrangGiayPhep
            End Get
            Set(ByVal Value As String)
                _TinhTrangGiayPhep = Value
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
        Public Property SoGiayPhep() As String
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value
            End Set
        End Property
        Public Property TuNgay() As String
            Get
                Return _TuNgay
            End Get
            Set(ByVal Value As String)
                _TuNgay = Value
            End Set
        End Property
        Public Property DenNgay() As String
            Get
                Return _DenNgay
            End Get
            Set(ByVal Value As String)
                _DenNgay = Value
            End Set
        End Property
        Public Property DauKi() As String
            Get
                Return _DauKi
            End Get
            Set(ByVal Value As String)
                _DauKi = Value
            End Set
        End Property
        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property

        Public Sub New(ByVal request As HttpRequest)
            _TabCode = ""
            _HoTen = ""
            _SoNha = ""
            _MaDuong = ""
            _MaPhuong = ""
            _BangHieu = ""
            _TinhTrangGiayPhep = ""
            _MatHangKinhDoanh = ""
            _SoGiayPhep = ""
            _TuNgay = Format(DateAdd(DateInterval.Day, -getSoNgayLoc(request), Now), "dd/MM/yyyy")
            _DenNgay = Format(Now, "dd/MM/yyyy")
            _DauKi = ""
            _URL = ""
        End Sub
    End Class

    Public Class KTThongTinTraCuuController
        Public Function getDanhSachGiayCNDKKDDauKi(ByVal obj As KTThongTinTraCuuInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKD_LstDauKi", _
                                                                    obj.TabCode, _
                                                                    obj.HoTen, _
                                                                    obj.SoCMND, _
                                                                    obj.SoNha, _
                                                                    obj.MaDuong, _
                                                                    obj.MaPhuong, _
                                                                    obj.BangHieu, _
                                                                    obj.TinhTrangGiayPhep, _
                                                                    obj.MatHangKinhDoanh, _
                                                                    obj.SoGiayPhep, _
                                                                    obj.TuNgay, _
                                                                    obj.DenNgay, _
                                                                    obj.URL)
        End Function
        Public Function getDanhSachGiayCNDKKDHTXDauKi(ByVal obj As KTThongTinTraCuuInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GiayCNDKKDHTX_LstDauKi", _
                                                                    obj.TabCode, _
                                                                    obj.HoTen, _
                                                                    obj.SoNha, _
                                                                    obj.MaDuong, _
                                                                    obj.MaPhuong, _
                                                                    obj.BangHieu, _
                                                                    obj.TinhTrangGiayPhep, _
                                                                    obj.MatHangKinhDoanh, _
                                                                    obj.SoGiayPhep, _
                                                                    obj.TuNgay, _
                                                                    obj.DenNgay, _
                                                                    obj.URL)
        End Function
    End Class
End Namespace