<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HuyGPXD.ascx.vb" Inherits="CPXD.HuyGPXD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="center">
			<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="80%" border="0">
				<TR>
					<TD><asp:label id="lblHeader" Width="100%" CssClass="QH_Label_Title" runat="server">Thông tin hủy hồ sơ cấp giấy CN ĐKKD</asp:label></TD>
				</TR>
				<TR>
					<TD height="5"></TD>
				</TR>
				<tr>
					<td>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="20%"><asp:linkbutton id="btnDanhSachGP" runat="server">Số giấy phép<font size="2" color="#ff0000">*</font></asp:linkbutton><asp:label id="lblDanhSachGP" runat="server">Số giấy phép<font size="2" color="#ff0000">*</font></asp:label></TD>
								<TD width="*"><asp:textbox id="txtSoGiayPhep" Width="40%" CssClass="QH_TextBox" ReadOnly="True" Runat="server"></asp:textbox>&nbsp;</TD>
								<TD class="QH_ColLabel" width="15%">Ngày ÐKKD</TD>
								<TD width="25%"><asp:textbox id="txtNgayCapCNDKKD" Width="50%" CssClass="QH_TextBox" Runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Họ tên</TD>
								<TD><asp:textbox id="txtHoTen" Width="100%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></TD>
								<TD class="QH_ColLabel">Số CMND</TD>
								<TD><asp:textbox id="txtSoCMND" Width="50%" CssClass="QH_TextBox" Runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Địa chỉ</TD>
								<TD><asp:textbox id="txtDiaChi" Width="100%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></TD>
								<td></td>
								<td></td>
							</TR>
							<TR>
								<TD colSpan="4" height="10"></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" height="16">Lý do hủy<font size="2" color="#ff0000">*</font></TD>
								<TD><asp:dropdownlist id="ddlLyDoHuy" Width="100%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
								<td></td>
								<td></td>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Người duyệt<font size="2" color="#ff0000">*</font></TD>
								<TD><asp:dropdownlist id="ddlNguoiDuyet" Width="100%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">Ngày duyệt<font size="2" color="#ff0000">*</font></TD>
								<TD><asp:textbox id="txtNgayDuyet" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayDuyet" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch"
										ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel">Người hủy<font size="2" color="#ff0000">*</font></TD>
								<TD><asp:dropdownlist id="ddlNguoiHuy" Width="100%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
								<TD class="QH_ColLabel">Ngày hủy<font size="2" color="#ff0000">*</font></TD>
								<TD><asp:textbox id="txtNgayHuy" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayHuy" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch" ImageAlign="Middle"
										ImageUrl="~\images\calendar.gif"></asp:image></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD height="5"></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center"><asp:imagebutton id="btnCapNhat" runat="server" ImageUrl="~/IMAGES/btn_CapNhat.gif"></asp:imagebutton><asp:imagebutton id="btnXoa" runat="server" ImageUrl="~/IMAGES/btn_Xoa.gif"></asp:imagebutton><asp:imagebutton id="btnIn" runat="server" ImageUrl="~/IMAGES/btn_InRaGiay.gif"></asp:imagebutton><asp:imagebutton id="btnTroVe" runat="server" ImageUrl="~/IMAGES/btn_TroVe.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
<asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtNguoiTacNghiep" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtGiayCNDKKDID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReload" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox>
