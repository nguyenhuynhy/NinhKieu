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

Imports System.Configuration
Imports System.Data.SqlClient

Namespace PortalQH

    Public MustInherit Class Users

        Inherits PortalQH.PortalModuleControl

        Protected WithEvents grdUsers As System.Web.UI.WebControls.DataGrid
        Protected WithEvents grdABC As System.Web.UI.WebControls.DataGrid
        Protected WithEvents cmdAddNew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents UpdateLDAPUser As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlHinhThucTim As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lnkTim As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents cmdDelete As System.Web.UI.WebControls.LinkButton

        Dim strFilter As String = ""

        Enum FindTypes As Integer
            Search 'without use alphabet
            Filter 'by alphabet
        End Enum

        Property CurrFindType() As FindTypes
            Get
                If ViewState("CurrFindType") Is Nothing Then
                    ViewState("CurrFindType") = FindTypes.Filter
                    Return FindTypes.Filter
                Else
                    Return CType(ViewState("CurrFindType"), FindTypes)
                End If
            End Get
            Set(ByVal Value As FindTypes)
                ViewState("CurrFindType") = Value
            End Set
        End Property

        Property FilterChar() As String
            Get
                If ViewState("FilterChar") Is Nothing Then
                    ViewState("FilterChar") = ""
                    Return ""
                Else
                    Return CStr(ViewState("FilterChar"))
                End If
            End Get
            Set(ByVal Value As String)
                ViewState("FilterChar") = Value
            End Set
        End Property

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
        ' The Page_Load server event handler on this user control is used
        ' to populate the current roles settings from the configuration system
        '
        '*******************************************************

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try

                If Not Me.IsPostBack Then
                    'cmdDelete.Attributes.Add("onClick", "javascript:return confirm('Are You Sure You Wish To Delete These Items ?');")
                    BindData(FindTypes.Filter)
                End If

                ' check user ldap flag
                If Not CType(ConfigurationSettings.AppSettings("UseLDAP"), Boolean) Then
                    UpdateLDAPUser.Visible = False
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub


        '********************************************************************
        'Purpose           	:The BindData helper method is used to bind the list of
        '                   users for this portal to an asp:Datagrid server control
        'Params         	:FindType: Current type of search
        'Returns         	:None
        'Created date		:Unknown
        'Creator		    :Unknown
        'Modified date  	:Oct 21st 2005
        'Modifier        	:Phuocdd
        '********************************************************************
        Sub BindData(ByVal FindType As FindTypes)

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' Get the list of registered users from the database
            Dim objUser As New UserController

            Dim ds As DataSet
            Select Case FindType
                Case FindTypes.Filter
                    ds = objUser.GetUsersDataSet(PortalId, Me.FilterChar, txtNoiDung.Text.Trim(), "-1")
                Case FindTypes.Search
                    ds = objUser.GetUsersDataSet(PortalId, Me.FilterChar, txtNoiDung.Text.Trim(), ddlHinhThucTim.SelectedValue)
            End Select
            grdUsers.DataSource = ds
            grdUsers.DataBind()
            grdABC.DataSource = objUser.GetUsersDataSet(PortalId, " ")
            grdABC.DataBind()
            objUser = Nothing
        End Sub

        'Public Function FormatURL(ByVal strKeyName As String, ByVal strKeyValue As String) As String
        '    Try
        '        FormatURL = EditURL(strKeyName, strKeyValue) & Convert.ToString(IIf(strFilter <> "", "&filter=" & strFilter, ""))

        '    Catch exc As Exception 'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Function

        'Public Function DisplayAddress(ByVal Unit As Object, ByVal Street As Object, ByVal City As Object, ByVal Region As Object, ByVal Country As Object, ByVal PostalCode As Object) As String
        '    Try
        '        DisplayAddress = FormatAddress(Unit, Street, City, Region, Country, PostalCode)

        '    Catch exc As Exception 'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Function

        'Public Function DisplayEmail(ByVal Email As Object) As String
        '    Try
        '        DisplayEmail = FormatEmail(Email)

        '    Catch exc As Exception 'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Function

        'Public Function DisplayLastLogin(ByVal LastLogin As Date) As String
        '    Try
        '        If Not Null.IsNull(LastLogin) Then
        '            DisplayLastLogin = LastLogin.ToString
        '        Else
        '            DisplayLastLogin = ""
        '        End If

        '    Catch exc As Exception 'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Function

        Private Sub grdABC_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdABC.ItemCreated
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
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        '********************************************************************
        'Purpose           	:Filters users of portal by Alphabet
        'Params         	:System params
        'Returns         	:None
        'Created date		:Unknown
        'Creator		    :Unknown
        'Modified date  	:Oct 21st 2005
        'Modifier        	:Phuocdd
        '********************************************************************
        Private Sub grdABC_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdABC.ItemCommand
            Try
                If e.CommandName = "filter" Then
                    Me.FilterChar = Convert.ToString(e.CommandArgument)
                    Me.CurrFindType = FindTypes.Filter
                    Me.grdUsers.CurrentPageIndex = 0
                    BindData(Me.CurrFindType)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        'Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        '    Try
        '        Dim objUser As New UserController

        '        objUser.DeleteUsers(PortalId)

        '        BindData()

        '    Catch exc As Exception 'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub
        Private Sub grdUsers_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdUsers.PageIndexChanged
            grdUsers.CurrentPageIndex = e.NewPageIndex
            BindData(Me.CurrFindType)
        End Sub

        Private Sub cmdAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
            Response.Redirect(EditURL("UserID", ""))
        End Sub

        Private Sub UpdateLDAPUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateLDAPUser.Click
            ' get ldap users
            Dim ad As New ActiveDirectory
            ad.DomainName = ConfigurationSettings.AppSettings("DomainName")
            ad.Filters = ConfigurationSettings.AppSettings("Filters")
            ad.Username = ConfigurationSettings.AppSettings("DefName")
            ad.Password = ConfigurationSettings.AppSettings("DefPass")
            ' users information
            Dim al As New ArrayList
            al.Add(ConfigurationSettings.AppSettings("UNameID"))
            al.Add(ConfigurationSettings.AppSettings("MailID"))
            al.Add(ConfigurationSettings.AppSettings("FNameID"))
            Dim dt As DataTable = ad.GetTableUser(al)

            ' get system users
            Dim uc As New UserController
            Dim ds As DataSet
            ds = uc.GetUsersDataSet(PortalId, strFilter)

            ' low case username
            al.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                If Not dt.Rows(i)(ConfigurationSettings.AppSettings("UNameID")) Is System.DBNull.Value Then
                    al.Add(CType(dt.Rows(i)(ConfigurationSettings.AppSettings("UNameID")), String).ToLower)
                End If
            Next
            ' check duplicate
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim j As Integer = al.IndexOf(CType(ds.Tables(0).Rows(i)(ConfigurationSettings.AppSettings("usernameID")), String).ToLower)
                If Not j < 0 Then
                    dt.Rows.RemoveAt(j)
                    al.RemoveAt(j)
                End If
            Next

            ' add ldap users into system
            Dim AffiliateId As Integer = Convert.ToInt32(Null.SetNull(AffiliateId))
            If Not Request.Cookies("AffiliateId") Is Nothing Then
                AffiliateId = Integer.Parse(Request.Cookies("AffiliateId").Value)
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Try
                    Dim fname As String = Nothing
                    Dim mail As String = Nothing
                    Dim uname As String = Nothing
                    ' check information is null
                    If Not dt.Rows(i)(ConfigurationSettings.AppSettings("FNameID")) Is System.DBNull.Value Then fname = CType(dt.Rows(i)(ConfigurationSettings.AppSettings("FNameID")), String)
                    If Not dt.Rows(i)(ConfigurationSettings.AppSettings("MailID")) Is System.DBNull.Value Then mail = CType(dt.Rows(i)(ConfigurationSettings.AppSettings("MailID")), String)
                    If Not dt.Rows(i)(ConfigurationSettings.AppSettings("UNameID")) Is System.DBNull.Value Then uname = CType(dt.Rows(i)(ConfigurationSettings.AppSettings("UNameID")), String)

                    ' adding
                    Dim id As String
                    id = uc.AddUser(PortalId, fname, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, mail, uname, Nothing, True, AffiliateId, Nothing, Nothing)
                    Dim ui As UserInfo = uc.GetUser(PortalId, id)
                    uc.UpdateUser(PortalId, ui.UserID, ui.FullName, ui.Unit, ui.Street, ui.City, ui.Region, ui.PostalCode, ui.Country, ui.Telephone, ui.Email, uname, Nothing, True, ui.MaChucDanh, ui.MaPhongBan)
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            Next
            'Bind the data sau khi dong bo user LDAP vao database
            BindData(Me.CurrFindType)
        End Sub

        '********************************************************************
        'Purpose           	:Search users
        'Params         	:System
        'Returns         	:None
        'Created date		:Unknown
        'Creator		    :Unknown
        'Modified date  	:Oct 21st 2005
        'Modifier        	:Phuocdd
        '********************************************************************
        Private Sub lnkTim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTim.Click
            Me.CurrFindType = FindTypes.Search
            Me.grdUsers.CurrentPageIndex = 0
            BindData(Me.CurrFindType)
        End Sub
    End Class

End Namespace
