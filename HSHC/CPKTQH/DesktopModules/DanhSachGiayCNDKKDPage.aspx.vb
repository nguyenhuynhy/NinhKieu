Imports PortalQH
Namespace CPKTQH
    Public Class DanhSachGiayCNDKKDPage
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton

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
                btnTroVe.Attributes.Add("onclick", "javascript:window.close();")
                txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
                LoadGrid()
            End If
        End Sub

        Private Sub GetValues()
            Dim objTimKiemCNDKKD As TimKiemGiayCNDKKDInfo
            If Not Session("TimKiemGiayCNDKKD") Is Nothing Then
                objTimKiemCNDKKD = CType(Session("TimKiemGiayCNDKKD"), TimKiemGiayCNDKKDInfo)
            End If

            If objTimKiemCNDKKD Is Nothing Then objTimKiemCNDKKD = New TimKiemGiayCNDKKDInfo

            With objTimKiemCNDKKD
                .BangHieu = CStr(Session("TimKiemGiayCNDKKDCUT")) 'Request.Params("BangHieu")
                .TinhTrangHienTai = "A"
            End With

            If objTimKiemCNDKKD.TinhTrangHienTai = "" Then objTimKiemCNDKKD.TinhTrangHienTai = ",A,TH,"

            Session("TimKiemGiayCNDKKD") = objTimKiemCNDKKD
            Session("TimKiemGiayCNDKKDCUT") = Nothing
        End Sub

        Private Sub LoadGrid()
            Dim ds As New DataSet
            Dim objTimKiemCNDKKD As TimKiemGiayCNDKKDInfo
            Dim obj As New TimKiemGiayCNDKKDController

            If Session("TimKiemGiayCNDKKD") Is Nothing Then
                GetValues()
            End If
            objTimKiemCNDKKD = CType(Session("TimKiemGiayCNDKKD"), TimKiemGiayCNDKKDInfo)
            ds = obj.getDanhSachGCNDKKD(objTimKiemCNDKKD)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                    dgdDanhSach.DataSource = ds
                    dgdDanhSach.DataBind()
                End If
            End If
            Session("TimKiemGiayCNDKKD") = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub
    End Class
End Namespace