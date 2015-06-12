Imports PortalQH
Namespace HSHC
    Public Class TinhTrangHoSoPhuongXaController
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
        Public Sub UpdChuyenXuLyMotCuaNhieuHS(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_UpdChuyenXuLyMotCuaNhieuHoSo", obj)
        End Sub
        Public Sub UpdChuyenXuLyThuLePhi(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_UpdChuyenXuLyThuLePhi", obj)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Phuc hoi lai tinh trang truoc cua ho so
        ''' </summary>
        ''' <param name="MaLinhVuc"></param>
        ''' <param name="TabCode"></param>
        ''' <param name="HoSoTiepNhanID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/27/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub restoreTinhTrangHoSo(ByVal MaLinhVuc As String, ByVal TabCode As String, ByVal HoSoTiepNhanID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_CapNhatTinhHinhThuLy", MaLinhVuc, TabCode, "", "", "", "", HoSoTiepNhanID, "")
        End Sub
        Public Function GetChuyenXuLy(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetChuyenXuLy", obj)
        End Function
        Public Function GetChuyenXuLyMotCuaNhieuHS(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetChuyenXuLyMotCuaNhieuHS", obj)
        End Function
        Public Function GetChuyenXuLyThuLePhi(ByVal obj As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetChuyenXuLyThuLePhi", obj)
        End Function
    End Class
End Namespace

