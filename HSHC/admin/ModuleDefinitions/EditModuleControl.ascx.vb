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

    Public Class EditModuleControl

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtModule As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDefinition As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKey As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboSource As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboType As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtViewOrder As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboIcon As System.Web.UI.WebControls.DropDownList

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Private DesktopModuleId As Integer
        Private ModuleDefId As Integer
        Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
        Private ModuleControlId As Integer

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
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                If Not (Request.Params("desktopmoduleid") Is Nothing) Then
                    DesktopModuleId = Int32.Parse(Request.Params("desktopmoduleid"))
                    If DesktopModuleId = -2 Then
                        DesktopModuleId = Convert.ToInt32(Null.SetNull(DesktopModuleId))
                    End If
                Else
                    DesktopModuleId = Null.NullInteger
                End If

                If Not (Request.Params("moduledefid") Is Nothing) Then
                    ModuleDefId = Int32.Parse(Request.Params("moduledefid"))
                Else
                    ModuleDefId = Null.NullInteger
                End If

                If Not (Request.Params("modulecontrolid") Is Nothing) Then
                    ModuleControlId = Int32.Parse(Request.Params("modulecontrolid"))
                Else
                    ModuleControlId = Null.NullInteger
                End If

                If Page.IsPostBack = False Then

                    Dim objDesktopModules As New DesktopModuleController
                    Dim objDesktopModule As DesktopModuleInfo

                    objDesktopModule = objDesktopModules.GetDesktopModule(DesktopModuleId)
                    If Not objDesktopModule Is Nothing Then
                        txtModule.Text = objDesktopModule.FriendlyName
                    Else
                        txtModule.Text = "[Skin Objects]"
                        txtTitle.Enabled = False
                        cboType.Enabled = False
                        txtViewOrder.Enabled = False
                        cboIcon.Enabled = False
                    End If

                    Dim objModuleDefinitions As New ModuleDefinitionController
                    Dim objModuleDefinition As ModuleDefinitionInfo

                    objModuleDefinition = objModuleDefinitions.GetModuleDefinition(ModuleDefId)
                    If Not objModuleDefinition Is Nothing Then
                        txtDefinition.Text = objModuleDefinition.FriendlyName
                    End If

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")
                    Dim strRoot As String
                    Dim strFolder As String
                    Dim arrFolders As String()
                    Dim strFile As String
                    Dim arrFiles As String()

                    'strRoot = "DesktopModules"
                    FindFolders(Request.MapPath(Global.ApplicationPath))

                    'If Directory.Exists(Request.MapPath(Global.ApplicationPath & "/" & strRoot)) Then
                    '    arrFolders = Directory.GetDirectories(Request.MapPath(Global.ApplicationPath & "/" & strRoot))
                    'If Directory.Exists(Request.MapPath(Global.ApplicationPath)) Then
                    '    arrFolders = Directory.GetDirectories(Request.MapPath(Global.ApplicationPath))
                    '    For Each strFolder In arrFolders
                    '        arrFiles = Directory.GetFiles(strFolder, "*.ascx")

                    '        For Each strFile In arrFiles
                    '            'strFile = strRoot & "/" & Mid(strFolder, InStrRev(strFolder, "\") + 1) & "/" & Path.GetFileName(strFile)
                    '            strFile = Mid(strFolder, InStrRev(strFolder, "\") + 1) & "/" & Path.GetFileName(strFile)
                    '            cboSource.Items.Add(New ListItem(strFile, strFile.ToLower))
                    '        Next
                    '    Next
                    'End If

                    If Not Null.IsNull(ModuleControlId) Then

                        Dim objModuleControls As New ModuleControlController
                        Dim objModuleControl As ModuleControlInfo

                        objModuleControl = objModuleControls.GetModuleControl(ModuleControlId)
                        If Not objModuleControl Is Nothing Then
                            txtKey.Text = objModuleControl.ControlKey
                            txtTitle.Text = objModuleControl.ControlTitle
                            If Not cboSource.Items.FindByValue(objModuleControl.ControlSrc.ToString.ToLower) Is Nothing Then
                                cboSource.Items.FindByValue(objModuleControl.ControlSrc.ToString.ToLower).Selected = True
                                LoadIcons()
                            End If
                            If Not cboType.Items.FindByValue(CType(objModuleControl.ControlType, Integer).ToString) Is Nothing Then
                                cboType.Items.FindByValue(CType(objModuleControl.ControlType, Integer).ToString).Selected = True
                            End If
                            If Not Null.IsNull(objModuleControl.ViewOrder) Then
                                txtViewOrder.Text = objModuleControl.ViewOrder.ToString
                            End If
                            If Not cboIcon.Items.FindByValue(objModuleControl.IconFile.ToLower) Is Nothing Then
                                cboIcon.Items.FindByValue(objModuleControl.IconFile.ToLower).Selected = True
                            End If
                        End If

                    End If

                End If


            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Sub FindFolders(ByVal strFolder As String)
            Dim tmpFolder As String
            Dim arrFolders() As String
            Dim arrFiles() As String
            arrFolders = Directory.GetDirectories(strFolder)
            For Each tmpFolder In arrFolders
                arrFiles = Directory.GetFiles(tmpFolder, "*.ascx")
                If arrFiles.Length <> 0 Then
                    FindFiles(tmpFolder)
                End If
                FindFolders(tmpFolder)
            Next
        End Sub
        Private Sub FindFiles(ByVal strFolder As String)

            Dim strFile As String
            Dim arrFiles() As String

            arrFiles = Directory.GetFiles(strFolder, "*.ascx")
            For Each strFile In arrFiles
                'strFile = strRoot & "/" & Mid(strFolder, InStrRev(strFolder, "\") + 1) & "/" & Path.GetFileName(strFile)
                'strFile = Mid(strFolder, InStrRev(strFolder, "\") + 1) & "/" & Path.GetFileName(strFile)
                strFile = Replace(strFolder, Request.MapPath(Global.ApplicationPath) & "\", "") & "\" & Path.GetFileName(strFile)
                strFile = Replace(strFile, "\", "/")
                cboSource.Items.Add(New ListItem(strFile, strFile.ToLower))
            Next

        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try

                If Page.IsValid = True Then

                    Dim objModuleControl As New ModuleControlInfo

                    objModuleControl.ModuleControlID = ModuleControlId
                    objModuleControl.ModuleDefID = ModuleDefId
                    If txtKey.Text <> "" Then
                        objModuleControl.ControlKey = txtKey.Text
                    Else
                        objModuleControl.ControlKey = Null.NullString
                    End If
                    If txtTitle.Text <> "" Then
                        objModuleControl.ControlTitle = txtTitle.Text
                    Else
                        objModuleControl.ControlTitle = Null.NullString
                    End If
                    objModuleControl.ControlSrc = cboSource.SelectedItem.Text
                    objModuleControl.ControlType = CType(cboType.SelectedItem.Value, SecurityAccessLevel)
                    If txtViewOrder.Text <> "" Then
                        objModuleControl.ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Else
                        objModuleControl.ViewOrder = Null.NullInteger
                    End If
                    If cboIcon.SelectedIndex > 0 Then
                        objModuleControl.IconFile = cboIcon.SelectedItem.Text
                    Else
                        objModuleControl.IconFile = Convert.ToString(Null.SetNull(objModuleControl.IconFile))
                    End If

                    Dim objModuleControls As New ModuleControlController

                    If Null.IsNull(ModuleControlId) Then
                        objModuleControls.AddModuleControl(objModuleControl)
                    Else
                        objModuleControls.UpdateModuleControl(objModuleControl)
                    End If

                    If DesktopModuleId = -1 Then
                        DesktopModuleId = -2
                    End If
                    Response.Redirect(EditURL("desktopmoduleid", DesktopModuleId.ToString), True)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try

                Dim objModuleControls As New ModuleControlController

                If Not Null.IsNull(ModuleControlId) Then
                    objModuleControls.DeleteModuleControl(ModuleControlId)
                End If

                If DesktopModuleId = -1 Then
                    DesktopModuleId = -2
                End If
                Response.Redirect(EditURL("desktopmoduleid", DesktopModuleId.ToString), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try

                If DesktopModuleId = -1 Then
                    DesktopModuleId = -2
                End If
                Response.Redirect(EditURL("desktopmoduleid", DesktopModuleId.ToString), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub LoadIcons()
            Dim strRoot As String
            Dim strFile As String
            Dim arrFiles As String()
            Dim strExtension As String

            cboIcon.Items.Clear()
            cboIcon.Items.Add("<Not Specified>")

            strRoot = cboSource.SelectedItem.Text
            strRoot = Request.MapPath(Global.ApplicationPath & "/" & strRoot.Substring(0, strRoot.LastIndexOf("/")))

            If Directory.Exists(strRoot) Then
                arrFiles = Directory.GetFiles(strRoot)
                For Each strFile In arrFiles
                    strExtension = Path.GetExtension(strFile).Replace(".", "")
                    If InStr(1, glbImageFileTypes & ",", strExtension & ",") <> 0 Then
                        cboIcon.Items.Add(New ListItem(Path.GetFileName(strFile), Path.GetFileName(strFile).ToLower))
                    End If
                Next
            End If

        End Sub

        Private Sub cboSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSource.SelectedIndexChanged
            LoadIcons()
        End Sub




        Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

        End Sub
    End Class

End Namespace
