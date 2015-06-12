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
Namespace PortalQH

    Public Class Container

        Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            '
            ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
            '
            InitializeComponent()

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' iterate page controls
            Dim ctlControl As Control
            For Each ctlControl In Me.Controls
                ' update the image paths
                If ctlControl.GetType().ToString = "System.Web.UI.HtmlControls.HtmlImage" Then
                    CType(ctlControl, HtmlImage).Src = Me.TemplateSourceDirectory & "/" & CType(ctlControl, HtmlImage).Src
                End If
                If ctlControl.GetType().ToString = "System.Web.UI.HtmlControls.HtmlTableCell" Then
                    Dim strBackground As String = CType(ctlControl, HtmlTableCell).Attributes.Item("background")
                    If strBackground <> "" Then
                        CType(ctlControl, HtmlTableCell).Attributes.Item("background") = Me.TemplateSourceDirectory & "/" & strBackground
                    End If
                End If
            Next

        End Sub

        Public Shared Function GetPortalModuleControl(ByVal objControl As UserControl) As PortalModuleControl

            Dim objPortalModuleControl As PortalModuleControl

            Dim ctlPanel As Panel = CType(objControl.Parent.FindControl("ModuleContent"), Panel)

            If Not ctlPanel Is Nothing Then
                Try
                    objPortalModuleControl = CType(ctlPanel.Controls(0), PortalModuleControl)
                Catch
                    ' module was not loaded correctly
                End Try
            End If

            If objPortalModuleControl Is Nothing Then
                objPortalModuleControl = New PortalModuleControl
                objPortalModuleControl.ModuleConfiguration = New ModuleSettings
            End If

            Return objPortalModuleControl

        End Function

    End Class

End Namespace