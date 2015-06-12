<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HoiDapList.ascx.vb" Inherits="PortalQH.HoiDapList" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td height="2"></td>
	</tr>
	<TR>
		<TD class="QH_ColLabel" width="100">Từ ngày</TD>
		<TD width="150"><asp:textbox id="txtTuNgay" Width="80%" MaxLength="10" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgTuNgay" CssClass="QH_IMAGEBUTTON" AlternateText="Ch?n ngày tháng nam" ImageUrl="~/images/calendar.gif"
				runat="server"></asp:image></TD>
		<TD class="QH_ColLabel" width="100">Người nhận</TD>
		<TD width="*" align="right"><asp:dropdownlist id="ddlNguoiGui" CssClass="QH_DropDownList" Runat="server" Width="100"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="100">Ðến ngày</TD>
		<TD width="150"><asp:textbox id="txtDenNgay" Width="80%" MaxLength="10" CssClass="QH_TextBox" Runat="server"></asp:textbox>&nbsp;<asp:image id="imgDenNgay" CssClass="QH_IMAGEBUTTON" AlternateText="Ch?n ngày tháng nam" ImageUrl="~/images/calendar.gif"
				runat="server"></asp:image></TD>
		<TD colspan="2" align="right" width="*"><asp:imagebutton id="btnThucHien" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_ThucHien.gif"></asp:imagebutton></TD>
	</TR>
	<tr>
		<td height="2"></td>
	</tr>
	<TR>
		<TD vAlign="top" align="left" colSpan="7"><asp:datagrid id="dgdDanhSach" Width="100%" CssClass="QH_DataGrid" Runat="server" CellPadding="3"
				AllowPaging="True" autogeneratecolumns="False">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<tr>
		<td colspan="7" height="2"></td>
	</tr>
	<TR>
		<TD colSpan="7" align="right"><asp:imagebutton id="btnThemMoi" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_ThemMoi.gif"></asp:imagebutton>
			<asp:imagebutton id="btnXoa" CssClass="QH_Button" Runat="server" ImageUrl="../../Images/btn_Xoa.gif"></asp:imagebutton>
		</TD>
	</TR>
</TABLE>
