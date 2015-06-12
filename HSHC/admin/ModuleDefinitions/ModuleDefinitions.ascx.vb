'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Shaun Walker ( sales@perpetualmotion.ca ) of Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify,merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
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

    Public MustInherit Class ModuleDefinitions

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents grdDefinitions As System.Web.UI.WebControls.DataGrid

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

        '*******************************************************
        '
        ' The Page_Load server event handler on this user control is used
        ' to populate the current defs settings from the configuration system
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objTab As TabStripDetails
                For Each objTab In PortalSettings.DesktopTabs
                    If objTab.TabName = "File Manager" And objTab.ParentId = PortalSettings.SuperTabId Then
                        lblMessage.Text = "<a class=""CommandButton"" href=""" & Global.ApplicationPath & "/" & glbDefaultPage & "?tabid=" & objTab.TabId.ToString & """>File Manager</a>"
                    End If
                Next
                lblMessage.Text = "<b>NOTE:</b>&nbsp;&nbsp;You must use the " & lblMessage.Text & " to install your Custom Modules which are packaged as Private Assemblies.<br><br>"

                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        '*******************************************************
        '
        ' The BindData helper method is used to bind the list of
        ' module definitions for this portal to an asp:datalist server control
        '
        '*******************************************************

        Sub BindData()

            ' Get the portal's defs from the database
            Dim objDesktopModules As New DesktopModuleController

            Dim arr As ArrayList = objDesktopModules.GetDesktopModules()

            Dim objDesktopModule As New DesktopModuleInfo

            objDesktopModule.DesktopModuleID = -2
            objDesktopModule.FriendlyName = "[Skin Objects]"
            objDesktopModule.Description = "Skin Objects are User Controls which can be used to provide custom functionality to your Skin files."
            objDesktopModule.IsPremium = False

            arr.Insert(0, objDesktopModule)

            grdDefinitions.DataSource = arr
            grdDefinitions.DataBind()

        End Sub

    End Class

End Namespace
