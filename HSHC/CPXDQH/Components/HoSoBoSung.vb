Imports PortalQH
Namespace CPXD
    Public Class HoSoBoSungController
        Public Function GetHoSoBoSung(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSung", pID)
        End Function
        Public Function UpdHoSoBoSung(ByVal obj As Object) As String
            'return "" khong thanh cong <> hosobosungid thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHoSoBoSung", obj)
        End Function
        'AnhLH
        Public Function AddHoSoBoSung(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsHoSoBoSung", obj)
            'DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_InsHoSoBoSung", obj)
        End Function
        Public Function AddThongBaoXacMinh(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsThongBaoXacMinh", obj)
        End Function

        Public Function GetHoSoBoSungBySoBienNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetHoSoBoSungBySoBienNhan", obj)
        End Function
        Public Function GetThongBaoXacMinhBySoBienNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetThongBaoXacMinhBySoBienNhan", obj)
        End Function
        Public Function GetHoSoBoSungBySoBienNhan(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSungBySoBienNhan", pSoBienNhan)
        End Function
        Public Function GetQuaHanBoSung(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetQuaHanBoSung", pSoBienNhan)
        End Function
        Public Function CheckHoSoBoSung(ByVal strHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_CheckHoSoBoSung", strHoSoTiepNhanID)
        End Function
        'End AnhLH
    End Class
End Namespace
