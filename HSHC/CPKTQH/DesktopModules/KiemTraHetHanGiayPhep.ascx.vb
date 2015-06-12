Imports PortalQH
Namespace CPKTQH
    Public Class KiemTraHetHanGiayPhep
        Inherits PortalQH.PortalModuleControl

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
            If Not Page.IsPostBack Then
                'ngày hiện tại đã kiểm tra hết hạn giấy phép chưa
                If glbNgayKiemTraHetHanGiayPhep <> Format(Now, "dd/MM/yyyy") Then
                    glbNgayKiemTraHetHanGiayPhep = Format(Now, "dd/MM/yyyy")

                    Dim strNgayKiemTraCuoiCung As String
                    strNgayKiemTraCuoiCung = GetParamValue("", "NgayHetHanGiayPhep")
                    If strNgayKiemTraCuoiCung <> Format(Now, "dd/MM/yyyy") Then
                        Dim objGiayCNDKKD As New GiayCNDKKDController
                        objGiayCNDKKD.KiemTraHetHanGiayPhep()
                        objGiayCNDKKD = Nothing
                    End If
                End If
            End If
        End Sub

    End Class
End Namespace