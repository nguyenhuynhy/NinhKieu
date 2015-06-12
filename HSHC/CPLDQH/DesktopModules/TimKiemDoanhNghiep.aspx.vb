Imports PortalQH
Imports System.Configuration

Namespace CPLDQH

    '============================================================================
    '=Người tạo : TuanNH                                                        =
    '=Ngày tạo  : 12/04/2006                                                    =
    '=Mục đích  : Tìm kiếm doanh nghiệp cho phần khai báo tăng giảm lao động    =
    '============================================================================

    Public Class TimKiemDoanhNghiep
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents txtIsHuy As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnChon As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtTenChuDonVi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSuDungLaoDongIDChon As System.Web.UI.WebControls.TextBox

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
            If Not Me.IsPostBack Then
                BindData()
                If Not Request.Params("IsHuy") Is Nothing Then
                    txtIsHuy.Text = Request.Params("IsHuy").ToString
                Else
                    txtIsHuy.Text = "0"
                End If
            End If
            LoadGrid()
            btnTroVe.Attributes.Add("onclick", "javascript:window.close();")
            btnChon.Attributes.Add("onclick", "javascript:form1_onsubmit();")
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("StartScript", ReLoadComboFilter(ctrlScriptComboFilter, ddlDuong))
            End If
        End Sub

        Private Sub BindData()
            'Doan loc duong theo phuong
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
            Dim objDanhMuc As New DanhMucController
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
            End If

            '-------------------------------------------------------------
        End Sub

        Public Function DanhSachGiayCNDKKD() As DataSet
            Dim ds As New DataSet
            Dim objTimKiemDoanhNghiep As New SuDungLaoDongController

            ds = objTimKiemDoanhNghiep.TimKiemDoanhNghiep(Trim(txtHoTen.Text), Trim(txtTenChuDonVi.Text), txtSoNha.Text, ddlDuong.SelectedValue, ddlPhuong.SelectedValue)
            Return ds
        End Function
        Private Sub LoadGrid()
            Dim strLoaiHoSo, strURL As String
            Dim ds As New DataSet
            ds = DanhSachGiayCNDKKD()

            BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Hồ sơ ID, Tên đơn vị, Tên chủ đơn vị, Địa chỉ, Tổng số lao động, Tổng số lao động nữ", "80,200,140,200,90,90", False, False)

            'BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Số GCN ĐKKD, GiayCNDKKDID, Ngày Cấp, Ngày hết hạn, Họ tên, Bảng hiệu, Địa chỉ kinh doanh,Mặt hàng kinh doanh, Vốn KD,Tình trạng", "80,0,60,0,100,150,150,200,100,0", False, False)

            AddAttributeCheckbox()
        End Sub
        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
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

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            LoadGrid()
        End Sub

    End Class

End Namespace