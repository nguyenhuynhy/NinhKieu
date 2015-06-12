Imports PortalQH
Namespace CPKTQH
    Public Class NgungKinhDoanhInfo
        Private _MaLinhVuc As String
        Private _TabCode As String
        Private _NguoiTacNghiep As String
        Private _HoSoTiepNhanID As String
        Private _NgungKinhDoanhID As String
        Private _NgayNgungKD As String
        Private _LyDoNgung As String
        Private _GhiChu As String
        Private _GiayCNDKKDID As String
        Private _SoGiayPhep As String

        Public Property MaLinhVuc() As String
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property

        Public Property TabCode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property

        Public Property NguoiTacNghiep() As String
            Get
                Return _NguoiTacNghiep
            End Get
            Set(ByVal Value As String)
                _NguoiTacNghiep = Value
            End Set
        End Property

        Public Property HoSoTiepNhanID() As String
            Get
                Return _HoSoTiepNhanID
            End Get
            Set(ByVal Value As String)
                _HoSoTiepNhanID = Value
            End Set
        End Property

        Public Property NgungKinhDoanhID() As String
            Get
                Return _NgungKinhDoanhID
            End Get
            Set(ByVal Value As String)
                _NgungKinhDoanhID = Value
            End Set
        End Property

        Public Property NgayNgungKD() As String
            Get
                Return _NgayNgungKD
            End Get
            Set(ByVal Value As String)
                _NgayNgungKD = Value
            End Set
        End Property

        Public Property LyDoNgung() As String
            Get
                Return _LyDoNgung
            End Get
            Set(ByVal Value As String)
                _LyDoNgung = Value
            End Set
        End Property

        Public Property GhiChu() As String
            Get
                Return _GhiChu
            End Get
            Set(ByVal Value As String)
                _GhiChu = Value
            End Set
        End Property

        Public Property GiayCNDKKDID() As String
            Get
                Return _GiayCNDKKDID
            End Get
            Set(ByVal Value As String)
                _GiayCNDKKDID = Value
            End Set
        End Property

        Public Property SoGiayPhep() As String
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value
            End Set
        End Property
    End Class
    Public Class NgungKinhDoanhController
        '--HoangLN
        Public Function getSoGiayPhep(ByVal SoBienNhan As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_SoGiayPhepNgung_GetBySoBienNhan", SoBienNhan)
        End Function
        Public Function getThongTinNgungKinhDoanh(ByVal SoGiayPhep As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ThongTinNgungKinhDoanh_Get", SoGiayPhep)
        End Function
        Public Function updNgungKinhDoanh(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_NgungKinhDoanh_Upd", obj)
        End Function
        Public Sub delNgungKinhDoanh(ByVal pNgungKinhDoanhID As String, ByVal pGiayCNDKKDID As String, ByVal pHoSoTiepNhanID As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_NgungKinhDoanh_Del", pNgungKinhDoanhID, pGiayCNDKKDID, pHoSoTiepNhanID)
        End Sub


        '--ThuyTT su dung cho trang ngung kinh doanh dau ki
        Public Function getNgungKinhDoanh(ByVal pNgungKinhDoanhID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_NgungKinhDoanh_GetByID", pNgungKinhDoanhID)
        End Function

        Public Function getNgungKinhDoanhID(ByVal pGiayCNDKKDID As String, ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_NgungKinhDoanh_GetID", pGiayCNDKKDID, pHoSoTiepNhanID)
        End Function

        Public Function updNgungKinhDoanhDauKi(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_NgungKinhDoanh_UpdDauKi", obj)
            Try
                Return CBool(str)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function delNgungKinhDoanhByID(ByVal pNgungKinhDoanhID As String) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_NgungKinhDoanh_DelByID", pNgungKinhDoanhID)
            Try
                Return CBool(str)
            Catch ex As Exception
                Return False
            End Try
        End Function

        'Ngưng kinh doanh hợp tác xã
        Public Function getNgungKinhDoanhHTXID(ByVal pGiayCNDKKDHTXID As String, ByVal pHoSoTiepNhanID As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_NgungKinhDoanhHTX_GetID", pGiayCNDKKDHTXID, pHoSoTiepNhanID)
        End Function

        Public Function getNgungKinhDoanhHTX(ByVal pNgungKinhDoanhHTXID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_NgungKinhDoanhHTX_GetByID", pNgungKinhDoanhHTXID)
        End Function

        Public Function updNgungKinhDoanhHTX(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_NgungKinhDoanhHTX_Upd", obj)
            Try
                Return CBool(str)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function delNgungKinhDoanhHTXByID(ByVal pNgungKinhDoanhHTXID As String) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_NgungKinhDoanhHTX_DelByID", pNgungKinhDoanhHTXID)
            Try
                Return CBool(str)
            Catch ex As Exception
                Return False
            End Try
        End Function
        'ThuyTT end

        'Public Function updNgungKinhDoanh(ByVal obj As NgungKinhDoanhInfo) As String
        '    Return DataProvider.Instance.ExecuteScalar("sp_updNgungKinhDoanh", obj.MaLinhVuc, _
        '                                                            obj.TabCode, _
        '                                                            obj.NguoiTacNghiep, _
        '                                                            obj.HoSoTiepNhanID, _
        '                                                            obj.NgungKinhDoanhID, _
        '                                                            obj.NgayNgungKD, _
        '                                                            obj.LyDoNgung, _
        '                                                            obj.GhiChu, _
        '                                                            obj.GiayCNDKKDID, _
        '                                                            obj.SoGiayPhep)
        'End Function

        Public Sub delNgungKinhDoanh(ByVal obj As NgungKinhDoanhInfo)
            DataProvider.Instance.ExecuteScalar("sp_delNgungKinhDoanh", obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.NguoiTacNghiep, _
                                                                    obj.NgungKinhDoanhID)
        End Sub
        Public Function InGiayChungNhanNgungKinhDoanh(ByVal strNgungKinhDoanhID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InGiayChungNhanNgungDKKD", strNgungKinhDoanhID)
        End Function
    End Class
End Namespace

