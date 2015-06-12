Imports PortalQH
Imports System.Configuration
Namespace HSHC
    'NganTL
    'Created on 15/10/2004
    'Desc : Tiep nhan ho so va bo sung ho so
    'Updated on : 

    'TuanNH
    'Updated on 16/02/2006
    'Desc : Show/Hide button InBienNhan

    Public Class TiepNhanHoSoPPhuongXa
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
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiDungTrichYeu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Private Const ColMaHoSo As Integer = 0
        Private mNgayNghiLe As String
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblBatBuocNgayHopLe As System.Web.UI.WebControls.Label
        Protected WithEvents txtNgayThucDia As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNgayThucDia As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkNTD As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnTraHoSo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.Label
        Protected WithEvents cmdNgayNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdNgayHopLe As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblBarcode As System.Web.UI.WebControls.Label
        Protected WithEvents lnkDownloadFont As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents btnKiemTra As System.Web.UI.WebControls.LinkButton
        Protected WithEvents tdInBienNhan As System.Web.UI.HtmlControls.HtmlTableCell
        Protected WithEvents cmdOK As System.Web.UI.WebControls.Button
        Protected WithEvents txt_OriginalName As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents dgdUpload As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtHoSoTiepNhanID_Temp As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAttachFileID As System.Web.UI.WebControls.TextBox
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")

            cmdOK.Attributes.Add("onclick", "javascript:return CheckFile();")
            'Me.txtSoCMND.Attributes.Add("onblur", "javascript:isSoCMND(" & txtSoCMND.ClientID & ",'0');")

            txtNgayNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayNhan.ClientID & ");")
            cmdNgayNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayNhan)

            txtNgayHopLe.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayHopLe.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayHopLe.ClientID & ");")
            cmdNgayHopLe.NavigateUrl = AdminDB.InvokePopupCal(txtNgayHopLe)

            chkNTD.Attributes.Add("Onclick", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayThucDia.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayThucDia.ClientID & ");" & "checkNgayThucDia(" & chkNTD.ClientID & "," & txtNgayThucDia.ClientID & ");")
            Me.chkAll.Attributes.Add("onclick", "javascript: return select_deselectAll ('" & chkAll.ClientID & "');")

            txtNgayThucDia.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayThucDia.ClientID & ");")


            Dim TiepNhanCon As New TiepNhanHoSoController
            ' Lay Ngay Nghi Le Trong PARAMS
            mNgayNghiLe = TiepNhanCon.getNgayNghiLe("HSHC")
            txtSoNgayThucDia.Text = ConfigurationSettings.AppSettings("SoNgayThucDia")
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

            If Not Page.IsPostBack Then
                Init_State()
            End If
            'Kiem tra chuc xem la chuc nang tiep nhan hay bo sung ho so
            If Not ConfigurationSettings.AppSettings("EnableNgayNhan" & Request.Params("TabID")) Is Nothing Then
                Me.txtNgayNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayHenTra(" & txtNgayNhan.ClientID & "," & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");" & "CheckDateOnBlur_GetNgayHenTra(" & txtNgayNhan.ClientID & "," & txtNgayHopLe.ClientID & "," & txtSoNgayThucDia.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayThucDia.ClientID & ");" & "checkNgayThucDia(" & chkNTD.ClientID & "," & txtNgayThucDia.ClientID & ");")
                Me.txtSoNgayGiaiQuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayHenTra(" & txtNgayNhan.ClientID & "," & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                ddlMaLoaiHoSo.Enabled = True

                txtNgayHopLe.ReadOnly = True
                imgNgayHopLe.Visible = False
                txtNgayNhan.ReadOnly = False
                btnThemMoi.Visible = True
            Else
                Me.txtNgayHopLe.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");" & "CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayThucDia.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayThucDia.ClientID & ");" & "checkNgayThucDia(" & chkNTD.ClientID & "," & txtNgayThucDia.ClientID & ");")
                Me.txtSoNgayGiaiQuyet.Attributes.Add("onblur", "javascript:CheckDateOnBlur_GetNgayBoSung(" & txtNgayHopLe.ClientID & "," & txtSoNgayGiaiQuyet.ClientID & ",'" & mNgayNghiLe & "'," & txtNgayHenTra.ClientID & ");")
                ddlMaLoaiHoSo.Enabled = False
                txtNgayHopLe.ReadOnly = False
                txtNgayNhan.ReadOnly = True
                imgNgayNhan.Visible = False
                btnThemMoi.Visible = False
            End If
            'set thuoc tinh control cho grid ho so sau khi duoc init
            Set_Attribute()
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "1", "HSHC", btnInBienNhan, Me)
            Dim str As String
            str = txtSoNha.Text & " " & ddlMaDuong.Items(ddlMaDuong.SelectedIndex).Text & "," & ddlMaPhuong.Items(ddlMaPhuong.SelectedIndex).Text
            ddlMaPhuong.Attributes.Add("onblur", "javascript:FillDiaChi(" & txtSoNha.ClientID & "," & txtDiaChiThuongTru.ClientID & "," & ddlMaDuong.ClientID & "," & ddlMaPhuong.ClientID & " );")
            ddlMaDuong.Attributes.Add("onblur", "javascript:FillDiaChi(" & txtSoNha.ClientID & "," & txtDiaChiThuongTru.ClientID & "," & ddlMaDuong.ClientID & "," & ddlMaPhuong.ClientID & " );")

            'show/hide button InBienNhan
            'tdInBienNhan.Visible = flagShow
            If txtSoBienNhan.Text = "" Then
                tdInBienNhan.Visible = False
                btnTraHoSo.Visible = False
            End If
            txtSoNgayGiaiQuyet.Enabled = False
            ddlMaPhuong.Enabled = False
            'ddlMaLoaiHoSo.Enabled = True
        End Sub

        Sub Init_State()
            Dim pID As String = ""
            Dim pMaPhuong As String
            Dim TiepNhanCon As New TiepNhanHoSoController
            ' Lay Phuong theo UserName
            pMaPhuong = TiepNhanCon.getUserInfo(CType(Session.Item("UserName"), String), "MaPhongBan")
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


            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
                dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")

                BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, pMaPhuong)
                BindDropDownList_Dataset(ddlMaDuong, dsDuong, "TenDuong", "MaDuong", True, "")
                With ctrlScriptComboFilter
                    .ConditionID = ddlMaPhuong.ClientID
                    .ConditionText = "Ten"
                    .ConditionValue = "Ma"
                    .ResultID = ddlMaDuong.ClientID
                    .ResultText = "TenDuong"
                    .ResultValue = "MaDuong"
                    .ConditionDS = dsPhuong
                    .ResultDS = dsDuong
                End With
                ddlMaPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            Else
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG", pMaPhuong, True)
            End If
            '-------------------------------------------------------------
            If ddlMaPhuong.Items.Count > 0 And ddlMaPhuong.Items.Count = 2 Then
                ddlMaPhuong.SelectedIndex = 1
            End If
            BindControl.BindDropDownList_StoreProc(ddlMaLoaiHoSo, False, "", "sp_getDMLoaiHoSo_Phuong", txtMaLinhVuc.Text, Request.Params("TabID"))

            'bind Grid ho so
            If Not Request.Params("ID") Is Nothing And Request.Params("ID") <> "" Then
                txtHoSoTiepNhanID.Text = Request.Params("ID")
                pID = txtHoSoTiepNhanID.Text
                flagShow = True
                BindData(pID)
            Else
                Init_Grid_HoSo(ddlMaLoaiHoSo.SelectedValue, txtMaLinhVuc.Text, pID)
                If pID = "" Then
                    Init_SoNgayGiaiQuyet(ddlMaLoaiHoSo.SelectedValue, txtMaLinhVuc.Text)
                    txtNgayNhan.Text = Format(Now, "dd/MM/yyyy")
                    txtNgayHopLe.Text = Format(Now, "dd/MM/yyyy")
                End If
            End If
            If Not ConfigurationSettings.AppSettings("BSHS" & Request.Params("TabID")) Is Nothing Then
                txtNgayNhan.Enabled = True
                txtSoNgayGiaiQuyet.Enabled = True
            End If
            BindDSFileDinhKem()
            SetFocus(Me.Page, txtHoTenNguoiNop)
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
            txtSoNgayGiaiQuyet.Text = TiepNhanCon.getSoNgayGQPhuongXa(pMaLoaiHoSo, pLinhvuc)
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
            If txtSoBienNhan.Text <> "" Then
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
            If Not ConfigurationSettings.AppSettings("BSHS" & Request.Params("TabID")) Is Nothing Then
                txtNgayNhan.Enabled = True
                txtNgayNhan.Text = NgayHienTai()
                txtNgayHopLe.Text = NgayHienTai()
                txtSoNgayGiaiQuyet.Enabled = True
            End If
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

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/14/2007	Updated, khong bat buoc nhap ten duong theo yeu cau khach hang
        '''     [phuocdd]   Jun 22nd 2007   Updated, bo require So nha theo yeu cau cua khach hang, mac dinh set bang " "
        '''     [phuocdd]   Sep 28th 2007   Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub Set_Attribute()
            Dim i As Integer : Dim obj1 As TextBox : Dim obj2 As CheckBox : Dim obj3 As TextBox
            For i = 0 To dgdHoSo.Items.Count - 1
                obj1 = CType(dgdHoSo.Items(i).FindControl("txtSoBanChinh"), TextBox)
                obj2 = CType(dgdHoSo.Items(i).FindControl("chkXoa"), CheckBox)

                obj1.Attributes.Add("onblur", "javascript:isNumeric(" & obj1.ClientID & ",'0');")
                obj1.Attributes.Add("onblur", "javascript:checkHS(" & obj1.ClientID & "," & obj2.ClientID & ");")
                obj3 = CType(dgdHoSo.Items(i).FindControl("txtSoBanSao"), TextBox)
                obj3.Attributes.Add("onblur", "javascript:isNumeric(" & obj3.ClientID & ",'0');")
                obj3.Attributes.Add("onblur", "javascript:checkHS(" & obj3.ClientID & "," & obj2.ClientID & ");")
                obj2.Attributes.Add("onclick", "javascript:checkHSKemTheo(" & obj2.ClientID & "," & obj1.ClientID & "," & obj3.ClientID & ");")
            Next
            obj1 = Nothing
            obj2 = Nothing
            obj3 = Nothing
            '============================Set controls nao ko duoc null ========================================'
            txtHoTenNguoiNop.Attributes.Add("ISNULL", "NOTNULL")
            txtDiaChiThuongTru.Attributes.Add("ISNULL", "NOTNULL")
            'txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNgayGiaiQuyet.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayNhan.Attributes.Add("ISNULL", "NOTNULL")
            txtNgayHopLe.Attributes.Add("ISNULL", "NOTNULL")
            'phuocdd, Sep 28th 2007, updated, chuyen nghiep vu tinh ngay hen tra xuong db
            'txtNgayHenTra.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")
            '==================================================================================================='
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim TinhTrangCon As New TinhTrangHoSoController : Dim err As Integer
            Dim TiepNhanCon As New TiepNhanHoSoController
            If (Me.txtSoNha.Text = "") Then
                Me.txtSoNha.Text = " "
            End If
            txtHoSoTiepNhanID.Text = TiepNhanCon.UpdHoSoTiepNhanPhuongXa(Me)
            SetFocus(Me.Page, btnInBienNhan)

            If txtHoSoTiepNhanID.Text <> "1" Then
                Save_Grid_HoSo(txtHoSoTiepNhanID.Text)
                UpdFileDinhKem()
                'show button InBienNhan
                flagShow = True

                ' truong hop la bo sung ho so
                If Not ConfigurationSettings.AppSettings("BSHS" & Request.Params("TabID")) Is Nothing Then
                    err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "NBS", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
                ElseIf Not ConfigurationSettings.AppSettings("TiepNhanPhuong" & Request.Params("TabID")) Is Nothing Then 'truong hop tiep nhan ho so
                    err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "VTNP", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
                Else
                    err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "VTN", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
                End If
                Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text & "&Malv=" & txtMaLinhVuc.Text & "&Tenlv=" & lblTieuDe.Text, "Edit"))

            Else
                SetMSGBOX_HIDDEN(Me.Page, "Thong tin nguoi nop ho so da duoc cap moi khong duoc cap moi ")
                BindData("")





                '    If Not ConfigurationSettings.AppSettings("BSHS" & Request.Params("TabID")) Is Nothing Then
                '        err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "NBSP", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
                '    ElseIf Not ConfigurationSettings.AppSettings("TiepNhanPhuong" & Request.Params("TabID")) Is Nothing Then 'truong hop tiep nhan ho so
                '        err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "VTNP", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
                '    Else
                '        err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "VTN", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")
                '        'Else if
                '        '    err = TinhTrangCon.UpdTinhTrangHoSo(txtMaLinhVuc.Text, Request.Params("tabid"), "VTNP", txtMaNguoiNhan.Text, "", "", txtHoSoTiepNhanID.Text, "")


                '    End If
                '    Response.Redirect(EditURL("ID", txtHoSoTiepNhanID.Text & "&Malv=" & txtMaLinhVuc.Text & "&Tenlv=" & lblTieuDe.Text, "Edit"))



                'Else
                '    SetMSGBOX_HIDDEN(Me.Page, "Thong tin nguoi nop ho so da duoc cap moi khong duoc cap moi ")
                '    BindData("")
            End If
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            'hide button InBienNhan
            flagShow = False
            BindData("")
            'Nut them moi hien thi phuong/xa tuong ung voi user cua phuong -HieuLC
            Init_State()
            txtHoTenNguoiNop.Text = ""
            txtSoNha.Text = ""
            ddlMaDuong.SelectedValue = ""
            txtDiaChiThuongTru.Text = ""
            txtNgayHenTra.Text = ""
            'End HieuLC
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
            txtSoBienNhan.Text = ""
            lblBarcode.Text = ""
            txtHoSoTiepNhanID.Text = ""
            txtSoNgayThucDia.Text = ConfigurationSettings.AppSettings("SoNgayThucDia")
            txtNgayNhan.Text = Format(Now, "dd/MM/yyyy")
            txtNgayHopLe.Text = Format(Now, "dd/MM/yyyy")
            SetFocus(Me.Page, txtHoTenNguoiNop)
            tdInBienNhan.Visible = False
            btnTraHoSo.Visible = False
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnTraHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraHoSo.Click
            'Response.Redirect(EditURL("ID", "&Malv=" & Request.Params("Malv") & "&Tenlv=" & Request.Params("Tenlv"), "PHIEUTRAHOSO"))
            'DungNT7
            Dim objTiepNhan As New TiepNhanHoSoController
            Dim ds As New DataSet
            Dim Script As String
            Dim PhieuChuyen As String

            ds = objTiepNhan.InPhieuChuyenPhuongXa(txtHoSoTiepNhanID.Text, CType(Session.Item("UserName"), String))
            PhieuChuyen = ddlMaLoaiHoSo.SelectedValue + ".doc"

            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", InPhieuChuyenPhuongXa(Request, ds, GetLinhVuc(), PhieuChuyen))
            Page.RegisterStartupScript("OpenWindow", Script)

            objTiepNhan = Nothing
            ds = Nothing
        End Sub

        'kiểm tra nếu trường hợp là lĩnh vực kinh doanh
        'thì visible=true button Kiểm tra
        Private Sub HienThiChucNangKiemTra()
            Dim arrLinhVucKiemTra As Array
            Dim i As Integer

            arrLinhVucKiemTra = LinhVucKiemTraHoSoTiepNhan()
            For i = 0 To arrLinhVucKiemTra.Length - 1
                If Trim(CStr(arrLinhVucKiemTra.GetValue(i))) = Trim(txtMaLinhVuc.Text) Then
                    btnKiemTra.Visible = True
                    btnKiemTra.Attributes.Add("onclick", "javascript:return btnKiemTra_Click();")
                End If
            Next
        End Sub

        Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
            Dim TiepNhanCon As New TiepNhanHoSoController
            Dim sFileName As String = System.IO.Path.GetFileName(txt_OriginalName.PostedFile.FileName())
            Dim sUploadDirName As String
            'Dim DirCreated As String
            sUploadDirName = "/HSHC/AttachFiles" + "/"

            If sFileName <> "" Then
                'upload file on server
                UpLoad(sFileName, sUploadDirName)
                'InsFileDinhKem(txtMaLinhVuc.Text, strFileName, sUploadDirName)
            End If
            InsFileDinhKem(txtMaLinhVuc.Text, sFileName, sUploadDirName)
            BindDSFileDinhKem()
            'BindDG()
        End Sub

        Sub UpLoad(ByVal UploadName As String, ByVal DirCreated As String)
            Dim strPathName As String
            Dim strFileName As String = ""
            If Not IsNothing(txt_OriginalName.PostedFile) Then
                strPathName = txt_OriginalName.PostedFile.FileName()
                strFileName = System.IO.Path.GetFileName(strPathName)
                If strFileName <> "" Then
                    If Not System.IO.Directory.Exists(Request.PhysicalApplicationPath & DirCreated) Then
                        System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath & DirCreated)
                    End If
                    Try
                        Dim VirPath As String
                        VirPath = Request.PhysicalApplicationPath & DirCreated & "\" & UploadName
                        txt_OriginalName.PostedFile.SaveAs(VirPath)
                    Catch err As Exception
                        'hMsg.Value = "Co´ lô~i xa?y ra trong khi Upload! Vui lo`ng thu? la?i"
                    End Try
                End If
            End If
        End Sub

        Private Sub BindDSFileDinhKem()

            Dim TiepNhanCon As New TiepNhanHoSoController
            Dim ds As DataSet
            If txtHoSoTiepNhanID.Text = "" Then
                ds = TiepNhanCon.GetDSFileDinhKemByHoSoTiepNhanID_Temp(txtHoSoTiepNhanID_Temp.Text)
                BindControl.BindDataGrid(ds, dgdUpload, ds.Tables(0).Rows.Count)
            Else
                ds = TiepNhanCon.GetDSFileDinhKemByHoSoTiepNhanID(txtHoSoTiepNhanID.Text)
                BindControl.BindDataGrid(ds, dgdUpload, ds.Tables(0).Rows.Count)
            End If

            ds = Nothing
            TiepNhanCon = Nothing

        End Sub

        Private Sub InsFileDinhKem(ByVal pMaLinhVuc As String, ByVal FileName As String, ByVal FilePath As String)
            Dim TiepNhanCon As New TiepNhanHoSoController
            If txtHoSoTiepNhanID.Text = "" Then
                txtHoSoTiepNhanID_Temp.Text = TiepNhanCon.InsFileDinhKem(txtHoSoTiepNhanID.Text, pMaLinhVuc, FileName, FilePath, txtHoSoTiepNhanID_Temp.Text)
                TiepNhanCon = Nothing

            End If

        End Sub

        Private Sub UpdFileDinhKem()
            Dim TiepNhanCon As New TiepNhanHoSoController
            txtAttachFileID.Text = TiepNhanCon.UpdateFileDinhKem(txtHoSoTiepNhanID.Text, txtHoSoTiepNhanID_Temp.Text)
            TiepNhanCon = Nothing
        End Sub

        Sub ItemCommand(ByVal o As Object, ByVal e As DataGridCommandEventArgs)
            If e.CommandName = "DeleteFileAttached" Then
                Dim TiepNhanCon As New TiepNhanHoSoController
                TiepNhanCon.DelFileDinhKem(e.Item.Cells(0).Text)

                'Refresh Grid
                BindDSFileDinhKem()
            End If
        End Sub
        
    End Class
End Namespace