Imports PortalQH
Namespace CPKTQH
    Public Class HuyGiayCNDKKD
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCNDKKD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLyDoHuy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNguoiDuyet As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayDuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayDuyet As System.Web.UI.WebControls.Image
        Protected WithEvents ddlNguoiHuy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayHuy As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayHuy As System.Web.UI.WebControls.Image
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDanhSachGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents tblNoiDung As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtHuyGiayCNDKKDID As System.Web.UI.WebControls.TextBox




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
                SetAttributesControl()
                BindData()
                GetData()
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtNgayDuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayDuyet.ClientID & ");")
            imgNgayDuyet.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayDuyet.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayDuyet.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayDuyet.ClientID & ");")
            Me.txtNgayDuyet.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHuy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHuy.ClientID & ");")
            imgNgayHuy.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayHuy.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayHuy.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayHuy.ClientID & ");")
            Me.txtNgayHuy.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            ddlLyDoHuy.Attributes.Add("ISNULL", "NOTNULL")
            ddlNguoiDuyet.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayDuyet.Attributes.Add("ISNULL", "NOTNULL")
            ddlNguoiHuy.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayHuy.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return KiemTraCapNhat();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin huy giay CN DKKD nay khong?');")
            'GetReportURL(Request.Params("TabID"), GetLinhVuc, "1", CType(Session.Item("ActiveDB"), String), btnIn, Me)
        End Sub

        Private Sub BindData()
            txtHoSoTiepNhanID.Text = Request.Params("ID")
            txtTabCode.Text = Request.Params("TabID")
            txtLinhVuc.Text = GetLinhVuc()
            txtNguoiTacNghiep.Text = CStr(Session.Item("UserName"))

            BindControl.BindDropDownList(ddlLyDoHuy, "DMLYDO")
            'BindDropDownList_NguoiKy(ddlNguoiDuyet)
            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlNguoiDuyet, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))
            BindControl.BindDropDownList(ddlNguoiHuy, "DMNGUOISUDUNG")
        End Sub

        Private Sub GetData()
            Dim objHuyCNDKKD As New HuyGiayCNDKKDController
            Dim ds As DataSet
            ds = objHuyCNDKKD.getHuyGiayCNDKKD(txtHoSoTiepNhanID.Text)
            gLoadControlValues(ds, Me)

            If txtGiayCNDKKDID.Text = "" Then
                'hồ sơ tiếp nhận này chưa được cấp giấy CN
                tblNoiDung.Visible = False
                btnCapNhat.Visible = False
                btnIn.Visible = False
                btnXoa.Visible = False
                lblTieuDe.Text = "Hồ sơ này chưa được cấp giấy chứng nhận"
            ElseIf txtHuyGiayCNDKKDID.Text = "" Then
                'hồ sơ đã cấp giấy CN ĐKKD nhưng chưa hủy giấy CN ĐKKD
                btnXoa.Visible = False
                btnIn.Visible = False

                txtNgayDuyet.Text = Format(Now(), "dd/MM/yyyy")
                txtNgayHuy.Text = Format(Now(), "dd/MM/yyyy")
                Try
                    ddlNguoiHuy.SelectedValue = txtNguoiTacNghiep.Text
                Catch ex As Exception
                    ddlNguoiHuy.SelectedValue = Nothing
                End Try
            End If
            objHuyCNDKKD = Nothing
            ds = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                Dim objHuyCNDKKD As New HuyGiayCNDKKDController

                If txtHuyGiayCNDKKDID.Text = "" Then
                    'thêm mới thông tin hủy
                    If Not objHuyCNDKKD.insHuyGiayCNDKKD(Me) Then
                        SetMSGBOX_HIDDEN(Page, "Huy giay chung nhan khong thanh cong!")
                        Exit Sub
                    End If
                Else
                    If Not objHuyCNDKKD.updHuyGiayCNDKKD(Me) Then
                        SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                        Exit Sub
                    End If
                End If
                objHuyCNDKKD = Nothing
                Response.Redirect(Request.RawUrl)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Try
                Dim objHuyCNDKKD As New HuyGiayCNDKKDController

                If Not objHuyCNDKKD.delHuyGiayCNDKKD(Me) Then
                    SetMSGBOX_HIDDEN(Page, "Xoa thong tin huy giay chung nhan khong thanh cong!")
                    Exit Sub
                End If
                objHuyCNDKKD = Nothing
                Response.Redirect(Request.RawUrl())
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objHuyGiayCNDKKD As New HuyGiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileHuyGiayCNDKKD", glbXMLFile)
            strOutputFileName = "ThongBaoHuyGCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objHuyGiayCNDKKD.InThongBaoHuyGCNDKKD(txtGiayCNDKKDID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objHuyGiayCNDKKD = Nothing
            ds = Nothing
        End Sub
    End Class
End Namespace