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
Imports System.Configuration
Imports System.Data
Imports System.Globalization

Namespace PortalQH
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : FileInfo
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Represents the File object and holds the Properties of that object
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[DYNST]	2/1/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class FileInfo
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Primary Key ID of the current File, as represented within the Database table named "Files"
        ''' </summary>
        ''' <remarks>
        ''' This Integer Property is passed to the FileInfo Collection
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private _FileId As Integer
        Private _PortalId As Integer
        Private _FileName As String
        Private _Extension As String
        Private _Size As Integer
        Private _Width As Integer
        Private _Height As Integer
        Private _ContentType As String

        Public Sub New()
        End Sub

        Public Property FileId() As Integer
            Get
                Return _FileId
            End Get
            Set(ByVal Value As Integer)
                _FileId = Value
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
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal Value As String)
                _FileName = Value
            End Set
        End Property
        Public Property Extension() As String
            Get
                Return _Extension
            End Get
            Set(ByVal Value As String)
                _Extension = Value
            End Set
        End Property
        Public Property Size() As Integer
            Get
                Return _Size
            End Get
            Set(ByVal Value As Integer)
                _Size = Value
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return _Width
            End Get
            Set(ByVal Value As Integer)
                _Width = Value
            End Set
        End Property
        Public Property Height() As Integer
            Get
                Return _Height
            End Get
            Set(ByVal Value As Integer)
                _Height = Value
            End Set
        End Property
        Public Property ContentType() As String
            Get
                Return _ContentType
            End Get
            Set(ByVal Value As String)
                _ContentType = Value
            End Set
        End Property
    End Class
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : FileController
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Business Class that provides access to the Database for the functions within the calling classes
    ''' Instantiates the instance of the DataProvider and returns the object, if any
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[DYNST]	2/1/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class FileController


        Public Function GetFiles(Optional ByVal PortalId As Integer = -1) As IDataReader

            Return DataProvider.Instance().GetFiles(PortalId)


        End Function


        Public Function GetFile(ByVal FileName As String, Optional ByVal PortalId As Integer = -1) As IDataReader

            Return DataProvider.Instance().GetFile(FileName, PortalId)

        End Function


        Public Sub DeleteFile(ByVal FileName As String, Optional ByVal PortalId As Integer = -1)

            DataProvider.Instance().DeleteFile(FileName, PortalId)

        End Sub


        Public Sub DeleteFiles(Optional ByVal PortalId As Integer = -1)

            DataProvider.Instance().DeleteFiles(PortalId)

        End Sub


        Public Sub AddFile(ByVal PortalId As Integer, ByVal FileName As String, ByVal Extension As String, ByVal Size As String, ByVal Width As String, ByVal Height As String, ByVal ContentType As String)

            Dim dr As IDataReader = DataProvider.Instance().GetFile(FileName, PortalId)
            If dr.Read Then
                DataProvider.Instance().UpdateFile(Convert.ToInt32(dr("FileId")), FileName, Extension, Size, Width, Height, ContentType)
            Else
                DataProvider.Instance().AddFile(PortalId, FileName, Extension, Size, Width, Height, ContentType)
            End If
            dr.Close()

        End Sub

    End Class

End Namespace
