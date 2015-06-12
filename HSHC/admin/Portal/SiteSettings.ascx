<%@ Register TagPrefix="Portal" TagName="Skin" Src="~/controls/SkinControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="PortalQH.SiteSettings" CodeBehind="SiteSettings.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<script language="javascript" src="controls/PopupCalendar.js"></script>
<portal:title id="Title1" runat="server"></portal:title>
<table cellSpacing="0" cellPadding="2" border="0" summary="Site Settings Design Table">
	<tr>
		<td vAlign="top">
			<table cellSpacing="2" cellPadding="2" border="0" summary="Site Settings Design Table">
				<tr>
					<td class="SubHead" width="165"><label for="<%=txtPortalName.ClientID%>">Title:</label></td>
					<td class="NormalTextBox"><asp:textbox id="txtPortalName" runat="server" width="300" MaxLength="128" CssClass="NormalTextBox"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboLogo.ClientID%>">Logo:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboLogo" runat="server" CssClass="NormalTextBox" DataTextField="Text" DataValueField="Value"
							Width="300"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=ctlPortalSkin.ClientID%>">Portal Skin:</label></td>
					<td valign="top"><portal:skin id="ctlPortalSkin" runat="server"></portal:skin></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=ctlPortalContainer.ClientID%>">Portal Container:</label></td>
					<td valign="top"><portal:skin id="ctlPortalContainer" runat="server"></portal:skin></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=ctlAdminSkin.ClientID%>">Admin Skin:</label></td>
					<td valign="top"><portal:skin id="ctlAdminSkin" runat="server"></portal:skin></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=ctlAdminContainer.ClientID%>">Admin Container:</label></td>
					<td valign="top"><portal:skin id="ctlAdminContainer" runat="server"></portal:skin></td>
				</tr>
				<tr>
					<td class="SubHead" vAlign="top" width="165"><label for="<%=txtDescription.ClientID%>">Description:</label></td>
					<td class="NormalTextBox"><asp:textbox id="txtDescription" runat="server" width="300" MaxLength="500" CssClass="NormalTextBox"
							Rows="3" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead" vAlign="top" width="165"><label for="<%=txtKeyWords.ClientID%>">Key Words:</label></td>
					<td class="NormalTextBox"><asp:textbox id="txtKeyWords" runat="server" width="300" MaxLength="500" CssClass="NormalTextBox"
							Rows="3" TextMode="MultiLine"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td width="165">&nbsp;</td>
					<td><asp:linkbutton id="cmdGoogle" runat="server" Text="Submit Site To Google" cssclass="CommandButton"></asp:linkbutton>
					</td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboBackground.ClientID%>">Body Background:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboBackground" runat="server" CssClass="NormalTextBox" DataTextField="Text"
							DataValueField="Value" Width="300"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=txtFooterText.ClientID%>">Copyright:</label></td>
					<td class="NormalTextBox"><asp:textbox id="txtFooterText" runat="server" width="300" MaxLength="100" CssClass="NormalTextBox"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead" width="165">User Registration?</td>
					<td class="NormalTextBox"><asp:radiobuttonlist id="optUserRegistration" CssClass="Normal" Runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="0">None</asp:ListItem>
							<asp:ListItem Value="1">Private</asp:ListItem>
							<asp:ListItem Value="2">Public</asp:ListItem>
							<asp:ListItem Value="3">Verified</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165">Banner Advertising?</td>
					<td class="NormalTextBox">
						<asp:radiobuttonlist id="optBannerAdvertising" CssClass="Normal" Runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="0">None</asp:ListItem>
							<asp:ListItem Value="1">Site</asp:ListItem>
							<asp:ListItem Value="2">Host</asp:ListItem>
						</asp:radiobuttonlist>
					</td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboHomeTabId.ClientID%>">Home Tab:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboHomeTabId" CssClass="NormalTextBox" DataTextField="TabName" DataValueField="TabId"
							Width="300" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboLoginTabId.ClientID%>">Login Tab:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboLoginTabId" CssClass="NormalTextBox" DataTextField="TabName" DataValueField="TabId"
							Width="300" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboUserTabId.ClientID%>">User Tab:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboUserTabId" CssClass="NormalTextBox" DataTextField="TabName" DataValueField="TabId"
							Width="300" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboCurrency.ClientID%>">Currency:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboCurrency" CssClass="NormalTextBox" DataTextField="Description" DataValueField="Code"
							Width="300" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboAdministratorId.ClientID%>">Administrator:</label></td>
					<td class="NormalTextBox"><asp:dropdownlist id="cboAdministratorId" CssClass="NormalTextBox" DataTextField="FullName" DataValueField="UserId"
							Width="300" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=cboProcessor.ClientID%>">Payment Processor:</label></td>
					<td>
						<asp:dropdownlist id="cboProcessor" CssClass="NormalTextBox" DataTextField="Description" DataValueField="Code"
							Width="300" Runat="server"></asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td width="165">&nbsp;</td>
					<td><asp:linkbutton id="cmdProcessor" runat="server" Text="Go To Payment Processor Website" cssclass="CommandButton"></asp:linkbutton>
					</td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=txtUserId.ClientID%>">Processor UserId:</label></td>
					<td>
						<asp:textbox id="txtUserId" runat="server" width="300" MaxLength="50" CssClass="NormalTextBox"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td class="SubHead" width="165"><label for="<%=txtPassword.ClientID%>">Processor Password:</label></td>
					<td>
						<asp:textbox id="txtPassword" runat="server" width="300" MaxLength="50" CssClass="NormalTextBox"
							TextMode="Password"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td colSpan="2">&nbsp;</td>
				</tr>
				<tr id="SiteRow1" runat="server" Visible="false">
					<td class="SubHead" vAlign="top" width="165"><label for="<%=txtPortalAlias.ClientID%>">Portal Alias:</label></td>
					<td class="NormalTextBox"><asp:textbox id="txtPortalAlias" runat="server" width="300" MaxLength="200" CssClass="NormalTextBox"
							Rows="3" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr id="SiteRow2" runat="server" Visible="false">
					<td class="SubHead" width="165"><label for="<%=txtExpiryDate.ClientID%>">Expiry Date:</label></td>
					<td class="NormalTextBox">
						<asp:textbox id="txtExpiryDate" runat="server" width="150" MaxLength="15" CssClass="NormalTextBox"></asp:textbox>
						<asp:HyperLink id="cmdExpiryCalendar" Runat="server" CssClass="CommandButton">Calendar</asp:HyperLink>
						<asp:CompareValidator id="valExpiryDate" runat="server" CssClass="NormalRed" ControlToValidate="txtExpiryDate"
							ErrorMessage="<br>Invalid expiry date!" Operator="DataTypeCheck" Type="Date" Display="Dynamic"></asp:CompareValidator>
					</td>
				</tr>
				<tr id="SiteRow3" runat="server" Visible="false">
					<td class="SubHead" width="165"><label for="<%=txtHostFee.ClientID%>">Hosting Fee:</label></td>
					<td class="NormalTextBox">
						<asp:textbox id="txtHostFee" runat="server" width="300" MaxLength="10" CssClass="NormalTextBox"></asp:textbox>
					</td>
				</tr>
				<tr id="SiteRow4" runat="server" Visible="false">
					<td class="SubHead" width="165"><label for="<%=txtHostSpace.ClientID%>">Disk Space (MB):</label></td>
					<td class="NormalTextBox">
						<asp:textbox id="txtHostSpace" runat="server" width="300" MaxLength="3" CssClass="NormalTextBox"></asp:textbox>
					</td>
				</tr>
				<tr id="SiteRow5" runat="server" Visible="false">
					<td class="SubHead" width="165"><label for="<%=txtSiteLogHistory.ClientID%>">Site Log History (Days):</label></td>
					<td class="NormalTextBox">
						<asp:textbox id="txtSiteLogHistory" runat="server" width="300" MaxLength="3" CssClass="NormalTextBox"></asp:textbox>
					</td>
				</tr>
				<tr id="SiteRow6" runat="server" Visible="false">
					<td colSpan="2">&nbsp;</td>
				</tr>
			</table>
		</td>
		<td vAlign="top">
			<table cellSpacing="2" cellPadding="2" border="0" summary="Site Settings Design Table">
				<tr>
					<td class="SubHead" align="center"><label for="<%=txtLogin.ClientID%>">Login Intructions:</label></td>
				</tr>
				<tr>
					<td><asp:textbox id="txtLogin" runat="server" width="200px" MaxLength="1000" CssClass="NormalTextBox"
							Rows="7" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="SubHead" align="center"><label for="<%=txtRegistration.ClientID%>">Registration Instructions:</label></td>
				</tr>
				<tr>
					<td><asp:textbox id="txtRegistration" runat="server" width="200px" MaxLength="1000" CssClass="NormalTextBox"
							Rows="7" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="SubHead" align="center"><label for="<%=txtSignup.ClientID%>">New User Signup Message:</label></td>
				</tr>
				<tr>
					<td><asp:textbox id="txtSignup" runat="server" width="200px" MaxLength="1000" CssClass="NormalTextBox"
							Rows="7" TextMode="MultiLine"></asp:textbox></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colSpan="2"><asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update"></asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" Visible="False"></asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton class="CommandButton" id="cmdDelete" runat="server" Text="Delete" Visible="False"></asp:linkbutton>
		</td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr>
		<td colSpan="2"><asp:checkbox id="chkStyleSheet" CssClass="NormalTextBox" Runat="server" AutoPostBack="True"></asp:checkbox>&nbsp;
			<label Class="SubHead" for="<%=chkStyleSheet.ClientID%>">Edit Style Sheet</label></td>
	</tr>
	<tr id="StyleRow1" runat="server" Visible="false">
		<td colSpan="2"><asp:textbox id="txtStyleSheet" CssClass="NormalTextBox" Rows="25" TextMode="MultiLine" Runat="server"
				Wrap="False" Columns="110"></asp:textbox></td>
	</tr>
	<tr id="StyleRow2" runat="server" Visible="false">
		<td colSpan="2"><asp:linkbutton id="cmdSave" CssClass="CommandButton" Runat="server">Save Style Sheet</asp:linkbutton>&nbsp;&nbsp;
			<asp:linkbutton id="cmdRestore" CssClass="CommandButton" Runat="server">Restore Default Style Sheet</asp:linkbutton></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr id="PortalRow1" runat="server" Visible="true">
		<td colSpan="2">
			<table cellSpacing="0" cellPadding="0" width="100%" summary="Site Settings Design Table">
				<tr>
					<td align="left"><span class="Head">Hosting Details</span>
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
	<tr id="PortalRow2" runat="server" Visible="true">
		<td colSpan="2">
			<asp:datagrid id="grdModuleDefinitions" runat="server" CssClass="Normal" DataKeyField="DesktopModuleID"
				Border="0" CellPadding="4" CellSpacing="4" AutoGenerateColumns="False" OnEditCommand="grdModuleDefinitions_Edit"
				OnUpdateCommand="grdModuleDefinitions_Update" OnCancelCommand="grdModuleDefinitions_CancelEdit"
				EnableViewState="True" summary="Site Settings Design Table">
				<Columns>
					<asp:TemplateColumn ItemStyle-Wrap="False">
						<ItemTemplate>
							<asp:imagebutton id="cmdEditModuleDefinitions" runat="server" causesvalidation="false" commandname="Edit"
								AlternateText="Edit" ImageUrl="~/images/edit.gif"></asp:imagebutton>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:imagebutton id="cmdSaveModuleDefinitions" runat="server" causesvalidation="false" commandname="Update"
								AlternateText="Update" ImageUrl="~/images/save.gif"></asp:imagebutton>
							<asp:imagebutton id="cmdCancelModuleDefinitions" runat="server" causesvalidation="false" commandname="Cancel"
								AlternateText="Cancel" ImageUrl="~/images/cancel.gif"></asp:imagebutton>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="" ItemStyle-CssClass="Normal" ItemStyle-HorizontalAlign="Center">
						<ItemTemplate>
							<asp:Image runat="server" ImageUrl='<%# IIf(IsSubscribed(DataBinder.Eval(Container.DataItem, "PortalModuleDefinitionId")), "~/images/checked.gif", "~/images/unchecked.gif") %>' AlternateText='<%# IIf(IsSubscribed(DataBinder.Eval(Container.DataItem, "PortalModuleDefinitionId")), "Checked", "UnChecked") %>' ID="Image2"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:Label ID="lblCheckBox2" Runat="server" />
							<asp:CheckBox runat="server" id="Checkbox2" Checked='<%# IIf(IsSubscribed(DataBinder.Eval(Container.DataItem, "PortalModuleDefinitionId")), "True", "False") %>' />
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn HeaderText="Premium Module" DataField="FriendlyName" ReadOnly="True" ItemStyle-CssClass="Normal"
						HeaderStyle-Cssclass="NormalBold" ItemStyle-Wrap="False" HeaderStyle-Wrap="False" />
					<asp:BoundColumn HeaderText="Description" DataField="Description" ReadOnly="True" ItemStyle-CssClass="Normal"
						HeaderStyle-Cssclass="NormalBold" />
					<asp:TemplateColumn HeaderText="Fee" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" ItemStyle-HorizontalAlign="Right">
						<ItemTemplate>
							<asp:label runat="server" Text='<%# FormatFee(DataBinder.Eval(Container.DataItem, "HostFee")) %>' ID="Label1"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:Label ID="lblHostingFee" Runat="server" />
							<asp:TextBox runat="server" id="txtHostingFee" Columns="10" MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "HostFee") %>' Enabled='<%# IsSuperUser() %>' />
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="" ItemStyle-CssClass="NormalBold" ItemStyle-Wrap="False" HeaderStyle-Wrap="False">
						<ItemTemplate>
							<asp:label runat="server" Text='<%# FormatCurrency %>' ID="Label2"/>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:label runat="server" Text='<%# FormatCurrency %>' ID="Label3"/>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid><br>
		</td>
	</tr>
	<tr id="PortalRow3" runat="server" Visible="true">
		<td colSpan="2">
			<table cellSpacing="0" cellPadding="2" border="0" summary="Site Settings Design Table">
				<tr>
					<td class="SubHead" width="165">Basic Hosting Fee:</td>
					<td class="Normal" align="right"><asp:label id="lblHostFee" runat="server" CssClass="Normal"></asp:label>&nbsp;&nbsp;<asp:label id="lblHostCurrency" runat="server" CssClass="NormalBold"></asp:label></td>
				</tr>
				<tr>
					<td class="SubHead" width="165">Premium Modules:</td>
					<td class="Normal" align="right"><asp:label id="lblModuleFee" runat="server" CssClass="Normal"></asp:label>&nbsp;&nbsp;<asp:label id="lblModuleCurrency" runat="server" CssClass="NormalBold"></asp:label></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<hr noShade SIZE="1">
					</td>
				</tr>
				<tr>
					<td class="SubHead" width="165">Total Hosting Fee:</td>
					<td class="Normal" align="right"><asp:label id="lblTotalFee" runat="server" CssClass="Normal"></asp:label>&nbsp;&nbsp;<asp:label id="lblTotalCurrency" runat="server" CssClass="NormalBold"></asp:label></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr id="PortalRow4" runat="server" Visible="true">
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr id="PortalRow5" runat="server" Visible="true">
		<td colSpan="2">
			<table cellSpacing="0" cellPadding="2" border="0" summary="Site Settings Design Table">
				<tr>
					<td class="SubHead" width="165">Portal Expiry Date:</td>
					<td class="NormalTextBox"><asp:label id="lblExpiryDate" runat="server" CssClass="Normal"></asp:label></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr id="PortalRow6" runat="server" Visible="true">
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr id="PortalRow7" runat="server" Visible="true">
		<td colSpan="2"><asp:linkbutton id="cmdRenew" runat="server" Text="Click Here To Renew/Extend Your Portal Hosting Subscription"
				cssclass="CommandButton"></asp:linkbutton></td>
	</tr>
</table>
