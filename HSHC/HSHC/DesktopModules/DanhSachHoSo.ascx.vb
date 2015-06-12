Imports System.Configuration
Imports PortalQH
Namespace HSHC
    Public Class DanhSachHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuu
        Dim objThongTinTraCuuInfo As ThongTinTraCuuInfo
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTinhThanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongTy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVanPhong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPathReport As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtProcName As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtMaLinhVuc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtURL As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label

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
            objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
            If Not Page.IsPostBack Then
                Init_State()
                SetAttributesControl()
            End If
            LoadGrid()
            GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "2", "HSHC", btnInRaGiay, Me, True)
        End Sub

        Private Sub SetAttributesControl()
            txtMaLinhVuc.Value = CType(Session.Item("ItemCode"), String)
            txtMaNguoiTacNghiep.Value = CType(Session.Item("UserName"), String)
        End Sub

        Sub Init_State()
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim iSelectedId As String

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

            iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            If CType(ConfigurationSettings.AppSettings("CheckUser" & CType(Session.Item("ActiveDB"), String)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If
            If ddlLinhVuc.SelectedIndex > -1 Then
                If Not Session.Item("ItemCode") Is Nothing Then
                    DdLSelected(ddlLinhVuc, CType(Session.Item("ItemCode"), String))
                Else
                    Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                End If
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            End If
            '====================================================================================================='
            If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                objThongTinTraCuuInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                tblHeader.Visible = False
            End If
            '====================================================================================================='
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            'init grid
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo

            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)

            'set các thông tin dùng cho việc in danh sách
            txtTabCode.Text = Request.Params("TabID")

        End Sub

      
        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
            Dim ds As DataSet

            objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)

            objThongTinTraCuuInfo.TabCode = Request.Params("TabID")
            objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            Dim strLoaiHoSo As String = GetParamByID("tabHUYHOSOBOSUNG", glbXMLFile)
            If InStr("," & strLoaiHoSo & ",", "," & Request.Params("TabID") & ",") > 0 Then
                objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE", "HUYHOSOBOSUNG")
                txtURL.Value = "HUYHOSOBOSUNG"
            Else
                objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE", )
            End If

            ds = objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuInfo)

            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày trình ký, Ngày hẹn trả, Loại hồ sơ,Mã tình trạng, Tình trạng, Người thụ lý", "100,0,300,400,100, 0, 100,200,0,200,0", False, True)


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
        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Dim ds As DataSet
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
                'bind lại dữ liệu tương ứng với ItemCode
                ThongTinTraCuu1.BindData(objThongTinTraCuuInfo.ItemCode)
                objThongTinTraCuuInfo = ThongTinTraCuu1.GetValues()
                Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
                LoadGrid()
                GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "2", "HSHC", btnInRaGiay, Me)
            End If
        End Sub


        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim ds As DataSet
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
                'bind lại dữ liệu tương ứng với ItemCode
                ThongTinTraCuu1.BindData(objThongTinTraCuuInfo.ItemCode)
                objThongTinTraCuuInfo = ThongTinTraCuu1.GetValues()
                Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
                LoadGrid()
                GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "2", "HSHC", btnInRaGiay, Me)
            End If
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Dim item As New ListItem
            Try
                If Not ThongTinTraCuu1 Is Nothing Then
                    If ddlLinhVuc.SelectedValue <> CType(Session.Item("ItemCode"), String) Then
                        item.Value = CType(Session.Item("ItemCode"), String)
                        item.Text = ddlLinhVuc.Items.FindByValue(CType(Session.Item("ItemCode"), String)).Text
                        ddlLinhVuc.SelectedIndex = ddlLinhVuc.Items.IndexOf(item)
                    End If
                    Session("ThongTinTraCuuInfo") = ThongTinTraCuu1.GetValues()
                    dgdDanhSach.CurrentPageIndex = 0
                    LoadGrid()
                End If
                GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "2", "HSHC", btnInRaGiay, Me)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            item = Nothing
        End Sub
    End Class
End Namespace