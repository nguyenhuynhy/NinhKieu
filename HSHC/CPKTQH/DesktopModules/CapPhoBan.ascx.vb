Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports PortalQH
Namespace CPKTQH
    Public Class CapPhoBan
        Inherits PortalQH.PortalModuleControl
        Private pID As String = ""
        Private strControl As String
        Protected WithEvents txtTenLinhVucCapPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGiayCNDKKDID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTenPhuongThucKinhDoanh As System.Web.UI.WebControls.TextBox
        Private Const strURL As String = "CPKTQH/DesktopModules/TimKiemGiayCNDKKD.aspx"

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtVonKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTienBangChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnHoSoKhong As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnYCBS As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnDeXuat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoLanCapPhoBan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDanhSachGP As System.Web.UI.WebControls.Label
        Protected WithEvents txtMaNguoiTacNghiep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTabCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaLinhVuc As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoSoTiepNhanID As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnIn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtGhiChu As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgNgayCapPhoBan As System.Web.UI.WebControls.Image
        Protected WithEvents txtNgayCapPhoBan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMatHangKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiThuongTru As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiaChiKinhDoanh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgayCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNgaySinh As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoBienNhan As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents txtReload As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnDanhSachGP As System.Web.UI.WebControls.LinkButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Các hàm sự kiện"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then

                SetAttribute()
                'BindControl.BindDropDownList(ddlMaHinhThucKinhDoanh, "DMHINHTHUCKINHDOANH")

                '--Get thong tin so bien nhan
                If Not Request.Params("ID") Is Nothing Then
                    txtHoSoTiepNhanID.Text = Request.Params("ID")
                    Dim objHoSoTiepNhan As New HoSoTiepNhanController
                    Dim ds As New DataSet
                    ds = objHoSoTiepNhan.GetChiTietHoSoTiepNhan(txtHoSoTiepNhanID.Text)
                    txtSoBienNhan.Text = ds.Tables(0).Rows(0).Item("SoBienNhan")
                    strControl = Request.Params("ctl")
                End If

                '--Get So giay phep cua so bien nhan
                GetSoGiayPhep()

                '--Lay Thong tin GiayCNDKKD neu co
                If Trim(txtSoGiayPhep.Text) <> "" Then 'Da co data
                    ViewState("isAddNew") = False
                    GetGiayCNDKKD()
                Else 'Chua co data
                    ViewState("isAddNew") = True

                End If
            End If

            hiddenAllButton()
            '--Cap nhat trang thai cac control
            If CBool(ViewState("isAddNew")) Then 'New la them moi
                If CheckHoSoBoSung(Request.Params("ID")) Then 'Neu la ho so da bo sung
                    btnYCBS.Visible = True
                    btnYCBS_Click(Nothing, Nothing)
                ElseIf CheckHoSoKhongGiaiQuyet(Request.Params("ID")) Then 'Neu la ho so khong giai quyet
                    btnHoSoKhong.Visible = True
                    btnHoSoKhong_Click(Nothing, Nothing)
                Else
                    btnHoSoKhong.Visible = True
                    btnYCBS.Visible = True
                    btnCapNhat.Visible = True
                End If

                lblDanhSachGP.Visible = False
                btnDanhSachGP.Visible = True
                txtSoGiayPhep.ReadOnly = False
            Else ' Neu la cap nhat
                If CheckHoSoDeXuat(Request.Params("ID")) Then 'Neu la ho so da de xuat
                    btnDeXuat.Visible = True
                    btnIn.Visible = True
                    btnCapNhat.Visible = True
                Else
                    btnDeXuat.Visible = True
                    btnCapNhat.Visible = True
                    btnXoa.Visible = True
                End If

                lblDanhSachGP.Visible = True
                btnDanhSachGP.Visible = False
                txtSoGiayPhep.ReadOnly = True
            End If
   
            'GetReportURL(Request.Params("TabId").ToString, CType(Session.Item("ItemCode"), String), "2", CType(Session.Item("ActiveDB"), String), btnIn, Me)
        End Sub

        Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim objCapPhoBan As New CapPhoBanController
            objCapPhoBan.UpdCapPhoBan(txtNgayCapPhoBan.Text.Replace("'", "''"), txtSoLanCapPhoBan.Text.Replace("'", "''"), txtGhiChu.Text.Replace("'", "''"), txtSoBienNhan.Text.Replace("'", "''"), txtSoGiayPhep.Text.Replace("'", "''"), Session.Item("UserName").ToString())

            ViewState("isAddNew") = False
            '-----------------------Cap nhat trang thai cac nut------------
            lblDanhSachGP.Visible = True
            btnDanhSachGP.Visible = False
            txtSoGiayPhep.ReadOnly = True

            btnXoa.Visible = Not CBool(ViewState("isAddNew"))
            btnDeXuat.Visible = btnXoa.Visible
            btnIn.Visible = btnXoa.Visible
            btnHoSoKhong.Visible = Not btnXoa.Visible
            btnYCBS.Visible = Not btnXoa.Visible

            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub btnDanhSach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect(EditURL("LoaiHoSo", Request.Params("ctl") & "&AddNew=" & Request.Params("AddNew")), True)
        End Sub
        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objCapPhoBan As New CapPhoBanController
            objCapPhoBan.DelCapPhoBan(txtSoGiayPhep.Text.Replace("'", "''"), txtSoLanCapPhoBan.Text.Replace("'", "''"))
            objCapPhoBan = Nothing

            Response.Redirect(Request.RawUrl())
        End Sub
        Private Sub btnDeXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeXuat.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            If strSoBienNhan <> "" And Not CheckBoSungHoSo(strSoBienNhan) Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "DEXUAT") & "&Loai=DX&oldControl=" & Request.Params("ctl") & "& SoGiayPhep=" & txtSoGiayPhep.Text, True)
            End If
        End Sub
        Private Sub btnYCBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYCBS.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtSoBienNhan.Text
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "YEUCAUBOSUNG") & "&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub
        Private Sub btnHoSoKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKhong.Click
            Dim strSoBienNhan As String
            strSoBienNhan = txtHoSoTiepNhanID.Text
            If strSoBienNhan <> "" Then
                Response.Redirect(EditURL("ID", strSoBienNhan, "HOSOKHONG") & "&oldControl=" & Request.Params("ctl"), True)
            End If
        End Sub

        Private Sub txtSoGiayPhep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoGiayPhep.TextChanged
            GetGiayCNDKKD()
        End Sub
        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Try

                Response.Redirect(NavigateURL(), True)

            Catch exc As Exception 'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn.Click
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As New DataSet
            Dim Script As String
            Dim strTemplateFileName As String
            Dim strOutputFileName As String

            strTemplateFileName = GetParamByID("FileGiayCNDKKD", glbXMLFile)
            strOutputFileName = "GiayCNDKKD" & "_" & CType(Session.Item("UserName"), String) & "_" & Format(Now(), "yyMMddhhmmss") & ".doc"

            ds = objGiayCNDKKD.InGiayCNDKKD(txtGiayCNDKKDID.Text, True)
            Script = String.Format("<script language='javascript'>window.open('{0}', '_blank');</script>", f_ExportWordFile(Request, ds, GetLinhVuc(), strTemplateFileName, strOutputFileName))
            Page.RegisterStartupScript("OpenWindow", Script)

            objGiayCNDKKD = Nothing
            ds = Nothing
        End Sub
