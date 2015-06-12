Imports System.Configuration
Namespace PortalQH
    Public Class GiaoViec
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents ddlNguoiGui As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Imagebutton1 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents ddlLoaiViec As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDuyet As System.Web.UI.WebControls.LinkButton
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Function laNguoiGiao() As Boolean
            Dim objcon As New LanhDaoController
            Dim user_ID As String = CType(Session("UserName"), String)
            Dim ds As DataSet
            ds = objcon.getDSNguoiGiaoViec(ConfigurationSettings.AppSettings("db_web").ToString(), ConfigurationSettings.AppSettings("commonDB").ToString())
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                If user_ID.CompareTo(ds.Tables(0).Rows(i)(0)) = 0 Then
                    Return True
                End If
            Next
            objcon = Nothing
            Return False
        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here            
            Dim strLoaiViec As String
            If Not Page.IsPostBack Then
                If Not Request.Params("GiaoNhan") Is Nothing Then
                    strLoaiViec = Request.Params("GiaoNhan")
                    ddlLoaiViec.SelectedValue = strLoaiViec
                    '    Else
                    '       strLoaiViec = ddlLoaiViec.SelectedValue
                End If
                If laNguoiGiao() Then
                    ddlLoaiViec.Enabled = True
                Else
                    ddlLoaiViec.SelectedIndex = 0
                    ddlLoaiViec.Enabled = False
                End If

                setAtribute()
                BindGrid()
            End If
            InitState()
        End Sub
        Private Sub InitState()
            Dim strLoaiViec As String
            strLoaiViec = ddlLoaiViec.SelectedValue
            'Truong hop loc theo nguoi nhan
            'Toi bo, dnductien - setAttrforCon(False)
            If strLoaiViec = "1" Then
                DdLSelected(ddlNguoiGui, CType(Session("UserName"), String))
                ddlNguoiGui.Enabled = False
            Else 'truong hop loc theo nguoi gui
                ddlNguoiGui.Enabled = True
            End If

            ' Sua boi dnductien, 9-2005
            'If ddlNguoiGui.SelectedValue = "" Or ddlNguoiGui.SelectedValue Is Nothing Then
            'setAttrforCon(False)
            'Else
            '    setAttrforCon(True)
            'End If
            If ddlLoaiViec.SelectedIndex = 0 Then
                setAttrforCon(False)
            Else
                setAttrforCon(True)
            End If

        End Sub
        ' Co thay doi
        ' dnductien, 8-2005
        Private Sub setAtribute()
            Dim db As String
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            BindControl.BindDropDownList_StoreProc(ddlNguoiGui, True, "", db & "..sp_CV_getDSNguoiGiaoViecByID", ConfigurationSettings.AppSettings("commonDB").ToString(), CType(Session("UserName"), String))

            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            Me.imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            Me.imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
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

        Private Sub BindGrid()
            Dim objLanhDao As New LanhDaoController
            Dim ds As New DataSet
            Dim db As String
            Dim iSelectID As String
            Dim URL As String
            ' Toi sua, dnductien
            URL = Replace(EditURL("ID", "VALUE&GiaoNhan=" + ddlLoaiViec.SelectedValue, "CV"), "mid=-1", "mid=" & CType(Session("Mid"), String))
            'URL = Replace(EditURL("ID", "VALUE", "CV"), "mid=-1", "mid=" & CType(Session("Mid"), String))
            db = CType(ConfigurationSettings.AppSettings("db_web"), String)
            iSelectID = ddlLoaiViec.SelectedValue
            ds = objLanhDao.getCongViec_Lst(db, CType(Session("UserName"), String), ddlNguoiGui.SelectedValue.ToString, txtTuNgay.Text, txtDenNgay.Text, iSelectID, URL)
            BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Công việc, Người giao, Ngày giao, Người nhận, Hạn thực hiện, Tình trạng, ID", "200, 150, 80, 150, 80, 80, 0")
            ' Dim i As Integer
            ' Dim strNguoiGiaoViec As String
        End Sub

        Private Sub setAttrforCon(Optional ByVal flag As Boolean = True)
            btnThemMoi.Visible = flag
            btnXoa.Visible = False
            btnDuyet.Visible = False
            If dgdDanhSach.Items.Count <= 0 Then
                Exit Sub
            End If
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub

        Private Sub ddlLoaiViec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLoaiViec.SelectedIndexChanged
            setAtribute()
            BindGrid()
            InitState()
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            BindGrid()
            InitState()
        End Sub
        Private Sub btnThemmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(Replace(EditURL("ID", "&GiaoNhan=1&Cat=" & Request.Params("Cat") & "&SelectID=" & ddlLoaiViec.SelectedValue, "CV"), "mid=-1", "mid=" & CType(Session("Mid"), String)))
        End Sub
        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim i As Integer
            Dim chkXoa As CheckBox
            Dim objLD As New LanhDaoController
            For i = 0 To dgdDanhSach.Items.Count - 1
                chkXoa = CType(Me.dgdDanhSach.Items(i).FindControl("chkXoa"), CheckBox)
                If chkXoa.Checked Then
                    objLD.delCongViec(ConfigurationSettings.AppSettings("db_web").ToString(), Me.dgdDanhSach.Items(i).Cells(8).Text)
                End If
            Next
            BindGrid()
            objLD = Nothing
        End Sub
        Private Sub btnDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuyet.Click
            Dim i As Integer
            Dim chkXoa As CheckBox
            Dim objLD As New LanhDaoController
            For i = 0 To dgdDanhSach.Items.Count - 1
                chkXoa = CType(Me.dgdDanhSach.Items(i).FindControl("chkXoa"), CheckBox)
                If chkXoa.Checked Then
                    objLD.apprCongViec(ConfigurationSettings.AppSettings("db_web").ToString(), CType(Me.dgdDanhSach.Items(i).FindControl("morelink"), HyperLink).Text, "")
                End If
            Next
            BindGrid()
            objLD = Nothing
        End Sub
    End Class

End Namespace