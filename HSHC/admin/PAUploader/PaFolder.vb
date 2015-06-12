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

Namespace PortalQH.Installer
    Public Class PaFolder
        Private _Name As String
        Private _Description As String
        Private _Version As String
        Private _ResourceFile As String
        Private _Modules As ArrayList
        Private _Controls As ArrayList
        Private _Files As ArrayList
        Private _type As String

        Public Sub New()
            _Description = Null.NullString
            _Version = Null.NullString
            _Modules = New ArrayList
            _Files = New ArrayList
            _Controls = New ArrayList
        End Sub

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal Value As String)
                _Name = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property Version() As String
            Get
                Return _Version
            End Get
            Set(ByVal Value As String)
                _Version = Value
            End Set
        End Property

        Public Property ResourceFile() As String
            Get
                Return _ResourceFile
            End Get
            Set(ByVal Value As String)
                _ResourceFile = Value
            End Set
        End Property

        Public ReadOnly Property Modules() As ArrayList
            Get
                Return _Modules
            End Get
        End Property

        Public ReadOnly Property Controls() As ArrayList
            Get
                Return _Controls
            End Get
        End Property

        Public ReadOnly Property Files() As ArrayList
            Get
                Return _Files
            End Get
        End Property

        Public Property ProviderType() As String
            Get
                Return _type
            End Get
            Set(ByVal Value As String)
                _type = Value
            End Set
        End Property

    End Class
End Namespace