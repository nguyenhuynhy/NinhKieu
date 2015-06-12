Namespace PortalQH
    Public Class SoLieuInfo
        Private _MaDMSoLieu As String
        Private _MaKyBaoCao As String
        Private _MaChiTieu As String
        Private _MaDiaBan As String
        Private _MaDonVi As String
        Private _Nam As Integer
        Private _SoLieu As String
        Private _SoLieuUocLuong As String
        Private _SoLieuThucHien As String
        Private _SoLieuKeHoach As String
        Private _DaDuyet As String
        Private _YKien As String

        Public Property Solieu() As String
            Get
                Return _SoLieu
            End Get
            Set(ByVal Value As String)
                _SoLieu = Value
            End Set
        End Property
        Public Property MaDMSoLieu() As String
            Get
                Return _MaDMSoLieu
            End Get
            Set(ByVal Value As String)
                _MaDMSoLieu = Value
            End Set
        End Property
        Public Property MaKyBaoCao() As String
            Get
                Return _MaKyBaoCao
            End Get
            Set(ByVal Value As String)
                _MaKyBaoCao = Value
            End Set
        End Property

        Public Property MaChiTieu() As String
            Get
                Return _MaChiTieu
            End Get
            Set(ByVal Value As String)
                _MaChiTieu = Value
            End Set
        End Property


        Public Property MaDiaBan() As String
            Get
                Return _MaDiaBan
            End Get
            Set(ByVal Value As String)
                _MaDiaBan = Value
            End Set
        End Property

        Public Property MaDonVi() As String
            Get
                Return _MaDonVi
            End Get
            Set(ByVal Value As String)
                _MaDonVi = Value
            End Set
        End Property
        Public Property Nam() As Integer
            Get
                Return _Nam
            End Get
            Set(ByVal Value As Integer)
                _Nam = Value
            End Set
        End Property
        Public Property SoLieuUocLuong() As String
            Get
                Return _SoLieuUocLuong
            End Get
            Set(ByVal Value As String)
                _SoLieuUocLuong = Value
            End Set
        End Property
        Public Property SoLieuThucHien() As String
            Get
                Return _SoLieuThucHien
            End Get
            Set(ByVal Value As String)
                _SoLieuThucHien = Value
            End Set
        End Property
        Public Property SoLieuKeHoach() As String
            Get
                Return _SoLieuKeHoach
            End Get
            Set(ByVal Value As String)
                _SoLieuKeHoach = Value
            End Set
        End Property
        Public Property DaDuyet() As String
            Get
                Return _DaDuyet
            End Get
            Set(ByVal Value As String)
                _DaDuyet = Value
            End Set
        End Property
        Public Property YKien() As String
            Get
                Return _YKien
            End Get
            Set(ByVal Value As String)
                _YKien = Value
            End Set
        End Property
    End Class
    Public Class SoLieuController
        Public Function GetSoLieuUocThucHien(ByVal dbPath As String, ByVal obj As SoLieuInfo, ByVal strLoai As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_GetChiTieuByDonVi", obj.MaDonVi, obj.MaKyBaoCao, obj.Nam, strLoai)
        End Function
        Public Function getAllKyBaoCao(ByVal dbPath As String, ByVal MaKBC As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_getLevelOfKyBaoCao", MaKBC)
        End Function
        Public Sub UpdateSoLieu(ByVal dbPath As String, ByVal obj As SoLieuInfo, ByVal strLoai As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(dbPath + "..sp_updateSoLieu", obj.MaDonVi, _
                                                                                            obj.MaChiTieu, _
                                                                                            obj.MaKyBaoCao, _
                                                                                            obj.Nam, _
                                                                                            obj.Solieu, _
                                                                                            obj.YKien, _
                                                                                            strLoai) 'obj.DaDuyet, _
            'strLoai)bu
        End Sub
        Public Sub DelSoLieu(ByVal dbPath As String, ByVal obj As SoLieuInfo, ByVal strLoai As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(dbPath + "..sp_delSLChiTieu", obj.MaDonVi, obj.MaKyBaoCao, obj.Nam, strLoai)
        End Sub
        Public Sub DuyetSoLieu(ByVal dbPath As String, ByVal ParamArray arr() As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc(dbPath + "..sp_DuyetSoLieu", arr)
        End Sub
        Public Function getDanhSachSoLieuDuyet(ByVal dbPath As String, ByVal ParamArray arr() As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_getDanhSachSoLieuDuyet", arr)
        End Function
        Public Function getSoLieuDuyet(ByVal dbPath As String, ByVal obj As SoLieuInfo, ByVal strLoaiDuyet As String, ByVal strLoaiSL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_getSoLieuDuyet", obj.MaDonVi, obj.MaKyBaoCao, obj.Nam, strLoaiDuyet, strLoaiSL)
        End Function
        ' Lay de phuc vu kiem tra tinh trang duyet
        Public Function getTinhTrangDuyet(ByVal dbPath As String, ByVal obj As SoLieuInfo, ByVal strLoaiSL As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_getTinhTrangDuyet", obj.MaDonVi, obj.MaKyBaoCao, obj.Nam, strLoaiSL)
        End Function
        Public Function getBaoCaoTongHopSoLieu(ByVal dbPath As String, ByVal ParamArray arr() As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_getBaoCaoTongHopSoLieu", arr)
        End Function
        Public Function getDonVi(ByVal dbPath As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(dbPath + "..sp_getallDonVi")
        End Function
    End Class
End Namespace