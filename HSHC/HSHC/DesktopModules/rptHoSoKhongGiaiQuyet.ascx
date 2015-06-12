<%@ Import Namespace="PortalQH" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="rptHoSoKhongGiaiQuyet.ascx.vb" Inherits="HSHC.rptHoSoKhongGiaiQuyet" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
</SCRIPT>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" class="QH_Table">
	<TR>
		<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
		<TD class="QH_ColControl" width="35%">
			<asp:DropDownList id="ddlLoaiHoSo" runat="server" Width="90%" CssClass="QH_Textbox"></asp:DropDownList></TD>
		<TD width="*"></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">Phường</TD>
		<TD width="35%" class="QH_ColControl">
			<asp:DropDownList id="ddlPhuong" runat="server" Width="90%" CssClass="QH_Textbox"></asp:DropDownList></TD>
		<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
		<TD width="*" class="QH_ColControl">
			<asp:TextBox id="txtTuNgay" runat="server" Width="35%" CssClass="QH_Textbox"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink>
		</TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Đường</TD>
		<TD class="QH_ColControl">
			<asp:DropDownList id="ddlDuong" runat="server" Width="90%" CssClass="QH_Textbox"></asp:DropDownList></TD>
		<TD class="QH_ColLabel">Đến ngày</TD>
		<TD>
			<asp:TextBox id="txtDenNgay" runat="server" Width="35%" CssClass="QH_Textbox"></asp:TextBox>
			&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink><asp:TextBox id="txtLoaiBaoCao" Width="0px" runat="server"></asp:TextBox></TD>
	</TR>
</TABLE>
