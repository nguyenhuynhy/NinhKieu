<%@ Register TagPrefix="Portal" TagName="Address" Src="~/controls/Address.ascx"%>
<%@ Control language="vb" CodeBehind="EditVendors.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditVendors" %>
<br>
<table cellSpacing="0" cellPadding="4" border="0" summary="Edit Vendors Design Table">
	<tr>
		<td align="top">
			<table cellSpacing="0" cellPadding="0" border="0" summary="Edit Vendors Design Table">
				<tr>
					<td valign="top">
						<table cellSpacing="0" cellPadding="1" border="0" summary="Edit Vendors Design Table">
							<tr vAlign="top">
								<td class="SubHead" width="90"><label for="<%=txtVendorName.ClientID%>">Company:</label></td>
								<td align="left" class="NormalBold" nowrap><asp:textbox id="txtVendorName" runat="server" cssclass="NormalTextBox" width="200px" maxlength="50"
										TabIndex="1"></asp:textbox>&nbsp;*
									<asp:requiredfieldvalidator id="valVendorName" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Company Name Is Required"
										ControlToValidate="txtVendorName"></asp:requiredfieldvalidator></td>
							</tr>
							<tr vAlign="top">
								<td class="SubHead" width="90"><label for="<%=txtFirstName.ClientID%>">First Name:</label></td>
								<td class="NormalBold" nowrap>
									<asp:textbox id="txtFirstName" runat="server" cssclass="NormalTextBox" width="200px" maxlength="50"
										TabIndex="2"></asp:textbox>&nbsp;*
									<asp:requiredfieldvalidator id="valFirstName" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>First Name Is Required"
										ControlToValidate="txtFirstName"></asp:requiredfieldvalidator>
								</td>
							</tr>
							<tr vAlign="top">
								<td class="SubHead" width="90"><label for="<%=txtLastName.ClientID%>">Last Name:</label></td>
								<td class="NormalBold" nowrap>
									<asp:textbox id="txtLastName" runat="server" cssclass="NormalTextBox" width="200px" maxlength="50"
										TabIndex="3"></asp:textbox>&nbsp;*
									<asp:requiredfieldvalidator id="valLastName" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Last Name Is Required"
										ControlToValidate="txtLastName"></asp:requiredfieldvalidator>
								</td>
							</tr>
							<tr vAlign="top">
								<td colSpan="2">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr vAlign="top">
					<td valign="top">
						<portal:address runat="server" id="Address1" />
					</td>
				</tr>
				<tr>
					<td valign="top">
						<table cellSpacing="0" cellPadding="1" border="0" summary="Edit Vendors Design Table">
							<tr vAlign="top">
								<td colSpan="2">&nbsp;</td>
							</tr>
							<tr vAlign="top">
								<td class="SubHead" width="90"><label for="<%=txtEmail.ClientID%>">Email:</label></td>
								<td class="NormalBold" nowrap>
									<asp:textbox id="txtEmail" runat="server" cssclass="NormalTextBox" width="200px" maxlength="50"
										TabIndex="11"></asp:textbox>&nbsp;*
									<asp:requiredfieldvalidator id="valEmail" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Email Is Required"
										ControlToValidate="txtEmail"></asp:requiredfieldvalidator>
								</td>
							</tr>
							<tr vAlign="top">
								<td class="SubHead" width="90"><label for="<%=txtFax.ClientID%>">Fax:</label></td>
								<td><asp:textbox id="txtFax" runat="server" cssclass="NormalTextBox" width="200px" maxlength="50"
										TabIndex="12"></asp:textbox></td>
							</tr>
							<tr vAlign="top">
								<td class="SubHead" width="90"><label for="<%=txtWebsite.ClientID%>">Website:</label></td>
								<td><asp:textbox id="txtWebsite" runat="server" cssclass="NormalTextBox" width="200px" maxlength="100"
										TabIndex="13"></asp:textbox></td>
							</tr>
							<tr id="rowVendor1" runat="server" vAlign="top">
								<td class="SubHead" width="90"><label for="<%=cboLogo.ClientID%>">Logo:</label></td>
								<td>
									<asp:dropdownlist id="cboLogo" runat="server" Width="200px" CssClass="NormalTextBox" DataValueField="Value"
										DataTextField="Text" TabIndex="14"></asp:dropdownlist>&nbsp;
									<asp:HyperLink ID="cmdUpload" Runat="server" CssClass="CommandButton">Upload New File</asp:HyperLink>
								</td>
							</tr>
							<tr id="rowVendor2" runat="server" vAlign="top">
								<td class="SubHead" width="90"><label for="<%=chkAuthorized.ClientID%>">Authorized:</label></td>
								<td><asp:CheckBox ID="chkAuthorized" Runat="server" tabIndex="15"></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
		<td id="colVendor" runat="server" vAlign="top">
			<table cellSpacing="0" cellPadding="0" border="0" summary="Edit Vendors Design Table">
				<tr vAlign="top">
					<td class="SubHead" align="center"><label for="<%=lstClassifications.ClientID%>">Classifications:</label></td>
				</tr>
				<tr vAlign="top">
					<td align="center"><asp:listbox id="lstClassifications" Width="200px" CssClass="NormalTextBox" Runat="server" Rows="10"
							SelectionMode="Multiple" TabIndex="16"></asp:listbox></td>
				</tr>
				<tr vAlign="top">
					<td class="SubHead">&nbsp;</td>
				</tr>
				<tr vAlign="top">
					<td class="SubHead" align="center"><label for="<%=txtKeyWords.ClientID%>">Key Words:</label></td>
				</tr>
				<tr vAlign="top">
					<td align="center"><asp:textbox id="txtKeyWords" Width="200px" CssClass="NormalTextBox" Runat="server" Rows="10"
							TextMode="MultiLine" TabIndex="17"></asp:textbox></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colSpan="2">
			<p><br>
				<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update" BorderStyle="none"></asp:linkbutton>&nbsp;
				<asp:linkbutton class="CommandButton" id="cmdCancel" runat="server" Text="Cancel" BorderStyle="none"
					CausesValidation="False"></asp:linkbutton>&nbsp;
				<asp:linkbutton class="CommandButton" id="cmdDelete" runat="server" Text="Delete" BorderStyle="none"
					CausesValidation="False"></asp:linkbutton></p>
			<asp:panel id="pnlAudit" Runat="server"><SPAN class=Normal>Last Updated By&nbsp;
