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

    Public Class Links

        Inherits SkinObject

        ' public attributes
        Public [Separator] As String
        Public [CssClass] As String
        Public [Level] As String
        Public [Alignment] As String

        ' protected controls
        Protected WithEvents lblLinks As System.Web.UI.WebControls.Label

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
                        [Separator] = Replace([Separator], "src=", "src=" & _portalSettings.ActiveTab.SkinPath)
                    End If
                    strSeparator = Replace([Separator], " ", "&nbsp;")
                Else
                    strSeparator = "&nbsp;&nbsp;"
                End If

                Dim strCssClass As String
                If [CssClass] <> "" Then
                    strCssClass = [CssClass]
                Else
                    strCssClass = "OtherTabs"
                End If

                strSeparator = "<span class=""" & strCssClass & """>" & strSeparator & "</span>"

                ' build links
                Dim strLinks As String = ""

                strLinks = BuildLinks([Level], [Alignment], strSeparator, strCssClass)

                If strLinks = "" Then
                    strLinks = BuildLinks("", [Alignment], strSeparator, strCssClass)
                End If

                lblLinks.Text = strLinks

            End If

        End Sub

        Private Function BuildLinks(ByVal Level As String, ByVal Alignment As String, ByVal strSeparator As String, ByVal strCssClass As String) As String

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim strLinks As String = ""
            Dim strLoop As String
            Dim intIndex As Integer

            For intIndex = 0 To _portalSettings.DesktopTabs.Count - 1

                Dim objTab As TabStripDetails = CType(_portalSettings.DesktopTabs(intIndex), TabStripDetails)

                If objTab.IsVisible = True And objTab.IsDeleted = False Then
                    If PortalSecurity.IsInRoles(objTab.AuthorizedRoles) = True Then
                        strLoop = ""
                        If [Alignment] = "Vertical" Then
                            If strLinks <> "" Then
                                strLoop = "<br>" & strSeparator
                            Else
                                strLoop = strSeparator
                            End If
                        Else
                            If strLinks <> "" Then
                                strLoop = strSeparator
                            End If
                        End If

                        Select Case Level
                            Case "Same", ""
                                If objTab.ParentId = _portalSettings.ActiveTab.ParentId Then
                                    strLinks += strLoop & AddLink(objTab.TabName, objTab.URL, strCssClass)
                                End If
                            Case "Child"
                                If objTab.ParentId = _portalSettings.ActiveTab.TabId Then
                                    strLinks += strLoop & AddLink(objTab.TabName, objTab.URL, strCssClass)
                                End If
                            Case "Parent"
                                If objTab.TabId = _portalSettings.ActiveTab.ParentId Then
                                    strLinks += strLoop & AddLink(objTab.TabName, objTab.URL, strCssClass)
                                End If
                            Case "Root"
                                If objTab.Level = 0 Then
                                    strLinks += strLoop & AddLink(objTab.TabName, objTab.URL, strCssClass)
                                End If
                        End Select
                    End If
                End If

            Next intIndex

            Return strLinks

        End Function

        Private Function AddLink(ByVal strTabName As String, ByVal strURL As String, ByVal strCssClass As String) As String

            Return "<a class=""" & strCssClass & """ href=""" & strURL & """>" & strTabName & "</a>"

        End Function

    End Class

End Namespace
