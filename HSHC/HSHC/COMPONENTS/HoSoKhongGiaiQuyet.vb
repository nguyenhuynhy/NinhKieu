Imports PortalQH
Namespace HSHC
    Public Class HoSoKhongGiaiQuyetInfo
        Private _HoSoKhongGiaiQuyetID As String
        Private _MaKhuVuc As String
        Private _HoSoTiepNhanID As String
        Private _NgayXuLy As String
        Private _MaLyDo As String
        Private _NoiDungXuLy As String
        Private _GhiChu As String
        Private _MaNguoiSuDung As String


        Public Property HoSoKhongGiaiQuyetID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.HoSoKhongGiaiQuyetID
            Get
                Return _HoSoKhongGiaiQuyetID
            End Get
            Set(ByVal Value As String)
                _HoSoKhongGiaiQuyetID = Value
            End Set
        End Property

        Public Property MaKhuVuc() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaKhuVuc
            Get
                Return _MaKhuVuc
            End Get
            Set(ByVal Value As String)
                _MaKhuVuc = Value
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

        Public Property NgayXuLy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NgayXuLy
            Get
                Return _NgayXuLy
            End Get
            Set(ByVal Value As String)
                _NgayXuLy = Value
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

        Public Property NoiDungXuLy() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.NoiDungXuLy
            Get
                Return _NoiDungXuLy
            End Get
            Set(ByVal Value As String)
                _NoiDungXuLy = Value
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

        Public Property MaNguoiSuDung() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.MaNguoiSuDung
            Get
                Return _MaNguoiSuDung
            End Get
            Set(ByVal Value As String)
                _MaNguoiSuDung = Value
            End Set
        End Property
        Public Sub ResetAll()
            _HoSoKhongGiaiQuyetID = ""
            _MaKhuVuc = ""
            _HoSoTiepNhanID = ""
            _NgayXuLy = ""
            _MaLyDo = ""
            _NoiDungXuLy = ""
            _GhiChu = ""
            _MaNguoiSuDung = ""
        End Sub

    End Class
    Public Class HoSoKhongGiaiQuyetController
        Public Sub AddHoSoKhongGiaiQuyet(ByVal obj As Object)
            DataProvider.Instance.ExecuteNonQueryStoreProcAuTo("sp_InsHoSoKhongGiaiQuyet", obj)
        End Sub
        Public Function GetHoSoKhongGiaiQuyet(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetHoSoKhongGiaiQuyet", obj)
        End Function
        Public Function GetHoSoKhongGiaiQuyet(ByVal pSoBienNhan As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_GetHoSoKhongGiaiQuyet", pSoBienNhan)
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' In van ban khong giai quyet ho so
        ''' </summary>
        ''' <param name="strHoSoTiepNhanID"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function InHoSoKhongGiaiQuyet(ByVal strHoSoTiepNhanID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InThongBaoHoSoKhongGiaiQuyet", strHoSoTiepNhanID)
        End Function
        Public Function GetLanhDaoKhongGiaiQuyet(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_GetLanhDaoKhongDuyet", obj)
        End Function
        Public Function AddLanhDaoKhongDuyet(ByVal obj As Object) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProcAuTo("sp_AddLanhDaoKhongDuyet", obj)
        End Function
    End Class
End Namespace