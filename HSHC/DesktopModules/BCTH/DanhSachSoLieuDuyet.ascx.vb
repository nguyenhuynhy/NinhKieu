Imports PortalQH
Imports HSHC
Imports System.Configuration
Public Class DanhSachSoLieuDuyet
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDongHienThi As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblDonVi As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDonVi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblNam As System.Web.UI.WebControls.Label
    Protected WithEvents ddlNam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnTimKiem As System.Web.UI.WebControls.Image
    Protected WithEvents lnkbtnChon As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblKyBaoCao As System.Web.UI.WebControls.Label
    Protected WithEvents ddlKyBaoCao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Dim strLoai As String

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'strLoai = Request.QueryString("tabid").ToString
        strLoai = gActiveDB()
        Select Case strLoai
            Case "SLCD" : lblTitle.Text = ".::Số liệu chờ duyệt::."
            Case "SLDD" : lblTitle.Text = ".::Số liệu đã duyệt::."
        End Select
        If Not Me.IsPostBack Then
            Init_State()
            BindGrid()
        End If
        If Request.Params("ToExcel") = "True" Then
            ExportToExcel()
        End If
        
    End Sub
    Private Sub Init_State()
        txtSoDongHienThi.Text = CStr(GetSoDongHienThiLuoi())
        dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
        txtSoDongHienThi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
        BindControl.BindDropDownList(ddlDonVi, "DonVi")
        BindControl.BindDropDownList_StoreProc(ddlKyBaoCao, True, "1", ConfigurationSettings.AppSettings("db_bcth") + "..sp_GetAllKyBaoCao")
        BindControl.BindDropDownList(ddlNam, "Nam")
        ddlNam.SelectedValue = Now.Year.ToString

    End Sub
    Private Sub BindGrid()
        Dim objSL As New SoLieuController
        Dim ds As DataSet
        Dim strMaKyBaoCao As String = ddlKyBaoCao.SelectedValue
        Dim strDonVi As String = ddlDonVi.SelectedValue
        Dim strNam As String = ddlNam.SelectedValue
        ds = objSL.getDanhSachSoLieuDuyet(ConfigurationSettings.AppSettings("db_bcth"), strLoai, strMaKyBaoCao, strDonVi, strNam)
        BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
        ds = Nothing
        objSL = Nothing
    End Sub
    Private Sub txtSoDongHienThi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDongHienThi.TextChanged
        If Not IsInteger(txtSoDongHienThi.Text) Or Trim(txtSoDongHienThi.Text) = "" Or Val(txtSoDongHienThi.Text) = 0 Then
            txtSoDongHienThi.Text = CStr(dgdDanhSach.PageSize)
            Exit Sub
        End If
        If dgdDanhSach.PageSize <> CInt(txtSoDongHienThi.Text) Then
            dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
            dgdDanhSach.CurrentPageIndex = 0
        End If
        BindGrid()
    End Sub
    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
        'Response.Redirect(EditURL("ToExcel", "True", ""))
        If dgdDanhSach.Items.Count > 0 Then
            ExportToExcel()
        Else
            SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Exit Sub
        End If

    End Sub
    Private Sub RenderGrid()
        
        Dim strFileName As String = "DanhSach.xls"

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=""" & strFileName & """")
        'Response.ContentEncoding = System.Text.Encoding.Unicode

        ' Turn off the view state.
        Me.EnableViewState = False
        Dim tw As New System.IO.StringWriter
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Replace_WebControls(dgdDanhSach, "txtMaCha", "txtIsData", "txtIsSum", "lblSoTT")
        ' Get the HTML for the control.
        lblTitle.Text = "<b><Font size=3>" + lblTitle.Text + "</font></b>"
        lblTitle.RenderControl(hw)
        dgdDanhSach.RenderControl(hw)
        ' Write the HTML back to the browser.
        Response.Write(tw.ToString())
        ' End the response.
        Response.End()
    End Sub
    Private Sub ExportToExcel()
        dgdDanhSach.AllowPaging = False
        dgdDanhSach.AllowSorting = False
        dgdDanhSach.CurrentPageIndex = 0
        BindGrid()
        RenderGrid()
    End Sub

    Private Sub lnkbtnChon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnChon.Click
        dgdDanhSach.CurrentPageIndex = 0
        BindGrid()
    End Sub
End Class
