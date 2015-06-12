Imports PortalQH
Imports System.Configuration
Namespace CPLDQH

    Public Class rptThongKeDoanhNghiep
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList

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
                BindData(CType(Session.Item("ItemCode"), String))
            End If

            'Init_Report()
        End Sub

        Public Sub BindData(ByVal ItemCode As String)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Month, -3, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now(), "dd/MM/yyyy")

            Dim dsPhuong As New DataSet
            Dim objDanhMuc As New DanhMucController
            dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
            BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, "")
        End Sub

        'Sub Init_Report()
        '    Dim strItemCode As String
        '    If Request.Params("SelectID") Is Nothing Then
        '        strItemCode = "1"
        '    Else
        '        strItemCode = Request.Params("SelectID")
        '    End If
        '    GetReportURL(Request.Params("TabId").ToString, "CPLD", strItemCode, "CPLDQH", btnIn, Me)
        'End Sub

    End Class

End Namespace