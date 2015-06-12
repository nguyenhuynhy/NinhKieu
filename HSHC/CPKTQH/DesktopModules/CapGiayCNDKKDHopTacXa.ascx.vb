'Option Strict Off
Imports System.Xml
Imports System.Configuration
Imports System.Net
Imports System.IO
Imports PortalQH
Namespace CPKTQH
    Public Class CapGiayCNDKKDHopTacXa
        'Created NganTL
        'Descr : Cap moi va cap doi giay CNDKKD
        'Date by 03/11/2004
        Inherits PortalQH.PortalModuleControl
        Private pID As String = ""
        Private strControl As String
        Protected WithEvents btnCapNhat As System.Web.UI.WebControls.LinkButton
        Protected WithEvents btnThemMoi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ctlTab As CPKTQH.TabStrip
        Protected WithEvents cMsg As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents pnlNoiDungDKKD As System.Web.UI.WebControls.Panel
        Protected WithEvents pnlNguoiDungDau As System.Web.UI.WebControls.Panel
        Protected WithEvents pnlDanhSachXaVien As System.Web.UI.WebControls.Panel
        Protected WithEvents btnBoQua As System.Web.UI.WebControls.LinkButton
        Protected WithEvents hMsg As System.Web.UI.HtmlControls.HtmlInputHidden


        Protected WithEvents txtGiayCNDKKDHTXID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaSoNguoiSuDung As System.Web.UI.WebControls.TextBox
        Protected WithEvents ctlTTCN As ThongTinCaNhan  'Thong tin chu nhiem
        Protected WithEvents ctlTTXV As ThongTinDanhSachXaVien 'Thong tin xa vien
        Protected WithEvents btnXoa As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ctlTTGP As ThongTinSoGiayPhep 'THong tin so giay phep


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents txtNoiCap As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDienThoai As System.Web.UI.WebControls.TextBox

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
            If Not Page.IsPostBack Then
                If Not Request.Params("ID") Is Nothing Then
                    txtGiayCNDKKDHTXID.Text = CStr(Request.Params("ID"))
                End If
                initState()

                If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                    txtGiayCNDKKDHTXID.Text = ""
                    btnThemMoi.Visible = False
                End If

                If txtGiayCNDKKDHTXID.Text <> "" Then
                    btnXoa.Visible = True
                Else
                    btnXoa.Visible = False
                End If
            End If
        End Sub
        Private Sub initState()
            If Not Session.Item("Username") Is Nothing Then
                txtMaSoNguoiSuDung.Text = CStr(Session.Item("Username"))
            End If
            btnXoa.Attributes.Add("onclick", "return confirm('Ban co chac chan muon xoa thong tin nay khong?');")

            'btnCapNhat.Attributes.Add("onclick", "javascript:return CheckCapNhat()")
        End Sub
        Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
            Dim strLoi As String
            strLoi = KiemTraDuLieuNhap(ctlTTCN, ctlTTGP, ctlTTXV)
            If strLoi <> "" Then
                SetMSGBOX_HIDDEN(Page, strLoi)
                Return
            End If

            Dim objTTCN As New XaVienInfo 'thong tin chu nhiem
            Dim objTTGP As New GiayPhepHopTacXaInfo 'thong tin so giay phep
            getThongTinChuNhiem(objTTCN)
            getThongTinGiayPhep(objTTGP)
            Dim dtThongTinXaVien As DataTable
            dtThongTinXaVien = ctlTTXV.getDTThongTinXaVien()

            Dim HopTacXaCon As New HopTacXaController
            Dim strGiayCNDKKDHTXID As String

            'truong hop cap doi
            If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                strGiayCNDKKDHTXID = HopTacXaCon.updCapDoiGiayCNDKKDHTX(txtGiayCNDKKDHTXID.Text, ctlTTGP.getGiayPhepTruoc(), txtMaSoNguoiSuDung.Text, objTTGP, objTTCN, dtThongTinXaVien)
            Else
                strGiayCNDKKDHTXID = HopTacXaCon.updGiayCNDKKDHTX(txtGiayCNDKKDHTXID.Text, txtMaSoNguoiSuDung.Text, objTTGP, objTTCN, dtThongTinXaVien)
            End If

            If strGiayCNDKKDHTXID = "1" Then
                SetMSGBOX_HIDDEN(Page, "Cap nhat khong thanh cong")
                Return
            Else
                If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                    If txtGiayCNDKKDHTXID.Text = "" Then
                        ctlTTGP.SoLanCapDoi = (CInt(ctlTTGP.SoLanCapDoi) + 1).ToString
                    End If
                End If
                txtGiayCNDKKDHTXID.Text = strGiayCNDKKDHTXID
            End If

            If ctlTTGP.SoLanCapDoi = "" Then
                ctlTTGP.SoLanCapDoi = "0"
            End If
            If ctlTTGP.SoLanThayDoi = "" Then
                ctlTTGP.SoLanThayDoi = "0"
            End If
            If ctlTTGP.SoLanCapPhoBan = "" Then
                ctlTTGP.SoLanCapPhoBan = "0"
            End If

            'su dung viewstate de kiem tra trung du lieu
            ViewState.Item("SoGiayPhepSS") = ctlTTGP.SoGiayPhep

            'btnXOa
            If txtGiayCNDKKDHTXID.Text <> "" Then
                btnXoa.Visible = True
            Else
                btnXoa.Visible = False
            End If
        End Sub
        Private Function KiemTraDuLieuNhap(ByVal TTCN As ThongTinCaNhan, ByVal TTGP As ThongTinSoGiayPhep, ByVal TTXV As ThongTinDanhSachXaVien) As String
            Dim strLoi As String = ""
            'TTGP
            If TTGP.SoGiayPhep.Trim = "" Then
                strLoi = "Chua nhap So giay phep"
                Return strLoi
            End If
            If TTGP.NgayCap.Trim = "" Then
                strLoi = "Chua nhap So giay phep"
                Return strLoi
            End If
            If TTGP.BangHieu.Trim = "" Then
                strLoi = "Chua nhap Bang hieu"
                Return strLoi
            End If
            If TTGP.MaLinhVucCapPhep.Trim = "" Then
                strLoi = "Chua nhap Linh vuc cap phep"
                Return strLoi
            End If
            'If TTGP.MaHinhThucKinhDoanh.Trim = "" Then
            '    strLoi = "Chua nhap Hinh thuc kinh doanh"
            '    Return strLoi
            'End If
            If TTGP.MaNganhKinhDoanh.Trim = "" Then
                strLoi = "Chua nhap Nganh kinh doanh"
                Return strLoi
            End If
            If TTGP.MatHangKinhDoanh.Trim = "" Then
                strLoi = "Chua nhap Mat hang kinh doanh"
                Return strLoi
            End If
            If TTGP.VonKinhDoanh.Trim = "" Then
                strLoi = "Chua nhap Von kinh doanh"
                Return strLoi
            End If
            If TTGP.SoNha.Trim = "" Then
                strLoi = "Chua nhap So nha"
                Return strLoi
            End If
            'If TTGP.MaDuong.Trim = "" Then
            '    strLoi = "Chua nhap Duong"
            '    Return strLoi
            'End If
            If TTGP.MaPhuong.Trim = "" Then
                strLoi = "Chua nhap Phuong"
                Return strLoi
            End If
            If TTGP.SoGiayPhepGoc.Trim = "" Then TTGP.SoGiayPhepGoc = TTGP.SoGiayPhep
            If TTGP.SoGiayPhepTruoc.Trim = "" Then TTGP.SoGiayPhepTruoc = TTGP.SoGiayPhep
            If TTGP.NgayCapGoc.Trim = "" Then TTGP.NgayCapGoc = TTGP.NgayCap
            If TTGP.NgayCapTruoc.Trim = "" Then TTGP.NgayCapTruoc = TTGP.NgayCap

            'TTCN
            If TTCN.HoTen = "" Then
                strLoi = "Chua nhap Ho ten chu nhiem"
                Return strLoi
            End If
            If TTCN.NgaySinh = "" Then
                strLoi = "Chua nhap Ngay sinh chu nhiem"
                Return strLoi
            End If
            If TTCN.SoCMND = "" Then
                strLoi = "Chua nhap So CMND chu nhiem"
                Return strLoi
            End If
            If TTCN.DiaChiThuongTru = "" Then
                strLoi = "Chua nhap Dia chi thuong tru chu nhiem"
                Return strLoi
            End If

            'ThanhVien
            If TTXV.getDTThongTinXaVien() Is Nothing Then
                strLoi = "Chua nhap Thanh vien cua Hop tac xa"
                Return strLoi
            End If
            If TTXV.getDTThongTinXaVien.Rows.Count = 0 Then
                strLoi = "Hop tac xa phai co it nhat 1 thanh vien"
                Return strLoi
            End If

            'Kiem tra trung so giay phep
            Dim HopTacXaCon As New HopTacXaController
            If ViewState.Item("SoGiayPhepSS") Is Nothing Then
                ViewState.Item("SoGiayPhepSS") = TTGP.getGiayPhepTruoc
            End If

            If txtGiayCNDKKDHTXID.Text = "" And CStr(ViewState.Item("SoGiayPhepSS")) = TTGP.SoGiayPhep Then
                strLoi = "So giay phep da ton tai"
                Return strLoi
            End If

            If CStr(ViewState.Item("SoGiayPhepSS")) <> TTGP.SoGiayPhep Then
                If HopTacXaCon.checkSoGiayPhepHTX(TTGP.SoGiayPhep) Then
                    strLoi = "So giay phep da ton tai"
                    Return strLoi
                End If
            End If

            Return strLoi
        End Function
        Private Sub getThongTinChuNhiem(ByRef objTTCN As XaVienInfo)
            objTTCN.HoTen = ctlTTCN.HoTen
            objTTCN.GioiTinh = ctlTTCN.GioiTinh
            objTTCN.NgaySinh = ctlTTCN.NgaySinh
            objTTCN.DanToc = ctlTTCN.DanToc
            objTTCN.SoCMND = ctlTTCN.SoCMND
            objTTCN.NoiCapCMND = ctlTTCN.NoiCapCMND
            objTTCN.NgayCapCMND = ctlTTCN.NgayCapCMND
            objTTCN.DiaChiThuongTru = ctlTTCN.DiaChiThuongTru
            objTTCN.ChoOHienNay = ctlTTCN.ChoOHienNay
        End Sub
        Private Sub getThongTinGiayPhep(ByRef objTTGP As GiayPhepHopTacXaInfo)
            objTTGP.SoBienNhan = ctlTTGP.SoBienNhan
            objTTGP.SoGiayPhep = ctlTTGP.SoGiayPhep
            objTTGP.BangHieu = ctlTTGP.BangHieu
            objTTGP.MaLinhVucCapPhep = ctlTTGP.MaLinhVucCapPhep
            'objTTGP.MaHinhThucKinhDoanh = ctlTTGP.MaHinhThucKinhDoanh
            objTTGP.MaNganhKinhDoanh = ctlTTGP.MaNganhKinhDoanh
            objTTGP.MatHangKinhDoanh = ctlTTGP.MatHangKinhDoanh
            objTTGP.VonKinhDoanh = ctlTTGP.VonKinhDoanh
            objTTGP.NgayCap = ctlTTGP.NgayCap
            objTTGP.SoNha = ctlTTGP.SoNha
            objTTGP.MaDuong = ctlTTGP.MaDuong
            objTTGP.MaPhuong = ctlTTGP.MaPhuong
            objTTGP.DiaChiCu = ctlTTGP.DiaChiCu
            objTTGP.DienThoai = ctlTTGP.DienThoai
            objTTGP.Fax = ctlTTGP.Fax
            objTTGP.Email = ctlTTGP.Email
            objTTGP.Website = ctlTTGP.Website
            objTTGP.SoLanCapDoi = ctlTTGP.SoLanCapDoi
            objTTGP.SoLanThayDoi = ctlTTGP.SoLanThayDoi
            objTTGP.SoLanCapPhoBan = ctlTTGP.SoLanCapPhoBan
            objTTGP.GhiChu = ctlTTGP.GhiChu
            objTTGP.NguoiKy = ctlTTGP.NguoiKy
            objTTGP.SoGiayPhepGoc = ctlTTGP.SoGiayPhepGoc
            objTTGP.NgayCapGoc = ctlTTGP.NgayCapGoc
            objTTGP.SoGiayPhepTruoc = ctlTTGP.SoGiayPhepTruoc
            objTTGP.NgayCapTruoc = ctlTTGP.NgayCapTruoc

        End Sub


        Private Sub btnBoQua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Sub btnThemMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemMoi.Click
            Response.Redirect(EditURL(, , "CAPMOICNDKKD"))
        End Sub
        Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
            Dim objHopTacXaCon As New HopTacXaController
            Dim strResult As String
            If CStr(Request.Params("ctl")) = "CAPDOICNDKKD" Then
                strResult = objHopTacXaCon.DelCapDoiHopTacXa(txtGiayCNDKKDHTXID.Text)
                If strResult = "1" Then
                    SetMSGBOX_HIDDEN(Page, "Xoa khong thanh cong")
                    Return
                End If
                Response.Redirect(Request.RawUrl())
            Else
                strResult = objHopTacXaCon.DelHopTacXa(txtGiayCNDKKDHTXID.Text)
                If strResult = "1" Then
                    SetMSGBOX_HIDDEN(Page, "Xoa khong thanh cong")
                    Return
                End If
                Response.Redirect(EditURL(, , "CAPMOICNDKKD"))
            End If
        End Sub
    End Class


End Namespace
