<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Web_PhanQuyenChucNang.ascx.vb" Inherits="PortalQH.Web_PhanQuyenChucNang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<!--Start bound-->
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td align="left" width="100%" colspan="3">
			<table width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="9" height="25" class="QH_Content_TopLeft">
					</td>
					<td width="*" height="25" class="QH_Content_TopMid">
						<asp:label id="lblTitle" runat="server" width="100%" CssClass="QH_Content_Header_Middle">PHÂN QUYỀN GIAO VIỆC</asp:label>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="643" border="0" height="168">
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD align="center">
								</TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:CheckBoxList class="QH_LoaiHS" Width="652px" id="cklUser" runat="server" RepeatColumns="3"></asp:CheckBoxList></TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:ImageButton id="btnCapNhat" runat="server" ImageUrl="../../Images/btn_CapNhat.gif" CssClass="QH_Button"></asp:ImageButton>
									<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_Trove.gif" CssClass="QH_Button"></asp:ImageButton>
									<asp:TextBox id="txtMaUser" Width="0px" runat="server"></asp:TextBox>
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
