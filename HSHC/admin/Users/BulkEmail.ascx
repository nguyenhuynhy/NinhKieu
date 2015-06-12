<%@ Control Inherits="PortalQH.BulkEmail" CodeBehind="BulkEmail.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<table cellspacing="0" cellpadding="2" border="0">
	<tr>
		<td class="SubHead" valign="middle"><label for="<%=chkRoles.ClientID%>">User Role(s):</label></td>
		<td align="center"><asp:CheckBoxList Runat="server" ID="chkRoles" Width="450px" CssClass="Normal" DataTextField="RoleName" DataValueField="RoleID" RepeatColumns="2"></asp:CheckBoxList></td>
	</tr>
	<tr valign="top">
		<td class="SubHead" valign="middle"><label for="<%=txtEmail.ClientID%>">Email List:</label></td>
		<td align="center">
			<span class="normal"><strong>Note:</strong> Email addresses must be seperated with ";"</span>
			<asp:TextBox id="txtEmail" runat="server" CssClass="NormalTextBox" Width="450" TextMode="MultiLine" Rows="3"></asp:TextBox>
		</td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=cboPriority.ClientID%>">Priority:</label></td>
		<td>
			<asp:DropDownList ID="cboPriority" Runat="server" cssclass="NormalTextBox" width="450">
				<asp:ListItem Value="1">High</asp:ListItem>
				<asp:ListItem Value="2" Selected="True">Normal</asp:ListItem>
				<asp:ListItem Value="3">Low</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtSubject.ClientID%>">Subject:</label></td>
		<td><asp:TextBox id="txtSubject" cssclass="NormalTextBox" width="450" columns="40" maxlength="100" runat="server" /></td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><br><br><br><label for="<%=txtMessage.ClientID%>">Message:</label></td>
		<td align="middle" width="450">
			<span class="normal"><strong>Note:</strong> Basic Text Box = Text Format and Rich Text Editor = HTML Format</span>
			<asp:RadioButtonList id="optView" CssClass="Normal" Runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
				<asp:ListItem Value="B" Selected="True">Basic Text Box</asp:ListItem>
				<asp:ListItem Value="R">Rich Text Editor ( FreeTextBox )</asp:ListItem>
			</asp:RadioButtonList>
			<asp:Panel ID="pnlBasicTextBox" Runat="server" Visible="True">
				<asp:TextBox id="txtMessage" runat="server" CssClass="NormalTextBox" columns="75" width="450" rows="12" textmode="multiline"></asp:TextBox>
			</asp:Panel>
			<asp:Panel ID="pnlRichTextBox" Runat="server" Visible="False">
				<FTB:FreeTextBox id="ftbDesktopText" runat="server" ButtonPath="controls/ftb/images/" HelperFilesPath="controls/" AutoConfigure="EnableAll" Height="400px"></FTB:FreeTextBox>
			</asp:Panel>
		</td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=cboAttachment.ClientID%>">Attachment:</label></td>
		<td>
			<asp:dropdownlist id="cboAttachment" runat="server" Width="350px" CssClass="NormalTextBox" DataValueField="Value" DataTextField="Text"></asp:dropdownlist>&nbsp;
			<asp:HyperLink ID="cmdUpload" Runat="server" CssClass="CommandButton">Upload New File</asp:HyperLink>
		</td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=cboSendMethod.ClientID%>">Send Method:</label></td>
		<td>
			<asp:DropDownList ID="cboSendMethod" Runat="server" CssClass="NormalTextBox"  Width="450px">
				<asp:ListItem Value="TO" Selected="True">TO: One Message Per User Or Email Address ( Personalized )</asp:ListItem>
				<asp:ListItem Value="BCC">BCC: One Email Sent To Blind Distribution List ( Not Personalized )</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead" valign="middle"><label for="<%=optSendAction.ClientID%>">Send Action:</label></td>
		<td>
			<asp:RadioButtonList id="optSendAction" CssClass="Normal" Runat="server" RepeatDirection="Horizontal">
				<asp:ListItem Value="S">Synchronous</asp:ListItem>
				<asp:ListItem Value="A" Selected="True">Asynchronous</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<tr valign="top">
		<td colspan="2"><asp:LinkButton id="btnSend" Text="Send Email" runat="server" CssClass="CommandButton" /></td>
	</tr>
</table>
