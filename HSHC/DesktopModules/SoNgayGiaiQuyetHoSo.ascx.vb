
Namespace PortalQH
    Public Class SoNgayGiaiQuyetHoSo
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaTinhTrangCurr As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoNgayGiaiQuyet As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Private Shared TinhTrangCurr As String
        Private Shared TinhTrangNext As String
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlMaLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaTinhTrangNext As System.Web.UI.WebControls.DropDownList
        Private Shared MaLoaiHoSo As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


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
                BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", , , 1)
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, CType(Session.Item("ActiveDB"), String))
                BindControl.BindDropDownList(ddlMaLoaiHoSo, "sp_GetDMLoaiHoSo", False, MaLoaiHoSo, ddlMaLinhVuc.SelectedValue, "")
                BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetCurrStateByLinhVucTabCode", False, TinhTrangCurr, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
                BindControl.BindDropDownList(ddlMaTinhTrangNext, "sp_GetNextStateByLinhVucTabCode", False, TinhTrangNext, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue, ddlMaTinhTrangCurr.SelectedValue)

                TabCode = ddlTabCode.SelectedValue
                TinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
                LoadData()
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/25/2007	Updated, 
        '''     So ngay giai quyet = '' -> xo'a dinh nghia thoi han thu ly cua giai doan
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub CapNhatSoNgayGiaiQuyet()
            Dim objDuongDiTinhTrangInfo As DuongDiTinhTrangInfo
            objDuongDiTinhTrangInfo = New DuongDiTinhTrangInfo
            Try
                If (Me.txtSoNgayGiaiQuyet.Text.Trim().Length > 0) Then
                    objDuongDiTinhTrangInfo.SoNgayGiaiQuyet = CInt(Me.txtSoNgayGiaiQuyet.Text.Trim())
                Else
                    objDuongDiTinhTrangInfo.SoNgayGiaiQuyet = -1 'Xoa dinh nghia
                End If
            Catch ex As Exception
                SetMSGBOX_HIDDEN(Page, "So ngay giai quyet khong hop le")
                Return
            End Try

            Dim objDuongDiTinhTrang As DuongDiTinhTrangController
            objDuongDiTinhTrang = New DuongDiTinhTrangController
            objDuongDiTinhTrangInfo.TabCode = ddlTabCode.SelectedValue
            objDuongDiTinhTrangInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objDuongDiTinhTrangInfo.MaTinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
            objDuongDiTinhTrangInfo.MaTinhTrangNext = ddlMaTinhTrangNext.SelectedValue
            objDuongDiTinhTrangInfo.MaLoaiHoso = ddlMaLoaiHoSo.SelectedValue
            objDuongDiTinhTrang.updSoNgayGiaiQuyet(objDuongDiTinhTrangInfo)
        End Sub

        Private Sub ddlMaLoaiHoSo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaLoaiHoSo.SelectedIndexChanged
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetCurrStateByLinhVucTabCode", False, TinhTrangCurr, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindDropDownList(ddlMaTinhTrangNext, "sp_GetNextStateByLinhVucTabCode", False, TinhTrangNext, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue, ddlMaTinhTrangCurr.SelectedValue)
            LoadData()
        End Sub

        Private Sub ddlMaTinhTrangCurr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaTinhTrangCurr.SelectedIndexChanged
            BindControl.BindDropDownList(ddlMaTinhTrangNext, "sp_GetNextStateByLinhVucTabCode", False, TinhTrangNext, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue, ddlMaTinhTrangCurr.SelectedValue)
            LoadData()
        End Sub

        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            BindControl.BindDropDownList(ddlMaLoaiHoSo, "sp_GetDMLoaiHoSo", False, MaLoaiHoSo, ddlMaLinhVuc.SelectedValue, "")
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetCurrStateByLinhVucTabCode", False, TinhTrangCurr, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindDropDownList(ddlMaTinhTrangNext, "sp_GetNextStateByLinhVucTabCode", False, TinhTrangNext, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue, ddlMaTinhTrangCurr.SelectedValue)
            LoadData()
        End Sub

        Private Sub ddlTabCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTabCode.SelectedIndexChanged
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetCurrStateByLinhVucTabCode", False, TinhTrangCurr, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindDropDownList(ddlMaTinhTrangNext, "sp_GetNextStateByLinhVucTabCode", False, TinhTrangNext, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue, ddlMaTinhTrangCurr.SelectedValue)
            LoadData()
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            CapNhatSoNgayGiaiQuyet()
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            BindControl.BindDropDownList(ddlMaLoaiHoSo, "sp_GetDMLoaiHoSo", False, MaLoaiHoSo, ddlMaLinhVuc.SelectedValue, "")
            BindControl.BindDropDownList(ddlMaTinhTrangCurr, "sp_GetCurrStateByLinhVucTabCode", False, TinhTrangCurr, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue)
            BindControl.BindDropDownList(ddlMaTinhTrangNext, "sp_GetNextStateByLinhVucTabCode", False, TinhTrangNext, ddlMaLinhVuc.SelectedValue, ddlTabCode.SelectedValue, ddlMaTinhTrangCurr.SelectedValue)
            LoadData()
        End Sub

        Public Sub LoadData()
            If (ddlMaLinhVuc.Items.Count > 0 And ddlTabCode.Items.Count > 0 And ddlMaTinhTrangCurr.Items.Count > 0) Then
                Dim objDuongDiTinhTrangController As New DuongDiTinhTrangController
                Dim objDuongDiInfo As New DuongDiTinhTrangInfo
                With objDuongDiInfo
                    .MaLinhVuc = ddlMaLinhVuc.SelectedValue
                    .TabCode = ddlTabCode.SelectedValue
                    .MaTinhTrangCurr = ddlMaTinhTrangCurr.SelectedValue
                    .MaTinhTrangNext = ddlMaTinhTrangNext.SelectedValue
                    .MaLoaiHoso = ddlMaLoaiHoSo.SelectedValue
                End With
                Dim ds As New DataSet
                ds = objDuongDiTinhTrangController.getSoNgayGiaiQuyet(objDuongDiInfo)
                If (ds.Tables(0).Rows.Count > 0) Then
                    If (ds.Tables(0).Rows(0)("SoNgayGiaiQuyet") Is DBNull.Value) Then
                        Me.txtSoNgayGiaiQuyet.Text = ""
                    Else
                        Me.txtSoNgayGiaiQuyet.Text = CStr(ds.Tables(0).Rows(0)("SoNgayGiaiQuyet"))
                    End If
                Else
                    Me.txtSoNgayGiaiQuyet.Text = ""
                End If
            End If
        End Sub

        Private Sub ddlMaTinhTrangNext_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaTinhTrangNext.SelectedIndexChanged
            LoadData()
        End Sub
    End Class
End Namespace