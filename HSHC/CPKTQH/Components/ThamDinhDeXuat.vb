Imports PortalQH
Namespace CPKTQH
    Public Class ThamDinhDeXuatController
        'AnhLH
        Public Function AddThamDinhDeXuat(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_DeXuat_Ins", obj)
        End Function
        Public Function GetThamDinhDeXuatBySoBienNhan(ByVal strSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetThamDinhDeXuatBySoBienNhan", strSoBienNhan)
        End Function
        Public Function CheckKiemTraDeXuat(ByVal strHoSoTiepNhan As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_DeXuat_Check", strHoSoTiepNhan)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Function CheckKiemTraBoSung(ByVal strHoSoTiepNhan As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_HoSoBoSung_Check", strHoSoTiepNhan)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Function CheckKiemTraKhongGiaiQuyet(ByVal strHoSoTiepNhan As String) As Boolean
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_HoSoKhongGiaiQuyet_Check", strHoSoTiepNhan)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Function DelThamDinhDeXuat(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_DeXuat_Del", obj)
            Return Not CBool(str)
        End Function
        'End AnhLH
        'Truongtd'
        Public Function InBaoCaoDeXuat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InBaoCaoKiemTraDeXuat", strHoSoTiepNhanID)
        End Function
        Public Function InPhieuChuyenKhaoSat(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InPhieuChuyenKhaoSat", strHoSoTiepNhanID)
        End Function

        'end truongtd'
    End Class
End Namespace

