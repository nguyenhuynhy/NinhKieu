Imports PortalQH
Namespace HSHC
    Public Class HoSoBoSungController
        Public Function GetHoSoBoSung(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSung", pID)
        End Function
        Public Function UpdHoSoBoSung(ByVal obj As Object) As String
            'return "" khong thanh cong <> hosobosungid thanh cong
            Return DataProvider.Instance.ExecuteScalarAuto("sp_updHoSoBoSung", obj)
        End Function
        'AnhLH
        Public Function AddHoSoBoSung(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsHoSoBoSung", obj)
            'DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_InsHoSoBoSung", obj)
        End Function
        'truongtd
        Public Sub DelHoSoBoDung(ByVal strSoBienNhan As String, ByVal strTabCode As String, ByVal strNguoiTacNghiep As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("dbo.sp_DelHOSOBOSUNG", strSoBienNhan, strTabCode, strNguoiTacNghiep)
        End Sub
        Public Function GetHoSoBoSungBySoBienNhan(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetHoSoBoSungBySoBienNhan", obj)
        End Function
        Public Function GetHoSoBoSungBySoBienNhan(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSungBySoBienNhan", pSoBienNhan)
        End Function
        Public Function GetQuaHanBoSung(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetQuaHanBoSung", pSoBienNhan)
        End Function
        Public Function InThongBaoYeuCauBoSungHoSo(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuYeuCauBoSungHoSo", strHoSoTiepNhanID)
        End Function
        Public Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            Dim dv As New DataView
            Dim ds As DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoBoSungBySoBienNhan", strSoBienNhan)
            dv = ds.Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function
        'End AnhLH
    End Class
End Namespace
