Imports PortalQH
Namespace LICHCONGTAC
    Public Class DanhSachDiaDiemHopController
        Public Function DiaDiem_List(ByVal Db As String, ByVal Url As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_LstDMLOCATION", Url)
        End Function
        Public Sub DiaDiem_Del(ByVal Db As String, ByVal Id As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_DelDMLOCATION", Id)
        End Sub
        Public Function DiaDiem_Get(ByVal Db As String, ByVal Id As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_GetDMLOCATION", Id)
        End Function
        Public Sub DiaDiem_Update(ByVal Db As String, ByVal Id As String, ByVal Ten As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_UpdDMLOCATION", Id, Ten)
        End Sub
        Public Function DiaDiem_Insert(ByVal Db As String, ByVal Ten As String) As String
            Return CType(DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_InsDMLOCATION", Ten), String)
        End Function
    End Class
End Namespace

