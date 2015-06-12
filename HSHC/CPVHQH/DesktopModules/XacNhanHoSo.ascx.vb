Imports PortalQH
Imports System.Configuration
Namespace CPVHQH
    Public Class XacNhanHoSoVanHoa
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        Protected WithEvents Label10 As System.Web.UI.WebControls.Label
        Protected WithEvents Label11 As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents Label14 As System.Web.UI.WebControls.Label
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents Label17 As System.Web.UI.WebControls.Label
        Protected WithEvents Label18 As System.Web.UI.WebControls.Label
        Protected WithEvents Label19 As System.Web.UI.WebControls.Label
        Protected WithEvents Label20 As System.Web.UI.WebControls.Label
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSoBN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoXacNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnLuuDiaChi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayXacNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayXacNhan As System.Web.UI.WebControls.Image
        Protected WithEvents ddlMaNganhKinhDoanh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienTich As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgayXacNhan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtNoiDungKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaSoLanhDao As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label13 As System.Web.UI.WebControls.Label
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTenLoaiHoSo As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private strControl As String
        'Dinh nghia vi tri cac field trong dataview
        'Private Const COL_DIACHIID As Integer = 0
        Private Const COL_DIACHIID As Integer = 0
        Private Const COL_SONHA As Integer = 1
        Private Const COL_MADUONG As Integer = 2
        Private Const COL_MAPHUONG As Integer = 3
        Private Const COL_DIENTICH As Integer = 4
        Private Const COL_TENDUONG As Integer = 5
        Private Const COL_TENDONVI As Integer = 6
        Private dsDiaChi As DataSet
        Private dvDiaChi As DataView
        Private arrDanhSach As New ArrayList

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Request.Params("ID") Is Nothing Then
                'pID = Request.Params("ID")
                strControl = Request.Params("ctl")
                txtHoSoTiepNhanID.Text = Request.Params("ID")
            End If

            If Not Page.IsPostBack() Then
                InitState()
                SetAttributesControl()
                CreateDataSource(Request.QueryString.Get("ID").ToString())
                txtTabCode.Text = CType(Request.Params("TabID"), String)
                txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
                txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
                If txtNgayXacNhan.Text = "" Then
                    txtNgayXacNhan.Text = NgayHienTai()
                End If
            End If
            BindGrid()
            SetEnableXoa()
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaDuong))
            End If
        End Sub
        Sub SetEnableXoa()
            'If (txtHoSoTiepNhanID.Text <> "") Then
            If (txtHoSoXacNhanID.Text <> "") Then
                btnXoa.Visible = True

            Else
                btnXoa.Visible = False

            End If
        End Sub
        'Ham CreateDataSource dung de gan tren dgdDanhSach
        Public Sub CreateDataSource(ByVal strHoSoTiepNhanID As String)
            Dim dr As DataRow
            Dim ds As DataSet

            Dim objHoSoXacNhanController As New HoSoXacNhanController
            Me.txtHoSoTiepNhanID.Text = strHoSoTiepNhanID
            ds = objHoSoXacNhanController.GetDiaChi(strHoSoTiepNhanID)
            Dim i As Integer
            Dim arrDanhSach As New ArrayList
            For i = 0 To ds.Tables(0).Rows.Count - 1
                arrDanhSach.Add(New DanhSach(i, ds.Tables(0).Rows(i)(COL_DIACHIID).ToString(), ds.Tables(0).Rows(i)(COL_SONHA).ToString(), ds.Tables(0).Rows(i)(COL_MADUONG).ToString(), ds.Tables(0).Rows(i)(COL_MAPHUONG).ToString(), ds.Tables(0).Rows(i)(COL_DIENTICH).ToString(), ds.Tables(0).Rows(i)(COL_TENDUONG).ToString(), ds.Tables(0).Rows(i)(COL_TENDONVI).ToString(), CPVHQH.RowState.UNCHANGED))
            Next
            ViewState("DanhSach") = arrDanhSach
            '  BindGrid()
            dvDiaChi = New DataView(ds.Tables(0))
            'BindGrid()

        End Sub
        Private Sub BindGrid()
            Dim dt As New DataTable
            Dim col As DataColumn
            Dim row As DataRow
            col = New DataColumn("DiaChiID", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("SoNha", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("MaDuong", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("MaPhuong", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("DienTich", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("TenDuong", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("TenDonVi", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("Key", Type.GetType("System.String"))
            dt.Columns.Add(col)
            'Dim arrDanhSach As ArrayList = CType(ViewState("DanhSach"), ArrayList)
            arrDanhSach = CType(ViewState("DanhSach"), ArrayList)
            Dim count As Int32
            count = arrDanhSach.Count()
            For i As Integer = 0 To arrDanhSach.Count - 1
                If CType(arrDanhSach(i), DanhSach).State <> RowState.DELETED Then
                    'chi load ~ record chua bi  danh dau xoa
                    row = dt.NewRow()
                    row(COL_DIACHIID) = CType(arrDanhSach(i), DanhSach).DiaChiID
                    row(COL_SONHA) = CType(arrDanhSach(i), DanhSach).SoNha
                    row(COL_MADUONG) = CType(arrDanhSach(i), DanhSach).MaDuong
                    row(COL_MAPHUONG) = CType(arrDanhSach(i), DanhSach).MaPhuong
                    row(COL_DIENTICH) = CType(arrDanhSach(i), DanhSach).DienTich
                    row(COL_TENDUONG) = CType(arrDanhSach(i), DanhSach).TenDuong
                    row(COL_TENDONVI) = CType(arrDanhSach(i), DanhSach).TenDonVi
                    row("Key") = CType(arrDanhSach(i), DanhSach).Key
                    dt.Rows.Add(row)
                    'row(5) = CType(arrDanhSach(i), DanhSach).TenDuong
                    'row(6) = CType(arrDanhSach(i), DanhSach).TenDonVi


                End If
            Next
            dvDiaChi = New DataView(dt)
            dvDiaChi.Sort = CStr(ViewState("SortField"))
            dgdDanhSach.DataSource = dvDiaChi
            dgdDanhSach.DataKeyField = "Key"
            'dgdDanhSach.DataKeyField = "DiaChiID"
            dgdDanhSach.DataBind()

        End Sub

        Private Sub InitState()
            'Doan loc duong theo phuong
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Dim dsPhuong As New DataSet
                Dim dsDuong As New DataSet
                Dim objDanhMuc As New DanhMucController
                dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
                dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
                BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, "")
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
                BindControl.BindDropDownList(ddlMaDuong, "DMDUONGKHONGVIETTAT")
                BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONGKHONGVIETTAT")
            End If

            BindControl.BindDropDownList(ddlGioiTinh, "DMGIOITINH")
            BindControl.BindDropDownList(ddlMaNganhKinhDoanh, "DMNGANHKINHDOANH")
            'BindDropDownList_NguoiKy(ddlMaSoLanhDao)
            BindControl.BindDropDownList_StoreProc(Me.ddlMaSoLanhDao, False, "", "sp_getNguoiKy", "CPVH", Request.QueryString("tabid"))
            BindControls()

        End Sub


        Protected Function IsLastPage() As Boolean
            ' CurrentPageIndex is 0-based...
            'If dgdDanhSach.CurrentPageIndex + 1 = dgdDanhSach.PageCount Then
            '    Return True
            'Else
            '    Return True 'false
            'End If
            Return True
        End Function

        Private Sub SetAttributesControl()
            'add lich cho ngay            
            txtNgayXacNhan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayXacNhan.ClientID & ");")
            txtNgayXacNhan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            cmdNgayXacNhan.NavigateUrl = AdminDB.InvokePopupCal(txtNgayXacNhan)
            'check data not null
            txtNgayXacNhan.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaLoaiHoSo.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganhKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            'txtNoiDungKinhDoanh.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaSoLanhDao.Attributes.Add("ISNULL", "NOTNULL")
            txtHoTen.Attributes.Add("ISNULL", "NOTNULL")
            'ddlGioiTinh.Attributes.Add("ISNULL", "NOTNULL")
            txtDiaChiThuongTru.Attributes.Add("ISNULL", "NOTNULL")
            'txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            'ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac muon xoa thong tin nay khong ?')")
        End Sub
        Private Sub LoadGrid()
            Dim objHoSoXacNhanController As New HoSoXacNhanController
            txtHoSoTiepNhanID.Text = Request.QueryString.Get("ID").ToString()
            dsDiaChi = objHoSoXacNhanController.GetDiaChi(Request.QueryString.Get("ID").ToString())
            With dgdDanhSach
                .DataSource = Me.dsDiaChi
                .DataBind()
            End With
            objHoSoXacNhanController = Nothing
        End Sub
        Private Sub BindControls()
            Dim ds As DataSet
            Dim objHoSoXacNhanController As New HoSoXacNhanController
            txtHoSoTiepNhanID.Text = Request.QueryString.Get("ID").ToString()
            ds = objHoSoXacNhanController.GetHoSoXacNhan(Me)
            'Lay so bien nhan
            'txtNgayXacNhan.Text = ds.Tables(0).Rows(0)("NgayXacNhan").ToString()
            'Me.selectValueInCombobox(ddlMaNganhKinhDoanh, ds.Tables(0).Rows(0)("MaNganhKinhDoanh").ToString())
            'Me.txtNoiDungKinhDoanh.Text = ds.Tables(0).Rows(0)("NoiDungKinhDoanh").ToString()
            'Me.txtGhiChu.Text = ds.Tables(0).Rows(0)("GhiChu").ToString()
            'Me.selectValueInCombobox(ddlMaSoLanhDao, ds.Tables(0).Rows(0)("MaSoLanhDao").ToString())
            'Me.txtHoTen.Text = ds.Tables(0).Rows(0)("HoTen").ToString()
            'Me.selectValueInCombobox(ddlGioiTinh, ds.Tables(0).Rows(0)("GioiTinh").ToString())
            'Me.txtDiaChiThuongTru.Text = ds.Tables(0).Rows(0)("DiaChiThuongTru").ToString()
            'Me.txtSoNha.Text = ds.Tables(0).Rows(0)("SoNha").ToString()
            'Me.selectValueInCombobox(ddlMaDuong, ds.Tables(0).Rows(0)("MaDuong").ToString())
            'Me.selectValueInCombobox(ddlMaPhuong, ds.Tables(0).Rows(0)("MaPhuong").ToString())
            'txtSoBienNhan.Text = ds.Tables(0).Rows(0)("SoBienNhan").ToString()
            'txtHoSoXacNhanID.Text = ds.Tables(0).Rows(0)("HoSoXacNhanID").ToString()
            gLoadControlValues(ds, Me)

            ds = Nothing
            objHoSoXacNhanController = Nothing


        End Sub

        'Doan code xu ly cap nhat, them moi, xoa tren luoi
        Private Sub updNoiDungDanhSachByKey(ByVal Key As Integer, ByVal SoNha As String, ByVal MaDuong As String, ByVal MaPhuong As String, ByVal DienTich As String)
            Dim arrDanhSach As ArrayList = CType(ViewState("DanhSach"), ArrayList)
            For i As Integer = 0 To arrDanhSach.Count - 1
                If CType(arrDanhSach(i), DanhSach).Key = Key Then
                    CType(arrDanhSach(i), DanhSach).SoNha = SoNha
                    CType(arrDanhSach(i), DanhSach).MaDuong = MaDuong
                    CType(arrDanhSach(i), DanhSach).MaPhuong = MaPhuong
                    CType(arrDanhSach(i), DanhSach).DienTich = DienTich
                    If CStr(ViewState("WorkState")).Equals("EDITNOIDUNG") Then
                        If CType(arrDanhSach(i), DanhSach).State <> RowState.ADDED Then
                            CType(arrDanhSach(i), DanhSach).State = RowState.MODIFIED
                        End If
                    Else
                        CType(arrDanhSach(i), DanhSach).State = RowState.ADDED
                    End If
                    Exit For
                End If
            Next
        End Sub

        Public Sub Save_DiaChi(ByVal strHoSoTiepNhanID As String)
            Dim objSoNha, objMaDuong, objMaPhuong, objDienTich As TextBox
            Dim objHoSoXacNhanController As New HoSoXacNhanController
            Dim objDiaChiInfo As New DiaChiInfo
            For i As Integer = 0 To CType(ViewState("DanhSach"), ArrayList).Count - 1
                Dim objDanhSach As DanhSach = CType(CType(viewstate("DanhSach"), ArrayList)(i), DanhSach)
                If objDanhSach.State <> RowState.DELETED Then
                    'objHoSoXacNhanController.InsDiaChi("", Request.QueryString.Get("ID").ToString(), objDanhSach.SoNha, objDanhSach.MaDuong, objDanhSach.MaPhuong, objDanhSach.DienTich)
                    objDiaChiInfo.DiaChiID = objDanhSach.DiaChiID
                    objDiaChiInfo.HoSoTiepNhanID = Request.QueryString.Get("ID").ToString()
                    objDiaChiInfo.SoNha = objDanhSach.SoNha
                    objDiaChiInfo.MaDuong = objDanhSach.MaDuong
                    objDiaChiInfo.MaPhuong = objDanhSach.MaPhuong
                    objDiaChiInfo.DienTich = objDanhSach.DienTich
                    objHoSoXacNhanController.InsDiaChi(objDiaChiInfo)
                End If
            Next
            objDiaChiInfo = Nothing
            objHoSoXacNhanController = Nothing

        End Sub
        Private Function getDanhSachByKey(ByVal Key As Integer) As DanhSach
            Dim arrDanhSach As ArrayList = CType(ViewState("DanhSach"), ArrayList)
            For i As Integer = 0 To arrDanhSach.Count - 1
                If CType(arrDanhSach(i), DanhSach).Key = Key Then
                    Return CType(arrDanhSach(i), DanhSach)
                End If
            Next
            Return Nothing
        End Function
        Private Sub delDanhSachByKey(ByVal Key As Integer)
            Dim arrDanhSach As ArrayList = CType(ViewState("DanhSach"), ArrayList)
            For i As Integer = 0 To arrDanhSach.Count - 1
                If CType(arrDanhSach(i), DanhSach).Key = Key Then
                    '   arrDanhSach.RemoveAt(i)
                    CType(arrDanhSach(i), DanhSach).State = RowState.DELETED
                    'Else 'danh dau xoa
                    '    CType(arrDanhSach(i), DanhSach).State = RowState.DELETED
                End If
            Next
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click

            Dim objHoSoXacNhanController As New HoSoXacNhanController
            Dim objDiaChiInfo As New DiaChiInfo
            objDiaChiInfo.HoSoTiepNhanID = Request.QueryString.Get("ID").ToString()
            objHoSoXacNhanController.DelDiaChiForUpdate(objDiaChiInfo)
            'set all DiaChiID to ""
            For i As Integer = 0 To arrDanhSach.Count - 1
                If CType(arrDanhSach(i), DanhSach).State <> RowState.DELETED Then
                    CType(arrDanhSach(i), DanhSach).DiaChiID = ""
                End If
            Next
            'update viewstate on client
            ViewState("DanhSach") = arrDanhSach
            Viewstate.Remove("WorkState")
            'update HoSoXacNhanID
            Me.txtHoSoXacNhanID.Text = objHoSoXacNhanController.AddHoSoXacNhan(Me)
            Me.Save_DiaChi(Request.QueryString.Get("ID").ToString())
            objHoSoXacNhanController = Nothing
            SetEnableXoa()
        End Sub

        Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objHoSoXacNhanInfo As New HoSoXacNhanInfo
            Dim objHoSoXacNhanController As New HoSoXacNhanController
            Dim objDiaChiInfo As New DiaChiInfo
            objDiaChiInfo.HoSoTiepNhanID = Request.QueryString.Get("ID").ToString()
            'delete all DIACHI where HoSoTiepNhanID =Request.QueryString.Get("ID").ToString()
            objHoSoXacNhanController.DelDiaChiForUpdate(objDiaChiInfo)
            'delete HOSOXACNHAN
            objHoSoXacNhanInfo.HoSoTiepNhanID = txtHoSoTiepNhanID.Text
            objHoSoXacNhanInfo.MaLinhVuc = ""
            objHoSoXacNhanInfo.TabCode = ""
            objHoSoXacNhanInfo.MaNguoiTacNghiep = ""
            objHoSoXacNhanController.DelHoSoXacNhan(Me)
            Me.SetRowStateAsDeleted()
            objDiaChiInfo = Nothing
            objHoSoXacNhanInfo = Nothing
            objHoSoXacNhanController = Nothing
            'Me.ClearAllDataField()
            Response.Redirect(NavigateURL(), True)
        End Sub
        Private Sub SetRowStateAsDeleted()
            Dim i As Int32 = 0
            For i = 0 To arrDanhSach.Count - 1
                CType(arrDanhSach(i), DanhSach).State = RowState.DELETED
            Next
            Me.BindGrid()
        End Sub


        Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Sub dgdDanhSach_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.DeleteCommand

            Dim curRow As Integer = dgdDanhSach.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdDanhSach.DataKeys.Item(curRow))
                Try

                    If Not ViewState("WorkState") Is Nothing Then
                        ViewState.Remove("WorkState")
                    End If
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Me.Page, "Du lieu nhap khong hop le")
                    Exit Sub
                End Try
            End If

            Dim key As Integer = CInt(dgdDanhSach.DataKeys.Item(e.Item.ItemIndex))

            delDanhSachByKey(key)

            viewstate("DanhSach") = arrDanhSach
            If Not ViewState("WorkState") Is Nothing Then
                ViewState.Remove("WorkState")
            End If
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdDanhSach.Items.Count = 1 And dgdDanhSach.PageCount > 1 And dgdDanhSach.CurrentPageIndex = dgdDanhSach.PageCount - 1 Then
                dgdDanhSach.CurrentPageIndex -= 1
            End If
            dgdDanhSach.EditItemIndex = -1
            BindGrid()
        End Sub

        Public Sub dgdDanhSach_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.EditCommand
            Me.dgdDanhSach.EditItemIndex = CType(e.Item.ItemIndex, Int32)
            'viewstate("DIACHIID") = CType(dgdDanhSach.DataKeys().Item(e.Item.ItemIndex), String)
            txtSoNha.Text = CType(e.Item.FindControl("lblgrdSoNha"), Label).Text

            selectValueInCombobox(ddlMaDuong, CType(e.Item.FindControl("lblgrdMaDuong"), Label).Text)
            selectValueInCombobox(ddlMaPhuong, CType(e.Item.FindControl("lblgrdMaphuong"), Label).Text)
            txtDienTich.Text = CType(e.Item.FindControl("lblgrdDienTich"), Label).Text
            'update work state
            viewState("WorkState") = "EDITNOIDUNG"
            'lay so trang hien tai
            viewstate("DATAKEY") = CType(e.Item.ItemIndex, Int32) + dgdDanhSach.CurrentPageIndex * dgdDanhSach.PageSize
            Me.BindGrid()
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaDuong))
            End If
        End Sub
        Public Sub selectValueInCombobox(ByRef cboBox As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList, ByVal sValue As String)
            Dim i As Integer
            For i = 0 To cboBox.Items.Count - 1
                If (cboBox.Items(i).Value.Equals(sValue)) Then
                    cboBox.SelectedIndex = i
                    Exit For
                End If
            Next
        End Sub

        Public Sub dgdDanhSach_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.UpdateCommand
            LuuDiaChi()
        End Sub

        Public Sub dgdDanhSach_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.CancelCommand
            Dim key As Integer = CInt(dgdDanhSach.DataKeys.Item(e.Item.ItemIndex))
            If CStr(ViewState("WorkState")) = "ADDNEWNOIDUNG" Then
                delDanhSachByKey(key)
            End If
            ViewState.Remove("WorkState")
            ' If the page is top, move to prev page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdDanhSach.PageCount > 1 Then
                dgdDanhSach.CurrentPageIndex -= 1
            End If
            Me.dgdDanhSach.EditItemIndex = -1
            Me.BindGrid()
        End Sub
        Public Sub ClearAllAddressField()
            Me.txtSoNha.Text = ""
            Me.ddlMaDuong.SelectedIndex = -1
            Me.ddlMaPhuong.SelectedIndex = -1
            Me.txtDienTich.Text = ""
        End Sub
        Public Sub dgdDanhSach_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgdDanhSach.SortCommand
            dvDiaChi.Sort = e.SortExpression.ToString()
            dgdDanhSach.DataSource = dvDiaChi
            dgdDanhSach.DataBind()
        End Sub

        Public Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            Dim curRow As Integer = dgdDanhSach.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdDanhSach.DataKeys.Item(curRow))
                Try

                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Me.Page, "Du lieu nhap khong hop le")
                    Exit Sub
                End Try
            End If
            dgdDanhSach.EditItemIndex = -1
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub
        Private Sub Delete()

        End Sub
        'Doan code xu ly cap nhat, them moi, xoa tren luoi
        Private Sub updDanhSachByKey(ByVal Key As Integer, ByVal SoNha As String, ByVal MaDuong As String, ByVal MaPhuong As String, ByVal DienTich As String)
            Dim arrDanhSach As ArrayList = CType(ViewState("DanhSach"), ArrayList)
            For i As Integer = 0 To arrDanhSach.Count - 1
                If CType(arrDanhSach(i), DanhSach).Key = Key Then
                    CType(arrDanhSach(i), DanhSach).SoNha = SoNha
                    CType(arrDanhSach(i), DanhSach).MaDuong = MaDuong
                    CType(arrDanhSach(i), DanhSach).MaPhuong = MaPhuong
                    CType(arrDanhSach(i), DanhSach).DienTich = DienTich

                    If CStr(ViewState("WorkState")).Equals("EDITNOIDUNG") Then
                        If CType(arrDanhSach(i), DanhSach).State <> RowState.ADDED Then
                            CType(arrDanhSach(i), DanhSach).State = RowState.MODIFIED
                        End If
                    Else
                        CType(arrDanhSach(i), DanhSach).State = RowState.ADDED
                    End If
                    Exit For
                End If
            Next
        End Sub


        Private Sub btnLuuDiaChi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuuDiaChi.Click

            ' Refresh the grid
            'UpdateViewStateDanhSach()
            If (txtSoNha.Text = "") Then
                SetMSGBOX_HIDDEN(Me.Page, "Ban chua nhap so nha !")
                Exit Sub
            End If
            If (ddlMaDuong.SelectedIndex = 0) Then
                SetMSGBOX_HIDDEN(Me.Page, "Ban chua nhap ten duong !")
                Exit Sub
            End If
            If (ddlMaPhuong.SelectedIndex = 0) Then
                SetMSGBOX_HIDDEN(Me.Page, "Ban chua nhap ten phuong !")
                Exit Sub
            End If


            If Not viewstate("WorkState") Is Nothing Then
                If Not CType(viewstate("WorkState"), String).Equals("EDITNOIDUNG") Then
                    ViewState("WorkState") = "ADDNEWNOIDUNG"
                End If
            Else
                ViewState("WorkState") = "ADDNEWNOIDUNG"
            End If
            'update all address viewstate
            'viewstate("VS_SONHA") = txtSoNha.Text
            'viewstate("VS_MADUONG") = ddlMaDuong.SelectedItem.Value.ToString()
            'viewstate("VS_MAPHUONG") = ddlMaPhuong.SelectedItem.Value.ToString()

            LuuDiaChi()
        End Sub
        Public Function KiemTraDiaChi() As Boolean


            arrDanhSach = CType(ViewState("DanhSach"), ArrayList)

            If (Not viewstate("WorkState") Is Nothing) Then
                If (CType(viewstate("WorkState"), String).Equals("EDITNOIDUNG")) Then
                    For i As Integer = 0 To arrDanhSach.Count - 1
                        If CType(arrDanhSach(i), DanhSach).State <> RowState.DELETED And i <> CType(viewstate("DATAKEY"), Int32) Then

                            'If (CType(arrDanhSach(i), DanhSach).SoNha = CType(viewstate("VS_SONHA"), String) And CType(arrDanhSach(i), DanhSach).MaDuong = CType(viewstate("VS_MADUONG"), String) And CType(arrDanhSach(i), DanhSach).MaPhuong = CType(viewstate("VS_MAPHUONG"), String)) Then
                            If (CType(arrDanhSach(i), DanhSach).SoNha = txtSoNha.Text.ToString() And CType(arrDanhSach(i), DanhSach).MaDuong = ddlMaDuong.SelectedItem.Value.ToString() And CType(arrDanhSach(i), DanhSach).MaPhuong = ddlMaPhuong.SelectedItem.Value.ToString()) Then
                                Return False
                                Exit Function
                            End If
                        End If
                    Next
                End If

                If (CType(viewstate("WorkState"), String).Equals("ADDNEWNOIDUNG")) Then
                    For i As Integer = 0 To arrDanhSach.Count - 1
                        If CType(arrDanhSach(i), DanhSach).State <> RowState.DELETED Then
                            'If (CType(arrDanhSach(i), DanhSach).SoNha = CType(viewstate("VS_SONHA"), String) And CType(arrDanhSach(i), DanhSach).MaDuong = CType(viewstate("VS_MADUONG"), String) And CType(arrDanhSach(i), DanhSach).MaPhuong = CType(viewstate("VS_MAPHUONG"), String)) Then
                            If (CType(arrDanhSach(i), DanhSach).SoNha = txtSoNha.Text.ToString() And CType(arrDanhSach(i), DanhSach).MaDuong = ddlMaDuong.SelectedItem.Value.ToString() And CType(arrDanhSach(i), DanhSach).MaPhuong = ddlMaPhuong.SelectedItem.Value.ToString()) Then
                                Return False
                                Exit Function
                            End If
                        End If
                    Next
                End If
            End If



            Return True
        End Function

        Public Sub LuuDiaChi()
            If (KiemTraDiaChi() = False) Then
                SetMSGBOX_HIDDEN(Me.Page, "Dia chi kinh doanh nay da co roi !")
                Exit Sub
            End If
            Dim objHoSoXacNhanController As New HoSoXacNhanController
            Dim objDanhSach As DanhSach
            Dim j As Integer
            If Not viewstate("WorkState") Is Nothing Then
                If CType(viewstate("WorkState"), String).Equals("EDITNOIDUNG") Then
                    For j = 0 To arrDanhSach.Count - 1
                        If CType(arrDanhSach(j), DanhSach).Key = CType(viewstate("DATAKEY"), Integer) Then
                            CType(arrDanhSach(j), DanhSach).Key = CType(viewstate("DATAKEY"), Integer)
                            CType(arrDanhSach(j), DanhSach).SoNha = txtSoNha.Text
                            CType(arrDanhSach(j), DanhSach).MaDuong = ddlMaDuong.SelectedItem.Value.ToString()
                            CType(arrDanhSach(j), DanhSach).MaPhuong = ddlMaPhuong.SelectedItem.Value.ToString()
                            CType(arrDanhSach(j), DanhSach).DienTich = txtDienTich.Text
                            CType(arrDanhSach(j), DanhSach).TenDuong = GetTextValue(ddlMaDuong.SelectedItem.Text.ToString())
                            CType(arrDanhSach(j), DanhSach).TenDonVi = GetTextValue(ddlMaPhuong.SelectedItem.Text.ToString())
                            Exit For
                        End If
                    Next
                    'ViewState.Remove("WorkState")
                    ViewState.Remove("DATAKEY")
                Else
                    j = arrDanhSach.Count()
                    objDanhSach = New DanhSach(j)
                    objDanhSach.DiaChiID = ""
                    objDanhSach.SoNha = txtSoNha.Text
                    objDanhSach.MaDuong = ddlMaDuong.SelectedItem.Value.ToString()
                    objDanhSach.MaPhuong = ddlMaPhuong.SelectedItem.Value.ToString()
                    objDanhSach.DienTich = txtDienTich.Text
                    objDanhSach.TenDuong = GetTextValue(ddlMaDuong.SelectedItem.Text.ToString())
                    objDanhSach.TenDonVi = GetTextValue(ddlMaPhuong.SelectedItem.Text.ToString())
                    arrDanhSach.Add(objDanhSach)
                    viewstate("DanhSach") = arrDanhSach
                End If

            End If
            'update viewstate "danhSach"
            ViewState.Remove("WorkState")
            viewstate("DanhSach") = arrDanhSach
            objHoSoXacNhanController = Nothing
            BindGrid()
            ClearAllAddressField()
            'dgdDanhSach.EditItemIndex = -1
            'objHoSoXacNhanController.DelDiaChi(CType(dgdDanhSach.DataKeys().Item(e.Item.ItemIndex), String))
        End Sub
        Public Function GetTextValue(ByVal strValue As String) As String
            If Strings.InStr(strValue, "-") > 0 Then
                Return Right(strValue, strValue.Length - Strings.InStr(strValue, "-"))
            Else
                Return strValue
            End If

        End Function
        'Public Function GetTextValue(ByVal strValue As String) As String
        '    Dim sResult As String = ""
        '    Dim iAppear As Integer = 0
        '    Dim iCondition As Integer = 0
        '    Dim i As Integer
        '    Dim iLength As Integer = 0
        '    Dim iCount As Integer = 0 ' count (-)
        '    For i = 0 To strValue.Length - 1
        '        If strValue.Substring(i, 1).Equals("-") Then
        '            iCount += 1
        '        End If
        '    Next
        '    If (iCount > 1) Then ' a-b - c - d
        '        iCondition = iCount \ 2
        '        iCondition += iCount Mod 2
        '        For i = 0 To strValue.Length - 1
        '            'If (iAppear = 2) Then
        '            If (iAppear = iCondition) Then
        '                Exit For
        '            ElseIf (strValue.Substring(i, 1).Equals("-") And (iAppear < 2)) Then
        '                iAppear += 1
        '            Else
        '                iLength += 1
        '            End If
        '        Next
        '    Else
        '        For i = 0 To strValue.Length - 1
        '            If (strValue.Substring(i, 1).Equals("-")) Then
        '                Exit For
        '            Else
        '                iLength += 1
        '            End If
        '        Next
        '    End If
        '    iLength += 2
        '    'sResult = strValue.Substring(strValue.IndexOf("- "), strValue.Length - iLength)
        '    sResult = Right(strValue, strValue.Length - iLength)
        '    GetTextValue = sResult
        'End Function
        Public Sub UpdateViewStateDanhSach()
            Dim objHoSoXacNhanController As New HoSoXacNhanController
            Dim j As Integer
            If Not viewstate("WorkState") Is Nothing Then
                If CType(viewstate("WorkState"), String).Equals("EDITNOIDUNG") Then
                    For j = 0 To arrDanhSach.Count - 1
                        If CType(arrDanhSach(j), DanhSach).Key = CType(viewstate("DATAKEY"), Integer) Then
                            CType(arrDanhSach(j), DanhSach).Key = CType(viewstate("DATAKEY"), Integer)
                            CType(arrDanhSach(j), DanhSach).SoNha = txtSoNha.Text
                            CType(arrDanhSach(j), DanhSach).MaDuong = ddlMaDuong.SelectedItem.Value.ToString()
                            CType(arrDanhSach(j), DanhSach).MaPhuong = ddlMaPhuong.SelectedItem.Value.ToString()
                            CType(arrDanhSach(j), DanhSach).DienTich = txtDienTich.Text
                            Exit For
                        End If
                    Next
                    'ViewState.Remove("WorkState")
                    'ViewState.Remove("DATAKEY")
                End If
            Else
                j = arrDanhSach.Count()
                Dim objDanhSach As New DanhSach(j + 1)
                objDanhSach.DiaChiID = ""
                objDanhSach.SoNha = txtSoNha.Text
                objDanhSach.MaDuong = ddlMaDuong.SelectedItem.Value.ToString()
                objDanhSach.MaPhuong = ddlMaPhuong.SelectedItem.Value.ToString()
                objDanhSach.DienTich = txtDienTich.Text
                arrDanhSach.Add(objDanhSach)
                viewstate("DanhSach") = arrDanhSach
            End If
            'update viewstate "danhSach"
            viewstate("DanhSach") = arrDanhSach
            objHoSoXacNhanController = Nothing
            'BindGrid()
            dgdDanhSach.EditItemIndex = -1
            'objHoSoXacNhanController.DelDiaChi(CType(dgdDanhSach.DataKeys().Item(e.Item.ItemIndex), String))
        End Sub
        Protected Sub dgdDanhSach_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgdDanhSach.ItemDataBound
            'Dim objddlMaDuong, objddlMaPhuong As DropDownList
            'objddlMaDuong = CType(e.Item.FindControl("ddlgrdMaDuong"), DropDownList)
            ''BindControl.BindDropDownList(objddlMaDuong, "DMDUONG")
            ''string[] options = { "Option1", "Option2", "Option3" };
            'Dim options1() As String = {"Option1", "Option2", "Option3"}
            'objddlMaDuong.DataSource = options1
            'objddlMaDuong.DataBind()
            ''DropDownList list = (DropDownList)e.Item.FindControl("ItemDropDown");
            ''list.DataSource = options;
            ''list.DataBind();

            'objddlMaPhuong = CType(e.Item.FindControl("ddlgrdMaPhuong"), DropDownList)
            'objddlMaPhuong.DataSource = options1
            'objddlMaPhuong.DataBind()
            'BindControl.BindDropDownList(objddlMaPhuong, "DMPHUONG")
        End Sub
        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSBS As New HSHC.HoSoBoSungController
            If objHSBS.CheckBoSungHoSo(strSoBienNhan) Then
                SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                Exit Sub
            End If
            Dim objHSK As New HoSoKhongGiaiQuyetController
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=DX&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub

        Private Sub btnHoSoKhong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSBS As New HSHC.HoSoBoSungController
            If objHSBS.CheckBoSungHoSo(strSoBienNhan) Then
                SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                Exit Sub
            End If
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub
        Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New HSHC.HoSoBoSungController
            Dim dv As New DataView
            dv = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Private Sub btnYCBS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYCBS.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            Dim objHSK As New HoSoKhongGiaiQuyetController
            If objHSK.CheckHoSoKhong(txtHoSoTiepNhanID.Text) Then
                SetMSGBOX_HIDDEN(Page, "Ho so khong duoc giai quyet")
                Exit Sub
            End If
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG") & "&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub



    End Class
    Public Enum RowState As Integer
        ADDED
        DELETED
        MODIFIED
        UNCHANGED
    End Enum
    <Serializable()> Public Class DanhSach
        '    Public Class DanhSach
        Private _Key As Integer = 0
        Private _DiaChiID As String = ""
        Private _SoNha As String = ""
        Private _MaDuong As String = ""
        Private _MaPhuong As String = ""
        Private _DienTich As String = ""
        Private _TenDuong As String = ""
        Private _TenDonVi As String = ""
        Private _State As RowState = RowState.ADDED

        Public Sub New(ByVal Key As Integer)
            MyBase.New()
            _Key = Key
        End Sub
        Public Sub New(ByVal Key As Integer, ByVal strDiaChiID As String, ByVal strSoNha As String, ByVal strMaDuong As String, ByVal strMaPhuong As String, ByVal strDienTich As String, _
         ByVal strTenDuong As String, ByVal strTenDonVi As String, ByVal State As RowState)
            MyBase.New()
            _Key = Key
            _DiaChiID = strDiaChiID
            _SoNha = strSoNha
            _MaDuong = strMaDuong
            _MaPhuong = strMaPhuong
            _DienTich = strDienTich
            _TenDuong = strTenDuong
            _TenDonVi = strTenDonVi
            '_TenDuong = "ba thang"
            '_TenDonVi = "PH02"
            _State = RowState.UNCHANGED
        End Sub
        Public Property Key() As Integer
            Get
                Return _Key
            End Get
            Set(ByVal value As Integer)
                _Key = value
            End Set
        End Property
        Public Property DiaChiID() As String
            Get
                Return _DiaChiID
            End Get
            Set(ByVal Value As String)
                _DiaChiID = Value
            End Set
        End Property
        Public Property SoNha() As String
            Get
                Return _SoNha
            End Get
            Set(ByVal Value As String)
                _SoNha = Value
            End Set
        End Property
        Public Property MaDuong() As String
            Get
                Return _MaDuong
            End Get
            Set(ByVal Value As String)
                _MaDuong = Value
            End Set
        End Property
        Public Property MaPhuong() As String
            Get
                Return _MaPhuong
            End Get
            Set(ByVal Value As String)
                _MaPhuong = Value
            End Set
        End Property

        Public Property DienTich() As String
            Get
                Return _DienTich
            End Get
            Set(ByVal Value As String)
                _DienTich = Value
            End Set
        End Property
        Public Property TenDuong() As String
            Get
                Return _TenDuong
            End Get
            Set(ByVal Value As String)
                _TenDuong = Value
            End Set
        End Property
        Public Property TenDonVi() As String
            Get
                Return _TenDonVi
            End Get
            Set(ByVal Value As String)
                _TenDonVi = Value
            End Set
        End Property
        Public Property State() As RowState
            Get
                Return _State
            End Get
            Set(ByVal Value As RowState)
                _State = Value
            End Set
        End Property
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

    End Class
    'Dim objThongTinTraCuuInfo As New ThongTinTraCuuInfo(Request)
    'Dim objThongTinTraCuuCtrl As New ThongTinTraCuuController
    'Dim objTraCuu As New TraCuu(Request)
    'objTraCuu = CType(viewstate("TraCuu"), TraCuu)
    'objThongTinTraCuuInfo = CType(ViewState("ThongTinTraCuuInfo"), ThongTinTraCuuInfo)
    'objThongTinTraCuuInfo.URL = EditURL("ID", "VALUE", "LOAIHOSO")
    'objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
    'objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
    'ds = objThongTinTraCuuCtrl.GetInfoFromSearch(objThongTinTraCuuInfo)

    'BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số biên nhận,, Họ tên, Ðịa chỉ, Ngày nhận, Ngày hẹn trả, Loại hồ sơ, Tình trạng, Tình trạng, Người thụ lý", _
    '                                                "50, 0, 150, 200, 70, 70,0,0,200,100", False, True)
End Namespace
