Imports PortalQH
Namespace CPKTQH
    Public Class DuongDiTinhTrangInfo
        Private _DuongDiTinhTrangID As String
        Private _TabCode As String
        Private _ItemCode As String
        Private _CapDo As String
        Private _MaLinhVuc As String
        Private _MaTinhTrangCurr As String
        Private _MaTinhTrangNext As String
        Private _MaTinhTrangXuLyCurr As String
        Private _MaTinhTrangXuLyNext As String

        Public Property DuongDiTinhTrangID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _DuongDiTinhTrangID
            End Get
            Set(ByVal Value As String)
                _DuongDiTinhTrangID = Value
            End Set
        End Property
        Public Property TabCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property ItemCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _ItemCode
            End Get
            Set(ByVal Value As String)
                _ItemCode = Value
            End Set
        End Property
        Public Property CapDo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _CapDo
            End Get
            Set(ByVal Value As String)
                _CapDo = Value
            End Set
        End Property
        Public Property MaLinhVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property
        Public Property MaTinhTrangCurr() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaTinhTrangCurr
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangCurr = Value
            End Set
        End Property
        Public Property MaTinhTrangNext() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaTinhTrangNext
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangNext = Value
            End Set
        End Property

        Public Property MaTinhTrangXuLyCurr() As String
            Get
                Return _MaTinhTrangXuLyCurr
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangXuLyCurr = Value
            End Set
        End Property

        Public Property MaTinhTrangXuLyNext() As String
            Get
                Return _MaTinhTrangXuLyNext
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangXuLyNext = Value
            End Set
        End Property

        Public Sub ResetAll()
            _DuongDiTinhTrangID = ""
            _TabCode = ""
            _ItemCode = Nothing
            _CapDo = ""
            _MaLinhVuc = ""
            _MaTinhTrangCurr = ""
            _MaTinhTrangNext = ""
            _MaTinhTrangXuLyCurr = ""
            _MaTinhTrangXuLyNext = ""
        End Sub
    End Class

    Public Class DuongDiTinhTrangController
        Public Function GetDuongDiTinhTrangNext(ByVal obj As DuongDiTinhTrangInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDuongDiTinhTrangNext", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangCurr)
        End Function
        Public Sub AddDuongDiTinhTrang(ByVal obj As DuongDiTinhTrangInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsDuongDiTinhTrang", _
                                                                    obj.TabCode, _
                                                                    obj.ItemCode, _
                                                                    obj.MaLinhVuc, _
                                                                    obj.MaTinhTrangCurr, _
                                                                    obj.MaTinhTrangNext)
        End Sub
        Public Sub DelDuongDiTinhTrang(ByVal obj As DuongDiTinhTrangInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelDuongDiTinhTrang", _
                                                                    obj.TabCode, _
                                                                    obj.MaLinhVuc, _
                                                                    obj.MaTinhTrangCurr)
        End Sub

        Public Function getDanhSachDuongDiTinhTrang(ByVal pMaLinhVuc As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDanhSachDuongDiTinhTrang", GetCommonDB(), pMaLinhVuc)
        End Function

        Public Function getDuongDiTinhTrang(ByVal pDuongDiTinhTrangID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDuongDiTinhTrang", pDuongDiTinhTrangID)
        End Function

        Public Function insDuongDiTinhTrang(ByVal objDuongDiTinhTrang As DuongDiTinhTrangInfo) As String
            Dim strDuongDiTinhTrangID As String
            With objDuongDiTinhTrang
                strDuongDiTinhTrangID = DataProvider.Instance.ExecuteScalar("sp_insDuongDiTinhTrang", _
                                                                .TabCode, _
                                                                .ItemCode, _
                                                                .MaLinhVuc, _
                                                                .MaTinhTrangCurr, _
                                                                .MaTinhTrangNext, _
                                                                .MaTinhTrangXuLyCurr, _
                                                                .MaTinhTrangXuLyNext)
            End With
            Return strDuongDiTinhTrangID
        End Function
        'Public Function insDuongDiTinhTrang(ByVal objDuongDiTinhTrang As DuongDiTinhTrangInfo) As String
        '    Dim strDuongDiTinhTrangID As String
        '    With objDuongDiTinhTrang
        '        strDuongDiTinhTrangID = DataProvider.Instance.ExecuteScalar("sp_insDuongDiTinhTrang", _
        '                                                        .TabCode, _
        '                                                        .ItemCode, _
        '                                                        .MaLinhVuc, _
        '                                                        .MaTinhTrangCurr, _
        '                                                        .MaTinhTrangNext)

        '    End With
        '    Return strDuongDiTinhTrangID
        'End Function
        Public Function updDuongDiTinhTrang(ByVal objDuongDiTinhTrang As DuongDiTinhTrangInfo) As Boolean
            Dim str As String
            With objDuongDiTinhTrang
                str = DataProvider.Instance.ExecuteScalar("sp_updDuongDiTinhTrang", _
                                                                .DuongDiTinhTrangID, _
                                                                .TabCode, _
                                                                .ItemCode, _
                                                                .MaLinhVuc, _
                                                                .MaTinhTrangCurr, _
                                                                .MaTinhTrangNext, _
                                                                .MaTinhTrangXuLyCurr, _
                                                                .MaTinhTrangXuLyNext)
            End With
            Return Not CBool(str)
        End Function

        Public Function delDuongDiTinhTrang(ByVal pDuongDiTinhTrangID As String) As Boolean
            Dim str As String
            str = DataProvider.Instance.ExecuteScalar("sp_delDuongDiTinhTrang", pDuongDiTinhTrangID)
            Return Not CBool(str)
        End Function
    End Class

    Public Class TinhTrangXuLyHoSoInfo
        Private _MaLinhVuc As String
        Private _TabCode As String
        Private _MaTinhTrangHoSo As String
        Private _MaTinhTrangXuLy As String


        Public Property MaLinhVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaLinhVuc
            End Get
            Set(ByVal Value As String)
                _MaLinhVuc = Value
            End Set
        End Property
        Public Property TabCode() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _TabCode
            End Get
            Set(ByVal Value As String)
                _TabCode = Value
            End Set
        End Property
        Public Property MaTinhTrangHoSo() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaTinhTrangHoSo
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangHoSo = Value
            End Set
        End Property
        Public Property MaTinhTrangXuLy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoBoSungID
            Get
                Return _MaTinhTrangXuLy
            End Get
            Set(ByVal Value As String)
                _MaTinhTrangXuLy = Value
            End Set
        End Property
        Public Sub ResetAll()
            _MaLinhVuc = ""
            _TabCode = ""
            _MaTinhTrangHoSo = ""
            _MaTinhTrangXuLy = ""

        End Sub
    End Class
    Public Class TinhTrangXuLyHoSoController
        Public Function GetTinhTrangXuLy(ByVal obj As TinhTrangXuLyHoSoInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getTinhTrangXuLyHoSo", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangHoSo)
        End Function
        Public Sub AddTinhTrangXuLyHoSo(ByVal obj As TinhTrangXuLyHoSoInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsTinhTrangXuLyHoSo", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangHoSo, _
                                                                    obj.MaTinhTrangXuLy)
        End Sub
        Public Sub DelTinhTrangXuLyHoSo(ByVal obj As TinhTrangXuLyHoSoInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelTinhTrangXuLyHoSo", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangHoSo)
        End Sub
    End Class
End Namespace