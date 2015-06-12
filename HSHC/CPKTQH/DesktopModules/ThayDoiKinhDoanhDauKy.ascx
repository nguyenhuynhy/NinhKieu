<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThayDoiKinhDoanhDauKy.ascx.vb" Inherits="CPKTQH.ThayDoiKinhDoanhDauKy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Thay &#273;&#7893;i kinh doanh H&#7897; cá th&#7875; (&#272;&#7847;u k&#7923;)</asp:label></td>
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
									<table class="QH_Table" id="table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" width="15%">Số&nbsp;GCN&nbsp;ĐKKD&nbsp; <FONT color="#ff0000" size="2">
													*</FONT></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" CssClass="QH_TextBox" Width="45%" Runat="server" AutoPostBack="True"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="45%" runat="server" EnableViewState="true"></asp:textbox></TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" height="5" width="15%">
												Ngày cấp</td>
											<td class="QH_ColControl" height="5" width="35%">
												<asp:textbox id="txtNgayCap" Runat="server" Width="45%" CssClass="QH_TextBox" ReadOnly="True"></asp:textbox></td>
											<TD class="QH_ColLabel" vAlign="middle" width="15%" height="5">Lãnh đạo ký<FONT color="#ff0000" size="2">*</FONT></TD>
											<TD class="QH_ColControl" width="35%" height="5"><asp:dropdownlist id="ddlMaSoLanhDaoMoi" CssClass="QH_DropDownList" Width="100%" Runat="server"></asp:dropdownlist></TD>
										</tr>
										<TR>
											<TD class="QH_ColLabel" vAlign="middle" width="15%">Ngày ÐKTÐ <FONT color="#ff0000" size="2">
													*</FONT></TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtNgayThayDoi" Runat="server" Width="45%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox></TD>
											<td class="QH_ColLabel" vAlign="top" width="15%" rowspan="2">
												<p style="MARGIN-TOP: 4px; MARGIN-BOTTOM: 0px">
													Ghi chú</p>
											</td>
											<td class="QH_ColControl" width="35%" rowspan="2" valign="top"><asp:textbox id="txtGhiChu" CssClass="QH_TextBox" Width="100%" Runat="server" TextMode="MultiLine"
													Rows="2" Height="42px"></asp:textbox></td>
										</TR>
										<tr>
											<td class="QH_ColLabel" vAlign="middle" width="15%">Lần thay đổi thứ</td>
											<td class="QH_ColControl" width="35%">
												<asp:textbox id="txtSoLanThayDoi" Runat="server" Width="45%" CssClass="QH_TextRight" AutoPostBack="True"
													ReadOnly="True"></asp:textbox></td>
										</tr>
									</table>
									<!--Hoangln sua lai table -->
									<table id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colspan="2" height="5"></td>
										</tr>
										<tr>
											<td align="left" width="50%"><asp:label id="Label2" CssClass="QH_LabelLeftBold" Runat="server"><strong>N&#7897;i 
														dung c&#361;</strong></asp:label>&nbsp;
											</td>
											<td align="left" width="50%"><asp:label id="Label1" CssClass="QH_LabelLeftBold" Runat="server"><strong>N&#7897;i 
														dung thay &#273;&#7893;i</strong></asp:label></td>
										</tr>
										<tr>
											<td colspan="2" height="5"></td>
										</tr>
									</table>
									<!--Thong tin kinh doanh -->
									<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="QH_ColLabel" height="1" width="15%">Bảng hiệu</TD>
											<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtBangHieuCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true" MaxLength="100"></asp:textbox></TD>
											<TD class="QH_ColLabel" height="1" width="15%">Bảng hiệu&nbsp;
												<asp:checkbox id="chkBangHieu" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtBangHieuMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true" MaxLength="100"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="23" width="15%">Ngành kinh doanh</TD>
											<TD class="QH_ColControl" height="23" width="35%"><asp:dropdownlist id="ddlMaNganhKinhDoanhCu" CssClass="QH_DropDownList" Width="100%" Enabled="False"
													runat="server" EnableViewState="true"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" height="23" width="15%">Ngành&nbsp;KD&nbsp;
												<asp:checkbox id="chkMaNganhKinhDoanh" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" height="23" width="35%"><asp:dropdownlist id="ddlMaNganhKinhDoanhMoi" CssClass="QH_DropDownList" Width="100%" Enabled="False"
													runat="server" EnableViewState="true"></asp:dropdownlist></TD>
										</TR>
										<!--
										<TR>
											<TD class="QH_ColLabel" height="24" width="15%">Hình thức kinh doanh</TD>
											<TD class="QH_ColControl" height="24" width="35%"><asp:dropdownlist id="ddlMaHinhThucKinhDoanhCu" CssClass="QH_DropDownList" Width="100%" Enabled="False"
													runat="server" EnableViewState="true"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%" height="24">Hình thức&nbsp;KD&nbsp;
												<asp:checkbox id="chkMaHinhThucKinhDoanh" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" height="24" width="35%"><asp:dropdownlist id="ddlMaHinhThucKinhDoanhMoi" CssClass="QH_DropDownList" Width="100%" Enabled="False"
													runat="server" EnableViewState="true"></asp:dropdownlist></TD>
										</TR>
										-->
										<TR>
											<TD class="QH_ColLabel" height="1" width="15%">Vốn kinh doanh</TD>
											<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtVonKinhDoanhCu" CssClass="QH_TextRight" Width="50%" Enabled="False" runat="server"
													EnableViewState="true" MaxLength="15"></asp:textbox>&nbsp;
												<asp:Label id="lblLabelDonViTinhCu" runat="server"></asp:Label></TD>
											<TD class="QH_ColLabel" height="1" width="15%">Vốn&nbsp;KD&nbsp;
												<asp:checkbox id="chkVonKinhDoanh" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" height="1" width="35%"><asp:textbox id="txtVonKinhDoanhMoi" CssClass="QH_TextRight" Width="50%" Enabled="False" runat="server"
													EnableViewState="true" MaxLength="15"></asp:textbox>&nbsp;
												<asp:Label id="lblLabelDonViTinhMoi" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Mặt hàng kinh&nbsp;doanh</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMatHangKinhDoanhCu" CssClass="QH_Textbox" Width="100%" Enabled="False" runat="server"
													ReadOnly="True"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Mặt hàng KD&nbsp;
												<asp:checkbox id="chkMatHangKinhDoanh" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtMatHangKinhDoanhMoi" CssClass="QH_Textbox" Width="100%" Enabled="False" runat="server"></asp:textbox></TD>
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
											<td colspan="4" height="5"></td>
										</tr>
										<TR>
											<TD class="QH_LabelLeftBold" vAlign="top" width="100%" colSpan="4" height="19"><strong>Địa 
													chỉ kinh doanh</strong>
											</TD>
										</TR>
										<tr>
											<td class="QH_ColLabel" width="15%">Số nhà</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNhaCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Số nhà&nbsp;
												<asp:checkbox id="chkSoNha" CssClass="" Runat="server" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoNhaMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%">Đường</td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuongCu" CssClass="QH_DropDownList" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:dropdownlist></td>
											<td class="QH_ColLabel" width="15%">Đường&nbsp;
												<asp:checkbox id="chkMaDuong" CssClass="" Runat="server" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaDuongMoi" CssClass="QH_DropDownList" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%">Phường</td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuongCu" CssClass="QH_DropDownList" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:dropdownlist></td>
											<td class="QH_ColLabel" width="15%">Phường&nbsp;
												<asp:checkbox id="chkMaPhuong" CssClass="" Runat="server" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlMaPhuongMoi" CssClass="QH_DropDownList" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="15%">Địa chỉ cũ</td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCuCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></td>
											<td class="QH_ColLabel" width="15%">Địa chỉ cũ&nbsp;
												<asp:checkbox id="chkDiaChiCu" CssClass="" Runat="server" Text=""></asp:checkbox></td>
											<td class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiCuMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Điện thoại</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtPhoneCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Điện thoại&nbsp;
												<asp:checkbox id="chkPhone" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtPhoneMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Fax</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtFaxCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Fax&nbsp;
												<asp:checkbox id="chkFax" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtFaxMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Email</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtEmailCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Email&nbsp;
												<asp:checkbox id="chkEmail" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtEmailMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Website</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtWebsiteCu" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Website&nbsp;
												<asp:checkbox id="chkWebsite" CssClass="" Runat="server" Text=""></asp:checkbox></TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtWebSiteMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
										<!--THONG TIN NGUOI DAI DIEN-->
										<tr>
											<td colspan="4" height="5"></td>
										</tr>
										<tr>
											<td vAlign="top" width="100%" colSpan="4"><asp:label id="Label3" CssClass="QH_LabelLeftBold" Width="100%" runat="server"><strong>Thông 
														tin ng&#432;&#7901;i &#273;&#7841;i di&#7879;n</strong></asp:label></td>
										</tr>
										<tr>
											<td colspan="4" height="5"></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Họ và tên</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenCNCu" CssClass="QH_textbox" Width="100%" runat="server" EnableViewState="true"
													Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Họ và tên&nbsp;
												<asp:checkbox id="chkHoTenCN" CssClass="" Runat="server" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTenCNMoi" CssClass="QH_textbox" Width="100%" Enabled="False" runat="server"
													EnableViewState="true"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Giới tính</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinhCNCu" CssClass="QH_DropDownList" Width="19%" runat="server" EnableViewState="true"
													Enabled="False">
													<asp:ListItem Value="1">Nam</asp:ListItem>
													<asp:ListItem Value="0">N&#7919;</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD class="QH_ColLabel" width="15%">
												Giới tính
												<asp:checkbox id="chkGioiTinhCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlGioiTinhCNMoi" CssClass="QH_DropDownList" Width="19%" Enabled="False" runat="server"
													EnableViewState="true">
													<asp:ListItem Value="1">Nam</asp:ListItem>
													<asp:ListItem Value="0">N&#7919;</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ngày sinh</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinhCNCu" CssClass="QH_TextBox" Width="100%" Runat="server" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Ngày sinh&nbsp;
												<asp:checkbox id="chkNgaySinhCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinhCNMoi" CssClass="QH_TextBox" Width="100%" Runat="server" Enabled="False"
													MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Thường trú</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTruCNCu" CssClass="QH_TextBox" Width="100%" Runat="server" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Thường trú&nbsp;
												<asp:checkbox id="chkDiaChiThuongTruCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTruCNMoi" CssClass="QH_TextBox" Width="100%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Chỗ ở hiện nay</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNayCNCu" CssClass="QH_TextBox" Width="100%" Runat="server" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Chỗ ở hiện nay
												<asp:checkbox id="chkChoOHienNayCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNayCNMoi" CssClass="QH_TextBox" Width="100%" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Số CMND</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtSoCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"
													MaxLength="20"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Số CMND&nbsp;
												<asp:checkbox id="chkSoCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtSoCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"
													MaxLength="20"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Ngày cấp</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtNgayCapCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Ngày cấp&nbsp;
												<asp:checkbox id="chkNgayCapCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtNgayCapCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"
													MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Nơi cấp</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtNoiCapCMNDCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Nơi cấp&nbsp;
												<asp:checkbox id="chkNoiCapCMNDCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtNoiCapCMNDCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="15%">Dân tộc</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtDanTocCNCu" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">
												Dân tộc&nbsp;
												<asp:checkbox id="chkDanTocCN" Runat="server" CssClass="" Text=""></asp:checkbox>
											</TD>
											<TD class="QH_ColControl" width="35%">
												<asp:textbox id="txtDanTocCNMoi" Runat="server" Width="100%" CssClass="QH_TextBox" Enabled="False"></asp:textbox></TD>
										</TR>
									</table>
									<!--THONG TIN NGUOI DAI DIEN-->
									<!--Hoangln sua lai table -->
									<BR>
									<asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">C&#7853;p nh&#7853;t</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton><asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Tr&#7903; v&#7873;</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD colSpan="5">
									<!--SET WIDTH=0-->
									<asp:textbox id="txtGiayCNDKKDID" CssClass="QH_TextBox" Width="0px" Runat="server" Visible="TRUE"></asp:textbox>
									<asp:textbox id="txtHoSoTiepNhanID" CssClass="QH_TextBox" Width="0px" Runat="server"></asp:textbox>
									<asp:textbox id="txtSoGiayPhepGoc" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox>
									<asp:textbox id="txtNgayCapGiayPhepGoc" CssClass="QH_TextBox" Width="30px" Runat="server" Visible="False"></asp:textbox>
									<asp:textbox id="txtReload" CssClass="QH_textbox" Width="0px" runat="server" Visible="False"></asp:textbox>
									<asp:image id="imgNgayDKBS" CssClass="QH_ImageButton" runat="server" Visible="False" AlternateText="Chọn lịch"
										ImageUrl="~\images\calendar.gif"></asp:image>
									<asp:textbox id="txtNgayDangKyBoSung" CssClass="QH_TextBox" Width="30%" Runat="server" Visible="False"></asp:textbox>
									<!--SET WIDTH=0-->
								</TD>
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
