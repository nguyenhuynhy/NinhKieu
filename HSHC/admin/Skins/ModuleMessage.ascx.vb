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

Namespace PortalQH.Skins

    Public Class ModuleMessage

        Inherits SkinObject

        Public Enum ModuleMessageType
            GreenSuccess
            YellowWarning
            RedError
        End Enum

        Public Text As String
        Public Heading As String
        Public IconType As ModuleMessageType
        Public IconImage As String

        ' protected controls
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
        Protected WithEvents imgIcon As System.Web.UI.WebControls.Image
        Protected WithEvents imgLogo As System.Web.UI.WebControls.Image

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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim strMessage As String

                'check to see if a url
                'was passed in for an icon
                If IconImage <> "" Then
                    strMessage += Me.Text
                    lblHeading.CssClass = "SubHead"
                    lblMessage.CssClass = "Normal"
                    imgIcon.ImageUrl = IconImage
                    imgIcon.Visible = True
                Else
                    Select Case IconType
                        Case Skins.ModuleMessage.ModuleMessageType.GreenSuccess
                            strMessage += Me.Text
                            lblHeading.CssClass = "SubHead"
                            lblMessage.CssClass = "Normal"
                            imgIcon.ImageUrl = "~/images/green-ok.gif"
                            imgIcon.Visible = True
                        Case Skins.ModuleMessage.ModuleMessageType.YellowWarning
                            strMessage += Me.Text
                            lblHeading.CssClass = "Normal"
                            lblMessage.CssClass = "Normal"
                            imgIcon.ImageUrl = "~/images/yellow-warning.gif"
                            imgIcon.Visible = True
                        Case Skins.ModuleMessage.ModuleMessageType.RedError
                            strMessage += Me.Text
                            lblHeading.CssClass = "NormalRed"
                            lblMessage.CssClass = "Normal"
                            imgIcon.ImageUrl = "~/images/red-error.gif"
                            imgIcon.Visible = True
                    End Select
                End If
                lblMessage.Text = strMessage
                If Heading <> "" Then
                    lblHeading.Visible = True
                    lblHeading.Text = Heading + "<br/>"
                End If

            Catch exc As Exception 'Control failed to load
                ProcessModuleLoadException(Me, exc, False)
            End Try
        End Sub

    End Class

End Namespace
