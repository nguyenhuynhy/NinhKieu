Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class YeuCauBSHS
        Inherits PortalQH.PortalModuleControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtNgayYeuCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNgayBoSung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLanhDao As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents imgNgayYeuCau As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungYeuCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNguoiSuDung As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoBoSungID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaTinhTrangXuLy As System.Web.UI.WebControls.DropDownList

        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInXacMinh As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdNgayYeuCau As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private strControl As String

        Const HSHCKEYWORD As String = "HSHCQH" 'Keyword of HSHC
        'Const HSHCPATH As String = "HSHC" 'Physical path of HSHC, use when get report file from HSHC

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            SetAttribute()
            lblTieuDe.Text = "Yêu cầu bổ sung hồ sơ" & UCase(Request.Params("Tenlv"))
            strControl = Request.Params("oldControl")
            If Not Me.IsPostBack Then
                Dim blnStatus As Boolean
                BindDropDownList_NguoiKy(ddlMaNguoiSuDung)
                BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangXuLy, False, "", "sp_getTinhTrangHoSoByLoai", CType(Session.Item("ItemCode"), String), Request.Params("tabid"), "BHS")
                If ddlMaTinhTrangXuLy.Items.Count > 0 Then ddlMaTinhTrangXuLy.SelectedIndex = 0
                If Not Request.Params("ID") Is Nothing Then
                    txtSoBienNhan.Text = Request.Params("ID").ToString
                End If
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
                If txtNgayYeuCau.Text = "" Then
                    txtNgayYeuCau.Text = NgayHienTai()
                End If
                If Request.Params("AddNew") = "" Then
                    blnStatus = True
                Else
                    blnStatus = CBool(Request.Params("AddNew"))
                End If
                SetStatusControl(blnStatus)
            End If
            If txtNoiDungYeuCau.Text <> "" Then
                btnXoa.Visible = True
                btnIn.Visible = True
            Else
                btnXoa.Visible = False
                btnIn.Visible = False
            End If
            If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("KeyWord_CPXD") Then
                btnInXacMinh.Visible = False
            End If
            If txtSoNgayBoSung.Text = "" Then txtSoNgayBoSung.Text = "30"
            Me.btnIn.Visible = (Me.txtNoiDungYeuCau.Text.Trim() <> "")
            'Me.btnXoa.Visible = (Me.txtHoSoBoSungID.Text <> "")
        End Sub
        Private Sub SetStatusControl(ByVal IsAddNew As Boolean)
            btnXoa.Visible = Not IsAddNew
            btnIn.Visible = Not IsAddNew
        End Sub
        Private Sub SetAttribute()
            txtNgayYeuCau.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayYeuCau);")

            txtNgayYeuCau.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayYeuCau.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayYeuCau.ClientID & ");")
            cmdNgayYeuCau.NavigateUrl = AdminDB.InvokePopupCal(txtNgayYeuCau)

            txtSoNgayBoSung.Attributes.Add("onblur", "javascript:CheckSoNgay(" & txtSoNgayBoSung.ClientID & ");")
            txtSoNgayBoSung.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDungYeuCau.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            ' GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "BS", "HSHC", btnIn, Me)
        End Sub


        Private Sub LoadData()
            Dim objHoSoBoSung As New HoSoBoSungController
            Dim rs As DataSet
            rs = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(Me)
            gLoadControlValues(rs, Me)

        End Sub


        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim objHoSoBoSung As New HoSoBoSungController
            txtHoSoBoSungID.Text = objHoSoBoSung.AddHoSoBoSung(Me)
            'Me.btnXoa.Visible = (Me.txtHoSoBoSungID.Text <> "")
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            If txtHoSoBoSungID.Text = "" Then
                If strControl <> "" Then
                    Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, strControl), True)
                Else
                    Response.Redirect(NavigateURL(), True)
                End If
            Else
                Response.Redirect(NavigateURL(), True)
            End If
        End Sub

        Private Function f_ExportFile(ByVal ds As DataSet, ByVal Path As String, ByVal FileTemplate As String, ByVal FileExport As String) As String
            Dim url As String
            Dim Script As String
            Dim Tool As OfficeTools.WordTools = New OfficeTools.WordTools

            If Right(FileTemplate, 4) <> ".doc" Then
                Exit Function
            End If

            Tool.OpenFile(FileTemplate)
            Tool.AddToMergeField(ds, 0)

            f_ExportFile = Tool.DoAll(GetAbsoluteServerPath(Request), Path, FileExport)
            Tool.CloseFile()
        End Function

        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click

            Dim objHoSoBoSung As New HoSoBoSungController
            Dim ds As New DataSet
            'Dim strFileTemplate As String
            'Dim strFileOutput As String
            'Dim strFileOpen As String
            'Dim strFileName As String
            'strFileName = GetParamByID("FileYeuCauBoSung" & CType(Session.Item_u34 ?ActiveDB"), String), glbXMLFile)
            'strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            'strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            'strFileOpen = strFileOutput
            'strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            'ds = objHoSoBoSung.InThongBaoYeuCauBoSungHoSo(txtHoSoTiepNhanID.Text)
            'ReportByWord(ds, strFileTemplate, strFileOutput)
            'Res_u111 ?nse.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            Dim Script As String
            Dim strFileNew As String
            Dim strServerPath As String
            Dim strFileTemplate As String
            Dim strPath As String
            Dim strTemplateFileName As String

            'strServerPath = Request.MapPath(Request.ApplicationPath)
            strTemplateFileName = GetParamByID("FileYeuCauBoSung" & CType(Session.Item("ActiveDB"), String), glbXMLFile)
            strFileNew = "YBS" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
            '
            'If CType(Session.Item("ActiveDB"), String) <> HSHCKEYWORD Then
            '    strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileYeuCauBoSung" & CType(Session.Item("ActiveDB"), String), glbXMLFile)
            '    strPath = "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            'Else
            '    strFileTemplate = strServerPath & "\" & ConfigurationSettings.AppSettings("FolderPathHSHCQH") & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileYeuCauBoSung" & CType(Session.Item("ActiveDB"), String), glbXMLFile)
            '    strPath = "\" & ConfigurationSettings.AppSettings("FolderPathHSHCQH") & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            'End If
            ds = objHoSoBoSung.InThongBaoYeuCauBoSungHoSo(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, CType(Session.Item("ItemCode"), String), strTemplateFileName, strFileNew)) ',f_ExportFile(ds, strPath, strFileTemplate, strFileNew))
            Page.RegisterStartupScript("OpenWindow", Script)
            objHoSoBoSung = Nothing
            ds = Nothing

        End Sub


        Private Sub btnInXacMinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInXacMinh.Click
            Dim objHoSoBoSung As New HoSoBoSungController
            Dim ds As New DataSet
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            Dim strFileName As String
            strFileName = GetParamByID("FileHenXacMinh" & CType(Session.Item("ActiveDB"), String), glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objHoSoBoSung.InThongBaoYeuCauBoSungHoSo(txtHoSoTiepNhanID.Text)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
        End Sub

        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objHoSoBoSung As New HoSoBoSungController
            If txtHoSoBoSungID.Text <> "" Then
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
                objHoSoBoSung.DelHoSoBoDung(txtSoBienNhan.Text, Request.Params("TabId"), txtMaNguoiTacNghiep.Text)
            End If
            Response.Redirect(EditURL("ID", txtSoBienNhan.Text, Request.QueryString("ctl").ToString()) + "&oldControl=" + strControl)
        End Sub
    End Class
End Namespace