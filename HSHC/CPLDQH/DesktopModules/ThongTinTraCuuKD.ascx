<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuuKD.ascx.vb" Inherits="CPLDQH.ThongTinTraCuuKD" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD class="QH_ColLabel" width="15%">H? tên</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" runat="server" CssClass="QH_Textbox" Width="90%"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="15%">Tình tr?ng</TD>
		<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlTinhTrang" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">S? nhà</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="30%" Runat="server"></asp:textbox>
		<TD class="QH_ColLabel" width="15%">S? biên nh?n</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoBienNhan" CssClass="QH_TextBox" Width="50%" Runat="server"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Ðu?ng</TD>
		<TD class="QH_ColControl"><asp:dropdownlist id="ddlDuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
		<TD class="QH_ColLabel">T? ngày</TD>
		<TD class="QH_ColControl"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgTuNgay" runat="server" CssClass="QH_IMAGEBUTTON" AlternateText="Ch?n ngày tháng nam"
				ImageUrl="~/images/calendar.gif"></asp:image></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Phu?ng</TD>
		<TD class="QH_ColControl"><asp:dropdownlist id="ddlPhuong" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
		<TD class="QH_ColLabel">Ð?n ngày</TD>
		<TD class="QH_ColControl"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgDenNgay" runat="server" CssClass="QH_IMAGEBUTTON" AlternateText="Ch?n ngày tháng nam"
				ImageUrl="~/images/calendar.gif"></asp:image></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Lo?i h? so</TD>
		<TD class="QH_ColControl"><asp:dropdownlist id="ddlLoaiHoSo" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
		<TD class="QH_ColLabel"><asp:label id="lblNgay" runat="server">Ngày công van</asp:label></TD>
		<TD class="QH_ColControl"><asp:textbox id="txtNgayCongVan" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="10"></asp:textbox>
			<asp:image id="imgNgayCongVan" runat="server" CssClass="QH_IMAGEBUTTON" AlternateText="Ch?n ngày tháng nam"
				ImageUrl="~/images/calendar.gif"></asp:image></TD>
	</TR>
	<tr>
		<td colspan="2"></td>
		<td colspan="2" class="QH_ColControl">
			<asp:RadioButtonList id="optLoaiCongVan" Width="305px" runat="server" RepeatDirection="Horizontal">
				<asp:ListItem Value="0" Selected="True">T?t c?</asp:ListItem>
				<asp:ListItem Value="1">B&#225;o c&#225;o d? xu?t</asp:ListItem>
				<asp:ListItem Value="2">C&#244;ng van</asp:ListItem>
			</asp:RadioButtonList></td>
	</tr>
</TABLE>
