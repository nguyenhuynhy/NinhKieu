Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ThongTinTraCuuMotCuaPhuongXa
        Inherits PortalQH.PortalModuleControl
        Dim _objThongTinTraCuuInfo As ThongTinTraCuuPhuongXaInfo
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Private _objTraCuu As TraCuu



#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTinhTrang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            _objThongTinTraCuuInfo = New ThongTinTraCuuPhuongXaInfo(Request)
        End Sub

#End Region

        '==========================================================================
        '==========================================================================
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
                cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
                cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                _objThongTinTraCuuInfo = CType(Session("ThongTinTraCuuPhuongXaInfo"), ThongTinTraCuuPhuongXaInfo)

                If (Not Me.IsPostBack) Then
                    BindData(_objThongTinTraCuuInfo.ItemCode)
                    SetValues(_objThongTinTraCuuInfo)
                End If

                If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                    Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlDuong))
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ItemCode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	3/31/2007	Updated
        '''     Desc. : Cho chon tat ca cac phuong, duong
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub BindData(ByVal ItemCode As String)
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG", "", True)
            BindControl.BindDropDownList(ddlDuong, "DMDUONG", "", True)

            'Doan loc duong theo phuong
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Dim dsPhuong As New DataSet
                Dim dsDuong As New DataSet
                Dim objDanhMuc As New DanhMucController
                dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
                dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
                BindDropDownList_Dataset(ddlPhuong, dsPhuong, "Ten", "Ma", True, "")
                BindDropDownList_Dataset(ddlDuong, dsDuong, "TenDuong", "MaDuong", True, "")

                With ctrlScriptComboFilter
                    .ConditionID = ddlPhuong.ClientID
                    .ConditionText = "Ten"
                    .ConditionValue = "Ma"
                    .ResultID = ddlDuong.ClientID
                    .ResultText = "TenDuong"
                    .ResultValue = "MaDuong"
                    .ConditionDS = dsPhuong
                    .ResultDS = dsDuong
                End With
                ddlPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            End If

            '-------------------------------------------------------------

            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDMLoaiHoSoMotCua", ItemCode, Request.Params("tabid"))
            BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo", ItemCode, Request.Params("tabid"))
        End Sub

        '==========================================================================
        '==========================================================================
        Public Function GetInfofromSearch(ByVal objThongTinTraCuuInfo As ThongTinTraCuuPhuongXaInfo) As DataSet
            Try
                Dim objThongTinTraCuuCtrl As New ThongTinTraCuuPhuongXaController
                Return objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuInfo)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Function

        '==========================================================================
        '==========================================================================
        Public Property ThongTinTraCuu() As ThongTinTraCuuPhuongXaInfo
            Get
                Return _objThongTinTraCuuInfo
            End Get
            Set(ByVal Value As ThongTinTraCuuPhuongXaInfo)
                _objThongTinTraCuuInfo = Value
            End Set
        End Property
        Public Property TraCuu() As TraCuu
            Get
                Return _objTraCuu
            End Get
            Set(ByVal Value As TraCuu)
                _objTraCuu = Value
            End Set
        End Property

        Public Function GetValues() As ThongTinTraCuuPhuongXaInfo
            '_objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            _objThongTinTraCuuInfo.HoTen = Me.txtHoTen.Text
            _objThongTinTraCuuInfo.TuNgay = Me.txtTuNgay.Text
            _objThongTinTraCuuInfo.DenNgay = Me.txtDenNgay.Text
            _objThongTinTraCuuInfo.SoNha = Me.txtSoNha.Text
            _objThongTinTraCuuInfo.Duong = Me.ddlDuong.SelectedValue
            _objThongTinTraCuuInfo.Phuong = Me.ddlPhuong.SelectedValue
            _objThongTinTraCuuInfo.SoBienNhan = Me.txtSoBienNhan.Text
            _objThongTinTraCuuInfo.LoaiHoSo = Me.ddlLoaiHoSo.SelectedValue
            _objThongTinTraCuuInfo.TinhTrang = Me.ddlTinhTrang.SelectedValue
            _objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            Return _objThongTinTraCuuInfo
        End Function

        Public Sub SetValues(ByVal objThongTinTraCuuInfo As ThongTinTraCuuPhuongXaInfo)
            Me.txtHoTen.Text = objThongTinTraCuuInfo.HoTen
            Me.txtTuNgay.Text = objThongTinTraCuuInfo.TuNgay
            Me.txtDenNgay.Text = objThongTinTraCuuInfo.DenNgay
            Me.txtSoNha.Text = objThongTinTraCuuInfo.SoNha
            Me.txtSoBienNhan.Text = objThongTinTraCuuInfo.SoBienNhan

            If objThongTinTraCuuInfo.Duong <> "" Then
                DdLSelected(ddlDuong, objThongTinTraCuuInfo.Duong)
            Else
                Me.ddlDuong.SelectedIndex = 0
            End If

            If objThongTinTraCuuInfo.Phuong <> "" Then
                DdLSelected(ddlPhuong, objThongTinTraCuuInfo.Phuong)
            Else
                Me.ddlPhuong.SelectedIndex = 0 'dieu chinh cho phu hop voi phuong
            End If

            If objThongTinTraCuuInfo.LoaiHoSo <> "" Then
                DdLSelected(ddlLoaiHoSo, objThongTinTraCuuInfo.LoaiHoSo)
            Else
                Me.ddlLoaiHoSo.SelectedIndex = 0
            End If

            If objThongTinTraCuuInfo.TinhTrang <> "" Then
                DdLSelected(ddlTinhTrang, objThongTinTraCuuInfo.TinhTrang)
            Else
                Me.ddlTinhTrang.SelectedIndex = 0
            End If
        End Sub
    End Class
End Namespace
