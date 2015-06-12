<%@ Control language="vb" CodeBehind="Register.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Register" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Register TagPrefix="Portal" TagName="Address" Src="~/controls/Address.ascx"%>
<portal:title runat="server" id="Title1" />
<br>
<asp:Panel ID="UserRow" Runat="server">
	<TABLE cellSpacing="1" cellPadding="0" width="600" summary="Register Design Table">
		<TR>
			<TD colSpan="4">
				<asp:label id="lblRegister" runat="server" CssClass="Normal"></asp:label></TD>
		</TR>
		<TR>
			<TD colSpan="4">&nbsp;
			</TD>
		</TR>
		<TR>
			<TD class="SubHead" width="100"><LABEL for="<%=txtFirstName.ClientID%>">First 
      Name:</LABEL></TD>
			<TD class="NormalBold" noWrap>
				<asp:textbox id="txtFirstName" tabIndex="1" runat="server" MaxLength="50" size="25" cssclass="NormalTextBox"></asp:textbox>&nbsp;*
				<asp:requiredfieldvalidator id="valFirstName" runat="server" CssClass="NormalRed" ControlToValidate="txtFirstName"
					ErrorMessage="<br>First Name Is Required." Display="Dynamic"></asp:requiredfieldvalidator></TD>
			<TD rowSpan="6">&nbsp;&nbsp;</TD>
			<TD class="NormalBold" vAlign="top" width="100" rowSpan="6">
				<portal:address id="Address1" runat="server"></portal:address></TD>
		</TR>
		<TR>
			<TD class="SubHead" width="100"><LABEL for="<%=txtLastName.ClientID%>">Last 
      Name:</LABEL></TD>
			<TD class="NormalBold" noWrap>
				<asp:textbox id="txtLastName" tabIndex="2" runat="server" MaxLength="50" size="25" cssclass="NormalTextBox"></asp:textbox>&nbsp;*
				<asp:requiredfieldvalidator id="valLastName" runat="server" CssClass="NormalRed" ControlToValidate="txtLastName"
					ErrorMessage="<br>Last Name Is Required." Display="Dynamic"></asp:requiredfieldvalidator></TD>
		</TR>
		<TR>
			<TD class="SubHead" width="100"><LABEL 
      for="<%=txtUsername.ClientID%>">Username:</LABEL></TD>
			<TD class="NormalBold" noWrap>
				<asp:textbox id="txtUsername" tabIndex="3" runat="server" MaxLength="100" size="25" cssclass="NormalTextBox"></asp:textbox>&nbsp;*
				<asp:requiredfieldvalidator id="valUsername" runat="server" CssClass="NormalRed" ControlToValidate="txtUsername"
					ErrorMessage="<br>Username Is Required." Display="Dynamic"></asp:requiredfieldvalidator></TD>
		</TR>
		<TR>
			<TD class="SubHead" width="100"><LABEL 
      for="<%=txtPassword.ClientID%>">Password:</LABEL></TD>
			<TD class="NormalBold" noWrap>
				<asp:textbox id="txtPassword" tabIndex="4" runat="server" MaxLength="20" size="25" cssclass="NormalTextBox"
					TextMode="Password"></asp:textbox>&nbsp;*
				<asp:requiredfieldvalidator id="valPassword" runat="server" CssClass="NormalRed" ControlToValidate="txtPassword"
					ErrorMessage="<br>Password Is Required." Display="Dynamic"></asp:requiredfieldvalidator></TD>
		</TR>
		<TR>
			<TD class="SubHead" width="100"><LABEL 
      for="<%=txtConfirm.ClientID%>">Confirm:</LABEL></TD>
			<TD class="NormalBold" noWrap>
				<asp:textbox id="txtConfirm" tabIndex="5" runat="server" MaxLength="20" size="25" cssclass="NormalTextBox"
					TextMode="Password"></asp:textbox>&nbsp;*
				<asp:requiredfieldvalidator id="valConfirm1" runat="server" CssClass="NormalRed" ControlToValidate="txtConfirm"
					ErrorMessage="<br>Password Confirmation Is Required." Display="Dynamic"></asp:requiredfieldvalidator>
				<asp:comparevalidator id="valConfirm2" runat="server" CssClass="NormalRed" ControlToValidate="txtConfirm"
					ErrorMessage="<br>Password Values Entered Do Not Match." Display="Dynamic" ControlToCompare="txtPassword"></asp:comparevalidator></TD>
		</TR>
		<TR>
			<TD class="SubHead" width="100"><LABEL 
      for="<%=txtEmail.ClientID%>">Email:</LABEL></TD>
			<TD class="NormalBold" noWrap>
				<asp:textbox id="txtEmail" tabIndex="6" runat="server" MaxLength="100" size="25" cssclass="NormalTextBox"></asp:textbox>&nbsp;*
				<asp:regularexpressionvalidator id="valEmail2" runat="server" CssClass="NormalRed" ControlToValidate="txtEmail"
					ErrorMessage="<br>Email Must be Valid." Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"></asp:regularexpressionvalidator></TD>
		</TR>
	</TABLE>
	<P>
		<asp:linkbutton class="CommandButton" id="RegisterBtn" runat="server" Text="Register" CausesValidation="True"></asp:linkbutton>&nbsp;&nbsp;
		<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" CausesValidation="False"
			BorderStyle="none"></asp:linkbutton>&nbsp;&nbsp;
		<asp:linkbutton class="CommandButton" id="UnregisterBtn" runat="server" Text="Unregister"></asp:linkbutton></P>
	<P>
		<asp:label id="Message" runat="server" CssClass="NormalRed"></asp:label></P>
	<P>
		<asp:label id="lblRegistration" runat="server" CssClass="Normal" Width="600"></asp:label></P>
