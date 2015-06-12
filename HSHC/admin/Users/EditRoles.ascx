<%@ Control language="vb" CodeBehind="EditRoles.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditRoles" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" />
<br>
<table width="750" cellspacing="0" cellpadding="0" border="0" summary="Edit Roles Design Table">
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtRoleName.ClientID%>">Name:</label></td>
		<td align="left">
			<asp:TextBox id="txtRoleName" cssclass="NormalTextBox" width="390" Columns="30" maxlength="50" runat="server" />
			<asp:RequiredFieldValidator ID="valRoleName" Display="Dynamic" runat="server" ErrorMessage="<br>You Must Enter a Valid Name" ControlToValidate="txtRoleName" CssClass="NormalRed" />
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtDescription.ClientID%>">Description:</label></td>
		<td><asp:TextBox id="txtDescription" cssclass="NormalTextBox" width="390" Columns="30" maxlength="1000" runat="server" Height="84px" TextMode="MultiLine" /></td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtServiceFee.ClientID%>">Service Fee:</label></td>
		<td>
			<asp:TextBox id="txtServiceFee" cssclass="NormalTextBox" width="390" Columns="30" maxlength="50" runat="server" />			
			<asp:comparevalidator id="valServiceFee1" runat="server" ControlToValidate="txtServiceFee" ErrorMessage="<br>Service Fee Value Entered Is Not Valid" Display="Dynamic" Operator="DataTypeCheck" Type="Currency" CssClass="NormalRed"></asp:comparevalidator>
			<asp:comparevalidator id="valServiceFee2" runat="server" ControlToValidate="txtServiceFee" ErrorMessage="<br>Service Fee Must Be Greater Than Zero" Display="Dynamic" Operator="GreaterThan" ValueToCompare="0" CssClass="NormalRed"></asp:comparevalidator>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtBillingPeriod.ClientID%>">Billing Period (Every):</label></td>
		<td>
			<asp:TextBox id="txtBillingPeriod" cssclass="NormalTextBox" width="390" Columns="30" maxlength="50" runat="server" />
			<asp:comparevalidator id="valBillingPeriod1" runat="server" ControlToValidate="txtBillingPeriod" ErrorMessage="<br>Trial Period Value Entered Is Not Valid" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" CssClass="NormalRed"></asp:comparevalidator>
			<asp:comparevalidator id="valBillingPeriod2" runat="server" ControlToValidate="txtBillingPeriod" ErrorMessage="<br>Trial Period Must Be Greater Than Zero" Display="Dynamic" Operator="GreaterThan" ValueToCompare="0" CssClass="NormalRed"></asp:comparevalidator>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=cboBillingFrequency.ClientID%>">Billing Frequency:</label></label></td>
		<td><asp:DropDownList id="cboBillingFrequency" DataTextField="Description" DataValueField="Code" runat="server" CssClass="NormalTextBox" Width="388px"></asp:DropDownList></td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtTrialFee.ClientID%>">Trial Fee:</label></td>
		<td>
			<asp:TextBox id="txtTrialFee" cssclass="NormalTextBox" width="390" Columns="30" maxlength="50" runat="server" />			
			<asp:comparevalidator id="valTrialFee1" runat="server" ControlToValidate="txtTrialFee" ErrorMessage="<br>Service Fee Value Entered Is Not Valid" Display="Dynamic" Operator="DataTypeCheck" Type="Currency" CssClass="NormalRed"></asp:comparevalidator>
			<asp:comparevalidator id="valTrialFee2" runat="server" ControlToValidate="txtTrialFee" ErrorMessage="<br>Service Fee Must Be Greater Than Zero" Display="Dynamic" Operator="GreaterThan" ValueToCompare="0" CssClass="NormalRed"></asp:comparevalidator>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtTrialPeriod.ClientID%>">Trial Period (Every):</label></td>
		<td>
			<asp:TextBox id="txtTrialPeriod" cssclass="NormalTextBox" width="390" Columns="30" maxlength="50" runat="server" />
			<asp:comparevalidator id="valTrialPeriod1" runat="server" ControlToValidate="txtTrialPeriod" ErrorMessage="<br>Trial Period Value Entered Is Not Valid" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" CssClass="NormalRed"></asp:comparevalidator>
			<asp:comparevalidator id="valTrialPeriod2" runat="server" ControlToValidate="txtTrialPeriod" ErrorMessage="<br>Trial Period Must Be Greater Than Zero" Display="Dynamic" Operator="GreaterThan" ValueToCompare="0" CssClass="NormalRed"></asp:comparevalidator>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=cboTrialFrequency.ClientID%>">Trial Frequency:</label></td>
		<td><asp:DropDownList id="cboTrialFrequency" DataTextField="Description" DataValueField="Code" runat="server" CssClass="NormalTextBox" Width="388px"></asp:DropDownList></td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=txtEvery.ClientID%>">Push Content Every:</label></td>
		<td>
			<asp:textbox ID="txtEvery" runat="server" maxlength="3" Columns="3" cssclass="NormalTextBox"></asp:textbox>&nbsp;
			<label style="display:none;" for="<%=cboPeriod.ClientID%>">Period</label>
			<asp:DropDownList ID="cboPeriod" Runat="server" cssclass="NormalTextBox">
				<asp:ListItem Value=""></asp:ListItem>
				<asp:ListItem Value="D">Day(s)</asp:ListItem>
				<asp:ListItem Value="W">Week(s)</asp:ListItem>
				<asp:ListItem Value="M">Month(s)</asp:ListItem>
				<asp:ListItem Value="Y">Year(s)</asp:ListItem>
			</asp:DropDownList>
			&nbsp;<span class="NormalRed">*Not Implemented*</span>
		</td>
		<td class="Normal"></td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead"><label for="<%=txtStartDate.ClientID%>">Start Date:</label>
		</td>
		<td>
			<asp:textbox id="txtStartDate" runat="server" maxlength="20" Columns="20" cssclass="NormalTextBox"></asp:textbox>
			&nbsp;<span class="NormalRed">*Not Implemented*</span>
		</td>
	</tr>
	<tr>
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=chkIsPublic.ClientID%>">Public Role?</label></td>
		<td><asp:CheckBox ID="chkIsPublic" Runat="server"></asp:CheckBox>
	</td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=chkAutoAssignment.ClientID%>">Auto Assignment?</label></td>
		<td><asp:CheckBox ID="chkAutoAssignment" Runat="server"></asp:CheckBox>
	</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" runat="server" CssClass="CommandButton" Text="Update" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancel" CausesValidation="False" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdDelete" runat="server" CssClass="CommandButton" Text="Delete" CausesValidation="False" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdManage" runat="server" CssClass="CommandButton" Text="Manage Users" CausesValidation="False" />
</p>

