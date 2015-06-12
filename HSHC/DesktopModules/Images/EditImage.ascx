<%@ Control language="vb" CodeBehind="EditImage.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.EditImage" %>
<br>
<table width="750" cellspacing="0" cellpadding="0" summary="Edit Image Design Table">
	<tr valign="top">
		<td width="120" class="SubHead"><label style="display:none;" for="<%=optInternal.ClientID%>">Select Internal Image</label>
			<asp:RadioButton ID="optInternal" Runat="server" GroupName="ImageType" AutoPostBack="True"></asp:RadioButton>&nbsp;<label for="<%=cboInternal.ClientID%>">Internal Image:</label>
		</td>
		<td class="Normal">
			<asp:dropdownlist id="cboInternal" CssClass="NormalTextBox" runat="server" Width="390" DataValueField="Value" DataTextField="Text"></asp:dropdownlist>&nbsp;
			<asp:HyperLink ID="cmdUpload" Runat="server" CssClass="CommandButton">Upload New File</asp:HyperLink>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label style="display:none;" for="<%=optExternal.ClientID%>">Select External Image</label>
			<asp:RadioButton ID="optExternal" Runat="server" GroupName="ImageType" AutoPostBack="True"></asp:RadioButton>&nbsp;<label for="<%=txtExternal.ClientID%>">External 
			Image:</label>
		</td>
		<td class="Normal">
			<asp:TextBox id="txtExternal" cssclass="NormalTextBox" width="390" Columns="30" runat="server" />
		</td>
	</tr>
	<tr valign="top">
		<td colspan="2">&nbsp;</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtAlt.ClientID%>">Alternate Text:</label></td>
		<td>
			<asp:TextBox id="txtAlt" cssclass="NormalTextBox" Columns="50" runat="server" />
			<asp:RequiredFieldValidator ID="valAltText"  runat=server ControlToValidate="txtAlt" Display="Dynamic" CssClass=""NormalRed" ErrorMessage="<br>Alternate Text Is Required"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtWidth.ClientID%>">Width:</label></td>
		<td>
			<asp:TextBox id="txtWidth" cssclass="NormalTextBox" Columns="50" runat="server" />
			<asp:RegularExpressionValidator id="valWidth" ControlToValidate="txtWidth" ValidationExpression="^[1-9]+[0]*$" Display="Dynamic" CssClass=""NormalRed" ErrorMessage="<br>Width Must Be A Valid Integer" runat="server"/>
		</td>
	</tr>
	<tr valign="top">
		<td class="SubHead"><label for="<%=txtHeight.ClientID%>">Height:</label></td>
		<td>
			<asp:TextBox id="txtHeight" cssclass="NormalTextBox" Columns="50" runat="server" />
			<asp:RegularExpressionValidator id="valHeight" ControlToValidate="txtHeight" ValidationExpression="^[1-9]+[0]*$" Display="Dynamic" CssClass=""NormalRed" ErrorMessage="<br>Height Must Be A Valid Integer" runat="server"/>
		</td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />
	&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
</p>
