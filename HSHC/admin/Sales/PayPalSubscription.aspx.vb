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
' CONTRACT, TORT OR OTHERWISE,ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System.Net
Imports System.IO

Namespace PortalQH

    Public Class PayPalSubscription

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
                Dim objAdmin As New AdminDB
                Dim intRoleId As Integer = -1
                If Not Request.Params("roleid") Is Nothing Then
                    intRoleId = Integer.Parse(Request.Params("roleid"))
                End If

                Dim strProcessorUserId As String

                Dim objRegionalController As New RegionalController

                Dim objPortalController As New PortalController
                Dim objPortalInfo As PortalInfo = objPortalController.GetPortal(_portalSettings.PortalId)
                If Not objPortalInfo Is Nothing Then
                    strProcessorUserId = objPortalInfo.ProcessorUserId
                End If

                If intRoleId <> -1 And strProcessorUserId <> "" Then

                    Dim strPayPalURL As String = "https://www.paypal.com/cgi-bin/webscr?"

                    If Not Request.Params("cancel") Is Nothing Then
                        ' build the cancellation PayPal URL
                        strPayPalURL += "cmd=_subscr-find&alias=" & HTTPPOSTEncode(strProcessorUserId)
                    Else
                        ' build the subscription PayPal URL
                        strPayPalURL += "cmd=_ext-enter&redirect_cmd=_xclick-subscriptions&business=" & HTTPPOSTEncode(strProcessorUserId)

                        Dim objRoles As New RoleController

                        Dim objRole As RoleInfo = objRoles.GetRole(intRoleId)
                        If Not objRole.RoleID = -1 Then
                            Dim intTrialPeriod As Integer = 1
                            If objRole.TrialPeriod <> 0 Then
                                intTrialPeriod = objRole.TrialPeriod
                            End If
                            Dim intBillingPeriod As Integer = 1
                            If objRole.BillingPeriod <> 0 Then
                                intBillingPeriod = objRole.BillingPeriod
                            End If

                            strPayPalURL += "&item_name=" & HTTPPOSTEncode(_portalSettings.PortalName & " - " & objRole.RoleName & " ( " & Format(objRole.ServiceFee, "0.00") & " " & _portalSettings.Currency & " every " & intBillingPeriod.ToString & " " & objAdmin.GetBillingFrequencyCode(objRole.BillingFrequency) & " )")
                            strPayPalURL += "&item_number=" & HTTPPOSTEncode(intRoleId.ToString)
                            strPayPalURL += "&no_shipping=1&no_note=1"
                            If objRole.TrialFrequency <> "N" Then
                                strPayPalURL += "&a1=" & HTTPPOSTEncode(Format(objRole.TrialFee, "#####0.00"))
                                strPayPalURL += "&p1=" & HTTPPOSTEncode(intTrialPeriod.ToString)
                                strPayPalURL += "&t1=" & HTTPPOSTEncode(objRole.TrialFrequency)
                            End If
                            strPayPalURL += "&a3=" & HTTPPOSTEncode(Format(objRole.ServiceFee, "#####0.00"))
                            strPayPalURL += "&p3=" & HTTPPOSTEncode(intBillingPeriod.ToString)
                            strPayPalURL += "&t3=" & HTTPPOSTEncode(objRole.BillingFrequency)
                            If objRole.BillingFrequency <> "O" Then ' one-time fee
                                strPayPalURL += "&src=1"
                            End If
                            strPayPalURL += "&currency_code=" & HTTPPOSTEncode(_portalSettings.Currency)
                        End If

                        If Not Request.Params("vendorid") Is Nothing Then
                            Dim objVendorController As New VendorController
                            Dim objVendorInfo As VendorInfo = objVendorController.GetVendor(Int32.Parse(Request.Params("vendorid")))
                            If Not objVendorInfo Is Nothing Then
                                If objVendorInfo.Country = "United States" Then
                                    strPayPalURL += "&first_name=" & HTTPPOSTEncode(objVendorInfo.FirstName)
                                    strPayPalURL += "&last_name=" & HTTPPOSTEncode(objVendorInfo.LastName)
                                    strPayPalURL += "&address1=" & HTTPPOSTEncode(Convert.ToString(IIf(objVendorInfo.Unit <> "", objVendorInfo.Unit & " ", "")) & objVendorInfo.Street)
                                    strPayPalURL += "&city=" & HTTPPOSTEncode(objVendorInfo.City)
                                    strPayPalURL += "&state=" & HTTPPOSTEncode(objRegionalController.GetRegionByDescription(objVendorInfo.Region).Code)
                                    strPayPalURL += "&zip=" & HTTPPOSTEncode(objVendorInfo.PostalCode)
                                End If
                            End If
                        Else
                            If Request.IsAuthenticated Then
                                Dim objUsers As UserController
                                Dim objUser As UserInfo = objUsers.GetUser(_portalSettings.PortalId, Context.User.Identity.Name)
                                If Not objUser.UserID = "" Then
                                    If objUser.Country = "United States" Then
                                        strPayPalURL += "&full_name=" & HTTPPOSTEncode(objUser.FullName)
                                        strPayPalURL += "&address1=" & HTTPPOSTEncode(Convert.ToString(IIf(objUser.Unit <> "", objUser.Unit & " ", "")) & objUser.Street)
                                        strPayPalURL += "&city=" & HTTPPOSTEncode(objUser.City)
                                        strPayPalURL += "&state=" & HTTPPOSTEncode(objRegionalController.GetRegionByDescription(objUser.Region).Code)
                                        strPayPalURL += "&zip=" & HTTPPOSTEncode(objUser.PostalCode)
                                    End If
                                End If
                            End If
                        End If

                        strPayPalURL += "&return=" & HTTPPOSTEncode("http://" & GetDomainName(Request))
                        strPayPalURL += "&cancel_return=" & HTTPPOSTEncode("http://" & GetDomainName(Request))
                        strPayPalURL += "&notify_url=" & HTTPPOSTEncode("http://" & GetDomainName(Request) & "/admin/Sales/PayPalIPN.aspx")
                        strPayPalURL += "&sra=1" ' reattempt on failure
                    End If

                    ' redirect to PayPal
                    Response.Redirect(strPayPalURL, True)
                Else
                    Response.Redirect(Request.UrlReferrer.ToString(), True)
                End If

            Catch exc As Exception 'Page failed to load
                ProcessPageLoadException(exc)
            End Try
        End Sub

    End Class

End Namespace
