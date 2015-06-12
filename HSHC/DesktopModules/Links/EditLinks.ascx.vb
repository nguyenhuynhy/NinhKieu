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

Namespace PortalQH

    Public Class EditLinks
        Inherits PortalQH.PortalModuleControl

        ' module options
        Protected WithEvents optControl As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents optView As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents optInfo As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents cmdUpdateOptions As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancelOptions As System.Web.UI.WebControls.LinkButton
        Protected WithEvents pnlOptions As System.Web.UI.WebControls.Panel
        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents valTitle As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents optExternal As System.Web.UI.WebControls.RadioButton
        Protected WithEvents txtExternal As System.Web.UI.WebControls.TextBox
        Protected WithEvents optInternal As System.Web.UI.WebControls.RadioButton
        Protected WithEvents cboInternal As System.Web.UI.WebControls.DropDownList
        Protected WithEvents optFile As System.Web.UI.WebControls.RadioButton
        Protected WithEvents cboFiles As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtViewOrder As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNewWindow As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblCreatedBy As System.Web.UI.WebControls.Label
        Protected WithEvents lblCreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents pnlAudit As System.Web.UI.WebControls.Panel
        Protected WithEvents lblClicks As System.Web.UI.WebControls.Label
        Protected WithEvents chkLog As System.Web.UI.WebControls.CheckBox
        Protected WithEvents grdLog As System.Web.UI.WebControls.DataGrid
        Protected WithEvents pnlContent As System.Web.UI.WebControls.Panel
        Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents valViewOrder As System.Web.UI.WebControls.RegularExpressionValidator


        Private itemId As Integer = -1

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
        ' The Page_Load event on this Page is used to obtain the
        ' ItemId of the link to edit.
        '
        ' It then uses the DotNetNuke.LinkDB() data component
        ' to populate the page's edit controls with the links details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objModules As New ModuleController

                ' Determine ItemId of Link to Update
                If Not (Request.Params("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.Params("ItemId"))
                End If

                If optExternal.Checked = False And optInternal.Checked = False And optFile.Checked = False Then
                    optExternal.Checked = True
                End If

                EnableControls()

                ' If the page is being requested the first time, determine if an
                ' link itemId value is specified, and if so populate page
                ' contents with the link details
                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    cboInternal.DataSource = GetPortalTabs(PortalSettings.DesktopTabs, True, True)
                    cboInternal.DataBind()

                    ' load the list of files found in the upload directory
                    Dim FileList As ArrayList = GetFileList(PortalId)
                    cboFiles.DataSource = FileList
                    cboFiles.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    If itemId <> -1 Then

                        ' Obtain a single row of link information
                        Dim objLinks As New LinkController
                        Dim objLink As LinkInfo = objLinks.GetLink(itemId, ModuleId)

                        If Not objLink Is Nothing Then
                            If InStr(1, objLink.Url.ToString, "://") = 0 Then
                                If IsNumeric(objLink.Url.ToString) Then
                                    optExternal.Checked = False
                                    optInternal.Checked = True
                                    optFile.Checked = False
                                    EnableControls()
                                    If Not cboInternal.Items.FindByValue(objLink.Url.ToString) Is Nothing Then
                                        cboInternal.Items.FindByValue(objLink.Url.ToString).Selected = True
                                    End If
                                Else ' file
                                    optExternal.Checked = False
                                    optInternal.Checked = False
                                    optFile.Checked = True
                                    EnableControls()
                                    If Not cboFiles.Items.FindByValue(objLink.Url.ToString) Is Nothing Then
                                        cboFiles.Items.FindByValue(objLink.Url.ToString).Selected = True
                                    End If
                                End If
                            Else ' external
                                optExternal.Checked = True
                                optInternal.Checked = False
                                optFile.Checked = False
                                EnableControls()
                                txtExternal.Text = objLink.Url.ToString
                            End If

                            txtTitle.Text = objLink.Title.ToString
                            txtDescription.Text = objLink.Description.ToString
                            If (Null.IsNull(objLink.ViewOrder) = False) Then
                                txtViewOrder.Text = Convert.ToString(objLink.ViewOrder)
                            End If
                            chkNewWindow.Checked = objLink.NewWindow
                            lblClicks.Text = objLink.Clicks.ToString

                            lblCreatedBy.Text = objLink.CreatedByUser.ToString
                            lblCreatedDate.Text = objLink.CreatedDate.ToString

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
        ' create or update a link.  It  uses the DotNetNuke.LinkDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                Dim strLink As String

                If optExternal.Checked = True Then
                    strLink = AddHTTP(txtExternal.Text)
                Else
                    If optInternal.Checked = True Then
                        strLink = cboInternal.SelectedItem.Value
                    Else
                        strLink = cboFiles.SelectedItem.Value
                    End If
                End If

                If Page.IsValid = True And strLink <> "" Then

                    Dim objLink As New LinkInfo

                    objLink = CType(CBO.InitializeObject(objLink, GetType(LinkInfo)), LinkInfo)

                    'bind text values to object
                    objLink.ItemId = itemId
                    objLink.ModuleId = ModuleId
                    objLink.CreatedByUser = Context.User.Identity.Name
                    objLink.Title = txtTitle.Text
                    objLink.Url = strLink
                    objLink.MobileUrl = Null.NullString
                    If (txtViewOrder.Text.Length > 0) Then
                        objLink.ViewOrder = Convert.ToInt32(txtViewOrder.Text)
                    End If
                    objLink.Description = txtDescription.Text
                    objLink.NewWindow = chkNewWindow.Checked

                    ' Create an instance of the Link DB component
                    Dim objLinks As New LinkController

                    If Null.IsNull(itemId) Then
                        objLinks.AddLink(objLink)
                    Else
                        objLinks.UpdateLink(objLink)
                    End If

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
        ' a link.  It  uses the DotNetNuke.LinksDB()
        ' data component to encapsulate all data functionality.
        '
        '****************************************************************

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If itemId <> -1 Then

                    Dim links As New LinkController
                    links.DeleteLink(itemId)

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
        '****************************************************************'

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
                cboFiles.ClearSelection()
                cboFiles.Enabled = False
            Else
                If optInternal.Checked Then
                    txtExternal.Text = ""
                    txtExternal.Enabled = False
                    cboInternal.Enabled = True
                    cboFiles.ClearSelection()
                    cboFiles.Enabled = False
                Else
                    txtExternal.Text = ""
                    txtExternal.Enabled = False
                    cboInternal.ClearSelection()
                    cboInternal.Enabled = False
                    cboFiles.Enabled = True
                End If
            End If
        End Sub

        Private Sub chkLog_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLog.CheckedChanged
            Try
                If chkLog.Checked Then
                    Dim objClick As New ClickLogController
                    grdLog.DataSource = objClick.GetClicks("Links", itemId)
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
