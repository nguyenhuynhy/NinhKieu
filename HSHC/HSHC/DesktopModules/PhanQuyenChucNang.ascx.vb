
Namespace PortalQH
    Public Class PhanQuyenChucNang
        Inherits PortalQH.PortalModuleControl
        Private iSelectItemCode As Integer
        Protected WithEvents ddlTab As System.Web.UI.WebControls.DropDownList
        Protected WithEvents grdPhanQuyen As System.Web.UI.WebControls.DataGrid
        Private iPortalID As Integer
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblMenu As System.Web.UI.WebControls.Label
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton

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
            If Not Request.Params("SelectItemCode") Is Nothing Then
                iSelectItemCode = CInt(Request.Params("SelectItemCode"))
            Else
                iSelectItemCode = -10
            End If
            If Not Page.IsPostBack Then
                iPortalID = CType(DataCache.GetCache("PortalID"), Int32)
                If iSelectItemCode <> -10 Then
                    BindControl.BindDropDownList_StoreProc(ddlTab, False, CType(iSelectItemCode, String), "sp_GetMenuTabList", iPortalID, ctype(Session.Item("ActiveDB"),string))
                Else
                    BindControl.BindDropDownList_StoreProc(ddlTab, False, "", "sp_GetMenuTabList", iPortalID, ctype(Session.Item("ActiveDB"),string))
                    iSelectItemCode = CInt(ddlTab.SelectedValue)
                End If
                LoadGrid(iSelectItemCode)
            End If
        End Sub
        Private Sub LoadGrid(ByVal iSelectItemCode As Integer)
            Dim ds As New DataSet
            Dim objPhanQuyen As New PhanQuyenChucNangController
            ds = objPhanQuyen.GetItemChucNang(iSelectItemCode)
            BindControl.BindDataGrid(ds, grdPhanQuyen, ds.Tables(0).Rows.Count)
            ds = Nothing
            lblMenu.Text = ".:: " & UCase(ddlTab.SelectedItem.Text) & " ::."
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim strURL As String
            strURL = "~/Default.aspx?tabid=" & Request.Params("tabid") & "&SelectItemCode=" & ddlTab.SelectedValue
            Response.Redirect(strURL, True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim chkChon As CheckBox
            Dim objPhanQuyen As New PhanQuyenChucNangController
            Dim flgCheck As String
            Dim i As Integer
            For i = 0 To grdPhanQuyen.Items.Count - 1
                chkChon = CType(Me.grdPhanQuyen.Items(i).FindControl("chkChon"), CheckBox)
                If chkChon.Checked = True Then
                    flgCheck = "1"
                Else
                    flgCheck = "0"
                End If
                objPhanQuyen.UpdIsCheckUser(CInt(CType(Me.grdPhanQuyen.Items(i).FindControl("lblTabCode"), Label).Text), CType(Me.grdPhanQuyen.Items(i).FindControl("lblItemCode"), Label).Text, flgCheck)
            Next
        End Sub
    End Class
End Namespace

