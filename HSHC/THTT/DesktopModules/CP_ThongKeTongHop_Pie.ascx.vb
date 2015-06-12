Imports System
Imports System.IO
Imports System.Xml
Imports PortalQH
Imports System.Configuration
Namespace THTT
    Public Class CP_ThongKeTongHop_Pie
        Inherits PortalQH.PortalModuleControl
        Public prefile As String
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents btnTuNgay As System.Web.UI.WebControls.Image
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                If Not Page.IsPostBack Then
                    SetAttributesControl()
                    Init_State()
                    LoadContent()
                End If
                txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
                txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub
        Private Sub SetAttributesControl()
            Me.txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");")
            'Me.btnTuNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtTuNgay.ClientID & ", 'dd/mm/yyyy')")
            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            Me.txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");")
            'Me.btnDenNgay.Attributes.Add("onclick", "javascript:popUpCalendar(this, " & txtDenNgay.ClientID & ", 'dd/mm/yyyy')")
            Me.txtTuNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.txtDenNgay.Attributes.Add("ISNULL", "NOTNULL")
            Me.btnTimKiem.Attributes.Add("onClick", "javascript:return CheckNull();")
        End Sub
        Private Sub Init_State()
            Dim glbFile As String
            Dim mSoNgay As Integer
            glbFile = ConfigurationSettings.AppSettings("PathXML") & "GLOBALHSHC.xml"
            mSoNgay = CType(GetValueItem(Request, "SoNgayLoc", glbFile), Integer)
            If Not Request.Params("TuNgay") Is Nothing Then
                txtTuNgay.Text = Request.Params("TuNgay").ToString()
            Else
                txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            End If
            If Not Request.Params("DenNgay") Is Nothing Then
                txtDenNgay.Text = Request.Params("DenNgay").ToString()
            Else
                txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
            End If
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
            For Each files In dirs.GetFiles("*" & "_TongHopHoSo.xml")
                files.Delete()
            Next

            '--------------------------------
            'arrDB.Add("db_CPKT")
            'arrDB.Add("db_CPDT")
            'arrDB.Add("db_CpVH")
            'arrDB.Add("db_CPLD")
            'arrDB.Add("db_hshc")
            '-----------------------------------
            prefile = CType(DatePart(DateInterval.Hour, Now), String) & CType(DatePart(DateInterval.Minute, Now), String) & _
                             CType(DatePart(DateInterval.Second, Now), String)

            Dim arrColor() As String = {"33FF66", "FF6600", "3399FF", "009966", "CC3399", "FFCC33", "6699CC", "CC3366", "33CCAA", "AA6633"}
            Dim xw As XmlTextWriter = New XmlTextWriter(Server.MapPath("xml") & "\" & prefile & "_TongHopHoSo.xml", System.Text.Encoding.ASCII)
            xw.WriteStartDocument()
            xw.WriteStartElement("graph")
            xw.WriteAttributeString("bgcolor", "E1F5FF")
            xw.WriteAttributeString("yaxisname", "Shares")
            xw.WriteAttributeString("xaxisname", "Name")
            xw.WriteAttributeString("showgridbg", "1")

            '-----------------------------------
            Dim objHSCT As New TinhHinhHoSoController
            Dim dv As New DataView
            Dim obDataView As New DataView

            'For i = 0 To arrDB.Count - 1
            ds = objHSCT.ThongKeTongHop(ConfigurationSettings.AppSettings("db_hshc"), txtTuNgay.Text, txtDenNgay.Text)
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
                For i = 0 To dv.Count - 1
                    .WriteStartElement("set")
                    .WriteAttributeString("name", CType(dv.Item(i)(1), String)) 'name
                    .WriteAttributeString("value", CType(dv.Item(i)(3), String))
                    .WriteAttributeString("color", arrColor(i))
                    .WriteAttributeString("link", GetURL(CType(dv.Item(i)(1), String)))
                    .WriteEndElement() 'set
                Next
            End With
            xw.WriteEndElement() 'root
            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()
            '------------------------------------------
            ds = Nothing
            Session.Item("TuNgay") = txtTuNgay.Text
            Session.Item("DenNgay") = txtDenNgay.Text
        End Sub

        'Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTimKiem.Click
        '    LoadContent()
        'End Sub
        Protected Function GetURL(ByVal LinhVuc As String) As String
            Dim strURL As String
            strURL = "default.aspx?ctl=" & "DTH_PIE" & "&SelectID=" & Request.Params("SelectID") & "&LinhVuc=" & LinhVuc & "&mid=" & Session("MidOfStartPage").ToString
            If Not Request.Params("TabID") Is Nothing Then
                strURL = strURL & "&TabID=" & Request.Params("TabID")
            End If
            If Not Request.Params("SelectIndex") Is Nothing Then
                strURL = strURL & "&SelectIndex=" & Request.Params("SelectIndex")
            End If
            If Not Request.Params("SelectChildIndex") Is Nothing Then
                strURL = strURL & "&SelectChildIndex=" & Request.Params("SelectChildIndex")
            End If
            If Not Request.Params("SelectChildID") Is Nothing Then
                strURL = strURL & "&SelectChildID=" & Request.Params("SelectChildID")
            End If
            If Not Request.Params("SelectTitle") Is Nothing Then
                strURL = strURL & "&SelectTitle=" & Request.Params("SelectTitle")
            End If
            If Not Request.Params("Type") Is Nothing Then
                strURL = strURL & "&Type=" & Request.Params("Type")
            End If
            'If Not Request.Params("TuNgay") Is Nothing Then
            strURL = strURL & "&TuNgay=" & txtTuNgay.Text
            'End If
            'If Not Request.Params("DenNgay") Is Nothing Then
            strURL = strURL & "&DenNgay=" & txtDenNgay.Text
            'End If
            Return strURL
        End Function

        Private Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
            LoadContent()
        End Sub
    End Class
End Namespace