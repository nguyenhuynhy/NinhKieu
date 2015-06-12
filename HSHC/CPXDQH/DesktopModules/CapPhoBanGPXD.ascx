<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CapPhoBanGPXD.ascx.vb" Inherits="CPXD.CapPhoBanGPXD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="Label1" Width="100%" CssClass="QH_Label_Title" runat="server">Cấp phó bản giấy phép xây dựng </asp:label></td>
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
						<TABLE align="center" id="Table1" height="200" cellSpacing="0" cellPadding="0" width="98%"
							border="0">
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="right" width="55%">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
													<TR>
														<TD class="QH_ColLabel" width="25%">
															<asp:Label id="lblSoBN" CssClass="QH_ColLabel" runat="server">Số biên nhận</asp:Label><font color="red">*</font>
														</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtSoBienNhan" Width="37%" CssClass="QH_Textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" width="25%">
															<asp:LinkButton cssclass="QH_ColLabel" id="btnDanhSachGP" runat="server" ToolTip="Lấy thông tin giấp phép">Số giấy phép</asp:LinkButton><asp:Label Runat="server" ID="lblSao"><font color="Red">*</font></asp:Label>
															<asp:Label cssclass="QH_ColLabel" id="lblSoGP" runat="server">Số giấy phép</asp:Label></FONT>
														</TD>
														<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoGiayPhep" Width="80%" CssClass="QH_Textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
														<TD width="15%" class="QH_ColLabel">&nbsp;Ngày GP&nbsp;
														</TD>
														<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayCapPhep" Width="70%" CssClass="QH_Textbox" runat="server" ReadOnly="True"></asp:textbox>
															&nbsp;&nbsp;
														</TD>
													</TR>
													<TR valign="top">
														<TD class="QH_ColLabel" width="20%">&nbsp;Số quyết định &nbsp;
														</TD>
														<TD class="QH_ColControl" width="30%" valign="top"><asp:textbox id="txtSoQuyetDinh" Width="80%" CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
														<TD width="15%" class="QH_ColLabel">&nbsp;Ngày QĐ&nbsp;
														</TD>
														<TD class="QH_ColControl" width="30%"><asp:textbox id="txtNgayQuyetDinh" Width="70%" CssClass="QH_Textbox" runat="server"></asp:textbox>
															<asp:hyperlink id="cmdNgayQuyetDinh" CssClass="CommandButton" Runat="server">
																<asp:Image runat="server" BorderWidth="0px" ID="btnNgayQD" ImageUrl="~/Images/calendar.gif"
																	CssClass="QH_imageButton"></asp:Image>
															</asp:hyperlink>
														</TD>
													</TR>
												</TABLE>
											</TD>
											<TD align="left" width="45%" valign="top">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
													<tr>
														<TD width="35%" class="QH_ColLabel">Ngày cấp phó bản<font color="red">*</font></TD>
														<TD class="QH_ColControl" width="65%"><asp:textbox id="txtNgayCapPhoBan" Width="40%" CssClass="QH_Textbox" runat="server"></asp:textbox>
															<asp:hyperlink id="cmdNgayCap" CssClass="CommandButton" Runat="server">
																<asp:image id="Image1" BorderWidth="0" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
															</asp:hyperlink>
														</TD>
													</tr>
													<TR>
														<TD class="QH_ColLabel" width="35%">Ghi chú&nbsp;</TD>
														<TD class="QH_ColControl" width="65%"><asp:TextBox id="txtGhiChu" runat="server" TextMode="MultiLine" CssClass="QH_Textbox" Width="85%"></asp:TextBox>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
										<TR>
											<TD colSpan="4">&nbsp;
												<asp:label id="Label3" CssClass="QH_LabelLeftBold" runat="server">Thông tin tham khảo</asp:label>
											</TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="8%">Họ tên
											</TD>
											<TD class="QH_ColControl" width="30%"><asp:textbox id="txtHoTen" Width="90%" CssClass="QH_textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="8%">Phân loại XD
											</TD>
											<TD class="QH_ColControl" width="30%">
												<asp:textbox id="txtLoaiXayDung" runat="server" CssClass="QH_textbox" Width="88%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="8%">Thường trú
											</TD>
											<TD class="QH_ColControl" width="30%"><asp:textbox id="txtDiaChiThuongTru" Width="90%" CssClass="QH_textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="8%">Cấp nhà
											</TD>
											<TD class="QH_ColControl" width="30%">
												<asp:textbox id="txtCapNha" runat="server" CssClass="QH_textbox" Width="88%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="8%">Địa chỉ XD
											</TD>
											<TD class="QH_ColControl" width="30%"><asp:textbox id="txtDiaChiXayDung" Width="90%" CssClass="QH_textbox" runat="server" ReadOnly="True"></asp:textbox></TD>
											<TD width="8%"></TD>
											<TD width="30%"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" height="10"></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInDexuat" runat="server" CssClass="QH_Button">In đề xuất</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInGP" runat="server" CssClass="QH_Button">In giấy phép</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnHoSoKhong" runat="server" CssClass="QH_Button">Hồ sơ không</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInQD" runat="server" CssClass="QH_Button">In quyết định</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnBoQua" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
									<asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtReload" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtMaNguoiTacNghiep" runat="server" Width="0px"></asp:textbox>
									<asp:textbox id="txtTabCode" runat="server" Width="0px"></asp:textbox>
								</TD>
							</TR>
							<TR>
								<td></td>
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
