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
Imports System.Collections


Namespace PortalQH.Installer

    Public Class PaLogger
        Private m_Logs As ArrayList
        Private m_Valid As Boolean
        Private m_Timer As PortalQH.Win32.HiPerfTimer


        Public Sub New()
            m_Logs = New ArrayList
            m_Valid = True
            m_Timer = New PortalQH.Win32.HiPerfTimer
            m_Timer.Start()
        End Sub 'New


        Public Sub AddInfo(ByVal info As String)
            m_Logs.Add(New PaLogEntry(PaLogType.Info, info, m_Timer.Now))
        End Sub 'AddInfo


        Public Sub AddWarning(ByVal warning As String)
            m_Logs.Add(New PaLogEntry(PaLogType.Warning, warning, m_Timer.Now))
        End Sub 'AddWarning


        Public Sub AddFailure(ByVal failure As String)
            m_Logs.Add(New PaLogEntry(PaLogType.Failure, failure, m_Timer.Now))
            m_Valid = False
        End Sub 'AddFailure


        Public Sub Add(ByVal ex As Exception)
            AddFailure(("Exception: " + ex.ToString()))
        End Sub 'Add


        Public Sub StartJob(ByVal job As String)
            m_Logs.Add(New PaLogEntry(PaLogType.StartJob, job, m_Timer.Now))
        End Sub 'StartJob


        Public Sub EndJob(ByVal job As String)
            m_Logs.Add(New PaLogEntry(PaLogType.EndJob, job, m_Timer.Now))
        End Sub 'EndJob


        Public ReadOnly Property Logs() As ArrayList
            Get
                Return m_Logs
            End Get
        End Property


        Public ReadOnly Property Valid() As Boolean
            Get
                Return m_Valid
            End Get
        End Property
    End Class 'PaLogger
End Namespace
