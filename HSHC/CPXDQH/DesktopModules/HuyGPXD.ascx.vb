Imports PortalQH
Namespace CPXD
    Public Class HuyGPXD
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDanhSachGP As System.Web.UI.WebControls.Label
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
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox




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
                SetStatusControl(CBool(Request.Params("AddNew")))
                Init_State()
                txtReload.Text = "0"
            End If

            If Trim(txtSoGiayPhep.Text) <> "" And txtReload.Text = "1" Then
                BindData()
                txtReload.Text = "0"
            End If
            If txtNgayDuyet.Text = "" Then txtNgayDuyet.Text = NgayHienTai()
            If txtNgayHuy.Text = "" Then txtNgayHuy.Text = NgayHienTai()
            If ddlNguoiHuy.SelectedValue = "" Then ddlNguoiHuy.SelectedValue = Session.Item("UserName").ToString
            btnCapNhat.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn cập nhật không ?');")

            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", strReportPath, btnIn, Me)
        End Sub

        Private Sub SetAttributesControl()
            txtNgayDuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayDuyet);")
            imgNgayDuyet.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayDuyet, 'dd/mm/yyyy');")

            txtNgayHuy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayHuy);")
            imgNgayHuy.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayHuy, 'dd/mm/yyyy');")

            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlLyDoHuy.Attributes.Add("ISNULL", "NOTNULL")
            ddlNguoiDuyet.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayDuyet.Attributes.Add("ISNULL", "NOTNULL")
            ddlNguoiHuy.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayHuy.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            'GetReportURL(Request.Params("TabID"), GetLinhVuc, "1", gActiveDB, btnIn, Me)

            Dim strURL As String
            strURL = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx?IsHuy=1"
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
        End Sub

        Private Sub SetStatusControl(ByVal IsAddNew As Boolean)
            btnDanhSachGP.Visible = IsAddNew
            lblDanhSachGP.Visible = Not IsAddNew
            'btnXoa.Visible = Not IsAddNew
            btnXoa.Visible = False
            btnIn.Visible = Not IsAddNew
        End Sub

        Private Sub Init_State()
            txtTabCode.Text = Request.Params("TabID")
            txtLinhVuc.Text = GetLinhVuc()
            txtNguoiTacNghiep.Text = CStr(Session.Item("UserName"))
            txtNgayDuyet.Text = Format(Now(), "dd/MM/yyyy")
            txtNgayHuy.Text = Format(Now(), "dd/MM/yyyy")
            BindControl.BindDropDownList(ddlLyDoHuy, "DMLYDO")
            BindDropDownList_NguoiKy(ddlNguoiDuyet)
            'mặc định người hủy là người đăng nhập
            BindControl.BindDropDownList(ddlNguoiHuy, "DMNGUOISUDUNG", CStr(Session.Item("UserName")))

            If Not Request.Params("ID") Is Nothing Then
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                BindData()
                SetStatusControl(False)
            End If
        End Sub

        Private Sub BindData()
            Dim objHuyGPXD As New HuyGPXDController
            gLoadControlValues(objHuyGPXD.getHuyGPXD(txtSoGiayPhep.Text, txtHoSoTiepNhanID.Text), Me)
            objHuyGPXD = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objHuyGPXD As New HuyGPXDController
            If objHuyGPXD.updHuyGPXD(Me) = "1" Then
                SetMSGBOX_HIDDEN(Page, "Cập nhật không thành công!")
                Exit Sub
            Else
                SetStatusControl(False)
            End If
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnXoa.Click
            Dim objHuyGPXD As New HuyGPXDController
            Select Case objHuyGPXD.delHuyGPXD(Me)
                Case "2" : Exit Sub
                Case "1"
                    SetMSGBOX_HIDDEN(Page, "Xóa không thành công!")
                Case "0"
                    Response.Redirect(NavigateURL(""))
            End Select
            objHuyGPXD = Nothing
        End Sub
    End Class
End Namespace