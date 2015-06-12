Imports PortalQH
Imports HSHC
Imports System.Configuration
Imports System.IO
Namespace PortalQH
    Public Class EditRMenu
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button
        Protected WithEvents lblLable1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlImgUp As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnUpLoad As System.Web.UI.WebControls.LinkButton
        Protected WithEvents chkLeftAligh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkTopAlign As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnLuu As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtUpLoadFile As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents txtWidth As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHeight As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFile As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        'Protected WithEvents objDyNamic As DyNamicControl
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblRong As System.Web.UI.WebControls.Label
        Protected WithEvents lblCao As System.Web.UI.WebControls.Label

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

            Try
                Dim objModules As New ModuleController
                If Page.IsPostBack = False Then
                    ' load the list of files found in the upload directory

                    If ModuleId <> -1 Then
                        Dim Settings As Hashtable
                        ' Get settings from the database
                        settings = PortalSettings.GetModuleSettings(ModuleId)
                        txtTieuDe.Text = CType(settings("TieuDe"), String)
                        'txtUpLoadFile.Value = CType(settings("imgName"), String)
                        txtFile.Text = CType(settings("imgName"), String)
                        txtNoiDung.Text = CType(settings("NoiDung"), String)
                        txtWidth.Text = CType(settings("Chieurong"), String)
                        txtHeight.Text = CType(Settings("ChieuCao"), String)
                    End If
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub

        Private Function UploadFiles(ByVal objHtmlInputFile As HttpPostedFile) As String
            Dim objPortalController As New PortalController
            Dim RootPath As String = Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder")

            Dim newfilename As String = Guid.NewGuid().ToString()
            Dim strExtension As String = Path.GetExtension(objHtmlInputFile.FileName)
            newfilename += strExtension
            Try
                'Kiem tra ten file da co chua, neu co roi thi tao ten moi
                While File.Exists(RootPath & newfilename)
                    newfilename = Guid.NewGuid().ToString() & strExtension
                End While
                objHtmlInputFile.SaveAs(RootPath & newfilename)
            Catch ex As Exception
                ' save error - can happen if the security settings are incorrect
                newfilename = ""
            End Try
            Return newfilename
        End Function
        ' Hàm uoload file mới
        Private Function UploadFiles(ByVal strPath As String, ByVal objHtmlInputFile As HttpPostedFile) As String
            Dim objPortalController As New PortalController
            Dim strMessage As String = ""

            Dim strFileName As String = strPath & Path.GetFileName(objHtmlInputFile.FileName)
            Dim strExtension As String = Replace(Path.GetExtension(strFileName), ".", "")

            If ((((objPortalController.GetPortalSpaceUsed(PortalId) + objHtmlInputFile.ContentLength) / 1000000) <= PortalSettings.HostSpace) Or PortalSettings.HostSpace = 0) Or (PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId) Then
                If InStr(1, "," & ConfigurationSettings.AppSettings("ImageFile").ToString.ToUpper, "," & strExtension.ToUpper) <> 0 Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    'If InStr(1, "," & PortalSettings.HostSettings("FileExtensions").ToString.ToUpper, "," & strExtension.ToUpper) <> 0 Or PortalSettings.ActiveTab.ParentId = PortalSettings.SuperTabId Then
                    'Save Uploaded file to server
                    Try
                        If File.Exists(strFileName) Then
                            File.SetAttributes(strFileName, FileAttributes.Normal)
                            File.Delete(strFileName)
                        End If
                        objHtmlInputFile.SaveAs(strFileName)
                        Return "0"
                    Catch
                        ' save error - can happen if the security settings are incorrect
                        strMessage += "<br>An Error Has Occurred When Attempting To Save The File " & strFileName & ". Please Contact Your Hosting Provider To Ensure The Appropriate Security Settings Have Been Enabled On The Server."
                        lblMessage.Text = "<Font color=Red>" & strMessage & "</Font>"
                        Return "1"
                    End Try
                Else
                    ' restricted file type
                    strMessage += "<br>File " & strFileName & " không hợp lệ. Những loại file hợp lệ ( *." & Replace(ConfigurationSettings.AppSettings("ImageFile").ToString, ",", ", *.") & " )."
                    lblMessage.Text = "<Font color=Red>" & strMessage & "</Font>"
                    Return "1"
                End If
            Else ' file too large
                strMessage += "<br> Dung lượng file quá lớn!"
                lblMessage.Text = "<Font color=Red>" & strMessage & "</Font>"
                Return "1"
            End If
        End Function
        Private Sub btnLuu_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLuu.Click
            ' Save images to upload folder
            Try
                Dim objModules As New ModuleController
                Dim strFileName As String = Path.GetFileName(Me.txtUpLoadFile.PostedFile.FileName)
                If txtUpLoadFile.Value.Equals("") Then
                    ' If no image 
                    If txtFile.Text = "" Then
                        ' set "" to imgName
                        objModules.UpdateModuleSetting(ModuleId, "imgName", "")
                        objModules.UpdateModuleSetting(ModuleId, "Chieurong", "")
                        objModules.UpdateModuleSetting(ModuleId, "ChieuCao", "")
                        If File.Exists(Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder") & CType(Settings("imgName"), String)) Then
                            File.Delete(Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder") & CType(Settings("imgName"), String))
                        End If
                    Else
                        objModules.UpdateModuleSetting(ModuleId, "Chieurong", txtWidth.Text)
                        objModules.UpdateModuleSetting(ModuleId, "ChieuCao", txtHeight.Text)
                    End If
                Else
                    'Del old file
                    'If File.Exists(Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder") & CType(Settings("imgName"), String)) Then
                    'File.Delete(Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder") & CType(Settings("imgName"), String))
                    objModules.UpdateModuleSetting(ModuleId, "imgName", "")
                    objModules.UpdateModuleSetting(ModuleId, "Chieurong", "")
                    objModules.UpdateModuleSetting(ModuleId, "ChieuCao", "")
                    'End If
                    'Upnew file
                    Dim Bool As String
                    Bool = UploadFiles(Request.PhysicalApplicationPath & ConfigurationSettings.AppSettings("RightMenuUpLoadImgFolder"), txtUpLoadFile.PostedFile)
                    ' upload success
                    If Bool = "0" Then
                        'update module
                        objModules.UpdateModuleSetting(ModuleId, "imgName", strFileName)
                        objModules.UpdateModuleSetting(ModuleId, "Chieurong", txtWidth.Text)
                        objModules.UpdateModuleSetting(ModuleId, "ChieuCao", txtHeight.Text)
                    End If
                End If
                objModules.UpdateModuleSetting(ModuleId, "TieuDe", txtTieuDe.Text)
                objModules.UpdateModuleSetting(ModuleId, "NoiDung", txtNoiDung.Text)
                'objModules.UpdateModuleSetting(ModuleId, "LeftTop", txtNoiDung.Text)
                Response.Redirect(NavigateURL(), True)
            Catch ex As Exception
                SetMSGBOX_HIDDEN(Page, "Có lỗi!!")
                'ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBoQua.Click
            ResetControls(Me)
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub
    End Class
End Namespace
