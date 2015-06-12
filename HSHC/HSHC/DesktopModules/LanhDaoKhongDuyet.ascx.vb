Imports PortalQH
Namespace HSHC
    Public Class LanhDaoKhongDuyet
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungXuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaTinhTrangXuLy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoSoKhongGiaiQuyetID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLyDo As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNguoiNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMaNguoiChuyen As System.Web.UI.WebControls.TextBox

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
            lblTieuDe.Text = "Chuyển trả bộ phận thụ lý"
            'txtNgayXuLy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayXuLy);")
            'imgNgayXuLy.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayXuLy, 'dd/mm/yyyy');")
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaNguoiNhan, "sp_GetNguoiSuDung", False, "", Request.Params("tabid"), Session.Item("ItemCode").ToString(), Session.Item("UserName"), "n")
                BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")
                'BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangXuLy, False, "", "sp_getTinhTrangHoSoByLoai", CType(Session.Item("ItemCode"), String), Request.Params("tabid"), "LDK")
                'If ddlMaTinhTrangXuLy.Items.Count > 0 Then ddlMaTinhTrangXuLy.SelectedIndex = 0
                txtSoBienNhan.Text = Request.Params("ID").ToString
                txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
                txtTabCode.Text = CType(TabId, String)
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
                txtMaNguoiChuyen.Text = Request.Params("NguoiChuyen").ToString
                ddlMaNguoiNhan.SelectedValue = Request.Params("NguoiNhan").ToString
                'txtMaNguoiNhan.Text = Request.Params("NguoiNhan").ToString
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
            End If

        End Sub
        Private Sub LoadData()
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Dim ds As DataSet
            ds = objHoSoKhong.GetLanhDaoKhongGiaiQuyet(Me)
            gLoadControlValues(ds, Me)
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objLanhDaoKhong As New HoSoKhongGiaiQuyetController
            objLanhDaoKhong.AddLanhDaoKhongDuyet(Me)
        End Sub
    End Class
End Namespace