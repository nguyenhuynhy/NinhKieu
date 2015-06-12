Imports System
Imports System.IO
Imports System.Xml
Imports System.Configuration
Imports PortalQH
Namespace THTT
    Public Class ThongKeDTH_Pie
        Inherits PortalQH.PortalModuleControl
        Public prefile As String
        Protected WithEvents btnTroVe As System.Web.UI.WebControls.LinkButton
        Public prefile1 As String
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
            For Each files In dirs.GetFiles("*" & "_TongHopHoSo_TDH.xml")
                files.Delete()
            Next
            For Each files In dirs.GetFiles("*" & "_TongHopHoSo_TDH1.xml")
                files.Delete()
            Next
            '--------------------------------
            'arrDB.Add("db_CPKT")
            'arrDB.Add("db_CPDT")
            'arrDB.Add("db_CpVH")
            'arrDB.Add("db_CPLD")
            'arrDB.Add("db_hshc")
            '-----------------------------------
            Dim objTinhHinhHoSo As New TinhHinhHoSoInfo
            Dim objTinhHinh As New TinhHinhHoSoController
            objTinhHinhHoSo.TuNgay = Request.Params("TuNgay").ToString()
            objTinhHinhHoSo.DenNgay = Request.Params("DenNgay").ToString()
            objTinhHinhHoSo.LinhVuc = Request.Params("LinhVuc").ToString()
            ds = objTinhHinh.ThongKeTongHopHoSo(ConfigurationSettings.AppSettings("db_hshc"), objTinhHinhHoSo)
            Dim TongDH, TongQH, TongGQ, TongTon, TongKGQ As Double
            For i = 0 To ds.Tables(0).Rows.Count - 1
                TongDH = CType(ds.Tables(0).Rows(i).Item(1), Double)
                TongQH = CType(ds.Tables(0).Rows(i).Item(2), Double)
                TongGQ = CType(ds.Tables(0).Rows(i).Item(3), Double)
                TongKGQ = CType(ds.Tables(0).Rows(i).Item(4), Double)
                TongTon = CType(ds.Tables(0).Rows(i).Item(0), Double)
            Next
            '---------------------------------
            prefile = CType(DatePart(DateInterval.Hour, Now), String) & CType(DatePart(DateInterval.Minute, Now), String) & _
                             CType(DatePart(DateInterval.Second, Now), String)

            Dim arrColor() As String = {"33FF66", "FF6600", "3399FF", "009966", "CC3399", "FFCC33", "6699CC", "CC3366"}
            Dim xw As XmlTextWriter = New XmlTextWriter(Server.MapPath("xml") & "\" & prefile & "_TongHopHoSo_TDH.xml", System.Text.Encoding.ASCII)
            xw.WriteStartDocument()
            xw.WriteStartElement("graph")
            xw.WriteAttributeString("bgcolor", "E1F5FF")
            xw.WriteAttributeString("yaxisname", "Shares")
            xw.WriteAttributeString("xaxisname", "Name")
            xw.WriteAttributeString("showgridbg", "1")
            With xw
                'dung han
                .WriteStartElement("set")
                .WriteAttributeString("name", "Dung han") 'name
                .WriteAttributeString("value", CType(TongDH, String)) 'value
                .WriteAttributeString("color", arrColor(0))
                .WriteEndElement() 'set
                'qua han
                .WriteStartElement("set")
                .WriteAttributeString("name", "Qua han") 'name
                .WriteAttributeString("value", CType(TongQH, String)) 'value
                .WriteAttributeString("color", arrColor(1))
                .WriteEndElement() 'set
            End With
            xw.WriteEndElement() 'root
            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()
            '------------------------------------
            prefile1 = CType(DatePart(DateInterval.Hour, Now), String) & CType(DatePart(DateInterval.Minute, Now), String) & _
                                         CType(DatePart(DateInterval.Second, Now), String) & "1"
            Dim xw1 As XmlTextWriter = New XmlTextWriter(Server.MapPath("xml") & "\" & prefile1 & "_TongHopHoSo_TDH1.xml", System.Text.Encoding.ASCII)

            xw1.WriteStartDocument()
            xw1.WriteStartElement("graph")
            xw1.WriteAttributeString("bgcolor", "E1F5FF")
            xw1.WriteAttributeString("yaxisname", "Shares")
            xw1.WriteAttributeString("xaxisname", "Name")
            xw1.WriteAttributeString("showgridbg", "1")
            With xw1
                'dung han
                .WriteStartElement("set")
                .WriteAttributeString("name", "Giai Quyet") 'name
                .WriteAttributeString("value", CType(TongGQ, String)) 'value
                .WriteAttributeString("color", arrColor(0))
                .WriteEndElement() 'set
                'qua han
                .WriteStartElement("set")
                .WriteAttributeString("name", "Khong giai quyet") 'name
                .WriteAttributeString("value", CType(TongKGQ, String)) 'value
                .WriteAttributeString("color", arrColor(1))
                .WriteEndElement() 'set
                'tong ton
                .WriteStartElement("set")
                .WriteAttributeString("name", "Ton") 'name
                .WriteAttributeString("value", CType(TongTon, String)) 'value
                .WriteAttributeString("color", arrColor(2))
                .WriteEndElement() 'set
            End With
            xw1.WriteEndElement() 'root
            xw1.WriteEndDocument()
            '------------------------------------
            xw1.Flush()
            xw1.Close()
            '------------------------------------------
            ds = Nothing
            objTinhHinh = Nothing
            objTinhHinhHoSo = Nothing
        End Sub
        Private Sub btnTroVe_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
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
                iSelectID = Request.Params("SelectID").ToString()
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
            'Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&SelectChildID=" & iChildID & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle)
            Response.Redirect(NavigateURL() & "&SelectIndex=" & iIndex & "&SelectChildIndex=" & iChildIndex & "&SelectChildID=" & iChildID & "&Type=" & iType & "&SelectID=" & iSelectID & "&SelectTitle=" & iSelectTitle & "&TuNgay=" & iTuNgay & "&DenNgay=" & iDenNgay)
        End Sub
    End Class
End Namespace

