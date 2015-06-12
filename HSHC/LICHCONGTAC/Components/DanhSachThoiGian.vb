Imports PortalQH
Namespace LICHCONGTAC
    Public Class DanhSachThoiGianController
        Public Function ThoiGian_List(ByVal Db As String, ByVal Url As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_LstParam", Url)
        End Function
        Public Sub ThoiGian_Del(ByVal Db As String, ByVal Id As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_DelParam", Id)
        End Sub
        Public Function ThoiGian_Get(ByVal Db As String, ByVal Id As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_GetParam", Id)
        End Function
        Public Sub ThoiGian_Update(ByVal Db As String, ByVal Id As String, ByVal Ten As String, ByVal Value As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_UpdParam", Id, Ten, Value)
        End Sub
        Public Function ThoiGian_Insert(ByVal Db As String, ByVal ID As String, ByVal Ten As String, ByVal Value As String) As String
            Return CType(DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_InsParam", ID, Ten, Value), String)
        End Function
    End Class
End Namespace