#End Region

#Region "Các hàm hỗ trợ"
        Public Sub SetAttribute()
            txtNgayCapPhoBan.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapPhoBan);")
            Me.txtNgayCapPhoBan.Attributes.Add("onkeyup", "javascript:getNow(" & txtNgayCapPhoBan.ClientID & ");")
            Me.txtNgayCapPhoBan.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            imgNgayCapPhoBan.Attributes.Add("onclick", "javascript:popUpCalendar(this," & Replace(Me.UniqueID, ":", "_") & "_txtNgayCapPhoBan, 'dd/mm/yyyy');")
            btnDanhSachGP.Attributes.Add("onclick", "javascript:CallWindow('" & strURL & "','Application');")
            btnCapNhat.Attributes.Add("onclick", "return btnCapNhat_clicked()")
            btnXoa.Attributes.Add("onclick", "return confirm('Ban co chac muon xoa ?')")
            '==============================================================================================='
            txtMaLinhVuc.Text = Request.Params("Malv")
            txtMaNguoiTacNghiep.Text = Session.Item("UserName").ToString()
            txtTabCode.Text = Request.Params("TabID")

        End Sub

        Private Function CheckHoSoDeXuat(ByVal strID As String) As Boolean
            Dim objHoSoThamDinh As New ThamDinhDeXuatController
            CheckHoSoDeXuat = objHoSoThamDinh.CheckKiemTraDeXuat(strID)
        End Function
        Private Function CheckHoSoBoSung(ByVal strID As String) As Boolean
            Dim objHoSoThamDinh As New ThamDinhDeXuatController
            Return objHoSoThamDinh.CheckKiemTraBoSung(strID)
        End Function
        Private Function CheckHoSoKhongGiaiQuyet(ByVal strID As String) As Boolean
            Dim objHoSoThamDinh As New ThamDinhDeXuatController
            Return objHoSoThamDinh.CheckKiemTraKhongGiaiQuyet(strID)
        End Function
        Private Sub hiddenAllButton()
            btnCapNhat.Visible = False
            btnXoa.Visible = False
            btnDeXuat.Visible = False
            btnHoSoKhong.Visible = False
            btnYCBS.Visible = False
            btnIn.Visible = False
        End Sub
