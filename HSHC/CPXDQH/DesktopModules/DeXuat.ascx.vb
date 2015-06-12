Imports PortalQH
Imports System.Configuration
Namespace CPXD
    Public Class DeXuat
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As ProgStudios.WebControls.ComboBox
        Protected WithEvents ddlMaPhuong As ProgStudios.WebControls.ComboBox
        Protected WithEvents txtMaCanBoDeXuat As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents TabStrip1 As Microsoft.Web.UI.WebControls.TabStrip
        Protected WithEvents tsNXHS As Microsoft.Web.UI.WebControls.MultiPage
        Protected WithEvents txtBaoCaoDeXuatID As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As ProgStudios.WebControls.ComboBox
        Protected WithEvents txtLoDat As System.Web.UI.WebControls.TextBox
        Protected WithEvents NoiDungGiayPhep As NXHS_HangMucXDTruoc
        Protected WithEvents ddlMaLoaiCongTrinh As ProgStudios.WebControls.ComboBox
        Protected WithEvents txtGP_DienTichSanXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents LinkChon As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtYeuToKhac As System.Web.UI.WebControls.TextBox

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
            txtSoBienNhan.Text = Request.Params("ID").ToString
            txtTabCode.Text = Request.Params("TabID")
            If Not IsPostBack Then

                If txtSoBienNhan.Text <> "" Then
                    Init_State()
                    LoadData()

                End If
            End If
            'btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            Dim strGioiTinh As String
            Select Case UCase(ddlGioiTinh.SelectedValue)
                Case "1"
                    strGioiTinh = "ông"
                Case "0"
                    strGioiTinh = "bà"
                Case ""
                    strGioiTinh = ""
            End Select
        End Sub
        Public Sub Init_State()
            BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
            BindControl.BindDropDownList(ddlMaLoaiCongTrinh, "DMCAPNHA")
            BindCombobox_NguoiKy(ddlMaSoLanhDao)
            NoiDungGiayPhep.CreateDataSource(txtBaoCaoDeXuatID.Text)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim strURL As String
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMYEUTOKHAC&TextName=" & txtYeuToKhac.ClientID
            Linkchon.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
        End Sub

        Private Sub LoadData()
            Dim objBaoCaoDeXuat As New BaoCaoDeXuatController
            Dim ds As DataSet
            ds = objBaoCaoDeXuat.GetBaoCaoDeXuatBySoBienNhan(Me)
            gLoadControlValues(ds, Me)
            NoiDungGiayPhep.CreateDataSource(txtBaoCaoDeXuatID.Text)
        End Sub
        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            'Response.Redirect(NavigateURL(, txtSoBienNhan.Text), True)
            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, Request.Params("oldControl")), True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objBaoCaoDeXuat As New BaoCaoDeXuatController
            txtGP_DienTichSanXayDung.Text = NoiDungGiayPhep.GhiLaiHangMucTruoc
            txtBaoCaoDeXuatID.Text = objBaoCaoDeXuat.AddBaoCaoDeXuat(Me)
            NoiDungGiayPhep.Save_HangMucXayDung(txtBaoCaoDeXuatID.Text)
        End Sub
        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objBaoCaoDeXuat As New BaoCaoDeXuatController
            objBaoCaoDeXuat.DelBaoCaoDeXuat(Me)
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objBaoCaoDexuat As New BaoCaoDeXuatController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileDeXuat", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objBaoCaoDexuat.InBaoCaoDeXuat(txtBaoCaoDeXuatID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objBaoCaoDexuat = Nothing
        End Sub

        Private Sub btnInPhieuChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim objBaoCaoDexuat As New BaoCaoDeXuatController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FilePhieuChuyenKhaoSat", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objBaoCaoDexuat.InPhieuChuyenKhaoSat(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objBaoCaoDexuat = Nothing
        End Sub
    End Class
End Namespace