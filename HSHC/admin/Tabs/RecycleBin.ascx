<%@ Control Language="vb" AutoEventWireup="false" Codebehind="RecycleBin.ascx.vb" Inherits="PortalQH.RecycleBin.RecycleBin" %>
<br>
<table cellSpacing="0" cellPadding="2" border="0">
	<tr vAlign="top">
		<td class="SubHead" vAlign="top" width="100">Tabs:</td>
		<td width="250"><asp:listbox id="lstTabs" runat="server" CssClass="Normal" Width="250px" Rows="5" DataTextField="TabName" DataValueField="TabId"></asp:listbox></td>
		<td vAlign="middle">
			<P><asp:imagebutton id="cmdRestoreTab" runat="server" AlternateText="Restore Tab" ImageUrl="~/images/restore.gif"></asp:imagebutton></P>
			<P><asp:imagebutton id="cmdDeleteTab" runat="server" AlternateText="Delete Tab" ImageUrl="~/images/delete.gif"></asp:imagebutton></P>
		</td>
	</tr>
	<tr>
		<td colspan="3">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead" vAlign="top" width="100">Modules:</td>
		<td width="250"><asp:listbox id="lstModules" runat="server" CssClass="Normal" Width="250px" Rows="5" DataTextField="ModuleTitle" DataValueField="ModuleId"></asp:listbox></td>
		<td>
			<P><asp:imagebutton id="cmdRestoreModule" runat="server" AlternateText="Restore Module" ImageUrl="~/images/restore.gif"></asp:imagebutton></P>
			<P><asp:imagebutton id="cmdDeleteModule" runat="server" AlternateText="Delete Module" ImageUrl="~/images/delete.gif"></asp:imagebutton></P>
		</td>
	</tr>
</table>
