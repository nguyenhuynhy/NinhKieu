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
    Public Class Icon

        Inherits SkinObject

        ' public attributes
        Public [BorderWidth] As String

        ' protected controls
        Protected WithEvents imgIcon As System.Web.UI.WebControls.Image

#Region " Web Form Designer Generated Code "


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
        ' to populate the control information
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not Page.IsPostBack Then

                    ' public attributes
                    If [BorderWidth] <> "" Then
                        imgIcon.BorderWidth = System.Web.UI.WebControls.Unit.Parse([BorderWidth])
                    End If

                    Dim objPortalModule As PortalModuleControl = Container.GetPortalModuleControl(Me)

                    If objPortalModule.ModuleConfiguration.IconFile <> "" Then

                        If IsAdminControl() Then
                            imgIcon.ImageUrl = objPortalModule.TemplateSourceDirectory & "/" & objPortalModule.ModuleConfiguration.IconFile
                        Else
                            If IsAdminTab(objPortalModule.PortalSettings.ActiveTab.TabId, objPortalModule.PortalSettings.ActiveTab.ParentId) Then
                                imgIcon.ImageUrl = "~/images/" & objPortalModule.ModuleConfiguration.IconFile
                            Else
                                imgIcon.ImageUrl = objPortalModule.PortalSettings.UploadDirectory & objPortalModule.ModuleConfiguration.IconFile
                            End If
                        End If
                        imgIcon.AlternateText = objPortalModule.ModuleConfiguration.ModuleTitle
                    Else
                        Me.Visible = False
                    End If

                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace
