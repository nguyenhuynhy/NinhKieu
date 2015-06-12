<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TinhTrangXuLyHoSo.ascx.vb" Inherits="PortalQH.TinhTrangXuLyHoSo" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
								<td height="2"></td>
							</tr>
							<TR>
								<TD>
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100%" colSpan="2">
												<table class="QH_LoaiHS" id="tblHeader" width="100%" align="center" runat="server">
													<TR vAlign="middle">
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Lĩnh vực &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="30%"><asp:dropdownlist id="ddlMaLinhVuc" Width="90%" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD vAlign="middle" align="right" width="10%" height="50"><STRONG>Chức năng &nbsp;</STRONG>
														</TD>
														<TD vAlign="middle" align="left" width="50%"><asp:dropdownlist id="ddlTabCode" Width="70%" runat="server" AutoPostBack="True"></asp:dropdownlist><asp:LinkButton CssClass="QH_Button" id="btnThucHien" runat="server">Thực hiện</asp:LinkButton></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<tr>
											<td height="2">
											</td>
										</tr>
										<TR>
											<TD vAlign="top" width="20%" height="15"><asp:label id="Label2" CssClass="QH_LabelLeftBold" Runat="server">Tình trạng hồ sơ</asp:label></TD>
											<TD vAlign="top" colSpan="3" height="15"><asp:dropdownlist id="ddlMaTinhTrangHoSo" Width="50%" runat="server" AutoPostBack="True" CssClass="QH_Dropdownlist"></asp:dropdownlist></TD>
										</TR>
										<tr>
											<td height="2">
											</td>
										</tr>
										<TR>
											<TD vAlign="top"><asp:label id="Label4" CssClass="QH_LabelLeftBold" Runat="server">Tình trạng xử lý</asp:label></TD>
											<TD vAlign="top" colSpan="3"><asp:checkboxlist id="lstMaTinhTrangXuLy" Width="90%" CssClass="QH_LoaiHS" Runat="server" RepeatLayout="Table"
													RepeatColumns="2" RepeatDirection="Vertical"></asp:checkboxlist></TD>
										</TR>
										<tr>
											<td height="2">
											</td>
										</tr>
										<TR>
											<TD vAlign="top" align="center" colSpan="4"><asp:LinkButton CssClass="QH_Button" id="btnCapNhat" runat="server">Cập nhật</asp:LinkButton></TD>
										</TR>
									</TABLE>
									<asp:label id="Label1" CssClass="QH_LabelLeftBold" Runat="server">Danh sách tình trạng xử lý</asp:label>
								</TD>
							</TR>
						</TABLE>
						<asp:DataGrid id="dgdDanhsach" runat="server"></asp:DataGrid>
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
