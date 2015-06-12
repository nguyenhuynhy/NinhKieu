
Imports PortalQH
Namespace CPXD
    Public Class NXHS_HangMucXDTruoc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnHuongdan2 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Imagebutton1 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents txtHangMucTruoc As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents txtGP_GhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDienTichSanXayDung As System.Web.UI.WebControls.Label
        Protected WithEvents txtDienTichSanXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents txtGP_KyHieuThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_DonViThietKe As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_QuyMo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_KetCau As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_ChieuCaoTungTang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_ChieuCaoToanCongTrinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_DienTichXayDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGP_DienTichSan As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdNoiDungHangMuc As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblTongChieuCao As System.Web.UI.WebControls.Label
        Protected WithEvents LnkQuyMo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents LnkKetCau As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        'Dinh nghia vi tri cac field trong dataview
        Private Const COL_MAHANGMUC As Integer = 2
        Private Const COL_HANGMUC As Integer = 3
        Private Const COL_NOIDUNG As Integer = 4
        Private Const COL_DIENTICH As Integer = 5
        Private Const COL_CHIEUCAO As Integer = 6
        Private Const COL_GIUNGUYEN As Integer = 7
        Private Const COL_HANGMUCXAYDUNGID As Integer = 0
        Private Const COL_NHANXETHOSOID As Integer = 1
        Private dvNoiDungHangMuc As DataView
        'Bien khai bao ho tro tinh cong thuc cua doan code chuyen tu VB6.0 Sang
        Dim arr_DaySo(900) As String
        Dim arr_Temp(200) As String
        Dim SoHang As Integer
        Dim mSoPhanTu As Integer
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not IsPostBack() Then
                Init_State()
            End If
        End Sub
        Public Sub Init_State()
            Dim strURL As String
            'txtGP_DienTichXayDung.Attributes.Add("onblur", "javascript:TinhDienTichSan(" & txtGP_DienTichSan.ClientID & "," & txtGP_DienTichXayDung.ClientID & ");")
            txtGP_DienTichXayDung.Attributes.Add("onblur", "javascript:TinhDienTichSan();")
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMKETCAU&TextName=" & txtGP_KetCau.ClientID
            LnkKetCau.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            strURL = "CPXD/DesktopModules/DanhMuc_Chon.aspx?DanhMuc=DMQUYMO&TextName=" & txtGP_QuyMo.ClientID
            LnkQuyMo.Attributes.Add("onclick", "javascript:DanhMucChon('" & strURL & "','Application');")
            txtGP_DienTichXayDung.Attributes.Add("onblur", "javascript:CheckData(" & txtGP_DienTichXayDung.ClientID & ");")
            txtGP_DienTichSan.Attributes.Add("onblur", "javascript:CheckData(" & txtGP_DienTichSan.ClientID & ");")
            txtGP_ChieuCaoToanCongTrinh.Attributes.Add("onblur", "javascript:CheckData(" & txtGP_ChieuCaoToanCongTrinh.ClientID & ");") 
        End Sub
        'Ham CreateDataSource dung de gan tren dgdHangMucXayDung
        Public Sub CreateDataSource(ByVal strNhanXetHoSoId As String)
            Dim dr As DataRow
            Dim ds As DataSet
            Dim NoiDungHangMuc As New NXHS_HangMucXDTruocController
            ds = NoiDungHangMuc.ListHangMucXayDung(strNhanXetHoSoId)
            Dim i As Integer
            Dim arrHangMuc As New ArrayList
            For i = 0 To ds.Tables(0).Rows.Count - 1
                arrHangMuc.Add(New HangMuc(i, ds.Tables(0).Rows(i)(COL_NHANXETHOSOID).ToString, ds.Tables(0).Rows(i)(COL_HANGMUCXAYDUNGID).ToString, ds.Tables(0).Rows(i)(COL_MAHANGMUC).ToString, ds.Tables(0).Rows(i)(COL_HANGMUC).ToString, ds.Tables(0).Rows(i)(COL_NOIDUNG).ToString, CType(ds.Tables(0).Rows(i)(COL_DIENTICH), Double), CType(ds.Tables(0).Rows(i)(COL_CHIEUCAO), Double), ds.Tables(0).Rows(i)(COL_GIUNGUYEN).ToString, CPXD.RowState.UNCHANGED))
            Next
            ViewState("HangMuc") = arrHangMuc
            '  BindGrid()
            dvNoiDungHangMuc = New DataView(ds.Tables(0))
            BindGrid()

        End Sub
        Private Sub BindGrid()
            Dim dt As New DataTable
            Dim col As DataColumn
            Dim row As DataRow
            col = New DataColumn("NhanXetHoSoID", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("HangMucXayDungID", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("MaHangMuc", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("TenHangMuc", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("NoiDung", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("DienTich", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("ChieuCao", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("GiuNguyen", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("Key", Type.GetType("System.Int16"))
            dt.Columns.Add(col)
            Dim arrHangMuc As ArrayList = CType(ViewState("HangMuc"), ArrayList)
            Dim Tong As Double
            Dim TongChieuCao As Double
            Dim str As String
            Dim strDienTichXayDung As String
            Dim j As Integer
            j = 0
            While j < arrHangMuc.Count
                If CType(arrHangMuc(j), HangMuc).State = RowState.DELETED Then
                    j = j + 1
                Else
                    strDienTichXayDung = CType(CType(arrHangMuc(j), HangMuc).DienTich, String)
                    Exit While
                End If
            End While

            For i As Integer = 0 To arrHangMuc.Count - 1
                If CType(arrHangMuc(i), HangMuc).State <> CPXD.RowState.DELETED Then
                    'chi load ~ record chua bi  danh dau xoa
                    row = dt.NewRow()
                    row(COL_HANGMUCXAYDUNGID) = CType(arrHangMuc(i), HangMuc).HangMucXayDungID
                    row(COL_NHANXETHOSOID) = CType(arrHangMuc(i), HangMuc).NhanXetHoSoID
                    row(COL_MAHANGMUC) = CType(arrHangMuc(i), HangMuc).MaHangMuc
                    row(COL_HANGMUC) = CType(arrHangMuc(i), HangMuc).TenHangMuc
                    row(COL_NOIDUNG) = CType(arrHangMuc(i), HangMuc).NoiDung
                    row(COL_DIENTICH) = FormatNumber(CType(arrHangMuc(i), HangMuc).DienTich, 2, , TriState.True)
                    row(COL_CHIEUCAO) = CType(arrHangMuc(i), HangMuc).ChieuCao
                    If CType(arrHangMuc(i), HangMuc).GiuNguyen <> "" Then
                        row(COL_GIUNGUYEN) = CType(arrHangMuc(i), HangMuc).GiuNguyen
                    Else
                        row(COL_GIUNGUYEN) = "False"
                    End If
                    row("Key") = CType(arrHangMuc(i), HangMuc).Key
                    dt.Rows.Add(row)
                    If (CType(arrHangMuc(i), HangMuc).GiuNguyen <> "True") Then
                        Tong = Tong + CType(arrHangMuc(i), HangMuc).DienTich
                    End If
                    If (CType(arrHangMuc(i), HangMuc).ChieuCao > 0) And (CType(arrHangMuc(i), HangMuc).GiuNguyen <> "True") Then

                        TongChieuCao = TongChieuCao + CType(arrHangMuc(i), HangMuc).ChieuCao
                        str = str & CType(arrHangMuc(i), HangMuc).TenHangMuc & ": " & CType(arrHangMuc(i), HangMuc).ChieuCao & " m;"
                    End If
                End If
            Next
            dvNoiDungHangMuc = New DataView(dt)
            dvNoiDungHangMuc.Sort = CStr(ViewState("SortField"))
            dgdNoiDungHangMuc.DataSource = dvNoiDungHangMuc
            lblDienTichSanXayDung.Text = CType(Tong, String)
            lblTongChieuCao.Text = CType(TongChieuCao, String)
            If str <> "" Or Len(str) > 2 Then txtGP_ChieuCaoTungTang.Text = Left(str, Len(str) - 1)
            txtGP_ChieuCaoToanCongTrinh.Text = FormatNumber(lblTongChieuCao.Text, 2, , , TriState.True)
            txtGP_DienTichXayDung.Text = FormatNumber(strDienTichXayDung, 2, , , TriState.True)
            dgdNoiDungHangMuc.DataKeyField = "Key"
            dgdNoiDungHangMuc.DataBind()
        End Sub
        'Doan code xu ly cap nhat, them moi, xoa tren luoi
        Private Sub updNoiDungHangMucByKey(ByVal Key As Integer, ByVal MaHangMuc As String, ByVal TenHangMuc As String, ByVal NoiDung As String, ByVal DienTich As Double, ByVal ChieuCao As Double, ByVal GiuNguyen As String)
            Dim arrHangMuc As ArrayList = CType(ViewState("HangMuc"), ArrayList)
            For i As Integer = 0 To arrHangMuc.Count - 1
                If CType(arrHangMuc(i), HangMuc).Key = Key Then
                    CType(arrHangMuc(i), HangMuc).MaHangMuc = MaHangMuc
                    CType(arrHangMuc(i), HangMuc).TenHangMuc = TenHangMuc
                    CType(arrHangMuc(i), HangMuc).NoiDung = NoiDung
                    CType(arrHangMuc(i), HangMuc).DienTich = DienTich
                    CType(arrHangMuc(i), HangMuc).ChieuCao = ChieuCao
                    CType(arrHangMuc(i), HangMuc).GiuNguyen = GiuNguyen
                    If CStr(ViewState("WorkState")).Equals("EDITNOIDUNG") Then
                        If CType(arrHangMuc(i), HangMuc).State <> CPXD.RowState.ADDED Then
                            CType(arrHangMuc(i), HangMuc).State = CPXD.RowState.MODIFIED
                        End If
                    Else
                        CType(arrHangMuc(i), HangMuc).State = CPXD.RowState.ADDED
                    End If
                    Exit For
                End If
            Next
        End Sub
        Private Function getHangMucByKey(ByVal Key As Integer) As HangMuc
            Dim arrHangMuc As ArrayList = CType(ViewState("HangMuc"), ArrayList)
            For i As Integer = 0 To arrHangMuc.Count - 1
                If CType(arrHangMuc(i), HangMuc).Key = Key Then
                    Return CType(arrHangMuc(i), HangMuc)
                End If
            Next
            Return Nothing
        End Function
        Private Sub delHangMucByKey(ByVal Key As Integer)
            Dim arrHangMuc As ArrayList = CType(ViewState("HangMuc"), ArrayList)
            For i As Integer = 0 To arrHangMuc.Count - 1
                If CType(arrHangMuc(i), HangMuc).Key = Key Then
                    If CType(arrHangMuc(i), HangMuc).MaHangMuc.Length <= 0 Then
                        'cac record moi add ko co MaChuDauTu -> delete luon
                        arrHangMuc.RemoveAt(i)
                        Exit For
                    Else 'danh dau xoa
                        CType(arrHangMuc(i), HangMuc).State = CPXD.RowState.DELETED
                    End If
                End If
            Next
        End Sub
        Public Sub AddNewRow(ByVal sender As Object, ByVal e As EventArgs)
            'Add a blank row
            Dim curRow As Integer = dgdNoiDungHangMuc.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdNoiDungHangMuc.DataKeys.Item(curRow))
                Try                    
                    updNoiDungHangMucByKey(curKey, CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text, _
                        CalString(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text), _
                        CType(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtChieuCao"), TextBox).Text, Double), _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Checked.ToString)
                    CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Enabled = False
                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Me.Page, "Du lieu nhap khong hop le")
                    Exit Sub
                End Try
            End If
            'Add a blank row
            Dim lastRec As Integer = CType(ViewState("HangMuc"), ArrayList).Count - 1
            If lastRec > -1 Then
                curKey = CType(CType(ViewState("HangMuc"), ArrayList)(lastRec), HangMuc).Key + 1
            Else
                curKey = 0
            End If

            CType(ViewState("HangMuc"), ArrayList).Add(New HangMuc(curKey))

            ' Index of the new item in the page: last +1
            Dim nNewItemIndex As Integer = dgdNoiDungHangMuc.Items.Count
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (nNewItemIndex >= dgdNoiDungHangMuc.PageSize) Then
                dgdNoiDungHangMuc.CurrentPageIndex += 1
                nNewItemIndex = 0
            End If

            ' Turn edit mode on for the newly added row
            dgdNoiDungHangMuc.EditItemIndex = nNewItemIndex

            ' Refresh the grid
            BindGrid()

            ViewState("WorkState") = "ADDNEWHANGMUC"
        End Sub
        Protected Function IsLastPage() As Boolean
            ' CurrentPageIndex is 0-based...
            If dgdNoiDungHangMuc.CurrentPageIndex + 1 = dgdNoiDungHangMuc.PageCount Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function GetDanhMuc(ByVal strTable As String) As ArrayList
            Return GetDanhMucList(strTable)
        End Function
        Public Function GetSelected(ByVal strDM As String, ByVal strMa As String) As Integer
            Return GetSelectedIndex(strDM, strMa)
        End Function
        Protected Sub dgdNoiDungHangMuc_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Me.dgdNoiDungHangMuc.EditItemIndex = CType(e.Item.ItemIndex, Int32)
            CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Enabled = True
            Me.BindGrid()
            ViewState("WorkState") = "EDITNOIDUNG"
        End Sub
        Protected Sub dgdNoiDungHangMuc_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            'update dong dang sua
            Dim curRow As Integer = dgdNoiDungHangMuc.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdNoiDungHangMuc.DataKeys.Item(curRow))
                Try
                    
                    updNoiDungHangMucByKey(curKey, CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text, _
                        CalString(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text), _
                        CType(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtChieuCao"), TextBox).Text, Double), _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Checked.ToString)
                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Me.Page, "Du lieu nhap khong hop le")
                    Exit Sub
                End Try
            End If

            Dim key As Integer = CInt(dgdNoiDungHangMuc.DataKeys.Item(e.Item.ItemIndex))
            delHangMucByKey(key)
            If Not ViewState("WorkState") Is Nothing Then
                ViewState.Remove("WorkState")
            End If
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdNoiDungHangMuc.Items.Count = 1 And dgdNoiDungHangMuc.PageCount > 1 And dgdNoiDungHangMuc.CurrentPageIndex = dgdNoiDungHangMuc.PageCount - 1 Then
                dgdNoiDungHangMuc.CurrentPageIndex -= 1
            End If
            dgdNoiDungHangMuc.EditItemIndex = -1
            BindGrid()
        End Sub
        Protected Sub dgdNoiDungHangMuc_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
            Dim curRow As Integer = dgdNoiDungHangMuc.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdNoiDungHangMuc.DataKeys.Item(curRow))
                Try
                    
                    updNoiDungHangMucByKey(curKey, CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text, _
                        CalString(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text), _
                        CType(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtChieuCao"), TextBox).Text, Double), _
                        CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Checked.ToString)
                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    SetMSGBOX_HIDDEN(Me.Page, "Du lieu nhap khong hop le")
                    Exit Sub
                End Try
            End If
            dgdNoiDungHangMuc.EditItemIndex = -1
            dgdNoiDungHangMuc.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub
        Protected Sub dgdNoiDungHangMuc_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
            dvNoiDungHangMuc.Sort = e.SortExpression.ToString()
            dgdNoiDungHangMuc.DataSource = dvNoiDungHangMuc
            dgdNoiDungHangMuc.DataBind()
        End Sub
        Public Sub dgdNoiDungHangMuc_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Dim str As String
            Dim state As RowState
            Dim curKey As Integer = CInt(dgdNoiDungHangMuc.DataKeys.Item(e.Item.ItemIndex))
            Try

                    
                updNoiDungHangMucByKey(curKey, CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                    CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("ddlHangMuc"), TextBox).Text, _
                    CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text, _
                    CalString(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtNoiDung"), TextBox).Text), _
                    CType(CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("txtChieuCao"), TextBox).Text, Double), _
                    CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Checked.ToString)
                CType(dgdNoiDungHangMuc.Items(dgdNoiDungHangMuc.EditItemIndex).FindControl("chkGiuNguyen"), CheckBox).Enabled = False
                ViewState.Remove("WorkState")
                ViewState("Status") = "False"
            Catch ex As Exception
                SetMSGBOX_HIDDEN(Me.Page, "Du lieu nhap khong hop le")
                Exit Sub
            End Try
            'TinhTongDienTich()
            dgdNoiDungHangMuc.EditItemIndex = -1
            BindGrid()
        End Sub

        Private Sub dgdNoiDungHangMuc_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        End Sub
        Public Sub Save_HangMucXayDung(ByVal strHoSoNhanXetID As String)
            Dim objHangMucXayDung As New NXHS_HangMucXDTruocController
            Dim objHangMucXayDungInfo As New NXHS_HangMucXDTruocInfo
            objHangMucXayDung.DelHangMucXayDung(strHoSoNhanXetID)
            For i As Integer = 0 To CType(ViewState("HangMuc"), ArrayList).Count - 1
                Dim objHangMuc As HangMuc = CType(CType(ViewState("HangMuc"), ArrayList)(i), HangMuc)
                If objHangMuc.State <> RowState.DELETED Then
                    objHangMucXayDungInfo.NhanXetHoSoID = strHoSoNhanXetID
                    objHangMucXayDungInfo.MaHangMuc = objHangMuc.MaHangMuc
                    objHangMucXayDungInfo.NoiDung = objHangMuc.NoiDung
                    objHangMucXayDungInfo.DienTich = objHangMuc.DienTich
                    objHangMucXayDungInfo.ChieuCao = objHangMuc.ChieuCao
                    objHangMucXayDungInfo.GiuNguyen = objHangMuc.GiuNguyen
                    If objHangMucXayDungInfo.MaHangMuc <> "" Then objHangMucXayDung.AddHangMucXayDung(objHangMucXayDungInfo)
                End If
            Next
        End Sub
        'Ham nay ghi lai noi dung day du cua Hang muc xay dung truoc'
        Public Function GhiLaiHangMucTruoc() As String
            Dim str As String
            txtDienTichSanXayDung.Text = lblDienTichSanXayDung.Text
            For i As Integer = 0 To CType(ViewState("HangMuc"), ArrayList).Count - 1
                Dim objHangMuc As HangMuc = CType(CType(ViewState("HangMuc"), ArrayList)(i), HangMuc)
                If objHangMuc.TenHangMuc <> "" And objHangMuc.DienTich > 0 Then
                    str = str & vbTab & "+"
                    str = str & Trim(objHangMuc.TenHangMuc) & ": "
                    str = str & Trim(objHangMuc.NoiDung) & vbTab & " = "
                    str = str & Trim(CType(objHangMuc.DienTich, String)) & " m2" & vbCrLf
                End If
            Next
            str = str & Label1.Text & vbTab & lblDienTichSanXayDung.Text & " m2"
            Return str
        End Function
        Public Function SetStatus(ByVal values As Integer) As String
            Dim str As String
            If values = dgdNoiDungHangMuc.CurrentPageIndex * dgdNoiDungHangMuc.PageSize + dgdNoiDungHangMuc.EditItemIndex + 1 Then
                Return "True"
            Else
                Return "False"
            End If
        End Function

        '//////////////////////////////////////////////////////////////////////////
        '/////Doan code tinh toan cong thuc, chuyen tu VB6.0 qua                ///
        '//////////////////////////////////////////////////////////////////////////
        Public Function CalString(ByVal strSource As String) As Double
            Dim i As Integer
            Dim strlen As Integer
            'Chuoi tam de lay so
            Dim StrTemp As String

            strlen = Len(strSource)
            strSource = Trim(Replace(strSource, " ", ""))
            'Xu ly cac ky hieu cho chuoi
            strSource = Trim(Replace(strSource, "x", "*"))
            strSource = Trim(Replace(strSource, ":", "/"))
            strSource = Trim(Replace(strSource, ",", "."))
            'strSource = Trim(Replace(strSource, ".", ","))
            strSource = Trim(Replace(strSource, "X", "*"))
            mSoPhanTu = 0
            Call DelDaySo()
            For i = 1 To strlen
                StrTemp = Mid(strSource, i, 1)
                Select Case StrTemp
                    'Case ",", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                Case ".", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                        arr_DaySo(SoHang) = arr_DaySo(SoHang) & StrTemp
                    Case "+", "-", "*", "/"
                        'Ket thuc so truoc
                        SoHang = SoHang + 1
                        arr_DaySo(SoHang) = arr_DaySo(SoHang) & StrTemp
                        'bat dau so sau
                        SoHang = SoHang + 1
                    Case "("
                        'dung lien ke dau truoc
                        arr_DaySo(SoHang) = arr_DaySo(SoHang) & StrTemp
                        'bat dau so sau
                        SoHang = SoHang + 1
                    Case ")"
                        'dung lien ke so truoc
                        SoHang = SoHang + 1

                        arr_DaySo(SoHang) = arr_DaySo(SoHang) & StrTemp

                End Select

            Next
            SoHang = SoHang + 1
            'Toi doan nay la da lay duoc cac so vao mang
            'Kiem tra tinh hop le cua bieu thuc

            'Tinh phan bieu thuc trong ngoac truoc
            Call TinhNgoac(arr_DaySo)
            'Tinh phan con lai
            CalString = CongTruNhanChia(arr_DaySo, mSoPhanTu)
        End Function
        Public Function CongTruNhanChia(ByVal MangSo() As String, ByVal m_SoPhanTu As Integer) As Double
            Dim i As Integer
            Dim N As Integer
            'Cho biet tinh va thay the hay tinh don lai
            Dim hoanvi As Boolean
            'Cho biet khong con phep nhan hay chia nao trong chuoi, san sang tinh cong va tru
            Dim hetphepnhan As Boolean
            Dim j As Integer
            'Ket qua phep tinh
            Dim ketqua As Double
            Dim DayTam(200) As String
            'Biet cho biet con phep nhan/chia trong bieu thuc hay khong
            hetphepnhan = False
            j = 0
            For i = 1 To mSoPhanTu - 1
                'Tinh phep nhan va phep chia truoc
                If (MangSo(i) = "*") Or (MangSo(i) = "/") Then
                    hoanvi = False
                    N = i
                    Do While MangSo(N) = "*" Or MangSo(N) = "/"
                        If MangSo(N) = "*" Then
                            If Not hoanvi Then
                                ketqua = CType(MangSo(N - 1), Double) * CType(MangSo(N + 1), Double)
                                hoanvi = True
                            Else
                                ketqua = ketqua * CType(MangSo(N + 1), Double)
                            End If
                        ElseIf (MangSo(N) = "/") Then
                            If Not hoanvi Then
                                ketqua = CType(MangSo(N - 1), Double) / CType(MangSo(N + 1), Double)
                                hoanvi = True
                            Else
                                ketqua = ketqua / CType(MangSo(N + 1), Double)
                            End If

                        End If
                        N = N + 2
                    Loop
                    DayTam(j) = CType(ketqua, String)
                    j = j + 1
                    If N < mSoPhanTu Then
                        i = N
                        DayTam(j) = MangSo(i)
                        j = j + 1
                    Else
                        hetphepnhan = True
                        Exit For
                    End If

                Else 'if dau tien
                    DayTam(j) = MangSo(i - 1)
                    j = j + 1
                    DayTam(j) = MangSo(i)
                    j = j + 1
                End If
                i = i + 1
            Next
            If Not hetphepnhan Then
                DayTam(j) = MangSo(mSoPhanTu - 1)
                j = j + 1
            End If

            'Tinh cong va tru
            ketqua = CType(DayTam(0), Double)
            For i = 1 To j - 1
                If (DayTam(i) = "+") Then
                    ketqua = ketqua + CType(DayTam(i + 1), Double)
                ElseIf DayTam(i) = "-" Then
                    ketqua = ketqua - CType(DayTam(i + 1), Double)
                End If
                i = i + 1
            Next
            CongTruNhanChia = ketqua
        End Function
        Public Function TinhNgoac(ByVal MangSo() As String) As Double

            Dim i, j As Integer
            Dim so, dem, X As Integer
            Dim vitri(100) As Integer
            'Mang tam
            Dim MangChua(200) As String
            Dim count As Integer
            Dim ketqua As Double
            'khoi tao cac gia tri mac dinh
            i = 0
            mSoPhanTu = SoHang
            'Dem va tim vi tri cac dau mo ngoac
            For dem = 0 To mSoPhanTu
                If MangSo(dem) = "(" Then
                    vitri(i) = dem
                    i = i + 1
                End If
            Next
            'Gia tri hien tai cua i bay gio la vi tri cua dau mo ngoac trong nhat
            'Vd: <12+(12+(12+1)+5)+1> thi i=5 tinh tu 0
            Do While i > 0
                j = 0
                X = vitri(i - 1) + 1
                For count = 0 To 200
                    MangChua(count) = ""
                Next
                'Lay phan bieu thuc trong ngoac
                Do While MangSo(X) <> ")"
                    MangChua(j) = MangSo(X)
                    j = j + 1
                    X = X + 1
                Loop
                'Tinh gia tri bieu thuc trong ngoac
                ketqua = CongTruNhanChia(MangChua, j)
                'Don bieu thuc, phan trong ngoac thay the bang gia tri tinh duoc
                'Chep lai tu dau den truoc mo ngoac
                For so = 0 To (vitri(i - 1) - 1)
                    arr_Temp(so) = MangSo(so)
                Next
                arr_Temp(vitri(i - 1)) = CType(ketqua, String)
                'Chep tu sau dong ngoac toi cuoi

                For X = X + 1 To mSoPhanTu
                    so = so + 1
                    arr_Temp(so) = MangSo(X)
                Next
                'Cap nhat lai so phan tu
                mSoPhanTu = so
                'Cap nhat mangso moi
                For so = 0 To mSoPhanTu
                    MangSo(so) = arr_Temp(so)
                Next
                'Giam so ngoac
                i = i - 1
            Loop
            TinhNgoac = ketqua
        End Function
        'Reset lai tinh trang cua Arr_DaySo
        Public Sub DelDaySo()
            Dim i As Integer
            For i = 0 To SoHang
                arr_DaySo(i) = ""
                SoHang = 0
            Next
        End Sub


        Public Sub dgdNoiDungHangMuc_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Dim key As Integer = CInt(dgdNoiDungHangMuc.DataKeys.Item(e.Item.ItemIndex))
            If CStr(ViewState("WorkState")) = "ADDNEWHANGMUC" Then
                delHangMucByKey(key)
            End If
            ViewState.Remove("WorkState")
            ' If the page is top, move to prev page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdNoiDungHangMuc.PageCount > 1 Then
                dgdNoiDungHangMuc.CurrentPageIndex -= 1
            End If
            Me.dgdNoiDungHangMuc.EditItemIndex = -1
            Me.BindGrid()
        End Sub


    End Class
    '/////////////////////////////////////////////////////////////////
    '/////Ket thuc doan code chuyen tu VB6.0 sang                  ///
    '//////////////////////////////////////////////////////////////////
    Public Enum RowState As Integer
        ADDED
        DELETED
        MODIFIED
        UNCHANGED
    End Enum
    <Serializable()> Public Class HangMuc
        Private _Key As Integer = 0
        Private _NhanXetHoSoID As String = ""
        Private _HangMucXayDungId As String = ""
        Private _MaHangMuc As String = ""
        Private _TenHangMuc As String = ""
        Private _NoiDung As String = ""
        Private _DienTich As Double = 0
        Private _ChieuCao As Double = 0
        Private _GiuNguyen As String
        Private _State As RowState = RowState.ADDED

        Public Sub New(ByVal Key As Integer)
            MyBase.New()
            _Key = Key
        End Sub
        Public Sub New(ByVal Key As Integer, ByVal strNhanXetHoSoID As String, ByVal strHangMucXayDungID As String, ByVal strMaHangMuc As String, ByVal strTenHangMuc As String, _
        ByVal strNoiDung As String, ByVal strDienTich As Double, ByVal ChieuCao As Double, ByVal GiuNguyen As String, ByVal State As RowState)
            MyBase.New()
            _Key = Key
            _NhanXetHoSoID = strNhanXetHoSoID
            _HangMucXayDungId = strHangMucXayDungID
            _MaHangMuc = strMaHangMuc
            _TenHangMuc = strTenHangMuc
            _NoiDung = strNoiDung
            _DienTich = strDienTich
            _ChieuCao = ChieuCao
            _GiuNguyen = GiuNguyen
            _State = RowState.UNCHANGED
        End Sub
        Public ReadOnly Property Key() As Integer
            Get
                Return _Key
            End Get
        End Property
        Public Property GiuNguyen() As String
            Get
                Return _GiuNguyen
            End Get
            Set(ByVal Value As String)
                _GiuNguyen = Value
            End Set
        End Property
        Public Property NhanXetHoSoID() As String
            Get
                Return _NhanXetHoSoID
            End Get
            Set(ByVal Value As String)
                _NhanXetHoSoID = Value
            End Set
        End Property
        Public Property HangMucXayDungID() As String
            Get
                Return _HangMucXayDungId
            End Get
            Set(ByVal Value As String)
                _HangMucXayDungId = Value
            End Set
        End Property
        Public Property MaHangMuc() As String
            Get
                Return _MaHangMuc
            End Get
            Set(ByVal Value As String)
                _MaHangMuc = Value
            End Set
        End Property
        Public Property TenHangMuc() As String
            Get
                Return _TenHangMuc
            End Get
            Set(ByVal Value As String)
                _TenHangMuc = Value
            End Set
        End Property
        Public Property NoiDung() As String
            Get
                Return _NoiDung
            End Get
            Set(ByVal Value As String)
                _NoiDung = Value
            End Set
        End Property
        Public Property DienTich() As Double
            Get
                Return _DienTich
            End Get
            Set(ByVal Value As Double)
                _DienTich = Value
            End Set
        End Property
        Public Property ChieuCao() As Double
            Get
                Return _ChieuCao
            End Get
            Set(ByVal Value As Double)
                _ChieuCao = Value
            End Set
        End Property
        Public Property State() As RowState
            Get
                Return _State
            End Get
            Set(ByVal Value As RowState)
                _State = Value
            End Set
        End Property
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

    End Class
End Namespace