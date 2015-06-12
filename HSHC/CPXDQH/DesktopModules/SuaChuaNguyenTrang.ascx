<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SuaChuaNguyenTrang.ascx.vb" Inherits="CPXD.SuaChuaNguyenTrang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="label1" CssClass="QH_Label_Title" Runat="server" Width="100%"> Thông tin sửa chữa nguyên trạng hồ sơ </asp:label></td>
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
						<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="98%" border="0" align="center">
							<tr valign="top">
								<td colSpan="2" height="5"></td>
							</tr>
							<tr valign="top">
								<td width="50%" align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<tr valign="top">
											<td class="QH_ColLabel" width="25%" valign="top"><asp:linkbutton id="btnSoBN" Runat="server">Số biên nhận</asp:linkbutton><asp:label id="lblSoBN" CssClass="QH_ColLabel" runat="server">Số biên nhận<font color="Red">
														*</font></asp:label></td>
											<td class="QH_ColControl" valign="top"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Runat="server" Width="40%" ReadOnly="True"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="25%">Ngày giải quyết<font color="red">*</font>
											</td>
											<TD class="QH_ColControl" width="70%"><asp:textbox id="txtNgayXacNhan" CssClass="QH_TextBox" Runat="server" Width="32%" MaxLength="10"></asp:textbox>&nbsp;
												<asp:hyperlink id="cmdCalendar" CssClass="CommandButton" Runat="server">
													<asp:image id="btnDenNgay" AlternateText="Chọn ngày" CssClass="QH_imageButton" Runat="server"
														ImageUrl="~/Images/calendar.gif"></asp:image>
												</asp:hyperlink></TD>
										</tr>
										<tr valign="top">
											<td class="QH_ColLabel" width="25%" valign="top">Nội dung hồ sơ
											</td>
											<td class="QH_ColControl" vAlign="top"><asp:textbox id="txtNoiDungXuLy" CssClass="QH_Textbox" Runat="server" Width="90%" MaxLength="500"
													TextMode="MultiLine" Rows="4"></asp:textbox></td>
										</tr>
										<tr valign="top">
											<td class="QH_ColLabel" width="25%" valign="top">Ghi chú
											</td>
											<td class="QH_ColControl" height="67"><asp:textbox id="txtGhiChu" CssClass="QH_Textbox" Runat="server" Width="90%" MaxLength="500"
													TextMode="MultiLine" Rows="4"></asp:textbox></td>
										</tr>
									</TABLE>
								</td>
								<td vAlign="top" width="50%">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<tr>
											<td class="QH_ColLabel" width="25%">Họ tên</td>
											<td class="QH_ColControl"><asp:textbox id="txtHoten" CssClass="QH_TextBox" Runat="server" Width="70%" ReadOnly="True"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="25%">Thường trú</td>
											<td class="QH_ColControl"><asp:textbox id="txtDiaChiThuongTru" CssClass="QH_TextBox" Runat="server" Width="70%" ReadOnly="True"
													Rows="1" TextMode="MultiLine"></asp:textbox></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="25%" height="21">Loại cấp phép</td>
											<td class="QH_ColControl" height="21"><asp:dropdownlist id="ddlTenLoaiHoSo" CssClass="QH_DropDownList" Runat="server" Width="70%" Enabled="False"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="QH_ColLabel" width="25%" height="18">Lãnh đạo ký <font color="red">*</font>
											</td>
											<td class="QH_ColControl" height="18"><asp:dropdownlist id="ddlLanhDaoKy" CssClass="QH_DropDownList" Runat="server" Width="70%"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td align="center" width="80%" colSpan="2">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
													<tr>
														<td height="5"></td>
													</tr>
													<tr>
														<td align="left" width="100%" colSpan="2"><strong>Ðịa chỉ xây dựng</strong></td>
													</tr>
													<tr vAlign="top">
														<td class="QH_ColLabel" align="left" width="30%">Số nhà
														</td>
														<td class="QH_ColControl" width="70%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Runat="server" ReadOnly="True"></asp:textbox></td>
													</tr>
													<tr vAlign="top">
														<td class="QH_ColLabel" align="left" width="30%">Ðường phố
														</td>
														<td class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlDuong" CssClass="QH_DropDownList" Runat="server" Width="70%" Enabled="False"></asp:dropdownlist></td>
													</tr>
													<tr vAlign="top">
														<td class="QH_ColLabel" align="left" width="30%">Phường
														</td>
														<td class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" Runat="server" Width="70%" Enabled="False"></asp:dropdownlist></td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<TD height="25"><asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaLinhVuc" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtHoSoNguyenTrangID" Width="0px" runat="server"></asp:textbox></TD>
							</tr>
							<tr>
								<td align="center" colSpan="2">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">&nbsp;In&nbsp;</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
								</td>
							</tr>
							<tr>
								<td height="10">
								</td>
							</tr>
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
