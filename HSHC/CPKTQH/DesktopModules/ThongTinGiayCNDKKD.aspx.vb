Imports PortalQH
Namespace CPKTQH
    Public Class ThongTinGiayCNDKKD
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoCMND As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChiKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGiayPhep As System.Web.UI.WebControls.Label
        Protected WithEvents lblMatHangKinhDoanh As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblTenTinhTrang As System.Web.UI.WebControls.Label
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
            btnTroVe.Attributes.Add("onclick", "javascript:window.close();")
            Dim objKiemTraHS As New KiemTraHoSoController
            Dim dsKetQua As DataSet
            dsKetQua = objKiemTraHS.KiemTraDaCapGCN("CPKT", Request("SoCMND"), Request("SoNha"), Request("Duong"), Request("Phuong"))
            If dsKetQua.Tables(0).Rows.Count > 0 Then
                Me.lblSoGiayPhep.Text = CStr(dsKetQua.Tables(0).Rows(0)("SoGiayPhep"))
                Me.lblNgayCap.Text = CStr(dsKetQua.Tables(0).Rows(0)("NgayCap"))
                Me.lblHoTen.Text = CStr(dsKetQua.Tables(0).Rows(0)("HoTen"))
                Me.lblSoCMND.Text = CStr(dsKetQua.Tables(0).Rows(0)("SoCMND"))
                Me.lblDiaChiKinhDoanh.Text = CStr(dsKetQua.Tables(0).Rows(0)("DiaChiKinhDoanh"))
                Me.lblBangHieu.Text = CStr(dsKetQua.Tables(0).Rows(0)("BangHieu"))
                Me.lblMatHangKinhDoanh.Text = CStr(dsKetQua.Tables(0).Rows(0)("MatHangKinhDoanh"))
                Me.lblTenTinhTrang.Text = CStr(dsKetQua.Tables(0).Rows(0)("TenTinhTrang"))
            End If
        End Sub

    End Class
End Namespace