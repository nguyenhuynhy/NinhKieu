Imports PortalQH
Namespace CPXD
    Public Class NXHS_HangMucXDTruocInfo
        Inherits PortalQH.PortalModuleControl
        Protected _HangMucXayDungID As String
        Protected _NhanXetHoSoID As String
        Protected _MaHangMuc As String
        Protected _NoiDung As String
        Protected _DienTich As Double
        Protected _ChieuCao As Double
        Protected _GiuNguyen As String
        Public Property HangMucXayDungID() As String
            Get
                Return _HangMucXayDungID
            End Get
            Set(ByVal Value As String)
                _HangMucXayDungID = Value
            End Set
        End Property
        Public Property NhanXetHoSoID() As String
            Get
                Return _NhanXetHoSoID
            End Get
            Set(ByVal Value As String)
                _NhanXetHoSoID = Value
            End Set
        End Property
        Public Property MaHangMuc() As String
            Get
                Return _MaHangMuc
            End Get
            Set(ByVal Value As String)
                _MaHangMuc = Value
            End Set
        End Property
        Public Property NoiDung() As String
            Get
                Return _NoiDung
            End Get
            Set(ByVal Value As String)
                _NoiDung = Value
            End Set
        End Property
        Public Property DienTich() As Double
            Get
                Return _DienTich
            End Get
            Set(ByVal Value As Double)
                _DienTich = Value
            End Set
        End Property
        Public Property ChieuCao() As Double
            Get
                Return _ChieuCao
            End Get
            Set(ByVal Value As Double)
                _ChieuCao = Value
            End Set
        End Property
        Public Property GiuNguyen() As String
            Get
                Return _GiuNguyen
            End Get
            Set(ByVal Value As String)
                _GiuNguyen = Value
            End Set
        End Property
    End Class
    Public Class NXHS_HangMucXDTruocController
        Public Function AddHangMucXayDungAuTO(ByVal obj As NXHS_HangMucXDTruocInfo) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_InsHangMucXayDung", obj)
        End Function
        Public Function AddHangMucXayDung(ByVal obj As NXHS_HangMucXDTruocInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_InsHangMucXayDung", _
                                                                obj.NhanXetHoSoID, _
                                                                obj.MaHangMuc, _
                                                                obj.NoiDung, _
                                                                obj.DienTich, _
                                                                obj.ChieuCao, _
                                                                obj.GiuNguyen)
        End Function
        Public Function UpdateHangMucXayDung(ByVal obj As NXHS_HangMucXDTruocInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_UpdHangMucXayDung", _
                                                                obj.HangMucXayDungID, _
                                                                obj.NhanXetHoSoID, _
                                                                obj.MaHangMuc, _
                                                                obj.NoiDung, _
                                                                obj.DienTich, _
                                                                obj.ChieuCao, _
                                                                obj.GiuNguyen)
        End Function
        Public Function GetHangMucXayDung(ByVal pHangMucXayDungID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_getHangMucXayDung", pHangMucXayDungID)
        End Function
        Public Function ListHangMucXayDung(ByVal pHoSoNhanXetID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_LstHangMucXayDung", pHoSoNhanXetID)
        End Function
        Public Sub DelHangMucXayDung(ByVal strNhanXetHoSoID As String)
            DataProvider.Instance.ExecuteQueryStoreProc("sp_DelHangMucXayDung", strNhanXetHoSoID)
        End Sub
    End Class
End Namespace
