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
' CONTRACT, TORT OR OTHERWISE,ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Configuration
Imports System.Data

Namespace PortalQH

    Public Class LinkInfo

        ' local property declarations
        Private _ItemId As Integer
        Private _ModuleId As Integer
        Private _Title As String
        Private _Url As String
        Private _MobileUrl As String
        Private _ViewOrder As Integer
        Private _Description As String
        Private _NewWindow As Boolean
        Private _CreatedByUser As String
        Private _CreatedDate As Date
        Private _Clicks As Integer

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property ItemId() As Integer
            Get
                Return _ItemId
            End Get
            Set(ByVal Value As Integer)
                _ItemId = Value
            End Set
        End Property

        Public Property ModuleId() As Integer
            Get
                Return _ModuleId
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal Value As String)
                _Title = Value
            End Set
        End Property

        Public Property Url() As String
            Get
                Return _Url
            End Get
            Set(ByVal Value As String)
                _Url = Value
            End Set
        End Property

        Public Property MobileUrl() As String
            Get
                Return _MobileUrl
            End Get
            Set(ByVal Value As String)
                _MobileUrl = Value
            End Set
        End Property

        Public Property ViewOrder() As Integer
            Get
                Return _ViewOrder
            End Get
            Set(ByVal Value As Integer)
                _ViewOrder = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property NewWindow() As Boolean
            Get
                Return _NewWindow
            End Get
            Set(ByVal Value As Boolean)
                _NewWindow = Value
            End Set
        End Property

        Public Property CreatedByUser() As String
            Get
                Return _CreatedByUser
            End Get
            Set(ByVal Value As String)
                _CreatedByUser = Value
            End Set
        End Property

        Public Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As Date)
                _CreatedDate = Value
            End Set
        End Property

        Public Property Clicks() As Integer
            Get
                Return _Clicks
            End Get
            Set(ByVal Value As Integer)
                _Clicks = Value
            End Set
        End Property
    End Class

    Public Class LinkController

        Public Function GetLinks(ByVal ModuleId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetLinks(ModuleId), GetType(LinkInfo))

        End Function

        Public Function GetLink(ByVal ItemID As Integer, ByVal ModuleId As Integer) As LinkInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetLink(ItemID, ModuleId), GetType(LinkInfo)), LinkInfo)

        End Function

        Public Sub DeleteLink(ByVal ItemID As Integer)

            DataProvider.Instance().DeleteLink(ItemID)

        End Sub

        Public Sub AddLink(ByVal objLink As LinkInfo)

            DataProvider.Instance().AddLink(objLink.ModuleId, objLink.CreatedByUser, objLink.Title, objLink.Url, objLink.MobileUrl, objLink.ViewOrder.ToString, objLink.Description, objLink.NewWindow)

        End Sub

        Public Sub UpdateLink(ByVal objLink As LinkInfo)

            DataProvider.Instance().UpdateLink(objLink.ItemId, objLink.CreatedByUser, objLink.Title, objLink.Url, objLink.MobileUrl, objLink.ViewOrder.ToString, objLink.Description, objLink.NewWindow)

        End Sub

    End Class

End Namespace
