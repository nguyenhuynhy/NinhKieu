Imports PortalQH
Namespace CPKTQH
    Public Class DinhNghiaPhuongThucNganhNgheController
        Public Function GetAllPhuongThucNganhNghe(ByVal strMaPhuongThucKinhDoanh As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetAllPhuongThucNganhNghe", strMaPhuongThucKinhDoanh)
        End Function
        Public Sub InsPhuongThucNganhNghe(ByVal strMaNganhNgheKinhDoanh As String, ByVal strMaPhuongThucKinhDoanh As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsPhuongThucNganhNghe", strMaNganhNgheKinhDoanh, strMaPhuongThucKinhDoanh)
        End Sub
        Public Sub DelPhuongThucNganhNghe(ByVal strMaDonVi As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelPhuongThucNganhNghe", strMaDonVi)
        End Sub
    End Class
End Namespace

