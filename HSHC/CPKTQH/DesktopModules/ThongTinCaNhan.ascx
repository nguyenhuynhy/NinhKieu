<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinCaNhan.ascx.vb" Inherits="CPKTQH.ThongTinCaNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<table class="QH_Table" id="table1" cellSpacing="0" cellPadding="0" width="96%" border="0">
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Họ và 
			tên <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" EnableViewState="true" runat="server" CssClass="QH_textbox" Width="80%"></asp:textbox><asp:dropdownlist id="ddlGioiTinh" EnableViewState="true" runat="server" CssClass="QH_DropDownList"
				Width="19%">
				<asp:ListItem Value="1" Selected="True">Nam</asp:ListItem>
				<asp:ListItem Value="0">Nữ</asp:ListItem>
			</asp:dropdownlist></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" height="3" rowSpan="1">Ngày 
			sinh <FONT color="#ff0000">*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtNgaySinh" CssClass="QH_TextBox" Width="40%" Runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%">Dân tộc</td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtDanToc" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></td>
		<td class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Số CMND <FONT color="#ff0000">
				*</FONT></td>
		<td class="QH_ColControl" width="35%"><asp:textbox id="txtSoCMND" CssClass="QH_TextBox" Width="40%" Runat="server" MaxLength="20"></asp:textbox></td>
	</tr>
	<tr>
		<td class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Nơi cấp</td>
		<td class="QH_ColControl" width="35%">
			<asp:textbox id="txtNoiCapCMND" Width="100%" CssClass="QH_TextBox" Runat="server"></asp:textbox></td>
		<TD class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Ngày 
			cấp</TD>
		<td class="QH_ColControl" width="35%">
			<asp:textbox id="txtNgayCapCMND" Width="40%" CssClass="QH_TextBox" Runat="server"></asp:textbox></td>
	</tr>
	<TR>
		<TD class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Thường 
			trú <FONT color="#ff0000">*</FONT></TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDiaChiThuongTru" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></TD>
		<TD class="QH_ColLabel" vAlign="middle" width="15%" colSpan="1" rowSpan="1">Chỗ ở 
			hiện nay</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtChoOHienNay" CssClass="QH_TextBox" Width="100%" Runat="server"></asp:textbox></TD>
	</TR>
</table>
