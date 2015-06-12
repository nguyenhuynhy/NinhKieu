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

    Public MustInherit Class BannerOptions
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents optSource As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents cboType As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCount As System.Web.UI.WebControls.TextBox

        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents valCount As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents cmdCancel As System.Web.UI.WebControls.LinkButton

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
        ' The Page_Load event handler on this User Control is used to
        ' obtain a DataReader of banner information from the Banners
        ' table, and then databind the results to a templated DataList
        ' server control.  It uses the PortalQH.BannerDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************'

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not Page.IsPostBack Then

                    ' Obtain banner information from the Banners table and bind to the list control
                    Dim objBannerTypes As New BannerTypeController

                    cboType.DataSource = objBannerTypes.GetBannerTypes
                    cboType.DataBind()

                    If ModuleId > 0 Then

                        ' Get settings from the database
                        Dim settings As Hashtable = PortalSettings.GetModuleSettings(ModuleId)

                        If Not optSource.Items.FindByValue(CType(settings("bannersource"), String)) Is Nothing Then
                            optSource.Items.FindByValue(CType(settings("bannersource"), String)).Selected = True
                        End If
                        If Not cboType.Items.FindByValue(CType(settings("bannertype"), String)) Is Nothing Then
                            cboType.Items.FindByValue(CType(settings("bannertype"), String)).Selected = True
                        End If
                        txtCount.Text = CType(settings("bannercount"), String)

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

                If Not optSource.SelectedItem Is Nothing Then
                    objModules.UpdateModuleSetting(ModuleId, "bannersource", optSource.SelectedItem.Value)
                End If
                If Not cboType.SelectedItem Is Nothing Then
                    objModules.UpdateModuleSetting(ModuleId, "bannertype", cboType.SelectedItem.Value)
                End If
                objModules.UpdateModuleSetting(ModuleId, "bannercount", txtCount.Text)

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
