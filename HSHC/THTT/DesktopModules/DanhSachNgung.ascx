<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DanhSachNgung.ascx.vb" Inherits="THTT.DanhSachNgung" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
	<TR>
		<TD><asp:label id="lblTieuDe" Runat="server" Width="100%" CssClass="QH_Label_Title">Danh sách hộ ngưng kinh doanh</asp:label></TD>
	</TR>
	<TR>
		<TD align="center" height="3"></TD>
	</TR>
	<TR>
		<TD align="center">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="80%" border="0">
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="QH_ColLabel" width="100">Phường</TD>
								<TD colSpan="4"><asp:dropdownlist id="ddlPhuong" Width="280px" CssClass="QH_DropDownList" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="QH_ColLabel" width="100">Từ ngày<FONT color="#ff0000" size="2">*</FONT></TD>
								<TD width="135"><asp:textbox id="txtTuNgay" Runat="server" Width="65%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
								<TD class="QH_ColLabel" width="80" colSpan="1" rowSpan="1">Đến ngày<FONT color="#ff0000" size="2">*</FONT></TD>
								<TD width="135"><asp:textbox id="txtDenNgay" Runat="server" Width="65%" CssClass="QH_TextBox" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
										<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
									</asp:hyperlink></TD>
								<TD><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Thực hiện</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<tr>
	<TD colspan="3" align="center">
		<table width="95%">
			<tr>
				<td align="right"><asp:Label ID="Label4" Runat="server" CssClass="QH_Label">Số dòng hiển thị</asp:Label>
		<asp:TextBox ID="txtSoDong" Runat="server" AutoPostBack="True" CssClass="QH_TextBox" Width="25px"
			MaxLength="3"></asp:TextBox></td>
			</tr>
		</table>
	</TD>
</tr>
	<TR>
		<TD align=center><asp:datagrid id="dgdDanhSach" CssClass="QH_DataGrid" runat="server" AllowPaging="True" AllowSorting="True" Width="95%">
				<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
				<HeaderStyle CssClass="QH_DataGridHeader"></HeaderStyle>
				<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD>
	</TR>
	<TR>
		<TD height="5"></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="6">
			<asp:linkbutton id="btnIn" runat="server" CssClass="QH_Button">In ra giấy</asp:linkbutton>
		</TD>
	</TR>
</TABLE>
