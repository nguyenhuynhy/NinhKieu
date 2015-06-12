<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhanQuyenChucNang.ascx.vb" Inherits="PortalQH.PhanQuyenChucNang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblMenu" runat="server" Width="100%" CssClass="QH_Label_Title"></asp:label>
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
						<table width="100%">
							<tr>
								<td align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD vAlign="top" width="100%" align="center">
												<TABLE class="QH_LoaiHS" id="Table2" width="100%" align="center">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="25%" height="50"><STRONG>Danh sách tab</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="40%">
															<asp:dropdownlist id="ddlTab" runat="server" Width="100%"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="*">
															<asp:LinkButton CssClass="QH_Button" id="btnThucHien" runat="server">Thực hiện</asp:LinkButton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<TABLE id="Table4" width="100%">
													<TR>
														<TD vAlign="top" width="70%">
															<TABLE id="Table5" width="100%">
																<TR>
																	<TD vAlign="top" width="100%" align="center">
																		<asp:datagrid id="grdPhanQuyen" runat="server" CssClass="QH_DataGridbottom" PageSize="3" autogeneratecolumns="False"
																			width="100%">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="STT">
																					<ItemStyle HorizontalAlign="Right"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="txtSTT" runat="server" cssclass= "QH_ColLabelMiddle" Width="100%" Text="<%# grdPhanQuyen.CurrentPageIndex*grdPhanQuyen.PageSize + grdPhanQuyen.Items.Count+1 %>">
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Lĩnh vực">
																					<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblTabCode" Visible="False" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.TabCode") %>'>
																						</asp:Label>
																						<asp:Label id="lblItemCode" Visible="False" runat="server" Width="0px" Text='<%# DataBinder.Eval(Container, "DataItem.ItemCode") %>'>
																						</asp:Label>
																						<asp:Label id="lblItemName" runat="server" cssclass= "QH_ColLabelLeft" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Chọn">
																					<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox ID="chkChon" Runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"IsCheckUser")) %>'>
																						</asp:CheckBox>
																					</ItemTemplate>
																					<FooterStyle HorizontalAlign="Center"></FooterStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid>
																	</TD>
																</TR>
																<TR>
																	<TD vAlign="top" align="center">
																		<asp:LinkButton CssClass="QH_Button" id="btnCapNhat" runat="server">Cập nhật</asp:LinkButton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
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
