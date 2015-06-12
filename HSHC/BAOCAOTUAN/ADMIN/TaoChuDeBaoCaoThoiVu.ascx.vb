Imports PortalQH

Public Class TaoChuDeBaoCaoThoiVu
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlNam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlLoaiBaoCao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlThang As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTuan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChuDe As System.Web.UI.WebControls.TextBox

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

        If Not IsPostBack Then
            setAttributes()
            InitState()
        End If
    End Sub


    Private Sub InitState()

        Dim sYear, sMonth, sWeek, i As Integer

        'Khoi tao du lieu nam
        sYear = DateTime.Now.Year
        For i = 2006 To sYear
            ddlNam.Items.Add(New ListItem(CStr(i), CStr(i)))
        Next

        'Khoi tao du lieu thang
        sMonth = DateTime.Now.Month
        For i = 1 To 12
            ddlThang.Items.Add(New ListItem(CStr(i), CStr(i)))
        Next
        ddlThang.Items(sMonth - 1).Selected = True

        'Khoi tao du lieu tuan
        sWeek = 53
        For i = 1 To sWeek
            ddlTuan.Items.Add(New ListItem(CStr(i), CStr(i)))
        Next

    End Sub


    Private Sub setAttributes()
        ddlLoaiBaoCao.Attributes.Add("onChange", "changeLoaiBaoCao();")
    End Sub

End Class
