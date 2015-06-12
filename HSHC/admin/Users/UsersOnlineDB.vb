'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Scott McCulloch ( smcculloch@iinet.net.au ) ( http://www.smcculloch.net )
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
Imports System.Configuration
Imports System.Data

Namespace PortalQH

    Public Class BaseUserInfo

        Private _PortalID As Integer
        Private _TabID As Integer
        Private _CreationDate As DateTime
        Private _LastActiveDate As DateTime

        Public Property PortalID() As Integer
            Get
                Return _PortalID
            End Get
            Set(ByVal Value As Integer)
                _PortalID = Value
            End Set
        End Property

        Public Property TabID() As Integer
            Get
                Return _TabID
            End Get
            Set(ByVal Value As Integer)
                _TabID = Value
            End Set
        End Property

        Public Property CreationDate() As DateTime
            Get
                Return _CreationDate
            End Get
            Set(ByVal Value As DateTime)
                _CreationDate = Value
            End Set
        End Property

        Public Property LastActiveDate() As DateTime
            Get
                Return _LastActiveDate
            End Get
            Set(ByVal Value As DateTime)
                _LastActiveDate = Value
            End Set
        End Property

    End Class

    Public Class OnlineUserInfo
        Inherits BaseUserInfo

        Private _UserID As String

        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

    End Class

    Public Class AnonymousUserInfo
        Inherits BaseUserInfo

        Private _UserID As String

        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

    End Class

    Public Class UserOnlineController

        Public Function IsEnabled() As Boolean

            Dim HostSettings As New Hashtable

            HostSettings = CType(DataCache.GetCache("GetHostSettings"), Hashtable)
            If HostSettings Is Nothing Then
                HostSettings = PortalSettings.GetHostSettings()
                DataCache.SetCache("GetHostSettings", HostSettings)
            End If

            If (HostSettings.Contains("DisableUsersOnline")) Then
                If HostSettings("DisableUsersOnline").ToString = "N" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End Function

        Public Function GetOnlineTimeWindow() As Integer

            Dim HostSettings As New Hashtable

            HostSettings = CType(DataCache.GetCache("GetHostSettings"), Hashtable)
            If HostSettings Is Nothing Then
                HostSettings = PortalSettings.GetHostSettings()
                DataCache.SetCache("GetHostSettings", HostSettings)
            End If

            If (HostSettings.Contains("UsersOnlineTime")) Then

                ' Try casting the setting
                '
                Try
                    Return Convert.ToInt32(HostSettings("UsersOnlineTime").ToString)
                Catch ex As Exception
                    Throw
                End Try

            Else
                ' Return a default of 15
                '
                Return 15

            End If

        End Function

        Public Sub TrackUsers()

            Dim context As HttpContext = HttpContext.Current

            ' Have we already done the work for this request?
            '
            If Not (context.Items("CheckedUsersOnlineCookie") Is Nothing) Then
                Return
            Else
                context.Items("CheckedUsersOnlineCookie") = "true"
            End If

            If (context.Request.IsAuthenticated) Then

                TrackAuthenticatedUser(context)

            Else

                TrackAnonymousUser(context)

            End If

        End Sub

        Private Sub TrackAuthenticatedUser(ByVal context As HttpContext)

            ' Retrieve Portal Settings
            '
            Dim portalSettings As portalSettings = CType(context.Items("PortalSettings"), portalSettings)

            ' Get the logged in User ID
            '
            Dim userID As String = context.User.Identity.Name

            ' Get user list
            '
            Dim userList As Hashtable = GetUserList()

            ' Is the user already in the list?
            '
            If (userList(userID) Is Nothing) Then
                userList(userID) = New OnlineUserInfo
                CType(userList(userID), OnlineUserInfo).CreationDate = DateTime.Now
            End If

            Dim user As OnlineUserInfo = CType(userList(userID), OnlineUserInfo)

            user.UserID = CType(context.User.Identity.Name, String)
            user.PortalID = portalSettings.PortalId
            user.TabID = portalSettings.ActiveTab.TabId
            user.LastActiveDate = DateTime.Now

        End Sub

        Private Sub TrackAnonymousUser(ByVal context As HttpContext)

            Dim cookieName As String = "PortalQHAnonymous"

            Dim portalSettings As portalSettings = CType(context.Items("PortalSettings"), portalSettings)

            Dim user As AnonymousUserInfo
            Dim userList As Hashtable = GetUserList()
            Dim userID As String

            ' Check if the Tracking cookie exists
            '
            Dim cookie As HttpCookie = context.Request.Cookies(cookieName)

            ' Track Anonymous User
            ' 
            If (cookie Is Nothing) Then

                ' Create a temporary userId
                '
                userID = Guid.NewGuid().ToString()

                ' Create a new cookie
                '
                cookie = New HttpCookie(cookieName)
                cookie.Value = userID
                cookie.Expires = DateTime.Now.AddMinutes(20)
                context.Response.Cookies.Add(cookie)

                ' Create a user
                ' 
                user = New AnonymousUserInfo

                user.UserID = userID
                user.PortalID = portalSettings.PortalId
                user.TabID = portalSettings.ActiveTab.TabId
                user.CreationDate = DateTime.Now
                user.LastActiveDate = DateTime.Now

                ' Add the user
                '
                If Not (userList.Contains(userID)) Then
                    userList(userID) = user
                End If

            Else

                If (cookie.Value Is Nothing) Then

                    ' Expire the cookie, there is something wrong with it
                    '
                    context.Response.Cookies(cookieName).Expires = New System.DateTime(1999, 10, 12)

                    ' No need to do anything else
                    '
                    Return

                End If

                ' Get userID out of cookie
                '
                userID = cookie.Value

                ' Find the cookie in the user list
                '
                If (userList(userID) Is Nothing) Then
                    userList(userID) = New AnonymousUserInfo
                    CType(userList(userID), AnonymousUserInfo).CreationDate = DateTime.Now
                End If

                user = CType(userList(userID), AnonymousUserInfo)

                user.UserID = userID
                user.PortalID = portalSettings.PortalId
                user.TabID = portalSettings.ActiveTab.TabId
                user.LastActiveDate = DateTime.Now

                ' Reset the expiration on the cookie
                '
                cookie = New HttpCookie(cookieName)
                cookie.Value = userID
                cookie.Expires = DateTime.Now.AddMinutes(20)
                context.Response.Cookies.Add(cookie)

            End If

        End Sub

        Public Function GetUserList() As Hashtable

            Dim key As String = "OnlineUserList"
            Dim userList As Hashtable

            ' Do we have the Hashtable?
            '
            If (DataCache.GetCache(key) Is Nothing) Then

                DataCache.SetCache(key, New Hashtable)

                ' Get the Hashtable
                '
                userList = CType(DataCache.GetCache(key), Hashtable)
            End If

            Return CType(DataCache.GetCache(key), Hashtable)

        End Function

        Public Sub UpdateUsersOnline()

            ' Get a Current User List
            '
            Dim userList As Hashtable = GetUserList()

            ' Obtain an instance of the Data Provider
            '
            Dim provider As PortalQH.DataProvider = DataProvider.Instance()

            ' Persist the current User List
            '
            provider.UpdateUsersOnline(userList)

            ' Remove users that have expired
            '
            provider.DeleteUsersOnline(GetOnlineTimeWindow())

            ' Empty the user list, we've already processed the users
            '
            userList.Clear()

        End Sub

    End Class

End Namespace