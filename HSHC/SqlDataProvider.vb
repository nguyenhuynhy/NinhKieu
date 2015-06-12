Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.IO
Imports System.Web
Imports PortalQH
Imports System.Configuration
Imports System.Web.UI.WebControls
Imports System.Web.UI

Namespace PortalQH.Data

    Public Class SqlDataProvider

        Inherits DataProvider

        Private Const ProviderType As String = "data"
        Private _providerConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType)
        Private _connectionString As String
        Private _connectionStringApp As String
        Private _providerPath As String
        Private _objectQualifier As String
        Private _databaseOwner As String


        Public Sub New()

            ' Read the configuration specific information for this provider
            Dim objProvider As Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Provider)

            ' Read the attributes for this provider
            _connectionString = objProvider.Attributes("connectionString")
            _connectionStringApp = ConfigurationSettings.AppSettings("connectionString" & gPortalID())

            _providerPath = objProvider.Attributes("providerPath")

            _objectQualifier = objProvider.Attributes("objectQualifier")
            If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
                _objectQualifier += "_"
            End If

            _databaseOwner = objProvider.Attributes("databaseOwner")
            If _databaseOwner <> "" And _databaseOwner.EndsWith(".") = False Then
                _databaseOwner += "."
            End If



        End Sub

        Public ReadOnly Property ConnectionString() As String
            Get
                Return _connectionString
            End Get
        End Property
        Public ReadOnly Property ConnectionStringApp() As String
            Get
                Return _connectionStringApp
            End Get
        End Property

        Public ReadOnly Property ProviderPath() As String
            Get
                Return _providerPath
            End Get
        End Property

        Public ReadOnly Property ObjectQualifier() As String
            Get
                Return _objectQualifier
            End Get
        End Property

        Public ReadOnly Property DatabaseOwner() As String
            Get
                Return _databaseOwner
            End Get
        End Property

        ' general
        Private Function GetNull(ByVal Field As Object) As Object
            Return Null.GetNull(Field, DBNull.Value)
        End Function

        ' upgrade
        Public Overrides Function GetProviderPath() As String
            Dim objHttpContext As HttpContext = HttpContext.Current

            GetProviderPath = ProviderPath

            If GetProviderPath <> "" Then
                GetProviderPath = objHttpContext.Server.MapPath(GetProviderPath)

                If Directory.Exists(GetProviderPath) Then
                    ' initialization logic here
                    Dim objStreamReader As StreamReader
                    objStreamReader = File.OpenText(GetProviderPath & "00.00.00." & _providerConfiguration.DefaultProvider)
                    Dim strScript As String = objStreamReader.ReadToEnd
                    objStreamReader.Close()

                    If ExecuteScript(strScript) <> "" Then
                        GetProviderPath = "ERROR: Could not connect to database specified in connectionString for SqlDataProvider"
                    End If
                Else
                    GetProviderPath = "ERROR: providerPath folder " & GetProviderPath & " specified for SqlDataProvider does not exist on web server"
                End If
            Else
                GetProviderPath = "ERROR: providerPath folder value not specified in web.config for SqlDataProvider"
            End If
        End Function
        Public Overloads Overrides Function ExecuteScript(ByVal Script As String) As String
            Return ExecuteScript(Script, False)
        End Function
        Public Overloads Overrides Function ExecuteScript(ByVal Script As String, ByVal UseTransactions As Boolean) As String
            Dim SQL As String
            Dim Exceptions As String = ""
            Dim Delimiter As String = "GO" & ControlChars.CrLf

            Dim arrSQL As String() = Split(Script, Delimiter, , CompareMethod.Text)

            If UseTransactions Then
                Dim Conn As New SqlConnection(ConnectionString)
                Conn.Open()
                Try
                    Dim Trans As SqlTransaction = Conn.BeginTransaction
                    Dim IgnoreErrors As Boolean

                    For Each SQL In arrSQL
                        If Trim(SQL) <> "" Then
                            ' script dynamic substitution
                            SQL = SQL.Replace("{databaseOwner}", DatabaseOwner)
                            SQL = SQL.Replace("{objectQualifier}", ObjectQualifier)

                            IgnoreErrors = False

                            If SQL.Trim.StartsWith("{IgnoreError}") Then
                                IgnoreErrors = True
                                SQL = SQL.Replace("{IgnoreError}", "")
                            End If

                            Try
                                SqlHelper.ExecuteNonQuery(Trans, CommandType.Text, SQL)
                            Catch objException As SqlException
                                If Not IgnoreErrors Then
                                    Exceptions += objException.ToString & vbCrLf & vbCrLf & SQL & vbCrLf & vbCrLf
                                End If
                            End Try
                        End If
                    Next
                    If Exceptions.Length = 0 Then
                        'No exceptions so go ahead and commit
                        Trans.Commit()
                    Else
                        'Found exceptions, so rollback db
                        Trans.Rollback()
                        Exceptions += "SQL Execution failed.  Database was rolled back" & vbCrLf & vbCrLf & SQL & vbCrLf & vbCrLf
                    End If
                Finally
                    Conn.Close()
                End Try
            Else
                For Each SQL In arrSQL
                    If Trim(SQL) <> "" Then
                        ' script dynamic substitution
                        SQL = SQL.Replace("{databaseOwner}", DatabaseOwner)
                        SQL = SQL.Replace("{objectQualifier}", ObjectQualifier)

                        Try
                            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, SQL)
                        Catch objException As SqlException
                            Exceptions += objException.ToString & vbCrLf & vbCrLf & SQL & vbCrLf & vbCrLf
                        End Try
                    End If
                Next
            End If

            Return Exceptions
        End Function
        Private Function FormatSQL(ByVal SQL As String) As String
            If Trim(SQL.Replace(vbCrLf, "")) = "" Then
                SQL = SQL.Replace(vbCrLf, "")
            End If
            Return SQL
        End Function

        Public Overrides Function GetDatabaseVersion() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetDatabaseVersion"), IDataReader)
        End Function
        Public Overrides Sub UpdateDatabaseVersion(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateDatabaseVersion", Major, Minor, Build)
        End Sub
        Public Overrides Function FindDatabaseVersion(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FindDatabaseVersion", Major, Minor, Build), IDataReader)
        End Function
        Public Overrides Sub UpgradeDatabaseSchema(ByVal Major As Integer, ByVal Minor As Integer, ByVal Build As Integer)
            ' not necessary for SQL Server - use database scripts
        End Sub

        ' host
        Public Overrides Function GetHostSettings() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetHostSettings"), IDataReader)
        End Function
        Public Overrides Function GetHostSetting(ByVal SettingName As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetHostSetting", SettingName), IDataReader)
        End Function
        Public Overrides Sub AddHostSetting(ByVal SettingName As String, ByVal SettingValue As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "AddHostSetting", SettingName, SettingValue)
        End Sub
        Public Overrides Sub UpdateHostSetting(ByVal SettingName As String, ByVal SettingValue As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateHostSetting", SettingName, SettingValue)
        End Sub

        ' portal
        Public Overrides Function GetPortalSettings(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalSettings", PortalId), IDataReader)
        End Function
        Public Overrides Function GetPortalByAlias(ByVal PortalAlias As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalByAlias", PortalAlias), IDataReader)
        End Function
        Public Overrides Sub UpdatePortalAlias(ByVal PortalAlias As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdatePortalAlias", PortalAlias)
        End Sub
        Public Overrides Function GetPortalByTab(ByVal TabId As Integer, ByVal PortalAlias As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalByTab", TabId, PortalAlias), IDataReader)
        End Function
        Public Overrides Function AddPortalInfo(ByVal PortalName As String, ByVal PortalAlias As String, ByVal Currency As String, ByVal FullName As String, ByVal Username As String, ByVal Password As String, ByVal Email As String, ByVal ExpiryDate As Date, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal SiteLogHistory As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddPortalInfo", PortalName, PortalAlias, Currency, FullName, Username, Password, Email, GetNull(ExpiryDate), HostFee, HostSpace, GetNull(SiteLogHistory)), Integer)
        End Function
        Public Overrides Sub UpdatePortalInfo(ByVal PortalId As Integer, ByVal PortalName As String, ByVal PortalAlias As String, ByVal LogoFile As String, ByVal FooterText As String, ByVal ExpiryDate As Date, ByVal UserRegistration As Integer, ByVal BannerAdvertising As Integer, ByVal Currency As String, ByVal AdministratorId As Integer, ByVal HostFee As Double, ByVal HostSpace As Double, ByVal PaymentProcessor As String, ByVal ProcessorUserId As String, ByVal ProcessorPassword As String, ByVal Description As String, ByVal KeyWords As String, ByVal BackgroundFile As String, ByVal SiteLogHistory As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdatePortalInfo", PortalId, PortalName, PortalAlias, GetNull(LogoFile), GetNull(FooterText), GetNull(ExpiryDate), UserRegistration, BannerAdvertising, Currency, GetNull(AdministratorId), HostFee, HostSpace, GetNull(PaymentProcessor), GetNull(ProcessorUserId), GetNull(ProcessorPassword), GetNull(Description), GetNull(KeyWords), GetNull(BackgroundFile), GetNull(SiteLogHistory), GetNull(HomeTabId), GetNull(LoginTabId), GetNull(UserTabId))
        End Sub
        Public Overrides Sub UpdatePortalSetup(ByVal PortalId As Integer, ByVal AdministratorId As String, ByVal AdministratorRoleId As Integer, ByVal RegisteredRoleId As Integer, ByVal HomeTabId As Integer, ByVal LoginTabId As Integer, ByVal UserTabId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdatePortalSetup", PortalId, AdministratorId, AdministratorRoleId, RegisteredRoleId, GetNull(HomeTabId), GetNull(LoginTabId), GetNull(UserTabId))
        End Sub
        Public Overrides Sub DeletePortalInfo(ByVal PortalId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeletePortalInfo", PortalId)
        End Sub
        Public Overrides Function GetPortals() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortals"), IDataReader)
        End Function
        Public Overrides Function GetPortal(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortal", PortalId), IDataReader)
        End Function
        Public Overrides Function GetPortalSpaceUsed(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalSpaceUsed", GetNull(PortalId)), IDataReader)
        End Function
        Public Overrides Function VerifyPortalTab(ByVal PortalId As Integer, ByVal TabId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "VerifyPortalTab", PortalId, TabId), IDataReader)
        End Function
        Public Overrides Function VerifyPortal(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "VerifyPortal", PortalId), IDataReader)
        End Function

        ' tab
        Public Overrides Function AddTab(ByVal PortalId As Integer, ByVal TabName As String, ByVal AuthorizedRoles As String, ByVal IsVisible As Boolean, ByVal DisableLink As Boolean, ByVal ParentId As Integer, ByVal IconFile As String, ByVal AdministratorRoles As String, ByVal Title As String, ByVal Description As String, ByVal KeyWords As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddTab", PortalId, TabName, AuthorizedRoles, IsVisible, DisableLink, GetNull(ParentId), IconFile, AdministratorRoles, Title, Description, KeyWords), Integer)
        End Function
        Public Overrides Sub UpdateTab(ByVal TabId As Integer, ByVal TabName As String, ByVal AuthorizedRoles As String, ByVal IsVisible As Boolean, ByVal DisableLink As Boolean, ByVal ParentId As Integer, ByVal IconFile As String, ByVal AdministratorRoles As String, ByVal Title As String, ByVal Description As String, ByVal KeyWords As String, ByVal IsDeleted As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateTab", TabId, TabName, AuthorizedRoles, IsVisible, DisableLink, GetNull(ParentId), IconFile, AdministratorRoles, Title, Description, KeyWords, IsDeleted)
        End Sub
        Public Overrides Sub UpdateTabOrder(ByVal TabId As Integer, ByVal TabOrder As Integer, ByVal Level As Integer, ByVal ParentId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateTabOrder", TabId, TabOrder, Level, GetNull(ParentId))
        End Sub
        Public Overrides Sub DeleteTab(ByVal TabId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteTab", TabId)
        End Sub
        Public Overrides Function GetTabs(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTabs", PortalId), IDataReader)
        End Function
        Public Overrides Function GetTab(ByVal TabId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTab", TabId), IDataReader)
        End Function
        Public Overrides Function GetTabByName(ByVal TabName As String, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTabByName", TabName, GetNull(PortalId)), IDataReader)
        End Function
        Public Overrides Function GetTabsByParentId(ByVal ParentId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTabsByParentId", ParentId), IDataReader)
        End Function
        Public Overrides Function GetTabPanes(ByVal TabId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTabPanes", TabId), IDataReader)
        End Function
        Public Overrides Sub UpdateTabModuleOrder(ByVal TabId As Integer, ByVal PaneName As String, ByVal OldModuleOrder As Integer, ByVal NewModuleOrder As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateTabModuleOrder", TabId, PaneName, OldModuleOrder, NewModuleOrder)
        End Sub
        Public Overrides Function GetPortalTabModules(ByVal PortalId As Integer, ByVal TabId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalTabModules", PortalId, TabId), IDataReader)
        End Function
        Public Overrides Function GetTabModules(ByVal TabId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTabModules", TabId), IDataReader)
        End Function
        Public Overrides Function GetTabModuleOrder(ByVal TabId As Integer, ByVal PaneName As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTabModuleOrder", TabId, PaneName), IDataReader)
        End Function

        ' module
        Public Overrides Function GetModule(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModule", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetModules(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModules", PortalId), IDataReader)
        End Function
        Public Overrides Sub UpdateModuleOrder(ByVal ModuleId As Integer, ByVal ModuleOrder As Integer, ByVal PaneName As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateModuleOrder", ModuleId, ModuleOrder, PaneName)
        End Sub
        Public Overrides Function AddModule(ByVal TabID As Integer, ByVal ModuleDefID As Integer, ByVal ModuleOrder As Integer, ByVal PaneName As String, ByVal ModuleTitle As String, ByVal AuthorizedEditRoles As String, ByVal CacheTime As Integer, ByVal AuthorizedViewRoles As String, ByVal Alignment As String, ByVal Color As String, ByVal Border As String, ByVal IconFile As String, ByVal AllTabs As Boolean, ByVal ShowTitle As Boolean, ByVal Personalize As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddModule", TabID, ModuleDefID, ModuleOrder, PaneName, ModuleTitle, AuthorizedEditRoles, CacheTime, GetNull(AuthorizedViewRoles), GetNull(Alignment), GetNull(Color), GetNull(Border), GetNull(IconFile), AllTabs, ShowTitle, Personalize), Integer)
        End Function
        Public Overrides Sub UpdateModule(ByVal ModuleId As Integer, ByVal ModuleOrder As Integer, ByVal ModuleTitle As String, ByVal Alignment As String, ByVal Color As String, ByVal Border As String, ByVal IconFile As String, ByVal CacheTime As Integer, ByVal AuthorizedViewRoles As String, ByVal AuthorizedEditRoles As String, ByVal TabId As Integer, ByVal AllTabs As Boolean, ByVal ShowTitle As Boolean, ByVal Personalize As Integer, ByVal IsDeleted As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateModule", ModuleId, ModuleOrder, ModuleTitle, Alignment, Color, Border, GetNull(IconFile), CacheTime, AuthorizedViewRoles, AuthorizedEditRoles, TabId, AllTabs, ShowTitle, Personalize, IsDeleted)
        End Sub
        Public Overrides Sub DeleteModule(ByVal ModuleId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteModule", ModuleId)
        End Sub
        Public Overrides Function GetModuleSettings(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleSettings", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleSetting", ModuleId, SettingName), IDataReader)
        End Function
        Public Overrides Sub AddModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String, ByVal SettingValue As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "AddModuleSetting", ModuleId, SettingName, SettingValue)
        End Sub
        Public Overrides Sub UpdateModuleSetting(ByVal ModuleId As Integer, ByVal SettingName As String, ByVal SettingValue As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateModuleSetting", ModuleId, SettingName, SettingValue)
        End Sub
        Public Overrides Function GetSiteModule(ByVal FriendlyName As String, ByVal PortalId As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "GetSiteModule", FriendlyName, GetNull(PortalId)), Integer)
        End Function

        ' module definition
        Public Overrides Function GetDesktopModule(ByVal DesktopModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetDesktopModule", DesktopModuleId), IDataReader)
        End Function
        Public Overrides Function GetDesktopModuleByName(ByVal FriendlyName As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetDesktopModuleByName", FriendlyName), IDataReader)
        End Function
        Public Overrides Function GetDesktopModules() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetDesktopModules"), IDataReader)
        End Function
        Public Overrides Function GetPortalDesktopModules(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalDesktopModules", PortalId), IDataReader)
        End Function
        Public Overrides Function GetPremiumDesktopModules(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPremiumDesktopModules", PortalId), IDataReader)
        End Function
        Public Overrides Function AddDesktopModule(ByVal FriendlyName As String, ByVal Description As String, ByVal Version As String, ByVal IsPremium As Boolean) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddDesktopModule", FriendlyName, GetNull(Description), GetNull(Version), IsPremium), Integer)
        End Function
        Public Overrides Sub UpdateDesktopModule(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String, ByVal Description As String, ByVal Version As String, ByVal IsPremium As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateDesktopModule", DesktopModuleId, FriendlyName, GetNull(Description), GetNull(Version), IsPremium)
        End Sub
        Public Overrides Sub DeleteDesktopModule(ByVal DesktopModuleId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteDesktopModule", DesktopModuleId)
        End Sub
        Public Overrides Function GetPortalModuleDefinition(ByVal PortalId As Integer, ByVal DesktopModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalModuleDefinition", PortalId, DesktopModuleId), IDataReader)
        End Function
        Public Overrides Function AddPortalModuleDefinition(ByVal PortalId As Integer, ByVal DesktopModuleId As Integer, ByVal HostFee As Double) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddPortalModuleDefinition", PortalId, DesktopModuleId, HostFee), Integer)
        End Function
        Public Overrides Sub UpdatePortalModuleDefinition(ByVal PortalId As Integer, ByVal DesktopModuleId As Integer, ByVal HostFee As Double)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdatePortalModuleDefinition", PortalId, DesktopModuleId, HostFee)
        End Sub
        Public Overrides Sub DeletePortalModuleDefinition(ByVal PortalId As Integer, ByVal DesktopModuleId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeletePortalModuleDefinition", PortalId, DesktopModuleId)
        End Sub
        Public Overrides Function GetModuleDefinitions(ByVal DesktopModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleDefinitions", DesktopModuleId), IDataReader)
        End Function
        Public Overrides Function GetModuleDefinition(ByVal ModuleDefId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleDefinition", ModuleDefId), IDataReader)
        End Function
        Public Overrides Function GetModuleDefinitionByName(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleDefinitionByName", DesktopModuleId, FriendlyName), IDataReader)
        End Function
        Public Overrides Function AddModuleDefinition(ByVal DesktopModuleId As Integer, ByVal FriendlyName As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddModuleDefinition", DesktopModuleId, FriendlyName), Integer)
        End Function
        Public Overrides Sub DeleteModuleDefinition(ByVal ModuleDefId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteModuleDefinition", ModuleDefId)
        End Sub
        Public Overrides Function GetModuleControl(ByVal ModuleControlId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleControl", ModuleControlId), IDataReader)
        End Function
        Public Overrides Function GetModuleControls(ByVal ModuleDefId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleControls", GetNull(ModuleDefId)), IDataReader)
        End Function
        Public Overrides Function GetModuleControlsByKey(ByVal ControlKey As String, ByVal ModuleDefId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleControlsByKey", GetNull(ControlKey), GetNull(ModuleDefId)), IDataReader)
        End Function
        Public Overrides Function GetModuleControlByKeyAndSrc(ByVal ModuleDefID As Integer, ByVal ControlKey As String, ByVal ControlSrc As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleControlByKeyAndSrc", GetNull(ModuleDefID), GetNull(ControlKey), GetNull(ControlSrc)), IDataReader)
        End Function
        Public Overrides Function AddModuleControl(ByVal ModuleDefId As Integer, ByVal ControlKey As String, ByVal ControlTitle As String, ByVal ControlSrc As String, ByVal IconFile As String, ByVal ControlType As Integer, ByVal ViewOrder As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddModuleControl", GetNull(ModuleDefId), GetNull(ControlKey), GetNull(ControlTitle), ControlSrc, GetNull(IconFile), ControlType, GetNull(ViewOrder)), Integer)
        End Function
        Public Overrides Sub UpdateModuleControl(ByVal ModuleControlId As Integer, ByVal ModuleDefId As Integer, ByVal ControlKey As String, ByVal ControlTitle As String, ByVal ControlSrc As String, ByVal IconFile As String, ByVal ControlType As Integer, ByVal ViewOrder As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateModuleControl", ModuleControlId, GetNull(ModuleDefId), GetNull(ControlKey), GetNull(ControlTitle), ControlSrc, GetNull(IconFile), ControlType, GetNull(ViewOrder))
        End Sub
        Public Overrides Sub DeleteModuleControl(ByVal ModuleControlId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteModuleControl", ModuleControlId)
        End Sub

        ' files
        Public Overrides Function GetFiles(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetFiles", GetNull(PortalId)), IDataReader)
        End Function
        Public Overrides Function GetFile(ByVal FileName As String, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetFile", FileName, GetNull(PortalId)), IDataReader)
        End Function
        Public Overrides Sub DeleteFile(ByVal FileName As String, ByVal PortalId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteFile", FileName, GetNull(PortalId))
        End Sub
        Public Overrides Sub DeleteFiles(ByVal PortalId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteFiles", GetNull(PortalId))
        End Sub
        Public Overrides Function AddFile(ByVal PortalId As Integer, ByVal FileName As String, ByVal Extension As String, ByVal Size As String, ByVal Width As String, ByVal Height As String, ByVal ContentType As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddFile", GetNull(PortalId), FileName, Extension, Size, GetNull(Width), GetNull(Height), ContentType), Integer)
        End Function
        Public Overrides Sub UpdateFile(ByVal FileId As Integer, ByVal FileName As String, ByVal Extension As String, ByVal Size As String, ByVal Width As String, ByVal Height As String, ByVal ContentType As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateFile", FileId, FileName, Extension, Size, GetNull(Width), GetNull(Height), ContentType)
        End Sub

        ' codes
        Public Overrides Function GetCountryCodes() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetCountryCodes"), IDataReader)
        End Function
        Public Overrides Function GetCountry(ByVal Code As String, ByVal Description As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetCountry", GetNull(Code), GetNull(Description)), IDataReader)
        End Function
        Public Overrides Function GetRegionCodes(ByVal Country As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetRegionCodes", Country), IDataReader)
        End Function
        Public Overrides Function GetRegion(ByVal Code As String, ByVal Description As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetRegion", GetNull(Code), GetNull(Description)), IDataReader)
        End Function
        Public Overrides Function GetCurrencies() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetCurrencies"), IDataReader)
        End Function
        Public Overrides Function GetBillingFrequencyCodes() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetBillingFrequencyCodes"), IDataReader)
        End Function
        Public Overrides Function GetBillingFrequencyCode(ByVal Code As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetBillingFrequencyCode", Code), IDataReader)
        End Function
        Public Overrides Function GetProcessorCodes() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetProcessorCodes"), IDataReader)
        End Function

        ' clicks
        Public Overrides Sub UpdateClicks(ByVal TableName As String, ByVal KeyField As String, ByVal ItemId As Integer, ByVal UserId As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateClicks", ObjectQualifier & TableName, KeyField, ItemId, GetNull(UserId))
        End Sub
        Public Overrides Function GetClicks(ByVal TableName As String, ByVal ItemId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetClicks", TableName, ItemId), IDataReader)
        End Function

        ' site log
        Public Overrides Sub AddSiteLog(ByVal DateTime As Date, ByVal PortalId As Integer, ByVal UserId As String, ByVal Referrer As String, ByVal URL As String, ByVal UserAgent As String, ByVal UserHostAddress As String, ByVal UserHostName As String, ByVal TabId As Integer, ByVal AffiliateId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "AddSiteLog", DateTime, PortalId, GetNull(UserId), GetNull(Referrer), GetNull(URL), GetNull(UserAgent), GetNull(UserHostAddress), GetNull(UserHostName), GetNull(TabId), GetNull(AffiliateId))
        End Sub
        Public Overrides Function GetSiteLog(ByVal PortalId As Integer, ByVal PortalAlias As String, ByVal ReportName As String, ByVal StartDate As Date, ByVal EndDate As Date) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & ReportName, PortalId, PortalAlias, StartDate, EndDate), IDataReader)
        End Function
        Public Overrides Function GetSiteLogReports() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetSiteLogReports"), IDataReader)
        End Function
        Public Overrides Sub DeleteSiteLog(ByVal DateTime As Date, ByVal PortalId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteSiteLog", DateTime, PortalId)
        End Sub

        ' database
        Public Overrides Function ExecuteSQL(ByVal SQL As String) As IDataReader
            SQL = SQL.Replace("{databaseOwner}", DatabaseOwner)
            SQL = SQL.Replace("{objectQualifier}", ObjectQualifier)
            Try
                Return CType(SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, SQL), IDataReader)
            Catch
                ' error in SQL query
                Return Nothing
            End Try
        End Function
        Public Overrides Function GetTables() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTables"), IDataReader)
        End Function
        Public Overrides Function GetFields(ByVal TableName As String) As IDataReader
            Dim SQL As String = "SELECT * FROM {objectQualifier}" & TableName & " WHERE 1 = 0"
            Return ExecuteSQL(SQL)
        End Function

        ' announcements module
        Public Overrides Function GetAnnouncements(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetAnnouncements", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetAnnouncement(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetAnnouncement", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteAnnouncement(ByVal ItemId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteAnnouncement", ItemId)
        End Sub
        Public Overrides Function AddAnnouncement(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Title As String, ByVal URL As String, ByVal Syndicate As Boolean, ByVal ExpireDate As Date, ByVal Description As String, ByVal ViewOrder As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddAnnouncement", ModuleId, UserName, Title, URL, Syndicate, GetNull(ExpireDate), Description, GetNull(ViewOrder)), Integer)
        End Function
        Public Overrides Sub UpdateAnnouncement(ByVal ItemId As Integer, ByVal UserName As String, ByVal Title As String, ByVal URL As String, ByVal Syndicate As Boolean, ByVal ExpireDate As Date, ByVal Description As String, ByVal ViewOrder As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateAnnouncement", ItemId, UserName, Title, URL, Syndicate, GetNull(ExpireDate), Description, GetNull(ViewOrder))
        End Sub

        ' contacts module
        Public Overrides Function GetContacts(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetContacts", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetContact(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetContact", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteContact(ByVal ItemId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteContact", ItemId)
        End Sub
        Public Overrides Function AddContact(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Name As String, ByVal Role As String, ByVal Email As String, ByVal Contact1 As String, ByVal Contact2 As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddContact", ModuleId, UserName, Name, Role, Email, Contact1, Contact2), Integer)
        End Function
        Public Overrides Sub UpdateContact(ByVal ItemId As Integer, ByVal UserName As String, ByVal Name As String, ByVal Role As String, ByVal Email As String, ByVal Contact1 As String, ByVal Contact2 As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateContact", ItemId, UserName, Name, Role, Email, Contact1, Contact2)
        End Sub

        ' discussions module
        Public Overrides Function GetTopLevelMessages(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetTopLevelMessages", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetThreadMessages(ByVal Parent As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetThreadMessages", Parent), IDataReader)
        End Function
        Public Overrides Function GetMessage(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetMessage", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteMessage(ByVal ModuleId As Integer, ByVal Start As Integer, ByVal Parent As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteMessage", ModuleId, Start, Parent)
        End Sub
        Public Overrides Function AddMessage(ByVal Title As String, ByVal Body As String, ByVal DisplayOrder As String, ByVal UserName As String, ByVal ModuleId As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddMessage", Title, Body, DisplayOrder, UserName, ModuleId), Integer)
        End Function
        Public Overrides Sub UpdateMessage(ByVal ItemId As Integer, ByVal Title As String, ByVal Body As String, ByVal UserName As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateMessage", ItemId, Title, Body, UserName)
        End Sub
        Public Overrides Function GetMessageByParentId(ByVal ParentId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetMessageByParentId", ParentId), IDataReader)
        End Function

        ' documents module
        Public Overrides Function GetDocuments(ByVal ModuleId As Integer, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetDocuments", ModuleId, PortalId), IDataReader)
        End Function
        Public Overrides Function GetDocument(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetDocument", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteDocument(ByVal ItemId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteDocument", ItemId)
        End Sub
        Public Overrides Function AddDocument(ByVal ModuleId As Integer, ByVal Title As String, ByVal URL As String, ByVal UserName As String, ByVal Category As String, ByVal Syndicate As Boolean) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddDocument", ModuleId, Title, URL, UserName, Category, Syndicate), Integer)
        End Function
        Public Overrides Sub UpdateDocument(ByVal ItemId As Integer, ByVal Title As String, ByVal URL As String, ByVal UserName As String, ByVal Category As String, ByVal Syndicate As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateDocument", ItemId, Title, URL, UserName, Category, Syndicate)
        End Sub

        ' events module
        Public Overrides Function GetModuleEvents(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleEvents", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetModuleEventsByDate(ByVal ModuleId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleEventsByDate", ModuleId, StartDate, EndDate), IDataReader)
        End Function
        Public Overrides Function GetModuleEvent(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetModuleEvent", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteModuleEvent(ByVal ItemId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteModuleEvent", ItemId)
        End Sub
        Public Overrides Function AddModuleEvent(ByVal ModuleId As Integer, ByVal Description As String, ByVal DateTime As Date, ByVal Title As String, ByVal ExpireDate As Date, ByVal UserName As String, ByVal Every As Integer, ByVal Period As String, ByVal IconFile As String, ByVal AltText As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddModuleEvent", ModuleId, Description, DateTime, Title, GetNull(ExpireDate), UserName, GetNull(Every), GetNull(Period), GetNull(IconFile), GetNull(AltText)), Integer)
        End Function
        Public Overrides Sub UpdateModuleEvent(ByVal ItemId As Integer, ByVal Description As String, ByVal DateTime As Date, ByVal Title As String, ByVal ExpireDate As Date, ByVal UserName As String, ByVal Every As Integer, ByVal Period As String, ByVal IconFile As String, ByVal AltText As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateModuleEvent", ItemId, Description, DateTime, Title, GetNull(ExpireDate), UserName, GetNull(Every), GetNull(Period), GetNull(IconFile), GetNull(AltText))
        End Sub

        ' FAQ module
        Public Overrides Function GetFAQs(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetFAQs", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetFAQ(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetFAQ", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteFAQ(ByVal ItemId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteFAQ", ItemId)
        End Sub
        Public Overrides Function AddFAQ(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Question As String, ByVal Answer As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddFAQ", ModuleId, UserName, Question, Answer), Integer)
        End Function
        Public Overrides Sub UpdateFAQ(ByVal ItemId As Integer, ByVal UserName As String, ByVal Question As String, ByVal Answer As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateFAQ", ItemId, UserName, Question, Answer)
        End Sub

        ' HTML module
        Public Overrides Function GetHtmlText(ByVal moduleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetHtmlText", moduleId), IDataReader)
        End Function
        Public Overrides Sub AddHtmlText(ByVal moduleId As Integer, ByVal desktopHtml As String, ByVal mobileSummary As String, ByVal mobileDetails As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "AddHtmlText", moduleId, desktopHtml, mobileSummary, mobileDetails)
        End Sub
        Public Overrides Sub UpdateHtmlText(ByVal moduleId As Integer, ByVal desktopHtml As String, ByVal mobileSummary As String, ByVal mobileDetails As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateHtmlText", moduleId, desktopHtml, mobileSummary, mobileDetails)
        End Sub

        ' links module
        Public Overrides Function GetLinks(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetLinks", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetLink(ByVal ItemId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetLink", ItemId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteLink(ByVal ItemId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteLink", ItemId)
        End Sub
        Public Overrides Function AddLink(ByVal ModuleId As Integer, ByVal UserName As String, ByVal Title As String, ByVal Url As String, ByVal MobileUrl As String, ByVal ViewOrder As String, ByVal Description As String, ByVal NewWindow As Boolean) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddLink", ModuleId, UserName, Title, Url, MobileUrl, GetNull(ViewOrder), Description, NewWindow), Integer)
        End Function
        Public Overrides Sub UpdateLink(ByVal ItemId As Integer, ByVal UserName As String, ByVal Title As String, ByVal Url As String, ByVal MobileUrl As String, ByVal ViewOrder As String, ByVal Description As String, ByVal NewWindow As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateLink", ItemId, UserName, Title, Url, MobileUrl, GetNull(ViewOrder), Description, NewWindow)
        End Sub

        ' search module
        Public Overrides Function GetSearchModule(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetSearch", ModuleId), IDataReader)
        End Function
        Public Overrides Function AddSearch(ByVal ModuleId As Integer, ByVal TableName As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddSearch", ModuleId, TableName), Integer)
        End Function
        Public Overrides Function GetSearch(ByVal SearchId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetSearch", SearchId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub UpdateSearch(ByVal SearchId As Integer, ByVal TitleField As String, ByVal DescriptionField As String, ByVal CreatedDateField As String, ByVal CreatedByUserField As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateSearch", SearchId, TitleField, DescriptionField, CreatedDateField, CreatedByUserField)
        End Sub
        Public Overrides Sub DeleteSearch(ByVal SearchId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteSearch", SearchId)
        End Sub
        Public Overrides Function GetSearchResults(ByVal PortalId As Integer, ByVal TableName As String, ByVal TitleField As String, ByVal DescriptionField As String, ByVal CreatedDateField As String, ByVal CreatedByUserField As String, ByVal Search As String) As IDataReader
            Dim SQL As String
            If PortalId = -1 Then
                SQL = "select {objectQualifier}Tabs.TabId, {objectQualifier}Tabs.TabName, {objectQualifier}Tabs.AuthorizedRoles, {objectQualifier}Modules.ModuleId, {objectQualifier}Modules.ModuleTitle, {objectQualifier}Modules.AuthorizedViewRoles, NULL AS TitleField, NULL AS DescriptionField, NULL AS CreatedDateField, NULL AS CreatedByUserField "
                SQL += "from {objectQualifier}Modules "
                SQL += "inner join {objectQualifier}Tabs on {objectQualifier}Modules.TabId = {objectQualifier}Tabs.TabId "
                SQL += "where 1 = 0;"
            Else
                SQL = "select {objectQualifier}Tabs.TabId, {objectQualifier}Tabs.TabName, {objectQualifier}Tabs.AuthorizedRoles, "
                SQL += "{objectQualifier}Modules.ModuleId, {objectQualifier}Modules.ModuleTitle, {objectQualifier}Modules.AuthorizedViewRoles, "
                SQL += String.Concat(IIf(TitleField = "", "NULL", TitleField), " AS TitleField, ")
                SQL += String.Concat(IIf(DescriptionField = "", "NULL", DescriptionField), " AS DescriptionField, ")
                SQL += String.Concat(IIf(CreatedDateField = "", "NULL", CreatedDateField), " AS CreatedDateField, ")
                If CreatedByUserField <> "" Then
                    SQL += "{objectQualifier}Users.FirstName + ' ' + {objectQualifier}Users.LastName AS CreatedByUserField"
                Else
                    SQL += "NULL AS CreatedByUserField"
                End If
                SQL += "from {objectQualifier}" & TableName & " "
                SQL += "inner join {objectQualifier}Modules on {objectQualifier}" & TableName & ".ModuleId = {objectQualifier}Modules.ModuleId "
                SQL += "inner join {objectQualifier}Tabs on {objectQualifier}Modules.TabId = {objectQualifier}Tabs.TabId "
                If CreatedByUserField <> "" Then
                    SQL += "left outer join {objectQualifier}Users on {objectQualifier}" & TableName & "." & CreatedByUserField & " = {objectQualifier}Users.UserId "
                End If
                SQL += "where {objectQualifier}Tabs.PortalId = " & PortalId & " and ( "
                SQL += String.Concat(IIf(TitleField = "", "''", TitleField), " like '%" & Search & "%' or ")
                SQL += String.Concat(IIf(DescriptionField = "", "''", DescriptionField), " like '%" & Search & "%' )")
            End If
            Return ExecuteSQL(SQL)
        End Function

        ' security
        Public Overrides Function UserLogin(ByVal Username As String, ByVal Password As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "UserLogin", Username, Password), IDataReader)
        End Function
        Public Overrides Function ChangePassword(ByVal Username As String, ByVal OldPassword As String, ByVal NewPassword As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "ChangePassword", Username, OldPassword, NewPassword), IDataReader)
        End Function
        Public Overrides Function GetAuthRoles(ByVal PortalId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetAuthRoles", PortalId, ModuleId), IDataReader)
        End Function

        ' user defined table
        Public Overrides Function GetUserDefinedFields(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserDefinedFields", ModuleId), IDataReader)
        End Function
        Public Overrides Function GetUserDefinedField(ByVal UserDefinedFieldId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserDefinedField", UserDefinedFieldId), IDataReader)
        End Function
        Public Overrides Function GetUserDefinedRow(ByVal UserDefinedRowId As Integer, ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserDefinedRow", UserDefinedRowId, ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteUserDefinedField(ByVal UserDefinedFieldId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteUserDefinedField", UserDefinedFieldId)
        End Sub
        Public Overrides Function AddUserDefinedField(ByVal ModuleId As Integer, ByVal FieldTitle As String, ByVal Visible As Boolean, ByVal FieldType As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddUserDefinedField", ModuleId, FieldTitle, Visible, FieldType), Integer)
        End Function
        Public Overrides Sub UpdateUserDefinedField(ByVal UserDefinedFieldId As Integer, ByVal FieldTitle As String, ByVal Visible As Boolean, ByVal FieldType As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateUserDefinedField", UserDefinedFieldId, FieldTitle, Visible, FieldType)
        End Sub
        Public Overrides Function GetUserDefinedRows(ByVal ModuleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserDefinedRows", ModuleId), IDataReader)
        End Function
        Public Overrides Sub DeleteUserDefinedRow(ByVal UserDefinedRowId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteUserDefinedRow", UserDefinedRowId)
        End Sub
        Public Overrides Function AddUserDefinedRow(ByVal ModuleId As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddUserDefinedRow", ModuleId), Integer)
        End Function
        Public Overrides Function GetUserDefinedData(ByVal UserDefinedRowId As Integer, ByVal UserDefinedFieldId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserDefinedData", UserDefinedRowId, UserDefinedFieldId), IDataReader)
        End Function
        Public Overrides Function AddUserDefinedData(ByVal UserDefinedRowId As Integer, ByVal UserDefinedFieldId As Integer, ByVal FieldValue As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddUserDefinedData", UserDefinedRowId, UserDefinedFieldId, FieldValue), Integer)
        End Function
        Public Overrides Sub UpdateUserDefinedData(ByVal UserDefinedRowId As Integer, ByVal UserDefinedFieldId As Integer, ByVal FieldValue As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateUserDefinedData", UserDefinedRowId, UserDefinedFieldId, GetNull(FieldValue))
        End Sub
        Public Overrides Sub UpdateUserDefinedFieldOrder(ByVal UserDefinedFieldId As Integer, ByVal FieldOrder As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateUserDefinedFieldOrder", UserDefinedFieldId, FieldOrder)
        End Sub
        Public Overrides Sub DeleteUserDefinedData(ByVal UserDefinedRowId As Integer, ByVal UserDefinedFieldId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteUserDefinedData", UserDefinedRowId, UserDefinedFieldId)
        End Sub

        ' users
        Public Overrides Function AddUser(ByVal FullName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal PostalCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Username As String, ByVal Password As String, ByVal AffiliateId As Integer) As String
            Try
                Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddUser", FullName, Unit, Street, City, Region, PostalCode, Country, Telephone, Email, Username, Password, GetNull(AffiliateId)), String)
            Catch ' duplicate
                Return ""
            End Try
        End Function
        Public Overrides Function AddPortalUser(ByVal PortalId As Integer, ByVal UserId As String, ByVal Authorized As Boolean) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddPortalUser", PortalId, UserId, IIf(Authorized, 1, 0)), Integer)
        End Function
        Public Overrides Sub DeletePortalUser(ByVal PortalId As Integer, ByVal UserId As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeletePortalUser", PortalId, UserId)
        End Sub
        Public Overrides Sub UpdatePortalUser(ByVal PortalId As Integer, ByVal UserId As String, ByVal Authorized As Boolean, ByVal LastLoginDate As Date)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdatePortalUser", PortalId, UserId, IIf(Authorized, 1, 0), GetNull(LastLoginDate))
        End Sub
        Public Overrides Sub DeleteUser(ByVal UserId As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteUser", UserId)
        End Sub
        Public Overrides Sub UpdateUser(ByVal UserId As String, ByVal FullName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal PostalCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Username As String, ByVal Password As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateUser", UserId, FullName, Unit, Street, City, Region, PostalCode, Country, Telephone, Email, Username, GetNull(Password))
        End Sub
        Public Overrides Function GetUser(ByVal PortalId As Integer, ByVal UserId As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUser", PortalId, UserId), IDataReader)
        End Function
        Public Overrides Function GetUserByUsername(ByVal PortalId As Integer, ByVal Username As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserByUsername", GetNull(PortalId), Username), IDataReader)
        End Function
        Public Overrides Function GetRolesByUser(ByVal UserId As String, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetRolesByUser", UserId, PortalId), IDataReader)
        End Function
        Public Overrides Function GetPortalRoles(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalRoles", PortalId), IDataReader)
        End Function
        Public Overrides Function GetRole(ByVal RoleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetRole", RoleId), IDataReader)
        End Function
        Public Overrides Function AddRole(ByVal PortalId As Integer, ByVal RoleName As String, ByVal Description As String, ByVal ServiceFee As Double, ByVal BillingPeriod As String, ByVal BillingFrequency As String, ByVal TrialFee As Double, ByVal TrialPeriod As Integer, ByVal TrialFrequency As String, ByVal IsPublic As Boolean, ByVal AutoAssignment As Boolean) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddRole", PortalId, RoleName, Description, ServiceFee, BillingPeriod, GetNull(BillingFrequency), TrialFee, TrialPeriod, GetNull(TrialFrequency), IsPublic, AutoAssignment), Integer)
        End Function
        Public Overrides Sub DeleteRole(ByVal RoleId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteRole", RoleId)
        End Sub
        Public Overrides Sub UpdateRole(ByVal RoleId As Integer, ByVal RoleName As String, ByVal Description As String, ByVal ServiceFee As Double, ByVal BillingPeriod As String, ByVal BillingFrequency As String, ByVal TrialFee As Double, ByVal TrialPeriod As Integer, ByVal TrialFrequency As String, ByVal IsPublic As Boolean, ByVal AutoAssignment As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateRole", RoleId, RoleName, Description, ServiceFee, BillingPeriod, GetNull(BillingFrequency), TrialFee, TrialPeriod, GetNull(TrialFrequency), IsPublic, AutoAssignment)
        End Sub
        Public Overrides Function GetRoleMembership(ByVal PortalId As Integer, ByVal RoleId As Integer, ByVal UserId As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetRoleMembership", PortalId, GetNull(RoleId), GetNull(UserId)), IDataReader)
        End Function
        Public Overrides Function IsUserInRole(ByVal UserId As String, ByVal RoleId As Integer, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "IsUserInRole", UserId, RoleId, PortalId), IDataReader)
        End Function
        Public Overrides Function GetUserRole(ByVal PortalId As Integer, ByVal UserId As String, ByVal RoleId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserRole", PortalId, UserId, RoleId), IDataReader)
        End Function
        Public Overrides Function AddUserRole(ByVal PortalId As Integer, ByVal UserId As String, ByVal RoleId As Integer, ByVal ExpiryDate As Date) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddUserRole", PortalId, UserId, RoleId, GetNull(ExpiryDate)), Integer)
        End Function
        Public Overrides Sub UpdateUserRole(ByVal UserRoleId As Integer, ByVal ExpiryDate As Date)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateUserRole", UserRoleId, GetNull(ExpiryDate))
        End Sub
        Public Overrides Sub DeleteUserRole(ByVal UserId As String, ByVal RoleId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteUserRole", UserId, RoleId)
        End Sub
        Public Overrides Function GetServices(ByVal PortalId As Integer, ByVal UserId As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetServices", PortalId, GetNull(UserId)), IDataReader)
        End Function
        Public Overrides Function GetUsers(ByVal PortalId As Integer, ByVal Filter As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUsers", GetNull(PortalId), Filter), IDataReader)
        End Function
        Public Overrides Function GetUsersDataSet(ByVal PortalId As Integer, ByVal Filter As String) As DataSet
            Return CType(SqlHelper.ExecuteDataset(ConnectionString, DatabaseOwner & ObjectQualifier & "sp_GetUsers", GetNull(PortalId), Filter), DataSet)
        End Function
        Public Overrides Function GetPortalUsers(ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalUsers", PortalId), IDataReader)
        End Function
        Public Overrides Function GetPortalUser(ByVal PortalId As Integer, ByVal UserId As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetPortalUser", PortalId, UserId), IDataReader)
        End Function
        Public Overrides Function GetUserPortals(ByVal UserId As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetUserPortals", UserId), IDataReader)
        End Function

        ' vendors
        Public Overrides Function GetVendors(ByVal PortalId As Integer, ByVal Filter As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetVendors", GetNull(PortalId), Filter), IDataReader)
        End Function
        Public Overrides Function GetVendor(ByVal VendorId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetVendor", VendorId), IDataReader)
        End Function
        Public Overrides Sub DeleteVendor(ByVal VendorId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteVendor", VendorId)
        End Sub
        Public Overrides Function AddVendor(ByVal PortalId As Integer, ByVal VendorName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal Country As String, ByVal PostalCode As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, ByVal FirstName As String, ByVal LastName As String, ByVal UserName As String, ByVal LogoFile As String, ByVal KeyWords As String, ByVal Authorized As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddVendor", GetNull(PortalId), VendorName, Unit, Street, City, Region, Country, PostalCode, Telephone, Fax, Email, Website, FirstName, LastName, UserName, LogoFile, KeyWords, Boolean.Parse(Authorized)), Integer)
        End Function
        Public Overrides Sub UpdateVendor(ByVal VendorId As Integer, ByVal VendorName As String, ByVal Unit As String, ByVal Street As String, ByVal City As String, ByVal Region As String, ByVal Country As String, ByVal PostalCode As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, ByVal FirstName As String, ByVal LastName As String, ByVal UserName As String, ByVal LogoFile As String, ByVal KeyWords As String, ByVal Authorized As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateVendor", VendorId, VendorName, Unit, Street, City, Region, Country, PostalCode, Telephone, Fax, Email, Website, FirstName, LastName, UserName, LogoFile, KeyWords, Boolean.Parse(Authorized))
        End Sub
        Public Overrides Function FindBanners(ByVal PortalId As Integer, ByVal BannerTypeId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "FindBanners", GetNull(PortalId), BannerTypeId), IDataReader)
        End Function
        Public Overrides Sub UpdateBannerViews(ByVal BannerId As Integer, ByVal Views As Integer, ByVal StartDate As Date, ByVal EndDate As Date)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateBannerViews", BannerId, Views, GetNull(StartDate), GetNull(EndDate))
        End Sub
        Public Overrides Sub UpdateBannerClickThrough(ByVal BannerId As Integer, ByVal VendorId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateBannerClickThrough", BannerId, VendorId)
        End Sub
        Public Overrides Function GetBanners(ByVal VendorId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetBanners", VendorId), IDataReader)
        End Function
        Public Overrides Function GetBanner(ByVal BannerId As Integer, ByVal VendorId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetBanner", BannerId, VendorId), IDataReader)
        End Function
        Public Overrides Sub DeleteBanner(ByVal BannerId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteBanner", BannerId)
        End Sub
        Public Overrides Function AddBanner(ByVal BannerName As String, ByVal VendorId As Integer, ByVal ImageFile As String, ByVal URL As String, ByVal Impressions As Integer, ByVal CPM As Double, ByVal StartDate As Date, ByVal EndDate As Date, ByVal UserName As String, ByVal BannerTypeId As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddBanner", BannerName, VendorId, ImageFile, GetNull(URL), Impressions, CPM, GetNull(StartDate), GetNull(EndDate), UserName, BannerTypeId), Integer)
        End Function
        Public Overrides Sub UpdateBanner(ByVal BannerId As Integer, ByVal BannerName As String, ByVal ImageFile As String, ByVal URL As String, ByVal Impressions As Integer, ByVal CPM As Double, ByVal StartDate As Date, ByVal EndDate As Date, ByVal UserName As String, ByVal BannerTypeId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateBanner", BannerId, BannerName, ImageFile, GetNull(URL), Impressions, CPM, GetNull(StartDate), GetNull(EndDate), UserName, BannerTypeId)
        End Sub
        Public Overrides Function GetBannerTypes() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetBannerTypes"), IDataReader)
        End Function
        Public Overrides Function GetVendorClassifications(ByVal VendorId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetVendorClassifications", GetNull(VendorId)), IDataReader)
        End Function
        Public Overrides Sub DeleteVendorClassifications(ByVal VendorId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteVendorClassifications", VendorId)
        End Sub
        Public Overrides Function AddVendorClassification(ByVal VendorId As Integer, ByVal ClassificationId As Integer) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddVendorClassification", VendorId, ClassificationId), Integer)
        End Function
        Public Overrides Function GetAffiliates(ByVal VendorId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetAffiliates", VendorId), IDataReader)
        End Function
        Public Overrides Function GetAffiliate(ByVal AffiliateId As Integer, ByVal VendorId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetAffiliate", AffiliateId, VendorId), IDataReader)
        End Function
        Public Overrides Sub DeleteAffiliate(ByVal AffiliateId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteAffiliate", AffiliateId)
        End Sub
        Public Overrides Function AddAffiliate(ByVal VendorId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CPC As Double, ByVal CPA As Double) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddAffiliate", VendorId, GetNull(StartDate), GetNull(EndDate), CPC, CPA), Integer)
        End Function
        Public Overrides Sub UpdateAffiliate(ByVal AffiliateId As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CPC As Double, ByVal CPA As Double)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateAffiliate", AffiliateId, GetNull(StartDate), GetNull(EndDate), CPC, CPA)
        End Sub
        Public Overrides Sub UpdateAffiliateStats(ByVal AffiliateId As Integer, ByVal Clicks As Integer, ByVal Acquisitions As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateAffiliateStats", AffiliateId, Clicks, Acquisitions)
        End Sub

        ' skins/containers
        Public Overrides Function GetSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabId As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetSkin", SkinRoot, GetNull(PortalId), GetNull(TabId), GetNull(ModuleId), IsAdmin), IDataReader)
        End Function
        Public Overrides Sub DeleteSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabId As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteSkin", SkinRoot, GetNull(PortalId), GetNull(TabId), GetNull(ModuleId), IsAdmin)
        End Sub
        Public Overrides Function AddSkin(ByVal SkinRoot As String, ByVal PortalId As Integer, ByVal TabId As Integer, ByVal ModuleId As Integer, ByVal IsAdmin As Boolean, ByVal SkinType As String, ByVal SkinName As String, ByVal SkinSrc As String) As Integer
            Return CType(SqlHelper.ExecuteScalar(ConnectionString, DatabaseOwner & ObjectQualifier & "AddSkin", SkinRoot, GetNull(PortalId), GetNull(TabId), GetNull(ModuleId), IsAdmin, SkinType, SkinName, SkinSrc), Integer)
        End Function

        ' personalization
        Public Overrides Function GetProfile(ByVal UserId As String, ByVal PortalId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionString, DatabaseOwner & ObjectQualifier & "GetProfile", UserId, PortalId), IDataReader)
        End Function
        Public Overrides Sub AddProfile(ByVal UserId As String, ByVal PortalId As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "AddProfile", UserId, PortalId)
        End Sub
        Public Overrides Sub UpdateProfile(ByVal UserId As String, ByVal PortalId As Integer, ByVal ProfileData As String)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateProfile", UserId, PortalId, ProfileData)
        End Sub

        ' users online
        Public Overrides Sub UpdateUsersOnline(ByVal UserList As Hashtable)

            If (UserList.Count = 0) Then
                'No users to process, quit method
                Return
            End If
            For Each key As String In UserList.Keys
                If TypeOf UserList(key) Is AnonymousUserInfo Then
                    Dim user As AnonymousUserInfo = CType(UserList(key), AnonymousUserInfo)
                    SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateAnonymousUser", user.UserID, user.PortalID, user.TabID, user.LastActiveDate)
                ElseIf TypeOf UserList(key) Is OnlineUserInfo Then
                    Dim user As OnlineUserInfo = CType(UserList(key), OnlineUserInfo)
                    SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "UpdateOnlineUser", user.UserID, user.PortalID, user.TabID, user.LastActiveDate)
                End If
            Next

        End Sub
        Public Overrides Sub DeleteUsersOnline(ByVal TimeWindow As Integer)
            SqlHelper.ExecuteNonQuery(ConnectionString, DatabaseOwner & ObjectQualifier & "DeleteUsersOnline", TimeWindow)
        End Sub

        'by AnhLH
        'date May 12, 2004
        '
        ' danhmuc module

        Public Overrides Function GetDanhMucList(ByVal strTableName As String, Optional ByVal strSortExpresion As String = "") As DataSet
            Return CType(SqlHelper.ExecuteDataset(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_GetDanhMucComList", GetCommonDB, strTableName, strSortExpresion), DataSet)
        End Function
        Public Overrides Function GetDanhMuc(ByVal objPage As Object, ByVal strTableName As String, ByVal ParamArray arrParams() As Object) As DataSet
            If arrParams.Length = 0 Then
                Dim paraValues() As Object
                GetParamArray("sp_GetByID" & strTableName, objPage, paraValues)
                Return CType(SqlHelper.ExecuteDataset(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_GetByID" & strTableName, paraValues), DataSet)
            Else
                Return CType(SqlHelper.ExecuteDataset(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_GetByID" & strTableName, arrParams), DataSet)
            End If
        End Function
        Public Overrides Sub DeleteDanhMuc(ByVal objPage As Object, ByVal strTableName As String, ByVal ParamArray arrParams() As Object)
            If arrParams.Length = 0 Then
                Dim paraValues() As Object
                GetParamArray("sp_Del" & strTableName, objPage, paraValues)
                SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_Del" & strTableName, paraValues)
            Else
                SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_Del" & strTableName, arrParams)
            End If
        End Sub

        Public Overrides Function AddDanhMuc(ByVal objPage As Object, ByVal strTableName As String) As Integer
            Dim paraValues() As Object
            GetParamArray("sp_Ins" & strTableName, objPage, paraValues)
            'Return CType(SqlHelper.ExecuteScalar(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_Ins" & strTableName, paraValues), Integer)
            SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_Ins" & strTableName, paraValues)
        End Function
        Public Overrides Sub UpdateDanhMuc(ByVal objPage As Object, ByVal strTableName As String)
            Dim paraValues() As Object
            GetParamArray("sp_Upd" & strTableName, objPage, paraValues)
            SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_Upd" & strTableName, paraValues)
        End Sub
        Public Overrides Function GetByID(ByVal strStoreProcName As String, ByVal ParamArray ParaValues() As Object) As DataSet
            Return CType(SqlHelper.ExecuteDataset(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProcName, ParaValues), DataSet)
        End Function
        Public Overrides Function ExecuteNonQueryStoreProc(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As Integer
            SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, arrParams)
        End Function
        Public Overrides Function ExecuteQueryStoreProc(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As DataSet
            Return CType(SqlHelper.ExecuteDataset(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, arrParams), DataSet)
        End Function
        Public Overrides Function ExecuteQueryStoreProcReader(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, arrParams), IDataReader)
        End Function
        Public Overrides Function ExecuteQueryStoreProcReaderAuto(ByVal strStoreProc As String, ByVal objControl As Object) As IDataReader
            Dim paraValues() As Object
            GetParamArray(strStoreProc, objControl, paraValues)
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, paraValues), IDataReader)
        End Function
        Public Overrides Function ExecuteNonQueryStoreProcAuTo(ByVal strStoreProc As String, ByVal objControl As Object) As Integer
            Dim paraValues() As Object
            GetParamArray(strStoreProc, objControl, paraValues)
            SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, paraValues)
        End Function
        Public Overrides Function ExecuteQueryStoreProcAuTo(ByVal strStoreProc As String, ByVal objControl As Object) As DataSet
            Dim paraValues() As Object
            GetParamArray(strStoreProc, objControl, paraValues)
            Return CType(SqlHelper.ExecuteDataset(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, paraValues), DataSet)
        End Function
        Public Overrides Function ExecuteScalarAuto(ByVal strStoreProc As String, ByVal objControl As Object) As String
            Dim paraValues() As Object
            GetParamArray(strStoreProc, objControl, paraValues)
            Return CType(SqlHelper.ExecuteScalar(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, paraValues), String)
        End Function
        Public Overrides Function ExecuteScalar(ByVal strStoreProc As String, ByVal ParamArray arrParams() As Object) As String
            Return CType(SqlHelper.ExecuteScalar(ConnectionStringApp, DatabaseOwner & ObjectQualifier & strStoreProc, arrParams), String)
        End Function

        Public Sub GetParamArray(ByVal strProcName As String, ByVal objPage As Object, ByRef ParaValues() As Object)
            Dim dr As IDataReader
            Dim c As DataColumn
            Dim r As DataRow
            Dim i, j As Integer
            Dim arr As New ArrayList
            Dim arrParam() As Object

            dr = CType(SqlHelper.ExecuteReader(ConnectionStringApp, CommandType.Text, "sp_sproc_columns '" & strProcName & "'"), IDataReader)
            j = 1
            While dr.Read
                For i = 1 To dr.FieldCount - 1
                    If UCase(dr.GetName(i)) = "COLUMN_NAME" Then
                        If dr.GetString(i) <> "@RETURN_VALUE" Then
                            'If AddArray(arr, dr.GetString(i), objPage) = 0 Then
                            '    arr.Add(Nothing)
                            'End If
                            AddArray(arr, dr.GetString(i), objPage)
                            If arr.Count < j Then
                                arr.Add(Nothing)
                            End If
                            j += 1
                        End If
                    End If
                Next
            End While
            ReDim arrParam(arr.Count - 1)
            For i = 0 To arr.Count - 1
                arrParam(i) = arr(i)
            Next
            ParaValues = arrParam

        End Sub
        Private Function AddArray(ByRef arr As ArrayList, ByVal strPamaName As String, ByVal objPage As Object) As Integer
            AddArray = FindControlAddArray(arr, strPamaName, objPage)
        End Function
        Private Function FindControlAddArray(ByRef arr As ArrayList, ByVal strPamaName As String, ByVal obj As Object) As Integer
            Dim oControl As Object
            Dim intAddArray As Integer
            Try
                If obj Is Nothing Then Exit Function
                intAddArray = 0
                For Each oControl In CType(obj, Control).Controls
                    Select Case True
                        Case TypeOf oControl Is TextBox
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                arr.Add(IIf(CType(oControl, TextBox).Text = "", Nothing, CType(oControl, TextBox).Text))
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is DropDownList
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                arr.Add(IIf(CType(oControl, DropDownList).SelectedItem.Value = "", Nothing, CType(oControl, DropDownList).SelectedItem.Value))
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is RadioButtonList
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                arr.Add(IIf(CType(oControl, RadioButtonList).SelectedItem.Value = "", Nothing, CType(oControl, RadioButtonList).SelectedItem.Value))
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is CheckBox
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                arr.Add(IIf(CType(oControl, CheckBox).Checked = True, 1, 0))
                                intAddArray = 1
                                Exit For
                            End If
                        Case TypeOf oControl Is RadioButton
                            If UCase(Mid(CType(oControl, Control).ID, 4)) = UCase(Mid(strPamaName, 3)) Then
                                arr.Add(IIf(CType(oControl, RadioButton).Checked = True, 1, 0))
                                intAddArray = 1
                                Exit For
                            End If
                        Case Else
                            FindControlAddArray(arr, strPamaName, oControl)
                    End Select
                Next oControl
            Catch ex As Exception
            Finally
                FindControlAddArray = intAddArray
            End Try
        End Function

        Public Overrides Function GetDanhMucCBO(ByVal strTableName As String) As System.Data.IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_GetDanhMucCBO", GetCommonDB, strTableName), IDataReader)
        End Function
        'begin ngantl
        Public Overrides Function InsHoSoTiepNhan(ByVal objPage As Object, ByVal sp_name As String) As Integer
            Try
                Dim paraValues() As Object
                GetParamArray(sp_name, objPage, paraValues)
                SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & sp_name, paraValues)
            Catch ' duplicate
                Return -1
            End Try
        End Function
        Public Overrides Function UpdHoSoTiepNhan(ByVal objPage As Object, ByVal sp_name As String) As Integer
            Try
                Dim paraValues() As Object
                GetParamArray(sp_name, objPage, paraValues)
                SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & sp_name, paraValues)
            Catch ' error
                Return -1
            End Try
        End Function
        Public Overrides Function GetHoSoTiepNhan_ChiTiet(ByVal HoSoTiepNhanID As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_getHoSoTiepNhan_ChiTiet", HoSoTiepNhanID), IDataReader)
        End Function
        Public Overrides Function GetHoSoTiepNhan_HoSoKemTheo(ByVal HoSoTiepNhanID As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_getHoSoTiepNhan_HoSoKemTheo", HoSoTiepNhanID), IDataReader)
        End Function
        Public Overrides Function GetHoSoTiepNhan_SoNgayQuiDinh(ByVal p_MaLoaiHoSo As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_getHoSoTiepNhan_SoNgayQuiDinh", p_MaLoaiHoSo), IDataReader)
        End Function
        Public Overrides Function GetHoSoTiepNhanID() As IDataReader
            Return CType(SqlHelper.ExecuteReader(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_getHoSoTiepNhanID"), IDataReader)
        End Function
        Public Overrides Function UpdateTinhTrangHoSo(ByVal MaKhuVuc As String, ByVal TabCode As Integer, _
                                    ByVal HoSoTiepNhanID As String, ByVal MaTinhTrangCurr As String, _
                                    ByVal ThongQua As String, ByVal MaNguoiDen As String, ByVal MaNguoiTacNghiep As String) As Integer
            Try
                Return CType(SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_updTinhTrangHoSo", _
                                    MaKhuVuc, TabCode, HoSoTiepNhanID, MaTinhTrangCurr, ThongQua, MaNguoiDen, MaNguoiTacNghiep), Integer)
            Catch ' loi
                Return -1
            End Try
        End Function

        Public Overrides Sub DeleteHoSoKemTheo(ByVal HoSoTiepNhanID As String)
            SqlHelper.ExecuteNonQuery(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_DeleteHoSoKemTheo", HoSoTiepNhanID)
        End Sub
        Public Overrides Function AddHoSoKemTheo(ByVal HoSoTiepNhanId As String, ByVal MaHoSoKemTheo As String, _
                                    ByVal MaKhuVuc As String, ByVal SoHoSo As String) As String
            Try
                Return CType(SqlHelper.ExecuteScalar(ConnectionStringApp, DatabaseOwner & ObjectQualifier & "sp_AddHoSoKemTheo", HoSoTiepNhanId, MaHoSoKemTheo, MaKhuVuc, SoHoSo), String)
            Catch ' duplicate
                Return ""
            End Try
        End Function
        'end ngantl

        Public Overrides Function ExecuteSQLApp(ByVal Script As String) As System.Data.IDataReader

        End Function

        Public Overrides Function ExecuteSQLAppDataSet(ByVal Script As String) As System.Data.DataSet

        End Function
    End Class
End Namespace
