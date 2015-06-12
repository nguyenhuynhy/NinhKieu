<%@ Control Language="vb" AutoEventWireup="false" Codebehind="EditLinksViewOptions.ascx.vb" Inherits="PortalQH.EditLinksViewOptions" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<table cellSpacing="0" cellPadding="2" border="0" summary="Edit Links Design Table">
	<tr>
		<td class="SubHead" valign="middle">
			<label for="<%=optControl.ClientID%>">Loại control:</label>
		</td>
		<td valign="bottom">
			<asp:RadioButtonList ID="optControl" Runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
				<asp:ListItem Value="L">List</asp:ListItem>
				<asp:ListItem Value="D">Dropdown</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="SubHead" valign="middle">
			<label for="<%=optView.ClientID%>">Chiều menu list:</label>
		</td>
		<td valign="bottom">
			<asp:RadioButtonList ID="optView" Runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
				<asp:ListItem Value="V">Vertical</asp:ListItem>
				<asp:ListItem Value="H">Horizontal</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="SubHead" valign="middle">
			<label for="<%=optInfo.ClientID%>">Hiển thị thông tin menu link:</label>
		</td>
		<td valign="bottom">
			<asp:RadioButtonList ID="optInfo" Runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
				<asp:ListItem Value="Y">Yes</asp:ListItem>
				<asp:ListItem Value="N">No</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdateOptions" Text="Update" runat="server" class="CommandButton" BorderStyle="none"
		CausesValidation="False" />
	&nbsp;
	<asp:LinkButton id="cmdCancelOptions" Text="Cancel" CausesValidation="False" runat="server" CssClass="CommandButton"
		BorderStyle="none" />
</p>
