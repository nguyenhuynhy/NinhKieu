<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThayDoiKinhDoanh.ascx.vb" Inherits="CPKTQH.ThayDoiKinhDoanh" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript src='<%= ResolveUrl("~/Inc/Common.js")%>'></script>
<script language=javascript src='<%= ResolveUrl("~/Inc/popcalendar.js")%>'></script>
<script language="javascript">

function btnCapNhat_clicked()
{
	var txtSoGiayPhep = document.all("<%=txtSoGiayPhep.clientID%>")
	if (txtSoGiayPhep.value=="")
	{
		alert("Chua chon So giay CNDKKD");
		return false;
	}

	var ddlMaSoLanhDao = document.all("<%=ddlMaSoLanhDaoMoi.clientID%>");
	if (ddlMaSoLanhDao.value=="")
	{
		alert("Chua chon lanh dao");
		return false;
	}
	var isAddNew = '<%=ViewState("isAddNew")%>';
	if (isAddNew=='True')
	{	
		
		var AllConTrols = document.getElementsByTagName("input");
		var i
		for (i=0;i<AllConTrols.length;i++)
		{
			if (AllConTrols[i].type =='checkbox')
				if (AllConTrols[i].checked)
					return true;
		}
		alert("Chua chon truong thay doi noi dung");
		return false;
	}
	return true;
	
} 
function SetStatus(CheckID,ThayDoiID)
{

		var i;
		var objCheck,objThayDoi;
		var objMaPhuongThucKinhDoanhMoi,objCheckNganhNghe;
		for (i=0;i<window.document.forms(0).length-1;i++)
		{
			if (window.document.forms(0).item(i).id == CheckID)
			{
				objCheck=window.document.forms(0).item(i);
			}
			if (window.document.forms(0).item(i).id == ThayDoiID)
			{
				objThayDoi=window.document.forms(0).item(i);
			}
			
			if (window.document.forms(0).item(i).id =="_ctl0__ctl0__ctl0_ddlMaPhuongThucKinhDoanhMoi")
			{
				objMaPhuongThucKinhDoanhMoi =window.document.forms(0).item(i);
			}
			if (window.document.forms(0).item(i).id =="_ctl0__ctl0__ctl0_chkMaNganhKinhDoanh")
			{
				objCheckNganhNghe =window.document.forms(0).item(i);
			}
		
		}
		objThayDoi.disabled = !objCheck.checked;
		objMaPhuongThucKinhDoanhMoi.disabled = !objCheckNganhNghe.checked;
		//ComboFilterctrlScriptComboFilter();
	
}
function CallNganhNghe(strURL,Parent,chk)
{		
		if (chk.checked==false)
		{	
			return;
		}
		strURL = GetParams(strURL);
		showWindow1(strURL,Parent);		
}
function showWindow1(obj1,Parent)
{
		//t = screen.height - 30;
		t = 300;
		w = screen.width - 10;
		window.open(obj1,Parent,"width=" + w + ", height=" + t + ", left=0, top=0, scrollbars=yes");
}

//Kiem tra co check thay doi thong tin thanh vien hay khong?
function checkThayDoi(id, a, b, c, d, e, f) {
	var i;
	var obj;
	for (i = 0; i < window.document.forms(0).length-1; i++)
	{
		if (window.document.forms(0).item(i).id == id)
		{
			obj = window.document.forms(0).item(i);
		}
	}
	
	//Neu co chon. thay doi thanh vien thi se enable cac controls tren luoi
	if (obj.checked == true) {
		a.disabled = false;
		b.disabled = false;
		c.disabled = false;
		d.disabled = false;
		e.disabled = false;
		f.disabled = false;
	}
	//Neu bo? chon. thay doi thong tin thanh vien thi se disbale cac controls tren luoi
	else {
		a.disabled = true;
		b.disabled = true;
		c.disabled = true;
		d.disabled = true;
		e.disabled = true;
		f.disabled = true;
	}
}

