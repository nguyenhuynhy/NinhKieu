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
Imports System.Configuration

Namespace PortalQH

    Public Class Skin

        Inherits System.Web.UI.UserControl

        Private _actionEventListeners As ArrayList

        Private objCommunicator As New ModuleCommunicate

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            '
            ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
            '
            InitializeComponent()

            Dim objModules As New ModuleController
            Dim objModule As ModuleInfo
            Dim blnLayoutMode As Boolean = False

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' get site module container
            Dim settings As Hashtable = PortalSettings.GetModuleSettings(objModules.GetSiteModule("Site Settings", _portalSettings.PortalId))
            Dim strContainer As String = Convert.ToString(settings("container"))

            ' iterate page controls
            Dim ctlControl As Control
            Dim objHtmlControl As HtmlControl
            For Each ctlControl In Me.Controls
                ' load the skin panes
                If TypeOf ctlControl Is HtmlControl Then
                    objHtmlControl = CType(ctlControl, HtmlControl)
                    If Not objHtmlControl.ID Is Nothing Then
                        Select Case objHtmlControl.TagName.ToUpper
                            Case "TD", "DIV", "SPAN", "P"
                                ' content pane
                                _portalSettings.Panes.Add(ctlControl.ID)
                        End Select
                    End If
                End If
            Next

            If Not IsAdminControl() Then ' master module

                If PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AuthorizedRoles) Then

                    ' check portal expiry date
                    Dim blnExpired As Boolean = False
                    If _portalSettings.ExpiryDate <> "" Then
                        If Convert.ToDateTime(_portalSettings.ExpiryDate) < Now() And _portalSettings.ActiveTab.ParentId <> _portalSettings.AdminTabId And _portalSettings.ActiveTab.ParentId <> _portalSettings.SuperTabId Then
                            blnExpired = True
                        End If
                    End If

                    If Not blnExpired Then
                        ' inject admin control if it does not exist in the skin
                        If Me.FindControl("dnnAdmin") Is Nothing Then
                            Dim objPortalModuleControl As UserControl = CType(LoadControl("~/admin/Skins/Admin.ascx"), UserControl)
                            Dim objForm As HtmlForm = CType(Me.Parent.FindControl("Form"), HtmlForm)
                            objForm.Controls.AddAt(0, objPortalModuleControl)
                        End If

                        ' process panes
                        Dim blnPreview As Boolean = False
                        If Not Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString) Is Nothing Then
                            blnPreview = Boolean.Parse(Request.Cookies("_Tab_Admin_Preview" & _portalSettings.PortalId.ToString).Value)
                        End If
                        If (PortalSecurity.IsInRole(_portalSettings.AdministratorRoleId.ToString) = True Or PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = True) And blnPreview = False Then
                            If IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) = False Then
                                blnLayoutMode = True
                            End If
                        End If

                        If blnLayoutMode Then
                            Dim ctlPane As Control
                            Dim strPane As String
                            For Each strPane In _portalSettings.Panes
                                ctlPane = Me.FindControl(strPane)
                                ctlPane.Visible = True

                                ' display pane border
                                If TypeOf ctlPane Is HtmlTableCell Then
                                    CType(ctlPane, HtmlTableCell).Style("border-top") = "1px #CCCCCC dotted"
                                    CType(ctlPane, HtmlTableCell).Style("border-bottom") = "1px #CCCCCC dotted"
                                    CType(ctlPane, HtmlTableCell).Style("border-right") = "1px #CCCCCC dotted"
                                    CType(ctlPane, HtmlTableCell).Style("border-left") = "1px #CCCCCC dotted"
                                End If

                                ' display pane name
                                Dim ctlLabel As New Label
                                ctlLabel.Text = "<center>" & strPane & "</center><br>"
                                ctlLabel.CssClass = "SubHead"
                                ctlPane.Controls.AddAt(0, ctlLabel)
                            Next
                        End If

                        ' dynamically populate the panes with modules
                        If _portalSettings.ActiveTab.Modules.Count > 0 Then

                            ' Loop through each entry in the configuration system for this tab
                            Dim _moduleSettings As ModuleSettings
                            For Each _moduleSettings In _portalSettings.ActiveTab.Modules

                                If PortalSecurity.IsInRoles(_moduleSettings.AuthorizedViewRoles) = True And _moduleSettings.IsDeleted = False Then

                                    ' modules which are displayed on all tabs should not be displayed on the Admin or Super tabs
                                    If _moduleSettings.AllTabs = False Or IsAdminTab(_portalSettings.ActiveTab.TabId, _portalSettings.ActiveTab.ParentId) = False Then

                                        Dim parent As Control = Me.FindControl(_moduleSettings.PaneName)

                                        If parent Is Nothing Then
                                            ' the pane specified in the database does not exist for this skin
                                            ' insert the module into the default pane
                                            parent = Me.FindControl(glbDefaultPane)
                                            ' TODO: what if the default pane does not exist?
                                        End If

                                        If Not parent Is Nothing Then
                                            ' inject the module into the skin
                                            InjectModule(parent, _moduleSettings, _portalSettings)
                                        Else ' no ContentPane in skin
                                            Dim lex As ModuleLoadException
                                            lex = New ModuleLoadException("Cannot locate ContentPane for Skin")
                                            Controls.Add(New ErrorContainer(_portalSettings, "Error loading module", lex).Container)
                                            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                                            Err.Clear()
                                        End If

                                    End If

                                End If

                            Next _moduleSettings
                        End If
                    Else
                        Skin.AddPageMessage(Me, "", "The hosting contract for " & _portalSettings.PortalName & " expired on " & GetMediumDate(_portalSettings.ExpiryDate) & ". please contact <a href=""mailto:" & _portalSettings.Email & """>" & _portalSettings.Email & "</a> for further information.", Skins.ModuleMessage.ModuleMessageType.RedError)
                    End If
                Else
                    'LANPHM rem 6/6/2005
                    'LANPHM add icon alert mau do
                    Skin.AddPageMessage(Me, "", "Bạn không có quyền truy cập vào chức năng này.", Skins.ModuleMessage.ModuleMessageType.RedError)
                    'Redirect to LoginPage 
                    Dim blnRedirectLogin As Boolean
                    blnRedirectLogin = CType(ConfigurationSettings.AppSettings("RedirectLoginPage"), Boolean)
                    If blnRedirectLogin Then
                        'Truong hop neu sign in lan dau tien
                        If Session.Item("UserID") Is Nothing Then
                            Response.Redirect(glbDefaultPage & "?ctl=Login", True)
                        Else
                            Response.Redirect(glbDefaultPage & "?ctl=Login&Message=" & Server.UrlEncode("Bạn không có quyền truy cập vào chức năng này."), True)
                        End If
                    End If
                End If
            Else ' slave module

                Dim ModuleId As Integer = -1
                Dim Key As String = ""

                ' get ModuleId
                If Not IsNothing(Request.QueryString("mid")) Then
                    ModuleId = Int32.Parse(Request.QueryString("mid"))
                End If

                ' get Key
                If Not IsNothing(Request.QueryString("def")) Then
                    Key = Request.QueryString("def") ' old syntax
                End If
                If Not IsNothing(Request.QueryString("ctl")) Then
                    Key = Request.QueryString("ctl") ' new syntax
                End If

                ' initialize module settings
                Dim _moduleSettings As New ModuleSettings
                _moduleSettings.ModuleId = ModuleId
                _moduleSettings.ModuleDefId = -1
                _moduleSettings.TabId = _portalSettings.ActiveTab.TabId
                _moduleSettings.ModuleTitle = ""
                _moduleSettings.PaneName = glbDefaultPane
                _moduleSettings.ShowTitle = True
                _moduleSettings.Personalize = 2
                _moduleSettings.AuthorizedEditRoles = ""
                _moduleSettings.AuthorizedViewRoles = ""

                ' get master module settings
                If ModuleId <> -1 Then
                    objModule = objModules.GetModule(ModuleId)
                    If Not IsNothing(objModule) Then
                        _moduleSettings.ModuleDefId = objModule.ModuleDefID
                        _moduleSettings.TabId = objModule.TabID
                        _moduleSettings.AuthorizedEditRoles = objModule.AuthorizedEditRoles
                        If objModule.AuthorizedViewRoles = "" Then
                            _moduleSettings.AuthorizedViewRoles = objModule.AuthorizedRoles
                        Else
                            _moduleSettings.AuthorizedViewRoles = objModule.AuthorizedViewRoles
                        End If
                    End If
                End If

                ' get the pane
                Dim parent As Control = Me.FindControl(glbDefaultPane)

                ' load the controls
                Dim objModuleControls As New ModuleControlController
                Dim objModuleControl As ModuleControlInfo
                Dim intCounter As Integer

                Dim arrModuleControls As ArrayList = objModuleControls.GetModuleControlsByKey(Key, _moduleSettings.ModuleDefId)

                For intCounter = 0 To arrModuleControls.Count - 1

                    objModuleControl = CType(arrModuleControls(intCounter), ModuleControlInfo)

                    ' initialize control values
                    _moduleSettings.ControlSrc = objModuleControl.ControlSrc
                    _moduleSettings.ControlType = objModuleControl.ControlType
                    _moduleSettings.IconFile = objModuleControl.IconFile
                    _moduleSettings.ShowTitle = False
                    If Not Null.IsNull(objModuleControl.ControlTitle) Then
                        _moduleSettings.ModuleTitle = objModuleControl.ControlTitle
                    Else
                        If Not objModule Is Nothing Then
                            _moduleSettings.ModuleTitle = objModule.ModuleTitle
                        End If
                    End If

                    ' verify that the current user has access to this control
                    Dim blnAuthorized As Boolean = True
                    Select Case _moduleSettings.ControlType
                        Case SecurityAccessLevel.Anonymous  ' anonymous
                        Case SecurityAccessLevel.View  ' view
                            If PortalSecurity.IsInRole(_portalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                                If Not PortalSecurity.IsInRoles(_moduleSettings.AuthorizedViewRoles) Then
                                    blnAuthorized = False
                                End If
                            End If
                        Case SecurityAccessLevel.Edit  ' edit
                            If PortalSecurity.IsInRole(_portalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                                If Not PortalSecurity.IsInRoles(_moduleSettings.AuthorizedViewRoles) Then
                                    blnAuthorized = False
                                Else
                                    If Not PortalSecurity.HasEditPermissions(ModuleId) Then
                                        blnAuthorized = False
                                    End If
                                End If
                            End If
                        Case SecurityAccessLevel.Admin  ' admin
                            If PortalSecurity.IsInRole(_portalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles.ToString) = False Then
                                blnAuthorized = False
                            End If
                        Case SecurityAccessLevel.Host  ' host
                            If Not Context.User.Identity.Name Is Nothing Then
                                If CType(Context.User.Identity.Name, String) <> _portalSettings.SuperUserId Then
                                    blnAuthorized = False
                                End If
                            Else ' no longer logged in
                                blnAuthorized = False
                            End If
                    End Select

                    If blnAuthorized Then
                        ' inject the module into the skin
                        InjectModule(parent, _moduleSettings, _portalSettings)
                    Else
                        Skin.AddPageMessage(Me, "", "Bạn không có quyền truy cập vào chức năng này.", Skins.ModuleMessage.ModuleMessageType.YellowWarning)
                    End If

                Next

            End If

            If Not blnLayoutMode Then
                CollapseUnusedPanes()
            End If

            If Not Request.QueryString("error") Is Nothing Then
                Skin.AddPageMessage(Me, "A critical error has occurred.", Server.HtmlEncode(Request.QueryString("error")), Skins.ModuleMessage.ModuleMessageType.RedError)
            End If

        End Sub
        Private Sub CollapseUnusedPanes()
            'This method sets the width to "0" on panes that have no modules.
            'This preserves the integrity of the HTML syntax so we don't have to set
            'the visiblity of a pane to false. Setting the visibility of a pane to
            'false where there are colspans and rowspans can render the skin incorrectly.

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            Dim ctlPane As Control
            Dim strPane As String
            For Each strPane In _portalSettings.Panes
                ctlPane = Me.FindControl(strPane)
                If Not ctlPane Is Nothing Then
                    If Not ctlPane.HasControls Then
                        'This pane has no controls so set the width to 0
                        Dim objHtmlControl As HtmlControl = CType(ctlPane, HtmlControl)
                        objHtmlControl.Attributes.Item("width") = "0"
                        If Not objHtmlControl.Attributes.Item("style") Is Nothing Then
                            objHtmlControl.Attributes.Remove("style")
                        End If
                    ElseIf ctlPane.Controls.Count = 1 Then
                        'this pane has one control, check to see if it's the pane name label
                        If ctlPane.Controls(0).GetType Is GetType(Label) Then
                            'the only control in this pane is some type of label
                            If CType(ctlPane.Controls(0), Label).Text.LastIndexOf(ctlPane.ID) > 0 Then
                                'the "pane name" is the only control in this pane
                                'so, since there are no other controls, resize the pane to width="0"
                                Dim objHtmlControl As HtmlControl = CType(ctlPane, HtmlControl)
                                objHtmlControl.Attributes.Item("width") = "0"
                                If Not objHtmlControl.Attributes.Item("style") Is Nothing Then
                                    objHtmlControl.Attributes.Remove("style")
                                End If

                                'hide the pane name label
                                Dim objLabel As Label = CType(ctlPane.Controls(0), Label)
                                objLabel.Visible = False
                            End If
                        End If
                    End If
                End If
            Next
        End Sub
        Private Sub InjectModule(ByVal objPane As Control, ByVal ModuleSettings As ModuleSettings, ByVal PortalSettings As PortalSettings)
            Try

                Dim objPortalModuleControl As PortalModuleControl

                ' load container control
                Dim ctlContainer As UserControl

                ' if showtitle is false then use the notitle container
                If ModuleSettings.ShowTitle = False Then
                    ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/_default/"
                    ModuleSettings.ContainerSrc = "notitle.ascx"
                    ctlContainer = LoadContainer("~" & ModuleSettings.ContainerPath.Remove(0, Len(Global.ApplicationPath)) & ModuleSettings.ContainerSrc, objPane)
                End If

                ' container preview
                If ctlContainer Is Nothing Then
                    Dim PreviewModuleId As Integer = -1
                    If Not Request.QueryString("ModuleId") Is Nothing Then
                        PreviewModuleId = Integer.Parse(Request.QueryString("ModuleId"))
                    End If
                    If (Not Request.QueryString("ContainerType") Is Nothing) And (Not Request.QueryString("ContainerName") Is Nothing) And (Not Request.QueryString("ContainerSrc") Is Nothing) And (ModuleSettings.ModuleId <> PreviewModuleId Or PreviewModuleId <> -1) Then
                        Select Case Request.QueryString("ContainerType")
                            Case "G" ' global
                                ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/" & Request.QueryString("ContainerName") & "/"
                            Case "L" ' local
                                ModuleSettings.ContainerPath = PortalSettings.UploadDirectory & SkinInfo.RootContainer & "/" & Request.QueryString("ContainerName") & "/"
                        End Select
                        ModuleSettings.ContainerSrc = Request.QueryString("ContainerSrc")
                        ctlContainer = LoadContainer("~" & ModuleSettings.ContainerPath.Remove(0, Len(Global.ApplicationPath)) & ModuleSettings.ContainerSrc, objPane)
                    End If
                End If

                ' if this is not a container assigned to a module
                If ctlContainer Is Nothing Then
                    If ModuleSettings.ContainerModuleId <> ModuleSettings.ModuleId Then
                        ' look for a container specification in the skin pane
                        If TypeOf objPane Is HtmlControl Then
                            Dim objHtmlControl As HtmlControl = CType(objPane, HtmlControl)
                            If (Not objHtmlControl.Attributes("ContainerType") Is Nothing) And (Not objHtmlControl.Attributes("ContainerName") Is Nothing) And (Not objHtmlControl.Attributes("ContainerSrc") Is Nothing) Then
                                Select Case objHtmlControl.Attributes("ContainerType")
                                    Case "G" ' global
                                        ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/" & objHtmlControl.Attributes("ContainerName") & "/"
                                    Case "L" ' local
                                        ModuleSettings.ContainerPath = PortalSettings.UploadDirectory & SkinInfo.RootContainer & "/" & objHtmlControl.Attributes("ContainerName") & "/"
                                End Select
                                ModuleSettings.ContainerSrc = objHtmlControl.Attributes("ContainerSrc")
                                ctlContainer = LoadContainer("~" & ModuleSettings.ContainerPath.Remove(0, Len(Global.ApplicationPath)) & ModuleSettings.ContainerSrc, objPane)
                            End If
                        End If
                    End If
                End If

                ' else load assigned container
                If ctlContainer Is Nothing Then
                    If IsAdminControl() Then
                        ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/_default/"
                        ModuleSettings.ContainerSrc = "default.ascx"

                        Dim objSkins As New SkinController
                        Dim objSkin As SkinInfo
                        objSkin = objSkins.GetSkin(SkinInfo.RootContainer, PortalSettings.PortalId, PortalSettings.ActiveTab.TabId, ModuleSettings.ModuleId, True)
                        If Not objSkin Is Nothing Then
                            Select Case objSkin.SkinType
                                Case "G" ' global
                                    ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/" & objSkin.SkinName & "/"
                                Case "L" ' local
                                    ModuleSettings.ContainerPath = PortalSettings.UploadDirectory & SkinInfo.RootContainer & "/" & objSkin.SkinName & "/"
                            End Select
                            ModuleSettings.ContainerSrc = objSkin.SkinSrc
                        End If
                    Else
                        If ModuleSettings.ContainerPath = "" Or ModuleSettings.ContainerSrc = "" Then
                            ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/_default/"
                            ModuleSettings.ContainerSrc = "default.ascx"
                        End If
                    End If
                    ctlContainer = LoadContainer("~" & ModuleSettings.ContainerPath.Remove(0, Len(Global.ApplicationPath)) & ModuleSettings.ContainerSrc, objPane)
                End If

                ' error loading container - load default
                If ctlContainer Is Nothing Then
                    ModuleSettings.ContainerPath = Global.HostPath & SkinInfo.RootContainer & "/_default/"
                    ModuleSettings.ContainerSrc = "default.ascx"
                    ctlContainer = LoadContainer("~" & ModuleSettings.ContainerPath.Remove(0, Len(Global.ApplicationPath)) & ModuleSettings.ContainerSrc, objPane)
                End If

                ' page style sheet reference
                Dim objCSS As Control = Page.FindControl("CSS")
                Dim objLink As HtmlGenericControl
                Dim ID As String

                Dim objCSSCache As Hashtable = CType(DataCache.GetCache("CSS"), Hashtable)
                If objCSSCache Is Nothing Then
                    objCSSCache = New Hashtable
                End If

                ' container stylesheet
                If Not objCSS Is Nothing Then

                    ' container package style sheet
                    ID = CreateValidID(ModuleSettings.ContainerPath)
                    If objCSSCache.ContainsKey(ID) = False Then
                        If File.Exists(Server.MapPath(ModuleSettings.ContainerPath) & "container.css") Then
                            objCSSCache(ID) = ModuleSettings.ContainerPath & "container.css"
                        Else
                            objCSSCache(ID) = ""
                        End If
                        DataCache.SetCache("CSS", objCSSCache)
                    End If
                    If objCSSCache(ID).ToString <> "" Then
                        If objCSS.FindControl(ID) Is Nothing Then
                            objLink = New HtmlGenericControl("LINK")
                            objLink.ID = ID
                            objLink.Attributes("rel") = "stylesheet"
                            objLink.Attributes("type") = "text/css"
                            objLink.Attributes("href") = objCSSCache(ID).ToString
                            objCSS.Controls.Add(objLink)
                        End If
                    End If

                    ' container file style sheet
                    ID = CreateValidID(ModuleSettings.ContainerPath & ModuleSettings.ContainerSrc.Replace(".ascx", ""))
                    If objCSSCache.ContainsKey(ID) = False Then
                        If File.Exists(Server.MapPath(ModuleSettings.ContainerPath) & Replace(ModuleSettings.ContainerSrc, ".ascx", ".css")) Then
                            objCSSCache(ID) = ModuleSettings.ContainerPath & Replace(ModuleSettings.ContainerSrc, ".ascx", ".css")
                        Else
                            objCSSCache(ID) = ""
                        End If
                        DataCache.SetCache("CSS", objCSSCache)
                    End If
                    If objCSSCache(ID).ToString <> "" Then
                        If objCSS.FindControl(ID) Is Nothing Then
                            objLink = New HtmlGenericControl("LINK")
                            objLink.ID = ID
                            objLink.Attributes("rel") = "stylesheet"
                            objLink.Attributes("type") = "text/css"
                            objLink.Attributes("href") = objCSSCache(ID).ToString
                            objCSS.Controls.Add(objLink)
                        End If
                    End If
                End If

                ' get container pane
                Dim objCell As Control = ctlContainer.FindControl(glbDefaultPane)
                Dim EditText As String = ""
                Dim DisplayOptions As Boolean = False

                If Not objCell Is Nothing Then
                    ' set container display properties
                    If TypeOf objCell Is HtmlTableCell Then
                        If ModuleSettings.Alignment <> "" Then
                            CType(objCell, HtmlTableCell).Align = ModuleSettings.Alignment
                        End If
                        If ModuleSettings.Color <> "" Then
                            CType(objCell, HtmlTableCell).BgColor = ModuleSettings.Color
                        End If
                        If ModuleSettings.Border <> "" Then
                            CType(objCell, HtmlTableCell).Attributes.Add("border", ModuleSettings.Border)
                        End If
                    End If

                    ' inject a start comment around the module content
                    If ModuleSettings.ModuleId <> -1 Then
                        objCell.Controls.Add(New LiteralControl("<!-- Start_Module_" & ModuleSettings.ModuleId.ToString & " -->"))
                    End If

                    ' inject a message placeholder for common module messaging - Skin.AddModuleMessage
                    Dim MessagePlaceholder As New PlaceHolder
                    MessagePlaceholder.ID = "MessagePlaceHolder"
                    MessagePlaceholder.Visible = False
                    objCell.Controls.Add(MessagePlaceholder)

                    ' create a wrapper panel control for the module content min/max
                    Dim objPanel As New Panel
                    objPanel.ID = "ModuleContent"

                    ' module content visibility options
                    Dim blnContent As Boolean = True
                    If Not Request.Cookies("_Tab_Admin_Content" & PortalSettings.PortalId.ToString) Is Nothing Then
                        blnContent = Boolean.Parse(Request.Cookies("_Tab_Admin_Content" & PortalSettings.PortalId.ToString).Value)
                    End If
                    If Not Request.QueryString("content") Is Nothing Then
                        Select Case Request.QueryString("Content").ToLower
                            Case "1", "true"
                                blnContent = True
                            Case "0", "false"
                                blnContent = False
                        End Select
                    End If
                    If IsAdminControl() = True Or IsAdminTab(PortalSettings.ActiveTab.TabId, PortalSettings.ActiveTab.ParentId) = True Then
                        blnContent = True
                    End If

                    ' try to load the module user control
                    Try
                        If blnContent Then
                            ' if the module has caching and we are not in admin mode
                            If ModuleSettings.CacheTime <> 0 And (PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(PortalSettings.ActiveTab.AdministratorRoles.ToString) = False) Then
                                ' use output caching
                                objPortalModuleControl = New PortalModuleControl
                            Else ' load the control dynamically
                                objPortalModuleControl = CType(Me.LoadControl("~/" & ModuleSettings.ControlSrc), PortalModuleControl)
                            End If
                        Else ' content placeholder
                            objPortalModuleControl = CType(Me.LoadControl("~/admin/Portal/NoContent.ascx"), PortalModuleControl)
                        End If

                        'check for IMC
                        objCommunicator.LoadCommunicator(objPortalModuleControl)

                        ' add module settings
                        objPortalModuleControl.ModuleConfiguration = ModuleSettings
                    Catch exc As Threading.ThreadAbortException
                        Threading.Thread.ResetAbort()
                    Catch exc As Exception
                        Dim lex As New ModuleLoadException("Unhandled Error	Loading	Module", exc)
                        objPanel.Controls.Add(New ErrorContainer(PortalSettings, "Error loading module", lex).Container)
                        Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                        Err.Clear()
                    End Try

                    ' module user control processing
                    If Not objPortalModuleControl Is Nothing Then

                        ' inject the module into the panel
                        objPanel.Controls.Add(objPortalModuleControl)
                    End If

                    ' inject the panel into the container pane
                    objCell.Controls.Add(objPanel)

                    ' force the CreateChildControls() event to fire for the PortalModuleControl ( the timing is critical for output caching )
                    objPortalModuleControl.FindControl("")

                    ' disable legacy controls in module 
                    If Not objPortalModuleControl Is Nothing Then
                        Dim objDesktopModuleTitle As DesktopModuleTitle = CType(FindTitleControl(objPortalModuleControl), DesktopModuleTitle)
                        If Not objDesktopModuleTitle Is Nothing Then
                            EditText = objDesktopModuleTitle.EditText
                            DisplayOptions = objDesktopModuleTitle.DisplayOptions
                            objDesktopModuleTitle.Visible = False
                        End If
                        Dim objModuleContent As Panel = CType(objPortalModuleControl.FindControl("ModuleContent"), Panel)
                        If Not objModuleContent Is Nothing Then
                            objModuleContent.Visible = False
                        End If
                    End If

                    ' inject an end comment around the module content
                    If ModuleSettings.ModuleId <> -1 Then
                        objPanel.Controls.Add(New LiteralControl("<!-- End_Module_" & ModuleSettings.ModuleId.ToString & " -->"))
                    End If

                End If

                ' inject the container into the page pane - this triggers the Pre_Init() event for the user control
                objPane.Controls.Add(ctlContainer)

                ' process the base class module properties set in Pre_Init() for user control
                If Not objPortalModuleControl Is Nothing Then

                    ' find the action control for the container
                    Dim objActions As Containers.ActionBase = CType(FindActionControl(ctlContainer), Containers.ActionBase)

                    ' custom module actions
                    If Not objActions Is Nothing Then
                        Dim arrActions As ModuleActionCollection = objPortalModuleControl.Actions
                        objActions.AssociatedModuleSettings = objPortalModuleControl.ModuleConfiguration
                        If Not arrActions Is Nothing Then
                            If arrActions.Count = 0 Then
                                ' legacy module display options
                                If DisplayOptions Then
                                    objActions.AddAction("Display Options", "", "", "view.gif", objPortalModuleControl.EditURL() & "&options=1", Secure:=SecurityAccessLevel.Edit, Visible:=objActions.EditMode)
                                End If
                                ' legacy module action
                                If EditText <> "" Then
                                    objActions.AddAction(EditText, "", "", "add.gif", objPortalModuleControl.EditURL(), Secure:=SecurityAccessLevel.Edit, Visible:=objActions.EditMode)
                                End If
                            Else ' module actions
                                objActions.MenuActions.AddRange(arrActions)
                            End If
                        End If

                        AddHandler objActions.Action, AddressOf ModuleAction_Click
                    End If

                    ' module stylesheet
                    ID = CreateValidID(Global.ApplicationPath & "/" & ModuleSettings.ControlSrc.Substring(0, ModuleSettings.ControlSrc.LastIndexOf("/")))
                    If objCSSCache.ContainsKey(ID) = False Then
                        If File.Exists(Server.MapPath(Global.ApplicationPath & "/" & ModuleSettings.ControlSrc.Substring(0, ModuleSettings.ControlSrc.LastIndexOf("/") + 1)) & "module.css") Then
                            objCSSCache(ID) = Global.ApplicationPath & "/" & ModuleSettings.ControlSrc.Substring(0, ModuleSettings.ControlSrc.LastIndexOf("/") + 1) & "module.css"
                        Else
                            objCSSCache(ID) = ""
                        End If
                        DataCache.SetCache("CSS", objCSSCache)
                    End If
                    If objCSSCache(ID).ToString <> "" Then
                        If Not objCSS Is Nothing Then
                            If objCSS.FindControl(ID) Is Nothing Then
                                objLink = New HtmlGenericControl("LINK")
                                objLink.ID = ID
                                objLink.Attributes("rel") = "stylesheet"
                                objLink.Attributes("type") = "text/css"
                                objLink.Attributes("href") = objCSSCache(ID).ToString
                                objCSS.Controls.AddAt(0, objLink)
                            End If
                        End If
                    End If

                End If

                ' display collapsible page panes
                If objPane.Visible = False Then
                    objPane.Visible = True
                End If

            Catch exc As Exception

                objPane.Controls.Clear()

                Dim lex As ModuleLoadException
                lex = New ModuleLoadException("Unhandled Error Adding Module to	" + objPane.ID.ToString, exc)
                objPane.Controls.Add(New ErrorContainer(PortalSettings, "Error loading module", lex).Container)
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                Err.Clear()

            End Try

        End Sub


        Public Sub ModuleAction_Click(ByVal sender As Object, ByVal e As ActionEventArgs)
            'Search through the listeners
            Dim Listener As ModuleActionEventListener
            For Each Listener In ActionEventListeners

                'If the associated module has registered a listener
                If e.AssociatedModule.ModuleId = Listener.ModuleID Then

                    'Invoke the listener to handle the ModuleAction_Click event
                    Listener.ActionEvent.Invoke(sender, e)
                End If
            Next
        End Sub

        Public Shared Function GetParentSkin(ByVal objModule As PortalModuleControl) As Skin
            Dim MyParent As System.Web.UI.Control = objModule.Parent
            Dim FoundSkin As Boolean = False
            While Not MyParent Is Nothing
                If TypeOf MyParent Is Skin Then
                    FoundSkin = True
                    Exit While
                End If
                MyParent = MyParent.Parent
            End While
            If FoundSkin Then
                Return DirectCast(MyParent, Skin)
            Else
                Return Nothing
            End If
        End Function

        Public Property ActionEventListeners() As ArrayList
            Get
                If _actionEventListeners Is Nothing Then
                    _actionEventListeners = New ArrayList
                End If
                Return _actionEventListeners
            End Get
            Set(ByVal Value As ArrayList)
                _actionEventListeners = Value
            End Set
        End Property

        Public Sub RegisterModuleActionEvent(ByVal ModuleID As Integer, ByVal e As ActionEventHandler)
            ActionEventListeners.Add(New ModuleActionEventListener(ModuleID, e))
        End Sub


        Public Shared Sub AddModuleMessage(ByVal objPortalModuleControl As PortalModuleControl, ByVal Message As String, ByVal objModuleMessageType As Skins.ModuleMessage.ModuleMessageType)
            AddModuleMessage(objPortalModuleControl, "", Message, objModuleMessageType)
        End Sub
        Public Shared Sub AddModuleMessage(ByVal objPortalModuleControl As PortalModuleControl, ByVal Heading As String, ByVal Message As String, ByVal objModuleMessageType As Skins.ModuleMessage.ModuleMessageType)
            If Not objPortalModuleControl Is Nothing Then
                If Message <> "" Then
                    Dim MessagePlaceHolder As PlaceHolder = CType(objPortalModuleControl.Parent.FindControl("MessagePlaceHolder"), PlaceHolder)
                    If Not MessagePlaceHolder Is Nothing Then
                        MessagePlaceHolder.Visible = True
                        Dim objModuleMessage As Skins.ModuleMessage
                        objModuleMessage = GetModuleMessageControl(Heading, Message, objModuleMessageType)
                        MessagePlaceHolder.Controls.Add(objModuleMessage)
                    End If
                End If
            End If
        End Sub
        Public Shared Sub AddModuleMessage(ByVal objPortalModuleControl As PortalModuleControl, ByVal Heading As String, ByVal Message As String, ByVal IconSrc As String)
            If Not objPortalModuleControl Is Nothing Then
                If Message <> "" Then
                    Dim MessagePlaceHolder As PlaceHolder = CType(objPortalModuleControl.Parent.FindControl("MessagePlaceHolder"), PlaceHolder)
                    If Not MessagePlaceHolder Is Nothing Then
                        MessagePlaceHolder.Visible = True
                        Dim objModuleMessage As Skins.ModuleMessage
                        objModuleMessage = GetModuleMessageControl(Heading, Message, IconSrc)
                        MessagePlaceHolder.Controls.Add(objModuleMessage)
                    End If
                End If
            End If
        End Sub
        Public Shared Function GetModuleMessageControl(ByVal Heading As String, ByVal Message As String, ByVal IconImage As String) As Skins.ModuleMessage
            'Use this to get a module message control
            'with a custom image for an icon
            Dim objModuleMessage As Skins.ModuleMessage
            Dim s As New Skin
            objModuleMessage = CType(s.LoadControl("~/admin/skins/ModuleMessage.ascx"), Skins.ModuleMessage)
            objModuleMessage.Heading = Heading
            objModuleMessage.Text = Message
            objModuleMessage.IconImage = IconImage
            Return objModuleMessage
        End Function
        Public Shared Function GetModuleMessageControl(ByVal Heading As String, ByVal Message As String, ByVal objModuleMessageType As Skins.ModuleMessage.ModuleMessageType) As Skins.ModuleMessage
            'Use this to get a module message control
            'with a standard PortalQH icon
            Dim objModuleMessage As Skins.ModuleMessage
            Dim s As New Skin
            objModuleMessage = CType(s.LoadControl("~/admin/skins/ModuleMessage.ascx"), Skins.ModuleMessage)
            objModuleMessage.Heading = Heading
            objModuleMessage.Text = Message
            objModuleMessage.IconType = objModuleMessageType
            Return objModuleMessage
        End Function
        Public Shared Sub AddPageMessage(ByVal objPage As Page, ByVal Heading As String, ByVal Message As String, ByVal IconSrc As String)

            If Message <> "" Then
                Dim ContentPane As Control = CType(objPage.FindControl(glbDefaultPane), Control)
                If Not ContentPane Is Nothing Then
                    Dim objModuleMessage As Skins.ModuleMessage
                    objModuleMessage = GetModuleMessageControl(Heading, Message, IconSrc)
                    ContentPane.Controls.AddAt(0, objModuleMessage)
                End If
            End If
        End Sub
        Public Shared Sub AddPageMessage(ByVal objSkin As Skin, ByVal Heading As String, ByVal Message As String, ByVal IconSrc As String)

            If Message <> "" Then
                Dim ContentPane As Control = CType(objSkin.FindControl(glbDefaultPane), Control)
                If Not ContentPane Is Nothing Then
                    Dim objModuleMessage As Skins.ModuleMessage
                    objModuleMessage = GetModuleMessageControl(Heading, Message, IconSrc)
                    ContentPane.Controls.AddAt(0, objModuleMessage)
                End If
            End If

        End Sub
        Public Shared Sub AddPageMessage(ByVal objSkin As Skin, ByVal Heading As String, ByVal Message As String, ByVal objModuleMessageType As Skins.ModuleMessage.ModuleMessageType)

            If Message <> "" Then
                Dim ContentPane As Control = CType(objSkin.FindControl(glbDefaultPane), Control)
                If Not ContentPane Is Nothing Then
                    Dim objModuleMessage As Skins.ModuleMessage
                    objModuleMessage = GetModuleMessageControl(Heading, Message, objModuleMessageType)
                    ContentPane.Controls.AddAt(0, objModuleMessage)
                End If
            End If

        End Sub
        Public Shared Sub AddPageMessage(ByVal objPage As Page, ByVal Heading As String, ByVal Message As String, ByVal objModuleMessageType As Skins.ModuleMessage.ModuleMessageType)

            If Message <> "" Then
                Dim ContentPane As Control = CType(objPage.FindControl(glbDefaultPane), Control)
                If Not ContentPane Is Nothing Then
                    Dim objModuleMessage As Skins.ModuleMessage
                    objModuleMessage = GetModuleMessageControl(Heading, Message, objModuleMessageType)
                    ContentPane.Controls.AddAt(0, objModuleMessage)
                End If
            End If
        End Sub
        Private Function FindActionControl(ByVal objContainer As Control) As Control

            Dim objChildControl As Control

            For Each objChildControl In objContainer.Controls

                ' check if control is an action control
                If TypeOf objChildControl Is Containers.ActionBase Then
                    Return objChildControl
                End If

                If objChildControl.HasControls Then
                    ' recursive call for child controls
                    Dim objFoundControl As Control = FindActionControl(objChildControl)

                    If Not (objFoundControl Is Nothing) Then
                        Return objFoundControl
                    End If
                End If
            Next

            Return Nothing

        End Function

        Private Function FindTitleControl(ByVal objContainer As Control) As Control

            Dim objChildControl As Control

            For Each objChildControl In objContainer.Controls

                ' check if control is an action control
                If TypeOf objChildControl Is DesktopModuleTitle Then
                    Return objChildControl
                End If

                If objChildControl.HasControls Then
                    ' recursive call for child controls
                    Dim objFoundControl As Control = FindActionControl(objChildControl)

                    If Not (objFoundControl Is Nothing) Then
                        Return objFoundControl
                    End If
                End If
            Next

            Return Nothing

        End Function

        Private Function LoadContainer(ByVal ContainerPath As String, ByVal objPane As Control) As UserControl
            Dim ctlContainer As UserControl

            Try
                ctlContainer = CType(LoadControl(ContainerPath), UserControl)
            Catch exc As Exception
                ' could not load user control
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
                Dim lex As New ModuleLoadException("Unhandled Error	Loading	Module", exc)
                objPane.Controls.Add(New ErrorContainer(_portalSettings, "Could Not Load Container: " & ContainerPath, lex).Container)
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                Err.Clear()
            End Try

            Return ctlContainer
        End Function

    End Class
End Namespace
