﻿Imports PortalQH
Imports System.Configuration
Namespace CPXD
    Public Class ThongTinTraCuuKD
        Inherits PortalQH.PortalModuleControl
        Dim _objThongTinTraCuuKDInfo As CPXD.ThongTinTraCuuKDInfo

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
        Protected WithEvents lblNgay As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayCongVan As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCongVan As System.Web.UI.WebControls.Image
        Protected WithEvents optLoaiCongVan As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents pnThongTinTraCuu As System.Web.UI.WebControls.Panel
        Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
        Protected WithEvents Radiobuttonlist1 As System.Web.UI.WebControls.RadioButtonList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            _objThongTinTraCuuKDInfo = New ThongTinTraCuuKDInfo(Request)
        End Sub

#End Region

        '==========================================================================
        '==========================================================================
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
                Me.imgTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
                Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
                Me.imgDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
                Me.txtNgayCongVan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayCongVan.ClientID & ");")
                Me.imgNgayCongVan.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtNgayCongVan.ClientID & ", 'dd/mm/yyyy')")
                _objThongTinTraCuuKDInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                If CType(Session.Item("ActiveDB"), String) <> ConfigurationSettings.AppSettings("HSHCDB") Then
                    _objThongTinTraCuuKDInfo.ItemCode = ConfigurationSettings.AppSettings("LINHVUC_DEFAULT" & CType(Session.Item("ActiveDB"), String))
                End If
                If Not Page.IsPostBack Then
                    BindData(_objThongTinTraCuuKDInfo.ItemCode)
                    SetValues(_objThongTinTraCuuKDInfo)
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
            'Chia lam hai truong hop neu edit thi cap do =0 (TT-DX-TD) else cap do = 1 (HSD)
            'If Not Request.Params("Edit") Is Nothing Then 'truong hop edit
            'If Not Request.Params("ctl") Is Nothing Then
            '   BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo_KT", ItemCode, Request.Params("tabid"), "0")
            'Else
            '   BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo_KT", ItemCode, Request.Params("tabid"), "1")
            'End If
            BindControl.BindDropDownList_StoreProc(ddlTinhTrang, True, "", "sp_getTinhTrangHoSo", ItemCode, Request.Params("tabid"))
            If GetParamByID("tab" & Request.Params("TabID").ToString, glbXMLFile) = "VAOSOCONGVAN" Or GetParamByID("tab" & Request.Params("TabID").ToString, glbXMLFile) = "INSOCONGVAN" Then
                lblNgay.Visible = True
                txtNgayCongVan.Visible = True
                imgNgayCongVan.Visible = True
                optLoaiCongVan.Visible = True
                txtTuNgay.Text = ""
                txtDenNgay.Text = ""
                txtNgayCongVan.Text = NgayHienTai()
            Else
                lblNgay.Visible = False
                txtNgayCongVan.Visible = False
                imgNgayCongVan.Visible = False
                optLoaiCongVan.Visible = False
            End If
        End Sub

        '==========================================================================
        '==========================================================================
        'Public Function GetInfofromSearch(ByVal objThongTinTraCuuKDInfo As ThongTinTraCuuKDInfo) As DataSet
        '    Try
        '        Dim objThongTinTraCuuCtrl As New ThongTinTraCuuKDController
        '        Return objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuKDInfo)
        '    Catch ex As Exception
        '        ProcessModuleLoadException(Me, ex)
        '    End Try
        'End Function

        '==========================================================================
        '==========================================================================
        Public Property ThongTinTraCuu() As ThongTinTraCuuKDInfo
            Get
                Return _objThongTinTraCuuKDInfo
            End Get
            Set(ByVal Value As ThongTinTraCuuKDInfo)
                _objThongTinTraCuuKDInfo = Value
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
            objTTTCInfo.NguoiTacNghiep = Session.Item("UserName").ToString
            objTTTCInfo.NgayCongVan = Me.txtNgayCongVan.Text
            objTTTCInfo.LoaiCongVan = Me.optLoaiCongVan.SelectedValue
            Return objTTTCInfo
        End Function

        '==========================================================================
        '==========================================================================
        Public Sub SetValues(ByVal objThongTinTraCuuKDInfo As ThongTinTraCuuKDInfo)
            Me.txtHoTen.Text = objThongTinTraCuuKDInfo.HoTen
            Me.txtTuNgay.Text = objThongTinTraCuuKDInfo.TuNgay
            Me.txtDenNgay.Text = objThongTinTraCuuKDInfo.DenNgay
            Me.txtSoNha.Text = objThongTinTraCuuKDInfo.SoNha
            Me.txtSoBienNhan.Text = objThongTinTraCuuKDInfo.SoBienNhan
            If objThongTinTraCuuKDInfo.Duong <> "" Then
                Me.ddlDuong.SelectedValue = objThongTinTraCuuKDInfo.Duong
            Else
                Me.ddlDuong.SelectedIndex = 0
            End If

            If objThongTinTraCuuKDInfo.Phuong <> "" Then
                Me.ddlPhuong.SelectedValue = objThongTinTraCuuKDInfo.Phuong
            Else
                Me.ddlPhuong.SelectedIndex = 0
            End If

            If objThongTinTraCuuKDInfo.LoaiHoSo <> "" Then
                Me.ddlLoaiHoSo.SelectedValue = objThongTinTraCuuKDInfo.LoaiHoSo
            Else
                Me.ddlLoaiHoSo.SelectedIndex = 0
            End If

            If objThongTinTraCuuKDInfo.TinhTrang <> "" Then
                Me.ddlTinhTrang.SelectedValue = objThongTinTraCuuKDInfo.TinhTrang
            Else
                Me.ddlTinhTrang.SelectedIndex = -1
            End If
            Me.txtNgayCongVan.Text = objThongTinTraCuuKDInfo.NgayCongVan
            If objThongTinTraCuuKDInfo.LoaiCongVan <> "" Then
                optLoaiCongVan.SelectedValue = objThongTinTraCuuKDInfo.LoaiCongVan
            End If
        End Sub
    End Class
End Namespace
