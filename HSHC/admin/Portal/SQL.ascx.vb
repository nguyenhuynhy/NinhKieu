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

    Public Class SQL
        Inherits PortalQH.PortalModuleControl

        Protected WithEvents grdResults As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtQuery As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdExecute As System.Web.UI.WebControls.LinkButton

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

                ' Verify that the current user has access to access this page
                If CType(Context.User.Identity.Name, String) <> _portalSettings.SuperUserId Then
                    Response.Redirect(NavigateURL("Edit Access Denied"), True)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdExecute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExecute.Click
            Try
                If txtQuery.Text <> "" Then

                    Dim objAdmin As New AdminDB

                    Dim dr As IDataReader = objAdmin.ExecuteSQL(txtQuery.Text)
                    grdResults.DataSource = dr
                    grdResults.DataBind()
                    dr.Close()

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
