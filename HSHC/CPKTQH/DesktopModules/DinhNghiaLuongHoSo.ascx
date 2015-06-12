<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DinhNghiaLuongHoSo.ascx.vb" Inherits="CPKTQH.DinhNghiaLuongHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title">&nbsp;</asp:label></td>
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
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD height="172">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td height="2"></td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%" colSpan="2">
												<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlMaLinhVuc" runat="server" Width="90%" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="right" width="15%" height="50"><STRONG>Chức năng &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="45%"><asp:dropdownlist id="ddlTabCode" runat="server" Width="90%"></asp:dropdownlist></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td colSpan="2">
												<table cellSpacing="0" cellPadding="0" border="0" width="100%">
													<tr>
														<td width="10%"></td>
														<td width="20%"></td>
														<td width="60%"></td>
														<td width="10%"></td>
													</tr>
													<tr>
														<td></td>
														<td colSpan="3"><asp:label id="lblTieuDe" CssClass="QH_LabelLeftBoldRedLarge" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td colSpan="4" height="5"></td>
													</tr>
													<tr>
														<td colSpan="4" height="5"></td>
													</tr>
													<tr>
														<td></td>
														<TD><asp:label id="Label6" Runat="server" CssClass="QH_LabelLeftBold">Loại đường đi tình trạng</asp:label></TD>
														<td><asp:dropdownlist id="ddlItemCode" runat="server" Width="90%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
														<td></td>
													</tr>
													<tr>
														<td colSpan="4" height="5"></td>
													</tr>
													<tr>
														<td></td>
														<TD><asp:label id="Label2" Runat="server" CssClass="QH_LabelLeftBold">Tình trạng hồ sơ hiện tại</asp:label>&nbsp;<FONT color="#ff0000" size="2">*</FONT></TD>
														<td><asp:dropdownlist id="ddlMaTinhTrangCurr" runat="server" Width="90%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
														<td></td>
													</tr>
													<tr>
														<td colSpan="4" height="5"></td>
													</tr>
													<tr>
														<td></td>
														<TD><asp:label id="Label3" Runat="server" CssClass="QH_LabelLeftBold">Tình trạng hồ sơ kế tiếp</asp:label>&nbsp;<FONT color="#ff0000" size="2">*</FONT></TD>
														<td><asp:dropdownlist id="ddlMaTinhTrangNext" runat="server" Width="90%" CssClass="QH_Dropdownlist"></asp:dropdownlist></td>
														<td></td>
													</tr>
													<tr>
														<td colSpan="4" height="10"></td>
													</tr>
													<tr>
														<TD align="center" colSpan="4"><asp:linkbutton id="btnCapNhat" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton></TD>
													</tr>
													<tr>
														<td colSpan="4" height="10"></td>
													</tr>
													<tr>
														<td colSpan="4" align="center"><asp:datagrid id="dgdDanhSach" Width="90%" Runat="server" CssClass="QH_DataGridBottom" autogeneratecolumns="False"
																AllowPaging="True" CellPadding="3">
																<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="STT">
																		<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:Label align=center id="lblSTT" Enabled="True" runat="server" Text='<%# dgdDanhSach.CurrentPageIndex*dgdDanhSach.PageSize + dgdDanhSach.Items.Count+1 %>' />
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn HeaderText="DuongDiTinhTrangID" DataField="DuongDiTinhTrangID" Visible="False"></asp:BoundColumn>
																	<asp:BoundColumn HeaderText="Chức năng" DataField="TabName">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn HeaderText="Loại" DataField="Loai">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Width="100px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn HeaderText="Tình trạng hiện tại" DataField="TenTinhTrangCurr">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Width="150px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn HeaderText="Tình trạng kế tiếp" DataField="TenTinhTrangNext">
																		<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																		<ItemStyle Width="150px"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="Sửa">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:ImageButton id="imgChon" runat="server" ImageUrl="~/images/edit.gif" CommandName="Sua"></asp:ImageButton>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Xóa">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:ImageButton id="imgXoa" runat="server" ImageUrl="~/images/delete.gif" CommandName="Xoa"></asp:ImageButton>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
													<tr>
														<td colSpan="2"><div style="DISPLAY:none"><asp:TextBox ID="txtDuongDiTinhTrangID" Runat="server" Enabled="false"></asp:TextBox></div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
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
