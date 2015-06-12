Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class ThongKeLoaiHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblLinhVuc As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
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
                    If (DataCache.GetCache("ThongKeLoaiHoSo") Is Nothing) Then
                        DataCache.SetCache("ThongKeLoaiHoSo", Request.UrlReferrer.PathAndQuery)
                    End If
                    SetAttributesControl()
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub

        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)

            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)

            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub

        Private Sub Init_State()
            Dim glbFile As String
            Dim mSoNgay As Integer
            lblLinhVuc.Text = "LĨNH VỰC: " & UCase(DecryptQueryParam(Request.Params("Tenlv")))
            glbFile = ConfigurationSettings.AppSettings("Path" & CType(Session.Item("ActiveDB"), String)) & "GLOBAL.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            If Request.Params("TuNgay") Is Nothing Then
                txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
                txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            Else
                txtTuNgay.Text = Request.Params("TuNgay")
                txtDenNgay.Text = Request.Params("DenNgay")
            End If
        End Sub

        Private Sub LoadGrid()
            Dim objThongKeBaoCao As New ThongKeBaoCaoInfo
            Dim objThongKe As New ThongKeBaoCaoController
            Dim ds As DataSet

            objThongKeBaoCao.LinhVuc = CStr(Request.Params("Malv"))
            objThongKeBaoCao.TuNgay = txtTuNgay.Text
            objThongKeBaoCao.DenNgay = txtDenNgay.Text

            ds = objThongKe.ThongKeLoaiHoSo(objThongKeBaoCao)
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)

            ds = Nothing
            objThongKe = Nothing
            objThongKeBaoCao = Nothing
        End Sub

        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell

            dgitem.Cells.Add(InitCell("STT", 1, 3))
            dgitem.Cells.Add(InitCell("Tên lĩnh vực", 1, 3)) 'Tên lĩnh vực
            dgitem.Cells.Add(InitCell("Hồ Sơ Nhận", 2, 1)) 'Tồn Trước
            dgitem.Cells.Add(InitCell("Hồ Sơ Đã Giải Quyết", 7, 1)) 'Nhận trong kỳ
            dgitem.Cells.Add(InitCell("Hồ Sơ Đang Giải Quyết", 1, 3)) 'Hủy trong kỳ
            dgitem.Cells.Add(InitCell("Hồ Sơ Đang GQ.Quá Hạn", 1, 3)) 'Hồ sơ quá hạn
            dgitem.Cells.Add(InitCell("Ghi Chú", 1, 3)) ' Đã giải quyết
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)
            dgitem = Nothing

            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Tổng Số", 1, 2))
            dgitem.Cells.Add(InitCell("Ngày Thứ Bảy", 1, 2))
            dgitem.Cells.Add(InitCell("Tổng Số", 1, 2))
            dgitem.Cells.Add(InitCell("Trong Đó", 6, 1))


            dgdDanhSach.Controls(0).Controls.AddAt(1, dgitem)
            dgitem = Nothing

            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Trước Hẹn", 1, 1))
            dgitem.Cells.Add(InitCell("Tỷ Lệ (%)", 1, 1))
            dgitem.Cells.Add(InitCell("Đúng Hẹn", 1, 1))
            dgitem.Cells.Add(InitCell("Tỷ Lệ (%)", 1, 1))
            dgitem.Cells.Add(InitCell("Trễ Hẹn", 1, 1))
            dgitem.Cells.Add(InitCell("Tỷ Lệ (%)", 1, 1))

            'dgitem.Cells.Add(InitCell("test", 8, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(2, dgitem)
            dgitem = Nothing


            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("A", 1, 1))
            dgitem.Cells.Add(InitCell("1", 1, 1))
            dgitem.Cells.Add(InitCell("2=4+11", 1, 1))
            dgitem.Cells.Add(InitCell("3", 1, 1))
            dgitem.Cells.Add(InitCell("4=5+7+9", 1, 1))
            dgitem.Cells.Add(InitCell("5", 1, 1))
            dgitem.Cells.Add(InitCell("6", 1, 1))
            dgitem.Cells.Add(InitCell("7", 1, 1))
            dgitem.Cells.Add(InitCell("8", 1, 1))
            dgitem.Cells.Add(InitCell("9", 1, 1))
            dgitem.Cells.Add(InitCell("10", 1, 1))
            dgitem.Cells.Add(InitCell("11", 1, 1))
            dgitem.Cells.Add(InitCell("12", 1, 1))
            dgitem.Cells.Add(InitCell("13", 1, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(3, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(4)
            dgdDanhSach.Controls(0).Controls.RemoveAt(4)
            dgitem = Nothing
            mycell = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            'Response.Redirect(NavigateURL())
            Dim m_ReturnURL As String = CStr(DataCache.GetCache("ThongKeLoaiHoSo"))
            DataCache.RemoveCache("ThongKeLoaiHoSo")
            Response.Redirect(m_ReturnURL, True)
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            LoadGrid()
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
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
    End Class
End Namespace