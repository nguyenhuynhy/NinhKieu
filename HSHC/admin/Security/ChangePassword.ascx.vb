Imports System.Web.Security

Namespace PortalQH
    Public MustInherit Class ChangePassword
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtNewPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCookie As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnHuyBo As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtOldPassword As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtConfirm As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVerification As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdSendPassword As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblLogin As System.Web.UI.WebControls.Label
        Protected WithEvents rowVerification1 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents rowVerification2 As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents btnCapNhat_Tmp As System.Web.UI.WebControls.ImageButton

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
            btnCapNhat.Attributes.Add("onclick", "javascript:return checkSamePassword();")
        End Sub

        Private Sub SetNullControls()
            Me.txtConfirm.Text = ""
            Me.txtNewPassword.Text = ""
            Me.txtOldPassword.Text = ""
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objUser As New UserController
            Dim objSecurity As New PortalSecurity
            Dim dr As IDataReader
            dr = objUser.ChangePassword(Session.Item("UserName").ToString(), _
                                        objSecurity.Encrypt(txtOldPassword.Text), _
                                        objSecurity.Encrypt(txtNewPassword.Text))
            If dr.Read Then
                Dim succ As Integer
                succ = CType(dr("succ"), Integer)
                If succ = 1 Then
                    Skin.AddModuleMessage(Me, "Mật khẩu đã được thay đổi.", Skins.ModuleMessage.ModuleMessageType.GreenSuccess)
                    SetNullControls()
                Else
                    Skin.AddModuleMessage(Me, "Mật khẩu cũ sai rồi!", Skins.ModuleMessage.ModuleMessageType.RedError)
                    SetFocus(Page, txtOldPassword)
                End If
            End If
            dr.Close()
        End Sub

        Private Sub btnCapNhat_Tmp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat_Tmp.Click
            btnCapNhat_Click(sender, e)
        End Sub
    End Class
End Namespace
