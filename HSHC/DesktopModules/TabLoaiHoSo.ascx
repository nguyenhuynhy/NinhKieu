<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TabLoaiHoSo.ascx.vb" Inherits="PortalQH.TabLoaiHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						&nbsp;
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
								<td width="100%">
									<table id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" width="100%" colSpan="2">
												<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlMaLinhVuc" runat="server" AutoPostBack="True" Width="90%"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Chức năng &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="50%"><asp:dropdownlist id="ddlTabCode" runat="server" AutoPostBack="True" Width="70%"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td height="2">
											</td>
										</tr>
										<tr>
											<TD class="QH_LabelLeftBold" width="10%">Loại hồ sơ
											</TD>
										</tr>
										<tr>
											<TD vAlign="top"><asp:checkboxlist id="lstLoaiHoSo" Width="100%" CssClass="QH_LoaiHS" RepeatLayout="Table" RepeatColumns="3"
													RepeatDirection="Vertical" Runat="server"></asp:checkboxlist></TD>
										</tr>
										<tr>
											<td height="2">
											</td>
										</tr>
										<tr>
											<TD vAlign="top" align="center" colSpan="4"><asp:LinkButton CssClass="QH_Button" id="btnUpdate" runat="server">Cập nhật</asp:LinkButton></TD>
										</tr>
									</table>
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
