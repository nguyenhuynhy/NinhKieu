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

Namespace PortalQH

    Public MustInherit Class Tabs
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents lstTabs As System.Web.UI.WebControls.ListBox
        Protected WithEvents cmdUp As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdDown As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdLeft As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdRight As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdEdit As System.Web.UI.WebControls.ImageButton
        Protected WithEvents cmdView As System.Web.UI.WebControls.ImageButton

        Protected arrPortalTabs As ArrayList

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
        ' to populate the current tab settings from the database
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                arrPortalTabs = GetPortalTabs(_portalSettings.DesktopTabs, , True)

                ' If this is the first visit to the page, bind the tab data to the page listbox
                If Page.IsPostBack = False Then

                    lstTabs.DataSource = arrPortalTabs
                    lstTabs.DataBind()

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '*******************************************************
        '
        ' The UpDown_Click server event handler on this page is
        ' used to change the tab display order in the current level 
        '
        '*******************************************************

        Private Sub UpDown_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles cmdDown.Click, cmdUp.Click
            Try
                If lstTabs.SelectedIndex <> -1 Then

                    ' Obtain PortalSettings from Current Context
                    Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                    Dim objTab As TabItem = CType(arrPortalTabs(lstTabs.SelectedIndex), TabItem)

                    Dim objTabs As New TabController

                    Select Case CType(sender, ImageButton).CommandName
                        Case "up"
                            objTabs.UpdatePortalTabOrder(PortalId, objTab.TabId, objTab.ParentId, 0, -1, True)
                        Case "down"
                            objTabs.UpdatePortalTabOrder(PortalId, objTab.TabId, objTab.ParentId, 0, 1, True)
                    End Select

                    ' Redirect to this site to refresh
                    Response.Redirect(NavigateURL(), True)

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '*******************************************************
        '
        ' The Rightleft_Click server event handler on this page is
        ' used to move a tab up or down one hierarchical level
        '
        '*******************************************************
        Private Sub RightLeft_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles cmdLeft.Click, cmdRight.Click
            Try

                If lstTabs.SelectedIndex <> -1 Then

                    ' Obtain PortalSettings from Current Context
                    Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                    Dim objTab As TabItem = CType(arrPortalTabs(lstTabs.SelectedIndex), TabItem)

                    Dim objTabs As New TabController

                    Select Case CType(sender, ImageButton).CommandName
                        Case "left"
                            objTabs.UpdatePortalTabOrder(PortalId, objTab.TabId, objTab.ParentId, -1, 0, True)
                        Case "right"
                            objTabs.UpdatePortalTabOrder(PortalId, objTab.TabId, objTab.ParentId, 1, 0, True)
                    End Select

                    ' Redirect to this site to refresh
                    Response.Redirect(NavigateURL(), True)

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '*******************************************************
        '
        ' The EditBtn_Click server event handler is used to edit
        ' the selected tab within the portal
        '
        '*******************************************************

        Private Sub EditBtn_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles cmdEdit.Click
            Try

                ' Redirect to edit page of currently selected tab
                If lstTabs.SelectedIndex <> -1 Then

                    ' Redirect to module settings page
                    Dim t As TabItem = CType(arrPortalTabs(lstTabs.SelectedIndex), TabItem)

                    Response.Redirect("~/DesktopDefault.aspx?tabid=" & t.TabId & "&def=Tab&action=edit", True)

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub ViewBtn_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles cmdView.Click
            Try
                ' Redirect to edit page of currently selected tab
                If lstTabs.SelectedIndex <> -1 Then

                    ' Redirect to module settings page
                    Dim t As TabItem = CType(arrPortalTabs(lstTabs.SelectedIndex), TabItem)

                    Response.Redirect("~/DesktopDefault.aspx?tabid=" & t.TabId, True)

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
