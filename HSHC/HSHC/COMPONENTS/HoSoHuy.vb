Option Strict Off
Imports PortalQH
Namespace HSHC
    Public Class HoSoHuyController
        Public Function GetChiTietHuyHoSo(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getChiTietHuyHoSo", pID)
        End Function
        Public Function UpdHoSoHuy(ByVal obj As Object) As String
            'return "" khong thanh cong <> huy ho so thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHoSoHuy", obj)
        End Function
        Public Function delHoSoHuy(ByVal pHoSoHuyID As String) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_delHoSoHuy", pHoSoHuyID)
        End Function
        Public Function IsHoSoDaHuy(ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_IsHoSoDaHuy", pHoSoTiepNhanID)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' In van ban khong giai quyet ho so
        ''' </summary>
        ''' <param name="strHoSoTiepNhanID"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function InHoSoHuy(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InThongBaoHuyHoSoTN", strHoSoTiepNhanID)
        End Function
    End Class
    Public Class HoSoHuyPhuongXaController
        Public Function GetChiTietHuyHoSo(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getChiTietHuyHoSo", pID)
        End Function
        Public Function UpdHoSoHuy(ByVal obj As Object) As String
            'return "" khong thanh cong <> huy ho so thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHoSoHuy", obj)
        End Function
        Public Function delHoSoHuy(ByVal pHoSoHuyID As String) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc("sp_delHoSoHuy", pHoSoHuyID)
        End Function
        Public Function IsHoSoDaHuy(ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_IsHoSoDaHuy", pHoSoTiepNhanID)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' In van ban khong giai quyet ho so
        ''' </summary>
        ''' <param name="strHoSoTiepNhanID"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function InHoSoHuy(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InThongBaoHuyHoSoTN", strHoSoTiepNhanID)
        End Function
    End Class
End Namespace