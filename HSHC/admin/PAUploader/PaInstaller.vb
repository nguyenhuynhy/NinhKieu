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
    Public Class PaInstaller
        Private _zipStream As Stream
        Private _dnnFolders As PaFolderCollection
        Private _installInfo As New PaInstallInfo

        Public ReadOnly Property InstallerInfo() As PaInstallInfo
            Get
                Return _InstallInfo
            End Get
        End Property

        Public ReadOnly Property ZipStream() As Stream
            Get
                Return _zipStream
            End Get
        End Property

        Public Sub New(ByVal inputStream As Stream, ByVal SitePath As String)

            InstallerInfo.SitePath = SitePath
            _zipStream = inputStream
        End Sub

        Public Function Install() As Boolean
            ' -----------------------------------------------------------------------------
            ' Step 1:  Expand ZipFile in memory - identify .dnn file
            ' Step 2:  Identify .dnn version/type and translate to object model
            ' Step 3:  Install objects
            ' -----------------------------------------------------------------------------

            InstallerInfo.Log.StartJob("Starting Installation")
            Try
                ' Step 1
                ReadZipStream()

                ' Step 2
                Dim Factory As New PaDnnLoaderFactory(InstallerInfo)
                _dnnFolders = Factory.GetDnnAdapter.ReadDnn()

                ' Step 3
                Factory.GetDnnInstaller.Install(_dnnFolders)

            Catch ex As Exception
                InstallerInfo.Log.Add(ex)
                Return False
            End Try

            InstallerInfo.Log.EndJob("Installation successfull.")
            Return True
        End Function

        Private Sub ReadZipStream()
            InstallerInfo.Log.StartJob("Reading files")

            Dim unzip As New ZipInputStream(ZipStream)

            Dim entry As ZipEntry = unzip.GetNextEntry()

            While Not (entry Is Nothing)
                If Not entry.IsDirectory Then
                    InstallerInfo.Log.AddInfo(("Loading " + entry.Name))

                    ' add file to the file list
                    Dim file As New PaFile(unzip, entry)

                    InstallerInfo.FileTable(file.Name) = file

                    If file.Type = PaFileType.Dnn Then
                        If Not (InstallerInfo.DnnFile Is Nothing) Then
                            InstallerInfo.Log.AddFailure(("Found multiple .dnn files in the zip file: " + InstallerInfo.DnnFile.Name + " and " + file.Name))
                        Else
                            InstallerInfo.DnnFile = file
                        End If
                    End If
                    InstallerInfo.Log.AddInfo(("File " + file.FullName + " read successfully"))
                End If
                entry = unzip.GetNextEntry
            End While

            If InstallerInfo.DnnFile Is Nothing Then
                InstallerInfo.Log.AddFailure("Did not find any .dnn file ???")
            End If

            If InstallerInfo.Log.Valid Then
                InstallerInfo.Log.EndJob("Reading files done.")
            Else
                Throw New Exception("File load failed, stopping")
            End If
        End Sub
    End Class
End Namespace
