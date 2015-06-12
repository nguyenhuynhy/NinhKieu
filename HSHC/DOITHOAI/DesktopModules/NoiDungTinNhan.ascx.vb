Imports PortalQH
Namespace DOITHOAI
    Public Class NoiDungTinNhan
        Inherits PortalQH.PortalModuleControl
        Private Const COL_TINNHANCHITIETID As Integer = 0
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblTenLinhVuc As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents grdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTraLoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTinNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiGui As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiGuiViewed As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiNhanViewed As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTinNhanChiTietID As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Các hàm sự kiện"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                'kiểm tra quyen nguoi su dung doi voi tin nhan
                KiemTraQuyenXemTinNhan()
                GetThongTinChung()
                LoadGrid()
                CapNhatDaXemTinNhan()    'cập nhật người đăng nhập đã xem nội dung tin nhắn
            End If
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim strURL As String
            strURL = NavigateURL
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub
        Private Sub btnTraLoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTraLoi.Click
            GetURLSoanThaoTinNhan("")
        End Sub
        Private Sub grdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDanhSach.PageIndexChanged
            grdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub
        Private Sub grdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDanhSach.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    XoaTinNhanChiTiet(e.Item.Cells(COL_TINNHANCHITIETID).Text)
                Case "Edit"
                    SuaTinNhanChiTiet(e.Item.Cells(COL_TINNHANCHITIETID).Text)
            End Select
        End Sub
#End Region

#Region "Các hàm xử lý"
        Private Sub KiemTraQuyenXemTinNhan()
            Dim strUserName As String
            Dim strTinNhanID As String
            Dim objTinNhan As New TinNhanController

            strUserName = CStr(Session("UserName"))
            strTinNhanID = Request.Params("ID")
            If Not objTinNhan.KiemTraQuyenXem(strUserName, strTinNhanID) Then
                GetURLError("VIEW")
            End If
        End Sub
        Private Sub GetThongTinChung()
            Dim objTinNhan As New TinNhanController
            Dim ds As DataSet
            ds = objTinNhan.NoiDungTinNhan(Request.Params("ID"))
            gLoadControlValues(ds, Me)
            If txtTinNhanID.Text = "" Then
                btnTroVe_Click(Nothing, Nothing)
            End If
            lblTenLinhVuc.Text = ".:: LĨNH VỰC: " & UCase(lblTenLinhVuc.Text) & " ::."

            btnTraLoi.Visible = False
            If txtNguoiNhan.Text = CStr(Session("UserName")) Then
                btnTraLoi.Visible = True
            End If
        End Sub
        Private Sub CapNhatDaXemTinNhan()
            'trường hợp tin nhắn mới đọc lần đầu, cập nhật người sử dụng đã đọc tin nhắn này
            If (txtNguoiGuiViewed.Text = "0" And txtNguoiGui.Text = CStr(Session("UserName"))) _
                    Or (txtNguoiNhanViewed.Text = "0" And txtNguoiNhan.Text = CStr(Session("UserName"))) Then
                Dim objTinNhan As New TinNhanController
                objTinNhan.CapNhatDaXemTinNhan(txtTinNhanID.Text, CStr(Session("UserName")))
                objTinNhan = Nothing
            End If
        End Sub
        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objTinNhan As New TinNhanController
            ds = objTinNhan.DanhSachTinNhanChiTiet(txtTinNhanID.Text)

            'replace các kí tự html và kí tự xuống dòng
            ReplaceChar(ds)

            grdDanhSach.DataSource = ds
            grdDanhSach.DataBind()

            'kiểm tra lần gửi tin nhắn cuối cùng có phải là người đăng nhập,
            'nếu phải thì cho phép sửa nội dung đó
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    Dim iToTalRows As Integer
                    iToTalRows = ds.Tables(0).Rows.Count
                    If ds.Tables(0).Rows(iToTalRows - 1).Item("NguoiGui").ToString = CStr(Session("UserName")) Then
                        Dim objButton As LinkButton

                        objButton = CType(grdDanhSach.Items(iToTalRows - 1).FindControl("btnSua"), LinkButton)
                        If Not objButton Is Nothing Then objButton.Visible = True

                        objButton = CType(grdDanhSach.Items(iToTalRows - 1).FindControl("btnXoa"), LinkButton)
                        If Not objButton Is Nothing Then
                            objButton.Visible = True
                            objButton.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn muốn xóa nội dung này không?')")
                        End If
                    End If
                End If
            End If
            ds = Nothing
            objTinNhan = Nothing
        End Sub
        Private Sub ReplaceChar(ByRef ds As DataSet)
            Dim i, j As Integer

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    For i = 0 To ds.Tables(0).Columns.Count - 1
                        If ds.Tables(0).Columns(i).DataType.ToString.Equals("System.String") Then
                            For j = 0 To ds.Tables(0).Rows.Count - 1
                                ds.Tables(0).Rows(j).Item(i) = ReplaceHTML(ds.Tables(0).Rows(j).Item(i).ToString)
                            Next
                        End If
                    Next
                End If
            End If
        End Sub
        Private Sub XoaTinNhanChiTiet(ByVal pTinNhanChiTietID As String)
            Dim objTinNhan As New TinNhanController
            'kiểm tra quyền xóa
            If Not objTinNhan.KiemTraQuyenXoa(CStr(Session("UserName")), txtTinNhanID.Text, pTinNhanChiTietID) Then
                GetURLError("DELETE")
                Exit Sub
            End If

            'thực hiện xóa tin nhắn
            objTinNhan.XoaTinNhanChiTiet(txtTinNhanID.Text, pTinNhanChiTietID)

            If grdDanhSach.Items.Count = 1 Then 'trường hợp xóa tin nhắn vừa gửi
                btnTroVe_Click(Nothing, Nothing)
            Else
                Response.Redirect(Request.RawUrl())
            End If
        End Sub
        Private Sub SuaTinNhanChiTiet(ByVal pTinNhanChiTietID As String)
            Dim objTinNhan As New TinNhanController

            'kiểm tra quyền sua
            If Not objTinNhan.KiemTraQuyenSua(CStr(Session("UserName")), txtTinNhanID.Text, pTinNhanChiTietID) Then
                GetURLError("EDIT")
                Exit Sub
            End If

            'chuyển sang trang sửa nội dung tin nhắn
            GetURLSoanThaoTinNhan(pTinNhanChiTietID)
        End Sub
        Private Sub GetURLError(ByVal pType As String)
            Dim strURL As String
            strURL = EditURL(, , "ERROR") & "&Type=" & pType
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub

        '------------------------------------------------------------------------
        'Mục đích: chuyển sang trang soạn thảo nội dung tin nhắn
        '------------------------------------------------------------------------
        Private Sub GetURLSoanThaoTinNhan(ByVal pTinNhanChiTietID As String)
            Dim strURL As String
            strURL = EditURL("ID", Request.Params("ID"), "TRALOI") & "&PreControl=" & Request.Params("ctl")
            If pTinNhanChiTietID <> "" Then
                strURL = strURL & "&ChiTietID=" & pTinNhanChiTietID
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub
#End Region



    End Class
End Namespace