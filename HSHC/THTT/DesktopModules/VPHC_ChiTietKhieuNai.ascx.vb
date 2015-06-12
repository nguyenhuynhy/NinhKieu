Option Strict Off
Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class VPHC_ChiTietKhieuNai
        Inherits PortalQH.PortalModuleControl
        Protected WithEvents lblTTrang As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiDungKN As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiThuongtru As System.Web.UI.WebControls.Label
        Protected WithEvents lblNguoiDaiDien As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayQD As System.Web.UI.WebControls.Label
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents lblTraLoi As System.Web.UI.WebControls.Label
        Protected WithEvents lblSocv As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCV As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoQD As System.Web.UI.WebControls.HyperLink
        Protected WithEvents frmChitietTiepNhan As System.Web.UI.HtmlControls.HtmlForm
        Private type As String
        Private CurID As String         ' id khieu nai
        Private strDB As String
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.ImageButton
        Private KeyID As String         ' keyid

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
            type = Trim(Request.QueryString("Type"))
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
                Me.lblDiaChi.Text = IIf(IsDBNull(r.Item("DIACHI")), "", r.Item("DIACHI"))
                Me.lblNoiDungKN.Text = Trim(IIf(IsDBNull(r.Item("NoidungKN")), "", r.Item("noidungKN")))
                Me.lblTraLoi.Text = Trim(IIf(IsDBNull(r.Item("NoidungTL")), "", r.Item("noidungTL")))
                If Not IsDBNull(r.Item("soqd")) Then
                    Me.lblSoQD.Text = IIf(IsDBNull(r.Item("soqd")), "", r.Item("soqd"))
                    Me.lblSoQD.NavigateUrl = "chitietraquyetdinh.aspx?type=QD&DB=" & strDB & "&cat=VPH&ID=" & r.Item("ABC_SoQD")
                End If
                If Not IsDBNull(r.Item("NGAYQD")) Then
                    Me.lblNgayQD.Text = r.Item("NGAYQD")
                End If
                Me.lblNoiThuongtru.Text = IIf(IsDBNull(r.Item("NOIDKTT")), "", r.Item("NOIDKTT"))
                Me.lblNguoiDaiDien.Text = IIf(IsDBNull(r.Item("hoten")), "", r.Item("HoTen"))
                Me.lblSocv.Text = IIf(IsDBNull(r.Item("socv")), "", r.Item("socv"))
                If Not IsDBNull(r.Item("NGAYCV")) Then
                    Me.lblNgayCV.Text = r.Item("NGAYCV")
                End If
                Me.lblTTrang.Text = IIf(IsDBNull(r.Item("TTRANG")), "", r.Item("TTRANG"))
                '----------lay keyid de xet tiep tinh trang xu ly
                If Not IsDBNull(r.Item("KeyId")) Then
                    KeyID = Trim(r.Item("keyid"))
                End If
            Next


        End Function
        Function getTTrangXLy() As String
            Return Globals.getTTrangXLy(strDB, KeyID)
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