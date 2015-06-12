Imports System.Configuration
Imports PortalQH
Namespace HSHC
    Public Class ThongBaoBSHS
        Inherits PortalQH.PortalModuleControl
        Private mNgayNghiLe As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayYeuCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInThu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoaiHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNgayBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoBoSungID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungYeuCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayYeuCau As System.Web.UI.WebControls.HyperLink

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
            If Not Request.Params("TabID") Is Nothing Then
                txtTabCode.Text = Request.Params("TabID")
            End If
            Try
                SetAttribute()

                txtNgayYeuCau.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtNgayYeuCau.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayYeuCau.ClientID & ");")
                cmdNgayYeuCau.NavigateUrl = AdminDB.InvokePopupCal(txtNgayYeuCau)

                btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
                Me.txtNgayNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayYeuCau.ClientID & "," & txtSoNgayBoSung.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayNop.ClientID & ");")
                Me.txtSoNgayBoSung.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayYeuCau.ClientID & "," & txtSoNgayBoSung.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayNop.ClientID & ");")
                btnCapNhat.Attributes.Add("onfocus", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayYeuCau.ClientID & "," & txtSoNgayBoSung.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayNop.ClientID & ");")
                If Not Page.IsPostBack Then
                    lblTieuDe.Text = "Thông báo bổ sung hồ sơ "
                    mNgayNghiLe = ConfigurationSettings.AppSettings("NgayNghiLe")
                    txtMaNguoiNhan.Text = CType(Session.Item("UserName"), String)
                    If Not Request.Params("ID") Is Nothing Then
                        txtHoSoTiepNhanID.Text = Request.Params("ID")
                    End If
                    If Not Request.Params("Malv") Is Nothing Then
                        txtMaLinhVuc.Text = Request.Params("Malv")
                    End If
                    'load các thông tin về ho so
                    BindData()
                End If
                GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInThu, Me)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

       
        Sub BindData()
            Dim HoSoCon As New HoSoBoSungController
            Dim ds As DataSet
            ds = HoSoCon.GetHoSoBoSung(txtHoSoTiepNhanID.Text)
            gLoadControlValues(ds, Me)
            GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInThu, Me)
            ds = Nothing
        End Sub
        
        Sub SetAttribute()
            txtNgayYeuCau.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayNop.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDungYeuCau.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNgayBoSung.Attributes.Add("ISNULL", "NOTNULL")
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim HoSoCon As New HoSoBoSungController : Dim err As Integer
            Dim TinhTrangCon As New TinhTrangHoSoController
            txtHoSoBoSungID.Text = HoSoCon.UpdHoSoBoSung(Me)
            BindData()
        End Sub

        Private Sub btnInThu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInThu.Click

        End Sub
    End Class
End Namespace