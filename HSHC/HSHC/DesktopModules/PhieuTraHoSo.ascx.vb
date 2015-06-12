Imports System.Configuration
Imports PortalQH
Namespace HSHC
    Public Class PhieuTraHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHoTenNguoiNop As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLyDo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaNguoiNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhieuTraHoSoID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtMaNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlMaPhuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ddlMaDuong As KeySortDropDownList.Thycotic.Web.UI.WebControls.KeySortDropDownList
        Protected WithEvents ctrlScriptComboFilter As PortalQH.ComboFilter

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
            If Not Me.IsPostBack Then
                txtMaLinhVuc.Text = Request.Params("Malv")
                txtMaNguoiSuDung.Text = CType(Session.Item("UserName"), String)
                SetAttributesControl()
                BindData()
                txtLyDo.Text = GetLyDo()
            End If
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                Page.RegisterStartupScript("DUONGPHUONG", ReLoadComboFilter(ctrlScriptComboFilter, ddlMaDuong))
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtHoTenNguoiNop.Attributes.Add("ISNULL", "NOTNULL")
            txtDiaChiThuongTru.Attributes.Add("ISNULL", "NOTNULL")
            txtLyDo.Attributes.Add("ISNULL", "NOTNULL")
            txtSoNha.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaDuong.Attributes.Add("ISNULL", "NOTNULL")
            ddlMaPhuong.Attributes.Add("ISNULL", "NOTNULL")

            btnCapNhat.Attributes.Add("onclick", "javascript:return CheckNull();")
            txtSoNha.Attributes.Add("onblur", "javascript:FillDiaChi(" & txtSoNha.ClientID & "," & txtDiaChiThuongTru.ClientID & "," & ddlMaDuong.ClientID & "," & ddlMaPhuong.ClientID & ");")
            ddlMaPhuong.Attributes.Add("onblur", "javascript:FillDiaChi(" & txtSoNha.ClientID & "," & txtDiaChiThuongTru.ClientID & "," & ddlMaDuong.ClientID & "," & ddlMaPhuong.ClientID & ");")
            ddlMaDuong.Attributes.Add("onblur", "javascript:FillDiaChi(" & txtSoNha.ClientID & "," & txtDiaChiThuongTru.ClientID & "," & ddlMaDuong.ClientID & "," & ddlMaPhuong.ClientID & ");")
        End Sub

        Private Sub BindData()
            BindControl.BindDropDownList_StoreProc(ddlMaLoaiHoSo, False, "", "sp_getDMLoaiHoSo", txtMaLinhVuc.Text, Request.Params("TabID"))
            'BindControl.BindDropDownList(ddlMaDuong, "DMDUONG")
            'BindControl.BindDropDownList(ddlMaPhuong, "DMPHUONG")
            'Doan loc duong theo phuong
            Dim dsPhuong As New DataSet
            Dim dsDuong As New DataSet
            Dim objDanhMuc As New DanhMucController
            dsPhuong = objDanhMuc.GetDanhMucList("DMPHUONG")
            dsDuong = objDanhMuc.GetDanhMucList("DMDUONGBYPHUONG")
            BindDropDownList_Dataset(ddlMaPhuong, dsPhuong, "Ten", "Ma", True, "")
            BindDropDownList_Dataset(ddlMaDuong, dsDuong, "TenDuong", "MaDuong", True, "")
            If CType(ConfigurationSettings.AppSettings("LocDuong"), String) <> "0" Then
                With ctrlScriptComboFilter
                    .ConditionID = ddlMaPhuong.ClientID
                    .ConditionText = "Ten"
                    .ConditionValue = "Ma"
                    .ResultID = ddlMaDuong.ClientID
                    .ResultText = "TenDuong"
                    .ResultValue = "MaDuong"
                    .ConditionDS = dsPhuong
                    .ResultDS = dsDuong
                End With
                ddlMaPhuong.Attributes.Add("onchange", "javascript:ComboFilter" & ctrlScriptComboFilter.ID & "('1');")
            End If

            '-------------------------------------------------------------
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            'Response.Redirect(EditURL("", "", ""), True)
            Response.Redirect(EditURL("ID", "&Malv=" & Request.Params("Malv") & "&Tenlv=" & Request.Params("Tenlv"), "Edit"))
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Try
                'cập nhật hồ sơ không giải quyết
                Dim objPhieuTraHoSo As New PhieuTraHoSoController
                txtPhieuTraHoSoID.Text = objPhieuTraHoSo.UpdPhieuTraHoSo(Me)
                objPhieuTraHoSo = Nothing
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            ResetControls(Me)
            txtLyDo.Text = GetLyDo()
            txtMaLinhVuc.Text = Request.Params("Malv")
            txtMaNguoiSuDung.Text = CType(Session.Item("UserName"), String)
        End Sub
        Private Function GetLyDo() As String
            Dim arr As New ArrayList
            arr = GetXMLChildValues(Request, "LyDoTraHoSo", glbXMLFile)
            Dim i As Integer
            For i = 0 To arr.Count - 1
                GetLyDo = GetLyDo & Chr(13)
                GetLyDo = GetLyDo & Trim(CType(arr(i), String))
            Next
        End Function

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objPhieuTraHoSo As New PhieuTraHoSoController
            Dim ds As New DataSet
            Dim strFileName As String
            Dim strFileTemplate As String
            Dim strFileOutput As String
            Dim strFileOpen As String
            strFileName = GetParamByID("FilePhieuTraHoSo", glbXMLFile)
            strFileTemplate = GetAbsoluteServerPath(Request) & ConfigurationSettings.AppSettings("Templates" & CType(Session.Item("ActiveDB"), String)) & strFileName
            strFileOutput = ConfigurationSettings.AppSettings("Documents" & CType(Session.Item("ActiveDB"), String)) & Mid(strFileName, 1, Len(strFileName) - 4) & CType(Session.Item("UserName"), String) & ".doc"
            strFileOpen = strFileOutput
            strFileOutput = GetAbsoluteServerPath(Request) & strFileOutput
            ds = objPhieuTraHoSo.InPhieuTraHoSo(Me)
            ReportByWord(ds, strFileTemplate, strFileOutput)
            Response.Write("<script language='javascript'>window.open('\" & Request.ApplicationPath() & "\\" & Replace(strFileOpen, "\", "\\") & "');</script>")
            objPhieuTraHoSo = Nothing
        End Sub
    End Class
End Namespace