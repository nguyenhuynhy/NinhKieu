Imports PortalQH
Namespace CPKTQH
    Public Class NganhCam_CoDieuKien
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlNganhCapTren As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNganhKD As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkCamKD As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents rdlPhamVi As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblMain As System.Web.UI.WebControls.Label
        Protected WithEvents lblSub As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDuongPhuong As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtReLoad As System.Web.UI.WebControls.TextBox



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
            imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtTuNgay, 'dd/mm/yyyy');")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtDenNgay);")
            imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtDenNgay, 'dd/mm/yyyy');")

            Me.chkAll.Attributes.Add("onclick", "javascript: return select_deselectAll ('" & chkAll.ClientID & "');")

            If Not Me.IsPostBack Then
                Dim objDanhMuc As New DanhMucController
                Dim strMaNganh As String

                BindControl.BindDropDownList(ddlNganhCapTren, "DMNGANHCAPTREN")
                If Not Request.Params("ID") Is Nothing Then 'cập nhật
                    strMaNganh = CStr(Request.Params("ID"))
                    BindControl.BindDropDownList(ddlNganhKD, "DMNGANHKINHDOANH")
                    'enable nganh
                    ddlNganhCapTren.Enabled = False
                    ddlNganhKD.Enabled = False
                Else
                    BindControl.BindDropDownList(ddlNganhKD, "sp_GetDMNGANHKDByNganhCapTren", "", ddlNganhCapTren.SelectedValue, 0)
                End If

                LoadThongTinNganhCam(strMaNganh)
                txtTuNgay.Text = Format(Now(), "dd/MM/yyyy")
                objDanhMuc = Nothing

                txtreload.text = "1"
            End If
        End Sub


        Private Sub ddlNganhCapTren_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlNganhCapTren.SelectedIndexChanged
            BindControl.BindDropDownList(ddlNganhKD, "sp_GetDMNGANHKDByNganhCapTren", "", ddlNganhCapTren.SelectedValue, 0) '1: lay mot item rong
            LoadThongTinNganhCam(ddlNganhKD.SelectedValue)
        End Sub

        Private Sub ddlNganhKD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlNganhKD.SelectedIndexChanged
            LoadThongTinNganhCam(ddlNganhKD.SelectedValue)
        End Sub

        Private Sub rdlPhamVi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdlPhamVi.SelectedIndexChanged
            LoadGrid()
        End Sub

        Private Sub LoadThongTinNganhCam(ByVal strID As String)
            Dim objNganhCamCtrl As New NganhCam_CoDieuKienController
            Dim ds As DataSet

            ds = objNganhCamCtrl.getThongTinNganhCam(strID)
            gLoadControlValues(ds, Me)

            If chkCamKD.Checked = False Then
                SetEnableControl(False)
            Else
                SetEnableControl(True)
            End If
            ds = Nothing
            objNganhCamCtrl = Nothing
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objNganhCamCtrl As New NganhCam_CoDieuKienController

            Select Case rdlPhamVi.SelectedValue
                Case "Q"
                    dgdDuongPhuong.Enabled = False
                    lblMain.Text = "Tên phường"
                    lblSub.Text = "Tên đường"
                Case "P"
                    dgdDuongPhuong.Enabled = True
                    lblMain.Text = "Tên phường"
                    lblSub.Text = "Tên đường"
                Case "D"
                    dgdDuongPhuong.Enabled = True
                    lblMain.Text = "Tên đường"
                    lblSub.Text = "Tên phường"
            End Select

            'load du lieu len luoi
            ds = objNganhCamCtrl.getThongTinDuongPhuongCam(ddlNganhKD.SelectedValue, rdlPhamVi.SelectedValue)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    BindControl.BindDataGrid(ds, dgdDuongPhuong)
                End If
            End If

                ds = Nothing
                objNganhCamCtrl = Nothing
        End Sub

        Private Sub SetEnableControl(ByVal flag As Boolean)
            txtTuNgay.Enabled = flag
            imgTuNgay.Enabled = flag
            txtDenNgay.Enabled = flag
            imgDenNgay.Enabled = flag
            rdlPhamVi.Enabled = flag
            dgdDuongPhuong.Enabled = flag
            If rdlPhamVi.SelectedValue = "Q" Then
                dgdDuongPhuong.Enabled = False
            End If
        End Sub


        Private Sub chkCamKD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCamKD.CheckedChanged
            SetEnableControl(chkCamKD.Checked)
            If txtTuNgay.Text = "" Then
                txtTuNgay.Text = Format(Now(), "dd/MM/yyyy")
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objNganhCam As New NganhCam_CoDieuKienController
            Dim objNganhCamInfo As New NganhCam_CoDieuKienInfo
            Dim strChon, strXoa As String
            Dim i As Integer
            Dim flagChon, flagCam As Boolean
            Dim str, strMa As String

            'không cấm kinh doanh ngành này
            If Not chkCamKD.Checked Then
                objNganhCam.delNganhCam(ddlNganhKD.SelectedValue)
                Exit Sub
            End If

            'cấm kinh doanh ngành này
            If txtTuNgay.Text = "" Then
                SetMSGBOX_HIDDEN(Page, "Bạn phải nhập ngày bắt đầu cấm!")
                Exit Sub
            End If

            strChon = ""
            strXoa = ""
            If rdlPhamVi.SelectedValue = "Q" Then
                GoTo practice
            End If

            For i = 0 To dgdDuongPhuong.Items.Count - 1
                flagChon = CType(GetGridControlValue(i, dgdDuongPhuong, "chkXoa"), Boolean)
                strMa = CType(GetGridControlValue(i, dgdDuongPhuong, "lblMa"), String)
                str = CType(GetGridControlValue(i, dgdDuongPhuong, "lblGhiChu"), String)
                If flagChon = True Then
                    flagCam = True
                    If str = "" Then
                        strChon = strChon + strMa + ","
                    End If
                End If
                If flagChon = False And str <> "" Then
                    strXoa = strXoa + strMa + ","
                End If
            Next
            'không chọn đường phường cấm --> thông báo
            If Not flagCam Then
                SetMSGBOX_HIDDEN(Page, "Bạn phải chọn đường phường cấm kinh doanh ngành này!")
                Exit Sub
            End If

practice:
            With objNganhCamInfo
                .NganhKinhDoanh = ddlNganhKD.SelectedValue
                .Loai = rdlPhamVi.SelectedValue
                .MaDuongPhuong = strChon
                .TuNgay = txtTuNgay.Text
                .DenNgay = txtDenNgay.Text
            End With
            objNganhCam.updNganhCam(objNganhCamInfo)
            If strXoa <> "" Then
                objNganhCamInfo.MaDuongPhuong = strXoa
                objNganhCam.delDuongPhuongCam(objNganhCamInfo)
            End If

            objNganhCam = Nothing
            objNganhCamInfo = Nothing

            LoadGrid()
        End Sub

    End Class
End Namespace