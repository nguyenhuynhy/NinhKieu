Imports PortalQH
Imports System.Configuration
Namespace CPVHQH
    Public Class HoSoKhong
        Inherits PortalQH.PortalModuleControl
        Private strControl As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents lblDanhSach As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayNopDon As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLoaiHoSo As System.Web.UI.WebControls.TextBox
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
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
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
                'SetStatusControl(blnStatus)

                Init_State()
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtNgayXuLy.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayXuLy);")
            imgNgayXuLy.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayXuLy, 'dd/mm/yyyy');")

            txtSoBienNhan.Attributes.Add("ISNULL", "NOTNULL")
            ddlLyDo.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayXuLy.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDungXuLy.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
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
            BindDropDownList_NguoiKy(ddlMaSoLanhDao)

            If Not Request.Params("ID") Is Nothing Then
                Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
                gLoadControlValues(objHoSoKhong.getHoSoKhongGiaiQuyet(Request.Params("ID")), Me)
                If txtNgayXuLy.Text = "" Then
                    txtNgayXuLy.Text = Format(Now(), "dd/MM/yyyy")
                End If
                objHoSoKhong = Nothing
            End If
            If txtHoSoKhongGiaiQuyetID.Text <> "" Then
                btnXoa.Visible = True
                btnIn.Visible = True
            Else
                btnXoa.Visible = False
                btnIn.Visible = False
            End If
        End Sub


        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            If txtHoSoKhongGiaiQuyetID.Text = "" And strControl <> "" Then
                Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, strControl), True)
            Else
                Response.Redirect(NavigateURL(), True)
            End If
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                'cập nhật hồ sơ không giải quyết
                Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
                If objHoSoKhong.updHoSoKhongGiaiQuyet(Me) <> "0" Then
                    SetMSGBOX_HIDDEN(Page, "Cập nhật không thành công!")
                    Exit Sub
                End If
                gLoadControlValues(objHoSoKhong.getHoSoKhongGiaiQuyet(Request.Params("ID")), Me)
                objHoSoKhong = Nothing
                SetStatusControl(False)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Select Case objHoSoKhong.delHoSoKhongGiaiQuyet(Me)
                Case "2" : Exit Sub
                Case "1"
                    SetMSGBOX_HIDDEN(Page, "Xóa không thành công!")
                Case "0"
                    
            End Select
            objHoSoKhong = Nothing
            If strControl <> "" Then
                Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text, strControl), True)
            Else
                Response.Redirect(NavigateURL(), True)
            End If
        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl")), True)
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
            Dim objHoSoKhong As New HoSoKhongGiaiQuyetController
            Dim ds As New DataSet
            'Dim strFileOutput As String
            'Dim strFileOpen As String
            'Dim strFileName As String
            'Dim strFileTemplate As String
            'Dim arrTable As New ArrayList
            'strFileName = GetParamByID("FileHoSoKhong", glbXMLFile)
            'strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            'strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & CType(Session.Item("UserName"), String) & Left(strFileName, Len(strFileName) - 4) & ".doc"
            'strFileOpen = strFileOutput
            'strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            'ds = objHoSoKhong.InHoSoKhongGiaiQuyet(txtHoSoTiepNhanID.Text)
            'ReportByWord(ds, strFileTemplate, strFileOutput)
            'Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            Dim Script As String
            Dim strFileNew As String
            Dim strServerPath As String
            Dim strFileTemplate As String
            Dim strPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            strPath = "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\DataReports\VanBan\" & CType(Session.Item("ItemCode"), String) & "\"
            strFileNew = "HSK" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"
            strFileTemplate = strServerPath & "\" & CType(Session.Item("ActiveDB"), String) & "\Reports\Templates\VanBan\" & CType(Session.Item("ItemCode"), String) & "\" & GetParamByID("FileHoSoKhong", glbXMLFile)
            ds = objHoSoKhong.InHoSoKhongGiaiQuyet(txtHoSoTiepNhanID.Text)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportFile(ds, strPath, strFileTemplate, strFileNew))
            Page.RegisterStartupScript("OpenWindow", Script)
        End Sub
    End Class
End Namespace