Imports System
Imports System.Configuration
Imports System.Text
Imports System.Web

Namespace PortalQH
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : HTTPHandler
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[sun1]	1/19/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class HTTPHandler
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Implements IHttpModule
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="app"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub Init(ByVal app As HttpApplication) Implements IHttpModule.Init
            AddHandler app.BeginRequest, AddressOf Me.OnBeginRequest
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub Dispose() Implements IHttpModule.Dispose
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Delegate Sub MyEventHandler(ByVal s As Object, ByVal e As EventArgs)
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Event MyEvent As MyEventHandler
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Enables portal jumping within the application, from alias to alias 
        ''' without requiring re authentication
        ''' </summary>
        ''' <param name="s"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' 'if we are not in the default.aspx
        ''' 'get the domain name using the global function GetDomainName
        ''' 'get the Portal Alias and match it to the Domain.  If it is a match then continue
        ''' ' request may include a tabname in the path
        ''' 'retrieve the Portal Alias by removing the Domain name and trailing slash from the querystring
        ''' ' if the Portal Alias exists that you would like to jump to, then get the leading parameter from the querystring
        ''' 'if the querystring parameter TabID is numeric then switch to the tab
        ''' otherwise use the tabname
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub OnBeginRequest(ByVal s As Object, ByVal e As EventArgs)

            Dim objHttpApplication As HttpApplication = CType(s, HttpApplication)
            'if we are not in the default.aspx
            If InStr(1, objHttpApplication.Request.Url.ToString.ToLower, "/default.aspx") <> 0 Then
                'get the domain name using the global function GetDomainName
                Dim DomainName As String = GetDomainName(objHttpApplication.Request)
                'get the Portal Alias and match it to the Domain.  If it is a match then continue
                If PortalSettings.GetPortalByAlias(DomainName) = -1 Then

                    ' request may include a tabname in the path
                    If InStr(1, DomainName, "/") <> 0 Then
                        'retrieve the Portal Alias by removing the Domain name and trailing slash from the querystring
                        Dim PortalAlias As String = Left(DomainName, InStrRev(DomainName, "/") - 1)
                        ' if the Portal Alias exists that you would like to jump to, then get the leading parameter from the querystring
                        If PortalSettings.GetPortalByAlias(PortalAlias) <> -1 Then
                            Dim Tab As String = Mid(DomainName, InStrRev(DomainName, "/") + 1)
                            'if the querystring parameter TabID is numeric then switch to the tab
                            If IsNumeric(Tab) Then
                                objHttpApplication.Context.RewritePath("~/DesktopDefault.aspx?tabid=" & Tab & "&alias=" & PortalAlias)
                                'otherwise use the tabname
                            Else
                                objHttpApplication.Context.RewritePath("~/DesktopDefault.aspx?tabname=" & Tab & "&alias=" & PortalAlias)
                            End If

                        End If

                    End If

                End If


            End If

        End Sub

    End Class

End Namespace
