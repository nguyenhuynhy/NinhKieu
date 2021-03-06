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

Namespace PortalQH

    Public Class BannerClickThrough
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
                Dim strURL As String

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim objBanners As New BannerController

                objBanners.UpdateBannerClickThrough(Convert.ToInt32(Request.QueryString("BannerId")), Convert.ToInt32(Request.QueryString("VendorId")))
                Dim objBanner As BannerInfo = objBanners.GetBanner(Convert.ToInt32(Request.QueryString("BannerId")), Convert.ToInt32(Request.QueryString("VendorId")))

                If Not objBanner Is Nothing Then
                    If Not Null.IsNull(objBanner.URL) Then
                        strURL = AddHTTP(objBanner.URL)
                    Else
                        strURL = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&VendorId=" & objBanner.VendorId & "&banner=1&def=View Vendor"
                    End If
                Else
                    If (Request.UrlReferrer Is Nothing) Then
                        strURL = "~/DesktopDefault.aspx"
                    Else
                        strURL = Request.UrlReferrer.ToString
                    End If
                End If

                Response.Redirect(strURL, True)
            Catch exc As Exception 'Page failed to load
                ProcessPageLoadException(exc)
            End Try
        End Sub


    End Class

End Namespace
