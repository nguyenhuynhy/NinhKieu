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

    Public Class EditBanner
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtBannerName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valBannerName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents cboBannerType As System.Web.UI.WebControls.DropDownList
        Protected WithEvents valBannerType As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents cboImage As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents valImagePath As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtURL As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtImpressions As System.Web.UI.WebControls.TextBox
        Protected WithEvents valImpressions As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents compareImpressions As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents txtCPM As System.Web.UI.WebControls.TextBox
        Protected WithEvents valCPM As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents compareCPM As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdStartCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdEndCalendar As System.Web.UI.WebControls.HyperLink

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Protected WithEvents pnlAudit As System.Web.UI.WebControls.Panel
        Protected WithEvents lblCreatedBy As System.Web.UI.WebControls.Label
        Protected WithEvents lblCreatedDate As System.Web.UI.WebControls.Label

        Private VendorId As Integer = Null.NullInteger
        Private BannerId As Integer = Null.NullInteger

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
                Dim objModules As New ModuleController

                If Not (Request.Params("VendorId") Is Nothing) Then
                    VendorId = Int32.Parse(Request.Params("VendorId"))
                End If

                If Not (Request.Params("BannerId") Is Nothing) Then
                    BannerId = Int32.Parse(Request.Params("BannerId"))
                End If

                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")
                    cmdStartCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtStartDate)
                    cmdEndCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtEndDate)

                    Dim objBannerTypes As New BannerTypeController
                    ' Get the banner types from the database
                    cboBannerType.DataSource = objBannerTypes.GetBannerTypes()
                    cboBannerType.DataBind()

                    ' load the list of files found in the upload directory
                    Dim FileList As ArrayList
                    If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                        FileList = GetFileList(, glbImageFileTypes, False)
                    Else
                        FileList = GetFileList(PortalId, glbImageFileTypes, False)
                    End If
                    cboImage.DataSource = FileList
                    cboImage.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    Dim objBanners As New BannerController
                    If Not BannerId = Null.NullInteger Then

                        ' Obtain a single row of banner information
                        Dim objBanner As BannerInfo = objBanners.GetBanner(BannerId, VendorId)

                        If Not objBanner Is Nothing Then
                            txtBannerName.Text = objBanner.BannerName
                            cboBannerType.Items.FindByValue(objBanner.BannerTypeId.ToString).Selected = True
                            If cboImage.Items.Contains(New ListItem(objBanner.ImageFile)) Then
                                cboImage.Items.FindByText(objBanner.ImageFile).Selected = True
                            End If
                            If Not IsDBNull(objBanner.URL) Then
                                txtURL.Text = objBanner.URL
                            End If
                            txtImpressions.Text = objBanner.Impressions.ToString
                            txtCPM.Text = objBanner.CPM.ToString
                            If Not Null.IsNull(objBanner.StartDate) Then
                                txtStartDate.Text = objBanner.StartDate.ToShortDateString
                            End If
                            If Not Null.IsNull(objBanner.EndDate) Then
                                txtEndDate.Text = objBanner.EndDate.ToShortDateString
                            End If
                            lblCreatedBy.Text = objBanner.CreatedByUser
                            lblCreatedDate.Text = objBanner.CreatedDate.ToString
                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(EditURL("VendorId", VendorId.ToString), True)
                        End If
                    Else
                        txtImpressions.Text = "0"
                        txtCPM.Text = "0.00"

                        cmdDelete.Visible = False
                        pnlAudit.Visible = False
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub


        '****************************************************************
        '
        ' The cmdUpdate_Click event handler on this Page is used to either
        ' create or update a banner.  It uses the PortalQH.BannerDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                ' Only Update if the Entered Data is val
                If Page.IsValid = True Then

                    Dim StartDate As Date = Null.NullDate
                    If txtStartDate.Text <> "" Then
                        StartDate = Convert.ToDateTime(txtStartDate.Text)
                    End If

                    Dim EndDate As Date = Null.NullDate
                    If txtEndDate.Text <> "" Then
                        EndDate = Convert.ToDateTime(txtEndDate.Text)
                    End If

                    ' Create an instance of the Banner DB component
                    Dim objBanners As New BannerController
                    Dim objBannerInfo As New BannerInfo
                    objBannerInfo.BannerId = BannerId
                    objBannerInfo.BannerName = txtBannerName.Text
                    objBannerInfo.VendorId = VendorId
                    objBannerInfo.ImageFile = cboImage.SelectedItem.Text
                    objBannerInfo.URL = txtURL.Text
                    objBannerInfo.Impressions = Integer.Parse(txtImpressions.Text)
                    objBannerInfo.CPM = Double.Parse(txtCPM.Text)
                    objBannerInfo.StartDate = StartDate
                    objBannerInfo.EndDate = EndDate
                    objBannerInfo.CreatedByUser = Context.User.Identity.Name
                    objBannerInfo.BannerTypeId = Convert.ToInt32(cboBannerType.SelectedItem.Value)

                    If BannerId = Null.NullInteger Then
                        ' Add the banner within the Banners table
                        objBanners.AddBanner(objBannerInfo)
                    Else
                        ' Update the banner within the Banners table
                        objBanners.UpdateBanner(objBannerInfo)
                    End If

                    ' Redirect back to the portal home page
                    Response.Redirect(EditURL("VendorId", VendorId.ToString), True)

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '****************************************************************
        '
        ' The cmdDelete_Click event handler on this Page is used to delete an
        ' a banner.  It  uses the PortalQH.BannerDB() data component to
        ' encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If BannerId <> -1 Then
                    Dim objBanner As New BannerController
                    objBanner.DeleteBanner(BannerId)

                    ' Redirect back to the portal home page
                    Response.Redirect(EditURL("VendorId", VendorId.ToString), True)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '****************************************************************
        '
        ' The cmdCancel_Click event handler on this Page is used to cancel
        ' out of the page, and return the user back to the portal home
        ' page.
        '
        '****************************************************************'

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                ' Redirect back to the portal home page
                Response.Redirect(EditURL("VendorId", VendorId.ToString), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace