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
Imports System.IO
Imports System.Xml

Namespace PortalQH

    Public MustInherit Class SiteLog
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents cboReportType As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdStartCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdEndCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents valStartDate As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valEndDate As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents grdLog As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdDisplay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton

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
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' If this is the first visit to the page, bind the role data to the datalist
                If Page.IsPostBack = False Then

                    cmdStartCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtStartDate)
                    cmdEndCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtEndDate)

                    Select Case _portalSettings.SiteLogHistory
                        Case -1 ' unlimited
                        Case 0
                            Skin.AddModuleMessage(Me, "Your Hosting Provider Has Disabled the Site Log History Feature For Your Portal.", Skins.ModuleMessage.ModuleMessageType.YellowWarning)
                        Case Else
                            Skin.AddModuleMessage(Me, "Your Hosting Provider Has Limited Your Portal To " & _portalSettings.SiteLogHistory.ToString & " Days Of Site Log History.", Skins.ModuleMessage.ModuleMessageType.YellowWarning)
                    End Select

                    Dim objCode As New CodeController

                    cboReportType.DataSource = objCode.GetSiteLogReports
                    cboReportType.DataBind()
                    cboReportType.SelectedIndex = 0

                    txtStartDate.Text = DateAdd(DateInterval.Day, -6, Date.Today).ToShortDateString
                    txtEndDate.Text = DateAdd(DateInterval.Day, 1, Date.Today).ToShortDateString

                    ' Store URL Referrer to return to portal
                    If Not Request.UrlReferrer Is Nothing Then
                        ViewState("UrlReferrer") = Convert.ToString(Request.UrlReferrer)
                    Else
                        ViewState("UrlReferrer") = ""
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")))

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
            Try
                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub BindData()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim strPortalAlias As String

            strPortalAlias = GetPortalDomainName(PortalAlias, Request, False)
            If InStr(1, strPortalAlias, "/") <> 0 Then ' child portal
                strPortalAlias = Left(strPortalAlias, InStrRev(strPortalAlias, "/") - 1)
            End If

            Dim strStartDate As String = txtStartDate.Text
            If strStartDate <> "" Then
                strStartDate = strStartDate & " 00:00"
            End If

            Dim strEndDate As String = txtEndDate.Text
            If strEndDate <> "" Then
                strEndDate = strEndDate & " 23:59"
            End If

            Dim objSiteLog As New SiteLogController
            Dim dr As IDataReader = objSiteLog.GetSiteLog(PortalId, strPortalAlias, Convert.ToInt32(cboReportType.SelectedItem.Value), Convert.ToDateTime(strStartDate), Convert.ToDateTime(strEndDate))
            grdLog.DataSource = dr ' we are using a DataReader here because the resultset returned by GetSiteLog varies based on the report type selected and therefore does not conform to a static business object
            grdLog.DataBind()
            dr.Close()

        End Sub

    End Class

End Namespace