<asp:label id=lblCreatedBy runat="server"></asp:label>&nbsp;On&nbsp;
<asp:label id=lblCreatedDate runat="server"></asp:label><BR></SPAN><BR>
      <TABLE cellSpacing=0 cellPadding=0 width=500 
      summary="Edit Vendors Design Table">
        <TR vAlign=top>
          <TD class=SubHead width=100>Views:</TD>
          <TD align=center width=320>
<asp:label id=lblViews runat="server" CssClass="Normal"></asp:label></TD></TR>
        <TR vAlign=top>
          <TD class=SubHead width=100>Click Throughs:</TD>
          <TD align=center width=320>
<asp:label id=lblClickThroughs runat="server" CssClass="Normal"></asp:label></TD></TR></TABLE><BR>
			</asp:panel></td>
	</tr>
	<tr>
		<td colSpan="2">
			<asp:PlaceHolder ID="pnlBanners" Runat="server">
				<br>
				<table cellSpacing="0" cellPadding="0" width="100%" summary="Banner Advertising Design Table">
					<tr>
						<td align="left"><span class="Head">Banner Advertising</span>
						</td>
					</tr>
					<tr>
						<td>
							<hr noShade SIZE="1">
						</td>
					</tr>
				</table>
			</asp:PlaceHolder>
		</td>
	</tr>
	<tr>
		<td colSpan="2">
			<asp:PlaceHolder ID="pnlAffiliates" Runat="server">
				<br>
				<table cellSpacing="0" cellPadding="0" width="100%" summary="Affiliate Referrals Design Table">
					<tr>
						<td align="left"><span class="Head">Affiliate Referrals</span>
						</td>
					</tr>
					<tr>
						<td>
							<hr noShade SIZE="1">
						</td>
					</tr>
				</table>
			</asp:PlaceHolder>
		</td>
	</tr>
</table>
