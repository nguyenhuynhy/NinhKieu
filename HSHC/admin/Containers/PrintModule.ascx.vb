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

Namespace PortalQH.Containers
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : Containers.Icon
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Contains the attributes of an Icon.  
    ''' These are read into the portalmodulecontrol collection as attributes for the icons within the module controls.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[sun1]	2/1/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class PrintModule

        Inherits SkinObject

        ' protected controls
        Protected WithEvents cmdPrint As System.Web.UI.WebControls.ImageButton

#Region " Web Form Designer Generated Code "


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
                If Not Page.IsPostBack Then

                    Dim objPortalModule As PortalModuleControl = Container.GetPortalModuleControl(Me)

                    If IsAdminTab(objPortalModule.PortalSettings.ActiveTab.TabId, objPortalModule.PortalSettings.ActiveTab.ParentId) Then
                        Me.Visible = False
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdPrint.Click

            Dim objPortalModule As PortalModuleControl = Container.GetPortalModuleControl(Me)

            Dim strURL As String = Request.RawUrl

            If strURL.IndexOf("?tabid") = -1 Then
                strURL += "?tabid=" & objPortalModule.TabId.ToString
            End If
            If strURL.IndexOf("&mid") = -1 Then
                strURL += "&mid=" & objPortalModule.ModuleId.ToString
            End If
            strURL += "&SkinType=G&SkinName=_default&SkinSrc=printmodule.ascx"
            strURL += "&ContainerType=G&ContainerName=_default&ContainerSrc=notitle.ascx"

            Response.Write("<script>window.open('" & strURL & "','_new')</script>")

        End Sub

    End Class

End Namespace
