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
Imports System.Threading
Imports System.Web.Mail

Namespace PortalQH

    Public MustInherit Class BulkEmail
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents chkRoles As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboPriority As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
        Protected WithEvents optView As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents pnlBasicTextBox As System.Web.UI.WebControls.Panel
        Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
        Protected WithEvents pnlRichTextBox As System.Web.UI.WebControls.Panel
        Protected WithEvents ftbDesktopText As FreeTextBoxControls.FreeTextBox
        Protected WithEvents cboAttachment As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cboSendMethod As System.Web.UI.WebControls.DropDownList
        Protected WithEvents optSendAction As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents btnSend As System.Web.UI.WebControls.LinkButton

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

                If Not Page.IsPostBack Then
                    Dim objRoleController As New RoleController
                    chkRoles.DataSource = objRoleController.GetPortalRoles(PortalId)
                    chkRoles.DataBind()

                    Dim FileList As ArrayList
                    FileList = GetFileList(PortalId)
                    cboAttachment.DataSource = FileList
                    cboAttachment.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")
                Else
                    If optView.SelectedItem.Value = "B" Then
                        pnlBasicTextBox.Visible = True
                        pnlRichTextBox.Visible = False
                    Else
                        pnlBasicTextBox.Visible = False
                        pnlRichTextBox.Visible = True
                        ftbDesktopText.ImageGalleryPath = PortalSettings.UploadDirectory.Substring(PortalSettings.UploadDirectory.IndexOf("/Portals/"))
                        ftbDesktopText.HelperFilesParameters = "tabid=" & TabId
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Try
                Dim objRecipients As New ArrayList

                ' load all user emails based on roles selected
                Dim objUsers As New UserController
                Dim objRole As ListItem
                Dim arrUsers As ArrayList
                For Each objRole In chkRoles.Items
                    If objRole.Selected Then
                        arrUsers = objUsers.GetRoleMembership(PortalId, Integer.Parse(objRole.Value))
                        Dim objUser As UserRoleInfo
                        For Each objUser In arrUsers
                            objRecipients.Add(New ListItem(objUser.Email, objUser.FullName))
                        Next
                    End If
                Next

                ' load emails specified in email distribution list
                If txtEmail.Text <> "" Then
                    Dim arrEmail As Array = Split(txtEmail.Text, ";")
                    Dim strEmail As String
                    For Each strEmail In arrEmail
                        objRecipients.Add(New ListItem(strEmail, strEmail))
                    Next
                End If

                ' create object
                Dim objSendBulkEMail As New SendBulkEMail

                objSendBulkEMail.Recipients = objRecipients
                Select Case cboPriority.SelectedItem.Value
                    Case "1"
                        objSendBulkEMail.Priority = MailPriority.High
                    Case "2"
                        objSendBulkEMail.Priority = MailPriority.Normal
                    Case "3"
                        objSendBulkEMail.Priority = MailPriority.Low
                End Select
                objSendBulkEMail.Subject = txtSubject.Text
                If optView.SelectedItem.Value = "B" Then
                    objSendBulkEMail.BodyFormat = MailFormat.Text
                    objSendBulkEMail.Body = txtMessage.Text
                Else
                    objSendBulkEMail.BodyFormat = MailFormat.Html
                    objSendBulkEMail.Body = ftbDesktopText.Text
                End If
                If cboAttachment.SelectedItem.Value <> "" Then
                    objSendBulkEMail.Attachment = (Request.MapPath(PortalSettings.UploadDirectory) & cboAttachment.SelectedItem.Value)
                End If
                objSendBulkEMail.SendMethod = cboSendMethod.SelectedItem.Value
                objSendBulkEMail.SMTPServer = Convert.ToString(PortalSettings.HostSettings("SMTPServer"))
                objSendBulkEMail.SMTPUsername = Convert.ToString(PortalSettings.HostSettings("SMTPUsername"))
                objSendBulkEMail.SMTPPassword = Convert.ToString(PortalSettings.HostSettings("SMTPPassword"))
                objSendBulkEMail.Administrator = PortalSettings.Email

                ' send mail
                If optSendAction.SelectedItem.Value = "S" Then
                    objSendBulkEMail.Send()
                Else ' ansynchronous uses threading
                    Dim objThread As New Thread(AddressOf objSendBulkEMail.Send)
                    objThread.Start()
                End If

                ' completed
                Skin.AddModuleMessage(Me, "Your Message(s) Have Been Sent.", Skins.ModuleMessage.ModuleMessageType.GreenSuccess)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub optView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optView.SelectedIndexChanged
            Try
                If optView.SelectedItem.Value = "B" Then
                    txtMessage.Text = ftbDesktopText.Text
                Else
                    ftbDesktopText.Text = txtMessage.Text
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

    Public Class SendBulkEMail

        Inherits PortalQH.PortalModuleControl

        Public Recipients As ArrayList
        Public Priority As MailPriority
        Public Subject As String
        Public BodyFormat As MailFormat
        Public Body As String
        Public Attachment As String
        Public SendMethod As String
        Public SMTPServer As String
        Public SMTPUsername As String
        Public SMTPPassword As String
        Public Administrator As String

        Public Sub Send()
            Try

                Dim strConfirmation As String
                strConfirmation = "Bulk Email Operation Started: " & Now().ToString & vbCrLf & vbCrLf

                ' send to recipients
                Dim strBody As String
                Dim intRecipients As Integer = 0
                Dim intMessages As Integer = 0
                Dim strDistributionList As String = ""
                Dim objRecipient As ListItem

                Select Case SendMethod
                    Case "TO"
                        For Each objRecipient In Recipients
                            If objRecipient.Text <> "" Then
                                intRecipients += 1
                                strBody = "Dear " & objRecipient.Value & "," & vbCrLf & vbCrLf & Body
                                SendMail(Administrator, objRecipient.Text, "", "", Priority, Subject, BodyFormat, System.Text.Encoding.Default, strBody, Attachment, SMTPServer, SMTPUsername, SMTPPassword)
                                intMessages += 1
                            End If
                        Next
                    Case "BCC"
                        For Each objRecipient In Recipients
                            If objRecipient.Text <> "" Then
                                intRecipients += 1
                                strDistributionList += "; " & objRecipient.Text
                            End If
                        Next
                        intMessages = 1
                        strBody = Body
                        SendMail(Administrator, "", "", strDistributionList, Priority, Subject, BodyFormat, System.Text.Encoding.Default, strBody, Attachment, SMTPServer, SMTPUsername, SMTPPassword)
                End Select

                ' send confirmation
                strConfirmation += "Email Recipients: " & intRecipients.ToString() & vbCrLf
                strConfirmation += "Email Messages: " & intMessages.ToString() & vbCrLf & vbCrLf
                strConfirmation += "Bulk Email Operation Completed: " & Now().ToString & vbCrLf
                SendMail(Administrator, Administrator, "", "", Priority, "Bulk Email Confirmation", BodyFormat, System.Text.Encoding.Default, strConfirmation, "", SMTPServer, SMTPUsername, SMTPPassword)

            Catch exc As Exception
                ' send mail failure
            End Try

        End Sub

    End Class

End Namespace
