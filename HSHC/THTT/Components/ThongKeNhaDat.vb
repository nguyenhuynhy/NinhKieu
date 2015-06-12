Imports PortalQH
Namespace THTT
    Public Class ThongKeNhaDatController
        Public Function ThongKeNhaDat_TheoLoaiHoSo(ByVal TuNgay As String, ByVal DenNgay As String, ByVal dbcommon As String, ByVal LinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_NHADATThongKeLoaiHoSo", dbcommon, TuNgay, DenNgay)
        End Function
    End Class
End Namespace

