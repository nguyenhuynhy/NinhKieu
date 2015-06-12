<%@ Control language="vb" CodeBehind="EditAnnouncements.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditAnnouncements" %>
<script language="javascript" src="controls/PopupCalendar.js"></script>
<table cellSpacing="0" cellPadding="0" width="750" summary="Edit Announcements Design Table">
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=txtTitle.ClientID%>">Title:</label></td>
		<td>
			<asp:textbox id="txtTitle" runat="server" maxlength="100" Columns="30" width="390" cssclass="NormalTextBox"></asp:textbox>&nbsp;<asp:CheckBox ID="chkAddDate" Runat="server" Checked="False" CSSClass="SubHead" Text="Add Date?"
				TextAlign="Right"></asp:CheckBox><br>
			<asp:requiredfieldvalidator id="valTitle" runat="server" CssClass="NormalRed" ControlToValidate="txtTitle" ErrorMessage="You Must Enter A Title For The Announcement"
				Display="Dynamic"></asp:requiredfieldvalidator>
		</td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=txtDescription.ClientID%>">Description:</label></td>
		<td><asp:textbox id="txtDescription" runat="server" Columns="44" width="390" CssClass="NormalTextBox"
				Rows="6" TextMode="Multiline"></asp:textbox><br>
			<asp:requiredfieldvalidator id="valDescription" runat="server" CssClass="NormalRed" ControlToValidate="txtDescription"
				ErrorMessage="You Must Enter A Description Of The Announcement" Display="Dynamic"></asp:requiredfieldvalidator></td>
	</tr>
	<tr vAlign="top">
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label class=SubHead style="DISPLAY: none" for="<%=optExternal.ClientID%>">Select External Link</label>
			<asp:radiobutton id="optExternal" AutoPostBack="True" GroupName="LinkType" Runat="server"></asp:radiobutton>&nbsp;<label for="<%=txtExternal.ClientID%>">External Link:</label></td>
		<td><asp:textbox id="txtExternal" runat="server" maxlength="250" cssclass="NormalTextBox" Width="390"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead" vAlign="top"><label class=SubHead style="DISPLAY: none" for="<%=optInternal.ClientID%>">Select Internal Link</label>
			<asp:radiobutton id="optInternal" AutoPostBack="True" GroupName="LinkType" Runat="server"></asp:radiobutton>&nbsp;<label for="<%=cboInternal.ClientID%>">Internal Link:</label>
		</td>
		<td><asp:dropdownlist id="cboInternal" width="390" CssClass="NormalTextBox" Runat="server" DataTextField="TabName"
				DataValueField="TabId"></asp:dropdownlist></td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead" height="41"><label class=SubHead style="DISPLAY: none" for="<%=optFile.ClientID%>">Select File Link</label>
			<asp:radiobutton id="optFile" AutoPostBack="True" GroupName="LinkType" Runat="server"></asp:radiobutton>&nbsp;<label for="<%=cboFile.ClientID%>">File Link:</label>
		</td>
		<td height="41"><asp:dropdownlist id="cboFile" runat="server" CssClass="NormalTextBox" Width="390" DataTextField="Text"
				DataValueField="Value"></asp:dropdownlist>&nbsp;
			<asp:hyperlink id="cmdUpload" CssClass="CommandButton" Runat="server">Upload New File</asp:hyperlink></td>
	</tr>
	<tr vAlign="top">
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtExpires.ClientID%>">Expires:</label></td>
		<td><asp:textbox id="txtExpires" runat="server" Columns="20" width="200" cssclass="NormalTextBox"
				Text=""></asp:textbox>&nbsp;
			<asp:hyperlink id="cmdCalendar" CssClass="CommandButton" Runat="server">Calendar</asp:hyperlink>
			<asp:comparevalidator id="valExpires" runat="server" CssClass="NormalRed" ControlToValidate="txtExpires"
				ErrorMessage="<br>You have entered an invalid date!" Display="Dynamic" Type="Date" Operator="DataTypeCheck"></asp:comparevalidator></td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtViewOrder.ClientID%>">View Order:</label></td>
		<td><asp:textbox id="txtViewOrder" runat="server" maxlength="3" Columns="20" width="200" CssClass="NormalTextBox"></asp:textbox>
			<asp:comparevalidator id="valViewOrder" runat="server" CssClass="NormalRed" ControlToValidate="txtViewOrder"
				ErrorMessage="<br>View order must be an integer value." Display="Dynamic" Type="Integer" Operator="DataTypeCheck"></asp:comparevalidator></td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=chkSyndicate.ClientID%>">*Syndicate:</label></td>
		<td><asp:checkbox id="chkSyndicate" CssClass="NormalTextBox" Runat="server"></asp:checkbox></td>
	</tr>
</table>
<p><asp:linkbutton id="cmdUpdate" runat="server" CssClass="CommandButton" Text="Update" BorderStyle="none"></asp:linkbutton>&nbsp;
	<asp:linkbutton id="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancel" BorderStyle="none"
		CausesValidation="False"></asp:linkbutton>&nbsp;
	<asp:linkbutton id="cmdDelete" runat="server" CssClass="CommandButton" Text="Delete" BorderStyle="none"
		CausesValidation="False"></asp:linkbutton>&nbsp;
	<asp:linkbutton id="cmdSyndicate" runat="server" CssClass="CommandButton" Text="Syndicate" BorderStyle="none"
		CausesValidation="False"></asp:linkbutton></p>
<hr noShade SIZE="1">
<asp:panel id="pnlAudit" Runat="server">
	<SPAN class="Normal">Last Updated By&nbsp; 
<asp:label id="lblCreatedBy" runat="server"></asp:label>&nbsp;On&nbsp; 
<asp:label id="lblCreatedDate" runat="server"></asp:label><BR></SPAN>
</asp:panel><br>
<asp:label id="lblSyndicate" CssClass="SubHead" Runat="server"></asp:label><br>
<br>
<table cellSpacing="0" cellPadding="2" summary="Edit Announcements Design Table" border="0">
	<tr vAlign="top">
		<td class="SubHead">Clicks:</td>
		<td><asp:label id="lblClicks" CssClass="Normal" Runat="server"></asp:label></td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=chkLog.ClientID%>">Show Log?</label></td>
		<td><asp:checkbox id="chkLog" runat="server" CssClass="NormalTextBox" AutoPostBack="True"></asp:checkbox></td>
	</tr>
</table>
<asp:datagrid id="grdLog" runat="server" Width="100%" Summary="Edit Announcements Design Table"
	EnableViewState="false" AutoGenerateColumns="false" CellSpacing="3" Border="0">
	<Columns>
		<asp:BoundColumn HeaderText="Date" DataField="DateTime" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
		<asp:BoundColumn HeaderText="User" DataField="FullName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
	</Columns>
</asp:datagrid>
