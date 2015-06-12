Imports system.Configuration
Imports PortalQH
Namespace THTT
    Public Class TinhHinhHoSo_LoaiHoSo
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.ImageButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents txtSoDong As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnIn As System.Web.UI.WebControls.ImageButton

        Protected WithEvents lblStt As System.Web.UI.WebControls.Label

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
            Try

                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Init_State()

                End If
                'Init_State()
                If Not Session.Item("TuNgay") Is Nothing Then
                    txtTuNgay.Text = Session.Item("TuNgay").ToString
                    txtDenNgay.Text = Session.Item("DenNgay").ToString
                End If
                LoadGrid()
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub
        Private Sub SetAttributesControl()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            Me.btnTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            Me.btnDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub

        Private Sub Init_State()
            Dim glbFile As String
            Dim mSoNgay As Integer

            glbFile = ConfigurationSettings.AppSettings("PathXML") & "GLOBALHSHC.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            If Not Request.Params("ctl") Is Nothing Then
                'lblTieuDe.Visible = True
                Label1.Visible = True
                btnTroVe.Visible = True
            Else
                'lblTieuDe.Visible = False
                Label1.Visible = False
                btnTroVe.Visible = False
            End If
            txtSoDong.Text = CStr(GetSoDongHienThiLuoi())
            dgdDanhSach.PageSize = CInt(txtSoDong.Text)
        End Sub

        Private Sub LoadGrid()
            Dim objTinhHinhHoSo As New TinhHinhHoSoInfo
            Dim objTinhHinh As New TinhHinhHoSoController
            Dim ds As DataSet

            'If Not Request.Params("SelectID") Is Nothing Then
            'objTinhHinhHoSo.LinhVuc = CStr(Request.Params("SelectID"))
            'End If

            If Not Request.Params("LinhVuc") Is Nothing Then
                objTinhHinhHoSo.LinhVuc = CStr(Request.Params("LinhVuc"))
            Else
                'objTinhHinhHoSo.LinhVuc = CType(ConfigurationSettings.AppSettings("MenuIDStart"), String)
                objTinhHinhHoSo.LinhVuc = GetDefaultItem()
            End If

            objTinhHinhHoSo.TuNgay = txtTuNgay.Text
            objTinhHinhHoSo.DenNgay = txtDenNgay.Text

            ds = objTinhHinh.ThongKeLoaiHoSo(objTinhHinhHoSo)
            BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)

            
            ds = Nothing
            objTinhHinh = Nothing
            objTinhHinhHoSo = Nothing
            Session.Item("TuNgay") = txtTuNgay.Text
            Session.Item("DenNgay") = txtDenNgay.Text
        End Sub

        Private Function GetDefaultItem() As String
            Dim ds As New DataSet
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuList As New MenuListController
            objMenuListInfo.TabID = CType(Request.Params("TabID"), Integer)
            ds = objMenuList.getDanhMucList(objMenuListInfo, CType(Session("UserID"), String))
            If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
                Return CType(ds.Tables(0).Rows(0).Item(0), String)
            End If
            Return ""
        End Function

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTimKiem.Click
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
        End Sub

        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            InitHeaderGrid()
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            Else
                strURL = strURL & "&SelectID=" & CType(ConfigurationSettings.AppSettings("MenuIDStart"), String)
            End If
            If Not Request.Params("LinhVuc") Is Nothing Then
                strURL = strURL & "&LinhVuc=" & Request.Params("LinhVuc")
            Else
                strURL = strURL & "&LinhVuc=" & CType(ConfigurationSettings.AppSettings("MenuIDStart"), String)
            End If
            Return strURL
        End Function

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Dim strLinhVuc As String
            Dim strSelectID As String
            Dim SelectIndex As String
            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhVuc = Request.Params("LinhVuc")
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strSelectID = Request.Params("SelectID")
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                SelectIndex = Request.Params("SelectIndex")
            End If
            Response.Redirect(NavigateURL("") & "&SelectID=" & strSelectID & "&LinhVuc=" & strLinhVuc & "&SelectIndex=" & SelectIndex)
        End Sub

        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "So dong hien thi khong hop le")
                txtSoDong.Text = CStr(dgdDanhSach.PageSize)
                Exit Sub
            End If
            If dgdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                dgdDanhSach.PageSize = CInt(txtSoDong.Text)
                dgdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIn.Click
            If dgdDanhSach.Items.Count <= 0 Then
                SetMSGBOX_HIDDEN(Page, "Không có dữ liệu để export!")
            Else
                GridToExcel()
            End If
        End Sub

        Private Sub GridToExcel()
            dgdDanhSach.AllowPaging = False
            dgdDanhSach.AllowSorting = False
            dgdDanhSach.CurrentPageIndex = 0
            LoadGrid()
            RenderGrid()
        End Sub

        Private Sub RenderGrid()

            Dim strFileName As String = "TinhHinhHoSo.xls"
            Response.Clear()
            Response.ContentType = "application/vnd.ms-excel"
            Response.Charset = ""
            Response.AddHeader("Content-Disposition", "attachment; filename=""" & strFileName & """")
            ' Turn off the view state.
            Me.EnableViewState = False
            Dim tw As New System.IO.StringWriter
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim str As String = ""
            Dim lbl As New Label

            InitHeaderGrid()

            dgdDanhSach.RenderControl(hw)
            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())
            ' End the response.
            Response.End()
        End Sub

        Private Sub InitHeaderGrid()
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell

            dgitem.Cells.Add(InitCell("STT", 1, 2))
            dgitem.Cells.Add(InitCell("Tên loại hồ sơ", 1, 2))
            dgitem.Cells.Add(InitCell("Tồn trước", 1, 2))
            dgitem.Cells.Add(InitCell("Nhận trong kỳ", 1, 2))
            dgitem.Cells.Add(InitCell("Đã giải quyết", 3, 1))
            dgitem.Cells.Add(InitCell("Chưa giải quyết", 3, 1))
            dgitem.Cells.Add(InitCell("Trả hồ sơ", 3, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)

            dgitem = Nothing
            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Đúng hạn"))
            dgitem.Cells.Add(InitCell("Quá hạn"))
            dgitem.Cells.Add(InitCell("%"))
            dgitem.Cells.Add(InitCell("Trong hạn"))
            dgitem.Cells.Add(InitCell("Quá hạn"))
            dgitem.Cells.Add(InitCell("%"))
            dgitem.Cells.Add(InitCell("Đã nhận"))
            dgitem.Cells.Add(InitCell("Chưa nhận"))
            dgitem.Cells.Add(InitCell("%"))
            dgdDanhSach.Controls(0).Controls.AddAt(1, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(2)
            dgdDanhSach.Controls(0).Controls.RemoveAt(2)
            dgitem = Nothing
            mycell = Nothing

        End Sub

        
    End Class
End Namespace

