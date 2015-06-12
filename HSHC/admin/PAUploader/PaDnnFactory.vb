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
    Public Class PaDnnLoaderFactory

        Private _installerInfo As PaInstallInfo

        Public Sub New(ByVal InstallerInfo As PaInstallInfo)
            _installerInfo = InstallerInfo
        End Sub

        Public ReadOnly Property InstallerInfo() As PaInstallInfo
            Get
                Return _installerInfo
            End Get
        End Property

        Public Function GetDnnAdapter() As PaDnnAdapterBase

            Dim Version As ModuleDefinitionVersion = GetModuleVersion()

            Select Case Version
                Case ModuleDefinitionVersion.V1
                    Return New PaDnnAdapter_V1(InstallerInfo)
                Case ModuleDefinitionVersion.V2
                    Return New PaDnnAdapter_V2(InstallerInfo)
                Case ModuleDefinitionVersion.V2_Skin
                    Return New PaDnnAdapter_V2Skin(InstallerInfo)
                Case ModuleDefinitionVersion.V2_Provider
                    Return New PaDnnAdapter_V2Provider(InstallerInfo)
                Case ModuleDefinitionVersion.VUnknown
                    Throw New Exception("Invalid Dnn format, aborting")
            End Select

        End Function

        Public Function GetDnnInstaller() As PaDnnInstallerBase
            Dim Version As ModuleDefinitionVersion = GetModuleVersion()

            Select Case Version
                Case ModuleDefinitionVersion.V1
                    Return New PaDnnInstaller_V1(InstallerInfo)
                Case ModuleDefinitionVersion.V2
                    Return New PaDnnInstallerBase(InstallerInfo)
                Case ModuleDefinitionVersion.V2_Skin
                    Return New PaDnnInstaller_V2Skin(InstallerInfo)
                Case ModuleDefinitionVersion.V2_Provider
                    Return New PaDnnInstaller_V2Provider(InstallerInfo)
                Case ModuleDefinitionVersion.VUnknown
                    Throw New Exception("Invalid Dnn format, aborting")
            End Select

        End Function

        Private Function GetModuleVersion() As ModuleDefinitionVersion
            If Not InstallerInfo.DnnFile Is Nothing Then
                Dim buffer As New MemoryStream(InstallerInfo.DnnFile.Buffer, False)
                Dim xmldoc As New XmlTextReader(buffer)
                xmldoc.MoveToContent()

                'This test assumes provides a simple validation 
                Select Case xmldoc.LocalName.ToLower
                    Case "module"
                        Return ModuleDefinitionVersion.V1
                    Case "PortalQH"
                        Select Case xmldoc.GetAttribute("type")
                            Case "Module"
                                Return ModuleDefinitionVersion.V2
                            Case "SkinObject"
                                Return ModuleDefinitionVersion.V2_Skin
                            Case "Provider"
                                Return ModuleDefinitionVersion.V2_Provider
                            Case Else
                                Return ModuleDefinitionVersion.VUnknown
                        End Select
                    Case Else
                        Return ModuleDefinitionVersion.VUnknown
                End Select
            Else
                Return ModuleDefinitionVersion.VUnknown
            End If
        End Function
    End Class
End Namespace