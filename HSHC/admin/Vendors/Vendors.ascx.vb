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

    Public MustInherit Class Vendors

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents grdVendors As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

        Dim strFilter As String

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
        ' obtain a DataReader of contact information from the Vendors
        ' table, and then databind the results to a DataGrid
        ' server control.  It uses the PortalQH.VendorsDB()
        ' data component to encapsulate all data functionality.
        '
        '*******************************************************'
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not Page.IsPostBack Then
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete These Items ?');")
                End If

                If Not Request.Params("filter") Is Nothing Then
                    strFilter = Request.Params("filter")
                Else
                    strFilter = " "
                End If

                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Sub BindData()

            ' Obtain PortalSettings from Current Context

            Dim objVendors As New VendorController
            If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                grdVendors.DataSource = objVendors.GetVendors(, strFilter)
            Else
                grdVendors.DataSource = objVendors.GetVendors(PortalId, strFilter)
            End If
            grdVendors.DataBind()

        End Sub

        Public Function FormatURL(ByVal strKeyName As String, ByVal strKeyValue As String) As String
            Try
                FormatURL = EditURL(strKeyName, strKeyValue) & IIf(strFilter <> "", "&filter=" & strFilter, "").ToString

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function DisplayAddress(ByVal Unit As Object, ByVal Street As Object, ByVal City As Object, ByVal Region As Object, ByVal Country As Object, ByVal PostalCode As Object) As String
            Try
                DisplayAddress = FormatAddress(Unit, Street, City, Region, Country, PostalCode)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Public Function DisplayEmail(ByVal Email As Object) As String
            Try
                DisplayEmail = FormatEmail(Email)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Function

        Private Sub grdVendors_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdVendors.ItemCreated
            Try
                Dim intCounter As Integer
                Dim objLinkButton As LinkButton

                If e.Item.ItemType = ListItemType.Pager Then
                    Dim objCell As TableCell = CType(e.Item.Controls(0), TableCell)
                    objCell.Controls.Clear()

                    For intCounter = Asc("A") To Asc("Z")
                        objLinkButton = New LinkButton
                        objLinkButton.Text = Chr(intCounter)
                        objLinkButton.CssClass = "CommandButton"
                        objLinkButton.CommandName = "filter"
                        objLinkButton.CommandArgument = objLinkButton.Text
                        objCell.Controls.Add(objLinkButton)
                        objCell.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    Next

                    objLinkButton = New LinkButton
                    objLinkButton.Text = "(All)"
                    objLinkButton.CssClass = "CommandButton"
                    objLinkButton.CommandName = "filter"
                    objLinkButton.CommandArgument = ""
                    objCell.Controls.Add(objLinkButton)
                    objCell.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                    objLinkButton = New LinkButton
                    objLinkButton.Text = "(Unauthorized)"
                    objLinkButton.CssClass = "CommandButton"
                    objLinkButton.CommandName = "filter"
                    objLinkButton.CommandArgument = "-"
                    objCell.Controls.Add(objLinkButton)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub grdVendors_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdVendors.ItemCommand
            Try
                If e.CommandName = "filter" Then
                    strFilter = e.CommandArgument.ToString
                    BindData()
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            Try
                Dim objVendors As New VendorController
                If PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    objVendors.DeleteVendors()
                Else
                    objVendors.DeleteVendors(PortalId)
                End If
                BindData()

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace