Imports PortalQH
Imports System.Configuration
Imports System.Web.UI.WebControls
Public Class SearchInfo
    Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents myTable As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lstReports As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLoaiHoSo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton

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
            'txtCommonDB.Text = ConfigurationSettings.AppSettings("commonDB")
            'txtURL.Text = EditURL("ID", "VALUE" & "&LoaiHoSo=" & ddlLoaiHoSo.SelectedValue, "CHITIETHOSO")
            Dim strLoaiHoSo As String

            If Not Request.Params("LoaiHoSo") Is Nothing Then
                'If InStr(Request.Params("LoaiHoSo"), ConfigurationSettings.AppSettings("db_tenan")) > 0 Then
                '    strLoaiHoSo = ConfigurationSettings.AppSettings("db_tenan")
                'Else
                strLoaiHoSo = Request.Params("LoaiHoSo")

                'End If
            End If
            BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, False, strLoaiHoSo, "sp_GetLoaiHoSoList", PortalId, Session.Item("UserID").ToString)
            'BindControl.BindDropDownList_StoreProc(ddlLoaiHoSo, False, strLoaiHoSo, "sp_GetLoaiHoSoList", PortalId)
            Dim objSearchInfo As New SearchInfoController
            Dim ds As DataSet

            'Kiem tra truong hop chua phan quyen
            If ddlLoaiHoSo.SelectedValue <> "" Then

                ds = objSearchInfo.GetSearchInfoList(ConfigurationSettings.AppSettings("commonDB"), ddlLoaiHoSo.SelectedValue)
                BindControl.BindRadioButtonList(lstReports, ds)
                CreateMyObject()
                CreateControls(True)
                LoadGrid()


                Dim txtTuNgay As TextBox
                Dim txtDenNgay As TextBox
                Dim cmdTuNgay As HyperLink
                Dim cmdDenNgay As HyperLink
                txtTuNgay = CType(myTable.FindControl("txtTuNgay"), TextBox)
                txtDenNgay = CType(myTable.FindControl("txtDenNgay"), TextBox)
                cmdTuNgay = CType(myTable.FindControl("cmdCalendarTuNgay"), HyperLink)
                cmdDenNgay = CType(myTable.FindControl("cmdCalendarDenNgay"), HyperLink)

                If Not (txtTuNgay Is Nothing Or txtDenNgay Is Nothing) Then
                    txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
                    txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
                End If

                If Not (cmdTuNgay Is Nothing Or cmdDenNgay Is Nothing) Then
                    cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
                    cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

                    cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
                    cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
                End If

            End If

        Else
            CreateMyObject()
            CreateControls()
            LoadGrid()
        End If

    End Sub
    Private Sub GetSearchList(ByVal DBName As String, ByVal ItemCode As String)
        Dim objSearchInfo As New SearchInfoController
        Dim ds As DataSet
        ds = objSearchInfo.GetSearchInfo(ConfigurationSettings.AppSettings("commonDB"), DBName, ItemCode)
    End Sub
    Private Sub CreateControls(Optional ByVal Init As Boolean = False)
        'If Not ViewState.Item("arr") Is Nothing Then
        '    GetDieuKien()
        'End If
        Dim TableLeft As New HtmlTable
        Dim TableRight As New HtmlTable
        Dim r As HtmlTableRow
        Dim c As HtmlTableCell
        Dim j, i As Integer

        Dim img As Image
        Dim hlk As HyperLink
        Dim hlk1 As HyperLink
        Dim hlk2 As HyperLink
        Dim txt1 As TextBox
        Dim txt2 As TextBox
        Dim arr As New ArrayList
        Dim obj As New MyNewObject
        arr = CType(ViewState.Item("arr"), ArrayList)
        Dim ctrl As Control
        'For i = 0 To myTable.Rows.Count - 1
        '    myTable.Rows.RemoveAt(0)
        'Next

        TableLeft.Align = "center"
        TableLeft.Width = "90%"
        TableLeft.Attributes.Add("runat", "server")
        TableRight.Align = "center"
        TableRight.Width = "90%"
        TableRight.Attributes.Add("runat", "server")
        For j = 0 To arr.Count - 1
            r = New HtmlTableRow
            c = New HtmlTableCell
            obj = New MyNewObject
            obj = CType(arr.Item(j), MyNewObject)
            c.Attributes.Add("class", "QH_ColLabel")
            c.Controls.Add(CreateLabel(obj))
            c.Width = "35%"
            c.VAlign = "middle"
            r.Cells.Add(c)
            c = Nothing

            c = New HtmlTableCell
            c.Attributes.Add("class", "QH_ColLabelLeft")
            c.Controls.Add(CreateInputControls(obj))
            If UCase(obj.ControlType) = "DATETEXTBOX" Then
                img = New Image
                CType(img, Image).ID = "btn" & obj.ID
                CType(img, Image).Attributes.Add("runat", "server")
                CType(img, Image).ImageUrl = "~/Images/calendar.gif"
                CType(img, Image).CssClass = "QH_ImageButton"

                hlk = New HyperLink
                hlk.ID = "cmdCalendar" & obj.ID
                hlk.CssClass = "CommandButton"
                hlk.Attributes.Add("Runat", "server")
                hlk.Controls.Add(img)
                c.Controls.Add(New LiteralControl(" "))
                c.Controls.Add(hlk)

            End If
            c.Width = "65%"
            c.VAlign = "middle"
            r.VAlign = "middle"
            r.Cells.Add(c)
            c = Nothing

            Select Case j Mod 2
                Case 0
                    TableLeft.Rows.Add(r)
                Case Else
                    TableRight.Rows.Add(r)
            End Select
            obj = Nothing
        Next


        r = New HtmlTableRow
        c = New HtmlTableCell
        c.Controls.Add(New LiteralControl("<br>"))
        r.Cells.Add(c)
        myTable.Rows.Add(r)

        r = New HtmlTableRow
        c = New HtmlTableCell
        c.Width = "50%"
        c.VAlign = "top"
        c.Controls.Add(TableLeft)
        c.Align = "Right"
        r.Cells.Add(c)

        c = New HtmlTableCell
        c.Width = "50%"
        c.VAlign = "top"
        c.Controls.Add(TableRight)
        r.Cells.Add(c)
        myTable.Rows.Add(r)

        r = New HtmlTableRow
        c = New HtmlTableCell
        c.Controls.Add(New LiteralControl("<br>"))
        r.Cells.Add(c)
        myTable.Rows.Add(r)

        txt1 = CType(myTable.FindControl("txtTuNgay"), TextBox)
        txt2 = CType(myTable.FindControl("txtDenNgay"), TextBox)
        'img = CType(myTable.FindControl("btnTuNgay"), Image)
        hlk1 = CType(myTable.FindControl("cmdCalendarTuNgay"), HyperLink)
        hlk2 = CType(myTable.FindControl("cmdCalendarDenNgay"), HyperLink)
        'If Not img Is Nothing And Not txt Is Nothing Then
        If Not hlk1 Is Nothing And Not txt1 Is Nothing Then
            txt1.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txt1.ClientID & ");checkCompareDates(" & txt1.ClientID & "," & txt2.ClientID & ");")
            Dim rightNow As DateTime = DateAdd(DateInterval.Month, -1, DateTime.Now)
            If Init Then
                txt1.Text = rightNow.ToString("dd/MM/yyyy")
            End If

            'img.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txt.ClientID & ", 'dd/mm/yyyy')")
            txt1.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            hlk1.NavigateUrl = AdminDB.InvokePopupCal(txt1)
        End If

        'img = CType(myTable.FindControl("btnDenNgay"), Image)

        'If Not img Is Nothing And Not txt Is Nothing Then
        If Not hlk2 Is Nothing And Not txt2 Is Nothing Then
            txt2.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txt2.ClientID & ");checkCompareDates(" & txt1.ClientID & "," & txt2.ClientID & ");")
            If Init Then
                txt2.Text = NgayHienTai()
            End If
            'img.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txt.ClientID & ", 'dd/mm/yyyy')")
            txt2.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            hlk2.NavigateUrl = AdminDB.InvokePopupCal(txt2)
        End If

        'If Not ViewState.Item("arr") Is Nothing Then
        '    GetValues()
        'End If
    End Sub
    Public Function CreateLabel(ByVal drw As MyNewObject) As Label
        Dim dv As DataView
        Dim lbl As New Label
        lbl.ID = "lbl" & drw.ID & "1"
        lbl.Text = drw.Description
        lbl.Visible = CType(Val(drw.Visible), Boolean)
        lbl.CssClass = "QH_Label"
        lbl.Width = Unit.Percentage(100)

        Return lbl
    End Function
    Public Function CreateInputControls(ByVal drw As MyNewObject) As Control
        Dim obj As Control
        Select Case UCase(drw.ControlType)
            Case "TEXTBOX", "DATETEXTBOX"
                'obj = New TextBox
                obj = New TextBox
                CType(obj, TextBox).ID = "txt" & drw.ID
                CType(obj, TextBox).Attributes.Add("runat", "server")

                If drw.TextMode <> "" Then
                    CType(obj, TextBox).TextMode = CType(drw.TextMode, TextBoxMode)
                End If
                If drw.Width <> "" Then
                    CType(obj, TextBox).Width = New Unit(CType(drw.Width, Integer), UnitType.Percentage)
                End If
                CType(obj, TextBox).Visible = CType(Val(drw.Visible), Boolean)
                CType(obj, TextBox).Text = drw.DefaultValue
                CType(obj, TextBox).CssClass = drw.CssClass


            Case "DROPDOWNLIST"
                obj = New DropDownList
                CType(obj, DropDownList).ID = "ddl" & drw.ID
                CType(obj, DropDownList).Attributes.Add("runat", "server")
                CType(obj, DropDownList).CssClass = drw.CssClass

                If drw.Width <> "" Then
                    CType(obj, DropDownList).Width = New Unit(CType(drw.Width, Integer), UnitType.Percentage)
                End If

                Dim strDefault As String
                If Not Request.Params(drw.ID) Is Nothing Then
                    strDefault = Request.Params(drw.ID)
                Else
                    strDefault = drw.DefaultValue
                End If
                PortalQH.BindControl.BindDropDownList_StoreProc(CType(obj, DropDownList), True, strDefault, "sp_GetDanhMucCBO", ConfigurationSettings.AppSettings("commonDB"), drw.DataSource)

            Case "CHECKBOX"
                obj = New CheckBox
                CType(obj, CheckBox).ID = "chk" & drw.ID
                CType(obj, CheckBox).Attributes.Add("runat", "server")
                CType(obj, CheckBox).CssClass = drw.CssClass
                'CType(obj, CheckBox).Enabled = CType(Val(drw.Enabled")), Boolean)
                CType(obj, CheckBox).Checked = CType(drw.DefaultValue, Boolean)

        End Select
        Return obj
    End Function

    Private Sub LoadGrid()
        Dim ds As DataSet
        Dim objSearchInfo As New SearchInfoController

        ds = objSearchInfo.GetThongTinTimKiem(ddlLoaiHoSo.SelectedValue, GetDieuKien, ViewState.Item("ProcedureName").ToString)
        'ds = objSearchInfo.GetThongTinTimKiem(ddlLoaiHoSo.SelectedValue, myTable, ViewState.Item("ProcedureName").ToString)
        If ds.Tables(0).Rows.Count < dgdDanhSach.PageSize Then dgdDanhSach.CurrentPageIndex = 0
        BindControl.BindGrdHoSo(ds, dgdDanhSach, False, "", "100,200,300,300,200", False, True)
        ds = Nothing
        objSearchInfo = Nothing
    End Sub

    Private Overloads Sub btnTimKiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
        dgdDanhSach.CurrentPageIndex = 0
        LoadGrid()
    End Sub

    Private Function GetDieuKien() As ArrayList
        Dim strDK As New ArrayList
        Dim obj As MyNewObject
        Dim ds As DataSet
        'Dim dv As DataView
        Dim arr As New ArrayList
        arr = CType(ViewState.Item("arr"), ArrayList)

        Dim j As Integer

        strDK.Add(ConfigurationSettings.AppSettings("commonDB"))
        'strDK.Add(ddlLoaiHoSo.SelectedValue)
        For j = 0 To arr.Count - 1
            obj = New MyNewObject
            obj = CType(arr(j), MyNewObject)
            strDK.Add(GetValueControl(obj))
        Next
        Dim strURL As String
        strURL = EditURL("ID", "VALUE" & "&LoaiHoSo=" & ddlLoaiHoSo.SelectedValue, "CHITIETHOSO")

        'If arr.Count > 3 Then
        '    strURL = EditURL("ID", "VALUE" & "&LoaiHoSo=" & ddlLoaiHoSo.SelectedValue, "ChiTietDoiTuong")
        'End If
        'Dim ctl As Control
        'ctl = myTable.FindControl("ddlMaKhuVuc")
        'If Not ctl Is Nothing Then
        '    strURL = strURL & "&MaKhuVuc=" & CType(ctl, DropDownList).SelectedValue
        'End If
        'ctl = myTable.FindControl("ddlTableName")
        'If Not ctl Is Nothing Then
        '    strURL = strURL & "&TableName=" & CType(ctl, DropDownList).SelectedValue
        'End If
        'ctl = myTable.FindControl("ddlLoaiCT")
        'If Not ctl Is Nothing Then
        '    strURL = strURL & "&LoaiCT=" & CType(ctl, DropDownList).SelectedValue
        'End If
        strDK.Add(strURL)
        Return strDK
    End Function
    Private Function GetValueControl(ByVal drw As MyNewObject) As String
        Dim strType, strID As String
        Dim ctl As Control
        Select Case UCase(drw.ControlType)
            Case "TEXTBOX", "DATETEXTBOX"
                ctl = myTable.FindControl("txt" & drw.ID)
                If Not ctl Is Nothing Then
                    Return CType(ctl, TextBox).Text.Replace("'", "''")
                End If
            Case "DROPDOWNLIST"
                ctl = myTable.FindControl("ddl" & drw.ID)
                If Not ctl Is Nothing Then
                    Return CType(ctl, DropDownList).SelectedValue
                End If
            Case "CHECKBOX"
                ctl = myTable.FindControl("txt" & drw.ID)
                If Not ctl Is Nothing Then
                    Return IIf(CType(ctl, CheckBox).Checked, "1", "0").ToString
                End If
        End Select

    End Function
    Private Sub CreateMyObject()
        Dim j As Integer
        Dim ID As String
        Dim objSearchInfo As New SearchInfoController
        Dim ds As DataSet

        Dim arr As New ArrayList
        Dim obj As MyNewObject


        Dim dv As DataView

        ds = objSearchInfo.GetSearchInfo(ConfigurationSettings.AppSettings("commonDB"), ddlLoaiHoSo.SelectedValue, lstReports.SelectedValue)
        dv = ds.Tables(0).DefaultView

        If dv.Count = 0 Then Exit Sub

        If dv.Count > 0 Then
            Dim drw As DataRowView = dv.Item(0)
            ID = dv.Item(0).Item("SearchInfoID").ToString
            ViewState.Item("ID") = ID
            ViewState.Item("ProcedureName") = dv.Item(0).Item("ProcedureName").ToString
        End If
        ds = Nothing
        ds = objSearchInfo.GetSearchParams(ConfigurationSettings.AppSettings("commonDB"), ID)

        dv = ds.Tables(0).DefaultView

        For j = 0 To dv.Count - 1
            obj = New MyNewObject
            obj.ControlType = dv(j).Item("ControlType").ToString
            obj.CssClass = dv(j).Item("CssClass").ToString
            obj.DataSource = dv(j).Item("DataSource").ToString
            obj.DefaultValue = dv(j).Item("DefaultValue").ToString
            obj.Description = dv(j).Item("Description").ToString
            obj.ID = dv(j).Item("ID").ToString
            obj.TextMode = dv(j).Item("TextMode").ToString
            obj.Visible = dv(j).Item("Visible").ToString
            obj.Width = dv(j).Item("Width").ToString
            arr.Add(obj)
            obj = Nothing
        Next
        ViewState.Item("arr") = arr
        dv = Nothing
        ds = Nothing
        objSearchInfo = Nothing
    End Sub
    Private Sub GetValueControls()
        Dim arr As New ArrayList
        Dim arr1 As New ArrayList
        Dim obj As MyNewObject
        Dim i As Integer
        If ViewState.Item("arr") Is Nothing Then Exit Sub
        arr = CType(viewstate.Item("arr"), ArrayList)
        For i = 0 To arr.Count - 1
            obj = New MyNewObject
            obj = CType(arr(i), MyNewObject)
            obj.DefaultValue = GetValueControl(obj)
            arr1.Add(obj)
        Next
        viewstate.Item("arr") = arr1
    End Sub

    Private Sub ddlLoaiHoSo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLoaiHoSo.SelectedIndexChanged
        Dim objSearchInfo As New SearchInfoController
        Dim ds As DataSet
        ds = objSearchInfo.GetSearchInfoList(ConfigurationSettings.AppSettings("commonDB"), ddlLoaiHoSo.SelectedValue)
        BindControl.BindRadioButtonList(lstReports, ds)
        'CreateMyObject()
        'CreateControls()
        dgdDanhSach.CurrentPageIndex = 0
        LoadGrid()
    End Sub
    Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
        If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
            SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
            txtSoDong.Text = CStr(dgdDanhSach.PageSize)
            Exit Sub
        End If
        If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
            dgdDanhSach.CurrentPageIndex = 0
            'CreateControls()
            LoadGrid()
        End If
    End Sub
    Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
        dgdDanhSach.CurrentPageIndex = e.NewPageIndex
        LoadGrid()
    End Sub


