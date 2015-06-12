Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class ThongKeKinhDoanh
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents trFilter As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trFilter2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trFilter1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

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

                Dim strType As String
                If Request.QueryString("Type") Is Nothing Then
                    strType = "1"
                Else
                    strType = CType(Request.QueryString("Type"), String)
                End If
                Select Case strType

                    Case "3" : lblTieuDe.Text = "Thống kê tình hình kinh doanh theo ngành"
                        trFilter.Visible = True
                        trFilter1.Visible = True
                        trFilter2.Visible = True
                    Case "1" : lblTieuDe.Text = "Thống kê tình hình kinh doanh theo phường"
                        trFilter.Visible = True
                        trFilter1.Visible = True
                        trFilter2.Visible = True
                    Case "4" : lblTieuDe.Text = "Thống kê tình hình kinh doanh theo năm"
                        trFilter.Visible = False
                        trFilter1.Visible = False
                        trFilter2.Visible = False
                End Select
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Init_State()
                End If
                LoadGrid()
                GetTotal(dgdDanhSach, "hplSoLuongKD", False)
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub SetAttributesControl()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            'Me.btnTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            'Me.btnDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
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
            If Not Request.QueryString("TuNgay") Is Nothing Then
                txtTuNgay.Text = Request.QueryString("TuNgay")
            End If
            If Not Request.QueryString("DenNgay") Is Nothing Then
                txtDenNgay.Text = Request.QueryString("DenNgay")
            End If
        End Sub
        Private Sub LoadGrid()
            Dim objThongKe As New ThongKeKinhDoanhController
            Dim ds As DataSet
            Dim strType As String
            If Request.QueryString("Type") Is Nothing Then
                strType = "1"
            Else
                strType = CType(Request.QueryString("Type"), String)
            End If
            Select Case strType
                Case "3" : ds = objThongKe.ThongKeKinhDoanh_TheoNganh(txtTuNgay.Text, txtDenNgay.Text, CStr(Request.Params("SelectID")))
                Case "1" : ds = objThongKe.ThongKeKinhDoanh_TheoPhuong(txtTuNgay.Text, txtDenNgay.Text, ConfigurationSettings.AppSettings("commonDB").ToString(), CStr(Request.Params("SelectID")))
                Case "4" : ds = objThongKe.ThongKeKinhDoanh_TheoNam(Request.Params("SelectID").ToString())
            End Select

            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            ds = Nothing
            objThongKe = Nothing
        End Sub

        

        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            InitHeaderGrid()
        End Sub

        Private Sub InitHeaderGrid()
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell
            Dim TypeName As String
            Dim strType As String
            If Request.QueryString("Type") Is Nothing Then
                strType = "1"
            Else
                strType = CType(Request.QueryString("Type"), String)
            End If
            Select Case strType
                Case "3" : TypeName = "Ngành nghề"
                Case "4" : TypeName = "Năm"
                Case "1" : TypeName = "Phường chợ"
                Case Else : TypeName = ""
            End Select
            'row 1
            dgitem.Cells.Add(InitCell("STT", 1, 3))
            dgitem.Cells.Add(InitCell(TypeName, 1, 3))
            dgitem.Cells.Add(InitCell("Hộ kinh Doanh", 4, 1))
            dgitem.Cells.Add(InitCell("Hộ ngưng kinh doanh", 2, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)
            dgitem = Nothing
            'row 2
            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Đã cấp giấy CN ĐKKD", 2, 1))
            dgitem.Cells.Add(InitCell("Đang hoạt động", 2, 1))
            dgitem.Cells.Add(InitCell("Số lượng", , 2))
            dgitem.Cells.Add(InitCell("Vốn ( Triệu đồng )", , 2))
            dgdDanhSach.Controls(0).Controls.AddAt(1, dgitem)

            'row 3
            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Số lượng"))
            dgitem.Cells.Add(InitCell("Vốn ( Triệu đồng )"))
            dgitem.Cells.Add(InitCell("Số lượng"))
            dgitem.Cells.Add(InitCell("Vốn ( Triệu đồng )"))
            dgdDanhSach.Controls(0).Controls.AddAt(2, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(3)
            'dgdDanhSach.Controls(0).Controls.RemoveAt(3)

            dgitem = Nothing
            mycell = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        

        Private Sub GridToExcel()
            dgdDanhSach.AllowPaging = False
            dgdDanhSach.AllowSorting = False
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
            RenderGrid()
        End Sub

        Private Sub RenderGrid()

            Dim strFileName As String = "Thongkekinhdoanh.xls"
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

            InitHeaderGrid()
            dgdDanhSach.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub
        ' GetMidURL("SelectID",Request.Params("SelectID") & "&Val=" & RTrim(DataBinder.Eval(Container.DataItem, "Ma")) & "&SelectTitle=" & Request.Params("SelectTitle") & "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text,"DSHOKD")
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            'If Not Request.Params("SelectID") Is Nothing Then
            '    strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            'End If
            If Not Request.QueryString("Type") Is Nothing Then
                strURL = strURL & "&Type=" & Request.QueryString("Type")
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                strURL = strURL & "&SelectChildIndex=" & Request.Params("SelectChildIndex")
            End If
            If Not Request.Params("SelectChildId") Is Nothing Then
                strURL = strURL & "&SelectChildId=" & Request.Params("SelectChildId")
            End If
            Return strURL

        End Function

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            If dgdDanhSach.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub
    End Class
End Namespace

