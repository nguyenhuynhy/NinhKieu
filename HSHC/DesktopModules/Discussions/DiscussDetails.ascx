<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control language="vb" CodeBehind="DiscussDetails.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.DiscussDetails" %>
<portal:title runat="server" id="Title1" />
<br>
<asp:panel id="EditPanel" Visible="false" runat="server">
<TABLE cellSpacing=0 cellPadding=4 width=750 border=0 Summary="Discuss Details Design Table">
  <TR vAlign=top>
    <TD class=SubHead><label for="<%=TitleField.ClientID%>">Title:</label> </TD>
    <TD rowSpan=4>&nbsp; </TD>
    <TD width=*>
<asp:TextBox id=TitleField runat="server" cssclass="NormalTextBox" width="500" columns="40" maxlength="100"></asp:TextBox><BR>
<asp:RequiredFieldValidator id=valTitleField ErrorMessage="You Must Enter The Title Of The Message" Display="Dynamic" ControlToValidate="TitleField" CssClass="NormalRed" Runat="server"></asp:RequiredFieldValidator></TD></TR>
  <TR vAlign=top>
    <TD class=SubHead><label for="<%=BodyField.ClientID%>">Body:</label> </TD>
    <TD width=*>
<asp:TextBox id=BodyField runat="server" cssclass="NormalTextBox" width="500" columns="59" TextMode="Multiline" Rows="15"></asp:TextBox><BR>
<asp:RequiredFieldValidator id=valBodyField ErrorMessage="You Must Enter The Body Of The Message" Display="Dynamic" ControlToValidate="BodyField" CssClass="NormalRed" Runat="server"></asp:RequiredFieldValidator></TD></TR>
  <TR vAlign=top>
    <TD>&nbsp; </TD>
    <TD>
<asp:LinkButton class=CommandButton id=cmdUpdate runat="server" Text="Submit"></asp:LinkButton>&nbsp; 
<asp:LinkButton class=CommandButton id=cmdCancel runat="server" Text="Cancel" CausesValidation="False"></asp:LinkButton></TD></TR></TABLE>
</asp:panel>
<table ID="tblOriginalMessage" runat="server" width="750" cellspacing="0" cellpadding="4" border="0" Summary="Discuss Details Design Table">
	<tr id="rowOriginalMessage" runat="server" valign="top" visible="false">
		<td>
			<hr noShade SIZE="1">
		</td>
	</tr>
	<tr valign="top">
		<td align="left">
			<table cellSpacing="0" cellPadding="4" width="600" border="0" Summary="Discuss Details Design Table">
				<tr>
					<td class="SubHead" valign="top">Subject:</td>
					<td><asp:Label id="Subject" CssClass="Normal" Width="500" runat="server" /></td>
				</tr>
				<tr>
					<td class="SubHead" valign="top">Author:</td>
					<td><asp:Label id="CreatedByUser" CssClass="Normal" Width="500" runat="server" /></td>
				</tr>
				<tr>
					<td class="SubHead" valign="top">Date:</td>
					<td><asp:Label id="CreatedDate" CssClass="Normal" Width="500" runat="server" /></td>
				</tr>
				<tr>
					<td class="SubHead" valign="top">Body:</td>
					<td><asp:Label id="Body" CssClass="Normal" Width="500" runat="server" /></td>
				</tr>
				<tr>
					<td colspan="2">&nbsp;</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:LinkButton id="cmdCancel2" Text="Cancel" CausesValidation="False" runat="server" class="CommandButton" />&nbsp;
						<asp:LinkButton class="CommandButton" id="cmdReply" runat="server" Text="Reply" CausesValidation="False"></asp:LinkButton>&nbsp;
						<asp:LinkButton class="CommandButton" id="cmdEdit" runat="server" Text="Edit" CausesValidation="False"></asp:LinkButton>&nbsp;
						<asp:LinkButton class="CommandButton" id="cmdDelete" runat="server" Text="Delete" CausesValidation="False"></asp:LinkButton>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
