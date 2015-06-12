Imports PortalQH
Namespace DOITHOAI
    Public Class TinNhanInfo
        Private _Loai As String
        Private _MaLinhVuc As String
        Private _TieuDe As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _MaNguoiSuDung As String
        Private _URL As String

        Public Property Loai() As String
            Get
                Return _Loai
            End Get
            Set(ByVal Value As String)
                _Loai = Value
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
        Public Property TieuDe() As String
            Get
                Return _TieuDe
            End Get
            Set(ByVal Value As String)
                _TieuDe = Value
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
        Public Property MaNguoiSuDung() As String
            Get
                Return _MaNguoiSuDung
            End Get
            Set(ByVal Value As String)
                _MaNguoiSuDung = Value
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
    Public Class TinNhanController

        Public Function getDanhSachTinNhan(ByVal obj As TinNhanInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDanhSachTinNhan", _
                                                                            Replace(obj.MaNguoiSuDung, "'", "''"), _
                                                                            Replace(obj.Loai, "'", "''"), _
                                                                            Replace(obj.MaLinhVuc, "'", "''"), _
                                                                            Replace(obj.TieuDe, "'", "''"), _
                                                                            Replace(obj.TuNgay, "'", "''"), _
                                                                            Replace(obj.DenNgay, "'", "''"), _
                                                                            Replace(obj.URL, "'", "''"))
        End Function
        Public Function DanhSachTinNhanChiTiet(ByVal pTinNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDanhSachTinNhanChiTiet", _
                                                                    pTinNhanID)
        End Function
        Public Function NoiDungTinNhan(ByVal pID As String, Optional ByVal pTinNhanChiTietID As String = "") As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getTinNhan", pID, pTinNhanChiTietID)
        End Function

        'kiểm tra người đăng nhập có được quyền xem nội dung tin nhắn hay không?
        'return true: được quyền, false: không được quyền
        Public Function KiemTraQuyenXem(ByVal pUserName As String, ByVal pTinNhanID As String) As Boolean
            Return CBool(DataProvider.Instance.ExecuteScalar("sp_TinNhan_KiemTraQuyenXem", pUserName, pTinNhanID))
        End Function

        'người sử dụng chỉ được xóa tin nhắn chi tiết do mình gửi và chưa có người nào trả lời tin nhắn này
        Public Function KiemTraQuyenXoa(ByVal pUserName As String, ByVal pTinNhanID As String, ByVal pTinNhanChiTietID As String) As Boolean
            Return CBool(DataProvider.Instance.ExecuteScalar("sp_TinNhan_KiemTraQuyenXoa", pUserName, pTinNhanID, pTinNhanChiTietID))
        End Function

        'người sử dụng chỉ được sửa tin nhắn chi tiết do mình gửi và chưa có người nào trả lời tin nhắn này
        Public Function KiemTraQuyenSua(ByVal pUserName As String, ByVal pTinNhanID As String, ByVal pTinNhanChiTietID As String) As Boolean
            Return KiemTraQuyenXoa(pUserName, pTinNhanID, pTinNhanChiTietID)
        End Function

        'người sử dụng chỉ được tra loi tin nhắn chi tiết mà mình nhận được
        Public Function KiemTraQuyenTraLoi(ByVal pUserName As String, ByVal pTinNhanID As String) As Boolean
            Return CBool(DataProvider.Instance.ExecuteScalar("sp_TinNhan_KiemTraQuyenTraLoi", pUserName, pTinNhanID))
        End Function

        Public Function ThemTinNhanMoi(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsTinNhan", obj)
        End Function
        Public Function ThemTinNhanTraLoi(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsTinNhanChiTiet", obj)
        End Function
        Public Sub CapNhatTinNhan(ByVal obj As Object)
            DataProvider.Instance.ExecuteScalarAuto("sp_UpdTinNhanChiTiet", obj)
        End Sub
        Public Sub CapNhatDaXemTinNhan(ByVal pTinNhanID As String, ByVal pUserName As String)
            DataProvider.Instance.ExecuteScalar("sp_TinNhan_DaXemTin", pTinNhanID, pUserName)
        End Sub

        Public Sub XoaTinNhanChiTiet(ByVal pTinNhanID As String, ByVal pTinNhanChiTietID As String)
            DataProvider.Instance.ExecuteScalar("sp_DelTinNhanChiTiet", pTinNhanID, pTinNhanChiTietID)
        End Sub










    End Class
End Namespace