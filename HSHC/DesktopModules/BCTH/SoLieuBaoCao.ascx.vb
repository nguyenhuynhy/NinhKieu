Imports PortalQH
Imports HSHC
Imports System.Configuration
Public Class SoLieuBaoCao
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDonVi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnLocDuLieu As System.Web.UI.WebControls.ImageButton
    Protected WithEvents label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDongHienThi As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnCapNhat As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnXoa As System.Web.UI.WebControls.ImageButton
    Dim strLoai As String
    Protected WithEvents btnDuyetSoLieu As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnTrove As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblDonViSL As System.Web.UI.WebControls.Label
    Protected WithEvents tblTable1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblTrangThaiDuyet As System.Web.UI.WebControls.Label
    Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMaKyBaoCao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlNam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblKyBaoCaoSL As System.Web.UI.WebControls.Label
    Protected WithEvents lblNamSL As System.Web.UI.WebControls.Label
    Protected WithEvents btnChoDuyet As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
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
        '*****************************************************
        ' bien strLoai dung de xac dinh loai so lieu         *
        ' Set cứng : tabid=197 : Uoc thuc hien ,             *
        'TabId = SLTH : Thuc hien, TabId = SLKH : Ke hoach     *
        '*****************************************************
        '********************************************************************************
        'Thuc tuc BindGrid(strLoai) : Dung cho truong hop nhập dữ liệu                  *
        '-- strLoai dùng để xác định đó là loại số liệu nào                             *
        'Thủ tục LoadGrid(strChoDuyet,strLoaiSL) dùng cho trường hợp duyệt số liệu      *
        'strChờ duyệt : Xác định loại số liệu này là chờ duyệt hay đã duyệt             *
        'strLoaiSL : Xác định đó là loại số liệu nào : Ước lượng, kế hoạch, thực hiện   *
        '********************************************************************************
        'strLoai = Request.QueryString("tabid").ToString
        strLoai = gActiveDB()
        Select Case strLoai
            'Xác định tiêu đề
        Case "SLUTH" : lblTitle.Text = ".::Số liệu ước thực hiện::."
            Case "SLTH" : lblTitle.Text = ".::Số liệu thực hiện::."
            Case "SLKH" : lblTitle.Text = ".::Số liệu kế hoạch::."
            Case "SLCD" : lblTitle.Text = ".::Số liệu chờ duyệt::."
            Case "SLDD" : lblTitle.Text = ".::Số liệu đã duyệt::."
        End Select


        If Not Me.IsPostBack Then
            BindControls()
            ' Cau lenh if dung cho truong hop duyet so lieu 
            If strLoai = "SLCD" Or strLoai = "SLDD" Then
                If Request.Params("MaDonVi").ToString <> "" And _
                   Request.Params("MaKyBaoCao").ToString <> "" And _
                   Request.Params("Nam").ToString <> "" And _
                   Request.Params("Loai").ToString <> "" Then

                    ddlDonVi.SelectedValue = Request.Params("MaDonVi").ToString
                    ddlMaKyBaoCao.SelectedValue = Request.Params("MaKyBaoCao").ToString
                    ddlNam.SelectedValue = Request.Params("Nam").ToString
                    lblDonViSL.Text = ddlDonVi.SelectedItem.ToString
                    lblKyBaoCaoSL.Text = ddlMaKyBaoCao.SelectedItem.ToString
                    lblKyBaoCaoSL.Text = lblKyBaoCaoSL.Text.ToString.Substring(2)
                    lblNamSL.Text = ddlNam.SelectedValue
                    Init_State()
                    setControl()
                    LoadGrid(strLoai, Request.Params("Loai").ToString)
                End If

            Else
                ' ngược lại là trường hợp nhập số liệu
                Init_State()
                setStatusControl()
                SetLoadGirdWhenPageLoad()
            End If
        End If
        'Export to excel
        'If Request.QueryString("ToExcel") = "True" Then
        'GridToExcel()
        'End If
    End Sub
    Private Sub BindControls()
        Dim ds As DataSet
        BindControl.BindDropDownList(ddlDonVi, "DonVi", "", False, 0)
        BindControl.BindDropDownList_StoreProc(ddlMaKyBaoCao, True, "1", ConfigurationSettings.AppSettings("db_bcth") + "..sp_GetAllKyBaoCao")
        ddlMaKyBaoCao.SelectedIndex = 2
        BindControl.BindDropDownList(ddlNam, "Nam", "", False, 1)
    End Sub
    Private Sub SetLoadGirdWhenPageLoad()
        ' Khi load trang len thi mac dinh load datagrid ' Truong hop nhap so lieu
        Dim ds As DataSet
        Dim objSLController As New SoLieuController
        Dim objSLinfo As New SoLieuInfo
        GanDuLieu(objSLinfo)
        If KiemTraHienThiGrid() = 0 Then
            ds = objSLController.GetSoLieuUocThucHien(ConfigurationSettings.AppSettings("db_bcth"), objSLinfo, strLoai)
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            setStatusWithEventInputData(ds)
            setAttrDisableText()
            setAttrNum()
            ds = Nothing

        Else
            Dim str As String
            Select Case strLoai
                Case "SLUTH" : str = "UL" ' Nếu là ước lượng thì gán strLoai =SLUTH
                Case "SLKH" : str = "KH" ' Nếu là kế hoạch thì gán strLoai =SLKH
                Case "SLTH" : str = "TH" ' Nếu là thực hiện thì gán strLoai =SLTH
            End Select
            LoadGrid("SLDD", str)

            lblTrangThaiDuyet.Text = "Số liệu đã được duyệt"
            lblTrangThaiDuyet.Visible = True
            btnCapNhat.Visible = False
            btnXoa.Visible = False
            btnIn.Visible = True

        End If

        '        ds = objSLController.GetSoLieuUocThucHien(ConfigurationSettings.AppSettings("db_bcth"), objSLinfo, strLoai)
        '       BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
        '      setStatusWithEventInputData(ds)
        '     setAttrDisableText()
        ''    setAttrNum()
        ds = Nothing
        objSLController = Nothing
        objSLinfo = Nothing
    End Sub
    Private Function KiemTraHienThiGrid() As Integer
        ' Kiem tra ky bao cao nay da duyet hay chua?
        Dim ds As DataSet
        Dim objSLController As New SoLieuController
        Dim objSLinfo As New SoLieuInfo
        GanDuLieu(objSLinfo)
        ds = objSLController.getTinhTrangDuyet(ConfigurationSettings.AppSettings("db_bcth"), objSLinfo, strLoai)
        If ds.Tables(0).Rows(0).Item(0).ToString = "0" Then
            Return 0 ' chua duyet
        Else
            Return 1 ' da duyet
        End If
        ds = Nothing
        objSLController = Nothing
        objSLinfo = Nothing
    End Function
    Private Sub Init_State()
        'Nhap so lieu
        txtSoDongHienThi.Text = CStr(GetSoDongHienThiLuoi())
        dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
        btnXoa.Attributes.Add("onClick", "javascript:return confirm('Bạn có chắc chắn muốn xóa số liệu này không ?');")
        ddlMaKyBaoCao.Attributes.Add("ISNULL", "NOTNULL")
        ddlNam.Attributes.Add("ISNULL", "NOTNULL")
        ddlNam.SelectedValue = Now.Year().ToString
        ddlDonVi.Attributes.Add("ISNULL", "NOTNULL")
        btnLocDuLieu.Attributes.Add("onclick", "javascript:return CheckNull(),checkKyBaoCao('" & ddlMaKyBaoCao.ClientID & "');")
        btnCapNhat.Attributes.Add("onclick", "javascript:CheckNull(),checkKyBaoCao('" & ddlMaKyBaoCao.ClientID & "');")
        txtSoDongHienThi.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

    End Sub
    Private Sub setStatusControl()
        btnCapNhat.Visible = False
        btnXoa.Visible = False
        btnIn.Visible = False
    End Sub
    ' Ham nay chi dung cho nhung truong hop nhap so lieu
    Private Sub BindGrid(ByVal str As String)
        Dim ds As DataSet
        Dim objSLController As New SoLieuController
        Dim objSLinfo As New SoLieuInfo
        GanDuLieu(objSLinfo)
        ds = objSLController.GetSoLieuUocThucHien(ConfigurationSettings.AppSettings("db_bcth"), objSLinfo, str)
        BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
        setStatusWithEventInputData(ds)
        setAttrDisableText()
        setAttrNum()
        ds = Nothing
        objSLController = Nothing
        objSLinfo = Nothing
    End Sub

    '============================================= Duyet so lieu======================
    Private Sub setControl()
        ' Ham nay chi dung cho truong hop Duyet so lieu
        ' Set cac control ung voi trang thai duyet so lieu
        btnLocDuLieu.Visible = False
        btnCapNhat.Visible = False
        btnXoa.Visible = False
        btnTrove.Visible = True
        If strLoai = "SLCD" Then
            btnDuyetSoLieu.Visible = True
            btnChoDuyet.Visible = False
        Else
            btnDuyetSoLieu.Visible = False
            btnChoDuyet.Visible = True
        End If
        lblDonViSL.Visible = True
        lblKyBaoCaoSL.Visible = True
        lblNamSL.Visible = True

        ddlDonVi.Visible = False
        ddlMaKyBaoCao.Visible = False
        ddlNam.Visible = False

    End Sub
    Private Sub LoadGrid(ByVal strChoDuyet As String, ByVal strLoaiSL As String)
        ' Ham nay chi dung cho truong hop Duyet so lieu
        ' Load grid ung voi truong hop duyet so lieu
        Dim ds As DataSet
        Dim objSLController As New SoLieuController
        Dim objSLinfo As New SoLieuInfo
        GanDuLieu(objSLinfo)
        ds = objSLController.getSoLieuDuyet(ConfigurationSettings.AppSettings("db_bcth"), objSLinfo, strChoDuyet, strLoaiSL)
        BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
        setAttrReadOnlyForGrid()
        'setAttrNum()
        objSLController = Nothing
        objSLinfo = Nothing
    End Sub



    Private Sub setAttrNum()
        ' Dung để kiểm tra giá trị nhập trong datagrid
        Dim obj As TextBox : Dim i As Integer
        If dgdDanhSach.Items.Count <= 0 Then Exit Sub
        For i = 0 To dgdDanhSach.Items.Count - 1
            obj = CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox)
            'obj.Attributes.Add("onfocus", "javascript:subtractChiTieu('" & obj.ClientID & "')") return isNumeric(" & obj.ClientID & ",'0'),
            obj.Attributes.Add("onblur", "javascript:return sumChiTieu('" & obj.ClientID & "');")
            obj.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
        Next i
        obj = Nothing
    End Sub
    '***************************************************************
    ' Trang thai cac control ung voi so lieu duyet hoac chua duyet *
    '***************************************************************
    Private Sub setStatusWithEventInputData(ByVal ds As DataSet)
        ' Neu da duyet
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("DaDuyet").ToString() = "1" Then
                setAttrReadOnlyForGrid()
                lblTrangThaiDuyet.Text = "Số liệu đã được duyệt"
                lblTrangThaiDuyet.Visible = True
                btnCapNhat.Visible = False
                btnXoa.Visible = False
                btnIn.Visible = True
            Else
                ' Nguoc lai thi cap nhat cac trang thai cua button
                If dgdDanhSach.Items.Count <= 0 Then
                    btnCapNhat.Visible = False
                    btnXoa.Visible = False
                    btnIn.Visible = False
                    lblTrangThaiDuyet.Visible = False
                Else
                    btnCapNhat.Visible = True
                    lblTrangThaiDuyet.Visible = False
                    btnXoa.Visible = True
                    btnIn.Visible = True
                End If
            End If
        End If
    End Sub
    ' 
    Private Sub setAttrReadOnlyForGrid()
        ' Thu tuc chi dung cho duyet so lieu
        If strLoai = "SLCD" Or strLoai = "SLDD" Then
            ' Neu la cho duyet hay da duyet thì hiển thị colum Ý kiến
            dgdDanhSach.Columns(4).Visible = True
        End If
        Dim i As Integer
        Dim j As Integer
        Dim txtSl As TextBox
        For i = 0 To dgdDanhSach.Items.Count - 1
            ' Các control nhập số liệu là read-only
            CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox).ReadOnly = True
            'CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox).BorderColor = Color.DarkGray
            CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox).BorderStyle = BorderStyle.None

        Next

        'NEU SO LIEU LA DA DUYET THI KHONG CHO NHAP TRONG CAC TRUONG HOP NHAP SO LIEU
        Dim txtYK As TextBox
        If strLoai = "SLDD" Then ' Số liệu đã duyệt thì không cập nhật ý kiến
            For i = 0 To dgdDanhSach.Items.Count - 1
                CType(dgdDanhSach.Items(i).FindControl("txtYKien"), TextBox).ReadOnly = True
                'CType(dgdDanhSach.Items(i).FindControl("txtYKien"), TextBox).BorderWidth = Unit.Empty
                'CType(dgdDanhSach.Items(i).FindControl("txtYKien"), TextBox).BorderColor = Color.DarkGray
                CType(dgdDanhSach.Items(i).FindControl("txtYKien"), TextBox).BorderStyle = BorderStyle.None


                '********************************************************************
                'Dim lbl As New LiteralControl                                      *
                'txtYK = CType(dgdDanhSach.Items(i).Cells(4).Controls(1), TextBox)  *
                'lbl.Text = txtYK.Text                                              *
                'dgdDanhSach.Items(i).Cells(4).Controls.Remove(txtYK)               *
                'dgdDanhSach.Items(i).Cells(4).Controls.Add(lbl)                    *
                '********************************************************************
            Next i
        End If
    End Sub

    ' DAT CAC CHI TIEU CHA THOA DIEU KIEN THANH READ_ONLY
    Private Sub setAttrDisableText()
        ' Thủ tục này dùng để set tất cả các chỉ tiêu cha mà thỏa những điều kiện cho trước không được nhập
        ' Duyet Grid tu dau den cuoi-1. Neu :
        ' - Ung voi mot dong, lay MaCT dong thoi kiem tra IsSum ==1&& IsData ==1
        'Neu dung : Duyet tiep tu vi tri do toi cuoi. Neu MaCha = MaCT thi lay control do ra va disable
        Dim objTxtCha As TextBox
        Dim MaCT As String
        Dim MaCha As String
        Dim i, j As Integer
        If dgdDanhSach.Items.Count = 0 Then Exit Sub
        For i = 0 To dgdDanhSach.Items.Count - 2
            MaCT = GetGridControlValue(i, dgdDanhSach, "txtMaCT").ToString
            If MaCT <> "" And _
            GetGridControlValue(i, dgdDanhSach, "txtIsData").ToString = "1" And _
            GetGridControlValue(i, dgdDanhSach, "txtIsSum").ToString = "1" Then
                'Lay text box cha
                objTxtCha = CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox)
                'Tim txtCon
                For j = i + 1 To dgdDanhSach.Items.Count - 1
                    ' Lay ma cha cua dong hien tai
                    MaCha = GetGridControlValue(j, dgdDanhSach, "txtMaCha")
                    If MaCha = MaCT Then
                        ' Neu co : co nghia la co it nhat mot con thi disable
                        CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox).ReadOnly = True
                        CType(dgdDanhSach.Items(i).FindControl("txtSoLieu"), TextBox).BorderColor = Color.DarkGray
                        Exit For
                    End If
                Next j
            End If
        Next i
    End Sub
    ' LAY DU LIEU TREN CAC CONTROL DUA VAO SOLIEUINFO --> TRONG TRUONG HOP CAP NHAT HOAC TRUY VAN
    Private Sub GanDuLieu(ByVal obj As SoLieuInfo)
        With obj
            .MaDonVi = ddlDonVi.SelectedValue
            .MaKyBaoCao = ddlMaKyBaoCao.SelectedValue
            If (ddlNam.SelectedValue.ToString <> "") Then
                .Nam = CType(ddlNam.SelectedValue.ToString, Integer)
            End If
        End With
    End Sub

    Private Sub txtSoDongHienThi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDongHienThi.TextChanged
        If Not IsInteger(txtSoDongHienThi.Text) Or Trim(txtSoDongHienThi.Text) = "" Or Val(txtSoDongHienThi.Text) = 0 Then
            txtSoDongHienThi.Text = CStr(dgdDanhSach.PageSize)
            Exit Sub
        End If
        If dgdDanhSach.PageSize <> CInt(txtSoDongHienThi.Text) Then
            dgdDanhSach.PageSize = CInt(txtSoDongHienThi.Text)
            dgdDanhSach.CurrentPageIndex = 0
        End If
        Select Case strLoai
            'HIEN THI LAI GRID.
            'Vì dùng chung một datagrid nên phải xác định từng trường hợp
        Case "SLUTH" : BindGrid(strLoai)
            Case "SLTH" : BindGrid(strLoai)
            Case "SLKH" : BindGrid(strLoai)
            Case "SLCD" : LoadGrid(strLoai, Request.Params("Loai").ToString)
            Case "SLDD" : LoadGrid(strLoai, Request.Params("Loai").ToString)
        End Select
    End Sub
    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        If strLoai = "SLUTH" Or strLoai = "SLTH" Or strLoai = "SLKH" Then
            InsertSoLieu()
        End If
        dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        Select Case strLoai
            Case "SLUTH" : BindGrid(strLoai)
            Case "SLTH" : BindGrid(strLoai)
            Case "SLKH" : BindGrid(strLoai)
            Case "SLCD" : LoadGrid(strLoai, Request.Params("Loai").ToString)
            Case "SLDD" : LoadGrid(strLoai, Request.Params("Loai").ToString)
        End Select
    End Sub

    Private Sub btnLocDuLieu_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLocDuLieu.Click
        dgdDanhSach.CurrentPageIndex = 0
        If KiemTraHienThiGrid() = 0 Then
            BindGrid(strLoai)
            lblTrangThaiDuyet.Visible = False
        Else
            Dim str As String
            Select Case strLoai
                Case "SLUTH" : str = "UL" ' Nếu là ước lượng thì gán strLoai =SLUTH
                Case "SLKH" : str = "KH" ' Nếu là kế hoạch thì gán strLoai =SLKH
                Case "SLTH" : str = "TH" ' Nếu là thực hiện thì gán strLoai =SLTH
            End Select
            LoadGrid("SLDD", str)

            lblTrangThaiDuyet.Text = "Số liệu đã được duyệt"
            lblTrangThaiDuyet.Visible = True
            btnCapNhat.Visible = False
            btnXoa.Visible = False
            btnIn.Visible = True
        End If

    End Sub
    Private Sub setSoLieuForValues(ByVal obj As SoLieuInfo, ByVal i As Integer, Optional ByVal DaDuyet As String = "0")
        ' gán dữ liệu trện grid và form vào trong object : SoLieuInfo
        obj.MaChiTieu = GetGridControlValue(i, dgdDanhSach, "txtMaCT")
        obj.Solieu = GetGridControlValue(i, dgdDanhSach, "txtSoLieu").ToString
        obj.MaDonVi = ddlDonVi.SelectedValue
        obj.MaKyBaoCao = ddlMaKyBaoCao.SelectedValue
        obj.Nam = CType(ddlNam.SelectedValue, Integer)
        obj.YKien = GetGridControlValue(i, dgdDanhSach, "txtYKien")
        obj.DaDuyet = DaDuyet
    End Sub
    'CAP NHAT SO LIEU
    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCapNhat.Click
        'dgdDanhSach.AllowPaging = False
        InsertSoLieu()
    End Sub
    Private Sub InsertSoLieu(Optional ByVal DaDuyet As String = "0")
        Dim objSLCon As New SoLieuController
        Dim objSLInfo As New SoLieuInfo
        Dim i As Integer
        For i = 0 To dgdDanhSach.Items.Count - 1
            setSoLieuForValues(objSLInfo, i, DaDuyet)
            objSLCon.UpdateSoLieu(ConfigurationSettings.AppSettings("db_bcth"), objSLInfo, strLoai)
        Next
        objSLCon = Nothing
        objSLInfo = Nothing
    End Sub
    'XOA SO LIEU
    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnXoa.Click
        If dgdDanhSach.Items.Count > 0 Then
            Dim objSLCon As New SoLieuController
            Dim objSLInfo As New SoLieuInfo
            Dim i As Integer
            'setSoLieuForValues(objSLInfo, i)
            objSLInfo.MaDonVi = ddlDonVi.SelectedValue.ToString
            objSLInfo.MaKyBaoCao = ddlMaKyBaoCao.SelectedValue.ToString
            objSLInfo.Nam = CInt(ddlNam.SelectedValue.ToString)
            objSLCon.DelSoLieu(ConfigurationSettings.AppSettings("db_bcth"), objSLInfo, strLoai)
            BindGrid(strLoai)

            objSLCon = Nothing
            objSLInfo = Nothing
        Else
            SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để xoá!")
        End If
    End Sub

    Private Sub btnTrove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTrove.Click
        Response.Redirect(NavigateURL())
    End Sub
    Private Sub btnDuyetSoLieu_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDuyetSoLieu.Click
        UpdateStatusDuyet("1")
    End Sub
    'DUNG DE BAT SU KIEN NGUOI SU DUNG AN NUT DUYET, SE CAP NHAT TRANG THAI CUA CAC SO LIEU
    Private Sub UpdateStatusDuyet(ByVal strStatus As String)
        ' Chi can thay doi tabid o day la dung duoc!
        ' tabid=197 : Uoc thuc hien , tabid = SLTH : Thuc hien , tabid =SLKH : Ke hoach

        If strLoai = "SLCD" Or strLoai = "SLDD" Then      ' Neu la so lieu cho duyet hoac duyet
            Dim strLoaiSL As String
            strLoaiSL = Request.Params("Loai").ToString ' Lấy loại số liệu : Ước lương , kế hoạch, thực hiện
            Select Case strLoaiSL                       ' Kiểm tra biếb strLoaiSL 
                Case "UL" : strLoai = "SLUTH" ' Nếu là ước lượng thì gán strLoai =SLUTH
                Case "KH" : strLoai = "SLKH" ' Nếu là kế hoạch thì gán strLoai =SLKH
                Case "TH" : strLoai = "SLTH" ' Nếu là thực hiện thì gán strLoai =SLTH
            End Select
        End If
        Try
            InsertSoLieu(strStatus)
            Dim objSl As New SoLieuController
            objSl.DuyetSoLieu(ConfigurationSettings.AppSettings("db_bcth"), Request.Params("MaKyBaoCao").ToString, Request.Params("MaDonVi").ToString, Request.Params("Nam"), strLoai, strStatus)
        Catch ex As Exception
            ProcessModuleLoadException("", Me, ex, True)
        End Try
        Response.Redirect(NavigateURL())
    End Sub
    Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
        ' Response.Redirect(EditURL("ToExcel", "True", ""))
        If dgdDanhSach.Items.Count <= 0 Then
            SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
        Else
            GridToExcel()
        End If

    End Sub
    Private Sub GridToExcel()
        dgdDanhSach.AllowPaging = False
        dgdDanhSach.AllowSorting = False
        dgdDanhSach.CurrentPageIndex = 0
        Select Case strLoai
            Case "SLUTH" : BindGrid(strLoai)
            Case "SLTH" : BindGrid(strLoai)
            Case "SLKH" : BindGrid(strLoai)
            Case "SLCD" : LoadGrid(strLoai, Request.Params("Loai").ToString)
            Case "SLDD" : LoadGrid(strLoai, Request.Params("Loai").ToString)
        End Select

        RenderGrid()
    End Sub
    Private Sub RenderGrid()

        Dim strFileName As String = "SoLieuChiTieu.xls"
        Response.Clear()
        Response.ContentType = "application/vnd.ms-excel"
        Response.Charset = ""

        Response.AddHeader("Content-Disposition", "attachment; filename=""" & strFileName & """")
        ' Turn off the view state.
        Me.EnableViewState = False
        Dim tw As New System.IO.StringWriter
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim str As String = ""
        Dim lbl As New Label

        Replace_WebControls(dgdDanhSach, "txtMaCha", "txtIsData", "txtIsSum", "txtMaCT")
        ' Get the HTML for the control.
        lblTitle.Text = "<b><font size=3>" + lblTitle.Text + "</font></b></P>"
        'Tieu de cua bao cao
        str = "<font size=3 name=Arial>Đơn vị báo cáo : " + Trim(ddlDonVi.SelectedItem.Text) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + " .Kỳ báo cáo " + Trim(ddlMaKyBaoCao.SelectedItem.Text) + "-" + Trim(ddlNam.SelectedItem.Text) + "</font></P>"
        lbl.Text = str

        lblTitle.RenderControl(hw)
        lbl.RenderControl(hw)

        dgdDanhSach.RenderControl(hw)
        ' Write the HTML back to the browser.
        Response.Write(tw.ToString())

        ' End the response.
        Response.End()
        '=================================================================================================



    End Sub

    Private Sub btnChoDuyet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnChoDuyet.Click
        UpdateStatusDuyet("0")
    End Sub
End Class
