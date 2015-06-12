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

Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports System.Text

Namespace PortalQH.Installer
    Public Class PaDnnInstaller_V1
        Inherits PaDnnInstallerBase

        Public Sub New(ByVal InstallerInfo As PaInstallInfo)
            MyBase.New(InstallerInfo)
        End Sub

        Protected Overrides Sub CreateFiles(ByVal Folder As PaFolder)

            installerInfo.Log.StartJob("Creating files")
            ' define bin folder location
            Dim binFolder As String = Path.Combine(InstallerInfo.SitePath, "bin")

            ' create the root folder
            Dim rootFolder As String = Path.Combine(InstallerInfo.SitePath, Folder.Name)
            If Not Directory.Exists(rootFolder) Then
                Directory.CreateDirectory(rootFolder)
            End If

            ' create the files
            Dim file As PaFile
            For Each file In Folder.Files
                If file.Type = PaFileType.Ascx Or file.Type = PaFileType.Other Or file.Type = PaFileType.Dnn Then
                    ' save file
                    Dim FullFileName As String = Path.Combine(rootFolder, file.Name)
                    CreateFile(FullFileName, file.Buffer)
                    InstallerInfo.Log.AddInfo(("Created " + FullFileName))
                ElseIf file.Type = PaFileType.Dll Then
                    ' all dlls go to the bin folder
                    Dim binFullFileName As String = Path.Combine(binFolder, file.Name)
                    CreateFile(binFullFileName, file.Buffer)
                    InstallerInfo.Log.AddInfo(("Created " + binFullFileName))
                End If
            Next file
            InstallerInfo.Log.EndJob("Files created")
        End Sub

        Protected Overrides Sub ExecuteSql(ByVal Folder As PaFolder)
            InstallerInfo.Log.StartJob("Begin Sql execution")

            ' get list of script files
            Dim arrScriptFiles As New ArrayList

            ' executing all the sql files
            Dim file As PaFile
            For Each file In Folder.Files
                If file.Type = PaFileType.Sql Then
                    arrScriptFiles.Add(file)
                End If
            Next file

            Dim Comparer As New PaDataProviderComparer
            arrScriptFiles.Sort(Comparer)
            Dim scriptFile As PaFile
            For Each scriptFile In arrScriptFiles
                InstallerInfo.Log.AddInfo(("Executing " + file.Name))
                BatchSql(scriptFile)
            Next

            InstallerInfo.Log.EndJob("Finished Sql execution")
        End Sub

        Protected Overrides Sub RegisterModules(ByVal Folder As PaFolder, ByVal Modules As ArrayList, ByVal Controls As ArrayList)

            InstallerInfo.Log.StartJob("Registering DesktopModule")

            Dim objDesktopModules As New DesktopModuleController

            ' check if desktop module exists
            Dim objDesktopModule As DesktopModuleInfo = objDesktopModules.GetDesktopModuleByName(CType(Folder.Modules.Item(0), ModuleDefinitionInfo).FriendlyName)
            If objDesktopModule Is Nothing Then
                objDesktopModule = New DesktopModuleInfo
                objDesktopModule.DesktopModuleID = Convert.ToInt32(Null.SetNull(objDesktopModule.DesktopModuleID))
            End If

            ' This is a change from the base...
            objDesktopModule.FriendlyName = CType(Folder.Modules.Item(0), ModuleDefinitionInfo).FriendlyName
            objDesktopModule.Description = Folder.Description
            objDesktopModule.Version = Folder.Version
            objDesktopModule.IsPremium = False

            If Null.IsNull(objDesktopModule.DesktopModuleID) Then
                ' new desktop module
                objDesktopModule.DesktopModuleID = objDesktopModules.AddDesktopModule(objDesktopModule)
            Else
                ' existing desktop module
                objDesktopModules.UpdateDesktopModule(objDesktopModule)
            End If

            InstallerInfo.Log.AddInfo("Registering Definitions")

            Dim objModuleDefinitons As New ModuleDefinitionController

            Dim objModuleDefinition As ModuleDefinitionInfo
            For Each objModuleDefinition In Modules
                ' check if definition exists
                Dim objModuleDefinition2 As ModuleDefinitionInfo = objModuleDefinitons.GetModuleDefinitionByName(objDesktopModule.DesktopModuleID, objModuleDefinition.FriendlyName)
                If objModuleDefinition2 Is Nothing Then
                    ' add new definition
                    objModuleDefinition.DesktopModuleID = objDesktopModule.DesktopModuleID
                    objModuleDefinition.ModuleDefID = objModuleDefinitons.AddModuleDefinition(objModuleDefinition)
                Else
                    objModuleDefinition.ModuleDefID = objModuleDefinition2.ModuleDefID
                End If
            Next

            InstallerInfo.Log.AddInfo("Registering Controls")

            Dim objModuleControls As New ModuleControlController

            Dim objModuleControl As ModuleControlInfo
            For Each objModuleControl In Controls
                ' get the real ModuleDefID from the associated Module
                objModuleControl.ModuleDefID = GetModDefID(objModuleControl.ModuleDefID, Modules)

                ' check if control exists
                Dim objModuleControl2 As ModuleControlInfo = objModuleControls.GetModuleControlByKeyAndSrc(objModuleControl.ModuleDefID, objModuleControl.ControlKey, objModuleControl.ControlSrc)
                If objModuleControl2 Is Nothing Then
                    ' add new control
                    objModuleControls.AddModuleControl(objModuleControl)
                Else
                    ' update existing control 
                    objModuleControl.ModuleControlID = objModuleControl2.ModuleControlID
                    objModuleControls.UpdateModuleControl(objModuleControl)
                End If
            Next

            InstallerInfo.Log.EndJob("Registering finished")
        End Sub
    End Class
End Namespace