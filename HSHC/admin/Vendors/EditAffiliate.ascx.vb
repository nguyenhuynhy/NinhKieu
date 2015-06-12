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

    Public Class EditAffiliate

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdStartCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdEndCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtCPC As System.Web.UI.WebControls.TextBox
        Protected WithEvents valCPC1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valCPC2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents txtCPA As System.Web.UI.WebControls.TextBox
        Protected WithEvents valCPA1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valCPA2 As System.Web.UI.WebControls.CompareValidator

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdSend As System.Web.UI.WebControls.LinkButton

        Private VendorId As Integer = -1
        Private AffiliateId As Integer = -1

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

            If Not (Request.QueryString("VendorId") Is Nothing) Then
                VendorId = Int32.Parse(Request.QueryString("VendorId"))
            End If

            If Not (Request.QueryString("AffiliateId") Is Nothing) Then
                AffiliateId = Int32.Parse(Request.QueryString("AffiliateId"))
            End If

            If Page.IsPostBack = False Then
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")
                cmdStartCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtStartDate)
                cmdEndCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtEndDate)

                Dim objAffiliates As New AffiliateController
                Dim objAffiliate As AffiliateInfo

                If AffiliateId <> -1 Then

                    ' Obtain a single row of banner information
                    objAffiliate = objAffiliates.GetAffiliate(AffiliateId, VendorId)

                    If Not objAffiliate Is Nothing Then
                        If Not Null.IsNull(objAffiliate.StartDate) Then
                            txtStartDate.Text = objAffiliate.StartDate.ToShortDateString
                        End If
                        If Not Null.IsNull(objAffiliate.EndDate) Then
                            txtEndDate.Text = objAffiliate.EndDate.ToShortDateString
                        End If
                        txtCPC.Text = objAffiliate.CPC.ToString
                        txtCPA.Text = objAffiliate.CPA.ToString

                    Else ' security violation attempt to access item not related to this Module
                        Response.Redirect(EditURL("VendorId", VendorId.ToString), True)
                    End If
                Else
                    txtCPC.Text = "0.00"
                    txtCPA.Text = "0.00"

                    cmdDelete.Visible = False
                End If

            End If

        End Sub


        '****************************************************************
        '
        ' The cmdUpdate_Click event handler on this Page is used to either
        ' create or update a banner.  It uses the PortalQH.BannerDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click

            If Page.IsValid = True Then

                Dim objAffiliate As New AffiliateInfo

                objAffiliate.AffiliateId = AffiliateId
                objAffiliate.VendorId = VendorId
                If txtStartDate.Text <> "" Then
                    objAffiliate.StartDate = Date.Parse(txtStartDate.Text)
                Else
                    objAffiliate.StartDate = Null.NullDate
                End If
                If txtEndDate.Text <> "" Then
                    objAffiliate.EndDate = Date.Parse(txtEndDate.Text)
                Else
                    objAffiliate.EndDate = Null.NullDate
                End If
                objAffiliate.CPC = Double.Parse(txtCPC.Text)
                objAffiliate.CPA = Double.Parse(txtCPA.Text)

                Dim objAffiliates As New AffiliateController

                If AffiliateId = -1 Then
                    objAffiliates.AddAffiliate(objAffiliate)
                Else
                    objAffiliates.UpdateAffiliate(objAffiliate)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(EditURL("VendorId", VendorId.ToString), True)

            End If

        End Sub


        '****************************************************************
        '
        ' The cmdDelete_Click event handler on this Page is used to delete an
        ' a banner.  It  uses the PortalQH.BannerDB() data component to
        ' encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click

            If AffiliateId <> -1 Then
                Dim objAffiliates As New AffiliateController
                objAffiliates.DeleteAffiliate(AffiliateId)

                ' Redirect back to the portal home page
                Response.Redirect(EditURL("VendorId", VendorId.ToString), True)
            End If

        End Sub


        '****************************************************************
        '
        ' The cmdCancel_Click event handler on this Page is used to cancel
        ' out of the page, and return the user back to the portal home
        ' page.
        '
        '****************************************************************'

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click

            ' Redirect back to the portal home page
            Response.Redirect(EditURL("VendorId", VendorId.ToString), True)

        End Sub


        Private Sub cmdSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSend.Click

            Dim objVendors As New VendorController
            Dim objVendor As VendorInfo

            objVendor = objVendors.GetVendor(VendorId)
            If Not objVendor Is Nothing Then
                If Not Null.IsNull(objVendor.Email) Then

                    Dim strBody As String

                    strBody = "Dear " & objVendor.VendorName & "," & vbCrLf & vbCrLf
                    strBody = strBody & "Your account for the " & PortalSettings.PortalName & " Affiliate Program has been created." & vbCrLf & vbCrLf
                    strBody = strBody & "To begin earning rewards, please use the following URL to link to our site." & vbCrLf & vbCrLf
                    strBody = strBody & GetPortalDomainName(PortalSettings.PortalAlias, Request) & "/DesktopDefault.aspx?AffiliateId=" & VendorId.ToString & vbCrLf & vbCrLf
                    strBody = strBody & "Thank you," & vbCrLf & vbCrLf
                    strBody = strBody & PortalSettings.PortalName

                    SendNotification(PortalSettings.Email, objVendor.Email, "", PortalSettings.PortalName & " Affiliate Notification", strBody)

                End If
            End If

        End Sub

    End Class

End Namespace