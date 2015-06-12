Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class ThongTinSoGiayPhep
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaLinhVucCapPhep As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebsite As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlNguoiKy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtSoLanCapDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLanThayDoi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLanCapPhoBan As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents imgNgayCap As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoGiayPhepGoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhepTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapGoc As System.Web.UI.WebControls.TextBox

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
            If Not Page.IsPostBack Then
               
                init_state()
                AddJavaScript()
                If Not Request.Params("ID") Is Nothing Then
                    bindData()
                End If
                If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                    enableControls(False)
                    txtSoGiayPhep.Text = ""
                    txtGhiChu.Text = ""
                    ddlNguoiKy.SelectedIndex = 0
                Else
                    If Not Request.Params("ID") Is Nothing Then
                        txtSoGiayPhep.Enabled = False
                        txtSoGiayPhepTruoc.Enabled = False
                        txtSoGiayPhepGoc.Enabled = False
                        txtNgayCap.Enabled = False
                        txtNgayCapTruoc.Enabled = False
                        txtNgayCapGoc.Enabled = False
                    End If
                End If

            End If
        End Sub
        Private Sub enableControls(ByVal b As Boolean)
            txtSoGiayPhepGoc.Enabled = b
            txtSoGiayPhepTruoc.Enabled = b
            txtNgayCapGoc.Enabled = b
            txtNgayCapTruoc.Enabled = b
            txtSoBienNhan.Enabled = b
            txtBangHieu.Enabled = b
            ddlMaLinhVucCapPhep.Enabled = b
            'ddlMaHinhThucKinhDoanh.Enabled = b
            ddlMaNganhKinhDoanh.Enabled = b
            txtMatHangKinhDoanh.Enabled = b
            txtVonKinhDoanh.Enabled = b
            txtNgayCap.Enabled = b
            '---
            txtSoNha.Enabled = b
            ddlMaDuong.Enabled = b
            ddlMaPhuong.Enabled = b
            txtDiaChiCu.Enabled = b
            txtDienThoai.Enabled = b
            txtFax.Enabled = b
            txtEmail.Enabled = b
            txtWebsite.Enabled = b
            '---
            txtSoLanCapDoi.Enabled = b
            txtSoLanCapPhoBan.Enabled = b
            txtSoLanThayDoi.Enabled = b
        End Sub
        Private Sub init_state()
            Dim dsLinhVuc As New DataSet
            Dim dsNganh As New DataSet
            Dim objDanhMuc As New DanhMucController

            If txtNgayCap.Text = "" Then txtNgayCap.Text = NgayHienTai()
            If txtNgayCapTruoc.Text = "" Then txtNgayCapTruoc.Text = txtNgayCap.Text
            If txtNgayCapGoc.Text = "" Then txtNgayCapGoc.Text = txtNgayCap.Text

            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            'BindControl.BindDropDownList(ddlMaHinhThucKinhDoanh, "DMHINHTHUCKINHDOANH")
            'BindDropDownList_NguoiKy(ddlNguoiKy)
            'PhuocDD updated Apr 1st 2006
            'Defined users that have Sign Right before
            BindControl.BindDropDownList_StoreProc(Me.ddlNguoiKy, False, "", "sp_getNguoiKy", "CPKT", Request.QueryString("tabid"))
            'txtReload.Text = "0"

            'ThuyTT update:chi lay nhung nganh cap 1 lam nganh kinh doanh chính
            Dim objNganhKD As New NganhKinhDoanhController
            dsLinhVuc = objNganhKD.getLinhVucCapPhep()
            dsNganh = objNganhKD.getNganhKinhDoanhChinh
            objNganhKD = Nothing
            'ThuyTT end

            ddlMaLinhVucCapPhep.DataSource = dsLinhVuc
            ddlMaLinhVucCapPhep.DataTextField = "TenLinhVuc"
            ddlMaLinhVucCapPhep.DataValueField = "MaLinhVuc"
            ddlMaLinhVucCapPhep.DataBind()
            ddlMaLinhVucCapPhep.Items.Insert(0, "")

            ddlMaNganhKinhDoanh.DataSource = dsNganh
            ddlMaNganhKinhDoanh.DataTextField = "TenNganh"
            ddlMaNganhKinhDoanh.DataValueField = "MaNganh"
            ddlMaNganhKinhDoanh.DataBind()
            ddlMaNganhKinhDoanh.Items.Insert(0, "")
            With ctrlScriptComboFilter
                .ConditionID = ddlMaLinhVucCapPhep.ClientID
                .ConditionText = "TenLinhVuc"
                .ConditionValue = "MaLinhVuc"

                .ResultID = ddlMaNganhKinhDoanh.ClientID
                .ResultText = "TenNganh"
                .ResultValue = "MaNganh"
                .ConditionDS = dsLinhVuc
                .ResultDS = dsNganh
            End With

            txtSoLanCapDoi.Text = "0"
            txtSoLanCapPhoBan.Text = "0"
            txtSoLanThayDoi.Text = "0"

            dsLinhVuc = Nothing
            dsNganh = Nothing

        End Sub
        Private Sub bindData()
            Dim strGiayCNDKKDHTXID As String = CStr(Request.Params("ID"))
            Dim objHopTacXaCon As New HopTacXaController
            Dim dsHTX As DataSet
            dsHTX = objHopTacXaCon.getGiayCNDKKDHTX(strGiayCNDKKDHTXID)
            gLoadControlValues(dsHTX, Me)
            'get so giay phep goc
            ViewState.Item("SoGiayPhepTruoc") = txtSoGiayPhep.Text
        End Sub

        Sub AddJavaScript()

            Dim strURLNganhKD As String
            ddlMaLinhVucCapPhep.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")

            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap);")
            imgNgayCap.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap, 'dd/mm/yyyy');")
            txtNgayCap.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCap.ClientID & ");")
            txtNgayCap.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayCapGoc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapGoc);")
            txtNgayCapGoc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapGoc.ClientID & ");")
            txtNgayCapGoc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgayCapTruoc.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapTruoc);")
            txtNgayCapTruoc.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapTruoc.ClientID & ");")
            txtNgayCapTruoc.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtSoGiayPhep.Attributes.Add("onblur", "txtSoGiayPhep_blur()")

            txtSoLanThayDoi.Attributes.Add("onkeypress", "ValidateNumeric()")
            txtSoLanThayDoi.Attributes.Add("onblur", "javascript:CheckNumber(" & txtSoLanThayDoi.ClientID & ");")

            txtSoLanCapDoi.Attributes.Add("onkeypress", "ValidateNumeric()")
            txtSoLanCapDoi.Attributes.Add("onblur", "javascript:CheckNumber(" & txtSoLanCapDoi.ClientID & ");")

            txtSoLanCapPhoBan.Attributes.Add("onkeypress", "ValidateNumeric()")
            txtSoLanCapPhoBan.Attributes.Add("onblur", "javascript:CheckNumber(" & txtSoLanCapPhoBan.ClientID & ");")

            txtDienThoai.Attributes.Add("onkeypress", "ValidateNumeric()")
            txtDienThoai.Attributes.Add("onblur", "javascript:CheckNumber(" & txtDienThoai.ClientID & ");")
            txtVonKinhDoanh.Attributes.Add("onblur", "javascript:CheckData(" & txtVonKinhDoanh.ClientID & ");")
            txtEmail.Attributes.Add("onblur", "javascript:validateEmail(" & txtEmail.ClientID & ");")

            txtSoGiayPhep.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            txtSoGiayPhepGoc.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCapGoc.Attributes.Add("ISNULL", "NOTNULL")
            txtSoGiayPhepTruoc.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayCapTruoc.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaHinhThucKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtMatHangKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtBangHieu.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaLinhVucCapPhep.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganhKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtVonKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
        End Sub
