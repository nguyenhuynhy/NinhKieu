Imports PortalQH
Imports System.Configuration
Namespace HSHC
    Public Class ShowAttachFile
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents dgdUpload As System.Web.UI.WebControls.DataGrid
        Protected WithEvents txtHoSoTiepNhaID As System.Web.UI.WebControls.TextBox

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
            If Not Page.IsPostBack Then
                txtHoSoTiepNhaID.Text = Request.QueryString("HoSoTiepNhanID").ToString
                BindDG()
            End If
        End Sub
        Sub BindDG()
            Dim TiepNhanCon As New TiepNhanHoSoPhuongXaController
            Dim ds As DataSet
            ds = TiepNhanCon.GetDSFileDinhKemByHoSoTiepNhanID(txtHoSoTiepNhaID.Text)
            BindControl.BindDataGrid(ds, dgdUpload, ds.Tables(0).Rows.Count)

            dgdUpload.DataBind()

            'get toan van
            Dim ToanVanID As String = ""
            Dim ToanVanName As String = ""
            Dim i As Integer
            For i = 0 To dgdUpload.Items.Count - 1
                ToanVanID = ToanVanID + "," + dgdUpload.Items(i).Cells(0).Text
                ToanVanName = ToanVanName + "," + dgdUpload.Items(i).Cells(2).Text
            Next i

            If ToanVanID.Length > 0 Then
                ToanVanID = Right(ToanVanID, ToanVanID.Length - 1)
                ToanVanName = Right(ToanVanName, ToanVanName.Length - 1)
            End If
        End Sub
    End Class
End Namespace
