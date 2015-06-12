Imports PortalQH
Namespace THTT
    'Public Class ChiTietDoThiController
    '    Public Function ChiTiet_I(ByVal ID As String, ByVal LinhVuc As String, ByVal dbcommon As String) As DataSet
    '        Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_ChiTietXD_I", ID, dbcommon)
    '    End Function
    '    Public Function ChiTiet_II(ByVal ID As String, ByVal LinhVuc As String, ByVal dbVPDT As String) As DataSet
    '        Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_web_ChiTietXD_II", ID, dbVPDT)
    '    End Function
    'End Class
    Public Class ChiTIetDoThiController
        Public Function ChiTiet_I(ByVal ID As String, ByVal Ngaycap As String, ByVal LinhVuc As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_ChiTietCPXD", ID, Ngaycap, Loai)
        End Function
        Public Function ChiTiet_II(ByVal ID As String, ByVal Ngaycap As String, ByVal LinhVuc As String, ByVal Loai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_ChiTietCPXD", ID, Ngaycap, Loai)
        End Function
    End Class
End Namespace

