<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchHoSoNhaDat.ascx.vb" Inherits=".SearchHoSoNhaDat" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="uc" Namespace="PortalQH" Assembly="PortalQH" %>
<%@ Register TagPrefix="cc1" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" Assembly="KeySortDropDownList" %>
<%@ Import Namespace="PortalQH" %>
<uc:combofilter id="ctrlScriptComboFilter" runat="server"></uc:combofilter>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Popupcalendar.js"%>'></script>
<TABLE class="QH_Table" id="Table1" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" CssClass="QH_TextBox" Width="70px" Runat="server" MaxLength="10"></asp:textbox><asp:hyperlink id="cmdTuNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
		<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDenNgay" CssClass="QH_TextBox" Width="70px" Runat="server" MaxLength="10"></asp:textbox><asp:hyperlink id="cmdDenNgay" CssClass="CommandButton" Runat="server">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">Số nhà</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" CssClass="QH_TextBox" Width="90%" Runat="server"></asp:textbox>
		<TD class="QH_ColLabel" width="15%">Họ tên</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" runat="server" CssClass="QH_TextBox" Width="90%"></asp:textbox></TD>
	<TR>
		<TD class="QH_ColLabel" width="15%">Phường</TD>
		<TD class="QH_ColControl" width="35%"><cc1:keysortdropdownlist id="ddlPhuong" runat="server" CssClass="QH_DropDownList" Width="90%"></cc1:keysortdropdownlist></TD>
		<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
		<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLoaiHoSo" CssClass="QH_DropDownList" Width="90%" Runat="server"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%" height="22">Đường</TD>
		<TD class="QH_ColControl" width="35%" height="23"><cc1:keysortdropdownlist id="ddlDuong" runat="server" CssClass="QH_DropDownList" Width="90%"></cc1:keysortdropdownlist></TD>
		<TD class="QH_ColLabel" width="15%" height="23">Số giấy chứng nhận</TD>
		<TD class="QH_ColControl" width="35%" height="23"><asp:textbox id="txtSoGiayPhep" runat="server" CssClass="QH_TextBox" Width="90%"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%" height="10">Số biên nhận</TD>
		<TD class="QH_ColControl" width="35%" height="10"><asp:textbox id="txtSoBienNhan" CssClass="QH_TextBox" Width="90%" Runat="server"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="15%" height="10">Số CMND</TD>
		<TD class="QH_ColControl" width="35%" height="10"><asp:textbox id="txtSoCMND" runat="server" CssClass="QH_TextBox" Width="90%"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%" height="22">Số tờ</TD>
		<TD class="QH_ColControl" width="35%" height="23">
			<asp:textbox id="txtSoTo" runat="server" CssClass="QH_TextBox" Width="90%"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="15%" height="23">Số thửa</TD>
		<TD class="QH_ColControl" width="35%" height="23"><asp:textbox id="txtSoThua" runat="server" CssClass="QH_TextBox" Width="90%"></asp:textbox></TD>
	</TR>
	<tr>
		<td colSpan="4">&nbsp;</td>
	</tr>
	<tr>
		<td colSpan="4">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="right" width="55%"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton></td>
					<td align="right" width="45%"><asp:label id="Label4" CssClass="QH_ColLabel1" Runat="server">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" MaxLength="3" Runat="server" Width="50px" CssClass="QH_TextRight"
							AutoPostBack="True">10</asp:textbox></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colSpan="4">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD colSpan="4"><asp:datagrid id="dgdDanhSach" Runat="server" Width="100%" CssClass="QH_DataGrid" autogeneratecolumns="False"
							AllowSorting="True" AllowPaging="True" CellPadding="3">
							<AlternatingItemStyle CssClass="QH_DatagridAlternation"></AlternatingItemStyle>
							<HeaderStyle CssClass="QH_DatagridHeader"></HeaderStyle>
							<PagerStyle HorizontalAlign="Right" CssClass="QH_ActivePage" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</table>
		</td>
	</tr>
</TABLE>
