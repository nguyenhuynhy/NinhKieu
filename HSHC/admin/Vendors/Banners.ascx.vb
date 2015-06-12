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

    Public MustInherit Class Banners

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents grdBanners As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdAdd As System.Web.UI.WebControls.HyperLink

        Public VendorID As Integer

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            If Not (Request.Params("VendorID") Is Nothing) Then
                VendorID = Int32.Parse(Request.Params("VendorID"))
            Else
                VendorID = Convert.ToInt32(Null.SetNull(VendorID))
            End If

            MyBase.Actions.Add(GetNextActionID, "Add Banner", "", URL:=EditURL("VendorID", VendorID.ToString, "Banner"), secure:=SecurityAccessLevel.Admin, Visible:=Null.IsNull(VendorID) = False)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try

                If Not Null.IsNull(VendorID) Then
                    BindData()
                Else
                    Me.Visible = False
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub BindData()
            Dim objBanners As New BannerController

            grdBanners.DataSource = objBanners.GetBanners(VendorID)
            grdBanners.DataBind()

            cmdAdd.NavigateUrl = FormatURL("BannerId", "-1")
        End Sub

        Public Function FormatURL(ByVal strKeyName As String, ByVal strKeyValue As String) As String
            Return EditURL(strKeyName, strKeyValue, "Banner") & "&VendorId=" & VendorID
        End Function

        Public Function DisplayDate(ByVal DateValue As Date) As String
            Try
                If Null.IsNull(DateValue) Then
                    Return ""
                Else
                    Return DateValue.ToShortDateString
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

    End Class

End Namespace