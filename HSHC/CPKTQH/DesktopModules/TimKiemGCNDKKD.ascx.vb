Imports PortalQH
Imports System.Configuration


Namespace CPKTQH
    Public Class TimKiemGCNDKKD
        Inherits PortalQH.PortalModuleControl

        Dim objTimKiemCNDKKD As TimKiemGiayCNDKKDInfo


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLinhVucCapPhep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMatHang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents ddlTinhTrangHienTai As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox


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
                GetValues()
                LoadGrid()
                GetReportURL(Request.Params("TabID"), GetLinhVuc, "1", GetReportPath(GetLinhVuc()), btnIn, Me)
            End If
            Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlNganhKinhDoanh))
        End Sub


        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            Me.txtTuNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtTuNgay.ClientID & ");")
            Me.txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Me.txtDenNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtDenNgay.ClientID & ");")
            Me.txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtSoDong.Attributes.Add("onkeypress", "javascript:return ValidateNumeric();")

            'ddlLinhVucCapPhep.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            ddlMaPhuongThucKinhDoanh.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
        End Sub


        Private Sub BindData()
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindControl.BindDropDownList(ddlTinhTrangHienTai, "DMTINHTRANGGIAYPHEP", "A")

            Dim dsLinhVuc As New DataSet
            Dim dsNganh As New DataSet
            Dim dsPhuongThuc As New DataSet
            Dim objNganhKD As New NganhKinhDoanhController
            dsLinhVuc = objNganhKD.getLinhVucCapPhep()
            'dsNganh = objNganhKD.getNganhKinhDoanhChinh
            dsNganh = objNganhKD.getPhuongThucNganhNghe()
            dsPhuongThuc = objNganhKD.getPhuongThucKinhDoanh()
            objNganhKD = Nothing

            'PhuocDD, modified Jul 07th 2006
            'Su dung phuong thuc kinh doanh de tim kiem
            'ddlLinhVucCapPhep.DataSource = dsLinhVuc
            'ddlLinhVucCapPhep.DataTextField = "TenLinhVuc"
            'ddlLinhVucCapPhep.DataValueField = "MaLinhVuc"
            'ddlLinhVucCapPhep.DataBind()
            'ddlLinhVucCapPhep.Items.Insert(0, "")
            ddlMaPhuongThucKinhDoanh.DataSource = dsPhuongThuc
            ddlMaPhuongThucKinhDoanh.DataTextField = "TenLinhVuc"
            ddlMaPhuongThucKinhDoanh.DataValueField = "MaLinhVuc"
            ddlMaPhuongThucKinhDoanh.DataBind()
            ddlMaPhuongThucKinhDoanh.Items.Insert(0, "")

            ddlNganhKinhDoanh.DataSource = dsNganh
            ddlNganhKinhDoanh.DataTextField = "TenNganh"
            ddlNganhKinhDoanh.DataValueField = "MaNganh"
            ddlNganhKinhDoanh.DataBind()
            ddlNganhKinhDoanh.Items.Insert(0, "")
            With ctrlScriptComboFilter
                '.ConditionID = ddlLinhVucCapPhep.ClientID
                .ConditionID = ddlMaPhuongThucKinhDoanh.ClientID
                .ConditionText = "TenLinhVuc"
                .ConditionValue = "MaLinhVuc"

                .ResultID = ddlNganhKinhDoanh.ClientID
                .ResultText = "TenNganh"
                .ResultValue = "MaNganh"
                .ConditionDS = dsLinhVuc
                .ResultDS = dsNganh
            End With

            Dim mSoNgay As Integer
            mSoNgay = getSoNgayLoc(Request)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
        End Sub

        Private Sub GetValues()
            If Not Session("TimKiemGiayCNDKKD") Is Nothing Then
                objTimKiemCNDKKD = CType(Session("TimKiemGiayCNDKKD"), TimKiemGiayCNDKKDInfo)
            End If

            If objTimKiemCNDKKD Is Nothing Then objTimKiemCNDKKD = New TimKiemGiayCNDKKDInfo

            With objTimKiemCNDKKD
                .TinhTrangHienTai = ddlTinhTrangHienTai.SelectedValue
                .SoGiayPhep = Trim(txtSoGiayPhep.Text)
                .TuNgay = txtTuNgay.Text
                .DenNgay = txtDenNgay.Text
                .HoTen = Trim(txtHoTen.Text)
                .SoNha = Trim(txtSoNha.Text)
                .MaDuong = ddlDuong.SelectedValue
                .MaPhuong = ddlPhuong.SelectedValue
                .MatHang = Trim(txtMatHang.Text)
                .LinhVucCapPhep = ddlLinhVucCapPhep.SelectedValue
                .MaNganh = ddlNganhKinhDoanh.SelectedValue
                .BangHieu = Trim(txtBangHieu.Text)
                .URL = EditURL("ID", "VALUE")
                .PhuongThucKinhDoanh = ddlMaPhuongThucKinhDoanh.SelectedValue
                .SoCMND = Trim(txtSoCMND.Text)
            End With

            Session("TimKiemGiayCNDKKD") = objTimKiemCNDKKD
        End Sub

        Private Sub LoadGrid()
            Dim ds As New DataSet
            Dim obj As New TimKiemGiayCNDKKDController

            lblTongSoHoSo.Text = "0"

            If Session("TimKiemGiayCNDKKD") Is Nothing Then
                GetValues()
            End If
            objTimKiemCNDKKD = CType(Session("TimKiemGiayCNDKKD"), TimKiemGiayCNDKKDInfo)
            ds = obj.getDanhSachGCNDKKD(objTimKiemCNDKKD)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                    dgdDanhSach.DataSource = ds
                    dgdDanhSach.DataBind()

                    lblTongSoHoSo.Text = CStr(ds.Tables(0).Rows.Count)
                End If
            End If
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "So dong hien thi khong hop le")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            GetValues()
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub
    End Class
End Namespace

