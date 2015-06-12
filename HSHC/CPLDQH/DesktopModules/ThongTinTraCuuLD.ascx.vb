Imports PortalQH
Imports System.Configuration
Namespace CPLDQH
    Public Class ThongTinTraCuuLD
        Inherits PortalQH.PortalModuleControl
        Dim _objThongTinTraCuuLDInfo As ThongTinTraCuuLDInfo

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
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayCongVan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents ddlPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            _objThongTinTraCuuLDInfo = New ThongTinTraCuuLDInfo(Request)
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

                cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                txtNgayCongVan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtNgayCongVan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCongVan.ClientID & ");")
                cmdNgayCongVan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayCongVan)

                _objThongTinTraCuuLDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                    _objThongTinTraCuuLDInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                End If
                If Not Page.IsPostBack Then
                    BindData(_objThongTinTraCuuLDInfo.ItemCode)
                    SetValues(_objThongTinTraCuuLDInfo)
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
            'BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            'BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            'Doan loc duong theo phuong
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
            Dim objDanhMuc As New DanhMucController
            dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
            dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
            BindDropDownList_Dataset(ddlPhuong, dsPhuong, "Ten", "Ma", True, "")
            BindDropDownList_Dataset(ddlDuong, dsDuong, "TenDuong", "MaDuong", True, "")
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
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
                'imgNgayCongVan.Visible = True
                cmdNgayCongVan.Visible = True
                optLoaiCongVan.Visible = True
            Else
                lblNgay.Visible = False
                txtNgayCongVan.Visible = False
                'imgNgayCongVan.Visible = False
                cmdNgayCongVan.Visible = False
                optLoaiCongVan.Visible = False
            End If
        End Sub

        '==========================================================================
        '==========================================================================
        Public Function GetInfofromSearch(ByVal objThongTinTraCuulDInfo As ThongTinTraCuuLDInfo) As DataSet
            Try
                Dim objThongTinTraCuuCtrl As New ThongTinTraCuuLDController
                Return objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuulDInfo)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Function

        '==========================================================================
        '==========================================================================
        Public Property ThongTinTraCuu() As ThongTinTraCuuLDInfo
            Get
                Return _objThongTinTraCuuLDInfo
            End Get
            Set(ByVal Value As ThongTinTraCuuLDInfo)
                _objThongTinTraCuuLDInfo = Value
            End Set
        End Property

        '==========================================================================
        '==========================================================================
        Public Function GetValues() As ThongTinTraCuuLDInfo
            Dim objTTTCInfo As New ThongTinTraCuuLDInfo(Request)
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
        Public Sub SetValues(ByVal objThongTinTraCuulDInfo As ThongTinTraCuuLDInfo)
            Me.txtHoTen.Text = objThongTinTraCuulDInfo.HoTen
            Me.txtTuNgay.Text = objThongTinTraCuulDInfo.TuNgay
            Me.txtDenNgay.Text = objThongTinTraCuulDInfo.DenNgay
            Me.txtSoNha.Text = objThongTinTraCuulDInfo.SoNha
            Me.txtSoBienNhan.Text = objThongTinTraCuulDInfo.SoBienNhan
            If objThongTinTraCuulDInfo.Duong <> "" Then
                Me.ddlDuong.SelectedValue = objThongTinTraCuulDInfo.Duong
            Else
                Me.ddlDuong.SelectedIndex = 0
            End If

            If objThongTinTraCuulDInfo.Phuong <> "" Then
                Me.ddlPhuong.SelectedValue = objThongTinTraCuulDInfo.Phuong
            Else
                Me.ddlPhuong.SelectedIndex = 0
            End If

            If objThongTinTraCuulDInfo.LoaiHoSo <> "" Then
                Me.ddlLoaiHoSo.SelectedValue = objThongTinTraCuulDInfo.LoaiHoSo
            Else
                Me.ddlLoaiHoSo.SelectedIndex = 0
            End If

            If objThongTinTraCuulDInfo.TinhTrang <> "" Then
                Me.ddlTinhTrang.SelectedValue = objThongTinTraCuulDInfo.TinhTrang
            Else
                Me.ddlTinhTrang.SelectedIndex = 0
            End If
            Me.txtNgayCongVan.Text = objThongTinTraCuulDInfo.NgayCongVan
            If objThongTinTraCuulDInfo.LoaiCongVan <> "" Then
                optLoaiCongVan.SelectedValue = objThongTinTraCuulDInfo.LoaiCongVan
            End If

        End Sub
    End Class
End Namespace
