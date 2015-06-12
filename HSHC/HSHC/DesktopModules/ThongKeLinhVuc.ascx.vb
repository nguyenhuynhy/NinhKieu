Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ThongKeLinhVuc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '********************************************************************
        'Purpose           	:Load page
        'Params         	:System params
        'Returns         	:None
        'Created date		:Unknown
        'Creator		    :Unknown
        'Modified date  	:Mar 13th 2006
        'Modifier        	:Phuocdd
        'Description        :Set request params TuNgay, DenNgay
        '********************************************************************
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Dim glbFile As String
                    Dim mSoNgay As Integer
                    glbFile = ConfigurationSettings.AppSettings("PATH" & CType(Session.Item("ActiveDB"), String)) & "GLOBAL.xml"
                    mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
                    If Request.Params("TuNgay") Is Nothing Then
                        txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
                        txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
                    Else
                        txtTuNgay.Text = Request.Params("TuNgay")
                        txtDenNgay.Text = Request.Params("DenNgay")
                    End If
                    LoadGrid()
                End If
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub

        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub

        Private Sub LoadGrid()
            Try
                Dim objThongKeBaoCao As New ThongKeBaoCaoInfo
                Dim objThongKe As New ThongKeBaoCaoController
                Dim ds As DataSet

                objThongKeBaoCao.TuNgay = txtTuNgay.Text
                objThongKeBaoCao.DenNgay = txtDenNgay.Text
                ds = objThongKe.ThongKeLinhVuc(objThongKeBaoCao)
                BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)

                ds = Nothing
                objThongKe = Nothing
                objThongKeBaoCao = Nothing
            Catch ex As Exception
                SetMSGBOX_HIDDEN(Me.Page, ex.Message)
            End Try
        End Sub

        Private Sub dgdDanhSach_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdDanhSach.PreRender
            Dim dgitem As New DataGridItem(0, 0, ListItemType.Header)
            Dim mycell As TableCell

            dgitem.Cells.Add(InitCell("STT", 1, 2))
            dgitem.Cells.Add(InitCell("Tên lĩnh vực", 1, 2))
            dgitem.Cells.Add(InitCell("Tồn trước", 1, 2))
            dgitem.Cells.Add(InitCell("Nhận trong kỳ", 1, 2))
            dgitem.Cells.Add(InitCell("Hủy trong kỳ", 1, 2))
            dgitem.Cells.Add(InitCell("Đã giải quyết", 2, 1))
            dgitem.Cells.Add(InitCell("Chưa giải quyết", 3, 1))
            dgitem.Cells.Add(InitCell("Trả hồ sơ", 2, 1))
            dgdDanhSach.Controls(0).Controls.AddAt(0, dgitem)

            dgitem = Nothing
            dgitem = New DataGridItem(0, 0, ListItemType.Header)
            dgitem.Cells.Add(InitCell("Đúng hạn"))
            dgitem.Cells.Add(InitCell("Quá hạn"))
            dgitem.Cells.Add(InitCell("Trong hạn"))
            dgitem.Cells.Add(InitCell("Quá hạn"))
            dgitem.Cells.Add(InitCell("Chờ bổ sung"))
            dgitem.Cells.Add(InitCell("Đã nhận"))
            dgitem.Cells.Add(InitCell("Chưa nhận"))
            dgdDanhSach.Controls(0).Controls.AddAt(1, dgitem)

            dgdDanhSach.Controls(0).Controls.RemoveAt(2)
            dgdDanhSach.Controls(0).Controls.RemoveAt(2)
            dgitem = Nothing
            mycell = Nothing
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            Dim sURL As String
            sURL = NavigateURL()
            sURL += "&TuNgay=" & txtTuNgay.Text & "&DenNgay=" & txtDenNgay.Text
            Response.Redirect(ResolveUrl(sURL), True)
            'LoadGrid()
        End Sub
    End Class
End Namespace