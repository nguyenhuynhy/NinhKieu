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
    Public Class EditRoles

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtRoleName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtServiceFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBillingPeriod As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboBillingFrequency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTrialFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTrialPeriod As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboTrialFrequency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkIsPublic As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkAutoAssignment As System.Web.UI.WebControls.CheckBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdManage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents valRoleName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valServiceFee1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valServiceFee2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valBillingPeriod1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valBillingPeriod2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valTrialFee1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valTrialFee2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valTrialPeriod1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents valTrialPeriod2 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents txtEvery As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboPeriod As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox

        Private RoleID As Integer = -1

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
                If Not (Request.Params("RoleID") Is Nothing) Then
                    RoleID = Int32.Parse(Request.Params("RoleID"))
                End If

                If Page.IsPostBack = False Then
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete This Item ?');")

                    Dim objUser As New RoleController
                    Dim objAdmin As New CodeController

                    cboBillingFrequency.DataSource = objAdmin.GetBillingFrequencyCodes()
                    cboBillingFrequency.DataBind()
                    cboBillingFrequency.Items.FindByValue("N").Selected = True

                    cboTrialFrequency.DataSource = objAdmin.GetBillingFrequencyCodes()
                    cboTrialFrequency.DataBind()
                    cboTrialFrequency.Items.FindByValue("N").Selected = True

                    If RoleID <> -1 Then
                        Dim objRoleInfo As RoleInfo = objUser.GetRole(RoleID)

                        If Not objRoleInfo Is Nothing Then
                            txtRoleName.Text = objRoleInfo.RoleName
                            txtDescription.Text = objRoleInfo.Description
                            If Format(objRoleInfo.ServiceFee, "#,##0.00") <> "0.00" Then
                                txtServiceFee.Text = Format(objRoleInfo.ServiceFee, "#,##0.00")
                                txtBillingPeriod.Text = objRoleInfo.BillingPeriod.ToString
                                If Not cboBillingFrequency.Items.FindByValue(objRoleInfo.BillingFrequency) Is Nothing Then
                                    cboBillingFrequency.ClearSelection()
                                    cboBillingFrequency.Items.FindByValue(objRoleInfo.BillingFrequency).Selected = True
                                End If
                            End If
                            If objRoleInfo.TrialFrequency <> "N" Then
                                txtTrialFee.Text = Format(objRoleInfo.TrialFee, "#,##0.00")
                                txtTrialPeriod.Text = objRoleInfo.TrialPeriod.ToString
                                If Not cboTrialFrequency.Items.FindByValue(objRoleInfo.TrialFrequency) Is Nothing Then
                                    cboTrialFrequency.ClearSelection()
                                    cboTrialFrequency.Items.FindByValue(objRoleInfo.TrialFrequency).Selected = True
                                End If
                            End If
                            chkIsPublic.Checked = objRoleInfo.IsPublic
                            chkAutoAssignment.Checked = objRoleInfo.AutoAssignment
                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL("Security Roles"))
                        End If

                        If RoleID = PortalSettings.AdministratorRoleId Or RoleID = PortalSettings.RegisteredRoleId Then
                            cmdDelete.Visible = False
                            cmdUpdate.Visible = False
                        End If

                        If RoleID = PortalSettings.RegisteredRoleId Then
                            cmdManage.Visible = False
                        End If
                    Else
                        cmdDelete.Visible = False
                        cmdManage.Visible = False
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                If Page.IsValid Then
                    Dim _portalSettings As PortalSettings = CType(Context.Items("PortalSettings"), PortalSettings)

                    Dim dblServiceFee As Double = 0
                    Dim intBillingPeriod As Integer = 1
                    Dim strBillingFrequency As String = "N"

                    If txtServiceFee.Text <> "" Then
                        dblServiceFee = Double.Parse(txtServiceFee.Text)
                        If txtBillingPeriod.Text <> "" Then
                            intBillingPeriod = Integer.Parse(txtBillingPeriod.Text)
                        End If
                        strBillingFrequency = cboBillingFrequency.SelectedItem.Value
                    End If

                    Dim dblTrialFee As Double = 0
                    Dim intTrialPeriod As Integer = 1
                    Dim strTrialFrequency As String = "N"

                    If dblServiceFee <> 0 And cboTrialFrequency.SelectedItem.Value <> "N" Then
                        If txtTrialFee.Text <> "" Then
                            dblTrialFee = Double.Parse(txtTrialFee.Text)
                        End If
                        If txtTrialPeriod.Text <> "" Then
                            intTrialPeriod = Integer.Parse(txtTrialPeriod.Text)
                        End If
                        strTrialFrequency = cboTrialFrequency.SelectedItem.Value
                    End If

                    Dim objRoleController As New RoleController
                    Dim objRoleInfo As New RoleInfo
                    objRoleInfo.PortalID = PortalId
                    objRoleInfo.RoleID = RoleID
                    objRoleInfo.RoleName = txtRoleName.Text
                    objRoleInfo.Description = txtDescription.Text
                    objRoleInfo.ServiceFee = Convert.ToSingle(dblServiceFee)
                    objRoleInfo.BillingPeriod = intBillingPeriod
                    objRoleInfo.BillingFrequency = strBillingFrequency
                    objRoleInfo.TrialFee = Convert.ToSingle(dblTrialFee)
                    objRoleInfo.TrialPeriod = intTrialPeriod
                    objRoleInfo.TrialFrequency = strTrialFrequency
                    objRoleInfo.IsPublic = chkIsPublic.Checked
                    objRoleInfo.AutoAssignment = chkAutoAssignment.Checked

                    If RoleID = -1 Then
                        objRoleController.AddRole(objRoleInfo)
                    Else
                        objRoleController.UpdateRole(objRoleInfo)
                    End If

                    Response.Redirect(NavigateURL())

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                Dim objUser As New RoleController

                objUser.DeleteRole(RoleID)

                Response.Redirect(NavigateURL())

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL())

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManage.Click
            Try
                Response.Redirect(NavigateURL("User Roles&RoleId=" & RoleID))
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
