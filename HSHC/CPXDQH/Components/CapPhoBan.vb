Imports PortalQH
Namespace CPXD
    Public Class CapPhoBanInfo

    End Class
    Public Class CapPhoBanController
        'Public Function AddCapPhoBan(ByVal obj As Object) As String
        '    Return DataProvider.Instance.ExecuteScalarAuto("sp_InsCAPPHOBAN_CPXD", obj)
        'End Function
        'Public Function updCapPhoBan(ByVal ParamArray arrParams() As Object) As Integer
        '    'Return DataProvider.Instance.ExecuteScalarAuto("sp_InsCAPPHOBAN_CPXD", obj)
        '    Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsCAPPHOBAN_CPXD", arrParams)
        'End Function
        'Public Function GetCapPhoBan(ByVal pHoSoTiepNhanID As String) As DataSet
        '    'Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCapPhoBan", pHoSoTiepNhanID)
        '    Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCapPhoBan_CPXD", pHoSoTiepNhanID)
        'End Function
        'Public Function delCapPhoBan(ByVal ParamArray arrParams() As Object) As Integer
        '    'DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelCapPhoBan_CPXD", obj)
        '    Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelCapPhoBan_CPXD", arrParams)
        'End Function
        Public Function getGPXD(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getGPXD", SoGiayPhep)
        End Function
        Public Function AddCapPhoBan(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsCAPPHOBAN_CPXD", obj)
        End Function
        Public Function GetCapPhoBan(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCapPhoBan_CPXD", pHoSoTiepNhanID)
        End Function
        Public Sub DelCapPhoBan(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelCapPhoBan_CPXD", obj)
        End Sub
        Public Function InBaoCaoDeXuat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InBaoCaoDeXuatPhoBan", strHoSoTiepNhanID)
        End Function
    End Class
End Namespace

