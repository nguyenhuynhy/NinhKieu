Imports PortalQH
Imports System.Configuration


Namespace HSHC

    Public Class TongHopHoSoTheoTrangThai
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents ddlMaLinhVuc As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaLoaiHoSo As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents txtFirstLoad As System.Web.UI.WebControls.TextBox


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

            If Not IsPostBack Then
                Me.SetAttributesControl()


                'Dim glbFile As String
                'Dim mSoNgay As Integer
                'glbFile = ConfigurationSettings.AppSettings("PATH" & CType(Session.Item("ActiveDB"), String)) & "GLOBAL.xml"
                'mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
                If Request.Params("TuNgay") Is Nothing Then
                    'txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
                    txtTuNgay.Text = Format(DateAdd(DateInterval.Day, -30, Now), "dd/MM/yyyy")
                    txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
                Else
                    txtTuNgay.Text = Request.Params("TuNgay")
                    txtDenNgay.Text = Request.Params("DenNgay")
                End If

                Me.initState()
                Me.setDefaultDataValue()

                LoadGrid()
            End If
        End Sub


        Private Sub setDefaultDataValue()

            If Not Request.Params("MaLV") Is Nothing Then
                ddlMaLinhVuc.SelectedValue = CType(Request.Params("MaLV"), String)
            End If
            If Not Request.Params("MaLHS") Is Nothing Then
                ddlMaLoaiHoSo.SelectedValue = CType(Request.Params("MaLHS"), String)
            End If
            If Not Request.Params("TuNgay") Is Nothing Then
                txtTuNgay.Text = CType(Request.Params("TuNgay"), String)
            End If
            If Not Request.Params("DenNgay") Is Nothing Then
                txtDenNgay.Text = CType(Request.Params("DenNgay"), String)
            End If

        End Sub


        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")

            'filter loai ho so by linh vuc
            ddlMaLinhVuc.Attributes.Add("onchange", "javascript:AutoFilterLoaiHoSoByLinhVuc('1', '1');")
        End Sub


        Private Sub initState()

            Dim dsLinhVuc As New DataSet
            Dim dsLoaihoso As New DataSet
            Dim objDanhMuc As New DanhMucController

            dsLinhVuc = objDanhMuc.GetDanhMucList("DMLINHVUC", "", " WHERE Used = '1' ")
            dsLoaihoso = objDanhMuc.GetDanhMucList("DMLOAIHOSOBYLV")

            BindDropDownList_Dataset(ddlMaLinhVuc, dsLinhVuc, "Ten", "Ma", False, "")
            BindDropDownList_Dataset(ddlMaLoaiHoSo, dsLoaihoso, "TenLoaiHoSo", "MaLoaiHoSo", True, "")

            'BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", "", False)
            'BindControl.BindDropDownList(ddlMaLoaiHoSo, "DMLOAIHOSO")

            'Loc linh vuc lay danh muc loai ho so
            With ctrlScriptComboFilter
                .ConditionID = ddlMaLinhVuc.ClientID
                .ConditionText = "Ten"
                .ConditionValue = "Ma"
                .ConditionDS = dsLinhVuc
                .ResultID = ddlMaLoaiHoSo.ClientID
                .ResultText = "TenLoaiHoSo"
                .ResultValue = "MaLoaiHoSo"
                .ResultDS = dsLoaihoso
            End With

            dsLinhVuc = Nothing
            dsLoaihoso = Nothing
            objDanhMuc = Nothing

        End Sub


        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell

            dgitem.Cells.Add(InitCell("STT"))
            dgitem.Cells.Add(InitCell("Trạng thái"))
            dgitem.Cells.Add(InitCell("Số lượng"))
            dgitem.Cells.Add(InitCell("Tổng hồ sơ từ trước đến trạng thái hiện tại"))
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(2)

            dgitem = Nothing
            mycell = Nothing
        End Sub


        Private Sub LoadGrid()
            Try
                Dim objThongKeBaoCao As New ThongKeBaoCaoInfo
                Dim objThongKe As New ThongKeBaoCaoController
                Dim ds As DataSet

                objThongKeBaoCao.LinhVuc = ddlMaLinhVuc.SelectedValue
                objThongKeBaoCao.LoaiHoSo = ddlMaLoaiHoSo.SelectedValue
                objThongKeBaoCao.TuNgay = txtTuNgay.Text
                objThongKeBaoCao.DenNgay = txtDenNgay.Text
                ds = objThongKe.TongHopHoSoTheoTrangThai(objThongKeBaoCao)
                BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)

                ds = Nothing
                objThongKe = Nothing
                objThongKeBaoCao = Nothing

            Catch ex As Exception
                SetMSGBOX_HIDDEN(Me.Page, ex.Message)
            End Try
        End Sub


        Private Sub btnTimKiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            txtFirstLoad.Text = "Yes"

            LoadGrid()
        End Sub

    End Class

End Namespace