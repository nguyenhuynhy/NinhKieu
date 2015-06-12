Imports PortalQH
Imports System.Configuration
Namespace CPLDQH
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
        Protected WithEvents tblThamDinh As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayThamDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayPhanHoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayPhanHoiThucTe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTrinhThamDinhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbYkien As System.Web.UI.WebControls.Label
        Protected WithEvents txtMaCanBoDeXuat As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbPhieuChuyenKhaoSat As System.Web.UI.WebControls.Label
        Protected WithEvents txtDiaChiKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlDonViThamDinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNguoiNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdNgayThamDinh As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayPhanHoi As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayPhanHoiThucTe As System.Web.UI.WebControls.HyperLink
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

        End Sub

#End Region
        Private strControl As String
        Private strSoGiayPhep As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            strControl = Request.Params("oldControl")
            strSoGiayPhep = Request.Params("SoGiayPhep")
            Select Case Request.Params("Loai")
                Case "DX"
                    tblThamDinh.Visible = False
                    lbYkien.Visible = True
                    txtNoiDung.Visible = True
                    'btnInPhieuKhaoSat.Visible = False
                    btnIn.Visible = True
                    lblTieuDe.Text = "Thông tin đề xuất"
                    lbPhieuChuyenKhaoSat.Visible = False
                Case "TT"

                    tblThamDinh.Visible = False
                    lblTieuDe.Text = "Thông tin tờ trình"
                Case "TD"
                    lbPhieuChuyenKhaoSat.Visible = True
                    tblThamDinh.Visible = True
                    lbYkien.Visible = False
                    txtNoiDung.Visible = False
                    ddlMaSoLanhDao.Visible = True
                    'btnInPhieuKhaoSat.Visible = True
                    btnIn.Visible = False
                    lblTieuDe.Text = "Thông tin chuyển thẩm định"
            End Select

           
            txtNgayThamDinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayThamDinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThamDinh.ClientID & ");")
            cmdNgayThamDinh.NavigateUrl = AdminDB.InvokePopupCal(txtNgayThamDinh)
            txtNgayPhanHoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayPhanHoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayPhanHoi.ClientID & ");")
            cmdNgayPhanHoi.NavigateUrl = AdminDB.InvokePopupCal(txtNgayPhanHoi)
            txtNgayPhanHoiThucTe.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayPhanHoiThucTe.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayPhanHoiThucTe.ClientID & ");")
            cmdNgayPhanHoiThucTe.NavigateUrl = AdminDB.InvokePopupCal(txtNgayPhanHoiThucTe)

            btnBoQua.Attributes.Add("onclick", "javascript:history.back();")
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
                BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
                BindControl.BindDropDownList(ddlDonViThamDinh, "DMPHONGBAN")
                BindControl.BindDropDownList(ddlNguoiNhan, "DMNGUOISUDUNG")
                BindControl.BindDropDownList(ddlMaNganhKinhDoanh, "DMNGANHKINHDOANH")
                BindDropDownList_NguoiKy(ddlMaSoLanhDao)
                txtMaCanBoDeXuat.Text = CType(Session.Item("UserName"), String)
                'BindControl.BindDropDownList(ddlMaDuong, "DMNGANHKINHDOANH")
                txtSoBienNhan.Text = Request.Params("ID").ToString
                txtLoai.Text = Request.Params("Loai").ToString
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
                txtNgayThamDinh.Text = NgayHienTai()
                btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            End If
            Dim strGioiTinh As String
            Select Case UCase(ddlGioiTinh.SelectedValue)
                Case "1"
                    strGioiTinh = "ông"
                Case "0"
                    strGioiTinh = "bà"
                Case ""
                    strGioiTinh = ""
            End Select
            Dim strNoiDung As String
            strNoiDung = GetParamByID("Ykiendexuat", glbXMLFile)
            strNoiDung = Replace(strNoiDung, "[HoTen]", txtHoTen.Text)
            txtNoiDung.Attributes.Add("tag", strNoiDung)
            txtMatHangKinhDoanh.Attributes.Add("onblur", "javascript:GetNoiDung('" & txtMatHangKinhDoanh.ClientID & "','" & txtNoiDung.ClientID & "');")
            txtNoiDung.Text = strNoiDung
            txtMaLinhVuc.Text = gItemCode
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), Request.Params("Loai"), ctype(Session.Item("ActiveDB"),string), btnIn, Me)
        End Sub


        Private Sub LoadData()
            Dim objThamDinhDeXuat As New ThamDinhDeXuatController
            Dim rs As DataSet
            rs = objThamDinhDeXuat.GetThamDinhDeXuatBySoBienNhan(txtSoBienNhan.Text, Request.Params("Loai"))
            gLoadControlValues(rs, Me)
            
        End Sub




        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objThamDinhDeXuat As New ThamDinhDeXuatController
            txtTrinhThamDinhID.Text = objThamDinhDeXuat.AddThamDinhDeXuat(Me)
            
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objThamDinhDeXuat As New ThamDinhDeXuatController
            objThamDinhDeXuat.DelThamDinhDeXuat(Me)
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Function f_ExportFile(ByVal ds As DataSet, ByVal Path As String, ByVal FileTemplate As String, ByVal FileExport As String) As String
            Dim url As String
            Dim Script As String
            Dim Tool As OfficeTools.WordTools = New OfficeTools.WordTools

            If Right(FileTemplate, 4) <> ".doc" Then
                Exit Function
            End If
            Tool.OpenFile(FileTemplate)
            Tool.AddToMergeField(ds, 0)

            f_ExportFile = Tool.DoAll(GetAbsoluteServerPath(Request), Path, FileExport)
            Tool.CloseFile()
        End Function

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objThamDinhDexuat As New ThamDinhDeXuatController
            Dim ds As New DataSet
            'Dim strFileTemplate As String
            'Dim strFileOutput As String
            'Dim strFileOpen As String
            'Dim strFileName As String
            'strFileName = GetParamByID("FileDeXuat", glbXMLFile)
            'strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            'strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            'strFileOpen = strFileOutput
            'strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            'ds = objThamDinhDexuat.InBaoCaoDeXuat(txtHoSoTiepNhanID.Text)
            'ReportByWord(ds, strFileTemplate, strFileOutput)
            'Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")

            Dim Script As String
            Dim strFileNew As String
            Dim strServerPath As String
            Dim strFileTemplate As String
            Dim strPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            strPath = "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            strFileNew = "DX" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
            strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileDeXuat", glbXMLFile)
            ds = objThamDinhDexuat.InBaoCaoDeXuat(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportFile(ds, strPath, strFileTemplate, strFileNew))
            Page.RegisterStartupScript("OpenWindow", Script)
            objThamDinhDexuat = Nothing
        End Sub

        Private Sub btnInPhieuChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim objThamDinhDexuat As New ThamDinhDeXuatController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FilePhieuChuyenKhaoSat", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objThamDinhDexuat.InPhieuChuyenKhaoSat(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objThamDinhDexuat = Nothing
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, strControl), True)
        End Sub
    End Class
End Namespace