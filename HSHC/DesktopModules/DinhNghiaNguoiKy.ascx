﻿<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DinhNghiaNguoiKy.ascx.vb" Inherits="PortalQH.DinhNghiaNguoiKy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
							<TR>
								<TD height="172">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td height="2">
											</td>
										</tr>
										<TR>
											<TD vAlign="top" width="100%" colSpan="2">
												<TABLE class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%">
															<asp:dropdownlist id="ddlMaLinhVuc" runat="server" Width="90%" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Chức năng &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="50%">
															<asp:dropdownlist id="ddlTabCode" runat="server" Width="70%" AutoPostBack="True"></asp:dropdownlist>
															<asp:LinkButton CssClass="QH_Button" id="btnThucHien" runat="server">Thực hiện</asp:LinkButton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<TD class="QH_LabelLeftBold" width="20%" colspan="2">Danh sách người sử dụng</TD>
										</tr>
										<tr>
											<TD colspan="2" height="2"></TD>
										</tr>
										<TR>
											<TD vAlign="top" colSpan="2" align="center">
												<asp:checkboxlist id="lstNguoiSuDung" Width="80%" CssClass="QH_LoaiHS" Runat="server" RepeatDirection="Vertical"
													RepeatColumns="4" RepeatLayout="Table"></asp:checkboxlist></TD>
										</TR>
										<tr>
											<td colspan="2" height="2">
											</td>
										</tr>
										<TR>
											<TD vAlign="top" align="center" colSpan="4">
												<asp:LinkButton CssClass="QH_Button" id="btnCapNhat" runat="server">Cập nhật</asp:LinkButton></TD>
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
