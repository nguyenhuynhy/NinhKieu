Imports PortalQH
Namespace CPXD
    Public Class ViPhamHanhChinhList
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoQuyetDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
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
            If Not Page.IsPostBack Then
                BindControl.BindDropDownList(ddlDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")

                txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)

                Dim objVPHCInfo As New ViPhamHanhChinhInfo
                Session("ViPhamHanhChinhInfo") = objVPHCInfo
                SetValues()
                objVPHCInfo = Nothing
            End If
            LoadGrid()
        End Sub


        Private Sub LoadGrid()
            Dim objVPHC As New ViPhamHanhChinhController
            Dim ds As DataSet

            ds = objVPHC.getDanhSachViPhamHanhChinh(CType(Session("ViPhamHanhChinhInfo"), ViPhamHanhChinhInfo))
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số quyết định, Họ tên, Số CMND, Địa chỉ, Số giấy phép,Lô đất", "100,200,80,250,100", False, True)

            ds = Nothing
            objVPHC = Nothing
        End Sub

        Private Sub SetValues()
            Dim objVPHCInfo As New ViPhamHanhChinhInfo
            objVPHCInfo = CType(Session("ViPhamHanhChinhInfo"), ViPhamHanhChinhInfo)
            With objVPHCInfo
                .SoQuyetDinh = txtSoQuyetDinh.Text
                .SoGiayPhep = txtSoGiayPhep.Text
                .SoCMND = txtSoCMND.Text
                .SoNha = txtSoNha.Text
                .Duong = ddlDuong.SelectedValue
                .Phuong = ddlPhuong.SelectedValue
                .URL = EditURL("ID", "VALUE")
            End With
            Session("ViPhamHanhChinhInfo") = objVPHCInfo
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

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL())
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            dgdDanhSach.CurrentPageIndex = 0
            SetValues()
            LoadGrid()
        End Sub
    End Class
End Namespace