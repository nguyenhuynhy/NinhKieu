<%@ Control language="vb" CodeBehind="BannerOptions.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.BannerOptions" %>
<br>
<table width="750" cellspacing="2" cellpadding="0" Summary="Edit Banners Design Table">
	<tr valign="bottom">
		<td class="SubHead">
			Banner Source:&nbsp;
		</td>
		<td>
			<asp:RadioButtonList id="optSource" runat="server" CssClass="NormalBold" RepeatDirection="Horizontal">
				<asp:ListItem Value="G">Host</asp:ListItem>
				<asp:ListItem Value="L">Site</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr valign="bottom">
		<td class="SubHead">
			<label for="<%=cboType.ClientID%>">Banner Type:</label>&nbsp;
		</td>
		<td>
			<asp:DropDownList ID="cboType" Runat="server" CssClass="NormalTextBox" Width="250px" DataTextField="BannerTypeName" DataValueField="BannerTypeId"></asp:DropDownList>
		</td>
	</tr>
	<tr valign="bottom">
		<td class="SubHead">
			<label for="<%=txtCount.ClientID%>">Banner Count:</label>&nbsp;
		</td>
		<td>
			<asp:TextBox id="txtCount" Runat="server" CssClass="NormalTextBox" Columns="30" Width="250px"></asp:TextBox> <asp:RegularExpressionValidator id="valCount" ControlToValidate="txtCount" ValidationExpression="^[1-9]+[0]*$" Display="Dynamic" ErrorMessage="Banner Count Must Be A Valid Integer" runat="server"/>
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
</p>
