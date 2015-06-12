Imports System.Configuration
Namespace PortalQH
    Public Class HoiDap_Rep
        Inherits PortalQH.PortalModuleControl
        Private Shared flgAddNew As Boolean
        'Private Shared flgRep As Boolean
        Protected WithEvents ddlNguoiNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnCapNhatCD As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Dim objLanhDao As LanhDaoController
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents trTraLoi As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents txtNguoiGui_Desr As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiGui As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayGui As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoiDapID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTraLoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
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
            Dim strCookies As String
            objLanhDao = New LanhDaoController
            If Not IsPostBack = True Then
                InitState()
                'Cap nhat tin da doc
                'If InStr(Request.Cookies("HOIDAP")(CType(Session("UserName"), String)), CType(Request.Params("ID"), String)) > 0 Then
                strCookies = Request.Cookies("HOIDAP")(CType(Session("UserName"), String)) & CType(Request.Params("ID"), String) & ";"
                Response.Cookies("HOIDAP")(CType(Session("UserName"), String)) = strCookies
                'End If
            End If
            BindData()
            SetFlag()
        End Sub

        Public Sub InitState()
            Dim db As String
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            'init data
            txtNgayGui.Text = Format(Now, "dd/MM/yyyy")
            txtNguoiGui.Text = CType(Session("UserName"), String)
            BindControl.BindDropDownList_StoreProc(ddlNguoiNhan, False, "", db & "..sp_GetUserCBO")
        End Sub

        Public Sub BindData()
            Dim ds As DataSet
            Dim db As String
            'load chu de
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            If Not Request.Params("ID") Is Nothing Then
                txtHoiDapID.Text = Request.Params("ID")
            End If
            If txtHoiDapID.Text <> "" Then
                ds = objLanhDao.GetTraLoi_Detail(db, txtHoiDapID.Text)
                gLoadControlValues(ds, Me)
            End If
            'load grid tra loi
            LoadGrid()
            

        End Sub

        Public Sub DdLSelected(ByVal Ddl As DropDownList, ByVal Value As String)
            Dim i As Integer
            If Ddl.Items.Count > 0 Then
                For i = 0 To Ddl.Items.Count - 1
                    If Ddl.Items(i).Value = Value Then
                        Ddl.ClearSelection()
                        Ddl.Items(i).Selected = True
                        Exit Sub
                    End If
                Next
            End If
        End Sub

        Public Sub LoadGrid()
            Dim ds As DataSet
            Dim db As String
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            ds = objLanhDao.GetTraLoi_Lst(db, txtHoiDapID.Text)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Nội dung, Người gửi, Ngày gửi", "600, 100, 100,100")
            ds = Nothing
        End Sub

        Public Sub SetFlag()
            If txtHoiDapID.Text = "" Then
                flgAddNew = True
                btnCapNhatCD.Visible = True
                txtTieuDe.ReadOnly = False
                txtNoiDung.ReadOnly = False
                ddlNguoiNhan.Enabled = True

                trTraLoi.Visible = False
                btnCapNhat.Visible = False
            Else
                flgAddNew = False
                btnCapNhatCD.Visible = False
                txtTieuDe.ReadOnly = True
                txtNoiDung.ReadOnly = True
                ddlNguoiNhan.Enabled = False

                trTraLoi.Visible = True
                btnCapNhat.Visible = True
            End If
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThemMoi.Click

            Dim SelectID As String
            Dim SelectIndex As String
            If Not Request.Params("SelectID") Is Nothing Then
                SelectID = CType(Request.Params("SelectID"), String)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                Selectindex = CType(Request.Params("SelectIndex"), String)
            End If
            
            Response.Redirect(EditURL("ID", "&Cat=HD&SelectID=" & SelectID & "&SelectIndex=" & SelectIndex, "HD"))
        End Sub

       

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            objLanhDao = Nothing
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBoQua.Click
            Dim index, id, cat As String
            If Not Request.Params("SelectIndex") Is Nothing Then
                index = Request.Params("SelectIndex")
            Else
                index = ""
            End If
            If Not Request.Params("Cat") Is Nothing Then
                cat = Request.Params("Cat")
            Else
                cat = ""
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                id = Request.Params("SelectID")
            Else
                id = ""
            End If
            Response.Redirect(NavigateURL() & "&SelectIndex=" & index & "&Cat=" & cat & "&SelectID=" & id)

        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            'cap nhat bai gui
            Dim db As String
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            objLanhDao.UpdHoiDap_TL(db, txtTraLoi.Text, txtNguoiGui.Text, txtHoiDapID.Text)
            txtTraLoi.Text = ""
            LoadGrid()
        End Sub

        Private Sub btnCapNhatCD_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhatCD.Click
            'cap nhat mot chu de moi
            Dim db As String
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            If flgAddNew = True Then 'add new chu de
                txtHoiDapID.Text = objLanhDao.UpdHoiDap(db, txtTieuDe.Text, txtNoiDung.Text, txtNguoiGui.Text, txtNgayGui.Text, ddlNguoiNhan.SelectedValue)
            End If
            Dim index, id, cat As String
            If Not Request.Params("SelectIndex") Is Nothing Then
                index = Request.Params("SelectIndex")
            Else
                index = ""
            End If
            If Not Request.Params("Cat") Is Nothing Then
                cat = Request.Params("Cat")
            Else
                cat = ""
            End If

            'cap nhat lai active topic
            'Response.Cookies("HOIDAP")(CType((Session("UserName")), String) & CType(Request.Params("ID"), String)) = ""
            Response.Redirect(NavigateURL() & "&SelectIndex=" & index & "&Cat=" & cat & "&ID=" & txtHoiDapID.Text & "&SelectID=0")
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub
    End Class
End Namespace