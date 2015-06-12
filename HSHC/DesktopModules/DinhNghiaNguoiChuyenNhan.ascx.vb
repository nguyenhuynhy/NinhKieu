Namespace PortalQH
    Public Class DinhNghiaNguoiChuyenNhan
        Inherits PortalQH.PortalModuleControl
        Private Shared TabCode As String
        Private Shared Loai As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThucHien As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlTabCode As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMaLinhVuc As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblHeader As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents chkNguoiChuyen As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkNguoiNhan As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lstNguoiSuDung As System.Web.UI.WebControls.CheckBoxList


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
                BindControl.BindDropDownList(ddlMaLinhVuc, "DMLINHVUC", , , 1)
                BindControl.BindCheckBoxList(lstNguoiSuDung, "sp_GetDanhMucCBO", "", GetCommonDB, "DMNGUOISUDUNG")
                BindControl.BindDropDownList(ddlTabCode, "sp_GetMenuTabListByLinhVuc", TabCode, ctype(Session.Item("ActiveDB"),string))
            End If
            TabCode = ddlTabCode.SelectedValue

            Loai = GetLoaiChuyenNhan()
            Select Case Loai
                Case "A"
                    chkNguoiChuyen.Checked = True
                    chkNguoiNhan.Checked = True
                Case "C"
                    chkNguoiChuyen.Checked = True
                    chkNguoiNhan.Checked = False
                Case "N"
                    chkNguoiChuyen.Checked = False
                    chkNguoiNhan.Checked = True
                Case Else
                    chkNguoiChuyen.Checked = False
                    chkNguoiNhan.Checked = False
            End Select
            
        End Sub
        Private Sub LoadNguoiChuyenNhan()
            If lstNguoiSuDung.Items.Count = 0 Then Exit Sub
            Dim i, j As Integer

            Dim ds As New DataSet
            Dim objNguoiChuyenNhanInfo As New NguoiChuyenNhanInfo
            Dim objNguoiChuyenNhan As New NguoiChuyenNhanController
            objNguoiChuyenNhanInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objNguoiChuyenNhanInfo.TabCode = ddlTabCode.SelectedValue
            objNguoiChuyenNhanInfo.Loai = Loai
            ds = objNguoiChuyenNhan.GetNguoiChuyenNhan(objNguoiChuyenNhanInfo)

            For j = 0 To lstNguoiSuDung.Items.Count - 1
                lstNguoiSuDung.Items(j).Selected = False
            Next

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To lstNguoiSuDung.Items.Count - 1
                    If CType(ds.Tables(0).Rows(i).Item(0), String) = CType(lstNguoiSuDung.Items(j).Value, String) Then
                        lstNguoiSuDung.Items(j).Selected = True
                    End If

                Next

            Next
        End Sub
        Private Sub CapNhatNguoiChuyenNhan(ByVal strLoai As String)

            Dim j As Integer
            Dim objNguoiChuyenNhanInfo As NguoiChuyenNhanInfo
            Dim objNguoiChuyenNhan As NguoiChuyenNhanController
            objNguoiChuyenNhanInfo = New NguoiChuyenNhanInfo
            objNguoiChuyenNhan = New NguoiChuyenNhanController
            objNguoiChuyenNhanInfo.TabCode = ddlTabCode.SelectedValue
            objNguoiChuyenNhanInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
            objNguoiChuyenNhanInfo.Loai = strLoai
            objNguoiChuyenNhan.DelNguoiChuyenNhan(objNguoiChuyenNhanInfo)
            For j = 0 To lstNguoiSuDung.Items.Count - 1
                If lstNguoiSuDung.Items(j).Selected Then
                    objNguoiChuyenNhanInfo = New NguoiChuyenNhanInfo
                    objNguoiChuyenNhan = New NguoiChuyenNhanController
                    objNguoiChuyenNhanInfo.TabCode = ddlTabCode.SelectedValue
                    objNguoiChuyenNhanInfo.ItemCode = "1"
                    objNguoiChuyenNhanInfo.MaLinhVuc = ddlMaLinhVuc.SelectedValue
                    objNguoiChuyenNhanInfo.Loai = strLoai
                    objNguoiChuyenNhanInfo.UserNane = lstNguoiSuDung.Items(j).Value
                    objNguoiChuyenNhan.AddNguoiChuyenNhan(objNguoiChuyenNhanInfo)
                End If
            Next
        End Sub

        



        Private Sub ddlTabCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTabCode.SelectedIndexChanged
            LoadNguoiChuyenNhan()
        End Sub
        Private Sub ddlMaLinhVuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaLinhVuc.SelectedIndexChanged
            LoadNguoiChuyenNhan()
        End Sub

        Private Sub chkNguoiChuyen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNguoiChuyen.CheckedChanged
            LoadNguoiChuyenNhan()
        End Sub

        Private Sub chkNguoiNhan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNguoiNhan.CheckedChanged
            LoadNguoiChuyenNhan()
        End Sub
        Private Function GetLoaiChuyenNhan() As String
            If chkNguoiChuyen.Checked And chkNguoiNhan.Checked Then
                Return "A"
            ElseIf chkNguoiChuyen.Checked Then
                Return "C"
            ElseIf chkNguoiNhan.Checked Then
                Return "N"
            Else
                Return ""
            End If

        End Function

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim strLoai As String = GetLoaiChuyenNhan()
            Select Case strLoai
                Case "A"
                    CapNhatNguoiChuyenNhan("C")
                    CapNhatNguoiChuyenNhan("N")
                Case "C", "N"
                    CapNhatNguoiChuyenNhan(strLoai)
                Case ""
            End Select
            LoadNguoiChuyenNhan()
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            LoadNguoiChuyenNhan()
        End Sub
    End Class
End Namespace