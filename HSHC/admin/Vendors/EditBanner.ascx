<%@ Control language="vb" CodeBehind="EditBanner.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditBanner" %>
<script language="javascript" src="controls/PopupCalendar.js"></script>
<br>
<table cellSpacing="2" cellPadding="0" width="750" summary="Edit Banner Design Table">
	<tr vAlign="top">
		<td class="SubHead" width="100"><label for="<%=txtBannerName.ClientID%>">Banner Name:</label></td>
		<td rowSpan="8">&nbsp;</td>
		<td>
			<asp:textbox id="txtBannerName" runat="server" maxlength="100" Columns="30" width="300" cssclass="NormalTextBox"></asp:textbox>
			<br>
			<asp:requiredfieldValidator id="valBannerName" runat="server" ControlToValidate="txtBannerName" ErrorMessage="You Must Enter a Banner Name"
				Display="Dynamic" CssClass="NormalRed"></asp:requiredfieldValidator>
		</td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=cboBannerType.ClientID%>">Banner Type:</label></td>
		<td>
			<asp:DropDownList id="cboBannerType" DataTextField="BannerTypeName" DataValueField="BannerTypeId" width="300" cssclass="NormalTextBox" runat="server" />
		</td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=cboImage.ClientID%>">Image:</label></td>
		<td>
			<asp:dropdownlist id="cboImage" CssClass="NormalTextBox" runat="server" Width="300" DataValueField="Value" DataTextField="Text"></asp:dropdownlist>&nbsp;
			<asp:HyperLink ID="cmdUpload" Runat="server" CssClass="CommandButton">Upload New File</asp:HyperLink>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtURL.ClientID%>">* URL:</label></td>
		<td>
			<asp:TextBox id="txtURL" runat="server" maxlength="100" Columns="30" width="300" cssclass="NormalTextBox"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtImpressions.ClientID%>">Impressions:</label></td>
		<td>
			<asp:TextBox id="txtImpressions" runat="server" maxlength="10" Columns="30" width="300" cssclass="NormalTextBox"></asp:TextBox>
			<br>
			<asp:requiredfieldValidator id="valImpressions" runat="server" ControlToValidate="txtImpressions" ErrorMessage="You Must Enter a Valid Number of Impressions"
				Display="Dynamic" CssClass="NormalRed"></asp:requiredfieldValidator>
			<asp:compareValidator id="compareImpressions" runat="server" Display="Dynamic" ErrorMessage="You Must Enter a Valid Number of Impressions"
				ControlToValidate="txtImpressions" Operator="DataTypeCheck" Type="Integer" CssClass="NormalRed"></asp:compareValidator>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtCPM.ClientID%>">CPM:</label></td>
		<td>
			<asp:TextBox id="txtCPM" runat="server" maxlength="7" Columns="30" width="300" cssclass="NormalTextBox"></asp:TextBox>
			<br>
			<asp:requiredfieldValidator id="valCPM" runat="server" ControlToValidate="txtCPM" ErrorMessage="You Must Enter a Valid CPM"
				Display="Dynamic" CssClass="NormalRed"></asp:requiredfieldValidator>
			<asp:compareValidator id="compareCPM" runat="server" ControlToValidate="txtCPM" ErrorMessage="You Must Enter a Valid CPM"
				Display="Dynamic" Type="Currency" Operator="DataTypeCheck" CssClass="NormalRed"></asp:compareValidator>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtStartDate.ClientID%>">* Start Date:</label></td>
		<td>
			<asp:TextBox id="txtStartDate" runat="server" cssclass="NormalTextBox" width="120" Columns="30" maxlength="11"></asp:TextBox>&nbsp;
			<asp:hyperlink id="cmdStartCalendar" CssClass="CommandButton" Runat="server">Calendar</asp:hyperlink>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=txtEndDate.ClientID%>">* End Date:</label></td>
		<td>
			<asp:TextBox id="txtEndDate" runat="server" cssclass="NormalTextBox" width="120" Columns="30" maxlength="11"></asp:TextBox>&nbsp;
			<asp:hyperlink id="cmdEndCalendar" CssClass="CommandButton" Runat="server">Calendar</asp:hyperlink>
		</td>
	</tr>
</table>
<br>
<span class="SubHead">* = Optional</span>
<p>
	<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update" BorderStyle="none"></asp:linkbutton>&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" BorderStyle="none"
		CausesValidation="False"></asp:linkbutton>&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdDelete" runat="server" Text="Delete" BorderStyle="none"
		CausesValidation="False"></asp:linkbutton>
</p>
<hr width="500" noShade SIZE="1">
<asp:Panel ID="pnlAudit" Runat="server">
	<SPAN class="Normal">Last Updated By&nbsp;<asp:label id="lblCreatedBy" runat="server"></asp:label>&nbsp;On&nbsp;<asp:label id="lblCreatedDate" runat="server"></asp:label><BR></SPAN><BR>
</asp:Panel>
<br>
<span class="Normal">
The Banner Name will be displayed as alternate text for the displayed image.<br><br>
If you do not enter a URL, a page displaying the Vendors contact information will be displayed on a Click Through.<br><br>
For unlimited Impressions enter Zero (0).<br><br>
CPM is the cost for 1000 Impressions.<br><br>
Use the Start Date and End Date to control the display schedule for the banner.<br><br>
</span>
