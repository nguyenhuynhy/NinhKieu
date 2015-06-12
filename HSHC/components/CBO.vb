'
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
Imports System.Web.Caching
Imports System.Reflection
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports System.IO

Namespace PortalQH

    '*********************************************************************
    '
    ' CBO Class
    '
    ' Class that hydrates custom business objects with data
    '
    '*********************************************************************

    Public Class CBO

        Private Shared Function GetPropertyInfo(ByVal objType As Type) As ArrayList

            ' Use the cache because the reflection used later is expensive
            Dim objProperties As ArrayList = CType(DataCache.GetCache(objType.FullName), ArrayList)

            If objProperties Is Nothing Then
                objProperties = New ArrayList
                Dim objProperty As PropertyInfo
                For Each objProperty In objType.GetProperties()
                    objProperties.Add(objProperty)
                Next
                DataCache.SetCache(objType.FullName, objProperties)
            End If

            Return objProperties

        End Function

        Private Shared Function GetOrdinals(ByVal objProperties As ArrayList, ByVal dr As IDataReader) As Integer()

            Dim arrOrdinals(objProperties.Count) As Integer
            Dim intProperty As Integer

            If Not dr Is Nothing Then
                For intProperty = 0 To objProperties.Count - 1
                    arrOrdinals(intProperty) = -1
                    Try
                        arrOrdinals(intProperty) = dr.GetOrdinal(CType(objProperties(intProperty), PropertyInfo).Name)
                    Catch
                        ' property does not exist in datareader
                    End Try
                Next intProperty
            End If

            Return arrOrdinals

        End Function

        Private Shared Function CreateObject(ByVal objType As Type, ByVal dr As IDataReader, ByVal objProperties As ArrayList, ByVal arrOrdinals As Integer()) As Object

            Dim objObject As Object = Activator.CreateInstance(objType)
            Dim intProperty As Integer

            ' fill object with values from datareader
            For intProperty = 0 To objProperties.Count - 1
                If CType(objProperties(intProperty), PropertyInfo).CanWrite Then
                    If arrOrdinals(intProperty) <> -1 Then
                        If IsDBNull(dr.GetValue(arrOrdinals(intProperty))) Then
                            ' translate Null value
                            CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, Null.SetNull(CType(objProperties(intProperty), PropertyInfo)), Nothing)
                        Else
                            Try
                                ' try implicit conversion first
                                CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, dr.GetValue(arrOrdinals(intProperty)), Nothing)
                            Catch ' data types do not match
                                Try
                                    Dim pType As Type = CType(objProperties(intProperty), PropertyInfo).PropertyType
                                    'need to handle enumeration conversions differently than other base types
                                    If pType.BaseType.Equals(GetType(System.Enum)) Then
                                        CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, System.Enum.ToObject(pType, dr.GetValue(arrOrdinals(intProperty))), Nothing)
                                    Else
                                        ' try explicit conversion
                                        CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals(intProperty)), pType), Nothing)
                                    End If
                                Catch
                                    ' error assigning a datareader value to a property
                                End Try
                            End Try
                        End If
                    Else ' property does not exist in datareader
                        CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, Null.SetNull(CType(objProperties(intProperty), PropertyInfo)), Nothing)
                    End If
                End If
            Next intProperty

            Return objObject

        End Function

        Public Shared Function FillObject(ByVal dr As IDataReader, ByVal objType As Type) As Object

            Dim objFillObject As Object
            Dim intProperty As Integer

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)

            ' get ordinal positions in datareader
            Dim arrOrdinals As Integer() = GetOrdinals(objProperties, dr)

            ' read datareader
            If dr.Read Then
                ' fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals)
            Else
                objFillObject = Nothing
            End If

            ' close datareader
            If Not dr Is Nothing Then
                dr.Close()
            End If

            Return objFillObject

        End Function

        Public Shared Function FillCollection(ByVal dr As IDataReader, ByVal objType As Type) As ArrayList

            Dim objFillCollection As New ArrayList
            Dim objFillObject As Object
            Dim intProperty As Integer


            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)


            ' get ordinal positions in datareader
            Dim arrOrdinals As Integer() = GetOrdinals(objProperties, dr)

            ' iterate datareader

            While dr.Read
                ' fill business object
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals)
                ' add to collection
                objFillCollection.Add(objFillObject)
            End While

            ' close datareader
            If Not dr Is Nothing Then
                dr.Close()
            End If

            Return objFillCollection

        End Function

        Public Shared Function InitializeObject(ByVal objObject As Object, ByVal objType As Type) As Object

            Dim intProperty As Integer

            ' get properties for type
            Dim objProperties As ArrayList = GetPropertyInfo(objType)

            ' initialize properties
            For intProperty = 0 To objProperties.Count - 1
                If CType(objProperties(intProperty), PropertyInfo).CanWrite Then
                    CType(objProperties(intProperty), PropertyInfo).SetValue(objObject, Null.SetNull(CType(objProperties(intProperty), PropertyInfo)), Nothing)
                End If
            Next intProperty

            Return objObject

        End Function

        Public Shared Function Serialize(ByVal objObject As Object) As XmlDocument

            Dim objXmlSerializer As New XmlSerializer(objObject.GetType())

            Dim objStringBuilder As New StringBuilder

            Dim objTextWriter As TextWriter = New StringWriter(objStringBuilder)

            objXmlSerializer.Serialize(objTextWriter, objObject)

            Dim objStringReader As New StringReader(objTextWriter.ToString())

            Dim objDataSet As New DataSet

            objDataSet.ReadXml(objStringReader)

            Dim xmlSerializedObject As New XmlDocument

            xmlSerializedObject.LoadXml(objDataSet.GetXml())

            Return xmlSerializedObject

        End Function

    End Class

End Namespace