Namespace PortalQH
    Public Class LanhDaoController

        Public Function GetMenuTinTuc(ByVal db As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_TinTuc_MNU")
        End Function
        Public Function GetMenuTongHop(ByVal db As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_TongHop_MNU")
        End Function
        Public Function GetMenuLichTrongNgay(ByVal db As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_LichTrongNgay_MNU")
        End Function
        Public Function GetMenuCongViec(ByVal db As String, ByVal UserName As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_CongViec_MNU", UserName)
        End Function
        Public Function GetMenuHoiDap(ByVal db As String, ByVal UserName As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_HoiDap_MNU", UserName)
        End Function
        '-------------------------------------------------------------------
        Public Function GetHoiDap_Lst(ByVal db As String, ByVal pNguoiNhan As String, ByVal pNguoiGui As String, ByVal pTuNgay As String, ByVal pDenNgay As String, ByVal pNhanGui As String, ByVal strActive As String, ByVal pURL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_HoiDap_Lst", pNguoiNhan, pNguoiGui, pTuNgay, pDenNgay, pNhanGui, strActive, pURL)
        End Function
        Public Function GetTraLoi_Lst(ByVal db As String, ByVal pHoiDapID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_TraLoi_Lst", pHoiDapID)
        End Function
        Public Function GetTraLoi_Detail(ByVal db As String, ByVal pHoiDapID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_LD_TraLoi_Detail", pHoiDapID)
        End Function
        Public Function UpdHoiDap(ByVal db As String, ByVal pTieuDe As String, ByVal pNoiDung As String, ByVal pNguoiGui As String, ByVal pNgayGui As String, ByVal pNguoiNhan As String) As String
            'return "" khong thanh cong <> hosotiepnhanid thanh cong
            Return DataProvider.Instance.ExecuteScalar(db & "..sp_LD_updHoiDap", pTieuDe, pNoiDung, pNguoiGui, pNgayGui, pNguoiNhan)
        End Function

        Public Function UpdHoiDap_TL(ByVal db As String, ByVal pNoiDung As String, ByVal pNguoiGui As String, ByVal pHoiDapID As String) As String
            'return "" khong thanh cong <> hosotiepnhanid thanh cong
            Return DataProvider.Instance.ExecuteScalar(db & "..sp_LD_updHoiDap_TL", pNoiDung, pNguoiGui, pHoiDapID)
        End Function
        ' Cong viec -- HienND
        Public Function getCongViec_Lst(ByVal db As String, ByVal ParamArray arr() As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db + "..sp_CV_getCongViec_Lst", arr)
        End Function
        Public Sub delCongViec(ByVal db As String, ByVal pID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_DelCongViec", pID)
        End Sub
        Public Sub apprCongViec(ByVal db As String, ByVal ParamArray arr() As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_apprCongViec", arr)
        End Sub
        Public Sub UpdCongViec(ByVal db As String, ByVal ParamArray arr() As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_UpdCongViec", arr)
        End Sub
        Public Function getCongViecByID(ByVal db As String, ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db & "..sp_CV_getCongViecByID", pID)
        End Function
        Public Sub InsCongViec(ByVal db As String, ByVal ParamArray arr() As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_InsCongViec", arr)
        End Sub

        Public Function getDSNguoiGiaoViec(ByVal databaseDemanders As String, ByVal databaseUsers As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(databaseDemanders & "..sp_CV_getDSNguoiGiaoViec", databaseUsers)
        End Function

        Public Sub insNguoiGiaoViec(ByVal db As String, ByVal userName As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_insNguoiGiaoViec", userName)
        End Sub

        Public Sub delToanBoNguoiGiaoViec(ByVal db As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_delMoiNguoiGiaoViec")
        End Sub

        Public Function getDSNguoiNhanViec(ByVal databaseDemanders As String, ByVal databaseUsers As String, ByVal demander As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(databaseDemanders & "..sp_CV_getDSNguoiNhanViec", databaseUsers, demander)
        End Function

        Public Sub insNguoiNhanViec(ByVal db As String, ByVal demanderName As String, ByVal receiverName As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_insNguoiNhanViec", demanderName, receiverName)
        End Sub

        Public Sub delToanBoNguoiNhanViec(ByVal db As String, ByVal userID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_CV_delMoiNguoiNhanViec", userID)
        End Sub

        Public Sub DelHoiDap(ByVal db As String, ByVal pID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..sp_LD_DelHoiDap", pID)
        End Sub

    End Class
End Namespace

