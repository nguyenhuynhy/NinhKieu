<%@ Control language="vb" CodeBehind="EditDirectory.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditDirectory" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" />
<br>
<table width="750" cellspacing="0" cellpadding="0" summary="Edit Directory Design Table">
	<tr valign="bottom">
		<td class="SubHead" valign="middle">
			Directory Source:&nbsp;
		</td>
		<td valign="top">
			<asp:RadioButtonList id="optSource" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
				<asp:ListItem Value="G">Host</asp:ListItem>
				<asp:ListItem Value="L">Site</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr valign="bottom">
		<td class="SubHead">
			<label class="SubHead" for="<%=chkFeedback.ClientID%>">Show Feedback?</label>&nbsp;
		</td>
		<td>
			<asp:CheckBox ID="chkFeedback" Runat="server" CssClass="NormalTextBox"></asp:CheckBox>
		</td>
	</tr>
	<tr valign="bottom">
		<td class="SubHead">
			<label class="SubHead" for="<%=chkSignup.ClientID%>">Allow Vendor Signup?</label>&nbsp;
		</td>
		<td>
			<asp:CheckBox ID="chkSignup" Runat="server" CssClass="NormalTextBox"></asp:CheckBox>
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
</p>
