<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HoSoKhong.ascx.vb" Inherits="CPXD.HoSoKhong" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server"> Thông tin không giải quyết hồ sơ</asp:label></td>
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
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
										<TR>
											<TD height="5"></TD>
										</TR>
										<tr vAlign="middle">
											<td vAlign="middle" width="*">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
													<TR vAlign="middle">
														<TD class="QH_ColLabel" width="22%"><asp:label id="lblDanhSach" runat="server">Số biên nhận<font size="2" color="#ff0000">*</font></asp:label></TD>
														<TD class="QH_ColControl" width="48%"><asp:textbox id="txtSoBienNhan" CssClass="QH_textbox" Width="50%" ReadOnly="True" EnableViewState="true"
																Runat="server"></asp:textbox>&nbsp;
														</TD>
														<TD class="QH_ColLabel" width="15%">Ngày nộp đơn</TD>
														<TD class="QH_ColControl" width="15%"><asp:textbox id="txtNgayNopDon" CssClass="QH_textbox" Width="100%" EnableViewState="true" Runat="server"
																Enabled="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Họ tên</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtHoTen" CssClass="QH_textbox" Width="100%" runat="server" EnableViewState="true"
																Enabled="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Ðịa chỉ</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtDiaChi" CssClass="QH_textbox" Width="100%" EnableViewState="true" Runat="server"
																Enabled="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Nội dung XD</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtMatHang" CssClass="QH_textbox" Width="100%" EnableViewState="true" Runat="server"
																Enabled="False" Rows="3" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Loại hồ sơ</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtLoaiHoSo" CssClass="QH_TextBox" Width="100%" runat="server" EnableViewState="true"
																Enabled="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Lý do không giải quyết<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlLyDo" CssClass="QH_DropDownList" Width="100%" runat="server" EnableViewState="true"></asp:dropdownlist></TD>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Lãnh đạo ký<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl"><asp:dropdownlist id="ddlMaSoLanhDao" CssClass="QH_DropDownList" Width="100%" runat="server" EnableViewState="true"></asp:dropdownlist></TD>
														<TD class="QH_ColLabel">Ngày xử lý<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl"><asp:textbox id="txtNgayXuLy" CssClass="QH_textbox" Width="70%" EnableViewState="true" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgNgayXuLy" CssClass="QH_Button" runat="server" AlternateText="Chọn lịch" ImageAlign="Middle"
																ImageUrl="~\images\calendar.gif"></asp:image></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Nội dung xử lý<font color="#ff0000" size="2">*</font></TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtNoiDungXuLy" CssClass="QH_textbox" Width="100%" EnableViewState="true" Runat="server"
																Rows="3" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Ghi chú</TD>
														<TD class="QH_ColControl" colSpan="3"><asp:textbox id="txtGhiChu" CssClass="QH_textbox" Width="100%" EnableViewState="true" Runat="server"
																Rows="3" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td height="5">
												<asp:CheckBox id="chkQuaHan" runat="server" Text="Hồ sơ quá hạn" CssClass="QH_Checkbox"></asp:CheckBox>
											</td>
										</tr>
										<TR>
											<TD vAlign="middle" align="center">
												<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In thông báo</asp:linkbutton>&nbsp;
												<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>&nbsp;
											</TD>
										</TR>
									</TABLE>
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
<asp:textbox id="txtTabCode" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtLinhVuc" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:textbox><asp:textbox id="txtNguoiTacNghiep" Width="0px" runat="server"></asp:textbox>
