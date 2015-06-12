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
Imports System
Imports System.IO
Imports System.Xml

Namespace PortalQH

    Public Class Upgrade

        Public Shared Sub AutoUpgrade()

            Dim strUpgrade As String = VerifyFolderPermissions()

            If strUpgrade = "" Then
                ' Get the name of the data provider
                Dim objProviderConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration("data")

                ' get path to script files
                Dim strProviderPath As String = PortalSettings.GetProviderPath()
                If Not strProviderPath.StartsWith("ERROR:") Then
                    Dim strAssemblyVersion As String
                    Dim strDatabaseVersion As String

                    ' get current assembly version
                    Dim intAssemblyMajor As Integer = System.Diagnostics.FileVersionInfo.GetVersionInfo(Global.AssemblyPath).ProductMajorPart()
                    Dim intAssemblyMinor As Integer = System.Diagnostics.FileVersionInfo.GetVersionInfo(Global.AssemblyPath).ProductMinorPart()
                    Dim intAssemblyBuild As Integer = System.Diagnostics.FileVersionInfo.GetVersionInfo(Global.AssemblyPath).ProductBuildPart()
                    strAssemblyVersion = Format(intAssemblyMajor, "00") & Format(intAssemblyMinor, "00") & Format(intAssemblyBuild, "00")

                    ' get current database version
                    Dim dr As IDataReader = PortalSettings.GetDatabaseVersion
                    If dr.Read Then
                        strDatabaseVersion = Format(dr("Major"), "00") & Format(dr("Minor"), "00") & Format(dr("Build"), "00")
                    End If
                    dr.Close()

                    ' get list of script files
                    Dim arrScriptFiles As New ArrayList
                    Dim strFile As String
                    Dim arrFiles As String() = Directory.GetFiles(strProviderPath, "*." & objProviderConfiguration.DefaultProvider)
                    For Each strFile In arrFiles
                        If Len(Path.GetFileName(strFile)) = 9 + Len(objProviderConfiguration.DefaultProvider) Then ' ##.##.##.DefaultProvider
                            arrScriptFiles.Add(strFile)
                        End If
                    Next
                    arrScriptFiles.Sort()

                    Dim strScriptVersion As String
                    Dim strScriptFile As String
                    For Each strScriptFile In arrScriptFiles
                        strScriptVersion = Path.GetFileNameWithoutExtension(strScriptFile)

                        If strScriptVersion.Replace(".", "") > strDatabaseVersion And strScriptVersion.Replace(".", "") <= strAssemblyVersion Then
                            Dim arrVersion As Array = strScriptVersion.Split(CType(".", Char))
                            Dim intMajor As Integer = CType(arrVersion.GetValue((0)), Integer)
                            Dim intMinor As Integer = CType(arrVersion.GetValue((1)), Integer)
                            Dim intBuild As Integer = CType(arrVersion.GetValue((2)), Integer)

                            ' verify script has not already been run
                            If Not PortalSettings.FindDatabaseVersion(intMajor, intMinor, intBuild) Then
                                ' upgrade database schema
                                PortalSettings.UpgradeDatabaseSchema(intMajor, intMinor, intBuild)

                                ' read script file for version
                                Dim objStreamReader As StreamReader
                                objStreamReader = File.OpenText(strScriptFile)
                                Dim strScript As String = objStreamReader.ReadToEnd
                                objStreamReader.Close()

                                ' execute SQL installation script
                                Dim strExceptions As String = PortalSettings.ExecuteScript(strScript)

                                ' perform file system upgrades
                                strExceptions += UpgradeFileSystem(strScriptVersion)

                                ' log the results
                                Try
                                    Dim objStream As StreamWriter
                                    objStream = File.CreateText(strScriptFile.Replace("." & objProviderConfiguration.DefaultProvider, "") & ".log")
                                    objStream.WriteLine(strExceptions)
                                    objStream.Close()
                                Catch
                                    ' does not have permission to create the log file
                                End Try

                                PortalSettings.UpdateDatabaseVersion(intMajor, intMinor, intBuild)
                            End If
                        End If
                    Next
                Else
                    ' upgrade error
                    Dim objStreamReader As StreamReader
                    objStreamReader = File.OpenText(HttpContext.Current.Server.MapPath("~/500.htm"))
                    Dim strHTML As String = objStreamReader.ReadToEnd
                    objStreamReader.Close()
                    strHTML = Replace(strHTML, "[MESSAGE]", strProviderPath)
                    HttpContext.Current.Response.Write(strHTML)
                    HttpContext.Current.Response.End()
                End If
            Else
                ' folder permissions not correct
                Dim objStreamReader As StreamReader
                objStreamReader = File.OpenText(HttpContext.Current.Server.MapPath("~/403-3.htm"))
                Dim strHTML As String = objStreamReader.ReadToEnd
                objStreamReader.Close()
                strHTML = Replace(strHTML, "[MESSAGE]", strUpgrade)
                HttpContext.Current.Response.Write(strHTML)
                HttpContext.Current.Response.End()
            End If

        End Sub

        Private Shared Function UpgradeFileSystem(ByVal Version As String) As String

            Dim strExceptions As String = ""

            Select Case Version
                Case "02.00.00"
                    ' change portal upload directory from GUID to ID
                    Dim strServerPath As String = HttpContext.Current.Request.MapPath(Global.ApplicationPath)
                    Dim dr As IDataReader = DataProvider.Instance().GetPortals()
                    While dr.Read
                        ' if GUID folder exists
                        If Directory.Exists(strServerPath & "\Portals\" & dr("GUID").ToString) = True Then
                            ' if ID folder does not exist
                            If Directory.Exists(strServerPath & "\Portals\" & dr("PortalID").ToString) = False Then
                                ' move GUID folder to ID folder
                                Try
                                    Directory.Move(strServerPath & "\Portals\" & dr("GUID").ToString, strServerPath & "\Portals\" & dr("PortalID").ToString)
                                Catch ex As Exception
                                    ' error moving the directory - security issue?
                                    strExceptions += "Could Not Move Folder " & strServerPath & "\Portals\" & dr("GUID").ToString & " To " & strServerPath & "\Portals\" & dr("PortalID").ToString & ". Error: " & ex.Message & vbCrLf
                                End Try
                            Else ' ID folder already exists - previous conversion has already migrated the data - this should only occur on a new DB install over an existing application install
                                ' remove the GUID folder
                                Try
                                    Directory.Delete(strServerPath & "\Portals\" & dr("GUID").ToString)
                                Catch ex As Exception
                                    ' error removing the directory - maybe there are files in it?
                                    strExceptions += "Could Not Delete Folder " & strServerPath & "\Portals\" & dr("GUID").ToString & ". Error: " & ex.Message & vbCrLf
                                End Try
                            End If
                        End If
                    End While
                    dr.Close()
            End Select

            Return strExceptions

        End Function


        Private Shared Function VerifyFolderPermissions() As String
            Try
                Dim strFolder As String = HttpContext.Current.Server.MapPath(Global.ApplicationPath)

                If Directory.Exists(strFolder & "\verify") Then
                    Directory.Delete(strFolder & "\verify", True)
                End If

                ' test folder write permission
                Directory.CreateDirectory(strFolder & "\verify")

                ' test folder delete permission
                Directory.Delete(strFolder & "\verify", True)

                If File.Exists(strFolder & "\verify.txt") Then
                    File.Delete(strFolder & "\verify.txt")
                End If

                ' test file write permission
                Dim objStream As StreamWriter
                objStream = File.CreateText(strFolder & "\verify.txt")
                objStream.WriteLine("")
                objStream.Close()

                ' test file delete permission
                File.Delete(strFolder & "\verify.txt")

                Return ""
            Catch ex As Exception ' security error
                Return ex.Message
            End Try

        End Function

    End Class

End Namespace