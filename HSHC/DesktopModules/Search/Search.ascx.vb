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

Imports System.Text.RegularExpressions

Namespace PortalQH

    Public MustInherit Class Search
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdGo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel
        Protected WithEvents lstResults As System.Web.UI.WebControls.DataList

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Not Page.IsPostBack Then

            End If

        End Sub

        Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGo.Click
            Try
                Dim objSearch As New SearchController

                Dim intMaxResults As Integer = -1
                If CType(Settings("maxresults"), String) <> "" Then
                    intMaxResults = CType(Settings("maxresults"), Integer)
                End If

                Dim objSecurity As New PortalSecurity

                lstResults.DataSource = objSearch.GetResults(PortalId, ModuleId, objSecurity.InputFilter(txtSearch.Text, PortalSecurity.FilterFlag.NoSQL), intMaxResults)
                lstResults.DataBind()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function FormatResult(ByVal TabId As Object, ByVal TabName As Object, ByVal ModuleTitle As Object, ByVal TitleField As Object, ByVal DescriptionField As Object, ByVal CreatedDateField As Object, ByVal CreatedByUserField As Object) As String
            Try
                Dim strResult As String

                strResult = "<hr noshade size=""1"">"
                strResult += "<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">"

                ' title
                strResult += "<tr><td width=""100%"">"
                strResult += "<a href=""" & FormatURL() & "?tabid=" & TabId.ToString & """ class=""CommandButton"">"
                If CType(Settings("maxtitle"), String) <> "" Then
                    strResult += Left(StripHTML(TitleField.ToString, txtSearch.Text), CType(Settings("maxtitle"), Integer)) & "..."
                Else
                    strResult += StripHTML(TitleField.ToString, txtSearch.Text)
                End If
                strResult += "</a>"
                strResult += "</td></tr>"

                If CType(Settings("showdescription"), String) <> "False" Then
                    If Not IsDBNull(DescriptionField) Then
                        strResult += "<tr><td width=""100%"">"
                        strResult += "<span class=""Normal"">"
                        If CType(Settings("maxdescription"), String) <> "" Then
                            strResult += Left(StripHTML(DescriptionField.ToString, txtSearch.Text), CType(Settings("maxdescription"), Integer)) & "..."
                        Else
                            strResult += StripHTML(DescriptionField.ToString, txtSearch.Text)
                        End If
                        strResult += "</span>"
                        strResult += "</td></tr>"
                    End If
                End If

                If CType(Settings("showaudit"), String) <> "False" Then
                    If IsDBNull(CreatedDateField) = False And IsDBNull(CreatedByUserField) = False Then
                        strResult += "<tr><td width=""100%"">"
                        strResult += "<span class=""Normal"">Updated: " & CreatedDateField.ToString & " By: " & CreatedByUserField.ToString & "</span>"
                        strResult += "</td></tr>"
                    End If
                End If

                If CType(Settings("showbreadcrumbs"), String) <> "False" Then
                    strResult += "<tr><td width=""100%"">"
                    strResult += GetBreadCrumbsRecursively(Convert.ToInt32(TabId))
                    strResult += "&nbsp;<span class=""Normal"">></span>&nbsp;"
                    strResult += "<a href=""" & FormatURL() & "?tabid=" & TabId.ToString & """ class=""CommandButton"">" & ModuleTitle.ToString & "</a>"
                    strResult += "</td></tr>"
                End If

                strResult += "</table>"

                Return strResult
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Function StripHTML(ByVal objHTML As Object, ByVal strSearch As String) As String
            Try

                Dim strOutput As String

                If Not IsDBNull(objHTML) Then
                    strOutput = objHTML.ToString

                    ' create regular expression object
                    Dim objRegExp1 As Regex = New Regex("<(.|\n)+?>", RegexOptions.IgnoreCase)

                    ' replace all HTML tag matches with the empty string
                    strOutput = objRegExp1.Replace(strOutput, "")

                    ' create regular expression object
                    Dim objRegExp2 As Regex = New Regex("&lt;(.|\n)+?&gt;", RegexOptions.IgnoreCase)

                    ' replace all HTML tag matches with the empty string
                    strOutput = objRegExp2.Replace(strOutput, "")

                    ' remove breaks
                    strOutput = Replace(strOutput, ControlChars.Lf, "")
                    strOutput = Replace(strOutput, Chr(13), "")

                    ' highlight search
                    strOutput = Replace(strOutput, strSearch, "<b>" & strSearch & "</b>", , , CompareMethod.Text)

                    Return strOutput
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Function GetBreadCrumbsRecursively(ByVal intTabId As Integer) As String
            Try
                Dim objTabs As New TabController

                Dim strBreadCrumbs As String = ""

                Dim objTab As TabInfo = objTabs.GetTab(intTabId)
                strBreadCrumbs += "&nbsp;<span class=""Normal"">></span>&nbsp;<a href=""" & FormatURL() & "?tabid=" & intTabId.ToString & """ class=""CommandButton"">" & objTab.TabName & "</a>"
                If Not IsDBNull(objTab.ParentId) Then
                    strBreadCrumbs = GetBreadCrumbsRecursively(objTab.ParentId) & strBreadCrumbs
                End If
                Return strBreadCrumbs
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Function FormatURL() As String
            Try

                Dim ServerPath As String

                ServerPath = Request.ApplicationPath
                If Not ServerPath.EndsWith("/") Then
                    ServerPath += "/"
                End If

                Return ServerPath & "DesktopDefault.aspx"
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function


    End Class

End Namespace
