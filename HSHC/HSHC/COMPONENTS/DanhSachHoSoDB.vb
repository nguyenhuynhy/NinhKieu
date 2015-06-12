Imports PortalQH
Namespace HSHC

    '==========================================================================
    '**************************************************************************
    '==========================================================================
    Public Class DanhSachHoSoInfo
        Private _TabID As String
        Private _Desc As String
        Private _Control As String
        Private _Button As String
        Private _IsCheckAll As Boolean
        Private _HyperlinkColumn As String

        Public Property TabID() As String
            Get
                Return _TabID
            End Get
            Set(ByVal Value As String)
                _TabID = Value
            End Set
        End Property

        Public Property Desc() As String
            Get
                Return _Desc
            End Get
            Set(ByVal Value As String)
                _Desc = Value
            End Set
        End Property

        Public Property Control() As String
            Get
                Return _Control
            End Get
            Set(ByVal Value As String)
                _Control = Value
            End Set
        End Property

        Public Property Button() As String
            Get
                Return _Button
            End Get
            Set(ByVal Value As String)
                _Button = Value
            End Set
        End Property

        Public Property CheckAll() As Boolean
            Get
                Return _IsCheckAll
            End Get
            Set(ByVal Value As Boolean)
                _IsCheckAll = Value
            End Set
        End Property

        Public Property HyperColumn() As String
            Get
                Return _HyperlinkColumn
            End Get
            Set(ByVal Value As String)
                _HyperlinkColumn = Value
            End Set
        End Property
    End Class

    '==========================================================================
    '**************************************************************************
    '==========================================================================
    Public Class DanhSachHoSoControl

        Public Function GetDisplayCategoryInfo(ByVal pTabCode As String) As DanhSachHoSoInfo
            Dim ds As DataSet
            Dim objDSHSInfo As New DanhSachHoSoInfo
            ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_GetDisplayCategoryInfo", CInt(pTabCode))
            With objDSHSInfo
                .TabID = pTabCode
                .Desc = ds.Tables(0).Rows(0).Item(0).ToString
                .Control = ds.Tables(0).Rows(0).Item(1).ToString
                .Button = ds.Tables(0).Rows(0).Item(2).ToString
                .CheckAll = CBool(ds.Tables(0).Rows(0).Item(3).ToString)
                .HyperColumn = ds.Tables(0).Rows(0).Item(4).ToString
            End With
            Return objDSHSInfo
        End Function

        '=============================================
        '=============================================
    End Class
End Namespace
