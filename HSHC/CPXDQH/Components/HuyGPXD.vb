Imports PortalQH
Namespace CPXD
    Public Class HuyGPXDController

        Public Function getHuyGPXD(ByVal pSoGiayPhep As String, ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getHUYGIAYCNDKKD", pSoGiayPhep, pHoSoTiepNhanID)
        End Function

        Public Function updHuyGPXD(ByVal obj As Object) As String
            'return "0": thành công  "1": có lỗi, không thành công
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHUYGIAYCNDKKD", obj)
        End Function

        Public Function delHuyGPXD(ByVal obj As Object) As String
            'return '0': thanh công, '1':có lỗi, '2':không có hồ sơ không giải quyết ứng với ID này
            Return DataProvider.Instance.ExecuteScalarAuto("sp_delHuyGiayCNDKKD", obj)
        End Function
    End Class
End Namespace

