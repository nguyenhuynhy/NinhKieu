<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HuyGiayCNDKKD.ascx.vb" Inherits="CPXD.HuyGiayCNDKKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" Width="100%" CssClass="QH_Label_Title" runat="server">Thông tin hủy hồ sơ cấp giấy phép xây dựng</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<TR>
								<TD height="5"></TD>
							</TR>
							<tr>
								<td>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<TR>
											<TD class="QH_ColLabel" width="20%"><asp:linkbutton id="btnDanhSachGP" runat="server">Số giấy phép<font size="2" color="#ff0000">*</font></asp:linkbutton><asp:label id="lblDanhSachGP" runat="server">Số giấy phép<font size="2" color="#ff0000">*</font></asp:label></TD>
											<TD class="QH_ColControl" width="*"><asp:textbox id="txtSoGiayPhep" Width="40%" CssClass="QH_TextBox" ReadOnly="True" Runat="server"></asp:textbox>&nbsp;</TD>
											<TD class="QH_ColLabel" width="15%">Ngày đăng ký</TD>
											<TD class="QH_ColControl" width="25%"><asp:textbox id="txtNgayCapCNDKKD" Width="50%" CssClass="QH_TextBox" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Họ tên</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></TD>
											<TD class="QH_ColLabel">Số CMND</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" Width="50%" CssClass="QH_TextBox" Runat="server" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Địa chỉ</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtDiaChi" Width="90%" CssClass="QH_TextBox" runat="server" Enabled="False"></asp:textbox></TD>
											<td></td>
											<td></td>
										</TR>
										<TR>
											<TD colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" height="15">Lý do hủy<font size="2" color="#ff0000">*</font></TD>
											<TD class="QH_ColControl" height="15"><asp:dropdownlist id="ddlLyDoHuy" Width="90%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
											<td height="15"></td>
											<td height="15"></td>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Người duyệt<font size="2" color="#ff0000">*</font></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlNguoiDuyet" Width="90%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel">Ngày duyệt<font size="2" color="#ff0000">*</font></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayDuyet" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayDuyet" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch"
													ImageAlign="Middle" ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Người hủy<font size="2" color="#ff0000">*</font></TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlNguoiHuy" Width="90%" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
											<TD class="QH_ColLabel">Ngày hủy<font size="2" color="#ff0000">*</font></TD>
											<TD class="QH_ColControl"><asp:textbox id="txtNgayHuy" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayHuy" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch" ImageAlign="Middle"
													ImageUrl="~\images\calendar.gif"></asp:image></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In thông báo</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
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
<asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtNguoiTacNghiep" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtGiayPhepXayDungID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReload" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox>
