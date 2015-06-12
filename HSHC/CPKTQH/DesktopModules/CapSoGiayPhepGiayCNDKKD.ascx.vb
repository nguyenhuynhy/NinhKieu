Imports PortalQH
Imports System.Configuration

Namespace CPKTQH

    Public Class CapSoGiayPhepGiayCNDKKD
        Inherits PortalQH.PortalModuleControl


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTenLinhVucCapPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenNganhKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHetHanGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblVonKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabelDonViTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDienThoai As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiCu As System.Web.UI.WebControls.Label
        Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgaySinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblChuoiGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInGiayCNDKKD As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayCNDKKD As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCap As System.Web.UI.WebControls.Image
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton

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
            If Not Session.Item("UserName") Is Nothing Then
                txtMaNguoiNhan.Text = CType(Session.Item("UserName"), String)
            Else
                Response.Redirect("Default.aspx?ctl=login")
            End If

            If Not Page.IsPostBack Then
                If Request.Params("ID") Is Nothing Then
                    btnTroVe_Click(Nothing, Nothing)
                End If
                LoadThongTinGiayPhep()
                AddJavaScript()
                'GetReportURL(Request.Params("TabId").ToString, GetLinhVuc(), "2", GetReportPath(GetLinhVuc), btnInBanSao, Me)
            End If

            If txtSoGiayCNDKKD.Text <> "" Then
                btnInGiayCNDKKD.Visible = True
            End If
        End Sub

        '***********************************************************
        '   Modified By     :PhuocDD
        '   Modified Date   :Apr 12th 2006
        '   Description     :Enable SoGCNDKKD when CAPMOI or CAPDOI
        '***********************************************************
        Private Sub LoadThongTinGiayPhep()
            Dim dsResult As DataSet
            Dim objGiayCNDKKD As New GiayCNDKKDController
            dsResult = objGiayCNDKKD.GetCapSoGiayPhepGiayCNDKKDByID(Request.Params("ID"), Request("LoaiHoSo"))
            gLoadControlValues(dsResult, Me)
            If Not dsResult Is Nothing And dsResult.Tables.Count > 0 Then
                Me.txtSoGiayCNDKKD.Enabled = (CStr(dsResult.Tables(0).Rows(0)("LoaiHoSo")).ToUpper = "CAPMOICNDKKD") Or (CStr(dsResult.Tables(0).Rows(0)("loaiHoSo")).ToUpper = "CAPDOICNDKKD")
            End If
            objGiayCNDKKD = Nothing

            'txtSoGiayPhep.Text = lblSoGiayPhep.Text
            If txtGiayCNDKKDID.Text = "" Then
                'trường hợp không tồn tại giấy phép
                btnTroVe_Click(Nothing, Nothing)
            End If
        End Sub


        Sub AddJavaScript()

            txtSoGiayCNDKKD.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")

        End Sub


        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub


        Private Sub btnInGiayCNDKKD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInGiayCNDKKD.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileGiayChungNhanDKKD", glbXMLFile)
            strOutputFileName = "GiayCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID.Text, True)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objGiayCNDKKD = Nothing
            ds = Nothing
        End Sub


        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim dsData As DataSet
            Dim LoaiHoSo As String

            If Not Request("LoaiHoSo") Is Nothing Then
                LoaiHoSo = Request("LoaiHoSo")
                dsData = objGiayCNDKKD.CapSoGiayPhepGiayCNDKKD(Request("ID"), txtSoGiayCNDKKD.Text, txtNgayCap.Text.Trim(), Request.Params("tabid"), txtMaNguoiNhan.Text, LoaiHoSo)
                If dsData.Tables(0).Rows(0).Item(0).ToString() = "" Then
                    SetMSGBOX_HIDDEN(Page, "Số giấy phép này đã được cấp!")
                ElseIf dsData.Tables(0).Rows(0).Item(0).ToString() = "Rollback" Then
                    SetMSGBOX_HIDDEN(Page, "Kết nối server bị lỗi, hãy thử lại lần nữa!")
                End If
            End If

            objGiayCNDKKD = Nothing
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim LoaiHoSo As String
            If Not Request("LoaiHoSo") Is Nothing Then
                LoaiHoSo = Request("LoaiHoSo")
                Dim objCapCNDKKD As New GiayCNDKKDController
                objCapCNDKKD.DelSoGCNCNDKKD(txtGiayCNDKKDID.Text, Request.Params("tabid"), txtMaNguoiNhan.Text, LoaiHoSo)
            End If
            btnTroVe_Click(Nothing, Nothing)
        End Sub

    End Class

End Namespace
