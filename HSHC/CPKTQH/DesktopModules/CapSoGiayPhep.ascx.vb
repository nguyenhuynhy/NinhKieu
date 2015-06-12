Imports PortalQH
Imports System.Configuration
Imports HSHC

Namespace CPKTQH

Public Class CapSoGiayPhep
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTongSoHoSo As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
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

        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuu

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                SetAttributesControl()
                Init_State()
            End If
            LoadGrid()
            Dim ID As String
            ID = Request.Params("ID")
            If ID <> "" Then CheckHoSo(ID)
        End Sub


        Private Sub SetAttributesControl()
            txtSoDong.Attributes.Add("onkeypress", "javascript:ValidateNumeric();")
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
            If CType(ConfigurationSettings.AppSettings("CheckUser" & CType(Session.Item("ActiveDB"), String)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & Me.PortalSettings.ActiveTab.TabName & " ::."
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            End If

            'init grid
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo

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

            objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)
            'objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE", "LOAIHOSO")
            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE", "CapSoGiayPhepDKKD")
            objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            ds = objThongTinTraCuuCtrl.GetInfoFromSearchCapSoBangTay(objThongTinTraCuuInfo)
            'BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,, Họ tên, Ðịa chỉ, Ngày nhận, Ngày hẹn trả, Loại hồ sơ, Tình trạng, Tình trạng, Người thụ lý", _
            '                                               "100, 0, 150, 200, 70, 70,0,0,200,100", False, True)
            If (Me.dgdDanhSach.CurrentPageIndex > CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))) Then
                Me.dgdDanhSach.CurrentPageIndex = CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))
            End If
            Me.dgdDanhSach.DataSource = ds
            Me.dgdDanhSach.DataBind()
            AddAttributeCheckbox()

            lblTongSoHoSo.Text = ds.Tables(0).Rows.Count.ToString + " hồ sơ"

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
                    Session("ThongTinTraCuuInfo") = ThongTinTraCuu1.GetValues()
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
