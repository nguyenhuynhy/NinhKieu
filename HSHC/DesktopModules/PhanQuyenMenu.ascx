<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhanQuyenMenu.ascx.vb" Inherits="PortalQH.PhanQuyenMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" height="24">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="16" height="24" class="QH_Khung_TopLeft">
					</td>
					<td class="QH_Khung_TopMid" width="*">
						<asp:label id="lblHeader" runat="server" Width="100%" CssClass="QH_Label_Title"> Phân quyền chức năng</asp:label>
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
							<TR>
								<TD>
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100%" colSpan="2">
												<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlMaLinhVuc" runat="server" AutoPostBack="True" Width="90%"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="3" height="5"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3"><asp:checkboxlist id="lstMaChucNang" Width="90%" Runat="server" CssClass="QH_LoaiHS" RepeatDirection="Vertical"
													RepeatColumns="3" RepeatLayout="Table"></asp:checkboxlist></TD>
										</TR>
										<tr>
											<td height="2">
											</td>
										</tr>
										<TR>
											<TD vAlign="top" align="center" colSpan="4"><asp:LinkButton CssClass="QH_Button" id="btnCapNhat" runat="server">Cập nhật</asp:LinkButton></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
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
