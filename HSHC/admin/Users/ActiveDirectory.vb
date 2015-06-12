Imports System.DirectoryServices
Namespace PortalQH
    Public Class ActiveDirectory
        Private strDomain As String = "LDAP://220.200.150.5/ou=FSOFTHCM User,dc=fsofthcm,dc=com"
        Public Property DomainName() As String
            Get
                Return strDomain
            End Get
            Set(ByVal Value As String)
                strDomain = Value
            End Set
        End Property

        Private strFilter As String = "(&(objectCategory=person)(objectClass=user))"
        Public Property Filters() As String
            Get
                Return strFilter
            End Get
            Set(ByVal Value As String)
                strFilter = Value
            End Set
        End Property

        Private strNameID As String = "samaccountname"
        Public Property NameID() As String
            Get
                Return strNameID
            End Get
            Set(ByVal Value As String)
                strNameID = Value
            End Set
        End Property

        Private strUsername As String = "svtt"
        Public Property Username() As String
            Get
                Return strUsername
            End Get
            Set(ByVal Value As String)
                strUsername = Value
            End Set
        End Property

        Private strPassword As String = "svtt"
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        Public Function CheckAccount(ByVal name As String, ByVal pass As String) As Boolean
            Try
                Dim de As New DirectoryEntry(DomainName, name, pass)
                Dim ds As New DirectorySearcher(de)
                ds.FindAll()
                Return True
            Catch e As Exception
                Return False
            End Try
        End Function

        Public Function CheckUsername(ByVal name As String) As Boolean
            Dim de As New DirectoryEntry(DomainName, Username, Password)
            Dim ds As New DirectorySearcher(de)
            ds.Filter = Filters
            Dim rs As SearchResultCollection = ds.FindAll()
            For Each sr As SearchResult In rs
                If CType(sr.GetDirectoryEntry().Properties(NameID).Value, String).Trim.ToLower = name.Trim().ToLower Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function Check(ByVal username As String, ByVal password As String, ByVal ischeck As Boolean) As Integer
            If ischeck Or CheckAccount(username, password) Then Return 0
            If Not CheckUsername(username) Then Return 1
            Return 2
        End Function

        Public Function GetListUser() As ArrayList
            Dim de As New DirectoryEntry(DomainName, Username, Password)
            Dim ds As New DirectorySearcher(de)
            ds.Filter = Filters
            Dim rs As SearchResultCollection = ds.FindAll()
            Dim al As New ArrayList
            For Each sr As SearchResult In rs
                al.Add(sr.GetDirectoryEntry().Properties(NameID).Value)
            Next
            Return al
        End Function

        Public Function GetTableUser(ByVal filter As ArrayList) As DataTable
            Dim de As New DirectoryEntry(DomainName, Username, Password)
            Dim ds As New DirectorySearcher(de)
            ds.Filter = Filters
            Dim rs As SearchResultCollection = ds.FindAll()
            Dim dt As New DataTable
            For Each s As String In filter
                dt.Columns.Add(s)
            Next
            If dt.Columns.Count <= filter.Count Then dt.Columns.Add()
            For Each sr As SearchResult In rs
                Dim o(filter.Count) As Object
                For i As Integer = 0 To filter.Count - 1
                    o(i) = sr.GetDirectoryEntry().Properties(CType(filter(i), String)).Value
                Next
                dt.Rows.Add(o)
            Next
            Return dt
        End Function
    End Class
End Namespace