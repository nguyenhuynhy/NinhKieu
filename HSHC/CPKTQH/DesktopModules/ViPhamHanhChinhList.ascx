<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ViPhamHanhChinhList.ascx.vb" Inherits="CPKTQH.ViPhamHanhChinhList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Danh sách đơn vị vi phạm hành chính</asp:label></td>
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
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE class="QH_Table" cellSpacing="0" cellPadding="0" width="98%" border="0">
										<br>
										<TR>
											<TD class="QH_ColLabel" width="20%">Số quyết định</TD>
											<TD class="QH_ColControl" width="30%"><asp:textbox id="txtSoQuyetDinh" CssClass="QH_TextBox" Width="90%" Runat="server" MaxLength="50"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Số nhà</TD>
											<TD class="QH_ColControl" width="*"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="70%" Runat="server" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Số GCN ĐKKD</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoGiayPhep" CssClass="QH_TextBox" Width="90%" Runat="server" MaxLength="50"></asp:textbox></TD>
											<TD class="QH_ColLabel">Đường</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlDuong" CssClass="QH_DropDownList" Width="70%" Runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="QH_ColLabel">Số CMND</TD>
											<TD class="QH_ColControl"><asp:textbox id="txtSoCMND" CssClass="QH_TextBox" Width="90%" Runat="server" MaxLength="9"></asp:textbox></TD>
											<TD class="QH_ColLabel">Phường</TD>
											<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" Width="70%" Runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD colSpan="4">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD align="center" width="58%"><asp:linkbutton id="btnTìmKiem" CssClass="QH_Button" runat="server">Tìm kiếm</asp:linkbutton>&nbsp;
															<asp:linkbutton id="btnThemMoi" CssClass="QH_Button" runat="server">Thêm mới</asp:linkbutton></TD>
													</tr>
													<TR>
														<TD align="right" width="*"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" Runat="server" AutoPostBack="True"
																MaxLength="3"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" CellPadding="3"
													autogeneratecolumns="False" AllowPaging="True">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
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
