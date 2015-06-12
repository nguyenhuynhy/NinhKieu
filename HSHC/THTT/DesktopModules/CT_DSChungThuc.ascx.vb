Imports PortalQH
Imports HSHC
Imports System.Configuration
Imports System
Imports System.Web
Namespace THTT
    Public Class CT_DSChungThuc
        Inherits PortalQH.PortalModuleControl

        Private PageIndex As Integer = 0
        Private STT As Integer = 0
        Protected WithEvents frmDSHoSo As System.Web.UI.HtmlControls.HtmlForm
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Private SortField As String = "SoChungThuc" 'default sort column
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
            'if the page first call
            If Not Page.IsPostBack Then
                ViewState("SortField") = SortField
                ViewState("PageIndex") = PageIndex
                txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
                DataGrid1.PageSize = CInt(txtSoDong.Text)

            Else
                ViewState("PageIndex") = PageIndex
                SortField = ViewState("SortField").ToString
            End If
            Binddata()

        End Sub

        'Get news from database
        Function MyQueryMethod() As System.Data.DataSet

            Dim objHSCT As New HoSoChungThucController
            Dim ds As New DataSet
            ds = objHSCT.GetHoSoChungThucByLoai(ConfigurationSettings.AppSettings("DB_CHUNGTHUC"), CType(Session("TuNgay"), String), CType(Session("DenNgay"), String), Trim(Request.QueryString("DocCode")))

            Return ds
        End Function
        Private Sub Binddata()

            Dim ds As New DataSet

            ds = MyQueryMethod()
            'On Error Resume Next
            Dim iCount As Long = ds.Tables(0).Rows.Count
            If iCount = 0 Then
                Exit Sub
                'tell the user search returned no messages"
            End If

            ds.Tables(0).DefaultView.Sort = SortField
            DataGrid1.DataSource = ds.Tables(0).DefaultView

            DataGrid1.DataBind()
            ds.Dispose()
        End Sub

        Private Function GetMaxPUBID() As Long
            Dim maxtid As Long
            Dim sqlConnection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(ConfigurationSettings.AppSettings("connectionstring_forums"))
            Dim sqlCommand As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("SELECT isnull(MAX(PUBID),-1) FROM NEWSPUB", sqlConnection)
            Try
                sqlConnection.Open()
                maxtid = CType(sqlCommand.ExecuteScalar(), Long)

            Catch e As Exception
                Throw e
            Finally
                If sqlConnection.State = ConnectionState.Open Then
                    sqlConnection.Close()
                End If
            End Try
            Return maxtid
        End Function

        Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            'LoadGrid()
            Binddata()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "S? dòng hi?n th? không h?p l?")
                txtSoDong.Text = CStr(DataGrid1.PageSize)
                Exit Sub
            End If
            If DataGrid1.PageSize <> CInt(txtSoDong.Text) Then
                DataGrid1.PageSize = CInt(txtSoDong.Text)
                DataGrid1.CurrentPageIndex = 0
                Binddata()
            End If
        End Sub
        Function DetermineURL(ByVal id As String, ByVal ml As String) As String

            DetermineURL = "ChitietChungThuc.aspx?" & "ID=" & id & "&ML=" & ml

        End Function
        Function SetVNDateString(ByVal dstring As Date) As String

            SetVNDateString = ShowDate(dstring)

        End Function
        Function ShowDate(ByVal dDate As Date) As String
            Dim tmpDate As String
            If IsDBNull(dDate) Then
                Return ""
            Else
                tmpDate = Right("0" & Day(dDate), 2) & "/" & Right("0" & Month(dDate), 2) & "/" & Year(dDate)
                Return tmpDate
            End If
        End Function

        Private Sub DataGrid1_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
            SortField = e.SortExpression
            ViewState("SortField") = SortField
            Binddata()
        End Sub
        Function GetSTT() As Integer
            STT = STT + 1
            Return STT
        End Function

        
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
        Private Sub GridToExcel()
            DataGrid1.AllowPaging = False
            DataGrid1.AllowSorting = False
            DataGrid1.CurrentPageIndex = 0
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

            DataGrid1.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            If DataGrid1.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL() & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID"))
        End Sub
    End Class
End Namespace