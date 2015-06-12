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
Imports System.Xml

Namespace PortalQH.Installer
    Public Class PaDnnAdapter_V2Provider
        Inherits PaDnnAdapterBase

        Public Sub New(ByVal InstallerInfo As PaInstallInfo)
            MyBase.New(InstallerInfo)
        End Sub

        Public Overrides Function ReadDnn() As PaFolderCollection

            'This is a very long subroutine and should probably be broken down
            'into a couple of smaller routines.  That would make it easier to 
            'maintain.
            InstallerInfo.Log.StartJob("Reading DNN file")

            'Determine if XML conforms to designated schema
            Dim DnnErrors As ArrayList = ValidateDnn()
            If DnnErrors.Count = 0 Then
                InstallerInfo.Log.AddInfo("DNN file is in valid 2.0 format.")

                Dim Folders As New PaFolderCollection

                Dim doc As New XmlDocument
                Dim buffer As New MemoryStream(InstallerInfo.DnnFile.Buffer, False)
                doc.Load(buffer)
                InstallerInfo.Log.AddInfo("xml loaded.")

                'Create an XmlNamespaceManager for resolving namespaces.
                'Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
                'nsmgr.AddNamespace("dnn", "urn:ModuleDefinitionSchema")

                Dim dnnRoot As XmlNode = doc.DocumentElement

                Dim FolderElement As XmlElement = DirectCast(dnnRoot.SelectSingleNode("folder"), XmlElement)
                'We will process each folder individually.  So we don't need to keep
                'as much in memory.

                'As we loop through each folder, we will save the data
                Dim Folder As New PaFolder

                'The folder/name node is a required node.  If empty, this will throw
                'an exception.
                Try
                    Folder.Name = FolderElement.SelectSingleNode("name").InnerText.Trim
                Catch ex As Exception
                    Throw New Exception("A folder must have a name value, aborting")
                End Try

                Try
                    Folder.ProviderType = FolderElement.SelectSingleNode("type").InnerText.Trim
                Catch ex As Exception
                    Throw New Exception("A folder must have a provider type, aborting")
                End Try

                ' loading files
                InstallerInfo.Log.AddInfo("Loading files info")
                Dim file As XmlElement
                For Each file In FolderElement.SelectNodes("files/file")
                    'The file/name node is a required node.  If empty, this will throw
                    'an exception.
                    Dim name As String
                    Try
                        name = file.SelectSingleNode("name").InnerText.Trim
                    Catch ex As Exception
                        Throw New Exception("A file must have a name value, aborting")
                    End Try
                    Dim paf As PaFile = CType(InstallerInfo.FileTable(name.ToLower), PaFile)
                    If paf Is Nothing Then
                        InstallerInfo.Log.AddFailure("File specified in the dnn could not be found in the zip file: " + name)
                    Else
                        'A file path may or may not exist
                        Dim pathElement As XmlElement = DirectCast(file.SelectSingleNode("path"), XmlElement)
                        If Not (pathElement Is Nothing) Then
                            Dim filepath As String = pathElement.InnerText.Trim
                            InstallerInfo.Log.AddInfo(String.Format("Found valid path ({0}) for {1}.", filepath, name))
                            paf.Path = filepath
                        Else
                            ' This is needed to override any file path which may exist in the zip file
                            paf.Path = ""
                        End If
                        Folder.Files.Add(paf)
                    End If
                Next file

                Folders.Add(Folder)

                If Not InstallerInfo.Log.Valid Then
                    Throw New Exception("Dnn load failed, aborting")
                End If
                InstallerInfo.Log.EndJob("Dnn load finished successfully")

                Return Folders
            Else
                Dim err As String
                For Each err In DnnErrors
                    InstallerInfo.Log.AddFailure(err)
                Next
                Throw New Exception("Invalid Dnn format, aborting")
            End If
        End Function

        Private Function ValidateDnn() As ArrayList
            'Create New Validator
            Dim ModuleValidator As New ModuleDefinitionValidator

            'Tell Validator what XML to use
            Dim xmlStream As New MemoryStream(InstallerInfo.DnnFile.Buffer)
            ModuleValidator.LoadXML(xmlStream)

            'Set the appropriate V2 schema
            Dim filename As String = Path.Combine(InstallerInfo.SitePath, "admin\PaUploader\ModuleDef_V2Provider.xsd")
            ModuleValidator.LoadSchema(filename)
            ModuleValidator.IsValid()
            Return ModuleValidator.Errors
        End Function
    End Class
End Namespace
