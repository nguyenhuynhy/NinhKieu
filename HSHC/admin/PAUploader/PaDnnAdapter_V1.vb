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
    Public Class PaDnnAdapter_V1
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
                InstallerInfo.Log.AddInfo("DNN file is in valid 1.0 format.")

                Dim Folders As New PaFolderCollection

                Dim doc As New XmlDocument
                Dim buffer As New MemoryStream(InstallerInfo.DnnFile.Buffer, False)
                doc.Load(buffer)
                InstallerInfo.Log.AddInfo("xml loaded.")

                Dim dnnRoot As XmlNode = doc.DocumentElement

                Dim TempModuleDefinitionID As Integer = 0


                Dim Folder As New PaFolder

                Try
                    Folder.Name = dnnRoot.SelectSingleNode("folder").InnerText.Trim
                Catch ex As Exception
                    Throw New Exception("A folder must have a name value, aborting")
                End Try

                Try
                    Folder.Description = dnnRoot.SelectSingleNode("description").InnerText.Trim
                Catch ex As Exception
                    Throw New Exception("A folder must have a description, aborting")
                End Try

                ' loading files
                InstallerInfo.Log.AddInfo("Loading files info")
                Dim file As XmlElement
                For Each file In dnnRoot.SelectNodes("files/file")
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
                        ' The earlier versions allowed files to be defined which didn't exist in the zip
                        ' InstallerInfo.Log.AddFailure("File specified in the dnn could not be found in the zip file: " + name)
                        ' So we are just going to present the error but not stop....
                        InstallerInfo.Log.AddWarning("File specified in the dnn could not be found in the zip file: " + name)

                    Else
                        paf.Path = Folder.Name
                        Folder.Files.Add(paf)
                    End If
                Next file

                ' add dnn file to collection ( if it does not exist already )
                If Folder.Files.Contains(InstallerInfo.DnnFile) = False Then
                    Folder.Files.Add(InstallerInfo.DnnFile)
                End If

                InstallerInfo.Log.AddInfo("Loading Modules info")

                Dim ModuleDef As New ModuleDefinitionInfo

                Dim friendlyNameElement As XmlElement = DirectCast(dnnRoot.SelectSingleNode("friendlyname"), XmlElement)
                If Not friendlyNameElement Is Nothing Then
                    ModuleDef.FriendlyName = friendlyNameElement.InnerText.Trim
                End If

                ModuleDef.TempModuleID = TempModuleDefinitionID
                'We need to ensure that admin order is null for "User" modules

                Folder.Modules.Add(ModuleDef)

                ' Load desktopsrc --------------------------------------------------------
                InstallerInfo.Log.AddInfo(String.Format("Loading Control info for '{0}' module", ModuleDef.FriendlyName))
                Dim DesktopControlDef As New ModuleControlInfo

                Try
                    DesktopControlDef.ControlSrc = Path.Combine(Folder.Name, dnnRoot.SelectSingleNode("desktopsrc").InnerText.Trim).Replace("\"c, "/"c)
                Catch ex As Exception
                    Throw New Exception("A module control must have a Desktopsrc value, aborting")
                End Try


                'This is a temporary relationship since the ModuleDef has not been saved to the db
                'it does not have a valid ModuleDefID.  Once it is saved then we can update the
                'ModuleControlDef with the correct value.
                DesktopControlDef.ModuleDefID = ModuleDef.TempModuleID

                Folder.Controls.Add(DesktopControlDef)

                ' Load editsrc --------------------------------------------------------
                InstallerInfo.Log.AddInfo(String.Format("Loading Control info for '{0}' module", ModuleDef.FriendlyName))
                Dim EditControlDef As New ModuleControlInfo

                Dim editsrcElement As XmlElement = DirectCast(dnnRoot.SelectSingleNode("editsrc"), XmlElement)
                If Not editsrcElement Is Nothing Then
                    EditControlDef.ControlSrc = Path.Combine(Folder.Name, editsrcElement.InnerText.Trim).Replace("\"c, "/"c)

                    ' In Version 1 we have to guess about the correct values
                    EditControlDef.ControlKey = "Edit"
                    EditControlDef.ControlTitle = "Edit " & ModuleDef.FriendlyName
                    EditControlDef.ControlType = SecurityAccessLevel.Edit

                    Dim iconElement As XmlElement = DirectCast(dnnRoot.SelectSingleNode("editmoduleicon"), XmlElement)
                    If Not iconElement Is Nothing Then
                        EditControlDef.IconFile = iconElement.InnerText.Trim
                    End If
                End If

                'This is a temporary relationship since the ModuleDef has not been saved to the db
                'it does not have a valid ModuleDefID.  Once it is saved then we can update the
                'ModuleControlDef with the correct value.
                EditControlDef.ModuleDefID = ModuleDef.TempModuleID

                Folder.Controls.Add(EditControlDef)


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
            Dim filename As String = Path.Combine(InstallerInfo.SitePath, "admin\PaUploader\ModuleDef_V1.xsd")
            ModuleValidator.LoadSchema(filename)
            ModuleValidator.IsValid()
            Return ModuleValidator.Errors
        End Function
    End Class
End Namespace
