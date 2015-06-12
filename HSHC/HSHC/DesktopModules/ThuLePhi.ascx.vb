Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ThuLePhi
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoTienNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoTienDangBo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox

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
            lblTieuDe.Text = "Thu Lệ Phí"
            If Not Me.IsPostBack Then
                txtHoSoTiepNhanID.Text = Request.Params("ID").ToString
                If txtHoSoTiepNhanID.Text <> "" Then
                    LoadData()
                End If
                AddJavaScript()
            End If
        End Sub
        Private Sub LoadData()
            Dim objTinhTrangHoSo As New TinhTrangHoSoController
            Dim rs As DataSet
            rs = objTinhTrangHoSo.GetChuyenXuLyThuLePhi(txtHoSoTiepNhanID.Text)
            If (rs.Tables(0).Rows.Count > 0) Then
                gLoadControlValues(rs, Me)
            End If
        End Sub
        Sub AddJavaScript()
            txtSoTienNop.Attributes.Add("onblur", "javascript:ConvertNumericVN(" & _
                                                                txtSoTienNop.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")

            txtSoTienDangBo.Attributes.Add("onfocus", "javascript:ConvertNumericVN(" & _
                                                                txtSoTienDangBo.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")

            txtSoTienDangBo.Attributes.Add("onblur", "javascript:ConvertNumericVN(" & _
                                                                txtSoTienDangBo.ClientID & _
                                                                "," & getDonViTinh() & _
                                                                "," & getSoKiSoThapPhan() & _
                                                                "," & getTienVonMin() & _
                                                                "," & getTienVonMax() & ");")

            txtSoTienNop.Attributes.Add("onchange", "javascript:getEval(" & _
                                                                            txtSoTienNop.ClientID & _
                                                                            "," & txtSoTienDangBo.ClientID & ");")

            txtSoTienNop.Attributes.Add("ISNULL", "NOTNULL")
            txtSoTienDangBo.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
        End Sub

        Public Function getDonViTinh() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "DonViTinh")
            If strResult = "" Then strResult = "0"
            Return strResult
        End Function
        Public Function getTienVonMin() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "TienVonMin")
            If strResult = "" Then strResult = "null"
            Return strResult
        End Function
        Public Function getTienVonMax() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "TienVonMax")
            If strResult = "" Then strResult = "null"
            Return strResult
        End Function
        Public Function getSoKiSoThapPhan() As String
            Dim strResult As String
            strResult = ParamController.GetParamValue("", "SoKiSoThapPhan")
            If strResult = "" Then strResult = "null"
            Return strResult
        End Function

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            'Dim m_ReturnURL As String = CStr(DataCache.GetCache("ThuLePhi"))
            'DataCache.RemoveCache("ThuLePhi")
            'Response.Redirect(m_ReturnURL, True)
            Try

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim objTinhTrangHoSo As New TinhTrangHoSoController
            objTinhTrangHoSo.UpdChuyenXuLyThuLePhi(Me)
        End Sub
    End Class
End Namespace
