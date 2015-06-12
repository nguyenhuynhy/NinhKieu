Imports System.Configuration
Imports PortalQH
Imports HSHC
Namespace DOITHOAI
    Public Class GuiTinNhanMoi
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnChonNguoiNhan As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnGui As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtNguoiHoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCauHoiID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Các hàm sự kiện"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                SetAttributesControl()
                BindData()
                btnTroVe.Visible = False
                lblTitle.Visible = False
                'kiểm tra trường hợp gui tin nhan cho 1 ho so tiep nhan
                If Not Request.Params("HoSoID") Is Nothing Then
                    CheckHoSoTiepNhan()
                    viewstate("UrlReferrer") = DataCache.GetCache(Session.SessionID + "UrlReferrer").ToString
                    btnTroVe.Visible = True
                    lblTitle.Visible = True
                End If
            End If
        End Sub
        Private Sub btnGui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGui.Click
            'kiểm tra người nhận có tồn tại trong hệ thống
            If Not CheckExistsUser(txtNguoiNhan.Text) Then
                SetMSGBOX_HIDDEN(Page, "Không tồn tại người nhận trong hệ thống!" & vbCrLf & "Kiểm tra lại tên truy cập của người nhận")
                SetFocus(Page, txtNguoiNhan)
                Exit Sub
            End If

            'thêm câu hỏi vào hệ thống
            Dim objTinNhanCtrl As New TinNhanController
            Dim strResult As String
            strResult = objTinNhanCtrl.ThemTinNhanMoi(Me)
            If strResult = "-1" Then
                SetMSGBOX_HIDDEN(Page, "Cập nhật không thành công!")
                SetFocus(Page, ddlMaLinhVuc)
                Exit Sub
            End If

            Response.Redirect(NavigateURL())
        End Sub
        Private Sub txtUserName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged
            txtNguoiNhan.Text = txtUserName.Text
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(CStr(viewstate("UrlReferrer")))
        End Sub
#End Region

#Region "Các hàm xử lý"
        Private Sub SetAttributesControl()
            ddlMaLinhVuc.Attributes.Add("ISNULL", "NOTNULL")
            txtTieuDe.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDung.Attributes.Add("ISNULL", "NOTNULL")
            txtNguoiNhan.Attributes.Add("ISNULL", "NOTNULL")

            btnGui.Attributes.Add("onclick", "javascript:return CheckCapNhat();")
            btnChonNguoiNhan.Attributes.Add("onclick", "javascript:CallWindow('" & strPathChonNguoiNhan & "','Application');")
        End Sub
        Private Sub BindData()
            'Bind dropdownlist lĩnh vực
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

            iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            If CType(ConfigurationSettings.AppSettings("CheckUser" & CType(Session.Item("ActiveDB"), String)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlMaLinhVuc, True, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlMaLinhVuc, True, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If

            objMenuListInfo = Nothing
            objMenuList = Nothing

            txtNguoiHoi.Text = CType(Session.Item("UserName"), String)
        End Sub
        Private Function CheckExistsUser(ByVal strUserName As String) As Boolean
            Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim objUsers As New UserController
            Dim objUser As UserInfo

            objUser = objUsers.GetUserByUsername(_portalSettings.PortalId, strUserName)

            If Not objUser Is Nothing Then
                If objUser.UserID <> "" Then
                    Return True
                End If
            End If
            Return False
        End Function

        Private Sub CheckHoSoTiepNhan()
            Dim strHoSoTiepNhanID As String
            Dim obj As New TiepNhanHoSoController
            Dim ds As DataSet

            strHoSoTiepNhanID = Request.Params("HoSoID")
            ds = obj.getHoSoTiepNhan(strHoSoTiepNhanID)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Columns.Contains("MaLinhVuc") Then
                        DdLSelected(ddlMaLinhVuc, ds.Tables(0).Rows(0).Item("MaLinhVuc").ToString)
                    End If
                    If ds.Tables(0).Columns.Contains("NguoiNhanCuoi") Then
                        txtNguoiNhan.Text = ds.Tables(0).Rows(0).Item("NguoiNhanCuoi").ToString
                    End If
                    If ds.Tables(0).Columns.Contains("SoBienNhan") Then
                        Dim str As String
                        str = getTieuDeDefault()
                        str = Replace(str, "{{SOBIENNHAN}}", ds.Tables(0).Rows(0).Item("SoBienNhan").ToString)
                        txtTieuDe.Text = str
                    End If
                End If
            End If

        End Sub
#End Region




    End Class
End Namespace