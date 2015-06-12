﻿Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class rptTongHopThuLyHoSoPhuongXa
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
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
                'BindData(CType(Session.Item("ItemCode"), String))
                BindData(CType(Session.Item("MaLinhVuc"), String))
            End If
        End Sub

        Public Sub BindData(ByVal ItemCode As String)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Month, -1, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now(), "dd/MM/yyyy")
        End Sub

        'Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '    Dim objBC As New ThongKeBaoCaoController
        '    Dim dt As New DataTable
        '    dt = objBC.ThongKeQuaTinhTiepNhan(txtTuNgay.Text, txtDenNgay.Text).Tables(0)
        '    Dim strServerPath As String
        '    Dim strFile As String
        '    Dim strTemplate As String
        '    Dim strFileOpen As String
        '    strServerPath = Request.MapPath(Request.ApplicationPath)
        '    strFile = strServerPath & "\HSHC\Reports\Temp\DanhSachGiayPhep_" & Session.Item("UserName").ToString & ".xls"
        '    strFileOpen = "\HSHC\Reports\Temp\DanhSachGiayPhep_" & Session.Item("UserName").ToString & ".xls"
        '    strTemplate = strServerPath & "\HSHC\Reports\Reports\MyTemplate.xls"
        '    ExportToExcel(dt, strFile, strTemplate, , 6)
        '    Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
        'End Sub
    End Class
End Namespace