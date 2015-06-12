<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NhapMoiChucNang.ascx.vb" Inherits="PortalQH.NhapMoiChucNang" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript">
function SetItemName()
{
	var ddl;
	var txt;
	for (i = 0; i <= document.forms(0).length-1; i++)
	{
		if (document.forms(0).item(i).id.indexOf('ddlItemCode', 0) > -1)
			
		{	
			ddl = document.forms(0).item(i);
		}
		if (document.forms(0).item(i).id.indexOf('txtItemName', 0) > -1)
		{	
			txt = document.forms(0).item(i);
		}
	}
     txt.value=trim(ddl.value.substring(5,255));
}
</script>
<TABLE class="QH_Table" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD colSpan="3">
			<asp:label id="Label3" CssClass="QH_LabelLeftBold" Runat="server">Nhập mới chức năng</asp:label>
			<asp:textbox id="txtTabCode" CssClass="QH_textbox" Width="30px" runat="server" EnableViewState="true"
				Visible="False"></asp:textbox></TD>
	</TR>
	<tr>
		<TD class="QH_ColLabel" width="30%" height="2">ItemCode</TD>
		<td class="QH_ColControl" width="50%"><asp:dropdownlist id="ddlItemCode" CssClass="QH_DropDownList" runat="server" Width="90%"></asp:dropdownlist></td>
		<TD class="QH_ColControl">
			<asp:TextBox id="txtItemCode" CssClass="QH_Textbox" Width="65%" runat="server"></asp:TextBox></TD>
	<tr>
		<TD class="QH_ColLabel">ItemName</TD>
		<TD class="QH_ColControl" colSpan="2">
			<asp:textbox id="txtItemName" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
	</tr>
	<TR>
		<TD class="QH_ColLabel">Target</TD>
		<TD class="QH_ColControl" colSpan="2">
			<asp:textbox id="txtTarget" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
	<tr>
		<TD class="QH_ColLabel">TargetChild</TD>
		<TD class="QH_ColControl" colSpan="2">
			<asp:textbox id="txtTargetChild" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
	</tr>
	<tr>
		<TD class="QH_ColLabel">MenuOrder</TD>
		<TD class="QH_ColControl" colSpan="2">
			<asp:textbox id="txtMenuOrder" CssClass="QH_textbox" Width="90%" runat="server" EnableViewState="true"></asp:textbox></TD>
	</tr>
</TABLE>
