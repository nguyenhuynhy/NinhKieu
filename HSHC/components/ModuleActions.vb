'
' Copyright (c) 2003-2004
' by Joe Brinkman ( joe.brinkman@tag-software.net ) of TAG Software, Inc. ( http://www.tag-software.net )
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

Namespace PortalQH

    '''-----------------------------------------------------------------------------
    ''' Project		: PortalQH
    ''' Class		: ModuleAction
    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' Each Module Action represents a separate functional action as defined by the
    ''' associated module.
    ''' </summary>
    ''' <remarks>A module action is used to define a specific function for a given module.
    ''' Each module can define one or more actions which the portal will present to the
    ''' user.  These actions may be presented as a menu, a dropdown list or even a group
    ''' of linkbuttons.
    ''' <seealso cref="T:PortalQH.ModuleActionCollection" /></remarks>
    ''' <history>
    ''' 	[Joe] 	10/9/2003	Created
    ''' </history>
    '''-----------------------------------------------------------------------------
    Public Class ModuleAction

        Private _actions As ModuleActionCollection
        Private _id As Integer
        Private _commandName As String
        Private _commandArgument As String
        Private _title As String
        Private _icon As String
        Private _url As String
        Private _useActionEvent As Boolean
        Private _secure As SecurityAccessLevel
        Private _visible As Boolean
        Private _newwindow As Boolean

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="T:PortalQH.ModuleAction"/> class
        ''' using the specified parameters
        ''' </summary>
        ''' <param name="ID">This is the identifier to use for this action.</param>
        ''' <param name="Title">This is the title that will be displayed for this action</param>
        ''' <param name="CmdName">The command name passed to the client when this action is 
        ''' clicked.</param>
        ''' <param name="CmdArg">The command argument passed to the client when this action is 
        ''' clicked.</param>
        ''' <param name="Icon">The URL of the Icon to place next to this action</param>
        ''' <param name="Url">The destination URL to redirect the client browser when this 
        ''' action is clicked.</param>
        ''' <param name="UseActionEvent">Determines whether client will receive an event
        ''' notification</param>
        ''' <param name="Secure">The security access level required for access to this action</param>
        ''' <param name="Visible">Whether this action will be displayed</param>
        ''' <remarks>The moduleaction constructor is used to set the various properties of 
        ''' the <see cref="T:PortalQH.ModuleAction" /> class at the time the instance is created.
        ''' </remarks>
        ''' <history>
        ''' 	[Joe] 	10/26/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub New(ByVal ID As Integer, ByVal Title As String, ByVal CmdName As String, Optional ByVal CmdArg As String = "", Optional ByVal Icon As String = "", Optional ByVal Url As String = "", Optional ByVal UseActionEvent As Boolean = False, Optional ByVal Secure As SecurityAccessLevel = SecurityAccessLevel.Anonymous, Optional ByVal Visible As Boolean = True, Optional ByVal NewWindow As Boolean = False)
            _id = ID
            _title = Title
            _commandName = CmdName
            _commandArgument = CmdArg
            _icon = Icon
            _url = Url
            _useActionEvent = UseActionEvent
            _secure = Secure
            _visible = Visible
            _newwindow = NewWindow
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the action node contains any child actions.
        ''' </summary>
        ''' <returns>True if child actions exist, false if child actions do not exist.</returns>
        ''' <remarks>Each action may contain one or more child actions in the
        ''' <see cref="P:PortalQH.ModuleAction.Actions"/> property.  When displayed via
        ''' the <see cref="T:PortalQH.Containers.Actions"/> control, these subactions are
        ''' shown as sub-menus.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/26/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Function HasChildren() As Boolean
            Return (Actions.Count > 0)
        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' The Actions property allows the user to create a heirarchy of actions, with
        ''' each action having sub-actions.
        ''' </summary>
        ''' <value>Returns a collection of ModuleActions.</value>
        ''' <remarks>Each action may contain one or more child actions.  When displayed via
        ''' the <see cref="T:PortalQH.Containers.Actions"/> control, these subactions are
        ''' shown as sub-menus.  If other Action controls are implemented, then
        ''' sub-actions may or may not be supported for that control type.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/26/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
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

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' A Module Action ID is a identifier that can be used in a Module Action Collection
        ''' to find a specific Action. 
        ''' </summary>
        ''' <value>The integer ID of the current <see cref="T:PortalQH.ModuleAction"/>.</value>
        ''' <remarks>When building a heirarchy of <see cref="T:PortalQH.ModuleAction">ModuleActions</see>, 
        ''' the ID is used to link the child and parent actions.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/18/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets whether the current action should be displayed.
        ''' </summary>
        ''' <value>A boolean value that determines if the current action should be displayed</value>
        ''' <remarks>If Visible is false, then the action is always hidden.  If Visible
        ''' is true then the action may be visible depending on the security access rights
        ''' specified by the <see cref="P:PortalQH.ModuleAction.Secure"/> property.  By
        ''' utilizing a custom method in your module, you can encapsulate specific business
        ''' rules to determine if the Action should be visible.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/26/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property Visible() As Boolean
            Get
                Return _visible
            End Get
            Set(ByVal Value As Boolean)
                _visible = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the value indicating the <see cref="T:PortalQH.SecurityAccessLevel" /> that is required
        ''' to access this <see cref="T:PortalQH.ModuleAction" />.
        ''' </summary>
        ''' <value>The value indicating the <see cref="T:PortalQH.SecurityAccessLevel" /> that is required
        ''' to access this <see cref="T:PortalQH.ModuleAction" /></value>
        ''' <remarks>The security access level determines the roles required by the current user in
        ''' order to access this module action.</remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/27/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property Secure() As SecurityAccessLevel
            Get
                Return _secure
            End Get
            Set(ByVal Value As SecurityAccessLevel)
                _secure = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' A Module Action CommandName represents a string used by the ModuleTitle to notify
        ''' the parent module that a given Module Action was selected in the Module Menu.
        ''' </summary>
        ''' <value>The name of the command to perform.</value>
        ''' <remarks>
        ''' Use the CommandName property to determine the command to perform. The CommandName 
        ''' property can contain any string set by the programmer. The programmer can then 
        ''' identify the command name in code and perform the appropriate tasks.
        ''' </remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property CommandName() As String
            Get
                Return _commandName
            End Get
            Set(ByVal Value As String)
                _commandName = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' A Module Action CommandArgument provides additional information and 
        ''' complements the CommandName.
        ''' </summary>
        ''' <value>A string that contains the argument for the command.</value>
        ''' <remarks>
        ''' The CommandArgument can contain any string set by the programmer. The 
        ''' CommandArgument property complements the <see cref="P:PortalQH.ModuleAction.CommandName" /> 
        '''  property by allowing you to provide any additional information for the command. 
        ''' For example, you can set the CommandName property to "Sort" and set the 
        ''' CommandArgument property to "Ascending" to specify a command to sort in ascending 
        ''' order.
        ''' </remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property CommandArgument() As String
            Get
                Return _commandArgument
            End Get
            Set(ByVal Value As String)
                _commandArgument = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the string that is displayed in the Module Menu
        ''' that represents a given menu action.
        ''' </summary>
        ''' <value>The string value that is displayed to represent the module action.</value>
        ''' <remarks>The title property is displayed by the Actions control for each module
        ''' action.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the URL for the icon file that is displayed for the given 
        ''' <see cref="T:PortalQH.ModuleAction" />.
        ''' </summary>
        ''' <value>The URL for the icon that is displayed with the module action.</value>
        ''' <remarks>The URL for the icon is a simple string and is not checked for formatting.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property Icon() As String
            Get
                Return _icon
            End Get
            Set(ByVal Value As String)
                _icon = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the URL to which the user is redirected when the 
        ''' associated Module Menu Action is selected.  
        ''' </summary>
        ''' <value>The URL to which the user is redirected when the 
        ''' associated Module Menu Action is selected.</value>
        ''' <remarks>If the URL is present then the Module Action Event is not fired.  
        ''' If the URL is empty then the Action Event is fired and is passed the value 
        ''' of the associated Command property.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property Url() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determines if a local ActionEvent is fired when the 
        ''' <see cref="T:PortalQH.ModuleAction" /> contains a URL. 
        ''' </summary>
        ''' <value>A boolean indicating whether to fire the ActionEvent.</value>
        ''' <remarks>When a MenuAction is clicked, an event is fired within the Actions 
        ''' control.  If the UseActionEvent is true then the Actions control will forward
        ''' the event to the parent skin which will then attempt to raise the event to
        ''' the appropriate module.  If the UseActionEvent is false, and the URL property
        ''' is set, then the Actions control will redirect the response to the URL.  In
        ''' all cases, an ActionEvent is raised if the URL is not set.</remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/22/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property UseActionEvent() As Boolean
            Get
                Return _useActionEvent
            End Get
            Set(ByVal Value As Boolean)
                _useActionEvent = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determines if a new window is opened when the 
        ''' DoAction() method is called. 
        ''' </summary>
        ''' <value>A boolean indicating whether to open a new window.</value>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/22/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Property NewWindow() As Boolean
            Get
                Return _newwindow
            End Get
            Set(ByVal Value As Boolean)
                _newwindow = Value
            End Set
        End Property

    End Class

    '''-----------------------------------------------------------------------------
    ''' Project		: PortalQH
    ''' Class		: ModuleActionCollection
    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' Represents a collection of <see cref="T:PortalQH.ModuleAction" /> objects.
    ''' </summary>
    ''' <remarks>The ModuleActionCollection is a custom collection of ModuleActions.
    ''' Each ModuleAction in the collection has it's own <see cref="P:PortalQH.ModuleAction.Actions" />
    '''  collection which provides the ability to create a heirarchy of ModuleActions.</remarks>
    ''' <history>
    ''' 	[Joe] 	10/9/2003	Created
    ''' </history>
    '''-----------------------------------------------------------------------------
    Public Class ModuleActionCollection
        Inherits CollectionBase

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new, empty instance of the <see cref="T:PortalQH.ModuleActionCollection" /> class.
        ''' </summary>
        ''' <remarks>The default constructor creates an empty collection of <see cref="T:PortalQH.ModuleAction" />
        '''  objects.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="T:PortalQH.ModuleActionCollection" />
        '''  class containing the elements of the specified source collection.
        ''' </summary>
        ''' <param name="value">A <see cref="T:PortalQH.ModuleActionCollection" /> with which to initialize the collection.</param>
        ''' <remarks>This overloaded constructor copies the <see cref="T:PortalQH.ModuleAction" />s
        '''  from the indicated collection.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub New(ByVal value As ModuleActionCollection)
            MyBase.New()
            AddRange(value)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="T:PortalQH.ModuleActionCollection" />
        '''  class containing the specified array of <see cref="T:PortalQH.ModuleAction" /> objects.
        ''' </summary>
        ''' <param name="value">An array of <see cref="T:PortalQH.ModuleAction" /> objects 
        ''' with which to initialize the collection. </param>
        ''' <remarks>This overloaded constructor copies the <see cref="T:PortalQH.ModuleAction" />s
        '''  from the indicated array.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub New(ByVal value As ModuleAction())
            MyBase.New()
            AddRange(value)
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the <see cref="T:PortalQH.ModuleActionCollection" /> at the 
        ''' specified index in the collection.
        ''' <para>
        ''' In VB.Net, this property is the indexer for the <see cref="T:PortalQH.ModuleActionCollection" /> class.
        ''' </para>
        ''' </summary>
        ''' <param name="index">The index of the collection to access.</param>
        ''' <value>A <see cref="T:PortalQH.ModuleAction" /> at each valid index.</value>
        ''' <remarks>This method is an indexer that can be used to access the collection.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Default Public Property Item(ByVal index As Integer) As ModuleAction
            Get
                Return CType(List(index), ModuleAction)
            End Get
            Set(ByVal Value As ModuleAction)
                List(index) = Value
            End Set
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Add an element of the specified <see cref="T:PortalQH.ModuleAction" /> to the end of the collection.
        ''' </summary>
        ''' <param name="value">An object of type <see cref="T:PortalQH.ModuleAction" /> to add to the collection.</param>
        ''' <returns>The index of the newly added <see cref="T:PortalQH.ModuleAction" /></returns>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Function Add(ByVal value As ModuleAction) As Integer
            Return List.Add(value)
        End Function 'Add

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Add an element of the specified <see cref="T:PortalQH.ModuleAction" /> to the end of the collection.
        ''' </summary>
        ''' <param name="ID">This is the identifier to use for this action.</param>
        ''' <param name="Title">This is the title that will be displayed for this action</param>
        ''' <param name="CmdName">The command name passed to the client when this action is 
        ''' clicked.</param>
        ''' <param name="CmdArg">The command argument passed to the client when this action is 
        ''' clicked.</param>
        ''' <param name="Icon">The URL of the Icon to place next to this action</param>
        ''' <param name="Url">The destination URL to redirect the client browser when this 
        ''' action is clicked.</param>
        ''' <param name="UseActionEvent">Determines whether client will receive an event
        ''' notification</param>
        ''' <param name="Secure">The security access level required for access to this action</param>
        ''' <param name="Visible">Whether this action will be displayed</param>
        ''' <returns>The index of the newly added <see cref="T:PortalQH.ModuleAction" /></returns>
        ''' <remarks>This method creates a new <see cref="T:PortalQH.ModuleAction" /> with the specified
        ''' values, adds it to the collection and returns the index of the newly created ModuleAction.</remarks>
        ''' <history>
        ''' 	[Joe] 	10/18/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Function Add(ByVal ID As Integer, ByVal Title As String, ByVal CmdName As String, Optional ByVal CmdArg As String = "", Optional ByVal Icon As String = "", Optional ByVal Url As String = "", Optional ByVal UseActionEvent As Boolean = False, Optional ByVal Secure As SecurityAccessLevel = SecurityAccessLevel.Anonymous, Optional ByVal Visible As Boolean = True, Optional ByVal NewWindow As Boolean = False) As ModuleAction
            Dim ModAction As ModuleAction = New ModuleAction(ID, Title, CmdName, CmdArg, Icon, Url, UseActionEvent, Secure, Visible, NewWindow)
            list.Add(ModAction)
            Return ModAction
        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the index in the collection of the specified <see cref="T:PortalQH.ModuleActionCollection" />, 
        ''' if it exists in the collection.
        ''' </summary>
        ''' <param name="value">The <see cref="T:PortalQH.ModuleAction" /> to locate in the collection.</param>
        ''' <returns>The index in the collection of the specified object, if found; otherwise, -1.</returns>
        ''' <example> This example tests for the presense of a ModuleAction in the
        ''' collection, and retrieves its index if it is found.
        ''' <code>
        '''   Dim testModuleAction = New ModuleAction(5, "Edit Action", "Edit")
        '''   Dim itemIndex As Integer = -1
        '''   If collection.Contains(testModuleAction) Then
        '''     itemIndex = collection.IndexOf(testModuleAction)
        '''   End If
        ''' </code>
        ''' </example>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Function IndexOf(ByVal value As ModuleAction) As Integer
            Return List.IndexOf(value)
        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Add an element of the specified <see cref="T:PortalQH.ModuleAction" /> to the 
        ''' collection at the designated index.
        ''' </summary>
        ''' <param name="index">An <see cref="T:system.int32">Integer</see> to indicate the location to add the object to the collection.</param>
        ''' <param name="value">An object of type <see cref="T:PortalQH.ModuleAction" /> to add to the collection.</param>
        ''' <example>
        ''' <code>
        ''' ' Inserts a ModuleAction at index 0 of the collection. 
        ''' collection.Insert(0, New ModuleAction(5, "Edit Action", "Edit"))
        ''' </code>
        ''' </example>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub Insert(ByVal index As Integer, ByVal value As ModuleAction)
            List.Insert(index, value)
        End Sub 'Insert

        '''----------------------------------------------------------------------------- 
        ''' <summary>
        ''' Remove the specified object of type <see cref="T:PortalQH.ModuleAction" /> from the collection.
        ''' </summary>
        ''' <param name="value">An object of type <see cref="T:PortalQH.ModuleAction" /> to remove from the collection.</param>
        ''' <example>
        ''' <code>
        ''' ' Removes the specified ModuleAction from the collection. 
        ''' Dim testModuleAction = New ModuleAction(5, "Edit Action", "Edit")
        ''' collection.Remove(testModuleAction)
        ''' </code>
        ''' </example>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub Remove(ByVal value As ModuleAction)
            List.Remove(value)
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value indicating whether the collection contains the specified <see cref="T:PortalQH.ModuleAction" />.
        ''' </summary>
        ''' <param name="value">The <see cref="T:PortalQH.ModuleAction" /> to search for in the collection.</param>
        ''' <returns><b>true</b> if the collection contains the specified object; otherwise, <b>false</b>.</returns>
        ''' <example>
        ''' <code>
        ''' ' Tests for the presence of a ModuleAction in the 
        ''' ' collection, and retrieves its index if it is found.
        ''' Dim testModuleAction = New ModuleAction(5, "Edit Action", "Edit")
        ''' Dim itemIndex As Integer = -1
        ''' If collection.Contains(testModuleAction) Then
        '''    itemIndex = collection.IndexOf(testModuleAction)
        ''' End If
        ''' </code>
        ''' </example>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Function Contains(ByVal value As ModuleAction) As Boolean
            ' If value is not of type ModuleAction, this will return false.
            Return List.Contains(value)
        End Function 'Contains

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Copies the elements of the specified <see cref="T:PortalQH.ModuleAction" />
        '''  array to the end of the collection.
        ''' </summary>
        ''' <param name="value">An array of type <see cref="T:PortalQH.ModuleAction" />
        '''  containing the objects to add to the collection.</param>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub AddRange(ByVal value As ModuleAction())
            Dim i As Integer
            For i = 0 To value.Length - 1
                Add(value(i))
            Next i
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Adds the contents of another <see cref="T:PortalQH.ModuleActionCollection" />
        '''  to the end of the collection.
        ''' </summary>
        ''' <param name="value">A <see cref="T:PortalQH.ModuleActionCollection" /> containing 
        ''' the objects to add to the collection. </param>
        ''' <history>
        ''' 	[Joe] 	10/9/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub AddRange(ByVal value As ModuleActionCollection)
            Dim i As Integer
            For i = 0 To value.Count - 1
                Add(CType(value.List(i), ModuleAction))
            Next i
        End Sub

    End Class

    '''-----------------------------------------------------------------------------
    ''' Project		: PortalQH
    ''' Class		: ActionEventArgs
    '''
    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' 	[Joe] 	10/26/2003	Created
    ''' </history>
    '''-----------------------------------------------------------------------------
    Public Class ActionEventArgs
        Inherits EventArgs

        Private _action As ModuleAction
        Private _moduleSettings As ModuleSettings

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ModAction"></param>
        ''' <param name="ModSettings"></param>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[Joe] 	10/26/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub New(ByVal ModAction As ModuleAction, ByVal ModSettings As ModuleSettings)
            _action = ModAction
            _moduleSettings = ModSettings
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[Joe] 	10/26/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public ReadOnly Property Action() As ModuleAction
            Get
                Return _action
            End Get
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/27/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public ReadOnly Property AssociatedModule() As ModuleSettings
            Get
                Return _moduleSettings
            End Get
        End Property

    End Class

    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''-----------------------------------------------------------------------------
    Public Delegate Sub ActionEventHandler(ByVal sender As Object, ByVal e As ActionEventArgs)

    '''-----------------------------------------------------------------------------
    ''' Project		: PortalQH
    ''' Class		: ModuleActionEventListener
    '''
    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' 	[jbrinkman] 	12/27/2003	Created
    ''' </history>
    '''-----------------------------------------------------------------------------
    Public Class ModuleActionEventListener
        Private _moduleID As Integer
        Private _actionEvent As ActionEventHandler

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ModID"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/27/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public Sub New(ByVal ModID As Integer, ByVal e As ActionEventHandler)
            _moduleID = ModID
            _actionEvent = e
        End Sub

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/27/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public ReadOnly Property ModuleID() As Integer
            Get
                Return _moduleID
            End Get
        End Property

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        ''' <history>
        ''' 	[jbrinkman] 	12/27/2003	Created
        ''' </history>
        '''-----------------------------------------------------------------------------
        Public ReadOnly Property ActionEvent() As ActionEventHandler
            Get
                Return _actionEvent
            End Get
        End Property

    End Class

End Namespace
