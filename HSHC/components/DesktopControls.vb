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
Imports System.IO

Namespace PortalQH

    '*********************************************************************
    '
    ' PortalModuleControl Class
    '
    ' The PortalModuleControl class defines a custom base class inherited by all
    ' desktop portal modules within the Portal.
    ' 
    ' The PortalModuleControl class defines portal specific properties
    ' that are used by the portal framework to correctly display portal modules
    '
    '*********************************************************************

    Public Class PortalModuleControl
        Inherits UserControl

        ' Private field variables
        Private _isEditable As Integer = 0
        Private _moduleConfiguration As ModuleSettings
        Private _settings As Hashtable
        Private _helpfile As String
        Private _helpurl As String
        Private _actions As ModuleActionCollection
        Private _cachedOutput As String = ""

        'TODO: This is not good...  it is the same as whats in the Actions class
        'It will have to do until I have time to come back and fix it.
        'Joe Brinkman - 12/19/2003
        Public Const cMenuActionRoot As Integer = 200

        ' Public property accessors
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property ModuleId() As Integer

            Get
                If Not _moduleConfiguration Is Nothing Then
                    Return Convert.ToInt32(_moduleConfiguration.ModuleId)
                Else
                    Return Convert.ToInt32(Null.SetNull(ModuleId))
                End If
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property TabId() As Integer

            Get
                If Not _moduleConfiguration Is Nothing Then
                    Return Convert.ToInt32(_moduleConfiguration.TabId)
                Else
                    Return Convert.ToInt32(Null.SetNull(TabId))
                End If
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property PortalId() As Integer

            Get
                Return PortalSettings.PortalId
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property PortalAlias() As String

            Get
                Return PortalSettings.PortalAlias
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property IsEditable() As Boolean

            Get

                ' Perform tri-state switch check to avoid having to perform a security
                ' role lookup on every property access (instead caching the result)
                If _isEditable = 0 Then

                    ' Obtain PortalSettings from Current Context
                    Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                    Dim blnPreview As Boolean = False
                    If Not Request.Cookies("_Tab_Admin_Preview" & PortalId.ToString) Is Nothing Then
                        blnPreview = Boolean.Parse(Request.Cookies("_Tab_Admin_Preview" & PortalId.ToString).Value)
                    End If
                    If _portalSettings.ActiveTab.ParentId = _portalSettings.AdminTabId Or _portalSettings.ActiveTab.ParentId = _portalSettings.SuperTabId Then
                        blnPreview = False
                    End If

                    If blnPreview = False And (PortalSecurity.IsInRoles(_moduleConfiguration.AuthorizedEditRoles) = True Or PortalSecurity.IsInRoles(_portalSettings.ActiveTab.AdministratorRoles) = True) Then
                        _isEditable = 1
                    Else
                        _isEditable = 2
                    End If
                End If

                Return _isEditable = 1
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property EditURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String

            Get
                Dim strURL As String = ApplicationURL() & "&mid=" & ModuleId.ToString
                If ControlKey <> "" Then
                    strURL += "&ctl=" & ControlKey
                End If
                If KeyName <> "" And KeyValue <> "" Then
                    strURL += "&" & KeyName & "=" & KeyValue
                End If
                If PortalSettings.ActiveTab.TabId = PortalSettings.SuperTabId Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    'phuocdd: 25 Feb 2005, them condition de tranh them portalid vao request 2 lan
                    If Not KeyName.ToLower.Equals("portalid") Then
                        strURL += "&portalid=" & PortalSettings.ActiveTab.PortalId.ToString
                    End If
                End If
                Return strURL
            End Get

        End Property
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property GotoURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit", Optional ByVal OldControl As String = "") As String

            Get
                Dim strURL As String = ApplicationURL() & "&mid=" & ModuleId.ToString
                If ControlKey <> "" Then
                    strURL += "&ctl=" & ControlKey & "&oldctl=" & OldControl
                End If
                If KeyName <> "" And KeyValue <> "" Then
                    strURL += "&" & KeyName & "=" & KeyValue
                End If
                If PortalSettings.ActiveTab.TabId = PortalSettings.SuperTabId Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    'phuocdd: 25 Feb 2005, them condition de tranh them portalid vao request 2 lan
                    If Not KeyName.ToLower.Equals("portalid") Then
                        strURL += "&portalid=" & PortalSettings.ActiveTab.PortalId.ToString
                    End If
                End If
                Return strURL
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property NavigateURL(Optional ByVal ControlKey As String = "", Optional ByVal ID As String = "") As String

            Get
                Dim strURL As String = ApplicationURL()
                If ControlKey <> "" Then
                    strURL += "&ctl=" & ControlKey
                End If
                If ID <> "" Then
                    strURL += "&ID=" & ID
                End If
                If PortalSettings.ActiveTab.TabId = PortalSettings.SuperTabId Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    strURL += "&portalid=" & PortalSettings.ActiveTab.PortalId.ToString
                End If
                Return strURL
            End Get

        End Property
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property NavigateURLWithID(Optional ByVal ControlKey As String = "") As String

            Get
                Dim strURL As String = ApplicationURL()
                If ControlKey <> "" Then
                    strURL += "&ctl=" & ControlKey
                End If
                If PortalSettings.ActiveTab.TabId = PortalSettings.SuperTabId Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    strURL += "&portalid=" & PortalSettings.ActiveTab.PortalId.ToString
                End If
                Return strURL
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property ModuleConfiguration() As ModuleSettings

            Get
                Return _moduleConfiguration
            End Get
            Set(ByVal Value As ModuleSettings)
                _moduleConfiguration = Value
            End Set

        End Property


        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Settings() As Hashtable

            Get

                If _settings Is Nothing Then

                    _settings = PortalSettings.GetModuleSettings(ModuleId)
                End If

                Return _settings
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property PortalSettings() As PortalSettings

            Get
                PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property UserId() As Integer

            Get
                If HttpContext.Current.Request.IsAuthenticated Then
                    UserId = CType(HttpContext.Current.User.Identity.Name, Integer)
                Else
                    UserId = -1
                End If
            End Get

        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property Actions() As ModuleActionCollection

            Get
                If _actions Is Nothing Then
                    _actions = New ModuleActionCollection
                End If
                Return _actions
            End Get
            Set(ByVal Value As ModuleActionCollection)
                _actions = Value
            End Set

        End Property

        Public Property HelpFile() As String
            Get
                Return _helpfile
            End Get
            Set(ByVal Value As String)
                _helpfile = Value
            End Set
        End Property

        Public Property HelpURL() As String
            Get
                Return _helpurl
            End Get
            Set(ByVal Value As String)
                _helpurl = Value
            End Set
        End Property

        Protected Function GetNextActionID() As Integer
            Return cMenuActionRoot + Actions.Count
        End Function

        '*********************************************************************
        '
        ' CacheKey Property
        '
        ' The CacheKey property is used to calculate a "unique" cache key
        ' entry to be used to store/retrieve the portal module's content
        ' from the ASP.NET Cache.
        '
        '*********************************************************************

        Public ReadOnly Property CacheKey() As String

            Get
                Return "Key:" & Me.GetType().ToString() & Me.ModuleId & PortalSecurity.IsInRoles(_moduleConfiguration.AuthorizedEditRoles)
            End Get

        End Property


        '*********************************************************************
        '
        ' CreateChildControls Method
        '
        ' The CreateChildControls method is called when the ASP.NET Page Framework
        ' determines that it is time to instantiate a server control.
        ' 
        ' This method and attempts to resolve any previously cached output of the portal 
        ' module from the ASP.NET cache.  
        '
        ' If it doesn't find cached output from a previous request, then it will instantiate 
        ' and add the portal modules UserControl instance into the page tree.
        '
        '*********************************************************************

        Protected Overrides Sub CreateChildControls()

            If Not _moduleConfiguration Is Nothing Then

                ' if not in admin mode
                If PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleId.ToString) = False And PortalSecurity.IsInRoles(PortalSettings.ActiveTab.AdministratorRoles.ToString) = False Then

                    ' Attempt to resolve previously cached content from the ASP.NET Cache
                    If _moduleConfiguration.CacheTime <> 0 Then
                        _cachedOutput = Convert.ToString(DataCache.GetCache(CacheKey))
                    End If

                    ' If no cached content is found, then instantiate and add the portal
                    ' module user control into the portal's page server control tree
                    If _cachedOutput = "" And _moduleConfiguration.CacheTime > 0 Then

                        MyBase.CreateChildControls()

                        Dim objPortalModuleControl As PortalModuleControl = CType(Page.LoadControl(_moduleConfiguration.ControlSrc), PortalModuleControl)
                        objPortalModuleControl.ModuleConfiguration = Me.ModuleConfiguration

                        ' In skin.vb, the call to Me.Controls.Add(objPortalModuleControl) calls CreateChildControls() therefore
                        ' we need to indicate the control has already been created. We will manipulate the CacheTime property for this purpose. 
                        objPortalModuleControl.ModuleConfiguration.CacheTime = -(objPortalModuleControl.ModuleConfiguration.CacheTime)

                        Me.Controls.Add(objPortalModuleControl)

                    Else
                        ' restore the CacheTime property in preparation for the Render() event
                        If _moduleConfiguration.CacheTime < 0 Then
                            _moduleConfiguration.CacheTime = -(_moduleConfiguration.CacheTime)
                        End If
                    End If

                End If
            End If

        End Sub


        '*********************************************************************
        '
        ' Render Method
        '
        ' The Render method is called when the ASP.NET Page Framework
        ' determines that it is time to render content into the page output stream.
        ' 
        ' This method and captures the output generated by the portal module user control
        ' It then adds this content into the ASP.NET Cache for future requests.
        '
        '*********************************************************************

        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)

            If Not _moduleConfiguration Is Nothing Then

                ' If no caching is specified or in admin mode, render the child tree and return 
                If _moduleConfiguration.CacheTime = 0 Or (PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleId.ToString) = True Or PortalSecurity.IsInRoles(PortalSettings.ActiveTab.AdministratorRoles.ToString) = True) Then

                    MyBase.Render(output)

                Else '  output caching enabled

                    ' If no cached output was found from a previous request, render
                    ' child controls into a TextWriter, and then cache the results
                    ' in the ASP.NET Cache for future requests.
                    If _cachedOutput = "" Then

                        Dim tempWriter As StringWriter = New StringWriter
                        MyBase.Render(New HtmlTextWriter(tempWriter))
                        _cachedOutput = tempWriter.ToString()

                        DataCache.SetCache(CacheKey, _cachedOutput, DateTime.Now.AddSeconds(_moduleConfiguration.CacheTime))

                    End If

                    ' Output the user control's content
                    output.Write(_cachedOutput)
                End If

            Else

                MyBase.Render(output)

            End If

        End Sub

    End Class

End Namespace
