Imports PortalQH
Namespace DOITHOAI
    Public Class TraLoiTinNhan
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnGui As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVeDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTenLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTinNhanChiTietID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTinNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiGui As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkTinNhanDauTien As System.Web.UI.WebControls.CheckBox

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
                SetAttributesControl()
                KiemTra()
                GetThongTinChung()
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim strURL As String
            strURL = EditURL("ID", Request.Params("ID"), Request.Params("PreControl"))
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub

        Private Sub btnTroVeDanhSach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVeDanhSach.Click
            Dim strURL As String
            strURL = NavigateURL()
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub

        Private Sub btnGui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGui.Click
            Dim objTinNhan As New TinNhanController

            'kiểm tra lại có được quyền trước khi cập nhật nội dung
            KiemTra()

            If txtTinNhanChiTietID.Text = "" Then
                'trường hợp trả lời tin nhắn
                If objTinNhan.ThemTinNhanTraLoi(Me) = "-1" Then
                    SetMSGBOX_HIDDEN(Page, "Gửi không thành công!")
                    Exit Sub
                End If
            Else
                'trường hợp cập nhật tin nhắn
                objTinNhan.CapNhatTinNhan(Me)
            End If
            btnTroVe_Click(Nothing, Nothing)
        End Sub

#End Region

#Region "Các hàm xử lý"
        Private Sub SetAttributesControl()
            txtNoiDung.Attributes.Add("ISNULL", "NOTNULL")
            btnGui.Attributes.Add("onclick", "javscript:return CheckNull();")
        End Sub
        Private Sub KiemTra()
            Dim objTinNhan As New TinNhanController
            Dim strUserName As String
            Dim strTinNhanID As String
            Dim strTinNhanChiTietID As String

            strUserName = CStr(Session("UserName"))
            strTinNhanID = Request.Params("ID")
            strTinNhanChiTietID = Request.Params("ChiTietID")
            If Request.Params("ChiTietID") Is Nothing Then
                'kiểm tra được quyền trả lời tin nhắn
                If Not objTinNhan.KiemTraQuyenTraLoi(strUserName, strTinNhanID) Then
                    GetURLError("ADDNEW")
                End If
            Else
                'kiểm tra được quyền sửa nội dung tin nhắn
                If Not objTinNhan.KiemTraQuyenSua(strUserName, strTinNhanID, strTinNhanChiTietID) Then
                    GetURLError("EDIT")
                End If
            End If
        End Sub

        Private Sub GetThongTinChung()
            Dim objTinNhan As New TinNhanController
            Dim ds As DataSet
            Dim str As String

            ds = objTinNhan.NoiDungTinNhan(Request.Params("ID"), Request.Params("ChiTietID"))

            gLoadControlValues(ds, Me)
            If txtTinNhanID.Text = "" Then
                btnTroVeDanhSach_Click(Nothing, Nothing)
            End If

            txtTieuDe.Enabled = False
            If Request.Params("ChiTietID") Is Nothing Then
                'trường hợp trả lời tin nhắn
                txtTieuDe.Enabled = False
                txtTinNhanChiTietID.Text = ""
                txtNoiDung.Text = ""
                str = txtNguoiGui.Text
                txtNguoiGui.Text = txtNguoiNhan.Text
                txtNguoiNhan.Text = str
            Else
                'trường hợp sửa tin nhắn, nếu là tin nhắn đầu tiên thì được phép sửa tiêu đề
                If chkTinNhanDauTien.Checked Then
                    txtTieuDe.Enabled = True
                End If
                btnGui.Text = "Cập nhật"
            End If
        End Sub
        Private Sub GetURLError(ByVal pType As String)
            Dim strURL As String
            strURL = EditURL(, , "ERROR") & "&Type=" & pType
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex") & "&SelectID=" & Request.Params("SelectID")
            End If
            Response.Redirect(strURL)
        End Sub
#End Region
    End Class
End Namespace