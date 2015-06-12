<%@ Control Inherits="PortalQH.Tabs" CodeBehind="Tabs.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title id="Title1" EditText="Add New Tab" runat="server"></portal:title>
<table cellSpacing="0" cellPadding="2" border="0" summary="Tabs Design Table">
	<tr vAlign="top">
		<td>
			<table cellSpacing="0" cellPadding="0" border="0" summary="Tabs Design Table">
				<tr vAlign="top">
					<td><label style="display:none;" for="<%=lstTabs.ClientID%>">First Tabs</label><asp:listbox id="lstTabs" runat="server" rows="20" DataTextField="TabName" DataValueField="TabId" CssClass="NormalTextBox" width="400px"></asp:listbox></td>
					<td>&nbsp;</td>
					<td height="100%">
						<table height="100%" summary="Tabs Design Table">
							<tr>
								<td valign="top"><asp:imagebutton id="cmdUp" runat="server" AlternateText="Move Tab Up In Current Level" CommandName="up" ImageUrl="~/images/up.gif"></asp:imagebutton></td>
							</tr>
							<tr>
								<td valign="top"><asp:imagebutton id="cmdDown" runat="server" AlternateText="Move Tab Down In Current Level" CommandName="down" ImageUrl="~/images/dn.gif"></asp:imagebutton></td>
							</tr>
							<tr>
								<td valign="top"><asp:imagebutton id="cmdLeft" runat="server" AlternateText="Move Tab Up One Hierarchical Level" CommandName="left" ImageUrl="~/images/lt.gif"></asp:imagebutton></td>
							</tr>
							<tr>
								<td valign="top"><asp:imagebutton id="cmdRight" runat="server" AlternateText="Move Tab Down One Hierarchical Level" CommandName="right" ImageUrl="~/images/rt.gif"></asp:imagebutton></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td valign="bottom"><asp:imagebutton id="cmdEdit" runat="server" AlternateText="Edit Tab" ImageUrl="~/images/edit.gif"></asp:imagebutton></td>
							</tr>
							<tr>
								<td valign="bottom"><asp:imagebutton id="cmdView" runat="server" AlternateText="View Tab" ImageUrl="~/images/view.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
