Imports PortalQH
Namespace THTT
    Public Class ThongKeDoThiController
        Public Function ThongKeDoThi_TheoPhuong(ByVal TuNgay As String, ByVal DenNgay As String, ByVal dbcommon As String, ByVal LinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(LinhVuc & "..sp_Web_CPXDThongKePhuong", dbcommon, TuNgay, DenNgay)
        End Function
    End Class
End Namespace

