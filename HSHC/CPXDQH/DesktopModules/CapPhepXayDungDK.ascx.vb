Imports System.Configuration
Imports PortalQH
Namespace CPXD
    Public Class CapPhepXayDungDK
        Inherits PortalQH.PortalModuleControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents title As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayCapPhep As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhanLoaiXayDung As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaCapNha As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDonViThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtKyHieuThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChieuCaoTungTang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChieuCaoToanCongTrinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTichKhuonVien As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChiGioiXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaySuDungDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThoiHanHoanThanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGiayPhepXayDungID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter

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
            If Not IsPostBack Then
                Init_State()
                GetGiayPhepXayDung()
            End If

        End Sub
        Private Sub Init_State()
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
            Dim objDanhMuc As New DanhMucController
            dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
            dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
            BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, "")
            BindDropDownList_Dataset(ddlMaDuong, dsDuong, "TenDuong", "MaDuong", True, "")
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                With ctrlScriptComboFilter
                    .ConditionID = ddlMaPhuong.ClientID
                    .ConditionText = "Ten"
                    .ConditionValue = "Ma"
                    .ResultID = ddlMaDuong.ClientID
                    .ResultText = "TenDuong"
                    .ResultValue = "MaDuong"
                    .ConditionDS = dsPhuong
                    .ResultDS = dsDuong
                End With
                ddlMaPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            Else
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            End If

            BindControl.BindDropDownList(ddlMaPhanLoaiXayDung, "DMPHANLOAIXAYDUNG")
            BindControl.BindDropDownList(ddlMaCapNha, "DMCAPNHA")
            BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
        End Sub
        Private Sub GetGiayPhepXayDung()
            Dim objGPXD As New CapMoiGPXDController
            gLoadControlValues(objGPXD.GetGiayPhepXayDungByID(Request.Params("ID")), Me)
        End Sub


        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objGPXD As New CapMoiGPXDController
            txtGiayPhepXayDungID.Text = objGPXD.AddGiayPhepXayDungDK(Me)
        End Sub
    End Class
End Namespace
