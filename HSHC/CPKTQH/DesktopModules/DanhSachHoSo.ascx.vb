Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class DanhSachHoSo
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChuoiID As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label25 As System.Web.UI.WebControls.Label
        Protected WithEvents Label26 As System.Web.UI.WebControls.Label
        Protected WithEvents Label27 As System.Web.UI.WebControls.Label
        Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Label10 As System.Web.UI.WebControls.Label
        Protected WithEvents Label11 As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents Label13 As System.Web.UI.WebControls.Label
        Protected WithEvents Label14 As System.Web.UI.WebControls.Label
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents Label16 As System.Web.UI.WebControls.Label
        Protected WithEvents Label17 As System.Web.UI.WebControls.Label
        Protected WithEvents Label18 As System.Web.UI.WebControls.Label
        Protected WithEvents Label19 As System.Web.UI.WebControls.Label
        Protected WithEvents Label20 As System.Web.UI.WebControls.Label
        Protected WithEvents Label21 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        Protected WithEvents Label22 As System.Web.UI.WebControls.Label
        Protected WithEvents Label23 As System.Web.UI.WebControls.Label
        Protected WithEvents Label24 As System.Web.UI.WebControls.Label
        Protected WithEvents Label28 As System.Web.UI.WebControls.Label
        Protected WithEvents Label29 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ThongTinTraCuuKD1 As ThongTinTraCuuKD


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

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
                lblHeader.Text = ".:: " & Me.PortalSettings.ActiveTab.TabName & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
            End If
            '====================================================================================================='
            If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                objThongTinTraCuuKDInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                tblHeader.Visible = False
            End If
            '====================================================================================================='

            Session("ThongTinTraCuuKDInfo") = objThongTinTraCuuKDInfo
            dgdDanhSach.Attributes.Add("onclick", "javascript:LaySoBienNhan();")
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing
            objThongTinTraCuuKDInfo = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim objThongTinTraCuuKDInfo As New ThongTinTraCuuKDInfo(Request)

            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuKDController
            Dim ds As DataSet
            Dim strLoaiHoSo, strURL As String

            objThongTinTraCuuKDInfo = CType(Session("ThongTinTraCuuKDInfo"), ThongTinTraCuuKDInfo)

            strLoaiHoSo = GetParamByID("tab" & TabId, glbXMLFile)
            strURL = EditURL("ID", "VALUE", strLoaiHoSo) & "&AddNew=False"

            objThongTinTraCuuKDInfo.URL = strURL
            ThongTinTraCuuKD1.GetValues()
            objThongTinTraCuuKDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            'ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD1(objThongTinTraCuuKDInfo)
            'If strLoaiHoSo <> "HOSOKHONG" Then
            '    'BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép,Hồ sơ tiếp nhận ID,  Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Tình trạng,tình trạng,Người thụ lý", "150,150, 0,150,250, 500, 100, 100,0,200")
            '    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150, 150,0,250, 250, 250, 100,100")
            'Else
            '    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép ,Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150,0,0,150,500, 250, 100, 100,100")
            'End If
            Select Case UCase(strLoaiHoSo)
                Case "HOSOKHONG"
                    ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD1(objThongTinTraCuuKDInfo)
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Số biên nhận,Số giấy phép ,Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150,0,0,150,500, 250, 100, 100,100")
                Case "VAOSOCONGVAN"
                    ds = objThongTinTraCuuCtrl.GetDanhSachCongVan(objThongTinTraCuuKDInfo)
                    'BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "", "100,200,250,0,100,100,150,200,200", True, True)
                    If (Me.dgdDanhSach.CurrentPageIndex > CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))) Then
                        Me.dgdDanhSach.CurrentPageIndex = CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))
                    End If
                    dgdDanhSach.DataSource = ds
                    dgdDanhSach.DataBind()

                    Dim i As Integer
                    Dim strChuoiID As String
                    For i = 0 To ds.Tables(0).DefaultView.Count - 1
                        strChuoiID = strChuoiID + ds.Tables(0).DefaultView.Item(i).Item("CongVanID").ToString
                    Next
                    txtChuoiID.Text = strChuoiID
                    GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), CType(IIf(objThongTinTraCuuKDInfo.LoaiCongVan <> "1", "2", "1"), String), CType(Session.Item("ActiveDB"), String), btnIn, Me, True)
                Case Else

                        ds = objThongTinTraCuuCtrl.GetInfoFromSearchCD1(objThongTinTraCuuKDInfo)
                        BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,Số giấy phép, Hồ sơ tiếp nhận ID, Họ tên, Địa chỉ, Ngày nhận, Ngày hẹn trả,Người thụ lý", "150, 150,0,250, 250, 250, 100,100")

                        GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), CType(IIf(objThongTinTraCuuKDInfo.LoaiCongVan <> "1", "2", "1"), String), CType(Session.Item("ActiveDB"), String), btnIn, Me, True)

            End Select


            objThongTinTraCuuCtrl = Nothing
            objThongTinTraCuuKDInfo = Nothing

        End Sub




        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
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
            Dim objThongTinTraCuuKDInfo As New ThongTinTraCuuKDInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & Me.PortalSettings.ActiveTab.TabName & " ::."
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


