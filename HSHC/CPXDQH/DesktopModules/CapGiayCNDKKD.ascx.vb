'Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports PortalQH
Namespace CPXD
    Public Class CapGiayCNDKKD
        'Created NganTL
        'Descr : Cap moi va cap doi giay CNDKKD
        'Date by 03/11/2004
        Inherits PortalQH.PortalModuleControl
        Private pID As String = ""
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.Image
        Protected WithEvents btnXoa As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVonLuuDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtVonCoDinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuongThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaHinhThucKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCap As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents btnDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTenNganh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNganh As System.Web.UI.WebControls.TextBox
        Protected WithEvents blkNganhKinhDoanh As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanToc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDiaChiCu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhone As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebsite As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoBN As System.Web.UI.WebControls.Label
        Protected WithEvents lblSGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoGiayPhepTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtTienBangChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnInThongBao As System.Web.UI.WebControls.Image
        Private Const strURL As String = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Private Shared dv As DataView
        Protected WithEvents txtNoiCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox

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
            Dim objCapCNDKKD As New GiayCNDKKDController
            If Not Me.IsPostBack Then
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
                BindControl.BindDropDownList(ddlMaPhuongThucKinhDoanh, "DMPHUONGTHUCKINHDOANH")
                BindControl.BindDropDownList(ddlMaHinhThucKinhDoanh, "DMHINHTHUCKINHDOANH")
                BindDropDownList_NguoiKy(ddlMaSoLanhDao)
                'CreateDataSource(pID)
                BindData(pID, CType(Request.Params("AddNew"), Boolean))
                txtReload.Text = "0"
                If txtNgayCap.Text = "" Then txtNgayCap.Text = NgayHienTai()
            End If
            'load grid cho nganh kinh doanh

            If Trim(txtSoGiayPhep.Text) <> "" And txtReload.Text = "1" Then
                GetGiayCNDKKD()
                txtReload.Text = "0"
                txtSoGiayPhep.Text = ""
                txtNgayCap.Text = NgayHienTai()
            End If
            'end load grid
            objCapCNDKKD = Nothing

            btnDanhSach.Visible = CType(Request.Params("AddNew"), Boolean)
            lblSoBN.Visible = Not CType(Request.Params("AddNew"), Boolean)

            If Request.Params("TabID") = GetValueItem(Request, "TabCapDoiKD", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml") Then
                btnDanhSachGP.Visible = CType(Request.Params("AddNew"), Boolean)
                lblSoGP.Visible = Not CType(Request.Params("AddNew"), Boolean)
            Else
                btnDanhSachGP.Visible = False
                lblSoGP.Visible = True
            End If
            SetStatus(CType(Request.Params("AddNew"), Boolean))
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", gActiveDB, btnIn, Me)
            txtTienBangChu.Text = Trim(Trans_VietNam(Val(Replace(Replace(txtVonKinhDoanh.Text, ".", ""), ",", "."))).ToString) & " đồng"
            txtNgayCap.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaHinhThucKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuongThucKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
        End Sub

        Sub BindData(ByVal id As String, ByVal isAddNew As Boolean)
            Dim objCapCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet
            If isAddNew Then
                ds = objCapCNDKKD.GetGiayCNDKKD_New(id)
                gLoadControlValues(ds, Me)
            Else
                ds = objCapCNDKKD.GetGiayCNDKKD_Edit(id)
                gLoadControlValues(ds, Me)
            End If
            'BindGrid()
            objCapCNDKKD = Nothing
        End Sub

        'Public Sub CreateDataSource(ByVal id As String)
        '    Dim objCapCNDKKD As New GiayCNDKKDController
        '    Dim ds As DataSet
        '    ds = objCapCNDKKD.getNganhKinhDoanhByID(id)
        '    dv = New DataView(ds.Tables(0))
        '    objCapCNDKKD = Nothing
        'End Sub

        Public Sub SetAttribute()
            Dim strURLNganhKD As String
            strURLNganhKD = "CPKTQH/DesktopModules/NhapNganhNghe.aspx?MaNganh=" & txtMaNganh.ClientID & "&TenNganh=" & txtTenNganh.ClientID
            blkNganhKinhDoanh.Attributes.Add("onclick", "javascript:CallNganhNghe('" & strURLNganhKD & "','Application'" & ");")
            btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa thông tin này không ?');")
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            Me.txtSoCMND.Attributes.Add("onblur", "javascript:isSoCMND(" & txtSoCMND.ClientID & ",'0');")
            txtNgayCap.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap);")
            imgNgayCap.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCap, 'dd/mm/yyyy');")
            Me.txtVonKinhDoanh.Attributes.Add("onblur", "javascript:CheckData(" & txtVonKinhDoanh.ClientID & ");")
            Me.txtVonCoDinh.Attributes.Add("onblur", "javascript:CheckDataSum(" & txtVonCoDinh.ClientID & "," & txtVonLuuDong.ClientID & "," & txtVonKinhDoanh.ClientID & ");")
            Me.txtVonLuuDong.Attributes.Add("onblur", "javascript:CheckDataSum(" & txtVonLuuDong.ClientID & "," & txtVonCoDinh.ClientID & "," & txtVonKinhDoanh.ClientID & ");")
            Me.txtEmail.Attributes.Add("onblur", "javascript:validateEmail(" & txtEmail.ClientID & ");")

            txtMaLinhVuc.Text = Request.Params("Malv")
            txtMaNguoiTacNghiep.Text = Session.Item("UserName").ToString()
            txtTabCode.Text = Request.Params("TabID")
        End Sub

        Private Sub SetStatus(ByVal flgAddNew As Boolean)
            If Request.Params("TabID") = GetValueItem(Request, "TabCapDoiKD", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml") Then
                btnDanhSachGP.Visible = flgAddNew
                lblSoGP.Visible = Not flgAddNew
            Else
                btnDanhSachGP.Visible = False
                lblSoGP.Visible = True
            End If
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
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim objCapCNDKKD As New GiayCNDKKDController
            Dim mID As String
            'truong hop cap doi
            If Request.Params("TabID") = GetValueItem(Request, "TabCapDoiKD", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml") Then
                mID = objCapCNDKKD.AddGIAYCNDKKD_CD(Me)
            Else 'cap moi
                mID = objCapCNDKKD.AddGIAYCNDKKD(Me)
            End If
            BindData(mID, False)
            objCapCNDKKD = Nothing
            txtTienBangChu.Text = Trim(Trans_VietNam(Val(Replace(Replace(txtVonKinhDoanh.Text, ".", ""), ",", "."))).ToString) & " đồng"
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnXoa.Click
            Dim objCapCNDKKD As New GiayCNDKKDController
            objCapCNDKKD.DelGIAYCNDKKD(Me)
            objCapCNDKKD = Nothing
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBoQua.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnDanhSach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDanhSach.Click
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl") & "&AddNew=" & Request.Params("AddNew")), True)
        End Sub
    End Class

End Namespace
