Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class ThongKeDoThi
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.ImageButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton

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
            Try
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Init_State()
                End If
                LoadGrid()
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub SetAttributesControl()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            Me.btnTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            Me.btnDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub
        Private Sub Init_State()
            Dim glbFile As String
            Dim mSoNgay As Integer

            glbFile = ConfigurationSettings.AppSettings("PathXML") & "GLOBALHSHC.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
        End Sub
        Private Sub LoadGrid()
            Dim objThongKe As New ThongKeDoThiController
            Dim ds As DataSet
            ds = objThongKe.ThongKeDoThi_TheoPhuong(txtTuNgay.Text, txtDenNgay.Text, ConfigurationSettings.AppSettings("DBCOMMON").ToString(), CStr(Request.Params("SelectID")))
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            ds = Nothing
            objThongKe = Nothing
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTimKiem.Click
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub

        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            InitHeaderGrid()
        End Sub

        Private Sub InitHeaderGrid()
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell
            'row 1
            dgitem.Cells.Add(InitCell("STT", 1, 2))
            dgitem.Cells.Add(InitCell("Phường", 1, 2))
            dgitem.Cells.Add(InitCell("Kiên cố", 2, 1))
            dgitem.Cells.Add(InitCell("Bán kiên cố", 2, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)
            dgitem = Nothing
            'row 2
            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Cấp phép", 1, 1))
            dgitem.Cells.Add(InitCell("Hoàn công", 1, 1))
            dgitem.Cells.Add(InitCell("Cấp phép", 1, 1))
            dgitem.Cells.Add(InitCell("Hoàn công", 1, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(1, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(2)
            dgitem = Nothing
            mycell = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
            If dgdDanhSach.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub

        Private Sub GridToExcel()
            dgdDanhSach.AllowPaging = False
            dgdDanhSach.AllowSorting = False
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
            RenderGrid()
        End Sub

        Private Sub RenderGrid()

            Dim strFileName As String = "Danhsachphoban.xls"
            Response.Clear()
            Response.ContentType = "application/vnd.ms-excel"
            Response.Charset = ""
            Response.AddHeader("Content-Disposition", "attachment; filename=""" & strFileName & """")
            ' Turn off the view state.
            Me.EnableViewState = False
            Dim tw As New System.IO.StringWriter
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim str As String = ""
            Dim lbl As New Label

            dgdDanhSach.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub
    End Class
End Namespace

