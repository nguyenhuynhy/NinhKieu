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

Namespace PortalQH.Skins

    Public Class SolPartMenu

        Inherits SkinObject

        ' public attributes
        Public [backcolor] As String
        Public [forecolor] As String
        Public [highlightcolor] As String
        Public [iconbackgroundcolor] As String
        Public [selectedbordercolor] As String
        Public [selectedcolor] As String
        Public [selectedforecolor] As String
        Public [display] As String
        Public [menubarheight] As String
        Public [menuborderwidth] As String
        Public [menuitemheight] As String
        Public [forcedownlevel] As String
        Public [moveable] As String
        Public [iconwidth] As String
        Public [menueffectsshadowcolor] As String
        Public [menueffectsmouseouthidedelay] As String
        Public [mouseouthidedelay] As String
        Public [menueffectsmouseoverdisplay] As String
        Public [menueffectsmouseoverexpand] As String
        Public [menueffectsstyle] As String
        Public [fontnames] As String
        Public [fontsize] As String
        Public [fontbold] As String
        Public [menueffectsshadowstrength] As String
        Public [menueffectsmenutransition] As String
        Public [menueffectsmenutransitionlength] As String
        Public [menueffectsshadowdirection] As String

        ' protected controls
        Protected WithEvents ctlMenu As SolpartWebControls.SolpartMenu

