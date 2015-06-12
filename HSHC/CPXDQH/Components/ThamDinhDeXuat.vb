Imports PortalQH
Namespace CPXD
    Public Class BaoCaoDeXuatController1
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
        'end truongtd'
    End Class
End Namespace

