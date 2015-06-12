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
    Public Class PaDnnInstaller_V2Skin
        Inherits PaDnnInstallerBase

        Private _installerInfo As PaInstallInfo

        Public Sub New(ByVal InstallerInfo As PaInstallInfo)
            MyBase.New(InstallerInfo)
        End Sub

        Protected Overrides Sub RegisterModules(ByVal Folder As PaFolder, ByVal Modules As ArrayList, ByVal Controls As ArrayList)

            InstallerInfo.Log.AddInfo("Registering Controls")

            Dim objModuleControls As New ModuleControlController

            Dim objModuleControl As ModuleControlInfo
            For Each objModuleControl In Controls
                ' Skins Objects have a null ModuleDefID
                objModuleControl.ModuleDefID = Null.NullInteger

                ' check if control exists
                Dim objModuleControl2 As ModuleControlInfo = objModuleControls.GetModuleControlByKeyAndSrc(Null.NullInteger, objModuleControl.ControlKey, objModuleControl.ControlSrc)
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
