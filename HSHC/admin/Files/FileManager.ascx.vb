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

Namespace PortalQH
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : FileManager
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Supplies the functionality for uploading files to the Portal
    ''' Synchronizing Files within the folder and the database
    ''' and Provides status of available disk space for the portal
    ''' as well as limiting uploads to the restricted allocated file space
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[DYNST]	2/1/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public MustInherit Class FileManager
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lblRootType As System.Web.UI.WebControls.Label
        Protected WithEvents lblRootFolder As System.Web.UI.WebControls.Label
        Protected WithEvents grdFiles As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblDiskSpace As System.Web.UI.WebControls.Label
        Protected WithEvents cmdSynchronize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkUploadRoles As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton

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

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Page_Load server event handler on this user control is used
        ''' to populate the current files from the appropriate PortalUpload Directory or the HostFolder
        ''' and binds this list to the Datagrid
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Page.IsPostBack = False Then

                    BindData()

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The BindData helper method is used to bind the list of
        ''' files for this portal or for the hostfolder, to an asp:DATAGRID server control
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub BindData()

            Dim SpaceUsed As Double

            Dim objPortal As New PortalController
            Dim objFiles As New FileController

            If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                lblRootType.Text = "Host Root:"
                lblRootFolder.Text = Request.MapPath(Global.HostPath)
            Else
                lblRootType.Text = "Portal Root:"
                lblRootFolder.Text = Request.MapPath(PortalSettings.UploadDirectory)
            End If

            Dim dr As IDataReader = objFiles.GetFiles(Convert.ToInt32(IIf(PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId, -1, PortalId)))
            grdFiles.DataSource = dr
            grdFiles.DataBind()
            dr.Close()

            If PortalSettings.ActiveTab.ParentId <> PortalSettings.SuperTabId Then
                SpaceUsed = objPortal.GetPortalSpaceUsed(PortalId) / 1000000
                If PortalSettings.HostSpace = 0 Then
                    lblDiskSpace.Text = "Disk Space ( Used: <b>" & Format(SpaceUsed, "#,##0.00") & " MB</b> )"
                Else
                    lblDiskSpace.Text = "Disk Space ( Capacity: <b>" & Format(PortalSettings.HostSpace, "#,##0.00") & " MB</b>  Used: <b>" & Format(SpaceUsed, "#,##0.00") & " MB</b>  Free: <b>" & Format(PortalSettings.HostSpace - SpaceUsed, "#,##0.00") & " MB</b> )"
                End If
            Else
                SpaceUsed = objPortal.GetPortalSpaceUsed(Null.NullInteger) / 1000000
                lblDiskSpace.Text = "Disk Space ( Used: <b>" & Format(SpaceUsed, "#,##0.00") & " MB</b> )"
            End If


            chkUploadRoles.Items.Clear()
            Dim settings As Hashtable = PortalSettings.GetModuleSettings(ModuleId)
            Dim UploadRoles As String = ""
            If Not CType(settings("uploadroles"), String) Is Nothing Then
                UploadRoles = CType(settings("uploadroles"), String)
            End If

            Dim objRoles As New RoleController

            Dim Arr As ArrayList = objRoles.GetPortalRoles(PortalId)
            Dim i As Integer
            For i = 0 To Arr.Count - 1

                Dim item As New ListItem
                Dim objRole As RoleInfo = CType(Arr(i), RoleInfo)
                item.Text = objRole.RoleName
                item.Value = objRole.RoleID.ToString

                If Convert.ToBoolean(InStr(1, UploadRoles, item.Value & ";")) Or Convert.ToBoolean(item.Value = PortalSettings.AdministratorRoleId.ToString) Then
                    item.Selected = True
                End If

                chkUploadRoles.Items.Add(item)

            Next

        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This event happens during the ItemCreated event of the Datagrid of files
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' add a onClick event attribute to the Delete link to return a Javascript confirmation prompting before deletion of files.
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub grdFiles_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdFiles.ItemCreated
            Try
                Dim cmdDelete As Control = e.Item.FindControl("cmdDelete")

                If Not cmdDelete Is Nothing Then
                    CType(cmdDelete, ImageButton).Attributes.Add("onClick", "javascript: return confirm('Are You Sure You Wish To Delete This Item ?')")
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This event happens on click of Synchronzise Files
        ''' Cycles through the file folder and compares the files to the existing records in the database.
        ''' if there are differences it updates, removes or adds the file information to the database.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        '''if the parent of the active tab is the host tab then allow file deletion, 
        '''and set the current working folder to the HostPath folder
        '''if the parent of the active tab is not the host tab, then restrict deletion to the portal upload folder 
        '''and set the current working folder to the Portal Upload directory for the portal
        '''do a check to make sure the folder exists and 
        '''if so loop through the selected folder and list the files within the folder
        '''using a extension filter to only allow files that match the extensions as listed in the site settings for that portal
        '''try to determine if this is an image file type by looking to the blgImageFileTypes Construct
        '''if so, retain the image properties and save it as an image
        '''otherwise save it as one of the other accepted file types
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub cmdSynchronize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSynchronize.Click
            Try
                Dim strFileName As String
                Dim strExtension As String
                Dim strContentType As String
                Dim imgImage As System.Drawing.Image
                Dim strWidth As String
                Dim strHeight As String

                Dim objFiles As New FileController

                'if the parent of the active tab is the host tab then allow file deletion, 
                'and set the current working folder to the HostPath folder

                'if the parent of the active tab is not the host tab, then restrict deletion to the portal upload folder 
                'and set the current working folder to the Portal Upload directory for the portal

                If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    objFiles.DeleteFiles()
                Else
                    objFiles.DeleteFiles(PortalId)
                End If

                'do a check to make sure the folder exists and 
                'if so loop through the selected folder and list the files within the folder
                'using a extension filter to only allow files that match the extensions as listed in the site settings for that portal

                If Directory.Exists(lblRootFolder.Text) Then
                    Dim fileEntries As String() = Directory.GetFiles(lblRootFolder.Text)
                    For Each strFileName In fileEntries
                        If Convert.ToBoolean(InStr(1, strFileName, ".")) Then
                            strExtension = Mid(strFileName, InStrRev(strFileName, ".") + 1)
                        End If

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

                        strHeight = ""
                        strWidth = ""

                        'try to determine if this is an image file type by looking to the blgImageFileTypes Construct
                        'if so, retain the image properties and save it as an image
                        'otherwise save it as one of the other accepted file types
                        If Convert.ToBoolean(InStr(1, glbImageFileTypes & ",", strExtension & ",")) Then
                            Try
                                imgImage = imgImage.FromFile(strFileName)
                                strHeight = imgImage.Height.ToString
                                strWidth = imgImage.Width.ToString
                                imgImage.Dispose()
                            Catch
                                ' error loading image file
                                strContentType = "application/octet-stream"
                            End Try
                        End If

                        If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                            objFiles.AddFile(Null.NullInteger, Mid(strFileName, InStrRev(strFileName, "\") + 1), strExtension, FileLen(strFileName).ToString, strWidth, strHeight, strContentType)
                        Else
                            objFiles.AddFile(PortalId, Mid(strFileName, InStrRev(strFileName, "\") + 1), strExtension, FileLen(strFileName).ToString, strWidth, strHeight, strContentType)
                        End If
                    Next strFileName
                End If
                'Complete the loop and bind the datagrid to show the files for that folder that are stored in the database
                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The DeleteCommand subroutine handles the functions to delete a file within the datalist,
        ''' from the database and from the physical folder.
        ''' This gets its working parameter, the FileID, from the datagrid itemindex datakey of the selected row
        ''' A determination is made to direct the user to the correct path.  
        ''' If the user is the Host then the path is set by the HostPath Property of the Global Class
        ''' If the User is the Administrator or is an accepted role to access files then the path is set to the UploadDirectory Property of the PortalSetting Collection
        ''' Catches if the file is read only and stop handles the event gracefully with a message
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' The FileID of the selected file is passed using the Datakey of the selected row of the datagrid
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub grdFiles_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFiles.DeleteCommand
            Try
                Dim objFiles As New FileController

                Try
                    If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                        File.Delete(lblRootFolder.Text & Convert.ToString(grdFiles.DataKeys(e.Item.ItemIndex)))
                        objFiles.DeleteFile(Convert.ToString(grdFiles.DataKeys(e.Item.ItemIndex)), Null.NullInteger)
                    Else
                        File.Delete(lblRootFolder.Text & Convert.ToString(grdFiles.DataKeys(e.Item.ItemIndex)))
                        objFiles.DeleteFile(Convert.ToString(grdFiles.DataKeys(e.Item.ItemIndex)), PortalId)
                    End If
                Catch
                    ' delete error - can happen if the file is read-only
                    Skin.AddModuleMessage(Me, "An Error Has Occurred When Attempting To Delete The Selected File. Please Contact Your Hosting Provider To Ensure The Appropriate Security Settings Have Been Enabled On The Server.", Skins.ModuleMessage.ModuleMessageType.RedError)
                End Try

                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The EditCommand subroutine handles the functions to download a file within the datalist 
        ''' that is stored within the database as a ID value to the path for that file.
        ''' This gets its working parameter, the FileID, from the datagrid itemindex datakey of the selected row
        ''' A determination is made to direct the user to the correct path.  
        ''' If the user is the Host then the path is set by the HostPath Property of the Global Class
        ''' If the User is the Administrator or is an accepted role to access files then the path is set to the UploadDirectory Property of the PortalSetting Collection
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' The FileID of the selected file is passed using the Datakey of the selected row of the datagrid
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        '''         ''' -----------------------------------------------------------------------------
        Public Sub grdFiles_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFiles.EditCommand
            Try
                Dim objFiles As New FileController
                Dim dr As IDataReader

                If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    dr = objFiles.GetFile(Convert.ToString(grdFiles.DataKeys(e.Item.ItemIndex)))
                Else
                    dr = objFiles.GetFile(Convert.ToString(grdFiles.DataKeys(e.Item.ItemIndex)), PortalId)
                End If

                If dr.Read Then
                    Response.AppendHeader("content-disposition", "attachment; filename=" + dr("FileName").ToString)
                    Response.ContentType = dr("ContentType").ToString
                    If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                        Response.WriteFile(Global.HostPath & dr("FileName").ToString)
                    Else
                        Response.WriteFile(PortalSettings.UploadDirectory & dr("FileName").ToString)
                    End If
                    Response.End()
                End If
                dr.Close()

                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This Helper Method formats the source integer into a valid bytesize representation
        ''' </summary>
        ''' <param name="intSize">This parameter is input and represents the value collected for the filesize of the current file</param>
        ''' <returns>a cleanly formatted integer representing the bytes within that file</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function FormatSize(ByVal intSize As Integer) As String
            Try
                Return Format(intSize / 1000, "#,##0.00")

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Update Click subroutine is called upon the Update click event, and is used to save the changed data.  
        ''' In this case it save the modules settings as well as the roles that can utilise this module within that portal / module
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[DYNST]	2/1/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

            Dim objModules As New ModuleController

            Dim item As ListItem

            ' Construct Authorized View Roles 
            Dim UploadRoles As String = ""
            For Each item In chkUploadRoles.Items
                If item.Selected Then
                    UploadRoles = UploadRoles & item.Value & ";"
                End If
            Next item
            If UploadRoles <> "" Then
                If InStr(1, UploadRoles, PortalSettings.AdministratorRoleId.ToString & ";") = 0 Then
                    UploadRoles += PortalSettings.AdministratorRoleId.ToString & ";"
                End If
            End If

            objModules.UpdateModuleSetting(ModuleId, "uploadroles", UploadRoles)

        End Sub

    End Class

End Namespace
