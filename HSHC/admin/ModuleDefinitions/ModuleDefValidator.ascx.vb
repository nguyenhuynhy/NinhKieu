Imports System.IO

Namespace PortalQH
    Public Class ModuleDefValidator
        Inherits PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents cmdBrowse As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents lnkValidate As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lstResults As System.Web.UI.WebControls.DataList

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
        End Sub

        Private Sub lnkValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkValidate.Click
            If Page.IsPostBack Then
                If cmdBrowse.PostedFile.FileName <> "" Then
                    Dim strExtension As String = Path.GetExtension(cmdBrowse.PostedFile.FileName)
                    Dim Messages As New ArrayList

                    Dim postedFile As String = Path.GetFileName(cmdBrowse.PostedFile.FileName)
                    If strExtension.ToLower = ".dnn" Then
                        Dim xval As New ModuleDefinitionValidator
                        xval.LoadXML(cmdBrowse.PostedFile.InputStream)
                        Dim filename As String = Server.MapPath("admin/PaUploader/ModuleDef_V2.xsd")
                        xval.LoadSchema(filename)
                        If xval.IsValid Then
                            Messages.Add(String.Format("{0} is a valid Module Definition File.", postedFile))
                        Else
                            Messages.AddRange(xval.Errors)
                        End If
                    Else
                        Messages.Add("Invalid File Extension For Custom Module Definition " & postedFile)
                    End If
                    lstResults.Visible = True
                    lstResults.DataSource = Messages
                    lstResults.DataBind()
                End If
            End If


        End Sub
    End Class
End Namespace
