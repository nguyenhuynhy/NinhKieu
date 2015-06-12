Imports PortalQH

Namespace CPKTQH
    Public Class QuanLyDonViTrucThuoc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtDonViTrucThuocID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents cMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenDoanhNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiDungDau As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaLinhVucCapPhep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenLoaiDoanhNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents tblThongTinQuanLy As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkHoatDong As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable

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
            txtSoGiayPhep.Text = Request.QueryString("ID")
            If Not Page.IsPostBack Then
                InitState()
                AddJavaScript()
                'ThuyTT add: trong trường hợp đã có lĩnh vực cấp phép, chỉ hiển thị những ngành kinh doanh thuộc lĩnh vực cấp phép này
                'If ddlMaLinhVucCapPhep.SelectedValue <> "" Then
                '    Page.RegisterStartupScript("LINHVUCCAPPHEP", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganhKinhDoanh))
                'End If
                'ThuyTT end
            End If

        End Sub

        Sub InitState()
            Dim dsLinhVucCapPhep As DataSet
            Dim dsNganh As DataSet
            Dim objNganh As New NganhKinhDoanhController

            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlMaLoaiHinhDoanhNghiep, "DMLOAICHINHANH")

            dsLinhVucCapPhep = objNganh.getLinhVucCapPhep()
            dsNganh = objNganh.getNganhKinhDoanhChinh()

            ddlMaLinhVucCapPhep.DataSource = dsLinhVucCapPhep
            ddlMaLinhVucCapPhep.DataTextField = "TenLinhVuc"
            ddlMaLinhVucCapPhep.DataValueField = "MaLinhVuc"
            ddlMaLinhVucCapPhep.DataBind()
            ddlMaLinhVucCapPhep.Items.Insert(0, "")

            ddlMaNganhKinhDoanh.DataSource = dsNganh
            ddlMaNganhKinhDoanh.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanh.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanh.DataBind()
            ddlMaNganhKinhDoanh.Items.Insert(0, "")
            With ctrlScriptComboFilter
                .ConditionID = ddlMaLinhVucCapPhep.ClientID
                .ConditionText = "TenLinhVuc"
                .ConditionValue = "MaLinhVuc"

                .ResultID = ddlMaNganhKinhDoanh.ClientID
                .ResultText = "TenNganh"
                .ResultValue = "MaNganh"
                .ConditionDS = dsLinhVucCapPhep
                .ResultDS = dsNganh
            End With
            objNganh = Nothing
            dsLinhVucCapPhep = Nothing
            dsNganh = Nothing

            GetDonViTrucThuoc()
        End Sub
        Private Sub AddJavaScript()
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLoaiHinhDoanhNghiep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLinhVucCapPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganhKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            ddlMaLinhVucCapPhep.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
        End Sub
        Private Sub GetDonViTrucThuoc()
            If Request.QueryString("ID") <> "" Then
                Dim objCapCNDKKD As New GiayCNDKKDController
                Dim ds As New DataSet
                ds = objCapCNDKKD.GetDonViTrucThuocBySoGiayPhep(Request.QueryString("ID"))
                If ds.Tables(0).Rows.Count > 0 Then
                    gLoadControlValues(ds, Me)
                    tblThongTinQuanLy.Visible = True
                    If txtHoSoTiepNhanID.Text <> "" Then
                        tblThongTinQuanLy.Visible = False
                    End If
                End If
                txtTabCode.Text = Request.QueryString("TabID")
                txtMaLinhVuc.Text = Request.QueryString("Malv")
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            End If
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objCapCNDKKD As New GiayCNDKKDController
            txtDonViTrucThuocID.Text = objCapCNDKKD.AddDonViTrucThuoc(Me)
            If txtDonViTrucThuocID.Text = "" Then
                hMsg.Value = "Cap nhat khong thanh cong"
                Exit Sub
            End If
            Response.Redirect(Request.RawUrl)
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL)
        End Sub
    End Class
End Namespace