</asp:Panel>
<asp:Panel ID="ServicesRow" Runat="server">
	<TABLE cellSpacing="0" cellPadding="4" width="600" summary="Register Design Table" border="0">
		<TR vAlign="top" height="*">
			<TD colSpan="3">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" summary="Register Design Table">
					<TR>
						<TD align="left"><SPAN class="Head">Membership Services</SPAN>
						</TD>
					</TR>
					<TR>
						<TD>
							<HR noShade SIZE="1">
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD>
				<P>
					<asp:datagrid id="myDataGrid" runat="server" Border="0" CellPadding="5" CellSpacing="5" AutoGenerateColumns="false"
						EnableViewState="true" summary="Register Design Table">
						<Columns>
							<asp:TemplateColumn>
								<ItemTemplate>
									<asp:HyperLink Text='<%# ServiceText(DataBinder.Eval(Container.DataItem,"Subscribed")) %>' CssClass="CommandButton" NavigateUrl='<%# ServiceURL("RoleID",DataBinder.Eval(Container.DataItem,"RoleID"),DataBinder.Eval(Container.DataItem,"ServiceFee"),DataBinder.Eval(Container.DataItem,"Subscribed")) %>' runat="server" ID="Hyperlink1"/>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn HeaderText="Name" DataField="RoleName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
							<asp:BoundColumn HeaderText="Description" DataField="Description" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
							<asp:TemplateColumn HeaderText="Fee" HeaderStyle-CssClass="NormalBold">
								<ItemTemplate>
									<asp:Label runat="server" Text='<%#FormatPrice(DataBinder.Eval(Container.DataItem, "ServiceFee")) %>' CssClass="Normal" ID="Label2"/>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Every" HeaderStyle-CssClass="NormalBold">
								<ItemTemplate>
									<asp:Label runat="server" Text='<%#FormatPeriod(DataBinder.Eval(Container.DataItem, "BillingPeriod")) %>' CssClass="Normal" ID="Label3"/>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn HeaderText="Period" DataField="BillingFrequency" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
							<asp:TemplateColumn HeaderText="Trial" HeaderStyle-CssClass="NormalBold">
								<ItemTemplate>
									<asp:Label runat="server" Text='<%#FormatPrice(DataBinder.Eval(Container.DataItem, "TrialFee")) %>' CssClass="Normal" ID="Label4"/>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Every" HeaderStyle-CssClass="NormalBold">
								<ItemTemplate>
									<asp:Label runat="server" Text='<%#FormatPeriod(DataBinder.Eval(Container.DataItem, "TrialPeriod")) %>' CssClass="Normal" ID="Label5"/>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn HeaderText="Period" DataField="TrialFrequency" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="NormalBold" />
							<asp:TemplateColumn HeaderText="Expiry Date" HeaderStyle-CssClass="NormalBold">
								<ItemTemplate>
									<asp:Label runat="server" Text='<%#FormatExpiryDate(DataBinder.Eval(Container.DataItem, "ExpiryDate")) %>' CssClass="Normal" ID="Label1"/>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
					</asp:datagrid>
					<asp:Label id="lblMessage" Runat="server" CssClass="Normal" Visible="False"></asp:Label>
				<P>
					<asp:linkbutton class="CommandButton" id="ReturnButton" runat="server" Text="Return" CausesValidation="False"
						BorderStyle="none"></asp:linkbutton></P>
			</TD>
		</TR>
	</TABLE>
</asp:Panel>
