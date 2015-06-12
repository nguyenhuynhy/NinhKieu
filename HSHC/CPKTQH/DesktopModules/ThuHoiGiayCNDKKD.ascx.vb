Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class ThuHoiGiayCNDKKD
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLoaiDoanhNghiep As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblVonKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHetHanGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgaySinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblChuoiGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThuHoiCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayDuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDuyet As System.Web.UI.WebControls.Image
        Protected WithEvents ddlNguoiThuHoi As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayThuHoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayThuHoi As System.Web.UI.WebControls.Image
        Protected WithEvents chkTraGiayPhep As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlNguoiTra As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayTraGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayTra As System.Web.UI.WebControls.Image
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTrove As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblLanThuHoi As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoLanThuHoi As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLinhVucCapPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabelDonViTinh As System.Web.UI.WebControls.Label
        Protected WithEvents btnInTTT As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInQD As System.Web.UI.WebControls.LinkButton




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
            If Not Page.IsPostBack Then
                LoadThongTinCNDKKD()
                SetAttributesControl()
                BindData()
                LoadThongTinThuHoi()
                SetVisibleControl()
                txtGiayCNDKKDID.Text = Request.Params("ID")
            End If
            If txtThuHoiCNDKKDID.Text <> "" Then
                btnInQD.Visible = True
                btnInTTT.Visible = True
            Else
                btnInQD.Visible = False
                btnInTTT.Visible = False
            End If
            Page.RegisterStartupScript("TraGiayPhep", "<script language='javascript'>AlterDiv();</script>")
        End Sub

        Private Sub LoadThongTinCNDKKD()
            Dim objGiayCNDKKD As New GiayCNDKKDController
            gLoadControlValues(objGiayCNDKKD.GetGiayCNDKKDByID(Request.Params("ID")), Me)
            txtGiayCNDKKDID.Text = Request.Params("ID")
            objGiayCNDKKD = Nothing

            txtSoGiayPhep.Text = lblSoGiayPhep.Text
            If txtGiayCNDKKDID.Text = "" Then
                'trường hợp không tồn tại giấy phép
                btnTrove_Click(Nothing, Nothing)
            End If
        End Sub

        Private Sub LoadThongTinThuHoi()
            Dim objThuHoi As New ThuHoiCNDKKDController
            Dim ds As DataSet

            ds = objThuHoi.getThuHoiCNDKKD(txtGiayCNDKKDID.Text)
            gLoadControlValues(ds, Me)

            If lblTongSoLanThuHoi.Text = "" Then
                lblTongSoLanThuHoi.Text = "1"
            End If
            lblLanThuHoi.Text = lblTongSoLanThuHoi.Text

            ds = Nothing
            objThuHoi = Nothing
        End Sub

        Private Sub SetAttributesControl()
            txtNgayDuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayDuyet.ClientID & ");")
            imgNgayDuyet.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayDuyet.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayDuyet.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayDuyet.ClientID & ");")
            Me.txtNgayDuyet.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayThuHoi.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThuHoi.ClientID & ");")
            imgNgayThuHoi.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayThuHoi.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayThuHoi.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayThuHoi.ClientID & ");")
            Me.txtNgayThuHoi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayTraGiayPhep.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayTraGiayPhep.ClientID & ");")
            imgNgayTra.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayTraGiayPhep.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayTraGiayPhep.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayTraGiayPhep.ClientID & ");")
            Me.txtNgayTraGiayPhep.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            chkTraGiayPhep.Attributes.Add("onclick", "javascript:AlterDiv();")

            ddlMaLyDo.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDung.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")
            ddlNguoiThuHoi.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayDuyet.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayThuHoi.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac chan muon xoa thong tin thu hoi giay CN nay khong?');")
        End Sub

        Private Sub SetVisibleControl()
            If txtThuHoiCNDKKDID.Text = "" Then
                'chưa thu hồi giấy CN ĐKKD
                btnThemMoi.Visible = False
                btnXoa.Visible = False
            Else
                'đã thu hồi giấy CN ĐKKD nhưng chưa trả lại giấy phép
                If Not chkTraGiayPhep.Checked Then
                    btnThemMoi.Visible = False
                End If
            End If
        End Sub

        Private Sub BindData()
            BindControl.BindDropDownList(ddlMaLyDo, "DMLYDO")
            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)
            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))
            BindControl.BindDropDownList(ddlNguoiThuHoi, "DMNGUOISUDUNG")
            BindControl.BindDropDownList(ddlNguoiTra, "DMNGUOISUDUNG")

            txtNgayDuyet.Text = Format(Now, "dd/MM/yyyy")
            txtNgayThuHoi.Text = Format(Now, "dd/MM/yyyy")
        End Sub

        Private Sub btnTrove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrove.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                Dim objThuHoi As New ThuHoiCNDKKDController
                If txtThuHoiCNDKKDID.Text = "" Then
                    'chưa thu hồi giấy CN ĐKKD
                    If Not objThuHoi.insThuHoiCNDKKD(Me) Then
                        SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                        Exit Sub
                    End If
                Else
                    'cập nhật thông tin giấy CN ĐKKD
                    If Not objThuHoi.updThuHoiCNDKKD(Me) Then
                        SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                        Exit Sub
                    End If
                End If
                objThuHoi = Nothing

                Response.Redirect(Request.RawUrl())
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Try
                Dim objThuHoi As New ThuHoiCNDKKDController

                If Not objThuHoi.delThuHoiCNDKKD(txtThuHoiCNDKKDID.Text) Then
                    SetMSGBOX_HIDDEN(Page, "Xoa thong tin thu hoi khong thanh cong!")
                    Exit Sub
                End If

                objThuHoi = Nothing
                Response.Redirect(Request.RawUrl())
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            txtThuHoiCNDKKDID.Text = ""
            ddlMaLyDo.SelectedValue = ""
            txtNoiDung.Text = ""
            ddlMaSoLanhDao.SelectedValue = ""
            ddlNguoiThuHoi.SelectedValue = ""
            txtNgayDuyet.Text = ""
            txtNgayThuHoi.Text = ""
            chkTraGiayPhep.Checked = False
            ddlNguoiTra.SelectedValue = ""
            txtNgayTraGiayPhep.Text = ""
            txtGhiChu.Text = ""
            lblLanThuHoi.Text = CStr(CInt(lblLanThuHoi.Text) + 1)

            btnThemMoi.Visible = False
            btnXoa.Visible = False

            Page.RegisterStartupScript("TraGiayPhep", "<script language='javascript'>AlterDiv();</script>")
        End Sub

        Private Sub btnInTTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInTTT.Click
            Dim obj As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileTBThuHoi", glbXMLFile)
            strOutputFileName = "TB" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = obj.InThongBaoThuHoiGCNDKKD(Request.Params("ID"))
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            obj = Nothing
            ds = Nothing
        End Sub

        Private Sub btnInQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInQD.Click
            Dim obj As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileQDThuHoi", glbXMLFile)
            strOutputFileName = "QD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = obj.InQuyetDinhThuHoiGCNDKKD(Request.Params("ID"))
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            obj = Nothing
            ds = Nothing
        End Sub
    End Class
End Namespace