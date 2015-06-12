Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class TinhHinhCapPhoBan
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
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
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

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

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub
        Private Sub SetAttributesControl()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            'Me.btnTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            'Me.btnDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub

        

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub
        Private Sub SetAlignGrid()
            dgdDanhSach.Columns(6).ItemStyle.HorizontalAlign() = HorizontalAlign.Right
        End Sub
        Private Sub LoadGrid()
            Dim objDanhSach As New DanhSachCapPhoBanController
            Dim strURL As String
            strURL = Replace(EditURL("ID", "value" & "&SelectID=" & Request.Params("SelectID") & "&SelectTitle=" & Request.Params("SelectTitle") & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&Type=" & Request.Params("Type").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString() & "&SelectChildID=" & Request.Params("SelectChildID").ToString() & "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text, "CHITIETHOCATHE"), "-1", Session("MidOfStartPage").ToString())
            Dim ds As DataSet
            ds = objDanhSach.DanhSachCapPhoBan(Request.Params("SelectID").ToString(), txtTuNgay.Text, txtDenNgay.Text, ConfigurationSettings.AppSettings("commonDB").ToString(), strURL)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số GP", "100,100,150,300,200,100", False, True)
            SetAlignGrid()
            ds = Nothing
            objDanhSach = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            Dim iIndex As String
            Dim iChildIndex As String
            Dim iType As String
            Dim iSelectID As String
            Dim iSelectTitle As String

            If Not Request.Params("SelectTitle") Is Nothing Then
                iSelectTitle = Request.Params("SelectTitle").ToString()
            Else
                iSelectTitle = ""
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectID = Request.Params("SelectID").ToString()
            Else
                iSelectID = "0"
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                iIndex = Request.Params("SelectIndex").ToString()
            Else
                iIndex = "0"
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                iChildIndex = Request.Params("SelectChildIndex").ToString()
            Else
                iChildIndex = "0"
            End If
            If Not Request.Params("Type") Is Nothing Then
                iType = Request.Params("Type").ToString()
            Else
                iType = "1"
            End If
            Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&SelectChildID=" & Request.Params("SelectChildID").ToString())

        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "So dong hien thi khong hop le")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
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
