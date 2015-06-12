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
    Public Class PaDnnInstallerBase

        Private _installerInfo As PaInstallInfo

        Public Sub New(ByVal InstallerInfo As PaInstallInfo)
            _installerInfo = InstallerInfo
        End Sub

        Public ReadOnly Property InstallerInfo() As PaInstallInfo
            Get
                Return _installerInfo
            End Get
        End Property

        Public Overridable Sub Install(ByVal folders As PaFolderCollection)
            Dim folder As PaFolder
            For Each folder In folders
                ExecuteSql(folder)
                CreateFiles(folder)
                RegisterModules(folder, folder.Modules, folder.Controls)
            Next
        End Sub

        Protected Overridable Sub ExecuteSql(ByVal Folder As PaFolder)

            InstallerInfo.Log.StartJob("Begin Sql execution")
            ' get list of script files
            Dim arrScriptFiles As New ArrayList

            ' executing all the sql files
            Dim file As PaFile
            For Each file In Folder.Files
                ' DataProvider files may be either: the SQL to execute, uninstall, or XML stored procs.
                ' We only want to execute the first type of DataProvider files.
                If file.Type = PaFileType.Sql _
                    OrElse (file.Type = PaFileType.DataProvider And file.Name.ToLower.IndexOf("uninstall") = -1 And file.Name.ToLower.IndexOf(".xml") = -1) Then

                    Dim objProviderConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration("data")

                    If objProviderConfiguration.DefaultProvider.ToLower = Path.GetExtension(file.Name).Substring(1) Then
                        arrScriptFiles.Add(file)
                    End If
                End If
            Next file

            ' get current module version
            Dim strModuleVersion As String = "000000"
            Dim objDesktopModules As New DesktopModuleController
            Dim objDesktopModule As DesktopModuleInfo = objDesktopModules.GetDesktopModuleByName(Folder.Name)
            If Not objDesktopModule Is Nothing Then
                strModuleVersion = objDesktopModule.Version.Replace(".", "")
            End If
            Dim strScriptVersion As String

            ' iterate through scripts
            Dim Comparer As New PaDataProviderComparer
            arrScriptFiles.Sort(Comparer)
            Dim scriptFile As PaFile
            For Each scriptFile In arrScriptFiles
                strScriptVersion = Path.GetFileNameWithoutExtension(scriptFile.Name).Replace(".", "")
                If strScriptVersion > strModuleVersion Then
                    InstallerInfo.Log.AddInfo(("Executing " + scriptFile.Name))
                    BatchSql(scriptFile)
                End If
            Next

            InstallerInfo.Log.EndJob("Finished Sql execution")
        End Sub

        Protected Overridable Function BatchSql(ByVal sqlFile As PaFile) As Boolean

            Dim WasSuccessful As Boolean = True

            InstallerInfo.Log.StartJob(String.Format("Start Sql execution: {0} file", sqlFile.Name))

            Dim strScript As String
            Select Case sqlFile.Encoding
                Case PaTextEncoding.UTF16LittleEndian
                    strScript = GetAsciiString(sqlFile.Buffer, System.Text.Encoding.Unicode)  'System.Text.Encoding.Unicode.GetString(sqlFile.Buffer)
                Case PaTextEncoding.UTF16BigEndian
                    strScript = GetAsciiString(sqlFile.Buffer, System.Text.Encoding.BigEndianUnicode)  'System.Text.Encoding.BigEndianUnicode.GetString(sqlFile.Buffer)
                Case PaTextEncoding.UTF8
                    strScript = GetAsciiString(sqlFile.Buffer, System.Text.Encoding.UTF8)  'System.Text.Encoding.UTF8.GetString(sqlFile.Buffer)
                Case PaTextEncoding.UTF7
                    strScript = GetAsciiString(sqlFile.Buffer, System.Text.Encoding.UTF7)  'System.Text.Encoding.UTF7.GetString(sqlFile.Buffer)
                Case PaTextEncoding.Unknown
                    Throw New Exception(String.Format("Unknown file encoding for {0}, aborting", sqlFile.Name))
            End Select

            'This check needs to be included because the unicode Byte Order mark results in an extra character at the start of the file
            'The extra character - '?' - causes an error with the database.
            If strScript.StartsWith("?") Then
                strScript = strScript.Substring(1)
            End If

            ' execute SQL installation script
            'TODO: Transactions are removed temporarily.
            Dim strSQLExceptions As String = PortalSettings.ExecuteScript(strScript, UseTransactions:=False)

            If strSQLExceptions = "" Then
                InstallerInfo.Log.AddFailure(String.Format("SQL Execution resulted in following Exceptions: {0}{1}", vbCrLf, strSQLExceptions))
                WasSuccessful = False
            End If

            InstallerInfo.Log.EndJob(String.Format("End Sql execution: {0} file", sqlFile.Name))

            Return WasSuccessful
        End Function

        Protected Function GetAsciiString(ByVal Buffer As Byte(), ByVal SourceEncoding As Encoding) As String
            Dim unicodeString As String = "This string contains the unicode character Pi(Ð)"

            ' Create two different encodings.
            Dim TargetEncoding As Encoding = Encoding.ASCII

            ' Perform the conversion from one encoding to the other.
            Dim asciiBytes As Byte() = Encoding.Convert(SourceEncoding, TargetEncoding, Buffer)

            ' Convert the new byte[] into an ascii string.
            Dim asciiString As String = System.Text.Encoding.ASCII.GetString(asciiBytes)

            Return asciiString
        End Function

        Protected Overridable Sub CreateFiles(ByVal Folder As PaFolder)

            InstallerInfo.Log.StartJob("Creating files")
            ' define bin folder location


            ' create the files
            Dim file As PaFile
            For Each file In Folder.Files
                Select Case file.Type
                    Case PaFileType.DataProvider
                        ' We need to store uninstall files in the main module directory because
                        ' that is where the uninstaller expects to find them
                        If file.Name.ToLower.IndexOf("uninstall") <> -1 Then
                            CreateModuleFile(file, Folder)
                        Else
                            CreateDataProviderFile(file, Folder)
                        End If
                    Case PaFileType.Dll
                        CreateBinFile(file)
                    Case PaFileType.Dnn, PaFileType.Ascx, PaFileType.Sql, PaFileType.Other
                        CreateModuleFile(file, Folder)
                End Select
            Next file

            InstallerInfo.Log.EndJob("Files created")

        End Sub

        Protected Overridable Sub CreateBinFile(ByVal File As PaFile)
            Dim binFolder As String = Path.Combine(InstallerInfo.SitePath, "bin")
            Dim binFullFileName As String = Path.Combine(binFolder, File.Name)
            CreateFile(binFullFileName, File.Buffer)
            InstallerInfo.Log.AddInfo(("Created " + binFullFileName))
        End Sub

        Protected Overridable Sub CreateDataProviderFile(ByVal file As PaFile, ByVal Folder As PaFolder)
            Dim ProviderTypeFolder As String = Path.Combine("Providers\DataProviders", file.Extension)
            Dim ProviderFolder As String = Path.Combine(InstallerInfo.SitePath, Path.Combine(ProviderTypeFolder, Folder.Name))
            If Not Directory.Exists(ProviderFolder) Then
                Directory.CreateDirectory(ProviderFolder)
            End If

            ' save file
            Dim FullFileName As String = Path.Combine(ProviderFolder, file.Name)
            CreateFile(FullFileName, file.Buffer)
            InstallerInfo.Log.AddInfo(("Created " + FullFileName))

        End Sub

        Protected Overridable Sub CreateModuleFile(ByVal File As PaFile, ByVal Folder As PaFolder)
            ' account for skinobject names which include [ ]
            Dim FolderName As String = Folder.Name.Trim("["c).Trim("]"c)
            Dim rootFolder As String = Path.Combine(InstallerInfo.SitePath, Path.Combine("DesktopModules", FolderName))

            ' create the root folder
            If Not Directory.Exists(rootFolder) Then
                Directory.CreateDirectory(rootFolder)
            End If

            ' create the actual file folder which includes any relative filepath info
            Dim fileFolder As String = Path.Combine(rootFolder, File.Path)
            If Not Directory.Exists(fileFolder) Then
                Directory.CreateDirectory(fileFolder)
            End If

            ' save file
            Dim FullFileName As String = Path.Combine(fileFolder, File.Name)
            CreateFile(FullFileName, File.Buffer)
            InstallerInfo.Log.AddInfo(("Created " + FullFileName))
        End Sub

        Protected Overridable Sub RegisterModules(ByVal Folder As PaFolder, ByVal Modules As ArrayList, ByVal Controls As ArrayList)

            InstallerInfo.Log.StartJob("Registering DesktopModule")

            Dim objDesktopModules As New DesktopModuleController

            ' check if desktop module exists
            Dim objDesktopModule As DesktopModuleInfo = objDesktopModules.GetDesktopModuleByName(Folder.Name)
            If objDesktopModule Is Nothing Then
                objDesktopModule = New DesktopModuleInfo
                objDesktopModule.DesktopModuleID = Convert.ToInt32(Null.SetNull(objDesktopModule.DesktopModuleID))
            End If

            objDesktopModule.FriendlyName = Folder.Name
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

        Protected Function GetModDefID(ByVal TempModDefID As Integer, ByVal Modules As ArrayList) As Integer
            Dim ModDefID As Integer = -1

            Dim MI As ModuleDefinitionInfo
            For Each MI In Modules
                If MI.TempModuleID = TempModDefID Then
                    ModDefID = MI.ModuleDefID
                    Exit For
                End If
            Next
            Return ModDefID
        End Function

        Protected Sub CreateFile(ByVal FullFileName As String, ByVal Buffer As Byte())
            If System.IO.File.Exists(FullFileName) Then
                System.IO.File.SetAttributes(FullFileName, FileAttributes.Normal)
            End If
            Dim fs As New FileStream(FullFileName, FileMode.Create, FileAccess.Write)
            fs.Write(Buffer, 0, Buffer.Length)
            fs.Close()
        End Sub

    End Class

End Namespace
