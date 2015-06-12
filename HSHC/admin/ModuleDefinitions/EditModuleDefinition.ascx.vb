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
Imports System.IO

Namespace PortalQH

    Public Class EditModuleDefinition

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents tabModule As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents txtFriendlyName As System.Web.UI.WebControls.TextBox
        Protected WithEvents valFriendlyName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkPremium As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtVersion As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Protected WithEvents tabDefinitions As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents cboDefinitions As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdDeleteDefinition As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtDefinition As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdAddDefinition As System.Web.UI.WebControls.LinkButton

        Protected WithEvents tabControls As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents grdControls As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdAddControl As System.Web.UI.WebControls.LinkButton

        Private DesktopModuleId As Integer

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
                If Not (Request.Params("desktopmoduleid") Is Nothing) Then
                    DesktopModuleId = Int32.Parse(Request.Params("desktopmoduleid"))
                Else
                    DesktopModuleId = Null.NullInteger
                End If

                If Page.IsPostBack = False Then

                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")
                    cmdDeleteDefinition.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    If Null.IsNull(DesktopModuleId) Then

                        txtFriendlyName.Enabled = True
                        cmdDelete.Visible = False
                        tabDefinitions.Visible = False
                        tabControls.Visible = False

                    Else

                        Dim objDesktopModules As New DesktopModuleController
                        Dim objDesktopModule As DesktopModuleInfo

                        If DesktopModuleId = -2 Then
                            objDesktopModule = New DesktopModuleInfo
                            objDesktopModule.FriendlyName = "[Skin Objects]"
                            objDesktopModule.Description = "Skin Objects are User Controls which can be used to provide custom functionality to your Skin files."
                            objDesktopModule.IsPremium = False
                            objDesktopModule.Version = ""

                            cmdUpdate.Visible = False
                            cmdDelete.Visible = False
                            tabDefinitions.Visible = False

                            LoadControls(Null.NullInteger)
                        Else
                            objDesktopModule = objDesktopModules.GetDesktopModule(DesktopModuleId)

                            LoadDefinitions()
                        End If

                        If Not objDesktopModule Is Nothing Then
                            txtFriendlyName.Text = objDesktopModule.FriendlyName
                            txtDescription.Text = objDesktopModule.Description
                            chkPremium.Checked = objDesktopModule.IsPremium
                            txtVersion.Text = objDesktopModule.Version
                        End If

                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try

                If Page.IsValid = True Then

                    Dim objDesktopModule As New DesktopModuleInfo

                    objDesktopModule.DesktopModuleID = DesktopModuleId
                    objDesktopModule.FriendlyName = txtFriendlyName.Text
                    objDesktopModule.Description = txtDescription.Text
                    objDesktopModule.IsPremium = chkPremium.Checked
                    If txtVersion.Text <> "" Then
                        objDesktopModule.Version = txtVersion.Text
                    Else
                        objDesktopModule.Version = Convert.ToString(Null.SetNull(objDesktopModule.Version))
                    End If

                    Dim objDesktopModules As New DesktopModuleController

                    If Null.IsNull(DesktopModuleId) Then
                        objDesktopModule.DesktopModuleID = objDesktopModules.AddDesktopModule(objDesktopModule)
                    Else
                        objDesktopModules.UpdateDesktopModule(objDesktopModule)
                    End If

                    Response.Redirect(EditURL("desktopmoduleid", objDesktopModule.DesktopModuleID.ToString), True)

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                Dim strFileName As String
                Dim arrFiles As String()

                If Not Null.IsNull(DesktopModuleId) Then

                    'Dim strRoot As String = Request.MapPath("~/DesktopModules/" & txtFriendlyName.Text) & "\"

                    '' find dnn manifest file
                    'arrFiles = Directory.GetFiles(strRoot, "*.dnn")
                    'If arrFiles.Length <> 0 Then
                    '    If File.Exists(strRoot & Path.GetFileName(arrFiles(0))) Then
                    '        Dim xmlDoc As New XmlDocument
                    '        Dim nodeFile As XmlNode

                    '        ' load the manifest file
                    '        xmlDoc.Load(strRoot & Path.GetFileName(arrFiles(0)))

                    '        ' check version
                    '        Dim nodeModule As XmlNode
                    '        Select Case xmlDoc.DocumentElement.LocalName.ToLower()
                    '            Case "module"
                    '                nodeModule = xmlDoc.SelectSingleNode("//module")
                    '            Case "PortalQH"
                    '                ' V2 allows for multiple folders in a single DNN definition - we need to identify the correct node
                    '                For Each nodeModule In xmlDoc.SelectNodes("//PortalQH/folders/folder")
                    '                    If nodeModule.SelectSingleNode("name").InnerText.Trim = txtFriendlyName.Text Then
                    '                        Exit For
                    '                    End If
                    '                Next
                    '        End Select

                    '        ' loop through file nodes
                    '        For Each nodeFile In nodeModule.SelectNodes("files/file")
                    '            strFileName = nodeFile.SelectSingleNode("name").InnerText.Trim
                    '            ' if Module DLL file
                    '            If Path.GetExtension(strFileName) = ".dll" Then
                    '                ' remove DLL from /bin
                    '                strFileName = Request.MapPath("~/bin/") & strFileName
                    '                If File.Exists(strFileName) Then
                    '                    File.SetAttributes(strFileName, FileAttributes.Normal)
                    '                    File.Delete(strFileName)
                    '                End If
                    '            End If
                    '        Next
                    '    End If
                    'End If

                    '' process uninstall script
                    'Dim strProviderType As String = "data"
                    'Dim objProviderConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration(strProviderType)
                    'Dim strUninstallScript As String = "Uninstall." & objProviderConfiguration.DefaultProvider
                    'If File.Exists(strRoot & strUninstallScript) Then
                    '    ' read uninstall script
                    '    Dim objStreamReader As StreamReader
                    '    objStreamReader = File.OpenText(strRoot & strUninstallScript)
                    '    Dim strScript As String = objStreamReader.ReadToEnd
                    '    objStreamReader.Close()

                    '    ' execute uninstall script
                    '    PortalSettings.ExecuteScript(strScript)
                    'End If

                    '' check for existence of project file ( this indicates a development environment )
                    'arrFiles = Directory.GetFiles(strRoot, "*.??proj")
                    'If arrFiles.Length = 0 Then
                    '    ' delete the module folder ( and subfolders )
                    '    If Directory.Exists(strRoot) Then
                    '        DeleteFolderRecursive(strRoot)
                    '    End If
                    'End If

                    ' delete the desktopmodule database record
                    Dim objDesktopModules As New DesktopModuleController
                    objDesktopModules.DeleteDesktopModule(DesktopModuleId)

                End If

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cboDefinitions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDefinitions.SelectedIndexChanged

            LoadControls(Int32.Parse(cboDefinitions.SelectedItem.Value))

        End Sub

        Private Sub LoadDefinitions()

            Dim objModuleDefinitions As New ModuleDefinitionController

            cboDefinitions.DataSource = objModuleDefinitions.GetModuleDefinitions(DesktopModuleId)
            cboDefinitions.DataBind()

            If cboDefinitions.Items.Count <> 0 Then
                cboDefinitions.SelectedIndex = 0
                LoadControls(Integer.Parse(cboDefinitions.SelectedItem.Value))
            Else
                cmdAddControl.Visible = False
                grdControls.Visible = False
            End If

        End Sub

        Private Sub cmdAddDefinition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddDefinition.Click

            If txtDefinition.Text <> "" Then

                Dim objModuleDefinition As New ModuleDefinitionInfo

                objModuleDefinition.DesktopModuleID = DesktopModuleId
                objModuleDefinition.FriendlyName = txtDefinition.Text

                Dim objModuleDefinitions As New ModuleDefinitionController

                objModuleDefinitions.AddModuleDefinition(objModuleDefinition)

                LoadDefinitions()

            End If

        End Sub

        Private Sub cmdDeleteDefinition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeleteDefinition.Click

            Dim objModuleDefinitions As New ModuleDefinitionController

            objModuleDefinitions.DeleteModuleDefinition(Integer.Parse(cboDefinitions.SelectedItem.Value))

            LoadDefinitions()

        End Sub

        Private Sub LoadControls(ByVal ModuleDefId As Integer)

            Dim objModuleControls As New ModuleControlController

            Dim arrModuleControls As ArrayList

            arrModuleControls = objModuleControls.GetModuleControls(ModuleDefId)

            If DesktopModuleId = -2 Then
                Dim objModuleControl As ModuleControlInfo
                Dim intIndex As Integer
                For intIndex = arrModuleControls.Count - 1 To 0 Step -1
                    objModuleControl = CType(arrModuleControls(intIndex), ModuleControlInfo)
                    If objModuleControl.ControlType <> SecurityAccessLevel.SkinObject Then
                        arrModuleControls.RemoveAt(intIndex)
                    End If
                Next
            End If

            grdControls.DataSource = arrModuleControls
            grdControls.DataBind()

            cmdAddControl.Visible = True
            grdControls.Visible = True

        End Sub

        Private Sub cmdAddControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddControl.Click

            Response.Redirect(FormatURL("modulecontrolid", "-1"))

        End Sub

        Public Function FormatURL(ByVal strKeyName As String, ByVal strKeyValue As String) As String
            Try

                FormatURL = EditURL(strKeyName, strKeyValue, "Control") & "&desktopmoduleid=" & DesktopModuleId.ToString()

                If DesktopModuleId <> -2 Then
                    FormatURL += "&moduledefid=" & cboDefinitions.SelectedItem.Value
                Else
                    FormatURL += "&moduledefid=-1"
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

    End Class

End Namespace
