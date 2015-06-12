Imports PortalQH
Namespace CPLDQH
    Public Class ThoaUocLaoDongController
        Public Function AddThoaUocLaoDong(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsThoaUocLaoDong", obj)
        End Function
        Public Function GetThoaUocLaoDong(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getThoaUocLaoDong", pHoSoTiepNhanID)
        End Function
        Public Sub DelThoaUocLaoDong(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelThoaUocLaoDong", obj)
        End Sub
        Public Function ThongBaoThoaUoc(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptThongBaoThoaUoc", pHoSoTiepNhanID)
        End Function
    End Class
End Namespace