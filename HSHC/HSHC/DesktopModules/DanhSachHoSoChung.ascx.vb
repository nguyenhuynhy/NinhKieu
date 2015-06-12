Imports PortalQH
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Object
Namespace HSHC
    Public Class DanhSachHoSoChung
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.ImageButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents grdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnInRagiay As System.Web.UI.WebControls.ImageButton
        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuu
        Protected WithEvents ThongTinTraCuuChuyenNhan1 As ThongTinTraCuuChuyenNhan

        Private Shared objThongTinTraCuuInfo As ThongTinTraCuuInfo
        Private Shared objDanhSachHoSoInfo As New DanhSachHoSoInfo
        Private Shared flagDisplayGrid As Boolean

        Private Const strTHONGTINTRACUU As String = "THONGTINTRACUU"
        Private Const strTHONGTINTRACUUCHUYENNHAN As String = "THONGTINTRACUUCHUYENNHAN"
        

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '==========================================================================
        '==========================================================================
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                If Not Page.IsPostBack Then
                    Init_State()
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        '==========================================================================
        '==========================================================================
        Private Sub Init_State()
            Dim ds As DataSet
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim iSelectedID As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            objMenuListInfo.UserID = CType(DataCache.GetCache("UserID"), String)

            'init dropdown list Lĩnh vực hồ sơ tiếp nhận
            'If objThongTinTraCuuInfo Is Nothing Then
            '    objThongTinTraCuuInfo = New ThongTinTraCuuInfo
            '    iSelectedID = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            'Else
            '    iSelectedID = objThongTinTraCuuInfo.ItemCode
            'End If
            objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
            iSelectedID = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)

            BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedID, "sp_getMenuUser", Request.Params("TabId"), CType(DataCache.GetCache("UserID"), String))
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                gItemCode = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = gItemCode
            End If

            DisableAll()
            'display and bind control
            flagDisplayGrid = True
            ds = Display_Control()

            If flagDisplayGrid Then
                'display button
                Display_Button()
                'init gird
                LoadGrid(ds)
            End If

            'release object
            ds = Nothing
            objMenuListInfo = Nothing
            objMenuList = Nothing
        End Sub

        '==========================================================================
        'Visible tat ca cac control tra cuu
        '==========================================================================
        Private Sub DisableAll(Optional ByVal value As Boolean = True)
            ThongTinTraCuu1.Visible = Not value
            ThongTinTraCuuChuyenNhan1.Visible = Not value
            btnTimKiem.Visible = False
            btnThemMoi.Visible = False
            btnCapNhat.Visible = False
            btnInRagiay.Visible = False
        End Sub

        '==========================================================================
        '==========================================================================
        Private Function Display_Control() As DataSet
            Dim ds As DataSet
            Dim objDanhSachHoSo As New DanhSachHoSoControl

            objDanhSachHoSoInfo = objDanhSachHoSo.GetDisplayCategoryInfo(Request.Params("TabID"))
            Select Case UCase(objDanhSachHoSoInfo.Control)
                Case strTHONGTINTRACUU
                    ThongTinTraCuu1.Visible = True
                    ThongTinTraCuu1.ThongTinTraCuu = objThongTinTraCuuInfo
                    ds = ThongTinTraCuu1.GetInfofromSearch(objThongTinTraCuuInfo)
                Case strTHONGTINTRACUUCHUYENNHAN
                    ThongTinTraCuuChuyenNhan1.Visible = True
                    ThongTinTraCuuChuyenNhan1.ThongTinTraCuu = objThongTinTraCuuInfo
                    ds = ThongTinTraCuuChuyenNhan1.GetInfofromSearch(objThongTinTraCuuInfo)
                Case Else
                    flagDisplayGrid = False
            End Select

            Return ds
            objDanhSachHoSo = Nothing
        End Function

        '==========================================================================
        '==========================================================================
        Private Sub Display_Button()
            If InStr(objDanhSachHoSoInfo.Button, ";0;") <> 0 Then
                btnTimKiem.Visible = True
            End If
            If InStr(objDanhSachHoSoInfo.Button, ";1;") <> 0 Then
                btnThemMoi.Visible = True
            End If
            If InStr(objDanhSachHoSoInfo.Button, ";2;") <> 0 Then
                btnCapNhat.Visible = True
            End If
            If InStr(objDanhSachHoSoInfo.Button, ";3;") <> 0 Then
                btnInRagiay.Visible = True
            End If
        End Sub

        '==========================================================================
        '==========================================================================
        Private Sub LoadGrid(ByVal ds As DataSet)

            'BindControl.BindDataGrid1(ds, grdDanhSach, True, True, False, "STT", "", "", "", 0, 100, 400, 800, 100, 100, 500, 80, 0, 0)

            'Select Case UCase(objDanhSachHoSoInfo.Control)
            '    Case strTHONGTINTRACUU

            '    Case strTHONGTINTRACUUCHUYENNHAN

            'End Select
            'BindControl.BindDataGrid(ds, grdDanhSach, True, True, False, "STT", "xoa", "", "", 100, 100, 100, 100, 100, 100, 100, 0, 0)
        End Sub

        '==========================================================================
        '==========================================================================
        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThucHien.Click
            Dim ds As DataSet
            If Not flagDisplayGrid Then Exit Sub
            If ddlLinhVuc.SelectedIndex > -1 Then
                lblHeader.Text = ".:: " & ddlLinhVuc.Items.FindByValue(ddlLinhVuc.SelectedValue()).Text & " ::."
                objThongTinTraCuuInfo = Nothing
                objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
                gItemCode = ddlLinhVuc.SelectedValue()
                objThongTinTraCuuInfo.ItemCode = gItemCode

                'bind lại dữ liệu tương ứng với ItemCode
                Select Case UCase(objDanhSachHoSoInfo.Control)
                    Case strTHONGTINTRACUU
                        ThongTinTraCuu1.BindData(objThongTinTraCuuInfo.ItemCode)
                        ThongTinTraCuu1.SetValues(objThongTinTraCuuInfo)
                        ds = ThongTinTraCuu1.GetInfofromSearch(objThongTinTraCuuInfo)
                    Case strTHONGTINTRACUUCHUYENNHAN
                        ThongTinTraCuuChuyenNhan1.BindData(objThongTinTraCuuInfo.ItemCode)
                        ThongTinTraCuuChuyenNhan1.SetValues(objThongTinTraCuuInfo)
                        ds = ThongTinTraCuuChuyenNhan1.GetInfofromSearch(objThongTinTraCuuInfo)
                End Select

                LoadGrid(ds)
            End If
        End Sub

        '==========================================================================
        '==========================================================================
        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTimKiem.Click
            Dim ds As DataSet
            Dim item As New ListItem
            Try
                
                If (UCase(objDanhSachHoSoInfo.Control) = strTHONGTINTRACUU And Not ThongTinTraCuu1 Is Nothing) _
                        Or (UCase(objDanhSachHoSoInfo.Control) = strTHONGTINTRACUUCHUYENNHAN And Not ThongTinTraCuuChuyenNhan1 Is Nothing) Then

                    If ddlLinhVuc.SelectedValue <> objThongTinTraCuuInfo.ItemCode Then
                        item.Value = objThongTinTraCuuInfo.ItemCode
                        item.Text = ddlLinhVuc.Items.FindByValue(objThongTinTraCuuInfo.ItemCode).Text
                        ddlLinhVuc.SelectedIndex = ddlLinhVuc.Items.IndexOf(item)
                    End If

                    Select Case UCase(objDanhSachHoSoInfo.Control)
                        Case strTHONGTINTRACUU
                            objThongTinTraCuuInfo = ThongTinTraCuu1.GetValues()
                            ds = ThongTinTraCuu1.GetInfofromSearch(objThongTinTraCuuInfo)
                        Case strTHONGTINTRACUUCHUYENNHAN
                            objThongTinTraCuuInfo = ThongTinTraCuuChuyenNhan1.GetValues()
                            ds = ThongTinTraCuuChuyenNhan1.GetInfofromSearch(objThongTinTraCuuInfo)
                    End Select
                    LoadGrid(ds)
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
            'release object
            ds = Nothing
            item = Nothing
        End Sub
    End Class
End Namespace