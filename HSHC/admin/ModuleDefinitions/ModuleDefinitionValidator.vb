
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( sales@perpetualmotion.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Globalization
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports ICSharpCode.SharpZipLib.Zip

Namespace PortalQH
    Public Enum ModuleDefinitionVersion
        VUnknown = 0
        V1 = 1
        V2 = 2
        V2_Skin = 3
        V2_Provider = 4
    End Enum

    Public Class ModuleDefinitionValidator
        Dim _errs As New ArrayList
        Dim _xml As Stream
        Dim _schemaCollection As New XmlSchemaCollection

        Public Property Errors() As ArrayList
            Get
                Return _errs
            End Get
            Set(ByVal Value As ArrayList)
                _errs = Value
            End Set
        End Property

        Public ReadOnly Property XML() As String
            Get
                Dim xmlString As String
                Dim Buffer() As Byte

                Buffer = New Byte(Convert.ToInt32(_xml.Length) - 1) {}
                Dim size As Integer = 0
                While size < Buffer.Length
                    size += _xml.Read(Buffer, size, Buffer.Length - size)
                End While
                If size <> Buffer.Length Then
                    Throw New Exception("Could not read all the data: " & Buffer.Length & "/" & size)
                End If
                xmlString = System.Text.Encoding.ASCII.GetString(Buffer)
                System.Diagnostics.Debug.WriteLine(xmlString)

                Return xmlString
            End Get
        End Property

        Public ReadOnly Property SchemaCollection() As XmlSchemaCollection
            Get
                Return _schemaCollection
            End Get
        End Property

        Public Sub LoadXML(ByVal XmlStream As Stream)
            _xml = XmlStream
        End Sub

        Public Sub LoadSchema(ByVal Schema As String)
            _schemaCollection.Add("", Schema)
        End Sub

        Public Function IsValid() As Boolean
            'There is a bug here which I haven't been able to fix.
            'If the XML Instance does not include a reference to the
            'schema, then the validation fails.  If the reference exists
            'the the validation works correctly.

            Dim txtReader As New XmlTextReader(_xml)
            'Create a validating reader
            Dim vreader As XmlValidatingReader
            '                        vreader = New XmlValidatingReader(_xml, XmlNodeType.Document,, Nothing)
            vreader = New XmlValidatingReader(txtReader)

            'Use the schemas stored in the schema collection.
            vreader.Schemas.Add(_schemaCollection)

            vreader.ValidationType = ValidationType.Schema

            'Set the validation event handler.
            AddHandler vreader.ValidationEventHandler, New ValidationEventHandler(AddressOf ValidationCallBack)

            'Read and validate the XML data.
            While vreader.Read()
            End While

            'Close the reader.
            vreader.Close()

            Return (_errs.Count = 0)
        End Function

        Protected Sub ValidationCallBack(ByVal sender As Object, ByVal args As ValidationEventArgs)
            _errs.Add(args.Message)
        End Sub

    End Class

End Namespace
