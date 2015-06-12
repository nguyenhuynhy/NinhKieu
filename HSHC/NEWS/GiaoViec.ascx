<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GiaoViec.ascx.vb" Inherits="PortalQH.GiaoViec" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td align="center">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" width="100">Loại công việc</TD>
					<TD>&nbsp;<asp:dropdownlist id="ddlLoaiViec" AutoPostBack="true" CssClass="QH_DropDownList" Runat="server" Width="200px">
							<asp:ListItem Value="0" Selected="True">Nhận việc</asp:ListItem>
							<asp:ListItem Value="1">Giao việc</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD class="QH_ColLabel" width="100">Từ ngày</TD>
					<TD width="120">&nbsp;<asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Runat="server" Width="80px" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgTuNgay" CssClass="QH_IMAGEBUTTON" runat="server" ImageUrl="~/images/calendar.gif"
							AlternateText="Chọn ngày tháng năm"></asp:image></TD>
					<TD><asp:linkbutton id="btnThucHien" CssClass="QH_Button" runat="server">Thực hiện</asp:linkbutton></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="100">Người giao việc</TD>
					<TD width="220">&nbsp;<asp:dropdownlist id="ddlNguoiGui" CssClass="QH_DropDownList" Runat="server" Width="200px"></asp:dropdownlist></TD>
					<TD class="QH_ColLabel" width="100">Ðến ngày</TD>
					<TD align="left" width="120">&nbsp;<asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Runat="server" Width="80px" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgDenNgay" CssClass="QH_IMAGEBUTTON" runat="server" ImageUrl="~/images/calendar.gif"
							AlternateText="Chọn ngày tháng năm"></asp:image></TD>
					<TD align="left"></TD>
					<TD align="left"></TD>
				</TR>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td width="100%">
			<table>
				<tr>
					<TD class="QH_LabelMiddleBold" align="center" width="100%">Danh sách công việc</TD>
				</tr>
				<tr>
					<td width="100%">
						<!--<DIV style="TABLE-LAYOUT: fixed; OVERFLOW: scroll; HEIGHT: 300px">-->
						<!--<DIV style="OVERFLOW: scroll; WIDTH: 100%; HEIGHT: 400px">--><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" Runat="server" Width="100%" AllowPaging="True"
							autogeneratecolumns="False">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle CssClass="QH_ActivePage"></PagerStyle>
						</asp:datagrid>
						<!--</DIV>--></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD width="100%"><asp:linkbutton id="btnThemMoi" CssClass="QH_Button" runat="server">Thêm mới</asp:linkbutton>&nbsp;
			<asp:linkbutton id="btnXoa" CssClass="QH_Button" runat="server">Xóa</asp:linkbutton>&nbsp;
			<asp:linkbutton id="btnDuyet" CssClass="QH_Button" runat="server">Duyệt</asp:linkbutton></TD>
	</TR>
</table>
