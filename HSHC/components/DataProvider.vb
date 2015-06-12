Imports System
Imports System.IO
Imports System.Web.Caching
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Reflection
Imports System.Configuration
Imports System.Web
Imports System.Xml

Namespace PortalQH

    Public MustInherit Class DataProvider

        ' provider constants - eliminates need for Reflection later
        Private Const [ProviderType] As String = "data" ' maps to <sectionGroup> in web.config 

        Public Shared Function Instance() As DataProvider

            Dim strCacheKey As String = [ProviderType] & "provider"

            ' Use the cache because the reflection used later is expensive
            Dim objConstructor As ConstructorInfo = CType(DataCache.GetCache(strCacheKey), ConstructorInfo)

            If objConstructor Is Nothing Then

                ' Get the name of the provider
                Dim objProviderConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration([ProviderType])

                ' The assembly should be in \bin or GAC, so we simply need to get an instance of the type
                Try

                    ' Get the typename of the Core DataProvider from web.config
                    Dim strTypeName As String = CType(objProviderConfiguration.Providers(objProviderConfiguration.DefaultProvider), Provider).Type

                    ' Use reflection to store the constructor of the class that implements DataProvider
                    Dim t As Type = Type.GetType(strTypeName, True)
                    objConstructor = t.GetConstructor(System.Type.EmptyTypes)

                    ' Insert the type into the cache
                    DataCache.SetCache(strCacheKey, objConstructor)

                Catch e As Exception

                    ' Could not load the provider - this is likely due to binary compatibility issues 

                End Try
            End If

            Return CType(objConstructor.Invoke(Nothing), DataProvider)

        End Function

        ' all core methods defined below

        ' upgrade
        Public MustOverride Function GetProviderPath() As String
        Public MustOverride Overloads Function ExecuteScript(ByVal SQL As String) As String
        Public MustOverride Overloads Function ExecuteScript(ByVal SQL As String, ByVal UseTransactions As Boolean) As String
        Public MustOverride Function GetDatabaseVersion() As IDataReader
        Public MustOverride Sub UpdateDatabaseVersion(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer)
        Public MustOverride Function FindDatabaseVersion(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer) As IDataReader
        Public MustOverride Sub UpgradeDatabaseSchema(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer)

        ' host
        Public MustOverride Function GetHostSettings() As IDataReader
        Public MustOverride Function GetHostSetting(ByVal SettingName As String) As IDataReader
        Public MustOverride Sub AddHostSetting(ByVal SettingName As String, ByVal SettingValue As String)
        Public MustOverride Sub UpdateHostSetting(ByVal SettingName As String, ByVal SettingValue As String)

        ' portal
        Public MustOverride Function GetPortalByAlias(ByVal PortalAlias As String) As IDataReader
        Public MustOverride Sub UpdatePortalAlias(ByVal PortalAlias As String)
        Public MustOverride Function GetPortalSettings(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetPortalByTab(ByVal TabId As Integer, ByVal PortalAlias As String) As IDataReader
        Public MustOverride Function AddPortalInfo(ByVal PortalName As String, ByVal PortalAlias As String, ByVal Currency As String, ByVal FullName As String, ByVal Username As String, ByVal Password As String, ByVal Email As String, ByVal ExpiryDate As Date, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal SiteLogHistory As Integer) As Integer
        'Public MustOverride Sub UpdatePortalInfo(ByVal PortalId As Integer, ByVal PortalName As String, ByVal PortalAlias As String, ByVal LogoFile As String, ByVal FooterText As String, ByVal ExpiryDate As Date, ByVal UserRegistration As Integer, ByVal BannerAdvertising As Integer, ByVal Currency As String, ByVal AdministratorId As Integer, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal PaymentProcessor As String, ByVal ProcessorUserId As String, ByVal ProcessorPassword As String, ByVal Description As String, ByVal KeyWords As String, ByVal BackgroundFile As String, ByVal SiteLogHistory As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)
        Public MustOverride Sub UpdatePortalInfo(ByVal PortalId As Integer, ByVal PortalName As String, ByVal PortalAlias As String, ByVal LogoFile As String, ByVal FooterText As String, ByVal ExpiryDate As Date, ByVal UserRegistration As Integer, ByVal BannerAdvertising As Integer, ByVal Currency As String, ByVal AdministratorId As String, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal PaymentProcessor As String, ByVal ProcessorUserId As String, ByVal ProcessorPassword As String, ByVal Description As String, ByVal KeyWords As String, ByVal BackgroundFile As String, ByVal SiteLogHistory As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)
        Public MustOverride Sub UpdatePortalSetup(ByVal PortalId As Integer, ByVal AdministratorId As String, ByVal AdministratorRoleId As Integer, ByVal RegisteredRoleId As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)
        Public MustOverride Sub DeletePortalInfo(ByVal PortalId As Integer)
        Public MustOverride Function GetPortals() As IDataReader
        Public MustOverride Function GetPortal(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetPortalSpaceUsed(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function VerifyPortalTab(ByVal PortalId As Integer, ByVal TabId As Integer) As IDataReader
        Public MustOverride Function VerifyPortal(ByVal PortalId As Integer) As IDataReader

        ' tab
        Public MustOverride Function AddTab(ByVal PortalId As Integer, ByVal TabName As String, ByVal AuthorizedRoles As String, ByVal IsVisible As Boolean, ByVal DisableLink As Boolean, ByVal ParentId As Integer, ByVal IconFile As String, ByVal AdministratorRoles As String, ByVal Title As String, ByVal Description As String, ByVal KeyWords As String) As Integer
        Public MustOverride Sub UpdateTab(ByVal TabId As Integer, ByVal TabName As String, ByVal AuthorizedRoles As String, ByVal IsVisible As Boolean, ByVal DisableLink As Boolean, ByVal ParentId As Integer, ByVal IconFile As String, ByVal AdministratorRoles As String, ByVal Title As String, ByVal Description As String, ByVal KeyWords As String, ByVal IsDeleted As Boolean)
        Public MustOverride Sub UpdateTabOrder(ByVal TabId As Integer, ByVal TabOrder As Integer, ByVal Level As Integer, ByVal ParentId As Integer)
        Public MustOverride Sub DeleteTab(ByVal TabId As Integer)
        Public MustOverride Function GetTabs(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetTab(ByVal TabId As Integer) As IDataReader
        Public MustOverride Function GetTabByName(ByVal TabName As String, ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetTabsByParentId(ByVal ParentId As Integer) As IDataReader
        Public MustOverride Sub UpdateTabModuleOrder(ByVal TabId As Integer, ByVal PaneName As String, ByVal OldModuleOrder As Integer, ByVal NewModuleOrder As Integer)
        Public MustOverride Function GetPortalTabModules(ByVal PortalId As Integer, ByVal TabId As Integer) As IDataReader
        Public MustOverride Function GetTabModules(ByVal TabId As Integer) As IDataReader
        Public MustOverride Function GetTabPanes(ByVal TabId As Integer) As IDataReader

        ' module
        Public MustOverride Function GetModule(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetModules(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Sub UpdateModuleOrder(ByVal ModuleId As Integer, ByVal ModuleOrder As Integer, ByVal PaneName As String)
        Public MustOverride Function AddModule(ByVal TabID As Integer, ByVal ModuleDefID As Integer, ByVal ModuleOrder As Integer, ByVal PaneName As String, ByVal ModuleTitle As String, ByVal AuthorizedEditRoles As String, ByVal CacheTime As Integer, ByVal AuthorizedViewRoles As String, ByVal Alignment As String, ByVal Color As String, ByVal Border As String, ByVal IconFile As String, ByVal AllTabs As Boolean, ByVal ShowTitle As Boolean, ByVal Personalize As Integer) As Integer
        Public MustOverride Sub UpdateModule(ByVal ModuleId As Integer, ByVal ModuleOrder As Integer, ByVal ModuleTitle As String, ByVal Alignment As String, ByVal Color As String, ByVal Border As String, ByVal IconFile As String, ByVal CacheTime As Integer, ByVal AuthorizedViewRoles As String, ByVal AuthorizedEditRoles As String, ByVal TabId As Integer, ByVal AllTabs As Boolean, ByVal ShowTitle As Boolean, ByVal Personalize As Integer, ByVal IsDeleted As Boolean)
        Public MustOverride Sub DeleteModule(ByVal ModuleId As Integer)
        Public MustOverride Function GetModuleSettings(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String) As IDataReader
        Public MustOverride Sub UpdateModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String, ByVal SettingValue As String)
        Public MustOverride Sub AddModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String, ByVal SettingValue As String)
        Public MustOverride Function GetTabModuleOrder(ByVal TabId As Integer, ByVal PaneName As String) As IDataReader
        Public MustOverride Function GetSiteModule(ByVal FriendlyName As String, ByVal PortalId As Integer) As Integer

        ' module definition
        Public MustOverride Function GetDesktopModule(ByVal DesktopModuleId As Integer) As IDataReader
        Public MustOverride Function GetDesktopModuleByName(ByVal FriendlyName As String) As IDataReader
        Public MustOverride Function GetDesktopModules() As IDataReader
        Public MustOverride Function GetPortalDesktopModules(ByVal PortalID As Integer) As IDataReader
        Public MustOverride Function GetPremiumDesktopModules(ByVal PortalID As Integer) As IDataReader
        Public MustOverride Function AddDesktopModule(ByVal FriendlyName As String, ByVal Description As String, ByVal Version As String, ByVal IsPremium As Boolean) As Integer
        Public MustOverride Sub UpdateDesktopModule(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String, ByVal Description As String, ByVal Version As String, ByVal IsPremium As Boolean)
        Public MustOverride Sub DeleteDesktopModule(ByVal DesktopModuleId As Integer)
        Public MustOverride Function GetPortalModuleDefinition(ByVal PortalID As Integer, ByVal DesktopModuleID As Integer) As IDataReader
        Public MustOverride Function AddPortalModuleDefinition(ByVal PortalID As Integer, ByVal DesktopModuleID As Integer, ByVal HostFee As Double) As Integer
        Public MustOverride Sub UpdatePortalModuleDefinition(ByVal PortalID As Integer, ByVal DesktopModuleID As Integer, ByVal HostFee As Double)
        Public MustOverride Sub DeletePortalModuleDefinition(ByVal PortalID As Integer, ByVal DesktopModuleID As Integer)
        Public MustOverride Function GetModuleDefinitions(ByVal DesktopModuleId As Integer) As IDataReader
        Public MustOverride Function GetModuleDefinition(ByVal ModuleDefId As Integer) As IDataReader
        Public MustOverride Function GetModuleDefinitionByName(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String) As IDataReader
        Public MustOverride Function AddModuleDefinition(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String) As Integer
        Public MustOverride Sub DeleteModuleDefinition(ByVal ModuleDefId As Integer)
        Public MustOverride Function GetModuleControl(ByVal ModuleControlId As Integer) As IDataReader
        Public MustOverride Function GetModuleControls(ByVal ModuleDefID As Integer) As IDataReader
        Public MustOverride Function GetModuleControlsByKey(ByVal ControlKey As String, ByVal ModuleDefId As Integer) As IDataReader
        Public MustOverride Function GetModuleControlByKeyAndSrc(ByVal ModuleDefID As Integer, ByVal ControlKey As String, ByVal ControlSrc As String) As IDataReader
        Public MustOverride Function AddModuleControl(ByVal ModuleDefId As Integer, ByVal ControlKey As String, ByVal ControlTitle As String, ByVal ControlSrc As String, ByVal IconFile As String, ByVal ControlType As Integer, ByVal ViewOrder As Integer) As Integer
        Public MustOverride Sub UpdateModuleControl(ByVal ModuleControlId As Integer, ByVal ModuleDefId As Integer, ByVal ControlKey As String, ByVal ControlTitle As String, ByVal ControlSrc As String, ByVal IconFile As String, ByVal ControlType As Integer, ByVal ViewOrder As Integer)
        Public MustOverride Sub DeleteModuleControl(ByVal ModuleControlId As Integer)

        ' files
        Public MustOverride Function GetFiles(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetFile(ByVal FileName As String, ByVal PortalId As Integer) As IDataReader
        Public MustOverride Sub DeleteFile(ByVal FileName As String, ByVal PortalId As Integer)
        Public MustOverride Sub DeleteFiles(ByVal PortalId As Integer)
        Public MustOverride Function AddFile(ByVal PortalId As Integer, ByVal FileName As String, ByVal Extension As String, ByVal Size As String, ByVal Width As String, ByVal Height As String, ByVal ContentType As String) As Integer
        Public MustOverride Sub UpdateFile(ByVal FileId As Integer, ByVal FileName As String, ByVal Extension As String, ByVal Size As String, ByVal Width As String, ByVal Height As String, ByVal ContentType As String)

        ' codes
        Public MustOverride Function GetCountryCodes() As IDataReader
        Public MustOverride Function GetCountry(ByVal Code As String, ByVal Description As String) As IDataReader
        Public MustOverride Function GetRegionCodes(ByVal Country As String) As IDataReader
        Public MustOverride Function GetRegion(ByVal Code As String, ByVal Description As String) As IDataReader
        Public MustOverride Function GetCurrencies() As IDataReader
        Public MustOverride Function GetBillingFrequencyCodes() As IDataReader
        Public MustOverride Function GetBillingFrequencyCode(ByVal Code As String) As IDataReader
        Public MustOverride Function GetProcessorCodes() As IDataReader

        ' clicks
        Public MustOverride Sub UpdateClicks(ByVal TableName As String, ByVal KeyField As String, ByVal ItemId As Integer, ByVal UserId As String)
        Public MustOverride Function GetClicks(ByVal TableName As String, ByVal ItemId As Integer) As IDataReader

        ' site log
        Public MustOverride Sub AddSiteLog(ByVal DateTime As Date, ByVal PortalId As Integer, ByVal UserId As String, ByVal Referrer As String, ByVal URL As String, ByVal UserAgent As String, ByVal UserHostAddress As String, ByVal UserHostName As String, ByVal TabId As Integer, ByVal AffiliateId As Integer)
        Public MustOverride Function GetSiteLogReports() As IDataReader
        Public MustOverride Function GetSiteLog(ByVal PortalId As Integer, ByVal PortalAlias As String, ByVal ReportName As String, ByVal StartDate As Date, ByVal EndDate As Date) As IDataReader
        Public MustOverride Sub DeleteSiteLog(ByVal DateTime As Date, ByVal PortalId As Integer)

        ' database 
        Public MustOverride Function ExecuteSQL(ByVal Script As String) As IDataReader
        Public MustOverride Function ExecuteSQLApp(ByVal Script As String) As IDataReader
        Public MustOverride Function ExecuteSQLAppDataSet(ByVal Script As String) As DataSet
        Public MustOverride Function GetTables() As IDataReader
        Public MustOverride Function GetFields(ByVal TableName As String) As IDataReader

        ' announcements module
        Public MustOverride Function GetAnnouncements(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetAnnouncement(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteAnnouncement(ByVal ItemID As Integer)
        Public MustOverride Function AddAnnouncement(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Title As String, ByVal URL As String, ByVal Syndicate As Boolean, ByVal ExpireDate As Date, ByVal Description As String, ByVal ViewOrder As Integer) As Integer
        Public MustOverride Sub UpdateAnnouncement(ByVal ItemId As Integer, ByVal UserName As String, ByVal Title As String, ByVal URL As String, ByVal Syndicate As Boolean, ByVal ExpireDate As Date, ByVal Description As String, ByVal ViewOrder As Integer)

        ' contacts module
        Public MustOverride Function GetContacts(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetContact(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteContact(ByVal ItemID As Integer)
        Public MustOverride Function AddContact(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Name As String, ByVal Role As String, ByVal Email As String, ByVal Contact1 As String, ByVal Contact2 As String) As Integer
        Public MustOverride Sub UpdateContact(ByVal ItemId As Integer, ByVal UserName As String, ByVal Name As String, ByVal Role As String, ByVal Email As String, ByVal Contact1 As String, ByVal Contact2 As String)

        ' discussions module
        Public MustOverride Function GetTopLevelMessages(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetThreadMessages(ByVal Parent As String) As IDataReader
        Public MustOverride Function GetMessage(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteMessage(ByVal ModuleId As Integer, ByVal Start As Integer, ByVal Parent As String)
        Public MustOverride Function AddMessage(ByVal Title As String, ByVal Body As String, ByVal DisplayOrder As String, ByVal UserName As String, ByVal ModuleId As Integer) As Integer
        Public MustOverride Sub UpdateMessage(ByVal ItemId As Integer, ByVal Title As String, ByVal Body As String, ByVal UserName As String)
        Public MustOverride Function GetMessageByParentId(ByVal ParentId As Integer) As IDataReader

        ' documents module
        Public MustOverride Function GetDocuments(ByVal ModuleId As Integer, ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetDocument(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteDocument(ByVal ItemID As Integer)
        Public MustOverride Function AddDocument(ByVal ModuleId As Integer, ByVal Title As String, ByVal URL As String, ByVal UserName As String, ByVal Category As String, ByVal Syndicate As Boolean) As Integer
        Public MustOverride Sub UpdateDocument(ByVal ItemId As Integer, ByVal Title As String, ByVal URL As String, ByVal UserName As String, ByVal Category As String, ByVal Syndicate As Boolean)

        ' events module
        Public MustOverride Function GetModuleEvents(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetModuleEventsByDate(ByVal ModuleId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As IDataReader
        Public MustOverride Function GetModuleEvent(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteModuleEvent(ByVal ItemID As Integer)
        Public MustOverride Function AddModuleEvent(ByVal ModuleId As Integer, ByVal Description As String, ByVal DateTime As Date, ByVal Title As String, ByVal ExpireDate As Date, ByVal UserName As String, ByVal Every As Integer, ByVal Period As String, ByVal IconFile As String, ByVal AltText As String) As Integer
        Public MustOverride Sub UpdateModuleEvent(ByVal ItemId As Integer, ByVal Description As String, ByVal DateTime As Date, ByVal Title As String, ByVal ExpireDate As Date, ByVal UserName As String, ByVal Every As Integer, ByVal Period As String, ByVal IconFile As String, ByVal AltText As String)

        ' FAQ module
        Public MustOverride Function GetFAQs(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetFAQ(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteFAQ(ByVal ItemID As Integer)
        Public MustOverride Function AddFAQ(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Question As String, ByVal Answer As String) As Integer
        Public MustOverride Sub UpdateFAQ(ByVal ItemId As Integer, ByVal UserName As String, ByVal Question As String, ByVal Answer As String)

        ' HTML module
        Public MustOverride Function GetHtmlText(ByVal moduleId As Integer) As IDataReader
        Public MustOverride Sub AddHtmlText(ByVal moduleId As Integer, ByVal desktopHtml As String, ByVal mobileSummary As String, ByVal mobileDetails As String)
        Public MustOverride Sub UpdateHtmlText(ByVal moduleId As Integer, ByVal desktopHtml As String, ByVal mobileSummary As String, ByVal mobileDetails As String)

        ' links module
        Public MustOverride Function GetLinks(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetLink(ByVal ItemID As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteLink(ByVal ItemID As Integer)
        Public MustOverride Function AddLink(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Title As String, ByVal Url As String, ByVal MobileUrl As String, ByVal ViewOrder As String, ByVal Description As String, ByVal NewWindow As Boolean) As Integer
        Public MustOverride Sub UpdateLink(ByVal ItemId As Integer, ByVal UserName As String, ByVal Title As String, ByVal Url As String, ByVal MobileUrl As String, ByVal ViewOrder As String, ByVal Description As String, ByVal NewWindow As Boolean)

        ' search module
        Public MustOverride Function GetSearchModule(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function AddSearch(ByVal ModuleId As Integer, ByVal TableName As String) As Integer
        Public MustOverride Function GetSearch(ByVal SearchId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub UpdateSearch(ByVal SearchId As Integer, ByVal TitleField As String, ByVal DescriptionField As String, ByVal CreatedDateField As String, ByVal CreatedByUserField As String)
        Public MustOverride Sub DeleteSearch(ByVal SearchId As Integer)
        Public MustOverride Function GetSearchResults(ByVal PortalId As Integer, ByVal TableName As String, ByVal TitleField As String, ByVal DescriptionField As String, ByVal CreatedDateField As String, ByVal CreatedByUserField As String, ByVal Search As String) As IDataReader

        ' security
        Public MustOverride Function UserLogin(ByVal Username As String, ByVal Password As String) As IDataReader
        Public MustOverride Function GetAuthRoles(ByVal PortalId As Integer, ByVal ModuleId As Integer) As IDataReader

        ' user defined table
        Public MustOverride Function GetUserDefinedFields(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetUserDefinedField(ByVal UserDefinedFieldId As Integer) As IDataReader
        Public MustOverride Sub DeleteUserDefinedField(ByVal UserDefinedFieldID As Integer)
        Public MustOverride Function AddUserDefinedField(ByVal ModuleID As Integer, ByVal FieldTitle As String, ByVal Visible As Boolean, ByVal FieldType As String) As Integer
        Public MustOverride Sub UpdateUserDefinedField(ByVal UserDefinedFieldID As Integer, ByVal FieldTitle As String, ByVal Visible As Boolean, ByVal FieldType As String)
        Public MustOverride Sub UpdateUserDefinedFieldOrder(ByVal UserDefinedFieldID As Integer, ByVal FieldOrder As Integer)
        Public MustOverride Function GetUserDefinedRows(ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Function GetUserDefinedRow(ByVal UserDefinedRowId As Integer, ByVal ModuleId As Integer) As IDataReader
        Public MustOverride Sub DeleteUserDefinedRow(ByVal UserDefinedRowID As Integer)
        Public MustOverride Function AddUserDefinedRow(ByVal ModuleId As Integer) As Integer
        Public MustOverride Function GetUserDefinedData(ByVal UserDefinedRowID As Integer, ByVal UserDefinedFieldID As Integer) As IDataReader
        Public MustOverride Sub DeleteUserDefinedData(ByVal UserDefinedRowID As Integer, ByVal UserDefinedFieldID As Integer)
        Public MustOverride Function AddUserDefinedData(ByVal UserDefinedRowID As Integer, ByVal UserDefinedFieldID As Integer, ByVal FieldValue As String) As Integer
        Public MustOverride Sub UpdateUserDefinedData(ByVal UserDefinedRowID As Integer, ByVal UserDefinedFieldID As Integer, ByVal FieldValue As String)

        ' users
        Public MustOverride Function GetDMChucDanh() As DataSet
        Public MustOverride Function GetDMPhongBan() As DataSet

        Public MustOverride Function GetUsers(ByVal PortalId As Integer, ByVal Filter As String) As IDataReader
        Public MustOverride Function GetUsersDataSet(ByVal PortalId As Integer, ByVal Filter As String, Optional ByVal NoiDung As String = "", Optional ByVal HinhThuc As String = "") As DataSet
        Public MustOverride Function GetUser(ByVal PortalId As Integer, ByVal UserId As String) As IDataReader
        Public MustOverride Function GetUserByUsername(ByVal PortalID As Integer, ByVal Username As String) As IDataReader
        Public MustOverride Function AddUser(ByVal FullName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal PostalCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Username As String, ByVal Password As String, ByVal AffiliateId As Integer, ByVal ChucDanh As String, ByVal PhongBan As String) As String
        Public MustOverride Sub DeleteUser(ByVal UserId As String)
        Public MustOverride Sub UpdateUser(ByVal UserId As String, ByVal FullName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal PostalCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Username As String, ByVal Password As String, ByVal ChucDanh As String, ByVal PhongBan As String)
        Public MustOverride Function GetPortalUsers(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetPortalUser(ByVal PortalId As Integer, ByVal UserId As String) As IDataReader
        Public MustOverride Function AddPortalUser(ByVal PortalId As Integer, ByVal UserId As String, ByVal Authorized As Boolean) As Integer
        Public MustOverride Sub DeletePortalUser(ByVal PortalId As Integer, ByVal UserId As String)
        Public MustOverride Sub UpdatePortalUser(ByVal PortalId As Integer, ByVal UserId As String, ByVal Authorized As Boolean, ByVal LastLoginDate As Date)
        Public MustOverride Function GetUserPortals(ByVal UserId As String) As IDataReader
        Public MustOverride Function GetPortalRoles(ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetRole(ByVal RoleID As Integer) As IDataReader
        Public MustOverride Function AddRole(ByVal PortalId As Integer, ByVal RoleName As String, ByVal Description As String, ByVal ServiceFee As Double, ByVal BillingPeriod As String, ByVal BillingFrequency As String, ByVal TrialFee As Double, ByVal TrialPeriod As Integer, ByVal TrialFrequency As String, ByVal IsPublic As Boolean, ByVal AutoAssignment As Boolean) As Integer
        Public MustOverride Sub DeleteRole(ByVal RoleId As Integer)
        Public MustOverride Sub UpdateRole(ByVal RoleId As Integer, ByVal RoleName As String, ByVal Description As String, ByVal ServiceFee As Double, ByVal BillingPeriod As String, ByVal BillingFrequency As String, ByVal TrialFee As Double, ByVal TrialPeriod As Integer, ByVal TrialFrequency As String, ByVal IsPublic As Boolean, ByVal AutoAssignment As Boolean)
        Public MustOverride Function GetRoleMembership(ByVal PortalId As Integer, ByVal RoleId As Integer, ByVal UserId As String) As IDataReader
        Public MustOverride Function IsUserInRole(ByVal UserId As String, ByVal RoleId As Integer, ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetRolesByUser(ByVal UserId As String, ByVal PortalId As Integer) As IDataReader
        Public MustOverride Function GetUserRole(ByVal PortalID As Integer, ByVal UserId As String, ByVal RoleId As Integer) As IDataReader
        Public MustOverride Function AddUserRole(ByVal PortalID As Integer, ByVal UserId As String, ByVal RoleId As Integer, ByVal ExpiryDate As Date) As Integer
        Public MustOverride Sub UpdateUserRole(ByVal UserRoleId As Integer, ByVal ExpiryDate As Date)
        Public MustOverride Sub DeleteUserRole(ByVal UserId As String, ByVal RoleId As Integer)
        Public MustOverride Function GetServices(ByVal PortalId As Integer, ByVal UserId As String) As IDataReader
        Public MustOverride Function ChangePassword(ByVal UserName As String, ByVal OldPassword As String, ByVal NewPassword As String) As IDataReader

        ' vendors
        Public MustOverride Function GetVendors(ByVal PortalId As Integer, ByVal Filter As String) As IDataReader
        Public MustOverride Function GetVendor(ByVal VendorID As Integer) As IDataReader
        Public MustOverride Sub DeleteVendor(ByVal VendorID As Integer)
        Public MustOverride Function AddVendor(ByVal PortalID As Integer, ByVal VendorName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal Country As String, ByVal PostalCode As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, ByVal FirstName As String, ByVal LastName As String, ByVal UserName As String, ByVal LogoFile As String, ByVal KeyWords As String, ByVal Authorized As String) As Integer
        Public MustOverride Sub UpdateVendor(ByVal VendorID As Integer, ByVal VendorName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal Country As String, ByVal PostalCode As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, ByVal FirstName As String, ByVal LastName As String, ByVal UserName As String, ByVal LogoFile As String, ByVal KeyWords As String, ByVal Authorized As String)
        Public MustOverride Function FindBanners(ByVal PortalId As Integer, ByVal BannerTypeId As Integer) As IDataReader
        Public MustOverride Sub UpdateBannerViews(ByVal BannerId As Integer, ByVal Views As Integer, ByVal StartDate As Date, ByVal EndDate As Date)
        Public MustOverride Sub UpdateBannerClickThrough(ByVal BannerId As Integer, ByVal VendorId As Integer)
        Public MustOverride Function GetBanners(ByVal VendorId As Integer) As IDataReader
        Public MustOverride Function GetBanner(ByVal BannerId As Integer, ByVal VendorId As Integer) As IDataReader
        Public MustOverride Sub DeleteBanner(ByVal BannerId As Integer)
        Public MustOverride Function AddBanner(ByVal BannerName As String, ByVal VendorId As Integer, ByVal ImageFile As String, ByVal URL As String, ByVal Impressions As Integer, ByVal CPM As Double, ByVal StartDate As Date, ByVal EndDate As Date, ByVal UserName As String, ByVal BannerTypeId As Integer) As Integer
        Public MustOverride Sub UpdateBanner(ByVal BannerId As Integer, ByVal BannerName As String, ByVal ImageFile As String, ByVal URL As String, ByVal Impressions As Integer, ByVal CPM As Double, ByVal StartDate As Date, ByVal EndDate As Date, ByVal UserName As String, ByVal BannerTypeId As Integer)
        Public MustOverride Function GetBannerTypes() As IDataReader
        Public MustOverride Function GetVendorClassifications(ByVal VendorId As Integer) As IDataReader
        Public MustOverride Sub DeleteVendorClassifications(ByVal VendorId As Integer)
        Public MustOverride Function AddVendorClassification(ByVal VendorId As Integer, ByVal ClassificationId As Integer) As Integer
        Public MustOverride Function GetAffiliates(ByVal VendorId As Integer) As IDataReader
        Public MustOverride Function GetAffiliate(ByVal AffiliateId As Integer, ByVal VendorId As Integer) As IDataReader
        Public MustOverride Sub DeleteAffiliate(ByVal AffiliateId As Integer)
        Public MustOverride Function AddAffiliate(ByVal VendorId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CPC As Double, ByVal CPA As Double) As Integer
        Public MustOverride Sub UpdateAffiliate(ByVal AffiliateId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CPC As Double, ByVal CPA As Double)
        Public MustOverride Sub UpdateAffiliateStats(ByVal AffiliateId As Integer, ByVal Clicks As Integer, ByVal Acquisitions As Integer)

        ' skins/containers
        Public MustOverride Function GetSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabId As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean) As IDataReader
        Public MustOverride Sub DeleteSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabId As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean)
        Public MustOverride Function AddSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabId As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean, ByVal SkinType As String, ByVal SkinName As String, ByVal SkinSrc As String) As Integer

        ' personalization
        Public MustOverride Function GetProfile(ByVal UserId As String, ByVal PortalId As Integer) As IDataReader
        Public MustOverride Sub AddProfile(ByVal UserId As String, ByVal PortalId As Integer)
        Public MustOverride Sub UpdateProfile(ByVal UserId As String, ByVal PortalId As Integer, ByVal ProfileData As String)

        ' users online
        Public MustOverride Sub UpdateUsersOnline(ByVal UserList As Hashtable)
        Public MustOverride Sub DeleteUsersOnline(ByVal TimeWindow As Integer)

        'by AnhLH
        'date May 12, 2004
        '
        'Cac ham dung chung 
        '
        'DanhMuc module
        Public MustOverride Function GetDanhMucCBO(ByVal strTableName As String) As IDataReader
        Public MustOverride Function GetDanhMucList(ByVal strTableName As String, Optional ByVal strSortExpression As String = "", Optional ByVal strFilterExpression As String = "") As DataSet
        Public MustOverride Function GetDanhMuc(ByVal objPage As Object, ByVal strTableName As String, ByVal ParamArray arrParams() As Object) As DataSet
        Public MustOverride Sub DeleteDanhMuc(ByVal objPage As Object, ByVal strTableName As String, ByVal ParamArray arrParams() As Object)
        Public MustOverride Function AddDanhMuc(ByVal objPage As Object, ByVal strTableName As String) As Integer
        Public MustOverride Function SearchDanhMuc(ByVal objPage As Object, ByVal strTableName As String) As DataSet
        Public MustOverride Sub UpdateDanhMuc(ByVal objPage As Object, ByVal strTableName As String)
        Public MustOverride Function GetByID(ByVal strStoreProc As String, ByVal ParamArray ParaValues() As Object) As DataSet
        Public MustOverride Function ExecuteNonQueryStoreProc(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As Integer
        Public MustOverride Function ExecuteQueryStoreProc(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As DataSet
        Public MustOverride Function ExecuteQueryStoreProcReader(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As IDataReader
        Public MustOverride Function ExecuteQueryStoreProcReaderAuto(ByVal strStoreProc As String, ByVal objControl As Object) As IDataReader
        Public MustOverride Function ExecuteNonQueryStoreProcAuTo(ByVal strStoreProc As String, ByVal objControl As Object) As Integer
        Public MustOverride Function ExecuteQueryStoreProcAuTo(ByVal strStoreProc As String, ByVal objControl As Object) As DataSet
        Public MustOverride Function ExecuteScalarAuto(ByVal strStoreProc As String, ByVal objControl As Object) As String
        Public MustOverride Function ExecuteScalarAutoByDBName(ByVal DBName As String, ByVal strStoreProc As String, ByVal objControl As Object) As String
        Public MustOverride Function ExecuteScalar(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As String

        'End Cac ham dung chung

        'Cac ham cua CPKTQH        
        'begin Ngantl
        Public MustOverride Function InsHoSoTiepNhan(ByVal objPage As Object, ByVal sp_name As String) As Integer
        Public MustOverride Function UpdHoSoTiepNhan(ByVal objPage As Object, ByVal sp_name As String) As Integer
        Public MustOverride Function GetHoSoTiepNhan_ChiTiet(ByVal HoSoTiepNhanID As String) As IDataReader
        Public MustOverride Function GetHoSoTiepNhan_HoSoKemTheo(ByVal HoSoTiepNhanID As String) As IDataReader
        Public MustOverride Function GetHoSoTiepNhan_SoNgayQuiDinh(ByVal p_MaLoaiHoSo As String) As IDataReader
        Public MustOverride Function GetHoSoTiepNhanID() As IDataReader
        Public MustOverride Function UpdateTinhTrangHoSo(ByVal MaKhuVuc As String, ByVal TabCode As Integer, _
                                    ByVal HoSoTiepNhanID As String, ByVal MaTinhTrangCurr As String, _
                                    ByVal ThongQua As String, ByVal MaNguoiDen As String, ByVal MaNguoiTacNghiep As String) As Integer


        Public MustOverride Sub DeleteHoSoKemTheo(ByVal HoSoTiepNhanID As String)
        Public MustOverride Function AddHoSoKemTheo(ByVal HoSoTiepNhanId As String, ByVal MaHoSoKemTheo As String, _
                                    ByVal MaKhuVuc As String, ByVal SoHoSo As String) As String

        'Phuocdd: Mar 03 2005
        'Cache
        Public MustOverride Sub ClearCacheParameterSet(ByVal connectionString As String, _
                                        ByVal commandText As String)

    End Class

End Namespace
