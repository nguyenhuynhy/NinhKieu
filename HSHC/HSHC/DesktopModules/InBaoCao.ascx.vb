Imports PortalQH
Imports System.Configuration
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared


Namespace HSHC
    Public Class InBaoCao
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents CrystalReportViewer2 As CrystalDecisions.Web.CrystalReportViewer
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

            txtSoBienNhan.Text = "2004CPKT1300004" 'Request.Params("SoBienNhan").ToString
            'Dung cho report
            Dim objReportInfo As New ReportsInfo
            Dim objReport As New ReportController
            Dim strSQL As String
            With objReportInfo
                .MaLinhVuc = gItemCode
                .TabCode = Request.Params("TabId").ToString
                .ItemCode = "1"
            End With
            objReportInfo = objReport.GetReportInfo(objReportInfo)
            strSQL = objReport.GetParamArray(objReportInfo.ProcedureName, Page)
            Dim strURL, strPath As String
            'AddAttributeChk()
            strPath = GetValueItem(Request, "PathReport", ConfigurationSettings.AppSettings("PathHSHC") & "GLOBAL.xml")
            strURL = "'" & objReportInfo.ReportName & "','" & strSQL & "','" & "Title" & "','" & objReportInfo.Title & "','" & "1" & "','" & strPath & "'"
            'strPath = Request.ApplicationPath & "/Reports/Reports/InPhieuChuyen.rpt"
            strPath = "D:/HSHC/Wip/SOURCE/HSHC/Reports/Reports/InPhieuChuyen.rpt"
            If Not IO.File.Exists(strPath) Then
                Throw (New Exception("Unable to locate report file:" & vbCrLf & strPath))
            End If
            Dim ds As New DataSet
            ds = DataProvider.Instance.ExecuteQueryStoreProcAuTo(objReportInfo.ProcedureName, Me)
            Dim cr As New ReportDocument
            cr.Load(strPath, OpenReportMethod.OpenReportByDefault)
            cr.SetDataSource(ds.Tables(0))
            CrystalReportViewer2.DisplayGroupTree = False
            CrystalReportViewer2.BorderStyle = BorderStyle.Solid
            CrystalReportViewer2.BestFitPage = True
            CrystalReportViewer2.ReportSource = cr
            CrystalReportViewer2.DataBind()






        End Sub


    End Class
End Namespace