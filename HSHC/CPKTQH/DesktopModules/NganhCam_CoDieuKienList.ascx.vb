Imports PortalQH
Namespace CPKTQH
    Public Class NganhCam_CoDieuKienList
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlNganhCapTren As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNganhKD As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlLoai As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents chkToanQuan As System.Web.UI.WebControls.CheckBox


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
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtTuNgay);")
            btnTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtTuNgay, 'dd/mm/yyyy');")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtDenNgay);")
            btnDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtDenNgay, 'dd/mm/yyyy');")
            If Not Page.IsPostBack Then
                Init_State()
            End If
            LoadGrid()
        End Sub

        Private Sub Init_State()
            BindControl.BindDropDownList(ddlNganhCapTren, "DMNGANHCAPTREN")
            BindControl.BindDropDownList(ddlNganhKD, "sp_GetDMNGANHKDByNganhCapTren", "", ddlNganhCapTren.SelectedValue, 1) '1: lay mot item rong
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindLoai()

            txtTuNgay.Text = Format(Now(), "dd/MM/yyyy")

            Dim objNganhCamInfo As New NganhCam_CoDieuKienInfo
            Session("NganhCam_CoDieuKienInfo") = objNganhCamInfo
            GetValue()

            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objNganhCamInfo As New NganhCam_CoDieuKienInfo
            Dim objNganhCam As New NganhCam_CoDieuKienController

            If Session("NganhCam_CoDieuKienInfo") Is Nothing Then
                Response.Redirect(Request.RawUrl())
            End If

            objNganhCamInfo = CType(Session("NganhCam_CoDieuKienInfo"), NganhCam_CoDieuKienInfo)
            Select Case objNganhCamInfo.Loai
                Case "CAM"
                    ds = objNganhCam.getDanhSachNganhCam(objNganhCamInfo)
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Ngành kinh doanh,Ngành cấp trên,Cấm từ ngày, Cấm đến ngày", "400,400,150,150", False, True)
                Case "CDK"
                    ds = objNganhCam.getDanhSachNganhKDCoDieuKien(objNganhCamInfo)
                    BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Ngành kinh doanh,Ngành cấp trên,Nội dung,Có vốn tối thiểu,Có chứng chỉ", "200,0,400,50,50", False, True)
            End Select

            objNganhCamInfo = Nothing
            objNganhCam = Nothing
            ds = Nothing
        End Sub

        Private Sub GetValue()
            Dim objNganhCamInfo As New NganhCam_CoDieuKienInfo
            objNganhCamInfo = CType(Session("NganhCam_CoDieuKienInfo"), NganhCam_CoDieuKienInfo)
            With objNganhCamInfo
                .NganhCapTren = ddlNganhCapTren.SelectedValue
                .NganhKinhDoanh = ddlNganhKD.SelectedValue
                .Loai = ddlLoai.SelectedValue
                .TuNgay = txtTuNgay.Text
                .DenNgay = txtDenNgay.Text
                .ToanQuan = chkToanQuan.Checked
                .Duong = ddlDuong.SelectedValue
                .Phuong = ddlPhuong.SelectedValue
                If ddlLoai.SelectedValue = "CAM" Then
                    .URL = EditURL("ID", "VALUE", "NGANHCAM")
                Else
                    .URL = EditURL("ID", "VALUE", "KDCODIEUKIEN")
                End If
            End With
            Session("NganhCam_CoDieuKienInfo") = objNganhCamInfo
            objNganhCamInfo = Nothing
        End Sub

        Private Sub BindLoai()
            AddItem(ddlLoai, "CAM", "Cấm kinh doanh")
            AddItem(ddlLoai, "CDK", "Kinh doanh có điều kiện")
        End Sub

        Private Sub AddItem(ByVal ddl As DropDownList, ByVal itemvalue As String, ByVal itemtext As String)
            Dim item As New ListItem
            item.Value = itemvalue
            item.Text = itemtext
            ddl.Items.Add(item)
            item = Nothing
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

        Private Sub ddlNganhCapTren_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNganhCapTren.SelectedIndexChanged
            BindControl.BindDropDownList(ddlNganhKD, "sp_GetDMNGANHKDByNganhCapTren", "", ddlNganhCapTren.SelectedValue, 1) '1: lay mot item rong
        End Sub


        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            GetValue()
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            If ddlLoai.SelectedValue = "CAM" Then
                Response.Redirect(EditURL(, , "NGANHCAM"))
            Else
                Response.Redirect(EditURL(, , "KDCODIEUKIEN"))
            End If
        End Sub
    End Class
End Namespace