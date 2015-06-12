Imports PortalQH
Namespace THTT
    Public Class TinhHinhHoSoInfo
        Private _LinhVuc As String
        Private _LoaiHoSo As String
        Private _LoaiThongKe As String
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
        Public Property LoaiHoSo() As String
            Get
                Return _LoaiHoSo
            End Get
            Set(ByVal Value As String)
                _LoaiHoSo = Value
            End Set
        End Property
        Public Property LoaiThongKe() As String
            Get
                Return _LoaiThongKe
            End Get
            Set(ByVal Value As String)
                _LoaiThongKe = Value
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

    Public Class TinhHinhHoSoController
        Public Function ThongKeLinhVuc(ByVal objThongKe As TinhHinhHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLinhVuc", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function

        Public Function ThongKeLoaiHoSo(ByVal objTinhHinh As TinhHinhHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(objTinhHinh.LinhVuc & "..sp_Web_XuLyHoSo_LoaiCP", objTinhHinh.TuNgay, objTinhHinh.DenNgay, "")
        End Function

        Public Function ThongKeHoSo(ByVal objThongKe As TinhHinhHoSoInfo, ByVal dbcommon As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(objThongKe.LinhVuc & "..sp_Web_XuLyHoSo_LoaiCP_DS", objThongKe.TuNgay, objThongKe.DenNgay, objThongKe.LinhVuc, dbcommon, "", objThongKe.LoaiThongKe, objThongKe.LoaiHoSo, objThongKe.URL)
        End Function

        Public Function ChiTietTiepNhan(ByVal pDBCommon As String, ByVal pID As String, ByVal pLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(pLinhVuc & "..sp_web_ChiTietTiepNhan", pDBCommon, "", pID)
        End Function

        Public Function QuaTrinhGiaiQuyet(ByVal pID As String, ByVal pLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(pLinhVuc & "..sp_ThongKe_QuaTrinhGiaiQuyet", pID)
        End Function
        Public Function ThongKeTongHop(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_Web_XuLyHoSo_TongHop", TuNgay, DenNgay)
        End Function
        Public Function ThongKeTongHopHoSo(ByVal DB As String, ByVal objTinhHinh As TinhHinhHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DB & "..sp_Web_ThongKeTongHopHoSo", objTinhHinh.TuNgay, objTinhHinh.DenNgay, objTinhHinh.LinhVuc)
        End Function
    End Class
End Namespace

