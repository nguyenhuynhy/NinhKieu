Imports PortalQH
Public Class DanhMucUserController
    Public Sub AddDanhMuc(ByVal obj As Object, ByVal DBName As String, ByVal strTableName As String)
        DataProvider.Instance.ExecuteScalarAutoByDBName(DBName, "sp_Ins" & strTableName, obj)
    End Sub
End Class
