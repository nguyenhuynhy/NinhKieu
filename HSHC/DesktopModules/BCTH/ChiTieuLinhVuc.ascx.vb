Imports System.Configuration
Imports System.Xml
Imports System.Net
Imports System.Math
Imports PortalQH
Namespace HSHC
    Public Class ChiTieuLinhVuc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label0 As System.Web.UI.WebControls.Label
        Protected WithEvents lbl0 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents table1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaChiTieu As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents label7 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDongHienThi As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnBoqua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnChonTatCa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoChon As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlDonVi As System.Web.UI.WebControls.DropDownList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object
        Protected WithEvents btnLoc1 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents btnLoc As System.Web.UI.WebControls.ImageButton
        Dim strArrMaCT As String

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            'Session.Item("strArrCT") = ""
        End Sub

#End Region
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then
                BindControls()
                Init_State()
                LoadGrid(ddlDonVi.SelectedValue, "")
            End If
        End Sub
        Private Sub BindControls()
            BindControl.BindDropDownList(ddlDonVi, "DonVi", "", False, 0)
            BindControl.BindDropDownList_StoreProc(ddlMaChiTieu, True, "", ConfigurationSettings.AppSettings("db_bcth").ToString + "..sp_GetDMChiTieuByGroup")
        End Sub
        Private Sub Init_State()
            txtSoDongHienThi.Text = CStr(GetSoDongHienThiLuoi())
            txtSoDongHienThi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
            btnChonTatCa.Attributes.Add("OnClick", "javascript:return AllCheck();")
            btnBoChon.Attributes.Add("Onclick", "javascript:return AllNoCheck();")
            ddlDonVi.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaChiTieu.Attributes.Add("ISNULL", "NOTNULL")
            btnLoc.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnThemMoi.Attributes.Add("onclick", "javascript:return CheckNull();")
            Session.Add("strArrCT", ",")
        End Sub
        Private Sub txtSoDongHienThi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDongHienThi.TextChanged
            If Not IsInteger(txtSoDongHienThi.Text) Or Trim(txtSoDongHienThi.Text) = "" Or Val(txtSoDongHienThi.Text) = 0 Then
                txtSoDongHienThi.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDongHienThi.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid(ddlDonVi.SelectedValue, Session.Item("strArrCT").ToString)
            End If
        End Sub
        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid(ddlDonVi.SelectedValue, Session.Item("strArrCT").ToString)
        End Sub
        Private Sub LoadGrid(ByVal strMaDonVi As String, ByVal strGroupID As String)
            Dim objDMChiTieu As New ChiTieuLinhVucController
            Dim ds As DataSet
            ds = objDMChiTieu.GetDonViChiTieu(ConfigurationSettings.AppSettings("db_bcth").ToString(), strGroupID, strMaDonVi)
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            AddAttributeCheckBox()
            ' Goi thu tuc bind cac check box
            BindCheckBox()
            objDMChiTieu = Nothing
            ds = Nothing
        End Sub
        Private Sub BindCheckBox()
            ' Thu tuc nay dung de bind cac check box ma chi tieu da duoc gan cho don vi do
            Dim objDMChiTieu As New ChiTieuLinhVucController
            Dim ds As DataSet : Dim i, j As Integer
            ds = objDMChiTieu.GetAllChiTieuOfDonVi(ConfigurationSettings.AppSettings("db_bcth").ToString, ddlDonVi.SelectedValue.ToString)
            For i = 0 To dgdDanhSach.Items.Count - 1
                For j = 0 To ds.Tables(0).Rows.Count - 1
                    If GetGridControlValue(i, dgdDanhSach, "txtMaCT") = ds.Tables(0).Rows(j).Item(0).ToString Then
                        CType(dgdDanhSach.Items(i).FindControl("chkChon"), CheckBox).Checked = True
                    End If
                Next j
            Next i
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThemMoi.Click
            'Goi thu tuc savegridhoso de luu tat ca nhung chi tieu duoc chon
            SaveGridHoSo()
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid(ddlDonVi.SelectedValue, "")
        End Sub
        Private Sub SaveGridHoSo()

            Dim ChiTieuLVCon As New ChiTieuLinhVucController
            Dim i As Integer : Dim flgCheck As Boolean
            ' Xoa tat ca nhung chi tieu ung voi don vi hien hanh
            For i = 0 To dgdDanhSach.Items.Count - 1
                flgCheck = CBool(GetGridControlValue(i, dgdDanhSach, "chkChon"))
                If flgCheck = False Then
                    ChiTieuLVCon.XoaChiTieu(ConfigurationSettings.AppSettings("db_bcth"), GetGridControlValue(i, dgdDanhSach, "txtMaCT").ToString, ddlDonVi.SelectedValue.ToString)
                End If
            Next
            ' save tat ca nhung chi tieu duoc chon
            For i = 0 To dgdDanhSach.Items.Count - 1
                flgCheck = CBool(GetGridControlValue(i, dgdDanhSach, "chkChon"))
                If flgCheck = True Then
                    ChiTieuLVCon.AddChiTieuLinhVuc(ConfigurationSettings.AppSettings("db_bcth"), GetGridControlValue(i, dgdDanhSach, "txtMaCT").ToString, ddlDonVi.SelectedValue.ToString)
                End If
            Next
        End Sub
        Private Sub btnLoc_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLoc.Click
            strArrMaCT = Session.Item("strArrCT").ToString + ddlMaChiTieu.SelectedValue + ","
            Session.Item("strArrCT") = strArrMaCT
            LoadGrid(ddlDonVi.SelectedValue, strArrMaCT)
        End Sub
        Private Sub ddlDonVi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDonVi.SelectedIndexChanged
            strArrMaCT = ""
            Session.Contents().Item("strArrCT") = ","
            LoadGrid(ddlDonVi.SelectedValue, strArrMaCT)
            'Session.Item("strArrCT") = Nothing
        End Sub
        Private Sub AddAttributeCheckBox()
            ' Gan cac thuoc tinh kiem tra cho cac check box
            Dim obj As TextBox : Dim chkCon As CheckBox
            Dim chkCha As CheckBox
            Dim MaCha As String
            Dim i, j As Integer
            If dgdDanhSach.Items.Count = 0 Then Exit Sub
            For i = dgdDanhSach.Items.Count - 1 To 1 Step -1
                chkCon = CType(dgdDanhSach.Items(i).FindControl("chkChon"), CheckBox)
                chkCon.Attributes.Add("OnClick", "javascript:return checkParent('" & chkCon.ClientID & "');")
                'chkCon.Attributes.Add("OnChange", "javascript:return checkedParent('" & chkCon.ClientID & "','" & chkCha.ClientID & "','" & MaCha & "');")
            Next i
        End Sub
    End Class
End Namespace