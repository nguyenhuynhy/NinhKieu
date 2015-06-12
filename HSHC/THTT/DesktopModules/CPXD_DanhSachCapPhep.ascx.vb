Imports system.Configuration
Imports PortalQH
Namespace THTT
    Public Class CPXD_DanhSachCapPhep
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
            Try
                If Not Page.IsPostBack Then
                    Init_State()
                End If
                LoadGrid()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub
        Private Sub Init_State()
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub
        Private Sub LoadGrid()
            Dim objDanhSach As New DanhSachDoThiController
            Dim ds As DataSet
            Dim strGroup As String
            Dim strURL As String

            strURL = EditURL("ID", "value" & "&SelectID=" & Request.Params("SelectID") & "&LoaiCP=" & Request.Params("LOAICP") & "&Val=" & RTrim(Request.Params("Val").ToString()) & "&SelectTitle=" & Request.Params("SelectTitle") & "&TuNgay=" & Request.Params("TuNgay").ToString() & "&DenNgay=" & Request.Params("DenNgay").ToString() & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&Type=" & Request.Params("Type").ToString() & "&Group=" & Request.Params("Group").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString(), "CHITIETDT")

            Select Case Request.Params("Group").ToString()
                Case "11" : strGroup = "11"
                Case "12" : strGroup = "12"
                Case Else : strGroup = "%%"
            End Select

            ds = objDanhSach.DanhSachDoThiPhuong_DS(Request.Params("TuNgay").ToString(), Request.Params("DenNgay").ToString(), Request.Params("Val").ToString(), strGroup, Request.Params("Type").ToString(), Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString(), Request.Params("LoaiCP"), strURL)

            'BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            If Not ds Is Nothing Then
                BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "Số GP,Ngày cấp,Họ tên,Địa chỉ,DTXD,DTXSD", "100,100,200,400,100,100,100", False, True)
            End If
            ds = Nothing
            objDanhSach = Nothing
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

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim iIndex As String
            Dim iChildIndex As String
            Dim iType As String
            Dim iSelectID As String
            Dim iSelectTitle As String

            If Not Request.Params("SelectTitle") Is Nothing Then
                iSelectTitle = Request.Params("SelectTitle").ToString()
            Else
                iSelectTitle = "0"
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectID = Request.Params("SelectID").ToString()
            Else
                iSelectID = "0"
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                iIndex = Request.Params("SelectIndex").ToString()
            Else
                iIndex = "0"
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                iChildIndex = Request.Params("SelectChildIndex").ToString()
            Else
                iChildIndex = "0"
            End If
            If Not Request.Params("Type") Is Nothing Then
                iType = Request.Params("Type").ToString()
            Else
                iType = "1"
            End If
            Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&Type=" & iType & "&TuNgay=" & Request.Params("TuNgay") & "&DenNgay=" & Request.Params("DenNgay") & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle)
        End Sub
    End Class
End Namespace