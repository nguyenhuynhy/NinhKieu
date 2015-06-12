Imports PortalQH
Namespace THTT
    Public Class DanhSachNgungController
        Public Function GetPhuong(ByVal LinhVuc As String, ByVal dbcommon As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..GetPhuong", dbcommon)
        End Function
        Public Function DanhSachNgungKD(ByVal LinhVuc As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal Phuong As String, ByVal dbcommon As String, ByVal URL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_DSNgung", TuNgay, DenNgay, Phuong, dbcommon, "", URL)
        End Function
    End Class

End Namespace
