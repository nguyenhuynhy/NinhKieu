Imports PortalQH
Imports System.Configuration
Namespace CPXD
    Public Class TimKiemGiayCNDKKD
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTinhTrangHienTai As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtSoGiayPhepChon As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnChon As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtIsHuy As System.Web.UI.WebControls.TextBox


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
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtTuNgay.ClientID & ", 'dd/mm/yyyy');")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtDenNgay.ClientID & ", 'dd/mm/yyyy');")
            Session.Item("gActiveDB") = ConfigurationSettings.AppSettings("db_cpxd")
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
                BindControl.BindDropDownList(ddlTinhTrangHienTai, "DMTINHTRANGGIAYPHEP", "A")
                If Not Request.Params("IsHuy") Is Nothing Then
                    txtIsHuy.Text = Request.Params("IsHuy").ToString
                Else
                    txtIsHuy.Text = "0"
                End If
            End If
            LoadGrid()
            btntroVe.Attributes.Add("onclick", "javascript:window.close();")
            btnChon.Attributes.Add("onclick", "javascript:form1_onsubmit();")

        End Sub
        Public Function DanhSachGiayCNDKKD() As DataSet
            Dim ds As New DataSet
            Dim objTimKiemGiayCNDKKDInfo As New TimKiemGiayCNDKKDInfo
            Dim objTimKiemGiayCNDKKD As New TimKiemGiayCNDKKDController
            objTimKiemGiayCNDKKDInfo.TuNgay = Trim(txtTuNgay.Text)
            objTimKiemGiayCNDKKDInfo.DenNgay = Trim(txtDenNgay.Text)
            objTimKiemGiayCNDKKDInfo.SoGiayPhep = Trim(txtSoGiayPhep.Text)
            objTimKiemGiayCNDKKDInfo.HoTen = Trim(txtHoTen.Text)
            objTimKiemGiayCNDKKDInfo.TinhTrangHienTai = Trim(ddlTinhTrangHienTai.SelectedValue)
            objTimKiemGiayCNDKKDInfo.SoNha = txtSoNha.Text
            objTimKiemGiayCNDKKDInfo.MaDuong = ddlDuong.SelectedValue
            objTimKiemGiayCNDKKDInfo.MaPhuong = ddlPhuong.SelectedValue
            objTimKiemGiayCNDKKDInfo.IsHuy = txtIsHuy.Text
            objTimKiemGiayCNDKKDInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            ds = objTimKiemGiayCNDKKD.LayDanhSachGiayCNDKKD(objTimKiemGiayCNDKKDInfo)
            Return ds
        End Function
        Private Sub LoadGrid()
            Dim strLoaiHoSo, strURL As String
            Dim ds As New DataSet
            ds = DanhSachGiayCNDKKD()

            BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Số giấy phép, Ngày Cấp, Họ tên, Địa chỉ xây dựng, Nội dung xây dựng", "80,60,150,200,200", False, False)
            AddAttributeCheckbox()

        End Sub
        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub

        Private Sub AddAttributeCheckbox()
            Dim chk As CheckBox
            Dim i As Integer
            If dgdDanhSach.Items.Count = 0 Then Exit Sub
            For i = 0 To dgdDanhSach.Controls(0).Controls.Count - 1
                chk = CType(dgdDanhSach.Controls(0).Controls(i).FindControl("chkXoa"), CheckBox)
                If Not chk Is Nothing Then
                    chk.Attributes.Add("OnClick", "javascript: return select_deselect('" & chk.ClientID & "');")
                End If
            Next
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            LoadGrid()
        End Sub
    End Class

End Namespace