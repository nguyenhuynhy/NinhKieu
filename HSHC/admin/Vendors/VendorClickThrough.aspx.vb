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

    Public Class VendorClickThrough
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

            Dim strURL As String

            Dim objVendors As New VendorController

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim objVendor As VendorInfo = objVendors.GetVendor(CInt(Request.QueryString("VendorId")))
            If Not objVendor Is Nothing Then
                Select Case Request.QueryString("link")
                    Case "logo", "name", "url"
                        strURL = AddHTTP(objVendor.Website)
                    Case "map"
                        strURL = "http://www.mapquest.com/maps/map.adp?country=" & Replace(objVendor.Country, " ", "+") & "&address=" & Replace(objVendor.Street, " ", "+") & "&city=" & Replace(objVendor.City, " ", "+") & "&state=" & Replace(objVendor.Region, " ", "+") & "&zip=" & Replace(objVendor.PostalCode, " ", "+")
                    Case "directions"
                        strURL = "http://www.mapquest.com/directions/main.adp?go=1"
                        If Request.IsAuthenticated Then
                            Dim objUsers As New UserController
                            Dim objUser As UserInfo = objUsers.GetUser(_portalSettings.PortalId, CType(context.User.Identity.Name, String))
                            If Not objUser Is Nothing Then
                                strURL += "&1y=" & Replace(objUser.Country, " ", "+") & " &1a=" & Replace(objUser.Street, " ", "+") & "&1p=&1c=" & Replace(objUser.City, " ", "+") & "&1s=" & Replace(objUser.Region, " ", "+") & "&1z=" & Replace(objUser.PostalCode, " ", "+") & "&1ah="
                            End If
                        End If
                        strURL += "&2y=" & Replace(objVendor.Country, " ", "+") & "&2a=" & Replace(objVendor.Street, " ", "+") & "&2p=&2c=" & Replace(objVendor.City, " ", "+") & "&2s=" & Replace(objVendor.Region, " ", "+") & "&2z=" & Replace(objVendor.PostalCode, " ", "+")
                    Case "feedback"
                        strURL = "~/DesktopDefault.aspx?tabid=" & Request.Params("tabid") & "&mid=" & Request.Params("mid") & "&VendorId=" & Request.Params("VendorId") & "&search=" & Request.Params("search") & "&def=Vendor Feedback"
                End Select
            Else
                strURL = Request.UrlReferrer.ToString
            End If

            Response.Redirect(strURL, True)
        End Sub

    End Class

End Namespace
