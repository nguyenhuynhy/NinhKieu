<%@ Control language="vb" CodeBehind="WebUpload.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.WebUpload" %>
<br>
<table id="tblUpload" height="151" cellSpacing="0" cellPadding="0" summary="Web Upload Design Table"
	runat="server">
	<tr>
		<td colSpan="2" align="center">
			<asp:Label ID="lblRootType" Runat="server" CssClass="SubHead"></asp:Label>
			&nbsp;&nbsp;
			<asp:Label ID="lblRootFolder" Runat="server" CssClass="Normal"></asp:Label>
		</td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr>
		<td align="center" colSpan="2"><asp:radiobuttonlist id="optFileType" CssClass="NormalTextBox" RepeatDirection="Horizontal" Runat="server" AutoPostBack="True"></asp:radiobuttonlist></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr>
		<td align="center" colSpan="2"><label 
      style="DISPLAY: none" for="<%=cmdBrowse.ClientID%>" 
      >Browse Files</label><INPUT id="cmdBrowse" type="file" size="50" runat="server">&nbsp;&nbsp;<asp:linkbutton id="cmdAdd" CssClass="CommandButton" Runat="server">Add</asp:linkbutton></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr>
		<td align="center" colSpan="2"><label 
      style="DISPLAY: none" for="<%=lstFiles.ClientID%>" 
      >First Files</label><asp:listbox id="lstFiles" CssClass="NormalTextBox" Runat="server" Rows="5" Width="500px"></asp:listbox></td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;</td>
	</tr>
	<tr>
		<td align="left">
			<asp:linkbutton id="cmdRemove" CssClass="CommandButton" Runat="server">Remove</asp:linkbutton>
			&nbsp;&nbsp;
			<asp:CheckBox ID="chkUnzip" Runat="server" CssClass="Normal" Text="Decompress ZIP Files?" TextAlign="Right"></asp:CheckBox>
		</td>
		<td align="right"><asp:linkbutton id="cmdUpload" runat="server" Cssclass="CommandButton">Upload File(s)</asp:linkbutton>&nbsp;&nbsp;<asp:linkbutton id="cmdCancel" runat="server" Cssclass="CommandButton">Cancel</asp:linkbutton></td>
	</tr>
	<tr>
		<td align="left" colSpan="2"><asp:label id="lblMessage" CssClass="Normal" Runat="server" Width="500px" EnableViewState="False"></asp:label><BR>
		</td>
	</tr>
</table>
<table id="tblLogs" cellSpacing="0" cellPadding="0" summary="Custom Module Upload Logs Table"
	runat="server" Visible="False">
	<tr>
		<td>Custom Module Upload Logs</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td><asp:PlaceHolder id="phPaLogs" runat="server"></asp:PlaceHolder></td>
	</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>
			<asp:LinkButton id="cmdReturn" runat="server" CssClass="CommandButton">Return to File Manager</asp:LinkButton></td>
	</tr>
</table>
