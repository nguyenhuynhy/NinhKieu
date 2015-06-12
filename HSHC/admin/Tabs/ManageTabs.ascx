<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="ManageTabs.ascx.vb" Inherits="PortalQH.ManageTabs"%>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="Portal" TagName="Skin" Src="~/controls/SkinControl.ascx" %>
<portal:title runat="server" id="Title1" />
<br>
<table cellSpacing="0" cellPadding="0" width="750" border="0" summary="Manage Tabs Design Table">
	<tr>
		<td class="SubHead" width="100"><label for="<%=txtTabName.ClientID%>">Tab Name:</td>
		<td>
			<asp:textbox id="txtTabName" runat="server" width="300" MaxLength="50" cssclass="NormalTextBox"></asp:textbox>
			<asp:RequiredFieldValidator id="valTabName" ControlToValidate="txtTabName" runat="server" ErrorMessage="<br>Tab Name Is Required" CssClass="NormalRed" Display="Dynamic"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead" width="100"><label for="<%=txtTitle.ClientID%>">Title:</td>
		<td><asp:textbox id="txtTitle" runat="server" width="300" MaxLength="200" cssclass="NormalTextBox"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead" vAlign="top" width="165"><label for="<%=txtDescription.ClientID%>">Description:</label></td>
		<td class="NormalTextBox"><asp:textbox id="txtDescription" runat="server" width="300" MaxLength="500" CssClass="NormalTextBox" Rows="3" TextMode="MultiLine"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead" vAlign="top" width="165"><label for="<%=txtKeyWords.ClientID%>">Key Words:</label></td>
		<td class="NormalTextBox"><asp:textbox id="txtKeyWords" runat="server" width="300" MaxLength="500" CssClass="NormalTextBox" Rows="3" TextMode="MultiLine"></asp:textbox></td>
	</tr>
	<tr>
		<td width="165">&nbsp;</td>
		<td><asp:linkbutton id="cmdGoogle" runat="server" Text="Submit Tab To Google" cssclass="CommandButton"></asp:linkbutton></td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead" nowrap>
			<label for="<%=cboIcon.ClientID%>">Icon:</label>
		</td>
		<td colspan="3">
			<asp:dropdownlist id="cboIcon" CssClass="NormalTextBox" runat="server" Width="300" DataValueField="Value" DataTextField="Text"></asp:dropdownlist>&nbsp;
			<asp:HyperLink ID="cmdUpload" Runat="server" CssClass="CommandButton">Upload New File</asp:HyperLink>
		</td>
	</tr>
	<tr>
		<td class="SubHead" width="100"><label for="<%=cboTab.ClientID%>">Parent Tab:</label>
		</td>
		<td>
			<asp:DropDownList ID="cboTab" Runat="server" width="300" DataValueField="TabId" DataTextField="TabName" CssClass="NormalTextBox"></asp:DropDownList>
		</td>
	</tr>
	<tr id="rowTemplate" runat="server">
		<td class="SubHead" width="100"><label for="<%=cboTemplate.ClientID%>">Template Tab:</label></td>
		<td>
			<asp:DropDownList ID="cboTemplate" Runat="server" width="300" DataValueField="TabId" DataTextField="TabName" CssClass="NormalTextBox"></asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead" width="100"><label for="<%=ctlSkin.ClientID%>">Tab Skin:</label></td>
		<td valign="top"><portal:skin id="ctlSkin" runat="server"></portal:skin></td>
	</tr>
	<tr>
		<td class="SubHead" width="100"><label for="<%=ctlContainer.ClientID%>">Tab Container:</label></td>
		<td valign="top"><portal:skin id="ctlContainer" runat="server"></portal:skin></td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<TR>
		<TD class="SubHead" noWrap><label for="<%=chkHidden.ClientID%>">Hidden?</label></TD>
		<TD><asp:checkbox id="chkHidden" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"></asp:checkbox></TD>
	</TR>
	<TR>
		<TD class="SubHead" noWrap><label for="<%=chkDisableLink.ClientID%>">Disabled?</label></TD>
		<TD><asp:checkbox id="chkDisableLink" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"></asp:checkbox></TD>
	</TR>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead" noWrap>Administrator Roles:</td>
		<td><asp:checkboxlist id="chkAdminRoles" runat="server" width="300" Font-Names="Verdana,Arial" Font-Size="8pt" RepeatColumns="2"></asp:checkboxlist></td>
	</tr>
	<tr>
		<td colspan="2">
			&nbsp;
		</td>
	</tr>
	<tr>
		<td class="SubHead" noWrap>Authorized Roles:</td>
		<td><asp:checkboxlist id="chkAuthRoles" runat="server" width="300" Font-Names="Verdana,Arial" Font-Size="8pt" RepeatColumns="2"></asp:checkboxlist></td>
	</tr>
</table>
<p>
	<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update"></asp:linkbutton>&nbsp;&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" CausesValidation="False" BorderStyle="none"></asp:linkbutton>&nbsp;&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdDelete" runat="server" Text="Delete" CausesValidation="False" BorderStyle="none"></asp:linkbutton>
</p>
