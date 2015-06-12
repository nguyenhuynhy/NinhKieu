<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Admin_AddChucNang.ascx.vb" Inherits="HSHC.Admin_AddChucNang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">DANH SÁCH CHỨC NĂNG</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top">
						<!--End bound-->
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD height="313" valign="top">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Tên chức năng</TD>
																	<TD>
																		<asp:TextBox id="txtTenChucNang" Width="50%" CssClass="QH_Textbox" runat="server"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Giá trị</TD>
																	<TD>
																		<asp:TextBox id="txtTenTrang" Width="50%" CssClass="QH_Textbox" runat="server"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD width="200" class="QH_ColLabel">Độ ưu tiên</TD>
																	<TD>
																		<asp:TextBox id="txtSoThuTu" Width="20%" CssClass="QH_TextRight" runat="server" MaxLength="3"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Tương đương</TD>
																	<TD>
																		<asp:DropDownList id="ddlTuongDuong" Width="20%" CssClass="QH_DropdownList" runat="server"></asp:DropDownList>&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Trình bày</TD>
																	<TD>
																		<asp:CheckBox id="chkIsShow" runat="server"></asp:CheckBox>&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<tr>
														<td height="10">
														</td>
													</tr>
													<TR>
														<TD align="center">
															<asp:Label height="18" id="lblTitle1" Class="QH_DataGridHeader" Width="90%" runat="server">CHỌN VAI TRÒ CHO CHỨC NĂNG</asp:Label></TD>
													</TR>
													<TR>
														<TD align="center">
															<asp:CheckBoxList class="QH_Textbox" Width="90%" id="cklVaiTro" runat="server" RepeatColumns="3"></asp:CheckBoxList></TD>
													</TR>
													<TR>
														<TD align="center"><asp:CheckBox id="chkPUB" runat="server" Text="Tất cả đều sử dụng"></asp:CheckBox>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="center"><asp:ImageButton id="btnCapNhat" runat="server" ImageUrl="../../Images/btn_CapNhat.gif" CssClass="QH_Button"></asp:ImageButton>
												<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_Trove.gif" CssClass="QH_Button"></asp:ImageButton>
												<asp:TextBox id="txtMaChucNang" Width="0px" runat="server"></asp:TextBox>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="12">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="128" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="130" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->