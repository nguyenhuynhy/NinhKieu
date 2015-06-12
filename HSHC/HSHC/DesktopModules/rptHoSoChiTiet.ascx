<%@ Control Language="vb" AutoEventWireup="false" Codebehind="rptHoSoChiTiet.ascx.vb" Inherits="HSHC.rptHoSoChiTiet" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" class="QH_Table">
	<TR>
		<TD class="QH_ColLabel" width="20%">Số biên nhận</TD>
		<TD class="QH_ColControl" width="%">
			<asp:TextBox id="txtSoBienNhan" runat="server" Width="35%" CssClass="QH_Textbox"></asp:TextBox></TD>
	</TR>
</TABLE>
