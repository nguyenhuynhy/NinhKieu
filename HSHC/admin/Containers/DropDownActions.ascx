<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DropDownActions.ascx.vb" Inherits="PortalQH.Containers.DropDownActions" %>
<table cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td nowrap>
			<asp:dropdownlist id="cboActions" runat="server"></asp:dropdownlist>
			<asp:ImageButton id="cmdGo" runat="server" ImageUrl="~/images/fwd.gif" AlternateText="Go" ToolTip="Go"></asp:ImageButton>
		</td>
	</tr>
</table>
