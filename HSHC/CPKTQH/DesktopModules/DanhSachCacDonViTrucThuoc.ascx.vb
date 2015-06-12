Imports PortalQH
Namespace CPKTQH
    Public Class DanhSachCacDonViTrucThuoc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgungKinhDoanhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLyDo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents imgNgayDuyet As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayDuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Dropdownlist3 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Dropdownlist4 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dgdDVTT As System.Web.UI.WebControls.DataGrid

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
            lblTieuDe.Text = ".:: " + Me.PortalSettings.ActiveTab.TabName + " ::."
            Dim dsDVTT As New DataSet
            dsDVTT = DataProvider.Instance.ExecuteQueryStoreProc("sp_DonViTruocThuoc_Lst")
            BindControl.BindGrdHoSo(dsDVTT, dgdDVTT, False, "", "100,150,150,150,100,100", False, False)
        End Sub

    End Class
End Namespace