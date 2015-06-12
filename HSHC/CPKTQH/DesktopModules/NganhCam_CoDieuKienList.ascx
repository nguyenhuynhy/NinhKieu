<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NganhCam_CoDieuKienList.ascx.vb" Inherits="CPKTQH.NganhCam_CoDieuKienList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblHeader" CssClass="QH_Label_Title" Width="100%" runat="server">Danh sách ngành cấm, kinh doanh có điều kiện</asp:label>
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
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
										<TR>
											<TD height="5"></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD height="5" width="55%"></TD>
														<TD class="QH_LabelLeftItalic" height="5" width="*"><font color="#ff0000"><strong>Phạm vi</strong></font>
															(trong trường hợp ngành cấm)
														</TD>
													</TR>
													<TR>
														<TD width="55%" valign="top">
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="30%">Ngành cấp trên</TD>
																	<TD class="QH_ColControl" width="70%"><asp:dropdownlist id="ddlNganhCapTren" CssClass="QH_DropDownList" Width="90%" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Ngành kinh doanh</TD>
																	<TD class="QH_ColControl"><asp:dropdownlist id="ddlNganhKD" CssClass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Loại</TD>
																	<TD class="QH_ColControl"><asp:dropdownlist id="ddlLoai" CssClass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></TD>
																</TR>
																<tr>
																	<td height="20">
																	</td>
																	<td>
																	</td>
																</tr>
																<tr>
																	<td></td>
																	<TD align="left">
																		<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
																		<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Thêm mới</asp:linkbutton>
																	</TD>
																</tr>
															</TABLE>
														</TD>
														<TD width="*" valign="top">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="QH_ColLabel" width="25%">Toàn quận</TD>
																	<TD class="QH_ColControl" width="75%">
																		<asp:CheckBox id="chkToanQuan" runat="server" CssClass="QH_Option"></asp:CheckBox>
																	</TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Phường</TD>
																	<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Đường</TD>
																	<TD class="QH_ColControl"><asp:dropdownlist id="ddlDuong" CssClass="QH_DropDownList" Width="90%" runat="server"></asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Từ ngày</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="40%" runat="server" MaxLength="10" ForeColor="Black"></asp:textbox>&nbsp;
																		<asp:image id="btnTuNgay" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn từ ngày"
																			ImageUrl="~/Images/calendar.gif"></asp:image></TD>
																</TR>
																<TR>
																	<TD class="QH_ColLabel">Đến ngày</TD>
																	<TD class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="40%" runat="server" MaxLength="10"></asp:textbox>&nbsp;
																		<asp:image id="btnDenNgay" CssClass="QH_ImageButton" runat="server" AlternateText="Chọn từ ngày"
																			ImageUrl="~/Images/calendar.gif"></asp:image></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD colSpan="2" height="5"></TD>
													</TR>
													<TR>
														<TD colSpan="2">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD align="right" width="*"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Width="50px" MaxLength="3" Runat="server"
																			AutoPostBack="True"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD colSpan="2"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" AllowPaging="True"
																autogeneratecolumns="False" CellPadding="3">
																<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
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
