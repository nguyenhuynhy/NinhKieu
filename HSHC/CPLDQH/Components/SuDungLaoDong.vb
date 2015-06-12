Imports PortalQH
Namespace CPLDQH
    Public Class SuDungLaoDongController
        Public Function AddSuDungLaoDong(ByVal obj As Object) As String
            Return CType(DataProvider.Instance.ExecuteScalarAuto("sp_InsSuDungLaoDong", obj), String)
        End Function
        Public Function GetSuDungLaoDong(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getSuDungLaoDong", pHoSoTiepNhanID)
        End Function
        Public Sub DelSuDungLaoDong(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelSuDungLaoDong", obj)
        End Sub
        'su dung cho chuc nang dau ky
        Public Function GetSuDungLaoDong_DauKy(ByVal pSuDungLaoDongID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getSuDungLaoDongDauKy", pSuDungLaoDongID)
        End Function

        'Người tạo : TuanNH
        'Ngày tạo  : 12/04/2006
        'Mục đích  : Tìm kiếm doanh nghiệp khi khai báo tăng giảm lao động
        Public Function TimKiemDoanhNghiep(ByVal pHoten As String, ByVal pTenChuDonVi As String, ByVal pSoNha As String, ByVal pMaDuong As String, ByVal pMaPhuong As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_TimKiemDoanhNghiep", pHoten, pTenChuDonVi, pSoNha, pMaDuong, pMaPhuong)
            'Return DataProvider.Instance.ExecuteQueryStoreProc("FSSCPKTQH..sp_GiayCNDKKD_Lst", "", "", "", "", "", "", "", "", "")
        End Function

        Public Function GetSuDungLaoDongByID(ByVal pSuDungLaoDongID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_SuDungLaoDongGetByID", pSuDungLaoDongID)
        End Function

        Public Function AddBienDongLaoDong(ByVal obj As Object) As String
            Return CType(DataProvider.Instance.ExecuteScalarAuto("sp_InsBienDongLaoDong", obj), String)
        End Function

        Public Sub DelBienDongLaoDong(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelBienDongLaoDong", obj)
        End Sub

        Public Function GetBienDongLaoDong(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetBienDongLaoDong", pHoSoTiepNhanID)
        End Function

        Public Function AddKhaiTrinhTangGiam(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_InsKhaiTrinhTangGiam", obj)
        End Function

        Public Sub DelKhaiTrinhTangGiam(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_DelKhaiTrinhTangGiam", obj)
        End Sub

        Public Function GetKhaiTrinhTangGiam(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetKhaiTrinhTangGiam", pHoSoTiepNhanID)
        End Function

        'end TuanNH thêm mới

    End Class
End Namespace