<%@ Control language="vb" CodeBehind="EditLinks.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditLinks" %>
<asp:Panel ID="pnlContent" Runat="server">
	<table width="750" cellspacing="0" cellpadding="0" border="0" summary="Edit Links Design Table">
		<tr>
			<td colspan="2">&nbsp;</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top">
				<label for="<%=txtTitle.ClientID%>">Title:</label>
			</td>
			<td>
				<asp:TextBox id="txtTitle" CssClass="NormalTextBox" width="300" Columns="30" maxlength="150" runat="server" />
				<br>
				<asp:RequiredFieldValidator id="valTitle" Display="Dynamic" ErrorMessage="You Must Enter a Title For The Link" ControlToValidate="txtTitle" runat="server" CssClass="NormalRed" />
			</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top"><label style="display:none;" for="<%=optExternal.ClientID%>">Select External Link</label>
				<asp:RadioButton ID="optExternal" Runat="server" GroupName="LinkType" AutoPostBack="True"></asp:RadioButton>&nbsp;<label for="<%=txtExternal.ClientID%>">External 
				Link:</label>
			</td>
			<td>
				<asp:TextBox id="txtExternal" CssClass="NormalTextBox" width="300" Columns="30" maxlength="150" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top"><label style="display:none;" for="<%=optInternal.ClientID%>">Select Internal Link</label>
				<asp:RadioButton ID="optInternal" Runat="server" GroupName="LinkType" AutoPostBack="True"></asp:RadioButton>&nbsp;<label for="<%=cboInternal.ClientID%>">Internal 
				Link:</label>
			</td>
			<td>
				<asp:DropDownList ID="cboInternal" Runat="server" DataValueField="TabId" DataTextField="TabName" CssClass="NormalTextBox" width="300"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top"><label style="display:none;" for="<%=optFile.ClientID%>">Select File Link</label>
				<asp:RadioButton ID="optFile" Runat="server" GroupName="LinkType" AutoPostBack="True"></asp:RadioButton>&nbsp;<label for="<%=cboFiles.ClientID%>">File 
				Link:</label>
			</td>
			<td>
				<asp:DropDownList ID="cboFiles" Runat="server" DataValueField="Value" DataTextField="Text" CssClass="NormalTextBox" width="300"></asp:DropDownList>&nbsp;
				<asp:HyperLink ID="cmdUpload" Runat="server" CssClass="CommandButton">Upload New File</asp:HyperLink>
			</td>
		</tr>
		<tr>
			<td colspan="2">&nbsp;</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top">
				<label for="<%=txtDescription.ClientID%>">Description:</label>
			</td>
			<td>
				<asp:TextBox id="txtDescription" CssClass="NormalTextBox" width="300" Columns="30" Rows="5" TextMode="MultiLine" maxlength="2000" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top">
				<label for="<%=txtViewOrder.ClientID%>">View Order:</label>
			</td>
			<td>
				<asp:TextBox id="txtViewOrder" CssClass="NormalTextBox" width="300" Columns="30" maxlength="3" runat="server" />
				<br>
				<asp:RegularExpressionValidator id="valViewOrder" runat="server" ErrorMessage="View Order must be a Number or an Empty String" Display="Dynamic" ControlToValidate="txtViewOrder" ValidationExpression="^\d*$" CssClass="NormalRed" />
			</td>
		</tr>
		<tr>
			<td class="SubHead" valign="top">
				<label class="SubHead" for="<%=chkNewWindow.ClientID%>">Display In New Window?</label>
			</td>
			<td>
				<asp:CheckBox ID="chkNewWindow" Runat="server" CssClass="NormalTextBox"></asp:CheckBox>
			</td>
		</tr>
	</table>
	<p>
		<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" CssClass="CommandButton" BorderStyle="none" />
		&nbsp;
		<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" CssClass="CommandButton" BorderStyle="none" />
		&nbsp;
		<asp:LinkButton id="cmdDelete" Text="Delete" CausesValidation="False" runat="server" CssClass="CommandButton" BorderStyle="none" />
	</p>
	<hr noshade size="1" width="500">
	<asp:Panel ID="pnlAudit" Runat="server">
		<SPAN class="Normal">Last Updated By&nbsp;<asp:label id="lblCreatedBy" runat="server"></asp:label>&nbsp;On&nbsp;<asp:label id="lblCreatedDate" runat="server"></asp:label></SPAN>
	</asp:Panel>
	<br>
	<table cellspacing="0" cellpadding="2" border="0" summary="Edit Links Design Table">
		<tr valign="top">
			<td class="SubHead">Clicks:</td>
			<td>
				<asp:Label ID="lblClicks" Runat="server" CssClass="Normal"></asp:Label>
			</td>
		</tr>
		<tr vAlign="top">
			<td class="SubHead"><label class="SubHead" for="<%=chkLog.ClientID%>">Show Log?</label></TD>
			<td>
				<asp:Checkbox id="chkLog" runat="server" AutoPostBack="True" CssClass="NormalTextBox"></asp:Checkbox>
			</td>
		</tr>
	</table>
	<asp:datagrid id="grdLog" runat="server" Width="100%" Border="0" CellSpacing="3" AutoGenerateColumns="false" EnableViewState="false" summary="Edit Links Design Table">
		<Columns>
			<asp:BoundColumn HeaderText="Date" DataField="DateTime" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
			<asp:BoundColumn HeaderText="User" DataField="FullName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		</Columns>
	</asp:datagrid>
</asp:Panel>