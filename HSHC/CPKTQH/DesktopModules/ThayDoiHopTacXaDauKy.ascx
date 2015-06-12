<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThayDoiHopTacXaDauKy.ascx.vb" Inherits="CPKTQH.ThayDoiHopTacXaDauKy" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language="javascript">

function KiemTraNhapLieu()
{
	var txtHoTen = document.all('<%=txtHoTen.clientID%>');
	var txtNgaySinh = document.all('<%=txtNgaySinh.clientID%>');
	var txtDiaChiThuongTru = document.all('<%=txtDiaChiThuongTru.clientID%>'); 
	var txtSoCMND = document.all('<%=txtSoCMND.clientID%>');
	if (txtHoTen.value=="")
	{
		alert("Chua nhap Ho Ten");
		txtHoTen.focus();
		return false;
	}
	if (txtNgaySinh.value=="")
	{
		alert("Chua nhap Ngay Sinh");
		txtNgaySinh.focus();
		return false;
	}
	if (txtSoCMND.value=="")
	{
		alert("Chua nhap CMND");
		txtSoCMND.focus();
		return false;
	}
	if (txtDiaChiThuongTru.value=="")
	{
		alert("Chua nhap Dia Chi Thuong Tru");
		txtDiaChiThuongTru.focus();
		return false;
	}
	return true;
}
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
			{
				if ((AllConTrols[i].id.indexOf('chkContent')==-1)&&(AllConTrols[i].id.indexOf('chkPreview')==-1))	
					if (AllConTrols[i].checked)
						return true;
			}
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
			
		}
		objThayDoi.disabled = !objCheck.checked;
	
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

