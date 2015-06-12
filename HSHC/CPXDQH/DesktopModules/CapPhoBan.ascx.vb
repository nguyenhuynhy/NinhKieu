Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports PortalQH
Namespace CPXD
    Public Class CapPhoBan
        Inherits PortalQH.PortalModuleControl
        Private pID As String = ""
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTienBangChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaHinhThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Private Const strURL As String = "CPXD/DesktopModules/TimKiemGiayCNDKKD.aspx"

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.Image
        Protected WithEvents btnXoa As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCapPhoBan As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayCapPhoBan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label

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
            'Put user code to initialize the page here
            If Not Request.Params("ID") Is Nothing Then
                pID = Request.Params("ID")
                txtHoSoTiepNhanID.Text = Request.Params("ID")
            End If
            SetAttribute()
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaPhuongThucKinhDoanh, "DMPHUONGTHUCKINHDOANH")
                BindControl.BindDropDownList(ddlMaHinhThucKinhDoanh, "DMHINHTHUCKINHDOANH")
                BindData(pID)
                txtReload.Text = "0"
            End If

            If Trim(txtSoGiayPhep.Text) <> "" And txtReload.Text = "1" Then
                GetGiayCNDKKD()
                txtReload.Text = "0"
            End If

            btnDanhSach.Visible = CType(Request.Params("AddNew"), Boolean)
            btnDanhSachGP.Visible = CType(Request.Params("AddNew"), Boolean)
            lblSoBN.Visible = Not CType(Request.Params("AddNew"), Boolean)
            lblSoGP.Visible = Not CType(Request.Params("AddNew"), Boolean)

            SetStatus(CType(Request.Params("AddNew"), Boolean))
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", gActiveDB, btnIn, Me)
            txtTienBangChu.Text = Trim(Trans_VietNam(Val(Replace(Replace(txtVonKinhDoanh.Text, ".", ""), ",", ".")))) & " đồng"
        End Sub
        Private Sub SetStatus(ByVal flgAddNew As Boolean)
            btnDanhSachGP.Visible = flgAddNew
            lblSoGP.Visible = Not flgAddNew
            'txtSoGiayPhep.ReadOnly = Not flgAddNew
            If txtSoBienNhan.Text = "" Then
                btnDanhSachGP.Visible = False
                lblSoGP.Visible = True
            End If
        End Sub
        Private Sub GetGiayCNDKKD()
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep1(txtSoGiayPhep.Text)
            gLoadControlValues(ds, Me)
            ds = Nothing
        End Sub
        Sub BindData(ByVal id As String)
            Dim objCapPhoBan As New CapPhoBanController
            Dim ds As DataSet
            ds = objCapPhoBan.GetCapPhoBan(id)
            gLoadControlValues(ds, Me)
            objCapPhoBan = Nothing
        End Sub

        Public Sub SetAttribute()
            txtNgayCapPhoBan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapPhoBan);")
            imgNgayCapPhoBan.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapPhoBan, 'dd/mm/yyyy');")
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            '==============================================================================================='
            txtMaLinhVuc.Text = Request.Params("Malv")
            txtMaNguoiTacNghiep.Text = Session.Item("UserName").ToString()
            txtTabCode.Text = Request.Params("TabID")
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnXoa.Click
            Dim objCapPhoBan As New CapPhoBanController
            objCapPhoBan.DelCapPhoBan(Me)
            objCapPhoBan = Nothing
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBoQua.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objCapPhoBan As New CapPhoBanController
            Dim mID As String
            mID = objCapPhoBan.AddCapPhoBan(Me)
            objCapPhoBan = Nothing
            'Response.Redirect(NavigateURL(), True)
            txtTienBangChu.Text = Trim(Trans_VietNam(Val(Replace(Replace(txtVonKinhDoanh.Text, ".", ""), ",", ".")))) & " đồng"
        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDanhSach.Click
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl") & "&AddNew=" & Request.Params("AddNew")), True)
        End Sub
    End Class

End Namespace
