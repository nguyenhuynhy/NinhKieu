Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class CPXD_ThongKeTongHop
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid

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
            Try
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Init_State()
                End If
                LoadGrid()
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub SetAttributesControl()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub
        Private Sub Init_State()
            Dim glbFile As String
            Dim mSoNgay As Integer

            'glbFile = ConfigurationSettings.AppSettings("PathXML") & "GLOBALHSHC.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbXMLFile), Integer)
            If Request.Params("TuNgay") Is Nothing Or Request.Params("DenNgay") Is Nothing Then
                txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
                txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            Else
                txtTuNgay.Text = Request.Params("TuNgay")
                txtDenNgay.Text = Request.Params("DenNgay")
            End If
        End Sub
        Private Sub LoadGrid()
            Dim objThongKe As New ThongKeDoThiController
            Dim ds As DataSet
            ds = objThongKe.ThongKeDoThi_TheoPhuong(txtTuNgay.Text, txtDenNgay.Text, ConfigurationSettings.AppSettings("COMMONDB").ToString(), CStr(Request.Params("SelectID")))
            If Not ds Is Nothing Then
                BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
            End If
            ds = Nothing
            objThongKe = Nothing
        End Sub
        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell
            'row 1
            dgitem.Cells.Add(InitCell("STT", 1, 2))
            dgitem.Cells.Add(InitCell("Phường", 1, 2))
            dgitem.Cells.Add(InitCell("Xây dựng mới", 2, 1))
            dgitem.Cells.Add(InitCell("Hợp thức hóa", 2, 1))
            dgitem.Cells.Add(InitCell("Hoàn công", 2, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)
            dgitem = Nothing
            'row 2
            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Số lượng"))
            dgitem.Cells.Add(InitCell("Diện tích"))
            dgitem.Cells.Add(InitCell("Số lượng"))
            dgitem.Cells.Add(InitCell("Diện tích"))
            dgitem.Cells.Add(InitCell("Số lượng"))
            dgitem.Cells.Add(InitCell("Diện tích"))
            dgdDanhSach.Controls(0).Controls.AddAt(1, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(2)
            dgitem = Nothing
            mycell = Nothing
        End Sub

        Private Sub dgdDanhSach_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdDanhSach.PageIndexChanged
            dgdDanhSach.CurrentPageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            dgdDanhSach.CurrentPageIndex = 0
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
            End If
            Return strURL
        End Function
    End Class
End Namespace