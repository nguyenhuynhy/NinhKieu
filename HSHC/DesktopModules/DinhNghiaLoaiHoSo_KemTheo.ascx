<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DinhNghiaLoaiHoSo_KemTheo.ascx.vb" Inherits="PortalQH.DinhNghiaLoaiHoSo_KemTheo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td height="2px">
								</td>
							</tr>
							<TR>
								<TD height="172" vAlign="top">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100%" colSpan="2">
												<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlMaLinhVuc" CssClass="QH_DropDownList" Width="90%" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Loại hồ 
																sơ&nbsp;&nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="50%"><asp:dropdownlist id="ddlLoaiHoSo" CssClass="QH_DropDownList" Width="70%" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<TD vAlign="top" width="20%"><asp:label id="lblHoSoKemTheo" Runat="server" CssClass="QH_LabelLeftBold">Hồ sơ kèm theo</asp:label></TD>
											<td vAlign="top" colSpan="3"><asp:checkboxlist id="lstHoSoKemTheo" Runat="server" CssClass="QH_LoaiHS" Width="90%" RepeatDirection="Vertical"
													RepeatColumns="2" RepeatLayout="Table"></asp:checkboxlist></td>
										</tr>
										<tr>
											<td height="2px">
											</td>
										</tr>
										<tr>
											<TD vAlign="top" align="center" colSpan="4">
												<asp:LinkButton CssClass="QH_Button" id="btnCapNhat" runat="server">Cập nhật</asp:LinkButton>
											</TD>
										</tr>
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
