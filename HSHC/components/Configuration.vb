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
Imports System.Web
Imports System.Collections
Imports System.IO
Imports System.Web.UI

Namespace PortalQH

    '*********************************************************************
    '
    ' TabStripDetails Class
    '
    ' Class that encapsulates the tabstrip details -- TabName, TabId and TabOrder 
    '
    '*********************************************************************

    <Serializable()> Public Class TabStripDetails

        Public PortalId As Integer
        Public TabId As Integer
        Public TabName As String
        Public TabOrder As Integer
        Public AuthorizedRoles As String
        Public AdministratorRoles As String
        Public IsVisible As Boolean
        Public DisableLink As Boolean
        Public ParentId As Integer
        Public Level As Integer
        Public IconFile As String
        Public HasChildren As Boolean
        Public IsDeleted As Boolean
        Public URL As String

    End Class


    '*********************************************************************
    '
    ' TabSettings Class
    '
    ' Class that encapsulates the detailed settings for a specific Tab 
    ' in the Portal
    '
    '*********************************************************************

    Public Class TabSettings

        Public PortalId As Integer
        Public TabId As Integer
        Public TabName As String
        Public Title As String
        Public Description As String
        Public KeyWords As String
        Public TabOrder As Integer
        Public AuthorizedRoles As String
        Public AdministratorRoles As String
        Public IsVisible As Boolean
        Public DisableLink As Boolean
        Public ParentId As Integer
        Public Level As Integer
        Public IconFile As String
        Public HasChildren As Boolean
        Public IsDeleted As Boolean
        Public SkinPath As String
        Public SkinSrc As String
        Public Modules As New ArrayList

    End Class


    '*********************************************************************
    '
    ' ModuleSettings Class
    '
    ' Class that encapsulates the detailed settings for a specific Tab 
    ' in the Portal
    '
    '*********************************************************************

    Public Class ModuleSettings

        Public ModuleId As Integer
        Public TabId As Integer
        Public ModuleDefId As Integer
        Public ModuleOrder As Integer
        Public PaneName As String
        Public ModuleTitle As String
        Public AuthorizedEditRoles As String
        Public CacheTime As Integer
        Public AuthorizedViewRoles As String
        Public Alignment As String
        Public Color As String
        Public Border As String
        Public IconFile As String
        Public AllTabs As Boolean
        Public ShowTitle As Boolean
        Public Personalize As Integer
        Public IsDeleted As Boolean
        Public ControlSrc As String
        Public ControlType As SecurityAccessLevel
        Public ControlTitle As String
        Public DesktopModuleId As Integer
        Public FriendlyName As String
        Public IsAdmin As Boolean
        Public ContainerModuleId As Integer
        Public ContainerPath As String
        Public ContainerSrc As String
        Public PaneModuleIndex As Integer
        Public PaneModuleCount As Integer

        Public Sub CopyTo(ByRef NewModuleSettings As ModuleSettings)
            NewModuleSettings = CType(Me.MemberwiseClone(), ModuleSettings)
        End Sub

    End Class


    '*********************************************************************
    '
    ' PortalSettings Class
    '
    ' This class encapsulates all of the settings for the Portal, as well
    ' as the configuration settings required to execute the current tab
    ' view within the portal.
    '
    '*********************************************************************

    Public Class PortalSettings

        Public PortalId As Integer
        Public GUID As String
        Public PortalAlias As String
        Public PortalName As String
        Public UploadDirectory As String
        Public LogoFile As String
        Public FooterText As String
        Public ExpiryDate As String
        Public UserRegistration As Integer
        Public BannerAdvertising As Integer
        Public Currency As String
        Public AdministratorId As String
        Public Email As String
        Public HostFee As String
        Public HostSpace As Integer
        Public AdministratorRoleId As Integer
        Public RegisteredRoleId As Integer
        Public Description As String
        Public KeyWords As String
        Public BackgroundFile As String
        Public SiteLogHistory As Integer
        Public AdminTabId As Integer
        Public SuperUserId As String
        Public SuperTabId As Integer
        Public HomeTabId As Integer
        Public LoginTabId As Integer
        Public UserTabId As Integer
        Public Version As String
        Public DatabaseVersion As String
        Public Panes As New ArrayList
        Public BreadCrumbs As New ArrayList
        Public DesktopTabs As New ArrayList
        Public ActiveTab As New TabSettings
        Public HostSettings As New Hashtable

        '*********************************************************************
        '
        ' PortalSettings Constructor
        '
        ' The PortalSettings Constructor encapsulates all of the logic
        ' necessary to obtain configuration settings necessary to render
        ' a Portal Tab view for a given request.
        '
        '*********************************************************************

        Public Sub New(ByVal tabId As Integer, ByVal PortalId As Integer)

            GetPortalSettings(tabId, PortalId)

        End Sub

        Public Sub GetPortalSettings(ByVal TabId As Integer, ByVal PortalId As Integer)

            Dim dr As IDataReader
            Dim dt As DataTable
            Dim intRow As Integer

            Dim objModuleDefinitions As New ModuleDefinitionController
            Dim objTabs As New TabController
            Dim objSkins As New SkinController
            Dim objSkin As SkinInfo

            ' host settings
            Me.HostSettings = CType(DataCache.GetCache("GetHostSettings"), Hashtable)
            If Me.HostSettings Is Nothing Then
                Me.HostSettings = GetHostSettings()
                DataCache.SetCache("GetHostSettings", Me.HostSettings)
            End If

            ' data caching settings
            Dim intCacheTimeout As Integer = 43200
            If Convert.ToString(Me.HostSettings("CacheTimeout")) <> "" Then
                intCacheTimeout = Integer.Parse(Convert.ToString(Me.HostSettings("CacheTimeout")))
            End If

            ' get portal settings
            dt = CType(DataCache.GetCache("GetPortalSettings" & PortalId.ToString), DataTable)
            If dt Is Nothing Then
                dt = ConvertDataReaderToDataTable(DataProvider.Instance().GetPortalSettings(PortalId))

                ' get database version
                dt.Columns.Add(New DataColumn("DatabaseVersion", Type.GetType("System.String")))
                dr = Me.GetDatabaseVersion()
                Dim strDatabaseVersion As String = ""
                If dr.Read Then
                    strDatabaseVersion = dr("Major").ToString & "." & dr("Minor").ToString & "." & dr("Build").ToString
                End If
                dr.Close()
                dt.Rows(0).Item("DatabaseVersion") = strDatabaseVersion

                If intCacheTimeout <> 0 Then
                    DataCache.SetCache("GetPortalSettings" & PortalId.ToString, dt)
                End If
            End If

            Me.PortalId = Convert.ToInt32(dt.Rows(0).Item("PortalId"))
            Me.GUID = dt.Rows(0).Item("GUID").ToString
            Me.PortalAlias = dt.Rows(0).Item("PortalAlias").ToString
            Me.PortalName = dt.Rows(0).Item("PortalName").ToString
            Me.LogoFile = dt.Rows(0).Item("LogoFile").ToString
            Me.FooterText = dt.Rows(0).Item("FooterText").ToString
            Me.ExpiryDate = dt.Rows(0).Item("ExpiryDate").ToString
            Me.UserRegistration = Convert.ToInt32(dt.Rows(0).Item("UserRegistration"))
            Me.BannerAdvertising = Convert.ToInt32(dt.Rows(0).Item("BannerAdvertising"))
            Me.Currency = dt.Rows(0).Item("Currency").ToString
            Me.AdministratorId = dt.Rows(0).Item("AdministratorId").ToString
            Me.Email = dt.Rows(0).Item("Email").ToString
            Me.HostFee = dt.Rows(0).Item("HostFee").ToString
            Me.HostSpace = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("HostSpace")), 0, dt.Rows(0).Item("HostSpace")))
            Me.AdministratorRoleId = Convert.ToInt32(dt.Rows(0).Item("AdministratorRoleId"))
            Me.RegisteredRoleId = Convert.ToInt32(dt.Rows(0).Item("RegisteredRoleId"))
            Me.Description = dt.Rows(0).Item("Description").ToString
            Me.KeyWords = dt.Rows(0).Item("KeyWords").ToString
            Me.BackgroundFile = dt.Rows(0).Item("BackgroundFile").ToString
            Me.SiteLogHistory = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("SiteLogHistory")), -1, dt.Rows(0).Item("SiteLogHistory")))
            Me.AdminTabId = Convert.ToInt32(dt.Rows(0).Item("AdminTabId"))
            Me.SuperUserId = CType(dt.Rows(0).Item("SuperUserId"), String)
            Me.SuperTabId = Convert.ToInt32(dt.Rows(0).Item("SuperTabId"))
            Me.HomeTabId = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("HomeTabId")), -1, dt.Rows(0).Item("HomeTabId")))
            Me.LoginTabId = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("LoginTabId")), -1, dt.Rows(0).Item("LoginTabId")))
            Me.UserTabId = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("UserTabId")), -1, dt.Rows(0).Item("UserTabId")))
            Me.DatabaseVersion = dt.Rows(0).Item("DatabaseVersion").ToString

            ' global settings
            Me.UploadDirectory = Global.ApplicationPath & "/Portals/" & Me.PortalId.ToString & "/"
            Me.Version = System.Diagnostics.FileVersionInfo.GetVersionInfo(Global.AssemblyPath).ProductVersion.ToString
            Me.Version = Left(Me.Version, InStrRev(Me.Version, ".") - 1)

            ' verify tab for portal
            Dim intTabId As Integer = VerifyPortalTab(PortalId, TabId, Me.HomeTabId)

            '  current tab settings
            dt = CType(DataCache.GetCache("GetTab" & intTabId.ToString), DataTable)
            If dt Is Nothing Then
                dt = ConvertDataReaderToDataTable(DataProvider.Instance().GetTab(intTabId))

                ' get tab skin
                dt.Columns.Add(New DataColumn("SkinPath", Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("SkinSrc", Type.GetType("System.String")))
                Dim strSkinPath As String = ""
                Dim strSkinSrc As String = ""
                objSkin = objSkins.GetSkin(SkinInfo.RootSkin, PortalId, intTabId, Null.NullInteger, False)
                If Not objSkin Is Nothing Then
                    Select Case objSkin.SkinType
                        Case "G" ' global
                            strSkinPath = Global.HostPath & SkinInfo.RootSkin & "/" & objSkin.SkinName & "/"
                        Case "L" ' local
                            strSkinPath = Me.UploadDirectory & SkinInfo.RootSkin & "/" & objSkin.SkinName & "/"
                    End Select
                    strSkinSrc = objSkin.SkinSrc
                End If
                dt.Rows(0).Item("SkinPath") = strSkinPath
                dt.Rows(0).Item("SkinSrc") = strSkinSrc

                If intCacheTimeout <> 0 Then
                    DataCache.SetCache("GetTab" & intTabId.ToString, dt, intCacheTimeout)
                End If
            End If

            Me.ActiveTab.PortalId = PortalId
            Me.ActiveTab.TabId = Convert.ToInt32(dt.Rows(0).Item("TabId"))
            Me.ActiveTab.TabOrder = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("TabOrder")), -1, dt.Rows(0).Item("TabOrder")))
            Me.ActiveTab.AuthorizedRoles = dt.Rows(0).Item("AuthorizedRoles").ToString
            Me.ActiveTab.AdministratorRoles = dt.Rows(0).Item("AdministratorRoles").ToString
            Me.ActiveTab.TabName = dt.Rows(0).Item("TabName").ToString
            Me.ActiveTab.IsVisible = Convert.ToBoolean(dt.Rows(0).Item("IsVisible"))
            Me.ActiveTab.DisableLink = Convert.ToBoolean(dt.Rows(0).Item("DisableLink"))
            Me.ActiveTab.ParentId = Convert.ToInt32(IIf(IsDBNull(dt.Rows(0).Item("ParentId")), -1, dt.Rows(0).Item("ParentId")))
            Me.ActiveTab.Level = Convert.ToInt32(dt.Rows(0).Item("Level"))
            Me.ActiveTab.IconFile = dt.Rows(0).Item("IconFile").ToString
            Me.ActiveTab.HasChildren = Convert.ToBoolean(dt.Rows(0).Item("HasChildren"))
            Me.ActiveTab.Title = dt.Rows(0).Item("Title").ToString
            Me.ActiveTab.Description = dt.Rows(0).Item("Description").ToString
            Me.ActiveTab.KeyWords = dt.Rows(0).Item("KeyWords").ToString
            Me.ActiveTab.IsDeleted = Convert.ToBoolean(dt.Rows(0).Item("IsDeleted"))

            Me.ActiveTab.SkinPath = dt.Rows(0).Item("SkinPath").ToString
            Me.ActiveTab.SkinSrc = dt.Rows(0).Item("SkinSrc").ToString

            ' breadcrumbs
            Dim objLosFormatter As LosFormatter = New LosFormatter
            Dim strBreadCrumbs As String = CType(DataCache.GetCache("GetBreadCrumbs" & Me.ActiveTab.TabId.ToString), String)
            If strBreadCrumbs Is Nothing Then
                GetBreadCrumbsRecursively(Me.ActiveTab.TabId)
                Dim objStringWriter As StringWriter = New StringWriter
                objLosFormatter.Serialize(objStringWriter, Me.BreadCrumbs)

                If intCacheTimeout <> 0 Then
                    DataCache.SetCache("GetBreadCrumbs" & Me.ActiveTab.TabId.ToString, objStringWriter.ToString, intCacheTimeout)
                End If
            Else
                Me.BreadCrumbs = CType(objLosFormatter.Deserialize(strBreadCrumbs), ArrayList)
            End If

            ' get tabs
            dt = CType(DataCache.GetCache("GetTabs" & PortalId.ToString), DataTable)
            If dt Is Nothing Then
                dt = ConvertDataReaderToDataTable(DataProvider.Instance().GetTabs(PortalId))

                If intCacheTimeout <> 0 Then
                    DataCache.SetCache("GetTabs" & PortalId.ToString, dt)
                End If
            End If

            For intRow = 0 To dt.Rows.Count - 1
                Dim DesktopTab As New TabStripDetails

                DesktopTab.PortalId = PortalId
                DesktopTab.TabId = Convert.ToInt32(dt.Rows(intRow).Item("TabId"))
                DesktopTab.TabName = dt.Rows(intRow).Item("TabName").ToString
                DesktopTab.TabOrder = Convert.ToInt32(IIf(IsDBNull(dt.Rows(intRow).Item("TabOrder")), -1, dt.Rows(intRow).Item("TabOrder")))
                DesktopTab.TabOrder = Convert.ToInt32(IIf(DesktopTab.TabOrder = 0, 999, DesktopTab.TabOrder))
                DesktopTab.AuthorizedRoles = dt.Rows(intRow).Item("AuthorizedRoles").ToString
                DesktopTab.AdministratorRoles = dt.Rows(intRow).Item("AdministratorRoles").ToString
                DesktopTab.IsVisible = Convert.ToBoolean(dt.Rows(intRow).Item("IsVisible"))
                DesktopTab.DisableLink = Convert.ToBoolean(dt.Rows(intRow).Item("DisableLink"))
                DesktopTab.ParentId = Convert.ToInt32(IIf(IsDBNull(dt.Rows(intRow).Item("ParentID")), -1, dt.Rows(intRow).Item("ParentId")))
                DesktopTab.Level = Convert.ToInt32(dt.Rows(intRow).Item("Level"))
                DesktopTab.IconFile = dt.Rows(intRow).Item("IconFile").ToString
                DesktopTab.HasChildren = Convert.ToBoolean(dt.Rows(intRow).Item("HasChildren"))
                DesktopTab.IsDeleted = Convert.ToBoolean(dt.Rows(intRow).Item("IsDeleted"))
                DesktopTab.URL = Global.ApplicationPath & "/" & glbDefaultPage & "?tabid=" & DesktopTab.TabId.ToString

                Me.DesktopTabs.Add(DesktopTab)
            Next intRow

            ' get host tabs
            Dim HostTab As TabStripDetails
            Dim objTab As TabInfo

            objTab = objTabs.GetTab(Me.SuperTabId)
            If Not objTab Is Nothing Then
                HostTab = New TabStripDetails
                HostTab.PortalId = PortalId
                HostTab.TabId = objTab.TabID
                HostTab.TabName = objTab.TabName
                HostTab.TabOrder = objTab.TabOrder
                HostTab.AuthorizedRoles = objTab.AuthorizedRoles
                HostTab.AdministratorRoles = objTab.AdministratorRoles
                HostTab.IsVisible = objTab.IsVisible
                HostTab.DisableLink = objTab.DisableLink
                HostTab.ParentId = objTab.ParentId
                HostTab.Level = objTab.Level
                HostTab.IconFile = objTab.IconFile
                HostTab.HasChildren = True
                HostTab.IsDeleted = objTab.IsDeleted
                HostTab.URL = Global.ApplicationPath & "/" & glbDefaultPage & "?tabid=" & HostTab.TabId.ToString & "&portalid=" & HostTab.PortalId.ToString

                Me.DesktopTabs.Add(HostTab)
            End If

            Dim intTab As Integer
            Dim arrTabs As ArrayList = objTabs.GetTabsByParentId(Me.SuperTabId)
            For intTab = 0 To arrTabs.Count - 1
                objTab = CType(arrTabs(intTab), TabInfo)

                HostTab = New TabStripDetails
                HostTab.PortalId = PortalId
                HostTab.TabId = objTab.TabID
                HostTab.TabName = objTab.TabName
                HostTab.TabOrder = objTab.TabOrder
                HostTab.AuthorizedRoles = objTab.AuthorizedRoles
                HostTab.AdministratorRoles = objTab.AdministratorRoles
                HostTab.IsVisible = objTab.IsVisible
                HostTab.DisableLink = objTab.DisableLink
                HostTab.ParentId = objTab.ParentId
                HostTab.Level = objTab.Level
                HostTab.IconFile = objTab.IconFile
                HostTab.HasChildren = False
                HostTab.IsDeleted = objTab.IsDeleted
                HostTab.URL = Global.ApplicationPath & "/" & glbDefaultPage & "?tabid=" & HostTab.TabId.ToString & "&portalid=" & HostTab.PortalId.ToString

                Me.DesktopTabs.Add(HostTab)
            Next intTab

            ' get current tab module settings
            dt = CType(DataCache.GetCache("GetPortalTabModules" & intTabId.ToString), DataTable)
            If dt Is Nothing Then
                dt = ConvertDataReaderToDataTable(DataProvider.Instance().GetPortalTabModules(Me.PortalId, Me.ActiveTab.TabId))

                ' get module container
                dt.Columns.Add(New DataColumn("ContainerModuleId", Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("ContainerPath", Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("ContainerSrc", Type.GetType("System.String")))
                Dim intContainerModuleId As Integer
                Dim strContainerPath As String
                Dim strContainerSrc As String
                For intRow = 0 To dt.Rows.Count - 1
                    intContainerModuleId = Null.NullInteger
                    strContainerPath = ""
                    strContainerSrc = ""
                    objSkin = objSkins.GetSkin(SkinInfo.RootContainer, PortalId, Convert.ToInt32(dt.Rows(intRow).Item("TabID")), Convert.ToInt32(dt.Rows(intRow).Item("ModuleID")), False)
                    If Not objSkin Is Nothing Then
                        intContainerModuleId = objSkin.ModuleId
                        Select Case objSkin.SkinType
                            Case "G" ' global
                                strContainerPath = Global.HostPath & SkinInfo.RootContainer & "/" & objSkin.SkinName & "/"
                            Case "L" ' local
                                strContainerPath = Me.UploadDirectory & SkinInfo.RootContainer & "/" & objSkin.SkinName & "/"
                        End Select
                        strContainerSrc = objSkin.SkinSrc
                    End If
                    dt.Rows(intRow).Item("ContainerModuleId") = intContainerModuleId
                    dt.Rows(intRow).Item("ContainerPath") = strContainerPath
                    dt.Rows(intRow).Item("ContainerSrc") = strContainerSrc
                Next intRow

                If intCacheTimeout <> 0 Then
                    DataCache.SetCache("GetPortalTabModules" & intTabId.ToString, dt, intCacheTimeout)
                End If
            End If

            Dim objPaneModules As New Hashtable

            For intRow = 0 To dt.Rows.Count - 1
                Dim m As New ModuleSettings

                m.ModuleId = Convert.ToInt32(dt.Rows(intRow).Item("ModuleID"))
                m.ModuleDefId = Convert.ToInt32(dt.Rows(intRow).Item("ModuleDefID"))
                m.TabId = Convert.ToInt32(dt.Rows(intRow).Item("TabID"))
                m.PaneName = dt.Rows(intRow).Item("PaneName").ToString
                m.ModuleTitle = dt.Rows(intRow).Item("ModuleTitle").ToString
                m.AuthorizedEditRoles = dt.Rows(intRow).Item("AuthorizedEditRoles").ToString
                m.CacheTime = Convert.ToInt32(dt.Rows(intRow).Item("CacheTime"))
                m.ModuleOrder = Convert.ToInt32(dt.Rows(intRow).Item("ModuleOrder"))
                If dt.Rows(intRow).Item("AuthorizedViewRoles").ToString = "" Then
                    m.AuthorizedViewRoles = dt.Rows(intRow).Item("AuthorizedRoles").ToString
                Else
                    m.AuthorizedViewRoles = dt.Rows(intRow).Item("AuthorizedViewRoles").ToString
                End If
                m.Alignment = dt.Rows(intRow).Item("Alignment").ToString
                m.Color = dt.Rows(intRow).Item("Color").ToString
                m.Border = dt.Rows(intRow).Item("Border").ToString
                m.IconFile = dt.Rows(intRow).Item("IconFile").ToString
                m.AllTabs = Convert.ToBoolean(dt.Rows(intRow).Item("AllTabs"))
                m.ShowTitle = Convert.ToBoolean(dt.Rows(intRow).Item("ShowTitle"))
                m.Personalize = Convert.ToInt32(dt.Rows(intRow).Item("Personalize"))
                m.IsDeleted = Convert.ToBoolean(dt.Rows(intRow).Item("IsDeleted"))

                m.ControlSrc = dt.Rows(intRow).Item("ControlSrc").ToString
                m.ControlType = CType(dt.Rows(intRow).Item("ControlType"), SecurityAccessLevel)
                m.ControlTitle = dt.Rows(intRow).Item("ControlTitle").ToString

                m.DesktopModuleId = Convert.ToInt32(dt.Rows(intRow).Item("DesktopModuleId"))
                m.FriendlyName = dt.Rows(intRow).Item("FriendlyName").ToString
                m.IsAdmin = Convert.ToBoolean(dt.Rows(intRow).Item("IsAdmin"))

                m.ContainerModuleId = Convert.ToInt32(dt.Rows(intRow).Item("ContainerModuleId"))
                m.ContainerPath = dt.Rows(intRow).Item("ContainerPath").ToString
                m.ContainerSrc = dt.Rows(intRow).Item("ContainerSrc").ToString

                ' process tab panes
                If objPaneModules.ContainsKey(m.PaneName) = False Then
                    objPaneModules.Add(m.PaneName, 0)
                End If
                m.PaneModuleCount = 0
                If Not m.IsDeleted Then
                    objPaneModules(m.PaneName) = CType(objPaneModules(m.PaneName), Integer) + 1
                    m.PaneModuleIndex = CType(objPaneModules(m.PaneName), Integer) - 1
                End If

                Me.ActiveTab.Modules.Add(m)

            Next intRow

            ' tab panes
            Dim objModuleSettings As ModuleSettings
            For Each objModuleSettings In Me.ActiveTab.Modules
                objModuleSettings.PaneModuleCount = Convert.ToInt32(objPaneModules(objModuleSettings.PaneName))
            Next

        End Sub

        Private Function VerifyPortalTab(ByVal PortalId As Integer, ByVal TabId As Integer, ByVal HomeTabId As Integer) As Integer

            Dim dr As IDataReader

            VerifyPortalTab = -1
            dr = DataProvider.Instance().VerifyPortalTab(PortalId, TabId)
            If dr.Read Then
                If Not IsDBNull(dr("TabId")) Then
                    VerifyPortalTab = Convert.ToInt32(dr("TabId"))
                End If
            End If
            dr.Close()

            If VerifyPortalTab = -1 Then
                VerifyPortalTab = HomeTabId
            End If

            If VerifyPortalTab = -1 Then
                dr = DataProvider.Instance().VerifyPortal(PortalId)
                If dr.Read Then
                    If Not IsDBNull(dr("TabId")) Then
                        VerifyPortalTab = Convert.ToInt32(dr("TabId"))
                    End If
                End If
                dr.Close()
            End If

        End Function

        Public Shared Function GetDesktopDefaultSettings(ByVal ModuleId As Integer) As ModuleSettings

            Dim _moduleSettings As New ModuleSettings

            Dim dr As IDataReader

            dr = DataProvider.Instance().GetModule(ModuleId)

            If dr.Read() Then
                _moduleSettings.ModuleId = Convert.ToInt32(dr("ModuleID"))
                _moduleSettings.ModuleDefId = Convert.ToInt32(dr("ModuleDefID"))
                _moduleSettings.TabId = Convert.ToInt32(dr("TabID"))
                _moduleSettings.PaneName = "Edit"
                _moduleSettings.ModuleTitle = dr("ModuleTitle").ToString
                _moduleSettings.AuthorizedEditRoles = dr("AuthorizedEditRoles").ToString
                _moduleSettings.IconFile = dr("IconFile").ToString
                _moduleSettings.ShowTitle = True
                _moduleSettings.Personalize = 2
            End If
            dr.Close()

            Return _moduleSettings

        End Function

        '*********************************************************************
        '
        ' GetModuleSettings Static Method
        '
        ' The PortalSettings.GetModuleSettings Method returns a hashtable of
        ' custom module specific settings from the database.  This method is
        ' used by some user control modules (Xml, Image, etc) to access misc
        ' settings.
        '
        '*********************************************************************

        Public Shared Function GetModuleSettings(ByVal ModuleId As Integer) As Hashtable

            Dim _settings As New Hashtable

            Dim dr As IDataReader = DataProvider.Instance().GetModuleSettings(ModuleId)

            While dr.Read()
                _settings(dr.GetString(0)) = dr.GetString(1)
            End While
            dr.Close()

            Return _settings

        End Function

        Public Shared Function GetHostSettings() As Hashtable

            Dim _settings As New Hashtable

            Dim dr As IDataReader = DataProvider.Instance().GetHostSettings

            While dr.Read()
                _settings(dr.GetString(0)) = dr.GetString(1)
            End While
            dr.Close()

            Return _settings

        End Function

#Region "Old GetPortalByAlias"
        'Public Shared Function GetPortalByAlias(ByVal PortalAlias As String) As Integer

        '    Dim objPortalAlias As Hashtable = GetPortalAliasLookup()

        '    GetPortalByAlias = -1

        '    ' locate portalalias ( exact match )
        '    If objPortalAlias.ContainsKey(PortalAlias.ToLower) Then
        '        GetPortalByAlias = CType(objPortalAlias(PortalAlias.ToLower), Integer)
        '    End If

        '    If GetPortalByAlias = -1 Then
        '        ' relate the PortalAlias to the default portal on a fresh database installation

        '        DataProvider.Instance().UpdatePortalAlias(PortalAlias)

        '        Dim dr As IDataReader = DataProvider.Instance().GetPortalByAlias(PortalAlias)
        '        If dr.Read Then
        '            If Not IsDBNull(dr("PortalId")) Then
        '                GetPortalByAlias = Convert.ToInt32(dr("PortalID"))
        '            End If
        '        End If
        '        dr.Close()
        '    End If

        '    Return GetPortalByAlias

        'End Function
#End Region

        '********************************************************************
        'Purpose           	:Get PortalID by Alias
        'Params         	:PortalAlias
        'Returns         	:PortalID
        'Created date		:Unknown
        'Creator		    :Unknown
        'Modified date  	:Mar 9th 2006
        'Modifier        	:Phuocdd
        '********************************************************************
        Public Shared Function GetPortalByAlias(ByVal PortalAlias As String) As Integer

            Dim objPortalAlias As Hashtable = GetPortalAliasLookup()

            GetPortalByAlias = -1

            Dim arrKeys(objPortalAlias.Count - 1) As String 'This array will have objPortalAlias.Count children --> not good

            objPortalAlias.Keys.CopyTo(arrKeys, 0)

            ' locate portalalias ( StartsWith )
            For i As Integer = 0 To arrKeys.Length - 1
                If PortalAlias.ToLower().StartsWith(CStr(arrKeys.GetValue(i)).ToLower()) Then
                    GetPortalByAlias = CType(objPortalAlias(CStr(arrKeys.GetValue(i)).ToLower()), Integer)
                    Exit For
                End If
            Next

            If GetPortalByAlias = -1 Then
                ' relate the PortalAlias to the default portal on a fresh database installation

                DataProvider.Instance().UpdatePortalAlias(PortalAlias)

                Dim dr As IDataReader = DataProvider.Instance().GetPortalByAlias(PortalAlias)
                If dr.Read Then
                    If Not IsDBNull(dr("PortalId")) Then
                        GetPortalByAlias = Convert.ToInt32(dr("PortalID"))
                    End If
                End If
                dr.Close()
            End If

            Return GetPortalByAlias

        End Function

        Public Shared Function GetPortalByTab(ByVal TabID As Integer, ByVal PortalAlias As String) As String

            Dim objPortalAlias As Hashtable = GetPortalAliasLookup()

            Dim intPortalId As Integer = -1
            Dim blnDeleted As Boolean = False

            Dim objTabs As New TabController
            Dim objTab As TabInfo = objTabs.GetTab(TabID)
            If Not objTab Is Nothing Then
                blnDeleted = objTab.IsDeleted
                If Null.IsNull(objTab.PortalID) = False Then
                    intPortalId = objTab.PortalID
                End If
            End If

            GetPortalByTab = Nothing

            If intPortalId = -1 Then ' host tab 
                GetPortalByTab = PortalAlias
            Else
                If blnDeleted = False Then
                    ' locate portalalias
                    Dim strPortalAlias As String
                    For Each strPortalAlias In objPortalAlias.Keys
                        If strPortalAlias.StartsWith(PortalAlias.ToLower) = True And CType(objPortalAlias(strPortalAlias), Integer) = intPortalId Then
                            GetPortalByTab = strPortalAlias
                        End If
                    Next
                End If
            End If

            Return GetPortalByTab

        End Function

        Public Shared Function GetPortalAliasLookup() As Hashtable

            Try
                Dim objPortalAlias As Hashtable = CType(DataCache.GetCache("GetPortalByAlias"), Hashtable)

                If objPortalAlias Is Nothing Then

                    Dim objPortals As New PortalController
                    Dim objPortal As PortalInfo
                    Dim intIndex As Integer
                    Dim arrPortalAlias() As String
                    Dim strPortalAlias As String

                    objPortalAlias = New Hashtable

                    ' load alias values for all portals
                    Dim arrPortals As ArrayList = objPortals.GetPortals()
                    For intIndex = 0 To arrPortals.Count - 1
                        objPortal = CType(arrPortals(intIndex), PortalInfo)
                        arrPortalAlias = Split(objPortal.PortalAlias, ",")
                        For Each strPortalAlias In arrPortalAlias
                            strPortalAlias = strPortalAlias.Trim() ' remove white space
                            If objPortalAlias.ContainsKey(strPortalAlias.ToLower) = False Then
                                objPortalAlias(strPortalAlias.ToLower) = objPortal.PortalID
                            End If
                        Next
                    Next

                    DataCache.SetCache("GetPortalByAlias", objPortalAlias)
                End If

                Return objPortalAlias

            Catch exc As Exception

                ' this is the first data access in Begin_Request and will catch any general connection issues
                Dim objHttpContext As HttpContext = HttpContext.Current
                Dim objStreamReader As StreamReader
                objStreamReader = File.OpenText(objHttpContext.Server.MapPath("~/500.htm"))
                Dim strHTML As String = objStreamReader.ReadToEnd
                objStreamReader.Close()
                strHTML = Replace(strHTML, "[MESSAGE]", "ERROR: Could not connect to database.<br><br>" & exc.Message)
                objHttpContext.Response.Write(strHTML)
                objHttpContext.Response.End()
            End Try
        End Function

        Private Sub GetBreadCrumbsRecursively(ByVal intTabId As Integer)
            Dim objTabs As New TabController

            Dim objTab As TabInfo = objTabs.GetTab(intTabId)
            If Not objTab Is Nothing Then
                If Not IsDBNull(objTab.ParentId) Then
                    Dim tabDetails As New TabStripDetails

                    tabDetails.TabId = intTabId
                    tabDetails.TabName = objTab.TabName

                    Me.BreadCrumbs.Insert(0, tabDetails)

                    GetBreadCrumbsRecursively(objTab.ParentId)
                Else ' root tabid
                    Dim tabDetails As New TabStripDetails

                    tabDetails.TabId = intTabId
                    tabDetails.TabName = objTab.TabName

                    Me.BreadCrumbs.Insert(0, tabDetails)
                End If
            End If

        End Sub

        Public Shared Function GetDatabaseVersion() As IDataReader

            Return DataProvider.Instance().GetDatabaseVersion

        End Function

        Public Shared Sub UpdateDatabaseVersion(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer)

            DataProvider.Instance().UpdateDatabaseVersion(Major, Minor, Build)

        End Sub

        Public Shared Sub UpgradeDatabaseSchema(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer)

            DataProvider.Instance().UpgradeDatabaseSchema(Major, Minor, Build)

        End Sub

        Public Shared Function FindDatabaseVersion(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer) As Boolean

            FindDatabaseVersion = False
            Dim dr As IDataReader = DataProvider.Instance().FindDatabaseVersion(Major, Minor, Build)
            If dr.Read Then
                FindDatabaseVersion = True
            End If
            dr.Close()

        End Function

        Public Shared Function GetProviderPath() As String

            Return DataProvider.Instance().GetProviderPath()

        End Function

        Public Shared Function ExecuteScript(ByVal strScript As String) As String

            Return DataProvider.Instance().ExecuteScript(strScript)

        End Function

        Public Shared Function ExecuteScript(ByVal strScript As String, ByVal UseTransactions As Boolean) As String

            Return DataProvider.Instance().ExecuteScript(strScript, UseTransactions)

        End Function

    End Class

End Namespace
