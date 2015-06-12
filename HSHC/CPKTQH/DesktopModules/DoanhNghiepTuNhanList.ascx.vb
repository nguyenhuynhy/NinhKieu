Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class DoanhNghiepTuNhanList
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlTinhTrangHienTai As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTienBangChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btntroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


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
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
                BindControl.BindDropDownList(ddlTinhTrangHienTai, "DMTINHTRANGGIAYPHEP", "A")
            End If
            LoadGrid()


        End Sub
 
        Public Function GetTimKiemGiayCNDKKDInfo() As TimKiemGiayCNDKKDInfo
            Dim objTimKiemGiayCNDKKDInfo As New TimKiemGiayCNDKKDInfo

            objTimKiemGiayCNDKKDInfo.TuNgay = Trim(txtTuNgay.Text)
            objTimKiemGiayCNDKKDInfo.DenNgay = Trim(txtDenNgay.Text)
            objTimKiemGiayCNDKKDInfo.SoGiayPhep = Trim(txtSoGiayPhep.Text)
            objTimKiemGiayCNDKKDInfo.HoTen = Trim(txtHoTen.Text)
            objTimKiemGiayCNDKKDInfo.TinhTrangHienTai = Trim(ddlTinhTrangHienTai.SelectedValue)
            objTimKiemGiayCNDKKDInfo.SoNha = txtSoNha.Text
            objTimKiemGiayCNDKKDInfo.MaDuong = ddlDuong.SelectedValue
            objTimKiemGiayCNDKKDInfo.MaPhuong = ddlPhuong.SelectedValue
            objTimKiemGiayCNDKKDInfo.IsHuy = "0"
            objTimKiemGiayCNDKKDInfo.URL = EditURL("ID", "VALUE")
            Return objTimKiemGiayCNDKKDInfo

        End Function
        Private Sub LoadGrid()
            Dim objTimKiemGiayCNDKKDInfo As New TimKiemGiayCNDKKDInfo
            Dim objTimKiemGiayCNDKKD As New TimKiemGiayCNDKKDController
            objTimKiemGiayCNDKKDInfo = GetTimKiemGiayCNDKKDInfo()
            Dim ds As New DataSet

            lblTieuDe.Text = "Danh sách hộ kinh doanh cá thể"
            ds = objTimKiemGiayCNDKKD.DSHoKDCaTheDauKy(objTimKiemGiayCNDKKDInfo)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "", "", False, True)
                

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

        Private Sub btntroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            LoadGrid()
        End Sub
        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL("ID"))
        End Sub
    End Class
End Namespace

