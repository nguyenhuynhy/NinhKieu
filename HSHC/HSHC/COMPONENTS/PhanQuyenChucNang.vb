Namespace PortalQH
    Public Class PhanQuyenChucNangController
        Public Function GetItemChucNang(ByVal SelectedTab As Integer) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetItemChucNang", SelectedTab)
        End Function
        Public Sub UpdIsCheckUser(ByVal SelectedTab As Integer, ByVal ItemCode As String, ByVal flgCheck As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_UpdIsCheckUser", SelectedTab, ItemCode, flgCheck)
        End Sub
    End Class

End Namespace
