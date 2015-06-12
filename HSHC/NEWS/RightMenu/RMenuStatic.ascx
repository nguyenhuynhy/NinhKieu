<%@ Control Language="vb" AutoEventWireup="false" Codebehind="RMenuStatic.ascx.vb" Inherits="PortalQH.RMenuStatic" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table class="QH_image" id="tblTitle" cellSpacing="0" cellPadding="0" width=170px>
	<tr class="QH_MENULD_Border">
		<td class="QH_MENULD_Header" id="tdTitle" colSpan="3" runat="server"></td>
	</tr>
	<tr>
		<td colSpan="3" height="3"></td>
	</tr>
	<tr id="tr1" runat="server">
		<td>
			<table width="100%" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
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
		<td><asp:Label ID="lblContent2" Runat="server" CssClass="QH_Label"></asp:Label></td>
	</tr>
</table>
