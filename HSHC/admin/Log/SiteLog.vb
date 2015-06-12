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
Imports System.Threading

Namespace PortalQH

    Public Class SiteLogInfo

        Private _DateTime As Date
        Private _PortalId As Integer
        Private _UserId As String
        Private _Referrer As String
        Private _URL As String
        Private _UserAgent As String
        Private _UserHostAddress As String
        Private _UserHostName As String
        Private _TabId As Integer
        Private _AffiliateId As Integer

        Public Sub New()
        End Sub

        Public Property DateTime() As Date
            Get
                Return _DateTime
            End Get
            Set(ByVal Value As Date)
                _DateTime = Value
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
        Public Property UserId() As String
            Get
                Return _UserId
            End Get
            Set(ByVal Value As String)
                _UserId = Value
            End Set
        End Property
        Public Property Referrer() As String
            Get
                Return _Referrer
            End Get
            Set(ByVal Value As String)
                _Referrer = Value
            End Set
        End Property
        Public Property URL() As String
            Get
                Return _URL
            End Get
            Set(ByVal Value As String)
                _URL = Value
            End Set
        End Property
        Public Property UserAgent() As String
            Get
                Return _UserAgent
            End Get
            Set(ByVal Value As String)
                _UserAgent = Value
            End Set
        End Property
        Public Property UserHostAddress() As String
            Get
                Return _UserHostAddress
            End Get
            Set(ByVal Value As String)
                _UserHostAddress = Value
            End Set
        End Property
        Public Property UserHostName() As String
            Get
                Return _UserHostName
            End Get
            Set(ByVal Value As String)
                _UserHostName = Value
            End Set
        End Property
        Public Property TabId() As Integer
            Get
                Return _TabId
            End Get
            Set(ByVal Value As Integer)
                _TabId = Value
            End Set
        End Property
        Public Property AffiliateId() As Integer
            Get
                Return _AffiliateId
            End Get
            Set(ByVal Value As Integer)
                _AffiliateId = Value
            End Set
        End Property
    End Class

    Public Class SiteLogController


        Public Sub AddSiteLog(ByVal PortalId As Integer, ByVal UserId As String, ByVal Referrer As String, ByVal URL As String, ByVal UserAgent As String, ByVal UserHostAddress As String, ByVal UserHostName As String, ByVal TabId As Integer, ByVal AffiliateId As Integer, ByVal SiteLogBuffer As Integer)

            Try
                '22/07/04 AnNT tam bo => chuong trinh chay nhanh hon

                'Select Case SiteLogBuffer
                '    Case 0 ' logging disabled
                '    Case 1 ' no buffering
                '        DataProvider.Instance().AddSiteLog(Now(), PortalId, UserId, Referrer, URL, UserAgent, UserHostAddress, UserHostName, TabId, AffiliateId)
                '    Case Else ' buffered logging
                '        Dim arrSiteLog As ArrayList

                '        Dim key As String = "SiteLog" & PortalId.ToString

                '        ' get buffered site log records from the cache
                '        If (DataCache.GetCache(key) Is Nothing) Then
                '            DataCache.SetCache(key, New ArrayList)
                '        End If
                '        arrSiteLog = CType(DataCache.GetCache(key), ArrayList)

                '        ' create new sitelog object
                '        Dim objSiteLog As New SiteLogInfo
                '        objSiteLog.DateTime = Now()
                '        objSiteLog.PortalId = PortalId
                '        objSiteLog.UserId = UserId
                '        objSiteLog.Referrer = Referrer
                '        objSiteLog.URL = URL
                '        objSiteLog.UserAgent = UserAgent
                '        objSiteLog.UserHostAddress = UserHostAddress
                '        objSiteLog.UserHostName = UserHostName
                '        objSiteLog.TabId = TabId
                '        objSiteLog.AffiliateId = AffiliateId

                '        ' add sitelog object to cache
                '        arrSiteLog.Add(objSiteLog)

                '        If arrSiteLog.Count >= SiteLogBuffer Then
                '            ' create the buffered sitelog object
                '            Dim objBufferedSiteLog As New BufferedSiteLog
                '            objBufferedSiteLog.SiteLog = arrSiteLog

                '            ' clear the current sitelogs from the cache
                '            DataCache.RemoveCache(key)

                '            ' process buffered sitelogs on a background thread
                '            Dim objThread As New Thread(AddressOf objBufferedSiteLog.AddSiteLog)
                '            objThread.Start()
                '        End If

                ' End Select

            Catch ex As Exception

            End Try

        End Sub

        Public Function GetSiteLog(ByVal PortalId As Integer, ByVal PortalAlias As String, ByVal ReportType As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As IDataReader

            Return DataProvider.Instance().GetSiteLog(PortalId, PortalAlias, "GetSiteLog" & ReportType.ToString, StartDate, EndDate)

        End Function

        Public Sub DeleteSiteLog(ByVal DateTime As Date, ByVal PortalId As Integer)

            DataProvider.Instance().DeleteSiteLog(DateTime, PortalId)

        End Sub

    End Class

    Public Class BufferedSiteLog

        Public SiteLog As ArrayList

        Public Sub AddSiteLog()

            Try

                Dim objSiteLog As SiteLogInfo

                ' iterate through buffered sitelog items and insert into database
                '22/07/04 AnNT tam bo => chuong trinh chay nhanh hon
                'Dim intIndex As Integer
                'For intIndex = 0 To SiteLog.Count - 1
                '    objSiteLog = CType(SiteLog(intIndex), SiteLogInfo)
                '    DataProvider.Instance().AddSiteLog(objSiteLog.DateTime, objSiteLog.PortalId, objSiteLog.UserId, objSiteLog.Referrer, objSiteLog.URL, objSiteLog.UserAgent, objSiteLog.UserHostAddress, objSiteLog.UserHostName, objSiteLog.TabId, objSiteLog.AffiliateId)
                'Next

            Catch ex As Exception

            End Try

        End Sub

    End Class

End Namespace