End Class
<Serializable()> Public Class MyNewObject
    Private _ID As String
    Private _Description As String
    Private _ControlType As String
    Private _Width As String
    Private _TextMode As String
    Private _DataSource As String
    Private _DefaultValue As String
    Private _Visible As String
    Private _CssClass As String
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal ID As String, _
                    ByVal Description As String, _
                    ByVal ControlType As String, _
                    ByVal Width As String, _
                    ByVal TextMode As String, _
                    ByVal DataSource As String, _
                    ByVal DefaultValue As String, _
                    ByVal Visible As String, _
                    ByVal CssClass As String)
        MyBase.New()
        _ID = ID
        _Description = Description
        _ControlType = ControlType
        _Width = Width
        _TextMode = TextMode
        _DataSource = DataSource
        _DefaultValue = DefaultValue
        _Visible = Visible
        _CssClass = CssClass
    End Sub
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal Value As String)
            _ID = Value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal Value As String)
            _Description = Value
        End Set
    End Property
    Public Property ControlType() As String
        Get
            Return _ControlType
        End Get
        Set(ByVal Value As String)
            _ControlType = Value
        End Set
    End Property
    Public Property Width() As String
        Get
            Return _Width
        End Get
        Set(ByVal Value As String)
            _Width = Value
        End Set
    End Property
    Public Property TextMode() As String
        Get
            Return _TextMode
        End Get
        Set(ByVal Value As String)
            _TextMode = Value
        End Set
    End Property
    Public Property DataSource() As String
        Get
            Return _DataSource
        End Get
        Set(ByVal Value As String)
            _DataSource = Value
        End Set
    End Property
    Public Property DefaultValue() As String
        Get
            Return _DefaultValue
        End Get
        Set(ByVal Value As String)
            _DefaultValue = Value
        End Set
    End Property
    Public Property Visible() As String
        Get
            Return _Visible
        End Get
        Set(ByVal Value As String)
            _Visible = Value
        End Set
    End Property
    Public Property CssClass() As String
        Get
            Return _CssClass
        End Get
        Set(ByVal Value As String)
            _CssClass = Value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

