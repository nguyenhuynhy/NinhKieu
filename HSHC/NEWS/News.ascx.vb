Imports PortalQH
Imports System.Configuration
Public MustInherit Class News

    Inherits PortalQH.PortalModuleControl
    'Protected WithEvents lstCats As System.Web.UI.WebControls.DataList
    Protected WithEvents dgdNewsByCat As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgdNewsSummary As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgdDetail As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgdNewsPosted As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents lblPageTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblNewsPosted As System.Web.UI.WebControls.Label
    Protected WithEvents rowNewsPosted As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents rowNewsByDate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents lnkbtnViewByDate As System.Web.UI.WebControls.LinkButton
    Protected WithEvents imgDate As System.Web.UI.WebControls.Image
    Protected WithEvents lnkbtnViewNext As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rowViewNext As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Image3 As System.Web.UI.WebControls.Image
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Image4 As System.Web.UI.WebControls.Image
    Protected WithEvents Label91 As System.Web.UI.WebControls.Label
    Protected WithEvents imgFromDate As System.Web.UI.WebControls.Image
    Protected WithEvents imgToDate As System.Web.UI.WebControls.Image
    Dim dsCats As New DataSet

    Public Property CategoryID() As String
        Get
            If Not ViewState("CatsID") Is Nothing Then
                Return CStr(ViewState("CatsID"))
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("CatsID") = Value
        End Set
    End Property

    'Tinh trang tin tuc
    Public Enum RunningMode
        Summary
        Category
        Detail
    End Enum

    Public Property NewsMode() As RunningMode
        Get
            If Not ViewState("NewsMode") Is Nothing Then
                Return CType(ViewState("NewsMode"), RunningMode)
            Else
                Return RunningMode.Summary
            End If
        End Get
        Set(ByVal Value As RunningMode)
            ViewState("NewsMode") = Value
        End Set
    End Property

    'Luu lai trang thai back
    Public Property ReturnMode() As RunningMode
        Get
            If Not ViewState("ReturnMode") Is Nothing Then
                Return CType(ViewState("ReturnMode"), RunningMode)
            Else
                Return RunningMode.Summary
            End If
        End Get
        Set(ByVal Value As RunningMode)
            ViewState("ReturnMode") = Value
        End Set
    End Property

    'Luu lai trang hien thoi khi xem tin theo loai tin
    Public Property CurrPage() As Integer
        Get
            If Not ViewState("CurrPage") Is Nothing Then
                Return CInt(ViewState("CurrPage"))
            Else
                Return 1
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState("CurrPage") = Value
        End Set
    End Property

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' declare module actions
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtFromDate.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtFromDate.ClientID & ");")
        Me.imgFromDate.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtFromDate.ClientID & ", 'dd/mm/yyyy')")
        Me.txtToDate.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtToDate.ClientID & ");")
        Me.imgToDate.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtToDate.ClientID & ", 'dd/mm/yyyy')")

        Try
            If Not Me.IsPostBack Then
                'Me.createLeftTable()
                Me.NewsMode = RunningMode.Summary
                Me.setupGUI()
                Me.loadNewsSummary() 'Lay 1 so tin dau tien cua tat ca cac loai tin
                ItemCommand_Selected()
            End If

        Catch exc As Exception 'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    'Setup GUI
    Private Sub setupGUI()
        Me.dgdNewsSummary.Visible = (Me.NewsMode = RunningMode.Summary)
        Me.dgdNewsByCat.Visible = (Me.NewsMode = RunningMode.Category)
        Me.dgdDetail.Visible = (Me.NewsMode = RunningMode.Detail)
        Me.rowNewsPosted.Visible = (Me.NewsMode = RunningMode.Category Or Me.NewsMode = RunningMode.Detail)
        Me.rowNewsByDate.Visible = (Me.NewsMode = RunningMode.Category)
        Me.rowViewNext.Visible = (Me.NewsMode = RunningMode.Category)
        Me.dgdNewsSummary.BorderWidth = Unit.Pixel(0)
        Me.dgdNewsByCat.BorderWidth = Unit.Pixel(0)
        Me.dgdDetail.BorderWidth = Unit.Pixel(0)
        Me.dgdNewsPosted.BorderWidth = Unit.Pixel(0)
    End Sub

    'Lay danh muc cac loai tin
    'Private Sub createLeftTable()
    '    Dim objNews As New NewsController
    '    Me.dsCats = objNews.getCategories(CType(ConfigurationSettings.AppSettings("db_web"), String))
    '    For Each row As DataRow In Me.dsCats.Tables(0).Rows
    '        If CStr(row("Ma")) = Me.CategoryID Then
    '            row("Selected") = 1
    '        End If
    '    Next
    '    Me.lstCats.DataSource = dsCats
    '    Me.lstCats.DataBind()
    'End Sub

    'Load tin tuc
    Private Sub bindData(ByVal datagrid As DataGrid, ByVal dsNews As DataSet)
        datagrid.DataSource = dsNews
        datagrid.DataBind()
        If datagrid.ID = "dgdNewsByCat" And datagrid.Items.Count <= 0 Then
            datagrid.Visible = False
            SetMSGBOX_HIDDEN(Me.Page, "Không tìm thấy tin")
        Else
            datagrid.Visible = True
        End If
    End Sub

    'Tong hop cac loai tin
    Function createTblSummary(ByVal dsNews As DataSet) As DataSet
        Dim dsResult As DataSet = dsNews.Copy()
        dsResult.Tables(0).Columns.Add(New DataColumn("Flag"))
        'Flag = 0 : Show Title
        'Flag = 1 : Show Title, View more
        'Flag = 6 : Show Category Name, Title, Summary
        'Flag = 7 : Show Category Name, Title, Summary, View more
        For i As Integer = 0 To dsResult.Tables(0).Rows.Count - 1 Step 1
            If i = 0 Then
                dsResult.Tables(0).Rows(i)("Flag") = 7
            Else
                If CStr(dsResult.Tables(0).Rows(i)("Category_ID")) = CStr(dsResult.Tables(0).Rows(i - 1)("Category_ID")) Then
                    Select Case CInt(CStr(dsResult.Tables(0).Rows(i - 1)("Flag")))
                        Case 7
                            dsResult.Tables(0).Rows(i - 1)("Flag") = 6
                            dsResult.Tables(0).Rows(i)("Flag") = 1
                        Case 6
                            dsResult.Tables(0).Rows(i)("Flag") = 1
                        Case 1
                            dsResult.Tables(0).Rows(i - 1)("Flag") = 0
                            dsResult.Tables(0).Rows(i)("Flag") = 1
                    End Select
                Else
                    dsResult.Tables(0).Rows(i)("Flag") = 7
                End If
            End If
        Next
        Return dsResult
    End Function

    Private Sub loadNewsSummary(Optional ByVal strTitle As String = "")
        Dim objNews As New NewsController
        Dim dsNews As New DataSet
        Dim dstmp As New DataSet

        Me.dsCats = objNews.getCategories(CType(ConfigurationSettings.AppSettings("db_web"), String))

        'Lay NumOfNews tin moi nhat theo tung loai tin
        Dim NumOfNews As Integer = CInt(ConfigurationSettings.AppSettings("NewsPerCat"))
        For Each row As DataRow In dsCats.Tables(0).Rows
            'Chi lay nhung tin tu hom nay tro ve truoc
            'Ngay duoc format theo kieu vi-VN
            dstmp.Merge(objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), strTitle, CStr(row("Ma")), "PUBLISHED", "V", 1, NumOfNews, "", DateTime.Today.ToString("dd/MM/yyyy")))
        Next
        Me.bindData(Me.dgdNewsSummary, Me.createTblSummary(dstmp))
        Dim now As String = DateTime.Now.ToString("dddd, dd/MM/yyyy, HH:mm", New System.Globalization.CultureInfo("vi-VN", False))
        'Me.lblPageTitle.Text = now.Substring(0, 1).ToUpper() & now.Substring(1)
    End Sub

    Private Sub loadNewsByCat(Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "")
        Dim objNews As New NewsController
        Dim dsNews As New DataSet
        'Lay NumOfNews tin moi nhat theo tung loai tin
        'Chi lay nhung tin tu ngay hien hanh tro ve truoc
        'Ngay duoc format theo kieu vi-VN
        If ToDate.Length = 0 Then
            ToDate = DateTime.Today.ToString("dd/MM/yyyy")
        End If
        If ToDate.Length > 0 Then
            If DateTime.Parse(ToDate, New System.Globalization.CultureInfo("vi-VN")) > DateTime.Today Then
                ToDate = DateTime.Today.ToString("dd/MM/yyyy")
            End If
        End If
        If FromDate.Length > 0 And ToDate.Length > 0 Then
            If DateTime.Parse(FromDate, New System.Globalization.CultureInfo("vi-VN")) > DateTime.Parse(ToDate, New System.Globalization.CultureInfo("vi-VN")) Then
                FromDate = ToDate
            End If
        End If
        Dim NumOfNews As Integer = CInt(ConfigurationSettings.AppSettings("NumOFNews"))
        Dim dstmp As New DataSet
        dstmp = objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), "", Me.CategoryID, "PUBLISHED", "V", Me.CurrPage, NumOfNews, FromDate, ToDate)
        Me.bindData(Me.dgdNewsByCat, dstmp)
        dstmp = objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), "", Me.CategoryID, "PUBLISHED", "V", Me.CurrPage + 1, NumOfNews, FromDate, ToDate)
        Me.bindData(Me.dgdNewsPosted, dstmp)
        Me.rowViewNext.Visible = Me.dgdNewsPosted.Visible
        Me.rowNewsPosted.Visible = Me.dgdNewsPosted.Visible
    End Sub

    Private Sub loadNewsDetail(ByVal NewsID As String)
        Dim objNews As New NewsController
        Dim dsNews As New DataSet
        Dim NumOfNews As Integer = CInt(ConfigurationSettings.AppSettings("NumOFNews"))
        Dim dstmp As New DataSet
        dstmp = objNews.getDataByKey(CType(ConfigurationSettings.AppSettings("db_web"), String), NewsID, "V")
        Me.bindData(Me.dgdDetail, dstmp)
        If Not dstmp Is Nothing And dstmp.Tables(0).Rows.Count > 0 Then
            Me.CategoryID = CStr(dstmp.Tables(0).Rows(0)("LoaiTin"))
            'Me.createLeftTable()
        End If
        'Ngay duoc format theo kieu vi-VN
        dstmp = objNews.LstAll(CType(ConfigurationSettings.AppSettings("db_web"), String), "", Me.CategoryID, "PUBLISHED", "V", 1, NumOfNews, "", DateTime.Today.ToString("dd/MM/yyyy"), CInt(NewsID))
        Me.bindData(Me.dgdNewsPosted, dstmp)
        Me.rowNewsPosted.Visible = Me.dgdNewsPosted.Visible
        Dim now As String = DateTime.Now.ToString("dddd, dd/MM/yyyy, HH:mm", New System.Globalization.CultureInfo("vi-VN", False))
        'Me.lblPageTitle.Text = now.Substring(0, 1).ToUpper() & now.Substring(1)
    End Sub

    Public Sub ItemCommand_Selected()
        Dim objNews As New NewsController
        Dim SelectID As String
        If Not Request.Params("SelectID") Is Nothing Then
            SelectID = CType(Request.Params("SelectID"), String)
            Me.dsCats = objNews.getCategories(CType(ConfigurationSettings.AppSettings("db_web"), String))

            Me.CategoryID = SelectID
            Me.NewsMode = RunningMode.Category
            Me.CurrPage = 1
            Me.setupGUI()

            Dim rows() As DataRow = Me.dsCats.Tables(0).Select("Ma = '" + Me.CategoryID + "'")
            'Me.lblPageTitle.Text = "Trang " & CStr(rows(0)("Ten")).ToLower()
            Me.loadNewsByCat()
        End If
        
    End Sub
    'Private Sub lstCats_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles lstCats.ItemCommand
    '    If e.CommandName.Equals("getByCat") Then
    '        Me.CategoryID = CStr(e.CommandArgument)
    '        Me.NewsMode = RunningMode.Category
    '        Me.CurrPage = 1
    '        Me.setupGUI()
    '        Me.createLeftTable()
    '        Dim rows() As DataRow = Me.dsCats.Tables(0).Select("Ma = '" + Me.CategoryID + "'")
    '        Me.lblPageTitle.Text = "Trang " & CStr(rows(0)("Ten")).ToLower()
    '        Me.loadNewsByCat()
    '    End If
    'End Sub

    Private Sub dgdNewsSummary_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdNewsSummary.ItemCommand
        Dim objNews As New NewsController
        Select Case e.CommandName
            Case "getByCat"
                Me.CategoryID = CStr(e.CommandArgument)
                Me.NewsMode = RunningMode.Category
                Me.setupGUI()
                'Me.createLeftTable()
                Me.dsCats = objNews.getCategories(CType(ConfigurationSettings.AppSettings("db_web"), String))

                Dim rows() As DataRow = Me.dsCats.Tables(0).Select("Ma = '" + Me.CategoryID + "'")
                'Me.lblPageTitle.Text = "Trang " & CStr(rows(0)("Ten")).ToLower()
                Me.loadNewsByCat()
            Case "viewDetail"
                Me.ReturnMode = Me.NewsMode
                Me.NewsMode = RunningMode.Detail
                Me.setupGUI()
                Me.loadNewsDetail(CStr(e.CommandArgument))
        End Select
    End Sub

    Private Sub dgdNewsByCat_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdNewsByCat.ItemCommand
        Select Case e.CommandName
            Case "viewDetail"
                Me.ReturnMode = Me.NewsMode
                Me.NewsMode = RunningMode.Detail
                Me.setupGUI()
                Me.loadNewsDetail(CStr(e.CommandArgument))
        End Select
    End Sub

    Private Sub dgdDetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDetail.ItemCommand
        Select Case e.CommandName
            Case "goBack"
                Me.CurrPage = 1
                Me.NewsMode = RunningMode.Category
                Me.setupGUI()
        End Select
    End Sub

    Private Sub dgdNewsPosted_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdNewsPosted.ItemCommand
        Select Case e.CommandName
            Case "viewDetail"
                Me.ReturnMode = Me.NewsMode
                Me.NewsMode = RunningMode.Detail
                Me.setupGUI()
                Me.loadNewsDetail(CStr(e.CommandArgument))
        End Select
    End Sub

    Private Sub lnkbtnViewNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnViewNext.Click
        Me.CurrPage += 1
        Me.loadNewsByCat()
    End Sub

    Private Sub lnkbtnViewByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnViewByDate.Click
        Me.CurrPage = 1
        Me.loadNewsByCat(Me.txtFromDate.Text.Trim(), Me.txtToDate.Text.Trim())
    End Sub

    Private Sub lnkbtnHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.NewsMode = RunningMode.Summary
        Me.CategoryID = ""
        'Me.createLeftTable()
        Me.setupGUI()
        Me.loadNewsSummary()
    End Sub

    'Private Sub btnTimNoiDung_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Me.CurrPage = 1
    '    Me.NewsMode = RunningMode.Summary
    '    'Me.createLeftTable()
    '    Me.setupGUI()
    '    'Me.loadNewsSummary(txtNoiDungTim.Text)
    'End Sub

    Public Sub TimNoiDung(ByVal pNoiDung As String)
        'Dim objNews As New NewsController
        'Me.dsCats = objNews.getCategories(CType(ConfigurationSettings.AppSettings("db_web"), String))

        Me.CurrPage = 1
        Me.NewsMode = RunningMode.Summary
        Me.setupGUI()
        Me.loadNewsSummary(pNoiDung)
    End Sub
End Class
