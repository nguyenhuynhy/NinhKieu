Imports PortalQH
Imports System.Configuration
Namespace CPXD
    Public Class HoSoThamDinh
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInPhieuChuyen As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents imgNgayThamDinh As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayThamDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDonViThamDinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMaCanBoDeXuat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTrinhThamDinhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents tblThamDinh As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents txtVeViec As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayPhanHoi As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayPhanHoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoThamDinhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList

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
            txtSoBienNhan.Text = Request.Params("ID").ToString
            If Not IsPostBack Then
                Init_State()
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
            End If
        End Sub
        Private Sub Init_State()
            BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
            BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
            BindControl.BindDropDownList(ddlDonViThamDinh, "DMPHONGBAN")
            BindDropDownList_NguoiKy(ddlMaSoLanhDao)
            txtNgayPhanHoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayPhanHoi);")
            imgNgayPhanHoi.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayPhanHoi, 'dd/mm/yyyy');")
            txtNgayThamDinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayThamDinh);")
            imgNgayThamDinh.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayThamDinh, 'dd/mm/yyyy');")
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
        End Sub
        Private Sub LoadData()
            Dim objHoSoThamDinh As New HoSoThamDinhController
            Dim ds As DataSet
            ds = objHoSoThamDinh.GetHoSoThamDinhBySoBienNhan(Me)
            gLoadControlValues(ds, Me)
        End Sub
        Private Sub txtNgayPhanHoi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objHoSoThamDinh As New HoSoThamDinhController
            txtHoSoThamDinhID.Text = objHoSoThamDinh.AddHoSoThamDinh(Me)
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(, txtSoBienNhan.Text), True)
        End Sub

        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objHoSoThamDinh As New HoSoThamDinhController
            objHoSoThamDinh.DelHoSoThamDinh(Me)
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnInPhieuChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInPhieuChuyen.Click
            Dim objHoSoThamDinh As New HoSoThamDinhController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileChuyenThamDinh", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objHoSoThamDinh.InChuyenHoSoThamDinh(txtSoBienNhan.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objHoSoThamDinh = Nothing
        End Sub
    End Class
End Namespace