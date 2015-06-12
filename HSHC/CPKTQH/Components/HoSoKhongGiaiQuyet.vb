Imports PortalQH
Namespace CPKTQH

    Public Class HoSoKhongGiaiQuyetController
        'HoangLn
        Public Function getHoSoKhongGiaiQuyet(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getHOSOKHONGGIAIQUYET", pID)
        End Function

        Public Function updHoSoKhongGiaiQuyet(ByVal obj As Object) As String
            'return '0': thanh công, '1':có lỗi
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHOSOKHONGGIAIQUYET", obj)
        End Function
        Public Function delHoSoKhongGiaiQuyet(ByVal ParamArray arrParams() As Object) As String
            Return DataProvider.Instance.ExecuteScalar("sp_DelHOSOKHONGGIAIQUYET", arrParams)
        End Function

        'Public Function delHoSoKhongGiaiQuyet(ByVal obj As Object) As String
        '    'return '0': thanh công, '1':có lỗi, '2':không có hồ sơ không giải quyết ứng với ID này
        '    Return DataProvider.Instance.ExecuteScalarAuto("sp_delHOSOKHONGGIAIQUYET", obj)
        'End Function
        Public Function InHoSoKhongGiaiQuyet(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InThongBaoHoSoKhongGiaiQuyet", strHoSoTiepNhanID)
        End Function
    End Class
End Namespace

