Imports PortalQH
Imports System.Configuration
Namespace CPVHQH
    Public Class ThongTinTraCuuVH
        Inherits PortalQH.PortalModuleControl
        Dim _objThongTinTraCuuVHInfo As ThongTinTraCuuVHInfo

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
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblNgay As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents optLoaiCongVan As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents imgNgayCongVan As System.Web.UI.WebControls.Image
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayCongVan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            _objThongTinTraCuuVHInfo = New ThongTinTraCuuVHInfo(Request)
        End Sub

#End Region

        '==========================================================================
        '==========================================================================
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
                cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
                'cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
                cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
                txtNgayCongVan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtNgayCongVan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCongVan.ClientID & ");")
                cmdNgayCongVan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCongVan)
                _objThongTinTraCuuVHInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                    _objThongTinTraCuuVHInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                End If
                If Not Page.IsPostBack Then
                    BindData(_objThongTinTraCuuVHInfo.ItemCode)
                    SetValues(_objThongTinTraCuuVHInfo)
                End If
                If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                    Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlDuong))
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        '==========================================================================
        '==========================================================================
        Public Sub BindData(ByVal ItemCode As String)
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
            Else
                BindControl.BindDropDownList(ddlDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            End If

            '-------------------------------------------------------------
            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDMLoaiHoSo", ItemCode, Request.Params("tabid"))
            'Chia lam hai truong hop neu edit thi cap do =0 (TT-DX-TD) else cap do = 1 (HSD)
            'If Not Request.Params("Edit") Is Nothing Then 'truong hop edit
            'If Not Request.Params("ctl") Is Nothing Then
            '    BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo_KT", ItemCode, Request.Params("tabid"), "0")
            'Else
            '    BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo_KT", ItemCode, Request.Params("tabid"), "1")
            'End If
            BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo", ItemCode, Request.Params("tabid"))
            If GetParamByID("tab" & Request.Params("TabID").ToString, glbXMLFile) = "VAOSOCONGVAN" Then
                lblNgay.Visible = True
                txtNgayCongVan.Visible = True
                imgNgayCongVan.Visible = True
                optLoaiCongVan.Visible = True
            Else
                lblNgay.Visible = False
                txtNgayCongVan.Visible = False
                imgNgayCongVan.Visible = False
                optLoaiCongVan.Visible = False
            End If
        End Sub

        '==========================================================================
        '==========================================================================
        Public Function GetInfofromSearch(ByVal objThongTinTraCuuVHInfo As ThongTinTraCuuVHInfo) As DataSet
            Try
                Dim objThongTinTraCuuCtrl As New ThongTinTraCuuVHController
                Return objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuVHInfo)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Function

        '==========================================================================
        '==========================================================================
        Public Property ThongTinTraCuu() As ThongTinTraCuuVHInfo
            Get
                Return _objThongTinTraCuuVHInfo
            End Get
            Set(ByVal Value As ThongTinTraCuuVHInfo)
                _objThongTinTraCuuVHInfo = Value
            End Set
        End Property

        '==========================================================================
        '==========================================================================
        Public Function GetValues() As ThongTinTraCuuVHInfo
            Dim objTTTCInfo As New ThongTinTraCuuVHInfo(Request)
            objTTTCInfo.ItemCode = CType(Session.Item("ItemCode"), String)
            objTTTCInfo.HoTen = Me.txtHoTen.Text.Replace("'", "''")
            objTTTCInfo.TuNgay = Me.txtTuNgay.Text
            objTTTCInfo.DenNgay = Me.txtDenNgay.Text
            objTTTCInfo.SoNha = Me.txtSoNha.Text.Replace("'", "''")
            objTTTCInfo.Duong = Me.ddlDuong.SelectedValue
            objTTTCInfo.Phuong = Me.ddlPhuong.SelectedValue
            objTTTCInfo.SoBienNhan = Me.txtSoBienNhan.Text.Replace("'", "''")
            objTTTCInfo.LoaiHoSo = Me.ddlLoaiHoSo.SelectedValue
            objTTTCInfo.TinhTrang = Me.ddlTinhTrang.SelectedValue
            objTTTCInfo.NgayCongVan = Me.txtNgayCongVan.Text
            objTTTCInfo.LoaiCongVan = Me.optLoaiCongVan.SelectedValue
            Return objTTTCInfo
        End Function

        '==========================================================================
        '==========================================================================
        Public Sub SetValues(ByVal objThongTinTraCuuVHInfo As ThongTinTraCuuVHInfo)
            Me.txtHoTen.Text = objThongTinTraCuuVHInfo.HoTen
            Me.txtTuNgay.Text = objThongTinTraCuuVHInfo.TuNgay
            Me.txtDenNgay.Text = objThongTinTraCuuVHInfo.DenNgay
            Me.txtSoNha.Text = objThongTinTraCuuVHInfo.SoNha
            Me.txtSoBienNhan.Text = objThongTinTraCuuVHInfo.SoBienNhan
            If objThongTinTraCuuVHInfo.Duong <> "" Then
                Me.ddlDuong.SelectedValue = objThongTinTraCuuVHInfo.Duong
            Else
                Me.ddlDuong.SelectedIndex = 0
            End If

            If objThongTinTraCuuVHInfo.Phuong <> "" Then
                Me.ddlPhuong.SelectedValue = objThongTinTraCuuVHInfo.Phuong
            Else
                Me.ddlPhuong.SelectedIndex = 0
            End If

            If objThongTinTraCuuVHInfo.LoaiHoSo <> "" Then
                Me.ddlLoaiHoSo.SelectedValue = objThongTinTraCuuVHInfo.LoaiHoSo
            Else
                Me.ddlLoaiHoSo.SelectedIndex = 0
            End If

            If objThongTinTraCuuVHInfo.TinhTrang <> "" Then
                Me.ddlTinhTrang.SelectedValue = objThongTinTraCuuVHInfo.TinhTrang
            Else
                Me.ddlTinhTrang.SelectedIndex = 0
            End If
            Me.txtNgayCongVan.Text = objThongTinTraCuuVHInfo.NgayCongVan
            If objThongTinTraCuuVHInfo.LoaiCongVan <> "" Then
                optLoaiCongVan.SelectedValue = objThongTinTraCuuVHInfo.LoaiCongVan
            End If

        End Sub
    End Class
End Namespace
