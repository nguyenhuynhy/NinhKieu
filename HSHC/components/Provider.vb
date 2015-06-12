Imports System
Imports System.IO
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Web
Imports System.Xml

Namespace PortalQH

    Public Class ProviderConfiguration

        Private _Providers As New Hashtable
        Private _DefaultProvider As String

        Public Shared Function GetProviderConfiguration(ByVal strProvider As String) As ProviderConfiguration
            Return CType(ConfigurationSettings.GetConfig("PortalQH/" & strProvider), ProviderConfiguration)
        End Function

        Friend Sub LoadValuesFromConfigurationXml(ByVal node As XmlNode)
            Dim attributeCollection As XmlAttributeCollection = node.Attributes

            ' Get the default provider
            _DefaultProvider = attributeCollection("defaultProvider").Value

            ' Read child nodes
            Dim child As XmlNode
            For Each child In node.ChildNodes
                If child.Name = "providers" Then
                    GetProviders(child)
                End If
            Next child
        End Sub

        Friend Sub GetProviders(ByVal node As XmlNode)

            Dim Provider As XmlNode
            For Each Provider In node.ChildNodes

                Select Case Provider.Name
                    Case "add"
                        Providers.Add(Provider.Attributes("name").Value, New Provider(Provider.Attributes))

                    Case "remove"
                        Providers.Remove(Provider.Attributes("name").Value)

                    Case "clear"
                        Providers.Clear()
                End Select
            Next Provider
        End Sub

        Public ReadOnly Property DefaultProvider() As String
            Get
                Return _DefaultProvider
            End Get
        End Property

        Public ReadOnly Property Providers() As Hashtable
            Get
                Return _Providers
            End Get
        End Property
    End Class

    Public Class Provider

        Private _ProviderName As String
        Private _ProviderType As String
        Private _ProviderAttributes As New NameValueCollection

        Public Sub New(ByVal Attributes As XmlAttributeCollection)

            ' Set the name of the provider
            '
            _ProviderName = Attributes("name").Value

            ' Set the type of the provider
            '
            _ProviderType = Attributes("type").Value

            ' Store all the attributes in the attributes bucket
            '
            Dim Attribute As XmlAttribute
            For Each Attribute In Attributes

                If Attribute.Name <> "name" And Attribute.Name <> "type" Then
                    _ProviderAttributes.Add(Attribute.Name, Attribute.Value)
                End If
            Next Attribute
        End Sub

        Public ReadOnly Property Name() As String
            Get
                Return _ProviderName
            End Get
        End Property

        Public ReadOnly Property Type() As String
            Get
                Return _ProviderType
            End Get
        End Property

        Public ReadOnly Property Attributes() As NameValueCollection
            Get
                Return _ProviderAttributes
            End Get
        End Property
    End Class

    Friend Class ProviderConfigurationHandler
        Implements IConfigurationSectionHandler

        Public Overridable Overloads Function Create(ByVal parent As Object, ByVal context As Object, ByVal node As System.Xml.XmlNode) As Object Implements IConfigurationSectionHandler.Create
            Dim objProviderConfiguration As New ProviderConfiguration
            objProviderConfiguration.LoadValuesFromConfigurationXml(node)
            Return objProviderConfiguration
        End Function
    End Class

End Namespace