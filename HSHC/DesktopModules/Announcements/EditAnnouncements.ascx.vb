'
' DotNetNuke -  http://www.dotnetnuke.com
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

    Public Class EditAnnouncements
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents valTitle As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents chkAddDate As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents valDescription As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents optExternal As System.Web.UI.WebControls.RadioButton
        Protected WithEvents txtExternal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtExpires As System.Web.UI.WebControls.TextBox
        Protected WithEvents valExpires As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents chkSyndicate As System.Web.UI.WebControls.CheckBox

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdSyndicate As System.Web.UI.WebControls.LinkButton

        Protected WithEvents pnlAudit As System.Web.UI.WebControls.Panel
        Protected WithEvents lblCreatedBy As System.Web.UI.WebControls.Label
        Protected WithEvents lblCreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblSyndicate As System.Web.UI.WebControls.Label

        Protected WithEvents lblClicks As System.Web.UI.WebControls.Label
        Protected WithEvents chkLog As System.Web.UI.WebControls.CheckBox
        Protected WithEvents grdLog As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtViewOrder As System.Web.UI.WebControls.TextBox
        Protected WithEvents optFile As System.Web.UI.WebControls.RadioButton
        Protected WithEvents cboFile As System.Web.UI.WebControls.DropDownList
        Protected WithEvents optInternal As System.Web.UI.WebControls.RadioButton
        Protected WithEvents cboInternal As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents valViewOrder As System.Web.UI.WebControls.CompareValidator

        Private itemId As Integer

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

        '****************************************************************
        '
        ' The Page_Load event on this Page is used to obtain the ModuleId
        ' and ItemId of the announcement to edit.
        '
        ' It then uses the DotNetNuke.AnnouncementsDB() data component
        ' to populate the page's edit controls with the annoucement details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objModules As New ModuleController

                ' Determine ItemId of Announcement to Update
                If Not (Request.Params("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.Params("ItemId"))
                Else
                    itemId = Convert.ToInt32(Null.SetNull(itemId))
                End If

                If optExternal.Checked = False And optInternal.Checked = False And optFile.Checked = False Then
                    optFile.Checked = True
                End If

                EnableControls()

                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")
                    cmdCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtExpires)

                    ' load the list of files found in the upload directory
                    Dim FileList As ArrayList = GetFileList(PortalId)
                    cboFile.DataSource = FileList
                    cboFile.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    cboInternal.DataSource = GetPortalTabs(PortalSettings.DesktopTabs, True, True)
                    cboInternal.DataBind()

                    lblSyndicate.Text = GetPortalDomainName(PortalSettings.PortalAlias, Request)
                    If Request.ApplicationPath <> "/" Then
                        lblSyndicate.Text = Left(lblSyndicate.Text, InStrRev(lblSyndicate.Text, "/") - 1)
                    End If
                    lblSyndicate.Text += PortalSettings.UploadDirectory & ModuleConfiguration.ModuleTitle & ".rss"

                    If Not Null.IsNull(itemId) Then

                        ' Obtain a single row of announcement information
                        Dim objAnnouncements As New AnnouncementsController
                        Dim objAnnouncement As AnnouncementInfo = objAnnouncements.GetAnnouncement(itemId, ModuleId)

                        ' Load first row 
                        If Not objAnnouncement Is Nothing Then
                            If InStr(1, objAnnouncement.Url.ToString, "://") = 0 Then
                                If IsNumeric(objAnnouncement.Url.ToString) Then
                                    optExternal.Checked = False
                                    optInternal.Checked = True
                                    optFile.Checked = False
                                    EnableControls()
                                    If Not cboInternal.Items.FindByValue(objAnnouncement.Url.ToString) Is Nothing Then
                                        cboInternal.Items.FindByValue(objAnnouncement.Url.ToString).Selected = True
                                    End If
                                Else ' file
                                    optExternal.Checked = False
                                    optInternal.Checked = False
                                    optFile.Checked = True
                                    EnableControls()
                                    If Not cboFile.Items.FindByValue(objAnnouncement.Url.ToString) Is Nothing Then
                                        cboFile.Items.FindByValue(objAnnouncement.Url.ToString).Selected = True
                                    End If
                                End If
                            Else ' external
                                optExternal.Checked = True
                                optInternal.Checked = False
                                optFile.Checked = False
                                EnableControls()
                                txtExternal.Text = objAnnouncement.Url.ToString
                            End If

                            txtTitle.Text = objAnnouncement.Title.ToString
                            txtDescription.Text = objAnnouncement.Description.ToString
                            If Not Null.IsNull(objAnnouncement.ExpireDate) Then
                                txtExpires.Text = objAnnouncement.ExpireDate.ToShortDateString()
                            End If
                            If Not Null.IsNull(objAnnouncement.ViewOrder) Then
                                txtViewOrder.Text = Convert.ToString(objAnnouncement.ViewOrder)
                            End If
                            chkSyndicate.Checked = objAnnouncement.Syndicate

                            lblClicks.Text = objAnnouncement.Clicks.ToString
                            lblCreatedBy.Text = objAnnouncement.CreatedByUser.ToString
                            lblCreatedDate.Text = objAnnouncement.CreatedDate.ToString
                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If
                    Else
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
        ' create or update an announcement.  It  uses the DotNetNuke.AnnouncementsDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                Dim strLink As String
                ' Only Update if the Entered Data is Valid
                If Page.IsValid = True Then

                    If optExternal.Checked = True Then
                        strLink = AddHTTP(txtExternal.Text)
                    Else
                        If optInternal.Checked = True Then
                            strLink = cboInternal.SelectedItem.Value
                        Else
                            strLink = cboFile.SelectedItem.Value
                        End If
                    End If

                    Dim objAnnouncement As New AnnouncementInfo

                    objAnnouncement = CType(CBO.InitializeObject(objAnnouncement, GetType(AnnouncementInfo)), AnnouncementInfo)

                    'bind text values to object
                    objAnnouncement.ItemId = itemId
                    objAnnouncement.ModuleId = ModuleId
                    objAnnouncement.CreatedByUser = Context.User.Identity.Name
                    objAnnouncement.Title = txtTitle.Text
                    If chkAddDate.Checked Then
                        objAnnouncement.Title += " - " & Now.ToLongDateString
                    End If
                    objAnnouncement.Description = txtDescription.Text
                    objAnnouncement.Url = strLink
                    objAnnouncement.Syndicate = chkSyndicate.Checked
                    If txtViewOrder.Text <> "" Then
                        objAnnouncement.ViewOrder = Convert.ToInt32(txtViewOrder.Text)
                    End If
                    If txtExpires.Text <> "" Then
                        objAnnouncement.ExpireDate = Convert.ToDateTime(txtExpires.Text)
                    End If

                    Dim objAnnouncements As New AnnouncementsController
                    If Null.IsNull(itemId) Then
                        objAnnouncements.AddAnnouncement(objAnnouncement)
                    Else
                        objAnnouncements.UpdateAnnouncement(objAnnouncement)
                    End If

                    Syndicate()

                    ' Redirect back to the portal home page
                    Response.Redirect(NavigateURL(), True)

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '****************************************************************
        '
        ' The cmdDelete_Click event handler on this Page is used to delete
        ' an announcement.  It  uses the DotNetNuke.AnnouncementsDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If Not Null.IsNull(itemId) Then
                    Dim objAnnouncements As New AnnouncementsController
                    objAnnouncements.DeleteAnnouncement(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
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
        '****************************************************************

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub EnableControls()
            If optExternal.Checked Then
                txtExternal.Enabled = True
                cboInternal.ClearSelection()
                cboInternal.Enabled = False
                cboFile.ClearSelection()
                cboFile.Enabled = False
            Else
                If optInternal.Checked Then
                    txtExternal.Text = ""
                    txtExternal.Enabled = False
                    cboInternal.Enabled = True
                    cboFile.ClearSelection()
                    cboFile.Enabled = False
                Else
                    txtExternal.Text = ""
                    txtExternal.Enabled = False
                    cboInternal.ClearSelection()
                    cboInternal.Enabled = False
                    cboFile.Enabled = True
                End If
            End If
        End Sub

        Private Sub Syndicate()
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                'Dim objAnnouncements As New AnnouncementsController
                'Dim dr As IDataReader = CType(objAnnouncements.GetAnnouncements(ModuleId), IDataReader)

                'should use business logic here, but quick fix for now !
                Dim dr As IDataReader = DataProvider.Instance().GetAnnouncements(ModuleId)
                CreateRSS(dr, "Title", "URL", "CreatedDate", "Syndicate", GetPortalDomainName(_portalSettings.PortalAlias, Request), Request.MapPath(_portalSettings.UploadDirectory) & ModuleConfiguration.ModuleTitle & ".rss")
                dr.Close()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdSyndicate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSyndicate.Click
            Try
                Syndicate()

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub chkLog_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLog.CheckedChanged
            Try

                If chkLog.Checked Then
                    Dim objClick As New ClickLogController
                    grdLog.DataSource = objClick.GetClicks("Announcements", itemId)
                    grdLog.DataBind()

                    grdLog.Visible = True
                Else
                    grdLog.Visible = False
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace