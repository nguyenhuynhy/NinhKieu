Imports PortalQH
Imports System.Configuration
Imports System.Web
Namespace HSHC
    <Serializable()> Public Class TraCuuPhuongXa

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
        End Sub
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
    <Serializable()> Public Class ThongTinTraCuuPhuongXaInfo

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
        Private _NgayTacNghiep As String

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

        Public Property NgayTacNghiep() As String
            Get
                Return _NgayTacNghiep
            End Get
            Set(ByVal Value As String)
                _NgayTacNghiep = Value
            End Set
        End Property

        Public Sub New(ByVal Request As HttpRequest)
            Dim glbFile As String
            Dim mSoNgay As Integer
            Dim objHttpContext As HttpContext = HttpContext.Current
            glbFile = ConfigurationSettings.AppSettings("Path" & CType(objHttpContext.Session.Item("ActiveDB"), String)) & "GLOBAL.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            _TabCode = Request.Params("TabID")
            _ItemCode = ""
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
            _URL = "" 'EditURL("ID", "VALUE")
        End Sub
    End Class

    Public Class ThongTinTraCuuPhuongXaController
        Public Function GetInfoFromSearchTGLD(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoTGLD", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function
        Public Function GetInfoFromSearchDauKy(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoDauKy", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen, _
                                                            objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function

        Public Function GetInfoFromSearch(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSo", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function
        Public Function GetInfoFromSearchPhuongXa(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoPhuongXa", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function
        Public Function GetInfoFromSearchThuLePhi(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoThuLePhi", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Lay danh sach ho so thu ly
        ''' </summary>
        ''' <param name="objTTTCInfo"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	3/31/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function GetDSHoSoThuLy(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoThuLy", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function


        'Create By      : TuanNH
        'Create Date    : 14/03/2006
        'Reason         : Cap so Giay Phep bang tay
        Public Function GetInfoFromSearchCapSoBangTay(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoCapSoBangTay", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function


        Public Function GetInfoFromSearch1(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenNhan", _
                                                            objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
                                                            objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep, objTTTCInfo.NgayTacNghiep)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="objTTTCInfo"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/2/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function GetDSHoSoChuyenThuLy(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenThuLy", _
                                                            objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
                                                            objTTTCInfo.NguoiTacNghiep, objTTTCInfo.NgayTacNghiep)
        End Function
        Public Function GetDSHoSoChuyenThuLyPhuongXa(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenThuLyPhuongXa", _
                                                            objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
                                                            objTTTCInfo.NguoiTacNghiep, objTTTCInfo.NgayTacNghiep)
        End Function
        Public Function GetDSHoSoChuyenThuLyMotCua(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenThuLyMotCua", _
                                                            objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
                                                            objTTTCInfo.NguoiTacNghiep, objTTTCInfo.NgayTacNghiep)
        End Function
        Public Function GetDSHoSoChuyenThuLyMotCuaPhuongXa(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyenThuLyMotCuaPhuongXa", _
                                                            objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                            objTTTCInfo.NguoiChuyen, objTTTCInfo.NguoiNhan, _
                                                            objTTTCInfo.NguoiTacNghiep, objTTTCInfo.NgayTacNghiep)
        End Function

        Public Function GetTinhTrangDefault(ByVal pMaLinhVuc As String, ByVal pTabCode As String, ByVal pCapDo As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GetTinhTrangDefault", pMaLinhVuc, pTabCode, pCapDo)
        End Function
        Public Function GetDanhSachHoSoCD1(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoChuyen", _
                                                                        objTTTCInfo.TabCode, objTTTCInfo.ItemCode, _
                                                                        objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                                        objTTTCInfo.HoTen, _
                                                                        objTTTCInfo.SoNha, objTTTCInfo.Duong, _
                                                                        objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan, _
                                                                        objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                                        objTTTCInfo.URL)
        End Function
        Public Function GetDSHoSoThuLyMotCua(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoThuLyMotCua", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function
        Public Function GetDSHoSoThuLyMotCuaPhuongXa(ByVal objTTTCInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDanhSachHoSoThuLyMotCuaPhuongXa", _
                                                            objTTTCInfo.TabCode, _
                                                            objTTTCInfo.ItemCode, _
                                                            objTTTCInfo.TuNgay, objTTTCInfo.DenNgay, _
                                                            objTTTCInfo.HoTen.Replace("'", "''"), _
                                                            objTTTCInfo.SoNha.Replace("'", "''"), objTTTCInfo.Duong, _
                                                            objTTTCInfo.Phuong, objTTTCInfo.SoBienNhan.Replace("'", "''"), _
                                                            objTTTCInfo.LoaiHoSo, objTTTCInfo.TinhTrang, _
                                                             objTTTCInfo.URL, objTTTCInfo.NguoiTacNghiep)
        End Function
    End Class
End Namespace
