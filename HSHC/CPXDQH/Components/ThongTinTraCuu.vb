Imports PortalQH
Imports System.Configuration
Namespace CPXD
    <Serializable()> Public Class ThongTinTraCuuInfo
        'Inherits PortalQH.PortalModuleControl
        Private _TabCode As String
        Private _ItemCode As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _HoTen As String
        Private _SoNha As String
        Private _Duong As String
        Private _Phuong As String
        Private _LoaiHoSo As String
        Private _SoBienNhan As String
        Private _TinhTrang As String
        Private _NguoiChuyen As String
        Private _NguoiNhan As String
        Private _NguoiTacNghiep As String
        Private _URL As String

        Public Property TabCode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property

        Public Property ItemCode() As String
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
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

        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
            End Set
        End Property

        Public Property SoNha() As String
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value
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

        Public Property SoBienNhan() As String
            Get
                Return _SoBienNhan
            End Get
            Set(ByVal Value As String)
                _SoBienNhan = Value
            End Set
        End Property

        Public Property LoaiHoSo() As String
            Get
                Return _LoaiHoSo
            End Get
            Set(ByVal Value As String)
                _LoaiHoSo = Value
            End Set
        End Property

        Public Property TinhTrang() As String
            Get
                Return _TinhTrang
            End Get
            Set(ByVal Value As String)
                _TinhTrang = Value
            End Set
        End Property

        Public Property NguoiChuyen() As String
            Get
                Return _NguoiChuyen
            End Get
            Set(ByVal Value As String)
                _NguoiChuyen = Value
            End Set
        End Property

        Public Property NguoiNhan() As String
            Get
                Return _NguoiNhan
            End Get
            Set(ByVal Value As String)
                _NguoiNhan = Value
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

        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property

        Public Sub New(ByVal Request As HttpRequest)
            Dim glbFile As String
            Dim mSoNgay As Integer
            Dim objHttpContext As HttpContext = HttpContext.Current
            glbFile = ConfigurationSettings.AppSettings("Path" & CType(objHttpContext.Session.Item("ActiveDB"), String)) & "GLOBAL.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            _TabCode = Request.Params("TabID")
            _ItemCode = "" 'CType(Session.Item("ItemCode"), String)
            _TuNgay = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            _DenNgay = Format(Now, "dd/MM/yyyy")
            _HoTen = ""
            _SoNha = ""
            _Duong = ""
            _Phuong = ""
            _SoBienNhan = ""
            _LoaiHoSo = ""
            _TinhTrang = ""
            _NguoiChuyen = ""
            _NguoiNhan = ""
            _NguoiTacNghiep = "" 'Session.Item("UserName").ToString()
            _URL = "" ' EditURL("ID", "VALUE")
        End Sub
    End Class

    Public Class ThongTinTraCuuController
        Public Function GetInfoFromSearch(ByVal objTTTCInfo As ThongTinTraCuuInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSo", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function

        Public Function GetInfoFromSearch1(ByVal objTTTCInfo As ThongTinTraCuuInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenNhan", _
                                                            objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
                                                            objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function
        Public Function GetTinhTrangDefault(ByVal pMaLinhVuc As String, ByVal pTabCode As String, ByVal pCapDo As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GetTinhTrangDefault", pMaLinhVuc, pTabCode, pCapDo)
        End Function
    End Class

    <Serializable()> Public Class ThongTinTraCuuKDInfo
        'Inherits PortalQH.PortalModuleControl
        Private _TabCode As String
        Private _ItemCode As String
        Private _TuNgay As String
        Private _DenNgay As String
        Private _HoTen As String
        Private _SoNha As String
        Private _Duong As String
        Private _Phuong As String
        Private _LoaiHoSo As String
        Private _SoBienNhan As String
        Private _TinhTrang As String
        Private _NguoiChuyen As String
        Private _NguoiNhan As String
        Private _NguoiTacNghiep As String
        Private _URL As String
        Private _NgayCongVan As String
        Private _LoaiCongVan As String


        Public Property TabCode() As String
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property

        Public Property ItemCode() As String
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
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

        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
            End Set
        End Property

        Public Property SoNha() As String
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value
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

        Public Property SoBienNhan() As String
            Get
                Return _SoBienNhan
            End Get
            Set(ByVal Value As String)
                _SoBienNhan = Value
            End Set
        End Property

        Public Property LoaiHoSo() As String
            Get
                Return _LoaiHoSo
            End Get
            Set(ByVal Value As String)
                _LoaiHoSo = Value
            End Set
        End Property

        Public Property TinhTrang() As String
            Get
                Return _TinhTrang
            End Get
            Set(ByVal Value As String)
                _TinhTrang = Value
            End Set
        End Property

        Public Property NguoiChuyen() As String
            Get
                Return _NguoiChuyen
            End Get
            Set(ByVal Value As String)
                _NguoiChuyen = Value
            End Set
        End Property

        Public Property NguoiNhan() As String
            Get
                Return _NguoiNhan
            End Get
            Set(ByVal Value As String)
                _NguoiNhan = Value
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
        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
        Public Property NgayCongVan() As String
            Get
                Return _NgayCongVan
            End Get
            Set(ByVal Value As String)
                _NgayCongVan = Value
            End Set
        End Property
        Public Property LoaiCongVan() As String
            Get
                Return _LoaiCongVan
            End Get
            Set(ByVal Value As String)
                _LoaiCongVan = Value
            End Set
        End Property

        Public Sub New(ByVal Request As HttpRequest)
            Dim glbFile As String
            Dim mSoNgay As Integer
            Dim objHttpContext As HttpContext = HttpContext.Current
            glbFile = ConfigurationSettings.AppSettings("Path" & CType(objHttpContext.Session.Item("ActiveDB"), String)) & "GLOBAL.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            _TabCode = Request.Params("TabID")
            _ItemCode = "" 'CType(Session.Item("ItemCode"), String)
            _TuNgay = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            _DenNgay = Format(Now, "dd/MM/yyyy")
            _HoTen = ""
            _SoNha = ""
            _Duong = ""
            _Phuong = ""
            _SoBienNhan = ""
            _LoaiHoSo = ""
            _TinhTrang = ""
            _NguoiChuyen = ""
            _NguoiNhan = ""
            _NguoiTacNghiep = ""
            _URL = "" 'EditURL("ID", "VALUE")
            _NgayCongVan = ""
            _LoaiCongVan = ""
        End Sub
    End Class

    Public Class ThongTinTraCuuKDController
        Public Function GetInfoFromSearchCD0(ByVal objTTTCInfo As ThongTinTraCuuKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoCD0", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiTacNghiep, _
                                                             objTTTCInfo.URL)
        End Function
        Public Function GetInfoFromSearchCD1(ByVal objTTTCInfo As ThongTinTraCuuKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoCD1", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiTacNghiep, _
                                                             objTTTCInfo.URL)
        End Function
        Public Function GetDanhSachHoSoCapPhep(ByVal objTTTCInfo As ThongTinTraCuuKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoCapPhep", _
                                                                        objTTTCInfo.TabCode, _
                                                                        objTTTCInfo.ItemCode, _
                                                                        objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                                        objTTTCInfo.HoTen, _
                                                                        objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                                        objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                                        objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                                        objTTTCInfo.NguoiTacNghiep, _
                                                                         objTTTCInfo.URL)
        End Function
        Public Function GetDanhSachCongVan(ByVal objTTTCInfo As ThongTinTraCuuKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachCongVan", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.URL, _
                                                            objTTTCInfo.NgayCongVan, _
                                                            objTTTCInfo.LoaiCongVan)
        End Function
        Public Function GetInfoFromSearch(ByVal objTTTCInfo As ThongTinTraCuuKDInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSo", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL)
        End Function

        'Public Function GetInfoFromSearch1(ByVal objTTTCInfo As ThongTinTraCuuKDInfo) As DataSet
        '    Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenNhan", _
        '                                                    objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
        '                                                    objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
        '                                                    objTTTCInfo.HoTen, _
        '                                                    objTTTCInfo.SoNha, objTTTCInfo.Duong, _
        '                                                    objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
        '                                                    objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
        '                                                    objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
        '                                                    objTTTCInfo.URL)
        'End Function
        Public Function GetTinhTrangDefault(ByVal pMaLinhVuc As String, ByVal pTabCode As String, ByVal pCapDo As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GetTinhTrangDefault", pMaLinhVuc, pTabCode, pCapDo)
        End Function
    End Class


End Namespace
