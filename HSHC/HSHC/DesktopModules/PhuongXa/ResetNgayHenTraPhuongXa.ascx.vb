Imports PortalQH
Imports System.Configuration
Namespace HSHC
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : TiepNhanHoSo1
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[phuocdd]	9/28/2007	Created
    '''         Reference: TiepNhanHoSo
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ResetNgayHenTraPhuongXa
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungKhac As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInBienNhan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayNhan As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayHopLe As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayHopLe As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoNgayGiaiQuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayHenTra As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtThongTinLienLac As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdHoSo As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungTrichYeu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Private Const ColMaHoSo As Integer = 0
        Private mNgayNghiLe As String
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblBatBuocNgayHopLe As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayThucDia As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNgayThucDia As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNTD As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayHopLe As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblBarcode As System.Web.UI.WebControls.Label
        Protected WithEvents lnkDownloadFont As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents tdInBienNhan As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents txtMaTinhTrang As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private flagShow As Boolean = False 'catch show/hide button InBienNhan

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	9/28/2007	Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")

            txtNgayHopLe.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHopLe.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHopLe.ClientID & ");")
            cmdNgayHopLe.NavigateUrl = AdminDB.InvokePopupCal(txtNgayHopLe)

            chkNTD.Attributes.Add("Onclick", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayThucDia.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayThucDia.ClientID & ");" & "checkNgayThucDia(" & chkNTD.ClientID & "," & txtNgayThucDia.ClientID & ");")

            txtNgayThucDia.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThucDia.ClientID & ");")

            mNgayNghiLe = ConfigurationSettings.AppSettings("NgayNghiLe")
            txtSoNgayThucDia.Text = ConfigurationSettings.AppSettings("SoNgayThucDia")
            txtNgayHopLe.Text = Format(Now, "dd/MM/yyyy")
            If Not Session.Item("UserName") Is Nothing Then
                txtMaNguoiNhan.Text = CType(Session.Item("UserName"), String)
            Else
                Response.Redirect("Default.aspx?ctl=login")
            End If

            If Not Request.Params("Malv") Is Nothing Then
                txtMaLinhVuc.Text = Request.Params("Malv")
            End If
            If Not Request.Params("Tenlv") Is Nothing Then
                lblTieuDe.Text = Request.Params("Tenlv")
            End If

            If Not Page.IsPostBack Then
                Init_State()
            End If

            'set thuoc tinh control cho grid ho so sau khi duoc init
            Set_Attribute()
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInBienNhan, Me)
            txtNoiDungKhac.Enabled = True
        End Sub

        Sub Init_State()
            Dim pID As String = ""

            Dim mSuDungBarCode As String
            mSuDungBarCode = CType(ConfigurationSettings.AppSettings("SuDungBarCode"), String)
            If mSuDungBarCode = "1" Then 'co su dung
                'Hien thi barcode
                'Type code here
                lblBarcode.Visible = True
                'end
            Else
                'Khong hien thi barcode
                'Type code here
                lblBarcode.Visible = False
                'end
            End If

            If txtMaLinhVuc.Text = "CPKTQH" Then Label2.Text = "Địa chỉ đăng ký kinh doanh"
            If txtMaLinhVuc.Text = "CPXD" Then Label2.Text = "Địa chỉ đăng ký xây dựng"
            'Bind ddl
            'Doan loc duong theo phuong
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
            Dim objDanhMuc As New DanhMucController


            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            BindControl.BindDropDownList_StoreProc(ddlMaLoaiHoSo, False, "", "sp_getDMLoaiHoSo", txtMaLinhVuc.Text, Request.Params("TabID"))

            'bind Grid ho so
            If Not Request.Params("ID") Is Nothing And Request.Params("ID") <> "" Then
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                pID = txtHoSoTiepNhanID.Text
                flagShow = True
                BindData(pID)
                If (txtNgayNhan.Text = txtNgayHopLe.Text) Then
                    Me.txtNgayHopLe.Text = DateTime.Now.Date.ToString("dd/MM/yyyy")
                End If
            End If
            SetFocus(Me.Page, txtNgayHopLe)
        End Sub
        'Bind data cho grid ho so kem theo
        Sub Init_Grid_HoSo(ByVal pMaLoaiHoSo As String, ByVal pLinhVuc As String, ByVal pID As String)
            Dim TiepNhanCon As New TiepNhanHoSoPhuongXaController
            Dim ds As DataSet
            ds = TiepNhanCon.GetDMHoSoKemTheo(pMaLoaiHoSo, pID, pLinhVuc)
            BindControl.BindDataGrid(ds, dgdHoSo, ds.Tables(0).Rows.Count)
            ds = Nothing
            TiepNhanCon = Nothing
        End Sub
        Sub Init_SoNgayGiaiQuyet(ByVal pMaLoaiHoSo As String, ByVal pLinhvuc As String)
            Dim TiepNhanCon As New TiepNhanHoSoPhuongXaController
            txtSoNgayGiaiQuyet.Text = TiepNhanCon.getSoNgayQuiDinh(pMaLoaiHoSo, pLinhvuc)
            TiepNhanCon = Nothing
        End Sub
        Sub BindData(ByVal pID As String)
            Dim TiepNhanCon As New TiepNhanHoSoPhuongXaController
            gLoadControlValues(TiepNhanCon.GetChiTietHoSoTiepNhan(pID), Me)
            ''============================================================='
            txtMaNguoiNhan.Text = CType(Session.Item("UserName"), String)
            txtMaLinhVuc.Text = Request.Params("Malv")
            ''============================================================='
            Init_Grid_HoSo(ddlMaLoaiHoSo.SelectedValue(), txtMaLinhVuc.Text, pID)
            If pID = "" Then
                Init_SoNgayGiaiQuyet(ddlMaLoaiHoSo.SelectedValue, txtMaLinhVuc.Text)
            End If
            'init barcode
            If txtSoBienNhan.Text <> "" Then
                Dim mSuDungBarCode As String
                mSuDungBarCode = CType(ConfigurationSettings.AppSettings("SuDungBarCode"), String)
                If mSuDungBarCode = "1" Then 'co su dung
                    lblBarcode.Visible = True
                Else
                    lblBarcode.Visible = True
                    'end
                End If
                lblBarcode.Text = "*" & txtSoBienNhan.Text & "*"
            Else
                lblBarcode.Text = txtSoBienNhan.Text
            End If
            'end init barcode
            TiepNhanCon = Nothing
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInBienNhan, Me)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	Oct 01st 2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub Set_Attribute()
            txtNgayHopLe.Attributes.Add("ISNULL", "NOTNULL")
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	9/28/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim TinhTrangCon As New TinhTrangHoSoPhuongXaController : Dim err As Integer
            Dim TiepNhanCon As New TiepNhanHoSoController
            If (Me.txtSoNha.Text = "") Then
                Me.txtSoNha.Text = " "
            End If
            Dim m_HoSoID As String
            m_HoSoID = TiepNhanCon.UpdHoSoTiepNhan1(txtHoSoTiepNhanID.Text, txtNgayHopLe.Text, txtSoNgayGiaiQuyet.Text, Request("tabid"), txtMaNguoiNhan.Text, txtMaTinhTrang.Text)
            SetFocus(Me.Page, txtNgayHopLe)

            If m_HoSoID = "" Then
                SetMSGBOX_HIDDEN(Me.Page, "Cap nhat khong thanh cong")
                BindData("")
            Else
                BindData(Me.txtHoSoTiepNhanID.Text)
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

    End Class
End Namespace