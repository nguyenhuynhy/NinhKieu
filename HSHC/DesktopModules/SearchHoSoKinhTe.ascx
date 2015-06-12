<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SearchHoSoKinhTe.ascx.vb" Inherits=".SearchHoSoKinhTe" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
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
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtTuNgay" MaxLength="10" Runat="server" Width="70px" CssClass="QH_TextBox"></asp:textbox><asp:hyperlink id="cmdTuNgay" Runat="server" CssClass="CommandButton">
				<asp:image id="imgTuNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
		<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtDenNgay" MaxLength="10" Runat="server" Width="70px" CssClass="QH_TextBox"></asp:textbox><asp:hyperlink id="cmdDenNgay" Runat="server" CssClass="CommandButton">
				<asp:image id="imgDenNgay" CssClass="QH_imageButton" Runat="server" ImageUrl="~/Images/calendar.gif"></asp:image>
			</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%">Số nhà</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtSoNha" Runat="server" Width="90%" CssClass="QH_TextBox"></asp:textbox>
		<TD class="QH_ColLabel" width="15%">Họ tên</TD>
		<TD class="QH_ColControl" width="35%"><asp:textbox id="txtHoTen" runat="server" Width="90%" CssClass="QH_TextBox"></asp:textbox></TD>
	<TR>
		<TD class="QH_ColLabel" width="15%">Phường</TD>
		<TD class="QH_ColControl" width="35%"><cc1:keysortdropdownlist id="ddlPhuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:keysortdropdownlist></TD>
		<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
		<TD class="QH_ColControl" width="35%"><asp:dropdownlist id="ddlLoaiHoSo" Runat="server" Width="90%" CssClass="QH_DropDownList"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%" height="22">Đường</TD>
		<TD class="QH_ColControl" width="35%" height="23"><cc1:keysortdropdownlist id="ddlDuong" runat="server" Width="90%" CssClass="QH_DropDownList"></cc1:keysortdropdownlist></TD>
		<TD class="QH_ColLabel" width="15%" height="23">Số giấy phép</TD>
		<TD class="QH_ColControl" width="35%" height="23"><asp:textbox id="txtSoGiayPhep" runat="server" Width="90%" CssClass="QH_TextBox"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="QH_ColLabel" width="15%" height="10">Số biên nhận</TD>
		<TD class="QH_ColControl" width="35%" height="10"><asp:textbox id="txtSoBienNhan" Runat="server" Width="90%" CssClass="QH_TextBox"></asp:textbox></TD>
		<TD class="QH_ColLabel" width="15%" height="10">Số CMND</TD>
		<TD class="QH_ColControl" width="35%" height="10"><asp:textbox id="txtSoCMND" runat="server" Width="90%" CssClass="QH_TextBox"></asp:textbox></TD>
	</TR>
	<tr>
		<td colSpan="4">&nbsp;</td>
	</tr>
	<tr>
		<td colSpan="4">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="right" width="55%"><asp:linkbutton id="btnTimKiem" runat="server" CssClass="QH_Button">Tìm kiếm</asp:linkbutton></td>
					<td align="right" width="45%"><asp:label id="Label4" Runat="server" CssClass="QH_ColLabel1">Số dòng hiển thị</asp:label><asp:textbox id="txtSoDong" MaxLength="3" Runat="server" Width="50px" CssClass="QH_TextRight"
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
