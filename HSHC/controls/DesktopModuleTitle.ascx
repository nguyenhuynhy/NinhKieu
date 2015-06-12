<%@ Control CodeBehind="DesktopModuleTitle.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.DesktopModuleTitle" %>
<asp:Panel ID="pnlModuleTitle" Runat="server">
<table width="100%" cellspacing="0" cellpadding="0" summary="Module Title Table">
	<tr>
		<td align="left" valign="bottom" nowrap>
			<asp:Hyperlink id="cmdEditModule" runat="server" Visible="False" BorderWidth="0"><asp:Image Visible="False" BorderWidth="0" AlternateText="Edit Module Settings" ImageUrl="~/images/edit.gif" runat=server ID="cmdEditModuleImage"/></asp:Hyperlink>
			<asp:ImageButton id="cmdModuleUp" runat="server" Visible="False" BorderWidth="0" CausesValidation="False"></asp:ImageButton>
			<asp:ImageButton id="cmdModuleDown" runat="server" Visible="False" BorderWidth="0" CausesValidation="False"></asp:ImageButton>
			<asp:ImageButton id="cmdModuleLeft" runat="server" Visible="False" BorderWidth="0" CausesValidation="False"></asp:ImageButton>
			<asp:ImageButton id="cmdModuleRight" runat="server" Visible="False" BorderWidth="0" CausesValidation="False"></asp:ImageButton>
			&nbsp;
		</td>
		<td align="left" valign="bottom" width="100%" nowrap>
			<asp:label id="lblModuleTitle" cssclass="Head" EnableViewState="false" runat="server" />&nbsp;
		</td>
		<td align="right" valign="bottom" nowrap>
			<asp:Hyperlink ID="cmdEditContent" Runat="server" CssClass="CommandButton"></asp:Hyperlink>
			<asp:Hyperlink ID="cmdEditOptions" Visible=False Runat="server" CssClass="CommandButton"><asp:Image BorderWidth="0" Visible=False AlternateText="Module Display Options" ImageUrl="~/images/view.gif" runat=server ID="cmdEditOptionsImage"/></asp:Hyperlink>
			<asp:ImageButton ID="cmdDisplayModule" Runat="server" Visible="False" CausesValidation="False"></asp:ImageButton>
			<asp:ImageButton ID="cmdHelpShow" Runat="server" Visible="False" BorderWidth="0" CausesValidation="False"></asp:ImageButton>
			<asp:ImageButton ID="cmdHelpHide" Runat="server" Visible="False" BorderWidth="0" CausesValidation="False"></asp:ImageButton>
		</td>
	</tr>
	<tr>
		<td colspan="3" width="100%">
			<hr noshade size="1">
		</td>
	</tr>
	<tr id="rowHelp1" runat="server" visible="false">
		<td colspan="3" width="100%">
			<asp:Label ID="lblHelp" Runat="server" CssClass="Normal"></asp:Label>
		</td>
	</tr>
	<tr id="rowHelp2" runat="server" visible="false">
		<td colspan="3" width="100%">
			<hr noshade size="1">
		</td>
	</tr>
</table>
</asp:Panel>
