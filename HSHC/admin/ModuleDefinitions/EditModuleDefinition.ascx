<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" CodeBehind="EditModuleDefinition.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditModuleDefinition" %>
<br>
<table cellSpacing="0" cellPadding="4" border="0" summary="Module Definitions Design Table">
	<tr>
		<td>
			<table id="tabModule" runat="server" cellspacing="0" cellpadding="4" border="0" summary="Module Definitions Design Table">
				<tr>
					<td width="128" class="SubHead">
						<label for="<%=txtFriendlyName.ClientID%>">Module Name:</label>
					</td>
					<td>
						<asp:TextBox id="txtFriendlyName" cssclass="NormalTextBox" width="390" Columns="30" maxlength="150"
							runat="server" Enabled="False" /><br>
						<asp:RequiredFieldValidator id="valFriendlyName" Display="Dynamic" ErrorMessage="Enter a Module Definition Name"
							ControlToValidate="txtFriendlyName" runat="server" />
					</td>
				</tr>
				<tr>
					<td width="128" class="SubHead" valign="top">
						<label for="<%=txtDescription.ClientID%>">Description:</label>
					</td>
					<td>
						<asp:TextBox id="txtDescription" cssclass="NormalTextBox" width="390" Columns="30" TextMode="MultiLine"
							Rows="10" maxlength="2000" runat="server" />
					</td>
				</tr>
				<tr>
					<td class="SubHead" width="128">
						<label for="<%=chkPremium.ClientID%>">Premium?</label>
					</td>
					<td>
						<asp:CheckBox ID="chkPremium" Runat="server" CssClass="NormalTextBox"></asp:CheckBox>
					</td>
				</tr>
				<tr>
					<td width="128" class="SubHead">
						<label for="<%=txtVersion.ClientID%>">Version:</label>
					</td>
					<td>
						<asp:TextBox id="txtVersion" cssclass="NormalTextBox" width="390" Columns="30" maxlength="150"
							runat="server" Enabled="False" /><br>
					</td>
				</tr>
			</table>
			<p>
				<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
				&nbsp;
				<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton"
					BorderStyle="none" />
				&nbsp;
				<asp:LinkButton id="cmdDelete" Text="Delete" CausesValidation="False" runat="server" class="CommandButton"
					BorderStyle="none" />
			</p>
			<table id="tabDefinitions" runat="server" cellspacing="0" cellpadding="4" border="0" summary="Module Definitions Design Table">
				<tr>
					<td colspan="2"><hr>
					</td>
				</tr>
				<tr>
					<td width="128" class="SubHead">
						<label for="<%=cboDefinitions.ClientID%>">Definitions:</label>
					</td>
					<td>
						<asp:dropdownlist id="cboDefinitions" runat="server" Width="290px" CssClass="NormalTextBox" DataTextField="FriendlyName"
							DataValueField="ModuleDefId" AutoPostBack="True"></asp:dropdownlist>
						&nbsp;&nbsp;
						<asp:LinkButton id="cmdDeleteDefinition" Text="Delete Definition" runat="server" class="CommandButton"
							BorderStyle="none" />
					</td>
				</tr>
				<tr>
					<td width="128" class="SubHead" valign="top">
						<label for="<%=txtDefinition.ClientID%>">New Definition:</label>
					</td>
					<td>
						<asp:TextBox id="txtDefinition" cssclass="NormalTextBox" width="290px" Columns="30" maxlength="128"
							runat="server" />
						&nbsp;&nbsp;
						<asp:LinkButton id="cmdAddDefinition" Text="Add Definition" runat="server" class="CommandButton"
							BorderStyle="none" />
					</td>
				</tr>
			</table>
			<table id="tabControls" runat="server" cellspacing="0" cellpadding="4" border="0" width="100%"
				summary="Module Definitions Design Table">
				<tr>
					<td colspan="2"><hr>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:datagrid id="grdControls" runat="server" Width="100%" Border="0" CellSpacing="3" AutoGenerateColumns="false"
							EnableViewState="true" summary="Module Controls Design Table">
							<Columns>
								<asp:TemplateColumn>
									<ItemStyle Width="20px"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id=Hyperlink1 runat="server" NavigateUrl='<%# FormatURL("modulecontrolid",DataBinder.Eval(Container.DataItem,"ModuleControlId")) %>'>
											<asp:Image ImageUrl="~/images/edit.gif" AlternateText="Edit" runat="server" ID="Hyperlink1Image" />
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ControlKey" HeaderText="Control">
									<HeaderStyle CssClass="NormalBold"></HeaderStyle>
									<ItemStyle CssClass="Normal"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ControlTitle" HeaderText="Title">
									<HeaderStyle CssClass="NormalBold"></HeaderStyle>
									<ItemStyle CssClass="Normal"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ControlSrc" HeaderText="Source">
									<HeaderStyle CssClass="NormalBold"></HeaderStyle>
									<ItemStyle CssClass="Normal"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid>
						<p>
							<asp:LinkButton id="cmdAddControl" Text="Add Control" runat="server" class="CommandButton" BorderStyle="none" />
						</p>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
