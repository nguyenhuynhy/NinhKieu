
Namespace PortalQH

    Public Class NhapMoiChucNang
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlItemCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTarget As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTargetChild As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMenuOrder As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemCode As System.Web.UI.WebControls.TextBox

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
            If Not Page.IsPostBack Then
                BindControl.BindDropDownList(ddlItemCode, "DMLINHVUCPQ")
            End If
            txtItemName.Attributes.Add("ISNULL", "NOTNULL")
            ddlItemCode.Attributes.Add("ISNULL", "NOTNULL")
            ddlItemCode.Attributes.Add("OnBlur", "javascript:SetItemName();")

        End Sub

        Public Sub CapNhatChucNang()
            Dim objMenuInfo As New MenuInfo
            Dim objMenu As New MenuController
            With objMenuInfo
                'ngantl edit
                If txtItemCode.Text = "" Then
                    .ItemCode = Trim(Left(ddlItemCode.SelectedItem.Value, 5))
                Else
                    .ItemCode = txtItemCode.Text
                End If
                'end ngantl edit
                .ItemName = Trim(txtItemName.Text)
                .MenuID = ""
                .MenuOrder = Trim(txtMenuOrder.Text)
                .TabCode = Trim(txtTabCode.Text)
                .Target = Trim(txtTarget.Text)
                .TargetChild = Trim(txtTargetChild.Text)
            End With
            objMenu.AddMenu(objMenuInfo)
            objMenu = Nothing
            objMenuInfo = Nothing
            ResetData()
        End Sub
        Public Sub ResetData()
            ResetControls(Me)
        End Sub
        Public Function GetItemID() As String
            Return Trim(Left(ddlItemCode.SelectedItem.Value, 5))
        End Function

    End Class
End Namespace
