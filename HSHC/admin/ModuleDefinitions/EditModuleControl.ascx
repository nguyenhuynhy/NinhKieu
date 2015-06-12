<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" CodeBehind="EditModuleControl.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditModuleControl" %>
<portal:title runat="server" id="Title1" />
<br>
<table cellspacing="0" cellpadding="4" border="0" summary="Module Controls Design Table">
	<tr>
		<td width="128" class="SubHead">
			<label for="<%=txtModule.ClientID%>">Module:</label>
		</td>
		<td>
			<asp:TextBox id="txtModule" cssclass="NormalTextBox" width="390" Columns="30" maxlength="150"
				runat="server" Enabled="False" /><br>
		</td>
	</tr>
	<tr>
		<td width="128" class="SubHead">
			<label for="<%=txtDefinition.ClientID%>">Definition:</label>
		</td>
		<td>
			<asp:TextBox id="txtDefinition" cssclass="NormalTextBox" width="390" Columns="30" maxlength="150"
				runat="server" Enabled="False" /><br>
		</td>
	</tr>
	<tr>
		<td width="128" class="SubHead">
			<label for="<%=txtKey.ClientID%>">Key:</label>
		</td>
		<td>
			<asp:TextBox id="txtKey" cssclass="NormalTextBox" width="390" Columns="30" maxlength="20" runat="server" /><br>
		</td>
	</tr>
	<tr>
		<td width="128" class="SubHead">
			<label for="<%=txtTitle.ClientID%>">Title:</label>
		</td>
		<td>
			<asp:TextBox id="txtTitle" cssclass="NormalTextBox" width="390" Columns="30" maxlength="50" runat="server" /><br>
		</td>
	</tr>
	<tr>
		<td width="128" class="SubHead" valign="top" height="25">
			<label for="<%=cboSource.ClientID%>">Source:</label>
		</td>
		<td height="25">
			<asp:dropdownlist id="cboSource" runat="server" Width="390" CssClass="NormalTextBox" AutoPostBack="True"></asp:dropdownlist>
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="128">
			<label for="<%=cboType.ClientID%>">Type:</label>
		</td>
		<td>
			<asp:dropdownlist id="cboType" runat="server" Width="390" CssClass="NormalTextBox">
				<asp:ListItem Value="-2">Skin Object</asp:ListItem>
				<asp:ListItem Value="-1">Anonymous</asp:ListItem>
				<asp:ListItem Value="0">View</asp:ListItem>
				<asp:ListItem Value="1">Edit</asp:ListItem>
				<asp:ListItem Value="2">Admin</asp:ListItem>
				<asp:ListItem Value="3">Host</asp:ListItem>
			</asp:dropdownlist>
		</td>
	</tr>
	<tr>
		<td width="128" class="SubHead">
			<label for="<%=txtViewOrder.ClientID%>">View Order:</label>
		</td>
		<td>
			<asp:TextBox id="txtViewOrder" cssclass="NormalTextBox" width="390" Columns="30" maxlength="2"
				runat="server" /><br>
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="128">
			<label for="<%=cboIcon.ClientID%>">Icon:</label>
		</td>
		<td>
			<asp:dropdownlist id="cboIcon" runat="server" Width="390" CssClass="NormalTextBox" DataValueField="Value"
				DataTextField="Text"></asp:dropdownlist>
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton"
		BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdDelete" Text="Delete" CausesValidation="False" runat="server" class="CommandButton"
		BorderStyle="none" />
	<asp:ImageButton id="ImageButton1" runat="server"></asp:ImageButton>
</p>
