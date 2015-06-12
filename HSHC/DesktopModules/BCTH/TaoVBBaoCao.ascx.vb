Imports PortalQH
Imports HSHC
Imports System.Configuration
Imports System.IO
Public Class TaoVBBaoCao
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents UpLoadFile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtUpLoadFile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblTinhTrang As System.Web.UI.WebControls.Label
    Protected WithEvents lblXemFile As System.Web.UI.WebControls.Label
    Protected WithEvents butFileName As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDonVi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlKyBaoCao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlNam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNgayLap As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgNgayXuLy As System.Web.UI.WebControls.Image
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTinhTrangHD As System.Web.UI.WebControls.Label
    Protected WithEvents chkTinhTrang As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl3 As System.Web.UI.WebControls.Label
    Protected WithEvents ftbNoidung As FreeTextBoxControls.FreeTextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnTrove As System.Web.UI.WebControls.ImageButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Property State() As String
        Get
            If Not ViewState("Sate") Is Nothing Then
                Return CType(ViewState("State"), String)
            Else
                Return "CREATE"
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("State") = Value
            State = Value
        End Set
    End Property
    Public Property VBBCID() As String
        Get
            If Not ViewState("VBBCID") Is Nothing Then
                Return CType(ViewState("VBBCID"), String)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("VBBCID") = Value
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Me.IsPostBack Then
            Init_State()
            BindControInMe()
            Me.State = Request("ctl")
            If Not Request("ID") Is Nothing Then
                Me.VBBCID = Request("ID")
                LoadVBBC()
            End If
        End If
    End Sub
    Private Sub Init_State()
        ddlNam.Attributes.Add("onblur", "javascript:isNumeric(" & ddlNam.ClientID & ", '0');")
        txtNgayLap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayLap.ClientID & ");")
        Me.imgNgayXuLy.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & imgNgayXuLy.ClientID & ", 'dd/mm/yyyy')")
        ddlNam.Attributes.Add("ISNULL", "NOTNULL")
        txtTieuDe.Attributes.Add("ISNULL", "NOTNULL")
        ddlKyBaoCao.Attributes.Add("ISNULL", "NOTNULL")
        ddlDonVi.Attributes.Add("ISNULL", "NOTNULL")
        Me.txtNgayLap.Text = Format(Now, "dd/MM/yyyy")
        btnSave.Attributes.Add("onclick", "javascript:return CheckNull();")
    End Sub
    Private Sub LoadVBBC()
        Dim VBBCCon As New VanBanBaoCaoController
        Dim ds As DataSet
        ds = VBBCCon.GetVanBanBaoCaoByKey(ConfigurationSettings.AppSettings("db_bcth"), Me.VBBCID)
        gLoadControlValues(ds, Me)
        If Not ds.Tables(0).Rows(0).Item("FileName") Is DBNull.Value Then
            Me.lblXemFile.Visible = True
            Me.butFileName.Visible = True
        Else
            Me.lblXemFile.Visible = False
            Me.butFileName.Visible = False
        End If
        If Not ds.Tables(0).Rows(0).Item("NoiDung") Is DBNull.Value Then
            ftbNoidung.Text = CStr(ds.Tables(0).Rows(0).Item("NoiDung"))
        End If
    End Sub
    Private Function UploadFiles(ByVal objHtmlInputFile As HttpPostedFile) As String
        Dim objPortalController As New PortalController
        Dim RootPath As String = Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("VBBCUploadFolder")

        Dim newfilename As String = Guid.NewGuid().ToString()
        'Dim strFileName As String = RootPath & Path.GetFileName(objHtmlInputFile.FileName)
        'Dim strExtension As String = Replace(Path.GetExtension(strFileName), ".", "")
        Dim strExtension As String = Path.GetExtension(objHtmlInputFile.FileName)
        newfilename += strExtension
        Try
            'Kiem tra ten file da co chua, neu co roi thi tao ten moi
            While File.Exists(RootPath & newfilename)
                newfilename = Guid.NewGuid().ToString() & strExtension
            End While
            'If File.Exists(strFileName) Then
            '    File.SetAttributes(strFileName, FileAttributes.Normal)
            '    File.Delete(strFileName)
            'End If
            objHtmlInputFile.SaveAs(RootPath & newfilename)
        Catch ex As Exception
            ' save error - can happen if the security settings are incorrect
            newfilename = ""
        End Try
        Return newfilename
    End Function
    Private Sub updateVanBan()
        Dim VBBCController As New VanBanBaoCaoController
        Dim VBBCInfo As New VanBanBaoCaoInfo
        Dim strFileDinhKem As String = Path.GetFileName(Me.txtUpLoadFile.PostedFile.FileName)
        Dim strFileSave As String
        Dim result As Integer = -1

        If strFileDinhKem.Trim().Length > 0 Then
            strFileSave = Me.UploadFiles(Me.txtUpLoadFile.PostedFile)
            If strFileSave.Length <= 0 Then
                SetMSGBOX_HIDDEN(Me.Page, "Không lưu được file đính kèm")
                Return
            End If
            'Me.lnkbtnXemhinh.Visible = True
            'Me.lnkbtnXemhinh.CommandArgument = newImage
        End If
        If Me.State.Equals("ADD") Or State.Equals("CREATE") Then
            result = VBBCController.InsVanBanBaoCao(ConfigurationSettings.AppSettings("db_bcth"), txtTieuDe.Text.Trim, _
                                                                                                            ftbNoidung.Text.ToString().Trim, _
                                                                                                            ddlDonVi.SelectedValue.ToString, _
                                                                                                            ddlKyBaoCao.SelectedValue.ToString, _
                                                                                                            ddlNam.SelectedValue.ToString, _
                                                                                                            Me.txtNgayLap.Text, _
                                                                                                            CType(Session("UserID"), String), _
                                                                                                            strFileDinhKem, _
                                                                                                            strFileSave, _
                                                                                                            Me.txtUpLoadFile.PostedFile.ContentLength, _
                                                                                                            Me.txtUpLoadFile.PostedFile.ContentType)

        Else
            'Update
            If Me.State.Equals("EDIT") Then
                result = VBBCController.UpdVanBanBaoCao(ConfigurationSettings.AppSettings("db_bcth"), txtTieuDe.Text.Trim, _
                                                                                                            ftbNoidung.Text.ToString().Trim, _
                                                                                                            CType(Request.Params("DonVi"), String), _
                                                                                                            CType(Request.Params("MaKyBaoCao"), String), _
                                                                                                            CType(Request.Params("Nam"), String), _
                                                                                                            Me.txtNgayLap.Text, _
                                                                                                            CType(Session("UserID"), String), _
                                                                                                            strFileDinhKem, _
                                                                                                            strFileSave, _
                                                                                                            Me.txtUpLoadFile.PostedFile.ContentLength, _
                                                                                                            Me.txtUpLoadFile.PostedFile.ContentType, _
                                                                                                            Me.VBBCID)

                'SetMSGBOX_HIDDEN(Me.Page, "Cập nhật không thành công")
            End If
        End If

        If result <= -1 Then
            'Xoa file vua up len server
            Try
                Dim imageFolder As String = ConfigurationSettings.AppSettings("NewsUploadFolder")
                If File.Exists(imageFolder & strFileSave) Then
                    File.SetAttributes(imageFolder & strFileSave, FileAttributes.Normal)
                    File.Delete(imageFolder & strFileSave)
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            SetMSGBOX_HIDDEN(Me.Page, "Cập nhật không thành công")
        Else
            Me.goBack()
        End If
    End Sub
    Private Sub goBack()
        Dim strURL As String
        Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
        strURL = "~/default.aspx?tabid=" & CStr(_portalSettings.ActiveTab.TabId)
        Response.Redirect(strURL, True)
    End Sub

    Private Sub BindControInMe()
        BindControl.BindDropDownList(ddlDonVi, "DonVi")
        BindControl.BindDropDownList_StoreProc(ddlKyBaoCao, True, "1", ConfigurationSettings.AppSettings("db_bcth") + "..sp_GetAllKyBaoCao")
        BindControl.BindDropDownList(ddlNam, "Nam", "", False, 0)
        ddlNam.SelectedValue = Now.Year().ToString
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        updateVanBan()
    End Sub
    Private Sub btnTrove_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Response.Redirect(NavigateURL())
    End Sub
End Class
