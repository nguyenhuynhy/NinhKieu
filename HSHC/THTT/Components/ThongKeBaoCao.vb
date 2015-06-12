Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class ThongKeBaoCaoInfo
        Private _LinhVuc As String
        Private _LoaiHoSo As String
        Private _LoaiThongKe As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _MaTinhTrang As String
        Private _URL As String
        Private _NguoiXemBaoCaoChiTiet As String
        Private _MaPhuong As String
        Private _NguoiXemBaoCao As String

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
        Public Property NguoiXemBaoCaoChiTiet() As String
            Get
                Return _NguoiXemBaoCaoChiTiet
            End Get
            Set(ByVal Value As String)
                _NguoiXemBaoCaoChiTiet = Value
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
        Public Property NguoiXemBaoCao() As String
            Get
                Return _NguoiXemBaoCao
            End Get
            Set(ByVal Value As String)
                _NguoiXemBaoCao = Value
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
        Public Property TinhTrang() As String
            Get
                Return _MaTinhTrang
            End Get
            Set(ByVal Value As String)
                _MaTinhTrang = Value
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

    Public Class ThongKeBaoCaoController
        Public Function ThongKeLinhVuc(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKeLinhVuc", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function
        Public Function ThongKeHoSoPhuong(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKeHoSoPhuong", objThongKe.LinhVuc, objThongKe.LoaiHoSo, objThongKe.TuNgay, objThongKe.DenNgay, objThongKe.LoaiThongKe, objThongKe.TinhTrang, objThongKe.URL, objThongKe.NguoiXemBaoCaoChiTiet, objThongKe.MaPhuong)
        End Function
        Public Function ThongKeLinhVucPhuong(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKeLinhVucPhuong", objThongKe.TuNgay, objThongKe.DenNgay, objThongKe.NguoiXemBaoCao, objThongKe.MaPhuong)
        End Function
        Public Function ThongKeLoaiHoSoPhuong(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKeLoaiHoSoPhuong", objThongKe.LinhVuc, objThongKe.TuNgay, objThongKe.DenNgay, objThongKe.NguoiXemBaoCao, objThongKe.MaPhuong)
        End Function
        Public Function ThongKeLoaiHoSo(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKeLoaiHoSo", objThongKe.LinhVuc, objThongKe.TuNgay, objThongKe.DenNgay)
        End Function

        Public Function ThongKeHoSo(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKeHoSo", objThongKe.LinhVuc, objThongKe.LoaiHoSo, objThongKe.TuNgay, objThongKe.DenNgay, objThongKe.LoaiThongKe, objThongKe.TinhTrang, objThongKe.URL)
        End Function

        Public Function ChiTietTiepNhan(ByVal pID As String, ByVal pMalv As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKe_ChiTietTiepNhan", pID, pMalv)
        End Function

        Public Function QuaTrinhGiaiQuyet(ByVal pID As String, ByVal pMalv As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKe_QuaTrinhGiaiQuyet", pID, pMalv)
        End Function
        Public Function ThongKeQuaTinhTiepNhan(ByVal strTuNgay As String, ByVal strDenNgay As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_BaoCaoTinhHinhTiepNhanHoSo", strTuNgay, strDenNgay)
        End Function
        Public Function QuaTrinhXuLY(ByVal pSoBienNhan As String, ByVal pMalv As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKe_QuaTrinhXuLy", pSoBienNhan, pMalv)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="pID"></param>
        ''' <param name="pMalv"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/1/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function LichSuGiaiQuyetHS(ByVal pID As String, ByVal pMalv As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_QuaTrinhGiaiQuyetHoSo", pID, pMalv)
        End Function
    End Class
End Namespace