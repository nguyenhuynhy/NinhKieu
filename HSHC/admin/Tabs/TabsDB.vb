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
' CONTRACT, TORT OR OTHERWISE,ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Globalization

Namespace PortalQH

    '*********************************************************************
    '
    ' TabItem Class
    '
    ' This class encapsulates the basic attributes of a Tab, and is used
    ' by the administration pages when manipulating tabs.  TabItem implements 
    ' the IComparable interface so that an ArrayList of TabItems may be sorted
    ' by TabOrder, using the ArrayList's Sort() method.
    '
    '*********************************************************************

    Public Class TabItem
        Implements IComparable

        Private _order As Integer
        Private _name As String
        Private _id As Integer
        Private _parent As Integer


        Public Property TabOrder() As Integer

            Get
                Return _order
            End Get
            Set(ByVal Value As Integer)
                _order = Value
            End Set
        End Property


        Public Property TabName() As String

            Get
                Return _name
            End Get
            Set(ByVal Value As String)
                _name = Value
            End Set
        End Property


        Public Property TabId() As Integer

            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property


        Public Property ParentId() As Integer

            Get
                Return _parent
            End Get
            Set(ByVal Value As Integer)
                _parent = Value
            End Set
        End Property


        Public Overridable Function CompareTo(ByVal value As Object) As Integer Implements IComparable.CompareTo

            If value Is Nothing Then
                Return 1
            End If

            Dim compareOrder As Integer = CType(value, TabItem).TabOrder

            If Me.TabOrder = compareOrder Then Return 0
            If Me.TabOrder < compareOrder Then Return -1
            If Me.TabOrder > compareOrder Then Return 1
            Return 0

        End Function

    End Class

    Public Class TabInfo
        Private _TabID As Integer
        Private _TabOrder As Integer
        Private _PortalID As Integer
        Private _TabName As String
        Private _AuthorizedRoles As String
        Private _IsVisible As Boolean
        Private _ParentId As Integer
        Private _Level As Integer
        Private _IconFile As String
        Private _AdministratorRoles As String
        Private _DisableLink As Boolean
        Private _Title As String
        Private _Description As String
        Private _KeyWords As String
        Private _IsDeleted As Boolean

        Public Sub New()
        End Sub

        Public Property TabID() As Integer
            Get
                Return _TabID
            End Get
            Set(ByVal Value As Integer)
                _TabID = Value
            End Set
        End Property
        Public Property TabOrder() As Integer
            Get
                Return _TabOrder
            End Get
            Set(ByVal Value As Integer)
                _TabOrder = Value
            End Set
        End Property
        Public Property PortalID() As Integer
            Get
                Return _PortalID
            End Get
            Set(ByVal Value As Integer)
                _PortalID = Value
            End Set
        End Property
        Public Property TabName() As String
            Get
                Return _TabName
            End Get
            Set(ByVal Value As String)
                _TabName = Value
            End Set
        End Property
        Public Property AuthorizedRoles() As String
            Get
                Return _AuthorizedRoles
            End Get
            Set(ByVal Value As String)
                _AuthorizedRoles = Value
            End Set
        End Property
        Public Property IsVisible() As Boolean
            Get
                Return _IsVisible
            End Get
            Set(ByVal Value As Boolean)
                _IsVisible = Value
            End Set
        End Property
        Public Property ParentId() As Integer
            Get
                Return _ParentId
            End Get
            Set(ByVal Value As Integer)
                _ParentId = Value
            End Set
        End Property
        Public Property Level() As Integer
            Get
                Return _Level
            End Get
            Set(ByVal Value As Integer)
                _Level = Value
            End Set
        End Property
        Public Property IconFile() As String
            Get
                Return _IconFile
            End Get
            Set(ByVal Value As String)
                _IconFile = Value
            End Set
        End Property
        Public Property AdministratorRoles() As String
            Get
                Return _AdministratorRoles
            End Get
            Set(ByVal Value As String)
                _AdministratorRoles = Value
            End Set
        End Property
        Public Property DisableLink() As Boolean
            Get
                Return _DisableLink
            End Get
            Set(ByVal Value As Boolean)
                _DisableLink = Value
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
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property
        Public Property KeyWords() As String
            Get
                Return _KeyWords
            End Get
            Set(ByVal Value As String)
                _KeyWords = Value
            End Set
        End Property
        Public Property IsDeleted() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
            End Set
        End Property
    End Class

    Public Class TabController
        Public Sub UpdatePortalTabOrder(ByVal PortalId As Integer, ByVal TabId As Integer, ByVal NewParentId As Integer, ByVal Level As Integer, ByVal Order As Integer, ByVal IsVisible As Boolean, Optional ByVal NewTab As Boolean = False)

            Dim objTabs As New ArrayList
            Dim objTab As TabStripDetails

            Dim intCounter As Integer
            Dim intFromIndex As Integer = -1
            Dim intOldParentId As Integer = -2
            Dim intToIndex As Integer = -1
            Dim intNewParentIndex As Integer = 0
            Dim intLevel As Integer
            Dim intAddTabLevel As Integer

            Dim objPortals As New PortalController
            Dim objPortal As PortalInfo = objPortals.GetPortal(PortalId)

            ' get the current tabs
            Dim objDesktopTabs As New ArrayList
            Dim objTabStripDetails As TabStripDetails
            Dim ds As DataSet = ConvertDataReaderToDataSet(DataProvider.Instance().GetTabs(PortalId))
            For intCounter = 0 To ds.Tables(0).Rows.Count - 1
                If NewTab = False Or Convert.ToInt32(ds.Tables(0).Rows(intCounter).Item("TabId")) <> TabId Then
                    objTabStripDetails = New TabStripDetails
                    objTabStripDetails.PortalId = PortalId
                    objTabStripDetails.TabId = Convert.ToInt32(ds.Tables(0).Rows(intCounter).Item("TabId"))
                    objTabStripDetails.TabName = ds.Tables(0).Rows(intCounter).Item("TabName").ToString
                    objTabStripDetails.TabOrder = Convert.ToInt32(IIf(IsDBNull(ds.Tables(0).Rows(intCounter).Item("TabOrder")), -1, ds.Tables(0).Rows(intCounter).Item("TabOrder")))
                    objTabStripDetails.TabOrder = Convert.ToInt32(IIf(objTabStripDetails.TabOrder = 0, 999, objTabStripDetails.TabOrder))
                    objTabStripDetails.AuthorizedRoles = ds.Tables(0).Rows(intCounter).Item("AuthorizedRoles").ToString
                    objTabStripDetails.AdministratorRoles = ds.Tables(0).Rows(intCounter).Item("AdministratorRoles").ToString
                    objTabStripDetails.IsVisible = Convert.ToBoolean(ds.Tables(0).Rows(intCounter).Item("IsVisible"))
                    objTabStripDetails.DisableLink = Convert.ToBoolean(ds.Tables(0).Rows(intCounter).Item("DisableLink"))
                    objTabStripDetails.ParentId = Convert.ToInt32(IIf(IsDBNull(ds.Tables(0).Rows(intCounter).Item("ParentID")), -1, ds.Tables(0).Rows(intCounter).Item("ParentId")))
                    objTabStripDetails.Level = Convert.ToInt32(ds.Tables(0).Rows(intCounter).Item("Level"))
                    objTabStripDetails.IconFile = ds.Tables(0).Rows(intCounter).Item("IconFile").ToString
                    objTabStripDetails.HasChildren = Convert.ToBoolean(ds.Tables(0).Rows(intCounter).Item("HasChildren"))
                    objDesktopTabs.Add(objTabStripDetails)
                End If
            Next intCounter

            ' populate temporary tab array
            intCounter = 0
            For Each objTab In objDesktopTabs
                objTabs.Add(objTab)
                If objTab.TabId = TabId Then
                    intOldParentId = objTab.ParentId
                    intFromIndex = intCounter
                End If
                If objTab.TabId = NewParentId Then
                    intNewParentIndex = intCounter
                    intAddTabLevel = objTab.Level + 1
                End If
                intCounter += 1
            Next

            If NewParentId <> -2 Then ' not deleted
                ' adding new tab
                If intFromIndex = -1 Then
                    objTab = New TabStripDetails
                    objTab.TabId = TabId
                    objTab.ParentId = NewParentId
                    objTab.IsVisible = IsVisible
                    objTab.Level = intAddTabLevel
                    objTabs.Add(objTab)
                    intFromIndex = objTabs.Count - 1
                End If

                If Level = 0 And Order = 0 Then
                    CType(objTabs(intFromIndex), TabStripDetails).IsVisible = IsVisible
                End If
            End If

            If NewParentId <> -2 Then ' not deleted
                ' if the parent changed or we added a new non root level tab
                If intOldParentId <> NewParentId And Not (intOldParentId = -2 And NewParentId = -1) Then
                    ' locate position of last child for new parent
                    If NewParentId <> -1 Then
                        intLevel = CType(objTabs(intNewParentIndex), TabStripDetails).Level
                    Else
                        intLevel = -1
                    End If

                    intCounter = intNewParentIndex + 1
                    While intCounter <= objTabs.Count - 1
                        If CType(objTabs(intCounter), TabStripDetails).Level > intLevel Then
                            intToIndex = intCounter
                        Else
                            Exit While
                        End If
                        intCounter += 1
                    End While
                    ' adding to parent with no children
                    If intToIndex = -1 Then
                        intToIndex = intNewParentIndex
                    End If
                    ' move tab
                    CType(objTabs(intFromIndex), TabStripDetails).ParentId = NewParentId
                    MoveTab(objTabs, intFromIndex, intToIndex, intLevel + 1)
                Else
                    ' if level has changed
                    If Level <> 0 Then
                        intLevel = CType(objTabs(intFromIndex), TabStripDetails).Level

                        Dim blnValid As Boolean = True
                        Select Case Level
                            Case -1
                                If intLevel = 0 Then
                                    blnValid = False
                                End If
                            Case 1
                                If intFromIndex > 0 Then
                                    If intLevel > CType(objTabs(intFromIndex - 1), TabStripDetails).Level Then
                                        blnValid = False
                                    End If
                                Else
                                    blnValid = False
                                End If
                        End Select

                        If blnValid Then
                            Dim intNewLevel As Integer
                            If Level = -1 Then
                                intNewLevel = intLevel + Level
                            Else
                                intNewLevel = intLevel
                            End If

                            ' get new parent
                            NewParentId = -2
                            intCounter = intFromIndex - 1
                            While intCounter >= 0 And NewParentId = -2
                                If CType(objTabs(intCounter), TabStripDetails).Level = intNewLevel Then
                                    If Level = -1 Then
                                        NewParentId = CType(objTabs(intCounter), TabStripDetails).ParentId
                                    Else
                                        NewParentId = CType(objTabs(intCounter), TabStripDetails).TabId
                                    End If
                                    intNewParentIndex = intCounter
                                End If
                                intCounter -= 1
                            End While
                            CType(objTabs(intFromIndex), TabStripDetails).ParentId = NewParentId

                            If Level = -1 Then
                                ' locate position of next child for parent
                                intToIndex = -1
                                intCounter = intNewParentIndex + 1
                                While intCounter <= objTabs.Count - 1
                                    If CType(objTabs(intCounter), TabStripDetails).Level > intNewLevel Then
                                        intToIndex = intCounter
                                    Else
                                        Exit While
                                    End If
                                    intCounter += 1
                                End While
                                ' adding to parent with no children
                                If intToIndex = -1 Then
                                    intToIndex = intNewParentIndex
                                End If
                            Else
                                intToIndex = intFromIndex - 1
                                intNewLevel = intLevel + Level
                            End If

                            ' move tab
                            If intFromIndex = intToIndex Then
                                CType(objTabs(intFromIndex), TabStripDetails).Level = intNewLevel
                            Else
                                MoveTab(objTabs, intFromIndex, intToIndex, intNewLevel)
                            End If
                        End If
                    Else
                        ' if order has changed
                        If Order <> 0 Then
                            intLevel = CType(objTabs(intFromIndex), TabStripDetails).Level

                            ' find previous/next item for parent
                            intToIndex = -1
                            intCounter = intFromIndex + Order
                            While intCounter >= 0 And intCounter <= objTabs.Count - 1 And intToIndex = -1
                                If CType(objTabs(intCounter), TabStripDetails).ParentId = NewParentId Then
                                    intToIndex = intCounter
                                End If
                                intCounter += Order
                            End While
                            If intToIndex <> -1 Then
                                If Order = 1 Then
                                    ' locate position of next child for parent
                                    intNewParentIndex = intToIndex
                                    intToIndex = -1
                                    intCounter = intNewParentIndex + 1
                                    While intCounter <= objTabs.Count - 1
                                        If CType(objTabs(intCounter), TabStripDetails).Level > intLevel Then
                                            intToIndex = intCounter
                                        Else
                                            Exit While
                                        End If
                                        intCounter += 1
                                    End While
                                    ' adding to parent with no children
                                    If intToIndex = -1 Then
                                        intToIndex = intNewParentIndex
                                    End If
                                    intToIndex += 1
                                End If
                                MoveTab(objTabs, intFromIndex, intToIndex, intLevel, False)
                            End If
                        End If
                    End If
                End If
            End If

            ' update the tabs
            Dim intTabOrder As Integer
            Dim intDesktopTabOrder As Integer = -1
            Dim intAdminTabOrder As Integer = 9999 ' this seeds the taborder for the admin tab so that they are always at the end of the tab list ( max = 5000 desktop tabs per portal )
            For Each objTab In objTabs
                If IsAdminTab(objTab.TabId, objTab.ParentId) Then
                    intAdminTabOrder += 2
                    intTabOrder = intAdminTabOrder
                Else ' desktop tab
                    intDesktopTabOrder += 2
                    intTabOrder = intDesktopTabOrder
                End If
                UpdateTabOrder(objTab.PortalId, objTab.TabId, intTabOrder, objTab.Level, objTab.ParentId)
            Next

            ' clear portal cache
            DataCache.ClearCoreCache(CoreCacheType.Portal, PortalId, True)

        End Sub

        Private Sub MoveTab(ByVal objDesktopTabs As ArrayList, ByVal intFromIndex As Integer, ByVal intToIndex As Integer, ByVal intNewLevel As Integer, Optional ByVal blnAddChild As Boolean = True)
            Dim intCounter As Integer
            Dim objTab As TabStripDetails
            Dim blnInsert As Boolean
            Dim intIncrement As Integer

            Dim intOldLevel As Integer = CType(objDesktopTabs(intFromIndex), TabStripDetails).Level
            If intToIndex <> objDesktopTabs.Count - 1 Then
                blnInsert = True
            End If

            ' clone tab and children from old parent
            Dim objClone As New ArrayList
            intCounter = intFromIndex
            While intCounter <= objDesktopTabs.Count - 1
                If CType(objDesktopTabs(intCounter), TabStripDetails).TabId = CType(objDesktopTabs(intFromIndex), TabStripDetails).TabId Or CType(objDesktopTabs(intCounter), TabStripDetails).Level > intOldLevel Then
                    objClone.Add(objDesktopTabs(intCounter))
                    intCounter += 1
                Else
                    Exit While
                End If
            End While

            ' remove tab and children from old parent
            objDesktopTabs.RemoveRange(intFromIndex, objClone.Count)
            If intToIndex > intFromIndex Then
                intToIndex -= objClone.Count
            End If

            ' add clone to new parent
            If blnInsert Then
                objClone.Reverse()
            End If

            For Each objTab In objClone
                If blnInsert Then
                    objTab.Level += (intNewLevel - intOldLevel)
                    If blnAddChild Then
                        intIncrement = 1
                    Else
                        intIncrement = 0
                    End If
                    objDesktopTabs.Insert(intToIndex + intIncrement, objTab)
                Else
                    objTab.Level += (intNewLevel - intOldLevel)
                    objDesktopTabs.Add(objTab)
                End If
            Next
        End Sub

        Public Function AddTab(ByVal objTab As TabInfo) As Integer

            Dim intTabId As Integer

            intTabId = DataProvider.Instance().AddTab(objTab.PortalID, objTab.TabName, objTab.AuthorizedRoles, objTab.IsVisible, objTab.DisableLink, objTab.ParentId, objTab.IconFile, objTab.AdministratorRoles, objTab.Title, objTab.Description, objTab.KeyWords)

            UpdatePortalTabOrder(objTab.PortalID, intTabId, objTab.ParentId, 0, 0, objTab.IsVisible, True)

            Return intTabId

        End Function

        Public Sub UpdateTab(ByVal objTab As TabInfo)

            UpdatePortalTabOrder(objTab.PortalID, objTab.TabID, objTab.ParentId, 0, 0, objTab.IsVisible)

            DataProvider.Instance().UpdateTab(objTab.TabID, objTab.TabName, objTab.AuthorizedRoles, objTab.IsVisible, objTab.DisableLink, objTab.ParentId, objTab.IconFile, objTab.AdministratorRoles, objTab.Title, objTab.Description, objTab.KeyWords, objTab.IsDeleted)

        End Sub


        Public Sub CopyTab(ByVal FromTabId As Integer, ByVal ToTabId As Integer)

            Dim arrModules As ArrayList
            Dim objModules As New ModuleController
            Dim objModule As ModuleInfo
            Dim intIndex As Integer

            arrModules = CBO.FillCollection(DataProvider.Instance().GetTabModules(FromTabId), GetType(ModuleInfo))
            For intIndex = 0 To arrModules.Count - 1
                objModule = CType(arrModules(intIndex), ModuleInfo)

                If objModule.IsDeleted = False Then
                    objModule.TabID = ToTabId
                    objModules.AddModule(objModule)
                End If
            Next

        End Sub


        Public Sub UpdateTabOrder(ByVal PortalID As Integer, ByVal TabId As Integer, ByVal TabOrder As Integer, ByVal Level As Integer, ByVal ParentId As Integer)

            DataProvider.Instance().UpdateTabOrder(TabId, TabOrder, Level, ParentId)

        End Sub


        Public Sub DeleteTab(ByVal TabId As Integer, ByVal PortalId As Integer)

            ' parent tabs can not be deleted
            Dim arrTabs As ArrayList = GetTabsByParentId(TabId)

            If arrTabs.Count = 0 Then
                DataProvider.Instance().DeleteTab(TabId)

                UpdatePortalTabOrder(PortalId, TabId, -2, 0, 0, True)
            End If

        End Sub


        Public Function GetTabs(ByVal PortalId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetTabs(PortalId), GetType(TabInfo))

        End Function


        Public Function GetTab(ByVal TabId As Integer) As TabInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetTab(TabId), GetType(TabInfo)), TabInfo)

        End Function


        Public Function GetTabByName(ByVal TabName As String, Optional ByVal PortalId As Integer = -1) As TabInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetTabByName(TabName, PortalId), GetType(TabInfo)), TabInfo)

        End Function


        Public Function GetTabsByParentId(ByVal ParentId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetTabsByParentId(ParentId), GetType(TabInfo))

        End Function


        Public Function GetTabIDByParentId(ByVal ParentId As Integer) As DataSet

            Return DataProvider.Instance.ExecuteQueryStoreProc("GetFirstTabByParentID", ParentId)

        End Function


    End Class


End Namespace

