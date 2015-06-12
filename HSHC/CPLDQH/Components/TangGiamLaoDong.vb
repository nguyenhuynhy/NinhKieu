Imports PortalQH
Namespace CPLDQH
    Public Class TangGiamLaoDongController
        Public Function AddTangGiamLaoDong(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsTangGiamLaoDong", obj)
        End Function
        Public Function GetTangGiamLaoDong(ByVal pSuDungLaoDongID As String, ByVal pMaKyBaoCao As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getTangGiamLaoDong", pSuDungLaoDongID, pMaKyBaoCao)
        End Function
        Public Sub DelTangGiamLaoDong(ByVal pTangGiamLaoDongID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelTangGiamLaoDong", pTangGiamLaoDongID)
        End Sub
    End Class
End Namespace