#Region " Web Form Designer Generated Code "


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '*******************************************************
        '
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try

                SetAttributes()

                ctlMenu.SeparateCSS = True

                ctlMenu.MenuCSS.MenuBar = "MainMenu_MenuBar"
                ctlMenu.MenuCSS.MenuContainer = "MainMenu_MenuContainer"
                ctlMenu.MenuCSS.MenuItem = "MainMenu_MenuItem"
                ctlMenu.MenuCSS.MenuIcon = "MainMenu_MenuIcon"
                ctlMenu.MenuCSS.SubMenu = "MainMenu_SubMenu"
                ctlMenu.MenuCSS.MenuBreak = "MainMenu_MenuBreak"
                ctlMenu.MenuCSS.MenuItemSel = "MainMenu_MenuItemSel"
                ctlMenu.MenuCSS.MenuArrow = "MainMenu_MenuArrow"
                ctlMenu.MenuCSS.RootMenuArrow = "MainMenu_RootMenuArrow"

                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim objTabs As New TabController

                ' Build list of tabs to be shown to user
                Dim authorizedTabs As New ArrayList
                Dim addedTabs As Integer = 0

                Dim i As Integer
                For i = 0 To _portalSettings.DesktopTabs.Count - 1

                    Dim tab As TabStripDetails = CType(_portalSettings.DesktopTabs(i), TabStripDetails)
                    If tab.IsVisible = True And tab.IsDeleted = False Then
                        If PortalSecurity.IsInRoles(tab.AuthorizedRoles) = True Then
                            authorizedTabs.Add(tab)
                            addedTabs += 1
                        End If
                    End If

                Next i

                ' generate dynamic menu
                ctlMenu.SystemImagesPath = Global.ApplicationPath & "/images/"
                ctlMenu.IconImagesPath = _portalSettings.UploadDirectory
                ctlMenu.ArrowImage = "breadcrumb.gif"
                ctlMenu.RootArrow = True
                ctlMenu.RootArrowImage = "menu_down.gif"
                ctlMenu.SystemScriptPath = Global.ApplicationPath & "/controls/SolpartMenu/"

                Dim objTab As TabStripDetails
                Dim objAttribute As System.Xml.XmlAttribute
                Dim objMenuItem As Solpart.WebControls.SPMenuItemNode

                For Each objTab In authorizedTabs
                    If objTab.ParentId = -1 Then ' root menu
                        If objTab.DisableLink Then
                            objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.TabId.ToString, objTab.TabName, ""))
                        Else
                            objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.TabId.ToString, objTab.TabName, objTab.URL))
                        End If

                        'add image next to selected item
                        If objTab.TabId = CType(_portalSettings.BreadCrumbs(0), TabStripDetails).TabId Then
                            'Lam noi bat root mene selected thay the cho image breadcrumb.gif
                            objMenuItem.LeftHTML = "<a class='QH_RootMenu' href='#'>"
                            'objMenuItem.LeftHTML += "<img alt=""*"" BORDER=""0"" src=""" & Global.ApplicationPath & "/images/breadcrumb.gif"">"
                            objMenuItem.LeftHTML += "&nbsp;"
                            objMenuItem.RightHTML = "</a>"
                        End If
                    Else
                            Try
                                If objTab.DisableLink Then
                                    objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.ParentId.ToString, objTab.TabId.ToString, "&nbsp;" & objTab.TabName, ""))
                                Else
                                    objMenuItem = New Solpart.WebControls.SPMenuItemNode(ctlMenu.AddMenuItem(objTab.ParentId.ToString, objTab.TabId.ToString, "&nbsp;" & objTab.TabName, objTab.URL))
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

        Private Sub SetAttributes()

            If [backcolor] <> "" Then
                ctlMenu.BackColor = Color.FromName([backcolor])
            End If
            If [forecolor] <> "" Then
                ctlMenu.ForeColor = Color.FromName([forecolor])
            End If
            If [highlightcolor] <> "" Then
                ctlMenu.HighlightColor = Color.FromName([highlightcolor])
            End If
            If [iconbackgroundcolor] <> "" Then
                ctlMenu.IconBackgroundColor = Color.FromName([iconbackgroundcolor])
            End If
            If [selectedbordercolor] <> "" Then
                ctlMenu.SelectedBorderColor = Color.FromName([selectedbordercolor])
            End If
            If [selectedcolor] <> "" Then
                ctlMenu.SelectedColor = Color.FromName([selectedcolor])
            End If
            If [selectedforecolor] <> "" Then
                ctlMenu.SelectedForeColor = Color.FromName([selectedforecolor])
            End If
            If [display] <> "" Then
                ctlMenu.Display = [display]
            End If
            If [menubarheight] <> "" Then
                ctlMenu.MenuBarHeight = Convert.ToInt64([menubarheight])
            End If
            If [menuborderwidth] <> "" Then
                ctlMenu.MenuBorderWidth = Convert.ToInt32([menuborderwidth])
            End If
            If [menuitemheight] <> "" Then
                ctlMenu.MenuItemHeight = Convert.ToInt64([menuitemheight])
            End If
            If [forcedownlevel] <> "" Then
                ctlMenu.ForceDownlevel = Convert.ToBoolean([forcedownlevel])
            End If
            If [moveable] <> "" Then
                ctlMenu.Moveable = Convert.ToBoolean([moveable])
            End If
            If [iconwidth] <> "" Then
                ctlMenu.IconWidth = Convert.ToInt64([iconwidth])
            End If
            If [menueffectsshadowcolor] <> "" Then
                ctlMenu.MenuEffects.ShadowColor = Color.FromName([menueffectsshadowcolor])
            End If
            If [menueffectsmouseouthidedelay] <> "" Then
                ctlMenu.MenuEffects.MouseOutHideDelay = Convert.ToInt32([menueffectsmouseouthidedelay])
            End If
            If [mouseouthidedelay] <> "" Then
                ctlMenu.MenuEffects.MouseOutHideDelay = Convert.ToInt32([mouseouthidedelay])
            End If
            If [menueffectsmouseoverdisplay] <> "" Then
                Select Case LCase([menueffectsmouseoverdisplay])
                    Case "highlight"
                        ctlMenu.MenuEffects.MouseOverDisplay = Solpart.WebControls.MenuEffectsMouseOverDisplay.Highlight
                    Case "none"
                        ctlMenu.MenuEffects.MouseOverDisplay = Solpart.WebControls.MenuEffectsMouseOverDisplay.None
                    Case "outset"
                        ctlMenu.MenuEffects.MouseOverDisplay = Solpart.WebControls.MenuEffectsMouseOverDisplay.Outset
                End Select
            End If
            If [menueffectsmouseoverexpand] <> "" Then
                ctlMenu.MenuEffects.MouseOverExpand = Convert.ToBoolean([menueffectsmouseoverexpand])
            End If
            If [menueffectsstyle] <> "" Then
                ctlMenu.MenuEffects.Style.Concat(ctlMenu.MenuEffects.Style.ToString, [menueffectsstyle])
            End If
            If [fontnames] <> "" Then
                ctlMenu.Font.Names = [fontnames].Split(Convert.ToChar(";"))
            End If
            If [fontsize] <> "" Then
                ctlMenu.Font.Size = FontUnit.Parse([fontsize])
            End If
            If [fontbold] <> "" Then
                ctlMenu.Font.Bold = Convert.ToBoolean([fontbold])
            End If
            If [menueffectsshadowstrength] <> "" Then
                ctlMenu.MenuEffects.ShadowStrength = Convert.ToInt32([menueffectsshadowstrength])
            End If
            If [menueffectsmenutransition] <> "" Then
                ctlMenu.MenuEffects.MenuTransition = [menueffectsmenutransition]
            End If
            If [menueffectsmenutransitionlength] <> "" Then
                ctlMenu.MenuEffects.MenuTransitionLength = Convert.ToDouble([menueffectsmenutransitionlength])
            End If
            If [menueffectsshadowdirection] <> "" Then
                ctlMenu.MenuEffects.ShadowDirection = [menueffectsshadowdirection]
            End If

        End Sub

    End Class

End Namespace
