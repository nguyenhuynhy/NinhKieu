Imports System.Configuration
Imports PortalQH
Namespace CPLDQH
    Public Class DanhSachSuDungLaoDong
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtChuoiID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ThongTinTraCuuLD1 As ThongTinTraCuuLD

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
            Dim objThongTinTraCuuldInfo As New ThongTinTraCuuLDInfo(Request)
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
                objThongTinTraCuuldInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                tblHeader.Visible = False
            End If
            '====================================================================================================='

            Session("ThongTinTraCuuldInfo") = objThongTinTraCuuldInfo
            dgdDanhSach.Attributes.Add("onclick", "javascript:LaySoBienNhan();")
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing
            objThongTinTraCuuldInfo = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim objThongTinTraCuulDInfo As New ThongTinTraCuuLDInfo(Request)

            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuLDController
            Dim ds As DataSet
            Dim strLoaiHoSo, strURL As String

            objThongTinTraCuulDInfo = CType(Session("ThongTinTraCuulDInfo"), ThongTinTraCuuLDInfo)

            strLoaiHoSo = GetParamByID("tab" & TabId, glbXMLFile)
            strURL = EditURL("ID", "VALUE", strLoaiHoSo) & "&AddNew=False"

            objThongTinTraCuulDInfo.URL = strURL
            ThongTinTraCuuLD1.GetValues()
            objThongTinTraCuulDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            'ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD1(objThongTinTraCuuKDInfo)
            'If strLoaiHoSo <> "HOSOKHONG" Then
            '    'BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép,Hồ sơ tiếp nhận ID,  Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Tình trạng,tình trạng,Người thụ lý", "150,150, 0,150,250, 500, 100, 100,0,200")
            '    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150, 150,0,250, 250, 250, 100,100")
            'Else
            '    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép ,Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150,0,0,150,500, 250, 100, 100,100")
            'End If
            Select Case UCase(strLoaiHoSo)
                Case "HOSOKHONG"
                    ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD1(objThongTinTraCuulDInfo)
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Số biên nhận,Số giấy phép ,Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150,0,0,150,500, 250, 100, 100,100")
                Case "VAOSOCONGVAN"
                    ds = objThongTinTraCuuCtrl.GetDanhSachCongVan(objThongTinTraCuulDInfo)
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "", "100,200,250,0,100,100,150,200,200", True, True)

                    Dim i As Integer
                    Dim strChuoiID As String
                    For i = 0 To ds.Tables(0).DefaultView.Count - 1
                        strChuoiID = strChuoiID + ds.Tables(0).DefaultView.Item(i).Item("CongVanID").ToString
                    Next
                    txtChuoiID.Text = strChuoiID
                    GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), CType(IIf(objThongTinTraCuulDInfo.LoaiCongVan <> "1", "2", "1"), String), CType(Session.Item("ActiveDB"), String), btnIn, Me)
                Case Else
                    ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD1(objThongTinTraCuulDInfo)
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150, 150,0,250, 250, 250, 100,100")

            End Select


            objThongTinTraCuuCtrl = Nothing
            objThongTinTraCuulDInfo = Nothing

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


        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuulDInfo As New ThongTinTraCuuLDInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuulDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                'bind lại dữ liệu tương ứng với ItemCode
                ThongTinTraCuuLD1.BindData(objThongTinTraCuulDInfo.ItemCode)
                ThongTinTraCuuLD1.SetValues(objThongTinTraCuulDInfo)
                Session("ThongTinTraCuulDInfo") = objThongTinTraCuulDInfo
                LoadGrid()
                Call btnTimKiem_Click(Me, e)
            End If
            objThongTinTraCuulDInfo = Nothing
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Dim item As New ListItem
            Try
                If Not ThongTinTraCuuLD1 Is Nothing Then
                    If ddlLinhVuc.SelectedValue <> CType(Session.Item("ItemCode"), String) Then
                        item.Value = CType(Session.Item("ItemCode"), String)
                        item.Text = ddlLinhVuc.Items.FindByValue(CType(Session.Item("ItemCode"), String)).Text
                        ddlLinhVuc.SelectedIndex = ddlLinhVuc.Items.IndexOf(item)
                    End If
                    Session("ThongTinTraCuulDInfo") = ThongTinTraCuuLD1.GetValues()
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            item = Nothing
        End Sub

        'Private Sub btnThemMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Response.Redirect(EditURL(, , GetParamByID("tab" & TabId, glbXMLFile) & "&AddNew=True" & "&Malv=" & CType(Session.Item("ItemCode"), String)), True)
        'End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            If txtChuoiSoBienNhan.Text <> "" Then
                txtChuoiID.Text = txtChuoiSoBienNhan.Text
            End If
        End Sub

    End Class
End Namespace