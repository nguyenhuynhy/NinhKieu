Imports PortalQH
Imports System.Configuration
Namespace CPKTQH
    Public Class ThongTinDanhSachXaVien
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents btnThem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnSua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ddlGioiTinh As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDanToc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNoiCapCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChoOHienNay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox

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
             
                If Not Request.Params("ID") Is Nothing Then
                    bindData()
                End If

                bindGrid()
                addJavaScript()

                If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                    enableControls(False)
                    dgdDanhSach.Enabled = False
                End If
            End If
        End Sub
        Private Sub enableControls(ByVal b As Boolean)
            txtHoTen.Enabled = b
            ddlGioiTinh.Enabled = b
            txtNgaySinh.Enabled = b
            txtDanToc.Enabled = b
            txtSoCMND.Enabled = b
            txtNoiCapCMND.Enabled = b
            txtNgayCapCMND.Enabled = b
            txtDiaChiThuongTru.Enabled = b
            txtChoOHienNay.Enabled = b
            btnThem.Enabled = b
            btnSua.Enabled = b
        End Sub
        Private Sub addJavaScript()
            'txtSoCMND.Attributes.Add("onblur", "javascript:CheckCMND(" & txtSoCMND.ClientID & ");")

            txtNgayCapCMND.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapCMND);")
            txtNgayCapCMND.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapCMND.ClientID & ");")
            txtNgayCapCMND.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtNgaySinh.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgaySinh);")
            txtNgaySinh.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgaySinh.ClientID & ");")
            txtNgaySinh.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            btnThem.Attributes.Add("onclick", "return KiemTraNhapLieu()")
            btnSua.Attributes.Add("onclick", "return KiemTraNhapLieu()")
        End Sub
        Private Sub bindData()
            Dim strGiayCNDKKDHTXID As String = CStr(Request.Params("ID"))
            Dim objHopTacXaCon As New HopTacXaController
            Dim dsThanhVien As DataSet
            dsThanhVien = objHopTacXaCon.getThanhVienHTX(strGiayCNDKKDHTXID)


            Dim dtThongTinXaVien As DataTable
            dtThongTinXaVien = makeDataTable()
            Dim drXaVien As DataRow

            Dim i As Integer
            For i = 0 To dsThanhVien.Tables(0).Rows.Count - 1
                drXaVien = dtThongTinXaVien.NewRow()
                drXaVien.Item("HoTen") = getItemValueFromTable(dsThanhVien.Tables(0), i, "HoTen")
                drXaVien.Item("GioiTinh") = getItemValueFromTable(dsThanhVien.Tables(0), i, "GioiTinh")
                drXaVien.Item("NgaySinh") = getItemValueFromTable(dsThanhVien.Tables(0), i, "NgaySinh")
                drXaVien.Item("DanToc") = getItemValueFromTable(dsThanhVien.Tables(0), i, "DanToc")
                drXaVien.Item("SoCMND") = getItemValueFromTable(dsThanhVien.Tables(0), i, "SoCMND")
                drXaVien.Item("NgayCapCMND") = getItemValueFromTable(dsThanhVien.Tables(0), i, "NgayCapCMND")
                drXaVien.Item("NoiCapCMND") = getItemValueFromTable(dsThanhVien.Tables(0), i, "NoiCapCMND")
                drXaVien.Item("DiaChiThuongTru") = getItemValueFromTable(dsThanhVien.Tables(0), i, "DiaChiThuongTru")
                drXaVien.Item("ChoOHienNay") = getItemValueFromTable(dsThanhVien.Tables(0), i, "ChoOHienNay")
                dtThongTinXaVien.Rows.Add(drXaVien)
                dtThongTinXaVien.AcceptChanges()
            Next
            ViewState.Item("ThongTinXaVien") = dtThongTinXaVien
        End Sub

        Private Sub bindGrid()
            Dim dtThongTinXaVien As New DataTable
            If Not ViewState.Item("ThongTinXaVien") Is Nothing Then
                dtThongTinXaVien = CType(ViewState.Item("ThongTinXaVien"), DataTable)
            Else
                dtThongTinXaVien = makeDataTable()
            End If
            dgdDanhSach.DataSource = dtThongTinXaVien
            dgdDanhSach.DataBind()
            AddFunctionOnClick()
        End Sub

        Private Sub btnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua.Click
            If Not updDataTable(False) Then
                Return
            End If
            bindGrid()
            btnThem.Visible = True
            btnSua.Visible = False
            clearControl()
        End Sub
        Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
            If Not (updDataTable(True)) Then
                Return
            End If
            bindGrid()
            clearControl()
        End Sub
        Private Sub clearControl()
            txtHoTen.Text = ""
            ddlGioiTinh.SelectedValue = "1"
            txtNgaySinh.Text = ""
            txtDanToc.Text = ""
            txtSoCMND.Text = ""
            txtNgayCapCMND.Text = ""
            txtNoiCapCMND.Text = ""
            txtDiaChiThuongTru.Text = ""
            txtChoOHienNay.Text = ""
        End Sub
        Private Function updDataTable(ByVal isThemMoi As Boolean) As Boolean
            If ViewState.Item("ThongTinXaVien") Is Nothing Then
                ViewState.Item("ThongTinXaVien") = makeDataTable()
            End If
            '
            Dim dtThongTinXaVien As New DataTable
            dtThongTinXaVien = CType(ViewState.Item("ThongTinXaVien"), DataTable)
            '
            Dim objXaVien As New XaVienInfo
            objXaVien.HoTen = txtHoTen.Text.Replace("'", "''")
            objXaVien.GioiTinh = ddlGioiTinh.SelectedValue
            objXaVien.NgaySinh = txtNgaySinh.Text.Replace("'", "''")
            objXaVien.DanToc = txtDanToc.Text.Replace("'", "''")
            objXaVien.SoCMND = txtSoCMND.Text.Replace("'", "''")
            objXaVien.NgayCapCMND = txtNgayCapCMND.Text.Replace("'", "''")
            objXaVien.NoiCapCMND = txtNoiCapCMND.Text.Replace("'", "''")
            objXaVien.DiaChiThuongTru = txtDiaChiThuongTru.Text.Replace("'", "''")
            objXaVien.ChoOHienNay = txtChoOHienNay.Text.Replace("'", "''")

            Dim i As Integer
            If isThemMoi Then 'Them moi
                For i = 0 To dtThongTinXaVien.Rows.Count - 1
                    If CStr(dtThongTinXaVien.Rows(i).Item("SoCMND")) = objXaVien.SoCMND Then
                        SetMSGBOX_HIDDEN(Page, "So CMND da ton tai")
                        Return False
                    End If
                Next
            Else 'Update
                For i = 0 To dtThongTinXaVien.Rows.Count - 1
                    If CStr(dtThongTinXaVien.Rows(i).Item("SoCMND")) = CStr(viewstate.Item("SoCMND")) Then
                        Dim j As Integer
                        For j = 0 To dtThongTinXaVien.Rows.Count - 1
                            If (CStr(dtThongTinXaVien.Rows(j).Item("SoCMND")) = objXaVien.SoCMND) And (objXaVien.SoCMND <> CStr(viewstate.Item("SoCMND"))) Then
                                SetMSGBOX_HIDDEN(Page, "So CMND da ton tai")
                                Return False
                            End If
                        Next
                        'Xoa DI
                        dtThongTinXaVien.Rows(i).Delete()
                        dtThongTinXaVien.AcceptChanges()
                        ViewState.Item("SoCMND") = objXaVien.SoCMND
                        Exit For
                    End If
                Next
            End If

            'Them vao
            Dim drXaVien As DataRow
            drXaVien = dtThongTinXaVien.NewRow()
            drXaVien.Item("HoTen") = objXaVien.HoTen
            drXaVien.Item("GioiTinh") = objXaVien.GioiTinh
            drXaVien.Item("NgaySinh") = objXaVien.NgaySinh
            drXaVien.Item("DanToc") = objXaVien.DanToc
            drXaVien.Item("SoCMND") = objXaVien.SoCMND
            drXaVien.Item("NgayCapCMND") = objXaVien.NgayCapCMND
            drXaVien.Item("NoiCapCMND") = objXaVien.NoiCapCMND
            drXaVien.Item("DiaChiThuongTru") = objXaVien.DiaChiThuongTru
            drXaVien.Item("ChoOHienNay") = objXaVien.ChoOHienNay
            dtThongTinXaVien.Rows.Add(drXaVien)
            dtThongTinXaVien.AcceptChanges()
            ViewState.Item("ThongTinXaVien") = dtThongTinXaVien
            Return True
        End Function
        Private Sub CreateColumn(ByVal name As String, ByVal namesTable As DataTable)
            Dim idColumn As New DataColumn
            idColumn.ColumnName = name
            namesTable.Columns.Add(idColumn)
        End Sub
        Private Function makeDataTable() As DataTable
            Dim dt As DataTable = New DataTable
            CreateColumn("HoTen", dt)
            CreateColumn("GioiTinh", dt)
            CreateColumn("NgaySinh", dt)
            CreateColumn("DanToc", dt)
            CreateColumn("SoCMND", dt)
            CreateColumn("NgayCapCMND", dt)
            CreateColumn("NoiCapCMND", dt)
            CreateColumn("DiaChiThuongTru", dt)
            CreateColumn("ChoOHienNay", dt)
            Return dt
        End Function
        Sub AddFunctionOnClick()
            Dim btn As System.Web.UI.WebControls.ImageButton
            Dim i As Integer
            For i = 0 To Me.dgdDanhSach.Items.Count - 1
                btn = CType(Me.dgdDanhSach.Items.Item(i).FindControl("imgXoa"), System.Web.UI.WebControls.ImageButton)
                btn.Attributes.Add("OnClick", "return confirm('Ban co chac la muon xoa thanh vien nay ?');")
            Next
        End Sub
        Private Sub dgdDanhSach_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdDanhSach.ItemCommand
            Dim dtThongTinXaVien As New DataTable
            dtThongTinXaVien = CType(ViewState.Item("ThongTinXaVien"), DataTable)
            Dim i As Integer = e.Item.ItemIndex
            Select Case e.CommandName
                Case "Xoa"
                    dtThongTinXaVien.Rows(i).Delete()
                    dtThongTinXaVien.AcceptChanges()
                    ViewState.Item("ThongTinXaVien") = dtThongTinXaVien
                    bindGrid()
                    btnThem.Visible = True
                    btnSua.Visible = False
                Case "Sua"
                    txtHoTen.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "HoTen")
                    ddlGioiTinh.SelectedValue = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "GioiTinh")
                    txtNgaySinh.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "NgaySinh")
                    txtDanToc.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "DanToc")
                    txtSoCMND.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "SoCMND")
                    txtNgayCapCMND.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "NgayCapCMND")
                    txtNoiCapCMND.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "NoiCapCMND")
                    txtDiaChiThuongTru.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "DiaChiThuongTru")
                    txtChoOHienNay.Text = getItemValueFromTable(dtThongTinXaVien, e.Item.ItemIndex, "ChoOHienNay")
                    btnSua.Visible = True
                    btnThem.Visible = False
                    ViewState.Item("SoCMND") = txtSoCMND.Text
            End Select
        End Sub
        Private Function getItemValueFromTable(ByVal dt As DataTable, ByVal rowNo As Integer, ByVal field As String) As String
            If (Not IsDBNull(dt.Rows(rowNo).Item(field))) Then
                Return Replace(CStr(dt.Rows(rowNo).Item(field)), "''", "'")
            Else
                Return ""
            End If
        End Function
        Public Function getDTThongTinXaVien() As DataTable
            If ViewState.Item("ThongTinXaVien") Is Nothing Then
                Return Nothing
            End If
            Return CType(ViewState.Item("ThongTinXaVien"), DataTable)
        End Function
    End Class
End Namespace

