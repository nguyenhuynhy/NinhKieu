Imports PortalQH
Namespace CPXD
    Public Class HuyGiayCNDKKDController

        Public Function getHuyGiayCNDKKD(ByVal pSoGiayPhep As String, ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getHUYGIAYPHEPXAYDUNG", pSoGiayPhep, pHoSoTiepNhanID)
        End Function

        Public Function updHuyGiayCNDKKD(ByVal obj As Object) As String
            'return "0": thành công  "1": có lỗi, không thành công
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHUYGIAYPHEPXAYDUNG", obj)
        End Function

        Public Function delHuyGiayCNDKKD(ByVal obj As Object) As String
            'return '0': thanh công, '1':có lỗi, '2':không có hồ sơ không giải quyết ứng với ID này
            Return DataProvider.Instance.ExecuteScalarAuto("sp_delHuyGIAYPHEPXAYDUNG", obj)
        End Function
    End Class
End Namespace

