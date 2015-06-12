Imports PortalQH
Namespace CPXD
    Public Class CapMoiGPXDController
        Public Function AddGiayPhepXayDung(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGiayPhepXayDung", obj)
        End Function
        Public Function AddGiayPhepXayDungDK(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsGiayPhepXayDungDK", obj)
        End Function
        Public Function GetGiayPhepXayDung(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGiayPhepXayDung", pHoSoTiepNhanID)
        End Function
        Public Sub DelGiayPhepXayDung(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelGiayPhepXayDung", obj)
        End Sub
        Public Function InGiayPhepXayDung(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptGiayPhepXayDung", strHoSoTiepNhanID)
        End Function
        Public Function InGiayPhepXayDungDieuChinh(ByVal strHoSoTiepNhanID As String, ByVal strSoGiayPhepTruoc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptGiayPhepXayDungDieuChinh", strHoSoTiepNhanID, strSoGiayPhepTruoc)
        End Function
        Public Function GetGiayPhepXayDungByID(ByVal strID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetByIDGIAYPHEPXAYDUNG", strID)
        End Function
        Public Function KiemTraDiaChiXayDung(ByVal strHoSoTiepNhanID As String) As Boolean
            If DataProvider.Instance.ExecuteScalar("sp_KiemTraDiaChiXayDung", strHoSoTiepNhanID) = "0" Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
