Imports PortalQH
Imports System.Configuration
Imports System.Web.UI.WebControls

Public Class SearchHoSoNhaDat
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
    Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
    Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
    Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtSoThua As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSoTo As System.Web.UI.WebControls.TextBox

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
        Dim glbFile As String
        Dim mSoNgay As Integer
        Dim obj As New SearchInfoController
        glbFile = ConfigurationSettings.AppSettings("PATH" & CType(Session.Item("ActiveDB"), String)) & "GLOBAL.xml"

        mSoNgay = CType(obj.GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
        If Request.Params("TuNgay") Is Nothing Then
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
        Else
            txtTuNgay.Text = Request.Params("TuNgay")
            txtDenNgay.Text = Request.Params("DenNgay")
        End If
        txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
        cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
        cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
        txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
        cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
        cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

        If Not Page.IsPostBack Then
            BindData()
        End If
        LoadGrid()
    End Sub

    Private Function GetDefaultLinhVuc() As String
        Dim TabId As String
        Dim ds As New DataSet
        Dim obj As New SearchInfoController
        If Not Request.Params("Tabid") Is Nothing Then
            TabId = Request.Params("Tabid")
        End If
        ds = obj.GetDefaultLinhVuc(TabId)
        If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
            Return CType(ds.Tables(0).Rows(0).Item(0), String)
        End If
        Return ""
    End Function

    Private Function GetDBByLinhVuc() As String
        Dim LinhVuc As String
        Dim ds As New DataSet
        Dim obj As New SearchInfoController
        If Not Request.Params("LinhVuc") Is Nothing Then
            LinhVuc = Request.Params("LinhVuc")
        Else
            LinhVuc = GetDefaultLinhVuc()
        End If
        ds = obj.GetDBByLinhVuc(LinhVuc)
        If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
            Return CType(ds.Tables(0).Rows(0).Item(0), String)
        End If
        Return ""
    End Function

    Private Sub BindData()
        Dim dsPhuong As New DataSet
        Dim dsDuong As New DataSet
        Dim objDanhMuc As New DanhMucController
        ' Lay linh vuc search
        Dim mLinhVuc As String
        If Not Request.Params("LinhVuc") Is Nothing Then
            mLinhVuc = Request.Params("LinhVuc")
        Else
            mLinhVuc = GetDefaultLinhVuc()
        End If

        dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
        dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
        BindDropDownList_Dataset(ddlPhuong, dsPhuong, "Ten", "Ma", True, "")
        BindDropDownList_Dataset(ddlDuong, dsDuong, "TenDuong", "MaDuong", True, "")
        If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
            With ctrlScriptComboFilter
                .ConditionID = ddlPhuong.ClientID
                .ConditionText = "Ten"
                .ConditionValue = "Ma"
                .ResultID = ddlDuong.ClientID
                .ResultText = "TenDuong"
                .ResultValue = "MaDuong"
                .ConditionDS = dsPhuong
                .ResultDS = dsDuong
            End With
            ddlPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
        Else
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
        End If
        BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDanhMucCBO", ConfigurationSettings.AppSettings("commonDB"), mLinhVuc & "_DMLOAIHOSO")

    End Sub

    Private Sub LoadGrid()
        Dim ds As DataSet
        Dim strURL As String
        Dim DB As String
        Dim mLinhVuc As String
        Dim objSearchInfo As New SearchInfoController
        DB = GetDBByLinhVuc()
        If Not Request.Params("LinhVuc") Is Nothing Then
            mLinhVuc = Request.Params("LinhVuc")
        Else
            mLinhVuc = GetDefaultLinhVuc()
        End If
        strURL = EditURL("ID", "VALUE", "CHITIETHOSO")
        If Not Session("ModuleIDOfPage") Is Nothing Then
            strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("ModuleIDOfPage").ToString)
        End If
        strURL = strURL & "&LoaiHoSo=" & DB & "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text & "&LinhVuc=" & mLinhVuc
        ds = objSearchInfo.GetThongTinTimKiemNhaDat(ConfigurationSettings.AppSettings("commonDB"), txtTuNgay.Text, txtDenNgay.Text, txtSoGiayPhep.Text.Trim, txtHoTen.Text.Trim, txtSoCMND.Text.Trim, txtSoNha.Text.Trim, ddlDuong.SelectedValue, ddlPhuong.SelectedValue, mLinhVuc, txtSoBienNhan.Text.Trim, ddlLoaiHoSo.SelectedValue, txtSoTo.Text.Trim, txtSoThua.Text.Trim, strURL)
        If ds.Tables(0).Rows.Count < dgdDanhSach.PageSize Then dgdDanhSach.CurrentPageIndex = 0
        BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "", "100,200,300,300,200", False, True)

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

    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

    Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
        LoadGrid()
    End Sub
End Class
