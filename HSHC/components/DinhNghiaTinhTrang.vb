Namespace PortalQH
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : DuongDiTinhTrangInfo
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[phuocdd]   3/29/2007   Updated
    '''     Desc    :Them thong tin so ngay giai quyet, MaLoaiHoSo
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class DuongDiTinhTrangInfo
        Private _DuongDiTinhTrangID As String
        Private _TabCode As String
        Private _ItemCode As String
        Private _CapDo As String
        Private _MaLinhVuc As String
        Private _MaTinhTrangCurr As String
        Private _MaTinhTrangNext As String
        Private _SoNgayGiaiQuyet As Integer
        Private _MaLoaiHoSo As String

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
        Public Sub ResetAll()

            _DuongDiTinhTrangID = ""
            _TabCode = ""
            _ItemCode = Nothing
            _CapDo = ""
            _MaLinhVuc = ""
            _MaTinhTrangCurr = ""
            _MaTinhTrangNext = ""

        End Sub
        Public Property SoNgayGiaiQuyet() As Integer
            Get
                Return _SoNgayGiaiQuyet
            End Get
            Set(ByVal Value As Integer)
                _SoNgayGiaiQuyet = Value
            End Set
        End Property
        Public Property MaLoaiHoso() As String
            Get
                Return _MaLoaiHoSo
            End Get
            Set(ByVal Value As String)
                _MaLoaiHoSo = Value
            End Set
        End Property

    End Class

    Public Class DuongDiTinhTrangController
        Public Function GetDuongDiTinhTrangNext(ByVal obj As DuongDiTinhTrangInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getDuongDiTinhTrangNext", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangCurr)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub AddDuongDiTinhTrang(ByVal obj As DuongDiTinhTrangInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_InsDuongDiTinhTrang", _
                                                                    obj.TabCode, _
                                                                    obj.ItemCode, _
                                                                    obj.MaLinhVuc, _
                                                                    obj.MaTinhTrangCurr, _
                                                                    obj.MaTinhTrangNext)
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub DelDuongDiTinhTrang(ByVal obj As DuongDiTinhTrangInfo)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelDuongDiTinhTrang", _
                                                                    obj.TabCode, _
                                                                    obj.MaLinhVuc, _
                                                                    obj.MaTinhTrangCurr)
        End Sub
        Public Function GetDuongDiTinhTrang(ByVal strLinhVuc As String, ByVal strTabCode As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDuongDiTinhTrangByTabCode", strLinhVuc, strTabCode)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	3/30/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub updSoNgayGiaiQuyet(ByVal obj As DuongDiTinhTrangInfo)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_UpdSoNgayGiaiQuyetSub", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangCurr, _
                                                                    obj.MaTinhTrangNext, _
                                                                    obj.MaLoaiHoso, _
                                                                    obj.SoNgayGiaiQuyet)
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	3/30/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function getSoNgayGiaiQuyet(ByVal obj As DuongDiTinhTrangInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetSoNgayGiaiQuyetSub", _
                                                                    obj.MaLinhVuc, _
                                                                    obj.TabCode, _
                                                                    obj.MaTinhTrangCurr, _
                                                                    obj.MaTinhTrangNext, _
                                                                    obj.MaLoaiHoso)
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
        Public Function GetTinhTrangXuLyByTinhTrangHoSo(ByVal strMaLinhVuc As String, ByVal strTabcode As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetTinhTrangXuLyByTinhTrangHoSo", _
                                                                                strMaLinhVuc, _
                                                                                strTabcode)
        End Function
    End Class
End Namespace