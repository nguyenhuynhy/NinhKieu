Imports PortalQH
Namespace CPXD
    Public Class NhanXetHoSo
        Inherits PortalQH.PortalModuleControl

        Protected ctrlChuDautuList As ChuDauTuList

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents title As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhanXet As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents TabStrip1 As Microsoft.Web.UI.WebControls.TabStrip
        Protected WithEvents tsNXHS As Microsoft.Web.UI.WebControls.MultiPage
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDanhSach As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnDieuChinh As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaCapNha As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdNgayNhanXet As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtCongTrinhXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents objNhanXet As NXHS_NhanXet
        Protected WithEvents txtLodat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDonViThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkChonDonViThietKe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents LinkChonLoDat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaPhanLoaiXayDung As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnInGiayPhep As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected objHangMucXDTruoc As NXHS_HangMucXDTruoc
        Protected WithEvents txtNhanXetHoSoID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHangMucTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKyHieuThietKe As System.Web.UI.WebControls.TextBox
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.

        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim strHoSoID As String
        Dim strHoSoNhanXetId As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            strHoSoID = Request.QueryString("ID")
            txtHoSoTiepNhanID.Text = strHoSoID
            If Not IsPostBack Then
                Init_State()
            End If
        End Sub
        Private Sub Init_State()
            BindControl.BindDropDownList(ddlMaCapNha, "DMCAPNHA", , False)
            BindControl.BindDropDownList(ddlMaPhanLoaiXayDung, "DMPHANLOAIXAYDUNG", , False)
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG", , False)
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG", , False)
            txtNgayNhanXet.Text = CStr(Format(Now, "dd/MM/yyyy"))
            ddlMaPhanLoaiXayDung.SelectedIndex = 1
            ddlMaCapNha.SelectedIndex = 1
            txtCongTrinhXayDung.Text = ddlMaCapNha.SelectedItem.Text
            txtKyHieuThietKe.Text = GetParamByID("KyHieuThietKe", glbXMLFile)
            SetAttributesNgay()
            If GetThongTinHoSoNhanXet() = False Then
                GetThongTinHoSoTiepNhan()
            End If
            GetThongTinHoSoTiepNhan()
            objHangMucXDTruoc.CreateDataSource(txtNhanXetHoSoID.Text)
            'Khoi tao cac link khi click se hien thi danh muc goi y
            Dim strURL As String
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMDONVITHIETKE&TextName=" & txtDonViThietKe.ClientID
            LinkChonDonViThietKe.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMLODAT&TextName=" & txtLodat.ClientID
            LinkChonLoDat.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            'Khoi tao cac button in report
            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "2", strReportPath, btnInGiayPhep, Me)
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", strReportPath, btnIn, Me)
            'Dua cac thuoc tinh kiem tra gia tri null cho cac control
            txtNgayNhanXet.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhanLoaiXayDung.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            '
            If txtNhanXetHoSoID.Text = "" Then
                btnIn.Visible = False
                btnInGiayPhep.Visible = False
                btnXoa.Visible = False
            End If
            'Lay thong tin chu dau tu
            ctrlChuDautuList.CreateDataSource(txtHoSoTiepNhanID.Text)
        End Sub
        Private Sub GetThongTinHoSoTiepNhan()
            Dim ds As New DataSet
            Dim objHoSoTiepNhan As New TiepNhanHoSoController
            ds = objHoSoTiepNhan.GetChiTietHoSoTiepNhan(strHoSoID)
            gLoadControlValues(ds, Me)
            txtHoTen.Text = txtHoTenNguoiNop.Text
            ds = Nothing
        End Sub
        Private Function GetThongTinHoSoNhanXet() As Boolean
            Dim ds As DataSet
            Dim objNhanXetHoSo As New NhanXetHoSoController
            ds = objNhanXetHoSo.LstNhanXetHoSo(strHoSoID)
            If ds.Tables(0).Rows.Count > 0 Then
                gLoadControlValues(ds, Me)
            End If
        End Function
        Private Sub SetAttributesNgay()
            txtNgayNhanXet.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayNhanXet.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayNhanXet.ClientID & ");")
            cmdNgayNhanXet.NavigateUrl = AdminDB.InvokePopupCal(txtNgayNhanXet)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            txtHangMucTruoc.Text = objHangMucXDTruoc.GhiLaiHangMucTruoc
            Dim objNhanXetHoSo As New NhanXetHoSoController
            Dim strHoSoNhanXetId As String
            strHoSoNhanXetId = objNhanXetHoSo.AddNhanXetHoSo(Me)
            txtNhanXetHoSoID.Text = strHoSoNhanXetId
            btnIn.Visible = True
            btnInGiayPhep.Visible = True
            btnXoa.Visible = True
            objHangMucXDTruoc.Save_HangMucXayDung(strHoSoNhanXetId)

            'Cap nhat chu dau tu
            ctrlChuDautuList.updateChuDauTu(txtHoSoTiepNhanID.Text)

            objNhanXetHoSo = Nothing
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objNhanXetHoSo As New NhanXetHoSoController
            objNhanXetHoSo.DelNhanXetHoSo(Me)
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
    End Class
End Namespace