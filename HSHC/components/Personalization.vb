Imports System
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections

Namespace PortalQH

    Public Class PersonalizationInfo

        ' local property declarations
        Private _UserId As String
        Private _PortalId As Integer
        Private _IsModified As Boolean
        Private _Profile As HashTable

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property UserId() As String
            Get
                Return _UserId
            End Get
            Set(ByVal Value As String)
                _UserId = Value
            End Set
        End Property

        Public Property PortalId() As Integer
            Get
                Return _PortalId
            End Get
            Set(ByVal Value As Integer)
                _PortalId = Value
            End Set
        End Property

        Public Property IsModified() As Boolean
            Get
                Return _IsModified
            End Get
            Set(ByVal Value As Boolean)
                _IsModified = Value
            End Set
        End Property

        Public Property Profile() As Hashtable
            Get
                Return _Profile
            End Get
            Set(ByVal Value As Hashtable)
                _Profile = Value
            End Set
        End Property

    End Class

    Public Class PersonalizationController

        Public Sub LoadProfile(ByVal objHTTPContext As HttpContext, ByVal UserId As String, ByVal PortalId As Integer)

            Dim objPersonalization As New PersonalizationInfo

            objPersonalization.UserId = UserId
            objPersonalization.PortalId = PortalId
            objPersonalization.IsModified = False

            Dim dr As IDataReader = DataProvider.Instance().GetProfile(UserId, PortalId)
            If dr.Read Then
                objPersonalization.Profile = DeserializeHashTableBase64(dr("ProfileData").ToString)
            Else ' does not exist
                DataProvider.Instance().AddProfile(UserId, PortalId)
            End If
            dr.Close()

            objHTTPContext.Items.Add("Personalization", objPersonalization)

        End Sub

        Public Sub SaveProfile(ByVal objHTTPContext As HttpContext, ByVal UserId As String, ByVal PortalId As Integer)
            Dim objPersonalization As PersonalizationInfo = CType(objHTTPContext.Items("Personalization"), PersonalizationInfo)
            If objPersonalization.IsModified Then
                Dim ProfileData As String = SerializeHashTableBase64(objPersonalization.Profile)
                DataProvider.Instance().UpdateProfile(UserId, PortalId, ProfileData)
            End If
        End Sub

        Private Function SerializeHashTableBase64(ByVal Source As Hashtable) As String
            Dim strString As String
            If Source.Count <> 0 Then
                Dim bin As BinaryFormatter = New BinaryFormatter
                Dim mem As MemoryStream = New MemoryStream
                bin.Serialize(mem, Source)
                strString = Convert.ToBase64String(mem.GetBuffer(), 0, Convert.ToInt32(mem.Length))
                mem.Close()
            Else
                strString = ""
            End If
            Return strString
        End Function

        Private Function DeserializeHashTableBase64(ByVal Source As String) As Hashtable
            Dim objHashTable As Hashtable
            If Source <> "" Then
                Dim bits As Byte() = Convert.FromBase64String(Source)
                Dim mem As MemoryStream = New MemoryStream(bits)
                Dim bin As BinaryFormatter = New BinaryFormatter
                objHashTable = CType(bin.Deserialize(mem), Hashtable)
                mem.Close()
            Else
                objHashTable = New Hashtable
            End If
            Return objHashTable
        End Function

    End Class

    Public Class Personalization

        Public Shared Sub SetProfile(ByVal NamingContainer As String, ByVal Key As String, ByVal Value As Object)
            Dim objPersonalization As PersonalizationInfo = CType(HttpContext.Current.Items("Personalization"), PersonalizationInfo)
            If Not objPersonalization Is Nothing Then
                objPersonalization.Profile(NamingContainer & ":" & Key) = Value
                objPersonalization.IsModified = True
            End If
        End Sub

        Public Shared Function GetProfile(ByVal NamingContainer As String, ByVal Key As String) As Object
            Dim objPersonalization As PersonalizationInfo = CType(HttpContext.Current.Items("Personalization"), PersonalizationInfo)
            If Not objPersonalization Is Nothing Then
                Return objPersonalization.Profile(NamingContainer & ":" & Key)
            Else
                Return ""
            End If
        End Function

        Public Shared Sub RemoveProfile(ByVal NamingContainer As String, ByVal Key As String)
            Dim objPersonalization As PersonalizationInfo = CType(HttpContext.Current.Items("Personalization"), PersonalizationInfo)
            If Not objPersonalization Is Nothing Then
                CType(objPersonalization.Profile, Hashtable).Remove(NamingContainer & ":" & Key)
                objPersonalization.IsModified = True
            End If
        End Sub

    End Class

End Namespace