#End Region

#Region "Các hàm dữ liệu"

        Private Sub GetSoGiayPhep()
            'Get so giay phep tu so bien nhan tu table CapPhoBan
            Dim objCapPhoBan As New CapPhoBanController
            txtSoGiayPhep.Text = objCapPhoBan.getSoGiayPhep(txtSoBienNhan.Text)
        End Sub


        Private Sub GetGiayCNDKKD()
            'Get thong tin GiayCNDKKD tu SoGiayPhep
            Dim objGiayCNDKKD As New GiayCNDKKDController
            Dim ds As DataSet

            '--Get thong tin GCNDKKD
            ds = objGiayCNDKKD.GetGiayCNDKKDBySoGiayPhep(txtSoGiayPhep.Text.Replace("'", "''"))
            If ds.Tables(0).Rows.Count > 0 Then 'Co data
                gLoadControlValues(ds, Me)

                '--Get so lan da cap pho ban va ngay cap pho ban cua GCNDKKD nay
                Dim objCapPhoBan As New CapPhoBanController
                ViewState("SoLanCapPhoBan") = objCapPhoBan.getSoLanCapPhoBan(txtSoGiayPhep.Text)
                If CBool(ViewState("isAddNew")) Then
                    txtSoLanCapPhoBan.Text = (CInt(ViewState("SoLanCapPhoBan")) + 1).ToString()
                Else
                    txtSoLanCapPhoBan.Text = ViewState("SoLanCapPhoBan")
                End If
                '---Load ngay cap pho ban
                Dim dsThongTin As New DataSet
                dsThongTin = objCapPhoBan.getThongTinCapPhoBan(txtSoGiayPhep.Text, txtSoLanCapPhoBan.Text)
                If dsThongTin.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(dsThongTin.Tables(0).Rows(0).Item("GhiChu")) Then
                        txtGhiChu.Text = CStr(dsThongTin.Tables(0).Rows(0).Item("GhiChu"))
                    End If

                    txtNgayCapPhoBan.Text = Format(dsThongTin.Tables(0).Rows(0).Item("NgayCapPhoBan"), "dd/MM/yyyy")
                Else
                    txtNgayCapPhoBan.Text = Format(Now(), "dd/MM/yyyy")
                    txtGhiChu.Text = ""
                End If
            Else
                '--Neu khong co du lieu thi` clear all textbox
                Dim strMid As String = Request.QueryString("mid")
                Dim strCtl As String = Request.QueryString("ctl")
                Dim strID As String = Request.QueryString("ID")
                Dim strMaLV As String = Request.QueryString("Malv")
                Dim strTenLV As String = Request.QueryString("Tenlv")
                Dim strAddNew As String = Request.QueryString("AddNew")
                Dim strURL As String = ApplicationURL()

                strURL += "&mid=" + strMid + "&ctl=" + strCtl + "&ID=" + strID + "&Malv=" + strMaLV + "&Tenlv=" + strTenLV + "&AddNew=" + strAddNew
                Response.Redirect(strURL)

            End If



        End Sub
        Private Function CheckBoSungHoSo(ByVal strSoBienNhan As String) As Boolean
            If strSoBienNhan = "" Then Exit Function
            Dim objHoSoBoSung As New HSHC.HoSoBoSungController
            Dim dv As New DataView
            dv = objHoSoBoSung.GetHoSoBoSungBySoBienNhan(strSoBienNhan).Tables(0).DefaultView
            If dv.Count > 0 Then
                If dv.Item(0).Item("HoSoBoSungID").ToString <> "" Then
                    SetMSGBOX_HIDDEN(Page, "Ho so dang yeu cau bo sung!")
                    Return True
                Else
                    Return False
                End If
            End If
        End Function
#End Region

     
    End Class

End Namespace
