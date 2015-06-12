Imports PortalQH
Imports System.Configuration
Public Class SearchInfo_ChiTietHoSo
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents myTable As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents dgdHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rowTitle As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents rowHistory As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnInLichSu As System.Web.UI.WebControls.LinkButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private DBName As String
    Private RptFormula As String
    Private RptValues As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        DBName = CType(Request.Params("LoaiHoSo"), String)
        CreateControls()
        LoadGrid()
    End Sub
    Private Sub LoadGrid()
        Dim objThongKe As New ThongKeBaoCaoController
        Dim ds As DataSet
        ds = objThongKe.QuaTrinhGiaiQuyet(DBName, CType(Request.Params("ID"), String))
        BindControl.BindDataGrid(ds, dgdDanhSach, True, False, False, "STT", "", "", "", 100, 300, 500)
        ds = Nothing
        ds = objThongKe.GetHistory(DBName, CType(Request.QueryString("SoGiayPhep"), String))
        rowTitle.Visible = False
        dgdHistory.Visible = False
        If Not ds Is Nothing Then
            If Not ds.Tables(0).Rows.Count = 0 Then
                rowTitle.Visible = True
                dgdHistory.Visible = True
                BindControl.BindDataGrid(ds, dgdHistory, True, False, False, "STT", "", "", "", 200, 400, 400, 100)
            End If
        End If
        'PhuocDD, updated Jun 30 2006
        'Chi in lich su voi ho so kinh doanh
        If dgdHistory.Visible = True Then
            Dim sFormula As String
            Dim sValues As String
            ds = DataProvider.Instance.ExecuteQueryStoreProc(Request.Params("LoaiHoSo") & "..sp_ChiTietHoSoHistory", "FSSPORTALQH", Request("ID"), Request("SoGiayPhep"))
            For Each col As DataColumn In ds.Tables(0).Columns
                sFormula += col.ColumnName & ";"
                sValues += CStr(ds.Tables(0).Rows(0)(col.ColumnName)) & ";"
            Next
            Me.btnInLichSu.Attributes.Add("onclick", "javascript:return rptHistory('" & Request("SoGiayPhep") & "','" & sFormula & "','" & sValues & "');")
            Me.btnInLichSu.Visible = dgdHistory.Visible
        Else
            btnInLichSu.Visible = False
        End If
        objThongKe = Nothing
    End Sub
    'Danh Muc
    Private Sub CreateControls()
        Dim TableLeft As New HtmlTable
        Dim TableRight As New HtmlTable
        Dim row As Integer = 0
        'Generate rows and cells.
        Dim numrows As Integer = 5
        Dim numcells As Integer = 2

        Dim objSearchInfo As New SearchInfoController
        Dim ds As DataSet
        Dim arr As ArrayList
        arr = GetDieuKien()
        ds = objSearchInfo.GetThongTinTimKiem_ChiTiet(Request.Params("LoaiHoSo"), _
                                    arr)

        Dim i As Integer
        Dim j As Integer

        For i = 0 To ds.Tables(0).Columns.Count - 1
            For j = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Columns(i).ToString <> "Tình trạng" _
                    And ds.Tables(0).Columns(i).ToString <> "Ngày sinh" _
                    And ds.Tables(0).Columns(i).ToString <> "Tổng số lao động" _
                    And ds.Tables(0).Columns(i).ToString <> "Tổng số lao động nữ" Then
                    ds.Tables(0).Rows(j)(i) = HttpUtility.HtmlEncode(ds.Tables(0).Rows(j)(i).ToString())
                End If
            Next
        Next

        If ds.Tables.Count = 0 Then Exit Sub
        Dim dv As DataView = ds.Tables(0).DefaultView
        Dim r As HtmlTableRow
        Dim c As HtmlTableCell

        For j = 0 To dv.Table.Columns.Count - 1
            r = New HtmlTableRow
            c = New HtmlTableCell
            c.Attributes.Add("class", "QH_ColLabel")
            c.Controls.Add(CreateLabel(dv.Table.Columns(j).ToString, False))
            c.Width = "40%"
            c.VAlign = "middle"
            r.Cells.Add(c)
            c = Nothing

            c = New HtmlTableCell
            c.Attributes.Add("class", "QH_ColLabelLeft")
            c.Controls.Add(CreateLabel(dv.Item(0).Item(j).ToString, True))
            c.Width = "60%"
            c.VAlign = "top"
            r.Cells.Add(c)
            c = Nothing

            Select Case j Mod 2
                Case 0
                    TableLeft.Rows.Add(r)
                Case Else
                    TableRight.Rows.Add(r)
            End Select
        Next


        r = New HtmlTableRow
        c = New HtmlTableCell
        c.Controls.Add(New LiteralControl("<br>"))
        r.Cells.Add(c)
        myTable.Rows.Add(r)

        r = New HtmlTableRow
        c = New HtmlTableCell
        c.Width = "50%"
        c.VAlign = "top"
        c.Controls.Add(TableLeft)
        r.Cells.Add(c)
        c = New HtmlTableCell
        c.Width = "50%"
        c.VAlign = "top"
        c.Controls.Add(TableRight)
        r.Cells.Add(c)
        myTable.Rows.Add(r)

        r = New HtmlTableRow
        c = New HtmlTableCell
        c.Controls.Add(New LiteralControl("<br>"))
        r.Cells.Add(c)
        myTable.Rows.Add(r)

    End Sub

    Private Function CreateLabel(ByVal Value As String, ByVal Display As Boolean) As Label
        Dim lbl As New Label
        Select Case Display
            Case True
                lbl.CssClass = "QH_LabelLeft"
                lbl.ForeColor = System.Drawing.Color.Blue
                lbl.Width = Unit.Percentage(100)
            Case False
                lbl.CssClass = "QH_Label"
                lbl.Width = Unit.Percentage(100)
        End Select
        lbl.Text = Value
        Return lbl
    End Function

    Private Function GetDieuKien() As ArrayList
        Dim strDK As New ArrayList

        strDK.Add(ConfigurationSettings.AppSettings("commonDB"))
        If Not Request.Params("MaKhuVuc") Is Nothing Then
            strDK.Add(Request.Params("MaKhuVuc"))
        End If
        If Not Request.Params("TableName") Is Nothing Then
            strDK.Add(Request.Params("TableName"))
        End If
        If Not Request.Params("ID") Is Nothing Then
            strDK.Add(Request.Params("ID"))
        End If
        If Not Request.Params("LoaiCT") Is Nothing Then
            strDK.Add(Request.Params("LoaiCT"))
        End If
        If Not Request.Params("SoGiayPhep") Is Nothing Then
            strDK.Add(Request.Params("SoGiayPhep"))
        End If
        Return strDK
    End Function

    Private Overloads Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
        Dim strURL As String
        strURL = NavigateURL()
        If Not Request.Params("LoaiHoSo") Is Nothing Then
            strURL = strURL & "&LoaiHoSo=" & Request.Params("LoaiHoSo")
        End If
        If Not Request.Params("TableName") Is Nothing Then
            strURL = strURL & "&TableName=" & Request.Params("TableName")
        End If
        If Not Request.Params("MaKhuVuc") Is Nothing Then
            strURL = strURL & "&MaKhuVuc=" & Request.Params("MaKhuVuc")
        End If
        If Not Request.Params("LoaiCT") Is Nothing Then
            strURL = strURL & "&LoaiCT=" & Request.Params("LoaiCT")
        End If
        Response.Redirect(strURL)
    End Sub

End Class
