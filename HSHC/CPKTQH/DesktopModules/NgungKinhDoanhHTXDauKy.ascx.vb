Imports PortalQH
Namespace CPKTQH
    Public Class NgungKinhDoanhHTXDauKy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHetHan As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenHinhThucKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblVonKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLinhVucCapPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgaySinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayBatDau As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayNgungKD As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayKetThuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayKetThuc As System.Web.UI.WebControls.Image
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTrove As System.Web.UI.WebControls.LinkButton
        Protected WithEvents imgNgayHoatDongLai As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblChuoiGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayHoatDongLai As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDiaChiThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents txtGiayCNDKKDHTXID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgungKinhDoanhHTXID As System.Web.UI.WebControls.TextBox

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
                SetAttributesControl()
                BindData()
                Init_State()
                If txtNgungKinhDoanhHTXID.Text = "" Then
                    btnXoa.Visible = False
                End If
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtNgayBatDau.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayBatDau);")
            imgNgayNgungKD.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayBatDau, 'dd/mm/yyyy');")
            Me.txtNgayBatDau.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayBatDau.ClientID & ");")
            Me.txtNgayBatDau.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayKetThuc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayKetThuc);")
            imgNgayKetThuc.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayKetThuc, 'dd/mm/yyyy');")
            Me.txtNgayKetThuc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayKetThuc.ClientID & ");")
            Me.txtNgayKetThuc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayHoatDongLai.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHoatDongLai.ClientID & ");")
            imgNgayHoatDongLai.Attributes.Add("onclick", "javascript:popUpCalendar(this," & txtNgayHoatDongLai.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayHoatDongLai.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayHoatDongLai.ClientID & ");")
            Me.txtNgayHoatDongLai.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayBatDau.Text = Format(Now(), "dd/MM/yyyy")

            ddlMaLyDo.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayBatDau.Attributes.Add("ISNULL", "NOTNULL")

            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
            btnCapNhat.Attributes.Add("onclick", "javascript:return btnCapNhat_clicked();")
        End Sub

        Private Sub BindData()
            BindControl.BindDropDownList(ddlMaLyDo, "DMLYDO")
        End Sub

        Private Sub Init_State()
            'load thong tin giay chung nhan hợp tác xã
            Dim objGCNHTX As New HopTacXaController
            Dim ds As DataSet
            ds = objGCNHTX.getGiayCNDKKDHTX(Request.Params("ID"))
            gLoadControlValues(ds, Me)
            objGCNHTX = Nothing

            If txtGiayCNDKKDHTXID.Text = "" Then
                btnTrove_Click(Nothing, Nothing)
            End If

            'lấy ID ngưng kinh doanh nếu có
            Dim objNgungKD As New NgungKinhDoanhController
            txtNgungKinhDoanhHTXID.Text = objNgungKD.getNgungKinhDoanhHTXID(txtGiayCNDKKDHTXID.Text, Nothing)

            'trường hợp đã có thông tin ngưng kinh doanh thì load thông tin lên
            txtGhiChu.Text = ""
            If txtNgungKinhDoanhHTXID.Text <> "" Then
                ds = objNgungKD.getNgungKinhDoanhHTX(txtNgungKinhDoanhHTXID.Text)
                gLoadControlValues(ds, Me)
            End If

            objNgungKD = Nothing
            ds = Nothing
        End Sub

        Private Sub btnTrove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrove.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objNgung As New NgungKinhDoanhController
            If Not objNgung.updNgungKinhDoanhHTX(Me) Then
                SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                Exit Sub
            End If
            objNgung = Nothing
            Response.Redirect(Request.RawUrl())
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objNgung As New NgungKinhDoanhController
            If Not objNgung.delNgungKinhDoanhHTXByID(txtNgungKinhDoanhHTXID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Xoa khong thanh cong!")
                Exit Sub
            End If
            objNgung = Nothing
            btnTrove_Click(Nothing, Nothing)
        End Sub
    End Class
End Namespace
