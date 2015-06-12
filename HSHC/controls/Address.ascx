<%@ Control language="vb" CodeBehind="Address.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Address" %>
<%@ Register TagPrefix="wc" Namespace="PortalQH.Web.UI.WebControls" Assembly="CountryListBox" %>
<table cellSpacing="0" cellPadding="1" border="0" summary="Address Design Table">
	<TR id="rowStreet" runat="server">
		<TD nowrap width="90"><LABEL for="<%=txtStreet.ClientID%>"><ASP:LABEL ID="lblStreet" Runat="server" CssClass="SubHead">Street:</ASP:LABEL></LABEL></TD>
		<TD valign="top" nowrap>
			<ASP:TEXTBOX id="txtStreet" runat="server" MaxLength="50" cssclass="NormalTextBox" Width="200px"></ASP:TEXTBOX>
			<ASP:CHECKBOX ID="chkStreet" Runat="server" CssClass="NormalTextBox" Visible="False" AutoPostBack="True"></ASP:CHECKBOX>
			<ASP:LABEL ID="lblStreetRequired" Runat="server" CssClass="NormalBold"></ASP:LABEL><LABEL class="SubHead" style="display:none;" for="<%=chkStreet.ClientID%>">Street Is Required.</LABEL>
			<ASP:REQUIREDFIELDVALIDATOR id="valStreet" runat="server" CssClass="NormalRed" ControlToValidate="txtStreet" ErrorMessage="<br>Street Is Required." Display="Dynamic"></ASP:REQUIREDFIELDVALIDATOR>
		</TD>
	</TR>
	<TR id="rowUnit" runat="server">
		<TD nowrap width="90"><LABEL for="<%=txtUnit.ClientID%>"><ASP:LABEL ID="lblUnit" Runat="server" CssClass="SubHead">Unit#:</ASP:LABEL></LABEL></TD>
		<TD valign="top" nowrap>
			<ASP:TEXTBOX id="txtUnit" runat="server" MaxLength="50" cssclass="NormalTextBox" Width="200px"></ASP:TEXTBOX>
		</TD>
	</TR>
	<TR id="rowCity" runat="server">
		<TD nowrap width="90"><LABEL for="<%=txtCity.ClientID%>"><ASP:LABEL ID="lblCity" Runat="server" CssClass="SubHead">City:</ASP:LABEL></LABEL></TD>
		<TD valign="top" nowrap>
			<ASP:TEXTBOX id="txtCity" runat="server" MaxLength="50" cssclass="NormalTextBox" Width="200px"></ASP:TEXTBOX>
			<ASP:CHECKBOX ID="chkCity" Runat="server" CssClass="NormalTextBox" Visible="False" AutoPostBack="True"></ASP:CHECKBOX>
			<ASP:LABEL ID="lblCityRequired" Runat="server" CssClass="NormalBold"></ASP:LABEL><LABEL class="SubHead" style="display:none;" for="<%=chkCity.ClientID%>">City Is Required.</LABEL>
			<ASP:REQUIREDFIELDVALIDATOR id="valCity" runat="server" CssClass="NormalRed" ControlToValidate="txtCity" ErrorMessage="<br>City Is Required." Display="Dynamic"></ASP:REQUIREDFIELDVALIDATOR>
		</TD>
	</TR>
	<tr id="rowCountry" runat="server">
		<td nowrap width="90"><label for="<%=cboCountry.ClientID%>"><asp:Label ID="lblCountry" Runat="server" CssClass="SubHead">Country:</asp:Label></label></td>
		<td valign="top" nowrap>
			<wc:CountryListBox TestIP="" LocalhostCountryCode="US" id=cboCountry CssClass="NormalTextBox" Width="200px" DataValueField="Code" DataTextField="Description" AutoPostBack="True" runat="server"></wc:CountryListBox>
			<asp:CheckBox ID="chkCountry" Runat="server" CssClass="NormalTextBox" Visible="False" AutoPostBack="True"></asp:CheckBox>
			<asp:Label ID="lblCountryRequired" Runat="server" CssClass="NormalBold"></asp:Label><label  class="SubHead" style="display:none;" for="<%=chkCountry.ClientID%>">Country is Required.</label>
			<asp:requiredfieldvalidator id="valCountry" runat="server" CssClass="NormalRed" ControlToValidate="cboCountry" ErrorMessage="<br>Country Is Required." Display="Dynamic"></asp:requiredfieldvalidator>
		</td>
	</tr>
	<tr id="rowRegion" runat="server">
		<td nowrap width="90"><label for="<%=cboRegion.ClientID%>"><asp:Label ID="lblRegion" Runat="server" CssClass="SubHead">Region:</asp:Label></label></td>
		<td valign="top" nowrap>
			<asp:DropDownList id="cboRegion" runat="server" cssclass="NormalTextBox" Width="200px" DataValueField="Code" DataTextField="Description" Visible="False"></asp:DropDownList>
			<asp:textbox id="txtRegion" runat="server" MaxLength="50" cssclass="NormalTextBox" Width="200px"></asp:textbox>
			<asp:CheckBox ID="chkRegion" Runat="server" CssClass="NormalTextBox" Visible="False" AutoPostBack="True"></asp:CheckBox>
			<asp:Label ID="lblRegionRequired" Runat="server" CssClass="NormalBold"></asp:Label><label class="SubHead" style="display:none;" for="<%=chkRegion.ClientID%>">Region Is Required.</label>
			<asp:requiredfieldvalidator id="valRegion1" runat="server" CssClass="NormalRed" ControlToValidate="cboRegion" ErrorMessage="<br>Region Is Required." Display="Dynamic"></asp:requiredfieldvalidator>
			<asp:requiredfieldvalidator id="valRegion2" runat="server" CssClass="NormalRed" ControlToValidate="txtRegion" ErrorMessage="<br>Region Is Required." Display="Dynamic"></asp:requiredfieldvalidator>
		</td>
	</tr>
	<tr id="rowPostal" runat="server">
		<td nowrap width="90"><label for="<%=txtPostal.ClientID%>"><asp:Label ID="lblPostal" Runat="server" CssClass="SubHead">Postal:</asp:Label></label></td>
		<td valign="top" nowrap>
			<asp:textbox id="txtPostal" runat="server" MaxLength="50" cssclass="NormalTextBox" Width="200px"></asp:textbox>
			<asp:CheckBox ID="chkPostal" Runat="server" CssClass="NormalTextBox" Visible="False" AutoPostBack="True"></asp:CheckBox>
			<asp:Label ID="lblPostalRequired" Runat="server" CssClass="NormalBold"></asp:Label><label class="SubHead" style="display:none;" for="<%=chkPostal.ClientID%>">Postal Code Is Required.</label>
			<asp:requiredfieldvalidator id="valPostal" runat="server" CssClass="NormalRed" ControlToValidate="txtPostal" ErrorMessage="<br>Postal Code Is Required." Display="Dynamic"></asp:requiredfieldvalidator>
		</td>
	</tr>
	<tr id="rowTelephone" runat="server">
		<td nowrap width="90"><label for="<%=txtTelephone.ClientID%>"><asp:Label ID="lblTelephone" Runat="server" CssClass="SubHead">Telephone:</asp:Label></label></td>
		<td valign="top" nowrap>
			<asp:textbox id="txtTelephone" runat="server" MaxLength="50" cssclass="NormalTextBox" Width="200px"></asp:textbox>
			<asp:CheckBox ID="chkTelephone" Runat="server" CssClass="NormalTextBox" Visible="False" AutoPostBack="True"></asp:CheckBox>
			<asp:Label ID="lblTelephoneRequired" Runat="server" CssClass="NormalBold"></asp:Label><label class="SubHead" style="display:none;" for="<%=chkTelephone.ClientID%>">Telephone Number Is Required.</label>
			<asp:requiredfieldvalidator id="valTelephone" runat="server" CssClass="NormalRed" ControlToValidate="txtTelephone" ErrorMessage="<br>Telephone Number Is Required." Display="Dynamic"></asp:requiredfieldvalidator>
		</td>
	</tr>
</table>
