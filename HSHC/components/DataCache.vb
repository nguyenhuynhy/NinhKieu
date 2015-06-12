Imports System
Imports System.Configuration
Imports System.Data
Imports System.IO

Namespace PortalQH

    Public Enum CoreCacheType
        Host = 1
        Portal = 2
        Tab = 3
    End Enum

    Public Class DataCache

        Public Shared Function GetCache(ByVal CacheKey As String) As Object

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            Return objCache(CacheKey)

        End Function

        Public Shared Sub SetCache(ByVal CacheKey As String, ByVal objObject As Object)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            objCache.Insert(CacheKey, objObject)

        End Sub

        Public Shared Sub SetCache(ByVal CacheKey As String, ByVal objObject As Object, ByVal SlidingExpiration As Integer)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            objCache.Insert(CacheKey, objObject, Nothing, DateTime.MaxValue, TimeSpan.FromSeconds(SlidingExpiration))

        End Sub

        Public Shared Sub SetCache(ByVal CacheKey As String, ByVal objObject As Object, ByVal AbsoluteExpiration As Date)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            objCache.Insert(CacheKey, objObject, Nothing, AbsoluteExpiration, TimeSpan.Zero)

        End Sub

        Public Shared Sub RemoveCache(ByVal CacheKey As String)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            If Not objCache(CacheKey) Is Nothing Then
                objCache.Remove(CacheKey)
            End If

        End Sub

        Public Shared Sub ClearCoreCache(ByVal Type As CoreCacheType, Optional ByVal ID As Integer = -1, Optional ByVal Cascade As Boolean = False)

            Select Case Type
                Case CoreCacheType.Host
                    ClearHostCache(Cascade)
                Case CoreCacheType.Portal
                    ClearPortalCache(ID, Cascade)
                Case CoreCacheType.Tab
                    ClearTabCache(ID)
            End Select

        End Sub

        Private Shared Sub ClearHostCache(ByVal Cascade As Boolean)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            If Not objCache("GetHostSettings") Is Nothing Then
                objCache.Remove("GetHostSettings")
            End If

            If Not objCache("GetPortalByAlias") Is Nothing Then
                objCache.Remove("GetPortalByAlias")
            End If

            If Not objCache("CSS") Is Nothing Then
                objCache.Remove("CSS")
            End If

            If Cascade Then
                Dim objPortals As New PortalController
                Dim objPortal As PortalInfo
                Dim arrPortals As ArrayList = objPortals.GetPortals

                Dim intIndex As Integer
                For intIndex = 0 To arrPortals.Count - 1
                    objPortal = CType(arrPortals(intIndex), PortalInfo)
                    ClearPortalCache(objPortal.PortalID, Cascade)
                Next
            End If

        End Sub

        Private Shared Sub ClearPortalCache(ByVal PortalId As Integer, ByVal Cascade As Boolean)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            If Not objCache("GetPortalSettings" & PortalId.ToString) Is Nothing Then
                objCache.Remove("GetPortalSettings" & PortalId.ToString)
            End If

            If Not objCache("GetTabs" & PortalId.ToString) Is Nothing Then
                objCache.Remove("GetTabs" & PortalId.ToString)
            End If

            If Cascade Then
                Dim objTabs As New TabController
                Dim objTab As TabInfo
                Dim arrTabs As ArrayList = objTabs.GetTabs(PortalId)

                Dim intIndex As Integer
                For intIndex = 0 To arrTabs.Count - 1
                    objTab = CType(arrTabs(intIndex), TabInfo)
                    ClearTabCache(objTab.TabID)
                Next
            End If

        End Sub

        Private Shared Sub ClearTabCache(ByVal TabId As Integer)

            Dim objCache As System.Web.Caching.Cache = HttpRuntime.Cache

            If Not objCache("GetTab" & TabId.ToString) Is Nothing Then
                objCache.Remove("GetTab" & TabId.ToString)
            End If

            If Not objCache("GetBreadCrumbs" & TabId.ToString) Is Nothing Then
                objCache.Remove("GetBreadCrumbs" & TabId.ToString)
            End If

            If Not objCache("GetPortalTabModules" & TabId.ToString) Is Nothing Then
                objCache.Remove("GetPortalTabModules" & TabId.ToString)
            End If

        End Sub

        Public Shared Sub ClearCacheParameterSet(ByVal connectionString As String, _
                                        ByVal commandText As String)
            DataProvider.Instance.ClearCacheParameterSet(connectionString, commandText)
        End Sub

    End Class

End Namespace