Imports PortalQH
Namespace LICHCONGTAC
    Public Class DanhSachNhomController
        Public Function Nhom_List(ByVal Db As String, ByVal Url As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_LstDMNHOM", Url)
        End Function
        Public Sub Nhom_Del(ByVal Db As String, ByVal Id As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_DelDMNHOM", Id)
        End Sub
        Public Function Nhom_Get(ByVal Db As String, ByVal Id As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_GetDMNHOM", Id)
        End Function
        Public Sub Nhom_Update(ByVal Db As String, ByVal Id As String, ByVal Ten As String, ByVal ThanhVien As String, ByVal ChuTri As String, ByVal Stt As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_UpdDMNHOM", Id, Ten, ThanhVien, ChuTri, Stt)
        End Sub
        Public Function Nhom_Insert(ByVal Db As String, ByVal Id As String, ByVal Ten As String, ByVal ThanhVien As String, ByVal ChuTri As String, ByVal Stt As String) As String
            Return CType(DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_InsDMNHOM", Id, Ten, ThanhVien, ChuTri, Stt), String)
        End Function
        Public Function Nhom_GetCodeID(ByVal Db As String, ByVal Pref As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Get_CodeID_In", Pref)
        End Function
    End Class
End Namespace

