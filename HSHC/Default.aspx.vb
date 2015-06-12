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
Imports System.IO

Namespace PortalQH
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : DesktopDefault
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[sun1]	1/19/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class CDefault

        Inherits PortalQH.BasePage

        ' obtain PortalSettings from Current Context
        Public _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

        Public Title As String = ""
        Public Description As String = ""
        Public KeyWords As String = ""
        Public Copyright As String = ""
        Public Generator As String = ""

        Protected WithEvents ScrollTop As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents SkinError As System.Web.UI.WebControls.Label
        Protected WithEvents CSS As System.Web.UI.WebControls.PlaceHolder
        Protected WithEvents SkinPlaceHolder As System.Web.UI.WebControls.PlaceHolder
        Protected WithEvents MsgBox_Hidden As System.Web.UI.HtmlControls.HtmlInputHidden

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Contains the functionality to populate the Root aspx page with controls
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' - obtain PortalSettings from Current Context
        ''' - set global page settings
        ''' - initialise reference paths to load the cascading style sheets
        ''' - add skin control placeholder.  This holds all the modules and content of the page.
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            '
            ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
            '
            InitializeComponent()

            ' set global page settings
            InitializePage()

            ' process the current request
            ManageRequest()

            ' load skin control
            Dim ctlSkin As UserControl

            ' skin preview
            If (Not Request.QueryString("SkinType") Is Nothing) And (Not Request.QueryString("SkinName") Is Nothing) And (Not Request.QueryString("SkinSrc") Is Nothing) Then
                Select Case Request.QueryString("SkinType")
                    Case "G" ' global
                        _portalSettings.ActiveTab.SkinPath = Global.HostPath & SkinInfo.RootSkin & "/" & Request.QueryString("SkinName") & "/"
                    Case "L" ' local
                        _portalSettings.ActiveTab.SkinPath = _portalSettings.UploadDirectory & SkinInfo.RootSkin & "/" & Request.QueryString("SkinName") & "/"
                End Select
                _portalSettings.ActiveTab.SkinSrc = Request.QueryString("SkinSrc")
                ctlSkin = LoadSkin("~" & _portalSettings.ActiveTab.SkinPath.Remove(0, Len(Global.ApplicationPath)) & _portalSettings.ActiveTab.SkinSrc)
            End If

            ' load assigned skin
            If ctlSkin Is Nothing Then
                If IsAdminControl() Then
                    _portalSettings.ActiveTab.SkinPath = Global.HostPath & SkinInfo.RootSkin & "/_default/"
                    _portalSettings.ActiveTab.SkinSrc = "admin.ascx"

                    Dim objSkins As New SkinController
                    Dim objSkin As SkinInfo
                    objSkin = objSkins.GetSkin(SkinInfo.RootSkin, _portalSettings.PortalId, _portalSettings.ActiveTab.TabId, Null.NullInteger, True)
                    If Not objSkin Is Nothing Then
                        Select Case objSkin.SkinType
                            Case "G" ' global
                                _portalSettings.ActiveTab.SkinPath = Global.HostPath & SkinInfo.RootSkin & "/" & objSkin.SkinName & "/"
                            Case "L" ' local
                                _portalSettings.ActiveTab.SkinPath = _portalSettings.UploadDirectory & SkinInfo.RootSkin & "/" & objSkin.SkinName & "/"
                        End Select
                        _portalSettings.ActiveTab.SkinSrc = objSkin.SkinSrc
                    End If
                Else
                    If _portalSettings.ActiveTab.SkinPath = "" Or _portalSettings.ActiveTab.SkinSrc = "" Then
                        _portalSettings.ActiveTab.SkinPath = Global.HostPath & SkinInfo.RootSkin & "/_default/"
                        _portalSettings.ActiveTab.SkinSrc = "default.ascx"
                    End If
                End If
                ctlSkin = LoadSkin("~" & _portalSettings.ActiveTab.SkinPath.Remove(0, Len(Global.ApplicationPath)) & _portalSettings.ActiveTab.SkinSrc)
            End If

            ' error loading skin - load default
            If ctlSkin Is Nothing Then
                ' could not load skin control - load default skin
                If IsAdminControl() Then
                    _portalSettings.ActiveTab.SkinPath = Global.HostPath & SkinInfo.RootSkin & "/_default/"
                    _portalSettings.ActiveTab.SkinSrc = "default.ascx"
                Else
                    _portalSettings.ActiveTab.SkinPath = Global.HostPath & SkinInfo.RootSkin & "/_default/"
                    _portalSettings.ActiveTab.SkinSrc = "default.ascx"
                End If
                ctlSkin = LoadSkin("~" & _portalSettings.ActiveTab.SkinPath.Remove(0, Len(Global.ApplicationPath)) & _portalSettings.ActiveTab.SkinSrc)
            End If

            ' add CSS links
            ManageStyleSheets(False)

            ' add skin to page
            SkinPlaceHolder.Controls.Add(ctlSkin)

            ' add CSS links
            ManageStyleSheets(True)



        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Initialize the Scrolltop html control which controls the open / closed nature of each module 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim Scrolltop As HtmlControls.HtmlInputHidden = CType(Page.FindControl("ScrollTop"), HtmlControls.HtmlInputHidden)
            If Scrolltop.Value <> "" Then
                If Not Me.FindControl("Body") Is Nothing Then
                    CType(Me.FindControl("Body"), HtmlGenericControl).Attributes.Add("onload", "javascript:Body.scrollTop=" & Scrolltop.Value & ";")
                End If
            End If
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' - Obtain PortalSettings from Current Context
        ''' - redirect to a specific tab based on name
        ''' - if first time loading this page then reload to avoid caching
        ''' - set page title and stylesheet
        ''' - check to see if we should show the Assembly Version in Page Title 
        ''' - set the background image if there is one selected
        ''' - set META tags, copyright, keywords and description
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub InitializePage()

            Dim objTabs As New TabController

            ' redirect to a specific tab based on name
            If Request.Params("tabname") <> "" Then
                Dim strURL As String = ""

                Dim objTab As TabInfo = objTabs.GetTabByName(Request.Params("TabName"), CType(HttpContext.Current.Items("PortalSettings"), PortalSettings).PortalId)
                If Not objTab Is Nothing Then
                    strURL = "~/DesktopDefault.aspx?tabid=" & objTab.TabID
                End If

                If strURL <> "" Then
                    Dim intParam As Integer
                    For intParam = 0 To Request.QueryString.Count - 1
                        Select Case Request.QueryString.Keys(intParam).ToLower()
                            Case "tabid", "tabname"
                            Case Else
                                strURL += "&" + Request.QueryString.Keys(intParam) + "=" + Request.QueryString(intParam)
                        End Select
                    Next

                    Response.Redirect(strURL, True)

                End If
            End If

            ' avoid client side page caching
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

            ' set page title
            Dim strTitle As String = _portalSettings.PortalName
            Dim tabstrip As TabStripDetails
            strTitle = _portalSettings.PortalName
            Dim tab As TabStripDetails
            For Each tab In _portalSettings.BreadCrumbs
                strTitle += " > " & tab.TabName
            Next
            ' check to see if we should show the Assembly Version in Page Title 
            If _portalSettings.HostSettings.ContainsKey("DisablePageTitleVersion") = True Then
                If _portalSettings.HostSettings("DisablePageTitleVersion").ToString = "N" Then
                    strTitle += " ( DNN " & _portalSettings.Version & " )"
                End If
            Else
                strTitle += " ( DNN " & _portalSettings.Version & " )"
            End If
            ' tab title override
            If _portalSettings.ActiveTab.Title <> "" Then
                strTitle = _portalSettings.ActiveTab.Title
            End If
            Title = strTitle

            'set the background image if there is one selected
            If Not Me.FindControl("Body") Is Nothing Then
                If _portalSettings.BackgroundFile <> "" Then
                    CType(Me.FindControl("Body"), HtmlGenericControl).Attributes("background") = _portalSettings.UploadDirectory & _portalSettings.BackgroundFile
                End If
            End If

            ' set META tags, keywords, copyright and description
            If _portalSettings.ActiveTab.Description <> "" Then
                Description = _portalSettings.ActiveTab.Description
            Else
                Description = _portalSettings.Description
            End If
            If _portalSettings.ActiveTab.KeyWords <> "" Then
                KeyWords = _portalSettings.ActiveTab.KeyWords
            Else
                KeyWords = _portalSettings.KeyWords
            End If
            If Not Request.Params("TabID") Is Nothing Then
               
                Session.Item("ActiveDB") = GetActiveDB()
                'Session.Item("gPortalID") = GetActiveDB()
            Else
               
                Session.Item("ActiveDB") = KeyWords
                'Session.Item("gPortalID") = KeyWords

            End If
            'If Session.Item("gPortalID") Is Nothing Then
            '    Session.Item("gPortalID") = ""
            'End If
            If Session.Item("ActiveDB") Is Nothing Then
                Session.Item("ActiveDB") = ""
            End If

            KeyWords = KeyWords & ",PortalQH"
            Copyright = "Copyright (c) 2002-" & Year(Now).ToString & " by PortalQH ( " & System.Diagnostics.FileVersionInfo.GetVersionInfo(Global.AssemblyPath).ProductName.ToString & " )"

            ' check to see if we should show the Assembly Version in the meta tag
            If _portalSettings.HostSettings.ContainsKey("DisablePageTitleVersion") = True Then
                If _portalSettings.HostSettings("DisablePageTitleVersion").ToString = "N" Then
                    Generator = "PortalQH " & _portalSettings.Version
                Else
                    Generator = "PortalQH"
                End If
            Else
                Generator = "PortalQH " & _portalSettings.Version
            End If

        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' - manage affiliates
        ''' - log visit to site
        ''' </remarks>
        ''' <history>
        ''' 	[sun1]	1/19/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub ManageRequest()

            ' affiliate processing
            Dim AffiliateId As Integer = -1
            If Not Request.QueryString("AffiliateId") Is Nothing Then
                If IsNumeric(Request.QueryString("AffiliateId")) Then
                    AffiliateId = Int32.Parse(Request.QueryString("AffiliateId"))
                    Dim objAffiliates As New AffiliateController
                    objAffiliates.UpdateAffiliateStats(AffiliateId, 1, 0)

                    ' save the affiliateid for acquisitions
                    If Request.Cookies("AffiliateId") Is Nothing Then ' do not overwrite
                        Dim objCookie As HttpCookie = New HttpCookie("AffiliateId")
                        objCookie.Value = AffiliateId.ToString
                        objCookie.Expires = Now.AddYears(1) ' persist cookie for one year
                        Response.Cookies.Add(objCookie)
                    End If
                End If
            End If

            ' site logging
            If _portalSettings.SiteLogHistory <> 0 Then
                ' get User ID
                Dim UserId As String = ""
                If Request.IsAuthenticated Then
                    UserId = CType(Context.User.Identity.Name, String)
                End If

                ' URL Referrer
                Dim URLReferrer As String = ""
                If Not Request.UrlReferrer Is Nothing Then
                    URLReferrer = Request.UrlReferrer.ToString()
                End If

                Dim intSiteLogBuffer As Integer = 100
                If Convert.ToString(_portalSettings.HostSettings("SiteLogBuffer")) <> "" Then
                    intSiteLogBuffer = Integer.Parse(Convert.ToString(_portalSettings.HostSettings("SiteLogBuffer")))
                End If

                ' log visit
                Dim objSiteLogs As New SiteLogController
                objSiteLogs.AddSiteLog(_portalSettings.PortalId, UserId, URLReferrer, Request.Url.ToString(), Request.UserAgent, Request.UserHostAddress, Request.UserHostName, _portalSettings.ActiveTab.TabId, AffiliateId, intSiteLogBuffer)
            End If

        End Sub

        Private Sub ManageStyleSheets(ByVal PortalCSS As Boolean)

            ' initialize reference paths to load the cascading style sheets
            Dim objCSS As Control = Me.FindControl("CSS")
            Dim objLink As HtmlGenericControl
            Dim ID As String

            Dim objCSSCache As Hashtable = CType(DataCache.GetCache("CSS"), Hashtable)
            If objCSSCache Is Nothing Then
                objCSSCache = New Hashtable
            End If

            If Not objCSS Is Nothing Then
                If PortalCSS = False Then
                    ' default style sheet ( required )
                    ID = CreateValidID(Global.HostPath)
                    objLink = New HtmlGenericControl("LINK")
                    objLink.ID = ID
                    objLink.Attributes("rel") = "stylesheet"
                    objLink.Attributes("type") = "text/css"
                    objLink.Attributes("href") = Global.HostPath & "default.css"
                    objCSS.Controls.Add(objLink)

                    ' skin package style sheet
                    ID = CreateValidID(_portalSettings.ActiveTab.SkinPath)
                    If objCSSCache.ContainsKey(ID) = False Then
                        If File.Exists(Server.MapPath(_portalSettings.ActiveTab.SkinPath) & "skin.css") Then
                            objCSSCache(ID) = _portalSettings.ActiveTab.SkinPath & "skin.css"
                        Else
                            objCSSCache(ID) = ""
                        End If
                        DataCache.SetCache("CSS", objCSSCache)
                    End If
                    If objCSSCache(ID).ToString <> "" Then
                        objLink = New HtmlGenericControl("LINK")
                        objLink.ID = ID
                        objLink.Attributes("rel") = "stylesheet"
                        objLink.Attributes("type") = "text/css"
                        objLink.Attributes("href") = objCSSCache(ID).ToString
                        objCSS.Controls.Add(objLink)
                    End If

                    ' skin file style sheet
                    ID = CreateValidID(_portalSettings.ActiveTab.SkinPath & Replace(_portalSettings.ActiveTab.SkinSrc, ".ascx", ".css"))
                    If objCSSCache.ContainsKey(ID) = False Then
                        If File.Exists(Server.MapPath(_portalSettings.ActiveTab.SkinPath) & Replace(_portalSettings.ActiveTab.SkinSrc, ".ascx", ".css")) Then
                            objCSSCache(ID) = _portalSettings.ActiveTab.SkinPath & Replace(_portalSettings.ActiveTab.SkinSrc, ".ascx", ".css")
                        Else
                            objCSSCache(ID) = ""
                        End If
                        DataCache.SetCache("CSS", objCSSCache)
                    End If
                    If objCSSCache(ID).ToString <> "" Then
                        objLink = New HtmlGenericControl("LINK")
                        objLink.ID = ID
                        objLink.Attributes("rel") = "stylesheet"
                        objLink.Attributes("type") = "text/css"
                        objLink.Attributes("href") = objCSSCache(ID).ToString
                        objCSS.Controls.Add(objLink)
                    End If
                Else
                    ' portal style sheet
                    ID = CreateValidID(_portalSettings.UploadDirectory)
                    objLink = New HtmlGenericControl("LINK")
                    objLink.ID = ID
                    objLink.Attributes("rel") = "stylesheet"
                    objLink.Attributes("type") = "text/css"
                    objLink.Attributes("href") = _portalSettings.UploadDirectory & "portal.css"
                    objCSS.Controls.Add(objLink)
                End If

            End If

        End Sub

        Private Function LoadSkin(ByVal SkinPath As String) As UserControl
            Dim ctlSkin As UserControl

            Try
                ctlSkin = CType(LoadControl(SkinPath), UserControl)
            Catch ex As Exception
                ' could not load user control
                SkinError.Text += "<center>Could Not Load Skin: " & SkinPath & " Error: " & ex.Message & "</center><br>"
                SkinError.Visible = True
            End Try

            Return ctlSkin
        End Function
        Private Function GetActiveDB() As String
            Dim objtabinfo As New TabInfo
            Dim objtab As New TabController
            objtabinfo.TabID = CType(Request.Params("TabID"), Integer)
            objtabinfo = objtab.GetTab(objtabinfo.TabID)
            Return objtabinfo.KeyWords
        End Function

    End Class

End Namespace
