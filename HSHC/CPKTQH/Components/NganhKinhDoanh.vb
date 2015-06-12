Imports PortalQH
Namespace CPKTQH
    Public Class NganhKinhDoanhController

        'lấy các ngành kinh doanh cấp 0 làm lĩnh vực cấp phép
        Public Function getLinhVucCapPhep() As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getLinhVucCapPhep")
        End Function

        'lấy các ngành kinh doanh cấp 1 làm ngành kinh doanh chính
        Public Function getNganhKinhDoanhChinh(Optional ByVal pMaLinhVucCapPhep As String = Nothing) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getNganhKinhDoanhChinh", pMaLinhVucCapPhep)
        End Function
        'lấy các ngành kinh doanh cấp 0 làm lĩnh vực cấp phép
        Public Function getPhuongThucKinhDoanh() As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getPhuongThucKinhDoanh")
        End Function
        Public Function getPhuongThucNganhNghe() As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getPhuongThucNganhNghe")
        End Function

    End Class
End Namespace