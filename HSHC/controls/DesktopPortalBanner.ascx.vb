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

    Public MustInherit Class DesktopPortalBanner
        Inherits System.Web.UI.UserControl

        Protected WithEvents hypLogo As System.Web.UI.WebControls.HyperLink
        Protected WithEvents hypLogoImage As System.Web.UI.WebControls.Image
        Protected WithEvents hypBanner As System.Web.UI.WebControls.HyperLink
        Protected WithEvents hypBannerImage As System.Web.UI.WebControls.Image
        Protected WithEvents ctlMenu As SolpartWebControls.SolpartMenu
        Protected WithEvents lblDate As System.Web.UI.WebControls.Label
        Protected WithEvents hypUser As System.Web.UI.WebControls.HyperLink
        Protected WithEvents imgSpacer1 As System.Web.UI.WebControls.Image
        Protected WithEvents imgSpacer2 As System.Web.UI.WebControls.Image
        Protected WithEvents imgSpacer3 As System.Web.UI.WebControls.Image
        Protected WithEvents imgTabImage As System.Web.UI.WebControls.Image
        Protected WithEvents imgBevel As System.Web.UI.WebControls.Image
        Protected WithEvents hypHelp As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblSeparator As System.Web.UI.WebControls.Label
        Protected WithEvents hypLogin As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblBreadCrumbs As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim ServerPath As String
                Dim BannerId As Integer = -1
                Dim VendorId As Integer = -1

                ' format the Request.ApplicationPath
                ServerPath = Request.ApplicationPath
                If Not ServerPath.EndsWith("/") Then
                    ServerPath += "/"
                End If

                ' set page title and stylesheet
                If Not Me.Parent.FindControl("Title") Is Nothing Then
                    Dim strTitle As String = _portalSettings.PortalName
                    Dim tab As TabStripDetails
                    For Each tab In _portalSettings.BreadCrumbs
                        strTitle += " > " & tab.TabName
                    Next

                    If _portalSettings.HostSettings.ContainsKey("DisablePageTitleVersion") = True Then
                        If _portalSettings.HostSettings("DisablePageTitleVersion").ToString = "N" Then
                            strTitle += " ( DNN " & _portalSettings.Version & " )"
                        Else
                            strTitle += ""
                        End If
                    Else
                        strTitle += " ( DNN " & _portalSettings.Version & " )"
                    End If
                    CType(Me.Parent.FindControl("Title"), HtmlGenericControl).InnerText = strTitle
                End If
                If Not Me.Parent.FindControl("StyleSheet") Is Nothing Then
                    CType(Me.Parent.FindControl("StyleSheet"), HtmlGenericControl).Attributes("href") = _portalSettings.UploadDirectory & "portal.css"
                End If
                If Not Me.Parent.FindControl("Body") Is Nothing Then
                    If _portalSettings.BackgroundFile <> "" Then
                        CType(Me.Parent.FindControl("Body"), HtmlGenericControl).Attributes("background") = _portalSettings.UploadDirectory & _portalSettings.BackgroundFile
                    End If
                End If

                ' dynamically populate the portal settings
                If _portalSettings.LogoFile <> "" Then
                    hypLogoImage.ImageUrl = _portalSettings.UploadDirectory & _portalSettings.LogoFile
                Else
                    hypLogoImage.Visible = False
                End If
                hypLogo.ToolTip = _portalSettings.PortalName
                hypLogoImage.AlternateText = _portalSettings.PortalName
                hypLogo.NavigateUrl = GetPortalDomainName(_portalSettings.PortalAlias, Request)
                hypHelp.Visible = False
                lblSeparator.Visible = False
                If _portalSettings.UserRegistration <> 0 Then
                    hypHelp.Text = "Register"
                    hypHelp.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&def=Register"
                    hypHelp.Visible = True
                    lblSeparator.Visible = True
                End If
                hypLogin.Text = "Login"
                hypLogin.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&showlogin=1"
                lblDate.Text = Format(Now(), "MMMM dd, yyyy")

                Dim objRoles As New RoleController
                Dim objUsers As New UserController
                Dim ArrServices As New ArrayList
                Dim objUser As New UserInfo
                Dim dr As IDataReader

                hypUser.Text = ""
                ArrServices = objRoles.GetServices(_portalSettings.PortalId)
                If Not ArrServices.Count = 0 Then
                    hypUser.Text = "Member Services"
                    hypUser.ToolTip = "Click Here To View Our Membership Services"
                    hypUser.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&def=Register&services=1"
                End If

                ' banner advertising
                If _portalSettings.BannerAdvertising <> 0 Then
                    Dim objBanners As New BannerController
                    Dim arrBanners As ArrayList = objBanners.LoadBanners(Convert.ToInt32(IIf(_portalSettings.BannerAdvertising = 1, _portalSettings.PortalId, Null.NullInteger)), 1, 1)
                    If arrBanners.Count <> 0 Then
                        Dim objBanner As BannerInfo = CType(arrBanners(0), BannerInfo)

                        hypBanner.Visible = True
                        hypBannerImage.Visible = True
                        Select Case _portalSettings.BannerAdvertising
                            Case 1 ' local
                                hypBanner.ImageUrl = _portalSettings.UploadDirectory & objBanner.ImageFile.ToString
                            Case 2 ' global
                                hypBanner.ImageUrl = Global.HostPath & objBanner.ImageFile.ToString
                        End Select
                        hypBanner.ToolTip = objBanner.BannerName.ToString
                        hypBannerImage.AlternateText = objBanner.BannerName.ToString
                        hypBanner.NavigateUrl = Global.ApplicationPath & "Admin/Vendors/BannerClickThrough.aspx?BannerId=" & objBanner.BannerId.ToString & "&VendorId=" & objBanner.VendorId.ToString
                    Else ' no banners defined
                        hypBanner.ImageUrl = "~/images/nobanner.gif"
                        hypBannerImage.AlternateText = "No Banner"
                    End If
                Else
                    hypBanner.Visible = False
                    hypBannerImage.Visible = False
                End If

                Dim UserId As String = ""
                If Request.IsAuthenticated Then
                    UserId = CType(Context.User.Identity.Name, String)
                End If

                ' log visit to site
                If _portalSettings.SiteLogHistory <> 0 Then
                    Dim URLReferrer As String = ""
                    If Not Request.UrlReferrer Is Nothing Then
                        URLReferrer = Convert.ToString(Request.UrlReferrer)
                    End If
                    Dim AffiliateId As Integer = -1
                    If Not Request.QueryString("AffiliateId") Is Nothing Then
                        If IsNumeric(Request.QueryString("AffiliateId")) Then
                            AffiliateId = Int32.Parse(Request.QueryString("AffiliateId"))
                        End If
                    End If
                    Dim objAdmin As New AdminDB
                    objAdmin.AddSiteLog(_portalSettings.PortalId, UserId, URLReferrer, Convert.ToString(Request.Url), Request.UserAgent, Request.UserHostAddress, Request.UserHostName, _portalSettings.ActiveTab.TabId, AffiliateId)
                End If

                ' If user logged in, customize welcome message
                If Request.IsAuthenticated = True Then
                    objUser = objUsers.GetUser(_portalSettings.PortalId, UserId)
                    If Not objUser Is Nothing Then
                        hypUser.Text = objUser.FullName
                        hypUser.ToolTip = "Click Here To Edit Your Account Profile"
                    End If


                    If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                        hypUser.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&UserId=" & _portalSettings.SuperUserId & "&def=User Accounts"
                    Else
                        hypUser.NavigateUrl = "~/DesktopDefault.aspx?tabid=" & _portalSettings.ActiveTab.TabId & "&def=Register"
                    End If

                    If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) Then
                        hypHelp.Text = "Help"
                        hypHelp.NavigateUrl = "mailto:" & _portalSettings.HostSettings("HostEmail").ToString & "?subject=" & _portalSettings.PortalName & " Support Request"
                        hypHelp.Visible = True
                        lblSeparator.Visible = True
                    Else ' registered user
                        hypHelp.Text = "Help"
                        hypHelp.NavigateUrl = "mailto:" & _portalSettings.Email & "?subject=" & _portalSettings.PortalName & " Support Request"
                        hypHelp.Visible = True
                        lblSeparator.Visible = True
                    End If

                    hypLogin.Text = "Logoff"
                    hypLogin.NavigateUrl = "~/Admin/Security/Logoff.aspx?tabid=" & _portalSettings.ActiveTab.TabId
                End If

                ' process bread crumbs
                Dim strBreadCrumbs As String = ""
                Dim intTab As Integer
                For intTab = 1 To _portalSettings.BreadCrumbs.Count - 1
                    strBreadCrumbs += "&nbsp;<img alt=""*"" src=""" & IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/images/breadcrumb.gif"">&nbsp;<a href=""" & FormatURL() & "?tabid=" & CType(_portalSettings.BreadCrumbs(intTab), TabStripDetails).TabId & """ class=""SelectedTab"">" & CType(_portalSettings.BreadCrumbs(intTab), TabStripDetails).TabName & "</a>"
                Next
                lblBreadCrumbs.Text = strBreadCrumbs

                ' Build list of tabs to be shown to user
                Dim authorizedTabs As New ArrayList
                Dim addedTabs As Integer = 0

                Dim i As Integer
                For i = 0 To _portalSettings.DesktopTabs.Count - 1

                    Dim tab As TabStripDetails = CType(_portalSettings.DesktopTabs(i), TabStripDetails)

                    Dim strTest As String = tab.TabName
                    If tab.IsVisible Then
                        If PortalSecurity.IsInRoles(tab.AuthorizedRoles) = True Then
                            authorizedTabs.Add(tab)
                            addedTabs += 1
                        End If
                    End If

                Next i

                If Request.IsAuthenticated Then
                    ' append super tab
                    If CType(Context.User.Identity.Name, String) = _portalSettings.SuperUserId Then
                        Dim SuperTab As TabStripDetails

                        SuperTab = New TabStripDetails
                        SuperTab.TabName = "Host"
                        SuperTab.TabId = _portalSettings.SuperTabId
                        SuperTab.TabOrder = 999
                        SuperTab.AuthorizedRoles = ""
                        SuperTab.ParentId = -1
                        SuperTab.IsVisible = True
                        SuperTab.IconFile = ""
                        SuperTab.Level = 0
                        SuperTab.HasChildren = True
                        authorizedTabs.Add(SuperTab)

                        Dim objTabs As New TabController
                        Dim Arr As ArrayList = objTabs.GetTabsByParentId(_portalSettings.SuperTabId)
                        For i = 0 To Arr.Count - 1
                            Dim objTabInfo As TabInfo = CType(Arr(i), TabInfo)
                            SuperTab = New TabStripDetails
                            SuperTab.TabName = objTabInfo.TabName
                            SuperTab.TabId = objTabInfo.TabID
                            SuperTab.TabOrder = 999
                            SuperTab.AuthorizedRoles = ""
                            SuperTab.ParentId = _portalSettings.SuperTabId
                            SuperTab.IsVisible = True
                            SuperTab.IconFile = objTabInfo.IconFile
                            SuperTab.Level = 1
                            SuperTab.HasChildren = False
                            authorizedTabs.Add(SuperTab)
                        Next
                    End If
                End If

                ' generate dynamic menu
                ctlMenu.SystemImagesPath = IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/images/"
                ctlMenu.IconImagesPath = _portalSettings.UploadDirectory
                ctlMenu.ArrowImage = "breadcrumb.gif"
                ctlMenu.RootArrow = True
                ctlMenu.RootArrowImage = "menu_down.gif"
                ctlMenu.SystemScriptPath = IIf(Request.ApplicationPath = "/", "", Request.ApplicationPath).ToString & "/controls/SolpartMenu/"

                Dim objTab As TabStripDetails
                Dim objAttribute As System.Xml.XmlAttribute
                Dim objMenuItem As Solpart.WebControls.SPMenuItemNode

                For Each objTab In authorizedTabs
                    If objTab.ParentId = -1 Then ' root menu
                        If objTab.DisableLink Then
                            objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.TabId.ToString, objTab.TabName, ""))
                        Else
                            objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.TabId.ToString, objTab.TabName, FormatURL() & "?tabid=" & objTab.TabId))
                        End If

                        'add image next to selected item
                        If objTab.TabId = CType(_portalSettings.BreadCrumbs(0), TabStripDetails).TabId Then
                            objMenuItem.LeftHTML = "<img alt=""*"" BORDER=""0"" src=""" & ctlMenu.SystemImagesPath & "breadcrumb.gif"">"
                        End If
                        'Has Children now handled by rootmenuarrow
                    Else
                        Try
                            If objTab.DisableLink Then
                                objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.ParentId.ToString, objTab.TabId.ToString, "&nbsp;" & objTab.TabName, ""))
                            Else
                                objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.ParentId.ToString, objTab.TabId.ToString, "&nbsp;" & objTab.TabName, FormatURL() & "?tabid=" & objTab.TabId))
                            End If
                        Catch
                            ' throws exception if the parent tab has not been loaded ( may be related to user role security not allowing access to a parent tab )
                            objMenuItem = Nothing
                        End Try
                    End If

                    ' menu icon
                    If Not objMenuItem Is Nothing Then
                        If IsAdminTab(objTab.TabId, objTab.ParentId) Then
                            If objTab.IconFile <> "" Then
                                objMenuItem.Image = objTab.IconFile
                                objMenuItem.ImagePath = ctlMenu.SystemImagesPath
                            End If
                        Else
                            If objTab.IconFile <> "" Then
                                objMenuItem.Image = objTab.IconFile
                            End If
                        End If
                    End If
                Next

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function FormatURL() As String
            Try
                Dim ServerPath As String

                ServerPath = Request.ApplicationPath
                If Not ServerPath.EndsWith("/") Then
                    ServerPath += "/"
                End If

                Return ServerPath & "DesktopDefault.aspx"

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function


    End Class

End Namespace
