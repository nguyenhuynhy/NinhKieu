<%@ Register TagPrefix="Portal" TagName="Title" Src="~/controls/DesktopModuleTitle.ascx"%>
<%@ Control Inherits="PortalQH.SiteLog" CodeBehind="SiteLog.ascx.vb" language="vb" AutoEventWireup="false" Explicit="True" %>
<script language="javascript" src="controls/PopupCalendar.js"></script>
<P align="center">
	<table cellSpacing="2" cellPadding="2" border="0" summary="Site Log Design Table">
		<tr vAlign="top">
			<td class="NormalBold" align="center" vAlign="top">
				<label for="<%=cboReportType.ClientID%>">Report Type:</label>
			</td>
			<td class="NormalBold" align="left">
				<asp:DropDownList ID="cboReportType" Runat="server" DataValueField="Code" DataTextField="Description" CssClass="NormalTextBox"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td class="NormalBold" align="left">
				<label for="<%= txtStartDate.ClientID%>">Start Date:</label>
			</td>
			<td class="NormalBold" align="left">
				<asp:TextBox id="txtStartDate" CssClass="NormalTextBox" runat="server" width="120" Columns="20"></asp:TextBox>&nbsp;
				<asp:HyperLink id="cmdStartCalendar" Runat="server" CssClass="CommandButton">Calendar</asp:HyperLink>
			</td>
		</tr>
		<tr>
			<td class="NormalBold" align="left">
				<label for="<%=txtEndDate.ClientID%>">End Date:</label>
			</td>
			<td class="NormalBold" align="left">
				<asp:TextBox id="txtEndDate" CssClass="NormalTextBox" runat="server" width="120" Columns="20"></asp:TextBox>&nbsp;
				<asp:HyperLink id="cmdEndCalendar" Runat="server" CssClass="CommandButton">Calendar</asp:HyperLink>
			</td>
		</tr>
		<tr>
			<td class="NormalBold" vAlign="top" align="center" colspan="2">
				<asp:LinkButton cssclass="CommandButton" Text="Display" runat="server" ID="cmdDisplay" />&nbsp;&nbsp;
				<asp:LinkButton id="cmdCancel" CssClass="CommandButton" runat="server">Cancel</asp:LinkButton>
			</td>
		</tr>
	</table>
	<br>
	<asp:datagrid id="grdLog" Runat="server" Border="0" CellPadding="4" CellSpacing="4" AutoGenerateColumns="true" HeaderStyle-CssClass="NormalBold" ItemStyle-CssClass="Normal" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:datagrid>
	<br>
</P>
