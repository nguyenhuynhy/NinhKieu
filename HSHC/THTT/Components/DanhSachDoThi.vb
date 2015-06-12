Imports PortalQH
Namespace THTT
    Public Class DanhSachDoThiController
        Public Function DanhSachDoThiPhuong_DS(ByVal TuNgay As String, ByVal DenNgay As String, _
                        ByVal Val As String, ByVal Group As String, ByVal Cat As String, _
                        ByVal LinhVuc As String, ByVal dbcommon As String, ByVal LoaiCP As String, ByVal URL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_DSCPXD_Phuong", dbcommon, TuNgay, _
                    DenNgay, Val, LoaiCP, URL)
        End Function
    End Class
    

End Namespace

