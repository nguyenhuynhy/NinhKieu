<%@ Control language="vb" CodeBehind="VendorFeedback.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.VendorFeedback" %>
<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<portal:title runat="server" DisplayTitle="Vendor Feedback" id="Title1" />
<br>
<asp:Label ID="lblMessage" Runat="server" CssClass="Normal"></asp:Label>
<asp:Label ID="lblVendor" Runat="server" CssClass="Head"></asp:Label>
<br>
<asp:Panel ID="pnlFeedback" Runat="server" Visible="False">
<br>
<table cellSpacing="2" cellPadding="0" width="500" summary="Vendor Feedback Design Table">
	<tr vAlign="top">
		<td class="SubHead" width="100"><label for="<%=cboValue.ClientID%>">Experience:</label>&nbsp;</td>
		<td width="320" align="left">
			<asp:DropDownList ID="cboValue" Runat="server" CssClass="NormalTextBox">
				<asp:ListItem Value="1">Positive</asp:ListItem>
				<asp:ListItem Value="-1">Negative</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr vAlign="top">
		<td class="SubHead" width="100"><label for="<%=txtComment.ClientID%>">Comment:</label>&nbsp;</td>
		<td width="320" align="left"><asp:TextBox id="txtComment" runat="server" columns="59" width="500" Rows="15" cssclass="NormalTextBox" TextMode="Multiline"></asp:TextBox></td>
	</tr>
</table>
<p>
	<asp:LinkButton id="cmdUpdate" Text="Update" runat="server" class="CommandButton" BorderStyle="none" />&nbsp;
	<asp:LinkButton id="cmdCancel" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />&nbsp;
	<asp:linkbutton id="cmdDelete" Text="Delete" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" ></asp:linkbutton>										
</p>
</asp:Panel>
<br>
<asp:DataList id="lstFeedback" RepeatColumns="1" runat="server" Width="100%"  summary="Vendor Feedback Design Table">
	<ItemTemplate>
		<table border="0" cellspacing="2" cellpadding="0" width="100%"  summary="Vendor Feedback Design Table">
			<tr>
				<td valign="top" align="left" nowrap>
					<asp:Label ID="lblValue" Runat="server"></asp:Label>
				</td>
				<td valign="top" align="left" nowrap>
					<asp:Label ID="lblDate" Runat="server" CssClass="Normal"></asp:Label>
				</td>
				<td valign="top" align="left" nowrap>
					<asp:Label ID="lblUser" Runat="server" CssClass="Normal"></asp:Label>
				</td>
				<td valign="top" width="100%">&nbsp;</td>
			</tr>
			<tr>
				<td colspan="4">
					<asp:Label ID="lblComment" Runat="server" cssClass="Normal"></asp:Label>
				</td>
			</tr>
		</table>
	</ItemTemplate>
</asp:DataList>
<p>
	<asp:LinkButton id="cmdFeedback" Text="Provide Feedback" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />&nbsp;&nbsp;
	<asp:LinkButton id="cmdBack" Text="Back" CausesValidation="False" runat="server" class="CommandButton" BorderStyle="none" />
</p>
