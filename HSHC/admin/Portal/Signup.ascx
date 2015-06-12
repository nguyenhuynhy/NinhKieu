<%@ Control language="vb" CodeBehind="Signup.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Signup" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" id="Title1" />
<table cellSpacing="0" cellPadding="4" width="750" border="0" summary="Sign Up Design Table">
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="2" border="0" summary="Sign Up Design Table">
				<tr>
					<td class="Normal">
						<asp:Label ID="lblInstructions" Runat="server" CssClass="Normal"></asp:Label>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr vAlign="top" height="*">
		<td colSpan="3">
			<table cellSpacing="0" cellPadding="0" width="100%" summary="Sign Up Design Table">
				<tr>
					<td align="left"><span class="Head">Portal Setup</span>
					</td>
				</tr>
				<tr>
					<td>
						<hr noShade SIZE="1">
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="2" border="0" summary="Sign Up Design Table">
				<tr>
					<td colspan="3" align="middle"><asp:Label ID="lblMessage" Runat="server" CssClass="NormalRed"></asp:Label></td>
				</tr>
				<tr id="rowType" runat="server">
					<td class="SubHead">Portal Type:</td>
					<td class="SubHead" colspan="2">
						<asp:RadioButton ID="optParent" Runat="server" GroupName="PortalType" CssClass="NormalTextBox"></asp:RadioButton>&nbsp;Parent&nbsp;&nbsp;
						<asp:RadioButton ID="optChild" Runat="server" GroupName="PortalType" CssClass="NormalTextBox" AutoPostBack="True"></asp:RadioButton>&nbsp;Child
					</td>
				</tr>
				<tr>
					<td class="SubHead"><label for="<%=txtPortalName.ClientID%>">Portal Name:</label></td>
					<td><asp:textbox id="txtPortalName" runat="server" width="300" MaxLength="128" CssClass="NormalTextBox"></asp:textbox></td>
					<td><asp:requiredfieldvalidator id="valPortalName" runat="server" CssClass="Normal" Display="Dynamic" ErrorMessage="Portal Name Is Required." ControlToValidate="txtPortalName"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=cboTemplate.ClientID%>">Template:</label></TD>
					<TD><asp:DropDownList ID="cboTemplate" Runat="server" CssClass="NormalTextBox" Width="300"></asp:DropDownList></TD>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<TD colspan="3">&nbsp;</TD>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=txtFirstName.ClientID%>">First Name:</label></TD>
					<TD><asp:textbox id="txtFirstName" CssClass="NormalTextBox" runat="server" MaxLength="100" width="300"></asp:textbox></TD>
					<td><asp:requiredfieldvalidator id="valFirstName" runat="server" CssClass="Normal" ControlToValidate="txtFirstName" ErrorMessage="First Name Is Required." Display="Dynamic"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=txtLastName.ClientID%>">Last Name:</label></TD>
					<TD><asp:textbox id="txtLastName" CssClass="NormalTextBox" runat="server" MaxLength="100" width="300"></asp:textbox></TD>
					<td><asp:requiredfieldvalidator id="valLastName" runat="server" CssClass="Normal" ControlToValidate="txtLastName" ErrorMessage="Last Name Is Required." Display="Dynamic"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=txtUsername.ClientID%>">Username:</label></TD>
					<TD><asp:textbox id="txtUsername" runat="server" width="300" MaxLength="100" CssClass="NormalTextBox"></asp:textbox></TD>
					<td><asp:requiredfieldvalidator id="valUsername" runat="server" CssClass="Normal" Display="Dynamic" ErrorMessage="Username Is Required." ControlToValidate="txtUsername"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=txtPassword.ClientID%>">Password:</label></TD>
					<TD><asp:textbox id="txtPassword" runat="server" width="300" MaxLength="20" CssClass="NormalTextBox" textmode="password"></asp:textbox></TD>
					<td><asp:requiredfieldvalidator id="valPassword" runat="server" CssClass="Normal" Display="Dynamic" ErrorMessage="Password Is Required." ControlToValidate="txtPassword"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=txtConfirm.ClientID%>">Confirm:</label></TD>
					<TD><asp:textbox id="txtConfirm" runat="server" width="300" MaxLength="20" CssClass="NormalTextBox" textmode="password"></asp:textbox></TD>
					<td><asp:requiredfieldvalidator id="valConfirm" runat="server" CssClass="Normal" Display="Dynamic" ErrorMessage="Password Confirmation Is Required." ControlToValidate="txtConfirm"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD class="SubHead"><label for="<%=txtEmail.ClientID%>">Email:</label></TD>
					<TD><asp:textbox id="txtEmail" runat="server" width="300" MaxLength="100" CssClass="NormalTextBox"></asp:textbox></TD>
					<td><asp:requiredfieldvalidator id="valEmail" runat="server" CssClass="Normal" Display="Dynamic" ErrorMessage="Email Is Required." ControlToValidate="txtEmail"></asp:requiredfieldvalidator></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="2" border="0" summary="Sign Up Design Table">
				<tr>
					<td colSpan="3">
						<table cellSpacing="0" cellPadding="0" border="0" summary="Sign Up Design Table">
							<tr>
								<td>
									<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Create Portal"></asp:linkbutton>&nbsp;&nbsp;
									<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" CausesValidation="False"></asp:linkbutton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<br>
		</td>
	</tr>
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="2" border="0" summary="Sign Up Design Table">
				<tr>
					<td class="Normal"><b>*Note:</b> Once your portal is created, you will need to 
						login using the Administrator information specified above.
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