</script>
<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td height="5"></td>
	</tr>
	<TR>
		<TD height="24" width="100%">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_TopLeft" height="24" width="16"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title"></asp:label></td>
					<td class="QH_Khung_TopRight" height="24" width="16"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td width="*" align="center">
						<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="98%">
							<TR>
								<TD colSpan="5" align="center"><br>
									<!--Hoangln sua lai table -->
									<table id="table1" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TBODY>
											<TR>
												<TD class="QH_ColLabel" width="15%"><asp:linkbutton id="btnDanhSachGP" Visible="False" runat="server">S&#7889; gi&#7845;y CN ÐKKD</asp:linkbutton><asp:label id="lblDanhSachGP" Visible="False" runat="server">S&#7889; gi&#7845;y CNDKKD</asp:label><FONT color="#ff0000" size="4">*</FONT></TD>
												<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Runat="server" Width="45%" CssClass="QH_TextBox" AutoPostBack="True">41J8</asp:textbox></TD>
								</TD>
								<TD class="QH_ColLabel" width="15%"><asp:linkbutton id="btnDanhSach" Visible="False" runat="server">S&#7889; biên nh&#7853;n</asp:linkbutton><asp:label id="lblDanhSach" runat="server">S&#7889; biên nh&#7853;n</asp:label><FONT color="#ff0000" size="4">*</FONT></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" Width="45%" CssClass="QH_textbox" runat="server" ReadOnly="True"
										EnableViewState="true"></asp:textbox></TD>
							</TR>
							<tr>
								<td class="QH_ColLabel" height="5" vAlign="middle" width="15%">Ngày ÐKTÐ <FONT color="#ff0000" size="4">
										*</FONT></td>
								<td class="QH_ColControl" height="5" width="35%"><asp:textbox id="txtNgayThayDoi" Runat="server" Width="45%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox></td>
								<td class="QH_ColLabel" height="5" vAlign="middle" width="15%">Họ tên người nộp</td>
								<td class="QH_ColControl" height="5" width="35%"><asp:textbox id="txtHoTenNguoiNop" Runat="server" Width="100%" CssClass="QH_TextBox" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" height="37" vAlign="middle" width="15%">Ngày cấp</td>
								<td class="QH_ColControl" height="37" width="35%"><asp:textbox id="txtNgayCap" Runat="server" Width="45%" CssClass="QH_TextBox" ReadOnly="True"></asp:textbox><asp:image id="imgNgayCapDKKD" CssClass="QH_ImageButton" Visible="False" runat="server" ImageUrl="~\images\calendar.gif"
										AlternateText="Chọn lịch"></asp:image></td>
								<td class="QH_ColLabel" height="37" vAlign="middle" width="15%">Lãnh&nbsp;đạo ký<FONT color="#ff0000" size="4">*</FONT></td>
								<td class="QH_ColControl" height="37" width="35%"><asp:dropdownlist id="ddlMaSoLanhDaoMoi" Runat="server" Width="100%" CssClass="QH_DropDownList"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" vAlign="middle" width="15%">Lần thay&nbsp;đổi thứ</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoLanThayDoi" Width="45%" CssClass="QH_TextRight" runat="server" AutoPostBack="True"
										ReadOnly="True" Enabled="False"></asp:textbox></td>
								<td class="QH_ColLabel" vAlign="middle" width="15%">Ghi chú</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtGhiChu" Runat="server" Width="100%" CssClass="QH_TextBox" Rows="1" TextMode="MultiLine"></asp:textbox></td>
							</tr>
						</TABLE>
						<!--Hoangln sua lai table -->
						<table id="table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td height="5" colSpan="2"></td>
							</tr>
							<tr>
								<td width="50%" align="left"><asp:label id="Label2" Runat="server" CssClass="QH_LabelLeftBold"><strong>Nội 
											dung cũ</strong></asp:label>&nbsp;
								</td>
								<td width="50%" align="left"><asp:label id="Label1" Runat="server" CssClass="QH_LabelLeftBold"><strong>Nội 
											dung thay đổi</strong></asp:label></td>
							</tr>
							<tr>
								<td height="5" colSpan="2"></td>
							</tr>
						</table>
						<!--Thong tin kinh doanh -->
						<table id="table1" class="QH_Table" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="QH_ColLabel" height="1" width="15%">Bảng hiệu</TD>
								<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtBangHieuCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										MaxLength="100" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" height="1" width="15%">Bảng hiệu
									<asp:checkbox id="chkBangHieu" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtBangHieuMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										MaxLength="100" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="23" rowSpan="2" width="15%">Ngành kinh doanh</TD>
								<TD class="QH_ColControl" height="23" width="35%"><asp:dropdownlist id="ddlMaPhuongThucKinhDoanhCu" Width="100%" CssClass="QH_DropDownList" runat="server"
										EnableViewState="true" Enabled="False"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel" height="23" rowSpan="2" width="15%">Ngành KD
									<asp:checkbox id="chkMaNganhKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" height="23" width="35%"><asp:dropdownlist id="ddlMaPhuongThucKinhDoanhMoi" Width="100%" CssClass="QH_DropDownList" runat="server"
										EnableViewState="true" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColControl" height="23" width="35%"><asp:dropdownlist id="ddlMaNganhKinhDoanhCu" Width="100%" CssClass="QH_DropDownList" runat="server"
										EnableViewState="true" Enabled="False"></asp:dropdownlist></TD>
								<TD class="QH_ColControl" height="23" width="35%"><asp:dropdownlist id="ddlMaNganhKinhDoanhMoi" Width="100%" CssClass="QH_DropDownList" runat="server"
										Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="1" width="15%">Vốn kinh doanh</TD>
								<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtVonKinhDoanhCu" Width="50%" CssClass="QH_TextRight" runat="server" EnableViewState="true"
										MaxLength="15" Enabled="False"></asp:textbox>&nbsp;
									<asp:label id="lblLabelDonViTinhCu" runat="server"></asp:label></TD>
								<TD class="QH_ColLabel" height="1" width="15%">Vốn&nbsp;KD&nbsp;
									<asp:checkbox id="chkVonKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtVonKinhDoanhMoi" Width="50%" CssClass="QH_TextRight" runat="server" EnableViewState="true"
										MaxLength="15" Enabled="False"></asp:textbox>&nbsp;
									<asp:label id="lblLabelDonViTinhMoi" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Mặt hàng kinh&nbsp;doanh</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMatHangKinhDoanhCu" Width="100%" CssClass="QH_Textbox" runat="server" ReadOnly="True"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Mặt hàng KD&nbsp;
									<asp:checkbox id="chkMatHangKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMatHangKinhDoanhMoi" Width="100%" CssClass="QH_Textbox" runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="1" width="15%">Tổng số lao động</TD>
								<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtTongSoLaoDongCu" Width="50%" CssClass="QH_TextRight" runat="server" EnableViewState="true"
										MaxLength="15" Enabled="False"></asp:textbox>&nbsp;</TD>
								<TD class="QH_ColLabel" height="1" width="15%">Tổng số lao độnng
									<asp:checkbox id="chkTongSoLaoDong" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtTongSoLaoDongMoi" Width="50%" CssClass="QH_TextRight" runat="server" EnableViewState="true"
										MaxLength="15" Enabled="False"></asp:textbox>&nbsp;</TD>
							</TR>
							<!--Dia Chi Kinh Doanh-->
							<tr>
								<td height="5" colSpan="4"></td>
							</tr>
							<TR>
								<TD class="QH_LabelLeftBold" height="19" vAlign="top" width="100%" colSpan="4"><strong>Ðịa 
										chỉ&nbsp;kinh doanh</strong>
								</TD>
							</TR>
							<tr>
								<td class="QH_ColLabel" width="15%">Số nhà</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNhaCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">Số nhà&nbsp;
									<asp:checkbox id="chkSoNha" Runat="server" CssClass="" Text=""></asp:checkbox></td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNhaMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Ðường</td>
								<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuongCu" Width="100%" CssClass="QH_DropDownList" runat="server" EnableViewState="true"
										Enabled="False"></asp:dropdownlist></td>
								<td class="QH_ColLabel" width="15%">Ðường&nbsp;
									<asp:checkbox id="chkMaDuong" Runat="server" CssClass="" Text=""></asp:checkbox></td>
								<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuongMoi" Width="100%" CssClass="QH_DropDownList" runat="server" EnableViewState="true"
										Enabled="False"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Phường</td>
								<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuongCu" Width="100%" CssClass="QH_DropDownList" runat="server" EnableViewState="true"
										Enabled="False"></asp:dropdownlist></td>
								<td class="QH_ColLabel" width="15%">Phường&nbsp;
									<asp:checkbox id="chkMaPhuong" Runat="server" CssClass="" Text=""></asp:checkbox></td>
								<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuongMoi" Width="100%" CssClass="QH_DropDownList" runat="server" EnableViewState="true"
										Enabled="False"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="QH_ColLabel" width="15%">Ðịa chỉ cũ</td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCuCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></td>
								<td class="QH_ColLabel" width="15%">&nbsp;Ðịa chỉ cũ
									<asp:checkbox id="chkDiaChiCu" Runat="server" CssClass="" Text=""></asp:checkbox></td>
								<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCuMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></td>
							</tr>
							<TR>
								<TD class="QH_ColLabel" width="15%">Ðiện thoại</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtPhoneCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Ðiện thoại&nbsp;
									<asp:checkbox id="chkPhone" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtPhoneMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Fax</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtFaxCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Fax&nbsp;
									<asp:checkbox id="chkFax" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtFaxMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Email</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtEmailCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Email&nbsp;
									<asp:checkbox id="chkEmail" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtEmailMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Website</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtWebsiteCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Website&nbsp;
									<asp:checkbox id="chkWebsite" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtWebSiteMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<!--THONG TIN NGUOI DAI DIEN-->
							<tr>
								<td height="5" colSpan="4"></td>
							</tr>
							<tr>
								<td vAlign="top" width="100%" colSpan="4"><asp:label id="Label3" Width="100%" CssClass="QH_LabelLeftBold" runat="server"><strong>Thông 
											tin người đại diện</strong></asp:label></td>
							</tr>
							<tr>
								<td height="5" colSpan="4"></td>
							</tr>
							<TR>
								<TD class="QH_ColLabel" width="15%">Họ và tên</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenCNCu" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Họ và tên&nbsp;
									<asp:checkbox id="chkHoTenCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenCNMoi" Width="100%" CssClass="QH_textbox" runat="server" EnableViewState="true"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Giới tính</TD>
								<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinhCNCu" Width="19%" CssClass="QH_DropDownList" runat="server" EnableViewState="true"
										Enabled="False">
										<asp:ListItem Value="1">Nam</asp:ListItem>
										<asp:ListItem Value="0">Nữ</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD class="QH_ColLabel" width="15%">&nbsp;Giới tính
									<asp:checkbox id="chkGioiTinhCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinhCNMoi" Width="19%" CssClass="QH_DropDownList" runat="server" EnableViewState="true"
										Enabled="False">
										<asp:ListItem Value="1">Nam</asp:ListItem>
										<asp:ListItem Value="0">Nữ</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Ngày sinh</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinhCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Ngày sinh&nbsp;
									<asp:checkbox id="chkNgaySinhCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinhCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="10"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Quốc tịch</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtQuocTichCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Quốc tịch&nbsp;
									<asp:checkbox id="chkQuocTich" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtQuocTichMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Thường trú</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTruCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Thường trú&nbsp;
									<asp:checkbox id="chkDiaChiThuongTruCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTruCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Chỗ ở hiện nay</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNayCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Chỗ ở hiện nay<asp:checkbox id="chkChoOHienNayCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNayCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Số CMND</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="20"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Số CMND&nbsp;
									<asp:checkbox id="chkSoCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="20"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="39" width="15%">Ngày cấp</TD>
								<TD class="QH_ColControl" height="39" width="35%"><asp:textbox id="txtNgayCapCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" height="39" width="15%">Ngày cấp&nbsp;
									<asp:checkbox id="chkNgayCapCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" height="39" width="35%"><asp:textbox id="txtNgayCapCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="10"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Nơi cấp</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNoiCapCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Nơi cấp
									<asp:checkbox id="chkNoiCapCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNoiCapCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Dân tộc</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDanTocCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Dân tộc&nbsp;
									<asp:checkbox id="chkDanTocCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDanTocCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<!--THONG TIN NGUOI DAI DIEN-->
							<!--THONG TIN CHUNG THUC CA NHAN-->
							<tr>
								<td height="5" colSpan="4"></td>
							</tr>
							<tr>
								<td vAlign="top" width="100%" colSpan="4"><asp:label id="Label4" Width="100%" CssClass="QH_LabelLeftBold" runat="server"><strong>Thông 
											tin cá nhân</strong></asp:label></td>
							</tr>
							<tr>
								<td height="5" colSpan="4"></td>
							</tr>
							<TR>
								<TD class="QH_ColLabel" width="15%">Tên giấy tờ</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTenGiayChungThucCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Tên giấy tờ&nbsp;
									<asp:checkbox id="chkTenGiayChungThuc" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTenGiayChungThucMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Số giấy chứng thực</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayChungThucCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Số giấy chứng thực&nbsp;
									<asp:checkbox id="chkSoGiayChungThuc" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayChungThucMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Ngày cấp</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCapGiayChungThucCu" Runat="server" Width="100%" CssClass="QH_TextBox"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Ngày cấp&nbsp;
									<asp:checkbox id="chkNgayCapGiayChungThuc" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCapGiayChungThucMoi" Runat="server" Width="100%" CssClass="QH_TextBox"
										MaxLength="10" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="15%">Noi cấp</TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNoiCapGiayChungThucCu" Runat="server" Width="100%" CssClass="QH_TextBox"
										Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel" width="15%">Noi cấp&nbsp;
									<asp:checkbox id="chkNoiCapGiayChungThuc" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
								<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNoiCapGiayChungThucMoi" Runat="server" Width="100%" CssClass="QH_TextBox"
										Enabled="False"></asp:textbox></TD>
							</TR>
							<tr>
								<td width="100%" colSpan="4"><asp:label id="Label5" Width="100%" CssClass="QH_LabelLeftBold" runat="server"><strong>Danh 
											sách cá nhân góp vốn thành lập hộ kinh doanh</strong></asp:label></td>
							</tr>
							<tr>
								<td colSpan="4">
									<table border="0" cellSpacing="0" cellPadding="0" width="80%" align="center">
										<tr>
											<td align="center"><asp:datagrid id="dgdDanhSach" Runat="server" Width="90%" CssClass="QH_DataGrid" AutoGenerateColumns="False"
													AllowSorting="True" CellPadding="3">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Chọn">
															<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
															<ItemTemplate>
																<input type="checkbox" name="chkChon" id="chkChon" runat="server">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Tên thành viên">
															<ItemStyle Width="10%"></ItemStyle>
															<ItemTemplate>
																<input type="text" runat="server" id="txtTenThanhVien" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.TenThanhVien")%>' NAME="txtTenThanhVien" disabled="true">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Thường trú">
															<ItemStyle Width="15%"></ItemStyle>
															<ItemTemplate>
																<input type="text" runat=server id="txtThanhVienThuongTru" style="width:200" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.ThanhVienThuongTru")%>' NAME="txtThanhVienThuongTru" disabled="true">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Giá trị gốp vốn">
															<ItemStyle Width="10%"></ItemStyle>
															<ItemTemplate>
																<input type="text" runat=server id="txtGiaTriGopVon" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.GiaTriGopVon")%>' NAME="txtGiaTriGopVon" disabled="true">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Tỉ lệ góp vốn">
															<ItemStyle Width="5%"></ItemStyle>
															<ItemTemplate>
																<input type="text" runat=server id="txtTyLeGopVon" style="width:50" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.TyLeGopVon")%>' NAME="txtTyLeGopVon" disabled="true">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Số CMND(hoặc giấy tờ khác)">
															<ItemStyle Width="35%"></ItemStyle>
															<ItemTemplate>
																<input type="text" runat=server id="txtThanhVienCMND" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.ThanhVienCMND")%>' NAME="txtThanhVienCMND" disabled="true">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Ghi chú">
															<ItemStyle Width="180px"></ItemStyle>
															<ItemTemplate>
																<input type="text" runat="server" id="txtThanhVienGhiChu" class="QH_TextBox" value='<%# DataBinder.Eval(Container, "DataItem.ThanhVienGhiChu")%>' NAME="txtThanhVienGhiChu" disabled="true">
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:ButtonColumn Text="Thêm" CommandName="Update">
															<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Text="Xóa" CommandName="Delete">
															<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
														</asp:ButtonColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td align="center"><asp:checkbox id="chkDoiSo" Visible="False" runat="server" Text="Đổi số giấy phép đối với giấy chứng nhận cũ"
													Font-Bold="True"></asp:checkbox></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="5" colSpan="4"></td>
							</tr>
						</table>
						<!--Hoangln sua lai table --><BR>
						<asp:linkbutton id="btnKiemTra" CssClass="QH_Button" runat="server">Kiểm tra hồ sơ</asp:linkbutton><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">C&#7853;p nh&#7853;t</asp:linkbutton><asp:linkbutton id="btnDeXuat" CssClass="QH_Button" Visible="False" runat="server">&#272;&#7873; xu&#7845;t</asp:linkbutton><asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server">B&#7893; sung h&#7891; s&#417;</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server">H&#7891; s&#417; không gi&#7843;i quy&#7871;t</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" Visible="False" runat="server">Xóa</asp:linkbutton><asp:linkbutton id="btnIn" CssClass="QH_Button" Visible="False" runat="server">In giấy CNĐKKD</asp:linkbutton><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Tr&#7903; v&#7873;</asp:linkbutton>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="lblKiemTra" runat="server" Font-Bold="True" ForeColor="Black">KẾT QUẢ KIỂM TRA HỒ SƠ</asp:label></td>
							</tr>
							<tr>
								<td><asp:label id="lblKetQuaKiemTraBangHieu" runat="server" Font-Bold="True" ForeColor="#ff0000"
										Font-Italic="True"></asp:label></td>
							</tr>
							<tr>
								<td><asp:label id="lblKetQuaKiemTraDiaChiDKKD" runat="server" Font-Bold="True" ForeColor="#ff0000"
										Font-Italic="True"></asp:label></td>
							</tr>
							<tr>
								<td><asp:label id="lblKetQuaThongTin" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
							</tr>
							<tr>
								<td><asp:label id="lblKetQuaVPHC" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
							</tr>
							<tr>
								<td><asp:label id="lblKetQuaNganhCam" runat="server" Font-Bold="True" ForeColor="#ff0000" Font-Italic="True"></asp:label></td>
							</tr>
							<tr>
								<td><asp:label id="lblKetQuaNganhDieuKien" runat="server" Font-Bold="True" ForeColor="#ff0000"
										Font-Italic="True"></asp:label></td>
							</tr>
							<tr>
								<td><asp:linkbutton id="hplDanhSachBangHieu" runat="server" CausesValidation="False"><br>Click vào đây để xem danh sách trùng bảng hiệu</asp:linkbutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD colSpan="5">
						<!--SET WIDTH=0--><asp:textbox id="txtGiayCNDKKDID" Runat="server" Width="0px" CssClass="QH_TextBox" Visible="TRUE"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Runat="server" Width="0px" CssClass="QH_TextBox"></asp:textbox><asp:textbox id="txtSoGiayPhepGoc" Runat="server" Width="30px" CssClass="QH_TextBox" Visible="False"></asp:textbox><asp:textbox id="txtNgayCapGiayPhepGoc" Runat="server" Width="30px" CssClass="QH_TextBox" Visible="False"></asp:textbox><asp:textbox id="txtReload" Width="0px" CssClass="QH_textbox" Visible="False" runat="server"></asp:textbox><asp:image id="imgNgayDKBS" CssClass="QH_ImageButton" Visible="False" runat="server" ImageUrl="~\images\calendar.gif"
							AlternateText="Chọn lịch"></asp:image><asp:textbox id="txtNgayDangKyBoSung" Runat="server" Width="30%" CssClass="QH_TextBox" Visible="False"></asp:textbox><uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter><asp:textbox id="txtThanhVienIDXoa" Width="0px" CssClass="QH_textbox" Visible="False" runat="server"></asp:textbox>
						<!--SET WIDTH=0--></TD>
				</TR>
			</table>
		</TD>
		<td class="QH_Khung_Right" width="16">
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr height="*">
					<td></td>
				</tr>
				<tr height="141">
					<td class="QH_Khung_Right1"></td>
				</tr>
			</TABLE>
		</td>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
