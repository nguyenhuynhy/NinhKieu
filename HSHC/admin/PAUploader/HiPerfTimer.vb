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
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Threading


Namespace PortalQH.Win32

    Friend Class HiPerfTimer
        Declare Auto Function QueryPerformanceCounter Lib "kernel32.dll" (ByRef lpPerformanceCount As Long) As Boolean

        Declare Auto Function QueryPerformanceFrequency Lib "kernel32.dll" (ByRef lpFrequency As Long) As Boolean

        Private _startTime As Long = 0
        Private _stopTime As Long = 0
        Private _now As Long
        Private _freq As Long


        ' Constructor
        Public Sub New()
            If QueryPerformanceFrequency(_freq) = False Then
                ' high-performance counter not supported 
                Throw New Win32Exception
            End If
        End Sub 'New


        ' Start the timer
        Public Sub Start()
            ' lets do the waiting threads there work
            Thread.Sleep(0)

            QueryPerformanceCounter(_startTime)
        End Sub 'Start


        ' Stop the timer
        Public Sub [Stop]()
            QueryPerformanceCounter(_stopTime)
        End Sub 'Stop


        Public ReadOnly Property Now() As Double
            Get
                QueryPerformanceCounter(Convert.ToInt64(Now))
                Return CDbl(Now - _startTime) / CDbl(_freq)
            End Get
        End Property

        ' Returns the duration of the timer (in seconds)

        Public ReadOnly Property Duration() As Double
            Get
                Return CDbl(_stopTime - _startTime) / CDbl(_freq)
            End Get
        End Property
    End Class 'HiPerfTimer
End Namespace 'Win32