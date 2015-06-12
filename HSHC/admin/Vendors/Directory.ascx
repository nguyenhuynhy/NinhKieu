<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Codebehind="Directory.ascx.vb" Inherits="PortalQH.ServiceDirectory" %>
<portal:title id="Title1" runat="server" EditText="Edit"></portal:title><asp:panel id="pnlModuleContent" Runat="server">
	<TABLE cellSpacing="0" cellPadding="2" border="0" summary="Directory Design Table">
		<TR>
			<TD class="NormalBold" vAlign="bottom"><label for="<%=txtSearch.ClientID%>">Search:</label></TD>
			<TD vAlign="bottom">
				<asp:TextBox id="txtSearch" Runat="server" Columns="30" MaxLength="200" CssClass="NormalTextBox"></asp:TextBox>
			</TD>
			<TD vAlign="bottom">
				<asp:LinkButton id="lnkSearch" Runat="server" CssClass="CommandButton">Search</asp:LinkButton>
			</TD>
		</TR>
	</TABLE>
	<asp:DataList id="lstVendors" runat="server" CellPadding="4" RepeatColumns="1" summary="Directory Design Table">
		<ItemTemplate>
			<table border="0" summary="Directory Design Table">
				<tr>
					<td colspan="2">
						<asp:HyperLink ID="lnkVendorName" Runat="server" cssClass="NormalBold"></asp:HyperLink>
					</td>
				</tr>
				<tr>
					<td width="50%" valign="top" nowrap>
						<asp:Label ID="lblAddress" Runat="server" CssClass="Normal"></asp:Label>
						<asp:Label ID="lblTelephone" Runat="server" CssClass="Normal"></asp:Label>
						<asp:Label ID="lblFax" Runat="server" CssClass="Normal"></asp:Label>
						<asp:Label ID="lblEmail" Runat="server" CssClass="Normal"></asp:Label>
						<asp:HyperLink ID="lnkWebsite" Runat="server" CssClass="Normal"></asp:HyperLink>
					</td>
					<td width="50%" valign="top" nowrap>
						<asp:Hyperlink ID="lnkMap" Runat="server" CssClass="Normal" Text="Show Map" Visible="False"></asp:Hyperlink>
						<asp:Hyperlink ID="lnkDirections" Runat="server" CssClass="Normal" Text="<br>Get Directions" Visible="False"></asp:Hyperlink>
						<asp:Hyperlink ID="lnkFeedback" Runat="server" CssClass="Normal" Text="<br>Feedback" Visible="False"></asp:Hyperlink>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Hyperlink ID="lnkLogo" Runat="server" CssClass="Normal"></asp:Hyperlink>
					</td>
				</tr>
			</table>
		</ItemTemplate>
	</asp:DataList>
	<TABLE cellSpacing="0" cellPadding="0" border="0" summary="Directory Design Table">
		<TR>
			<TD>
				<asp:LinkButton id="cmdSignup" Runat="server" CssClass="CommandButton">Signup</asp:LinkButton>
			</TD>
		</TR>
	</TABLE>
</asp:panel>
