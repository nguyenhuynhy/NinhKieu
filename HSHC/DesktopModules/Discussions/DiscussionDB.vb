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

    Public Class DiscussionInfo

        Private _ItemID As Integer
        Private _ModuleID As Integer
        Private _Title As String
        Private _Body As String
        Private _DisplayOrder As String
        Private _Parent As String
        Private _ChildCount As String
        Private _CreatedByUser As String
        Private _CreatedDate As Date
        Private _ParentID As Integer
        Private _Indent As String

        ' initialization
        Public Sub New()
        End Sub

        Public Property ItemID() As Integer
            Get
                Return _ItemID
            End Get
            Set(ByVal Value As Integer)
                _ItemID = Value
            End Set
        End Property
        Public Property ModuleID() As Integer
            Get
                Return _ModuleID
            End Get
            Set(ByVal Value As Integer)
                _ModuleID = Value
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
        Public Property Body() As String
            Get
                Return _Body
            End Get
            Set(ByVal Value As String)
                _Body = Value
            End Set
        End Property
        Public Property DisplayOrder() As String
            Get
                Return _DisplayOrder
            End Get
            Set(ByVal Value As String)
                _DisplayOrder = Value
            End Set
        End Property
        Public Property Parent() As String
            Get
                Return _Parent
            End Get
            Set(ByVal Value As String)
                _Parent = Value
            End Set
        End Property
        Public Property ChildCount() As String
            Get
                Return _ChildCount
            End Get
            Set(ByVal Value As String)
                _ChildCount = Value
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
        Public Property ParentID() As Integer
            Get
                Return _ParentID
            End Get
            Set(ByVal Value As Integer)
                _ParentID = Value
            End Set
        End Property
        Public Property Indent() As String
            Get
                Return _Indent
            End Get
            Set(ByVal Value As String)
                _Indent = Value
            End Set
        End Property
    End Class

    Public Class DiscussionController

        Public Function GetTopLevelMessages(ByVal ModuleId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetTopLevelMessages(ModuleId), GetType(DiscussionInfo))

        End Function


        Public Function GetThreadMessages(ByVal Parent As String) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetThreadMessages(Parent), GetType(DiscussionInfo))

        End Function


        Public Function GetMessage(ByVal ItemId As Integer, ByVal ModuleId As Integer) As DiscussionInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetMessage(ItemId, ModuleId), GetType(DiscussionInfo)), DiscussionInfo)

        End Function


        Public Sub DeleteMessage(ByVal ItemId As Integer, ByVal ModuleId As Integer)

            Dim dr As IDataReader = DataProvider.Instance().GetMessage(ItemId, ModuleId)
            If dr.Read Then
                Dim Start As Integer = Len(dr("DisplayOrder")) - 18
                DataProvider.Instance().DeleteMessage(ModuleId, Start, Mid(Convert.ToString(dr("DisplayOrder")), Start, 19))
            End If
            dr.Close()

        End Sub


        Public Sub AddMessage(ByVal objDiscussion As DiscussionInfo)

            objDiscussion.DisplayOrder = ""
            Dim dr As IDataReader = DataProvider.Instance().GetMessageByParentId(objDiscussion.ParentID)
            If dr.Read Then
                If Not IsDBNull(dr("DisplayOrder")) Then
                    objDiscussion.DisplayOrder = Convert.ToString(dr("DisplayOrder"))
                End If
            End If
            dr.Close()

            Dim objSecurity As New PortalSecurity

            DataProvider.Instance().AddMessage(objSecurity.InputFilter(objDiscussion.Title, PortalSecurity.FilterFlag.NoMarkup), objSecurity.InputFilter(objDiscussion.Body, PortalSecurity.FilterFlag.NoMarkup), objDiscussion.DisplayOrder & Now.ToString("s"), objDiscussion.CreatedByUser, objDiscussion.ModuleID)

        End Sub


        Public Sub UpdateMessage(ByVal objDiscussion As DiscussionInfo)

            Dim objSecurity As New PortalSecurity

            DataProvider.Instance().UpdateMessage(objDiscussion.ItemID, objSecurity.InputFilter(objDiscussion.Title, PortalSecurity.FilterFlag.NoMarkup), objSecurity.InputFilter(objDiscussion.Body, PortalSecurity.FilterFlag.NoMarkup), objDiscussion.CreatedByUser)

        End Sub

    End Class

End Namespace
