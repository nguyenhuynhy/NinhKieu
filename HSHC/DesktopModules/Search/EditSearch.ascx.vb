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

    Public Class EditSearch
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtResults As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkDescription As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkBreadcrumbs As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkAudit As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cboTables As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdAdd As System.Web.UI.WebControls.LinkButton
        Protected WithEvents grdCriteria As System.Web.UI.WebControls.DataGrid

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton

        Public arrFields As ArrayList
        Dim Search As SearchInfo

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

                If Page.IsPostBack = False Then

                    If ModuleId > 0 Then

                        txtResults.Text = CType(Settings("maxresults"), String)
                        txtTitle.Text = CType(Settings("maxtitle"), String)
                        txtDescription.Text = CType(Settings("maxdescription"), String)
                        chkDescription.Checked = CType(Settings("showdescription"), Boolean)
                        chkAudit.Checked = CType(Settings("showaudit"), Boolean)
                        chkBreadcrumbs.Checked = CType(Settings("showbreadcrumbs"), Boolean)

                    End If

                    Dim objSearch As New SearchController

                    cboTables.DataSource = objSearch.GetSearchTables
                    cboTables.DataBind()

                    BindData()

                    ' Store URL Referrer to return to portal
                    If Not Request.UrlReferrer Is Nothing Then
                        ViewState("UrlReferrer") = Convert.ToString(Request.UrlReferrer)
                    Else
                        ViewState("UrlReferrer") = ""
                    End If

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try

                ' Update settings in the database
                Dim objModules As New ModuleController

                objModules.UpdateModuleSetting(ModuleId, "maxresults", txtResults.Text)
                objModules.UpdateModuleSetting(ModuleId, "maxtitle", txtTitle.Text)
                objModules.UpdateModuleSetting(ModuleId, "maxdescription", txtDescription.Text)
                objModules.UpdateModuleSetting(ModuleId, "showdescription", chkDescription.Checked.ToString)
                objModules.UpdateModuleSetting(ModuleId, "showaudit", chkAudit.Checked.ToString)
                objModules.UpdateModuleSetting(ModuleId, "showbreadcrumbs", chkBreadcrumbs.Checked.ToString)

                ' Redirect back to the portal home page
                Response.Redirect(Convert.ToString(ViewState("UrlReferrer")), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(Convert.ToString(ViewState("UrlReferrer")), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub BindData(Optional ByVal intSearchId As Integer = -1)

            Dim objSearch As New SearchController

            If intSearchId <> -1 Then
                arrFields = objSearch.GetSearchFields(intSearchId, ModuleId)
            End If

            grdCriteria.DataSource = objSearch.GetSearch(ModuleId)
            grdCriteria.DataBind()

        End Sub

        Public Function SelectField(ByVal objFieldValue As Object) As String
            Try
                Dim intField As Integer

                If IsDBNull(objFieldValue) Then
                    Return "0"
                Else
                    For intField = 0 To arrFields.Count - 1
                        If objFieldValue Is arrFields(intField) Then
                            Return intField.ToString
                        End If
                    Next intField
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub grdCriteria_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdCriteria.ItemCreated
            Try
                Dim cmdDeleteCriteria As Control = e.Item.FindControl("cmdDeleteCriteria")

                If Not cmdDeleteCriteria Is Nothing Then
                    CType(cmdDeleteCriteria, ImageButton).Attributes.Add("onClick", "javascript: return confirm('Are You Sure You Wish To Delete This Item ?')")
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Public Sub grdCriteria_Edit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                grdCriteria.EditItemIndex = e.Item.ItemIndex
                grdCriteria.SelectedIndex = -1

                BindData(Integer.Parse(Convert.ToString(grdCriteria.DataKeys(e.Item.ItemIndex))))
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdCriteria_Delete(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try
                Dim objSearch As New SearchController

                objSearch.DeleteSearch(Integer.Parse(Convert.ToString(grdCriteria.DataKeys(e.Item.ItemIndex))))

                grdCriteria.EditItemIndex = -1

                BindData()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdCriteria_Update(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)

            Try
                Dim cboTitleField As DropDownList = CType(e.Item.Cells(2).Controls(1), DropDownList)
                Dim cboDescriptionField As DropDownList = CType(e.Item.Cells(3).Controls(1), DropDownList)
                Dim cboCreatedDateField As DropDownList = CType(e.Item.Cells(4).Controls(1), DropDownList)
                Dim cboCreatedByUserField As DropDownList = CType(e.Item.Cells(5).Controls(1), DropDownList)

                Dim strTitleField As String = ""
                If cboTitleField.SelectedIndex <> -1 And cboTitleField.SelectedIndex <> 0 Then
                    strTitleField = cboTitleField.SelectedItem.Value
                End If
                Dim strDescriptionField As String = ""
                If cboDescriptionField.SelectedIndex <> -1 And cboDescriptionField.SelectedIndex <> 0 Then
                    strDescriptionField = cboDescriptionField.SelectedItem.Value
                End If
                Dim strCreatedDateField As String = ""
                If cboCreatedDateField.SelectedIndex <> -1 And cboCreatedDateField.SelectedIndex <> 0 Then
                    strCreatedDateField = cboCreatedDateField.SelectedItem.Value
                End If
                Dim strCreatedByUserField As String = ""
                If cboCreatedByUserField.SelectedIndex <> -1 And cboCreatedByUserField.SelectedIndex <> 0 Then
                    strCreatedByUserField = cboCreatedByUserField.SelectedItem.Value
                End If

                Dim objSearch As New SearchController

                Search.SearchId = Integer.Parse(grdCriteria.DataKeys(e.Item.ItemIndex).ToString)
                Search.TitleField = strTitleField
                Search.DescriptionField = strDescriptionField
                Search.CreatedDateField = strCreatedDateField
                Search.CreatedByUserField = strCreatedByUserField

                objSearch.UpdateSearch(Search)

                grdCriteria.EditItemIndex = -1
                BindData()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdCriteria_CancelEdit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try
                grdCriteria.EditItemIndex = -1
                BindData()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

            Try
                Dim objSearch As New SearchController
                Search.ModuleId = ModuleId
                Search.TableName = cboTables.SelectedItem.Value

                If Not cboTables.SelectedItem Is Nothing Then
                    objSearch.AddSearch(Search)
                End If

                BindData()
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace