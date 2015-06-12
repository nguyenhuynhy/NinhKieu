Imports PortalQH
Namespace CPXD
    Public Class TinhTrangHoSoController
        Public Function UpdTinhTrangHoSo(ByVal pMaLinhVuc As String, ByVal pTabCode As String, _
                                                ByVal pMaTinhTrangXuLy As String, ByVal pMaNguoiTacNghiep As String, _
                                                ByVal pMaNguoiDen As String, ByVal pMaNguoiNhan As String, _
                                                ByVal pHoSoTiepNhanID As String, ByVal pNoiDungThuLy As String) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_updTinhTrangHoSo", pMaLinhVuc, pTabCode, pMaTinhTrangXuLy, _
                    pMaNguoiTacNghiep, pMaNguoiDen, pMaNguoiNhan, pHoSoTiepNhanID, pNoiDungThuLy)
        End Function
        Public Function updTinhTrangHoSo_LDK(ByVal pHoSoTiepNhanID As String, ByVal pMaTinhTrangHoSo As String, _
                            ByVal pMaTinhTrangXuLy As String, ByVal pMaNguoiTacNghiep As String) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_updTinhTrangHoSo_LDK", pHoSoTiepNhanID, pMaTinhTrangHoSo, pMaTinhTrangXuLy, pMaNguoiTacNghiep)
        End Function
        Public Sub UpdChuyenXuLy(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_UpdChuyenXuLy", obj)
        End Sub
        Public Function GetChuyenXuLy(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetChuyenXuLy", obj)
        End Function
    End Class
End Namespace