#Region "Properties"
        Public Property SoBienNhan() As String
            Get
                Return txtSoBienNhan.Text
            End Get
            Set(ByVal Value As String)
                txtSoBienNhan.Text = Value
            End Set
        End Property
        Public Property SoGiayPhep() As String
            Get
                Return txtSoGiayPhep.Text
            End Get
            Set(ByVal Value As String)
                txtSoGiayPhep.Text = Value
            End Set
        End Property
        Public Property BangHieu() As String
            Get
                Return txtBangHieu.Text
            End Get
            Set(ByVal Value As String)
                txtBangHieu.Text = Value
            End Set
        End Property
        Public Property MaLinhVucCapPhep() As String
            Get
                Return ddlMaLinhVucCapPhep.SelectedValue
            End Get
            Set(ByVal Value As String)
                ddlMaLinhVucCapPhep.SelectedValue = Value
            End Set
        End Property
        'Public Property MaHinhThucKinhDoanh() As String
        '    Get
        '        Return ddlMaHinhThucKinhDoanh.SelectedValue
        '    End Get
        '    Set(ByVal Value As String)
        '        ddlMaHinhThucKinhDoanh.SelectedValue = Value
        '    End Set
        'End Property
        Public Property MaNganhKinhDoanh() As String
            Get
                Return ddlMaNganhKinhDoanh.SelectedValue
            End Get
            Set(ByVal Value As String)
                ddlMaNganhKinhDoanh.SelectedValue = Value
            End Set
        End Property
        Public Property MatHangKinhDoanh() As String
            Get
                Return txtMatHangKinhDoanh.Text
            End Get
            Set(ByVal Value As String)
                txtMatHangKinhDoanh.Text = Value
            End Set
        End Property
        Public Property VonKinhDoanh() As String
            Get
                Return txtVonKinhDoanh.Text
            End Get
            Set(ByVal Value As String)
                txtVonKinhDoanh.Text = Value
            End Set
        End Property
        Public Property NgayCap() As String
            Get
                Return txtNgayCap.Text
            End Get
            Set(ByVal Value As String)
                txtNgayCap.Text = Value
            End Set
        End Property
        Public Property SoNha() As String
            Get
                Return txtSoNha.Text
            End Get
            Set(ByVal Value As String)
                txtSoNha.Text = Value
            End Set
        End Property
        Public Property MaDuong() As String
            Get
                Return ddlMaDuong.SelectedValue
            End Get
            Set(ByVal Value As String)
                ddlMaDuong.SelectedValue = Value
            End Set
        End Property
        Public Property MaPhuong() As String
            Get
                Return ddlMaPhuong.SelectedValue
            End Get
            Set(ByVal Value As String)
                ddlMaPhuong.SelectedValue = Value
            End Set
        End Property
        Public Property DiaChiCu() As String
            Get
                Return txtDiaChiCu.Text
            End Get
            Set(ByVal Value As String)
                txtDiaChiCu.Text = Value
            End Set
        End Property
        Public Property DienThoai() As String
            Get
                Return txtDienThoai.Text
            End Get
            Set(ByVal Value As String)
                txtDienThoai.Text = Value
            End Set
        End Property
        Public Property Fax() As String
            Get
                Return txtFax.Text
            End Get
            Set(ByVal Value As String)
                txtFax.Text = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return txtEmail.Text
            End Get
            Set(ByVal Value As String)
                txtEmail.Text = Value
            End Set
        End Property
        Public Property Website() As String
            Get
                Return txtWebsite.Text
            End Get
            Set(ByVal Value As String)
                txtWebsite.Text = Value
            End Set
        End Property
        Public Property SoLanCapDoi() As String
            Get
                Return txtSoLanCapDoi.Text
            End Get
            Set(ByVal Value As String)
                txtSoLanCapDoi.Text = Value
            End Set
        End Property
        Public Property SoLanThayDoi() As String
            Get
                Return txtSoLanThayDoi.Text
            End Get
            Set(ByVal Value As String)
                txtSoLanThayDoi.Text = Value
            End Set
        End Property
        Public Property SoLanCapPhoBan() As String
            Get
                Return txtSoLanCapPhoBan.Text
            End Get
            Set(ByVal Value As String)
                txtSoLanCapPhoBan.Text = Value
            End Set
        End Property
        Public Property GhiChu() As String
            Get
                Return txtGhiChu.Text
            End Get
            Set(ByVal Value As String)
                txtGhiChu.Text = Value
            End Set
        End Property
        Public Property NguoiKy() As String
            Get
                Return ddlNguoiKy.SelectedValue
            End Get
            Set(ByVal Value As String)
                ddlNguoiKy.SelectedValue = Value
            End Set
        End Property
        Public Property SoGiayPhepGoc() As String
            Get
                Return txtSoGiayPhepGoc.Text
            End Get
            Set(ByVal Value As String)
                txtSoGiayPhepGoc.Text = Value
            End Set
        End Property
        Public Property NgayCapGoc() As String
            Get
                Return txtNgayCapGoc.Text
            End Get
            Set(ByVal Value As String)
                txtNgayCapGoc.Text = Value
            End Set
        End Property
        Public Property SoGiayPhepTruoc() As String
            Get
                Return txtSoGiayPhepTruoc.Text
            End Get
            Set(ByVal Value As String)
                txtSoGiayPhepTruoc.Text = Value
            End Set
        End Property
        Public Property NgayCapTruoc() As String
            Get
                Return txtNgayCapTruoc.Text
            End Get
            Set(ByVal Value As String)
                txtNgayCapTruoc.Text = Value
            End Set
        End Property
        Public Function getGiayPhepTruoc() As String
            If ViewState.Item("SoGiayPhepTruoc") Is Nothing Then
                Return ""
            End If
            Return CStr(ViewState.Item("SoGiayPhepTruoc"))
        End Function


#End Region





    End Class
End Namespace
