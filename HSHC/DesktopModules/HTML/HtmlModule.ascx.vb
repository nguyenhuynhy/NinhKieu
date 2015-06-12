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

    Public MustInherit Class HtmlModule
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents HtmlHolder As System.Web.UI.HtmlControls.HtmlTableCell

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            ' base module properties
            MyBase.Actions.Add(GetNextActionID, "Edit", "", URL:=EditURL(), UseActionEvent:=True, Secure:=SecurityAccessLevel.Edit, Visible:=True)
            MyBase.HelpURL = "http://www.dotnetnuke.com/" & glbDefaultPage & "?tabid=452"
            MyBase.HelpFile = "HTML.txt"

        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load event handler on this User Control is
        ' used to render a block of HTML or text to the page.  
        ' The text/HTML to render is stored in the HtmlText 
        ' database table.  This method uses the PortalQH.HtmlTextDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain the selected item from the HtmlText table
                Dim objHTML As New HtmlTextController
                Dim objDr As HtmlTextInfo = objHTML.GetHtmlText(ModuleId)

                If Not objDr Is Nothing Then 'dr.Read() Then

                    ' Dynamically add the file content into the page
                    Dim content As String = Server.HtmlDecode(CType(objDr.DeskTopHTML, String))

                    HtmlHolder.Controls.Add(New LiteralControl(ManageUploadDirectory(content, PortalSettings.UploadDirectory)))

                End If

                '------------------------------------------------------------------------------------
                '-                        Menu Action Handler Registration                          -
                '------------------------------------------------------------------------------------
                'This finds a reference to the containing skin
                Dim ParentSkin As Skin = Skin.GetParentSkin(Me)
                'We should always have a ParentSkin, but need to make sure
                If Not ParentSkin Is Nothing Then
                    'Register our EventHandler as a listener on the ParentSkin so that it may tell us 
                    'when a menu has been clicked.
                    ParentSkin.RegisterModuleActionEvent(Me.ModuleId, AddressOf ModuleAction_Click)
                End If
                '-------------------------------------------------------------------------------------

                ' Close the datareader
                'dr.Close()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        Private Function ManageUploadDirectory(ByVal strHTML As String, ByVal strUploadDirectory As String) As String

            Dim P As Integer

            P = InStr(1, strHTML.ToLower, "src=""")
            While P <> 0
                ManageUploadDirectory = ManageUploadDirectory & Left(strHTML, P + 4)

                strHTML = Mid(strHTML, P + 5)

                ' add uploaddirectory if we are linking internally
                Dim strSRC As String = Left(strHTML, InStr(1, strHTML, """") - 1)
                If InStr(1, strSRC, "://") = 0 And Left(strSRC, 1) <> "/" Then
                    strHTML = strUploadDirectory & strHTML
                End If

                P = InStr(1, strHTML.ToLower, "src=""")
            End While

            ManageUploadDirectory = ManageUploadDirectory & strHTML

        End Function

        'This handles all ModuleAction events raised from the skin
        Public Sub ModuleAction_Click(ByVal sender As Object, ByVal e As ActionEventArgs)

            'We could get much fancier here by declaring each ModuleAction with a
            'Command and then using a Select Case statement to handle the various
            'commands.
            If e.Action.Url.Length > 0 Then
                Response.Redirect(e.Action.Url, True)
            End If

        End Sub

    End Class

End Namespace
