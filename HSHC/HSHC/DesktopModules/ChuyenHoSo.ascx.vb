Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ChuyenHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInPhieu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtMaLinhVuc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid

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
            If Not IsPostBack Then
                Init_State()
                SetAttributesControl()
            End If
            LoadGrid()
        End Sub
        Sub Init_State()
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

            'init dropdownlist
            iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            If CType(ConfigurationSettings.AppSettings("CheckUser" & gActiveDB), Boolean) Then
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
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            End If
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            'init grid
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)

            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing
            objThongTinTraCuuInfo = Nothing
        End Sub
        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController

            objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)
            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE")
            ds = objThongTinTraCuuCtrl.GetDanhSachHoSoCD1(objThongTinTraCuuInfo)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Số biên nhận, Hồ sơ tiếp nhận ID,Số giấy phép, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150,0,150,300, 350, 100, 100,0", True, False)
            AddAttributeCheckbox()

            ds = Nothing
            objThongTinTraCuuInfo = Nothing
            objThongTinTraCuuCtrl = Nothing
        End Sub
        Private Sub SetAttributesControl()
            txtMaLinhVuc.Value = CType(Session.Item("ItemCode"), String)
            txtMaNguoiTacNghiep.Value = CType(Session.Item("UserName"), String)
            GetReportURL(CType(TabId, String), CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInRaGiay, Me)
            dgdDanhSach.Attributes.Add("onclick", "javascript:LaySoBienNhan();")
        End Sub
        Private Sub AddAttributeCheckbox()
            Dim chk As CheckBox
            Dim i As Integer
            If dgdDanhSach.Items.Count = 0 Then Exit Sub
            For i = 0 To dgdDanhSach.Controls(0).Controls.Count - 1
                chk = CType(dgdDanhSach.Controls(0).Controls(i).FindControl("chkXoa"), CheckBox)
                If Not chk Is Nothing Then
                    chk.Attributes.Add("OnClick", "javascript: return select_deselect('" & chk.ClientID & "');")
                End If
            Next
        End Sub
    End Class
End Namespace
