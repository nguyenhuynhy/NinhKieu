Imports PortalQH
Imports CrystalDecisions.Shared


Namespace HSHC


    Public Class rptReport
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents CrystalReportViewer1 As CrystalDecisions.Web.CrystalReportViewer

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
            Dim rptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim objTLOI As New TableLogOnInfo
            Dim dsResult As New DataSet

            Dim rptName As String = ""
            Dim sqlScript As String = ""
            Dim strFormula As String = ""
            Dim strValue As String = ""
            Dim arrFormula() As String
            Dim arrValue() As String
            Dim i As Integer = 0

            'set info for database server
            objTLOI.ConnectionInfo.ServerName = "abc"
            objTLOI.ConnectionInfo.DatabaseName = "def"
            objTLOI.ConnectionInfo.UserID = "sa"
            objTLOI.ConnectionInfo.Password = "sa"

            'Get report name and store name
            rptName = Request.QueryString("REPORT")
            sqlScript = Request.QueryString("SQL")

            'Get formula and value of formula
            strFormula = Request.QueryString("formula")
            strValue = Request.QueryString("value")
            'Convert A String to String Array by Char ";"
            arrFormula = strFormula.Split(Convert.ToChar(";"))
            arrValue = strValue.Split(Convert.ToChar(";"))

            'Get data to pass into Report
            dsResult = DataProvider.Instance.ExecuteSQLAppDataSet(sqlScript)

            'Set full path file report, load report and bind data to report
            rptName = Request.MapPath("~\HSHC\Reports\Reports\") + rptName
            rptDoc.Load(rptName, OpenReportMethod.OpenReportByDefault)
            rptDoc.SetDataSource(dsResult)

            'add value to formula
            '================================
            If arrFormula.Length > 1 Then   'Greater than One Parameter
                For i = 0 To arrFormula.Length - 1
                    rptDoc.SetParameterValue(arrFormula.GetValue(i).ToString().Trim(), arrValue.GetValue(i).ToString().Trim())
                Next
            Else    'One Parameter
                If rptDoc.ParameterFields.Count > 0 Then
                    rptDoc.SetParameterValue(strFormula.Trim(), strValue.Trim())
                End If
            End If
            'end add value to formula
            '================================

            'set connection information
            For i = 0 To rptDoc.Database.Tables.Count - 1
                rptDoc.Database.Tables(0).LogOnInfo.ConnectionInfo = objTLOI.ConnectionInfo
                rptDoc.Database.Tables(i).ApplyLogOnInfo(objTLOI)
            Next

            'show report
            Me.CrystalReportViewer1.ReportSource = rptDoc
            'Me.CrystalReportViewer1.ShowFirstPage()
            'Me.CrystalReportViewer1.EnableParameterPrompt = False
            'Me.CrystalReportViewer1.HasRefreshButton = True
            'Me.CrystalReportViewer1.HasPrintButton = True
            'Me.CrystalReportViewer1.HasToggleGroupTreeButton = False
            'Me.CrystalReportViewer1.HasExportButton = True
            ''refresh report
            'Me.CrystalReportViewer1.RefreshReport()
        End Sub

        Private Sub CrystalReportViewer1_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init

        End Sub
    End Class


End Namespace