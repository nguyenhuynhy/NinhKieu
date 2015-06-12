Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ChuyenHoSoThuLy
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents grdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ThongTinTraCuuPhanCong1 As ThongTinTraCuuPhanCong
        Private Shared objThongTinTraCuuInfo As ThongTinTraCuuInfo
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtMaLinhVuc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.HtmlControls.HtmlInputHidden


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
                'Init_State()
                'SetAttributesControl()
            End If
        End Sub

        Sub Init_State()
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

            'init dropdownlist
            If objThongTinTraCuuInfo Is Nothing Then
                objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
                iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            Else
                iSelectedId = objThongTinTraCuuInfo.ItemCode
            End If
            If CType(ConfigurationSettings.AppSettings("CheckUser" & ctype(Session.Item("ActiveDB"),string)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            End If

            'init grid
            ThongTinTraCuuPhanCong1.ThongTinTraCuu = objThongTinTraCuuInfo
            LoadGrid()

            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing
        End Sub

       
       

        Private Sub grdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDanhSach.PageIndexChanged
            grdDanhSach.CurrentPageIndex = e.NewPageIndex
            objThongTinTraCuuInfo = ThongTinTraCuuPhanCong1.GetValues()
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
            Dim ds As DataSet
            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE")
            ds = objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuInfo)
            BindControl.BindDataGrid(ds, grdDanhSach, True, False, True, "STT", "", "Chọn", "~/Images/edit.gif", 100, 300, 500, 100, 0, 300, 100, 0, 300)
            objThongTinTraCuuCtrl = Nothing
            SetAttributesControl()
        End Sub
        Private Sub SetAttributesControl()
            txtMaLinhVuc.Value = CType(Session.Item("ItemCode"), String)
            txtMaNguoiTacNghiep.Value = CType(Session.Item("UserName"), String)
            GetReportURL(Request.Params("TabId"), CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInRaGiay, Me, True)
            grdDanhSach.Attributes.Add("onclick", "javascript:LaySoBienNhan();")
        End Sub
        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                objThongTinTraCuuInfo = Nothing
                objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)

                ThongTinTraCuuPhanCong1.BindData(objThongTinTraCuuInfo.ItemCode)
                ThongTinTraCuuPhanCong1.SetValues(objThongTinTraCuuInfo)
                LoadGrid()
            End If
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                objThongTinTraCuuInfo = Nothing
                objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)

                ThongTinTraCuuPhanCong1.BindData(objThongTinTraCuuInfo.ItemCode)
                ThongTinTraCuuPhanCong1.SetValues(objThongTinTraCuuInfo)
                LoadGrid()
            End If
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Dim item As New ListItem
            Try
                If Not ThongTinTraCuuPhanCong1 Is Nothing Then
                    If ddlLinhVuc.SelectedValue <> CType(Session.Item("ItemCode"), String) Then
                        item.Value = CType(Session.Item("ItemCode"), String)
                        item.Text = ddlLinhVuc.Items.FindByValue(CType(Session.Item("ItemCode"), String)).Text
                        ddlLinhVuc.SelectedIndex = ddlLinhVuc.Items.IndexOf(item)
                    End If
                    objThongTinTraCuuInfo = ThongTinTraCuuPhanCong1.GetValues()
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            item = Nothing
        End Sub
    End Class
End Namespace