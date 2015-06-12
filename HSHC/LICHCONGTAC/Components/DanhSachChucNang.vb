Imports PortalQH
Namespace LICHCONGTAC
    Public Class DanhSachChucNangController
        Public Function ChucNang_List(ByVal Db As String, ByVal Url As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_LstDMCHUCNANG", Url)
        End Function
        Public Sub ChucNang_Del(ByVal Db As String, ByVal Id As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_DelDMCHUCNANG", Id)
        End Sub
        Public Function ChucNang_Get(ByVal Db As String, ByVal Id As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..Web_GetDMCHUCNANG", Id)
        End Function
        Public Sub ChucNang_Update(ByVal Db As String, ByVal Id As String, ByVal Ten As String, ByVal TenTrang As String, ByVal Stt As String, ByVal TuongDuong As String, ByVal isshow As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_UpdDMCHUCNANG", Id, Ten, TenTrang, Stt, TuongDuong, isshow)
        End Sub
        Public Function ChucNang_Insert(ByVal Db As String, ByVal Id As String, ByVal Ten As String, ByVal TenTrang As String, ByVal Stt As String, ByVal TuongDuong As String, ByVal isshow As String) As String
            Return CType(DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..Web_InsDMCHUCNANG", Id, Ten, TenTrang, Stt, TuongDuong, isshow), String)
        End Function
        Public Function ChucNang_ListPhanQuyen(ByVal Db As String, ByVal Id As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(Db & "..sp_GetPhanQuyenChucNang", Id)
        End Function
        Public Sub ChucNang_DelPhanQuyen(ByVal Db As String, ByVal Id As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..sp_DelPhanQuyenChucNang", Id)
        End Sub
        Public Function ChucNang_InsertPhanQuyen(ByVal Db As String, ByVal TenTrang As String, ByVal VaiTro As String) As String
            Return CType(DataProvider.Instance.ExecuteNonQueryStoreProc(Db & "..sp_InsPhanQuyenChucNang", TenTrang, VaiTro), String)
        End Function
    End Class
End Namespace

