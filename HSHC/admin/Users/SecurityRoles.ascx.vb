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

    Public Class SecurityRoles
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents cboUsers As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboRoles As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtExpiryDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdAdd As System.Web.UI.WebControls.LinkButton
        Protected WithEvents grdUserRoles As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdExpiryCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents valExpiryDate As System.Web.UI.WebControls.CompareValidator

        Private RoleId As Integer = -1
        Protected WithEvents cmdAssignRoles As System.Web.UI.WebControls.LinkButton
        Private Shadows UserId As String = ""

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
        ' The Page_Load server event handler on this page is used
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                ' Verify that the current user has access to this page
                If PortalSecurity.IsInRoles(_portalSettings.AdministratorRoleId.ToString) = False Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

                If Not (Request.Params("RoleId") Is Nothing) Then
                    RoleId = Int32.Parse(Request.Params("RoleId"))
                End If

                'If Not (Request.Params("UserId") Is Nothing) Then
                '    UserId = CType(Request.Params("UserId"), String)
                'End If

                If Not (Request.QueryString("UserId") Is Nothing) Then
                    UserId = CType(Request.QueryString("UserId"), String)
                End If

                ' If this is the first visit to the page, bind the role data to the datalist
                If Page.IsPostBack = False Then
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete The Entire Role Membership For This Item ?');")
                    cmdExpiryCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtExpiryDate)
                    BindData()

                    ' Store URL Referrer to return to portal
                    If Not Request.UrlReferrer Is Nothing Then
                        ViewState("UrlReferrer") = Convert.ToString(Request.UrlReferrer)
                    Else
                        ViewState("UrlReferrer") = ""
                    End If
                End If

                BindGrid()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '*******************************************************
        '
        ' The BindData helper method is used to bind the list of 
        ' security roles for this portal to an asp:datalist server control
        '
        '*******************************************************'

        Sub BindData()

            Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)
            Dim objRole As New RoleController
            Dim objUsers As New UserController
            ' bind all portal roles to dropdownlist
            cboRoles.DataSource = objRole.GetPortalRoles(PortalId)
            cboRoles.DataBind()
            cboRoles.Items.Insert(0, New ListItem("<All Roles>", "-1"))
            If RoleId <> -1 Then
                cboRoles.Items.FindByValue(RoleId.ToString).Selected = True
                cboRoles.Enabled = False
            End If

            ' bind all portal users to dropdownlist
            cboUsers.DataSource = objUsers.GetUsersDataSet(PortalId)
            cboUsers.DataBind()
            cboUsers.Items.Insert(0, New ListItem("<All Users>", "-1"))
            If UserId <> "" Then
                cboUsers.Items.FindByValue(UserId.ToString).Selected = True
                cboUsers.Enabled = False
            End If

        End Sub

        Sub BindGrid()

            Dim objUser As New UserController
            Dim i As Integer
            i = -1
            If RoleId <> -1 Then
                grdUserRoles.DataKeyField = "UserId"
                grdUserRoles.DataSource = objUser.GetRoleMembership(PortalId, RoleId)
                grdUserRoles.DataBind()
            End If
            If UserId <> "" Then
                grdUserRoles.DataKeyField = "RoleId"
                grdUserRoles.DataSource = objUser.GetRoleMembership(PortalId, , UserId)
                grdUserRoles.DataBind()
            End If
        End Sub

        Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Try
                Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

                Dim objUserController As New UserController
                Dim objRoleController As New RoleController

                ' do not expire the portal Administrator account
                If cboUsers.SelectedItem.Value = _portalSettings.AdministratorId.ToString And cboRoles.SelectedItem.Value = _portalSettings.AdministratorRoleId.ToString Then
                    txtExpiryDate.Text = ""
                End If

                Dim datExpiryDate As Date
                If txtExpiryDate.Text <> "" Then
                    datExpiryDate = Date.Parse(txtExpiryDate.Text)
                Else
                    datExpiryDate = Null.NullDate
                End If

                If Int32.Parse(cboRoles.SelectedItem.Value) = -1 Then
                    Dim arrPortalRoles As New ArrayList
                    ' all roles
                    arrPortalRoles = objRoleController.GetPortalRoles(PortalId)
                    Dim objRole As RoleInfo
                    For Each objRole In arrPortalRoles
                        objRoleController.AddUserRole(PortalId, CType(cboUsers.SelectedItem.Value, String), objRole.RoleID, datExpiryDate)
                    Next
                Else
                    If CType(cboUsers.SelectedItem.Value, String) = "-1" Then
                        ' all users
                        Dim arrUsers As New ArrayList
                        arrUsers = objUserController.GetUsers(PortalId)
                        Dim objUserInfo As UserInfo
                        For Each objUserInfo In arrUsers
                            objRoleController.AddUserRole(PortalId, objUserInfo.UserID, _
                                                            Convert.ToInt32(cboRoles.SelectedItem.Value), _
                                                            datExpiryDate, _
                                                            Convert.ToBoolean(IIf(_portalSettings.UserRegistration = 1, False, True)))
                        Next
                    Else
                        ' single user/role
                        objRoleController.AddUserRole(PortalId, CType(cboUsers.SelectedItem.Value, String), _
                                                        Convert.ToInt32(cboRoles.SelectedItem.Value), _
                                                        datExpiryDate, _
                                                        Convert.ToBoolean(IIf(_portalSettings.UserRegistration = 1, False, True)))
                    End If
                End If

                BindGrid()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try

                Response.Redirect(Convert.ToString(Viewstate("UrlReferrer")), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub grdUserRoles_Delete(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Try

                Dim objUser As New RoleController
                Dim strMessage As String = ""

                If RoleId <> -1 Then
                    If objUser.DeleteUserRole(PortalId, Convert.ToString(grdUserRoles.DataKeys(e.Item.ItemIndex)), RoleId) = False Then
                        strMessage = "You Can Not Remove The Portal Administrator Or The Registered Users Role"
                    End If
                End If
                If UserId <> "" Then
                    If objUser.DeleteUserRole(PortalId, UserId, Integer.Parse(Convert.ToString(grdUserRoles.DataKeys(e.Item.ItemIndex)))) = False Then
                        strMessage = "You Can Not Remove The Portal Administrator Or The Registered Users Role"
                    End If
                End If

                grdUserRoles.EditItemIndex = -1
                BindGrid()

                If strMessage <> "" Then
                    Skin.AddModuleMessage(Me, strMessage, Skins.ModuleMessage.ModuleMessageType.RedError)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub grdUserRoles_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdUserRoles.ItemCreated
            Try

                Dim cmdDeleteUserRole As Control = e.Item.FindControl("cmdDeleteUserRole")

                If Not cmdDeleteUserRole Is Nothing Then
                    CType(cmdDeleteUserRole, ImageButton).Attributes.Add("onClick", "javascript: return confirm('Are You Sure You Wish To Delete This Item ?')")
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                Dim objUser As New UserController
                Dim objRole As New RoleController
                Dim arrUserRoleInfo As New ArrayList
                Dim objUserRoleInfo As UserRoleInfo

                If RoleId <> -1 Then
                    arrUserRoleInfo = objUser.GetRoleMembership(PortalId, RoleId)
                End If
                If UserId <> "" Then
                    arrUserRoleInfo = objUser.GetRoleMembership(PortalId, , UserId)
                End If

                For Each objUserRoleInfo In arrUserRoleInfo
                    objRole.DeleteUserRole(PortalId, objUserRoleInfo.UserID, objUserRoleInfo.RoleID)
                Next


                BindGrid()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ' Format the expiry date and filter out null-dates 
        Function FormatExpiryDate(ByVal DateTime As Date) As String
            Try
                If Not Null.IsNull(DateTime) Then
                    FormatExpiryDate = DateTime.ToShortDateString
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub cmdAssignRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignRoles.Click
            Try
                Response.Redirect(NavigateURL("PhanQuyen&UserId=" & UserId), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
    End Class

End Namespace
