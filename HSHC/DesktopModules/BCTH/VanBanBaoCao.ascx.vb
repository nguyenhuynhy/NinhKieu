Imports PortalQH
Imports HSHC
Imports System.Configuration
Public Class VanBanBaoCao
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDonVi As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDonVi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblKyBaoCao As System.Web.UI.WebControls.Label
    Protected WithEvents ddlKyBaoCao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblNam As System.Web.UI.WebControls.Label
    Protected WithEvents ddlNam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnTimKiem As System.Web.UI.WebControls.Image
    Protected WithEvents lnkbtnChon As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblSoDong As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblLinhVucBC As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnThem1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnAdd1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnThem As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnAdd As System.Web.UI.WebControls.LinkButton


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Public Property State() As String
        Get
            If Not ViewState("VBBCState") Is Nothing Then
                Return CType(ViewState("VBBCState"), String)
            Else
                Return "CREATE"
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("VBBCState") = Value
        End Set
    End Property
    Public Property VBBCID() As String
        Get
            If Not ViewState("VBBCID") Is Nothing Then
                Return CType(ViewState("VBBCID"), String)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("VBBCID") = Value
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.IsPostBack Then
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Me.State = _portalSettings.ActiveTab.KeyWords
            txtSoDong.Text = "10"
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            Init_Control()
            BindControlInMe()
            BindGrid()
        End If
    End Sub
    Private Sub Init_Control()
        lnkbtnChon.Attributes.Add("onclick", "javascript:return checkKyBaoCao('" & ddlKyBaoCao.ClientID & "');")
        txtSoDong.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
    End Sub
    Private Sub BindGrid()
        Dim vbbcCon As New VanBanBaoCaoController
        Dim ds As DataSet
        ds = vbbcCon.GetVanBanBaoCaoList(ConfigurationSettings.AppSettings("db_bcth"))
        BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
        ds = Nothing
        vbbcCon = Nothing
    End Sub
    Private Sub BindControlInMe()
        BindControl.BindDropDownList(ddlDonVi, "DonVi")
        BindControl.BindDropDownList_StoreProc(ddlKyBaoCao, True, "1", ConfigurationSettings.AppSettings("db_bcth") + "..sp_GetAllKyBaoCao")
        BindControl.BindDropDownList_StoreProc(ddlLinhVuc, True, "1", ConfigurationSettings.AppSettings("db_bcth") + "..sp_getALLLinhVuc")
        BindControl.BindDropDownList(ddlNam, "Nam")
        ddlNam.SelectedValue = Now.Year.ToString
    End Sub
    Private Sub LoadGrid()
        Dim strMaKyBaoCao As String = ddlKyBaoCao.SelectedValue
        Dim strDonVi As String = ddlDonVi.SelectedValue
        Dim strLinhVuc As String = ddlLinhVuc.SelectedValue
        Dim strNam As String = ddlNam.SelectedValue
        Dim vbbcCon As New VanBanBaoCaoController
        Dim ds As DataSet
        ds = vbbcCon.GetVanBanBaoCao(ConfigurationSettings.AppSettings("db_bcth"), strDonVi, strLinhVuc, strMaKyBaoCao, strNam)
        BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
        ds = Nothing
        vbbcCon = Nothing
    End Sub
    Private Sub lnkbtnChon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnChon.Click
        dgdDanhSach.CurrentPageIndex = 0
        LoadGrid()
    End Sub
    Private Sub prepareAdd()
        Dim strURL As String
        strURL = EditURL("", "", "ADD")
        Response.Redirect(strURL)
    End Sub
    Private Sub lnkbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtnAdd.Click
        Me.prepareAdd()
    End Sub
    Private Sub dgdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.ItemCommand
        Select Case e.CommandName
            Case "EditVBBC"
                Dim strCtl As String
                strCtl = "EDIT"
                Dim strURL As String
                strURL = EditURL("ID", CStr(e.CommandArgument), strCtl)
                Response.Redirect(strURL)
        End Select
    End Sub

    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        LoadGrid()
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
            LoadGrid()
        End If
    End Sub
End Class
