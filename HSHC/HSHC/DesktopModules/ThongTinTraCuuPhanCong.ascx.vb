Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ThongTinTraCuuPhanCong
        Inherits PortalQH.PortalModuleControl

        Dim _objThongTinTraCuuInfo As ThongTinTraCuuInfo
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents ddlTinhTrangChuyenNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNguoiChuyen As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNguoiNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTinhTrang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            _objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
                cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)

                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
                cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)

                _objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                    _objThongTinTraCuuInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                End If
                If Not Page.IsPostBack Then
                    BindData(_objThongTinTraCuuInfo.ItemCode)
                    SetValues(_objThongTinTraCuuInfo)
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        '==========================================================================
        '==========================================================================
        Public Sub BindData(ByVal ItemCode As String)
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDMLoaiHoSo", ItemCode, Request.Params("tabid"))
            BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_GetDMTinhTrang", ItemCode, Request.Params("tabid"))
            BindControl.BindDropDownList_StoreProc(ddlNguoiChuyen, True, "", "sp_GetNguoiChuyenNhan", Request.Params("tabid"), ItemCode, "c")
            BindControl.BindDropDownList_StoreProc(ddlNguoiNhan, True, "", "sp_GetNguoiChuyenNhan", Request.Params("tabid"), ItemCode, "n")
        End Sub

        '==========================================================================
        '==========================================================================
        Public Property ThongTinTraCuu() As ThongTinTraCuuInfo
            Get
                Return _objThongTinTraCuuInfo
            End Get
            Set(ByVal Value As ThongTinTraCuuInfo)
                _objThongTinTraCuuInfo = Value
            End Set
        End Property

        '==========================================================================
        '==========================================================================
        Public Function GetValues() As ThongTinTraCuuInfo
            Dim objTTTCInfo As New ThongTinTraCuuInfo(Request)
            objTTTCInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objTTTCInfo.TuNgay = Me.txtTuNgay.Text
            objTTTCInfo.DenNgay = Me.txtDenNgay.Text
            objTTTCInfo.SoNha = Me.txtSoNha.Text
            objTTTCInfo.Duong = Me.ddlDuong.SelectedValue
            objTTTCInfo.Phuong = Me.ddlPhuong.SelectedValue
            objTTTCInfo.SoBienNhan = Me.txtSoBienNhan.Text
            objTTTCInfo.LoaiHoSo = Me.ddlLoaiHoSo.SelectedValue
            objTTTCInfo.TinhTrang = Me.ddlTinhTrang.SelectedValue
            Return objTTTCInfo
        End Function

        '==========================================================================
        '==========================================================================
        Public Sub SetValues(ByVal objThongTinTraCuuInfo As ThongTinTraCuuInfo)
            Me.txtTuNgay.Text = objThongTinTraCuuInfo.TuNgay
            Me.txtDenNgay.Text = objThongTinTraCuuInfo.DenNgay
            Me.txtSoNha.Text = objThongTinTraCuuInfo.SoNha
            If objThongTinTraCuuInfo.Duong <> "" Then Me.ddlDuong.SelectedValue = objThongTinTraCuuInfo.Duong
            If objThongTinTraCuuInfo.Phuong <> "" Then Me.ddlPhuong.SelectedValue = objThongTinTraCuuInfo.Phuong
            If objThongTinTraCuuInfo.LoaiHoSo <> "" Then Me.ddlLoaiHoSo.SelectedValue = objThongTinTraCuuInfo.LoaiHoSo
            If objThongTinTraCuuInfo.TinhTrang <> "" Then Me.ddlTinhTrang.SelectedValue = objThongTinTraCuuInfo.TinhTrang
            Me.txtSoBienNhan.Text = objThongTinTraCuuInfo.SoBienNhan
        End Sub
    End Class
End Namespace