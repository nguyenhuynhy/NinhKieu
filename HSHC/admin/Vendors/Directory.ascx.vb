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
    Public MustInherit Class ServiceDirectory
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkSearch As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lstVendors As System.Web.UI.WebControls.DataList
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel
        Protected WithEvents cmdSignup As System.Web.UI.WebControls.LinkButton

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
        ' obtain a DataReader of contact information from the Vendors
        ' table, and then databind the results to a DataGrid
        ' server control.  It uses the PortalQH.VendorsDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************'
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not Page.IsPostBack Then
                    If CType(Settings("directorysignup"), Boolean) = False Then
                        cmdSignup.Visible = False
                    End If

                    If Not Request.Params("search") Is Nothing Then
                        txtSearch.Text = Request.Params("search")
                        BindData()
                    End If
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub lnkSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSearch.Click
            Try
                BindData()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub lstVendors_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles lstVendors.ItemDataBound
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim strURL As String
                Dim rowView As DataRowView = DirectCast(e.Item.DataItem, DataRowView)

                strURL = "~/admin/Vendors/VendorClickThrough.aspx?tabid=" & TabId & "&mid=" & ModuleId
                strURL += "&VendorId=" & rowView("VendorId").ToString

                Select Case e.Item.ItemType
                    Case ListItemType.Item, ListItemType.AlternatingItem
                        CType(e.Item.FindControl("lnkVendorName"), HyperLink).Text = rowView("VendorName").ToString
                        If rowView("Website").ToString <> "" Then
                            CType(e.Item.FindControl("lnkVendorName"), HyperLink).NavigateUrl = strURL & "&link=name"
                        End If

                        CType(e.Item.FindControl("lblAddress"), Label).Text = FormatAddress(rowView("Unit"), rowView("Street"), rowView("City"), rowView("Region"), rowView("Country"), rowView("PostalCode"))
                        If rowView("Telephone").ToString <> "" Then
                            CType(e.Item.FindControl("lblTelephone"), Label).Text = "<br>" & rowView("Telephone").ToString
                        End If
                        If rowView("Fax").ToString <> "" Then
                            CType(e.Item.FindControl("lblFax"), Label).Text = "<br>" & rowView("Fax").ToString & " (fax)"
                        End If
                        If rowView("Email").ToString <> "" Then
                            CType(e.Item.FindControl("lblEmail"), Label).Text = "<br>" & FormatEmail(rowView("Email"))
                        End If
                        If rowView("Website").ToString <> "" Then
                            CType(e.Item.FindControl("lnkWebsite"), HyperLink).Text = "<br>" & rowView("Website").ToString
                            CType(e.Item.FindControl("lnkWebsite"), HyperLink).NavigateUrl = strURL & "&link=url"
                        End If

                        CType(e.Item.FindControl("lnkMap"), HyperLink).NavigateUrl = strURL & "&link=map"
                        CType(e.Item.FindControl("lnkMap"), HyperLink).Visible = True
                        CType(e.Item.FindControl("lnkDirections"), HyperLink).NavigateUrl = strURL & "&link=directions"
                        CType(e.Item.FindControl("lnkDirections"), HyperLink).Visible = True

                        If CType(Settings("directoryfeedback"), Boolean) Then
                            CType(e.Item.FindControl("lnkFeedback"), HyperLink).NavigateUrl = strURL & "&link=feedback&search=" & txtSearch.Text
                            CType(e.Item.FindControl("lnkFeedback"), HyperLink).Text = "<br>Feedback"
                            CType(e.Item.FindControl("lnkFeedback"), HyperLink).Visible = True
                            If rowView("Feedback").ToString <> "" Then
                                Select Case Int32.Parse(rowView("Feedback").ToString)
                                    Case Is > 0
                                        CType(e.Item.FindControl("lnkFeedback"), HyperLink).Text += "&nbsp;<img src=""" & IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/images/ratingplus.gif"" border=""0"" alt=""Feedback Rating: +" & rowView("Feedback").ToString & """>"
                                    Case Is < 0
                                        CType(e.Item.FindControl("lnkFeedback"), HyperLink).Text += "&nbsp;<img src=""" & IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/images/ratingminus.gif"" border=""0"" alt=""Feedback Rating: " & rowView("Feedback").ToString & """>"
                                    Case Else
                                        CType(e.Item.FindControl("lnkFeedback"), HyperLink).Text += "&nbsp;<img src=""" & IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/images/ratingzero.gif"" border=""0"" alt=""Feedback Rating: " & rowView("Feedback").ToString & """>"
                                End Select
                            Else
                                CType(e.Item.FindControl("lnkFeedback"), HyperLink).Text += "&nbsp;<img src=""" & IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/images/ratingzero.gif"" border=""0"" alt=""No Feedback Recorded"">"
                            End If
                        End If

                        If rowView("LogoFile").ToString <> "" Then
                            If CType(Settings("directorysource"), String) = "L" Then
                                CType(e.Item.FindControl("lnkLogo"), HyperLink).ImageUrl = _portalSettings.UploadDirectory & rowView("LogoFile").ToString
                            Else
                                CType(e.Item.FindControl("lnkLogo"), HyperLink).ImageUrl = Global.HostPath & rowView("LogoFile").ToString
                            End If
                            CType(e.Item.FindControl("lnkLogo"), HyperLink).NavigateUrl = strURL & "&link=logo"
                        End If
                End Select
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub BindData()
            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim objVendors As New VendorController

            lstVendors.DataSource = objVendors.FindVendors(PortalId, txtSearch.Text, Convert.ToInt32(IIf(CType(Settings("directorysource"), String) = "L", _portalSettings.PortalId, -1)))
            lstVendors.DataBind()

        End Sub

        Private Sub cmdSignup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSignup.Click
            Try
                Response.Redirect(NavigateURL("Vendors"), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace