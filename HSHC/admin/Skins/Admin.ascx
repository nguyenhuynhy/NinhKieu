<%@ Register TagPrefix="dnn" TagName="LinkActions" Src="~/admin/Containers/LinkActions.ascx"%>
<%@ Control language="vb" CodeBehind="Admin.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="PortalQH.Skins.Admin" %>
<table width="100%" border="0" summary="Table for design" id="Table2" style="BORDER-RIGHT:#cccccc 1px dotted; BORDER-TOP:#cccccc 1px dotted; BORDER-LEFT:#cccccc 1px dotted; BORDER-BOTTOM:#cccccc 1px dotted">
	<tr valign="top">
		<td align="left" valign="bottom" width="20%" nowrap>
			<table border="0">
				<tr>
					<td id="CellBefore" runat="server"></td>
					<td nowrap><label class="SubHead" for="<%=dnnActions.ClientID%>">Tab Admin:</label></td>
					<td id="CellAfter" runat="server" nowrap></td>
				</tr>
			</table>
		</td>
		<td align="center" valign="top" nowrap>
			<asp:imagebutton id="cmdHelpShow" alternatetext="Show Module Info" runat="server" visible="False"
				borderwidth="0"></asp:imagebutton>
			<asp:imagebutton id="cmdHelpHide" alternatetext="Hide Module Info" runat="server" visible="False"
				borderwidth="0"></asp:imagebutton>
			&nbsp;
			<label for="<%=cboDesktopModules.ClientID%>">
				<span class="SubHead">Module:</span>
			</label>
			&nbsp;
			<asp:dropdownlist id="cboDesktopModules" runat="server" cssclass="NormalTextBox" datavaluefield="DesktopModuleID"
				datatextfield="FriendlyName" Width="150px"></asp:dropdownlist>
			&nbsp;
			<label for="<%=cboPanes.ClientID%>">
				<span class="SubHead">Pane:</span>
			</label>
			&nbsp;
			<asp:dropdownlist id="cboPanes" runat="server" cssclass="NormalTextBox" Width="80px"></asp:dropdownlist>
			&nbsp;
			<label for="<%=cboAlign.ClientID%>">
				<span class="SubHead">Align:</span>
			</label>
			&nbsp;
			<asp:dropdownlist id="cboAlign" runat="server" CssClass="NormalTextBox">
				<asp:ListItem Value="left">Left</asp:ListItem>
				<asp:ListItem Value="center">Center</asp:ListItem>
				<asp:ListItem Value="right">Right</asp:ListItem>
			</asp:dropdownlist>&nbsp;
		</td>
		<TD vAlign="bottom" noWrap align="right" width="20%">
			<label class="SubHead" for="<%=chkContent.ClientID%>">
<asp:linkbutton id="cmdAdd" runat="server" cssclass="CommandButton">Add</asp:linkbutton>&nbsp;Content</label><asp:checkbox id="chkContent" runat="server" cssclass="SubHead" autopostback="True"></asp:checkbox>
			<label class="SubHead" for="<%=chkPreview.ClientID%>">Preview</label><asp:checkbox id="chkPreview" runat="server" cssclass="SubHead" autopostback="True"></asp:checkbox>
		</TD>
	</tr>
	<tr>
		<td></td>
		<td align="center" valign="top"><asp:label id="lblDescription" runat="server" cssclass="Normal"></asp:label></td>
		<td></td>
	</tr>
</table>
