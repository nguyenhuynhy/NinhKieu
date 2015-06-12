Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class ChiTietHoCaThe
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHoTen As System.Web.UI.WebControls.Label
        Protected WithEvents lblSoGP As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCap As System.Web.UI.WebControls.Label
        Protected WithEvents lblCMND As System.Web.UI.WebControls.Label
        Protected WithEvents lblNgayCapCMND As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiCapCMND As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoiDKTT As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiaChi As System.Web.UI.WebControls.Label
        Protected WithEvents lblBangHieu As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoidungKD As System.Web.UI.WebControls.Label
        Protected WithEvents lblVon As System.Web.UI.WebControls.Label
        Protected WithEvents lblTamNgung As System.Web.UI.WebControls.Label
        Protected WithEvents lblThayDoi As System.Web.UI.WebControls.Label
        Protected WithEvents lblViPhamHC As System.Web.UI.WebControls.Label
        Protected WithEvents lblTieuDe As System.Web.UI.WebControls.Label
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton

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
            Dim ds2, ds1 As DataSet
            Dim objChiTiet As New ChiTietHoCaTheController
            ds1 = objChiTiet.ChiTiet_I(Request.Params("ID").ToString(), Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString())
            ds2 = objChiTiet.ChiTiet_II(Request.Params("ID").ToString(), Request.Params("SelectID").ToString(), ConfigurationSettings.AppSettings("COMMONDB").ToString())
            gLoadControlValues(ds1, Me)
            gLoadControlValues(ds2, Me)
            objChiTiet = Nothing
        End Sub
        
        Protected Function GetMidURL(Optional ByVal KeyName As String = "", Optional ByVal KeyValue As String = "", Optional ByVal ControlKey As String = "Edit") As String
            Dim strURL As String
            strURL = EditURL(KeyName, KeyValue, ControlKey)
            If Not Session("MidOfStartPage") Is Nothing Then
                strURL = Replace(strURL, "&mid=-1", "&mid=" & Session("MidOfStartPage").ToString)
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                strURL = strURL & "&SelectID=" & Request.Params("SelectID")
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectTitle") Is Nothing Then
                strURL = strURL & "&SelectTitle=" & Request.Params("SelectTitle")
            End If

            If Not Request.Params("Type") Is Nothing Then
                strURL = strURL & "&Type=" & Request.Params("Type")
            Else
                strURL = strURL & "&Type=1"
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                strURL = strURL & "&SelectChildIndex=" & Request.Params("SelectChildIndex")
            End If
            If Not Request.Params("SelectChildId") Is Nothing Then
                strURL = strURL & "&SelectChildId=" & Request.Params("SelectChildId")
            End If
            If Not Request.Params("Group") Is Nothing Then
                strURL = strURL & "&Group=" & Request.Params("Group")
            End If
            If Not Request.Params("Val") Is Nothing Then
                strURL = strURL & "&Val=" & Request.Params("Val")
            End If
            If Not Request.Params("TuNgay") Is Nothing Then
                strURL = strURL & "&TuNgay=" & Request.Params("TuNgay")
            End If
            If Not Request.Params("DenNgay") Is Nothing Then
                strURL = strURL & "&DenNgay=" & Request.Params("DenNgay")
            End If
            Return strURL

        End Function

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim strType As String
            If Not Request.Params("Type") Is Nothing Then
                strType = Request.Params("Type").ToString()
            Else
                strType = "1"
            End If
            Select Case strType
                'Case "1" : Response.Redirect(EditURL("SelectID", Request.Params("SelectID").ToString() & "&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&Type=" & strType & "&Group=" & Request.Params("Group").ToString() & "&Val=" & Request.Params("Val").ToString() & "&TuNgay=" & Request.Params("TuNgay").ToString() & "&DenNgay=" & Request.Params("DenNgay").ToString() & "&SelectChildID=" & Request.Params("SelectChildID").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString(), "DSHOKD"))
                'Case "3" : Response.Redirect(EditURL("SelectID", Request.Params("SelectID").ToString() & "&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&Type=" & strType & "&Group=" & Request.Params("Group").ToString() & "&Val=" & Request.Params("Val").ToString() & "&TuNgay=" & Request.Params("TuNgay").ToString() & "&DenNgay=" & Request.Params("DenNgay").ToString() & "&SelectChildID=" & Request.Params("SelectChildID").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString(), "DSHOKD"))
                'Case "4" : Response.Redirect(EditURL("SelectID", Request.Params("SelectID").ToString() & "&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&Type=" & strType & "&Group=" & Request.Params("Group").ToString() & "&Val=" & Request.Params("Val").ToString() & "&TuNgay=" & Request.Params("TuNgay").ToString() & "&DenNgay=" & Request.Params("DenNgay").ToString() & "&SelectChildID=" & Request.Params("SelectChildID").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString(), "DSHOKD"))
                'Case Else : Response.Redirect(NavigateURL() & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString() & "&Type=" & Request.Params("Type").ToString() & "&SelectID=" & Request.Params("SelectID").ToString() & "&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&SelectChildID=" & Request.Params("SelectChildID").ToString())
            Case "1" : Response.Redirect(GetMidURL("", "", "DSHOKD"))
                Case "3" : Response.Redirect(GetMidURL("", "", "DSHOKD"))
                Case "4" : Response.Redirect(GetMidURL("", "", "DSHOKD"))
                Case Else : Response.Redirect(NavigateURL() & "&SelectIndex=" & Request.Params("SelectIndex").ToString() & "&SelectChildIndex=" & Request.Params("SelectChildIndex").ToString() & "&Type=" & Request.Params("Type").ToString() & "&SelectID=" & Request.Params("SelectID").ToString() & "&SelectTitle=" & Request.Params("SelectTitle").ToString() & "&SelectChildID=" & Request.Params("SelectChildID").ToString() & "&TuNgay=" & Request.Params("TuNgay") & "&DenNgay=" & Request.Params("DenNgay"))
            End Select
        End Sub
    End Class
End Namespace

