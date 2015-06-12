Imports PortalQH
Namespace CPKTQH
    Public Class TrinhThamDinhInfo
        Private _TrinhThamDinhID As String
        Private _NgayHetHan As String
        Private _MatHangKinhDoanh As String
        Private _NoiDung As String
        Private _NguoiNhan As String
        Private _NgayPhanHoi As String
        Private _NgayPhanHoiThucTe As String
        Private _NgayCapNhatCuoi As String
        Private _MaDonVi As String
        Private _DonViThamDinh As String
        Private _NgayThamDinh As String
        Private _Loai As String
        Private _HoSoTiepNhanID As String
        Private _LastUpdate As String


        Public Property TrinhThamDinhID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.TrinhThamDinhID
            Get
                Return _TrinhThamDinhID
            End Get
            Set(ByVal Value As String)
                _TrinhThamDinhID = Value
            End Set
        End Property

        Public Property NgayHetHan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayHetHan
            Get
                Return _NgayHetHan
            End Get
            Set(ByVal Value As String)
                _NgayHetHan = Value
            End Set
        End Property

        Public Property MatHangKinhDoanh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MatHangKinhDoanh
            Get
                Return _MatHangKinhDoanh
            End Get
            Set(ByVal Value As String)
                _MatHangKinhDoanh = Value
            End Set
        End Property

        Public Property NoiDung() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDung
            Get
                Return _NoiDung
            End Get
            Set(ByVal Value As String)
                _NoiDung = Value
            End Set
        End Property

        Public Property NguoiNhan() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NguoiNhan
            Get
                Return _NguoiNhan
            End Get
            Set(ByVal Value As String)
                _NguoiNhan = Value
            End Set
        End Property

        Public Property NgayPhanHoi() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayPhanHoi
            Get
                Return _NgayPhanHoi
            End Get
            Set(ByVal Value As String)
                _NgayPhanHoi = Value
            End Set
        End Property

        Public Property NgayPhanHoiThucTe() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayPhanHoiThucTe
            Get
                Return _NgayPhanHoiThucTe
            End Get
            Set(ByVal Value As String)
                _NgayPhanHoiThucTe = Value
            End Set
        End Property

        Public Property NgayCapNhatCuoi() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayCapNhatCuoi
            Get
                Return _NgayCapNhatCuoi
            End Get
            Set(ByVal Value As String)
                _NgayCapNhatCuoi = Value
            End Set
        End Property

        Public Property MaDonVi() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaDonVi
            Get
                Return _MaDonVi
            End Get
            Set(ByVal Value As String)
                _MaDonVi = Value
            End Set
        End Property

        Public Property DonViThamDinh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.DonViThamDinh
            Get
                Return _DonViThamDinh
            End Get
            Set(ByVal Value As String)
                _DonViThamDinh = Value
            End Set
        End Property

        Public Property NgayThamDinh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayThamDinh
            Get
                Return _NgayThamDinh
            End Get
            Set(ByVal Value As String)
                _NgayThamDinh = Value
            End Set
        End Property

        Public Property Loai() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.Loai
            Get
                Return _Loai
            End Get
            Set(ByVal Value As String)
                _Loai = Value
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
            _TrinhThamDinhID = ""
            _NgayHetHan = ""
            _MatHangKinhDoanh = ""
            _NoiDung = ""
            _NguoiNhan = ""
            _NgayPhanHoi = ""
            _NgayPhanHoiThucTe = ""
            _NgayCapNhatCuoi = ""
            _MaDonVi = ""
            _DonViThamDinh = ""
            _NgayThamDinh = ""
            _Loai = ""
            _HoSoTiepNhanID = ""
            _LastUpdate = ""
        End Sub



    End Class
    Public Class TrinhThamDinhController

    End Class
End Namespace

