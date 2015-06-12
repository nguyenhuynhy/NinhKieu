Namespace PortalQH
    Public MustInherit Class DanhMucList
        Inherits PortalQH.PortalModuleControl


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lstAnnouncements As System.Web.UI.WebControls.DataList
        Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList

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
                ' Obtain announcement information from Announcements table
                ' and bind to the datalist control
                Dim strTableName As String
                'Dim objDanhMuc As New DanhMucController

                ' DataBind Announcements to DataList Control
                'lstAnnouncements.DataSource = DanhMucList.GetDanhMucList("COMMONQH", "DMLOAIHOSO")
                'lstAnnouncements.DataBind()

                'DataGrid1.DataSource = objDanhMuc.GetDanhMucList(Page)
                'DataGrid1.DataBind()

                'strTableName = GetLoaiDanhMuc((CStr(TabId))
                'BindControl.BindDataGrid(objDanhMuc.GetDanhMucList(strTableName), DataGrid1, True, True, True, "STT", "Xóa", "S?a", -1, 500, 0, 500, 2, 2, 2, 2, 2, 2)
                'BindControl.BindDropDownList(DropDownList1, strTableName)
            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            Finally
            End Try
        End Sub
        Public Function FormatURL(ByVal Link As String, ByVal ID As Integer) As String

            'If InStr(1, Link, "://") = 0 Then
            '    If IsNumeric(Link) Then ' internal tab link
            '        Link = Global.ApplicationPath & "/DesktopDefault.aspx?tabid=" & Link
            '    End If
            'End If

            'Return Global.ApplicationPath & "/admin/Portal/LinkClick.aspx?tabid=" & TabId & "&table=Announcements&field=ItemID&id=" & ID.ToString & "&link=" & Server.UrlEncode(Link)

        End Function

    End Class
End Namespace