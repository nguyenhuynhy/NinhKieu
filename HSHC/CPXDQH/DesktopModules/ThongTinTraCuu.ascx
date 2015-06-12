<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ThongTinTraCuu.ascx.vb" Inherits="CPXD.ThongTinTraCuu" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Import Namespace="PortalQH" %>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/Common.js"%>'></script>
<script language=javascript 
src='<%= Request.ApplicationPath + "/Inc/popcalendar.js"%>'></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD width="100%" valign="top">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="QH_Table">
				<TR>
					<TD class="QH_ColLabel" width="15%">Họ tên</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtHoTen" Width="90%" CssClass="QH_Textbox" runat="server"></asp:TextBox></TD>
					<TD width="15%" class="QH_ColLabel">
						Tình trạng</TD>
					<TD class="QH_ColControl" width="35%"><asp:DropDownList ID="ddlTinhTrang" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Số nhà</TD>
					<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtSoNha" Runat="server" CssClass="QH_TextBox" Width="30%"></asp:TextBox>
					<TD class="QH_ColLabel" width="15%">Số biên nhận</TD>
					<TD class="QH_ColControl" width="35%">
						<asp:TextBox id="txtSoBienNhan" Width="50%" CssClass="QH_TextBox" Runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">
						Đường</TD>
					<TD class="QH_ColControl" width="35%"><asp:DropDownList ID="ddlDuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
					<TD class="QH_ColLabel" width="15%">Từ ngày</TD>
					<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtTuNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="50%"></asp:TextBox>
						&nbsp;<asp:image id="imgTuNgay" runat="server" CssClass="QH_IMAGEBUTTON" ImageUrl="~/images/calendar.gif"
							AlternateText="Chọn ngày tháng năm"></asp:image></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">
						Phường</TD>
					<TD class="QH_ColControl" width="35%"><asp:DropDownList ID="ddlPhuong" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
					<TD class="QH_ColLabel" width="15%">Đến ngày</TD>
					<TD class="QH_ColControl" width="35%"><asp:TextBox ID="txtDenNgay" Runat="server" CssClass="QH_TextBox" MaxLength="10" Width="50%"></asp:TextBox>
						&nbsp;<asp:image id="imgDenNgay" runat="server" CssClass="QH_IMAGEBUTTON" ImageUrl="~/images/calendar.gif"
							AlternateText="Chọn ngày tháng năm"></asp:image></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="15%">Loại hồ sơ</TD>
					<TD class="QH_ColControl" width="35%"><asp:DropDownList ID="ddlLoaiHoSo" Runat="server" CssClass="QH_DropDownList" Width="90%"></asp:DropDownList></TD>
					<td width="15%"></td>
					<td width="35%"></td>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
