Imports PortalQH
Namespace CPKTQH
    Public Class PhieuKhaoSat
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtGioKhaoSat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayKhaoSat As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCanBoKhaoSat1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChucVu1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCanBoKhaoSat2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtChucVu2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdNoiDungKhaoSat As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtTrinhThamDinhID As System.Web.UI.WebControls.TextBox
        Protected WithEvents cmdNgaykhaosat As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtDienGiai As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKetLuan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lstRadioKetLuan As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents txtLanhDaoDonVi As System.Web.UI.WebControls.TextBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private Const COL_NOIDUNGKHAOSATID As Integer = 0
        Private Const COL_TRINHTHAMDINHID As Integer = 1
        Private Const COL_NOIDUNGKHAOSAT As Integer = 2
        Private Const COL_KETQUAKHAOSAT As Integer = 3
        Private dvNoiDungKhaoSat As DataView
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            txtNgayKhaoSat.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtNgayKhaoSat.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtNgayKhaoSat.ClientID & ");")
            cmdNgaykhaosat.NavigateUrl = AdminDB.InvokePopupCal(txtNgayKhaoSat)
            lstRadioKetLuan.Items(0).Selected = True
        End Sub

        Private Sub BindGrid()
            'Dim dt As New DataTable
            'Dim col As DataColumn
            'Dim row As DataRow
            'col = New DataColumn("NoiDungKhaoSatID", Type.GetType("System.String"))
            'dt.Columns.Add(col)
            'col = New DataColumn("TrinhThamDinhID", Type.GetType("System.String"))
            'dt.Columns.Add(col)
            'col = New DataColumn("NoiDungKhaoSat", Type.GetType("System.String"))
            'dt.Columns.Add(col)
            'col = New DataColumn("KetQuaKhaoSat", Type.GetType("System.String"))
            'dt.Columns.Add(col)
            'col = New DataColumn("Key", Type.GetType("System.Int16"))
            'dt.Columns.Add(col)
            'Dim arrNoiDungKhaoSat As ArrayList = CType(ViewState("NoiDungKhaoSat"), ArrayList)
            'Dim Tong As Double
            'For i As Integer = 0 To arrNoiDungKhaoSat.Count - 1
            '    If CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).State <> CPXD.RowState.DELETED Then
            '        'chi load ~ record chua bi  danh dau xoa
            '        row = dt.NewRow()
            '        row(COL_NOIDUNGKHAOSATID) = CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).NoiDungKhaoSatID
            '        row(COL_TRINHTHAMDINHID) = CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).TrinhThamDinhID
            '        row(COL_NOIDUNGKHAOSAT) = CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).NoiDungKhaoSat
            '        row(COL_KETQUAKHAOSAT) = CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).KetQuaKhaoSat
            '        row("Key") = CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).Key
            '        dt.Rows.Add(row)
            '    End If
            'Next
            'dvNoiDungKhaoSat = New DataView(dt)
            'dvNoiDungKhaoSat.Sort = CStr(ViewState("SortField"))
            'dgdNoiDungKhaoSat.DataSource = dvNoiDungKhaoSat
            'dgdNoiDungKhaoSat.DataKeyField = "Key"
            'dgdNoiDungKhaoSat.DataBind()
        End Sub
        Public Sub CreateDataSource(ByVal strTrinhThamDinhId As String)
            Dim dr As DataRow
            Dim ds As DataSet
            Dim NoiDungKhaoSat As New PhieuKhaoSatController
            ds = NoiDungKhaoSat.LstNoiDungKhaoSat(strTrinhThamDinhId)
            Dim i As Integer
            Dim arrNoiDungKhaoSat As New ArrayList
            For i = 0 To ds.Tables(0).Rows.Count - 1
                arrNoiDungKhaoSat.Add(New CPhieuKhaoSat(i, ds.Tables(0).Rows(i)(COL_TRINHTHAMDINHID).ToString, ds.Tables(0).Rows(i)(COL_NOIDUNGKHAOSATID).ToString, ds.Tables(0).Rows(i)(COL_NOIDUNGKHAOSAT).ToString, ds.Tables(0).Rows(i)(COL_KETQUAKHAOSAT).ToString, RowState.UNCHANGED))
            Next
            ViewState("NoiDungKhaoSat") = arrNoiDungKhaoSat
            '  BindGrid()
            dvNoiDungKhaoSat = New DataView(ds.Tables(0))
            BindGrid()

        End Sub


        Public Sub dgdNoiDungKhaoSat_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Dim curRow As Integer = dgdNoiDungKhaoSat.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdNoiDungKhaoSat.DataKeys.Item(curRow))
                Try
                    updNoiDungKhaoSatByKey(curKey, CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtNoiDungKhaoSat"), TextBox).Text, _
                        CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtKetQuaKhaoSat"), TextBox).Text)
                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    Exit Sub
                End Try
            End If

            Dim key As Integer = CInt(dgdNoiDungKhaoSat.DataKeys.Item(e.Item.ItemIndex))
            delNoiDungKhaoSatByKey(key)
            If Not ViewState("WorkState") Is Nothing Then
                ViewState.Remove("WorkState")
            End If
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (e.Item.ItemIndex = 0) And dgdNoiDungKhaoSat.Items.Count = 1 And dgdNoiDungKhaoSat.PageCount > 1 And dgdNoiDungKhaoSat.CurrentPageIndex = dgdNoiDungKhaoSat.PageCount - 1 Then
                dgdNoiDungKhaoSat.CurrentPageIndex -= 1
            End If
            dgdNoiDungKhaoSat.EditItemIndex = -1
            BindGrid()
        End Sub

        Public Sub dgdNoiDungKhaoSat_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Me.dgdNoiDungKhaoSat.EditItemIndex = CType(e.Item.ItemIndex, Int32)
            Me.BindGrid()
            ViewState("WorkState") = "EDITNOIDUNG"
        End Sub

        Public Sub dgdNoiDungKhaoSat_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        End Sub

        Public Sub dgdNoiDungKhaoSat_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
            dvNoiDungKhaoSat.Sort = e.SortExpression.ToString()
            dgdNoiDungKhaoSat.DataSource = dvNoiDungKhaoSat
            dgdNoiDungKhaoSat.DataBind()
        End Sub

        Public Sub dgdNoiDungKhaoSat_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Dim str As String
            Dim state As RowState
            Dim curKey As Integer = CInt(dgdNoiDungKhaoSat.DataKeys.Item(e.Item.ItemIndex))
            Try
                updNoiDungKhaoSatByKey(curKey, CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtNoiDungKhaoSat"), TextBox).Text, _
                        CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtKetQuaKhaoSat"), TextBox).Text)
                ViewState.Remove("WorkState")
            Catch ex As Exception
                Exit Sub
            End Try
            'TinhTongDienTich()
            dgdNoiDungKhaoSat.EditItemIndex = -1
            BindGrid()
        End Sub

        Public Sub dgdNoiDungKhaoSat_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
            Dim curRow As Integer = dgdNoiDungKhaoSat.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdNoiDungKhaoSat.DataKeys.Item(curRow))
                Try
                    updNoiDungKhaoSatByKey(curKey, CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtNoiDungKhaoSat"), TextBox).Text, _
                        CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtKetQuaKhaoSat"), TextBox).Text)
                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    Exit Sub
                End Try
            End If
            dgdNoiDungKhaoSat.EditItemIndex = -1
            dgdNoiDungKhaoSat.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub
        Protected Function IsLastPage() As Boolean
            ' CurrentPageIndex is 0-based...
            If dgdNoiDungKhaoSat.CurrentPageIndex + 1 = dgdNoiDungKhaoSat.PageCount Then
                Return True
            Else
                Return False
            End If
        End Function
        'Doan code xu ly cap nhat, them moi, xoa tren luoi
        Private Sub updNoiDungKhaoSatByKey(ByVal Key As Integer, ByVal NoiDungKhaoSat As String, ByVal KetQuaKhaoSat As String)
            Dim arrNoiDungKhaoSat As ArrayList = CType(ViewState("NoiDungKhaoSat"), ArrayList)
            For i As Integer = 0 To arrNoiDungKhaoSat.Count - 1
                If CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).Key = Key Then
                    CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).NoiDungKhaoSat = NoiDungKhaoSat
                    CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).KetQuaKhaoSat = KetQuaKhaoSat
                    If CStr(ViewState("WorkState")).Equals("EDIT") Then
                        If CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).State <> RowState.ADDED Then
                            CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).State = RowState.MODIFIED
                        End If
                    Else
                        CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).State = RowState.ADDED
                    End If
                    Exit For
                End If
            Next
        End Sub
        Private Function getHangMucByKey(ByVal Key As Integer) As CPhieuKhaoSat
            Dim arrNoiDungKhaoSat As ArrayList = CType(ViewState("NoiDungKhaoSat"), ArrayList)
            For i As Integer = 0 To arrNoiDungKhaoSat.Count - 1
                If CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).Key = Key Then
                    Return CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat)
                End If
            Next
            Return Nothing
        End Function
        Private Sub delNoiDungKhaoSatByKey(ByVal Key As Integer)
            Dim arrNoiDungKhaoSat As ArrayList = CType(ViewState("NoiDungKhaoSat"), ArrayList)
            For i As Integer = 0 To arrNoiDungKhaoSat.Count - 1
                If CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).Key = Key Then
                    If CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).NoiDungKhaoSat.Length <= 0 Then
                        'cac record moi add ko co MaChuDauTu -> delete luon
                        arrNoiDungKhaoSat.RemoveAt(i)
                        Exit For
                    Else 'danh dau xoa
                        CType(arrNoiDungKhaoSat(i), CPhieuKhaoSat).State = RowState.DELETED
                    End If
                End If
            Next
        End Sub
        Public Sub AddNewRow(ByVal sender As Object, ByVal e As EventArgs)
            'Add a blank row
            Dim curRow As Integer = dgdNoiDungKhaoSat.EditItemIndex
            Dim curKey As Integer
            If curRow > -1 And Not ViewState("WorkState") Is Nothing Then
                curKey = CInt(dgdNoiDungKhaoSat.DataKeys.Item(curRow))
                Try
                    updNoiDungKhaoSatByKey(curKey, CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtNoiDungKhaoSat"), TextBox).Text, _
                        CType(dgdNoiDungKhaoSat.Items(dgdNoiDungKhaoSat.EditItemIndex).FindControl("txtKetQuaKhaoSat"), TextBox).Text)
                    ViewState.Remove("WorkState")
                Catch ex As Exception
                    Exit Sub
                End Try
            End If
            'Add a blank row
            Dim lastRec As Integer = CType(ViewState("NoiDungKhaoSat"), ArrayList).Count - 1
            If lastRec > -1 Then
                curKey = CType(CType(ViewState("NoiDungKhaoSat"), ArrayList)(lastRec), CPhieuKhaoSat).Key + 1
            Else
                curKey = 0
            End If

            CType(ViewState("NoiDungKhaoSat"), ArrayList).Add(New CPhieuKhaoSat(curKey))

            ' Index of the new item in the page: last +1
            Dim nNewItemIndex As Integer = dgdNoiDungKhaoSat.Items.Count
            ' If the page is full, move to next page. In this 
            ' case, first item.
            If (nNewItemIndex >= dgdNoiDungKhaoSat.PageSize) Then
                dgdNoiDungKhaoSat.CurrentPageIndex += 1
                nNewItemIndex = 0
            End If

            ' Turn edit mode on for the newly added row
            dgdNoiDungKhaoSat.EditItemIndex = nNewItemIndex

            ' Refresh the grid
            BindGrid()

            ViewState("WorkState") = "ADDNEW"
        End Sub
        Public Sub Save_NoiDungKhaoSat(ByVal strTrinhThamDinhID As String)
            Dim objNoiDungKhaoSat As New PhieuKhaoSatController
            objNoiDungKhaoSat.DelNoiDungKhaoSat(strTrinhThamDinhID)
            For i As Integer = 0 To CType(ViewState("NoiDungKhaoSat"), ArrayList).Count - 1
                Dim objKhaoSat As CPhieuKhaoSat = CType(CType(ViewState("NoiDungKhaoSat"), ArrayList)(i), CPhieuKhaoSat)
                If objKhaoSat.State <> RowState.DELETED Then
                    objNoiDungKhaoSat.AddNoiDungKhaoSat(strTrinhThamDinhID, objKhaoSat.NoiDungKhaoSat, objKhaoSat.KetQuaKhaoSat)
                End If
            Next
        End Sub
        Public Sub Save_PhieuKhaoSat(ByVal strTrinhThamDinhID As String)
            Dim objNoiDungKhaoSat As New PhieuKhaoSatController
            txtTrinhThamDinhID.Text = strTrinhThamDinhID
            Dim i As Integer
            For i = 0 To 2
                If lstRadioKetLuan.Items(i).Selected = True Then
                    txtKetLuan.Text = CType(i, String)
                End If
            Next
            objNoiDungKhaoSat.AddPhieuKhaoSat(Me)
        End Sub
        Public Sub LoadPhieuKhaoSat(ByVal strTrinhThamDinhID As String)
            Dim objPhieuKhaoSat As New PhieuKhaoSatController
            Dim ds As New DataSet
            ds = objPhieuKhaoSat.GetPhieuKhaoSat(strTrinhThamDinhID)
            gLoadControlValues(ds, Me)
        End Sub
    End Class
    Public Enum RowState As Integer
        ADDED
        DELETED
        MODIFIED
        UNCHANGED
    End Enum
    <Serializable()> Public Class CPhieuKhaoSat
        Private _Key As Integer = 0
        Private _TrinhThamDinhID As String = ""
        Private _NoiDungKhaoSatId As String = ""
        Private _NoiDungKhaoSat As String = ""
        Private _KetQuaKhaoSat As String = ""
        Private _State As RowState = RowState.ADDED

        Public Sub New(ByVal Key As Integer)
            MyBase.New()
            _Key = Key
        End Sub
        Public Sub New(ByVal Key As Integer, _
                      ByVal strTrinhThamDinhID As String, _
                      ByVal strNoiDungKhaoSatID As String, _
                      ByVal strNoiDungKhaoSat As String, _
                      ByVal strKetQuaKhaoSat As String, _
                     ByVal State As RowState)
            MyBase.New()
            _Key = Key
            _TrinhThamDinhID = strTrinhThamDinhID
            _NoiDungKhaoSatId = strNoiDungKhaoSatID
            _NoiDungKhaoSat = strNoiDungKhaoSat
            _KetQuaKhaoSat = strKetQuaKhaoSat
            _State = RowState.UNCHANGED
        End Sub
        Public ReadOnly Property Key() As Integer
            Get
                Return _Key
            End Get
        End Property

        Public Property TrinhThamDinhID() As String
            Get
                Return _TrinhThamDinhID
            End Get
            Set(ByVal Value As String)
                _TrinhThamDinhID = Value
            End Set
        End Property
        Public Property NoiDungKhaoSatID() As String
            Get
                Return _NoiDungKhaoSatId
            End Get
            Set(ByVal Value As String)
                _NoiDungKhaoSatId = Value
            End Set
        End Property
        Public Property NoiDungKhaoSat() As String
            Get
                Return _NoiDungKhaoSat
            End Get
            Set(ByVal Value As String)
                _NoiDungKhaoSat = Value
            End Set
        End Property
        Public Property KetQuaKhaoSat() As String
            Get
                Return _KetQuaKhaoSat
            End Get
            Set(ByVal Value As String)
                _KetQuaKhaoSat = Value
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
