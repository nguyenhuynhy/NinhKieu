'
' DotNetNuke -  http://www.dotnetnuke.com
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

    Public MustInherit Class Announcements

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lstAnnouncements As System.Web.UI.WebControls.DataList

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            ' declare module actions
            MyBase.Actions.Add(GetNextActionID, "Add New Announcement", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load event handler on this User Control is used to
        ' obtain a DataSet of announcement information from the Announcements
        ' table, and then databind the results to a templated DataList
        ' server control.  It uses the DotNetNuke.AnnouncementsDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain announcement information from Announcements table
                ' and bind to the datalist control
                Dim announcements As New AnnouncementsController

                ' DataBind Announcements to DataList Control
                lstAnnouncements.DataSource = announcements.GetAnnouncements(ModuleId)
                lstAnnouncements.DataBind()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Function FormatURL(ByVal Link As String, ByVal ID As Integer) As String

            If InStr(1, Link, "://") = 0 Then
                If IsNumeric(Link) Then ' internal tab link
                    Link = Global.ApplicationPath & "/DesktopDefault.aspx?tabid=" & Link
                End If
            End If

            Return Global.ApplicationPath & "/admin/Portal/LinkClick.aspx?tabid=" & TabId & "&table=Announcements&field=ItemID&id=" & ID.ToString & "&link=" & Server.UrlEncode(Link)

        End Function


        Private Sub lstAnnouncements_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnnouncements.SelectedIndexChanged

        End Sub
    End Class

End Namespace
