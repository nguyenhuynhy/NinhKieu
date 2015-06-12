Imports PortalQH
Namespace CPKTQH
    Public Class PhieuKhaoSatController
        Public Function LstNoiDungKhaoSat(ByVal strTrinhThamDinhId As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_LstNoiDungKhaoSat", strTrinhThamDinhId)
        End Function
        Public Sub AddNoiDungKhaoSat(ByVal strTrinhThamDinhId As String, _
                                          ByVal strNoiDungKhaoSat As String, _
                                          ByVal strKetQuaKhaoSat As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsNOIDUNGKHAOSAT", strTrinhThamDinhId, strNoiDungKhaoSat, strKetQuaKhaoSat)
        End Sub
        Public Sub DelNoiDungKhaoSat(ByVal strTrinhThamDinhID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_DelNOIDUNGKHAOSAT", strTrinhThamDinhID)
        End Sub
        Public Sub AddPhieuKhaoSat(ByVal obj As Object)
            DataProvider.Instance.ExecuteScalarAuto("sp_InsPHIEUKHAOSAT", obj)
        End Sub
        Public Sub DelPhieuKhaoSat(ByVal strTrinhThamDinhID As String)
            DataProvider.Instance.ExecuteScalarAuto("sp_DelPHIEUKHAOSAT", strTrinhThamDinhID)
        End Sub
        Public Function GetPhieuKhaoSat(ByVal strTrinhThamDinhID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetByIDPHIEUKHAOSAT", strTrinhThamDinhID)
        End Function
        Public Function InPhieuKhaoSat(ByVal strTrinhThamDinhID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuKhaoSat", strTrinhThamDinhID)
        End Function
        Public Function InNoiDungKhaoSat(ByVal strTrinhThamDinhID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InNoiDungKhaoSat", strTrinhThamDinhID)
        End Function
    End Class
End Namespace
