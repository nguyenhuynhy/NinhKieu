Imports PortalQH
Namespace CPKTQH
    Public Class ThayDoiHTXController
        Public Function GetThongTinThayDoi(ByVal pGiayCNDKKDHTXID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiHTX_Get", pGiayCNDKKDHTXID, pLanThayDoi)
        End Function
        Public Function GetThongTinDKKDCu(ByVal pGiayCNDKKDHTXID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongTinHTXCu_Get", pGiayCNDKKDHTXID, pLanThayDoi)
        End Function
        Public Function GetThongTinDKKDMoi(ByVal pGiayCNDKKDHTXID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongTinHTXMoi_Get", pGiayCNDKKDHTXID, pLanThayDoi)
        End Function
        Public Function GetThayDoiThanhVienHTX(ByVal pGiayCNDKKDHTXID As String, ByVal pLanThayDoi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiThanhVienHTX_Get", pGiayCNDKKDHTXID, pLanThayDoi)
        End Function
        Public Sub UpdateThayDoiHTX(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiHTX_Upd", arrParams)
        End Sub
        Public Sub UpdateThayDoiChiTietHTX(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_ThayDoiChiTietHTX_Upd", arrParams)
        End Sub
        Public Sub UpdateGCNDKKDHTX(ByVal ParamArray arrParams() As Object)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_NoiDungDKKDHTX_Upd", arrParams)
        End Sub
        Public Sub UpdateThayDoiDanhSachXaVien(ByVal strGiayCNDKKDHTXID As String, ByVal strLanThayDoi As String, ByVal dtThongTinXaVien As DataTable)
            'delete thong tin xa vien
            DataProvider.Instance.ExecuteScalar("sp_ThayDoiThanhVienHTX_Del", strGiayCNDKKDHTXID, strLanThayDoi)
            'insert thong tin xa vien
            Dim i As Integer
            For i = 0 To dtThongTinXaVien.Rows.Count - 1
                DataProvider.Instance.ExecuteScalar("sp_ThayDoiThanhVienHTX_Ins", _
                    strGiayCNDKKDHTXID, _
                    strLanThayDoi, _
                    getItemValueFromTable(dtThongTinXaVien, i, "HoTen"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "GioiTinh"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "NgaySinh"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "DanToc"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "SoCMND"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "NgayCapCMND"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "NoiCapCMND"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "DiaChiThuongTru"), _
                    getItemValueFromTable(dtThongTinXaVien, i, "ChoOHienNay") _
                )
            Next
        End Sub
        Public Function ThayDoiLanDau(ByVal strGiayCNDKKDHTXID As String) As Boolean
            Dim strResult As String
            strResult = DataProvider.Instance.ExecuteScalar("sp_ThayDoiHTXLanDau_Check", strGiayCNDKKDHTXID)
            If strResult = "0" Then
                Return False
            End If
            Return True
        End Function
        Public Function DelThayDoiHTX(ByVal pGiayCNDKKDHTXID As String, ByVal pLanThayDoi As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_ThayDoiHTX_Del", pGiayCNDKKDHTXID, pLanThayDoi)
        End Function
        Public Function CheckHTXDaThayDoi(ByVal pGiayCNDKKDHTXID As String, ByVal pLanThayDoi As String) As Boolean
            Dim strResult As String
            strResult = DataProvider.Instance.ExecuteScalar("sp_ThayDoiHTX_Check", pGiayCNDKKDHTXID, pLanThayDoi)
            If strResult = "0" Then
                Return False
            End If
            Return True
        End Function
        Private Function getItemValueFromTable(ByVal dt As DataTable, ByVal rowNo As Integer, ByVal field As String) As String
            If (Not IsDBNull(dt.Rows(rowNo).Item(field))) Then
                Return Replace(CStr(dt.Rows(rowNo).Item(field)), "''", "'")
            Else
                Return ""
            End If
        End Function
    End Class
End Namespace

