Imports PortalQH
Namespace CPKTQH
    Public Class ThuHoiCNDKKDController
        Public Function getThuHoiCNDKKD(ByVal pGiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThuHoiCNDKKD_Get", pGiayCNDKKDID)
        End Function

        Public Function insThuHoiCNDKKD(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_ThuHoiCNDKKD_Ins", obj)
            Return Not CBool(str)
        End Function

        Public Function updThuHoiCNDKKD(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_ThuHoiCNDKKD_Upd", obj)
            Return Not CBool(str)
        End Function

        Public Function delThuHoiCNDKKD(ByVal pThuHoiCNDKKDID As String) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_ThuHoiCNDKKD_Del", pThuHoiCNDKKDID)
            Return Not CBool(str)
        End Function
    End Class
End Namespace