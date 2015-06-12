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

Namespace PortalQH.Skins

    Public Class Banner

        Inherits SkinObject

        ' public attributes
        Public [BorderWidth] As String

        ' protected controls
        Protected WithEvents hypBanner As System.Web.UI.WebControls.HyperLink
        Protected WithEvents imgBanner As System.Web.UI.WebControls.Image

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
        ' to populate the role information for the page
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Obtain PortalSettings from Current Context
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If Not Page.IsPostBack Then

                ' public attributes
                If [BorderWidth] <> "" Then
                    imgBanner.BorderWidth = System.Web.UI.WebControls.Unit.Parse([BorderWidth])
                End If


                If _portalSettings.BannerAdvertising <> 0 Then
                    Dim objBanners As New BannerController
                    Dim arrBanners As ArrayList = objBanners.LoadBanners(Convert.ToInt32(IIf(_portalSettings.BannerAdvertising = 1, _portalSettings.PortalId, Null.NullInteger)), 1, 1)
                    If arrBanners.Count <> 0 Then
                        Dim objBanner As BannerInfo = CType(arrBanners(0), BannerInfo)

                        hypBanner.Visible = True
                        imgBanner.Visible = True
                        Select Case _portalSettings.BannerAdvertising
                            Case 1 ' local
                                hypBanner.ImageUrl = _portalSettings.UploadDirectory & objBanner.ImageFile.ToString
                            Case 2 ' global
                                hypBanner.ImageUrl = Global.HostPath & objBanner.ImageFile.ToString
                        End Select
                        hypBanner.ToolTip = objBanner.BannerName.ToString
                        imgBanner.AlternateText = objBanner.BannerName.ToString
                        hypBanner.NavigateUrl = Global.ApplicationPath & "/Admin/Vendors/BannerClickThrough.aspx?BannerId=" & objBanner.BannerId.ToString & "&VendorId=" & objBanner.VendorId.ToString
                    Else ' no banners defined
                        hypBanner.ImageUrl = "~/images/nobanner.gif"
                        imgBanner.AlternateText = "No Banner"
                    End If
                Else
                    hypBanner.Visible = False
                    imgBanner.Visible = False
                End If

            End If

        End Sub

    End Class

End Namespace
