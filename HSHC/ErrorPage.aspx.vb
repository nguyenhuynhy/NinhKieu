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
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : ErrorPage
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Trapped errors are redirected to this universal error page, resulting in a 
    ''' graceful display.
    ''' </summary>
    ''' <remarks>
    ''' 'get the last server error
    ''' 'process this error using the Exception Management Application Block
    ''' 'add to a placeholder and place on page
    ''' 'catch direct access - No exception was found...you shouldn't end up here unless you go to this aspx page URL directly
    ''' </remarks>
    ''' <history>
    ''' 	[sun1]	1/19/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ErrorPage
        Inherits System.Web.UI.Page
        Protected WithEvents ErrorPlaceHolder As System.Web.UI.WebControls.PlaceHolder

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
            'get the last server error
            Dim exc As Exception = Server.GetLastError
            Try
                Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

                Dim lex As New PageLoadException(exc.Message.ToString, exc)
                'process this error using the Exception Management Application Block
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(lex)
                'add to a placeholder and place on page
                ErrorPlaceHolder.Controls.Add(New ErrorContainer(_portalSettings, "An error has occurred.", lex).Container)
            Catch
                'No exception was found...you shouldn't end up here
                ' unless you go to this aspx page URL directly
                ErrorPlaceHolder.Controls.Add(New LiteralControl("An unhandled error has occurred."))
            End Try
        End Sub

    End Class

End Namespace