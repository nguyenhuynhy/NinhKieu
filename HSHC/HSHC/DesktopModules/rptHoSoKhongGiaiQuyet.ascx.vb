Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class rptHoSoKhongGiaiQuyet
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtLoaiBaoCao As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

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
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            If Not Page.IsPostBack Then
                BindControl.BindDropDownList(ddlDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            End If
            Init_State()
            'BindData(CType(Session.Item("ItemCode"), String))
            BindData(CType(Session.Item("MaLinhVuc"), String))
        End Sub

        Public Sub BindData(ByVal ItemCode As String)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Month, -1, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            ddlDuong.SelectedIndex = 0
            ddlPhuong.SelectedIndex = 0
            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDMLoaiHoSo", ItemCode, Request.Params("TabID"))
        End Sub

        Sub Init_State()

            Select Case Request.Params("SelectID")
                Case Nothing : txtLoaiBaoCao.Text = "DSKHONGGIAIQUYET"
                Case "1" : txtLoaiBaoCao.Text = "DSKHONGGIAIQUYET"
                Case "2" : txtLoaiBaoCao.Text = "DSDAGIAIQUYET"
                Case "3" : txtLoaiBaoCao.Text = "DSQUAHAN"
                Case "4" : txtLoaiBaoCao.Text = "DSHUY"
            End Select
        End Sub
    End Class

End Namespace
