Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH

Namespace CPKTQH
    Public Class GiaHanGPKD
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnSoGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDenNgay As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayGiaHan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnNgayGiaHan As System.Web.UI.WebControls.Image
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtGiaHanDen As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnGiaHanDen As System.Web.UI.WebControls.Image
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaHanGPXDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiaHanGPKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents KiemTra As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlMaSoLanhDaoGiaHan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGhiChuGiaHan As System.Web.UI.WebControls.TextBox
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private Const strURL As String = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Các hàm sự kiện"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Me.IsPostBack Then
                SetAttributesControl()
                BindControls()
                BindData()
            End If
            If KiemTra.Value = "1" Then
                GetThongTinGCNDKKD()
            End If
        End Sub

        Private Sub BindData()
            Dim objHoSoTiepNhan As New HoSoTiepNhanController

            If Request.Params("ID") Is Nothing Then
                btnBoQua_Click(Nothing, Nothing)
            End If

            '--Get thong tin so bien nhan
            GetHoSoTiepNhan()
            
            'kiểm tra hồ sơ đã lập Yêu cầu bổ sung --> neu da lap chuyen qua man hinh yeu cau bo sung
            If objHoSoTiepNhan.DangYeuCauBoSung(txtHoSoTiepNhanID.Text) Then
                btnYCBS_Click(Nothing, Nothing)
            End If
            'kiểm tra hồ sơ đã lập Thông báo không giải quyết --> neu da lap chuyen qua man hinh không giải quyết
            If objHoSoTiepNhan.DangYeuCauBoSung(txtHoSoTiepNhanID.Text) Then
                btnHoSoKhong_Click(Nothing, Nothing)
            End If

            '--Kiểm tra hồ sơ đã lập gia hạn chưa
            Dim objGiaHan As New GiaHanGPKDController
            txtGiaHanGPKDID.Text = objGiaHan.getGiaHanID(txtHoSoTiepNhanID.Text)

            If txtGiaHanGPKDID.Text <> "" Then  'hồ sơ đã lập gia hạn
                GetThongTinGiaHan()
                GetThongTinGCNDKKD()
                If objHoSoTiepNhan.DangDeXuat(txtHoSoTiepNhanID.Text) Then
                    btnCapNhat.Visible = True
                    btnDeXuat.Visible = True
                    btnIn.Visible = True
                Else
                    btnCapNhat.Visible = True
                    btnDeXuat.Visible = True
                    btnXoa.Visible = True
                End If
            Else
                'Trường hợp chưa chọn GP gia hạn
                btnCapNhat.Visible = True
                btnSoGP.Visible = True
                lblSoGP.Visible = False
                txtSoGiayPhep.Enabled = True
                btnYCBS.Visible = True
                btnHoSoKhong.Visible = True
                txtSoGiayPhep.Enabled = True
                Init_State()
            End If
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                'cập nhật hồ sơ không giải quyết
                Dim objGiaHanGPKD As New GiaHanGPKDController
                Try
                    If Not objGiaHanGPKD.UpdGiaHanGPKD(Me) Then
                        SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                        Exit Sub
                    End If
                    If txtGiaHanGPKDID.Text = "" Then
                        Response.Redirect(Request.RawUrl())
                    End If
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Page, ex.Message)
                End Try
                objGiaHanGPKD = Nothing

            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            If txtGiaHanGPKDID.Text = "" Then
                Exit Sub
            End If

            Dim objGiaHanGPKDController As New GiaHanGPKDController
            If Not objGiaHanGPKDController.DelGiaHanGPKD(txtGiaHanGPKDID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Xoa khong thanh cong!")
                Exit Sub
            End If
            objGiaHanGPKDController = Nothing

            Response.Redirect(Request.RawUrl())
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnYCBS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYCBS.Click
            Response.Redirect(EditURL("ID", txtSoBienNhan.Text, "YEUCAUBOSUNG") & "&oldControl=" & Request.Params("ctl"), True)
        End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, "HOSOKHONG") & "&oldControl=" & Request.Params("ctl"), True)
        End Sub

        Private Sub btnDeXuat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
            Response.Redirect(EditURL("ID", txtSoBienNhan.Text, "DEXUAT") & "&Loai=HCT&oldControl=" & Request.Params("ctl") & "&SoGiayPhep=" & txtSoGiayPhep.Text, True)
        End Sub


        Private Sub txtSoGiayPhep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoGiayPhep.TextChanged
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            txtSoGiayPhep.Text = Trim(txtSoGiayPhep.Text)
            GetThongTinGCNDKKD()
            If txtSoGiayPhep.Text = "" Then
                SetMSGBOX_HIDDEN(Page, "So giay phep nay khong ton tai trong he thong!")
            End If
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileGiayCNDKKD", glbXMLFile)
            strOutputFileName = "GiayCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objGiayCNDKKD = Nothing
            ds = Nothing
        End Sub
