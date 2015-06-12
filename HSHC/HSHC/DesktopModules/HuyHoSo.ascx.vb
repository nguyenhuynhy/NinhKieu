Imports PortalQH
Namespace HSHC
    Public Class HuyHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoaiHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLyDoHuy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayHuy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiHuy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayTacNghiepCuoiCung As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayHuy As System.Web.UI.WebControls.HyperLink
        Protected WithEvents rdoReason As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rdoOtherReason As System.Web.UI.WebControls.RadioButton
        Protected WithEvents txtLyDoKhac As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnInVB As System.Web.UI.WebControls.LinkButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '==============================================================================
        '==============================================================================
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Put user code to initialize the page here
                Me.RegisterClientScript()
                
                If Not Page.IsPostBack Then
                    'lblTieuDe.Text = "Thông tin hủy hồ sơ " & UCase(Request.Params("Tenlv"))
                    lblTieuDe.Text = "Thông tin hủy hồ sơ"
                    Init_State()

                    'load các thông tin về biên nhận
                    Me.LoadData()

                    If txtNgayHuy.Text = "" Then
                        txtNgayHuy.Text = Format(Now(), "dd/MM/yyyy")
                    End If
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Dang ky javascript
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/5/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub RegisterClientScript()
            txtNgayHuy.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHuy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHuy.ClientID & ");")
            cmdNgayHuy.NavigateUrl = AdminDB.InvokePopupCal(txtNgayHuy)
            txtNgayHuy.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onClick", "javascript:return KiemTra();")
            Me.rdoReason.Attributes.Add("onclick", "javascript:SelectLyDo();")
            Me.rdoOtherReason.Attributes.Add("onclick", "javascript:InputLyDo();")
        End Sub

        Private Sub Init_State()
            BindControl.BindDropDownList(ddlLyDoHuy, "sp_GetDMLyDo", False, "", Request.Params("Malv"), "1")
            txtHoSoTiepNhanID.Text = Request.Params("ID")
            txtNguoiHuy.Text = CStr(Session.Item("UserName"))
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/5/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub LoadData()
            Dim HoSoHuyCtrl As New HoSoHuyController
            Dim ds As DataSet
            ds = HoSoHuyCtrl.GetChiTietHuyHoSo(Request.Params("ID"))
            gLoadControlValues(ds, Me)

            If (Me.txtLyDoKhac.Text.Trim().Length > 0) Then
                Me.rdoOtherReason.Checked = True
                Me.txtLyDoKhac.Enabled = Me.rdoOtherReason.Checked
                Me.ddlLyDoHuy.Enabled = Not Me.rdoOtherReason.Checked
            Else
                Me.rdoReason.Checked = True
                Me.rdoOtherReason.Checked = False
                Me.txtLyDoKhac.Enabled = Not Me.rdoReason.Checked
                Me.ddlLyDoHuy.Enabled = Me.rdoReason.Checked
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/5/2007	Updated, ReLoad du lieu sau khi update
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim TinhTrangCon As New TinhTrangHoSoController
            Dim objHoSoHuy As New HoSoHuyController
            Dim strHoSoHuyID As String
            Dim err As Integer
            Dim strDaHuy As String

            If Me.rdoReason.Checked And ddlLyDoHuy.SelectedValue = "" Then
                Me.LoadData()
                SetMSGBOX_HIDDEN(Page, "Ban phai chon ly do huy")
                Exit Sub
            End If

            If Me.rdoOtherReason.Checked And txtLyDoKhac.Text.Trim() = "" Then
                Me.LoadData()
                SetMSGBOX_HIDDEN(Page, "Ban phai nhap ly do huy")
                Exit Sub
            End If

            If txtNgayHuy.Text = "" Then
                Me.LoadData()
                SetMSGBOX_HIDDEN(Page, "Ban phai nhap ngay huy ho so")
                Exit Sub
            End If

            'kiểm tra hồ sơ đã hủy chưa
            strDaHuy = objHoSoHuy.IsHoSoDaHuy(txtHoSoTiepNhanID.Text)

            strHoSoHuyID = objHoSoHuy.UpdHoSoHuy(Me)

            If strHoSoHuyID <> "" Then
                'nếu hồ sơ chưa hủy thì cập nhật tình trạng hồ sơ
                If strDaHuy = "0" Then
                    err = TinhTrangCon.UpdTinhTrangHoSo(Request.Params("Malv"), _
                                Request.Params("TabID"), "HUY", txtNguoiHuy.Text, txtNguoiHuy.Text, txtNguoiHuy.Text, _
                                txtHoSoTiepNhanID.Text, "")
                    If err <> 0 Then
                        'xóa dong ho so huy da insert vao
                        objHoSoHuy.delHoSoHuy(strHoSoHuyID)
                        SetMSGBOX_HIDDEN(Page, "Cap nhat ho so khong thanh cong")
                    End If
                End If
            Else
                SetMSGBOX_HIDDEN(Page, "Cap nhat ho so khong thanh cong")
            End If

            Me.LoadData()
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(""))
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' In van ban huy ho so tiep nhan
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	6/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnInVB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInVB.Click
            Dim objHoSoHuy As New HoSoHuyController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileHuyHoSoTN", glbXMLFile)
            strOutputFileName = "ThongBaoHuyTN" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objHoSoHuy.InHoSoHuy(Me.txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, Request("Malv"), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objHoSoHuy = Nothing
            ds = Nothing
        End Sub
    End Class
End Namespace