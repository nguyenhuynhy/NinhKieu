<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NoiQuyLaoDong.ascx.vb" Inherits="CPLDQH.NoiQuyLaoDong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
	class="QH_Table">
	<tr>
		<td colSpan="3">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Đăng ký nội quy lao động</asp:label></td>
					<td class="QH_Khung_TopRight" width="16"></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<td class="QH_ColLabel" width="20%">Số biên nhận<font color="#ff0000" size="2">&nbsp;*</font></td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtSoBienNhan" CssClass="QH_TextBox" Width="90%" runat="server" ReadOnly="True"></asp:textbox></td>
		<td align="left" width="*">&nbsp;
			<asp:label id="Label1" CssClass="QH_LabelLeftBold" runat="server">Kết quả giải quyết</asp:label></td>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Tên đơn vị<font color="#ff0000" size="2">&nbsp;*</font></td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtHoTen" CssClass="QH_TextBox" Width="90%" runat="server" tabIndex="1"></asp:textbox></td>
		<td vAlign="top" width="90%" rowspan="2"><asp:textbox id="txtKetQuaGiaiQuyet" CssClass="QH_TextBox" Width="92%" runat="server" Rows="3"
				TextMode="MultiLine" tabIndex="9"></asp:textbox></td>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Loại hình DN<font color="#ff0000" size="2">&nbsp;*</font></td>
		<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaLoaiHinhDoanhNghiep" CssClass="QH_dropdownlist" Width="90%" runat="server"
				tabIndex="2"></asp:dropdownlist></td>
	</TR>
	<TR id="rowSoThongBao" runat="server">
		<td class="QH_ColLabel" width="20%" height="30">Số thông báo</td>
		<td class="QH_ColControl" width="30%" height="30"><asp:textbox id="txtSoThongBao" CssClass="QH_TextBox" Width="90%" runat="server" tabIndex="3"></asp:textbox></td>
	</TR>
	<TR id="rowNgayThongBao" runat="server">
		<td class="QH_ColLabel" width="20%">Ngày thông báo</td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtNgayThongBao" CssClass="QH_TextBox" Width="30%" runat="server" tabIndex="4"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayThongBao" CssClass="CommandButton" runat="server">
				<asp:image id="imgNgayThongBao" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>&nbsp;
		</td>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="20%">Ngày ĐK nội quy<font color="#ff0000" size="2">&nbsp;*</font></TD>
		<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayDangKyNoiQuy" CssClass="QH_TextBox" Width="30%" runat="server" tabIndex="5"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayDangKyNoiQuy" CssClass="CommandButton" runat="server">
				<asp:image id="imgNgayDangKyNoiQuy" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>&nbsp;
		</TD>
		<TD width="*" rowSpan="6">&nbsp;&nbsp;
			<asp:label id="Label15" CssClass="QH_LabelLeftBold" runat="server">Địa chỉ đơn vị</asp:label>
			<table class="QH_Table" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_ColLabel" width="30%">Số nhà<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="45%" runat="server" tabIndex="10"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Phường<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl">
						<cc1:KeySortDropDownList id="ddlMaPhuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></td>
				</tr>
				<tr>
					<td class="QH_ColLabel" height="21">Đường<font color="#ff0000" size="2">&nbsp;*</font></td>
					<td class="QH_ColControl" height="21">
						<cc1:KeySortDropDownList id="ddlMaDuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:KeySortDropDownList></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Điện thoại</td>
					<td class="QH_ColControl"><asp:textbox id="txtDienThoai" CssClass="QH_TextBox" Width="45%" runat="server" tabIndex="13"></asp:textbox></td>
				</tr>
				<tr>
					<td class="QH_ColLabel">Chọn mẫu thông báo</td>
					<td class="QH_ColControl" width="100%"><asp:radiobuttonlist id="rblBieuMau" runat="server" RepeatDirection="Horizontal" tabIndex="14">
							<asp:ListItem Value="0" Selected="True">In lần đầu</asp:ListItem>
							<asp:ListItem Value="1">In sửa đổi, bổ sung</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Họ tên giám đốc</td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtHoTenGiamDoc" CssClass="QH_TextBox" Width="90%" runat="server" tabIndex="6"></asp:textbox></td>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Tổng số lao động</FONT></td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtTongSoLD" CssClass="QH_TextBox" Width="50%" runat="server" tabIndex="6" style="TEXT-ALIGN:right"></asp:textbox></td>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Thời hạn nội quy<font color="#ff0000" size="2">&nbsp;*</font></td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtThoiHanNoiQuy" CssClass="QH_TextBox" Width="90%" runat="server" tabIndex="6"></asp:textbox></td>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Ngày xác nhận hồ sơ<font color="#ff0000" size="2">&nbsp;*</font></td>
		<td class="QH_ColControl" width="30%"><asp:textbox id="txtNgayXacNhan" CssClass="QH_TextBox" Width="30%" runat="server" tabIndex="7"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayXacNhan" runat="server">
				<asp:image id="imgNgayXacNhan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></td>
	</TR>
	<TR>
		<td class="QH_ColLabel" width="20%">Lãnh đạo duyệt<font color="#ff0000" size="2">&nbsp;*</font></td>
		<td class="QH_ColControl" width="30%"><asp:dropdownlist id="ddlMaSoLanhDao" CssClass="QH_dropdownlist" Width="90%" runat="server" tabIndex="8"></asp:dropdownlist></td>
	</TR>
	<tr>
		<td colSpan="3"></td>
	</tr>
	<tr>
		<td align="center" width="100%" colSpan="3"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server" tabIndex="15">Cập nhật</asp:linkbutton><asp:linkbutton id="btnXoa" CssClass="QH_Button" Width="50px" runat="server" tabIndex="16">Xoá</asp:linkbutton><asp:linkbutton id="btnYCBS" CssClass="QH_Button" runat="server" tabIndex="17">Bổ sung hồ sơ</asp:linkbutton><asp:linkbutton id="btnHoSoKhong" CssClass="QH_Button" runat="server" tabIndex="18">Hồ sơ không giải quyết</asp:linkbutton><asp:linkbutton id="btnIn" CssClass="QH_Button" runat="server" tabIndex="19">In thông báo</asp:linkbutton><asp:linkbutton id="btnBoQua" CssClass="QH_Button" runat="server" tabIndex="20">Trở về</asp:linkbutton></td>
	</tr>
</TABLE>
<asp:textbox id="txtNoiQuyLaoDongID" runat="server" Visible="false"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtTabCode" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Visible="False"></asp:textbox>
