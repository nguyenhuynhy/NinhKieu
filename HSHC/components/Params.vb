Namespace PortalQH
    Public Class ParamInfo
        Private _ParamID As String
        Private _ParamName As String
        Private _ParamValue As String


        Public Property ParamID() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ParamID
            Get
                Return _ParamID
            End Get
            Set(ByVal Value As String)
                _ParamID = Value
            End Set
        End Property

        Public Property ParamName() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ParamName
            Get
                Return _ParamName
            End Get
            Set(ByVal Value As String)
                _ParamName = Value
            End Set
        End Property

        Public Property ParamValue() As String
            'Used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.ParamValue
            Get
                Return _ParamValue
            End Get
            Set(ByVal Value As String)
                _ParamValue = Value
            End Set
        End Property
        Public Sub ResetAll()
            _ParamID = ""
            _ParamName = ""
            _ParamValue = ""
        End Sub
    End Class
    Public Class ParamController
        'ThuyTT add date 16/01/2006
        'Mục đích: lấy giá trị tham số của chương trình
        Public Shared Function GetParamValue(ByVal pMaLinhVuc As String, ByVal pParamName As String) As String
            Return DataProvider.Instance.ExecuteScalar("sp_GetParamValue", pMaLinhVuc, pParamName)
        End Function
    End Class
End Namespace