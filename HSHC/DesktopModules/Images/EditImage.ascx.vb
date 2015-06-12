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

    Public Class EditImage
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents optExternal As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optInternal As System.Web.UI.WebControls.RadioButton
        Protected WithEvents txtExternal As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboInternal As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdUpload As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtAlt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWidth As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHeight As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdUpdate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents valAltText As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents valWidth As System.Web.UI.WebControls.RegularExpressionValidator
        Protected WithEvents valHeight As System.Web.UI.WebControls.RegularExpressionValidator
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

        '****************************************************************
        '
        ' The Page_Load event on this Page is usedto obtain the ModuleId
        ' of the image module to edit.
        '
        ' It then uses the ASP.NET configuration system to populate the page's
        ' edit controls with the image details.
        '
        '****************************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objModules As New ModuleController

                If optExternal.Checked = False And optInternal.Checked = False Then
                    optInternal.Checked = True
                End If

                EnableControls()

                If Page.IsPostBack = False Then

                    ' load the list of files found in the upload directory
                    Dim FileList As ArrayList = GetFileList(PortalId, glbImageFileTypes)
                    cboInternal.DataSource = FileList
                    cboInternal.DataBind()
                    cmdUpload.NavigateUrl = NavigateURL("File Manager")

                    If ModuleId <> -1 Then

                        Dim settings As Hashtable

                        ' Get settings from the database
                        settings = PortalSettings.GetModuleSettings(ModuleId)

                        If InStr(1, CType(settings("src"), String), "://") = 0 Then
                            optInternal.Checked = True
                            optExternal.Checked = False
                            EnableControls()
                            If cboInternal.Items.Contains(New ListItem(CType(settings("src"), String))) Then
                                cboInternal.Items.FindByText(CType(settings("src"), String)).Selected = True
                            End If
                        Else
                            optInternal.Checked = False
                            optExternal.Checked = True
                            EnableControls()
                            txtExternal.Text = CType(settings("src"), String)
                        End If

                        txtAlt.Text = CType(settings("alt"), String)
                        txtWidth.Text = CType(settings("width"), String)
                        txtHeight.Text = CType(settings("height"), String)

                    End If

                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '****************************************************************
        '
        ' The cmdUpdate_Click event handler on this Page is used to save
        ' the settings to the ModuleSettings database table.  It  uses the
        ' PortalQH.AdminDB() data component to encapsulate the data
        ' access functionality.
        '
        '****************************************************************

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            Try
                ' Update settings in the database
                Dim objFiles As New FileController
                Dim strImage As String

                If txtExternal.Text <> "" Then
                    strImage = AddHTTP(txtExternal.Text)
                Else
                    strImage = cboInternal.SelectedItem.Text

                    Dim dr As IDataReader = objFiles.GetFile(cboInternal.SelectedItem.Text, PortalId)
                    If dr.Read Then
                        If txtWidth.Text = "" Then
                            txtWidth.Text = dr("Width").ToString
                        End If
                        If txtHeight.Text = "" Then
                            txtHeight.Text = dr("Height").ToString
                        End If
                    End If
                    dr.Close()
                End If

                Dim objModules As New ModuleController
                objModules.UpdateModuleSetting(ModuleId, "src", strImage)
                objModules.UpdateModuleSetting(ModuleId, "alt", txtAlt.Text)
                objModules.UpdateModuleSetting(ModuleId, "width", txtWidth.Text)
                objModules.UpdateModuleSetting(ModuleId, "height", txtHeight.Text)

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        '****************************************************************
        '
        ' The cmdCancel_Click event handler on this Page is used to cancel
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

        Private Sub EnableControls()
            Try
                If optExternal.Checked Then
                    cboInternal.ClearSelection()
                    cboInternal.Enabled = False
                    txtExternal.Enabled = True
                Else
                    cboInternal.Enabled = True
                    txtExternal.Text = ""
                    txtExternal.Enabled = False
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace