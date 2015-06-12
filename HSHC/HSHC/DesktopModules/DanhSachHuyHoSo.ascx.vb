Imports PortalQH
Namespace HSHC
    Public Class DanhSachHuyHoSo
        Inherits PortalQH.PortalModuleControl

        Dim objThongTinTraCuuInfo As ThongTinTraCuuInfo
        'Private iSoBienNhan As String
        Protected WithEvents grdDanhSachHoSo As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ThongTinTraCuu1 As ThongTinTraCuu

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.ImageButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
            objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Dim ds As New DataSet

            If objThongTinTraCuuInfo.ItemCode <> CType(Session.Item("ItemCode"), String) Then
                objThongTinTraCuuInfo = Nothing
                objThongTinTraCuuInfo = New ThongTinTraCuuInfo(Request)
                objThongTinTraCuuInfo.ItemCode = CType(Session.Item("ItemCode"), String)
                objThongTinTraCuuInfo.NguoiTacNghiep = CType(Session.Item("UserName"), String)
            End If
            ThongTinTraCuu1.ThongTinTraCuu = objThongTinTraCuuInfo
            ds = ThongTinTraCuu1.GetInfofromSearch(objThongTinTraCuuInfo)
            BindControl.BindDataGrid(ds, grdDanhSachHoSo, ds.Tables(0).Rows.Count)
            ds = Nothing
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTimKiem.Click
            Try
                Dim ds As New DataSet
                If Not ThongTinTraCuu1 Is Nothing Then
                    objThongTinTraCuuInfo = ThongTinTraCuu1.GetValues()
                    ds = ThongTinTraCuu1.GetInfofromSearch(objThongTinTraCuuInfo)
                    BindControl.BindDataGrid(ds, grdDanhSachHoSo, ds.Tables(0).Rows.Count)
                    ds = Nothing
                End If
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        
    End Class
End Namespace