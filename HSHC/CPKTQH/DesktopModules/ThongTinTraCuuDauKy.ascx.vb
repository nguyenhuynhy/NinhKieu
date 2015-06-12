Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class ThongTinTraCuuDauKy
        Inherits PortalQH.PortalModuleControl
        Dim _objThongTinTraCuuInfo As ThongTinTraCuuKDInfo

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTinhTrang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLoaiHinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            _objThongTinTraCuuInfo = New ThongTinTraCuuKDInfo(Request)
        End Sub

#End Region

        '==========================================================================
        '==========================================================================
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                SetAttributesControl()
                _objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                    _objThongTinTraCuuInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                End If
                '_objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
                If Not Page.IsPostBack Then
                    BindData(_objThongTinTraCuuInfo.ItemCode)
                    SetValues(_objThongTinTraCuuInfo)
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            Me.txtTuNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtTuNgay.ClientID & ");")
            Me.txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Me.txtDenNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtDenNgay.ClientID & ");")
            Me.txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
        End Sub
        '==========================================================================
        '==========================================================================
        Public Sub BindData(ByVal ItemCode As String)
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindControl.BindDropDownList_StoreProc(ddlLoaiHinh, True, "", "sp_GetDMLoaiDoanhNghiep", Request.Params("tabid"))
            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDMLoaiHoSo", ItemCode, Request.Params("tabid"))
            BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo", ItemCode, Request.Params("tabid"))
        End Sub

        '==========================================================================
        '==========================================================================
        Public Function GetInfofromSearch(ByVal objThongTinTraCuuInfo As ThongTinTraCuuKDInfo) As DataSet
            Try
                Dim objThongTinTraCuuCtrl As New ThongTinTraCuuKDController
                Return objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuInfo)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Function

        '==========================================================================
        '==========================================================================
        Public Property ThongTinTraCuu() As ThongTinTraCuuKDInfo
            Get
                Return _objThongTinTraCuuInfo
            End Get
            Set(ByVal Value As ThongTinTraCuuKDInfo)
                _objThongTinTraCuuInfo = Value
            End Set
        End Property

        '==========================================================================
        '==========================================================================
        Public Function GetValues() As ThongTinTraCuuKDInfo
            Dim objTTTCInfo As New ThongTinTraCuuKDInfo(Request)
            objTTTCInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objTTTCInfo.HoTen = Me.txtHoTen.Text
            objTTTCInfo.TuNgay = Me.txtTuNgay.Text
            objTTTCInfo.DenNgay = Me.txtDenNgay.Text
            objTTTCInfo.SoNha = Me.txtSoNha.Text
            objTTTCInfo.Duong = Me.ddlDuong.SelectedValue
            objTTTCInfo.Phuong = Me.ddlPhuong.SelectedValue
            objTTTCInfo.SoBienNhan = Me.txtSoBienNhan.Text
            objTTTCInfo.LoaiHoSo = Me.ddlLoaiHoSo.SelectedValue
            objTTTCInfo.TinhTrang = Me.ddlTinhTrang.SelectedValue
            'objTTTCInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            'objTTTCInfo.LoaiHinh = Me.ddlLoaiHinh.SelectedValue
            Return objTTTCInfo
        End Function

        '==========================================================================
        '==========================================================================
        Public Sub SetValues(ByVal objThongTinTraCuuInfo As ThongTinTraCuuKDInfo)
            Me.txtHoTen.Text = objThongTinTraCuuInfo.HoTen
            Me.txtTuNgay.Text = objThongTinTraCuuInfo.TuNgay
            Me.txtDenNgay.Text = objThongTinTraCuuInfo.DenNgay
            Me.txtSoNha.Text = objThongTinTraCuuInfo.SoNha
            Me.txtSoBienNhan.Text = objThongTinTraCuuInfo.SoBienNhan

            If objThongTinTraCuuInfo.Duong <> "" Then
                DdLSelected(ddlDuong, objThongTinTraCuuInfo.Duong)
                'Me.ddlDuong.SelectedValue = objThongTinTraCuuInfo.Duong
            Else
                Me.ddlDuong.SelectedIndex = 0
            End If

            If objThongTinTraCuuInfo.Phuong <> "" Then
                DdLSelected(ddlPhuong, objThongTinTraCuuInfo.Phuong)
                'Me.ddlPhuong.SelectedValue = objThongTinTraCuuInfo.Phuong
            Else
                Me.ddlPhuong.SelectedIndex = 0 'dieu chinh cho phu hop voi phuong
            End If

            'If objThongTinTraCuuInfo.LoaiHinh <> "" Then
            '    DdLSelected(ddlLoaiHinh, objThongTinTraCuuInfo.LoaiHinh)
            'Else
            '    Me.ddlLoaiHinh.SelectedIndex = 0
            'End If

            If objThongTinTraCuuInfo.LoaiHoSo <> "" Then
                DdLSelected(ddlLoaiHoSo, objThongTinTraCuuInfo.LoaiHoSo)
                'Me.ddlLoaiHoSo.SelectedValue = objThongTinTraCuuInfo.LoaiHoSo
            Else
                Me.ddlLoaiHoSo.SelectedIndex = 0
            End If

            If objThongTinTraCuuInfo.TinhTrang <> "" Then
                DdLSelected(ddlTinhTrang, objThongTinTraCuuInfo.TinhTrang)
                'Me.ddlTinhTrang.SelectedValue = objThongTinTraCuuInfo.TinhTrang
            Else
                Me.ddlTinhTrang.SelectedIndex = 0
            End If
        End Sub
    End Class
End Namespace
