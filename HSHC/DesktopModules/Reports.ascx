<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Reports.ascx.vb" Inherits="PortalQH.Reports" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Khung_TopLeft" width="16" height="24"></td>
					<td class="QH_Khung_TopMid" width="*">&nbsp;
					</td>
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
							<TR>
								<TD height="172">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td height="2"></td>
										</tr>
										<TR>
											<TD>
												<TABLE class="QH_LoaiHS" id="Table0" cellSpacing="0" cellPadding="0" width="100%" align="center"
													border="0">
													<tr>
														<TD vAlign="middle" align="right" width="10%"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlMaLinhVuc" runat="server" Width="90%" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="right" width="10%"><STRONG>Chức năng &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlTabCode" runat="server" Width="90%" AutoPostBack="True"></asp:dropdownlist></TD>
														<td vAlign="middle" align="left" width="20%"><asp:linkbutton id="btnThucHien" runat="server" CssClass="QH_Button">Thực hiện</asp:linkbutton></td>
													</tr>
												</TABLE>
											</TD>
										</TR>
										<TR vAlign="top">
											<TD vAlign="top">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" runat="server">
													<TR>
														<TD class="QH_ColLabel" width="30%" height="22">Item Code</TD>
														<TD class="QH_ColControl" width="70%" height="22"><asp:textbox id="txtItemCode" runat="server" Width="30%" CssClass="QH_textbox"></asp:textbox><asp:textbox id="txtReportID" runat="server" Width="36px" CssClass="QH_textbox" Visible="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Report Name</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtReportName" runat="server" Width="70%" CssClass="QH_textbox"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Procedure Name</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtProcedureName" runat="server" Width="70%" CssClass="QH_textbox"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Title</TD>
														<TD class="QH_ColControl"><asp:textbox id="txtTitle" runat="server" Width="70%" CssClass="QH_textbox" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="QH_ColLabel">Used</TD>
														<TD class="QH_ColControl"><asp:CheckBox Runat="server" ID="chkUsed"></asp:CheckBox></TD>
													</TR>
													<tr>
														<td height="2"></td>
													</tr>
													<TR vAlign="middle">
														<TD align="center" colSpan="2"><asp:linkbutton id="btnUpdate" runat="server" CssClass="QH_Button">Cập nhật</asp:linkbutton>&nbsp;
															<asp:linkbutton id="btnXoa" runat="server" CssClass="QH_Button">Xóa</asp:linkbutton>&nbsp;<asp:linkbutton id="btnCancel" runat="server" CssClass="QH_Button">Bỏ qua</asp:linkbutton></TD>
													</TR>
													<tr>
														<td height="2"></td>
													</tr>
												</TABLE>
											</TD>
										<TR>
											<TD align="center"><asp:datagrid id="grdList" runat="server" CssClass="QH_DataGrid" AllowPaging="True" CellPadding="0">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="ActivePage"></PagerStyle>
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
