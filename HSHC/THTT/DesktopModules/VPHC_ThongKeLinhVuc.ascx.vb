Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class VPHC_ThongKeLinhVuc
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        'Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        'Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTimKiem As System.Web.UI.WebControls.LinkButton
        Protected WithEvents dgdDanhSach As System.Web.UI.WebControls.DataGrid
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try

                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Dim glbFile As String
                    Dim mSoNgay As Integer
                    glbFile = ConfigurationSettings.AppSettings("PATH") & glbXMLFile
                    mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
                    txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
                    txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
                    If Not Request.QueryString("TuNgay") Is Nothing Then
                        txtTuNgay.Text = Request.QueryString("TuNgay")
                    End If
                    If Not Request.QueryString("TuNgay") Is Nothing Then
                        txtDenNgay.Text = Request.QueryString("DenNgay")
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
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
            'Me.cmdTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")
            'Me.cmdDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub

        Private Sub LoadGrid()
            Try
                Dim objThongKeBaoCao As New VPHC_ThongKeBaoCaoInfo
                Dim objThongKe As New VPHC_ThongKeBaoCaoController
                Dim ds As DataSet

                objThongKeBaoCao.TuNgay = txtTuNgay.Text
                objThongKeBaoCao.DenNgay = txtDenNgay.Text
                objThongKeBaoCao.LinhVuc = Request.QueryString("selectID")
                ds = objThongKe.ThongKeTheoPhongBan(objThongKeBaoCao)
                BindControl.BindDataGrid(ds, dgdDanhSach, ds.Tables(0).Rows.Count)
                ds = Nothing
                objThongKe = Nothing
                objThongKeBaoCao = Nothing
            Catch ex As Exception
                SetMSGBOX_HIDDEN(Me.Page, ex.Message)
            End Try
        End Sub

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
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