Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH

Namespace CPXD
    Public Class GiaHanGPXD
        Inherits PortalQH.PortalModuleControl
        Private strControl As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label

        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents btnIn As System.Web.UI.WebControls.Image
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoten As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDenNgay As System.Web.UI.WebControls.Label
        Protected WithEvents cmdEndCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblTuNgay As System.Web.UI.WebControls.Label
        Protected WithEvents cmdStartCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtNgayGiaHan As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents cmdCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtGiaHanDen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnSoBN As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaHanGPXDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnSoGP As System.Web.UI.WebControls.LinkButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private Const strURL As String = "CPXD/DesktopModules/TimKiemGiayCNDKKD.aspx"
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYeuCauBoSung As System.Web.UI.WebControls.LinkButton
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            strControl = Request.Params("ctl")

            If Not Me.IsPostBack Then
                Init_State()
                SetAttributesControl() ' use for add atrr to control 
                SetAttributesNgay()
                BindControls()      'bind data into dropdown list
                BindData()
            End If
            Dim blnStatus As Boolean
            If Request.Params("AddNew") = "" Then
                blnStatus = True
            Else
                blnStatus = CBool(Request.Params("AddNew"))
            End If
            SetStatusControl(blnStatus)
            If txtSoGiayPhep.Text <> "" Then
                GetGHGPXD()
            End If
            btnSoBN.Visible = False
            lblSoBN.Visible = True
            
        End Sub
        Private Sub SetAttributesControl()
            txtNgayGiaHan.Attributes.Add("ISNULL", "NOTNULL")
            txtGiaHanDen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            btnSoGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?')")
            'sua doi ngay 8/3/2005 by Hiennd : Noi dung :Bo button In-> Khong goi ReportUrl!
            'GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", ctype(Session.Item("ActiveDB"),string), btnIn, Me)
        End Sub
        Private Sub BindData()
            If Not Request.Params("ID") Is Nothing Then
                Dim objGiaHanGPXD As New GiaHanGPXDController
                gLoadControlValues(objGiaHanGPXD.GetGiaHanGPXD(Request.Params("ID")), Me)
                objGiaHanGPXD = Nothing
            End If
        End Sub
        Private Sub GetGHGPXD()
            Dim objGiaHanGPXD As New GiaHanGPXDController
            Dim ds As DataSet
            ds = objGiaHanGPXD.GetGiaHanGPXDbySoGiayPhep(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me)
            ds = Nothing
        End Sub

        Private Sub BindControls()
            BindControl.BindDropDownList(ddlMaDuong, "DMDuong")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPhuong")
            BindDropDownList_NguoiKy(ddlMaSoLanhDao)
        End Sub
        Private Sub Init_State()
            txtTabCode.Text = Request.Params("TabID")
            txtHoSoTiepNhanID.Text = Request.Params("ID")
            txtMaNguoiTacNghiep.Text = CStr(Session.Item("UserName"))
            txtNgayGiaHan.Text = NgayHienTai()
            txtGiaHanDen.Text = NgayHienTai()
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)

        End Sub

        Private Sub SetStatusControl(ByVal IsAddNew As Boolean)
            btnSoBN.Visible = IsAddNew
            btnSoGP.Visible = IsAddNew

            lblSoBN.Visible = Not IsAddNew
            lblSoGP.Visible = Not IsAddNew
            If (txtSoBienNhan.Text = "" Or txtSoBienNhan.Text Is Nothing) Then
                btnSoGP.Visible = False
                lblSoGP.Visible = True
            End If
            btnXoa.Visible = Not IsAddNew
            'Sua ngay 8/3/2005 : Bo button In
            'btnIn.Visible = Not IsAddNew
        End Sub
        Private Sub SetAttributesNgay()
            txtNgayGiaHan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtGiaHanDen.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayGiaHan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayGiaHan.ClientID & ");")
            txtGiaHanDen.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtGiaHanDen.ClientID & ");")
            txtGiaHanDen.Attributes.Add("onblur", "javascript:CheckDateOnBlurWithCompare(" & txtGiaHanDen.ClientID & "," & txtNgayGiaHan.ClientID & ");")


            cmdStartCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtNgayGiaHan)
            cmdEndCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtGiaHanDen)
        End Sub

        Private Sub btnSoBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoBN.Click
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl") & "&AddNew=" & Request.Params("AddNew")), True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                'cập nhật hồ sơ không giải quyết
                Dim objGiaHanGPXD As New GiaHanGPXDController
                Try
                    objGiaHanGPXD.AddGiaHanGPXD(Me)
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Page, ex.Message)
                End Try
                objGiaHanGPXD = Nothing
                SetStatusControl(False)

            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objGiaHanGPXDController As New GiaHanGPXDController
            Dim str As String
            str = objGiaHanGPXDController.DelGiaHanGPXD(Me)
            Select Case objGiaHanGPXDController.DelGiaHanGPXD(Me)
                Case "2" : Exit Sub
                Case "1"
                    SetMSGBOX_HIDDEN(Page, "Xóa không thành công!")
                Case "0"
                    SetMSGBOX_HIDDEN(Page, "Đã xoá!")
                    Response.Redirect(NavigateURL(""))

            End Select
            Response.Redirect(NavigateURL(), True)
            objGiaHanGPXDController = Nothing
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objGPXD As New GiaHanGPXDController

            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileDeXuatGiaHan", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & ctype(Session.Item("ActiveDB"),string)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & ctype(Session.Item("ActiveDB"),string)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objGPXD.InGiaHan(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objGPXD = Nothing
        End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            strHoSoTiepNhanID = txtHoSoTiepNhanID.Text
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & strControl, True)
        End Sub

        Private Sub btnYeuCauBoSung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYeuCauBoSung.Click
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSK As New HoSoKhongGiaiQuyetController
            Dim objBCDX As New BaoCaoDeXuatController
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If
            'If strHoSoTiepNhanID <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
            If strSoBienNhan <> "" And objBCDX.CheckBaoCaoDeXuat(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so da lam de xuat")
                Exit Sub
            End If
            Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG") & "&oldControl=" & strControl, True)
        End Sub
    End Class
End Namespace
