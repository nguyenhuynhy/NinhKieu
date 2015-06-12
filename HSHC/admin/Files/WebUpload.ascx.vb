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

Imports PortalQH.Installer
Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO

Namespace PortalQH

    Public Class WebUpload
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lblRootType As System.Web.UI.WebControls.Label
        Protected WithEvents lblRootFolder As System.Web.UI.WebControls.Label
        Protected WithEvents optFileType As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents cmdBrowse As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents lstFiles As System.Web.UI.WebControls.ListBox
        Protected WithEvents cmdAdd As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdRemove As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkUnzip As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

        Public Shared arrFiles As ArrayList = New ArrayList
        Public Shared arrTypes As ArrayList = New ArrayList
        Protected WithEvents phPaLogs As System.Web.UI.WebControls.PlaceHolder
        Protected WithEvents tblUpload As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblLogs As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents cmdReturn As System.Web.UI.WebControls.LinkButton

        Private FileType As String = "F" ' content files

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

                If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    lblRootType.Text = "Host Root:"
                    lblRootFolder.Text = Request.MapPath(Global.HostPath)
                Else
                    lblRootType.Text = "Portal Root:"
                    lblRootFolder.Text = Request.MapPath(PortalSettings.UploadDirectory)
                End If

                Dim objModules As New ModuleController
                Dim intModuleId As Integer = objModules.GetSiteModule("File Manager", PortalId)
                Dim settings As Hashtable = PortalSettings.GetModuleSettings(intModuleId)
                Dim UploadRoles As String = ""
                If Not CType(settings("uploadroles"), String) Is Nothing Then
                    UploadRoles = CType(settings("uploadroles"), String)
                End If

                If PortalSecurity.IsInRole(PortalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(UploadRoles) = False Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

                If Not Page.IsPostBack Then
                    arrFiles.Clear()
                    arrTypes.Clear()

                    optFileType.Items.Add(New ListItem("Content Files", "F"))
                    chkUnzip.Checked = False

                    Select Case Convert.ToString(PortalSettings.HostSettings("SkinUpload"))
                        Case "G" ' host
                            If Context.User.Identity.Name = PortalSettings.SuperUserId.ToString Then
                                optFileType.Items.Add(New ListItem("Skin Package", "S"))
                                optFileType.Items.Add(New ListItem("Container Package", "C"))
                            End If
                        Case "", "L" ' portal
                            If PortalSecurity.IsInRole(PortalSettings.AdministratorRoleId.ToString) = True Then
                                optFileType.Items.Add(New ListItem("Skin Package", "S"))
                                optFileType.Items.Add(New ListItem("Container Package", "C"))
                            End If
                    End Select
                    If Context.User.Identity.Name = PortalSettings.SuperUserId.ToString Then
                        optFileType.Items.Add(New ListItem("Custom Module", "M"))
                    End If

                    If Not (Request.Params("filetype") Is Nothing) Then
                        FileType = Request.Params("filetype")
                    End If

                    optFileType.Items.FindByValue(FileType).Selected = True
                    If FileType <> "F" Then
                        chkUnzip.Enabled = False
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Try
                If Page.IsPostBack Then
                    If cmdBrowse.PostedFile.FileName <> "" Then
                        arrFiles.Add(cmdBrowse)
                        arrTypes.Add(optFileType.SelectedItem.Value)
                        lstFiles.Items.Add(optFileType.SelectedItem.Text & " - " & cmdBrowse.PostedFile.FileName)
                    End If
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
            Try
                If Not lstFiles.SelectedItem Is Nothing Then
                    arrFiles.RemoveAt(lstFiles.SelectedIndex)
                    arrTypes.RemoveAt(lstFiles.SelectedIndex)
                    lstFiles.Items.Remove(lstFiles.SelectedItem.Text)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
            Try
                Dim strFileName As String
                Dim strFileNamePath As String
                Dim strExtension As String = ""
                Dim strMessage As String = ""

                Dim objHtmlInputFile As System.Web.UI.HtmlControls.HtmlInputFile
                Dim intItem As Integer

                For intItem = 0 To arrFiles.Count - 1
                    objHtmlInputFile = CType(arrFiles(intItem), HtmlInputFile)

                    strFileName = System.IO.Path.GetFileName(objHtmlInputFile.PostedFile.FileName)
                    strExtension = Path.GetExtension(strFileName)

                    Select Case arrTypes(intItem)
                        Case "F" ' content files
                            strMessage += UploadFiles(lblRootFolder.Text, objHtmlInputFile.PostedFile)
                        Case "S" ' skin package
                            If strExtension.ToLower = ".zip" Then
                                Dim objSkins As New SkinController
                                Dim objSkin As SkinInfo
                                strMessage += objSkins.UploadSkin(lblRootFolder.Text, objSkin.RootSkin, objHtmlInputFile.PostedFile)
                            Else
                                strMessage += "Invalid File Extension For Skin Package " & strFileName
                            End If
                        Case "C" ' container package
                            If strExtension.ToLower = ".zip" Then
                                Dim objSkins As New SkinController
                                Dim objSkin As SkinInfo
                                strMessage += objSkins.UploadSkin(lblRootFolder.Text, objSkin.RootContainer, objHtmlInputFile.PostedFile)
                            Else
                                strMessage += "Invalid File Extension For Container Package " & strFileName
                            End If
                        Case "M" ' custom module
                            If strExtension.ToLower = ".zip" Then
                                phPaLogs.Visible = True
                                Dim pa As New PaInstaller(CType(objHtmlInputFile.PostedFile.InputStream, Stream), Request.MapPath("."))

                                pa.Install()

                                phPaLogs.Controls.Add(PaLogsToTable(pa.InstallerInfo.Log.Logs))
                            Else
                                strMessage += "Invalid File Extension For Custom Module " & strFileName
                            End If
                    End Select
                Next

                If phPaLogs.Controls.Count > 0 Then
                    tblUpload.Visible = False
                    tblLogs.Visible = True
                ElseIf strMessage = "" Then
                    Response.Redirect(NavigateURL(), True)
                Else
                    lblMessage.Text = strMessage
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Function UploadFiles(ByVal RootPath As String, ByVal objHtmlInputFile As HttpPostedFile) As String

            Dim objPortalController As New PortalController
            Dim strMessage As String

            Dim strFileName As String = RootPath & Path.GetFileName(objHtmlInputFile.FileName)
            Dim strExtension As String = Replace(Path.GetExtension(strFileName), ".", "")

            If ((((objPortalController.GetPortalSpaceUsed(PortalId) + objHtmlInputFile.ContentLength) / 1000000) <= PortalSettings.HostSpace) Or PortalSettings.HostSpace = 0) Or (PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId) Then

                If InStr(1, "," & PortalSettings.HostSettings("FileExtensions").ToString.ToUpper, "," & strExtension.ToUpper) <> 0 Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    'Save Uploaded file to server
                    Try
                        If File.Exists(strFileName) Then
                            File.SetAttributes(strFileName, FileAttributes.Normal)
                            File.Delete(strFileName)
                        End If

                        objHtmlInputFile.SaveAs(strFileName)

                        If Path.GetExtension(strFileName) = ".zip" And chkUnzip.Checked = True Then
                            strMessage += UnzipFiles(strFileName, RootPath)
                        Else
                            AddFile(strFileName, strExtension, objHtmlInputFile.ContentType)
                        End If
                    Catch
                        ' save error - can happen if the security settings are incorrect
                        strMessage += "<br>An Error Has Occurred When Attempting To Save The File " & strFileName & ". Please Contact Your Hosting Provider To Ensure The Appropriate Security Settings Have Been Enabled On The Server."
                    End Try
                Else
                    ' restricted file type
                    strMessage += "<br>The File " & strFileName & " Is A Restricted File Type. Valid File Types Include ( *." & Replace(PortalSettings.HostSettings("FileExtensions").ToString, ",", ", *.") & " ). Please Contact Your Hosting Provider If You Need To Upload A File Type Which Is Not Supported."
                End If
            Else ' file too large
                strMessage += "<br>The File " & strFileName & " Exceeds The Amount Of Disk Space You Currently Have Available. Please Contact Your Hosting Provider For Inquiries Related To Increasing Your Portal Disk Space."
            End If

            Return strMessage
        End Function

        Private Function UnzipFiles(ByVal strZIPFile As String, ByVal RootPath As String) As String

            Dim objPortalController As New PortalController

            ' save zip file name
            Dim strMessage As String = ""
            Dim strFileName As String
            Dim strExtension As String

            Dim objZipEntry As ZipEntry
            Dim objZipInputStream As New ZipInputStream(File.OpenRead(strZIPFile))

            objZipEntry = objZipInputStream.GetNextEntry
            While Not objZipEntry Is Nothing
                If ((((objPortalController.GetPortalSpaceUsed(PortalId) + objZipEntry.Size) / 1000000) <= PortalSettings.HostSpace) Or PortalSettings.HostSpace = 0) Or (PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId) Then
                    strFileName = Path.GetFileName(objZipEntry.Name)

                    If strFileName <> "" Then
                        strFileName = RootPath & strFileName

                        strExtension = Path.GetExtension(strFileName).Replace(".", "")

                        If InStr(1, "," & PortalSettings.HostSettings("FileExtensions").ToString, "," & strExtension) <> 0 Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                            If File.Exists(strFileName) Then
                                File.SetAttributes(strFileName, FileAttributes.Normal)
                                File.Delete(strFileName)
                            End If
                            Dim objFileStream As FileStream = File.Create(strFileName)

                            Dim intSize As Integer = 2048
                            Dim arrData(2048) As Byte

                            intSize = objZipInputStream.Read(arrData, 0, arrData.Length)
                            While intSize > 0
                                objFileStream.Write(arrData, 0, intSize)
                                intSize = objZipInputStream.Read(arrData, 0, arrData.Length)
                            End While

                            objFileStream.Close()

                            AddFile(strFileName, strExtension)
                        Else
                            ' restricted file type
                            strMessage += "<br>The File " & strFileName & " Is A Restricted File Type. Valid File Types Include ( *." & Replace(PortalSettings.HostSettings("FileExtensions").ToString, ",", ", *.") & " ). Please Contact Your Hosting Provider If You Need To Upload A File Type Which Is Not Supported."
                        End If
                    End If
                Else ' file too large
                    strMessage += "<br>The File " & strFileName & " Exceeds The Amount Of Disk Space You Currently Have Available. Please Contact Your Hosting Provider For Inquiries Related To Increasing Your Portal Disk Space."
                End If

                objZipEntry = objZipInputStream.GetNextEntry
            End While
            objZipInputStream.Close()

            ' delete the zip file
            File.Delete(strZIPFile)

            Return strMessage
        End Function

        Private Sub AddFile(ByVal strFileNamePath As String, ByVal strExtension As String, Optional ByVal strContentType As String = "")

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim strFileName As String = Path.GetFileName(strFileNamePath)

            If strContentType = "" Then
                Select Case strExtension
                    Case "txt" : strContentType = "text/plain"
                    Case "htm", "html" : strContentType = "text/html"
                    Case "rtf" : strContentType = "text/richtext"
                    Case "jpg", "jpeg" : strContentType = "image/jpeg"
                    Case "gif" : strContentType = "image/gif"
                    Case "bmp" : strContentType = "image/bmp"
                    Case "mpg", "mpeg" : strContentType = "video/mpeg"
                    Case "avi" : strContentType = "video/avi"
                    Case "pdf" : strContentType = "application/pdf"
                    Case "doc", "dot" : strContentType = "application/msword"
                    Case "csv", "xls", "xlt" : strContentType = "application/x-msexcel"
                    Case Else : strContentType = "application/octet-stream"
                End Select
            End If

            Dim imgImage As System.Drawing.Image
            Dim strWidth As String = ""
            Dim strHeight As String = ""

            If Convert.ToBoolean(InStr(1, glbImageFileTypes & ",", strExtension & ",")) Then
                Try
                    imgImage = imgImage.FromFile(strFileNamePath)
                    strHeight = imgImage.Height.ToString
                    strWidth = imgImage.Width.ToString
                    imgImage.Dispose()
                Catch
                    ' error loading image file
                    strContentType = "application/octet-stream"
                End Try
            End If

            Dim objFiles As New FileController

            If _portalSettings.ActiveTab.ParentId = _portalSettings.SuperTabId Then
                objFiles.AddFile(-1, strFileName, strExtension, FileLen(strFileNamePath).ToString, strWidth, strHeight, strContentType)
            Else
                objFiles.AddFile(PortalId, strFileName, strExtension, FileLen(strFileNamePath).ToString, strWidth, strHeight, strContentType)
            End If

        End Sub

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Function PaLogsToTable(ByVal Source As ArrayList) As HtmlTable
            Dim arrayTable As New HtmlTable

            Dim LogEntry As PaLogEntry

            For Each LogEntry In Source
                Dim tr As New HtmlTableRow
                Dim tdType As New HtmlTableCell
                tdType.InnerText = LogEntry.Type.ToString
                Dim tdTime As New HtmlTableCell
                'tdTime.Attributes.Add("NoWrap", "true")
                tdTime.InnerHtml = "&nbsp;&nbsp;"  'LogEntry.Time.ToString
                Dim tdDescription As New HtmlTableCell
                tdDescription.InnerText = LogEntry.Description
                tr.Cells.Add(tdType)
                tr.Cells.Add(tdTime)
                tr.Cells.Add(tdDescription)
                Select Case LogEntry.Type
                    Case PaLogType.Failure, PaLogType.Warning
                        tr.Attributes.Add("class", "NormalRed")
                    Case PaLogType.StartJob, PaLogType.EndJob
                        tr.Attributes.Add("class", "NormalBold")
                End Select
                arrayTable.Rows.Add(tr)
            Next

            Return arrayTable
        End Function

        Private Sub cmdReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReturn.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub optFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optFileType.SelectedIndexChanged
            chkUnzip.Checked = False
            If optFileType.SelectedItem.Value = "F" Then
                chkUnzip.Enabled = True
            Else
                chkUnzip.Enabled = False
            End If
        End Sub
    End Class

End Namespace
