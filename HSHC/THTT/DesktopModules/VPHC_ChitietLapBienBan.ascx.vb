Option Strict Off
Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class VPHC_ChitietLapBienBan
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents lblNgayQD As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoBB As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayBB As System.Web.UI.WebControls.Label
        Protected WithEvents lblNguoiDaiDien As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiThuongtru As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiDungVP As System.Web.UI.WebControls.Label
        Protected WithEvents lblTTrang As System.Web.UI.WebControls.Label
        Protected WithEvents hyperlinkSoGP As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblNgayCP As System.Web.UI.WebControls.Label
        Protected WithEvents hplToCao As System.Web.UI.WebControls.HyperLink
        Protected WithEvents frmChitietTiepNhan As System.Web.UI.HtmlControls.HtmlForm
        Private type As String
        Private CurID As String
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoQD As System.Web.UI.WebControls.Label
        Private strDB As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            type = Request.QueryString("Type")
            CurID = Request.QueryString("ID")
            strDB = Request.QueryString("DB")
            If Not Page.IsPostBack() Then
                BindData()
            End If
        End Sub
        Public Function BindData() As String
            Dim CurID As String = Request.QueryString("ID")
            Dim strDB As String = Request.QueryString("DB")
            Dim strType As String = Request.QueryString("Type")
            Dim firstRow As Boolean = True
            Dim dataSet As System.Data.DataSet = New System.Data.DataSet
            Dim objVPHC As New ViPhamHanhChinhController
            dataSet = objVPHC.GetChiTietQuyetDinh(strDB, ConfigurationSettings.AppSettings("commonDB"), CurID, strType)
            Dim r As DataRow
            For Each r In dataSet.Tables(0).Rows
                If Not IsDBNull(r.Item("SoQD")) Then
                    Me.lblSoQD.Text = r.Item("SoQD")
                    'Me.lblSoQD.NavigateUrl = "chitietraquyetdinh.aspx?type=QD&DB=" & strDB & "&cat=VPH&ID=" & r.Item("ABC_SoQD")
                End If
                If r.Item("SoGiayPhep") = "" Then
                    Me.hyperlinkSoGP.Text = ""
                    Me.lblNgayCP.Text = ""
                    Me.lblSoGP.Text = ""
                Else
                    If Not IsDBNull(r.Item("NgayGP")) Then
                        Me.lblNgayCP.Text = r.Item("NgayGP")
                    End If
                    If UCase(strDB) = "DB_VPDTBT" Then
                        Me.hyperlinkSoGP.NavigateUrl = "../cpdt/ChiTietDT.aspx?CAT=QDT&ID=" & Trim(IIf(IsDBNull(r.Item("SoGiayPhep")), "", r.Item("SoGiayPhep")))
                        '                    Me.hyperlinkSoGP.Text = MyModule.GETSOGP_DT(r.Item("SOGIAYPHEP"), ConfigurationSettings.AppSettings("DB_CPDTBT"), "giayphep_xd")
                        Me.hyperlinkSoGP.Text = r.Item("SoGIAYPHEP")
                        Me.lblSoGP.Text = r.Item("SoGIAYPHEP")
                    Else
                        Me.hyperlinkSoGP.NavigateUrl = "../cpkt/ChiTietHoCaThe.aspx?ID=" & Trim(IIf(IsDBNull(r.Item("SoGiayPhep")), "", r.Item("SoGiayPhep")))
                        Me.hyperlinkSoGP.Text = r.Item("SoGIAYPHEP")
                        Me.lblSoGP.Text = r.Item("SoGIAYPHEP")
                    End If
                End If
                If Not IsDBNull(r.Item("ngayqd")) Then
                    Me.lblNgayQD.Text = r.Item("NgayQD")
                End If
                If Not IsDBNull(r.Item("ngaybb")) Then
                    Me.lblNgayBB.Text = r.Item("Ngaybb")
                End If
                Me.lblSoBB.Text = Trim(IIf(IsDBNull(r.Item("sobienbanlap")), "", r.Item("sobienbanlap")))
                Me.lblNguoiDaiDien.Text = Trim(IIf(IsDBNull(r.Item("HoTen")), "", r.Item("HoTen")))
                Me.lblNoiThuongtru.Text = Trim(IIf(IsDBNull(r.Item("NoiDKTT")), "", r.Item("NoiDKTT")))
                Me.lblDiaChi.Text = Trim(IIf(IsDBNull(r.Item("Diachi")), "", r.Item("Diachi")))
                Me.lblTTrang.Text = Trim(IIf(IsDBNull(r.Item("TTrang")), "", r.Item("TTrang")))
                Me.lblNoiDungVP.Text = Trim(IIf(IsDBNull(r.Item("NoidungVP")), "", r.Item("noidungvp")))
                If Trim(r.Item("TocaoID")) <> "" Then
                    Me.hplToCao.NavigateUrl = "ChiTietToCao.aspx?CAT=VPH&ID=" & Trim(r.Item("ToCaoID")) & "&DB=" & strDB
                    Me.hplToCao.Text = "Xem chi tiết nội dung tố cáo"
                End If
            Next
        End Function
        Function getTTrangXLy() As String
            Return Globals.getTTrangXLy(Request.QueryString("DB"), CurID)
        End Function

        Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTroVe.Click
            Response.Redirect(GetMidURL("DB", Request.QueryString("DB") & "&Loai=" & Request.QueryString("Loai"), "VPHC_DSHOSO"))
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