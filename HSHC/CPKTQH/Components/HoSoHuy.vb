Imports PortalQH
Namespace CPKTQH
    Public Class HoSoHuyInfo
        Private _HoSoHuyID As String
        Private _NgayHuy As String
        Private _NguoiHuy As String
        Private _GhiChu As String
        Private _NgayCapNhatCuoi As String
        Private _HoSoTiepNhanID As String
        Private _MaLyDo As String
        Private _LastUpdate As String


        Public Property HoSoHuyID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoHuyID
            Get
                Return _HoSoHuyID
            End Get
            Set(ByVal Value As String)
                _HoSoHuyID = Value
            End Set
        End Property

        Public Property NgayHuy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayHuy
            Get
                Return _NgayHuy
            End Get
            Set(ByVal Value As String)
                _NgayHuy = Value
            End Set
        End Property

        Public Property NguoiHuy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NguoiHuy
            Get
                Return _NguoiHuy
            End Get
            Set(ByVal Value As String)
                _NguoiHuy = Value
            End Set
        End Property

        Public Property GhiChu() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.GhiChu
            Get
                Return _GhiChu
            End Get
            Set(ByVal Value As String)
                _GhiChu = Value
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

        Public Property MaLyDo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaLyDo
            Get
                Return _MaLyDo
            End Get
            Set(ByVal Value As String)
                _MaLyDo = Value
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
            _HoSoHuyID = ""
            _NgayHuy = ""
            _NguoiHuy = ""
            _GhiChu = ""
            _NgayCapNhatCuoi = ""
            _HoSoTiepNhanID = ""
            _MaLyDo = ""
            _LastUpdate = ""
        End Sub

    End Class

    Public Class HoSoHuyController

    End Class
End Namespace

