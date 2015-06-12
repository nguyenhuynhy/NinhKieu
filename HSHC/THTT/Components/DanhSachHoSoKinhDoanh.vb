Imports PortalQH
Namespace THTT
    Public Class DanhSachHoSoKDController
        Public Function DanhSachHoSoKD_TheoNganh(ByVal TuNgay As String, ByVal DenNgay As String, ByVal Val As String, ByVal Group As String, ByVal LinhVuc As String, ByVal dbcommon As String, ByVal URL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_DSHoCaThe_Nganh", TuNgay, DenNgay, Val, Group, dbcommon, "", URL)
        End Function
        Public Function DanhSachHoSoKD_TheoPhuong(ByVal TuNgay As String, ByVal DenNgay As String, ByVal Val As String, ByVal Group As String, ByVal LinhVuc As String, ByVal dbcommon As String, ByVal URL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_DSHoCaThe_Phuong", TuNgay, DenNgay, Val, Group, dbcommon, "", URL)
        End Function
        Public Function DanhSachHoSoKD_TheoNam(ByVal Val As String, ByVal Group As String, ByVal LinhVuc As String, ByVal dbcommon As String, ByVal URL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_DSHoCaThe_Nam", Val, Group, dbcommon, "", URL)
        End Function
    End Class
End Namespace

