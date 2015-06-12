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
Imports System.IO

Namespace PortalQH

    Public Class LinkClick
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
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If Not Request.Params("link") Is Nothing Then
                    Dim strLink As String = Request.Params("link").ToString

                    Dim UserId As String = ""
                    If Request.IsAuthenticated Then
                        UserId = Context.User.Identity.Name
                    End If

                    ' update clicks
                    Dim objClick As New ClickLogController
                    objClick.UpdateClicks(Request.Params("table").ToString, Request.Params("field").ToString, Integer.Parse(Request.Params("id")), UserId)

                    ' format file link
                    If InStr(1, strLink, "/") = 0 Then
                        strLink = _portalSettings.UploadDirectory & strLink
                    End If

                    ' link to internal file
                    If Not Request.Params("contenttype") Is Nothing Then
                        ' verify file extension for request
                        Dim strExtension As String = Replace(Path.GetExtension(Request.Params("link").ToString()), ".", "")
                        If InStr(1, "," & _portalSettings.HostSettings("FileExtensions").ToString.ToUpper, "," & strExtension.ToUpper) <> 0 Then
                            ' force download dialog
                            Response.AppendHeader("content-disposition", "attachment; filename=" + Request.Params("link").ToString)
                            Response.ContentType = Request.Params("contenttype").ToString
                            Response.WriteFile(strLink)
                            Response.End()
                        End If
                    Else ' redirect
                        Response.Redirect(strLink, True)
                    End If
                End If

            Catch exc As Exception 'Page failed to load
                ProcessPageLoadException(exc)
            End Try
        End Sub

    End Class

End Namespace
