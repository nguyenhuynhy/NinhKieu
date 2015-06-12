Namespace PortalQH
    Public Class DinhNghiaDuongPhuongController
        Public Function GetAllDuongPhuong(ByVal strMaPhuong As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetAllDUONGPHUONG", strMaPhuong)
        End Function
        Public Sub InsDuongPhuong(ByVal strMaDuong As String, ByVal strMaPhuong As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsDUONGPHUONG", strMaDuong, strMaPhuong)
        End Sub
        Public Sub DelDuongPhuong(ByVal strMaDonVi As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelDUONGPHUONG", strMaDonVi)
        End Sub
    End Class
End Namespace
