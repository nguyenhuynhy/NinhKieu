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

    Public MustInherit Class VendorFeedback
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lblVendor As System.Web.UI.WebControls.Label
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

        Protected WithEvents cmdFeedback As System.Web.UI.WebControls.LinkButton
        Protected WithEvents pnlFeedback As System.Web.UI.WebControls.Panel
        Protected WithEvents cboValue As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtComment As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Protected WithEvents lstFeedback As System.Web.UI.WebControls.DataList
        Protected WithEvents cmdBack As System.Web.UI.WebControls.LinkButton

        Private VendorId As Integer = 0

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

        '*******************************************************
        '
        ' The Page_Load event handler on this User Control is used to
        ' obtain a DataReader of banner information from the Banners
        ' table, and then databind the results to a templated DataList
        ' server control.  It uses the PortalQH.BannerDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************'

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Not (Request.Params("VendorId") Is Nothing) Then
                VendorId = Int32.Parse(Request.Params("VendorId"))
            End If

            If Not Page.IsPostBack Then

                If Not Request.IsAuthenticated Then
                    lblMessage.Text = "In order to provide Feedback, you must first identify yourself as a member of the site. If you have already registered in the past, please enter your Email and Password on the Account Login screen. If you have not yet registered for the site, click the Register button on the Account Login screen and enter your Account Registration details.<br><br>Please click <b><a href=""" & GetPortalDomainName(PortalAlias, Request) & """>here</a></b> to proceed to the Account Login screen.<br><br>"
                    cmdFeedback.Visible = False
                Else
                    lblMessage.Text = ""
                    cmdFeedback.Visible = True
                End If

                Dim objVendors As New VendorController
                Dim objVendor As VendorInfo = objVendors.GetVendor(VendorId)
                If Not objVendor Is Nothing Then
                    lblVendor.Text = objVendor.VendorName
                End If

                Dim objFeedback As New FeedBackController
                lstFeedback.DataSource = objFeedback.GetVendorFeedback(VendorId)
                lstFeedback.DataBind()

                ' Store URL Referrer to return to portal
                Dim strReferrer As String = Convert.ToString(Request.UrlReferrer)
                If Convert.ToBoolean(InStr(1, strReferrer, "&search=")) Then
                    strReferrer = Left(strReferrer, InStr(1, strReferrer, "&search=") - 1)
                End If
                ViewState("UrlReferrer") = strReferrer & "&search=" & Request.QueryString("search")

            End If

        End Sub

        Private Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
            Response.Redirect(Convert.ToString(ViewState("UrlReferrer")), True)
        End Sub

        Private Sub cmdFeedback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFeedback.Click

            Dim objFeedBacks As New FeedBackController

            Dim objFeedBack As FeedBackInfo = objFeedBacks.GetSingleVendorFeedback(VendorId, Convert.ToInt32(Context.User.Identity.Name))
            If Not objFeedBack Is Nothing Then
                cboValue.Items.FindByValue(objFeedBack.Value).Selected = True
                txtComment.Text = objFeedBack.Comment
            End If

            pnlFeedback.Visible = True

        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
            Dim objFeedBacks As New FeedBackController
            objFeedBacks.UpdateVendorFeedback(VendorId, Int32.Parse(Context.User.Identity.Name), txtComment.Text, Int32.Parse(cboValue.SelectedItem.Value))

            ' Redirect back to the portal home page
            Response.Redirect(Convert.ToString(ViewState("UrlReferrer")), True)
        End Sub

        Private Sub lstFeedback_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles lstFeedback.ItemDataBound

            Dim rowView As DataRowView = DirectCast(e.Item.DataItem, DataRowView)

            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Select Case Int32.Parse(rowView("Value").ToString)
                        Case 1
                            CType(e.Item.FindControl("lblValue"), Label).Text += "<img src=""" & Convert.ToString(IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath)) & "/images/ratingplus.gif"" border=""0"" alt=""Positive Feedback"">"
                        Case -1
                            CType(e.Item.FindControl("lblValue"), Label).Text += "<img src=""" & Convert.ToString(IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath)) & "/images/ratingminus.gif"" border=""0"" alt=""Negative Feedback"">"
                    End Select
                    CType(e.Item.FindControl("lblDate"), Label).Text = "&nbsp;&nbsp;<b>Date:</b>&nbsp;" & rowView("Date").ToString
                    CType(e.Item.FindControl("lblUser"), Label).Text = "&nbsp;&nbsp;<b>User:</b>&nbsp;" & "<a href=""mailto:" & rowView("Email").ToString & """>" & rowView("FullName").ToString & "</a>"

                    CType(e.Item.FindControl("lblComment"), Label).Text = rowView("Comment").ToString & "<br>"
            End Select
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

            pnlFeedback.Visible = False

        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Dim objFeedBacks As New FeedBackController
            objFeedBacks.DeleteVendorFeedback(VendorId, Convert.ToInt32(Context.User.Identity.Name))

            ' Redirect back to the portal home page
            Response.Redirect(Convert.ToString(ViewState("UrlReferrer")), True)
        End Sub

    End Class

End Namespace
