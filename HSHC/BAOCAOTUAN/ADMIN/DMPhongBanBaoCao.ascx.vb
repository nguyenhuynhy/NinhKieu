Imports PortalQH

Public Class DMPhongBanBaoCao
    Inherits PortalQH.PortalModuleControl


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
    Protected WithEvents chkDonVi As System.Web.UI.WebControls.CheckBoxList

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
        If Not Me.IsPostBack Then
            initState()
            LoadData()
        End If
    End Sub


    Private Sub initState()
        BindControl.BindCheckBoxList(chkDonVi, "DMDONVI", , False)
    End Sub


    Private Sub LoadData()
        Dim ds As DataSet
        Dim i, j As Integer

        ds = DataProvider.Instance.ExecuteQueryStoreProc("sp_BCT_getPhongBanBaoCao")

        'Neu co data thi moi kiem tra check
        If ds.Tables.Count > 0 Then
            For j = 0 To chkDonVi.Items.Count - 1
                chkDonVi.Items(j).Selected = False
            Next
            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To chkDonVi.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(chkDonVi.Items(j).Value, String) Then
                        chkDonVi.Items(j).Selected = True
                    End If
                Next
            Next
        End If
    End Sub


    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Dim n, i As Integer
        Dim strTenDonVi As String = ""
        Dim strMaDonVi As String = ""

        n = chkDonVi.Items.Count
        For i = 0 To n - 1
            If chkDonVi.Items(i).Selected = True Then
                strMaDonVi = strMaDonVi + chkDonVi.Items(i).Value + ";"
                strTenDonVi = strTenDonVi + chkDonVi.Items(i).Text + ";"
            End If
        Next i
        If strMaDonVi = "" Then
            SetMSGBOX_HIDDEN(Page, "Không có dữ liệu cập nhật")
        Else
            DataProvider.Instance.ExecuteNonQueryStoreProc("sp_BCT_InsPhongBanBaoCao", strMaDonVi, strTenDonVi)
        End If
    End Sub
End Class
