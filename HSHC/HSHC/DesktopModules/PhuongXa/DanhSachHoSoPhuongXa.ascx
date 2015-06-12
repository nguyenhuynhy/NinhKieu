<%@ Register TagPrefix="uc1" TagName="ThongTinTraCuu" Src="ThongTinTraCuuPhuongXa.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachHoSoPhuongXa.ascx.vb" Inherits="HSHC.DanhSachHoSoPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblHeader" CssClass="QH_Label_Title" runat="server" Width="100%">&nbsp;</asp:label></td>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr height="2">
											<td></td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%">
												<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="20%" height="50"><STRONG>Loại hồ sơ tiếp nhận 
																&nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="60%"><asp:dropdownlist id="ddlLinhVuc" CssClass="QH_DropDownList" runat="server" AutoPostBack="True" Width="95%"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="left" width="20%" colSpan="1" rowSpan="1">
															<asp:linkbutton id="btnThucHien" runat="server" CssClass="QH_Button" Visible="False">Thực hiện</asp:linkbutton></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" width="100%">
												<table width="100%">
													<tr>
														<td>
															<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD><uc1:thongtintracuu id="ThongTinTraCuu1" runat="server"></uc1:thongtintracuu></TD>
																</TR>
																<TR>
																	<TD height="5"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD align="center" width="65%">
																					<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton>&nbsp;
																					<asp:linkbutton id="btnInRaGiay" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
																				</TD>
																			</TR>
																			<tr>
																				<TD align="right" width="*"><asp:label id="Label1" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" CssClass="QH_TextRight" Runat="server" Width="50px" MaxLength="3"
																						AutoPostBack="True"></asp:textbox></TD>
																			</tr>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="100%" CellPadding="3"
																			AllowPaging="True" AllowSorting="True" autogeneratecolumns="False">
																			<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																			<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																			<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></TD>
																</TR>
															</TABLE>
														</td>
													</tr>
												</table>
												<INPUT id="txtMaNguoiTacNghiep" type="hidden" size="1" name="txtMaNguoiTacNghiep" runat="server"><INPUT id="txtMaLinhVuc" type="hidden" size="1" name="txtMaLinhVuc" runat="server"><INPUT id="txtChuoiSoBienNhan" type="hidden" size="1" name="txtChuoiSoBienNhan" runat="server">
												<INPUT id="txtURL" type="hidden" size="1" name="txtURL" runat="server">
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
						<asp:textbox id="txtTabCode" runat="server" Width="0px"></asp:textbox></td>
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
