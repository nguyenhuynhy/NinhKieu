<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HoiDap_Rep.ascx.vb" Inherits="PortalQH.HoiDap_Rep" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">HỎI ĐÁP</asp:label>
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
					<td width="*" valign="top">
						<!--End bound-->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="80%" border="0">
										<tr>
											<td colSpan="7" height="2"></td>
										</tr>
										<TR>
											<TD class="QH_ColLabel" width="15%">Người gửi</TD>
											<TD width="15%"><asp:textbox id="txtNguoiGui" CssClass="QH_TextBox" ReadOnly="true" Width="90%" MaxLength="100"
													Runat="server"></asp:textbox></TD>
											<TD width="10%">Ngày gửi</TD>
											<TD width="15%"><asp:textbox id="txtNgayGui" CssClass="QH_TextBox" ReadOnly="true" Width="90%" MaxLength="10"
													Runat="server"></asp:textbox></TD>
											<TD class="QH_ColLabel" width="15%">Người nhận</TD>
											<TD align="right" width="20%"><asp:dropdownlist id="ddlNguoiNhan" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
											<td width="*"></td>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="100">Tiêu đề</TD>
											<TD width="80%" colSpan="5"><asp:textbox id="txtTieuDe" CssClass="QH_TextBox" Width="100%" MaxLength="200" Runat="server"></asp:textbox></TD>
											<td width="*"></td>
										</TR>
										<TR>
											<TD class="QH_ColLabel" width="100">Nôi dung</TD>
											<TD width="*" colSpan="5"><asp:textbox id="txtNoiDung" CssClass="QH_TextBox" Width="100%" MaxLength="4000" Runat="server"
													TextMode="MultiLine" Rows="4"></asp:textbox></TD>
											<td width="*"></td>
										</TR>
										<TR>
											<TD align="center" colSpan="7"><asp:imagebutton id="btnCapNhatCD" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_CapNhat.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD width="100" class="QH_LabelLeftBold">Các bài trả lời</TD>
											<TD align="right" colSpan="6">
												<asp:imagebutton id="btnThemMoi" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_BaiMoi.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD colSpan="7"><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Width="100%" Runat="server" CellPadding="3"
													AllowPaging="True" autogeneratecolumns="False">
													<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
													<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
													<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<!--<TR>
											<TD align="center" width="100%" colSpan="7">.:: Trả lời ::.</TD>
										</TR>-->
										<TR id="trTraLoi" runat="server">
											<td width="100"></td>
											<TD align="center" width="*" colSpan="5">
												<asp:label CssClass="QH_LabelMiddleBold" id="Label1" runat="server">.:: Trả lời ::.</asp:label>
												<br>
												<asp:textbox id="txtTraLoi" CssClass="QH_TextBox" Width="100%" MaxLength="4000" Runat="server"
													TextMode="MultiLine" Rows="3"></asp:textbox><br>
											</TD>
											<td width="100"></td>
										</TR>
										<tr>
											<td colspan="7" align=center width="100%">
												<asp:imagebutton id="btnCapNhat" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_GuiBai.gif"></asp:imagebutton><asp:imagebutton id="btnBoQua" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_TroVe.gif"></asp:imagebutton>
											</td>
										</tr>
									</TABLE>
									<asp:textbox id="txtHoiDapID" Runat="server" CssClass="QH_TextBox" MaxLength="20" Width="0"></asp:textbox></td>
							</tr>
						</table>
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
		<td width="100%" colspan="3" height="38">
			<table width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td width="9" height="100%" class="QH_Content_BottomLeft">
					</td>
					<td width="*" height="100%" class="QH_Content_BottomMid">&nbsp;
						<table width="258" height="100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td Width="100%" height="100%">
								</td>
							</tr>
						</table>
					</td>
					<td width="8" height="100%" class="QH_Content_BottomRight">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
