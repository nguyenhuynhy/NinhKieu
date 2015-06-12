<%@ Control Language="vb" AutoEventWireup="false" Codebehind="PhanQuyenThongKe.ascx.vb" Inherits="THTT.PhanQuyenThongKe" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<TABLE id="Table1" class="QH_TableMain" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%"><asp:Label id="lblTitle" runat="server" CssClass="QH_Label_Title" Width="100%">Phân quyền thống kê</asp:Label></TD>
	</TR>
	<TR>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD align="center">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="70%" border="0">
				<TR>
					<TD width="70%">
						<asp:DropDownList id="ddlLinhVuc" Width="100%" CssClass="QH_DropdownList" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD align="center">
			<asp:CheckBoxList class="QH_LoaiHS" Width="90%" id="cklUser" runat="server" RepeatColumns="4"></asp:CheckBoxList></TD>
	</TR>
	<TR>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD align="center">
			<asp:ImageButton id="btnCapNhat" runat="server" ImageUrl="../../Images/btn_CapNhat.gif" CssClass="QH_Button"></asp:ImageButton>
			<asp:ImageButton id="btnTroVe" runat="server" ImageUrl="../../Images/btn_Trove.gif" CssClass="QH_Button"></asp:ImageButton>
			<asp:TextBox id="txtMaUser" Width="0px" runat="server"></asp:TextBox>
		</TD>
	</TR>
</TABLE>
