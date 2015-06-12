Imports HSHC
Imports System.Configuration

Namespace PortalQH
    Public Class GiaoViec_Rep
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtTieuDe As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbl3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayGiaoViec As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbl4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayHoanThanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbl5 As System.Web.UI.WebControls.Label
        Protected WithEvents lbltTitle As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayGiao As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayXong As System.Web.UI.WebControls.Image
        Protected WithEvents CklDsNguoiThucHien As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents txtNguoiThucHien As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCongViecID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbl16 As System.Web.UI.WebControls.Label
        Protected WithEvents tblHienThi As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents txtDienGiai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTinhTrang As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlTinhTrang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblNTH As System.Web.UI.WebControls.Label
        Protected WithEvents txtDuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNguoiGiaoViec As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDuyet As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        'Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Function laNguoiNhan() As Boolean
            Dim objcon As New LanhDaoController
            Dim user_ID As String = CType(Session("UserName"), String)
            Dim ds As DataSet
            ds = objcon.getDSNguoiGiaoViec(ConfigurationSettings.AppSettings("db_web").ToString(), ConfigurationSettings.AppSettings("commonDB").ToString())
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                If user_ID.CompareTo(ds.Tables(0).Rows(i)(0)) = 0 Then
                    Return False
                End If
            Next
            objcon = Nothing
            Return True
        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here

            If Not Me.IsPostBack Then
                setAtribute()
                InitGrid()
                If Not Request.Params("ID") = "" Then
                    getValuesForForm(Trim(Request.Params("ID").ToString))
                Else
                    txtNguoiGiaoViec.Text = CType(Session("UserName"), String)
                    btnDuyet.Visible = False
                    btnXoa.Visible = False
                End If

                'If Request.Params("GiaoNhan") Is Nothing Or Request.Params("GiaoNhan") = "0" Then
                If Not (txtNguoiGiaoViec.Text.CompareTo(CType(Session("UserName"), String)) = 0) Then 'laNguoiNhan() Then
                    'Duoc giao
                    If Request.Params("SelectIndex") Is Nothing Or Request.Params("SelectIndex") = "0" Then
                        txtNgayGiaoViec.ReadOnly = True
                        txtNgayHoanThanh.ReadOnly = True
                        txtNguoiThucHien.ReadOnly = True
                        txtNoiDung.ReadOnly = True
                        txtTieuDe.ReadOnly = True

                        CklDsNguoiThucHien.Visible = False
                        lblNTH.Visible = False

                        imgNgayGiao.Visible = False
                        imgNgayXong.Visible = False

                        btnDuyet.Visible = False
                        btnXoa.Visible = False
                        txtDienGiai.ReadOnly = False
                        ddlTinhTrang.Enabled = True
                    End If
                Else
                    'Giao
                    If Request.Params("SelectIndex") = "1" Then
                        btnDuyet.Visible = True
                        btnXoa.Visible = True
                        btnCapNhat.Visible = False
                        txtDienGiai.ReadOnly = True
                        ddlTinhTrang.Enabled = False
                    End If
                End If
                SetCheckGrid()
                If txtDuyet.Text = "1" Then
                    Dim oControl As Control
                    For Each oControl In CType(Me, Control).Controls
                        Select Case True
                            Case TypeOf oControl Is TextBox
                                CType(oControl, TextBox).ReadOnly = True
                            Case TypeOf oControl Is DropDownList
                                CType(oControl, DropDownList).Enabled = False
                            Case TypeOf oControl Is CheckBox
                                CType(oControl, CheckBox).Enabled = False
                            Case TypeOf oControl Is RadioButton
                                CType(oControl, RadioButton).Enabled = False
                            Case TypeOf oControl Is CheckBoxList
                                CType(oControl, CheckBoxList).Enabled = False
                        End Select
                    Next
                    imgNgayGiao.Enabled = False
                    imgNgayXong.Enabled = False
                    btnCapNhat.Visible = False
                    btnDuyet.Visible = False
                End If
            End If

        End Sub
        Private Sub getValuesForForm(ByVal strID As String)
            Dim LDCon As New LanhDaoController
            Dim ds As New DataSet
            Dim db As String = ConfigurationSettings.AppSettings("db_web")
            ds = LDCon.getCongViecByID(db, strID)
            gLoadControlValues(ds, Me)
        End Sub
        Private Sub setAtribute()
            Me.txtNgayGiaoViec.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayGiaoViec.ClientID & ");")
            Me.imgNgayGiao.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtNgayGiaoViec.ClientID & ", 'dd/mm/yyyy')")
            Me.txtNgayHoanThanh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHoanThanh.ClientID & ");")
            Me.imgNgayXong.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtNgayHoanThanh.ClientID & ", 'dd/mm/yyyy')")

        End Sub
        Private Sub InitGrid()
            Dim objcon As New DanhSachNhomController
            BindControl.BindCheckBoxList(CklDsNguoiThucHien, ConfigurationSettings.AppSettings("db_web").ToString() & "..sp_CV_getDSNguoiNhanViec", "", ConfigurationSettings.AppSettings("commonDB").ToString(), CType(Session("UserName"), String))
            objcon = Nothing
        End Sub
        Private Sub SetCheckGrid()
            Dim i As Integer
            For i = 0 To CklDsNguoiThucHien.Items.Count - 1
                If InStr(1, txtNguoiThucHien.Text, "," + CklDsNguoiThucHien.Items(i).Value + ",") > 0 Then
                    CklDsNguoiThucHien.Items(i).Selected = True
                End If
            Next
        End Sub
        Private Function getNguoiTH() As String
            Dim i As Integer
            Dim list As New ListItem
            Dim str As String = ","
            For Each list In CklDsNguoiThucHien.Items
                If list.Selected = True Then
                    str = str + list.Value + ","
                End If
            Next list
            If str = "," Then
                str = ""
            End If
            Return str
        End Function
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            ' Them boi dnductien
            Dim errorValidation As Boolean = False
            If txtTieuDe.Text = "" Then
                Label7.Text = "Chưa nhập tên tiêu đề"
                errorValidation = True
            Else
                Label7.Text = ""
            End If
            If txtNgayGiaoViec.Text = "" Then
                Label8.Text = "Chưa nhập ngày giao việc"
                errorValidation = True
            Else
                Label8.Text = ""
            End If
            If txtNgayHoanThanh.Text = "" Then
                Label9.Text = "Chưa nhập ngày hoàn thành"
                errorValidation = True
            Else
                Label9.Text = ""
            End If
            If errorValidation Then
                Return
            End If

            Dim LDCon As New LanhDaoController
            Dim strNguoiTH As String
            strNguoiTH = getNguoiTH()
            ' Cap nhat
            If Not Request.Params("ID").Equals("") Then
                LDCon.UpdCongViec(ConfigurationSettings.AppSettings("db_web"), txtCongViecID.Text, _
                                                                                txtTieuDe.Text, _
                                                                                txtNoiDung.Text, _
                                                                                txtNguoiGiaoViec.Text, _
                                                                                txtNgayGiaoViec.Text, _
                                                                                txtNgayHoanThanh.Text, _
                                                                                strNguoiTH, _
                                                                                ddlTinhTrang.SelectedValue, _
                                                                                txtDienGiai.Text, _
                                                                                "0")
            Else 'Them moi 
                LDCon.InsCongViec(ConfigurationSettings.AppSettings("db_web"), txtTieuDe.Text, _
                                                                                txtNoiDung.Text, _
                                                                                txtNguoiGiaoViec.Text, _
                                                                                txtNgayGiaoViec.Text, _
                                                                                txtNgayHoanThanh.Text, _
                                                                                strNguoiTH, _
                                                                                ddlTinhTrang.SelectedValue, _
                                                                                txtDienGiai.Text, _
                                                                                "0")
                'Response.Redirect(NavigateURL())
                btnTroVe_Click(sender, e)

            End If

        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim index, id, cat, strLoaiViec As String
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

            'toi sua, dnductien
            If Not Request.Params("GiaoNhan") Is Nothing Then
                strLoaiViec = Request.Params("GiaoNhan")
            Else
                strLoaiViec = ""
            End If
            Response.Redirect(NavigateURL() & "&SelectIndex=" & index & "&Cat=" & cat & "&GiaoNhan=" & strLoaiViec)

            'Response.Redirect(NavigateURL() & "&SelectIndex=" & index & "&Cat=" & cat)
        End Sub
        Private Sub btnDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuyet.Click
            Dim objLD As New LanhDaoController
            objLD.apprCongViec(ConfigurationSettings.AppSettings("db_web").ToString(), txtCongViecID.Text, "")
        End Sub

        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objLD As New LanhDaoController
            objLD.delCongViec(ConfigurationSettings.AppSettings("db_web").ToString(), txtCongViecID.Text)
            btnTroVe_Click(sender, e)
        End Sub
    End Class

End Namespace