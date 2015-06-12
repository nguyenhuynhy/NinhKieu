Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class HoSoKhong
        Inherits PortalQH.PortalModuleControl
        Private strControl As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgayXuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayXuLy As System.Web.UI.WebControls.Image
        Protected WithEvents txtNoiDungXuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblGioiTinh As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenLoaiHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayNopDon As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoSoKhongGiaiQuyetID As System.Web.UI.WebControls.TextBox



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
            strControl = Request.Params("oldControl")
            If Not Me.IsPostBack Then
                SetAttributesControl()
                Dim blnStatus As Boolean
                If Request.Params("AddNew") = "" Then
                    blnStatus = True
                Else
                    blnStatus = CBool(Request.Params("AddNew"))
                End If
                SetStatusControl(blnStatus)
                Init_State()
            End If

            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Dim strHSKGQ As String

            If txtNoiDungXuLy.Text <> "" Then
                btnXoa.Visible = True
                btnIn.Visible = True
            Else
                btnXoa.Visible = False
                btnIn.Visible = False
            End If

        End Sub
        Private Sub SetAttributesControl()
            txtNgayXuLy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayXuLy);")
            Me.txtNgayXuLy.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayXuLy.ClientID & ");")
            Me.txtNgayXuLy.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            imgNgayXuLy.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayXuLy, 'dd/mm/yyyy');")
            Me.txtNgayXuLy.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayXuLy.ClientID & ");")
            Me.txtNgayXuLy.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            ddlLyDo.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayXuLy.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDungXuLy.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nay khong?');")
            'GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "1", ctype(Session.Item("ActiveDB"),string), btnIn, Me)
        End Sub

        Private Sub SetStatusControl(ByVal IsAddNew As Boolean)
            btnXoa.Visible = Not IsAddNew
            btnIn.Visible = Not IsAddNew
        End Sub

        Private Sub Init_State()
            txtTabCode.Text = Request.Params("TabID")
            txtHoSoTiepNhanID.Text = Request.Params("ID")
            txtNguoiTacNghiep.Text = CStr(Session.Item("UserName"))
            txtNgayXuLy.Text = Format(Now(), "dd/MM/yyyy")
            txtLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            BindControl.BindDropDownList(ddlLyDo, "DMLYDO")

            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)

            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))

            If Not Request.Params("ID") Is Nothing Then
                Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
                gLoadControlValues(objHoSoKhong.getHoSoKhongGiaiQuyet(Request.Params("ID")), Me)
                If txtNgayXuLy.Text = "" Then
                    txtNgayXuLy.Text = Format(Now(), "dd/MM/yyyy")
                End If
                objHoSoKhong = Nothing
            End If
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            If txtHoSoKhongGiaiQuyetID.Text <> "" Then
                Response.Redirect(NavigateURL())
            Else
                Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, strControl), True)
            End If
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            'HoangLN
            If objHoSoKhong.updHoSoKhongGiaiQuyet(Me) = "1" Then
                SetMSGBOX_HIDDEN(Page, "Du lieu cap nhat khong thanh cong")
            End If

            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, Request.QueryString("ctl").ToString()) + "&oldControl=" + strControl)



        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            'HoangLN
            Dim strErr As String
            strErr = objHoSoKhong.delHoSoKhongGiaiQuyet(lblSoHoSo.Text, Request.QueryString("TabID").ToString, CStr(Session.Item("UserName")))
            If (strErr = "1") Then
                SetMSGBOX_HIDDEN(Page, "Du lieu xoa khong thanh cong")
            End If

            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, Request.QueryString("ctl").ToString()) + "&oldControl=" + strControl)

        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl")), True)
        End Sub

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
            'Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            'Dim ds As New DataSet
            'Dim strFileOutput As String
            'Dim strFileOpen As String
            'Dim strFileName As String
            'Dim strFileTemplate As String
            'Dim arrTable As New ArrayList
            'strFileName = GetParamByID("FileHoSoKhong", glbXMLFile)
            'strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("TemplatesCPKTQH") & strFileName
            'strFileOutput = ConfigurationSettings.AppSettings("DocumentsCPKTQH") & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            'strFileOpen = strFileOutput
            'strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            'ds = objHoSoKhong.InHoSoKhongGiaiQuyet(txtHoSoTiepNhanID.Text)
            'ReportByWord(ds, strFileTemplate, strFileOutput)
            'Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")

            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileHoSoKhong", glbXMLFile)
            strOutputFileName = "HoSoKhong" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objHoSoKhong.InHoSoKhongGiaiQuyet(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objHoSoKhong = Nothing
            ds = Nothing
        End Sub
    End Class
End Namespace