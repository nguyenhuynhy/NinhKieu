Imports PortalQH
Namespace HSHC
    Public Class PhieuTraHoSoController
        Public Function UpdPhieuTraHoSo(ByVal obj As Object) As String
            'return "" khong thanh cong <> hosobosungid thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updPhieuTraHoSo", obj)
        End Function
        Public Function InPhieuTraHoSo(ByVal obj As Object) As DataSet
            'return "" khong thanh cong <> hosobosungid thanh cong
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_InPhieuTraHoSo", obj)
        End Function
    End Class
End Namespace
