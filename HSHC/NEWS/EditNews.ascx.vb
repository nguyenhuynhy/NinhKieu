Imports PortalQH
Imports System.Configuration
Imports System.IO
Public Class EditNews
    Inherits PortalQH.PortalModuleControl

    Private Const NEWSID_COL As Integer = 1
    Public Property State() As String
        Get
            If Not ViewState("NewsState") Is Nothing Then
                Return CType(ViewState("NewsState"), String)
            Else
                Return "CREATE"
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("NewsState") = Value
        End Set
    End Property

    'Luu lai trang thai control dang edit hay list cac news
    Public Property WorkState() As String
        Get
            If Not ViewState("WorkState") Is Nothing Then
                Return CType(ViewState("WorkState"), String)
            Else
                Return "LIST"
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("WorkState") = Value
        End Set
    End Property

    Public Property NewsID() As String
        Get
            If Not ViewState("NewsID") Is Nothing Then
                Return CType(ViewState("NewsID"), String)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("NewsID") = Value
        End Set
    End Property

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSoDong As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCategories As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkbtnChon As System.Web.UI.WebControls.LinkButton
    Protected WithEvents imgbtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnAdd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents imgbtnDuyet As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnDuyet As System.Web.UI.WebControls.LinkButton
    Protected WithEvents pnlList As System.Web.UI.WebControls.Panel
    Protected WithEvents imgbtnBack As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnBack As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTieude As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgDate As System.Web.UI.WebControls.Image

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Request("hBookID") Is Nothing And Request("hBookID") <> "" Then
            Me.NewsID = Request("hBookID")
            Me.delNews()
        End If
        If Not Me.IsPostBack Then
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Me.State = _portalSettings.ActiveTab.KeyWords
            Me.setupGUI()
            Me.getDropDownList()
            Me.ddlCategories.SelectedIndex = 0
            txtSoDong.Text = "10"
            dgdDanhSach.AllowPaging = True
            dgdDanhSach.AllowCustomPaging = True
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            dgdDanhSach.PagerStyle.Mode = PagerMode.NumericPages
            LoadGrid(dgdDanhSach.CurrentPageIndex)
        End If
        Dim strTabID As String
    End Sub

    Private Sub setupGUI()
        Me.pnlList.Visible = Me.WorkState.Equals("LIST")
        Me.lnkbtnAdd.Visible = Me.State.Equals("CREATE")
        Me.imgbtnAdd.Visible = Me.State.Equals("CREATE")
        'Tam thoi invisible button back
        Me.lnkbtnBack.Visible = False
        Me.imgbtnBack.Visible = False
    End Sub

    Private Sub aprNews()
        Dim objNews As New NewsController
        Dim result As Integer
        Dim newsid As String
        newsid = ""
        For Each item As DataGridItem In Me.dgdDanhSach.Items
            If Not item.FindControl("chkDuyet") Is Nothing Then
                If CType(item.FindControl("chkDuyet"), CheckBox).Checked Then
                    newsid += item.Cells(NEWSID_COL).Text & "~"
                End If
            End If
        Next
        If newsid = "" Then
            SetMSGBOX_HIDDEN(Me.Page, "Chưa chọn tin cần duyệt")
            Return
        End If
        result = objNews.updNewsState(CType(ConfigurationSettings.AppSettings("db_web"), String), newsid, CStr(Session("UserID")))
        If result < 0 Then
            SetMSGBOX_HIDDEN(Me.Page, "Không cập nhật được tin")
        Else
            Me.LoadGrid(0)
        End If
    End Sub

    Private Sub delNews()
        Dim objNews As New NewsController
        Dim result As Integer
        result = objNews.delNews(CType(ConfigurationSettings.AppSettings("db_web"), String), Me.NewsID)
        If result < 0 Then
            SetMSGBOX_HIDDEN(Me.Page, "Không xóa được tin")
        Else
            Me.LoadGrid(0)
        End If
    End Sub

    Private Sub setupGrid()
        Me.dgdDanhSach.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
        Dim colCount As Integer = Me.dgdDanhSach.Columns.Count - 1
        Me.dgdDanhSach.Columns(colCount - 1).Visible = (Me.State <> "PUBLISHED" And Me.State <> "PUBLISH")
        Me.dgdDanhSach.Columns(colCount - 2).Visible = (Me.State <> "PUBLISHED" And Me.State <> "PUBLISH")
    End Sub

    Private Sub setupButton()
        Me.imgbtnDuyet.Visible = (Me.dgdDanhSach.Items.Count > 0 And Me.State <> "PUBLISHED" And Me.State <> "PUBLISH")
        Me.lnkbtnDuyet.Visible = (Me.dgdDanhSach.Items.Count > 0 And Me.State <> "PUBLISHED" And Me.State <> "PUBLISH")
    End Sub

    Private Sub getDropDownList()
        BindControl.BindDropDownList(Me.ddlCategories, CType(ConfigurationSettings.AppSettings("db_web"), String) & "..sp_GetAllDMCATEGORIES", True, "", "V")
        'BindControl.BindDropDownList(ddlCategories, CType(ConfigurationSettings.AppSettings("db_web"), String) & "..sp_GetAllDMCATEGORIES", "", "V")
    End Sub

    Public Sub LoadGrid(ByVal curPage As Integer)
        Me.setupGrid()
        Dim strCat_ID As String = Me.ddlCategories.SelectedValue
        Dim strname As String = Me.txtTitle.Text
        Dim strLanguage As String = CType(Session("Language"), String)
        If Session("Language") Is Nothing Then
            strLanguage = "V"
        End If
        Dim strState_ID As String = Me.State
        Dim ds As DataSet
        Dim totalRecords As Integer = 0
        Dim objNews As New NewsController
        If Me.State.Equals("PUBLISH") Then
            'Lay cac tin sap den ngay xuat ban
            ds = objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), strname, strCat_ID, "PUBLISHED", strLanguage, curPage + 1, dgdDanhSach.PageSize, DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"))
        ElseIf Me.State.Equals("PUBLISHED") Then
            ds = objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), strname, strCat_ID, "PUBLISHED", strLanguage, curPage + 1, dgdDanhSach.PageSize, "", DateTime.Today.ToString("dd/MM/yyyy"))
        Else
            ds = objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), strname, strCat_ID, strState_ID, strLanguage, curPage + 1, dgdDanhSach.PageSize)
        End If
        Me.dgdDanhSach.VirtualItemCount = CType(ds.Tables(1).Rows(0)("TotalRecords"), Integer)
        Me.dgdDanhSach.DataSource = ds
        Me.dgdDanhSach.DataBind()
        Me.setupButton()
    End Sub

    Private Sub prepareAdd()
        Dim strURL As String
        strURL = EditURL("", "", "ADD")
        Response.Redirect(strURL)
    End Sub

    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        Try
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            Me.LoadGrid(dgdDanhSach.CurrentPageIndex)
        Catch ex As Exception
            ProcessModuleLoadException(Me, ex)
        End Try
    End Sub

    Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
        If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
            SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
            txtSoDong.Text = CStr(dgdDanhSach.PageSize)
            Exit Sub
        End If
        If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid(dgdDanhSach.CurrentPageIndex)
        End If
    End Sub

    Private Sub dgdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.ItemCommand
        Select Case e.CommandName
            Case "editNews"
                Dim strCtl As String
                If Me.State.Equals("PUBLISH") Or Me.State.Equals("PUBLISHED") Then
                    strCtl = "VIEW"
                Else
                    strCtl = "EDIT"
                End If
                Dim strURL As String
                strURL = EditURL("ID", CStr(e.CommandArgument), strCtl)
                Response.Redirect(strURL)
            Case "delNews"
                Me.NewsID = CType(e.CommandArgument, String)
                Me.delNews()
        End Select
    End Sub

    Private Sub lnkbtnChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtnChon.Click
        dgdDanhSach.CurrentPageIndex = 0
        LoadGrid(0)
    End Sub

    Private Sub lnkbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtnAdd.Click
        Me.prepareAdd()
        'Me.setupGUI()
    End Sub

    Private Sub imgbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAdd.Click
        Me.prepareAdd()
        'Me.setupGUI()
    End Sub

    Private Sub goBack()
        Dim strURL As String
        Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
        strURL = "~/default.aspx?tabid=" & CStr(_portalSettings.ActiveTab.TabId)
        Response.Redirect(strURL)
    End Sub

    Private Sub imgbtnDuyet_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDuyet.Click
        Me.aprNews()
        Me.LoadGrid(0)
    End Sub

    Private Sub lnkbtnDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtnDuyet.Click
        Me.aprNews()
        Me.LoadGrid(0)
    End Sub
End Class