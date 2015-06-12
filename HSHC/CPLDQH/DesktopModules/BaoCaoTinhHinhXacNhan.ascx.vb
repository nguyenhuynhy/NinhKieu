Imports PortalQH
Imports System.Configuration
Imports System.Web.UI.WebControls
Namespace CPLDQH
    Public Class BaoCaoTinhHinhXacNhan
        Inherits PortalQH.PortalModuleControl
        Protected Reports1 As Reports
        Private Shared IDLinhVuc As String = ""
        Private Shared IDReport As String = ""
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lstReports As System.Web.UI.WebControls.RadioButtonList
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
            Dim ctrl As Control
            If Not Me.IsPostBack Then
                Init_State()
            End If
            If IDReport = "" Or lstReports.SelectedValue <> IDReport Then
                Reports1.Load_Page(lstReports.SelectedValue)
            Else
                If IDLinhVuc = ddlLinhVuc.SelectedValue Then
                    Reports1.Load_Page(IDReport)
                Else
                    Call ddlLinhVuc_SelectedIndexChanged(sender, e)
                    Reports1.Load_Page(IDReport)
                End If
            End If

            'TuanNH add date 02/03/2006
            'Mục đích : kiểm tra TuNgay phải nhỏ hơn DenNgay
            If Not Me.IsPostBack Then
                Dim txtTuNgay As TextBox
                Dim txtDenNgay As TextBox
                Dim cmdTuNgay As HyperLink
                Dim cmdDenNgay As HyperLink
                txtTuNgay = CType(Reports1.FindControl("txtTuNgay"), TextBox)
                txtDenNgay = CType(Reports1.FindControl("txtDenNgay"), TextBox)
                cmdTuNgay = CType(Reports1.FindControl("cmdCalendarTuNgay"), HyperLink)
                cmdDenNgay = CType(Reports1.FindControl("cmdCalendarDenNgay"), HyperLink)
                If Not (txtTuNgay Is Nothing Or txtDenNgay Is Nothing) Then
                    txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
                    txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
                End If

                If Not (cmdTuNgay Is Nothing Or cmdDenNgay Is Nothing) Then
                    cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
                    cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                    cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
                    cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
                End If
            End If

        End Sub

        Sub Init_State()
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuLDController
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
                End If
                Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
                lblTieuDe.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            End If
            BindControl.BindRadioButtonList(lstReports, "sp_GetReportList", "", CType(Request.Params("TabId"), String))

        End Sub

        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            BindControl.BindRadioButtonList(lstReports, "sp_GetReportList", "", CType(Request.Params("TabId"), String))
            Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
            IDLinhVuc = ddlLinhVuc.SelectedValue()
            IDReport = lstReports.SelectedValue
        End Sub

        Private Sub lstReports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstReports.SelectedIndexChanged
            IDLinhVuc = ddlLinhVuc.SelectedValue()
            IDReport = lstReports.SelectedValue
        End Sub

    End Class
End Namespace