#End Region

#Region "Các hàm gán thuộc tính và giá trị control"

        Private Sub SetAttributesControl()

            txtNgayGiaHan.Attributes.Add("ISNULL", "NOTNULL")
            txtGiaHanDen.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaSoLanhDaoGiaHan.Attributes.Add("ISNULL", "NOTNULL")
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")

            txtNgayGiaHan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayGiaHan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayGiaHan.ClientID & ");")
            txtNgayGiaHan.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayGiaHan.ClientID & ");")
            btnNgayGiaHan.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayGiaHan.ClientID & ", 'dd/mm/yyyy');")
            txtGiaHanDen.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtGiaHanDen.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtGiaHanDen.ClientID & ");")
            txtGiaHanDen.Attributes.Add("onkeyup", "javascript:getNow(" & txtGiaHanDen.ClientID & ");")
            btnGiaHanDen.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtGiaHanDen.ClientID & ", 'dd/mm/yyyy');")

            btnSoGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?')")
        End Sub
        Private Sub BindControls()
            'BindDropDownList_NguoiKy(ddlMaSoLanhDaoGiaHan)
            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDaoGiaHan, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))
        End Sub
        Private Sub Init_State()
            txtTabCode.Text = Request.Params("TabID")
            txtHoSoTiepNhanID.Text = Request.Params("ID")
            txtMaNguoiTacNghiep.Text = CStr(Session.Item("UserName"))
            txtNgayGiaHan.Text = NgayHienTai()
            txtGiaHanDen.Text = NgayHienTai()
            txtMaLinhVuc.Text = GetLinhVuc()
        End Sub

#End Region

#Region "Các hàm lấy thông tin"
        Private Sub GetHoSoTiepNhan()
            Dim objHoSoTiepNhan As New HoSoTiepNhanController
            Dim ds As New DataSet

            txtHoSoTiepNhanID.Text = Request.Params("ID")
            ds = objHoSoTiepNhan.GetChiTietHoSoTiepNhan(txtHoSoTiepNhanID.Text)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Columns.Contains("SoBienNhan") Then
                            txtSoBienNhan.Text = CStr(ds.Tables(0).Rows(0).Item("SoBienNhan"))
                            Exit Sub
                        End If
                    End If
                End If
            End If
            btnBoQua_Click(Nothing, Nothing)
        End Sub
        Private Sub GetThongTinGiaHan()
            Dim objGiaHan As New GiaHanGPKDController
            Dim ds As DataSet
            ds = objGiaHan.GetGiaHanGPKD(txtGiaHanGPKDID.Text)
            gLoadControlValues(ds, Me)
        End Sub
        Private Sub GetThongTinGCNDKKD()
            Dim objGCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            ds = objGCNDKKD.GetGiayCNDKKDBySoGiayPhep1(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me)
        End Sub
#End Region
    End Class
End Namespace
