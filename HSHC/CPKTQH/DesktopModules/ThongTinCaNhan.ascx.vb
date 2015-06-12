Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class ThongTinCaNhan
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanToc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNay As System.Web.UI.WebControls.TextBox

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
           
                addJavaScript()
                If Not Request.Params("ID") Is Nothing Then
                    bindData()
                End If

                If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                    enableControls(False)
                End If
            End If
        End Sub
#Region "properties"
        Public Property HoTen() As String
            Get
                Return txtHoTen.Text
            End Get
            Set(ByVal Value As String)
                txtHoTen.Text = Value
            End Set
        End Property
        Public Property NgaySinh() As String
            Get
                Return txtNgaySinh.Text
            End Get
            Set(ByVal Value As String)
                txtNgaySinh.Text = Value
            End Set
        End Property
        Public Property GioiTinh() As String
            Get
                Return ddlGioiTinh.SelectedValue
            End Get
            Set(ByVal Value As String)
                ddlGioiTinh.SelectedValue = Value
            End Set
        End Property
        Public Property DanToc() As String
            Get
                Return txtHoTen.Text
            End Get
            Set(ByVal Value As String)
                txtHoTen.Text = Value
            End Set
        End Property
        Public Property SoCMND() As String
            Get
                Return txtSoCMND.Text
            End Get
            Set(ByVal Value As String)
                txtSoCMND.Text = Value
            End Set
        End Property
        Public Property NoiCapCMND() As String
            Get
                Return txtNoiCapCMND.Text
            End Get
            Set(ByVal Value As String)
                txtNoiCapCMND.Text = Value
            End Set
        End Property
        Public Property NgayCapCMND() As String
            Get
                Return txtNgayCapCMND.Text
            End Get
            Set(ByVal Value As String)
                txtNgayCapCMND.Text = Value
            End Set
        End Property
        Public Property DiaChiThuongTru() As String
            Get
                Return txtDiaChiThuongTru.Text
            End Get
            Set(ByVal Value As String)
                txtDiaChiThuongTru.Text = Value
            End Set
        End Property
        Public Property ChoOHienNay() As String
            Get
                Return txtChoOHienNay.Text
            End Get
            Set(ByVal Value As String)
                txtChoOHienNay.Text = Value
            End Set
        End Property
#End Region
        Private Sub enableControls(ByVal b As Boolean)
            txtHoTen.Enabled = b
            ddlGioiTinh.Enabled = b
            txtNgaySinh.Enabled = b
            txtDanToc.Enabled = b
            txtSoCMND.Enabled = b
            txtNoiCapCMND.Enabled = b
            txtNgayCapCMND.Enabled = b
            txtDiaChiThuongTru.Enabled = b
            txtChoOHienNay.Enabled = b
        End Sub
        Private Sub addJavaScript()
            'txtSoCMND.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMND.ClientID & ");")

            txtNgayCapCMND.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMND);")
            txtNgayCapCMND.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapCMND.ClientID & ");")
            txtNgayCapCMND.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgaySinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinh);")
            txtNgaySinh.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgaySinh.ClientID & ");")
            txtNgaySinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

        End Sub
        Private Sub bindData()
            Dim strGiayCNDKKDHTXID As String = CStr(Request.Params("ID"))
            Dim objHopTacXaCon As New HopTacXaController
            Dim dsHTX As DataSet
            dsHTX = objHopTacXaCon.getGiayCNDKKDHTX(strGiayCNDKKDHTXID)
            gLoadControlValues(dsHTX, Me)
        End Sub

    End Class
End Namespace

