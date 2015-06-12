<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HoSoKhong.ascx.vb" Inherits="CPKTQH.HoSoKhong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td height="5"></td>
	</tr>
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">Thông tin không giải quyết hồ sơ</asp:label></td>
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
					<td width="*">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
										<TR>
											<TD colSpan="3" height="5"></TD>
										</TR>
										<tr vAlign="middle">
											<td vAlign="middle" width="*">
												<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td height="5"></td>
													</tr>
													<tr>
														<td colspan="4" Class="QH_LabelLeftBold"><strong>Thông tin hồ sơ tiếp nhận</strong></td>
													</tr>
													<tr>
														<td height="5"></td>
													</tr>
													<TR>
														<TD class="QH_ColLabel" width="20%" height="20">Số biên nhận</TD>
														<TD class="QH_ColControl" width="35%" height="20">
															<asp:Label id="lblSoHoSo" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
														<TD class="QH_ColLabel" width="15%" height="20">Họ tên</TD>
														<TD class="QH_ColControl" width="30%" height="20">
															<asp:Label id="lblHoTen" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" height="20">Ngày nhận</TD>
														<TD class="QH_ColControl" height="20">
															<asp:Label id="lblNgayNopDon" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
														<TD class="QH_ColLabel">Giới tính</TD>
														<TD class="QH_ColControl">
															<asp:Label id="lblGioiTinh" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" height="20">Loại hồ sơ</TD>
														<TD class="QH_ColControl" height="20">
															<asp:Label id="lblTenLoaiHoSo" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
														<TD class="QH_ColLabel">Số CMND</TD>
														<TD class="QH_ColControl">
															<asp:Label id="lblSoCMND" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel" height="20">Địa chỉ kinh doanh</TD>
														<TD class="QH_ColControl">
															<asp:Label id="lblDiaChiKinhDoanh" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
														<TD class="QH_ColLabel">Địa chỉ cư trú</TD>
														<TD class="QH_ColControl">
															<asp:Label id="lblDiaChi" runat="server" CssClass="QH_LabelLeftBold"></asp:Label></TD>
													</TR>
													<tr>
														<td height="5"></td>
													</tr>
													<tr>
														<td colspan="4" Class="QH_LabelLeftBold"><strong>Thông tin không giải quyết</strong></td>
													</tr>
													<tr>
														<td height="5"></td>
													</tr>
													<TR>
														<TD class="QH_ColLabel">
															Lý do<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlLyDo" runat="server" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"></asp:dropdownlist></TD>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Lãnh đạo ký<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDao" runat="server" Width="100%" CssClass="QH_DropDownList" EnableViewState="true"></asp:dropdownlist></TD>
														<TD class="QH_ColLabel">Ngày xử lý<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl"><asp:textbox id="txtNgayXuLy" Width="40%" CssClass="QH_textbox" Runat="server" EnableViewState="true"
																MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgNgayXuLy" runat="server" CssClass="QH_ImageButton" ImageUrl="~\images\calendar.gif"
																AlternateText="Chọn lịch"></asp:image></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Nội dung xử lý<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtNoiDungXuLy" Width="100%" CssClass="QH_textbox" Runat="server" EnableViewState="true"
																TextMode="MultiLine" Rows="3" MaxLength="1000"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Ghi chú</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtGhiChu" Width="100%" CssClass="QH_textbox" Runat="server" EnableViewState="true"
																TextMode="MultiLine" Rows="3" MaxLength="1000"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
											<td width="5%"></td>
										</tr>
										<TR>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3" height="5"></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center" colSpan="3"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>
									<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>
									<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton></TD>
							</TR>
						</TABLE>
						<asp:textbox id="txtTabCode" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtLinhVuc" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtNguoiTacNghiep" runat="server" Width="0px"></asp:textbox></td>
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
<div style="DISPLAY:none"><asp:TextBox ID="txtHoSoKhongGiaiQuyetID" Runat="server" Enabled="False"></asp:TextBox></div>
