Imports PortalQH
Namespace THTT
    Public Class QuanLyHoTichController
        Public Function GetThongKeHoSo(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_ThongKeHoSo", TuNgay, DenNgay)
        End Function
        Public Function GetDanhSachHoSo(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal MaKhuVuc As String, ByVal Loai As String, ByVal URL As String) As DataSet
            If InStr(Loai, "_BS") = 0 Then
                Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_DanhSachHoSo", TuNgay, DenNgay, MaKhuVuc, Loai, URL)
            Else
                Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_DanhSachHoSo_BS", TuNgay, DenNgay, MaKhuVuc, Loai, URL)
            End If
        End Function
        Public Function GetChiTietHoSo(ByVal DBName As String, ByVal DBCommon As String, ByVal MaKhuVuc As String, ByVal Loai As String, ByVal ID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_ChiTietHoSo", DBCommon, MaKhuVuc, Loai, ID)
        End Function
        Public Function GetLinhVuc(ByVal DBName As String, ByVal MaKhuVuc As String) As String
            Return DataProvider.Instance.ExecuteScalar(DBName & "..sp_web_GetKhuVuc", MaKhuVuc)
        End Function
    End Class
End Namespace