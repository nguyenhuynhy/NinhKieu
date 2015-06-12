Imports System.Web.UI.WebControls
Imports PortalQH
Namespace DOITHOAI
    Public Class DanhSachTinNhan
        Inherits PortalQH.PortalModuleControl
        Private Const COL_VIEWED As Integer = 9
        Private Const COL_TIEUDE As Integer = 1
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents grdDanhSach As System.Web.UI.WebControls.DataGrid
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                grdDanhSach.PageSize = GetSoDongHienThiLuoi()
                txtSoDong.Text = CStr(grdDanhSach.PageSize)
            End If
            LoadGrid()
        End Sub

        Private Sub LoadGrid()
            Dim objTinNhan As New TinNhanController
            Dim objTinNhanInfo As New TinNhanInfo
            Dim ds As DataSet
            Dim strHeader As String
            Dim strWidthColumn As String

            'lấy các thông tin tìm kiếm tin nhắn
            GetValues(objTinNhanInfo)

            'định các cột hiển thị trên danh sách ứng với từng loại danh sách
            SetVisibleColumn(objTinNhanInfo.Loai, strHeader, strWidthColumn)

            'bind grid
            ds = objTinNhan.getDanhSachTinNhan(objTinNhanInfo)
            BindControl.BindGrdHoSo(ds, grdDanhSach, False, strHeader, strWidthColumn)

            'set style cho các dòng tin nhắn chưa được đọc
            SetStyle()

            ds = Nothing
            objTinNhan = Nothing
            objTinNhanInfo = Nothing
        End Sub
        Private Sub GetValues(ByRef objCauHoiInfo As TinNhanInfo)
            Dim strSelectID As String
            Dim strURL As String

            'lấy URL
            Select Case True
                Case TypeOf Me.NamingContainer Is Main
                    strURL = CType(Me.NamingContainer, Main).GetURL("ID", "VALUE")
                    If Request.Params("SelectID") Is Nothing Then
                        strSelectID = CType(Me.NamingContainer, Main).GetSelectID(0)
                    End If
                Case Else
                    strURL = EditURL("ID", "VALUE")
                    strSelectID = "1"
            End Select

            If Not Request.Params("SelectID") Is Nothing Then
                strSelectID = Request.Params("SelectID")
            End If

            With objCauHoiInfo
                .MaNguoiSuDung = CStr(Session("UserName"))
                .Loai = getLoaiDanhSachCauHoi(Request, strSelectID)
                .URL = strURL
            End With
        End Sub
        Private Sub SetVisibleColumn(ByVal pLoai As String, ByRef pHeader As String, ByRef pColumnWidth As String)
            pHeader = "Tiêu đề,TinNhanID,Lĩnh vực hỏi, Ngày hỏi, Ngày gửi cuối, Ngày trả lời, Người nhận, Người trả lời, Số lần trả lời,Viewed"

            Select Case pLoai
                Case "TINGUI"
                    pHeader = "Tiêu đề,TinNhanID,Lĩnh vực hỏi, Ngày hỏi, Ngày gửi, Người nhận, Người trả lời, Số lần trả lời,Viewed"
                    pColumnWidth = "300,0,120,0,80,70,0,50,0"
                Case "TINNHAN"
                    pHeader = "Tiêu đề,TinNhanID,Lĩnh vực hỏi, Ngày hỏi, Ngày nhận, Người nhận, Người gửi, Số lần trả lời,Viewed"
                    pColumnWidth = "300,0,120,0,80,0,70,50,0"
            End Select
        End Sub
        Private Sub SetStyle()
            Dim i As Integer
            For i = 0 To grdDanhSach.Items.Count - 1
                If grdDanhSach.Items(i).Cells(COL_VIEWED).Text = "0" Then
                    Dim obj As New Image
                    obj.ImageUrl = "~/Images/news.gif"
                    grdDanhSach.Items(i).Cells(COL_TIEUDE).Controls.Add(obj)
                End If
            Next
        End Sub
        Private Sub txtSoDong_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoDong.TextChanged
            If Not IsInteger(txtSoDong.Text) Or Trim(txtSoDong.Text) = "" Or Val(txtSoDong.Text) = 0 Then
                SetMSGBOX_HIDDEN(Page, "Số dòng hiển thị không hợp lệ")
                txtSoDong.Text = CStr(grdDanhSach.PageSize)
                Exit Sub
            End If
            If grdDanhSach.PageSize <> CInt(txtSoDong.Text) Then
                grdDanhSach.PageSize = CInt(txtSoDong.Text)
                grdDanhSach.CurrentPageIndex = 0
                LoadGrid()
            End If
        End Sub
        Private Sub grdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDanhSach.PageIndexChanged
            grdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub
    End Class
End Namespace