Imports PortalQH
Namespace CPKTQH
    <Serializable()> Public Class ViPhamHanhChinhInfo
        Private _SoQuyetDinh As String
        Private _SoGiayPhep As String
        Private _SoCMND As String
        Private _SoNha As String
        Private _Duong As String
        Private _Phuong As String
        Private _URL As String

        Public Property SoQuyetDinh() As String
            Get
                Return _SoQuyetDinh
            End Get
            Set(ByVal Value As String)
                _SoQuyetDinh = Value
            End Set
        End Property

        Public Property SoGiayPhep() As String
            Get
                Return _SoGiayPhep
            End Get
            Set(ByVal Value As String)
                _SoGiayPhep = Value
            End Set
        End Property

        Public Property SoCMND() As String
            Get
                Return _SoCMND
            End Get
            Set(ByVal Value As String)
                _SoCMND = Value
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

        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
    End Class

    Public Class ViPhamHanhChinhController

        Public Function getDanhSachViPhamHanhChinh(ByVal obj As ViPhamHanhChinhInfo) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ViPhamHanhChinh_Lst", _
                                                            obj.SoQuyetDinh.Replace("'", "''"), _
                                                            obj.SoGiayPhep.Replace("'", "''"), _
                                                            obj.SoCMND.Replace("'", "''"), _
                                                            obj.SoNha.Replace("'", "''"), _
                                                            obj.Duong, _
                                                            obj.Phuong, _
                                                            obj.URL)
        End Function

        Public Function getThongTinViPhamHanhChinh(ByVal pID As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc("sp_ViPhamHanhChinh_Get", pID)
        End Function

        Public Sub delViPhamHanhChinh(ByVal pID As String)
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_ViPhamHanhChinh_Del", pID)
        End Sub

        Public Function updViPhamHanhChinh(ByVal obj As Object) As String
            Return DataProvider.Instance.ExecuteScalarAuto("sp_ViPhamHanhChinh_Upd", obj)
        End Function

    End Class
End Namespace