Imports PortalQH
Namespace DOITHOAI
    Public Class ChonNguoiNhanCauHoi
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlHinhThucTim As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lnkTim As System.Web.UI.WebControls.LinkButton
        Protected WithEvents grdABC As System.Web.UI.WebControls.DataGrid
        Protected WithEvents grdUsers As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Enum FindTypes As Integer
            Search 'without use alphabet
            Filter 'by alphabet
        End Enum
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                BindData(FindTypes.Filter)

                btnTroVe.Attributes.Add("onclick", "javascript:window.close();")
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Sub BindData(ByVal FindType As FindTypes)

            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            ' Get the list of registered users from the database
            Dim objUser As New UserController

            Dim ds As DataSet
            Select Case FindType
                Case FindTypes.Filter
                    ds = objUser.GetUsersDataSet(_portalSettings.PortalId, Me.FilterChar, txtNoiDung.Text.Trim(), "-1")
                Case FindTypes.Search
                    ds = objUser.GetUsersDataSet(_portalSettings.PortalId, Me.FilterChar, txtNoiDung.Text.Trim(), ddlHinhThucTim.SelectedValue)
            End Select
            grdUsers.DataSource = ds
            grdUsers.DataBind()
            grdABC.DataSource = objUser.GetUsersDataSet(_portalSettings.PortalId, " ")
            grdABC.DataBind()
            objUser = Nothing
        End Sub

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
                    BindData(Me.CurrFindType)
                End If

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub grdUsers_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdUsers.PageIndexChanged
            grdUsers.CurrentPageIndex = e.NewPageIndex
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
            BindData(Me.CurrFindType)
        End Sub

        Private Sub grdUsers_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdUsers.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim obj As ImageButton
                Dim objLabel As Label
                obj = CType(e.Item.FindControl("btnChon"), ImageButton)
                objLabel = CType(e.Item.FindControl("lblTenDangNhap"), Label)
                If Not obj Is Nothing And Not objLabel Is Nothing Then
                    obj.Attributes.Add("onclick", "javascript:form1_onsubmit(" & objLabel.ClientID & ");")
                End If
            End If
        End Sub
    End Class
End Namespace