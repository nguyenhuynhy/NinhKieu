Imports PortalQH
Namespace HSHC
    Public Class THQTThuLyController
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Lay danh sach ho so co 1 giai doan thu ly bat ky bi qua han
        ''' </summary>
        ''' <param name="LinhVuc"></param>
        ''' <param name="LoaiHoSo"></param>
        ''' <param name="TuNgay"></param>
        ''' <param name="DenNgay"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/28/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function THQTThuLy(ByVal LinhVuc As String, ByVal LoaiHoSo As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_THQTTLHoSo", LinhVuc, LoaiHoSo, TuNgay, DenNgay)
        End Function
    End Class
End Namespace