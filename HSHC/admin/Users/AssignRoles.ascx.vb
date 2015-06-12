Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data

Namespace PortalQH
    Public Class AssignRoles
        Inherits PortalQH.PortalModuleControl
        Private Shadows UserId As String = ""
        Private Const ProviderType As String = "data"
        Private _providerConfiguration As ProviderConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType)
        Private _connectionString As String
        Private _connectionStringApp As String
        Private _providerPath As String
        Private _objectQualifier As String
        Protected WithEvents lblFullName As System.Web.UI.WebControls.Label
        Protected WithEvents btnGetDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKeyWords As System.Web.UI.WebControls.TextBox
        Private _databaseOwner As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdRole As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dgdUsers As System.Web.UI.WebControls.DataGrid

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Public Sub New()

            ' Read the configuration specific information for this provider
            Dim objProvider As Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Provider)

            ' Read the attributes for this provider
            _connectionString = objProvider.Attributes("connectionString")
            '_connectionStringApp = ConfigurationSettings.AppSettings("connectionString" & gPortalID())
            Dim objHttpContext As HttpContext = HttpContext.Current
            If Not objHttpContext.Session Is Nothing Then
                If objHttpContext.Session.Item("ActiveDB").ToString = "" Then
                    _connectionStringApp = ConfigurationSettings.AppSettings("connectionString" & "PortalQH")
                Else
                    _connectionStringApp = ConfigurationSettings.AppSettings("connectionString" & objHttpContext.Session.Item("ActiveDB").ToString)
                End If

            Else
                _connectionStringApp = _connectionString
            End If
            _providerPath = objProvider.Attributes("providerPath")


            _objectQualifier = objProvider.Attributes("objectQualifier")
            If _objectQualifier <> "" And _objectQualifier.EndsWith("_") = False Then
                _objectQualifier += "_"
            End If

            _databaseOwner = objProvider.Attributes("databaseOwner")
            If _databaseOwner <> "" And _databaseOwner.EndsWith(".") = False Then
                _databaseOwner += "."
            End If

        End Sub

        Public ReadOnly Property ConnectionString() As String
            Get
                Return _connectionString

            End Get
        End Property
        Public ReadOnly Property ConnectionStringApp() As String
            Get

                Return _connectionStringApp
            End Get
        End Property

        Public ReadOnly Property ProviderPath() As String
            Get
                Return _providerPath
            End Get
        End Property

        Public ReadOnly Property ObjectQualifier() As String
            Get
                Return _objectQualifier
            End Get
        End Property

        Public ReadOnly Property DatabaseOwner() As String
            Get
                Return _databaseOwner
            End Get
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then
                InitState()
                txtSoDong.Text = "10"
            End If
            BindGrid()
        End Sub
        Private Sub BindGrid()
            Dim ds As New DataSet
            ds = GetUsersRole(PortalId, , Request.QueryString("UserId").ToString)
            dgdRole.DataSource = ds
            dgdRole.DataBind()
            gLoadControlValues(ds, Me)
        End Sub
        Private Sub InitState()
            Dim i, len As Integer
            len = dgdRole.Items.Count
            For i = 0 To len - 1
                CType(dgdRole.Items(i).FindControl("dgdchkChonUser"), CheckBox).Attributes.Add("onclick", "javascript:return select_deselect();")
            Next
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNullGrid();")
        End Sub
        Private Sub BindGridUser()
            Dim sRole, sUserName, sKeyWord As String
            Dim ds As DataSet
            sRole = getStringRoleID()
            If sRole = ";" Then
                Return
            End If
            ' Lay username va keyword
            sUserName = txtUserName.Text.ToString.Trim
            sKeyWord = txtKeyWords.Text.ToString.Trim

            ds = GetUserListsByRole(sRole, PortalId, Request.Params("UserID").ToString, sUserName, sKeyWord)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    If dgdUsers.PageCount < dgdUsers.CurrentPageIndex Then
                        dgdUsers.CurrentPageIndex = 1
                    End If
                    dgdUsers.PageSize = CInt(txtSoDong.Text)
                    dgdUsers.DataSource = ds
                    dgdUsers.DataBind()
                End If
            End If
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub
        Private Sub btnGetDanhSach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDanhSach.Click
            dgdUsers.CurrentPageIndex = 0
            BindGridUser()
        End Sub
        Private Function getStringRoleID() As String
            Dim i, len As Integer
            Dim strRoleID As String
            strRoleID = ";"
            len = dgdRole.Items.Count
            For i = 0 To len - 1
                If Not dgdRole.Items(i).FindControl("dgdRoleCheck") Is Nothing Then
                    If CType(dgdRole.Items(i).FindControl("dgdRoleCheck"), CheckBox).Checked = True Then
                        strRoleID = strRoleID + dgdRole.Items(i).Cells(1).Text() + ";"
                    End If
                End If
            Next
            Return strRoleID
        End Function
        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(dgdUsers.PageSize)
                Exit Sub
            End If
            If dgdUsers.PageSize <> CInt(txtSoDong.Text) Then
                dgdUsers.PageSize = CInt(txtSoDong.Text)
                dgdUsers.CurrentPageIndex = 0
                BindGridUser()
            End If
        End Sub
        Private Sub dgdUsers_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdUsers.PageIndexChanged
            dgdUsers.CurrentPageIndex = e.NewPageIndex
            BindGridUser()
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            ' Thu tuc nay se cap nhat tat ca cac quyen giong voi user duoc chon, tru quyen admin
            Dim i As Integer
            Dim roleId As String
            Dim UserID As String
            Dim UserNameSame As String
            Dim KeyWord As String

            Dim connectionStringApp As String
            For i = 0 To dgdUsers.Items.Count - 1
                If CType(dgdUsers.Items(i).FindControl("dgdchkChonUser"), CheckBox).Checked = True Then
                    UserID = dgdUsers.Items(i).Cells(1).Text
                    roleId = dgdUsers.Items(i).Cells(2).Text
                    UserNameSame = dgdUsers.Items(i).Cells(4).Text
                    KeyWord = dgdUsers.Items(i).Cells(7).Text

                    connectionStringApp = ConfigurationSettings.AppSettings("connectionString" & KeyWord)
                    ' gan quyen cua user hien tai giong nhu quyen user duoc chon
                    ' Insert into bang tuong duong
                    InsTuongDuong(UserID, Request.QueryString("UserID"), roleId, UserNameSame, KeyWord)
                    ' Gan quyen tren MENU_USER cho user nay tuong duong nguoi da chon
                    AssignRole(connectionStringApp, UserID, Request.QueryString("UserID"), roleId)
                    ' Ins nguoi chuyen nguoi nhan giong voi user duoc chon
                    InsChuyenNhan(connectionStringApp, Request.QueryString("UserID"), UserNameSame)
                End If
            Next
        End Sub
        ' Cac ham co so du lieu goi ngay tren lop thu nhat
        ' Do dang gap kho khan trong viec xac dinh connectionString khi module nay khong co KeyWords cua Tabs
        ' HienND comment
        'Cac ham co so du lieu
        Private Function GetUsersRole(ByVal PortalId As Integer, Optional ByVal RoleId As Integer = -1, Optional ByVal UserId As String = "") As DataSet
            Return CType(SqlHelper.ExecuteDataset(_connectionStringApp, DatabaseOwner & ObjectQualifier & "GetRoleMembership", PortalId, Nothing, UserId), DataSet)
        End Function
        Private Function GetUserListsByRole(ByVal strRoleID As String, ByVal PortalID As Integer, ByVal UserID As String, ByVal sUserName As String, ByVal sKeyWord As String) As DataSet
            Return CType(SqlHelper.ExecuteDataset(_connectionStringApp, DatabaseOwner & ObjectQualifier & "sp_GetUserListByRoles", strRoleID, PortalID, UserID, sUserName, sKeyWord), DataSet)
        End Function
        Private Sub AssignRole(ByVal cn As String, ByVal UserIDTarget As String, ByVal UserIDOwnner As String, ByVal RoleID As String)
            SqlHelper.ExecuteNonQuery(cn, DatabaseOwner & ObjectQualifier & "sp_AssignRole", UserIDTarget, UserIDOwnner, RoleID)
        End Sub
        Private Sub InsTuongDuong(ByVal UserIDTarget As String, ByVal UserIDOwner As String, ByVal RoleID As String, ByVal UserNameTarget As String, ByVal KeyWords As String)
            SqlHelper.ExecuteNonQuery(_connectionStringApp, DatabaseOwner & ObjectQualifier & "sp_InsTuongDuong", UserIDTarget, UserIDOwner, RoleID, UserNameTarget, KeyWords)
        End Sub
        Private Sub InsChuyenNhan(ByVal cn As String, ByVal UserID As String, ByVal UserNameTarget As String)
            SqlHelper.ExecuteNonQuery(cn, DatabaseOwner & ObjectQualifier & "sp_InsTuongDuongChuyenNhan", UserID, UserNameTarget)
        End Sub
    End Class
End Namespace
