Imports PortalQH
Namespace CPXD

    Public Class HoSoKhongGiaiQuyetController

        Public Function getHoSoKhongGiaiQuyet(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getHOSOKHONGGIAIQUYET", pID)
        End Function

        Public Function updHoSoKhongGiaiQuyet(ByVal obj As Object) As String
            'return '0': thanh công, '1':có lỗi
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHOSOKHONGGIAIQUYET", obj)
        End Function

        Public Function delHoSoKhongGiaiQuyet(ByVal obj As Object) As String
            'return '0': thanh công, '1':có lỗi, '2':không có hồ sơ không giải quyết ứng với ID này
            Return DataProvider.Instance.ExecuteScalarAuto("sp_delHOSOKHONGGIAIQUYET", obj)
        End Function
        Public Function InThongBaoHoSoKhongGiaiQuyet(ByVal strHoSoTiepNhanId As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InThongBaoHoSoKhongGiaiQuyet", strHoSoTiepNhanId)
        End Function
        Public Function CheckHoSoKhong(ByVal strHoSoTiepNhanID As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_CheckHoSoKhong", strHoSoTiepNhanID)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

