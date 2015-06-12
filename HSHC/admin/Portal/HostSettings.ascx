<%@ Register TagPrefix="Portal" TagName="Skin" Src="~/controls/SkinControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="PortalQH.HostSettings" CodeBehind="HostSettings.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<portal:title id="Title1" runat="server"></portal:title>
<table cellSpacing="0" cellPadding="2" border="0" summary="Host Settings Design Table">
	<tr>
		<td class="SubHead"><label for="<%=txtHostTitle.ClientID%>">Host Title:</label></td>
		<td><asp:textbox id="txtHostTitle" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></td>
	</tr>
	<TR>
		<TD class="SubHead"><label for="<%=txtHostURL.ClientID%>">Host URL:</label></TD>
		<td><asp:textbox id="txtHostURL" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></td>
	</TR>
	<tr>
		<td class="SubHead"><label for="<%=txtHostEmail.ClientID%>">Host Email:</label></td>
		<td><asp:textbox id="txtHostEmail" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<tr>
		<td class="SubHead"><label for="<%=ctlHostSkin.ClientID%>">Host Skin:</label></td>
		<td valign="top"><portal:skin id="ctlHostSkin" runat="server"></portal:skin></td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=ctlHostContainer.ClientID%>">Host Container:</label></td>
		<td valign="top"><portal:skin id="ctlHostContainer" runat="server"></portal:skin></td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=ctlAdminSkin.ClientID%>">Admin Skin:</label></td>
		<td valign="top"><portal:skin id="ctlAdminSkin" runat="server"></portal:skin></td>
	</tr>
	<tr>
		<td class="SubHead"><label for="<%=ctlAdminContainer.ClientID%>">Admin Container:</label></td>
		<td valign="top"><portal:skin id="ctlAdminContainer" runat="server"></portal:skin></td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead" valign="top"><label for="<%=cboProcessor.ClientID%>">Payment Processor:</label></TD>
		<TD align="left">
			<asp:dropdownlist id="cboProcessor" CssClass="NormalTextBox" DataTextField="Description" DataValueField="Code" Width="300" Runat="server"></asp:dropdownlist>
			&nbsp;
			<asp:linkbutton id="cmdProcessor" runat="server" cssclass="CommandButton">Go</asp:linkbutton>
		</TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtUserId.ClientID%>">Processor UserId:</label></TD>
		<TD><asp:textbox id="txtUserId" runat="server" width="300" MaxLength="50" CssClass="NormalTextBox"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtPassword.ClientID%>">Processor Password:</label></TD>
		<TD><asp:textbox id="txtPassword" runat="server" width="300" MaxLength="50" CssClass="NormalTextBox" TextMode="Password"></asp:textbox></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead"><label for="<%=txtHostFee.ClientID%>">Hosting Fee:</label></TD>
		<TD><asp:textbox id="txtHostFee" CssClass="NormalTextBox" runat="server" MaxLength="10" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=cboHostCurrency.ClientID%>">Hosting Currency:</label></TD>
		<TD><asp:DropDownList ID="cboHostCurrency" CssClass="NormalTextBox" DataValueField="Code" DataTextField="Description" Width="300" Runat="server"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtHostSpace.ClientID%>">Hosting Space (MB):</label></TD>
		<TD><asp:textbox id="txtHostSpace" CssClass="NormalTextBox" runat="server" MaxLength="3" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtDemoPeriod.ClientID%>">Demo Period (Days):</label></TD>
		<TD><asp:textbox id="txtDemoPeriod" CssClass="NormalTextBox" runat="server" MaxLength="3" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=chkDemoSignup.ClientID%>">Anonymous Demo Signup?</label></TD>
		<TD><asp:checkbox id="chkDemoSignup" CssClass="NormalTextBox" runat="server"></asp:checkbox></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead"><label for="<%=txtSiteLogBuffer.ClientID%>">Site Log Buffer (Items):</label></TD>
		<TD><asp:textbox id="txtSiteLogBuffer" CssClass="NormalTextBox" runat="server" MaxLength="4" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtSiteLogHistory.ClientID%>">Site Log History (Days):</label></TD>
		<TD><asp:textbox id="txtSiteLogHistory" CssClass="NormalTextBox" runat="server" MaxLength="3" width="300"></asp:textbox></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead"><label for="<%=chkUsersOnline.ClientID%>">Disable Users Online?</label></TD>
		<TD><asp:checkbox id="chkUsersOnline" CssClass="NormalTextBox" runat="server"></asp:checkbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtUsersOnlineTime.ClientID%>">Users Online Time (Minutes):</label></TD>
		<TD><asp:textbox id="txtUsersOnlineTime" CssClass="NormalTextBox" runat="server" MaxLength="3" width="300"></asp:textbox></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead"><label for="<%=txtProxyServer.ClientID%>">Proxy Server:</label></TD>
		<TD><asp:textbox id="txtProxyServer" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtProxyPort.ClientID%>">Proxy Port:</label></TD>
		<TD><asp:textbox id="txtProxyPort" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtProxyUsername.ClientID%>">Proxy Username:</label></TD>
		<TD><asp:textbox id="txtProxyUsername" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtProxyPassword.ClientID%>">Proxy Password:</label></TD>
		<TD><asp:textbox id="txtProxyPassword" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300" TextMode="Password"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtWebRequestTimeout.ClientID%>">Web Request Timeout:</label></TD>
		<TD><asp:textbox id="txtWebRequestTimeout" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead" valign="top"><label for="<%=txtSMTPServer.ClientID%>">SMTP Server:</label></TD>
		<TD align=left>
			<asp:textbox id="txtSMTPServer" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox>
			&nbsp;
			<asp:linkbutton id="cmdEmail" runat="server" cssclass="CommandButton">Test</asp:linkbutton>
			<asp:Label ID="lblEmail" Runat="server" CssClass="NormalRed"></asp:Label>
		</TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtSMTPUsername.ClientID%>">SMTP Username:</label></TD>
		<TD><asp:textbox id="txtSMTPUsername" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtSMTPPassword.ClientID%>">SMTP Password:</label></TD>
		<TD><asp:textbox id="txtSMTPPassword" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300" TextMode="Password"></asp:textbox></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead" valign="top"><label for="<%=txtFileExtensions.ClientID%>">File Upload Extensions:</label></TD>
		<TD><asp:textbox id="txtFileExtensions" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300" TextMode="MultiLine" Rows="3"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=optSkinUpload.ClientID%>">Skin Upload Permission:</label></TD>
		<TD><asp:radiobuttonlist id="optSkinUpload" CssClass="Normal" Runat="server" RepeatDirection="Horizontal"><asp:ListItem Value="G">Host</asp:ListItem><asp:ListItem Value="L">Portal</asp:ListItem></asp:radiobuttonlist></TD>
	</TR>
	<tr><td colspan="2">&nbsp;</td></tr>
	<TR>
		<TD class="SubHead"><label for="<%=txtCache.ClientID%>">Cache Timeout (seconds):</label></TD>
		<TD>
			<asp:textbox id="txtCache" CssClass="NormalTextBox" runat="server" width="300" Columns="10" MaxLength="6"></asp:textbox>
			&nbsp;
			<asp:LinkButton ID="cmdCache" Runat="server" CssClass="CommandButton">Clear</asp:LinkButton>
		</TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=txtEncryptionKey.ClientID%>">Password Encryption Key:</label></TD>
		<TD><asp:textbox id="txtEncryptionKey" CssClass="NormalTextBox" runat="server" MaxLength="256" width="300"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><label for="<%=chkPageTitleVersion.ClientID%>">Disable Version in Page Title?</label></TD>
		<TD><asp:checkbox id="chkPageTitleVersion" CssClass="NormalTextBox" runat="server"></asp:checkbox></TD>
	</TR>
	<TR>
		<TD class="SubHead"><LABEL for="<%=chkUseCustomErrorMessages.ClientID%>">Use Custom Error Messages?</LABEL></TD>
		<TD><ASP:CHECKBOX id="chkUseCustomErrorMessages" CssClass="NormalTextBox" runat="server"></ASP:CHECKBOX></TD>
	</TR>
	<TR>
		<TD colspan="2">&nbsp;</TD>
	</TR>
	<tr>
		<td colSpan="2">
			<asp:linkbutton class="CommandButton" id="cmdUpdate" runat="server" Text="Update"></asp:linkbutton>
		</td>
	</tr>
</table>
<br>
<hr noshade size="1">
<br>
<span class="SubHead">
	<label for="<%=cboUpgrade.ClientID%>">Upgrade Log For Version:</label>
</span>&nbsp;
<asp:DropDownList ID="cboUpgrade" Runat="server" CssClass="NormalTextBox"></asp:DropDownList>&nbsp;
<asp:LinkButton ID="cmdUpgrade" Runat="server" CssClass="CommandButton">Go</asp:LinkButton>
<br>
<br>
<asp:Label ID="lblUpgrade" Runat="server" CssClass="Normal"></asp:Label>
