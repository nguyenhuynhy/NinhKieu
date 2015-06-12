Imports PortalQH

Namespace HSHC
    ''' -----------------------------------------------------------------------------
    ''' Project	 : PortalQH
    ''' Class	 : DanhSachHSQuaHan
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Bao cao chi tiet qua trinh thu ly qua han.
    ''' Dieu kien lay la cac ho so co 1 giai doan thu ly bat ky bi tre han
    ''' Moi ho so se link den lich su thu ly ho so
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[phuocdd]	4/28/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class DanhSachHSQuaHan
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnPreview As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnInRaGiay As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlMaNguoiNhan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaTinhTrang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Events Handlers"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                If (Not Me.IsPostBack) Then
                    txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
                    If (DataCache.GetCache("DanhSachHSQuaHan") Is Nothing And Not Request.UrlReferrer Is Nothing) Then
                        DataCache.SetCache("DanhSachHSQuaHan", Request.UrlReferrer.PathAndQuery)
                    End If
                    BindControl.BindDropDownList(Me.ddlMaNguoiNhan, "DMNGUOISUDUNG", "", True)
                    Me.loadDMLinhVuc()
                    If (Not Request.QueryString("ctl") Is Nothing And (Request("ctl") = "DSQUAHAN")) Then
                        Me.getFromQueryString()
                    Else
                        If (Me.ddlLinhVuc.Items.Count > 0) Then
                            Me.loadDMLoaiHoSo(ddlLinhVuc.SelectedValue)
                        End If
                    End If
                    Me.ClientScriptRegister()
                    BindControl.BindDropDownList(ddlMaTinhTrang, "sp_GetCurrStateByLinhVucTabCode", True, "", ddlLinhVuc.SelectedValue, "")
                    If (Not DataCache.GetCache("malv") Is Nothing) Then
                        Me.ddlLinhVuc.SelectedIndex = Me.ddlLinhVuc.Items.IndexOf(Me.ddlLinhVuc.Items.FindByValue(CStr(DataCache.GetCache("malv"))))
                    End If
                    If (Not DataCache.GetCache("lhs") Is Nothing) Then
                        Me.ddlLoaiHoSo.SelectedIndex = Me.ddlLinhVuc.Items.IndexOf(Me.ddlLoaiHoSo.Items.FindByValue(CStr(DataCache.GetCache("lhs"))))
                    End If
                    If (Not DataCache.GetCache("TuNgay") Is Nothing) Then
                        Me.txtTuNgay.Text = CStr(DataCache.GetCache("TuNgay"))
                    End If
                    If (Not DataCache.GetCache("DenNgay") Is Nothing) Then
                        Me.txtDenNgay.Text = CStr(DataCache.GetCache("DenNgay"))
                    End If
                    If (Not DataCache.GetCache("uid") Is Nothing) Then
                        Me.ddlMaNguoiNhan.SelectedIndex = Me.ddlMaNguoiNhan.Items.IndexOf(Me.ddlMaNguoiNhan.Items.FindByValue(CStr(DataCache.GetCache("uid"))))
                    End If
                    If (Not DataCache.GetCache("sid") Is Nothing) Then
                        Me.ddlMaTinhTrang.SelectedIndex = Me.ddlMaTinhTrang.Items.IndexOf(Me.ddlMaTinhTrang.Items.FindByValue(CStr(DataCache.GetCache("sid"))))
                    End If
                    Me.loadData()
                End If
                Me.btnInRaGiay.Attributes.Add("onclick", "javascript:return reportShow();")
                Me.btnTroVe.Visible = (Not DataCache.GetCache("DanhSachHSQuaHan") Is Nothing)
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Me.loadDMLoaiHoSo(Me.ddlLinhVuc.SelectedValue)
            BindControl.BindDropDownList(ddlMaTinhTrang, "sp_GetCurrStateByLinhVucTabCode", True, "", ddlLinhVuc.SelectedValue, "")
        End Sub

        Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            DataCache.SetCache("malv", Me.ddlLinhVuc.SelectedValue)
            DataCache.SetCache("lhs", Me.ddlLoaiHoSo.SelectedValue)
            DataCache.SetCache("TuNgay", Me.txtTuNgay.Text)
            DataCache.SetCache("DenNgay", Me.txtDenNgay.Text)
            DataCache.SetCache("uid", Me.ddlMaNguoiNhan.SelectedValue)
            DataCache.SetCache("sid", Me.ddlMaTinhTrang.SelectedValue)
            Me.loadData()
        End Sub

        Private Sub dgDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDanhSach.PageIndexChanged
            Me.dgDanhSach.CurrentPageIndex = e.NewPageIndex
            Me.loadData()
        End Sub

        Private Sub dgDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDanhSach.ItemCommand
            Select Case e.CommandName
                Case "ViewHistory"
                    Me.viewHistory(CStr(e.CommandArgument))
            End Select
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim m_ReturnURL As String = CStr(DataCache.GetCache("DanhSachHSQuaHan"))
            DataCache.RemoveCache("DanhSachHSQuaHan")
            DataCache.RemoveCache("malv")
            DataCache.RemoveCache("lhs")
            DataCache.RemoveCache("TuNgay")
            DataCache.RemoveCache("DenNgay")
            DataCache.RemoveCache("uid")
            DataCache.RemoveCache("sid")
            Response.Redirect(m_ReturnURL, True)
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "So dong hien thi khong hop le")
                txtSoDong.Text = CStr(dgDanhSach.PageSize)
                Exit Sub
            End If
            If dgDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgDanhSach.PageSize = CInt(txtSoDong.Text)
                dgDanhSach.CurrentPageIndex = 0
                loadData()
            End If
        End Sub
#End Region

#Region "Custom Methods"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/28/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub loadDMLinhVuc()
            Dim objMenuList As New MenuListController
            Dim objMenuListInfo As New MenuListInfo
            Dim iSelectedId As String = ""

            objMenuListInfo.TabID = CType(Request.Params("TabId"), Integer)
            objMenuListInfo.UserID = CType(Session.Item("UserID"), String)

            'init dropdownlist
            iSelectedId = CType(objMenuList.getDefaultItemCode(objMenuListInfo), String)
            If CType(System.Configuration.ConfigurationSettings.AppSettings("CheckUser" & CType(Session.Item("ActiveDB"), String)), Boolean) Then
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), CType(Session.Item("UserID"), String))
            Else
                BindControl.BindDropDownList_StoreProc(ddlLinhVuc, False, iSelectedId, "sp_getMenuUser", Request.Params("TabId"), "")
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="LinhVuc"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/28/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub loadDMLoaiHoSo(ByVal LinhVuc As String)
            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, True, "", "sp_GetDMLoaiHoSo", LinhVuc, Request.Params("tabid"))
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/28/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub ClientScriptRegister()
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	4/28/2007	Created
        '''     [phuocdd]   Oct 15th 2007   Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub loadData()
            Dim objHSQuaHan As New DanhSachHSQuaHanController
            Dim dsHSQuaHan As DataSet = objHSQuaHan.DanhSachHSQuaHan(Me.ddlLinhVuc.SelectedValue, Me.ddlLoaiHoSo.SelectedValue, Me.txtTuNgay.Text, Me.txtDenNgay.Text, Me.ddlMaNguoiNhan.SelectedValue, Me.ddlMaTinhTrang.SelectedValue)
            Me.dgDanhSach.DataSource = dsHSQuaHan.Tables(0)
            Me.dgDanhSach.DataBind()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Xem lich su thu ly ho so
        ''' </summary>
        ''' <param name="HoSoTiepNhanID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/2/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub viewHistory(ByVal HoSoTiepNhanID As String)
            Dim sURL As String
            sURL = EditURL("ID", HoSoTiepNhanID, "HISTORY&Malv=" & Me.ddlLinhVuc.SelectedValue)
            Response.Redirect(sURL, True)
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Set param lay tu QueryString, sau do load du lieu
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/2/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub getFromQueryString()
            Me.ddlLinhVuc.SelectedIndex = Me.ddlLinhVuc.Items.IndexOf(Me.ddlLinhVuc.Items.FindByValue(Request.QueryString("LinhVuc")))
            Me.loadDMLoaiHoSo(Me.ddlLinhVuc.SelectedValue)
            Me.ddlLoaiHoSo.SelectedIndex = Me.ddlLoaiHoSo.Items.IndexOf(Me.ddlLoaiHoSo.Items.FindByValue(Request.QueryString("LoaiHoSo")))
            Me.txtTuNgay.Text = Request.QueryString("TuNgay")
            Me.txtDenNgay.Text = Request.QueryString("DenNgay")
            Me.loadData()
        End Sub
#End Region

    End Class

End Namespace