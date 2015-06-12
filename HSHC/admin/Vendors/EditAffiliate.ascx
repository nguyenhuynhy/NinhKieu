<%@ Control language="vb" CodeBehind="EditAffiliate.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditAffiliate" %>
<script language="javascript" src="controls/PopupCalendar.js"></script>
<br>
<table cellSpacing="2" cellPadding="0" width="750">
	<TR>
		<TD class="SubHead">* Start Date:</TD>
		<TD>
			<asp:TextBox id="txtStartDate" runat="server" cssclass="NormalTextBox" width="120" Columns="30" maxlength="11"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdStartCalendar" CssClass="CommandButton" Runat="server">Calendar</asp:hyperlink>
		</TD>
	</TR>
	<TR>
		<TD class="SubHead">* End Date:</TD>
		<TD>
			<asp:TextBox id="txtEndDate" runat="server" cssclass="NormalTextBox" width="120" Columns="30" maxlength="11"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdEndCalendar" CssClass="CommandButton" Runat="server">Calendar</asp:hyperlink>
		</TD>
	</TR>
	<TR>
		<TD class="SubHead">Cost Per Click ( CPC ):</TD>
		<TD>
			<asp:TextBox id="txtCPC" runat="server" maxlength="7" Columns="30" width="300" cssclass="NormalTextBox"></asp:TextBox>
			<br>
			<asp:requiredfieldValidator id="valCPC1" runat="server" ControlToValidate="txtCPC" ErrorMessage="You Must Enter a Valid CPC" Display="Dynamic" CssClass="NormalRed"></asp:requiredfieldValidator>
			<asp:compareValidator id="valCPC2" runat="server" ControlToValidate="txtCPC" ErrorMessage="You Must Enter a Valid CPC" Display="Dynamic" Type="Double" Operator="DataTypeCheck" CssClass="NormalRed"></asp:compareValidator>
		</TD>
	</TR>
	<TR>
		<TD class="SubHead">Cost Per Acquisition ( CPA ):</TD>
		<TD>
			<asp:TextBox id="txtCPA" runat="server" maxlength="7" Columns="30" width="300" cssclass="NormalTextBox"></asp:TextBox>
			<br>
			<asp:requiredfieldValidator id="valCPA1" runat="server" ControlToValidate="txtCPA" ErrorMessage="You Must Enter a Valid CPA" Display="Dynamic" CssClass="NormalRed"></asp:requiredfieldValidator>
			<asp:compareValidator id="valCPA2" runat="server" ControlToValidate="txtCPA" ErrorMessage="You Must Enter a Valid CPA" Display="Dynamic" Type="Double" Operator="DataTypeCheck" CssClass="NormalRed"></asp:compareValidator>
		</TD>
	</TR>
</table>
<br>
<span class="SubHead">* = Optional</span>
<p>
	<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update" BorderStyle="none"></asp:linkbutton>&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" BorderStyle="none" CausesValidation="False"></asp:linkbutton>&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdDelete" runat="server" Text="Delete" BorderStyle="none" CausesValidation="False"></asp:linkbutton>&nbsp;
	<asp:linkbutton class="CommandButton" id="cmdSend" runat="server" Text="Send Notification" BorderStyle="none" CausesValidation="False"></asp:linkbutton>
</p>
<hr width="500" noShade SIZE="1">
<br>
<span class="Normal">
Use the Start Date and End Date to control the rate schedule for the affiliate contract.<br><br>
Cost Per Click (CPC) is the commission paid to the vendor when a visitor is referred to your portal website.<br><br>
Cost Per Acquisition (CPA) is the commission paid to the vendor when a visitor becomes a member of your portal website.<br><br>
</span>
