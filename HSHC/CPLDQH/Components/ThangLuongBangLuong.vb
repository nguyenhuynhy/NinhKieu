Imports PortalQH
Namespace CPLDQH
    Public Class ThangLuongBangLuongController
        Public Function AddThangLuongBangLuong(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsThangLuongBangLuong", obj)
        End Function
        Public Function GetThangLuongBangLuong(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_getThangLuongBangLuong", obj)
        End Function
        Public Sub DelThangLuongBangLuong(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelThangLuongBangLuong", obj)
        End Sub
        Public Function ThongBaoThangLuongBangLuong(ByVal pHoSoTiepNhanID As String, ByVal pInLan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptThongBaoThangLuongBangLuong", pHoSoTiepNhanID, pInLan)
        End Function
    End Class
End Namespace