Imports PortalQH
Namespace CPLDQH
    Public Class ThamDinhDeXuatController
        'AnhLH
        Public Function AddThamDinhDeXuat(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsThamDinhDeXuat", obj)
        End Function
        Public Function GetThamDinhDeXuatBySoBienNhan(ByVal strSoBienNhan As String, ByVal strLoai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetThamDinhDeXuatBySoBienNhan", strSoBienNhan, strLoai)
        End Function
        Public Function CheckKiemTraDeXuat(ByVal strSoBienNhan As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_KiemTraHoSoDeXuat", strSoBienNhan)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Sub DelThamDinhDeXuat(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelThamDinhDeXuat", obj)
        End Sub
        'End AnhLH
        'Truongtd'
        Public Function InBaoCaoDeXuat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InBaoCaoKiemTraDeXuat", strHoSoTiepNhanID)
        End Function
        Public Function InPhieuChuyenKhaoSat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuChuyenKhaoSat", strHoSoTiepNhanID)
        End Function
        'end truongtd'
    End Class
End Namespace

