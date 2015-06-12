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
    Public Class THQTThuLy
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
                    Me.loadDMLinhVuc()
                    If (Me.ddlLinhVuc.Items.Count > 0) Then
                        Me.loadDMLoaiHoSo(ddlLinhVuc.SelectedValue)
                    End If
                    Me.ClientScriptRegister()
                End If
                Me.btnInRaGiay.Attributes.Add("onclick", "javascript:return reportShow();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub ddlLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLinhVuc.SelectedIndexChanged
            Me.loadDMLoaiHoSo(Me.ddlLinhVuc.SelectedValue)
        End Sub

        Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            Me.loadData()
        End Sub

        Private Sub dgDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDanhSach.PageIndexChanged
            Me.dgDanhSach.CurrentPageIndex = e.NewPageIndex
            Me.loadData()
        End Sub

        Private Sub dgDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDanhSach.ItemCommand
            Select Case e.CommandName
                Case "DSQuaHan"
                    Me.viewDSQuaHan(CStr(e.CommandArgument))
            End Select
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
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur('" & txtTuNgay.ClientID & "');checkCompareDates('" & txtTuNgay.ClientID & "','" & txtDenNgay.ClientID & "');")

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
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub loadData()
            Dim objHSQuaHan As New THQTThuLyController
            Dim dsHSQuaHan As DataSet = objHSQuaHan.THQTThuLy(Me.ddlLinhVuc.SelectedValue, Me.ddlLoaiHoSo.SelectedValue, Me.txtTuNgay.Text, Me.txtDenNgay.Text)
            Me.dgDanhSach.DataSource = dsHSQuaHan.Tables(0)
            Me.dgDanhSach.DataBind()
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Xem danh sach ho so thu ly qua han
        ''' </summary>
        ''' <param name="MaLoaiHoSo"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[phuocdd]	5/3/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub viewDSQuaHan(ByVal MaLoaiHoSo As String)
            Dim sURL As String
            sURL = EditURL("LinhVuc", Me.ddlLinhVuc.SelectedValue & "&LoaiHoSo=" & MaLoaiHoSo & "&TuNgay=" & Me.txtTuNgay.Text & "&DenNgay=" & Me.txtDenNgay.Text, "DSQUAHAN")
            Response.Redirect(sURL, True)
        End Sub
#End Region

    End Class

End Namespace