Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class DanhSachHoKinhDoanh
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton

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
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub Init_State()
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
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

            If Not Request.QueryString("Type") Is Nothing Then
                strURL = strURL & "&Type=" & Request.QueryString("Type")
            Else
                strURL = strURL & "&Type=1"
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                strURL = strURL & "&SelectChildIndex=" & Request.Params("SelectChildIndex")
            End If
            If Not Request.Params("SelectChildId") Is Nothing Then
                strURL = strURL & "&SelectChildId=" & Request.Params("SelectChildId")
            End If
            Return strURL

        End Function
        Private Sub LoadGrid()
            Dim objDanhSach As New DanhSachHoSoKDController
            Dim ds As DataSet
            Dim strGroup As String
            Dim strURL As String

            strURL = GetMidURL("ID", "value" & "&Val=" & RTrim(Request.Params("Val").ToString()) & "&TuNgay=" & Request.Params("TuNgay").ToString() & "&DenNgay=" & Request.Params("DenNgay").ToString() & "&Group=" & Request.Params("Group").ToString(), "CHITIETHOCATHE")

            Select Case Request.Params("Group").ToString()
                Case "SL08" : strGroup = "08"
                Case "SLHD" : strGroup = "HD"
                Case "NGUNG" : strGroup = "NGUNG"
                Case Else : strGroup = "ZZ"
            End Select
            Dim strType As String
            If Request.QueryString("Type") Is Nothing Then
                strType = "1"
            Else
                strType = Request.QueryString("Type")
            End If
            Select Case strType
                Case "1"
                    ds = objDanhSach.DanhSachHoSoKD_TheoPhuong(Request.Params("TuNgay").ToString(), Request.Params("DenNgay").ToString(), Request.Params("Val").ToString(), strGroup, Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString(), strURL)
                Case "3"
                    ds = objDanhSach.DanhSachHoSoKD_TheoNganh(Request.Params("TuNgay").ToString(), Request.Params("DenNgay").ToString(), Request.Params("Val").ToString(), strGroup, Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString(), strURL)
                Case "4"
                    ds = objDanhSach.DanhSachHoSoKD_TheoNam(Request.Params("Val").ToString(), strGroup, Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString(), strURL)
            End Select

            'BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số GP", "100,100,200,100,200,200", False, True)
            SetAlignGrid()
            ds = Nothing
            objDanhSach = Nothing
        End Sub
        Private Sub SetAlignGrid()
            dgdDanhSach.Columns(4).ItemStyle.HorizontalAlign() = HorizontalAlign.Right
            dgdDanhSach.Columns(2).ItemStyle.HorizontalAlign() = HorizontalAlign.Center
        End Sub

       

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
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

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            If dgdDanhSach.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim iIndex As String
            Dim iChildIndex As String
            Dim iChildID As String
            Dim iType As String
            Dim iSelectID As String
            Dim iSelectTitle As String

            If Not Request.Params("SelectTitle") Is Nothing Then
                iSelectTitle = Request.Params("SelectTitle").ToString()
            Else
                iSelectTitle = "0"
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
            If Not Request.Params("SelectChildID") Is Nothing Then
                iChildID = Request.Params("SelectChildID").ToString()
            Else
                iChildID = "1"
            End If
            If Not Request.QueryString("Type") Is Nothing Then
                iType = Request.QueryString("Type").ToString()
            Else
                iType = "1"
            End If
            Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&SelectChildID=" & iChildID & "&TuNgay=" & Request.Params("TuNgay").ToString() & "&DenNgay=" & Request.Params("DenNgay").ToString())
        End Sub
    End Class

End Namespace
