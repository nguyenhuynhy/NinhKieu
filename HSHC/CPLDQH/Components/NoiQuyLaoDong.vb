Imports PortalQH
Namespace CPLDQH
    Public Class NoiQuyLaoDongController
        Public Function AddNoiQuyLaoDong(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsNoiQuyLaoDong", obj)
        End Function
        Public Function GetNoiQuyLaoDong(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_getNoiQuyLaoDong", obj)
        End Function
        Public Sub DelNoiQuyLaoDong(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelNoiQuyLaoDong", obj)
        End Sub
        Public Function ThongBaoNoiQuy(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptThongBaoNoiQuy", pHoSoTiepNhanID)
        End Function
    End Class

End Namespace
