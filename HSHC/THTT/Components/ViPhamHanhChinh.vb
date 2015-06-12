Imports PortalQH
Namespace THTT
    Public Class ViPhamHanhChinhController
        Public Function GetHoSoVPHC(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_TinhhinhhosoVP", TuNgay, DenNgay)
        End Function
        Public Function GetHoSoVPHCByLoai(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal DBCommon As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_Web_TINHHINHHOSOVP_DS", TuNgay, DenNgay, DBCommon, Loai)
        End Function
        Public Function GetChiTietQuyetDinh(ByVal DBName As String, ByVal DBCommon As String, ByVal ID As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_ChiTietQuyetDinh", DBCommon, ID, Loai)
        End Function
        Public Function GetTinhTrangXuLy(ByVal DBName As String, ByVal DBCommon As String, ByVal ID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_TTRANGXLY_DS", DBCommon, ID)
        End Function
        Public Function GetHoSoVPHCLoaiHoSo(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal LinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_TinhhinhhosoVPLoaiHoSo", TuNgay, DenNgay, LinhVuc)
        End Function
    End Class
End Namespace