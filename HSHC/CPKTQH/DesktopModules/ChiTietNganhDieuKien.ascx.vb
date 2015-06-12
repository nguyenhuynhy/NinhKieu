Imports PortalQH
Namespace CPKTQH

Public Class ChiTietNganhDieuKien
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ddlNganhCapTren As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtReLoad As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaNganh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNoiDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCoVonToiThieu As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtSoVonToiThieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents cblChungChi As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter
        Protected WithEvents txtNganhDieuKienID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUserUpdate As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkCoChungChi As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton

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
            If Not Page.IsPostBack Then
                SetAttributesControl()
                BindData()
                If Not Request.Params("ID") Is Nothing Then
                    LoadData()
                End If
                txtUserUpdate.Text = CStr(Session("UserName"))
                'If ddlNganhCapTren.SelectedValue <> "" Then
                '    Page.RegisterStartupScript("LINHVUCCAPPHEP", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaNganh))
                'End If
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtSoVonToiThieu.Attributes.Add("onblur", "javascript:return CheckData(" & txtSoVonToiThieu.ClientID & ");")
            'ddlNganhCapTren.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")

            ddlNganhCapTren.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaNganh.Attributes.Add("ISNULL", "NOTNULL")
            txtNoiDung.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript: return CheckNull();")
            btnXoa.Attributes.Add("onclick", "javascript:return confirm('Ban co chac chan muon xoa thong tin nganh kinh doanh co dieu kien nay khong?');")
        End Sub

        Private Sub BindData()
            BindControl.BindDropDownList(ddlNganhCapTren, "DMNGANHCAPTREN")
            If Not Request.Params("ID") Is Nothing Then
                BindControl.BindDropDownList(ddlMaNganh, "DMNGANHKINHDOANH")
                ddlNganhCapTren.Enabled = False
                ddlMaNganh.Enabled = False
            Else
                BindControl.BindDropDownList(ddlMaNganh, "sp_GetDMNGANHKDByNganhCapTren", "", ddlNganhCapTren.SelectedValue, 0)
            End If
            'Dim objNganh As New NganhKinhDoanhController
            'Dim dsNganhCapTren As DataSet
            'Dim dsNganhKinhDoanh As DataSet

            'dsNganhCapTren = objNganh.getLinhVucCapPhep()
            'dsNganhKinhDoanh = objNganh.getNganhKinhDoanhChinh()

            'ddlNganhCapTren.DataSource = dsNganhCapTren
            'ddlNganhCapTren.DataTextField = "TenLinhVuc"
            'ddlNganhCapTren.DataValueField = "MaLinhVuc"
            'ddlNganhCapTren.DataBind()
            'ddlNganhCapTren.Items.Insert(0, "")

            'ddlMaNganh.DataSource = dsNganhKinhDoanh
            'ddlMaNganh.DataTextField = "TenNganh"
            'ddlMaNganh.DataValueField = "MaNganh"
            'ddlMaNganh.DataBind()
            'ddlMaNganh.Items.Insert(0, "")
            'With ctrlScriptComboFilter
            '    .ConditionID = ddlNganhCapTren.ClientID
            '    .ConditionText = "TenLinhVuc"
            '    .ConditionValue = "MaLinhVuc"

            '    .ResultID = ddlMaNganh.ClientID
            '    .ResultText = "TenNganh"
            '    .ResultValue = "MaNganh"
            '    .ConditionDS = dsNganhCapTren
            '    .ResultDS = dsNganhKinhDoanh
            'End With
            'dsNganhCapTren = Nothing
            'dsNganhKinhDoanh = Nothing
            'objNganh = Nothing

            BindControl.BindCheckBoxList(cblChungChi, "sp_getDanhMucCBO", "", GetCommonDB, "DMCHUNGCHI")
        End Sub

        Private Sub LoadData()
            Dim ds As DataSet
            Dim obj As New NganhCam_CoDieuKienController
            Dim i, j As Integer

            'LOAD THÔNG TIN NGÀNH ĐIỀU KIỆN
            ds = obj.getNganhDieuKien(Request.Params("ID"))
            gLoadControlValues(ds, Me)
            If txtNganhDieuKienID.Text = "" Then
                Response.Redirect(EditURL(, , Request.Params("ctl")))
            End If

            'LOAD THÔNG TIN DANH SÁCH CHỨNG CHỈ KÈM THEO
            For j = 0 To cblChungChi.Items.Count - 1
                cblChungChi.Items(j).Selected = False
            Next

            ds = obj.getNganhDieuKienChungChi(txtNganhDieuKienID.Text)
            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        For j = 0 To cblChungChi.Items.Count - 1
                            If cblChungChi.Items(j).Value = ds.Tables(0).Rows(i).Item(0).ToString Then
                                cblChungChi.Items(j).Selected = True
                                Exit For
                            End If
                        Next
                    Next
                End If
            End If

            ddlNganhCapTren.Enabled = False
            ddlMaNganh.Enabled = False
            btnXoa.Visible = True
        End Sub

        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim obj As New NganhCam_CoDieuKienController
            obj.delNganhDieuKien(txtNganhDieuKienID.Text)
            btnThemMoi_Click(Nothing, Nothing)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objNganhDKInfo As New NganhCam_CoDieuKienInfo
            Dim objNganhDK As New NganhCam_CoDieuKienController
            Dim i As Integer

            'CẬP NHẬT THÔNG TIN NGÀNH ĐIỀU KIỆN
            If txtNganhDieuKienID.Text = "" Then
                'thêm mới ngành điều kiện
                txtNganhDieuKienID.Text = objNganhDK.insNganhDieuKien(Me)
                If txtNganhDieuKienID.Text = "" Then
                    SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                    Exit Sub
                End If
            Else
                If Not objNganhDK.updNganhDieuKien(Me) Then
                    SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong!")
                    Exit Sub
                End If
            End If

            'CẬP NHẬT THÔNG TIN NGÀNH ĐIỀU KIỆN - CHỨNG CHỈ
            objNganhDK.delNganhDieuKienChungChi(txtNganhDieuKienID.Text)
            If chkCoChungChi.Checked Then
                For i = 0 To cblChungChi.Items.Count - 1
                    If cblChungChi.Items(i).Selected Then
                        objNganhDK.insNganhDieuKienChungChi(txtNganhDieuKienID.Text, cblChungChi.Items(i).Value)
                    End If
                Next
            End If

            Response.Redirect(EditURL("ID", txtNganhDieuKienID.Text, Request.Params("ctl")))
            objNganhDK = Nothing
            objNganhDKInfo = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL(, , Request.Params("ctl")))
        End Sub

        Private Sub ddlNganhCapTren_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNganhCapTren.SelectedIndexChanged
            BindControl.BindDropDownList(ddlMaNganh, "sp_GetDMNGANHKDByNganhCapTren", "", ddlNganhCapTren.SelectedValue, 0) '1: lay mot item rong
        End Sub
    End Class
End Namespace
