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
Imports System.XML

Namespace PortalQH
    Public Class PortalInfo
        Private _PortalID As Integer
        Private _PortalAlias As String
        Private _PortalName As String
        Private _LogoFile As String
        Private _FooterText As String
        Private _ExpiryDate As Date
        Private _UserRegistration As Integer
        Private _BannerAdvertising As Integer
        Private _AdministratorId As String
        Private _Currency As String
        Private _HostFee As Single
        Private _HostSpace As Integer
        Private _AdministratorRoleId As Integer
        Private _RegisteredRoleId As Integer
        Private _Description As String
        Private _KeyWords As String
        Private _BackgroundFile As String
        Private _PaymentProcessor As String
        Private _ProcessorUserId As String
        Private _ProcessorPassword As String
        Private _SiteLogHistory As Integer
        Private _Email As String
        Private _AdminTabId As Integer
        Private _SuperUserId As Integer
        Private _SuperTabId As Integer
        Private _Users As Integer
        Private _HomeTabId As Integer
        Private _LoginTabId As Integer
        Private _UserTabId As Integer

        ' initialization
        Public Sub New()
        End Sub

        ' public properties
        Public Property PortalID() As Integer
            Get
                Return _PortalID
            End Get
            Set(ByVal Value As Integer)
                _PortalID = Value
            End Set
        End Property
        Public Property PortalAlias() As String
            Get
                Return _PortalAlias
            End Get
            Set(ByVal Value As String)
                _PortalAlias = Value
            End Set
        End Property
        Public Property PortalName() As String
            Get
                Return _PortalName
            End Get
            Set(ByVal Value As String)
                _PortalName = Value
            End Set
        End Property
        Public Property LogoFile() As String
            Get
                Return _LogoFile
            End Get
            Set(ByVal Value As String)
                _LogoFile = Value
            End Set
        End Property
        Public Property FooterText() As String
            Get
                Return _FooterText
            End Get
            Set(ByVal Value As String)
                _FooterText = Value
            End Set
        End Property
        Public Property ExpiryDate() As Date
            Get
                Return _ExpiryDate
            End Get
            Set(ByVal Value As Date)
                _ExpiryDate = Value
            End Set
        End Property
        Public Property UserRegistration() As Integer
            Get
                Return _UserRegistration
            End Get
            Set(ByVal Value As Integer)
                _UserRegistration = Value
            End Set
        End Property
        Public Property BannerAdvertising() As Integer
            Get
                Return _BannerAdvertising
            End Get
            Set(ByVal Value As Integer)
                _BannerAdvertising = Value
            End Set
        End Property
        Public Property AdministratorId() As String
            Get
                Return _AdministratorId
            End Get
            Set(ByVal Value As String)
                _AdministratorId = Value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Return _Currency
            End Get
            Set(ByVal Value As String)
                _Currency = Value
            End Set
        End Property
        Public Property HostFee() As Single
            Get
                Return _HostFee
            End Get
            Set(ByVal Value As Single)
                _HostFee = Value
            End Set
        End Property
        Public Property HostSpace() As Integer
            Get
                Return _HostSpace
            End Get
            Set(ByVal Value As Integer)
                _HostSpace = Value
            End Set
        End Property
        Public Property AdministratorRoleId() As Integer
            Get
                Return _AdministratorRoleId
            End Get
            Set(ByVal Value As Integer)
                _AdministratorRoleId = Value
            End Set
        End Property
        Public Property RegisteredRoleId() As Integer
            Get
                Return _RegisteredRoleId
            End Get
            Set(ByVal Value As Integer)
                _RegisteredRoleId = Value
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
        Public Property BackgroundFile() As String
            Get
                Return _BackgroundFile
            End Get
            Set(ByVal Value As String)
                _BackgroundFile = Value
            End Set
        End Property
        Public Property PaymentProcessor() As String
            Get
                Return _PaymentProcessor
            End Get
            Set(ByVal Value As String)
                _PaymentProcessor = Value
            End Set
        End Property
        Public Property ProcessorPassword() As String
            Get
                Return _ProcessorPassword
            End Get
            Set(ByVal Value As String)
                _ProcessorPassword = Value
            End Set
        End Property
        Public Property ProcessorUserId() As String
            Get
                Return _ProcessorUserId
            End Get
            Set(ByVal Value As String)
                _ProcessorUserId = Value
            End Set
        End Property
        Public Property SiteLogHistory() As Integer
            Get
                Return _SiteLogHistory
            End Get
            Set(ByVal Value As Integer)
                _SiteLogHistory = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property
        Public Property AdminTabId() As Integer
            Get
                Return _AdminTabId
            End Get
            Set(ByVal Value As Integer)
                _AdminTabId = Value
            End Set
        End Property
        Public Property SuperUserId() As Integer
            Get
                Return _SuperUserId
            End Get
            Set(ByVal Value As Integer)
                _SuperUserId = Value
            End Set
        End Property
        Public Property SuperTabId() As Integer
            Get
                Return _SuperTabId
            End Get
            Set(ByVal Value As Integer)
                _SuperTabId = Value
            End Set
        End Property
        Public Property Users() As Integer
            Get
                Return _Users
            End Get
            Set(ByVal Value As Integer)
                _Users = Value
            End Set
        End Property
        Public Property HomeTabId() As Integer
            Get
                Return _HomeTabId
            End Get
            Set(ByVal Value As Integer)
                _HomeTabId = Value
            End Set
        End Property
        Public Property LoginTabId() As Integer
            Get
                Return _LoginTabId
            End Get
            Set(ByVal Value As Integer)
                _LoginTabId = Value
            End Set
        End Property
        Public Property UserTabId() As Integer
            Get
                Return _UserTabId
            End Get
            Set(ByVal Value As Integer)
                _UserTabId = Value
            End Set
        End Property
    End Class
    Public Class PortalController

        Public Function AddPortalInfo(ByVal PortalName As String, ByVal PortalAlias As String, ByVal Currency As String, ByVal FullName As String, ByVal Username As String, ByVal Password As String, ByVal Email As String, ByVal ExpiryDate As Date, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal SiteLogHistory As Integer, ByVal TemplatePath As String, ByVal TemplateFile As String) As Integer

            Dim objRole As New RoleController
            Dim objUser As New UserController
            Dim objModuleDefinitions As New ModuleDefinitionController

            ' add portal
            Dim PortalId As Integer = -1
            Try
                PortalId = DataProvider.Instance().AddPortalInfo(PortalName, PortalAlias, Currency, FullName, Username, Password, Email, ExpiryDate, HostFee, HostSpace, SiteLogHistory)
            Catch
                ' error creating portal
            End Try

            If PortalId <> -1 Then

                ' add administrator
                Dim AdministratorId As String = ""
                Try
                    AdministratorId = objUser.AddUser(PortalId, FullName, "", "", "", "", "", "", "", Email, Username, Password, True, Null.NullInteger, "", "")
                Catch
                    ' error creating admin user account - duplicate username but different password
                End Try

                If AdministratorId <> "" Then
                    ' add administrator role
                    Dim objRoleInfo As New RoleInfo
                    objRoleInfo.PortalID = PortalId
                    objRoleInfo.RoleName = "Administrators"
                    objRoleInfo.Description = "Portal Administrators"
                    objRoleInfo.ServiceFee = 0
                    objRoleInfo.BillingPeriod = 0
                    objRoleInfo.BillingFrequency = "M"
                    objRoleInfo.TrialFee = 0
                    objRoleInfo.TrialPeriod = 0
                    objRoleInfo.TrialFrequency = "N"
                    objRoleInfo.IsPublic = False
                    objRoleInfo.AutoAssignment = False
                    Dim AdministratorRoleId As Integer = objRole.AddRole(objRoleInfo)

                    ' add user administrator role
                    objRole.AddUserRole(PortalId, AdministratorId, AdministratorRoleId, Null.NullDate)

                    ' add registered role
                    objRoleInfo.PortalID = PortalId
                    objRoleInfo.RoleName = "Registered Users"
                    objRoleInfo.Description = "Registered Users"
                    objRoleInfo.ServiceFee = 0
                    objRoleInfo.BillingPeriod = 0
                    objRoleInfo.BillingFrequency = "M"
                    objRoleInfo.TrialFee = 0
                    objRoleInfo.TrialPeriod = 0
                    objRoleInfo.TrialFrequency = "N"
                    objRoleInfo.IsPublic = False
                    objRoleInfo.AutoAssignment = True
                    Dim RegisteredRoleId As Integer = objRole.AddRole(objRoleInfo)

                    ' add user registered role
                    objRole.AddUserRole(PortalId, AdministratorId, RegisteredRoleId, Null.NullDate)

                    ' complete portal setup
                    DataProvider.Instance().UpdatePortalSetup(PortalId, AdministratorId, AdministratorRoleId, RegisteredRoleId, Convert.ToInt32(Null.SetNull(0)), Convert.ToInt32(Null.SetNull(0)), Convert.ToInt32(Null.SetNull(0)))

                    ' parse admin template
                    ParseTemplate(PortalId, TemplatePath & "admin.template")

                    ' parse user template
                    If TemplateFile <> "" Then
                        ParseTemplate(PortalId, TemplatePath & TemplateFile)
                    End If

                    ' clear portal alias cache
                    DataCache.ClearCoreCache(CoreCacheType.Host)

                Else ' clean up
                    DeletePortalInfo(PortalId)
                    PortalId = -1
                End If

            End If

            Return PortalId

        End Function

        'Public Sub UpdatePortalInfo(ByVal PortalId As Integer, ByVal PortalName As String, ByVal PortalAlias As String, ByVal LogoFile As String, ByVal FooterText As String, ByVal ExpiryDate As Date, ByVal UserRegistration As Integer, ByVal BannerAdvertising As Integer, ByVal Currency As String, ByVal AdministratorId As Integer, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal PaymentProcessor As String, ByVal ProcessorUserId As String, ByVal ProcessorPassword As String, ByVal Description As String, ByVal KeyWords As String, ByVal BackgroundFile As String, ByVal SiteLogHistory As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)
        Public Sub UpdatePortalInfo(ByVal PortalId As Integer, ByVal PortalName As String, ByVal PortalAlias As String, ByVal LogoFile As String, ByVal FooterText As String, ByVal ExpiryDate As Date, ByVal UserRegistration As Integer, ByVal BannerAdvertising As Integer, ByVal Currency As String, ByVal AdministratorId As String, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal PaymentProcessor As String, ByVal ProcessorUserId As String, ByVal ProcessorPassword As String, ByVal Description As String, ByVal KeyWords As String, ByVal BackgroundFile As String, ByVal SiteLogHistory As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)

            DataProvider.Instance().UpdatePortalInfo(PortalId, PortalName, PortalAlias, LogoFile, FooterText, ExpiryDate, UserRegistration, BannerAdvertising, Currency, AdministratorId, HostFee, HostSpace, PaymentProcessor, ProcessorUserId, ProcessorPassword, Description, KeyWords, BackgroundFile, SiteLogHistory, HomeTabId, LoginTabId, UserTabId)

            ' clear portal alias cache and portal settings
            DataCache.ClearCoreCache(CoreCacheType.Host)
            DataCache.ClearCoreCache(CoreCacheType.Portal, PortalId, True)

        End Sub

        Public Sub DeletePortalInfo(ByVal PortalId As Integer)

            DataProvider.Instance().DeletePortalInfo(PortalId)

            ' clear portal alias cache and entire portal
            DataCache.ClearCoreCache(CoreCacheType.Host)
            DataCache.ClearCoreCache(CoreCacheType.Portal, PortalId, True)

        End Sub


        Public Function GetPortals() As ArrayList

            Return CBO.FillCollection(DataProvider.Instance().GetPortals(), GetType(PortalInfo))

        End Function


        Public Function GetPortal(ByVal PortalId As Integer) As PortalInfo

            Return CType(CBO.FillObject(DataProvider.Instance().GetPortal(PortalId), GetType(PortalInfo)), PortalInfo)

        End Function


        Public Sub UpdatePortalExpiry(ByVal PortalId As Integer)

            Dim ExpiryDate As DateTime

            Dim dr As IDataReader = DataProvider.Instance().GetPortal(PortalId)
            If dr.Read Then
                If IsDBNull(dr("ExpiryDate")) Then
                    ExpiryDate = Convert.ToDateTime(dr("ExpiryDate"))
                Else
                    ExpiryDate = Now()
                End If

                'DataProvider.Instance().UpdatePortalInfo(PortalId, Convert.ToString(dr("PortalName")), Convert.ToString(dr("PortalAlias")), Convert.ToString(dr("LogoFile")), Convert.ToString(dr("FooterText")), DateAdd(DateInterval.Month, 1, ExpiryDate), Convert.ToInt32(dr("UserRegistration")), Convert.ToInt32(dr("BannerAdvertising")), Convert.ToString(dr("Currency")), Convert.ToInt32(dr("AdministratorId")), Convert.ToDouble(dr("HostFee")), Convert.ToDouble(dr("HostSpace")), Convert.ToString(dr("PaymentProcessor")), Convert.ToString(dr("ProcessorUserId")), Convert.ToString(dr("ProcessorPassword")), Convert.ToString(dr("Description")), Convert.ToString(dr("KeyWords")), Convert.ToString(dr("BackgroundFile")), Convert.ToInt32(dr("SiteLogHistory")), Convert.ToInt32(dr("HomeTabId")), Convert.ToInt32(dr("LoginTabId")), Convert.ToInt32(dr("UserTabId")))
                DataProvider.Instance().UpdatePortalInfo(PortalId, Convert.ToString(dr("PortalName")), Convert.ToString(dr("PortalAlias")), Convert.ToString(dr("LogoFile")), Convert.ToString(dr("FooterText")), DateAdd(DateInterval.Month, 1, ExpiryDate), Convert.ToInt32(dr("UserRegistration")), Convert.ToInt32(dr("BannerAdvertising")), Convert.ToString(dr("Currency")), CStr(dr("AdministratorId")), Convert.ToDouble(dr("HostFee")), Convert.ToDouble(dr("HostSpace")), Convert.ToString(dr("PaymentProcessor")), Convert.ToString(dr("ProcessorUserId")), Convert.ToString(dr("ProcessorPassword")), Convert.ToString(dr("Description")), Convert.ToString(dr("KeyWords")), Convert.ToString(dr("BackgroundFile")), Convert.ToInt32(dr("SiteLogHistory")), Convert.ToInt32(dr("HomeTabId")), Convert.ToInt32(dr("LoginTabId")), Convert.ToInt32(dr("UserTabId")))
            End If
            dr.Close()

        End Sub

        Public Function GetPortalSpaceUsed(Optional ByVal PortalId As Integer = -1) As Integer

            GetPortalSpaceUsed = 0
            Dim dr As IDataReader = DataProvider.Instance().GetPortalSpaceUsed(PortalId)
            If dr.Read Then
                If Not IsDBNull(dr("SpaceUsed")) Then
                    GetPortalSpaceUsed = Convert.ToInt32(dr("SpaceUsed"))
                End If
            End If
            dr.Close()

        End Function

        Private Sub ParseTemplate(ByVal PortalId As Integer, ByVal Template As String)

            Dim xmlDoc As New XmlDocument
            Dim nodeTab As XmlNode
            Dim nodePane As XmlNode
            Dim nodeModule As XmlNode
            Dim intTabId As Integer

            Dim objDesktopModules As New DesktopModuleController
            Dim objModuleDefinitions As New ModuleDefinitionController
            Dim objModuleDefinition As ModuleDefinitionInfo
            Dim objTabs As New TabController
            Dim objTab As TabInfo
            Dim objModules As New ModuleController
            Dim objModule As ModuleInfo
            Dim intIndex As Integer

            ' open the XML file
            Try
                xmlDoc.Load(Template)
            Catch ' error
                ' 
            End Try

            ' get the portal
            Dim objPortal As PortalInfo = GetPortal(PortalId)

            ' iterate through the tabs
            For Each nodeTab In xmlDoc.SelectNodes("//portal/tabs/tab")

                If GetNodeValue(nodeTab, "name") <> "" Then

                    objTab = objTabs.GetTabByName(GetNodeValue(nodeTab, "name"), PortalId)

                    If objTab Is Nothing Then
                        objTab = New TabInfo
                        objTab = CType(CBO.InitializeObject(objTab, GetType(TabInfo)), TabInfo)
                        intTabId = Null.NullInteger
                    Else
                        intTabId = objTab.TabID
                    End If

                    objTab.TabID = intTabId
                    objTab.PortalID = PortalId
                    objTab.TabName = GetNodeValue(nodeTab, "name")
                    objTab.Title = GetNodeValue(nodeTab, "title")
                    objTab.Description = GetNodeValue(nodeTab, "description")
                    objTab.KeyWords = GetNodeValue(nodeTab, "keywords")
                    objTab.IsVisible = Convert.ToBoolean(GetNodeValue(nodeTab, "visible", "True"))
                    objTab.DisableLink = Convert.ToBoolean(GetNodeValue(nodeTab, "disabled", "False"))
                    objTab.IconFile = GetNodeValue(nodeTab, "iconfile")
                    objTab.AuthorizedRoles = ConvertRoles(GetNodeValue(nodeTab, "authorizedroles", "-1;"), objPortal)
                    objTab.AdministratorRoles = objPortal.AdministratorRoleId.ToString & ";"

                    ' get parent
                    If GetNodeValue(nodeTab, "parent") <> "" Then
                        Dim objParent As TabInfo = objTabs.GetTabByName(GetNodeValue(nodeTab, "parent"), PortalId)
                        If Not objParent Is Nothing Then
                            objTab.ParentId = objParent.TabID
                        End If
                    Else
                        objTab.ParentId = Null.NullInteger
                    End If

                    If Null.IsNull(intTabId) Then
                        ' create
                        intTabId = objTabs.AddTab(objTab)
                    Else
                        ' update
                        objTabs.UpdateTab(objTab)
                    End If

                    ' iterate through the panes
                    If Not nodeTab.SelectSingleNode("panes") Is Nothing Then
                        For Each nodePane In nodeTab.SelectSingleNode("panes").ChildNodes
                            ' iterate through the modules
                            If Not nodePane.SelectSingleNode("modules") Is Nothing Then
                                For Each nodeModule In nodePane.SelectSingleNode("modules")
                                    ' get module definition
                                    Dim objDesktopModule As DesktopModuleInfo = objDesktopModules.GetDesktopModuleByName(GetNodeValue(nodeModule, "definition"))
                                    If Not objDesktopModule Is Nothing Then
                                        Dim arrModuleDefinitions As ArrayList = objModuleDefinitions.GetModuleDefinitions(objDesktopModule.DesktopModuleID)
                                        For intIndex = 0 To arrModuleDefinitions.Count - 1
                                            objModuleDefinition = CType(arrModuleDefinitions(intIndex), ModuleDefinitionInfo)
                                            If Not objModuleDefinition Is Nothing Then
                                                ' add module
                                                objModule = New ModuleInfo
                                                objModule = CType(CBO.InitializeObject(objModule, GetType(ModuleInfo)), ModuleInfo)
                                                objModule.TabID = intTabId
                                                objModule.ModuleOrder = -1
                                                objModule.ModuleTitle = GetNodeValue(nodeModule, "title", objModuleDefinition.FriendlyName)
                                                objModule.PaneName = GetNodeValue(nodePane, "name")
                                                objModule.ModuleDefID = objModuleDefinition.ModuleDefID
                                                objModule.CacheTime = Convert.ToInt32(GetNodeValue(nodeModule, "cachetime", "0"))
                                                objModule.AuthorizedEditRoles = objPortal.AdministratorRoleId.ToString & ";"
                                                objModule.AuthorizedViewRoles = ConvertRoles(GetNodeValue(nodeModule, "authorizedviewroles"), objPortal)
                                                objModule.Alignment = GetNodeValue(nodeModule, "alignment")
                                                objModule.IconFile = GetNodeValue(nodeModule, "iconfile")
                                                objModule.AllTabs = Convert.ToBoolean(GetNodeValue(nodeModule, "alltabs", "False"))
                                                objModule.ShowTitle = Convert.ToBoolean(GetNodeValue(nodeModule, "showtitle", "True"))
                                                objModule.Personalize = Convert.ToInt32(GetNodeValue(nodeModule, "personalize", "0"))
                                                objModules.AddModule(objModule)
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If
            Next

        End Sub

        Private Function GetNodeValue(ByVal objNode As XmlNode, ByVal NodeName As String, Optional ByVal DefaultValue As String = "") As String

            Dim strValue As String = DefaultValue

            Try
                strValue = objNode.Item(NodeName).InnerText

                If strValue = "" And DefaultValue <> "" Then
                    strValue = DefaultValue
                End If
            Catch
                ' node does not exist - legacy issue
            End Try

            Return strValue

        End Function

        Private Function ConvertRoles(ByVal Roles As String, ByVal objPortal As PortalInfo) As String

            Dim strRoles As String = Roles

            strRoles = strRoles.Replace("All", glbRoleAllUsers)
            strRoles = strRoles.Replace("Unauthenticated", glbRoleUnauthUser)
            strRoles = strRoles.Replace("Registered", objPortal.RegisteredRoleId.ToString)
            strRoles = strRoles.Replace("Administrator", objPortal.AdministratorRoleId.ToString)
            strRoles = strRoles.Replace("Super", glbRoleSuperUser)

            Return strRoles

        End Function

    End Class

End Namespace