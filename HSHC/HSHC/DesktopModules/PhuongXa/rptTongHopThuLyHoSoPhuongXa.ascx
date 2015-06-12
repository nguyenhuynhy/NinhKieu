<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="rptTongHopThuLyHoSoPhuongXa.ascx.vb" Inherits="HSHC.rptTongHopThuLyHoSoPhuongXa" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'>
</script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" class="QH_Table">
	<TR>
		<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
		<TD width="20%" class="QH_ColControl">
			<asp:TextBox id="txtTuNgay" Width="70px" runat="server" CssClass="QH_Textbox"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
		<TD class="QH_ColLabel" width="10%" colSpan="1" rowSpan="1">Đến ngày</TD>
		<TD width="20%" class="QH_ColControl">
			<asp:TextBox id="txtDenNgay" Width="70px" runat="server" CssClass="QH_Textbox"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%"></TD>
		<TD class="QH_ColControl" width="20%"></TD>
		<TD class="QH_ColLabel" width="10%"></TD>
		<TD class="QH_ColControl" width="20%">
			<!--Xoa nut in bao cao do bi du--></TD>
	</TR>
</TABLE>
