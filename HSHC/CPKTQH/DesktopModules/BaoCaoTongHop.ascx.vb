Imports PortalQH

Namespace CPKTQH
    Public Class BaoCaoTongHop
        Inherits PortalQH.PortalModuleControl


        '---------------------------------------------------------------------------------------
        'Người thay đổi : TuanNH
        'Ngày thay đổi  : 
        'Mô tả          : Thêm các Danh Mục phục vụ cho việc báo cáo : DMNGUOIKY, DMTHANG, DMNAM
        '---------------------------------------------------------------------------------------


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents lstReports As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblReport As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblTuNgay As System.Web.UI.WebControls.Label
        Protected WithEvents lblDenNgay As System.Web.UI.WebControls.Label
        Protected WithEvents lblMaPhuong As System.Web.UI.WebControls.Label
        Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnExport As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblMaPhuongThucKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblMaDuong As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblVonKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents txtVonTu As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblVonDen As System.Web.UI.WebControls.Label
        Protected WithEvents txtVonDen As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblMaNganhKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlNguoiKy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaNguoiKy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblNguoiKy As System.Web.UI.WebControls.Label
        Protected WithEvents lblThang As System.Web.UI.WebControls.Label
        Protected WithEvents ddlThang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNam As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox

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
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtVonTu.Attributes.Add("onblur", "javascript:CheckData(" & txtVonTu.ClientID & ");")
            txtVonDen.Attributes.Add("onblur", "javascript:CheckData(" & txtVonDen.ClientID & ");")
            Dim ctrl As Control
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaNganhKinhDoanh, "DMNGANH")
                BindControl.BindDropDownList(ddlMaPhuongThucKinhDoanh, "DMPHUONGTHUCKINHDOANH")

                Dim objNguoiKyInfo As NguoiKyInfo
                Dim objNguoiKy As NguoiKyController
                objNguoiKyInfo = New NguoiKyInfo
                objNguoiKy = New NguoiKyController
                objNguoiKyInfo.TabCode = Request.Params("TabId").ToString
                objNguoiKyInfo.MaLinhVuc = GetLinhVuc()

                ddlMaNguoiKy.DataSource = objNguoiKy.GetNguoiKy(objNguoiKyInfo)
                ddlMaNguoiKy.DataTextField = "Ten"
                ddlMaNguoiKy.DataValueField = "Ma"
                ddlMaNguoiKy.DataBind()

                Dim i As Integer
                Dim dtNow As New DateTime

                'Bind data Tháng và seek tới tháng hiện tại
                ddlThang.Items.Add("")
                For i = 1 To 12
                    ddlThang.Items.Add((IIf(i < 10, "0" + i.ToString(), i.ToString())).ToString())
                    If i = Month(dtNow.Now()) Then
                        ddlThang.Items(i - 1).Selected = True
                    End If
                Next

                'Bind data Năm và seek tới năm hiện tại
                'Dữ liệu năm bắt đầu từ năm 2000 tới năm hiện tại
                For i = 2000 To Year(dtNow.Now())
                    ddlNam.Items.Add(i.ToString())
                    If i = Year(dtNow.Now()) Then
                        ddlNam.Items(i Mod 2000).Selected = True
                    End If
                Next

                BindControl.BindRadioButtonList(lstReports, "sp_GetReportList", "1", TabId)
                txtLoai.Text = lstReports.SelectedItem.Value

                lblTieuDe.Text = "Báo cáo tình hình đăng ký kinh doanh"
                txtTuNgay.Text = g_DateToString(DateAdd(DateInterval.Month, -1, Now))
                txtDenNgay.Text = NgayHienTai()

                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
                SetControlStatus()

            End If
            GetReportURL(Request.Params("TabId").ToString, GetLinhVuc, lstReports.SelectedItem.Value, CType(Session.Item("ActiveDB"), String), btnIn, Me)
            
        End Sub


        Private Sub lstReports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstReports.SelectedIndexChanged
            SetControlStatus()
        End Sub
        Private Sub SetControlStatus()
            btnIn.Visible = True
            Select Case lstReports.SelectedValue
                Case "1", "2", "3", "4", "5", "6" 'Danh sach ho kinh doanh
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlMaPhuong.Visible = True
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblNguoiKy.Visible = False
                    ddlMaNguoiKy.Visible = False
                    ddlThang.Visible = False
                    ddlNam.Visible = False
                    lblThang.Visible = False
                    lblMatHangKinhDoanh.Visible = False
                    txtMatHangKinhDoanh.Visible = False
                Case "7" 'Chi tiet dia ban nganh nghe
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlMaPhuong.Visible = True
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblNguoiKy.Visible = False
                    ddlMaNguoiKy.Visible = False
                    ddlThang.Visible = False
                    ddlNam.Visible = False
                    lblThang.Visible = False
                    lblMatHangKinhDoanh.Visible = False
                    txtMatHangKinhDoanh.Visible = False
                Case "9"
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlMaPhuong.Visible = True
                    lblMaDuong.Visible = True
                    ddlMaDuong.Visible = True
                    lblGioiTinh.Visible = True
                    ddlGioiTinh.Visible = True
                    ddlMaNganhKinhDoanh.Visible = True
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    lblVonKinhDoanh.Visible = True
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = True
                    lblVonDen.Visible = True
                    txtVonDen.Visible = True
                    lblNguoiKy.Visible = False
                    ddlMaNguoiKy.Visible = False
                    ddlThang.Visible = False
                    ddlNam.Visible = False
                    lblThang.Visible = False
                    lblMatHangKinhDoanh.Visible = True
                    txtMatHangKinhDoanh.Visible = True
                Case "10", "11"
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlMaPhuong.Visible = False
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblNguoiKy.Visible = True
                    ddlMaNguoiKy.Visible = True
                    ddlThang.Visible = False
                    ddlNam.Visible = False
                    lblThang.Visible = False
                    lblMatHangKinhDoanh.Visible = False
                    txtMatHangKinhDoanh.Visible = False
                Case "12"
                    txtTuNgay.Visible = False
                    txtDenNgay.Visible = False
                    ddlMaPhuong.Visible = False
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblNguoiKy.Visible = True
                    ddlMaNguoiKy.Visible = True
                    ddlThang.Visible = True
                    ddlNam.Visible = True
                    lblThang.Visible = True
                    lblMatHangKinhDoanh.Visible = False
                    txtMatHangKinhDoanh.Visible = False
                Case "13", "15"
                    txtTuNgay.Visible = False
                    txtDenNgay.Visible = False
                    ddlMaPhuong.Visible = True
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblNguoiKy.Visible = True
                    ddlMaNguoiKy.Visible = True
                    ddlThang.Visible = True
                    ddlNam.Visible = True
                    lblThang.Visible = True
                    lblMatHangKinhDoanh.Visible = False
                    txtMatHangKinhDoanh.Visible = False
                Case "14"
                    txtTuNgay.Visible = False
                    txtDenNgay.Visible = False
                    ddlMaPhuong.Visible = False
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = True
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblNguoiKy.Visible = True
                    ddlMaNguoiKy.Visible = True
                    ddlThang.Visible = True
                    ddlNam.Visible = True
                    lblThang.Visible = True
                    lblMatHangKinhDoanh.Visible = False
                    txtMatHangKinhDoanh.Visible = False
                Case "8"
                    txtTuNgay.Visible = True
                    txtDenNgay.Visible = True
                    ddlMaPhuong.Visible = True
                    ddlMaNganhKinhDoanh.Visible = False
                    ddlMaPhuongThucKinhDoanh.Visible = False
                    btnIn.Visible = False
                    lblVonKinhDoanh.Visible = False
                    'lblVonTu.Visible = False
                    txtVonTu.Visible = False
                    lblVonDen.Visible = False
                    txtVonDen.Visible = False
                    lblGioiTinh.Visible = False
                    ddlGioiTinh.Visible = False
                    lblMaDuong.Visible = False
                    ddlMaDuong.Visible = False
                    lblNguoiKy.Visible = False
                    ddlMaNguoiKy.Visible = False
                    ddlThang.Visible = False
                    ddlNam.Visible = False
                    lblThang.Visible = False
                    lblMatHangKinhDoanh.Visible = True
                    txtMatHangKinhDoanh.Visible = True

                    Dim strFile As String
                    Dim strTemplate As String

                    strFile = AddHTTP(GetDomainName(Request) & "/CPKTQH/Reports/Temp/DanhSachHoCaThe_" & Session.Item("UserName").ToString & ".xls")
                    LinkButton1.Attributes.Add("Onclick", "javascript:window.open('" & strFile & "');")
            End Select
            btnExport.Visible = Not btnIn.Visible
            LinkButton1.Visible = False
            imgTuNgay.Visible = txtTuNgay.Visible
            imgDenNgay.Visible = txtDenNgay.Visible
            lblTuNgay.Visible = txtTuNgay.Visible
            lblDenNgay.Visible = txtDenNgay.Visible
            lblMaPhuong.Visible = ddlMaPhuong.Visible
            If ddlMaNganhKinhDoanh.Visible = True Then
                lblMaNganhKinhDoanh.Visible = ddlMaNganhKinhDoanh.Visible
            Else
                lblMaNganhKinhDoanh.Visible = ddlMaPhuongThucKinhDoanh.Visible
            End If
        End Sub
        Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim objDSHoCaThe As New TimKiemGiayCNDKKDController
            Dim dt As DataTable
            dt = objDSHoCaThe.LayDanhSachHoCaThe(txtTuNgay.Text, txtDenNgay.Text, ddlMaPhuong.SelectedValue).Tables(0)
            Dim strServerPath As String
            Dim strFile As String
            Dim strTemplate As String
            strServerPath = Request.MapPath(Request.ApplicationPath)
            strFile = strServerPath & "\CPKTQH\Reports\Temp\DanhSachHoCaThe_" & Session.Item("UserName").ToString & ".xls"
            strTemplate = strServerPath & "\CPKTQH\Reports\Reports\MyTemplate.xls"
            If ExportToExcel(dt, strFile, strTemplate) Then
                LinkButton1.Visible = True
            Else
                LinkButton1.Visible = False
                SetMSGBOX_HIDDEN(Page, "Khong tao duoc file. Kiem tra xem ban da dong file 'DanhSachHoCaThe_" & Session.Item("UserName").ToString & ".xls' chua?")
            End If
        End Sub
        
        Private Sub txtVonDen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVonDen.TextChanged

        End Sub
    End Class

End Namespace