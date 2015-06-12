Imports PortalQH
Namespace THTT
    Public Class ChiTietHoCaTheController
        Public Function ChiTiet_I(ByVal ID As String, ByVal LinhVuc As String, ByVal dbcommon As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_ChiTietCT_I", ID, dbcommon, "")
        End Function
        Public Function ChiTiet_II(ByVal ID As String, ByVal LinhVuc As String, ByVal dbcommon As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_ChiTietCT_II", ID, "", dbcommon)
        End Function
    End Class
End Namespace

