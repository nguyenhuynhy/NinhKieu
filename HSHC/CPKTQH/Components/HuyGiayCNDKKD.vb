Imports PortalQH
Namespace CPKTQH
    Public Class HuyGiayCNDKKDController

        Public Function getHuyGiayCNDKKD(ByVal pHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_HuyGiayCNDKKD_Get", pHoSoTiepNhanID)
        End Function

        Public Function insHuyGiayCNDKKD(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_HuyGiayCNDKKD_Ins", obj)
            Return Not CBool(str)
        End Function

        Public Function updHuyGiayCNDKKD(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_HuyGiayCNDKKD_Upd", obj)
            Return Not CBool(str)
        End Function

        Public Function delHuyGiayCNDKKD(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_HuyGiayCNDKKD_Del", obj)
            Return Not CBool(str)
        End Function

        Public Function InThongBaoHuyGCNDKKD(ByVal pGiayCNDKKDID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_rptHuyGiayCNDKKD", pGiayCNDKKDID)
        End Function
    End Class
End Namespace

