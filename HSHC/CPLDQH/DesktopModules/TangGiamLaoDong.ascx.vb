Imports PortalQH
Namespace CPLDQH
    Public Class TangGiamLaoDong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents Label13 As System.Web.UI.WebControls.Label
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents Label17 As System.Web.UI.WebControls.Label
        Protected WithEvents Label18 As System.Web.UI.WebControls.Label
        Protected WithEvents Label19 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTongSoLDDauKy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDNuDauKy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDTangTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDNuTangTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDGiamTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamNghiHuuTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamThoiViecTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamSaThaiTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDGiamKhacTK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDCK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDNuCK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongHDLDKXD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHDLDKXDNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongHDLDXD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHDLDXDNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongHDLDTV As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHDLDTVNu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDDTDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLD12DK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLD12NuDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDDuTuyenDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDThongQuaDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDKXDDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDKXDNuDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDXDDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTangGiamLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label10 As System.Web.UI.WebControls.Label
        Protected WithEvents Label11 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayNhap As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayNhap As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlMaKyBaoCao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTenDonVi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDDTNuDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTongSoLDDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDNuDk As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLDTVNuDK As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSuDungLaoDongID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox

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
            SetAttribute()
            If Not Page.IsPostBack Then
                InitState()
                BindData()
                txtMaSoNguoiSuDung.Text = CType(Session.Item("UserName"), String)
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            End If            
        End Sub

        Sub InitState()
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaKyBaoCao, "DMKYBAOCAO")
            txtNgayNhap.Text = Format(Now, "dd/MM/yyyy")
        End Sub

        Sub BindData()
            Dim objTangGiamLaoDong As New TangGiamLaoDongController
            Dim ds As DataSet
            If Not Request.QueryString("ID") Is Nothing Then
                'txtHoSoTiepNhanID.Text = CType(Request.QueryString("ID"), String)
                txtSuDungLaoDongID.Text = CType(Request.QueryString("ID"), String)
            End If
            'ds = objTangGiamLaoDong.GetTangGiamLaoDong(txtHoSoTiepNhanID.Text, ddlMaKyBaoCao.SelectedValue)
            ds = objTangGiamLaoDong.GetTangGiamLaoDong(txtSuDungLaoDongID.Text, ddlMaKyBaoCao.SelectedValue)
            gLoadControlValues(ds, Me)
            If txtTangGiamLaoDongID.Text = "" Then
                txtNgayNhap.Text = Format(Now, "dd/MM/yyyy")
            End If
            SetVisibleButton()
            objTangGiamLaoDong = Nothing
        End Sub

        Sub SetVisibleButton()
            If txtTangGiamLaoDongID.Text <> "" Then
                btnXoa.Visible = True
            Else
                btnXoa.Visible = False
            End If
        End Sub

        Private Sub SetAttribute()
            'add lich cho ngay
            txtNgayNhap.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayNhap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayNhap.ClientID & ");")
            cmdNgayNhap.NavigateUrl = AdminDB.InvokePopupCal(txtNgayNhap)

            txtSoLD12NuDK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLD12NuDK.ClientID & ");")
            txtSoLDDuTuyenDK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDDuTuyenDK.ClientID & ");")
            txtSoLDGiamKhacTK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamKhacTK.ClientID & ");")
            txtSoLDGiamNghiHuuTK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamNghiHuuTK.ClientID & ");")
            txtSoLDGiamSaThaiTK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamSaThaiTK.ClientID & ");")
            txtSoLDGiamThoiViecTK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDGiamThoiViecTK.ClientID & ");")
            txtSoLDKXDNuDK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDKXDNuDK.ClientID & ");")
            txtSoLDNuDauKy.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDNuDauKy.ClientID & ");")
            txtSoLDNuCK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDNuCK.ClientID & ");")
            txtSoLDNuTangTK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDNuTangTK.ClientID & ");")
            txtSoLDThongQuaDK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDThongQuaDK.ClientID & ");")
            txtSoLDTVNuDK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDTVNuDK.ClientID & ");")
            txtHDLDKXDNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHDLDKXDNu.ClientID & ");")
            txtHDLDTVNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHDLDTVNu.ClientID & ");")
            txtHDLDXDNu.Attributes.Add("onblur", "javascript:CheckData(" & txtHDLDXDNu.ClientID & ");")
            txtTongHDLDKXD.Attributes.Add("onblur", "javascript:CheckData(" & txtTongHDLDKXD.ClientID & ");")
            txtTongHDLDTV.Attributes.Add("onblur", "javascript:CheckData(" & txtTongHDLDTV.ClientID & ");")
            txtTongHDLDXD.Attributes.Add("onblur", "javascript:CheckData(" & txtTongHDLDXD.ClientID & ");")
            txtTongSoLD12DK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLD12DK.ClientID & ");")
            txtTongSoLDCK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDCK.ClientID & ");")
            txtTongSoLDDauKy.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDDauKy.ClientID & ");")
            txtTongSoLDDTDK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDDTDK.ClientID & ");")
            txtTongSoLDGiamTK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDGiamTK.ClientID & ");")
            txtTongSoLDKXDDK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDKXDDK.ClientID & ");")
            txtTongSoLDTangTK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDTangTK.ClientID & ");")
            txtTongSoLDXDDK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDXDDK.ClientID & ");")
            txtSoLDDTNuDK.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDDTNuDK.ClientID & ");")
            txtTongSoLDDK.Attributes.Add("onblur", "javascript:CheckData(" & txtTongSoLDDK.ClientID & ");")
            txtSoLDNuDk.Attributes.Add("onblur", "javascript:CheckData(" & txtSoLDNuDk.ClientID & ");")

            'set thuoc tinh not null
            ddlMaKyBaoCao.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayNhap.Attributes.Add("ISNULL", "NOTNULL")
            txtTenDonVi.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ''''''''''''''''''''''''
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objTangGiamLaoDong As New TangGiamLaoDongController
            txtTangGiamLaoDongID.Text = objTangGiamLaoDong.AddTangGiamLaoDong(Me)
            objTangGiamLaoDong = Nothing
            BindData()
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objTangGiamLaoDong As New TangGiamLaoDongController
            objTangGiamLaoDong.DelTangGiamLaoDong(txtTangGiamLaoDongID.Text)
            objTangGiamLaoDong = Nothing
            'Response.Redirect(NavigateURL(), True)
            txtTangGiamLaoDongID.Text = ""
            BindData()
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub ddlMaKyBaoCao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaKyBaoCao.SelectedIndexChanged
            BindData()
        End Sub
    End Class
End Namespace