Imports System.Configuration
Imports System.Xml
Imports System.Net
Imports System.Math
Imports System.IO
Imports PortalQH
Namespace HSHC
    Public Class DMChitieu
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents txtTenChiTieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents table0 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents label0 As System.Web.UI.WebControls.Label
        Protected WithEvents lbllabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaCha As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtThuTuHienThi As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbllabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents chkBaoCaoThanhPho As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents chkIsData As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents chkIsSum As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        'Protected WithEvents chkIsProgressive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents label7 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDongHienThi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienGiai As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents chkTinhTrang As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlNhomChiTieu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaDonViTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaChiTieu As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object
        Protected WithEvents btnChonDM As System.Web.UI.WebControls.ImageButton
        Protected WithEvents divGrid As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents CongCon As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trDVT As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trCongCon As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trProgressive As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trBCQuan As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents trBCThanhpho As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents btnChonCT As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents BaoCaoQuan As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkBaoCaoQuan As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReLoad As System.Web.UI.WebControls.TextBox
        Private strValue As String = ""
        Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnBoqua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents aqua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtgridMaCha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaCha As System.Web.UI.WebControls.TextBox
        'Protected WithEvents hplXem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents hplXem As System.Web.UI.WebControls.ImageButton
        Protected WithEvents bplXem As System.Web.UI.WebControls.ImageButton
        Private strConst As String = ""

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then
                BindControls()
                Init_State()
                BindGrid(ddlNhomChiTieu.SelectedValue)
                setState()
            End If
            Dim strFile As String
            hplXem.Visible = False
            strFile = AddHTTP(GetDomainName(Request) & "/DESKTOPMODULES/BCTH/Reports/Excel/DMChiTieu_" & ddlNhomChiTieu.SelectedValue.ToString & "_" & Session.Item("UserName").ToString & ".xls")
            hplXem.Attributes.Add("Onclick", "javascript:window.open('" & strFile & "');")

        End Sub
        Private Sub Init_State()
            'txtMaChiTieu.Text = Request.Params("MaChiTieu")
            'ddlNhomChiTieu.SelectedValue = Request.Params("MaCha")

            txtSoDongHienThi.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
            txtTenChiTieu.Attributes.Add("ISNULL", "NOTNULL")
            txtSoDongHienThi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            btnThemMoi.Attributes.Add("onclick", "javascript:return CheckNull();")
            Dim strURLNganhKD As String
            strURLNganhKD = "DesktopModules/BCTH/DanhMuc_Chon.aspx"
            btnChonCT.Attributes.Add("onclick", "javascript:return checkParent(" & txtMaChiTieu.ClientID & ");") ',CallWindow('" & strURLNganhKD & "','Application',Width=700" & ");")
            txtReLoad.Text = ""
            chkTinhTrang.Checked = True
            chkTinhTrang.Attributes.Add("OnClick", "javascript:return checkStatus(" & chkTinhTrang.ClientID & "," & txtMaChiTieu.ClientID & ");")
            ' btnChonCT.Attributes.Add("onlcik", "javascript:return CallWindow('" & strURLNganhKD & "','Application',Width=700" & ");")
            chkIsSum.Checked = True
            chkIsSum.Attributes.Add("onclick", "javascript:return checkIsSum(" & chkIsSum.ClientID & "," & chkIsData.ClientID & ");")
            chkIsData.Attributes.Add("onclick", "javascript:return checkIsSum(" & chkIsSum.ClientID & "," & chkIsData.ClientID & ");")
        End Sub
        Private Sub BindControls()
            BindControl.BindDropDownList(ddlMaDonViTinh, "DMDONVITINH")
            BindControl.BindDropDownList_StoreProc(ddlNhomChiTieu, False, "", ConfigurationSettings.AppSettings("db_bcth").ToString + "..sp_GetDMChiTieuByGroup")
        End Sub
        Private Sub setState()
            If Not Request("MACT") Is Nothing Or Request("MACT") <> "" Then
                Dim strID As String
                strID = Request("MACT")
                Dim ds As DataSet
                Dim objDMCT As New DanhMucChiTieuController
                ds = objDMCT.getDMChiTieuByID(ConfigurationSettings.AppSettings("db_bcth"), strID)
                gLoadControlValues(ds, Me)
                BindGrid(ddlNhomChiTieu.SelectedValue)
                ds = Nothing
                objDMCT = Nothing
            End If
        End Sub
        Private Sub BindGrid(ByVal GroupID As String)
            Dim objDMChiTieu As New DanhMucChiTieuController
            Dim ds As DataSet
            ds = objDMChiTieu.GetAllDMChiTieuByGroup(ConfigurationSettings.AppSettings("db_bcth").ToString(), GroupID)
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            objDMChiTieu = Nothing
            ds = Nothing
        End Sub
        Private Sub txtSoDongHienThi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDongHienThi.TextChanged
            If Not IsInteger(txtSoDongHienThi.Text) Or Trim(txtSoDongHienThi.Text) = "" Or Val(txtSoDongHienThi.Text) = 0 Then
                txtSoDongHienThi.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDongHienThi.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
                dgdDanhSach.CurrentPageIndex = 0
                BindGrid(ddlNhomChiTieu.SelectedValue.ToString)
            End If
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            BindGrid(ddlNhomChiTieu.SelectedValue)
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThemMoi.Click
            Dim objDMChiTieuInfo As New DanhMucChiTieuInfo
            Dim objDMChiTieu As New DanhMucChiTieuController
            Dim ds As New DataSet
            Dim str As String
            LayGiaTri(objDMChiTieuInfo)
            ds = objDMChiTieu.AddDMChiTieu(objDMChiTieuInfo, ConfigurationSettings.AppSettings("db_bcth").ToString)
            If Not ds Is Nothing Then
                gLoadControlValues(ds, Me)
            End If
            'If Not ds.Tables(0).Rows(0).Item("MACHITIEU") Is DBNull.Value Then
            ' Response.Redirect(EditURL("State", "EDIT", ""))
            'End If
            objDMChiTieu = Nothing
            objDMChiTieuInfo = Nothing
            BindControl.BindDropDownList_StoreProc(ddlNhomChiTieu, True, "", ConfigurationSettings.AppSettings("db_bcth").ToString + "..sp_GetDMChiTieuByGroup")
            BindGrid(ddlNhomChiTieu.SelectedValue.ToString)
            'strConst = Request.RawUrl
            'str = strConst + "&MaCT=" + txtMaChiTieu.Text '+ "&MaCha = " + txtMaCha.Text
            Response.Redirect(EditURL("MACT", txtMaChiTieu.Text, ""))
            'Response.Redirect(str)
        End Sub
        Private Sub BindControlwithEvent()
            BindGrid(ddlNhomChiTieu.SelectedValue.ToString)
        End Sub
        Private Sub ddlNhomChiTieu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlNhomChiTieu.SelectedIndexChanged
            strValue = ddlNhomChiTieu.SelectedValue
            BindControlwithEvent()

            ' SetAttributeControls()
        End Sub
        Private Sub LayGiaTri(ByVal obj As DanhMucChiTieuInfo)
            With obj
                .MaChiTieu = txtMaChiTieu.Text
                '.MaCha = ddlMaCha.SelectedValue
                .MaCha = txtMaCha.Text
                .TenChiTieu = txtTenChiTieu.Text.Trim
                .MaDonViTinh = ddlMaDonViTinh.SelectedValue
                .TinhTrang = Abs(CType(chkTinhTrang.Checked, Integer)).ToString
                .IsData = Abs(CType(chkIsData.Checked, Integer)).ToString
                .IsSum = Abs(CType(chkIsSum.Checked, Integer)).ToString
                '.IsProgressive = Abs(CType(chkIsProgressive.Checked, Integer)).ToString
                .DienGiai = CType(txtDienGiai.Text.Trim, String)
                '.BaoCaoQuan = Abs(CType(chkBaoCaoQuan.Checked, Integer)).ToString
                '.BaoCaoThanhPho = Abs(CType(chkBaoCaoThanhPho.Checked, Integer)).ToString
                If txtCap.Text.ToString <> "" Then
                    .Cap = CType(txtCap.Text.ToString, Integer)
                End If
                .MaGoc = ddlNhomChiTieu.SelectedValue
            End With
        End Sub

        Private Sub dgdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.ItemCommand
            Dim objDMChiTieu As New DanhMucChiTieuController
            Dim ds As DataSet
            Dim str As String
            Dim str1 As String
            str = e.CommandName
            Select Case str
                Case "Chon"
                    ds = objDMChiTieu.getDMChiTieuByID(ConfigurationSettings.AppSettings("db_bcth"), e.Item.Cells(2).Text.ToString)
                    gLoadControlValues(ds, Me)
                    ds = Nothing
                    objDMChiTieu = Nothing
                Case "MoveUp"
                    Dim objDMInfo As New DanhMucChiTieuInfo
                    ds = objDMChiTieu.getDMChiTieuByID(ConfigurationSettings.AppSettings("db_bcth"), e.Item.Cells(2).Text.ToString)
                    ' dua du lieu vao control
                    gLoadControlValues(ds, Me)
                    ' gan gia tri vao dmchitieuinfo
                    LayGiaTri(objDMInfo)
                    objDMChiTieu.UpdateChiTieuTabOrder(objDMInfo.MaGoc, objDMInfo.MaChiTieu, objDMInfo.MaCha, 0, -1, True)
                    BindGrid(ddlNhomChiTieu.SelectedValue)
                    objDMChiTieu = Nothing
                Case "MoveDown"
                    Dim objDMInfo As New DanhMucChiTieuInfo
                    ' dua du lieu vao control
                    ds = objDMChiTieu.getDMChiTieuByID(ConfigurationSettings.AppSettings("db_bcth"), e.Item.Cells(2).Text.ToString)
                    gLoadControlValues(ds, Me)
                    ' gan gia tri vao dmchitieuinfo
                    LayGiaTri(objDMInfo)
                    objDMChiTieu.UpdateChiTieuTabOrder(objDMInfo.MaGoc, objDMInfo.MaChiTieu, objDMInfo.MaCha, 0, 1, True)
                    BindGrid(ddlNhomChiTieu.SelectedValue)
                    objDMChiTieu = Nothing
            End Select

        End Sub
        Private Sub btnBoqua_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBoqua.Click
            Response.Redirect(EditURL("", "", ""))
        End Sub
        Private Sub ExportDaTaToExcel()
            Dim objDMChiTieu As New DanhMucChiTieuController
            Dim ds As DataSet
            Dim dt As DataTable
            Dim dtNew As New DataTable
            Dim dc As New DataColumn
            Dim dr As DataRow
            Dim i As Integer
            ds = objDMChiTieu.GetAllDMChiTieuByGroup(ConfigurationSettings.AppSettings("db_bcth").ToString(), ddlNhomChiTieu.SelectedValue.ToString)

            dt = ds.Tables(0)

            Dim strServerPath As String
            Dim strFile As String
            Dim strTemplate As String
            strServerPath = Request.MapPath(Request.ApplicationPath)
            strFile = strServerPath & "\DESKTOPMODULES\BCTH\Reports\Excel\DMChiTieu_" & ddlNhomChiTieu.SelectedValue.ToString & "_" & Session.Item("UserName").ToString & ".xls"
            strTemplate = strServerPath & "\DESKTOPMODULES\BCTH\Reports\Excel\MyTemplate.xls"
            If dt.Rows.Count > 0 Then
                Dim str As String
                For i = 0 To dt.Rows.Count - 1
                    str = dt.Rows(i).Item("Ten").ToString.Replace("&nbsp;", "  ")
                    dt.Rows(i).Item("Ten") = ""
                    'SetMSGBOX_HIDDEN(Page, dt.Rows(i).Item("Ten").ToString)
                    dt.Rows(i).Item("Ten") = str
                Next
                'dtNew = dt
                'dt.Rows.Add(dr)
                If ExportToExcel(dt, strFile, strTemplate) Then
                    hplXem.Visible = True
                Else
                    hplXem.Visible = False
                    SetMSGBOX_HIDDEN(Page, "Khong tao duoc file. Kiem tra xem ban da dong file 'DMChiTieu_" & ddlNhomChiTieu.SelectedValue.ToString & "_" & Session.Item("UserName").ToString & ".xls' chua?")
                End If
            Else
                SetMSGBOX_HIDDEN(Page, "Khong co du lieu, xin vui long kiem tra lai")
            End If
        End Sub
        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
            'dgdDanhSach.AllowPaging = False
            'dgdDanhSach.CurrentPageIndex = dgdDanhSach.PageSize
            'RenderGrid()
            ExportDaTaToExcel()
        End Sub
        Private Sub RenderGrid()
            Response.ContentType = "application/vnd.ms-excel"
            ' Remove the charset from the Content-Type header.
            Response.Charset = ""
            ' Turn off the view state.
            Me.EnableViewState = False
            Dim tw As New System.IO.StringWriter
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Replace_WebControls(dgdDanhSach)
            ' Get the HTML for the control.
            dgdDanhSach.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub
    End Class


End Namespace
