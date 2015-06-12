Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class ChiTietDoThi
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSOGP As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiXD As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiDungXD As System.Web.UI.WebControls.Label
        Protected WithEvents lblDienTich As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHoanCong As System.Web.UI.WebControls.Label
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents lblSOLAN As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblTenCapNha As System.Web.UI.WebControls.Label

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
            Dim ds2, ds1 As DataSet
            Dim objChiTiet As New ChiTietDoThiController
            'ds1 = objChiTiet.ChiTiet_I(Request.Params("ID").ToString(), Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("DBCOMMON").ToString())
            'ds2 = objChiTiet.ChiTiet_II(Request.Params("ID").ToString(), Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("db_vpdt").ToString())
            gLoadControlValues(ds1, Me)
            gLoadControlValues(ds2, Me)
            objChiTiet = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL() & "&mid=" & CType(Request.Params("Mid"), String) & "&SelectChildIndex=" & CType(Request.Params("SelectChildIndex"), String) & "&SelectChildID=" & CType(Request.Params("SelectChildID"), String) & "&ctl=DSDOTHI" & "&SelectID=" & CType(Request.Params("SelectID"), String) & "&val=" & CType(Request.Params("val"), String) & "&SelectTitle=" & CType(Request.Params("SelectTitle"), String) & "&TuNgay=" & CType(Request.Params("TuNgay"), String) & "&DenNgay=" & CType(Request.Params("DenNgay"), String) & "&SelectIndex=" & CType(Request.Params("SelectIndex"), String) & "&Type=" & CType(Request.Params("Type"), String) & "&Group=" & CType(Request.Params("Group"), String))
            'http://localhost/WebQ1/Default.aspx?tabid=236&mid=726&SelectChildIndex=1&SelectChildID=2&ctl=DSDOTHI&SelectID=CPDT&Val=G006&SelectTitle=0&TuNgay=14/01/2001&DenNgay=03/02/2005&SelectIndex=1&Type=&Group=12
            'http://localhost/WebQ1/Default.aspx?tabid=236&mid=726&SelectChildIndex=1&SelectChildID=2&ctl=DSDOTHI&SelectID=CPDT&val=G006N&SelectTitle=0&TuNgay=14/01/2001&DenNgay=03/02/2005&SelectIndex=1&Type=&Group=12
        End Sub
    End Class
End Namespace

