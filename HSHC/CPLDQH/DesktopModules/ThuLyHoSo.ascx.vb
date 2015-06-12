Imports PortalQH
Imports System.Configuration
Imports HSHC
Namespace CPLDQH
    Public Class ThuLyHoSo
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuu

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
            Dim ID As String
            ID = Request.Params("ID")
            If ID <> "" Then CheckHoSo(ID)
        End Sub

        Sub Init_State()
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            Dim objTraCuu As New TraCuu(Request)
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
            'Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
            Viewstate("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
            If (Session("ThongTinTraCuuInfo") Is Nothing) Then
                Dim obj As New ThongTinTraCuuInfo(Request)
                obj.ItemCode = ddlLinhVuc.SelectedValue
                obj.NguoiTacNghiep = CStr(Session("UserID"))
                'khởi tạo giá trị session
                Session("ThongTinTraCuuInfo") = obj
            Else 'them o day nhe' ca'c em
                Dim obj As ThongTinTraCuuInfo = CType(Session("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)
                obj.TabCode = Request("tabid")
                Session("ThongTinTraCuuInfo") = obj
            End If
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)

            'release object
            objMenuListInfo = Nothing
            objMenuList = Nothing

        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
            Dim objTraCuu As New TraCuu(Request)
            objTraCuu = CType(viewstate("TraCuu"), TraCuu)
            objThongTinTraCuuInfo = CType(ViewState("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)
            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE", "LOAIHOSO")
            objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            ds = objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuInfo)
            'BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,, Họ tên, Ðịa chỉ, Ngày nhận, Ngày hẹn trả, Loại hồ sơ, Tình trạng, Tình trạng, Người thụ lý", _
            '                                                "50, 0, 150, 200, 70, 70,0,0,200,100", False, True)
            If (Me.dgdDanhSach.CurrentPageIndex > CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))) Then
                Me.dgdDanhSach.CurrentPageIndex = CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))
            End If
            Me.dgdDanhSach.DataSource = ds
            Me.dgdDanhSach.DataBind()
            AddAttributeCheckbox()
            ds = Nothing
            objThongTinTraCuuCtrl = Nothing
            objThongTinTraCuuInfo = Nothing
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


        Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New HSHC.HoSoBoSungController
            Dim dv As New DataView
            dv = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Return True
                Else
                    Return False
                End If
            End If
        End Function
        Private Function CheckQuaHanBoSung(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New HSHC.HoSoBoSungController
            Dim dv As New DataView
            dv = objHoSoBoSung.GetQuaHanBoSung(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    Return True
                Else
                    SetMSGBOX_HIDDEN(Page, "Ho so nay chua qua han bo sung!")
                    Return False
                End If
            End If
        End Function
        Private Function GetSoBienNhan() As String
            Dim strSoBienNhan As String
            Dim item As DataGridItem
            For Each item In dgdDanhSach.Items
                If CType(item.FindControl("chkXoa"), CheckBox).Checked = True Then
                    If strSoBienNhan <> "" Then strSoBienNhan = strSoBienNhan & ","
                    strSoBienNhan = strSoBienNhan & item.Cells(2).Text
                End If
            Next
            Return strSoBienNhan
        End Function
        Private Function GetHoSoTiepNhanID() As String
            Dim strHoSoTiepNhanID As String
            Dim item As DataGridItem
            For Each item In dgdDanhSach.Items
                If CType(item.FindControl("chkXoa"), CheckBox).Checked = True Then
                    If strHoSoTiepNhanID <> "" Then strHoSoTiepNhanID = strHoSoTiepNhanID & ","
                    strHoSoTiepNhanID = strHoSoTiepNhanID & item.Cells(3).Text
                End If
            Next
            Return strHoSoTiepNhanID
        End Function
        Private Sub CheckHoSo(ByVal strSoBienNhan As String)
            Dim item As DataGridItem
            For Each item In dgdDanhSach.Items
                If strSoBienNhan = item.Cells(2).Text Then
                    CType(item.FindControl("chkXoa"), CheckBox).Checked = True
                End If
            Next
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
                    ViewState("ThongTinTraCuuInfo") = ThongTinTraCuu1.GetValues()
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            item = Nothing
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)

                'bind l?i d? li?u tuong ?ng v?i ItemCode
                ThongTinTraCuu1.BindData(objThongTinTraCuuInfo.ItemCode)
                ThongTinTraCuu1.SetValues(objThongTinTraCuuInfo)
                Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
                LoadGrid()
            End If
            objThongTinTraCuuInfo = Nothing
        End Sub

        Private Sub btnYeuCauBoSung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim strSoBienNhan As String
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG"), True)
            End If
        End Sub

        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim strSoBienNhan As String
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=DX", True)
            End If
        End Sub

        Private Sub btnThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim strSoBienNhan As String
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=TD", True)
            End If
        End Sub

        Private Sub btnToTrinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim strSoBienNhan As String
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=TT", True)
            End If
        End Sub

        Private Sub btnKiemTra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("", "", "KIEMTRA"), True)
        End Sub

        Private Sub btnHuyHS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim strSoBienNhan, strHoSoTiepNhanID As String
            strSoBienNhan = GetSoBienNhan()
            strHoSoTiepNhanID = GetHoSoTiepNhanID()
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                SetMSGBOX_HIDDEN(Page, "Khong duoc huy ho so nay!")
                Exit Sub
            End If
            If strSoBienNhan <> "" And CheckQuaHanBoSung(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strHoSoTiepNhanID, "HUY"), True)
            End If
        End Sub
    End Class
End Namespace
