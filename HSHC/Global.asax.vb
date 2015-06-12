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
Imports System.Security
Imports System.Security.Principal
Imports System.Threading
Imports System.Web.Security
Imports System.IO
Imports System.Configuration
Imports Microsoft.ApplicationBlocks.ExceptionManagement


Namespace PortalQH
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : Global
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[sun1]	1/18/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class Global
        Inherits System.Web.HttpApplication

        ' global constants for the life of the application ( set in Application_Start )
        Public Shared ApplicationPath As String
        Public Shared HostPath As String
        Public Shared AssemblyPath As String

        Public Shared OneMinuteTimer As Timer
        Public Shared OneDayTimer As Timer

        'Danh muc



        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Application_BeginRequest Event
        '''
        ''' The Application_BeginRequest method is an ASP.NET event that executes 
        ''' on each web request into the portal application.  The below method
        ''' obtains the current TabId from the querystring of the 
        ''' request -- and then obtains the configuration necessary to process
        ''' and render the request.
        '''
        ''' This portal configuration is stored within the application's "Context"
        ''' object -- which is available to all pages, controls and components
        ''' during the processing of a single request.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' - get TabId from querystring
        ''' - parse the Request URL into a Domain Name token 
        ''' - alias parameter can be used to switch portals
        ''' - TabId uniquely identifies a Portal
        ''' - else use the domainname
        ''' - if portalalias is nothing then load the default tab
        ''' - validate the alias
        ''' - if Portal Alias Exists then load the PortalSettings into current context
        ''' - Else portal Alias does not exist in database
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/18/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

            Dim TabId As Integer = 0
            Dim PortalId As Integer = -1
            Dim DomainName As String = Nothing
            Dim PortalAlias As String = Nothing

            ' URL validation 
            ' removes ".." escape characters commonly used by hackers to traverse the folder tree on the server
            ' the application should always use the exact relative location of the resource it is requesting
            Dim strURL As String = Server.UrlDecode(Request.RawUrl)
            If strURL.IndexOf("..") <> -1 Then
                HttpContext.Current.RewritePath(strURL.Replace("..", ""))
            End If

            ' get TabId from querystring
            If Not (Request.QueryString("tabid") Is Nothing) Then
                TabId = Int32.Parse(Request.QueryString("tabid"))
            End If
            '
            ' parse the Request URL into a Domain Name token 
            DomainName = GetDomainName(Request)
            ' get PortalId from querystring ( this is used for host menu options as well as child portal navigation )
            If Not (Request.QueryString("portalid") Is Nothing) Then
                PortalId = Int32.Parse(Request.QueryString("portalid"))
            End If

            ' parse the Request URL into a Domain Name token 
            DomainName = GetDomainName(Request)

            ' alias parameter can be used to switch portals
            If Not (Request.QueryString("alias") Is Nothing) Then
                If PortalSettings.GetPortalByAlias(Request.QueryString("alias")) <> -1 Then
                    If InStr(1, Request.QueryString("alias"), DomainName, CompareMethod.Text) = 0 Then
                        Response.Redirect(GetPortalDomainName(Request.QueryString("alias"), Request), True)
                    Else
                        PortalAlias = Request.QueryString("alias")
                    End If
                End If
            End If

            ' TabId uniquely identifies a Portal
            If PortalAlias Is Nothing Then
                If TabId <> 0 Then
                    PortalAlias = PortalSettings.GetPortalByTab(TabId, DomainName)
                End If
            End If

            ' else use the domainname
            If PortalAlias Is Nothing Then
                PortalAlias = DomainName
                TabId = CType(ConfigurationSettings.AppSettings("TabDefault"), Integer) 'if portalalias is nothing then load the default tab 
            End If

            ' validate the alias
            If PortalId = -1 Then
                PortalId = PortalSettings.GetPortalByAlias(PortalAlias)
            End If

            gPortalID() = CType(PortalId, String)
            gRequest = Request
            If KiemTraBanQuyen() = False Then
                Dim objStreamReader As StreamReader
                objStreamReader = File.OpenText(Server.MapPath("~/404.htm"))
                Dim strHTML As String = objStreamReader.ReadToEnd
                objStreamReader.Close()
                strHTML = Replace(strHTML, "[DOMAINNAME]", DomainName)
                Response.Write(strHTML)
                Response.End()
            End If
            If PortalId <> -1 Then
                ' load the PortalSettings into current context
                Context.Items.Add("PortalSettings", New PortalSettings(TabId, PortalId))
            Else
                ' alias does not exist in database
                Dim objStreamReader As StreamReader
                objStreamReader = File.OpenText(Server.MapPath("~/404.htm"))
                Dim strHTML As String = objStreamReader.ReadToEnd
                objStreamReader.Close()
                strHTML = Replace(strHTML, "[DOMAINNAME]", DomainName)
                Response.Write(strHTML)
                Response.End()
            End If

        End Sub


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Application_AuthenticateRequest  Event
        '''
        ''' If the client is authenticated with the application, then determine
        ''' which security roles he/she belongs to and replace the "User" intrinsic
        ''' with a custom IPrincipal security object that permits "User.IsInRole"
        ''' role checks within the application
        '''
        ''' Roles are cached in the browser in an in-memory encrypted cookie.  If the
        ''' cookie doesn't exist yet for this session, create it.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' - Obtain PortalSettings from Current Context
        ''' ' check if user has switched portals
        ''' '   expire cookies if portal has changed
        ''' '   check if user is valid for new portal
        ''' '       log user out
        ''' '       Redirect browser back to home page
        ''' 
        ''' ' get UserId based on authentication method ( from web.config )
        ''' '   authenticate user and set last login ( this is necessary for users who have a permanent Auth cookie set ) 
        ''' '       Log User Off from Cookie Authentication System
        ''' '       expire cookies
        '''     Else ' valid Auth cookie
        ''' '       create cookies if they do not exist yet for this session.
        ''' '           keep cookies in sync
        '''             create a cookie authentication ticket ( version, user name, issue time, expires every hour, don't persist cookie, roles )
        '''             encrypt the ticket
        '''             send roles cookie to client
        '''             get roles from UserRoles table
        '''             create a string to persist the roles
        '''         ELSE get roles from roles cookie
        '''             convert the string representation of the role data into a string array
        ''' add our own custom principal to the request containing the roles in the auth ticket
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/18/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim CookieName As String = ""
            CookieName = GetCookieName(Request)

            If Request.IsAuthenticated = True Then
                If Not Request.Cookies(CookieName & "portalid") Is Nothing Then
                    Dim PortalCookie As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies(CookieName & "portalid").Value)

                    ' check if user has switched portals
                    If _portalSettings.PortalId <> Int32.Parse(PortalCookie.UserData) Then

                        ' expire cookies if portal has changed

                        Response.Cookies(CookieName & "portalid").Value = Nothing
                        Response.Cookies(CookieName & "portalid").Path = "/"
                        Response.Cookies(CookieName & "portalid").Expires = DateTime.Now.AddYears(-30)

                        Response.Cookies(CookieName & "portalroles").Value = Nothing
                        Response.Cookies(CookieName & "portalroles").Path = "/"
                        Response.Cookies(CookieName & "portalroles").Expires = DateTime.Now.AddYears(-30)

                        Dim arrPortalRoles() As String
                        Dim objRole As New RoleController
                        Dim objUsers As New UserController
                        Dim objUser As UserInfo = objUsers.GetUser(_portalSettings.PortalId, Context.User.Identity.Name)
                        If objUser Is Nothing Then
                            ' log user out
                            FormsAuthentication.SignOut()
                            ' Redirect browser back to home page
                            Response.Redirect(Request.RawUrl, True)
                            Exit Sub
                        End If

                    End If
                End If
            End If

            If Request.IsAuthenticated = True Then
                Dim arrPortalRoles() As String
                Dim objRole As New RoleController
                Dim objUser As New UserController

                ' get UserId 
                Dim intUserId As String = ""
                If Context.User.Identity.Name <> "" Then
                    ' forms authentication
                    intUserId = Context.User.Identity.Name
                Else ' windows authentication
                    Dim objUsers As UserInfo = objUser.GetUserByUsername(_portalSettings.PortalId, Context.User.Identity.Name)
                    If Not objUsers Is Nothing Then
                        intUserId = objUsers.UserID
                    End If
                End If

                ' authenticate user and set last login ( this is necessary for users who have a permanent Auth cookie set ) 
                If Not objUser.UpdateUserLogin(intUserId, _portalSettings.PortalId, _portalSettings.SuperUserId) Then

                    ' Log User Off from Cookie Authentication System
                    FormsAuthentication.SignOut()

                    ' expire cookies
                    Response.Cookies(CookieName & "portalid").Value = Nothing
                    Response.Cookies(CookieName & "portalid").Path = "/"
                    Response.Cookies(CookieName & "portalid").Expires = DateTime.Now.AddYears(-30)

                    Response.Cookies(CookieName & "portalroles").Value = Nothing
                    Response.Cookies(CookieName & "portalroles").Path = "/"


                Else ' valid Auth cookie

                    ' create cookies if they do not exist yet for this session.
                    If Request.Cookies(CookieName & "portalroles") Is Nothing Then

                        ' keep cookies in sync
                        Dim CurrentDateTime As Date = DateTime.Now

                        ' create a cookie authentication ticket ( version, user name, issue time, expires every hour, don't persist cookie, roles )
                        Dim PortalTicket As New FormsAuthenticationTicket(1, intUserId.ToString, CurrentDateTime, CurrentDateTime.AddHours(1), False, _portalSettings.PortalId.ToString)
                        ' encrypt the ticket
                        Dim strPortal As String = FormsAuthentication.Encrypt(PortalTicket)
                        ' send portal cookie to client
                        Response.Cookies(CookieName & "portalid").Value = strPortal
                        Response.Cookies(CookieName & "portalid").Path = "/"
                        Response.Cookies(CookieName & "portalid").Expires = CurrentDateTime.AddMinutes(1)
                        ' get roles from UserRoles table
                        arrPortalRoles = objRole.GetRolesByUser(intUserId, _portalSettings.PortalId)
                        ' create a string to persist the roles
                        Dim strPortalRoles As String = Join(arrPortalRoles, New Char() {";"c})

                        ' create a cookie authentication ticket ( version, user name, issue time, expires every hour, don't persist cookie, roles )
                        Dim RolesTicket As New FormsAuthenticationTicket(1, intUserId.ToString, CurrentDateTime, CurrentDateTime.AddHours(1), False, strPortalRoles)
                        ' encrypt the ticket
                        Dim strRoles As String = FormsAuthentication.Encrypt(RolesTicket)
                        ' send roles cookie to client
                        Response.Cookies(CookieName & "portalroles").Value = strRoles
                        Response.Cookies(CookieName & "portalroles").Path = "/"
                        Response.Cookies(CookieName & "portalroles").Expires = CurrentDateTime.AddMinutes(1)

                    Else
                        If Request.Cookies(CookieName & "portalroles").Value <> "" Then

                            ' get roles from roles cookie
                            Dim RoleTicket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies(CookieName & "portalroles").Value)
                            ' get roles from roles cookie
                            ' convert the string representation of the role data into a string array
                            arrPortalRoles = Split(RoleTicket.UserData, New Char() {";"c})
                        End If

                    End If

                    ' add our own custom principal to the request containing the roles in the auth ticket
                    Dim objGenericIdentity As Principal.GenericIdentity = New Principal.GenericIdentity(intUserId.ToString)
                    Context.User = New GenericPrincipal(objGenericIdentity, arrPortalRoles)

                    ' personalization
                    Dim objPersonalization As New PersonalizationController
                    objPersonalization.LoadProfile(Context, intUserId, _portalSettings.PortalId)

                End If
            End If

        End Sub

        Private Sub Application_AuthorizeRequest(ByVal sender As Object, ByVal e As System.EventArgs)

            ' Create a Users Online Controller
            '
            Dim objUserOnlineController As New UserOnlineController

            ' Is Users Online Enabled?
            '
            If (objUserOnlineController.IsEnabled()) Then

                ' Track the current user
                '
                objUserOnlineController.TrackUsers()

            End If

        End Sub

        Private Sub Application_EndRequest(ByVal sender As Object, ByVal e As System.EventArgs)

            If Request.IsAuthenticated = True Then
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' get UserId 
                Dim intUserId As String = ""
                If Context.User.Identity.Name <> "" Then
                    ' forms authentication
                    intUserId = Context.User.Identity.Name
                Else ' windows authentication
                    Dim objUser As New UserController
                    Dim objUsers As UserInfo = objUser.GetUserByUsername(_portalSettings.PortalId, Context.User.Identity.Name)
                    If Not objUsers Is Nothing Then
                        intUserId = objUsers.UserID
                    End If
                End If

                ' personalization
                Dim objPersonalization As New PersonalizationController
                objPersonalization.SaveProfile(Context, intUserId, _portalSettings.PortalId)

            End If

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Application_Start
        '''
        ''' Executes on the first web request into the portal application, 
        ''' when a new DLL is deployed, or when web.config is modified.
        ''' This procedure performs all version upgrade operations ( including database )
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="E"></param>
        ''' <remarks>
        ''' - global variable initialization
        ''' - Get the name of the data provider
        ''' - get the executing assembly location and cache it
        ''' - perform automatic upgrade
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/18/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub Application_Start(ByVal Sender As Object, ByVal E As EventArgs)

            ' global variable initialization
            If HttpContext.Current.Request.ApplicationPath = "/" Then
                ApplicationPath = ""
            Else
                ApplicationPath = HttpContext.Current.Request.ApplicationPath
            End If

            HostPath = ApplicationPath & "/Portals/_default/"

            AssemblyPath = System.Reflection.Assembly.GetExecutingAssembly.Location

            ' Get the name of the data provider
            Dim objProviderConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration("data")

            ' perform automatic upgrade
            'Upgrade.AutoUpgrade()

            ' Schedule Timer
            If (OneMinuteTimer Is Nothing) Then
                OneMinuteTimer = New Timer(New TimerCallback(AddressOf ScheduledWorkCallbackOneMinute), Me.Context, 60000, 60000)
            End If
            If (OneDayTimer Is Nothing) Then
                OneDayTimer = New Timer(New TimerCallback(AddressOf ScheduledWorkCallbackOneDay), Me.Context, 0, 86400000)
            End If

        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Report errors in the Application utilizing the ExceptionManagement ApplicationBlock from Microsoft
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/18/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim lex As New BaseApplicationException("Unhandled Error: ", Server.GetLastError)
            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
        End Sub

        Private Sub ScheduledWorkCallbackOneMinute(ByVal sender As Object)

            ' Create Users Online Controller
            '
            Dim objUserOnlineController As UserOnlineController = New UserOnlineController

            ' Is Users Online Enabled?
            '
            If (objUserOnlineController.IsEnabled()) Then

                ' Update the Users Online records from Cache
                '
                objUserOnlineController.UpdateUsersOnline()

            End If

        End Sub

        Private Sub ScheduledWorkCallbackOneDay(ByVal sender As Object)

            Dim objSiteLog As New SiteLogController

            Dim objPortals As New PortalController
            Dim arrPortals As ArrayList = objPortals.GetPortals
            Dim objPortal As PortalInfo
            Dim PurgeDate As Date

            Dim intIndex As Integer
            For intIndex = 0 To arrPortals.Count - 1
                objPortal = CType(arrPortals(intIndex), PortalInfo)
                If objPortal.SiteLogHistory > 0 Then
                    PurgeDate = DateAdd(DateInterval.Day, -(objPortal.SiteLogHistory), Now())
                    objSiteLog.DeleteSiteLog(PurgeDate, objPortal.PortalID)
                End If
            Next

        End Sub
        Private Function KiemTraBanQuyen() As Boolean
            Dim objFile As FileStream
            Dim obj As New StringCrypto.License
            Dim objReader As StreamReader
            Dim fs As New Scripting.FileSystemObject
            Dim serialHardisk As Integer
            Dim d As Scripting.Drive
            Dim str As String
            Return obj.CompareFrom(GetAbsoluteServerPath(gRequest))
    
        End Function

    End Class

End Namespace
