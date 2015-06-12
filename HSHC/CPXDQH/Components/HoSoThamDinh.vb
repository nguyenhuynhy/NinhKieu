Imports PortalQH
Namespace CPXD
    Public Class HoSoThamDinhController
        Public Function AddHoSoThamDinh(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsHoSoThamDinh", obj)
        End Function
        Public Function GetHoSoThamDinhBySoBienNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetHoSoThamDinhBySoBienNhan", obj)
        End Function
        Public Sub DelHoSoThamDinh(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelHoSoThamDinh", obj)
        End Sub
        'End AnhLH
        'Truongtd'
        Public Function InChuyenHoSoThamDinh(ByVal strSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuChuyenHoSoThamDinh", strSoBienNhan)
        End Function
        Public Function InPhieuChuyenKhaoSat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuChuyenKhaoSat", strHoSoTiepNhanID)
        End Function

    End Class
End Namespace
