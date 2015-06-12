Imports PortalQH
Namespace CPKTQH
    Public Class HoSoKemTheoInfo
        Private _HoSoKemTheoID As String
        Private _SoBanChinh As String
        Private _SoBanSao As String
        Private _SoBanPhoto As String
        Private _HoSoTiepNhanID As String
        Private _MaHoSoKemTheo As String
        Private _LastUpdate As String


        Public Property HoSoKemTheoID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoKemTheoID
            Get
                Return _HoSoKemTheoID
            End Get
            Set(ByVal Value As String)
                _HoSoKemTheoID = Value
            End Set
        End Property

        Public Property SoBanChinh() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoBanChinh
            Get
                Return _SoBanChinh
            End Get
            Set(ByVal Value As String)
                _SoBanChinh = Value
            End Set
        End Property

        Public Property SoBanSao() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoBanSao
            Get
                Return _SoBanSao
            End Get
            Set(ByVal Value As String)
                _SoBanSao = Value
            End Set
        End Property

        Public Property SoBanPhoto() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.SoBanPhoto
            Get
                Return _SoBanPhoto
            End Get
            Set(ByVal Value As String)
                _SoBanPhoto = Value
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

        Public Property MaHoSoKemTheo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaHoSoKemTheo
            Get
                Return _MaHoSoKemTheo
            End Get
            Set(ByVal Value As String)
                _MaHoSoKemTheo = Value
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
            _HoSoKemTheoID = ""
            _SoBanChinh = ""
            _SoBanSao = ""
            _SoBanPhoto = ""
            _HoSoTiepNhanID = ""
            _MaHoSoKemTheo = ""
            _LastUpdate = ""
        End Sub



    End Class
    Public Class HoSoKemTheoController

    End Class
End Namespace

