Imports PortalQH


Namespace CPXD


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
            Dim dsResult As New DataSet
            Dim rptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim rptName As String
            Dim sqlScript As String

            rptName = Request.QueryString("REPORT")
            sqlScript = Request.QueryString("SQL")

            dsResult = DataProvider.Instance.ExecuteSQLAppDataSet(sqlScript)

            rptName = Request.MapPath("~\CPXDQH\Reports\Reports\") + rptName

            rptDoc.Load(rptName)
            rptDoc.SetDataSource(dsResult)

            Me.CrystalReportViewer1.ReportSource = rptDoc
            Me.CrystalReportViewer1.RefreshReport()
        End Sub

    End Class


End Namespace