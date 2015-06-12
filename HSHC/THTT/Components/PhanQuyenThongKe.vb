Imports PortalQH
Namespace THTT
    Public Class PhanQuyenThongKeController
        Public Function Get_LinhVuc(ByVal Db As String, ByVal Id As String, ByVal TabCode As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..GetLinhVuc", Id, TabCode)
        End Function
        Public Sub LV_Update(ByVal Db As String, ByVal Id As String, ByVal Tabcode As String, ByVal ThanhVien As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..UpdLinhVuc", Id, Tabcode, ThanhVien)
        End Sub
    End Class
End Namespace

