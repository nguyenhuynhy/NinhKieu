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

Imports FreeTextBoxControls

Namespace PortalQH

    Public Class EditHtml
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents optView As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents pnlBasicTextBox As System.Web.UI.WebControls.Panel

        Protected WithEvents pnlRichTextBox As System.Web.UI.WebControls.Panel
        Protected WithEvents txtDesktopHTML As System.Web.UI.WebControls.TextBox
        Protected WithEvents optRender As System.Web.UI.WebControls.RadioButtonList

        Protected WithEvents ftbDesktopText As FreeTextBoxControls.FreeTextBox

        Protected WithEvents txtMobileSummary As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMobileDetails As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdPreview As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblPreview As System.Web.UI.WebControls.Label

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
        ' of the xml module to edit.
        '
        ' It then uses the PortalQH.HtmlTextDB() data component
        ' to populate the page's edit controls with the text details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Get settings from the database 
                Dim settings As Hashtable = PortalSettings.GetModuleSettings(ModuleId)

                Dim DesktopView As String = CType(settings("desktopview"), String)
                Dim LastDesktopView As String = DesktopView

                If optView.SelectedIndex <> -1 Then
                    DesktopView = optView.SelectedItem.Value
                    Dim objModules As New ModuleController
                    objModules.UpdateModuleSetting(ModuleId, "desktopview", DesktopView)
                End If

                If DesktopView <> "" Then
                    optView.Items.FindByValue(DesktopView).Selected = True
                Else
                    optView.SelectedIndex = 0
                End If

                Dim TextRender As String = CType(settings("textrender"), String)

                If optRender.SelectedIndex <> -1 Then
                    TextRender = optRender.SelectedItem.Value
                    Dim objModules As New ModuleController
                    objModules.UpdateModuleSetting(ModuleId, "textrender", TextRender)
                End If

                If TextRender <> "" Then
                    optRender.Items.FindByValue(TextRender).Selected = True
                Else
                    optRender.SelectedIndex = 0
                End If

                If optView.SelectedItem.Value = "B" Then
                    pnlBasicTextBox.Visible = True
                    pnlRichTextBox.Visible = False
                Else
                    pnlBasicTextBox.Visible = False
                    pnlRichTextBox.Visible = True
                    ftbDesktopText.ImageGalleryPath = PortalSettings.UploadDirectory.Substring(PortalSettings.UploadDirectory.IndexOf("/Portals/"))
                    ftbDesktopText.HelperFilesPath = "controls/ftb/"
                    ftbDesktopText.HelperFilesParameters = "tabid=" & TabId
                    ftbDesktopText.ButtonPath = "controls/ftb/images/"
                End If

                If Page.IsPostBack = False Then

                    ' Obtain a single row of text information
                    Dim objHTML As New HtmlTextController
                    Dim objText As HtmlTextInfo = objHTML.GetHtmlText(ModuleId)

                    If Not objText Is Nothing Then

                        ' this is a temp fix to deal with legacy conversions where the upload directory used a GUID
                        If Not PortalSettings.GUID.Length = 0 Then
                            objText.DeskTopHTML = objText.DeskTopHTML.Replace(PortalSettings.GUID.ToString, PortalSettings.PortalId.ToString)
                        End If

                        If optRender.SelectedItem.Value = "T" Then
                            txtDesktopHTML.Text = FormatText(CType(objText.DeskTopHTML, String))
                        Else
                            txtDesktopHTML.Text = Server.HtmlDecode(CType(objText.DeskTopHTML, String))
                        End If
                        ftbDesktopText.Text = Server.HtmlDecode(CType(objText.DeskTopHTML, String))
                        txtMobileSummary.Text = Server.HtmlDecode(CType(objText.MobileSummary, String))
                        txtMobileDetails.Text = Server.HtmlDecode(CType(objText.MobileDetails, String))

                    Else

                        ftbDesktopText.Text = "Add Content..."
                        txtDesktopHTML.Text = "Add Content..."
                        txtMobileSummary.Text = ""
                        txtMobileDetails.Text = ""

                    End If

                Else
                    If (LastDesktopView <> optView.SelectedItem.Value) And (Not LastDesktopView Is Nothing) Then
                        If optView.SelectedItem.Value = "B" Then
                            If optRender.SelectedItem.Value = "T" Then
                                txtDesktopHTML.Text = FormatText(ftbDesktopText.Text)
                            Else
                                txtDesktopHTML.Text = ftbDesktopText.Text
                            End If
                        Else
                            If optRender.SelectedItem.Value = "T" Then
                                ftbDesktopText.Text = FormatHTML(txtDesktopHTML.Text)
                            Else
                                ftbDesktopText.Text = txtDesktopHTML.Text
                            End If
                        End If
                    Else
                        If optView.SelectedItem.Value = "B" Then
                            If optRender.SelectedItem.Value = "T" Then
                                txtDesktopHTML.Text = FormatText(txtDesktopHTML.Text)
                            Else
                                txtDesktopHTML.Text = FormatHTML(txtDesktopHTML.Text)
                            End If
                        End If
                    End If
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        Private Function FormatText(ByVal strHTML As String) As String
            Try
                Dim strText As String = strHTML

                If strText <> "" Then
                    strText = Replace(strText, "<br>", ControlChars.Lf)
                    strText = Replace(strText, "<BR>", ControlChars.Lf)
                    strText = Server.HtmlDecode(strText)
                End If

                Return strText

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Function FormatHTML(ByVal strText As String) As String
            Try

                Dim strHTML As String = strText

                If strHTML <> "" Then
                    strHTML = Replace(strHTML, Chr(13), "")
                    strHTML = Replace(strHTML, ControlChars.Lf, "<br>")
                End If

                Return strHTML

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Function

        '****************************************************************
        '
        ' The cmdUpdate_Click event handler on this Page is used to save
        ' the text changes to the database.
        '
        '****************************************************************

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                Dim objHTML As New HtmlTextController

                Dim strDesktopHTML As String

                If pnlBasicTextBox.Visible Then
                    If optRender.SelectedItem.Value = "T" Then
                        strDesktopHTML = FormatHTML(txtDesktopHTML.Text)
                    Else
                        strDesktopHTML = txtDesktopHTML.Text
                    End If
                Else
                    strDesktopHTML = Server.HtmlEncode(ftbDesktopText.Text)
                End If

                ' Update the text within the HtmlText table
                objHTML.UpdateHtmlText(ModuleId, strDesktopHTML & " ", " ", " ")

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

        Private Sub cmdPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
            Try
                Dim strDesktopHTML As String

                If pnlBasicTextBox.Visible Then
                    strDesktopHTML = Server.HtmlEncode(txtDesktopHTML.Text)
                    If optRender.SelectedItem.Value = "T" Then
                        strDesktopHTML = Replace(strDesktopHTML, ControlChars.Lf, "<br>")
                    End If
                Else
                    strDesktopHTML = Server.HtmlEncode(ftbDesktopText.Text)
                End If

                lblPreview.Text = ManageUploadDirectory(Server.HtmlDecode(strDesktopHTML), PortalSettings.UploadDirectory)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace