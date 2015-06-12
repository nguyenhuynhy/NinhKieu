Imports PortalQH
Namespace CPKTQH
    Public Class NhapDauKyList
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInDanhSach As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTongSoHoSo As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents KTThongTinTraCuu1 As KTThongTinTraCuu
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
            If Not Page.IsPostBack Then
                SetAttributesControl()
                Init_State()
            End If
            LoadGrid()
        End Sub

        Private Sub SetAttributesControl()
            txtSoDong.Attributes.Add("onkeypress", "javascript:ValidateNumeric();")
            GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "2", "HSHC", btnInDanhSach, Me)
        End Sub

        Sub Init_State()

            dgdDanhSach.PageSize = GetSoDongHienThiLuoi()
            txtSoDong.Text = CStr(dgdDanhSach.PageSize)

            Dim objKTThongTinTraCuuInfo As New KTThongTinTraCuuInfo(Request)
            With objKTThongTinTraCuuInfo
                .TabCode = Request.Params("TabID")
                .DauKi = "1"
                .URL = EditURL("ID", "VALUE")
            End With
            Session("KTThongTinTraCuuInfo") = objKTThongTinTraCuuInfo
            objKTThongTinTraCuuInfo = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim objKTThongTinTraCuuInfo As KTThongTinTraCuuInfo
            Dim objKTThongTinTraCuuCtrl As New KTThongTinTraCuuController
            Dim ds As DataSet

            objKTThongTinTraCuuInfo = CType(Session("KTThongTinTraCuuInfo"), KTThongTinTraCuuInfo)
            If objKTThongTinTraCuuInfo Is Nothing Then
                Response.Redirect(Request.RawUrl())
            End If
            ds = objKTThongTinTraCuuCtrl.getDanhSachGiayCNDKKDDauKi(objKTThongTinTraCuuInfo)
            dgdDanhSach.DataSource = ds
            dgdDanhSach.DataBind()

            lblTongSoHoSo.Text = ds.Tables(0).Rows.Count.ToString() + " giấy phép"

            objKTThongTinTraCuuCtrl = Nothing
            objKTThongTinTraCuuInfo = Nothing
        End Sub


        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "So dong hien thi khong hop le")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL(, , getControlCapMoiCNDKKD()))
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Try
                KTThongTinTraCuu1.GetValues()
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub dgdDanhSach_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgdDanhSach.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim hpl As HyperLink
                'kiểm tra chức năng cập nhật thông tin giấy phép
                hpl = CType(e.Item.FindControl("hplCapNhat"), HyperLink)
                If Not hpl Is Nothing Then
                    If hpl.NavigateUrl = "" Then
                        'hpl.Attributes.Add("onclick", "javascript:alert('Giay phep nay khong duoc phep cap nhat thong tin\n do da nhap thong tin thay doi hoac dang ngung kinh doanh!');")
                        hpl.Visible = False
                    End If
                End If
                'kiểm tra chức năng cấp đổi
                hpl = CType(e.Item.FindControl("hplCapDoi"), HyperLink)
                If Not hpl Is Nothing Then
                    If hpl.NavigateUrl = "" Then
                        'hpl.Attributes.Add("onclick", "javascript:alert('Giay phep nay khong duoc phep cap doi\n do dang ngung kinh doanh!');")
                        hpl.Visible = False
                    End If
                End If
                'kiểm tra chức năng thay đổi nội dung ĐKKD
                hpl = CType(e.Item.FindControl("hplThayDoi"), HyperLink)
                If Not hpl Is Nothing Then
                    If hpl.NavigateUrl = "" Then
                        'hpl.Attributes.Add("onclick", "javascript:alert('Giay phep nay khong duoc phep thay doi noi dung ĐKKD\n do dang ngung kinh doanh!');")
                        hpl.Visible = False
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace

