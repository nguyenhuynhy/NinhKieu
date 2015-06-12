'
' PortalQH -  http://www.PortalQH.com
' Copyright (c) 2002-2004
' by Phil Beadle     ( phil.beadle@nexxus.com.au ), 
'    Mark Hoskins    ( dynst@xpdit.com ) and 
'    Scott Willhite  ( mrswoop@tough.net )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT ‘LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO ‘EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ‘ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR ‘OTHER 
' DEALINGS IN THE SOFTWARE.

Imports PortalQH

Namespace PortalQH.RecycleBin

    Public MustInherit Class RecycleBin

        Inherits PortalModuleControl

        Protected WithEvents lstTabs As System.Web.UI.WebControls.ListBox
        Protected WithEvents cmdRestoreTab As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdDeleteTab As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lstModules As System.Web.UI.WebControls.ListBox
        Protected WithEvents cmdRestoreModule As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdDeleteModule As System.Web.UI.WebControls.ImageButton

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

            ' ----------------------------------------------------------------------
            ' This procedure validates that the user has access to the page and then
            ' populates the databound controls.
            ' ----------------------------------------------------------------------

            ' If this is the first visit to the page
            If (Page.IsPostBack = False) Then

                cmdDeleteTab.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Permanently Delete This Tab?');")
                cmdDeleteModule.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Permanently Delete This Module?');")

                BindData()

            End If

        End Sub

        Private Sub BindData()

            Dim intTab As Integer
            Dim arrDeletedTabs As New ArrayList
            Dim intModule As Integer
            Dim arrDeletedModules As New ArrayList

            Dim objTabs As New TabController
            Dim objTab As TabInfo
            Dim objModules As New ModuleController
            Dim objModule As ModuleInfo

            Dim arrTabs As ArrayList = objTabs.GetTabs(PortalId)
            For intTab = 0 To arrTabs.Count - 1
                objTab = CType(arrTabs(intTab), TabInfo)
                If objTab.IsDeleted = True Then
                    arrDeletedTabs.Add(objTab)
                End If

                Dim arrModules As ArrayList = objModules.GetPortalTabModules(PortalId, objTab.TabID)
                For intModule = 0 To arrModules.Count - 1
                    objModule = CType(arrModules(intModule), ModuleInfo)
                    If objModule.IsDeleted = True Then
                        objModule.ModuleTitle += " - " & objTab.TabName
                        arrDeletedModules.Add(objModule)
                    End If
                Next
            Next

            lstTabs.DataSource = arrDeletedTabs
            lstTabs.DataBind()

            lstModules.DataSource = arrDeletedModules
            lstModules.DataBind()

        End Sub

        Private Sub cmdRestoreTab_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdRestoreTab.Click

            If lstTabs.SelectedIndex <> -1 Then

                Dim objTabs As New TabController

                Dim objTab As TabInfo = objTabs.GetTab(Integer.Parse(lstTabs.SelectedItem.Value))
                If Not objTab Is Nothing Then
                    objTab.IsDeleted = False
                    objTabs.UpdateTab(objTab)
                End If

                Response.Redirect(NavigateURL())

            End If

        End Sub

        Private Sub cmdDeleteTab_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdDeleteTab.Click

            If lstTabs.SelectedIndex <> -1 Then

                Dim intTabId As Integer = Integer.Parse(lstTabs.SelectedItem.Value)

                ' remove skin assignments
                Dim objSkin As New SkinController
                objSkin.SetSkin(SkinInfo.RootSkin, Null.NullInteger, intTabId, Null.NullInteger, False, "", "", "")
                objSkin.SetSkin(SkinInfo.RootContainer, Null.NullInteger, intTabId, Null.NullInteger, False, "", "", "")

                ' delete tab
                Dim objTabs As New TabController
                Dim objTab As TabInfo = objTabs.GetTab(intTabId)
                If Not objTab Is Nothing Then
                    objTabs.DeleteTab(objTab.TabID, objTab.PortalID)
                End If

                BindData()

            End If

        End Sub

        Private Sub cmdRestoreModule_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdRestoreModule.Click

            If lstModules.SelectedIndex <> -1 Then

                Dim objModules As New ModuleController

                Dim objModule As ModuleInfo = objModules.GetModule(Integer.Parse(lstModules.SelectedItem.Value))
                If Not objModule Is Nothing Then
                    objModule.IsDeleted = False
                    objModules.UpdateModule(objModule)
                End If

                BindData()

            End If

        End Sub

        Private Sub cmdDeleteModule_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdDeleteModule.Click

            If lstModules.SelectedIndex <> -1 Then

                Dim objModules As New ModuleController

                Dim objModule As ModuleInfo = objModules.GetModule(Integer.Parse(lstModules.SelectedItem.Value))
                If Not objModule Is Nothing Then
                    objModules.DeleteModule(objModule.ModuleID, objModule.TabID)
                End If

                BindData()

            End If

        End Sub

    End Class

End Namespace
