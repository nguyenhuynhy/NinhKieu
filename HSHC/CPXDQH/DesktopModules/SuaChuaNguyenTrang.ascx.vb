Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports PortalQH
Namespace CPXD
    Public Class SuaChuaNguyenTrang
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoten As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayXacNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungXuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLanhDaoKy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdCalendar As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnSoBN As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoNguyenTrangID As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlTenLoaiHoSo As System.Web.UI.WebControls.DropDownList

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
                SetAttributesControls()
                Init_State()
                SetAttributesNgay()
                BindControls()
                BindData()
            End If
            Dim blnStatus As Boolean
            If Request.Params("AddNew") = "" Then
                blnStatus = True
            Else
                blnStatus = CBool(Request.Params("AddNew"))
            End If
            SetStatusControl(blnStatus)
            Dim strReportPath As String = GetParamByID("ReportPath", glbXMLFile)
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", strReportPath, btnIn, Me)

        End Sub
        Private Sub SetAttributesNgay()
            txtNgayXacNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayXacNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayXacNhan.ClientID & ");")
            cmdCalendar.NavigateUrl = AdminDB.InvokePopupCal(txtNgayXacNhan)
        End Sub
        Private Sub SetAttributesControls()
            txtNoiDungXuLy.Attributes.Add("ISNULL", "ISNOTNULL")
            txtHoten.Attributes.Add("ISNULL", "ISNOTNULL")
            ddlLanhDaoKy.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayXacNhan.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?')")
            GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", ctype(Session.Item("ActiveDB"),string), btnIn, Me)
        End Sub
        Private Sub BindData()
            If Not Request.Params("ID") Is Nothing Then
                Dim objSuaChuaNguyenTrang As New SuaChuaNguyenTrangController
                gLoadControlValues(objSuaChuaNguyenTrang.GetSuaChuaNguyenTrang(Request.Params("ID")), Me)
                objSuaChuaNguyenTrang = Nothing
            End If
        End Sub
        Private Sub BindControls()
            BindControl.BindDropDownList(ddlDuong, "DMDuong")
            BindControl.BindDropDownList(ddlPhuong, "DMPhuong")
            BindControl.BindDropDownList(ddlTenLoaiHoSo, "DMLOAIHOSO")
            BindDropDownList_NguoiKy(ddlLanhDaoKy)
        End Sub
        Private Sub SetStatusControl(ByVal IsAddNew As Boolean)
            btnSoBN.Visible = IsAddNew
            lblSoBN.Visible = Not IsAddNew
            btnXoa.Visible = Not IsAddNew
            btnIn.Visible = Not IsAddNew
        End Sub
        Private Sub Init_State()

            txtTabCode.Text = Request.Params("TabID")
            txtHoSoTiepNhanID.Text = Request.Params("ID")
            txtMaNguoiTacNghiep.Text = CStr(Session.Item("UserName"))
            txtNgayXacNhan.Text = NgayHienTai()
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            If txtNgayXacNhan.Text = "" Then
                txtNgayXacNhan.Text = NgayHienTai()
            End If

        End Sub

        Private Sub btnSoBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoBN.Click
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl")), True)
        End Sub

      
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                Dim objSuachuanguyentrangcontroller As New SuaChuaNguyenTrangController
                If objSuachuanguyentrangcontroller.AddSuaChuaNguyenTrang(Me) <> "0" Then
                    SetMSGBOX_HIDDEN(Page, "Cập nhật không thành công")
                    Exit Sub
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objSuaChuaNguyenTrangController As New SuaChuaNguyenTrangController
            Try
                objSuaChuaNguyenTrangController.DelSuaChuaNguyenTrang(Me)
                SetMSGBOX_HIDDEN(Page, "Đã xoá")
                Response.Redirect(NavigateURL(), True)
                objSuaChuaNguyenTrangController = Nothing
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL(""))
        End Sub
    End Class
End Namespace

