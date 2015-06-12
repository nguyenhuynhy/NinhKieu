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

    Public Class EditIFrame
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSrc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHeight As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWidth As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboScrolling As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cboBorder As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Page.IsPostBack = False Then

                    If ModuleId > 0 Then

                        ' Get settings from the database 
                        'Dim settings As Hashtable = PortalSettings.GetModuleSettings(ModuleId)

                        txtSrc.Text = CType(Settings("src"), String)
                        txtHeight.Text = CType(Settings("height"), String)
                        txtWidth.Text = CType(Settings("width"), String)
                        txtTitle.Text = CType(Settings("title"), String)

                        If CType(Settings("scrolling"), String) <> "" Then
                            cboScrolling.Items.FindByText(CType(Settings("scrolling"), String)).Selected = True
                        Else
                            cboScrolling.SelectedIndex = 0 ' auto
                        End If
                        If CType(Settings("border"), String) <> "" Then
                            cboBorder.Items.FindByText(CType(Settings("border"), String)).Selected = True
                        Else
                            cboBorder.SelectedIndex = 0 ' no
                        End If

                    End If

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '**************************************************************** 
        ' 
        ' The UpdateBtn_Click event handler on this Page is used to save 
        ' the settings to the configuration file. 
        ' 
        '**************************************************************** 

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                ' Update settings in the database 
                Dim objModules As New ModuleController

                objModules.UpdateModuleSetting(ModuleId, "src", txtSrc.Text)
                objModules.UpdateModuleSetting(ModuleId, "height", txtHeight.Text)
                objModules.UpdateModuleSetting(ModuleId, "width", txtWidth.Text)
                objModules.UpdateModuleSetting(ModuleId, "scrolling", cboScrolling.SelectedItem.Text)
                objModules.UpdateModuleSetting(ModuleId, "border", cboBorder.SelectedItem.Text)
                objModules.UpdateModuleSetting(ModuleId, "title", txtTitle.Text)

                ' Redirect back to the portal home page 
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '**************************************************************** 
        ' 
        ' The CancelBtn_Click event handler on this Page is used to cancel 
        ' out of the page, and return the user back to the portal home 
        ' page. 
        ' 
        '**************************************************************** 
        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace