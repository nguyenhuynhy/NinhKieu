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
Imports System.Configuration
Namespace PortalQH.Skins

    Public Class CurrentDate

        Inherits SkinObject

        ' public attributes
        Public [CssClass] As String
        Public [DateFormat] As String

        ' protected controls
        Protected WithEvents lblDate As System.Web.UI.WebControls.Label

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
                If [CssClass] <> "" Then
                    lblDate.CssClass = [CssClass]
                End If

                'If [DateFormat] <> "" Then
                '    lblDate.Text = Format(Now(), [DateFormat])
                'Else
                '    lblDate.Text = Now().ToLongDateString
                'End If
                lblDate.Text = "Ngày " & Format(Now(), "dd/MM/yyyy")
                'lblDate.Text = ShowVietTime(Now().ToShortDateString)

            End If
        End Sub

        Private Function ShowVietTime(ByVal dday As String) As String
            Dim intDate As Date
            Dim intDay As Integer
            Dim intWeek As Integer
            Dim intMonth As Integer
            Dim intYear As Integer
            intDate = CDate(dday)
            intWeek = Weekday(intDate) - 1
            intDay = Day(intDate)
            intMonth = Month(intDate)
            intYear = Year(intDate)
            Dim VietDay As String
            Select Case intWeek
                Case 1 : VietDay = "Thứ hai"
                Case 2 : VietDay = "Thứ ba"
                Case 3 : VietDay = "Thứ tư"
                Case 4 : VietDay = "Thứ năm"
                Case 5 : VietDay = "Thứ sáu"
                Case 6 : VietDay = "Thứ bảy"
                Case 0 : VietDay = "Chủ nhật"
            End Select

            Return (VietDay & ", ngày " & intDay & " tháng " & intMonth & " năm " & intYear)
        End Function

    End Class

End Namespace
