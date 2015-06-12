Imports PortalQH
Namespace CPKTQH
    Public Class CapPhoBanInfo

    End Class
    Public Class CapPhoBanController
        'HoangLN
        Public Function getSoGiayPhep(ByVal SoBienNhan As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_SoGiayPhepCapPhoBan_GetBySoBienNhan", SoBienNhan)
        End Function
        Public Function getSoLanCapPhoBan(ByVal SoGiayPhep As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_SoLanCapPhoBan_Get", SoGiayPhep)
        End Function
        Public Function getThongTinCapPhoBan(ByVal SoGiayPhep As String, ByVal SoLan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongTinCapPhoBan_Get", SoGiayPhep, SoLan)
        End Function
        Public Sub UpdCapPhoBan(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_CapPhoBan_Upd", arrParams)
        End Sub
        Public Sub DelCapPhoBan(ByVal SoGiayPhep As String, ByVal SoLan As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_CapPhoBan_Del", SoGiayPhep, SoLan)
        End Sub
        '---------------------------
        Public Function AddCapPhoBan(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsCAPPHOBAN", obj)
        End Function
        Public Function GetCapPhoBan(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCapPhoBan", pHoSoTiepNhanID)
        End Function

    End Class
End Namespace

