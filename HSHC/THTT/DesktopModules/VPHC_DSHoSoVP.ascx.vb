
Imports System
Imports System.Web
Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class VPHC_DSHoSoVP
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents datagrid1 As System.Web.UI.WebControls.DataGrid
        Private PageIndex As Integer = 0
        Private STT As Integer = 0
        Protected WithEvents frmDSHoSo As System.Web.UI.HtmlControls.HtmlForm
        Private SortField As String = "TINHTRANG" 'default sort column
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgHeader As System.Web.UI.WebControls.Image
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
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Not Page.IsPostBack Then
                Select Case Request.QueryString("Loai")
                    Case "TOCAO"
                        datagrid1.Columns(1).HeaderText = "Số CV trả lời"
                        datagrid1.Columns(2).HeaderText = "Người bị tố cáo"
                        imgHeader.ImageUrl = "images/Title_DSHoSoToCao.jpg"
                    Case "CUONGCHE"
                        datagrid1.Columns(1).HeaderText = "Số QĐ cưỡng chế"
                        datagrid1.Columns(4).HeaderText = "Nội dung quyết định"
                        imgHeader.ImageUrl = "images/Title_DSHoSocuongche.jpg"
                    Case "KHIEUNAIQD"
                        datagrid1.Columns(1).HeaderText = "Số CV"
                        datagrid1.Columns(4).HeaderText = "Nội dung khiếu nại"
                        imgHeader.ImageUrl = "images/Title_DSHoSokhieunai.jpg"
                    Case "TONGDATQD"
                        imgHeader.ImageUrl = "images/Title_DSHoSoTongDat.jpg"
                End Select
                ViewState("PageIndex") = PageIndex
                ViewState("SortField") = SortField
                txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
                datagrid1.PageSize = CInt(txtSoDong.Text)
                'Binddata()

            Else
                ViewState("PageIndex") = PageIndex
                SortField = ViewState("SortField").ToString
                'Binddata()
            End If
            Binddata()
        End Sub

        Private Sub Binddata()
            Dim ds As New DataSet
            Dim objVPHC As New ViPhamHanhChinhController
            ds = objVPHC.GetHoSoVPHCByLoai(Request.QueryString("DB"), Session("TuNgay").ToString, Session("DenNgay").ToString, ConfigurationSettings.AppSettings("commonDB"), Request.QueryString("Loai"))
            'On Error Resume Next
            Dim iCount As Long = ds.Tables(0).Rows.Count
            If iCount = 0 Then
                Exit Sub
                'tell the user search returned no messages"
            End If
            'datagrid1.CurrentPageIndex = PageIndex
            'get current STT to show
            'STT = CInt(txtSoDong.Text) * datagrid1.CurrentPageIndex
            ds.Tables(0).DefaultView.Sort = SortField
            datagrid1.DataSource = ds.Tables(0).DefaultView

            datagrid1.DataBind()
            ds.Dispose()
        End Sub

        Private Sub DeSelectAnySelectedItem()
            Me.datagrid1.SelectedIndex = -1
        End Sub

        'Public Sub DataGrid1_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        '    DeSelectAnySelectedItem()
        '    PageIndex = e.NewPageIndex
        '    ViewState("PageIndex") = PageIndex
        '    Binddata()
        'End Sub
        Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles datagrid1.PageIndexChanged
            datagrid1.CurrentPageIndex = e.NewPageIndex
            'LoadGrid()
            Binddata()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(datagrid1.PageSize)
                Exit Sub
            End If
            If datagrid1.PageSize <> CInt(txtSoDong.Text) Then
                datagrid1.PageSize = CInt(txtSoDong.Text)
                datagrid1.CurrentPageIndex = 0
                Binddata()
            End If
        End Sub


        Function GetCtr(ByVal PhanLoai As String) As String
            Select Case PhanLoai
                Case "BB"
                    Return "CHITIETBB"
                Case "KN"
                    Return "CHITIETKN"
                Case Else
                    Return "CHITIETRAQD"
            End Select
        End Function

        'Function SetVNDateString(ByVal dstring As String) As String
        '    SetVNDateString = ShowDate(dstring)
        'End Function

        Private Sub DataGrid1_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
            SortField = e.SortExpression
            ViewState("SortField") = SortField
            Binddata()
        End Sub
        'Function GetSTT() As Integer
        '    STT = STT + 1
        '    Return STT
        'End Function
        Function DoiTenColumn() As String
            Dim strReturn As String
            strReturn = "Số QĐ"
            If Request.QueryString("Loai") = "TOCAO" Then
                strReturn = "Số CV trả lời"
            End If
            DoiTenColumn = strReturn
        End Function

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL() & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID"))
        End Sub
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            End If
            Return strURL
        End Function

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
            If datagrid1.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub

        Private Sub GridToExcel()
            datagrid1.AllowPaging = False
            datagrid1.AllowSorting = False
            datagrid1.CurrentPageIndex = 0
            Binddata()
            RenderGrid()
        End Sub

        Private Sub RenderGrid()

            Dim strFileName As String = "DanhSachHoSo.xls"
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

            datagrid1.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub
    End Class

End Namespace