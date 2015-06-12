Imports PortalQH
Namespace HSHC
    Public Class ChuyenXuLyMotCuaNhieuHS
        Inherits PortalQH.PortalModuleControl
        Private Shared arrSoBienNhan As New ArrayList

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaTinhTrangXuLy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaNguoiNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaNguoiDen As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtnoiDungThuLy As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnUndo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblResult As System.Web.UI.WebControls.Label

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
            lblTieuDe.Text = "Chuyển xử lý hồ sơ "
            If Not Me.IsPostBack Then
                If (DataCache.GetCache("ChuyenXuLy") Is Nothing And Not Request.UrlReferrer Is Nothing) Then
                    DataCache.SetCache("ChuyenXuLy", Request.UrlReferrer.PathAndQuery)
                End If

                BindControl.BindDropDownList_StoreProc(ddlMaNguoiDen, True, CType(Session.Item("UserName"), String), "sp_GetNguoiSuDung", Request.Params("tabid"), CType(Session.Item("ItemCode"), String), CType(Session.Item("UserName"), String), "C")
                BindControl.BindDropDownList_StoreProc(ddlMaNguoiNhan, True, "", "sp_GetNguoiSuDung", Request.Params("tabid"), CType(Session.Item("ItemCode"), String), CType(Session.Item("UserName"), String), "N")
                txtSoBienNhan.Text = Request.Params("ID").ToString
                If txtSoBienNhan.Text <> "" Then
                    LoadData()
                End If
                BindControl.BindDropDownList_StoreProc(ddlMaTinhTrangXuLy, False, "", "sp_getTinhTrangHoSoByLoaiMotCuaNhieuHS", CType(Session.Item("ItemCode"), String), Request.Params("tabid"), "XL", txtHoSoTiepNhanID.Text)
                If ddlMaTinhTrangXuLy.Items.Count > 0 Then ddlMaTinhTrangXuLy.SelectedIndex = 0
                ddlMaNguoiDen.SelectedIndex = ddlMaNguoiDen.Items.IndexOf(ddlMaNguoiDen.Items.FindByValue(CType(Session.Item("UserName"), String)))
            End If
            GetReportURL(Request.Params("TabID"), CType(Session.Item("ItemCode"), String), "2", "HSHC", btnIn, Me)
            'If txtHoSoTiepNhanID.Text = "" Then
            '    btnIn.Visible = False
            'Else
            '    btnIn.Visible = True
            'End If
        End Sub

        Private Sub LoadData()
            Dim objTinhTrangHoSo As New TinhTrangHoSoController
            Dim rs As DataSet
            rs = objTinhTrangHoSo.GetChuyenXuLyMotCuaNhieuHS(txtSoBienNhan.Text)
            If (rs.Tables(0).Rows.Count > 0) Then
                gLoadControlValues(rs, Me)
            End If
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            'Dim m_ReturnURL As String = CStr(DataCache.GetCache("ChuyenXuLy"))
            'DataCache.RemoveCache("ChuyenXuLy")
            'Response.Redirect(m_ReturnURL, True)
            Response.Redirect(NavigateURL(), True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim objTinhTrangHoSo As New TinhTrangHoSoController
            objTinhTrangHoSo.UpdChuyenXuLyMotCuaNhieuHS(Me)
            lblResult.Visible = True
            'btnIn.Visible = True
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/25/2007	Created
        '''     Description: Phuc hoi lai tinh trang ho so truoc khi thu ly
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
            'delete history
            Me.ddlMaTinhTrangXuLy.SelectedIndex = -1
            txtMaLinhVuc.Text = CType(Session.Item("ItemCode"), String)
            txtTabCode.Text = CType(TabId, String)
            txtMaNguoiTacNghiep.Text = CType(Session.Item("UserName"), String)
            Dim objTinhTrangHoSo As New TinhTrangHoSoController
            objTinhTrangHoSo.restoreTinhTrangHoSo(Me.txtMaLinhVuc.Text, Me.txtTabCode.Text, Me.txtHoSoTiepNhanID.Text)
            'return
            Dim m_ReturnURL As String = CStr(DataCache.GetCache("ChuyenXuLy"))
            DataCache.RemoveCache("ChuyenXuLy")
            Response.Redirect(m_ReturnURL, True)
            'Response.Redirect(NavigateURL(), True)
        End Sub
        Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click

        End Sub
    End Class
End Namespace