Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ThuLyHoSoMotCuaPhuongXa
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnChuyenXuLy As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYeuCauBoSung As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnKhongXuLy As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents dgdHoSoThuLy As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuuMotCuaPhuongXa
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
                Init_State()
                Me.LoadGrid()
                ' btnTimKiem_Click(Nothing, Nothing)

            End If
            ' GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "3", "HSHC", btnIndanhsach, Me, True)
            dgdHoSoThuLy.Attributes.Add("onclick", "javascript:LaySoBienNhan();")

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	3/31/2007	Updated
        '''     Desc. : Thay doi cach lay du lieu
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub Init_State()
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuPhuongXaController
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

            'init dropdownlist
            If Session("ItemCode") Is Nothing Then
                iSelectedId = objMenuList.getDefaultItemCode(objMenuListInfo)
                Session("ItemCode") = iSelectedId
            Else
                iSelectedId = CStr(Session("ItemCode"))
            End If
            If CType(ConfigurationSettings.AppSettings("CheckUser" & CType(Session.Item("ActiveDB"), String)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If

            Session("ItemCode") = ddlLinhVuc.SelectedValue

            If (Session("ThongTinTraCuuPhuongXaInfo") Is Nothing) Then
                Dim obj As New ThongTinTraCuuPhuongXaInfo(Request)
                obj.ItemCode = ddlLinhVuc.SelectedValue
                obj.NguoiTacNghiep = CStr(Session("UserID"))
                'khởi tạo giá trị session
                Session("ThongTinTraCuuPhuongXaInfo") = obj
            Else 'them o day nhe' ca'c em
                Dim obj As ThongTinTraCuuPhuongXaInfo = CType(Session("ThongTinTraCuuPhuongXaInfo"), ThongTinTraCuuPhuongXaInfo)
                obj.TabCode = Request("tabid")
                Session("ThongTinTraCuuPhuongXaInfo") = obj
            End If
            '===========================================================
            'TuanNH added date 28/09/2007
            '===========================================================
            If Not Session.Item("SoDongHienThi") Is Nothing Then
                txtSoDong.Text = Session.Item("SoDongHienThi").ToString()
            Else
                txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            End If

            dgdHoSoThuLy.PageSize = CInt(txtSoDong.Text)

        End Sub

        Private Sub dgdHoSoThuLy_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdHoSoThuLy.PageIndexChanged
            dgdHoSoThuLy.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim ds As DataSet
            Dim objThongTinTraCuuInfo As ThongTinTraCuuPhuongXaInfo
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuPhuongXaController

            objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuPhuongXaInfo"), ThongTinTraCuuPhuongXaInfo)

            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE")
            ds = objThongTinTraCuuCtrl.GetDSHoSoThuLyMotCuaPhuongXa(objThongTinTraCuuInfo)
            If (Me.dgdHoSoThuLy.CurrentPageIndex > CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))) Then
                Me.dgdHoSoThuLy.CurrentPageIndex = CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))
            End If
            Me.dgdHoSoThuLy.DataSource = ds
            Me.dgdHoSoThuLy.DataBind()

            'AddAttributeCheckbox()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	3/31/2007	Updated
        '''     Desc. : Doi ID checkbox control
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub AddAttributeCheckbox()
            Dim chk As CheckBox
            Dim i As Integer
            If dgdHoSoThuLy.Items.Count = 0 Then Exit Sub
            For i = 0 To dgdHoSoThuLy.Controls(0).Controls.Count - 1
                chk = CType(dgdHoSoThuLy.Controls(0).Controls(i).FindControl("chkSelected"), CheckBox)
                If Not chk Is Nothing Then
                    chk.Attributes.Add("OnClick", "javascript: return select_deselect('" & chk.ClientID & "');")
                End If
            Next
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(dgdHoSoThuLy.PageSize)
                Exit Sub
            End If
            If dgdHoSoThuLy.PageSize <> CInt(txtSoDong.Text) Then
                dgdHoSoThuLy.PageSize = CInt(txtSoDong.Text)
                '===========================================================
                'TuanNH added date 28/09/2007
                '===========================================================
                Session.Item("SoDongHienThi") = txtSoDong.Text
                LoadGrid()
            End If
        End Sub

        Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New HSHC.HoSoBoSungController
            Dim dv As New DataView
            dv = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Private Function CheckHoSoKhongGiaiQuyet(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoKhongGiaiQuyet As New HSHC.HoSoKhongGiaiQuyetController
            Dim dv As New DataView
            dv = objHoSoKhongGiaiQuyet.GetHoSoKhongGiaiQuyet(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoKhongGiaiQuyetID").ToString <> "" Then
                    SetMSGBOX_HIDDEN(Page, "Ho so khong duoc chap nhan giai quyet!")
                    Return True
                Else
                    Return False
                End If
            End If
        End Function
        Private Function GetSoBienNhan() As String
            Dim strSoBienNhan As String
            Dim item As DataGridItem
            For Each item In dgdHoSoThuLy.Items
                If CType(item.FindControl("chkXoa"), CheckBox).Checked = True Then
                    If strSoBienNhan <> "" Then strSoBienNhan = strSoBienNhan & ","
                    strSoBienNhan = strSoBienNhan & item.Cells(2).Text
                End If
            Next
            Return strSoBienNhan
        End Function

        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Dim objThongTinTraCuuInfo As ThongTinTraCuuPhuongXaInfo
            objThongTinTraCuuInfo = ThongTinTraCuu1.GetValues()

            lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
            objThongTinTraCuuInfo.ItemCode = ddlLinhVuc.SelectedValue()

            'bind lại dữ liệu tương ứng với ItemCode
            Session("ThongTinTraCuuPhuongXaInfo") = objThongTinTraCuuInfo
            ThongTinTraCuu1.BindData(ddlLinhVuc.SelectedValue)
            LoadGrid()
        End Sub
        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuuInfo As ThongTinTraCuuPhuongXaInfo
            objThongTinTraCuuInfo = ThongTinTraCuu1.GetValues()

            lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
            objThongTinTraCuuInfo.ItemCode = ddlLinhVuc.SelectedValue

            'bind lại dữ liệu tương ứng với ItemCode
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
            ThongTinTraCuu1.BindData(ddlLinhVuc.SelectedValue)
            LoadGrid()
        End Sub

        Private Sub btnChuyenXuLy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChuyenXuLy.Click
            Dim strSoBienNhan As String
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan & "&Malv=" & Session.Item("ItemCode").ToString(), "CHUYENXULY"), True)
            End If
        End Sub

        Private Sub btnKhongXuLy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongXuLy.Click
            Dim strSoBienNhan As String
            Dim item As DataGridItem
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan & "&Malv=" & Session.Item("ItemCode").ToString(), "KHONGGIAIQUYET"), True)
            End If
        End Sub

        Private Sub btnYeuCauBoSung_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYeuCauBoSung.Click
            Dim strSoBienNhan As String
            strSoBienNhan = GetSoBienNhan()
            If strSoBienNhan <> "" And Not CheckHoSoKhongGiaiQuyet(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan & "&Malv=" & Session.Item("ItemCode").ToString(), "YEUCAUBOSUNG"), True)
            End If
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Try
                If Not ThongTinTraCuu1 Is Nothing Then
                    Dim objThongTin As ThongTinTraCuuPhuongXaInfo
                    objThongTin = ThongTinTraCuu1.GetValues()
                    objThongTin.ItemCode = ddlLinhVuc.SelectedValue
                    Session("ThongTinTraCuuPhuongXaInfo") = objThongTin
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
    End Class
End Namespace