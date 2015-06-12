Imports PortalQH
Namespace LICHCONGTAC
    Public Class DanhSachCongViecController
        Public Function CongViec_List(ByVal Db As String, ByVal Url As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_LstCongViec", Url)
        End Function
        Public Sub CongViec_Del(ByVal Db As String, ByVal Id As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_DelCongViec", Id)
        End Sub
        Public Function CongViec_Get(ByVal Db As String, ByVal Id As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_GetCongViec", Id)
        End Function
        Public Sub CongViec_Update(ByVal Db As String, ByVal Id As String, ByVal Ten As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_UpdCongViec", Id, Ten)
        End Sub
        Public Function CongViec_Insert(ByVal Db As String, ByVal Id As String, ByVal Ten As String) As String
            Return CType(DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_InsCongViec", Id, Ten), String)
        End Function
    End Class
End Namespace

