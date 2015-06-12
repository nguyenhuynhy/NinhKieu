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

    Public Class BreadCrumb

        Inherits SkinObject

        ' public attributes
        Public [Separator] As String
        Public [CssClass] As String
        Public [RootLevel] As String

        ' protected controls
        Protected WithEvents lblBreadCrumb As System.Web.UI.WebControls.Label

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

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If Not Page.IsPostBack Then

                ' public attributes
                Dim strSeparator As String
                If [Separator] <> "" Then
                    If [Separator].IndexOf("src=") <> -1 Then
                        [Separator] = Replace([Separator], "src=""", "src=""" & _portalSettings.ActiveTab.SkinPath)
                    End If
                    strSeparator = [Separator]
                Else
                    strSeparator = "&nbsp;<img alt=""*"" src=""" & Global.ApplicationPath & "/images/breadcrumb.gif"">&nbsp;"
                End If

                Dim strCssClass As String
                If [CssClass] <> "" Then
                    strCssClass = [CssClass]
                Else
                    strCssClass = "SelectedTab"
                End If

                Dim intRootLevel As Integer
                If [RootLevel] <> "" Then
                    intRootLevel = Integer.Parse([RootLevel])
                Else
                    intRootLevel = 1
                End If

                ' process bread crumbs
                Dim strBreadCrumbs As String = ""
                Dim intTab As Integer
                For intTab = intRootLevel To _portalSettings.BreadCrumbs.Count - 1
                    strBreadCrumbs += strSeparator & "<a href=""" & Global.ApplicationPath & "/DesktopDefault.aspx" & "?tabid=" & CType(_portalSettings.BreadCrumbs(intTab), TabStripDetails).TabId & """ class=""" & strCssClass & """>" & CType(_portalSettings.BreadCrumbs(intTab), TabStripDetails).TabName & "</a>"
                Next
                lblBreadCrumb.Text = Convert.ToString(strBreadCrumbs)

            End If

        End Sub

    End Class

End Namespace
