<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongBaoBSHS.ascx.vb" Inherits="HSHC.ThongBaoBSHS" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:Label ID="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title"></asp:Label>
					</td>
					<td width="16" height="24" class="QH_Khung_TopRight">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0" width="90%">
										<TR>
											<TD colspan="4" height="5">
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" width="99%" class="QH_Table">
													<TBODY>
														<TR>
															<TD width="25%" class="QH_ColLabel">Số biên nhận</TD>
															<TD width="25%" class="QH_ColControl">
																<asp:TextBox id="txtSoBienNhan" runat="server" CssClass="QH_Textbox" Width="100%" Enabled="False"></asp:TextBox></TD>
															<TD width="25%" class="QH_ColLabel">Ngày nộp hồ sơ</TD>
															<TD width="25%" class="QH_ColControl">
																<asp:TextBox id="txtNgayNhan" runat="server" CssClass="QH_Textbox" Width="70px" Enabled="False"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Họ tên người nộp</TD>
															<TD colspan="3" class="QH_ColControl">
																<asp:TextBox id="txtHoTenNguoiNop" runat="server" CssClass="QH_Textbox" Width="100%" Enabled="False"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Địa chỉ</TD>
															<TD colspan="3" class="QH_ColControl">
																<asp:TextBox id="txtDiaChi" runat="server" CssClass="QH_TextBox" Width="100%" Enabled="False"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Loại hồ sơ</TD>
															<TD colspan="3" class="QH_ColControl">
																<asp:TextBox id="txtLoaiHoSo" runat="server" CssClass="QH_TextBox" Width="100%" Enabled="False"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel">Ngày yêu cầu<font size="2" color="#ff0000">*</font></TD>
															<TD class="QH_ColControl">
																<asp:TextBox id="txtNgayYeuCau" runat="server" CssClass="QH_TextBox" Width="70px"></asp:TextBox>
															</TD>
															<TD colspan="2" class="QH_ColControl">
																&nbsp;<asp:hyperlink id="cmdNgayYeuCau" CssClass="CommandButton" Runat="server">
																	<asp:image id="imgNgayYeuCau" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
																</asp:hyperlink>
																&nbsp;&nbsp;<asp:TextBox id="txtSoNgayBoSung" runat="server" CssClass="QH_TextRight" Width="30px"></asp:TextBox>&nbsp;&nbsp;( 
																ngày )
															</TD>
											</TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Ngày phải nộp hồ sơ<font size="2" color="#ff0000">*</font></TD>
											<TD>
												<asp:TextBox id="txtNgayNop" runat="server" CssClass="QH_TextBox" Width="70px" ReadOnly="True"></asp:TextBox>
											</TD>
											<TD colspan="2">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Nội dung yêu cầu<font size="2" color="#ff0000">*</font></TD>
											<TD colspan="3">
												<asp:TextBox id="txtNoiDungYeuCau" runat="server" CssClass="QH_TextBox" Width="100%" TextMode="MultiLine"
													Rows="5"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<td height="5"></td>
							</TR>
							<tr>
								<td valign="bottom" align="center">
									<asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnInThu" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>&nbsp;
									<asp:linkbutton id="btnTroVe" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton>
								</td>
							</tr>
						</TABLE>
						<asp:TextBox id="txtHoSoBoSungID" CssClass="QH_Textbox" Width="0px" runat="server" Visible="true"></asp:TextBox>
						<asp:TextBox id="txtHoSoTiepNhanID" CssClass="QH_Textbox" Width="0px" runat="server" Visible="true"></asp:TextBox>
						<asp:TextBox id="txtMaNguoiNhan" CssClass="QH_Textbox" Width="0px" runat="server" Visible="true"></asp:TextBox>
						<asp:TextBox id="txtMaLinhVuc" CssClass="QH_Textbox" Width="0px" runat="server" Visible="true"></asp:TextBox>
						<asp:TextBox id="txtTabCode" CssClass="QH_Textbox" Width="0px" runat="server" Visible="true"></asp:TextBox>
					</td>
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
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
