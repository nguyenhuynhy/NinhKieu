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


Namespace PortalQH.Installer

    Public Enum PaLogType
        Info
        Warning
        Failure
        StartJob
        EndJob
    End Enum 'PaLogType

    Public Class PaLogEntry
        Private m_Type As PaLogType
        Private m_Description As [String]
        Private m_Time As Double


        Public Sub New(ByVal type As PaLogType, ByVal description As [String], ByVal time As Double)
            m_Type = type
            m_Description = description
            m_Time = time
        End Sub 'New


        Public ReadOnly Property Type() As PaLogType
            Get
                Return m_Type
            End Get
        End Property


        Public ReadOnly Property Description() As [String]
            Get
                If m_Description Is Nothing Then
                    Return "..."
                Else
                    Return m_Description
                End If
            End Get
        End Property

        Public ReadOnly Property Time() As Double
            Get
                Return m_Time
            End Get
        End Property
    End Class 'PaLogEntry
End Namespace 'PrivateAssemblyInstallerGold