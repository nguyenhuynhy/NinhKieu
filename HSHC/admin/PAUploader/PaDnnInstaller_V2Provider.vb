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
    Public Class PaDnnInstaller_V2Provider
        Inherits PaDnnInstallerBase

        Public Sub New(ByVal InstallerInfo As PaInstallInfo)
            MyBase.New(InstallerInfo)
        End Sub

        Public Overrides Sub Install(ByVal folders As PaFolderCollection)
            Dim folder As PaFolder
            For Each folder In folders
                CreateFiles(folder)
            Next
        End Sub

        Protected Overrides Sub CreateFiles(ByVal Folder As PaFolder)

            InstallerInfo.Log.StartJob("Creating files")
            ' define bin folder location
            Dim binFolder As String = Path.Combine(InstallerInfo.SitePath, "bin")

            ' create the root folder
            Dim rootFolder As String = Path.Combine(InstallerInfo.SitePath, Path.Combine("Providers", Path.Combine(Folder.ProviderType, Folder.Name)))
            If Not Directory.Exists(rootFolder) Then
                Directory.CreateDirectory(rootFolder)
            End If

            ' create the files
            Dim file As PaFile
            For Each file In Folder.Files
                If file.Type = PaFileType.DataProvider _
                    OrElse file.Type = PaFileType.Other _
                    OrElse file.Type = PaFileType.Sql Then
                    ' create the directory for this file
                    Dim fileFolder As String = Path.Combine(rootFolder, file.Path)
                    If Not Directory.Exists(fileFolder) Then
                        Directory.CreateDirectory(fileFolder)
                    End If

                    ' save file
                    Dim FullFileName As String = Path.Combine(fileFolder, file.Name)
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

    End Class
End Namespace
