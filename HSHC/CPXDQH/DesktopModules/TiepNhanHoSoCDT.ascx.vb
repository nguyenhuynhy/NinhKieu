Imports PortalQH
Imports System.Configuration
Namespace CPXD
    'NganTL
    'Created on 15/10/2004
    'Desc : Tiep nhan ho so va bo sung ho so
    'Updated on : 
    Public Class TiepNhanHoSoCDT
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungKhac As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
        Protected WithEvents btnInBienNhan As System.Web.UI.WebControls.Image
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaPhuong As System.Web.UI.WebControls.DropDownList
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
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtMaNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungTrichYeu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Private Const ColMaHoSo As Integer = 0
        Private mNgayNghiLe As String
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblBatBuocNgayHopLe As System.Web.UI.WebControls.Label
        Protected WithEvents dgdChuDauTu As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lnkThemChuDauTu As System.Web.UI.WebControls.LinkButton

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

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            Me.txtSoCMND.Attributes.Add("onblur", "javascript:isSoCMND(" & txtSoCMND.ClientID & ",'0');")
            Me.imgNgayNhan.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtNgayNhan.ClientID & ", 'dd/mm/yyyy')")
            Me.imgNgayHopLe.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtNgayHopLe.ClientID & ", 'dd/mm/yyyy')")
            Me.chkAll.Attributes.Add("onclick", "javascript: return select_deselectAll ('" & chkAll.ClientID & "');")
            '----------------------------------------------------------------------------------------------------'
            mNgayNghiLe = ConfigurationSettings.AppSettings("NgayNghiLe")
            If Not Session.Item("UserName") Is Nothing Then
                txtMaNguoiNhan.Text = CType(Session.Item("UserName"), String)
            Else
                Response.Redirect("Default.aspx?tabid=117&ctl=login")
            End If

            If Not Request.Params("Malv") Is Nothing Then
                txtMaLinhVuc.Text = Request.Params("Malv")
            End If
            If Not Request.Params("Tenlv") Is Nothing Then
                lblTieuDe.Text = Request.Params("Tenlv")
            End If
            'Kiem tra chuc xem la chuc nang tiep nhan hay bo sung ho so
            If Not ConfigurationSettings.AppSettings("EnableNgayNhan" & Request.Params("TabID")) Is Nothing Then
                Me.txtNgayNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayHenTra(" & txtNgayNhan.ClientID & "," & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                Me.txtSoNgayGiaiQuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayHenTra(" & txtNgayNhan.ClientID & "," & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                Me.btnCapNhat.Attributes.Add("onfocus", "javascript:CheckDateOnBlur_GetNgayHenTra(" & txtNgayNhan.ClientID & "," & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                'lblBatBuocNgayHopLe.Visible = False
                ddlMaLoaiHoSo.Enabled = True
                txtNgayHopLe.ReadOnly = True
                imgNgayHopLe.Visible = False
                txtNgayNhan.ReadOnly = False
            Else
                Me.txtNgayHopLe.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                Me.txtSoNgayGiaiQuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                Me.btnCapNhat.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")

                'lblBatBuocNgayHopLe.Visible = True
                ddlMaLoaiHoSo.Enabled = False
                txtNgayHopLe.ReadOnly = False
                txtNgayNhan.ReadOnly = True
                imgNgayNhan.Visible = False
            End If
            If Not Page.IsPostBack Then
                Init_State()
            End If
            'set thuoc tinh control cho grid ho so sau khi duoc init
            Set_Attribute()
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInBienNhan, Me)

        End Sub
        Sub Init_State()
            'declare params
            Dim pID As String = ""
            'set img template cho barcode
            'imgBarCode.ImageUrl = GetValueItem(Request, "FileTemplate", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml")
            'Bind ddl
            BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            If ddlMaPhuong.Items.Count > 0 And ddlMaPhuong.Items.Count = 2 Then
                ddlMaPhuong.SelectedIndex = 1
            End If
            BindControl.BindDropDownList_StoreProc(ddlMaLoaiHoSo, False, "", "sp_getDMLoaiHoSo", txtMaLinhVuc.Text, Request.Params("TabID"))
            'bind Grid ho so
            If Not Request.Params("ID") Is Nothing And Request.Params("ID") <> "" Then
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                pID = txtHoSoTiepNhanID.Text
                BindData(pID)
                Me.lnkThemChuDauTu.Visible = True
            Else
                Init_Grid_HoSo(ddlMaLoaiHoSo.SelectedValue, txtMaLinhVuc.Text, pID)
                If pID = "" Then
                    Init_SoNgayGiaiQuyet(ddlMaLoaiHoSo.SelectedValue, txtMaLinhVuc.Text)
                    txtNgayNhan.Text = Format(Now, "dd/MM/yyyy")
                    txtNgayHopLe.Text = Format(Now, "dd/MM/yyyy")
                End If
                Me.lnkThemChuDauTu.Visible = False
            End If
        End Sub
        'Bind data cho grid ho so kem theo
        Sub Init_Grid_HoSo(ByVal pMaLoaiHoSo As String, ByVal pLinhVuc As String, ByVal pID As String)
            Dim TiepNhanCon As New TiepNhanHoSoController
            Dim ds As DataSet
            ds = TiepNhanCon.GetDMHoSoKemTheo(pMaLoaiHoSo, pID, pLinhVuc)
            BindControl.BindDataGrid(ds, dgdHoSo, ds.Tables(0).Rows.Count)
            ds = Nothing
            TiepNhanCon = Nothing
        End Sub
        Sub Init_SoNgayGiaiQuyet(ByVal pMaLoaiHoSo As String, ByVal pLinhvuc As String)
            Dim TiepNhanCon As New TiepNhanHoSoController
            txtSoNgayGiaiQuyet.Text = TiepNhanCon.getSoNgayQuiDinh(pMaLoaiHoSo, pLinhvuc)
            TiepNhanCon = Nothing
        End Sub
        Sub BindData(ByVal pID As String)
            Dim TiepNhanCon As New TiepNhanHoSoController
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
            'If txtSoBienNhan.Text <> "" Then
            '    TiepNhanCon.CreateBarCode(txtSoBienNhan.Text, _
            '                                    ConfigurationSettings.AppSettings("TypeBarCode" & txtMaLinhVuc.Text).ToString(), _
            '                                    GetValueItem(Request, "FileTemplate", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml"), _
            '                                    GetValueItem(Request, "FileExport", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml"))

            'imgBarCode.ImageUrl = GetValueItem(Request, "FileExport", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml")
            'End If
            'end init barcode
            TiepNhanCon = Nothing
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInBienNhan, Me)
        End Sub
        Public Sub Save_Grid_HoSo(ByVal pID As String)
            Dim TiepNhanCon As New TiepNhanHoSoController
            Dim i As Integer : Dim flgCheck As Boolean
            'neu xoa ho so kem theo thanh cong ( khong loi )
            If TiepNhanCon.DelHoSoKemTheo(pID) <> "" Then
                'insert again
                For i = 0 To dgdHoSo.Items.Count - 1
                    flgCheck = CBool(GetGridControlValue(i, dgdHoSo, "chkXoa"))
                    If flgCheck Then
                        TiepNhanCon.AddHoSoKemTheo(GetGridControlValue(i, dgdHoSo, "txtSoBanChinh"), _
                                                    GetGridControlValue(i, dgdHoSo, "txtSoBanSao"), _
                                                    pID, GetGridControlValue(i, dgdHoSo, "lblMaHoSo"))
                    End If
                Next
            End If
            TiepNhanCon = Nothing
        End Sub
        Private Sub ddlMaLoaiHoSo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMaLoaiHoSo.SelectedIndexChanged
            txtNgayNhan.Text = Format(Now, "dd/MM/yyyy")
            txtNgayHopLe.Text = Format(Now, "dd/MM/yyyy")
            txtNgayHenTra.Text = ""
            Init_Grid_HoSo(ddlMaLoaiHoSo.SelectedItem.Value, txtMaLinhVuc.Text, txtHoSoTiepNhanID.Text)
            Init_SoNgayGiaiQuyet(ddlMaLoaiHoSo.SelectedItem.Value, txtMaLinhVuc.Text)
            Set_Attribute()
        End Sub
        Sub Set_Attribute()
            Dim i As Integer : Dim obj As TextBox
            For i = 0 To dgdHoSo.Items.Count - 1
                obj = CType(dgdHoSo.Items(i).FindControl("txtSoBanChinh"), TextBox)
                obj.Attributes.Add("onblur", "javascript:isNumeric(" & obj.ClientID & ",'0');")
                obj = CType(dgdHoSo.Items(i).FindControl("txtSoBanSao"), TextBox)
                obj.Attributes.Add("onblur", "javascript:isNumeric(" & obj.ClientID & ",'0');")
            Next
            obj = Nothing
            '============================Set controls nao ko duoc null ========================================'
            txtHoTenNguoiNop.Attributes.Add("ISNULL", "NOTNULL")
            txtDiaChiThuongTru.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNgayGiaiQuyet.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayHopLe.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayHenTra.Attributes.Add("ISNULL", "NOTNULL")
            '==================================================================================================='
        End Sub
        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnThemMoi.Click
            BindData("")
            txtNgayNhan.Text = Format(Now, "dd/MM/yyyy")
            txtNgayHopLe.Text = Format(Now, "dd/MM/yyyy")
            'imgBarCode.ImageUrl = GetValueItem(Request, "FileTemplate", ConfigurationSettings.AppSettings("Path" & gActiveDB) & "GLOBAL.xml")
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
            Dim TinhTrangCon As New TinhTrangHoSoController : Dim err As Integer
            Dim TiepNhanCon As New TiepNhanHoSoController

            txtHoSoTiepNhanID.Text = TiepNhanCon.UpdHoSoTiepNhan(Me)
            Save_Grid_HoSo(txtHoSoTiepNhanID.Text)

            ' truong hop la bo sung ho so
            If Not ConfigurationSettings.AppSettings("BSHS" & Request.Params("TabID")) Is Nothing Then
                err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "NBS", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
            Else 'truong hop tiep nhan ho so
                err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "VTN", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
            End If
            Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text & "&Malv=" & txtMaLinhVuc.Text & "&Tenlv=" & lblTieuDe.Text, "Edit"))
        End Sub

        Private Sub lnkThemChuDauTu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkThemChuDauTu.Click
            Dim strURL As String = EditURL("ID", Me.txtHoSoTiepNhanID.Text, "ADDCDT")
            Response.Redirect(strURL, True)
        End Sub
    End Class
End Namespace