Imports PortalQH
Namespace HSHC
    Public Class DanhSachHSQuaHanController
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
        '''     [phuocdd]   Oct 15th 2007   Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function DanhSachHSQuaHan(ByVal LinhVuc As String, ByVal LoaiHoSo As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal UserName As String, ByVal MaTinhTrang As String) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_DanhSachHSQuaHan", LinhVuc, LoaiHoSo, TuNgay, DenNgay, UserName, MaTinhTrang)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="LinhVuc"></param>
        ''' <param name="LoaiHoSo"></param>
        ''' <param name="TuNgay"></param>
        ''' <param name="DenNgay"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	Oct 4th 2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function DanhSachHSChuaGQQuaHan(ByVal LinhVuc As String, ByVal LoaiHoSo As String, ByVal TuNgay As String, ByVal DenNgay As String) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_ThongKeHoSoChuaGQQuaHan", LinhVuc, LoaiHoSo, TuNgay, DenNgay)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="LinhVuc"></param>
        ''' <param name="LoaiHoSo"></param>
        ''' <param name="TuNgay"></param>
        ''' <param name="DenNgay"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	Oct 4th 2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function DanhSachHSChuaGQQuaHanByUser(ByVal LinhVuc As String, ByVal LoaiHoSo As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal UserID As String) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_ThongKeHoSoChuaGQQuaHanByUser", LinhVuc, LoaiHoSo, TuNgay, DenNgay, UserID)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="LinhVuc"></param>
        ''' <param name="LoaiHoSo"></param>
        ''' <param name="TuNgay"></param>
        ''' <param name="DenNgay"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	Oct 4th 2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function DanhSachHSChuaGQQuaHanByStatus(ByVal LinhVuc As String, ByVal LoaiHoSo As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal MaTinhTrang As String) As DataSet
            Return DataProvider.Instance().ExecuteQueryStoreProc("sp_ThongKeHoSoChuaGQQuaHanByStatus", LinhVuc, LoaiHoSo, TuNgay, DenNgay, MaTinhTrang)
        End Function
    End Class
End Namespace