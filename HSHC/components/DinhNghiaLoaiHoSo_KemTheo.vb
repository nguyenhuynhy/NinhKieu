Namespace PortalQH
    Public Class DinhNghiaLoaiHoSo_KemTheoController
        Public Function GetLoaiHoSoHoSoKemTheo(ByVal pLinhVuc As String, ByVal pLoaiHoSo As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getLoaiHoSoHoSoKemTheo", pLinhVuc, pLoaiHoSo)
        End Function
        Public Sub DelLoaiHoSoHoSoKemTheo(ByVal pMaLinhVuc As String, ByVal pMaLoaiHoSo As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelLoaiHoSoHoSoKemTheo", pMaLinhVuc, pMaLoaiHoSo)
        End Sub
        Public Sub AddLoaiHoSoHoSoKemTheo(ByVal pMaLinhVuc As String, ByVal pMaLoaiHoSo As String, ByVal pMaHoSoKemTheo As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsLoaiHoSoHoSoKemTheo", pMaLinhVuc, pMaLoaiHoSo, pMaHoSoKemTheo)
        End Sub
    End Class
End Namespace

