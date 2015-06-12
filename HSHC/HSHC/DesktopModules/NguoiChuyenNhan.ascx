<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NguoiChuyenNhan.ascx.vb" Inherits="NguoiChuyenNhan" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="48%">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="30%" class="QH_ColLabel">Người chuyển</TD>
					<TD width="70%">
						<asp:DropDownList id="ddlFromNguoi" Width="100%" CssClass="QH_DropDownList" Runat="server"></asp:DropDownList></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="48%">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="30%" class="QH_ColLabel">Người nhận</TD>
					<TD width="70%">
						<asp:DropDownList id="ddlToNguoi" Width="100%" CssClass="QH_DropDownList" Runat="server"></asp:DropDownList></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="4%"></TD>
	</TR>
</TABLE>
