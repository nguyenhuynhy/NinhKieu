Imports PortalQH
Namespace THTT
    Public Class ThongKeKinhDoanhController
        Public Function ThongKeKinhDoanh_TheoNganh(ByVal TuNgay As String, ByVal DenNgay As String, ByVal LinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_KinhDoanhNhomNganh", TuNgay, DenNgay, "")
        End Function
        Public Function ThongKeKinhDoanh_TheoPhuong(ByVal TuNgay As String, ByVal DenNgay As String, ByVal dbcommon As String, ByVal LinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_KinhDoanhPhuong", TuNgay, DenNgay, dbcommon, "")
        End Function
        Public Function ThongKeKinhDoanh_TheoNam(ByVal LinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_KinhDoanhNam", "")
        End Function
    End Class
End Namespace

