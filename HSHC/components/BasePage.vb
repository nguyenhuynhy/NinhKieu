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

Imports System
Imports System.Diagnostics

Namespace PortalQH

    Public Class BasePage

        Inherits System.Web.UI.Page

        Private Sub Page_Error(ByVal Source As Object, ByVal e As System.EventArgs) Handles MyBase.Error
            Dim exc As Exception = Server.GetLastError
            Dim strURL As String = ApplicationURL()
            If Not Request.QueryString("error") Is Nothing Then
                strURL += "&error=terminate"
            Else
                strURL += "&error=" & Server.UrlEncode(exc.Message)
                If Not IsAdminControl() Then
                    strURL += "&content=0"
                End If
            End If
            ProcessPageLoadException(exc, strURL)
        End Sub

        '
        ' This method overrides the Render() method for the page and moves the ViewState
        ' from its default location at the top of the page to the bottom of the page. This
        ' results in better search engine spidering. 
        '
        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter
            Dim htmlWriter As HtmlTextWriter = New HtmlTextWriter(stringWriter)
            MyBase.Render(htmlWriter)
            Dim html As String = stringWriter.ToString()
            Dim StartPoint As Integer = html.IndexOf("<input type=""hidden"" name=""__VIEWSTATE""")
            Dim EndPoint As Integer = html.IndexOf("/>", StartPoint) + 2
            Dim ViewStateInput As String = html.Substring(StartPoint, EndPoint - StartPoint)
            html = html.Remove(StartPoint, EndPoint - StartPoint)
            Dim FormEndStart As Integer = html.IndexOf("</form>") - 1
            html = html.Insert(FormEndStart, ViewStateInput)
            writer.Write(html)
        End Sub

    End Class 'BasePage

End Namespace
