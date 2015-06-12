Namespace PortalQH
    Public Class NewsInfo
        Private _News_ID As String
        Public Property News_ID() As String
            Get
                Return _News_ID
            End Get
            Set(ByVal Value As String)
                _News_ID = Value
            End Set
        End Property
        Private _Title As String
        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal Value As String)
                _Title = Value
            End Set
        End Property

        Private _TitleE As String
        Public Property TitleE() As String
            Get
                Return _TitleE
            End Get
            Set(ByVal Value As String)
                _TitleE = Value
            End Set
        End Property

        Private _Image As String
        Public Property Image() As String
            Get
                Return _Image
            End Get
            Set(ByVal Value As String)
                _Image = Value
            End Set
        End Property

        Private _Summarize As String
        Public Property Summarize() As String
            Get
                Return _Summarize
            End Get
            Set(ByVal Value As String)
                _Summarize = Value
            End Set
        End Property

        Private _Body As String
        Public Property Body() As String
            Get
                Return _Body
            End Get
            Set(ByVal Value As String)
                _Body = Value
            End Set
        End Property

        Private _BodyE As String
        Public Property BodyE() As String
            Get
                Return _BodyE
            End Get
            Set(ByVal Value As String)
                _BodyE = Value
            End Set
        End Property

        Private _Source As String
        Public Property Source() As String
            Get
                Return _Source
            End Get
            Set(ByVal Value As String)
                _Source = Value
            End Set
        End Property

        Private _SourceE As String
        Public Property SourceE() As String
            Get
                Return _SourceE
            End Get
            Set(ByVal Value As String)
                _SourceE = Value
            End Set
        End Property

        Private _Hotnews As String
        Public Property Hotnews() As String
            Get
                Return _Hotnews
            End Get
            Set(ByVal Value As String)
                _Hotnews = Value
            End Set
        End Property

        Private _PublishDate As DateTime
        Public Property PublishDate() As DateTime
            Get
                Return _PublishDate
            End Get
            Set(ByVal Value As DateTime)
                _PublishDate = Value
            End Set
        End Property

        Private _Show As String
        Public Property Show() As String
            Get
                Return _Show
            End Get
            Set(ByVal Value As String)
                _Show = Value
            End Set
        End Property

        Private _ModifiedOn As DateTime
        Public Property ModifiedOn() As DateTime
            Get
                Return _ModifiedOn
            End Get
            Set(ByVal Value As DateTime)
                _ModifiedOn = Value
            End Set
        End Property

        Private _ModifiedBy As String
        Public Property ModifiedBy() As String
            Get
                Return _ModifiedBy
            End Get
            Set(ByVal Value As String)
                _ModifiedBy = Value
            End Set
        End Property

        Private _Category_ID As String
        Public Property Category_ID() As String
            Get
                Return _Category_ID
            End Get
            Set(ByVal Value As String)
                _Category_ID = Value
            End Set
        End Property

        Private _WorkFlow_ID As String
        Public Property WorkFlow_ID() As String
            Get
                Return _WorkFlow_ID
            End Get
            Set(ByVal Value As String)
                _WorkFlow_ID = Value
            End Set
        End Property

        Private _State_ID As String
        Public Property State_ID() As String
            Get
                Return _State_ID
            End Get
            Set(ByVal Value As String)
                _State_ID = Value
            End Set
        End Property
    End Class

    Public Class NewsController
        Public Function LstAll(ByVal db As String, Optional ByVal Title As String = "", _
            Optional ByVal Category_ID As String = "", _
            Optional ByVal State_ID As String = "", _
            Optional ByVal language As String = "V", _
            Optional ByVal PageNumber As Integer = 1, _
            Optional ByVal PageSize As Integer = 10, _
            Optional ByVal FromDate As String = "", _
            Optional ByVal ToDate As String = "", _
            Optional ByVal ExcpID As Integer = -1) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db & "..News_Lst", Title, _
                                                                Category_ID, State_ID, language, PageNumber, PageSize, FromDate, ToDate, ExcpID)
        End Function

        'return dataset
        Public Function getDataByKey(ByVal db As String, ByVal News_ID As String, Optional ByVal language As String = "V") As DataSet
            Dim dsResult As DataSet = DataProvider.Instance.ExecuteQueryStoreProc(db & "..News_Get", News_ID, language)
            Return dsResult
        End Function

        Public Function insNews(ByVal db As String, ByVal ParamArray arrParams() As Object) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..NEWS_Ins", arrParams)
        End Function

        Public Function delNews(ByVal db As String, ByVal News_ID As String) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..News_Del", News_ID)
        End Function

        Public Function updNews(ByVal db As String, ByVal ParamArray arrParams() As Object) As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..NEWS_Upd", arrParams)
        End Function

        Public Function updNewsState(ByVal db As String, ByVal News_ID As String, Optional ByVal ModifyBy As String = "") As Integer
            Return DataProvider.Instance.ExecuteNonQueryStoreProc(db & "..News_Upd_State", News_ID, ModifyBy)
        End Function

        Public Function getCategories(ByVal db As String) As DataSet
            Return DataProvider.Instance.ExecuteQueryStoreProc(db & "..sp_GetAllDMCATEGORIES", "V")
        End Function
    End Class
End Namespace
