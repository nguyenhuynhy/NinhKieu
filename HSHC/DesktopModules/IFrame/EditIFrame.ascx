<%@ Control language="vb" CodeBehind="EditIFrame.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditIFrame" %>
<br>
<table width="750" cellspacing="0" cellpadding="0" border="0" summary="Edit IFrame Design Table">
	<tr valign="top">
		<td width="144" class="SubHead"><label for="<%=txtSrc.ClientID%>">Source</label></td>
		<td>
			<asp:TextBox id="txtSrc" cssclass="NormalTextBox" Columns="50" runat="server" />
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtWidth.ClientID%>">Width:</label></td>
		<td>
			<asp:TextBox id="txtWidth" cssclass="NormalTextBox" Columns="50" runat="server" />
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtHeight.ClientID%>">Height:</label></td>
		<td>
			<asp:TextBox id="txtHeight" cssclass="NormalTextBox" Columns="50" runat="server" />
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtTitle.ClientID%>">Title:</label></td>
		<td>
			<asp:TextBox id="txtTitle" cssclass="NormalTextBox" Columns="50" runat="server" />
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=cboScrolling.ClientID%>">Scrolling:</label></td>
		<td>
			<asp:DropDownList ID="cboScrolling" Runat="server" CssClass="NormalTextBox">
				<asp:ListItem>auto</asp:ListItem>
				<asp:ListItem>no</asp:ListItem>
				<asp:ListItem>yes</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=cboBorder.ClientID%>">Border:</label></td>
		<td>
			<asp:DropDownList ID="cboBorder" Runat="server" CssClass="NormalTextBox">
				<asp:ListItem>no</asp:ListItem>
				<asp:ListItem>yes</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" cssclass="CommandButton" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" cssclass="CommandButton" />
</p>
