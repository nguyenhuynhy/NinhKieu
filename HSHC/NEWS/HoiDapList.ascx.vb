Imports System.Configuration
Namespace PortalQH
    Public Class HoiDapList
        Inherits PortalQH.PortalModuleControl
        Dim objLanhDao As LanhDaoController
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents ddlNguoiGui As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.ImageButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.ImageButton

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
            objLanhDao = New LanhDaoController
            SetAttribute()
            If Not IsPostBack = True Then
                InitState()
            End If
            LoadGrid()
        End Sub

        Public Sub InitState()
            Dim db As String

            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            BindControl.BindDropDownList_StoreProc(ddlNguoiGui, True, "", db & "..sp_GetUserCBO")
            'truong hop loc theo nguoi nhan
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, -3, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            If Not Request.Params("SelectID") Is Nothing And CType(Request.Params("SelectID"), String) = "0" Then
                ddlNguoiGui.Enabled = True
                btnThemMoi.Visible = True
                btnXoa.Visible = True
                'truong hop loc theo nguoi gui
                'ElseIf Not Request.Params("SelectID") Is Nothing And (CType(Request.Params("SelectID"), String) = "1" Or CType(Request.Params("SelectID"), String) = "2") Then
            Else
                DdLSelected(ddlNguoiGui, CType(Session("UserName"), String))
                ddlNguoiGui.Enabled = False
                btnThemMoi.Visible = False
                btnXoa.Visible = False
                SetVisibleGrid()
                
            End If
        End Sub

        Public Sub SetVisibleGrid()
            If dgdDanhSach.Items.Count <= 0 Then
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To dgdDanhSach.Items.Count - 1
                CType(dgdDanhSach.Items(i).FindControl("chkXoa"), CheckBox).Enabled = False
            Next
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
            Dim iSelectID As String
            Dim iSelectIndex As String
            Dim iCat As String
            Dim URL As String
            'Dim i As Integer
            Dim strActive As String

            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectID = CType(Request.Params("SelectID"), String)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                iSelectIndex = CType(Request.Params("SelectIndex"), String)
            End If
            If Not Request.Params("Cat") Is Nothing Then
                iCat = CType(Request.Params("Cat"), String)
            End If

            URL = Replace(EditURL("ID", "VALUE" & "&SelectID=" & iSelectID & "&SelectIndex=" & iSelectIndex & "&Cat=" & iCat, "HD"), "mid=-1", "mid=" & CType(Session("Mid"), String))

            'truong hop active topic
            If Not Request.Cookies("HOIDAP") Is Nothing Then 'And Request.Cookies("HOIDAP").Values().Count > 0 Then
                strActive = Request.Cookies("HOIDAP")(CType(Session("UserName"), String))
            End If
            'end truong hop active topic

            ds = objLanhDao.GetHoiDap_Lst(db, CType(Session("UserName"), String), ddlNguoiGui.SelectedValue, txtTuNgay.Text, txtDenNgay.Text, iSelectID, strActive, URL)
            If iSelectIndex = "0" Then
                BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Chủ đề, Số bài, Ngày gửi ,Người nhận", "550, 50,100, 100, 0")
            Else
                BindControl.BindGrdHoSo(ds, dgdDanhSach, True, "Chủ đề, Số bài, Ngày gửi ,Người gửi", "550, 50,100, 100, 0")
            End If

        End Sub

        Public Sub SetAttribute()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            Me.imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            Me.imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            objLanhDao = Nothing
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThucHien.Click
            LoadGrid()
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThemMoi.Click
            Response.Redirect(Replace(EditURL("ID", "&Cat=" & Request.Params("Cat") & "&SelectID=" & Request.Params("SelectID") & "&SelectIndex=" & Request.Params("SelectIndex"), "HD"), "mid=-1", "mid=" & CType(Session("Mid"), String)))
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnXoa.Click
            Dim i As Integer
            Dim chkXoa As CheckBox
            For i = 0 To dgdDanhSach.Items.Count - 1
                chkXoa = CType(Me.dgdDanhSach.Items(i).FindControl("chkXoa"), CheckBox)
                If chkXoa.Checked Then
                    objLanhDao.DelHoiDap(ConfigurationSettings.AppSettings("db_web").ToString(), Me.dgdDanhSach.Items(i).Cells(6).Text)
                End If
            Next
            LoadGrid()
            objLanhDao = Nothing
        End Sub
    End Class
End Namespace