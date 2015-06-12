Imports PortalQH
Imports System.Configuration
Imports System.IO
Public Class NewsDetails
    Inherits PortalQH.PortalModuleControl

    Public Property State() As String
        Get
            If Not ViewState("NewsState") Is Nothing Then
                Return CType(ViewState("NewsState"), String)
            Else
                Return "CREATE"
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("NewsState") = Value
        End Set
    End Property

    Public Property NewsID() As String
        Get
            If Not ViewState("NewsID") Is Nothing Then
                Return CType(ViewState("NewsID"), String)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("NewsID") = Value
        End Set
    End Property

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTieude As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLoaitin As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents lblUpload As System.Web.UI.WebControls.Label
    Protected WithEvents lnkbtnXemhinh As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlQuytrinh As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPublishDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgDate As System.Web.UI.WebControls.Image
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSource As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkHotnews As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rdoChuaDuyet As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdoDuyet As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdoTraLai As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTomtat As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents ftbNoidung As FreeTextBoxControls.FreeTextBox
    Protected WithEvents imgbtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnSave As System.Web.UI.WebControls.LinkButton
    Protected WithEvents imgbtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkbtnCancel As System.Web.UI.WebControls.LinkButton
    Protected WithEvents pnlNewsInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents imgupdImage As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label

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
        'Me.txtPublishDate.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtPublishDate.ClientID & ");")
        'Me.imgDate.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtPublishDate.ClientID & ", 'dd/mm/yyyy')")

        txtPublishDate.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtPublishDate);")
        imgDate.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtPublishDate, 'dd/mm/yyyy');")
        imgbtnSave.Attributes.Add("onclick", "javascript:return CheckNull();")
        If Not Me.IsPostBack Then
            Me.setupGUI()
            Me.getDropDownList()
            Me.State = Request("ctl")
            Me.txtPublishDate.Text = Format(Now, "dd/MM/yyyy")
            If Not Request("ID") Is Nothing Then
                Me.NewsID = Request("ID")
                Me.loadNews()
            End If
        End If
        txtTieude.Attributes.Add("ISNULL", "NOTNULL")
        ddlLoaitin.Attributes.Add("ISNULL", "NOTNULL")
        txtTomtat.Attributes.Add("ISNULL", "NOTNULL")
    End Sub

    Private Sub setupGUI()

        If Not Directory.Exists(Request.PhysicalApplicationPath & "news\" & ConfigurationSettings.AppSettings("NewsContentImgFolder")) Then
            Directory.CreateDirectory(Request.PhysicalApplicationPath & "news\" & ConfigurationSettings.AppSettings("NewsContentImgFolder"))
        End If
        Me.ftbNoidung.ImageGalleryPath = "~/news/" & ConfigurationSettings.AppSettings("NewsContentImgFolder")

        'Me.ftbNoidung.SupportFolder = "~/Inc/FreeTextBox/"
    End Sub

    Private Sub getDropDownList()
        BindControl.BindDropDownList(Me.ddlLoaitin, CType(ConfigurationSettings.AppSettings("db_web"), String) & "..sp_GetAllDMCATEGORIES", True, "", "V")
        BindControl.BindDropDownList(Me.ddlQuytrinh, CType(ConfigurationSettings.AppSettings("db_web"), String) & "..sp_GetAllDMWORKFLOWS", False, "", "V")
    End Sub

    Private Sub setupEditForm(ByVal mainCtrl As Control)
        For Each ctrl As Control In mainCtrl.Controls
            If ctrl.Controls.Count > 0 Then
                setupEditForm(ctrl)
            End If
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = (Me.State = "VIEW")
            End If
            If TypeOf ctrl Is DropDownList Then
                CType(ctrl, DropDownList).Enabled = (Me.State <> "VIEW")
            End If
        Next

        Me.ftbNoidung.EnableToolbars = (Me.State <> "VIEW")
        Me.ftbNoidung.ReadOnly = (Me.State = "VIEW")
        Me.lnkbtnSave.Visible = (Me.State <> "VIEW")
        Me.imgbtnSave.Visible = (Me.State <> "VIEW")
    End Sub

    'Luu image len server va tra ve ten file moi
    Private Function UploadFiles(ByVal objHtmlInputFile As HttpPostedFile) As String
        Dim objPortalController As New PortalController
        Dim RootPath As String = Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("NewsUploadFolder")

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

    Private Sub loadNews()
        Dim objNews As New NewsController
        Dim dsResult As New DataSet
        dsResult = objNews.getDataByKey(CType(ConfigurationSettings.AppSettings("db_web"), String), Me.NewsID, "V")
        gLoadControlValues(dsResult, Me)
        'Me.imgupdImage. = CStr(dsResult.Tables(0).Rows(0)("Image"))
        If Not dsResult.Tables(0).Rows(0)("ImageSave") Is DBNull.Value Then
            Me.lnkbtnXemhinh.Visible = True
            Me.lnkbtnXemhinh.Attributes.Clear()
            Me.lnkbtnXemhinh.Attributes.Add("onclick", "javascript:return viewImage('" & CStr(dsResult.Tables(0).Rows(0)("ImageSave")) & "');")
        Else
            Me.lnkbtnXemhinh.Visible = False
        End If
        If Not dsResult.Tables(0).Rows(0)("Noidung") Is DBNull.Value Then
            Me.ftbNoidung.Text = CStr(dsResult.Tables(0).Rows(0)("Noidung"))
        End If
        Me.setupEditForm(Me)
    End Sub

    Private Function checkRequire() As Boolean
        Dim result As Boolean
        result = True
        'If (Me.txtTieude.Text.Trim().Length <= 0) Then
        '    result = False
        'End If
        'If (Me.txtPublishDate.Text.Trim().Length <= 0) Then
        '    result = False
        'End If
        'If (Me.txtTomtat.Text.Trim().Length <= 0) Then
        '    result = False
        'End If
        Return result
    End Function

    Private Sub updNews()
        If Not Me.checkRequire() Then
            SetMSGBOX_HIDDEN(Me.Page, "Nhập thiếu thông tin")
        Else
            Dim srcImage As String = Path.GetFileName(Me.imgupdImage.PostedFile.FileName)
            Dim newImage As String
            newImage = ""
            If srcImage.Trim().Length > 0 Then
                newImage = Me.UploadFiles(Me.imgupdImage.PostedFile)
                If newImage.Length <= 0 Then
                    Me.lblUpload.Text = "Không lưu được hình minh họa"
                    Me.lblUpload.Visible = True
                    Return
                End If
                Me.lnkbtnXemhinh.Visible = True
                Me.lnkbtnXemhinh.CommandArgument = newImage
            End If
            Dim hotnews As String
            If Me.chkHotnews.Checked Then
                hotnews = "1"
            Else
                hotnews = "0"
            End If
            Dim objNews As New NewsController
            'Danh tin tuc co duoc duyet hay ko
            Dim Duyet As Integer = 0
            If Me.rdoDuyet.Checked Then
                Duyet = 1 'Duyet -> toi buoc ke tiep trong quy trinh
            ElseIf Me.rdoTraLai.Checked Then
                Duyet = 2 'Ko duyet -> ve lai buoc truoc trong quy trinh
            End If
            Dim result As Integer = -1

            If Me.State.Equals("ADD") Then
                result = objNews.insNews(CType(ConfigurationSettings.AppSettings("db_web"), String), srcImage, newImage, Me.imgupdImage.PostedFile.ContentLength, _
                    Me.imgupdImage.PostedFile.ContentType, "I", Me.txtTieude.Text.Trim(), Me.txtTomtat.Text.Trim(), _
                    Me.ftbNoidung.Text.Trim(), Me.txtSource.Text.Trim(), hotnews, Me.txtPublishDate.Text.Trim(), _
                    CType(Session("UserID"), String), Me.ddlLoaitin.SelectedValue, Me.ddlQuytrinh.SelectedValue, _
                    "V", Duyet, Me.VerticalHorizontal(newImage))
            Else
                If Me.State.Equals("EDIT") Then
                    result = objNews.updNews(CType(ConfigurationSettings.AppSettings("db_web"), String), Me.NewsID, srcImage, newImage, Me.imgupdImage.PostedFile.ContentLength, _
                            Me.imgupdImage.PostedFile.ContentType, "I", Me.txtTieude.Text.Trim(), Me.txtTomtat.Text.Trim(), _
                            Me.ftbNoidung.Text.Trim(), Me.txtSource.Text.Trim(), hotnews, Me.txtPublishDate.Text.Trim(), _
                            CType(Session("UserID"), String), Me.ddlLoaitin.SelectedValue, Me.ddlQuytrinh.SelectedValue, _
                            "V", Duyet, Me.VerticalHorizontal(newImage))
                End If
            End If
            If result <= -1 Then
                'Xoa file vua up len server
                Try
                    Dim imageFolder As String = ConfigurationSettings.AppSettings("NewsUploadFolder")
                    If File.Exists(imageFolder & newImage) Then
                        File.SetAttributes(imageFolder & newImage, FileAttributes.Normal)
                        File.Delete(imageFolder & newImage)
                    End If
                Catch ex As Exception
                    ProcessModuleLoadException(Me, ex)
                End Try
                SetMSGBOX_HIDDEN(Me.Page, "Cập nhật không thành công")
            Else
                Me.goBack()
            End If
        End If
    End Sub

    Private Function VerticalHorizontal(ByVal filename As String) As String
        Dim result As String
        result = ""
        If filename.Length > 0 Then
            Try
                Dim RootPath As String = Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("NewsUploadFolder")
                Dim bmp As New Bitmap(RootPath & filename)
                If bmp.PhysicalDimension.Height > bmp.PhysicalDimension.Width Then
                    result = "0" 'Vertical
                ElseIf bmp.PhysicalDimension.Height < bmp.PhysicalDimension.Width Then
                    result = "1" 'Horizontal
                Else
                    result = "2" 'Square
                End If
            Catch
                result = ""
            End Try
        End If
        Return result
    End Function

    Private Sub goBack()
        Dim strURL As String
        Dim _portalSettings As PortalSettings = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
        strURL = "~/default.aspx?tabid=" & CStr(_portalSettings.ActiveTab.TabId)
        Response.Redirect(strURL, True)
    End Sub

    Private Sub imgbtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnCancel.Click
        Me.goBack()
    End Sub

    Private Sub lnkbtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtnCancel.Click
        Me.goBack()
    End Sub

    Private Sub imgbtnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSave.Click
        Me.updNews()
    End Sub

    Private Sub lnkbtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnSave.Click
        Me.updNews()
    End Sub
End Class
