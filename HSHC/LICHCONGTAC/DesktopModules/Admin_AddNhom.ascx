<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Admin_AddNhom.ascx.vb" Inherits="LICHCONGTAC.Admin_AddNhom" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">DANH SÁCH NHÓM</asp:label>
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
								<TD align="center" valign="top">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD height="313" valign="top">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Tên nhóm</TD>
																	<TD>
																		<asp:TextBox id="txtTenNhom" Width="50%" CssClass="QH_Textbox" runat="server"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="200">Chủ trì</TD>
																	<TD>
																		<asp:RadioButtonList class="QH_Textbox" id="rblChutri" runat="server" Width="50%" RepeatDirection="Horizontal">
																			<asp:ListItem Value="N" Selected="True">Kh&#244;ng c&#243; chủ tr&#236;</asp:ListItem>
																			<asp:ListItem Value="Y">C&#243; chủ tr&#236;</asp:ListItem>
																		</asp:RadioButtonList></TD>
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
																		<asp:TextBox id="txtStt" Width="10%" CssClass="QH_TextRight" runat="server" MaxLength="3"></asp:TextBox></TD>
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
															<asp:Label height="18" id="lblTitle1" CssClass="QH_DataGridHeader" Width="90%" runat="server">Chọn thành viên cho nhóm</asp:Label></TD>
													</TR>
													<TR>
														<TD align="center">
															<asp:CheckBoxList Cssclass="QH_LoaiHS" Width="90%" id="cklThanhvien" runat="server" RepeatColumns="3"
																RepeatLayout="Table"></asp:CheckBoxList></TD>
													</TR>
													<tr>
														<td height="5">
														</td>
													</tr>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="center"><asp:ImageButton id="btnCapNhat" runat="server" ImageUrl="../../Images/btn_CapNhat.gif" CssClass="QH_Button"></asp:ImageButton>
												<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_Trove.gif" CssClass="QH_Button"></asp:ImageButton>
												<asp:TextBox id="txtThanhVien" width="0px" runat="server"></asp:TextBox>
												<asp:TextBox id="txtMaNhom" Width="0px" runat="server"></asp:TextBox>
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
					<td width="9" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="8" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
