Option Strict Off
Namespace PortalQH
    Public Class PhanQuyenUser
        Inherits PortalQH.PortalModuleControl

        Private iPortalID As Integer
        Private iSelectItemCode As Integer
        Private iSelectUserIndex As Integer
        Private iSelectUserID As String
        Private iSelectUserName As String
        Protected WithEvents MenuList_User As MenuList
        Protected WithEvents grdPhanQuyen As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblMenu As System.Web.UI.WebControls.Label
        Protected WithEvents ddlTab As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnCapNhatChucNang As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnBoQuaChucNang As System.Web.UI.WebControls.LinkButton
        Protected WithEvents NhapMoiChucNang1 As NhapMoiChucNang


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
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
            Try
                iSelectUserID = CStr(Request.Params("SelectID"))
                iSelectUserName = CStr(Request.Params("SelectTitle"))
                iSelectItemCode = CInt(Request.Params("SelectItemCode"))

                iSelectUserIndex = CInt(Request.Params("SelectIndex"))

                If Request.Params("SelectItemCode") = "" Then
                    iSelectItemCode = -10
                    iSelectUserIndex = 0
                End If
                If Not Page.IsPostBack Then
                    iPortalID = CType(DataCache.GetCache("PortalID"), Int32)
                    If iSelectItemCode <> -10 Then
                        BindControl.BindDropDownList_StoreProc(ddlTab, False, CType(iSelectItemCode, String), "sp_GetMenuTabList", iPortalID, ctype(Session.Item("ActiveDB"),string))
                    Else
                        BindControl.BindDropDownList_StoreProc(ddlTab, False, "", "sp_GetMenuTabList", iPortalID, ctype(Session.Item("ActiveDB"),string))
                        iSelectItemCode = CInt(ddlTab.SelectedValue)
                    End If

                    If iSelectUserIndex = 0 Then
                        LoadUserDefault()
                    Else
                        iSelectUserID = CStr(Request.Params("SelectID"))
                        iSelectUserName = CStr(Request.Params("SelectTitle"))
                    End If
                    LoadGrid()
                End If
                MenuList_User.iSelectIndex = iSelectUserIndex
                MenuList_User.iSelectItemCode = iSelectItemCode

                Radio_Check()
                btnCapNhatChucNang.Attributes.Add("onclick", "javascript:return CheckNull();")
            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try
        End Sub


     

        Private Sub LoadUserDefault()
            Dim objMenuListInfo As New MenuListInfo
            Dim objMenuListCtrl As New MenuListController
            Dim dr As DataRowView
            dr = objMenuListCtrl.getTopUserList(objMenuListInfo)
            iSelectUserID = dr.Item("Ma").ToString
            iSelectUserName = dr.Item("title").ToString
        End Sub

        Private Sub LoadGrid()
            Dim ds As New DataSet
            Dim menucontrol As New MenuListController
            Dim menuinfo As New MenuListInfo
            menuinfo.TabID = iSelectItemCode
            menuinfo.UserID = iSelectUserID

            ds = menucontrol.GetItemUserList(menuinfo)
            BindControl.BindDataGrid(ds, grdPhanQuyen, ds.Tables(0).Rows.Count)
            ds = Nothing

            lblMenu.Text = ".:: " & UCase(ddlTab.SelectedItem.Text) & " ::."
            lblHeader.Text = ".:: User: " & iSelectUserName & " ::."
        End Sub

        Private Sub Radio_Check()
            Dim item As DataGridItem

            For Each item In Me.grdPhanQuyen.Items
                Dim rd As New RadioButton
                rd = item.FindControl("radDefault")
                rd.Attributes.Add("OnClick", "javascript:DefaultChange(" + rd.ClientID + ");")

                Dim cb As New CheckBox
                cb = item.FindControl("chkChon")
                cb.Attributes.Add("OnClick", "javascript:ChonChange(" + cb.ClientID + ");")
            Next

        End Sub

        Private Function KiemTraCapNhat() As Boolean
            Dim i As Integer
            Dim strItemID As String
            strItemID = NhapMoiChucNang1.GetItemID
            For i = 0 To grdPhanQuyen.Items.Count - 1
                If strItemID = CType(grdPhanQuyen.Items(i).Cells(1).FindControl("lblItemCode"), Label).Text Then
                    Return False
                End If
            Next
            Return True
        End Function

        Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Dim strURL As String
            strURL = "~/Default.aspx?tabid=" & Request.Params("tabid") & "&SelectItemCode=" & ddlTab.SelectedValue & "&SelectIndex=0"
            Response.Redirect(strURL, True)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim chkChon As CheckBox
            Dim radDefault As RadioButton
            Dim lblMenuID As Label
            Dim i As Integer
            Dim objPhanQuyenUserInfo As New PhanQuyenUserInfo
            Dim objPhanQuyenUserCtrl As New PhanQuyenUserController

            If iSelectItemCode = -10 Then
                iSelectItemCode = ddlTab.SelectedValue
            End If
            If iSelectUserIndex = 0 Then
                LoadUserDefault()
            End If

            'xoá phân quyền user cũ ứng với tab này
            objPhanQuyenUserInfo.TabID = iSelectItemCode
            objPhanQuyenUserInfo.UserID = iSelectUserID
            objPhanQuyenUserCtrl.DeleteMenuUser(objPhanQuyenUserInfo)

            'thêm phân quyền user mới
            For i = 0 To grdPhanQuyen.Items.Count - 1
                chkChon = Me.grdPhanQuyen.Items(i).FindControl("chkChon")
                If chkChon.Checked = True Then
                    lblMenuID = Me.grdPhanQuyen.Items(i).FindControl("lblMa")
                    radDefault = Me.grdPhanQuyen.Items(i).FindControl("radDefault")
                    objPhanQuyenUserInfo.MenuID = lblMenuID.Text
                    objPhanQuyenUserInfo.UserID = iSelectUserID
                    objPhanQuyenUserInfo.DefaultItemCode = IIf(radDefault.Checked, 1, 0)
                    objPhanQuyenUserCtrl.AddMenuUser(objPhanQuyenUserInfo)
                End If
            Next
            Dim strURL As String
        End Sub

        Private Sub btnBoQuaChucNang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQuaChucNang.Click
            NhapMoiChucNang1.ResetData()
        End Sub

        Private Sub btnCapNhatChucNang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhatChucNang.Click
            If Not KiemTraCapNhat() Then
                SetMSGBOX_HIDDEN(Page, "Loai ho so nay da ton tai!")
                Exit Sub
            End If
            SetControlValues("txtTabCode", ddlTab.SelectedValue, NhapMoiChucNang1)
            NhapMoiChucNang1.CapNhatChucNang()
            Dim strURL As String

            Dim intSelectIndex As Integer
            If CStr(Request.Params("SelectIndex")) Is Nothing Then
                intSelectIndex = 0
            Else
                intSelectIndex = Request.Params("SelectIndex")
            End If
            strURL = "~/Default.aspx?tabid=" & Request.Params("tabid") & "&SelectItemCode=" & ddlTab.SelectedValue & "&SelectIndex=0"
            Response.Redirect(strURL, True)
        End Sub
    End Class
End Namespace