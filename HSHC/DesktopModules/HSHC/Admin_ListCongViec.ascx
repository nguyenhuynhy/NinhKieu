<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Admin_ListCongViec.ascx.vb" Inherits="HSHC.Admin_ListCongViec" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">DANH SÁCH CÔNG VIỆC</asp:label>
					</td>
					<td width="8" height="25" class="QH_Content_TopRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="9" class="QH_Content_Left">&nbsp;
					</td>
					<td width="*" valign="top" align="center">
						<!--End bound-->
						<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
							<TR>
								<TD align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<TR>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD colSpan="3" align="right">
															<asp:Label ID="Label4" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
															<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextRight" Width="50px"
																MaxLength="3"></asp:TextBox>
														</TD>
													</TR>
													<TR>
														<TD colspan="3" width="100%">
															<asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" autogeneratecolumns="false"
																Runat="server" AllowSorting="True" AllowPaging="True" CellPadding="3">
																<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
																<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
																<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
															</asp:datagrid>
														</TD>
													</TR>
													<TR>
														<TD colspan="3" height="5"></TD>
													</TR>
													<TR>
														<TD colspan="3" align="center"><asp:ImageButton id="btnThemMoi" runat="server" ImageUrl="../../Images/btn_ThemMoi.gif" CssClass="QH_Button"></asp:ImageButton>
															<asp:ImageButton id="btnXoa" runat="server" ImageUrl="../../Images/btn_Xoa.gif" CssClass="QH_Button"></asp:ImageButton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<!--start bound-->
					</td>
					<td width="8" class="QH_Content_Right">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colspan="3" height="12">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="128" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
					</td>
					<td width="130" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
