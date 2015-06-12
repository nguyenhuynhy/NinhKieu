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
Imports System.Text
Namespace PortalQH

    Public MustInherit Class IFrame
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents lblIFrame As System.Web.UI.WebControls.Label
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel
        Protected WithEventspnlModuleContent As System.Web.UI.WebControls.Panel


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            MyBase.Actions.Add(GetNextActionID, "Edit IFrame Options", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strUserID As String
            If Not Session("UserID") Is Nothing Then
                strUserID = CType(Session("UserID"), String)
            Else
                strUserID = ""
            End If
            Try
                If (CType(Settings("src"), String)) <> "" Then
                    Dim FrameText As New StringBuilder
                    FrameText.Append("<iframe frameborder=""")
                    FrameText.Append(CType(Settings("border"), String))
                    FrameText.Append(""" src=""")
                    'FrameText.Append(AddHTTP(CType(Settings("src"), String) & "?UID=" & strUserID & "&Sp=1"))
                    If InStr(CType(Settings("src"), String), "?") > 0 Or InStr(CType(Settings("src"), String), ".nsf") > 0 Then
                        FrameText.Append(AddHTTP(CType(Settings("src"), String)))
                    Else
                        FrameText.Append(AddHTTP(CType(Settings("src"), String) & "?UID=" & strUserID & "&Sp=1"))
                    End If
                    FrameText.Append(""" height=""")
                    FrameText.Append(CType(Settings("height"), String))
                    FrameText.Append(""" width=""")
                    FrameText.Append(CType(Settings("width"), String))
                    FrameText.Append(""" title=""")
                    FrameText.Append(CType(Settings("title"), String))
                    FrameText.Append(""" scrolling=""")
                    FrameText.Append(CType(Settings("scrolling"), String))
                    FrameText.Append(""">Your Browser Does Not Support Frames</iframe>")
                    lblIFrame.Text = FrameText.ToString

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
