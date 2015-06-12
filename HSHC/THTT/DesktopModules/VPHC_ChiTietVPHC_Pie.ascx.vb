Imports System
Imports System.IO
Imports System.Xml
Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class VPHC_ChiTietVPHC_Pie
        Inherits PortalQH.PortalModuleControl
        Public prefile As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
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
            Try
                LoadContent()
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub LoadContent()
            Dim i, j As Integer
            Dim Db As String
            Dim ds As New DataSet
            Dim arrDB As New ArrayList
            '------------------------
            Dim dirs As New DirectoryInfo(Server.MapPath("xml"))
            Dim files As System.IO.FileInfo
            Dim s As String
            For Each files In dirs.GetFiles("*" & "_VPHC_ChiTietVPHC.xml")
                files.Delete()
            Next
            '--------------------------------
            arrDB.Add("db_VPKT")
            arrDB.Add("db_VPDT")
            arrDB.Add("db_VPVH")
            arrDB.Add("db_VPLD")
            '-----------------------------------
            prefile = CType(DatePart(DateInterval.Hour, Now), String) & CType(DatePart(DateInterval.Minute, Now), String) & _
                             CType(DatePart(DateInterval.Second, Now), String)

            Dim arrColor() As String = {"33FF66", "FF6600", "3399FF", "009966", "CC3399", "FFCC33", "6699CC", "CC3366", "33CCAA", "AA6633"}
            Dim xw As XmlTextWriter = New XmlTextWriter(Server.MapPath("xml") & "\" & prefile & "_VPHC_ChiTietVPHC.xml", System.Text.Encoding.ASCII)
            xw.WriteStartDocument()
            xw.WriteStartElement("graph")
            xw.WriteAttributeString("bgcolor", "E1F5FF")
            xw.WriteAttributeString("yaxisname", "Shares")
            xw.WriteAttributeString("xaxisname", "Name")
            xw.WriteAttributeString("showgridbg", "1")

            '-----------------------------------
            Dim objHSCT As New ViPhamHanhChinhController
            Dim dv As New DataView
            Dim obDataView As New DataView
            Dim strTuNgay, strDenNgay, strLinhVuc As String
            If Not Request.Params("TuNgay") Is Nothing Then
                strTuNgay = CType(Request.Params("TuNgay"), String)
            End If
            If Not Request.Params("DenNgay") Is Nothing Then
                strDenNgay = CType(Request.Params("DenNgay"), String)
            End If
            If Not Request.Params("LinhVuc") Is Nothing Then
                strLinhVuc = CType(Request.Params("LinhVuc"), String)
            End If

            'For i = 0 To arrDB.Count - 1
            'ds = objHSCT.GetHoSoVPHC(ConfigurationSettings.AppSettings(CType(arrDB(i), String)), strTuNgay, strDenNgay)
            'ds = objHSCT.GetHoSoVPHC(ConfigurationSettings.AppSettings("db_vphc"), strTuNgay, strDenNgay)
            ds = objHSCT.GetHoSoVPHCLoaiHoSo(ConfigurationSettings.AppSettings("db_vphc"), strTuNgay, strDenNgay, strLinhVuc)
            'If i = 0 Then
            dv = ds.Tables(0).DefaultView
            'Else
            '    obDataView = ds.Tables(0).DefaultView
            '    Dim viewEnumerator As IEnumerator = obDataView.GetEnumerator()
            '    viewEnumerator.MoveNext()
            '    Dim drv As DataRowView = CType(viewEnumerator.Current, DataRowView)
            '    Dim strName As String
            '    dv.AddNew()
            '    For j = 0 To obDataView.Table.Columns.Count - 1
            '        dv.Item(i).Item(j) = drv(j)
            '    Next
            'End If
            'Next
            '------------------------------------------
            With xw
                'For i = 0 To dv.Count - 1
                .WriteStartElement("set")
                .WriteAttributeString("name", "Quyet dinh") 'name
                .WriteAttributeString("value", CType(dv.Item(0).Item(1), String))
                .WriteAttributeString("color", arrColor(0))
                .WriteEndElement() 'set

                .WriteStartElement("set")
                .WriteAttributeString("name", "Thi hanh quyet dinh") 'name
                .WriteAttributeString("value", CType(dv.Item(0).Item(2), String))
                .WriteAttributeString("color", arrColor(1))
                .WriteEndElement() 'set
                'Next
            End With
            xw.WriteEndElement() 'root
            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()
            '------------------------------------------
            ds = Nothing
        End Sub

        Private Sub btnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
            Dim iIndex As String
            Dim iChildIndex As String
            Dim iChildID As String
            Dim iType As String
            Dim iSelectID As String
            Dim iSelectTitle As String
            Dim iTuNgay As String
            Dim iDenNgay As String
            If Not Request.Params("SelectTitle") Is Nothing Then
                iSelectTitle = Request.Params("SelectTitle").ToString()
            Else
                iSelectTitle = "0"
            End If
            If Not Request.Params("SelectID") Is Nothing Then
                iSelectID = Request.Params("SelectID")
            Else
                iSelectID = CType(ConfigurationSettings.AppSettings("MenuIDStart"), String)
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                iIndex = Request.Params("SelectIndex").ToString()
            Else
                iIndex = "0"
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                iChildIndex = Request.Params("SelectChildIndex").ToString()
            Else
                iChildIndex = "0"
            End If
            If Not Request.Params("SelectChildID") Is Nothing Then
                iChildID = Request.Params("SelectChildID").ToString()
            Else
                iChildID = "0"
            End If
            If Not Request.Params("Type") Is Nothing Then
                iType = Request.Params("Type").ToString()
            Else
                iType = "1"
            End If
            If Not Request.Params("TuNgay") Is Nothing Then
                iTuNgay = Request.Params("TuNgay").ToString()
            End If
            If Not Request.Params("DenNgay") Is Nothing Then
                iDenNgay = Request.Params("DenNgay").ToString()
            End If
            Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&SelectChildID=" & iChildID & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&TuNgay=" & iTuNgay & "&DenNgay=" & iDenNgay)
        End Sub
    End Class
End Namespace

