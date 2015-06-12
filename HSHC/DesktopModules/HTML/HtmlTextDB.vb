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
Imports System.Configuration
Imports System.Data

Namespace PortalQH
    Public Class HtmlTextInfo
        ' local property declarations
        Private _ModuleId As Integer
        Private _DeskTopHTML As String
        Private _MobileSummary As String
        Private _MobileDetails As String

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property ModuleId() As Integer
            Get
                Return _ModuleId
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property
        Public Property DeskTopHTML() As String
            Get
                Return _DeskTopHTML
            End Get
            Set(ByVal Value As String)
                _DeskTopHTML = Value
            End Set
        End Property

        Public Property MobileSummary() As String
            Get
                Return _MobileSummary
            End Get
            Set(ByVal Value As String)
                _MobileSummary = Value
            End Set
        End Property

        Public Property MobileDetails() As String
            Get
                Return _MobileDetails
            End Get
            Set(ByVal Value As String)
                _MobileDetails = Value
            End Set
        End Property

    End Class
    Public Class HtmlTextController


        Public Function GetHtmlText(ByVal moduleId As Integer) As HtmlTextInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetHtmlText(moduleId), GetType(HtmlTextInfo)), HtmlTextInfo)

        End Function


        Public Sub UpdateHtmlText(ByVal moduleId As Integer, ByVal desktopHtml As String, ByVal mobileSummary As String, ByVal mobileDetails As String)

            Dim objHTML As New HtmlTextController
            Dim objText As HtmlTextInfo = objHTML.GetHtmlText(moduleId)

            If Not objText Is Nothing Then
                DataProvider.Instance().UpdateHtmlText(moduleId, desktopHtml, mobileSummary, mobileDetails)
            Else
                DataProvider.Instance().AddHtmlText(moduleId, desktopHtml, mobileSummary, mobileDetails)
            End If

        End Sub

    End Class

End Namespace