</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td height="5"></td>
	</tr>
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Thay &#273;&#7893;i Hợp tác xã</asp:label></td>
					<td class="QH_Khung_TopRight" width="16" height="24"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_Left" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1"></td>
							</tr>
						</TABLE>
					</td>
					<td align="center" width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
							<TR>
								<TD align="center" colSpan="5"><br>
									<!--Hoangln sua lai table -->
									<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="800" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%">Số&nbsp;GCN&nbsp;ĐKKD&nbsp; <FONT color="#ff0000" size="2">
													*</FONT></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Runat="server" Width="45%" CssClass="QH_TextBox" AutoPostBack="True"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" Width="45%" CssClass="QH_textbox" EnableViewState="true" runat="server"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" width="15%" height="5">Ngày cấp</td>
											<td class="QH_ColControl" width="35%" height="5"><asp:textbox id="txtNgayCap" Runat="server" Width="45%" CssClass="QH_TextBox" ReadOnly="True"></asp:textbox></td>
											<TD class="QH_ColLabel" vAlign="middle" width="15%" height="5">Lãnh đạo ký<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl" width="35%" height="5"><asp:dropdownlist id="ddlMaSoLanhDaoMoi" Runat="server" Width="100%" CssClass="QH_DropDownList"></asp:dropdownlist></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" vAlign="middle" width="15%">Ngày ÐKTÐ <FONT color="#ff0000" size="2">
													*</FONT></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayThayDoi" Runat="server" Width="45%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox></TD>
											<td class="QH_ColLabel" vAlign="top" width="15%" rowSpan="2">
												<p style="MARGIN-TOP: 4px; MARGIN-BOTTOM: 0px">Ghi chú</p>
											</td>
											<td class="QH_ColControl" vAlign="top" width="35%" rowSpan="2"><asp:textbox id="txtGhiChu" Runat="server" Width="100%" CssClass="QH_TextBox" Height="42px" Rows="2"
													TextMode="MultiLine"></asp:textbox></td>
										</TR>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" width="15%">Lần thay đổi thứ</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoLanThayDoi" Runat="server" Width="45%" CssClass="QH_TextRight" AutoPostBack="True"
													ReadOnly="True"></asp:textbox></td>
										</tr>
									</table>
									<!--Hoangln sua lai table -->
									<table id="table1" cellSpacing="0" cellPadding="0" width="800" border="0">
										<tr>
											<td colSpan="2" height="5"></td>
										</tr>
										<tr>
											<td align="left" width="50%"><asp:label id="Label2" Runat="server" CssClass="QH_LabelLeftBold"><strong>N&#7897;i 
														dung c&#361;</strong></asp:label>&nbsp;
											</td>
											<td align="left" width="50%"><asp:label id="Label1" Runat="server" CssClass="QH_LabelLeftBold"><strong>N&#7897;i 
														dung thay &#273;&#7893;i</strong></asp:label></td>
										</tr>
										<tr>
											<td colSpan="2" height="5"></td>
										</tr>
									</table>
									<!--Thong tin kinh doanh -->
									<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="800" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%" height="1">Bảng hiệu</TD>
											<TD class="QH_ColControl" width="35%" height="1"><asp:textbox id="txtBangHieuCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													MaxLength="100" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%" height="1">Bảng hiệu&nbsp;
												<asp:checkbox id="chkBangHieu" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%" height="1"><asp:textbox id="txtBangHieuMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													MaxLength="100" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%" height="23">Ngành kinh doanh</TD>
											<TD class="QH_ColControl" width="35%" height="23"><asp:dropdownlist id="ddlMaNganhKinhDoanhCu" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%" height="23">Ngành&nbsp;KD&nbsp;
												<asp:checkbox id="chkMaNganhKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%" height="23"><asp:dropdownlist id="ddlMaNganhKinhDoanhMoi" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<!--
										<TR>
											<TD class="QH_ColLabel" width="15%" height="24">Hình thức kinh doanh</TD>
											<TD class="QH_ColControl" width="35%" height="24"><asp:dropdownlist id="ddlMaHinhThucKinhDoanhCu" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%" height="24">Hình thức&nbsp;KD&nbsp;
												<asp:checkbox id="chkMaHinhThucKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%" height="24"><asp:dropdownlist id="ddlMaHinhThucKinhDoanhMoi" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										-->
										<TR>
											<TD class="QH_ColLabel" width="15%" height="1">Vốn kinh doanh</TD>
											<TD class="QH_ColControl" width="35%" height="1"><asp:textbox id="txtVonKinhDoanhCu" Width="100%" CssClass="QH_TextRight" EnableViewState="true"
													runat="server" MaxLength="15" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%" height="1">Vốn&nbsp;KD&nbsp;
												<asp:checkbox id="chkVonKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%" height="1"><asp:textbox id="txtVonKinhDoanhMoi" Width="100%" CssClass="QH_TextRight" EnableViewState="true"
													runat="server" MaxLength="15" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Mặt hàng kinh&nbsp;doanh</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMatHangKinhDoanhCu" Width="100%" CssClass="QH_Textbox" runat="server" ReadOnly="True"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Mặt hàng KD&nbsp;
												<asp:checkbox id="chkMatHangKinhDoanh" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMatHangKinhDoanhMoi" Width="100%" CssClass="QH_Textbox" runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<!--Dia Chi Kinh Doanh-->
										<tr>
											<td colSpan="4" height="5"></td>
										</tr>
										<TR>
											<TD class="QH_LabelLeftBold" vAlign="top" width="100%" colSpan="4" height="19"><strong>Địa 
													chỉ kinh doanh</strong>
											</TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" width="15%">Số nhà</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNhaCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Số nhà&nbsp;
												<asp:checkbox id="chkSoNha" Runat="server" CssClass="" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNhaMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%">Đường</td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuongCu" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></td>
											<td class="QH_ColLabel" width="15%">Đường&nbsp;
												<asp:checkbox id="chkMaDuong" Runat="server" CssClass="" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuongMoi" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%">Phường</td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuongCu" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></td>
											<td class="QH_ColLabel" width="15%">Phường&nbsp;
												<asp:checkbox id="chkMaPhuong" Runat="server" CssClass="" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuongMoi" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%">Địa chỉ cũ</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCuCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Địa chỉ cũ&nbsp;
												<asp:checkbox id="chkDiaChiCu" Runat="server" CssClass="" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCuMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Điện thoại</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtPhoneCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Điện thoại&nbsp;
												<asp:checkbox id="chkPhone" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtPhoneMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Fax</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtFaxCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Fax&nbsp;
												<asp:checkbox id="chkFax" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtFaxMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Email</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtEmailCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Email&nbsp;
												<asp:checkbox id="chkEmail" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtEmailMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Website</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtWebsiteCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Website&nbsp;
												<asp:checkbox id="chkWebsite" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtWebSiteMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<!--THONG TIN NGUOI DAI DIEN-->
										<tr>
											<td colSpan="4" height="5"></td>
										</tr>
										<tr>
											<td vAlign="top" width="100%" colSpan="4"><asp:label id="Label3" Width="100%" CssClass="QH_LabelLeftBold" runat="server"><strong>Thông 
														tin chủ nhiệm</strong></asp:label></td>
										</tr>
										<tr>
											<td colSpan="4" height="5"></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Họ và tên</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenCNCu" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Họ và tên&nbsp;
												<asp:checkbox id="chkHoTenCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenCNMoi" Width="100%" CssClass="QH_textbox" EnableViewState="true" runat="server"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Giới tính</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinhCNCu" Width="19%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False">
													<asp:ListItem Value="1">Nam</asp:ListItem>
													<asp:ListItem Value="0">N&#7919;</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">Giới tính
												<asp:checkbox id="chkGioiTinhCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinhCNMoi" Width="19%" CssClass="QH_DropDownList" EnableViewState="true"
													runat="server" Enabled="False">
													<asp:ListItem Value="1">Nam</asp:ListItem>
													<asp:ListItem Value="0">N&#7919;</asp:ListItem>
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
											<TD class="QH_ColLabel" width="15%">Thường trú</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTruCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Thường trú&nbsp;
												<asp:checkbox id="chkDiaChiThuongTruCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTruCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Chỗ ở hiện nay</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNayCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Chỗ ở hiện nay
												<asp:checkbox id="chkChoOHienNayCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNayCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Số CMND</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="9"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Số CMND&nbsp;
												<asp:checkbox id="chkSoCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="20"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ngày cấp</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCapCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Ngày cấp&nbsp;
												<asp:checkbox id="chkNgayCapCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgayCapCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" MaxLength="10"
													Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Nơi cấp</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNoiCapCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Nơi cấp&nbsp;
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
									</table>
									<!--Hoangln sua lai table -->
									<!--THONG TIN XA VIEN-->
									<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="800" border="0">
										<tr>
											<td colSpan="4" height="5"></td>
										</tr>
										<tr>
											<td vAlign="top" width="100%" colSpan="4"><asp:label id="Label5" Width="100%" CssClass="QH_LabelLeftBold" runat="server"><strong>Thông 
														tin Xã viên</strong></asp:label></td>
										</tr>
										<tr>
											<td colSpan="4" height="5"></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" width="15%">Họ và tên <FONT color="#ff0000">*</FONT></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" Width="80%" CssClass="QH_textbox" EnableViewState="true" runat="server"></asp:textbox><asp:dropdownlist id="ddlGioiTinh" Width="19%" CssClass="QH_DropDownList" EnableViewState="true" runat="server">
													<asp:ListItem Value="1" Selected="True">Nam</asp:ListItem>
													<asp:ListItem Value="0">Nữ</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="QH_ColLabel" vAlign="middle" width="15%" height="3">Ngày sinh <FONT color="#ff0000">
													*</FONT></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinh" Runat="server" Width="40%" CssClass="QH_TextBox"></asp:textbox>&nbsp;</td>
										</tr>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" width="15%">Dân tộc</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtDanToc" Runat="server" Width="100%" CssClass="QH_TextBox"></asp:textbox></td>
											<td class="QH_ColLabel" vAlign="middle" width="15%">Số CMND <FONT color="#ff0000">*</FONT></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMND" Runat="server" Width="40%" CssClass="QH_TextBox" MaxLength="20"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" width="15%" height="18">Nơi cấp</td>
											<td class="QH_ColControl" width="35%" height="18"><asp:textbox id="txtNoiCapCMND" Runat="server" Width="100%" CssClass="QH_TextBox"></asp:textbox></td>
											<td class="QH_ColLabel" vAlign="middle" width="15%" height="18">Ngày cấp</td>
											<td class="QH_ColControl" width="35%" height="18"><asp:textbox id="txtNgayCapCMND" Runat="server" Width="40%" CssClass="QH_TextBox"></asp:textbox>&nbsp;</td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" vAlign="middle" width="15%">Thường trú <FONT color="#ff0000">*</FONT></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTru" Runat="server" Width="100%" CssClass="QH_TextBox"></asp:textbox></TD>
											<TD class="QH_ColLabel" vAlign="middle" width="15%">Chỗ ở hiện nay</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNay" Runat="server" Width="100%" CssClass="QH_TextBox"></asp:textbox></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" width="100%" colSpan="4"><asp:linkbutton id="btnThem" CssClass="QH_Button" runat="server">Thêm thành viên</asp:linkbutton><asp:linkbutton id="btnSua" CssClass="QH_Button" runat="server" Visible="False">Sửa thành viên</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" width="100%" colSpan="4"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_DataGridBottom" CellPadding="3"
													autogeneratecolumns="False" AllowPaging="True">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="STT">
															<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="HoTen" HeaderText="Họ t&#234;n">
															<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SoCMND" HeaderText="Số CMND">
															<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NgaySinh" HeaderText="Ng&#224;y sinh">
															<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DiaChiThuongTru" HeaderText="Địa chỉ thường tr&#250;">
															<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Sửa">
															<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="imgSua" runat="server" CommandName="Sua" ImageUrl="~/images/edit.gif"></asp:ImageButton>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Center"></FooterStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="X&#243;a">
															<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="imgXoa" runat="server" CommandName="Xoa" ImageUrl="~/images/delete.gif"></asp:ImageButton>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Center"></FooterStyle>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" CssClass="ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</table>
									<BR>
									<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">C&#7853;p nh&#7853;t</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Tr&#7903; v&#7873;</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD colSpan="5">
									<!--SET WIDTH=0--><asp:textbox id="txtGiayCNDKKDID" Runat="server" Width="0px" CssClass="QH_TextBox" Visible="TRUE"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Runat="server" Width="0px" CssClass="QH_TextBox"></asp:textbox><asp:textbox id="txtSoGiayPhepGoc" Runat="server" Width="30px" CssClass="QH_TextBox" Visible="False"></asp:textbox><asp:textbox id="txtNgayCapGiayPhepGoc" Runat="server" Width="30px" CssClass="QH_TextBox" Visible="False"></asp:textbox><asp:textbox id="txtReload" Width="0px" CssClass="QH_textbox" runat="server" Visible="False"></asp:textbox><asp:image id="imgNgayDKBS" CssClass="QH_ImageButton" runat="server" Visible="False" ImageUrl="~\images\calendar.gif"
										AlternateText="Chọn lịch"></asp:image><asp:textbox id="txtNgayDangKyBoSung" Runat="server" Width="30%" CssClass="QH_TextBox" Visible="False"></asp:textbox>
									<!--SET WIDTH=0--></TD>
							</TR>
						</TABLE>
					</td>
					<td class="QH_Khung_Right" width="16">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="*">
								<td></td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Right1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
