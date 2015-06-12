Imports PortalQH
Namespace THTT
    Public Class HoSoChungThucController
        Public Function GetHoSoChungThuc(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_Chungthuc", TuNgay, DenNgay)
        End Function
        Public Function GetHoSoChungThucByLoai(ByVal DBName As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_List_CT", TuNgay, DenNgay, Loai)
        End Function
        Public Function GetHoSoChungThucChiTiet(ByVal DBName As String, ByVal SoChungThuc As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_chitiet_CT", SoChungThuc, Loai)
        End Function
        Public Function GetHoSoChungThucChiTiet2(ByVal DBName As String, ByVal SoChungThuc As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(DBName & "..sp_web_chitiet_CT2", SoChungThuc, Loai)
        End Function
    End Class
End Namespace
