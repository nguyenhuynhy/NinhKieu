<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachDoanhNghiepCapTren.ascx.vb" Inherits="CPKTQH.DanhSachDoanhNghiepCapTren" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
					<td class="QH_Khung_TopMid" width="*"><asp:label id="lblTieuDe" CssClass="QH_Label_Title" runat="server" Width="100%">Danh sách doanh nghiệp cấp trên</asp:label></td>
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
							<TBODY>
								<TR>
									<TD vAlign="top" align="center"><BR>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center" width="100%">
													<!-- content is put here -->
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="800" border="0">
														<TR>
															<TD class="QH_ColLabel" width="15%">Loại doanh nghiệp</TD>
															<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLyDo" CssClass="QH_DropDownList" runat="server" Width="80%" EnableViewState="true"></asp:dropdownlist></TD>
															<TD class="QH_ColLabel" width="15%">
																Tình trạng</TD>
															<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="Dropdownlist1" CssClass="QH_DropDownList" runat="server" Width="80%" EnableViewState="true"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="15%">Ngành kinh doanh</TD>
															<TD class="QH_ColControl" width="35%"><asp:textbox id="Textbox2" CssClass="QH_textbox" runat="server" Width="80%" EnableViewState="true"></asp:textbox></TD>
															<TD class="QH_ColLabel" width="15%">Số GCN ĐKKD</TD>
															<TD class="QH_ColControl" width="35%"><asp:textbox id="Textbox5" CssClass="QH_textbox" runat="server" Width="80%" EnableViewState="true"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="15%">Lĩnh vực cấp phép</TD>
															<TD class="QH_ColControl" width="35%">
																<asp:dropdownlist id="Dropdownlist5" Width="80%" runat="server" CssClass="QH_DropDownList" EnableViewState="true"></asp:dropdownlist></TD>
															<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
															<TD class="QH_ColControl" width="35%">
																<asp:textbox id="txtNgayDuyet" Width="96px" runat="server" CssClass="QH_textbox" EnableViewState="true"></asp:textbox>
																<asp:image id="imgNgayDuyet" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
																	ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
														</TR>
														<TR>
															<TD class="QH_ColLabel" width="15%">Ngành kinh doanh</TD>
															<TD class="QH_ColControl" width="35%"><asp:textbox id="Textbox4" CssClass="QH_textbox" runat="server" Width="80%" EnableViewState="true"></asp:textbox></TD>
															<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
															<TD class="QH_ColControl" width="35%"><asp:textbox id="Textbox1" CssClass="QH_textbox" runat="server" Width="96px" EnableViewState="true"></asp:textbox>
																<asp:image id="Image1" runat="server" CssClass="QH_Button" ImageUrl="~\images\calendar.gif"
																	ImageAlign="Middle" AlternateText="Chọn lịch"></asp:image></TD>
														</TR>
													</TABLE>
													<BR>
													<asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button"> Tìm kiếm</asp:linkbutton>
													<asp:linkbutton id="btnThemMoi" runat="server" CssClass="QH_Button">Chọn</asp:linkbutton>
													<asp:linkbutton id="btnInRaGiay" runat="server" CssClass="QH_Button">Trở về</asp:linkbutton><BR> <!-- content is put here --><BR>
													<asp:datagrid id="dgdDNCT" runat="server"></asp:datagrid></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center"></TD>
					</td>
				</tr>
			</table>
			<asp:textbox id="txtReload" Width="20px" runat="server" Visible="False"></asp:textbox>
			<asp:textbox id="txtHoSoTiepNhanID" Width="0px" runat="server"></asp:textbox>
			<asp:textbox id="txtGiayCNDKKDID" Width="0px" runat="server"></asp:textbox>
			<asp:textbox id="txtNgungKinhDoanhID" Width="20px" runat="server" Visible="False"></asp:textbox></TD>
		<TD class="QH_Khung_Right" width="16">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="*">
					<TD></TD>
				</TR>
				<TR height="141">
					<TD class="QH_Khung_Right1"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
