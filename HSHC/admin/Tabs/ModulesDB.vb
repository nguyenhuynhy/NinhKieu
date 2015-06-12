
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
Imports System.Globalization

Namespace PortalQH

    '*********************************************************************
    '
    ' ModuleItem Class
    '
    ' This class encapsulates the basic attributes of a Module, and is used
    ' by the administration pages when manipulating modules.  ModuleItem implements 
    ' the IComparable interface so that an ArrayList of ModuleItems may be sorted
    ' by ModuleOrder, using the ArrayList's Sort() method.
    '
    '*********************************************************************

    Public Class ModuleItem
        Implements IComparable


        Private _moduleOrder As Integer
        Private _title As String
        Private _pane As String
        Private _id As Integer
        Private _defId As Integer


        Public Property ModuleOrder() As Integer

            Get
                Return _moduleOrder
            End Get
            Set(ByVal Value As Integer)
                _moduleOrder = Value
            End Set

        End Property


        Public Property ModuleTitle() As String

            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set

        End Property


        Public Property PaneName() As String

            Get
                Return _pane
            End Get
            Set(ByVal Value As String)
                _pane = Value
            End Set

        End Property


        Public Property ModuleId() As Integer

            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set

        End Property


        Public Property ModuleDefId() As Integer

            Get
                Return _defId
            End Get
            Set(ByVal Value As Integer)
                _defId = Value
            End Set

        End Property


        Protected Overridable Function CompareTo(ByVal value As Object) As Integer Implements IComparable.CompareTo

            If value Is Nothing Then
                Return 1
            End If

            Dim compareOrder As Integer = CType(value, ModuleItem).ModuleOrder

            If Me.ModuleOrder = compareOrder Then Return 0
            If Me.ModuleOrder < compareOrder Then Return -1
            If Me.ModuleOrder > compareOrder Then Return 1
            Return 0

        End Function

    End Class

    Public Class ModuleInfo
        Private _ModuleID As Integer
        Private _TabID As Integer
        Private _ModuleDefID As Integer
        Private _ModuleOrder As Integer
        Private _PaneName As String
        Private _ModuleTitle As String
        Private _AuthorizedEditRoles As String
        Private _CacheTime As Integer
        Private _AuthorizedViewRoles As String
        Private _Alignment As String
        Private _Color As String
        Private _Border As String
        Private _IconFile As String
        Private _AllTabs As Boolean
        Private _ShowTitle As Boolean
        Private _Personalize As Integer
        Private _AuthorizedRoles As String
        Private _IsDeleted As Boolean

        Public Sub New()
        End Sub

        Public Property ModuleID() As Integer
            Get
                Return _ModuleID
            End Get
            Set(ByVal Value As Integer)
                _ModuleID = Value
            End Set
        End Property
        Public Property TabID() As Integer
            Get
                Return _TabID
            End Get
            Set(ByVal Value As Integer)
                _TabID = Value
            End Set
        End Property
        Public Property ModuleDefID() As Integer
            Get
                Return _ModuleDefID
            End Get
            Set(ByVal Value As Integer)
                _ModuleDefID = Value
            End Set
        End Property
        Public Property ModuleOrder() As Integer
            Get
                Return _ModuleOrder
            End Get
            Set(ByVal Value As Integer)
                _ModuleOrder = Value
            End Set
        End Property
        Public Property PaneName() As String
            Get
                Return _PaneName
            End Get
            Set(ByVal Value As String)
                _PaneName = Value
            End Set
        End Property
        Public Property ModuleTitle() As String
            Get
                Return _ModuleTitle
            End Get
            Set(ByVal Value As String)
                _ModuleTitle = Value
            End Set
        End Property
        Public Property AuthorizedEditRoles() As String
            Get
                Return _AuthorizedEditRoles
            End Get
            Set(ByVal Value As String)
                _AuthorizedEditRoles = Value
            End Set
        End Property
        Public Property CacheTime() As Integer
            Get
                Return _CacheTime
            End Get
            Set(ByVal Value As Integer)
                _CacheTime = Value
            End Set
        End Property
        Public Property AuthorizedViewRoles() As String
            Get
                Return _AuthorizedViewRoles
            End Get
            Set(ByVal Value As String)
                _AuthorizedViewRoles = Value
            End Set
        End Property
        Public Property Alignment() As String
            Get
                Return _Alignment
            End Get
            Set(ByVal Value As String)
                _Alignment = Value
            End Set
        End Property
        Public Property Color() As String
            Get
                Return _Color
            End Get
            Set(ByVal Value As String)
                _Color = Value
            End Set
        End Property
        Public Property Border() As String
            Get
                Return _Border
            End Get
            Set(ByVal Value As String)
                _Border = Value
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
        Public Property AllTabs() As Boolean
            Get
                Return _AllTabs
            End Get
            Set(ByVal Value As Boolean)
                _AllTabs = Value
            End Set
        End Property
        Public Property ShowTitle() As Boolean
            Get
                Return _ShowTitle
            End Get
            Set(ByVal Value As Boolean)
                _ShowTitle = Value
            End Set
        End Property
        Public Property Personalize() As Integer
            Get
                Return _Personalize
            End Get
            Set(ByVal Value As Integer)
                _Personalize = Value
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
        Public Property IsDeleted() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
            End Set
        End Property
    End Class

    Public Class ModuleController

        Public Function GetModule(ByVal ModuleId As Integer) As ModuleInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetModule(ModuleId), GetType(ModuleInfo)), ModuleInfo)

        End Function


        Public Function GetPortalTabModules(ByVal PortalId As Integer, ByVal TabId As Integer) As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetPortalTabModules(PortalId, TabId), GetType(ModuleInfo))

        End Function


        Public Sub UpdateModuleOrder(ByVal ModuleId As Integer, ByVal ModuleOrder As Integer, ByVal PaneName As String)

            Dim objModule As ModuleInfo = GetModule(ModuleId)
            If Not objModule Is Nothing Then
                ' adding a module to a new pane - places the module at the bottom of the pane 
                If ModuleOrder = -1 Then
                    Dim dr As IDataReader = DataProvider.Instance().GetTabModuleOrder(objModule.TabID, PaneName)
                    While dr.Read
                        ModuleOrder = Convert.ToInt32(dr("ModuleOrder"))
                    End While
                    dr.Close()
                    ModuleOrder += 2
                End If

                DataProvider.Instance().UpdateModuleOrder(ModuleId, ModuleOrder, PaneName)

                ' clear cache
                If objModule.AllTabs = False Then
                    DataCache.ClearCoreCache(CoreCacheType.Tab, objModule.TabID)
                Else
                    Dim objTabs As New TabController
                    Dim objTab As TabInfo = objTabs.GetTab(objModule.TabID)
                    If Not objTab Is Nothing Then
                        DataCache.ClearCoreCache(CoreCacheType.Portal, objTab.PortalID, True)
                    End If
                End If
            End If

        End Sub


        Public Function AddModule(ByVal objModule As ModuleInfo) As Integer

            Dim ModuleId As Integer = -1

            ModuleId = DataProvider.Instance().AddModule(objModule.TabID, objModule.ModuleDefID, objModule.ModuleOrder, objModule.PaneName, objModule.ModuleTitle, objModule.AuthorizedEditRoles, objModule.CacheTime, objModule.AuthorizedViewRoles, objModule.Alignment, objModule.Color, objModule.Border, objModule.IconFile, objModule.AllTabs, objModule.ShowTitle, objModule.Personalize)

            ' move module to bottom of pane
            UpdateModuleOrder(ModuleId, -1, objModule.PaneName)

            Return ModuleId

        End Function


        Public Sub UpdateModule(ByVal objModule As ModuleInfo)

            If objModule.AllTabs Then
                objModule.ModuleOrder = 0
            End If

            DataProvider.Instance().UpdateModule(objModule.ModuleID, objModule.ModuleOrder, objModule.ModuleTitle, objModule.Alignment, objModule.Color, objModule.Border, objModule.IconFile, objModule.CacheTime, objModule.AuthorizedViewRoles, objModule.AuthorizedEditRoles, objModule.TabID, objModule.AllTabs, objModule.ShowTitle, objModule.Personalize, objModule.IsDeleted)

            If objModule.IsDeleted Then
                objModule.ModuleOrder = -1 ' move to end of pane
            End If

            ' update module order in pane
            UpdateModuleOrder(objModule.ModuleID, objModule.ModuleOrder, objModule.PaneName)

            If objModule.IsDeleted Then
                UpdateTabModuleOrder(objModule.TabID) ' reorder all modules on tab
            End If

        End Sub


        Public Sub DeleteModule(ByVal ModuleId As Integer, ByVal TabId As Integer)

            DataProvider.Instance().DeleteModule(ModuleId)

            ' reorder all modules on tab
            UpdateTabModuleOrder(TabId)

        End Sub

        Public Sub UpdateModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String, ByVal SettingValue As String)

            Dim dr As IDataReader = DataProvider.Instance().GetModuleSetting(ModuleId, SettingName)

            If dr.Read Then
                DataProvider.Instance().UpdateModuleSetting(ModuleId, SettingName, SettingValue)
            Else
                DataProvider.Instance().AddModuleSetting(ModuleId, SettingName, SettingValue)
            End If
            dr.Close()

        End Sub

        Public Function GetSiteModule(ByVal FriendlyName As String, ByVal PortalId As Integer) As Integer

            Return DataProvider.Instance().GetSiteModule(FriendlyName, PortalId)

        End Function


        Public Sub UpdateTabModuleOrder(ByVal TabId As Integer)

            Dim ModuleCounter As Integer
            Dim dr As IDataReader = DataProvider.Instance().GetTabPanes(TabId)
            While dr.Read
                ModuleCounter = 0
                Dim dr2 As IDataReader = DataProvider.Instance().GetTabModuleOrder(TabId, Convert.ToString(dr("PaneName")))
                While dr2.Read
                    ModuleCounter += 1
                    DataProvider.Instance().UpdateModuleOrder(Convert.ToInt32(dr2("ModuleID")), (ModuleCounter * 2) - 1, Convert.ToString(dr("PaneName")))
                End While
                dr2.Close()
            End While
            dr.Close()

            ' clear tab cache
            DataCache.ClearCoreCache(CoreCacheType.Tab, TabId)

        End Sub
    End Class


End Namespace
