<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Web_PhanQuyenNhanViec.ascx.vb" Inherits="PortalQH.Web_PhanQuyenNhanViec" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colSpan="3">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="QH_Content_TopLeft" width="9" height="25"></td>
					<td class="QH_Content_TopMid" width="*" height="25"><asp:label id="lblTitle" CssClass="QH_Content_Header_Middle" width="100%" runat="server">PHÂN QUYỀN NHẬN VIỆC</asp:label></td>
					<td class="QH_Content_TopRight" width="8" height="25"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td width="100%" colSpan="3">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Content_Left" width="9">&nbsp;
					</td>
					<td vAlign="top" align="center" width="*">
						<!--End bound-->
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="80%" border="0">
							<TR>
								<TD height="5">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
										<TR>
											<TD align="center" width="100%">
												<P>Người giao việc:</P>
											</TD>
											<TD></TD>
										</TR>
									</TABLE>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
										<TR>
											<TD align="center" width="100%">
												<P><asp:dropdownlist id="ddlNguoiGiao" CssClass="QH_DropdownList" runat="server" AutoPostBack="True"
														Width="50%"></asp:dropdownlist></P>
											</TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<!--TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="70%" border="0">
										<TR>
											<TD width="100%" align="center"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR-->
							<TR>
								<TD height="10">
									<P>&nbsp;</P>
								</TD>
							</TR>
							<TR>
								<TD align="center" height="5">Những người nhận việc:</TD>
							</TR>
							<TR>
								<TD align="center" height="45"><asp:checkboxlist class="QH_LoaiHS" id="cklUser" runat="server" Width="664px" RepeatColumns="3"></asp:checkboxlist></TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD align="center"><asp:imagebutton id="btnCapNhat" CssClass="QH_Button" runat="server" ImageUrl="../../Images/btn_CapNhat.gif"></asp:imagebutton><asp:imagebutton id="btnTroVe" CssClass="QH_Button" runat="server" ImageUrl="../../Images/btn_Trove.gif"></asp:imagebutton><asp:textbox id="txtMaUser" runat="server" Width="0px"></asp:textbox></TD>
							</TR>
						</TABLE>
						<!--start bound--></td>
					<td class="QH_Content_Right" width="8">&nbsp;
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<!--Footer-->
	<tr>
		<td width="100%" colSpan="3" height="12">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="QH_Content_BottomLeft" width="128" height="100%"></td>
					<td class="QH_Content_BottomMid" width="*" height="100%">&nbsp;
					</td>
					<td class="QH_Content_BottomRight" width="130" height="100%"></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--End bound-->
