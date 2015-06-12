Imports PortalQH
Namespace CPXD
    Public Class SuaChuaNguyenTrangController
        Public Function AddSuaChuaNguyenTrang(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsSuaChuaNguyenTrang", obj)
        End Function
        Public Function GetSuaChuaNguyenTrang(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getSuaChuaNguyenTrang", pHoSoTiepNhanID)
        End Function
        Public Sub DelSuaChuaNguyenTrang(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelSuaChuaNguyenTrang", obj)
        End Sub
    End Class
End Namespace
