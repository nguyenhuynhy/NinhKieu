Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class QLHT_ChiTietHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Protected WithEvents myTable As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton


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
            CreateControls()
        End Sub

        'Danh Muc
        Public Sub CreateControls()
            Dim TableLeft As New HtmlTable
            Dim TableRight As New HtmlTable
            Dim row As Integer = 0
            'Generate rows and cells.
            Dim numrows As Integer = 5
            Dim numcells As Integer = 2

            Dim objQLHT As New QuanLyHoTichController
            Dim ds As DataSet
            ds = objQLHT.GetChiTietHoSo(ConfigurationSettings.AppSettings("DB_QLHT"), _
                                        ConfigurationSettings.AppSettings("commonDB"), _
                                        Request.QueryString("MaKhuVuc").ToString, _
                                        Request.QueryString("Loai").ToString, _
                                        Request.QueryString("ID").ToString.Trim())
            If ds.Tables(0).Rows.Count = 0 Then Exit Sub
            Dim dv As DataView = ds.Tables(0).DefaultView
            Dim r As HtmlTableRow
            Dim c As HtmlTableCell
            Dim j As Integer
            For j = 0 To dv.Table.Columns.Count - 1
                r = New HtmlTableRow
                c = New HtmlTableCell
                c.Controls.Add(CreateLabel(dv.Table.Columns(j).ToString, False))
                c.Width = "40%"
                c.VAlign = "middle"
                r.Cells.Add(c)
                c = Nothing

                c = New HtmlTableCell
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
            c.Controls.Add(TableLeft)
            r.Cells.Add(c)
            c = New HtmlTableCell
            c.Width = "50%"
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
                Case False
                    lbl.CssClass = "QH_Label"
            End Select
            lbl.Text = Value
            Return lbl
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

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(GetMidURL("MaKhuVuc", Request.QueryString("MaKhuVuc") & "&Loai=" & Request.QueryString("Loai"), "QLHT_DSHOSO"))
        End Sub
    End Class
End Namespace