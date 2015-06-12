Imports PortalQH
Namespace CPKTQH
    Public Class KiemTraHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnKiemTra As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblKetQuaVPHC As System.Web.UI.WebControls.Label
        Protected WithEvents lblKetQuaNganhCam As System.Web.UI.WebControls.Label
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlNganh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents chkViPham As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkNganhCam As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkNganhDieuKien As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkThongTinDKKD As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblViPham As System.Web.UI.WebControls.Label
        Protected WithEvents lblDuongPhuongCam As System.Web.UI.WebControls.Label
        Protected WithEvents lblNganhDK As System.Web.UI.WebControls.Label
        Protected WithEvents lblThongTinDKKD As System.Web.UI.WebControls.Label
        Protected WithEvents lblDanhSachViPham As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSachViPham As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblDanhSachNganhCam As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSachNganhCam As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblDanhSachNganhDK As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSachNganhDK As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblDanhSachThongTinDKKD As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSachThongTinDKKD As System.Web.UI.WebControls.DataGrid
        Protected WithEvents chkSoCMND As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label

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
            If Not Me.IsPostBack Then
                lblHeader.Text = ".:: " & Me.PortalSettings.ActiveTab.TabName & " ::."
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
                BindControl.BindDropDownList(ddlNganh, "DMNGANHKINHDOANH")

                SetVisibleControl(False)
                btnKiemTra.Attributes.Add("onclick", "javascript:return CheckKiemTra();")
            End If
        End Sub

        Private Sub btnKiemTra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKiemTra.Click

            SetVisibleControl(False)
            GetValues()

            'KIỂM TRA VI PHẠM HÀNH CHÍNH
            If chkViPham.Checked Then
                LoadGridViPham()
            End If

            'KIỂM TRA NGÀNH CẤM
            If chkNganhCam.Checked Then
                LoadGridNganhCam()
            End If

            'KIỂM TRA NGÀNH KINH DOANH CÓ ĐIỀU KIỆN
            If chkNganhDieuKien.Checked Then
                LoadGridNganhDK()
            End If

            'KIỂM TRA THÔNG TIN ĐĂNG KÝ KINH DOANH (trùng bảng hiệu, họ tên chủ sở hữu)
            If chkThongTinDKKD.Checked Then
                LoadGridThongTinDKKD()
            End If

            'KIỂM TRA THÔNG TIN ĐĂNG KÝ KINH DOANH (số cmnd)
            If chkSoCMND.Checked Then
                LoadGridThongTinDKKD()
            End If

        End Sub

        Private Sub SetVisibleControl(ByVal flag As Boolean)
            lblViPham.Visible = flag
            lblDanhSachViPham.Visible = False
            dgdDanhSachViPham.Visible = False

            lblDuongPhuongCam.Visible = False
            lblDanhSachNganhCam.Visible = False
            dgdDanhSachNganhCam.Visible = False

            lblNganhDK.Visible = False
            lblDanhSachNganhDK.Visible = False
            dgdDanhSachNganhDK.Visible = False

            lblThongTinDKKD.Visible = False
            lblDanhSachThongTinDKKD.Visible = False
            dgdDanhSachThongTinDKKD.Visible = False

            lblSoCMND.Visible = False
            lblDanhSachThongTinDKKD.Visible = False
            dgdDanhSachThongTinDKKD.Visible = False
        End Sub

        Private Sub GetValues()
            Dim obj As New KiemTraHoSoInfo
            With obj
                .SoGiayPhep = Trim(txtSoGiayPhep.Text)
                .BangHieu = Trim(txtBangHieu.Text)
                .HoTen = Trim(txtHoTen.Text)
                .SoCMND = Trim(txtSoCMND.Text)
                .SoNha = Trim(txtSoNha.Text)
                .MaDuong = ddlMaDuong.SelectedValue
                .MaPhuong = ddlMaPhuong.SelectedValue
                .MaNganh = ddlNganh.SelectedValue
            End With
            Session("KiemTraHoSoInfo") = obj
        End Sub

        Private Sub LoadGridNganhCam()
            Dim objKiemTraInfo As New KiemTraHoSoInfo
            Dim objKiemTra As New KiemTraHoSoController
            Dim ds As DataSet

            If Session("KiemTraHoSoInfo") Is Nothing Then
                btnKiemTra_Click(Nothing, Nothing)
                Exit Sub
            End If
            objKiemTraInfo = CType(Session("KiemTraHoSoInfo"), KiemTraHoSoInfo)

            ds = objKiemTra.KiemTraNganhCamKD(objKiemTraInfo)
            lblDuongPhuongCam.Visible = True
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblDuongPhuongCam.Visible = False
                        lblDanhSachNganhCam.Visible = True
                        dgdDanhSachNganhCam.Visible = True
                        dgdDanhSachNganhCam.DataSource = ds
                        dgdDanhSachNganhCam.DataBind()
                    End If
                End If
            End If
            ds = Nothing
            objKiemTra = Nothing
            objKiemTraInfo = Nothing
        End Sub

        Private Sub LoadGridNganhDK()
            Dim objKiemTraInfo As New KiemTraHoSoInfo
            Dim objKiemTra As New KiemTraHoSoController
            Dim ds As DataSet

            If Session("KiemTraHoSoInfo") Is Nothing Then
                btnKiemTra_Click(Nothing, Nothing)
                Exit Sub
            End If
            objKiemTraInfo = CType(Session("KiemTraHoSoInfo"), KiemTraHoSoInfo)

            ds = objKiemTra.KiemTraNganhKDCoDieuKien(objKiemTraInfo)
            lblNganhDK.Visible = True
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblNganhDK.Visible = False
                        lblDanhSachNganhDK.Visible = True
                        dgdDanhSachNganhDK.Visible = True
                        dgdDanhSachNganhDK.DataSource = ds
                        dgdDanhSachNganhDK.DataBind()
                    End If
                End If
            End If

            ds = Nothing
            objKiemTra = Nothing
            objKiemTraInfo = Nothing
        End Sub

        Private Sub LoadGridThongTinDKKD()
            Dim objKiemTraInfo As New KiemTraHoSoInfo
            Dim objKiemTra As New KiemTraHoSoController
            Dim ds As DataSet

            If Session("KiemTraHoSoInfo") Is Nothing Then
                btnKiemTra_Click(Nothing, Nothing)
                Exit Sub
            End If
            objKiemTraInfo = CType(Session("KiemTraHoSoInfo"), KiemTraHoSoInfo)

            ds = objKiemTra.KiemTraThongTinDKKD(objKiemTraInfo)
            lblThongTinDKKD.Visible = True
            lblSoCMND.Visible = True
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblThongTinDKKD.Visible = False
                        lblSoCMND.Visible = False
                        lblDanhSachThongTinDKKD.Visible = True
                        dgdDanhSachThongTinDKKD.Visible = True
                        dgdDanhSachThongTinDKKD.DataSource = ds
                        dgdDanhSachThongTinDKKD.DataBind()
                    End If
                End If
            End If
            ds = Nothing
            objKiemTra = Nothing
            objKiemTraInfo = Nothing
        End Sub

        Private Sub LoadGridViPham()
            Dim objKiemTraInfo As New KiemTraHoSoInfo
            Dim objKiemTra As New KiemTraHoSoController
            Dim ds As DataSet

            If Session("KiemTraHoSoInfo") Is Nothing Then Exit Sub

            objKiemTraInfo = CType(Session("KiemTraHoSoInfo"), KiemTraHoSoInfo)
            ds = objKiemTra.KiemTraViPhamHanhChinh(objKiemTraInfo)
            lblViPham.Visible = True
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblViPham.Visible = False
                        lblDanhSachViPham.Visible = True
                        dgdDanhSachViPham.Visible = True
                        dgdDanhSachViPham.DataSource = ds
                        dgdDanhSachViPham.DataBind()
                    End If
                End If
            End If
            ds = Nothing
            objKiemTra = Nothing
            objKiemTraInfo = Nothing
        End Sub

        Private Sub dgdDanhSachNganhCam_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSachNganhCam.PageIndexChanged
            dgdDanhSachNganhCam.CurrentPageIndex = e.NewPageIndex
            LoadGridNganhCam()
        End Sub

        Private Sub dgdDanhSachNganhDK_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSachNganhDK.PageIndexChanged
            dgdDanhSachNganhDK.CurrentPageIndex = e.NewPageIndex
            LoadGridNganhDK()
        End Sub

        Private Sub dgdDanhSachThongTinDKKD_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSachThongTinDKKD.PageIndexChanged
            dgdDanhSachThongTinDKKD.CurrentPageIndex = e.NewPageIndex
            LoadGridThongTinDKKD()
        End Sub

        Private Sub dgdDanhSachViPham_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSachViPham.PageIndexChanged
            dgdDanhSachViPham.CurrentPageIndex = e.NewPageIndex
            LoadGridViPham()
        End Sub
    End Class
End Namespace