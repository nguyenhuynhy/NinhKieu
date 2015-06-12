Imports PortalQH
Namespace THTT
    Public Class DanhSachCapPhoBanController
        Public Function DanhSachCapPhoBan(ByVal LinhVuc As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal dbcommon As String, ByVal URL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_CapPhoBan", dbcommon, "", TuNgay, DenNgay, URL)
        End Function
    End Class
End Namespace

