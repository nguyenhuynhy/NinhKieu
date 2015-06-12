<%@ Control language="vb" CodeBehind="SecurityRoles.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.SecurityRoles" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<script language="javascript" src="controls/PopupCalendar.js"></script>
<portal:title id="Title1" runat="server"></portal:title><br>
<table cellSpacing="0" cellPadding="0" width="750" summary="Security Roles Design Table"
	border="0">
	<tr>
		<td>
			<table cellSpacing="1" cellPadding="1" summary="Security Roles Design Table">
				<tr>
					<td class="NormalBold" width="169"><label 
            for="<%=cboUsers.ClientID%>">User 
          Name</label></td>
					<td class="NormalBold" width="171"><label 
            for="<%=cboRoles.ClientID%>">Security 
            Role</label></td>
					<td class="NormalBold" width="166"><label 
            for="<%=txtExpiryDate.ClientID%>">Expiry 
            Date</label>&nbsp;&nbsp;&nbsp;<asp:hyperlink id="cmdExpiryCalendar" Runat="server" CssClass="CommandButton">Calendar</asp:hyperlink></td>
					<td class="NormalBold">&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="top" width="169"><asp:dropdownlist id="cboUsers" runat="server" CssClass="NormalTextBox" Width="168px" DataTextField="FullName"
							DataValueField="UserID"></asp:dropdownlist></td>
					<td vAlign="top" width="171"><asp:dropdownlist id="cboRoles" runat="server" CssClass="NormalTextBox" Width="164px" DataTextField="RoleName"
							DataValueField="RoleID"></asp:dropdownlist></td>
					<td vAlign="top" width="166"><asp:textbox id="txtExpiryDate" runat="server" CssClass="NormalTextBox" Width="151px"></asp:textbox></td>
					<td vAlign="top" width="150"><asp:linkbutton id="cmdAdd" runat="server" Width="159px" Text="Add Role Membership" cssclass="CommandButton">Update Role Membership</asp:linkbutton></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td><asp:comparevalidator id="valExpiryDate" runat="server" CssClass="NormalRed" ControlToValidate="txtExpiryDate"
							ErrorMessage="Invalid expiry date!" Operator="DataTypeCheck" Type="Date" Display="Dynamic"></asp:comparevalidator></td>
					<td></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colSpan="3">
			<hr noShade SIZE="1">
		</td>
	</tr>
	<tr vAlign="top">
		<td width="755">&nbsp;
			<asp:datagrid id="grdUserRoles" runat="server" Width="100%" OnDeleteCommand="grdUserRoles_Delete"
				DataKeyField="UserRoleID" EnableViewState="false" AutoGenerateColumns="false" CellSpacing="0"
				CellPadding="4" Border="0" summary="Security Roles Design Table">
				<Columns>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:ImageButton ID="cmdDeleteUserRole" Runat="server" AlternateText="Delete" CausesValidation="False"
								CommandName="Delete" ImageUrl="~/images/delete.gif"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn HeaderText="User Name" DataField="FullName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
					<asp:BoundColumn HeaderText="Security Role" DataField="RoleName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
					<asp:TemplateColumn HeaderText="Expiry Date" HeaderStyle-CssClass="NormalBold">
						<ItemTemplate>
							<asp:Label runat="server" Text='<%#FormatExpiryDate(DataBinder.Eval(Container.DataItem, "ExpiryDate")) %>' CssClass="Normal"/>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></td>
	</tr>
	<tr>
		<td><asp:linkbutton id="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancel" CausesValidation="False"></asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton id="cmdDelete" runat="server" CssClass="CommandButton" Text="Delete Role Membership"
				CausesValidation="False"></asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton id="cmdAssignRoles" runat="server" CssClass="CommandButton" Text="Phân Quyền" CausesValidation="False"></asp:linkbutton></td>
	</tr>
</table>
