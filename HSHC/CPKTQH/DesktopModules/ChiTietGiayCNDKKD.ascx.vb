Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class ChiTietGiayCNDKKD
        Inherits PortalQH.PortalModuleControl


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLinhVucCapPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKD As System.Web.UI.WebControls.Label
        Protected WithEvents lblVonKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgaySinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents btnInBanSao As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnLichSu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLinhVucCapPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenNganhKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHetHanGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiCu As System.Web.UI.WebControls.Label
        Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
        Protected WithEvents lblChuoiGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDienThoai As System.Web.UI.WebControls.Label
        Protected WithEvents lblThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabelDonViTinh As System.Web.UI.WebControls.Label

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
            If Not Page.IsPostBack Then
                If Request.Params("ID") Is Nothing Then
                    btnTroVe_Click(Nothing, Nothing)
                End If
                LoadThongTinGiayPhep()
                'GetReportURL(Request.Params("TabId").ToString, GetLinhVuc(), "2", GetReportPath(GetLinhVuc), btnInBanSao, Me)
            End If
            'LoadDanhSachThanhVien()
        End Sub

        Private Sub LoadThongTinGiayPhep()
            Dim objGiayCNDKKD As New GiayCNDKKDController
            gLoadControlValues(objGiayCNDKKD.GetGiayCNDKKDByID(Request.Params("ID")), Me)
            objGiayCNDKKD = Nothing

            'txtSoGiayPhep.Text = lblSoGiayPhep.Text
            If txtGiayCNDKKDID.Text = "" Then
                'trường hợp không tồn tại giấy phép
                btnTroVe_Click(Nothing, Nothing)
            End If
        End Sub

        Private Sub LoadDanhSachThanhVien()
            'Dim objGCN As New GiayCNDKKDController
            'Dim ds As DataSet
            'ds = objGCN.GetThanhVien(txtGiayCNDKKDID.Text)
            'If Not ds Is Nothing Then
            '    If ds.Tables.Count > 0 Then
            '        BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "A,Họ tên,Ngày sinh,A,Số CMND,A,A,A,Địa chỉ thường trú,A,Chức danh", "0,150,80,0,80,0,0,0,200,0,100,0,0,0,0,0,0", False, False)
            '    End If
            'End If
            'ds = Nothing
            'objGCN = Nothing
        End Sub


        Private Sub btnLichSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLichSu.Click
            Response.Redirect(EditURL("ID", txtGiayCNDKKDID.Text, "LISHSUGIAYPHEP"))
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub

        'Private Sub dgdDanhSach_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        '    dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        '    LoadDanhSachThanhVien()
        'End Sub

        Private Sub btnInBanSao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInBanSao.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileGiayCNDKKD", glbXMLFile)
            strOutputFileName = "GiayCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID.Text, True)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objGiayCNDKKD = Nothing
            ds = Nothing
        End Sub
    End Class
End Namespace
