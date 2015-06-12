Imports PortalQH
Namespace CPKTQH
    Public Class ChiTietDuongPhuongCam
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblNganhCapTren As System.Web.UI.WebControls.Label
        Protected WithEvents lblNganhKD As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoai As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents lblTenDuongPhuong As System.Web.UI.WebControls.Label
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblMain As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDuongPhuong As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton



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

            btnTroVe.Attributes.Add("onclick", "javascript:window.close();")
            Me.chkAll.Attributes.Add("onclick", "javascript:return select_deselectAll ('" & chkAll.ClientID & "');")

            If Not Page.IsPostBack Then
                lblNganhCapTren.Text = CStr(Request.Params("NganhCT"))
                lblNganhKD.Text = CStr(Request.Params("NganhKD"))
                Select Case CStr(Request.Params("Loai"))
                    Case "P"
                        lblLoai.Text = "Cấm theo phường"
                        lblMain.Text = "Tên đường"
                    Case "D"
                        lblLoai.Text = "Cấm theo đường"
                        lblMain.Text = "Tên phường"
                End Select
                txtTuNgay.Text = CStr(Request.Params("TuNgay"))
                txtDenNgay.Text = CStr(Request.Params("DenNgay"))
                lblTenDuongPhuong.Text = CStr(Request.Params("Ten"))

                LoadGrid()

                If txtTuNgay.Text <> "" Then
                    txtTuNgay.ReadOnly = True
                    txtDenNgay.ReadOnly = True
                    imgTuNgay.Enabled = False
                    imgDenNgay.Enabled = False
                End If
            End If

        End Sub

        Private Sub LoadGrid()
            Dim objNganhCam As New NganhCam_CoDieuKienController
            Dim ds As DataSet

            ds = objNganhCam.getThongTinChiTietDuongPhuongCam(CStr(Request.Params("MaNganhKD")), CStr(Request.Params("Loai")), CStr(Request.Params("Ma")))
            BindControl.BindDataGrid(ds, dgdDuongPhuong)

            ds = Nothing
            objNganhCam = Nothing
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            If txtTuNgay.Text = "" Then
                SetMSGBOX_HIDDEN(Page, "Bạn phải nhập thời gian bắt đầu cấm kinh doanh ngành này!")
                Exit Sub
            End If

            Dim objNganhCam As New NganhCam_CoDieuKienController
            Dim objNganhCamInfo As New NganhCam_CoDieuKienInfo
            Dim strChon, strMa As String
            Dim i As Integer
            Dim flagChon As Boolean

            strChon = ""
            For i = 0 To dgdDuongPhuong.Items.Count - 1
                strMa = CType(GetGridControlValue(i, dgdDuongPhuong, "lblMa"), String)
                If CType(GetGridControlValue(i, dgdDuongPhuong, "chkXoa"), Boolean) Then
                    flagChon = True
                    strChon = strChon + strMa + ","
                End If
            Next

            With objNganhCamInfo
                .Loai = CStr(Request.Params("Loai"))
                .TuNgay = txtTuNgay.Text
                .DenNgay = txtDenNgay.Text
                .NganhKinhDoanh = CStr(Request.Params("MaNganhKD"))
                If .Loai = "D" Then
                    .Duong = CStr(Request.Params("Ma"))
                    .Phuong = strChon
                Else
                    .Duong = strChon
                    .Phuong = CStr(Request.Params("Ma"))
                End If
            End With
            objNganhCam.updDuongPhuongCam(objNganhCamInfo)

            SetMSGBOX_HIDDEN(Page, "Đã cập nhật thành công!")

            Response.Write("<script language=javascript>window.opener.document.forms[0].submit();window.opener.refresh;window.close();</script>")

            objNganhCam = Nothing
            objNganhCamInfo = Nothing
            '            private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e) { 
            'Response.Write("<script language=javascript>\n"); 
            'if (Request.QueryString["single"] == "false"){ 
            'Response.Write("window.opener.document['" + Request.QueryString["form"].ToString() + "']['" + Request.QueryString["field"].ToString() + "'].value+='" + DropDownList1.SelectedItem.Value.ToString() + ";';\n"); 
            '} 
            'else{ 
            'Response.Write("window.opener.document['" + Request.QueryString["form"].ToString() + "']['" + Request.QueryString["field"].ToString() + "'].value ='" + DropDownList1.SelectedItem.Value.ToString() + "';\n"); 
            '} 
            'Response.Write("window.opener.document['" + Request.QueryString["form"].ToString() + "']['" + Request.QueryString["field"].ToString() + "'].focus();\n"); 
            'Response.Write("window.opener.document['" + Request.QueryString["form"].ToString() + "']['" + Request.QueryString["field"].ToString() + "'].blur();\n"); 
            'Response.Write("self.close();\n"); 
            'Response.Write("</script>\n"); 
            '} 
        End Sub
    End Class
End Namespace