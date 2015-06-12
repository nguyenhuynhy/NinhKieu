﻿'
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

Imports System.Web.UI.UserControl

Namespace PortalQH.Skins

    Public Class Help

        Inherits SkinObject

        ' public attributes
        Public [CssClass] As String

        ' protected controls
        Protected WithEvents hypHelp As System.Web.UI.WebControls.HyperLink

#Region " Web Form Designer Generated Code "


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        'Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    Try
        '        ' Obtain PortalSettings from Current Context
        '        Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

        '        If Not Page.IsPostBack Then

        '            ' public attributes
        '            If [CssClass] <> "" Then
        '                hypHelp.CssClass = [CssClass]
        '            End If

        '            If Request.IsAuthenticated = True Then

        '                If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) Then
        '                    hypHelp.Text = "Help"
        '                    hypHelp.NavigateUrl = "mailto:" & Convert.ToString(_portalSettings.HostSettings("HostEmail")) & "?subject=" & _portalSettings.PortalName & " Support Request"
        '                    hypHelp.Visible = True
        '                Else
        '                    hypHelp.Text = "Help"
        '                    hypHelp.NavigateUrl = "mailto:" & _portalSettings.Email & "?subject=" & _portalSettings.PortalName & " Support Request"
        '                    hypHelp.Visible = True
        '                End If

        '            End If

        '        End If

        '    Catch exc As Exception 'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'hypHelp.Text = "Trợ giúp |"
            'hypHelp.NavigateUrl = "~/Help/Tai lieu HuongDanSuDung v1.0.doc"
            'hypHelp.Visible = True
        End Sub
    End Class

End Namespace