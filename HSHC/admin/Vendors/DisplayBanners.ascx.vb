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

    Public MustInherit Class DisplayBanners
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents pnlModuleContent As System.Web.UI.WebControls.Panel

        Protected WithEvents lstBanners As System.Web.UI.WebControls.DataList

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            MyBase.Actions.Add(GetNextActionID, "Edit", "", URL:=EditURL(), secure:=SecurityAccessLevel.Edit, Visible:=True)
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
                Dim intPortalId As Integer
                Dim intBannerTypeId As Integer
                Dim intBanners As Integer

                Dim objBanner As New BannerController

                Select Case CType(Settings("bannersource"), String)
                    Case "L", "" ' local
                        intPortalId = PortalId
                    Case "G" ' global
                        intPortalId = Convert.ToInt32(Null.SetNull(intPortalId))
                End Select

                If CType(Settings("bannertype"), String) <> "" Then
                    intBannerTypeId = Int32.Parse(CType(Settings("bannertype"), String))
                Else
                    intBannerTypeId = 1
                End If

                If CType(Settings("bannercount"), String) <> "" Then
                    intBanners = Int32.Parse(CType(Settings("bannercount"), String))
                Else
                    intBanners = 1
                End If

                lstBanners.DataSource = objBanner.LoadBanners(intPortalId, intBannerTypeId, intBanners)
                lstBanners.DataBind()

                If lstBanners.Items.Count = 0 Then
                    lstBanners.Visible = False
                End If
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Function FormatImagePath(ByVal ImageFile As String) As String

            If InStr(1, ImageFile, "://") = 0 Then
                ImageFile = PortalSettings.UploadDirectory & ImageFile
            End If

            Return ImageFile

        End Function

    End Class

End Namespace
