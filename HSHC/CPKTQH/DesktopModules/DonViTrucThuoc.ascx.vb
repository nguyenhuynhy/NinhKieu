'Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports PortalQH
Namespace CPKTQH
    Public Class DonViTrucThuoc
        Inherits PortalQH.PortalModuleControl
        Private pID As String = ""
        Private strControl As String
        Dim iTotal As New Integer


        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGIAYCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDIDCapTren As System.Web.UI.WebControls.TextBox
        Protected WithEvents cMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNganhKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCap As System.Web.UI.WebControls.Image
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTenDoanhNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLoaiHinhDoanhNghiep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNguoiDungDau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDonViTrucThuocID As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaLinhVucCapPhep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox

        Private Const strURL As String = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Private Shared dv As DataView
        Protected WithEvents txtNoiCap As System.Web.UI.WebControls.TextBox

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
            txtHoSoTiepNhanID.Text = Request.QueryString("ID")
            If Not Page.IsPostBack Then
                InitState()
                GetDonViTrucThuoc()
                AddJavaScript()
                'ThuyTT add: trong trường hợp đã có lĩnh vực cấp phép, chỉ hiển thị những ngành kinh doanh thuộc lĩnh vực cấp phép này
                If ddlMaLinhVucCapPhep.SelectedValue <> "" Then
                    Page.RegisterStartupScript("LINHVUCCAPPHEP", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganhKinhDoanh))
                End If
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
        End Sub
        Private Sub GetDonViTrucThuoc()
            If Request.QueryString("ID") <> "" Then
                Dim objCapCNDKKD As New GiayCNDKKDController
                Dim ds As New DataSet
                ds = objCapCNDKKD.GetDonViTrucThuoc(Request.QueryString("ID"))
                If ds.Tables(0).Rows.Count > 0 Then
                    gLoadControlValues(ds, Me)

                End If
                If txtDonViTrucThuocID.Text <> "" Then
                    btnXoa.Visible = True
                End If
                txtTabCode.Text = Request.QueryString("TabID")
                txtMaLinhVuc.Text = Request.QueryString("Malv")
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            End If
        End Sub

        Private Sub AddJavaScript()
            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            txtVonKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            txtTenDoanhNghiep.Attributes.Add("ISNULL", "NOTNULL")
            txtNguoiDungDau.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLinhVucCapPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganhKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtMatHangKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")

            'txtSoCMND.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMND.ClientID & ");")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa ?');")

            txtVonKinhDoanh.Attributes.Add("onblur", "javascript:CheckData(" & txtVonKinhDoanh.ClientID & ");")
            txtVonKinhDoanh.Attributes.Add("OnKeyPress", "javascript:ValidateNumeric();")

            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCap.ClientID & ");")
            imgNgayCap.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtNgayCap.ClientID & ", 'dd/mm/yyyy');")
            Me.txtNgayCap.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCap.ClientID & ");")
            Me.txtNgayCap.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            ddlMaLinhVucCapPhep.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            ddlMaNganhKinhDoanh.Attributes.Add("onblur", "javascript:getNganhKinhDoanh(" & ddlMaNganhKinhDoanh.ClientID & "," & txtMatHangKinhDoanh.ClientID & ");")
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objCapCNDKKD As New GiayCNDKKDController
            Dim str As String
            str = objCapCNDKKD.AddDonViTrucThuoc(Me)
            Select Case str
                Case ""
                    SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                Case "2"
                    SetMSGBOX_HIDDEN(Page, "So giay phep nay da ton tai trong he thong!")
                Case Else
                    Response.Redirect(Request.RawUrl)
            End Select
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objCapCNDKKD As New GiayCNDKKDController
            If txtSoGiayPhep.Text <> "" Then
                If Not objCapCNDKKD.DelDonViTrucThuoc(txtDonViTrucThuocID.Text, txtMaLinhVuc.Text, txtTabCode.Text, txtHoSoTiepNhanID.Text, txtMaNguoiTacNghiep.Text) Then
                    SetMSGBOX_HIDDEN(Page, "Xoa khong thanh cong!")
                    Exit Sub
                End If
                Response.Redirect(Request.RawUrl)
            End If
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
    End Class

End Namespace
