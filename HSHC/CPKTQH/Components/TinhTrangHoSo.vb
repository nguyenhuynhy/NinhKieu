Imports PortalQH
Namespace CPKTQH
    Public Class TinhTrangHoSoInfo
        Private _TinhTrangHoSoID As String
        Private _NgayTacNghiep As String
        Private _MaNguoiTacNghiep As String
        Private _MaNguoiDen As String
        Private _HoSoTiepNhanID As String
        Private _MaTinhTrangThuLy As String
        Private _NgayNhan As String
        Private _MaNguoiNhan As String
        Private _NgayChuyen As String
        Private _MaTinhTrang As String
        Private _NoiDungThuLy As String
        Private _LastUpdate As String


        Public Property TinhTrangHoSoID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.TinhTrangHoSoID
            Get
                Return _TinhTrangHoSoID
            End Get
            Set(ByVal Value As String)
                _TinhTrangHoSoID = Value
            End Set
        End Property

        Public Property NgayTacNghiep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayTacNghiep
            Get
                Return _NgayTacNghiep
            End Get
            Set(ByVal Value As String)
                _NgayTacNghiep = Value
            End Set
        End Property

        Public Property MaNguoiTacNghiep() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNguoiTacNghiep
            Get
                Return _MaNguoiTacNghiep
            End Get
            Set(ByVal Value As String)
                _MaNguoiTacNghiep = Value
            End Set
        End Property

        Public Property MaNguoiDen() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNguoiDen
            Get
                Return _MaNguoiDen
            End Get
            Set(ByVal Value As String)
                _MaNguoiDen = Value
            End Set
        End Property

        Public Property HoSoTiepNhanID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoTiepNhanID
            Get
                Return _HoSoTiepNhanID
            End Get
            Set(ByVal Value As String)
                _HoSoTiepNhanID = Value
            End Set
        End Property

        Public Property MaTinhTrangThuLy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaTinhTrangThuLy
            Get
                Return _MaTinhTrangThuLy
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangThuLy = Value
            End Set
        End Property

        Public Property NgayNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayNhan
            Get
                Return _NgayNhan
            End Get
            Set(ByVal Value As String)
                _NgayNhan = Value
            End Set
        End Property

        Public Property MaNguoiNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNguoiNhan
            Get
                Return _MaNguoiNhan
            End Get
            Set(ByVal Value As String)
                _MaNguoiNhan = Value
            End Set
        End Property

        Public Property NgayChuyen() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayChuyen
            Get
                Return _NgayChuyen
            End Get
            Set(ByVal Value As String)
                _NgayChuyen = Value
            End Set
        End Property

        Public Property MaTinhTrang() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaTinhTrang
            Get
                Return _MaTinhTrang
            End Get
            Set(ByVal Value As String)
                _MaTinhTrang = Value
            End Set
        End Property

        Public Property NoiDungThuLy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungThuLy
            Get
                Return _NoiDungThuLy
            End Get
            Set(ByVal Value As String)
                _NoiDungThuLy = Value
            End Set
        End Property

        Public Property LastUpdate() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.LastUpdate
            Get
                Return _LastUpdate
            End Get
            Set(ByVal Value As String)
                _LastUpdate = Value
            End Set
        End Property
        Public Sub ResetAll()
            _TinhTrangHoSoID = ""
            _NgayTacNghiep = ""
            _MaNguoiTacNghiep = ""
            _MaNguoiDen = ""
            _HoSoTiepNhanID = ""
            _MaTinhTrangThuLy = ""
            _NgayNhan = ""
            _MaNguoiNhan = ""
            _NgayChuyen = ""
            _MaTinhTrang = ""
            _NoiDungThuLy = ""
            _LastUpdate = ""
        End Sub

    End Class
    Public Class TinhTrangHoSoController

    End Class
End Namespace

