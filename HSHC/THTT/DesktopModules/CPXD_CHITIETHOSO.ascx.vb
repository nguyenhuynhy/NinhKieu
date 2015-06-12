Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class CPXD_CHITIETHOSO
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents lblSOGP As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblThuongTru As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiXD As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiDungXD As System.Web.UI.WebControls.Label
        Protected WithEvents lblDienTich As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenCapNha As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayHoanCong As System.Web.UI.WebControls.Label
        Protected WithEvents lblSOLAN As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblDienTichSuDung As System.Web.UI.WebControls.Label
        Protected WithEvents lblKYHIEUTHIETKE As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoaiXayDung As System.Web.UI.WebControls.Label
        Protected WithEvents lblCapNha As System.Web.UI.WebControls.Label

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
            Dim objChiTiet As New ChiTIetDoThiController
            ds1 = objChiTiet.ChiTiet_I(Request.Params("ID").ToString(), Request.Params("NGAYCAP").ToString, Request.Params("SelectID").ToString(), Request.Params("LoaiCP").ToString)
            'ds2 = objChiTiet.ChiTiet_II(Request.Params("ID").ToString(), Request.Params("NGAYCAP").ToString, Request.Params("SelectID").ToString(), Request.Params("LoaiCP").ToString)
            If ds1.Tables(0).Rows.Count >= 1 Then
                gLoadControlValues(ds1, Me)
            End If
            'gLoadControlValues(ds2, Me)
            objChiTiet = Nothing
        End Sub
        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL() & "&mid=" & CType(Request.Params("Mid"), String) & "&LoaiCP=" & CType(Request.Params("LoaiCP"), String) & "&SelectChildIndex=" & CType(Request.Params("SelectChildIndex"), String) & "&SelectChildID=" & CType(Request.Params("SelectChildID"), String) & "&ctl=DSDOTHI" & "&SelectID=" & CType(Request.Params("SelectID"), String) & "&val=" & CType(Request.Params("val"), String) & "&SelectTitle=" & CType(Request.Params("SelectTitle"), String) & "&TuNgay=" & CType(Request.Params("TuNgay"), String) & "&DenNgay=" & CType(Request.Params("DenNgay"), String) & "&SelectIndex=" & CType(Request.Params("SelectIndex"), String) & "&Type=" & CType(Request.Params("Type"), String) & "&Group=" & CType(Request.Params("Group"), String))
        End Sub
    End Class
End Namespace