<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DiaChi.ascx.vb" Inherits="CPKTQH.DiaChi" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
	<TR>
		<TD width="30%" class="QH_ColLabel">Số nhà</TD>
		<TD width="70%"><asp:TextBox ID="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="90%"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" height="20">Đường</TD>
		<TD><asp:DropDownList ID="ddlMaDuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel">Phường</TD>
		<TD><asp:DropDownList ID="ddlMaPhuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
	</TR>
</TABLE>
