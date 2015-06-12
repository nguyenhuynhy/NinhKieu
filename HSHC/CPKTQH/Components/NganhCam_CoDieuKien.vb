Imports PortalQH
Namespace CPKTQH
    <Serializable()> Public Class NganhCam_CoDieuKienInfo
        Private _NganhKinhDoanh As String
        Private _NganhCapTren As String
        Private _Loai As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _ToanQuan As Boolean
        Private _Duong As String
        Private _Phuong As String
        Private _MaDuongPhuong As String
        Private _URL As String
        'thông tin sử dụng cho ngành kinh doanh có điều kiện
        Private _NoiDung As String
        Private _CoVonToiThieu As Boolean
        Private _SoVonToiThieu As String
        Private _CoChungChi As Boolean
        Private _UserUpdate As String

        Public Property NganhKinhDoanh() As String
            Get
                Return _NganhKinhDoanh
            End Get
            Set(ByVal Value As String)
                _NganhKinhDoanh = Value
            End Set
        End Property

        Public Property NganhCapTren() As String
            Get
                Return _NganhCapTren
            End Get
            Set(ByVal Value As String)
                _NganhCapTren = Value
            End Set
        End Property

        Public Property Loai() As String
            Get
                Return _Loai
            End Get
            Set(ByVal Value As String)
                _Loai = Value
            End Set
        End Property

        Public Property TuNgay() As String
            Get
                Return _TuNgay
            End Get
            Set(ByVal Value As String)
                _TuNgay = Value
            End Set
        End Property

        Public Property DenNgay() As String
            Get
                Return _DenNgay
            End Get
            Set(ByVal Value As String)
                _DenNgay = Value
            End Set
        End Property

        Public Property ToanQuan() As Boolean
            Get
                Return _ToanQuan
            End Get
            Set(ByVal Value As Boolean)
                _ToanQuan = Value
            End Set
        End Property

        Public Property Duong() As String
            Get
                Return _Duong
            End Get
            Set(ByVal Value As String)
                _Duong = Value
            End Set
        End Property

        Public Property Phuong() As String
            Get
                Return _Phuong
            End Get
            Set(ByVal Value As String)
                _Phuong = Value
            End Set
        End Property

        Public Property MaDuongPhuong() As String
            Get
                Return _MaDuongPhuong
            End Get
            Set(ByVal Value As String)
                _MaDuongPhuong = Value
            End Set
        End Property

        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
        Public Property NoiDung() As String
            Get
                Return _NoiDung
            End Get
            Set(ByVal Value As String)
                _NoiDung = Value
            End Set
        End Property
        Public Property CoVonToiThieu() As Boolean
            Get
                Return _CoVonToiThieu
            End Get
            Set(ByVal Value As Boolean)
                _CoVonToiThieu = Value
            End Set
        End Property
        Public Property SoVonToiThieu() As String
            Get
                Return _SoVonToiThieu
            End Get
            Set(ByVal Value As String)
                _SoVonToiThieu = Value
            End Set
        End Property
        Public Property CoChungChi() As Boolean
            Get
                Return _CoChungChi
            End Get
            Set(ByVal Value As Boolean)
                _CoChungChi = Value
            End Set
        End Property
        Public Property UserUpdate() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
            End Set
        End Property
    End Class

    Public Class NganhCam_CoDieuKienController
        Public Function getDanhSachNganhCam(ByVal objNganhCamInfo As NganhCam_CoDieuKienInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachNganhCam", _
                                                                        objNganhCamInfo.NganhCapTren, _
                                                                        objNganhCamInfo.NganhKinhDoanh, _
                                                                        objNganhCamInfo.TuNgay, _
                                                                        objNganhCamInfo.DenNgay, _
                                                                        -CInt(objNganhCamInfo.ToanQuan), _
                                                                        objNganhCamInfo.Phuong, _
                                                                        objNganhCamInfo.Duong, _
                                                                        objNganhCamInfo.URL)
        End Function

        Public Function getDanhSachNganhKDCoDieuKien(ByVal objNganhCamInfo As NganhCam_CoDieuKienInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachNganhKDCoDieuKien", _
                                                                        objNganhCamInfo.NganhCapTren, _
                                                                        objNganhCamInfo.NganhKinhDoanh, _
                                                                        objNganhCamInfo.URL)
        End Function

        Public Function getThongTinNganhCam(ByVal pMaNganh As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetThongTinNganhCam", pMaNganh)
        End Function

        Public Function getThongTinDuongPhuongCam(ByVal pMaNganh As String, ByVal pPhamVi As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetThongTinDuongPhuongCam", pMaNganh, pPhamVi)
        End Function

        Public Function getThongTinChiTietDuongPhuongCam(ByVal pMaNganh As String, ByVal pPhamVi As String, ByVal pMa As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetThongTinChiTietDuongPhuongCam", pMaNganh, pPhamVi, pMa)
        End Function

        Public Sub updNganhCam(ByVal obj As NganhCam_CoDieuKienInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_updNganhCam", _
                                                    obj.NganhKinhDoanh, _
                                                    obj.Loai, _
                                                    obj.MaDuongPhuong, _
                                                    obj.TuNgay, _
                                                    obj.DenNgay)
        End Sub

        Public Sub updDuongPhuongCam(ByVal obj As NganhCam_CoDieuKienInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_updDuongPhuongCam", _
                                                    obj.Loai, _
                                                    obj.TuNgay, _
                                                    obj.DenNgay, _
                                                    obj.NganhKinhDoanh, _
                                                    obj.Duong, _
                                                    obj.Phuong)
        End Sub

        Public Sub delNganhCam(ByVal pNganh As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_delNganhCam", pNganh)
        End Sub

        Public Sub delDuongPhuongCam(ByVal obj As NganhCam_CoDieuKienInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_delDuongPhuongCam", _
                                                    obj.NganhKinhDoanh, _
                                                    obj.Loai, _
                                                    obj.MaDuongPhuong)
        End Sub
        
        'NGÀNH KINH DOANH CÓ ĐIỀU KIỆN
        Public Function getNganhDieuKien(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_NganhDieuKien_Get", pID)
        End Function

        Public Function insNganhDieuKien(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_NganhDieuKien_Ins", obj)
        End Function

        Public Function updNganhDieuKien(ByVal obj As Object) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalarAuto("sp_NganhDieuKien_Upd", obj)
            Return Not CBool(str)
        End Function

        Public Sub delNganhDieuKien(ByVal pID As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_NganhDieuKien_Del", pID)
        End Sub

        Public Function getNganhDieuKienChungChi(ByVal pNganhDieuKienID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_NganhDieuKienChungChi_Get", pNganhDieuKienID)
        End Function

        Public Function insNganhDieuKienChungChi(ByVal pNganhDieuKienID As String, ByVal pMaChungChi As String) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_NganhDieuKienChungChi_Ins", pNganhDieuKienID, pMaChungChi)
            Return Not CBool(str)
        End Function

        Public Sub delNganhDieuKienChungChi(ByVal pID As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_NganhDieuKienChungChi_Del", pID)
        End Sub

    End Class
End Namespace