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

Imports System.Net
Imports System.IO

Namespace PortalQH

    Public Class PayPalIPN
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
                Dim strName As String
                Dim objStream As StreamWriter
                Dim blnValid As Boolean = True
                Dim strTransactionID As String
                Dim strTransactionType As String
                Dim intRoleID As Integer
                Dim intPortalID As Integer
                Dim intUserID As String
                Dim strDescription As String
                Dim dblAmount As Double
                Dim strEmail As String
                Dim strBody As String
                Dim blnCancel As Boolean = False

                Dim objRoles As New RoleController
                Dim objPortalController As New PortalController

                Dim strPost As String = "cmd=_notify-validate"
                For Each strName In Request.Form
                    Dim strValue As String = Request.Form(strName)
                    Select Case strName
                        Case "txn_type" ' get the transaction type
                            strTransactionType = strValue
                            Select Case strTransactionType
                                Case "subscr_signup", "subscr_payment"
                                Case "subscr_cancel"
                                    blnCancel = True
                                Case Else
                                    blnValid = False
                            End Select
                        Case "payment_status" ' verify the status
                            If strValue <> "Completed" Then
                                blnValid = False
                            End If
                        Case "txn_id" ' verify the transaction id for duplicates
                            strTransactionID = strValue
                        Case "receiver_email" ' verify the PayPalId
                        Case "mc_gross" ' verify the price
                            dblAmount = Double.Parse(strValue)
                        Case "item_number" ' get the RoleID
                            intRoleID = Int32.Parse(strValue)
                            Dim objRole As RoleInfo = objRoles.GetRole(intRoleID)
                            intPortalID = objRole.PortalID
                        Case "item_name" ' get the product description
                            strDescription = strValue
                        Case "custom" ' get the UserID
                            intUserID = strValue
                        Case "email" ' get the email
                            strEmail = strValue
                    End Select
                    ' reconstruct post for postback validation
                    strPost += String.Format("&{0}={1}", strName, HTTPPOSTEncode(strValue))
                Next

                ' postback to verify the source
                If blnValid Then
                    Dim objRequest As HttpWebRequest = CType(WebRequest.Create("https://www.paypal.com/cgi-bin/webscr"), HttpWebRequest)
                    objRequest.Method = "POST"
                    objRequest.ContentLength = strPost.Length
                    objRequest.ContentType = "application/x-www-form-urlencoded"

                    objStream = New StreamWriter(objRequest.GetRequestStream())
                    objStream.Write(strPost)
                    objStream.Close()

                    Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)
                    Dim sr As StreamReader
                    sr = New StreamReader(objResponse.GetResponseStream())
                    Dim strResponse As String = sr.ReadToEnd()
                    sr.Close()

                    Select Case strResponse
                        Case "VERIFIED"
                        Case Else
                            ' possible fraud
                            blnValid = False
                    End Select
                End If

                If blnValid Then

                    Dim intAdministratorRoleId As Integer

                    Dim objPortalInfo As PortalInfo = objPortalController.GetPortal(intPortalID)
                    If Not objPortalInfo Is Nothing Then
                        intAdministratorRoleId = objPortalInfo.AdministratorRoleId
                    End If

                    If intRoleID = intAdministratorRoleId Then
                        ' admin portal renewal
                        objPortalController.UpdatePortalExpiry(intPortalID)
                    Else
                        ' user subscription
                        objRoles.UpdateService(intPortalID, intUserID, intRoleID, blnCancel)
                    End If

                End If

            Catch exc As Exception 'Page failed to load
                ProcessPageLoadException(exc)
            End Try
        End Sub

    End Class

End Namespace
