<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control CodeBehind="ModuleSettings.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.ModuleSettingsPage" %>
<%@ Register TagPrefix="Portal" TagName="Skin" Src="~/controls/SkinControl.ascx" %>
<portal:title id="Title1" runat="server"></portal:title><br>
<table cellSpacing="0" cellPadding="0" width="750" border="0" summary="Module Settings Design Table">
	<tr>
		<td class="SubHead" width="200"><label for="<%=txtTitle.ClientID%>">Title:</label>
		</td>
		<td><asp:textbox id="txtTitle" runat="server" cssclass="NormalTextBox" width="300"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap width="200"><label for="<%=cboIcon.ClientID%>">Icon:</label>
		</td>
		<td><asp:dropdownlist id="cboIcon" runat="server" DataTextField="Text" DataValueField="Value" Width="300" CssClass="NormalTextBox"></asp:dropdownlist>&nbsp;
			<asp:hyperlink id="cmdUpload" CssClass="CommandButton" Runat="server">Upload New File</asp:hyperlink></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" noWrap width="200"><label for="<%=chkShowTitle.ClientID%>">Display Module Title?:</label>
		</td>
		<td><asp:checkbox id="chkShowTitle" runat="server" Font-Size="8pt" Font-Names="Verdana,Arial"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap width="200"><label for="<%=chkAllTabs.ClientID%>">Display Module On All Tabs?:</label>
		</td>
		<td><asp:checkbox id="chkAllTabs" runat="server" Font-Size="8pt" Font-Names="Verdana,Arial"></asp:checkbox></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" noWrap width="200"><label for="<%=cboPersonalize.ClientID%>">Personalization?:</label>
		</td>
		<td><asp:dropdownlist id="cboPersonalize" width="300" CssClass="NormalTextBox" Runat="server">
				<asp:ListItem Value="0">Maximized</asp:ListItem>
				<asp:ListItem Value="1">Minimized</asp:ListItem>
				<asp:ListItem Value="2">None</asp:ListItem>
			</asp:dropdownlist></td>
	</tr>
	<tr>
		<td class="SubHead" width="200"><label for="<%=txtCacheTime.ClientID%>">Cache Timeout (seconds):</label>
		</td>
		<td><asp:textbox id="txtCacheTime" runat="server" cssclass="NormalTextBox" width="300" Columns="10" MaxLength="6"></asp:textbox></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="200" valign="top">Roles that can View Content:<br>
			( Overrides Tab Authorized Roles )
		</td>
		<td><asp:checkboxlist id="chkAuthViewRoles" runat="server" width="300" Font-Size="8pt" Font-Names="Verdana,Arial" cellspacing="0" cellpadding="0" RepeatColumns="2"></asp:checkboxlist></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="200" valign="top">Roles that can Edit Content:
		</td>
		<td><asp:checkboxlist id="chkAuthEditRoles" runat="server" width="300" Font-Size="8pt" Font-Names="Verdana,Arial" cellspacing="0" cellpadding="0" RepeatColumns="2"></asp:checkboxlist></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="200"><label Class="SubHead" for="<%=cboAlign.ClientID%>">Alignment:</label></td>
		<td valign="top">
			<asp:dropdownlist id="cboAlign" width="300" CssClass="NormalTextBox" Runat="server">
				<asp:ListItem Value=""></asp:ListItem>
				<asp:ListItem Value="left">Left</asp:ListItem>
				<asp:ListItem Value="center">Center</asp:ListItem>
				<asp:ListItem Value="right">Right</asp:ListItem>
			</asp:dropdownlist>
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="200"><label Class="SubHead" for="<%=txtColor.ClientID%>">Color:</label></td>
		<td valign="top"><asp:textbox id="txtColor" width="300" CssClass="NormalTextBox" Runat="server" Columns="7"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="SubHead" width="200"><label Class="SubHead" for="<%=txtBorder.ClientID%>">Border:</label></td>
		<td valign="top"><asp:textbox id="txtBorder" width="300" CssClass="NormalTextBox" Runat="server" Columns="1"></asp:TextBox></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="200"><label for="<%=ctlModuleContainer.ClientID%>">Module Container:</label></td>
		<td valign="top"><portal:skin id="ctlModuleContainer" runat="server"></portal:skin></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" noWrap width="200"><label for="<%=cboTab.ClientID%>">Move To Tab:</label>
		</td>
		<td><asp:dropdownlist id="cboTab" width="300" DataTextField="TabName" DataValueField="TabId" CssClass="NormalTextBox" Runat="server"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
	<tr>
		<td colSpan="2"><asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update"></asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel"></asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton class="CommandButton" id="cmdDelete" runat="server" Text="Delete"></asp:linkbutton>
		</td>
	</tr>
</table>
