Imports PortalQH
Namespace CPKTQH
    Public Class KTThongTinTraCuu
        Inherits PortalQH.PortalModuleControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtHoTen As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoNha As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPhuong As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtBangHieu As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlTinhTrangHienTai As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtMatHang As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSoGiayPhep As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTuNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgTuNgay As System.Web.UI.WebControls.Image
        Protected WithEvents txtDenNgay As System.Web.UI.WebControls.TextBox
        Protected WithEvents imgDenNgay As System.Web.UI.WebControls.Image
        Protected WithEvents cmdTuNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents cmdDenNgay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents txtSoCMND As System.Web.UI.WebControls.TextBox

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
                SetAttributesControl()
                BindData()
                SetValues()
            End If
        End Sub

        Private Sub SetAttributesControl()
            txtTuNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtTuNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdTuNgay.NavigateUrl = AdminDB.InvokePopupCal(txtTuNgay)
            cmdTuNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtTuNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtTuNgay.ClientID & ");")
            txtTuNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")

            txtDenNgay.Attributes.Add("onblur", "javascript:CheckDateOnBlur(" & txtDenNgay.ClientID & ");checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            cmdDenNgay.NavigateUrl = AdminDB.InvokePopupCal(txtDenNgay)
            cmdDenNgay.Attributes.Add("onblur", "javascript:checkCompareDates(" & txtTuNgay.ClientID & "," & txtDenNgay.ClientID & ");")

            txtDenNgay.Attributes.Add("onkeyup", "javascript:getNow(" & txtDenNgay.ClientID & ");")
            txtDenNgay.Attributes.Add("onkeydown", "javascript:return CheckEnter();")
        End Sub

        Private Sub BindData()
            BindControl.BindDropDownList(ddlDuong, "DMDUONG")
            BindControl.BindDropDownList(ddlPhuong, "DMPHUONG")
            BindControl.BindDropDownList_StoreProc(ddlTinhTrangHienTai, True, "", "sp_DuongDiGiayPhep_GetTinhTrang", Request.Params("TabID"))

            Dim mSoNgay As Integer
            mSoNgay = getSoNgayLoc(Request)
            txtTuNgay.Text = Format(DateAdd(DateInterval.Day, mSoNgay - mSoNgay * 2, Now), "dd/MM/yyyy")
            txtDenNgay.Text = Format(Now, "dd/MM/yyyy")
        End Sub

        Public Sub SetValues()
            If Session("KTThongTinTraCuuInfo") Is Nothing Then
                Response.Redirect(Request.RawUrl())
            End If

            Dim objKTThongTinTraCuuInfo As KTThongTinTraCuuInfo
            objKTThongTinTraCuuInfo = CType(Session("KTThongTinTraCuuInfo"), KTThongTinTraCuuInfo)

            With objKTThongTinTraCuuInfo
                txtHoTen.Text = .HoTen
                txtSoNha.Text = .SoNha
                Try
                    ddlDuong.SelectedValue = .MaDuong
                Catch
                    ddlDuong.SelectedValue = ""
                End Try
                Try
                    ddlPhuong.SelectedValue = .MaPhuong
                Catch
                    ddlPhuong.SelectedValue = ""
                End Try
                txtBangHieu.Text = .BangHieu
                Try
                    ddlTinhTrangHienTai.SelectedValue = .TinhTrangGiayPhep
                Catch
                    ddlTinhTrangHienTai.SelectedValue = ""
                End Try
                txtSoGiayPhep.Text = .SoGiayPhep
                txtTuNgay.Text = .TuNgay
                txtDenNgay.Text = .DenNgay
                txtSoCMND.Text = .SoCMND
            End With
            objKTThongTinTraCuuInfo = Nothing
        End Sub

        Public Sub GetValues()
            If Session("KTThongTinTraCuuInfo") Is Nothing Then
                Response.Redirect(Request.RawUrl())
            End If
            Dim objKTThongTinTraCuuInfo As KTThongTinTraCuuInfo
            objKTThongTinTraCuuInfo = CType(Session("KTThongTinTraCuuInfo"), KTThongTinTraCuuInfo)
            With objKTThongTinTraCuuInfo
                .HoTen = Trim(txtHoTen.Text)
                .SoNha = Trim(txtSoNha.Text)
                .MaDuong = ddlDuong.SelectedValue
                .MaPhuong = ddlPhuong.SelectedValue
                .BangHieu = Trim(txtBangHieu.Text)
                .TinhTrangGiayPhep = ddlTinhTrangHienTai.SelectedValue
                .MatHangKinhDoanh = Trim(txtMatHang.Text)
                .SoGiayPhep = Trim(txtSoGiayPhep.Text)
                .TuNgay = Trim(txtTuNgay.Text)
                .DenNgay = Trim(txtDenNgay.Text)
                .SoCMND = Trim(txtSoCMND.Text)
            End With
            Session("KTThongTinTraCuuInfo") = objKTThongTinTraCuuInfo
        End Sub
    End Class
End Namespace