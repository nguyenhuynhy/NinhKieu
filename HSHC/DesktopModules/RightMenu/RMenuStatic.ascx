<%@ Control Language="vb" AutoEventWireup="false" Codebehind="RMenuStatic.ascx.vb" Inherits="PortalQH.RMenuStatic" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE cellSpacing="0" cellPadding="0" width="158" runat=server border="0" id="tblTitle">
	<TR>
		<TD width="158" class="QH_MenuRight_Header" id="tdTitle">&nbsp;</TD>
	</TR>
	<TR>
		<TD width="158" class="QH_MenuRight_Middle" align=center>
			<table cellSpacing="0" cellPadding="0" width="140">
				<tr>
					<td colSpan="3" height="3"></td>
				</tr>
				<tr id="tr1" runat="server">
					<td>
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="3" nowrap></td>
								<td><asp:image id="img1" Runat="server"></asp:image></td>
								<td width="3" nowrap></td>
								<td><asp:label id="lblContent1" CssClass="QH_LabelRMenu" Runat="server"></asp:label></td>
							</tr>
							<tr>
							<td colspan=4 height=3></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="tr2" runat="server">
					<td><asp:image id="Img2" Runat="server"></asp:image></td>
					<td width="5"></td>
					<td><asp:Label ID="lblContent2" Runat="server" CssClass="QH_ColLabel"></asp:Label></td>
				</tr>
			</table>
</TD>
	</TR>
	<TR>
		<TD width="158" height="25" class="QH_MenuRight_Footer"></TD>
	</TR>
</TABLE>