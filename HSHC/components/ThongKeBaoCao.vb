Imports System.Configuration
Namespace PORTALQH
    Public Class ThongKeBaoCaoInfo
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

    Public Class ThongKeBaoCaoController
        Public Function ThongKeLinhVuc(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLinhVuc", objThongKe.TuNgay, objThongKe.DenNgay)
        End Function

        Public Function ThongKeLoaiHoSo(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeLoaiHoSo", objThongKe.LinhVuc, objThongKe.TuNgay, objThongKe.DenNgay)
        End Function

        Public Function ThongKeHoSo(ByVal objThongKe As ThongKeBaoCaoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongKeHoSo", objThongKe.LinhVuc, objThongKe.LoaiHoSo, objThongKe.TuNgay, objThongKe.DenNgay, objThongKe.LoaiThongKe, objThongKe.URL)
        End Function

        Public Function ChiTietTiepNhan(ByVal DBName As String, ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_ThongKe_ChiTietTiepNhan", pID)
        End Function

        'Public Function QuaTrinhGiaiQuyet(ByVal DBName As String, ByVal pID As String) As DataSet
        '    Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_ThongKe_QuaTrinhGiaiQuyet", pID, "")
        'End Function
        Public Function QuaTrinhGiaiQuyet(ByVal DBName As String, ByVal pID As String) As DataSet
            If InStr(DBName, ConfigurationSettings.AppSettings("db_hshc")) > 0 Then
                Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_ThongKe_QuaTrinhGiaiQuyet", pID, "")
            Else
                Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_ThongKe_QuaTrinhGiaiQuyet", pID, "")
            End If

        End Function
        Public Function GetHistory(ByVal DBName As String, ByVal pID As String) As DataSet
            If InStr(DBName, ConfigurationSettings.AppSettings("db_hshc")) > 0 Then
                'Return DataProvider.Instance.ExecuteQueryStoreProc(ConfigurationSettings.AppSettings("db_hshc") & "..sp_GetHistory", pID, "")
                Return Nothing
            Else
                If InStr(DBName, ConfigurationSettings.AppSettings("db_cpkt")) > 0 Then
                    Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_GetHistory", pID)
                Else
                    Return Nothing
                End If
            End If

        End Function
    End Class
End Namespace