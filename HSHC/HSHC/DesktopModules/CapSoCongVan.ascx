﻿<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapSoCongVan.ascx.vb" Inherits="HSHC.CongVan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblTieuDe" CssClass="QH_Label_Title" Width="100%" Runat="server">Cấp số công văn</asp:label>
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD align="center" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" class="QH_Khung_Left">
						<Table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr height="*">
								<td>
								</td>
							</tr>
							<tr height="141">
								<td class="QH_Khung_Left1">
								</td>
							</tr>
						</Table>
					</td>
					<td width="*">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="80%" border="0" align="center">
							<TR>
								<TD width="100%">
									<TABLE id="TblInfo" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TBODY>
											<tr>
												<td colSpan="2" height="5"></td>
											</tr>
											<TR>
												<td class="QH_ColLabel" height="19">Họ tên</td>
												<TD class="QH_ColControl">
													<asp:textbox id="txtHoTen" runat="server" Width="70%" CssClass="QH_Textbox" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<td class="QH_ColLabel">Địa chỉ</td>
												<TD class="QH_ColControl">
													<asp:textbox id="txtDiaChi" runat="server" Width="70%" CssClass="QH_Textbox" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<td class="QH_ColLabel">Nội dung</td>
												<TD class="QH_ColControl"><asp:textbox id="txtNoiDung" runat="server" Width="70%" CssClass="QH_Textbox" Enabled="False"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<td class="QH_ColLabel">Loại hồ sơ</td>
												<TD class="QH_ColControl"><asp:textbox id="txtTenLoaiHoSo" runat="server" Width="70%" CssClass="QH_Textbox" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<td class="QH_ColLabel" width="20%">Số công văn<FONT color="#ff0000" size="2">*</FONT></td>
												<TD width="40%" class="QH_ColControl"><asp:textbox id="txtSoCongVan" runat="server" Width="70px" CssClass="QH_Textbox" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<td class="QH_ColLabel">Ngày phát hành<FONT color="#ff0000" size="2">*</FONT></td>
												<td class="QH_ColControl"><asp:textbox id="txtNgayCongVan" runat="server" Width="70px" CssClass="QH_Textbox" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdNgayCongVan" CssClass="CommandButton" Runat="server">
														<asp:image id="imgNgayCongVan" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
													</asp:hyperlink></td>
											</TR>
											<TR>
												<td class="QH_ColLabel" height="19">Ghi chú</td>
												<TD class="QH_ColControl">
													<asp:textbox id="txtGhiChu" runat="server" Width="70%" CssClass="QH_Textbox" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<td class="QH_ColLabel">Hủy</td>
												<TD class="QH_ColControl">
													<asp:CheckBox id="chkHuy" runat="server"></asp:CheckBox></TD>
											</TR>
											<TR>
												<TD align="center" width="100%" colSpan="2" height="19"><asp:linkbutton id="btnCapNhat" CssClass="QH_Button" runat="server">Cập nhật</asp:linkbutton>&nbsp;
													<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server" Visible="False">Xóa</asp:linkbutton>&nbsp;
													<asp:linkbutton id="btnTroVe" CssClass="QH_Button" runat="server">Trở về</asp:linkbutton></TD>
											</TR>
											<tr>
												<td><asp:textbox id="txtMaNhomCongVan" Runat="server" Width="0px"></asp:textbox>
													<asp:textbox id="txtHoSoTiepNhanID" Runat="server" Width="0px"></asp:textbox><asp:textbox id="txtCongVanID" Runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaHoSo" Runat="server" Width="0px"></asp:textbox></td>
											</tr>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
		<td width="16" class="QH_Khung_Right">
			<Table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr height="*">
					<td>
					</td>
				</tr>
				<tr height="141">
					<td class="QH_Khung_Right1">
					</td>
				</tr>
			</Table>
		</td>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
