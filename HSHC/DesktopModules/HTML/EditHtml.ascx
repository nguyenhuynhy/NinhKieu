<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Control language="vb" Inherits="PortalQH.EditHtml" CodeBehind="EditHtml.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<br>
<table cellspacing="2" cellpadding="2" border="0" summary="Edit HTML Design Table">
	<tr valign="top">
		<td>&nbsp;</td>
		<td align="center">
			<asp:RadioButtonList ID="optView" Runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal" AutoPostBack="True">
				<asp:ListItem Value="B">Basic Text Box</asp:ListItem>			
				<asp:ListItem Value="R">Rich Text Editor ( FreeTextBox )</asp:ListItem>			
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead">
			<label for='<%=IIf(optView.SelectedItem.Value = "B" , txtDesktopHTML.ClientID, ftbDesktopText.ClientID)%>'>Content:</label>
		</td>
		<td>
			<asp:Panel ID="pnlBasicTextBox" Runat="server" Visible="False">
				<asp:TextBox id="txtDesktopHTML" runat="server" CssClass="NormalTextBox" textmode="multiline" rows="12" width="600" columns="75"></asp:TextBox><BR>
				<asp:RadioButtonList ID="optRender" Runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal" AutoPostBack="True">
					<asp:ListItem Value="T">Text</asp:ListItem>			
					<asp:ListItem Value="H">HTML</asp:ListItem>			
				</asp:RadioButtonList>
			</asp:Panel>
			<asp:Panel ID="pnlRichTextBox" Runat="server" Visible="False">
				<FTB:FreeTextBox id="ftbDesktopText" runat="server" Height="400px" AutoConfigure="EnableAll"></FTB:FreeTextBox>
			</asp:Panel>
		</td>
	</tr>
	<tr valign="top" id="rowMobileSummary" runat="server" visible="false">
		<td class="SubHead">
			<label for="<%=txtMobileSummary.ClientID%>">Mobile Summary<br>
			(Optional):</label>
		</td>
		<td>
			<asp:TextBox id="txtMobileSummary" runat="server" CssClass="NormalTextBox" columns="75" width="600" rows="3" textmode="multiline" />
		</td>
	</tr>
	<tr valign="top" id="rowMobileDetails" runat="server" visible="false">
		<td class="SubHead">
			<label for="<%=txtMobileDetails.ClientID%>">Mobile Details<br>
			(Optional):</label>
		</td>
		<td>
			<asp:TextBox id="txtMobileDetails" runat="server" CssClass="NormalTextBox" columns="75" width="600" rows="5" textmode="multiline" />
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdPreview" Text="Preview" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
</p>
<table width="750" cellspacing="0" cellpadding="0">
	<tr valign="top">
		<td>
			<asp:Label ID="lblPreview" Runat="server" CssClass="Normal"></asp:Label>
		</td>
	</tr>
</table>
