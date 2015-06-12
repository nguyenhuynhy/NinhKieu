Imports PortalQH
Imports HSHC
Imports System.Configuration
Imports System.IO
Namespace PortalQH
    Public Class DyNamicControl
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtFile As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtWidth As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHeight As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkLeftAligh As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkTopAlign As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUpLoadFile As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents lblRong As System.Web.UI.WebControls.Label
        Protected WithEvents lblCao As System.Web.UI.WebControls.Label
        Protected WithEvents btnLuu As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.ImageButton
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
            Try
                Dim objModules As New ModuleController
                If Page.IsPostBack = False Then
                    ' load the list of files found in the upload directory                    
                    If ModuleId <> -1 Then
                        Dim settings As Hashtable
                        ' Get settings from the database
                        settings = PortalSettings.GetModuleSettings(ModuleId)
                        txtTieuDe.Text = CType(settings("TieuDe"), String)
                        'txtUpLoadFile.Value = CType(settings("imgName"), String)
                        txtFile.Text = CType(settings("imgName"), String)
                        txtNoiDung.Text = CType(settings("NoiDung"), String)
                        txtWidth.Text = CType(settings("Chieurong"), String)
                        txtHeight.Text = CType(settings("ChieuCao"), String)
                        
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
        Private Sub btnLuu_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLuu.Click
            ' Save images to upload folder
            Try
                Dim strFileSave As String = Me.UploadFiles(Me.txtUpLoadFile.PostedFile)
                Dim strFileName As String = Path.GetFileName(Me.txtUpLoadFile.PostedFile.FileName)
                Dim strExtension As String = Path.GetExtension(Me.txtUpLoadFile.PostedFile.FileName)
                Dim strContentType As String = txtUpLoadFile.PostedFile.ContentType
                Dim intSize As Integer = txtUpLoadFile.Size

                ' Save FileName, FileSave,FileSize,Witdth,FileContent... to table name : RightMenu
                'DataProvider.Instance.ExecuteNonQueryStoreProc("sp_InsRMenu", PortalId, strFileName, strFileSave, _
                'strExtension, intSize, strContentType)

                If strFileName.Trim().Length < 0 Then
                    SetMSGBOX_HIDDEN(Me.Page, "Không lưu được file đính kèm!")
                    Return
                End If

                Dim objModules As New ModuleController
                objModules.UpdateModuleSetting(ModuleId, "imgSrc", strFileSave)
                objModules.UpdateModuleSetting(ModuleId, "imgName", strFileName)
                objModules.UpdateModuleSetting(ModuleId, "TieuDe", txtTieuDe.Text)
                objModules.UpdateModuleSetting(ModuleId, "NoiDung", txtNoiDung.Text)
                objModules.UpdateModuleSetting(ModuleId, "Chieurong", txtWidth.Text)
                objModules.UpdateModuleSetting(ModuleId, "ChieuCao", txtHeight.Text)
                'objModules.UpdateModuleSetting(ModuleId, "LeftTop", txtNoiDung.Text)
                Response.Redirect(NavigateURL(), True)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub


    End Class
End Namespace
