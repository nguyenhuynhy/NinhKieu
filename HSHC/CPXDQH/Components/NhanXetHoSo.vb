Imports PortalQH
Namespace CPXD
    Public Class NhanXetHoSoController
        Public Function AddNhanXetHoSo(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsNhanXetHoSo", obj)
        End Function
        Public Function UpdateNhanXetHoSo(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_UpdNhanXetHoSo", obj)
        End Function
        Public Function GetNhanXetHoSo(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNhanXetHoSo", pHoSoTiepNhanID)
        End Function
        Public Function LstNhanXetHoSo(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_LstNhanXetHoSo", pHoSoTiepNhanID)
        End Function
        Public Sub DelNhanXetHoSo(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelNhanXetHoSo", obj)
        End Sub
    End Class
End Namespace
