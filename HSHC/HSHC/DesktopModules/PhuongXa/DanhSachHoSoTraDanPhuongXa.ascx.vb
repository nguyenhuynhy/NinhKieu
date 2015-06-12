Imports System.Configuration
Imports PortalQH
Namespace HSHC
    Public Class DanhSachHoSoTraDanPhuongXa
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents grdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuuPhuongXa
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtMaLinhVuc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.HtmlControls.HtmlInputHidden
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
            btnCapNhat.Attributes.Add("onClick", "javascript:return KiemTra();")
            If Not Page.IsPostBack Then
                Init_State()
                SetAttributesControl()
            End If
            LoadGrid()
        End Sub

        Sub Init_State()
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuPhuongXaInfo(Request)
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)
            'init dropdownlist
            iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            If CType(ConfigurationSettings.AppSettings("CheckUser" & CType(Session.Item("ActiveDB"), String)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            End If
            '====================================================================================================='
            If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                objThongTinTraCuuInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                tblHeader.Visible = False
            End If
            '====================================================================================================='
            'init grid
            Session("ThongTinTraCuuPhuongXaInfo") = objThongTinTraCuuInfo

            txtSoDong.Text = Str(GetSoDongHienThiLuoi())
            grdDanhSach.PageSize = CInt(txtSoDong.Text)

            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing
            objThongTinTraCuuInfo = Nothing
        End Sub


        Private Sub grdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDanhSach.PageIndexChanged
            grdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuPhuongXaInfo(Request)
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuPhuongXaController

            objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuPhuongXaInfo"), ThongTinTraCuuPhuongXaInfo)
            objThongTinTraCuuInfo.TabCode = Request.Params("TabID")
            objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE")
            ds = objThongTinTraCuuCtrl.GetInfoFromSearchPhuongXa(objThongTinTraCuuInfo)
            BindControl.BindGrdHoSo(ds, grdDanhSach, True, "Số biên nhận, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày trình ký, Ngày hẹn trả, Loại hồ sơ, Mã tình trạng, Tình trạng, Người thụ lý", "100,0,250,430,100, 0, 100,270,0,240,0", True, False)

            Dim i, item As Integer
            Dim flagcheck As Boolean

            For i = 0 To grdDanhSach.Items.Count - 1
                item = i + (grdDanhSach.PageSize * grdDanhSach.CurrentPageIndex)
                If ds.Tables(0).Rows(item).Item("Tình trạng").ToString = "DTD" Or ds.Tables(0).Rows(item).Item("Tình trạng").ToString = "DTDP" Then
                    CType(grdDanhSach.Items(i).FindControl("chkXoa"), CheckBox).Enabled = False
                Else
                    CType(grdDanhSach.Items(i).FindControl("chkXoa"), CheckBox).Enabled = True
                End If
            Next
            objThongTinTraCuuCtrl = Nothing
            objThongTinTraCuuInfo = Nothing
            ds = Nothing
            SetAttributesControl()
        End Sub



        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(grdDanhSach.PageSize)
                Exit Sub
            End If
            If grdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                grdDanhSach.PageSize = CInt(txtSoDong.Text)
                grdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub
        Private Sub SetAttributesControl()
            txtMaLinhVuc.Value = CType(Session.Item("ItemCode"), String)
            txtMaNguoiTacNghiep.Value = CType(Session.Item("UserName"), String)
            GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInRaGiay, Me, True)
            grdDanhSach.Attributes.Add("onclick", "javascript:LaySoBienNhan();")
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
                    grdDanhSach.CurrentPageIndex = 0
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            item = Nothing
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim i As Integer
            Dim err As Integer
            Dim flgCheck As Boolean
            Dim flgUpdated As Boolean
            Dim strUserName As String
            Dim objTinhTrangCtrl As New TinhTrangHoSoPhuongXaController
            Dim objTiepNhanHSCtrl As New TiepNhanHoSoPhuongXaController

            If Session.Item("UserName") Is Nothing Then
                strUserName = ""
            Else
                strUserName = Session.Item("UserName").ToString
            End If

            For i = 0 To grdDanhSach.Items.Count - 1
                flgCheck = CType(GetGridControlValue(i, grdDanhSach, "chkXoa"), Boolean)
                If flgCheck Then
                    err = objTinhTrangCtrl.UpdTinhTrangHoSo(CType(Session.Item("ItemCode"), String), Request.Params("TabID"), "", strUserName, strUserName, strUserName, grdDanhSach.Items(i).Cells(3).Text, "")
                    If err <> 0 Then
                        SetMSGBOX_HIDDEN(Page, "Cập nhật hồ sơ có số biên nhận " & grdDanhSach.Items(i).Cells(2).Text & " bị lỗi")
                        Exit Sub
                    Else
                        flgUpdated = True
                    End If
                    objTiepNhanHSCtrl.UpdTraHoSo(grdDanhSach.Items(i).Cells(3).Text)
                End If
            Next

            If flgUpdated Then
                ThongTinTraCuu1.SetValues(CType(Session("ThongTinTraCuuPhuongXaInfo"), ThongTinTraCuuPhuongXaInfo))
                LoadGrid()
            Else
                SetMSGBOX_HIDDEN(Page, "Bạn phải chọn hồ sơ để cập nhật")
            End If
            objTinhTrangCtrl = Nothing
            objTiepNhanHSCtrl = Nothing
        End Sub
        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuPhuongXaInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                ThongTinTraCuu1.BindData(objThongTinTraCuuInfo.ItemCode)
                ThongTinTraCuu1.SetValues(objThongTinTraCuuInfo)
                Session("ThongTinTraCuuPhuongXaInfo") = objThongTinTraCuuInfo
                LoadGrid()
            End If
            objThongTinTraCuuInfo = Nothing
        End Sub
        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuPhuongXaInfo(Request)

            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                ThongTinTraCuu1.BindData(objThongTinTraCuuInfo.ItemCode)
                ThongTinTraCuu1.SetValues(objThongTinTraCuuInfo)
                Session("ThongTinTraCuuPhuongXaInfo") = objThongTinTraCuuInfo
                LoadGrid()
            End If
            objThongTinTraCuuInfo = Nothing
        End Sub
    End Class
End Namespace