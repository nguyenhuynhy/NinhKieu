Imports PortalQH
Imports System.Configuration
Namespace CPXD
    'NganTL
    'Created on 15/10/2004
    'Desc : Tiep nhan ho so va bo sung ho so
    'Updated on : 
    Public Class ChuDauTuList
        Inherits PortalQH.PortalModuleControl

        Private Const COL_MACHUDAUTU As Integer = 0
        Private Const COL_HOTEN As Integer = 1
        Private Const COL_NGAYSINH As Integer = 2
        Private Const COL_GIOITINH As Integer = 3
        Private Const COL_SOCMND As Integer = 4
        Private Const COL_NOICAPCMND As Integer = 5
        Private Const COL_NGAYCAPCMND As Integer = 6
        Private Const COL_DIACHI As Integer = 7
        Private Const COL_DIENTHOAI As Integer = 8
        Private Const COL_FAX As Integer = 9
        Private Const COL_EMAIL As Integer = 10
        Protected WithEvents dgdChuDautuList As System.Web.UI.WebControls.DataGrid
        Private dvChuDauTu As DataView

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
        End Sub

        Private Sub BindGrid()
            Dim dt As New DataTable
            Dim col As DataColumn
            Dim row As DataRow

            'create table's structure
            col = New DataColumn("MaChuDauTu", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("HoTen", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("NgaySinh", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("GioiTinh", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("SoCMND", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("NoiCapCMND", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("NgayCapCMND", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("DienThoai", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("Fax", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("Email", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("NoiDKTT", Type.GetType("System.String"))
            dt.Columns.Add(col)
            col = New DataColumn("Key", Type.GetType("System.Int16"))
            dt.Columns.Add(col)

            Dim arrChuDauTu As ArrayList = CType(ViewState("lstChuDauTu"), ArrayList)
            For i As Integer = 0 To arrChuDauTu.Count - 1
                If CType(arrChuDauTu(i), ChuDauTuInfor).State <> ChuDauTuState.DELETED Then
                    'chi load ~ record chua bi  danh dau xoa
                    row = dt.NewRow()
                    row("Key") = CType(arrChuDauTu(i), ChuDauTuInfor).Key
                    row("MaChuDauTu") = CType(arrChuDauTu(i), ChuDauTuInfor).MaChuDauTu
                    row("HoTen") = CType(arrChuDauTu(i), ChuDauTuInfor).HoTen
                    row("NgaySinh") = CType(arrChuDauTu(i), ChuDauTuInfor).NgaySinh
                    row("GioiTinh") = CType(arrChuDauTu(i), ChuDauTuInfor).GioiTinh
                    row("SoCMND") = CType(arrChuDauTu(i), ChuDauTuInfor).SoCMND
                    row("NoiCapCMND") = CType(arrChuDauTu(i), ChuDauTuInfor).NoiCapCMND
                    row("NgayCapCMND") = CType(arrChuDauTu(i), ChuDauTuInfor).NgayCapCMND
                    row("DienThoai") = CType(arrChuDauTu(i), ChuDauTuInfor).DienThoai
                    row("Fax") = CType(arrChuDauTu(i), ChuDauTuInfor).Fax
                    row("Email") = CType(arrChuDauTu(i), ChuDauTuInfor).Email
                    row("NoiDKTT") = CType(arrChuDauTu(i), ChuDauTuInfor).NoiDKTT
                    dt.Rows.Add(row)
                End If
            Next

            dvChuDauTu = New DataView(dt)
            dvChuDauTu.Sort = CStr(ViewState("SortField"))
            dgdChuDautuList.DataSource = dvChuDauTu
            dgdChuDautuList.DataKeyField = "Key"
            dgdChuDautuList.DataBind()
        End Sub

        'Xoa chu dau tu trong arraylist
        Public Sub delChuDauTuByKey(ByVal Key As Integer)
            Dim arrCDT As ArrayList = CType(ViewState("lstChuDauTu"), ArrayList)
            For i As Integer = 0 To arrCDT.Count - 1
                If CType(arrCDT(i), ChuDauTuInfor).Key = Key Then
                    If CType(arrCDT(i), ChuDauTuInfor).MaChuDauTu.Length <= 0 Then
                        'cac record moi add ko co MaChuDauTu -> delete luon
                        arrCDT.RemoveAt(i)
                        Exit For
                    Else 'danh dau xoa
                        CType(arrCDT(i), ChuDauTuInfor).State = ChuDauTuState.DELETED
                    End If
                End If
            Next
        End Sub

        'cap nhat chu dau tu
        Public Sub updChuDauTuByKey(ByVal Key As Integer, ByVal HoTen As String, ByVal NgaySinh As String, ByVal GioiTinh As String, ByVal SoCMND As String, ByVal NoiCapCMND As String, ByVal NgayCapCMND As String, ByVal DienThoai As String, ByVal Fax As String, ByVal Email As String, ByVal NoiDKTT As String)
            Dim arrCDT As ArrayList = CType(ViewState("lstChuDauTu"), ArrayList)
            For i As Integer = 0 To arrCDT.Count - 1
                If CType(arrCDT(i), ChuDauTuInfor).Key = Key Then
                    CType(arrCDT(i), ChuDauTuInfor).HoTen = HoTen
                    CType(arrCDT(i), ChuDauTuInfor).NgaySinh = NgaySinh
                    CType(arrCDT(i), ChuDauTuInfor).GioiTinh = GioiTinh
                    CType(arrCDT(i), ChuDauTuInfor).SoCMND = SoCMND
                    CType(arrCDT(i), ChuDauTuInfor).NoiCapCMND = NoiCapCMND
                    CType(arrCDT(i), ChuDauTuInfor).NgayCapCMND = NgayCapCMND
                    CType(arrCDT(i), ChuDauTuInfor).DienThoai = DienThoai
                    CType(arrCDT(i), ChuDauTuInfor).Fax = Fax
                    CType(arrCDT(i), ChuDauTuInfor).Email = Email
                    CType(arrCDT(i), ChuDauTuInfor).NoiDKTT = NoiDKTT
                    If CStr(ViewState("WorkState")).Equals("EDITCHUDAUTU") Then
                        If CType(arrCDT(i), ChuDauTuInfor).State <> ChuDauTuState.ADDED Then
                            CType(arrCDT(i), ChuDauTuInfor).State = ChuDauTuState.MODIFIED
                        End If
                    Else
                        CType(arrCDT(i), ChuDauTuInfor).State = ChuDauTuState.ADDED
                    End If
                    Exit For
                End If
            Next
        End Sub

        'Get chu dau tu trong arraylist
        Public Function getChuDauTuByKey(ByVal Key As Integer) As ChuDauTuInfor
            Dim arrCDT As ArrayList = CType(ViewState("lstChuDauTu"), ArrayList)
            For i As Integer = 0 To arrCDT.Count - 1
                If CType(arrCDT(i), ChuDauTuInfor).Key = Key Then
                    Return CType(arrCDT(i), ChuDauTuInfor)
                End If
            Next
            Return Nothing
        End Function

        Public Sub dgdChuDautuList_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdChuDautuList.EditCommand
            Me.dgdChuDautuList.EditItemIndex = CType(e.Item.ItemIndex, Int32)
            Me.BindGrid()
            ViewState("WorkState") = "EDITCHUDAUTU"

            setGridBtnAttr()
        End Sub

        Public Sub dgdChuDautuList_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdChuDautuList.CancelCommand
            Dim key As Integer = CInt(dgdChuDautuList.DataKeys.Item(e.Item.ItemIndex))
            If CStr(ViewState("WorkState")) = "ADDNEWCHUDAUTU" Then
                delChuDauTuByKey(key)
            End If

            ViewState.Remove("WorkState")

            ' If the page is top, move to prev page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdChuDautuList.PageCount > 1 Then
                dgdChuDautuList.CurrentPageIndex -= 1
            End If
            Me.dgdChuDautuList.EditItemIndex = -1
            Me.BindGrid()
        End Sub

        Public Sub dgdChuDautuList_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdChuDautuList.DeleteCommand
            'update dong dang sua
            Dim curRow As Integer = dgdChuDautuList.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                If Me.checkGridRequire() Then
                    curKey = CInt(dgdChuDautuList.DataKeys.Item(curRow))
                    updChuDauTuByKey(curKey, CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdHoTen"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgaySinh"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdGioiTinh"), DropDownList).SelectedValue, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdSoCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgayCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdDienThoai"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdFax"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdEmail"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiDKTT"), TextBox).Text)
                    ViewState.Remove("WorkState")
                End If
            End If

            Dim key As Integer = CInt(dgdChuDautuList.DataKeys.Item(e.Item.ItemIndex))
            delChuDauTuByKey(key)

            If Not ViewState("WorkState") Is Nothing Then
                ViewState.Remove("WorkState")
            End If
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdChuDautuList.Items.Count = 1 And dgdChuDautuList.PageCount > 1 And dgdChuDautuList.CurrentPageIndex = dgdChuDautuList.PageCount - 1 Then
                dgdChuDautuList.CurrentPageIndex -= 1
            End If
            dgdChuDautuList.EditItemIndex = -1
            BindGrid()
        End Sub

        Private Function checkGridRequire() As Boolean
            checkGridRequire = True
        End Function

        Public Sub dgdChuDautuList_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdChuDautuList.UpdateCommand
            Dim curKey As Integer = CInt(dgdChuDautuList.DataKeys.Item(e.Item.ItemIndex))
            If Me.checkGridRequire() Then
                Dim state As ChuDauTuState

                updChuDauTuByKey(curKey, CType(e.Item.FindControl("dgdHoTen"), TextBox).Text, CType(e.Item.FindControl("dgdNgaySinh"), TextBox).Text, _
                CType(e.Item.FindControl("dgdGioiTinh"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("dgdSoCMND"), TextBox).Text, _
                CType(e.Item.FindControl("dgdNoiCapCMND"), TextBox).Text, _
                CType(e.Item.FindControl("dgdNgayCapCMND"), TextBox).Text, _
                CType(e.Item.FindControl("dgdDienThoai"), TextBox).Text, _
                CType(e.Item.FindControl("dgdFax"), TextBox).Text, _
                CType(e.Item.FindControl("dgdEmail"), TextBox).Text, _
                CType(e.Item.FindControl("dgdNoiDKTT"), TextBox).Text)

                ViewState.Remove("WorkState")

                dgdChuDautuList.EditItemIndex = -1
                BindGrid()
                'ViewState("CHUDAUTUREQUIRE") = "TRUE"
            Else
                Return
                'SetMSGBOX_HIDDEN(Me.Page, "Nhập thiếu thông tin chủ đầu tư")
                'ViewState("CHUDAUTUREQUIRE") = "FALSE"
            End If
        End Sub

        Public Sub dgdChuDautuList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdChuDautuList.PageIndexChanged
            Dim curRow As Integer = dgdChuDautuList.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                If Me.checkGridRequire() Then
                    curKey = CInt(dgdChuDautuList.DataKeys.Item(curRow))
                    updChuDauTuByKey(curKey, CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdHoTen"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgaySinh"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdGioiTinh"), DropDownList).SelectedValue, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdSoCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgayCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdDienThoai"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdFax"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdEmail"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiDKTT"), TextBox).Text)
                    ViewState.Remove("WorkState")
                End If
            End If
            dgdChuDautuList.EditItemIndex = -1
            dgdChuDautuList.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub

        Public Sub dgdChuDautuList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgdChuDautuList.SortCommand
            ViewState("SortField") = e.SortExpression.ToString()
            BindGrid()
        End Sub

        Public Sub CreateDataSource(ByVal HoSoTiepNhanID As String)
            Dim dr As DataRow
            Dim ds As DataSet
            Dim lstChuDauTu As New TiepNhanHoSoController
            ds = lstChuDauTu.GetChuDauTuByHSID(HoSoTiepNhanID)

            Dim i As Integer
            Dim arrChuDauTu As New ArrayList
            For i = 0 To ds.Tables(0).Rows.Count - 1
                arrChuDauTu.Add(New ChuDauTuInfor(i, ds.Tables(0).Rows(i)("MaChuDauTu").ToString, ds.Tables(0).Rows(i)("HoTen").ToString, ds.Tables(0).Rows(i)("NgaySinh").ToString, ds.Tables(0).Rows(i)("GioiTinh").ToString, ds.Tables(0).Rows(i)("SoCMND").ToString, ds.Tables(0).Rows(i)("NoiCapCMND").ToString, ds.Tables(0).Rows(i)("NgayCapCMND").ToString, ds.Tables(0).Rows(i)("DienThoai").ToString, ds.Tables(0).Rows(i)("Fax").ToString, ds.Tables(0).Rows(i)("Email").ToString, ds.Tables(0).Rows(i)("NoiDKTT").ToString, ChuDauTuState.UNCHANGED))
            Next
            ViewState("lstChuDauTu") = arrChuDauTu

            BindGrid()
        End Sub

        Public Sub AddNewRow(ByVal sender As Object, ByVal e As EventArgs)
            Dim curRow As Integer = dgdChuDautuList.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                If Me.checkGridRequire() Then
                    curKey = CInt(dgdChuDautuList.DataKeys.Item(curRow))
                    updChuDauTuByKey(curKey, CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdHoTen"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgaySinh"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdGioiTinh"), DropDownList).SelectedValue, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdSoCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgayCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdDienThoai"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdFax"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdEmail"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiDKTT"), TextBox).Text)
                End If
            End If

            'Add a blank row
            Dim lastRec As Integer = CType(ViewState("lstChuDauTu"), ArrayList).Count - 1
            If lastRec > -1 Then
                curKey = CType(CType(ViewState("lstChuDauTu"), ArrayList)(lastRec), ChuDauTuInfor).Key + 1
            Else
                curKey = 0
            End If

            CType(ViewState("lstChuDauTu"), ArrayList).Add(New ChuDauTuInfor(curKey))

            ' Index of the new item in the page: last +1
            Dim nNewItemIndex As Integer = dgdChuDautuList.Items.Count
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (nNewItemIndex >= dgdChuDautuList.PageSize) Then
                dgdChuDautuList.CurrentPageIndex += 1
                nNewItemIndex = 0
            End If

            ' Turn edit mode on for the newly added row
            dgdChuDautuList.EditItemIndex = nNewItemIndex

            ' Refresh the grid
            BindGrid()

            ViewState("WorkState") = "ADDNEWCHUDAUTU"

            setGridBtnAttr()

        End Sub

        Private Sub setGridBtnAttr()
            'Set require
            Dim obj As TextBox
            For j As Integer = 0 To dgdChuDautuList.Items.Count - 1
                obj = CType(dgdChuDautuList.Items(j).FindControl("dgdSoCMND"), TextBox)
                If Not obj Is Nothing Then
                    obj.Attributes.Add("onblur", "javascript:isSoCMND(" & obj.ClientID & ",'0');")
                End If
            Next
        End Sub

        Public Function IsLastPage() As Boolean
            ' CurrentPageIndex is 0-based...
            If dgdChuDautuList.CurrentPageIndex + 1 = dgdChuDautuList.PageCount Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub updateChuDauTu(ByVal HoSoTiepNhanID As String)

            'update dong dang sua
            Dim curRow As Integer = dgdChuDautuList.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                If Me.checkGridRequire() Then
                    curKey = CInt(dgdChuDautuList.DataKeys.Item(curRow))
                    updChuDauTuByKey(curKey, CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdHoTen"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgaySinh"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdGioiTinh"), DropDownList).SelectedValue, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdSoCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNgayCapCMND"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdDienThoai"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdFax"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdEmail"), TextBox).Text, _
                        CType(dgdChuDautuList.Items(dgdChuDautuList.EditItemIndex).FindControl("dgdNoiDKTT"), TextBox).Text)
                    dgdChuDautuList.EditItemIndex = -1
                    BindGrid()
                End If
            End If

            Dim objHoSo As New TiepNhanHoSoController

            For i As Integer = 0 To CType(ViewState("lstChuDauTu"), ArrayList).Count - 1
                Dim chudautu As ChuDauTuInfor = CType(CType(ViewState("lstChuDauTu"), ArrayList)(i), ChuDauTuInfor)
                If chudautu.State = ChuDauTuState.ADDED Then
                    objHoSo.AddChuDauTuByHSID(HoSoTiepNhanID, chudautu.HoTen, chudautu.NgaySinh, chudautu.GioiTinh, chudautu.SoCMND, chudautu.NoiCapCMND, chudautu.NgayCapCMND, chudautu.DienThoai, chudautu.Fax, chudautu.Email, chudautu.NoiDKTT)
                Else
                    If chudautu.State = ChuDauTuState.MODIFIED Then
                        objHoSo.UpdChuDauTu(chudautu.MaChuDauTu, chudautu.HoTen, chudautu.NgaySinh, chudautu.GioiTinh, chudautu.SoCMND, chudautu.NoiCapCMND, chudautu.NgayCapCMND, chudautu.DienThoai, chudautu.Fax, chudautu.Email, chudautu.NoiDKTT)
                    Else
                        If chudautu.State = ChuDauTuState.DELETED Then
                            objHoSo.DelChuDauTu(chudautu.MaChuDauTu)
                        End If
                    End If
                End If
            Next
        End Sub

        Public Function GetSelectedIndex(ByVal GioiTinh As Object) As Integer
            If GioiTinh Is Nothing Or GioiTinh Is DBNull.Value Then
                Return 0
            Else
                If CStr(GioiTinh) = "" Then
                    Return 0
                Else
                    If CInt(GioiTinh) = 0 Then
                        Return 2
                    Else
                        Return 1
                    End If
                End If
            End If
        End Function

        Public Function GetGender(ByVal GioiTinh As String) As String
            If GioiTinh = "" Then
                Return ""
            Else
                If GioiTinh = "0" Then
                    Return "Nữ"
                Else
                    Return "Nam"
                End If
            End If
        End Function
    End Class

    Public Enum ChuDauTuState As Integer
        ADDED
        DELETED
        MODIFIED
        UNCHANGED
    End Enum

    <Serializable()> Public Class ChuDauTuInfor
        Private _Key As Integer = 0
        Private _MaChuDauTu As String = ""
        Private _HoTen As String = ""
        Private _NgaySinh As String = ""
        Private _GioiTinh As String = ""
        Private _SoCMND As String = ""
        Private _NoiCapCMND As String = ""
        Private _NgayCapCMND As String = ""
        Private _DienThoai As String = ""
        Private _Fax As String = ""
        Private _Email As String = ""
        Private _NoiDKTT As String = ""
        Private _State As ChuDauTuState = ChuDauTuState.ADDED

        Public Sub New(ByVal Key As Integer)
            MyBase.New()
            _Key = Key
        End Sub

        Public Sub New(ByVal Key As Integer, ByVal Ma As String, ByVal Ten As String, ByVal NgaySinh As String, ByVal GioiTinh As String, _
        ByVal SoCMND As String, ByVal NoiCapCMND As String, ByVal NgayCapCMND As String, ByVal DienThoai As String, _
        ByVal Fax As String, ByVal Email As String, ByVal NoiDKTT As String, ByVal State As ChuDauTuState)
            MyBase.New()
            _Key = Key
            _MaChuDauTu = Ma
            _HoTen = Ten
            _NgaySinh = NgaySinh
            _GioiTinh = GioiTinh
            _SoCMND = SoCMND
            _NoiCapCMND = NoiCapCMND
            _NgayCapCMND = NgayCapCMND
            _DienThoai = DienThoai
            _Fax = Fax
            _Email = Email
            _NoiDKTT = NoiDKTT
            _State = ChuDauTuState.UNCHANGED
        End Sub
        Public ReadOnly Property Key() As Integer
            Get
                Return _Key
            End Get
        End Property
        Public ReadOnly Property MaChuDauTu() As String
            Get
                Return _MaChuDauTu
            End Get
        End Property
        Public Property HoTen() As String
            Get
                Return _HoTen
            End Get
            Set(ByVal Value As String)
                _HoTen = Value
            End Set
        End Property
        Public Property NgaySinh() As String
            Get
                Return _NgaySinh
            End Get
            Set(ByVal Value As String)
                _NgaySinh = Value
            End Set
        End Property
        Public Property GioiTinh() As String
            Get
                Return _GioiTinh
            End Get
            Set(ByVal Value As String)
                _GioiTinh = Value
            End Set
        End Property
        Public Property SoCMND() As String
            Get
                Return _SoCMND
            End Get
            Set(ByVal Value As String)
                _SoCMND = Value
            End Set
        End Property
        Public Property NoiCapCMND() As String
            Get
                Return _NoiCapCMND
            End Get
            Set(ByVal Value As String)
                _NoiCapCMND = Value
            End Set
        End Property
        Public Property NgayCapCMND() As String
            Get
                Return _NgayCapCMND
            End Get
            Set(ByVal Value As String)
                _NgayCapCMND = Value
            End Set
        End Property
        Public Property DienThoai() As String
            Get
                Return _DienThoai
            End Get
            Set(ByVal Value As String)
                _DienThoai = Value
            End Set
        End Property
        Public Property Fax() As String
            Get
                Return _Fax
            End Get
            Set(ByVal Value As String)
                _Fax = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property
        Public Property NoiDKTT() As String
            Get
                Return _NoiDKTT
            End Get
            Set(ByVal Value As String)
                _NoiDKTT = Value
            End Set
        End Property
        Public Property State() As ChuDauTuState
            Get
                Return _State
            End Get
            Set(ByVal Value As ChuDauTuState)
                _State = Value
            End Set
        End Property
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace