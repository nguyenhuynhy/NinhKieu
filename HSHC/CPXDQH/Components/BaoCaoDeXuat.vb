Imports PortalQH
Namespace CPXD
    Public Class BaoCaoDeXuatController
        'AnhLH
        Public Function AddBaoCaoDeXuat(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsBAOCAODEXUAT", obj)
        End Function
        Public Function GetBaoCaoDeXuatBySoBienNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetBaoCaoDeXuatBySoBienNhan", obj)
        End Function
        Public Sub DelBaoCaoDeXuat(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelBaoCaoDeXuat", obj)
        End Sub
        'End AnhLH
        'Truongtd'
        Public Function InBaoCaoDeXuat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InBaoCaoKiemTraDeXuat", strHoSoTiepNhanID)
        End Function
        Public Function InPhieuChuyenKhaoSat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuChuyenKhaoSat", strHoSoTiepNhanID)
        End Function
        Public Function CheckBaoCaoDeXuat(ByVal strHoSoTiepNhanID As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_CheckBaoCaoDeXuat", strHoSoTiepNhanID)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        'end truongtd'
    End Class
End Namespace

