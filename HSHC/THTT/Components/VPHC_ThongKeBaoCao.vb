Imports PortalQH
Namespace THTT
    Public Class VPHC_ThongKeBaoCaoInfo
        Private _LinhVuc As String
        Private _LinhVucXayDung As String
        Private _LoaiHoSo As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _URL As String

        Public Property LinhVuc() As String
            Get
                Return _LinhVuc
            End Get
            Set(ByVal Value As String)
                _LinhVuc = Value
            End Set
        End Property
        Public Property LinhVucXayDung() As String
            Get
                Return _LinhVucXayDung
            End Get
            Set(ByVal Value As String)
                _LinhVucXayDung = Value
            End Set
        End Property
        Public Property LoaiHoSo() As String
            Get
                Return _LoaiHoSo
            End Get
            Set(ByVal Value As String)
                _LoaiHoSo = Value
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
        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property

    End Class

    Public Class VPHC_ThongKeBaoCaoController
        Public Function ThongKeLinhVuc(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLinhVucVPHC", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeTienDo(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKe", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeHoSo(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeChiTietHoSo", objThongKe.LinhVuc, objThongKe.LoaiHoSo, objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ChiTietTiepNhan(ByVal pID As String, ByVal strKhuVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(strKhuVuc & "..sp_ChiTietHoSoViPham", pID)
        End Function

        Public Function QuaTrinhGiaiQuyet(ByVal pID As String, ByVal strLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(strLinhVuc & "..sp_ThongKe_QuaTrinhGiaiQuyet", pID, "")
        End Function
        'AnhLH them ngay 17/10/05
        Public Function ThongKeByLinhVuc(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLinhVuc", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeByLinhVucViPham(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLinhVucViPham", objThongKe.LinhVuc, objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeByLinhVucViPhamDS(ByVal objThongKe As VPHC_ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLinhVucViPhamDS", objThongKe.LinhVuc, objThongKe.LinhVucXayDung, objThongKe.LoaiHoSo, objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeDanhSachHoSo(ByVal objThongKe As VPHC_ThongKeBaoCaoInfo) As DataSet            '
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeDanhSach", objThongKe.LinhVuc, objThongKe.LinhVucXayDung, objThongKe.LoaiHoSo, objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        'End AnhLH
        'Khailt 19/05/2006
        Public Function ThongKeTheoPhongBan(ByVal objThongKe As VPHC_ThongKeBaoCaoInfo) As DataSet
            'Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeTheoPhongBan", objThongKe.TuNgay, objThongKe.DenNgay)
            Return DataProvider.Instance.ExecuteQueryStoreProc(objThongKe.LinhVuc & "..sp_ThongKeTheoPhongBan", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeDanhSachHoSoPhongBan(ByVal strTuNgay As String, ByVal strDenNgay As String, ByVal strMaDonVi As String, ByVal strLoaiHoSo As String, ByVal strLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(strLinhVuc & "..sp_ThongKeDanhSachTheoPhongBan", strTuNgay, strDenNgay, strMaDonVi, strLoaiHoSo)
            'Return DataProvider.Instance.ExecuteQueryStoreProc(objThongKe.LinhVuc & "..sp_ThongKeDanhSachTheoPhongBan", strTuNgay, strDenNgay, strMaDonVi, strLoaiHoSo)
        End Function

    End Class
End Namespace



