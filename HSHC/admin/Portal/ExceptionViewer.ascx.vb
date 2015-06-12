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

Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO

Namespace PortalQH

    Public Class ExceptionsViewer

        Inherits PortalQH.PortalModuleControl

        Protected phExceptions As System.Web.UI.WebControls.PlaceHolder
        Protected WithEvents txtEmailAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
        Protected WithEvents emailExceptions As System.Web.UI.WebControls.Panel
        Protected WithEvents txtServerSendDNNEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtServerSendDNNMessage As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnServerSendToDNN As System.Web.UI.HtmlControls.HtmlAnchor
        Protected WithEvents pnlSendEmail As System.Web.UI.WebControls.Panel
        Protected WithEvents pnlSendServer As System.Web.UI.WebControls.Panel
        Protected WithEvents btnEmail As System.Web.UI.HtmlControls.HtmlAnchor
        Protected WithEvents ddlPortalID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents pnlPortalID As System.Web.UI.WebControls.Panel
        Protected WithEvents btnDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnClear As System.Web.UI.WebControls.LinkButton
        Protected WithEvents pnlSendExceptions As System.Web.UI.WebControls.Panel

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
        ' The Page_Load server event handler on this user control is used
        ' to populate the current site settings from the config system
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
                Dim objPortalSecurity As New PortalSecurity

                ' If this is the first visit to the page, populate the site data
                If Page.IsPostBack = False Then
                    BindPortalDropDown()
                    BindData()
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub
        Private Sub BindPortalDropDown()
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim objPortalSecurity As New PortalSecurity

            If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                Dim objPortalController As New PortalController
                Dim arrPortals As New ArrayList
                arrPortals = objPortalController.GetPortals()
                ddlPortalID.DataTextField = "PortalName"
                ddlPortalID.DataValueField = "PortalID"
                ddlPortalID.DataSource = arrPortals
                ddlPortalID.DataBind()
                Dim ddlAllPortals As New ListItem("All", "-1")
                ddlPortalID.Items.Insert(0, ddlAllPortals)
            ElseIf objPortalSecurity.IsInRoles(Me.ModuleConfiguration.AuthorizedViewRoles) Then
                pnlPortalID.Visible = False
                ddlPortalID.Visible = False
            Else
                Response.Redirect(NavigateURL("Edit Access Denied"), True)
            End If
        End Sub
        Private Sub BindData()
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim strPortalID As String
            If Context.User.Identity.Name = _portalSettings.SuperUserId Then
                strPortalID = ddlPortalID.SelectedItem.Value
            Else
                strPortalID = PortalId.ToString
            End If

            pnlSendEmail.Visible = True
            pnlSendServer.Visible = True

            Dim Publisher As String
            For Each Publisher In GetLogFilePaths()
                If System.IO.File.Exists(Server.MapPath(Publisher)) Then
                    Dim ctrlXML As New System.Web.UI.WebControls.Xml
                    Dim tal As New Xsl.XsltArgumentList
                    tal.AddParam("LogFileName", "", Publisher)
                    tal.AddParam("PortalID", "", strPortalID)
                    ctrlXML.TransformArgumentList = tal
                    ctrlXML.DocumentSource = Publisher
                    ctrlXML.TransformSource = CType(Global.ApplicationPath, String) + "/Admin/Portal/Exceptions.xslt"
                    ctrlXML.DataBind()
                    phExceptions.Controls.Add(ctrlXML)
                Else
                    ddlPortalID.Visible = False
                    btnDelete.Visible = False
                    btnClear.Visible = False
                    pnlSendExceptions.Visible = False
                    pnlSendEmail.Visible = False
                    pnlSendServer.Visible = False
                    pnlPortalID.Visible = False
                    phExceptions.Controls.Add(New LiteralControl("<font class=""Normal"">File doesn't exist: <b>" + Server.MapPath(Publisher) + "</b>.  This can happen when no exeptions have been logged or if the log file is inaccessible due to permissions.</font>"))
                End If
            Next
        End Sub

        Private Function GetLogFilePaths() As ArrayList
            Dim myArr As New ArrayList

            Dim xmlWebConfig As New XmlDocument
            xmlWebConfig.Load(Server.MapPath("Web.config"))
            Dim nlPublishers As XmlNodeList
            nlPublishers = xmlWebConfig.DocumentElement.SelectNodes("exceptionManagement/publisher")
            Dim elPublisher As XmlElement
            For Each elPublisher In nlPublishers
                If elPublisher.Attributes("type").Value = "PortalQH.XMLExceptionPublisher" Then
                    myArr.Add(Trim(GetXMLFilePath(elPublisher.Attributes("fileName").Value)))
                End If
            Next
            Return myArr

        End Function
        Private Function GetXMLFilePath(ByVal strFile As String) As String
            Dim strFilePath As String
            strFilePath = strFile
            'check to see if they entered a filename or an absolute file path
            If strFilePath.LastIndexOf("\") = -1 And strFilePath.LastIndexOf("/") = -1 Then
                'Config settings specified a filename only, with no absolute path
                'Use the /Portals/_default/Logs directory to store the log file
                'This allows user to specify alternative location for
                'log files to be stored, othre than the DNN directory.
                strFilePath = Global.HostPath + "Logs\" + strFilePath
            End If
            Return strFilePath
        End Function

        Private Sub btnEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmail.ServerClick
            Try
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim strEmail As String = GetSelectedExceptions()
                Dim strFromEmailAddress As String
                Dim _userController As New UserController
                Dim _userInfo As UserInfo
                _userInfo = _userController.GetUser(_portalSettings.PortalId, CType(HttpContext.Current.User.Identity.Name, String))
                If _userInfo.Email <> "" Then
                    strFromEmailAddress = _userInfo.Email
                Else
                    strFromEmailAddress = _portalSettings.Email
                End If
                Dim ReturnMsg As String = SendNotification(strFromEmailAddress, txtEmailAddress.Text, "", _portalSettings.PortalName & " Exceptions", Server.HtmlEncode(txtMessage.Text + vbCrLf + strEmail.ToString), "", "html")

                If ReturnMsg = "" Then
                    pnlSendEmail.Visible = False
                    phExceptions.Controls.Add(New LiteralControl("<font class=""Normal"">Your email has been sent.</font>"))
                Else
                    pnlSendExceptions.Visible = False
                    phExceptions.Controls.Add(New LiteralControl("<font class=""Normal"">Your email has <b>not</b> been sent.  " + ReturnMsg + "</font>"))
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Function GetSelectedExceptions() As String
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim strXMLOut As New System.Text.StringBuilder
            Dim s As String = Request.Form("Exception")
            If Not s Is Nothing Then

                Dim strPortalID As String
                If Context.User.Identity.Name = _portalSettings.SuperUserId Then
                    strPortalID = ddlPortalID.SelectedItem.Value
                Else
                    strPortalID = PortalId.ToString
                End If
                Dim arrExcPositions() As String
                If s.LastIndexOf(",") > 0 Then
                    arrExcPositions = s.Split(Convert.ToChar(","))
                ElseIf s.Length > 0 Then
                    ReDim arrExcPositions(0)
                    arrExcPositions(0) = s
                End If
                strXMLOut.Append("<exceptions>")
                Dim Publisher As String
                For Each Publisher In GetLogFilePaths()
                    If System.IO.File.Exists(Server.MapPath(Publisher)) Then
                        Dim xmlExceptionsDoc As New XmlDocument
                        xmlExceptionsDoc.Load(Server.MapPath(Publisher))


                        Dim i As Integer
                        For i = 0 To arrExcPositions.Length - 1
                            Dim excKey() As String
                            excKey = arrExcPositions(i).Split(Convert.ToChar("|"))
                            Dim exc As XmlElement
                            If Publisher = excKey(1) Then
                                If strPortalID = "-1" Then
                                    exc = CType(xmlExceptionsDoc.SelectSingleNode("exceptions/ExceptionInformation[position()=" + excKey(0) + "]/Exception"), XmlElement)
                                Else
                                    exc = CType(xmlExceptionsDoc.SelectSingleNode("exceptions/ExceptionInformation[Exception/@PortalID='" + strPortalID + "'][position()=" + excKey(0) + "]/Exception"), XmlElement)
                                End If

                                Dim submissionInfo As XmlElement
                                submissionInfo = xmlExceptionsDoc.CreateElement("SubmissionDetails")
                                Dim emailNode As XmlElement
                                emailNode = xmlExceptionsDoc.CreateElement("EmailAddress")
                                Dim emailInfo As XmlCDataSection = xmlExceptionsDoc.CreateCDataSection(txtServerSendDNNEmail.Text)
                                emailNode.AppendChild(emailInfo)
                                submissionInfo.AppendChild(emailNode)
                                Dim messageNode As XmlElement
                                messageNode = xmlExceptionsDoc.CreateElement("Comments")
                                Dim messageInfo As XmlCDataSection = xmlExceptionsDoc.CreateCDataSection(txtServerSendDNNMessage.Text)
                                messageNode.AppendChild(messageInfo)
                                submissionInfo.AppendChild(messageNode)
                                exc.AppendChild(submissionInfo)
                                strXMLOut.Append(exc.OuterXml)
                            End If
                        Next
                    End If
                Next
                strXMLOut.Append("</exceptions>")
            End If
            Return strXMLOut.ToString
        End Function
        Private Sub btnServerSendToDNN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServerSendToDNN.ServerClick
            Try
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim xmlInput As String
                xmlInput = GetSelectedExceptions()

                Dim RedirectURL As String

                ' Dim x As New PortalQH.WebServices.ExceptionsReceiver
                ' RedirectURL = x.SendExceptions(xmlInput)
                Try
                    Response.Redirect(RedirectURL, True)
                Catch exc As ArgumentNullException
                    ProcessModuleLoadException("The web service at PortalQH.com is currently unavailable.", Me, exc)
                End Try

            Catch exc As WebException
                ProcessModuleLoadException("The web service at PortalQH.com is currently unavailable.", Me, exc)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub ddlPortalID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPortalID.SelectedIndexChanged
            BindData()
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            DeleteSelectedExceptions()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Dim d As Boolean = False
                Dim Publisher As String
                For Each Publisher In GetLogFilePaths()
                    If System.IO.File.Exists(Server.MapPath(Publisher)) Then
                        File.Delete(Server.MapPath(Publisher))
                        d = True
                    End If
                Next
                If d Then
                    Skin.AddModuleMessage(Me, "Log successfully cleared.", Skins.ModuleMessage.ModuleMessageType.GreenSuccess)
                Else
                    Skin.AddModuleMessage(Me, "The log file was not cleared.  The log file may not exist.", Skins.ModuleMessage.ModuleMessageType.RedError)
                End If
                BindPortalDropDown()
                BindData()
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        Private Function DeleteSelectedExceptions() As String
            Try
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
                Dim strXMLOut As New System.Text.StringBuilder
                Dim s As String = Request.Form("Exception")
                If Not s Is Nothing Then
                    Dim strPortalID As String
                    If Context.User.Identity.Name = _portalSettings.SuperUserId Then
                        strPortalID = ddlPortalID.SelectedItem.Value
                    Else
                        strPortalID = PortalId.ToString
                    End If
                    Dim arrExcPositions() As String
                    If s.LastIndexOf(",") > 0 Then
                        arrExcPositions = s.Split(Convert.ToChar(","))
                    ElseIf s.Length > 0 Then
                        ReDim arrExcPositions(0)
                        arrExcPositions(0) = s
                    End If

                    Dim Publisher As String
                    For Each Publisher In GetLogFilePaths()
                        If System.IO.File.Exists(Server.MapPath(Publisher)) Then
                            Dim xmlExceptionsDoc As New XmlDocument
                            xmlExceptionsDoc.Load(Server.MapPath(Publisher))

                            Dim i As Integer
                            For i = 0 To arrExcPositions.Length - 1
                                Dim excKey() As String
                                excKey = arrExcPositions(i).Split(Convert.ToChar("|"))
                                Dim exc As XmlElement
                                If Publisher = excKey(1) Then
                                    If strPortalID = "-1" Then
                                        exc = CType(xmlExceptionsDoc.SelectSingleNode("exceptions/ExceptionInformation[position()=" + excKey(0) + "]"), XmlElement)
                                    Else
                                        exc = CType(xmlExceptionsDoc.SelectSingleNode("exceptions/ExceptionInformation[Exception/@PortalID='" + strPortalID + "'][position()=" + excKey(0) + "]"), XmlElement)
                                    End If
                                    exc.ParentNode.RemoveChild(exc)
                                    'xmlExceptionsDoc.DocumentElement.RemoveChild(exc)
                                End If
                            Next
                            xmlExceptionsDoc.Save(Server.MapPath(Publisher))
                        End If
                    Next

                End If
                Skin.AddModuleMessage(Me, "The selected exceptions were successfully deleted.", Skins.ModuleMessage.ModuleMessageType.GreenSuccess)
                BindPortalDropDown()
                BindData()
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function
    End Class

End Namespace