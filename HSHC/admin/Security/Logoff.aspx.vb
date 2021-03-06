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

Imports System.Web.Security
Imports System.Configuration

Namespace PortalQH

    Public Class Logoff
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)
                'Create On: 06/06/2005
                'Create By: LANPHM
                'Purpose: Bien cookiename de tranh viec dung cookie giua~ 2 session khac nhau.
                Dim CookieName As String = ""
                CookieName = GetCookieName(Request)
                'End

                ' Log User Off from Cookie Authentication System
                FormsAuthentication.SignOut()

                ' expire cookies 
                Response.Cookies(CookieName & "portalid").Value = Nothing
                Response.Cookies(CookieName & "portalid").Path = "/"
                Response.Cookies(CookieName & "portalid").Expires = DateTime.Now.AddYears(-30)

                Response.Cookies(CookieName & "portalroles").Value = Nothing
                Response.Cookies(CookieName & "portalroles").Path = "/"
                Response.Cookies(CookieName & "portalroles").Expires = DateTime.Now.AddYears(-30)

                'LANPHM add 6/6/2005
                'Remove all session
                Session.RemoveAll()

                ' Redirect browser back to portal 
                If _portalSettings.HomeTabId <> -1 Then
                    Response.Redirect("~/DesktopDefault.aspx?tabid=" & _portalSettings.HomeTabId.ToString, True)
                Else
                    If (Globals.IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId)) Then
                        Response.Redirect("~/Default.aspx", True)
                    Else
                        'Response.Redirect("~/DesktopDefault.aspx?tabid=" & CType(ConfigurationSettings.AppSettings("TabDefault"), Integer), True)
                        Response.Redirect("~/Default.aspx", True)
                    End If
                End If

            Catch exc As Exception 'Page failed to load
                ProcessPageLoadException(exc)
            End Try
        End Sub


    End Class

End Namespace