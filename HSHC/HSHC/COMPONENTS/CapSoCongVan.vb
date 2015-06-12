Imports PortalQH
Namespace HSHC
    Public Class CongVanController
        Public Function getCongVan(ByVal pMaHoSo As String, _
                                                    ByVal pMaNhomCongVan As String _
                                                    ) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getCongVan", pMaHoSo, pMaNhomCongVan)
        End Function

        Public Function insCongVan(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_insCongVan", obj)
        End Function

        Public Function delCongVan(ByVal obj As Object) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_delCongVan", obj)
        End Function
    End Class
End Namespace