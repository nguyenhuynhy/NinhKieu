
Option Strict Off
Imports System.Configuration
Imports PortalQH

Namespace HSHC
    Public Class ChuyenNhanHS
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents ThongTinTraCuuChuyenNhan1 As ThongTinTraCuuChuyenNhan
        Protected WithEvents grdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtChuoiSoBienNhan As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtMaLinhVuc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInPhieu As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputText
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Dim objThongTinTraCuuInfo As ThongTinTraCuuInfo

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

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
            Try
                If Not Page.IsPostBack Then
                    Init_State()
                    SetAttributesControl()
                    LoadGrid()
                End If
               
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
            'LoadGrid()
        End Sub

        Private Sub SetAttributesControl()
            txtMaLinhVuc.Value = CType(Session.Item("ItemCode"), String)
            txtMaNguoiTacNghiep.Value = CType(Session.Item("UserName"), String)
            GetReportURL(TabId, CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInRaGiay, Me, True)
            GetReportURL(TabId, CType(Session.Item("ItemCode"), String), "2", "HSHC", btnInPhieu, Me)
            grdDanhSach.Attributes.Add("onclick", "javascript:LaySoBienNhan();")
            btnCapNhat.Attributes.Add("onclick", "javascript:return KiemTraThongTinCapNhat();")
        End Sub

        Sub Init_State()
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

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

            lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            Session("ItemCode") = ddlLinhVuc.SelectedValue

            '========================================================================
            If (Session("ThongTinTraCuuInfo") Is Nothing) Then
                Dim obj As New ThongTinTraCuuInfo(Request)
                obj.ItemCode = ddlLinhVuc.SelectedValue
                obj.NguoiTacNghiep = CStr(Session("UserID"))
                'khởi tạo giá trị session
                Session("ThongTinTraCuuInfo") = obj
            Else 'them o day nhe' ca'c em
                Dim obj As ThongTinTraCuuInfo = CType(Session("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)
                obj.TabCode = Request("tabid")
                Session("ThongTinTraCuuInfo") = obj
            End If


            'set gia tri mac dinh cho datagird
            '===========================================================
            'TuanNH added date 28/09/2007
            '===========================================================
            If Not Session.Item("SoDongHienThi") Is Nothing Then
                txtSoDong.Text = Session.Item("SoDongHienThi").ToString()
            Else
                txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            End If
            grdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub


        Private Sub grdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDanhSach.PageIndexChanged
            grdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/2/2007	Updated
        '''     Desc. : The hien thoi han chuyen ho so 
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub LoadGrid()
            Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
            Dim ds As DataSet

            objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)

            objThongTinTraCuuInfo.TabCode = Request.Params("TabID")
            objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE")

            ds = objThongTinTraCuuCtrl.GetDSHoSoChuyenThuLy(objThongTinTraCuuInfo)
            If (Me.grdDanhSach.CurrentPageIndex > CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))) Then
                Me.grdDanhSach.CurrentPageIndex = CInt((ds.Tables(0).Rows.Count - 1) / CInt(txtSoDong.Text))
            End If
            grdDanhSach.DataSource = ds
            grdDanhSach.DataBind()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/2/2007	Updated
        '''     Desc. : Sua cach lay control checkbox
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function LayChuoiSoBienNhan() As String
            Dim Item As DataGridItem
            Dim strID As String
            Dim chk As CheckBox
            If grdDanhSach Is Nothing Then Exit Function
            For Each Item In grdDanhSach.Items
                chk = CType(Item.FindControl("chkXoa"), CheckBox)
                If chk.Checked Then
                    If strID <> "" Then strID = strID & ","
                    strID = strID & Item.Cells(2).Text
                End If
            Next
            Return strID
        End Function


        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(grdDanhSach.PageSize)
                Exit Sub
            End If
            If grdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                Session("SoDongHienThi") = txtSoDong.Text
                grdDanhSach.PageSize = CInt(txtSoDong.Text)
                LoadGrid()
            End If
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Try
                If Not ThongTinTraCuuChuyenNhan1 Is Nothing Then
                    Dim objThongTin As ThongTinTraCuuInfo
                    objThongTin = ThongTinTraCuuChuyenNhan1.GetValues()
                    objThongTin.ItemCode = ddlLinhVuc.SelectedValue
                    Session("ThongTinTraCuuInfo") = objThongTin
                    LoadGrid()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnInRaGiay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInRaGiay.Click
            Dim strURL As String
            Dim strSoBienNhan
            strSoBienNhan = txtChuoiSoBienNhan.Value
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/2/2007	Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim i As Integer
            Dim err As Integer
            Dim flgCheck As Boolean
            Dim strUserName As String
            Dim objTinhTrangCtrl As New TinhTrangHoSoController

            objThongTinTraCuuInfo = ThongTinTraCuuChuyenNhan1.GetValues()

            If Session.Item("UserName") Is Nothing Then
                strUserName = ""
            Else
                strUserName = Session.Item("UserName").ToString
            End If

            For i = 0 To grdDanhSach.Items.Count - 1
                flgCheck = CType(GetGridControlValue(i, grdDanhSach, "chkXoa"), Boolean)
                If flgCheck Then
                    err = objTinhTrangCtrl.UpdTinhTrangHoSo(CType(Session.Item("ItemCode"), String), Request.Params("TabID"), "", strUserName, objThongTinTraCuuInfo.NguoiChuyen, objThongTinTraCuuInfo.NguoiNhan, grdDanhSach.Items(i).Cells(0).Text, "")
                    If err <> 0 Then
                        SetMSGBOX_HIDDEN(Page, "Cập nhật hồ sơ có số biên nhận " & grdDanhSach.Items(i).Cells(2).Text & " bị lỗi")
                        Exit Sub
                    End If
                End If
            Next

            objThongTinTraCuuInfo.ItemCode = ddlLinhVuc.SelectedValue
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
            LoadGrid()

            SetAttributesControl()

        End Sub
        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Dim objThongTinTraCuuInfo As ThongTinTraCuuInfo
            objThongTinTraCuuInfo = ThongTinTraCuuChuyenNhan1.GetValues()

            lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
            objThongTinTraCuuInfo.ItemCode = ddlLinhVuc.SelectedValue()

            'bind lại dữ liệu tương ứng với ItemCode
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
            ThongTinTraCuuChuyenNhan1.BindData(ddlLinhVuc.SelectedValue)
            LoadGrid()
            SetAttributesControl()
        End Sub
        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim objThongTinTraCuuInfo As ThongTinTraCuuInfo
            objThongTinTraCuuInfo = ThongTinTraCuuChuyenNhan1.GetValues()

            lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
            Session.Item("ItemCode") = ddlLinhVuc.SelectedValue()
            objThongTinTraCuuInfo.ItemCode = ddlLinhVuc.SelectedValue()

            'bind lại dữ liệu tương ứng với ItemCode
            Session("ThongTinTraCuuInfo") = objThongTinTraCuuInfo
            ThongTinTraCuuChuyenNhan1.BindData(ddlLinhVuc.SelectedValue)
            LoadGrid()
            SetAttributesControl()
        End Sub

    End Class
End Namespace