Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class DanhSachHoSo_Chon
        Inherits PortalQH.PortalModuleControl


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ThongTinTraCuuKD1 As ThongTinTraCuuKD

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
            If Not Page.IsPostBack Then
                Init_State()
            End If
            LoadGrid()
        End Sub
        Sub Init_State()
            Dim objThongTinTraCuuKDInfo As New ThongTinTraCuuKDInfo(Request)
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
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
            End If
            '====================================================================================================='
            If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                objThongTinTraCuuKDInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                tblHeader.Visible = False
            End If
            '====================================================================================================='
            Session("ThongTinTraCuuKDInfo") = objThongTinTraCuuKDInfo

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            'release object
            objThongTinTraCuuKDInfo = Nothing
            objMenuListInfo = Nothing
            objMenuList = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim strLoaiHoSo, strURL As String
            strLoaiHoSo = GetParamByID("tab" & TabId, glbXMLFile)
            strURL = EditURL("ID", "VALUE", strLoaiHoSo) & "&AddNew=True"

            Dim objThongTinTraCuuKDInfo As New ThongTinTraCuuKDInfo(Request)
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuKDController
            Dim ds As DataSet

            objThongTinTraCuuKDInfo = CType(Session("ThongTinTraCuuKDInfo"), ThongTinTraCuuKDInfo)
            objThongTinTraCuuKDInfo.URL = strURL
            ThongTinTraCuuKD1.GetValues()
            objThongTinTraCuuKDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD0(objThongTinTraCuuKDInfo)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả, Loại hồ sơ, Mã tình trạng, Tình trạng, Người thụ lý", "0, 0,300, 500, 100, 100, 300,0,200,0")
            objThongTinTraCuuCtrl = Nothing
            objThongTinTraCuuKDInfo = Nothing
        End Sub



        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
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
            Dim item As New ListItem
            Try
                If Not ThongTinTraCuuKD1 Is Nothing Then
                    If ddlLinhVuc.SelectedValue <> CType(Session.Item("ItemCode"), String) Then
                        item.Value = CType(Session.Item("ItemCode"), String)
                        item.Text = ddlLinhVuc.Items.FindByValue(CType(Session.Item("ItemCode"), String)).Text
                        ddlLinhVuc.SelectedIndex = ddlLinhVuc.Items.IndexOf(item)
                    End If
                    Session("ThongTinTraCuuKDInfo") = ThongTinTraCuuKD1.GetValues()
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            item = Nothing
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuuKDInfo As New ThongTinTraCuuKDInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuKDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                'bind lại dữ liệu tương ứng với ItemCode
                ThongTinTraCuuKD1.BindData(objThongTinTraCuuKDInfo.ItemCode)
                ThongTinTraCuuKD1.SetValues(objThongTinTraCuuKDInfo)
                Session("ThongTinTraCuuKDInfo") = objThongTinTraCuuKDInfo
                LoadGrid()
                Call btnTimKiem_Click(Me, e)
            End If
            objThongTinTraCuuKDInfo = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(EditURL(, , Request.Params("LoaiHoSo") & "&AddNew=" & Request.Params("AddNew") & "&Malv=" & CType(Session.Item("ItemCode"), String)))
        End Sub
    End Class
End Namespace