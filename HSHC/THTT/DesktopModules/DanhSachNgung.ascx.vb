Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class DanhSachNgung
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
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
                    BindPUBList()
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

        
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectTitle") Is Nothing Then
                strURL = strURL & "&SelectTitle=" & Request.Params("SelectTitle")
            End If

            If Not Request.Params("Type") Is Nothing Then
                strURL = strURL & "&Type=" & Request.Params("Type")
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                strURL = strURL & "&SelectChildIndex=" & Request.Params("SelectChildIndex")
            End If
            If Not Request.Params("SelectChildId") Is Nothing Then
                strURL = strURL & "&SelectChildId=" & Request.Params("SelectChildId")
            End If
            If Not Request.Params("Group") Is Nothing Then
                strURL = strURL & "&Group=" & Request.Params("Group")
            End If
            If Not Request.Params("Val") Is Nothing Then
                strURL = strURL & "&Val=" & Request.Params("Val")
            End If

            strURL = strURL & "&TuNgay=" & txtTuNgay.Text
            strURL = strURL & "&DenNgay=" & txtDenNgay.Text
            Return strURL

        End Function

        Private Sub LoadGrid()
            Dim objDanhSach As New DanhSachNgungController
            Dim Phuong As String
            Dim strURL As String

            strURL = GetMidURL("ID", "value", "CHITIETHOCATHE")
            If ddlPhuong.SelectedValue = "ZZZZ" Then
                Phuong = "%%"
            Else
                Phuong = ddlPhuong.SelectedValue()
            End If
            Dim ds As DataSet
            Dim mSoNgay As Integer

            If txtTuNgay.Text = "" Then
                Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            End If
            If txtDenNgay.Text = "" Then
                txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            End If
            If Not Request.QueryString("TuNgay") Is Nothing Then
                txtTuNgay.Text = Request.QueryString("TuNgay")
            End If
            If Not Request.QueryString("DenNgay") Is Nothing Then
                txtDenNgay.Text = Request.QueryString("DenNgay")
            End If

            ds = objDanhSach.DanhSachNgungKD(Request.Params("SelectID").ToString(), txtTuNgay.Text, txtDenNgay.Text, Phuong, ConfigurationSettings.AppSettings("commonDB").ToString(), strURL)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số GP", "100,100,200,200,100,200", False, True)
            ds = Nothing
            objDanhSach = Nothing
        End Sub
        Function WardQUERY() As System.Data.DataSet
            Dim objDanhSach As New DanhSachNgungController
            Return objDanhSach.GetPhuong(Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString())
        End Function
        Private Sub BindPUBList()
            Dim ds As New DataSet
            ds = WardQUERY()
            Dim iCount As Long = ds.Tables(0).Rows.Count
            ddlPhuong.DataSource = ds.Tables(0).DefaultView
            ddlPhuong.DataTextField = ds.Tables(0).Columns(0).ToString
            ddlPhuong.DataValueField = ds.Tables(0).Columns(1).ToString
            ddlPhuong.DataBind()
            'Select the newest PUB 
            Dim newitem As New ListItem
            newitem.Text = "Tất cả"
            newitem.Value = "ZZZZ"
            ddlPhuong.Items.Insert(0, newitem)
            'cboPhuong.SelectedIndex = cboPhuong.Items.Count - 1
            ds.Dispose()
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

            Dim strFileName As String = "Danhsachngungkinhdoanh.xls"
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

